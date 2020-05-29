Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WS_INSERT_XML_FOOD
    Inherits System.Web.Services.WebService
    Dim db As New LGT_XML_CPNDataContext
    Public rows As Integer
#Region "ใส่Newcode"
    <WebMethod(Description:="อาหารทุกประเภท")>
    Public Function XML_FOOD(ByVal Newcode As String)
        Dim ck_ As String = check_xml_food(Newcode)
        Return ck_
    End Function
    Private Function check_xml_food(ByVal Newcode As String) As String
        Dim ck As String = ""
        Dim Status As String = ""
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim ck_fda_xml As New DAO_XML_FOOD.TB_XML_FOOD_PRODUCT

        If dao_fda_cpn.fields.IDA = 0 Then 'ไม่มี xml ใน ตารางเช็คสถานะ
            ck_fda_xml.GetDataby_Newcode(Newcode) 'เอา Newcode จากตารางพี่บิ๊กไป insert 
            insert_Newcode_tb_keep(Newcode) ' insert Newcode ลงตารางเช็คสถานะ

            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                ck = BUILD_XML_FOOD(Newcode)
                update_status_food(Newcode, ck_fda_xml.fields.groupname)   '
            End If
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                ck = BUILD_XML_FOOD(Newcode)
                update_status_food(Newcode, ck_fda_xml.fields.groupname)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                ck = BUILD_XML_FOOD(Newcode)
                update_status_food(Newcode, ck_fda_xml.fields.groupname)
                'BUILD_XML(Newcode_txt)
                'update_status(Newcode_txt)
                'ElseIf Status = "F" Then
                '    BUILD_XML(Newcode_txt)
                '    update_status_F(Newcode_txt)
            End If
        End If
        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML_FOOD.TB_XML_FOOD_PRODUCT
        dao_fda_cpn.GetDatabyfdpdtno(Newcode)
        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.NewCode
        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.groupname
        dao_fda_cpn_keep.fields.Status = "W"
        dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn_keep.insert()
    End Sub
    Private Function BUILD_XML_FOOD(ByVal Newcode_txt As String)

        Dim cut As String = Newcode_txt.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim IDENTIFY As String
        Dim dt_detail As New DataTable

        'For Each fields As XML_CONFIG In Details
        'Dim HeadName As String = dao_insert.fields.XML_HEADER
        '    Dim BodyName As String = dao_insert.fields.XML_BODY
        '    Dim Paths As String = dao_insert.fields.XML_PATH
        '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString

        Dim dt As New DataTable


        'Try
        'steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @Newcode = '" & Newcode_txt & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()
        'lb_Field_Name.Text = Field_Name
        'lb_Newcode_food.Text = steps & " " & rows.ToString()

        If dt.Rows.Count > 0 Then

            Dim Ms As New MemoryStream
            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
            xmlwriter.WriteStartElement(BodyName)    'FOOD
            'Dim dao As New DAO_DRUG.TB_XML_FRGN

            For Each dr As DataRow In dt.Rows
                groupname = dr("groupname")
                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
                IDENTIFY = dr("IDENTIFY")   'ใส้ใน  คือ detail
                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next
                '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

                'Else

                'End If

            Next
            'xmlwriter.WriteEndElement()    'FOOD/

            'Dim dao_food As New DAO_XML.TB_XML_FOOD
            'dao_food.GetDataby_Newcode(Newcode_dt)
            'xmlwriter.WriteRaw(XML_FOOD_DATA(dao_food.fields.fdpdtno)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

            'xmlwriter.WriteEndElement()   'LGTFOOD/ 
            xmlwriter.WriteEndDocument()
            xmlwriter.Flush()

            'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
            'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
            'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
            'dao_fda_cpn.update()



            If groupname = "FE" Or groupname = "FM" Then

                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                '----------------------BC--------------------------
                Dim pdfBytes As Byte() = clsds.UpLoadImageByte(dao.fields.XML_PATH & Newcode_dt & ".xml")
                Dim pdf_b64 As String = Convert.ToBase64String(pdfBytes)
                Dim ws_blockchain As New BLOCK_APP.WS_BLOCKCHAIN
                Dim ws_fields As New BLOCK_APP.XML_BLOCK
                ws_fields.TR_ID = Newcode_dt 'เลขTRANSATION
                ws_fields.IDENTIFY = IDENTIFY 'เลขนิติบุคคล
                ws_fields.PROCESS_ID = "FOOD" 'เลขนิติบุคคล
                ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
                ws_fields.SOP_STATUS = "8" 'สถานะคำขอนะ
                ws_fields.SYSTEM_ID = "FOOD" 'เลขสารระบบ
                ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
                ws_fields.XML_DATA = pdf_b64 'classxml ข้อมูล
                ws_blockchain.WS_BLOCK_CHAIN(ws_fields)


                Return "success"
                'Return "False"
            Else
                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(dao.fields.XML_PATH & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                '----------------------BC--------------------------
                Dim pdfBytes As Byte() = clsds.UpLoadImageByte(dao.fields.XML_PATH & Newcode_dt & ".xml")
                Dim pdf_b64 As String = Convert.ToBase64String(pdfBytes)
                Dim ws_blockchain As New BLOCK_APP.WS_BLOCKCHAIN
                Dim ws_fields As New BLOCK_APP.XML_BLOCK
                ws_fields.TR_ID = Newcode_dt 'เลขTRANSATION
                ws_fields.IDENTIFY = IDENTIFY 'เลขนิติบุคคล
                ws_fields.PROCESS_ID = "FOOD" 'เลขนิติบุคคล
                ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
                ws_fields.SOP_STATUS = "8" 'สถานะคำขอนะ
                ws_fields.SYSTEM_ID = "FOOD" 'เลขสารระบบ
                ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
                ws_fields.XML_DATA = pdf_b64 'classxml ข้อมูล
                ws_blockchain.WS_BLOCK_CHAIN(ws_fields)

                Return "success"
            End If

        Else
            Return "False"
        End If

        'If dt.Rows.Count > 0 Then

        '    Dim Ms As New MemoryStream
        '    Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
        '    xmlwriter.WriteStartDocument()
        '    xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
        '    xmlwriter.WriteStartElement(BodyName)    'DRUG
        '    'Dim dao As New DAO_DRUG.TB_XML_FRGN

        '    For Each dr As DataRow In dt.Rows

        '        Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
        '        'If Newcode_dt = Newcode_txt Then
        '        For Each dc As DataColumn In dt.Columns
        '            xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
        '        Next
        '        '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

        '        'Else

        '        'End If

        '    Next
        '    xmlwriter.WriteEndElement()    'DRUG/
        '    xmlwriter.WriteEndElement()   'LGTDRUG/ 
        '    xmlwriter.WriteEndDocument()
        '    xmlwriter.Flush()

        '    'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        '    'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
        '    'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
        '    'dao_fda_cpn.update()


        '    Dim byterarrary As Byte() = Ms.ToArray()
        '    Dim oFileStream As System.IO.FileStream
        '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)

        '    oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '    oFileStream.Close()
        '    Ms.Close()

        '    Return "success"
        'Else

        '    Return "False"
        'End If
    End Function

    Private Function XML_FOOD_DATA(ByVal FDPDTNO As String) As String
        Dim dao As New DAO_XML_FOOD.TB_XML_FOOD_EDIT_HISTORY
        dao.GetDataby_FDPDTNO(FDPDTNO)

        Dim xx As New XML_FOOD_LICENSE_HISTORY
        xx.XML_FOOD_EDIT_HISTORY = dao.Details
        Return XML_TO_OBJECT(xx)
    End Function
    Private Function XML_TO_OBJECT(ByVal obb As Object) As String
        Dim mem2 As New MemoryStream()         'เอาค่า xml ที่ได้มาเก็บไว้ใน Memory 

        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8           'เอาค่า xml มาแปลง
        settings.Indent = True
        mem2.Position = 0


        Dim x2 As New XmlSerializer(obb.GetType())

        Using writer As XmlWriter = System.Xml.XmlWriter.Create(mem2, settings)     'แปลง xml ให้อยู่ในรูปแบบ class ที่มันจะเป็นแท๊กฟิลด์เรียงต่อกันลงมา
            mem2.Position = 0                           '
            x2.Serialize(writer, obb)
            writer.Flush()
            writer.Close()
        End Using


        Dim mem As New MemoryStream()
        mem.Write(mem2.GetBuffer(), 0, mem2.Length)
        mem.Position = 0
        'Dim xmlData As String = Encoding.UTF8.GetString(mem.GetBuffer(), 0, mem.Length)

        Dim xmldo As New System.Xml.XmlDocument    '
        xmldo.Load(mem)
        Dim xmldata As String = xmldo.DocumentElement.InnerXml     'เอา xml มาแปลงตัดหัว xml ออก เหลือแต่ใส้xml 
        Return xmldata
    End Function
    Private Sub update_status_food(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_fda_cpn.GetDataby_Newcode(Newcode)

        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 

    Public Function CLASS_TO_XMLTYPE(ByVal cls_xml As DataTable)   'function ไว้แปลง xml ลงไปในtable 
        Dim mem As New MemoryStream()
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim x As New XmlSerializer(cls_xml.GetType())
        Dim abc As String = ""
        Using writer As XmlWriter = XmlWriter.Create(mem, settings)

            x.Serialize(writer, cls_xml)
            writer.Flush()
            writer.Close()
        End Using
        mem.Position = 0
        Dim sr As New StreamReader(mem)
        Dim xml As String = sr.ReadToEnd

        Return XElement.Parse(xml)
    End Function
#End Region
#Region "ใส่เลขสารระบบ"
    <WebMethod(Description:="อาหารทุกประเภท(ส่งเลขสารระบบ)")>
    Public Function XML_FOOD_FDPDTNO(ByVal fdpdtno As String, ByVal IDENTIFY_EDIT As String)
        Dim ck_ As String = check_xml_food_fdpdtno(fdpdtno, IDENTIFY_EDIT)
        Return ck_
    End Function
    Private Function check_xml_food_fdpdtno(ByVal fdpdtno As String, ByVal IDENTIFY_EDIT As String) As String
        Dim des As String
        Dim ck As String = ""
        Dim Status As String = ""
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_fda_cpn.GetDataby_fdp13(fdpdtno)
        Dim ck_fda_xml As New DAO_XML_FOOD.TB_XML_FOOD_PRODUCT

        des = "START FC:XML_FOOD_FDPDTNO"
        des_log(fdpdtno, IDENTIFY_EDIT, des, "สร้าง xml อาหาร")
        Try

            If dao_fda_cpn.fields.IDA = 0 Then 'ไม่มี xml ใน ตารางเช็คสถานะ
                des = "START FC:XML_FOOD_FDPDTNO :check Newcod TB XML_CPN_KEEP_FOOD"
                ck_fda_xml.GetDatabyfdpdtno(fdpdtno) 'เอา Newcode จากตารางพี่บิ๊กไป insert 
                insert_Newcode_tb_keep_fdpdtno(fdpdtno) ' insert Newcode ลงตารางเช็คสถานะ

                If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                    'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                    ck = BUILD_XML_FOOD_FDPDTNO(fdpdtno, IDENTIFY_EDIT)
                    update_status_food_fdpdtno(fdpdtno)   '
                End If
                des = "START FC:XML_FOOD_FDPDTNO :check Newcod TB XML_CPN_KEEP_FOOD success"
            Else
                'เช็คสถานะ ว่าเป็น W หรือ S 
                Status = dao_fda_cpn.fields.Status
                If Status = "W" Then
                    'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                    ck = BUILD_XML_FOOD_FDPDTNO(fdpdtno, IDENTIFY_EDIT)
                    'update_status_food_fdpdtno(fdpdtno)
                ElseIf Status = "S" Then
                    'ไม่ต้องทำอะไร
                    ck = BUILD_XML_FOOD_FDPDTNO(fdpdtno, IDENTIFY_EDIT)
                    'update_status_food_fdpdtno(fdpdtno)
                    'BUILD_XML(Newcode_txt)
                    'update_status(Newcode_txt)
                    'ElseIf Status = "F" Then
                    '    BUILD_XML(Newcode_txt)
                    '    update_status_F(Newcode_txt)
                End If
            End If
            des = "START FC:XML_FOOD_FDPDTNO : create xml success"
            des_log(fdpdtno, IDENTIFY_EDIT, des, "สร้าง xml อาหาร")
        Catch ex As Exception
            Dim title As String
        Dim Content As String
            title = "ERROR การสร้าง xml ยาที่ WS_INSERT_XML_CPN " & fdpdtno
            des_log(fdpdtno, IDENTIFY_EDIT, des, ex.Message)
            Content = fdpdtno & " : " & des

            SendMail(Content, "supaporn.s@fsa.co.th", title) 'ทราย
        End Try
        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Sub insert_Newcode_tb_keep_fdpdtno(ByVal fdpdtno As String)
        Dim dao_fda_cpn As New DAO_XML_FOOD.TB_XML_FOOD_PRODUCT
        dao_fda_cpn.GetDatabyfdpdtno(fdpdtno)
        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.NewCode
        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.groupname
        dao_fda_cpn_keep.fields.Status = "W"
        dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn_keep.fields.fdpdtno = dao_fda_cpn.fields.fdpdtno
        dao_fda_cpn_keep.insert()
    End Sub
    Private Function BUILD_XML_FOOD_FDPDTNO(ByVal fdpdtno As String, ByVal IDENTIFY_EDIT As String)
        Dim dao_fda_food As New DAO_XML_FOOD.TB_XML_FOOD_PRODUCT
        dao_fda_food.GetDatabyfdpdtno(fdpdtno)
        Dim NewCode As String = dao_fda_food.fields.NewCode
        Dim cut As String = NewCode.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim IDENTIFY As String
        Dim dt_detail As New DataTable

        'For Each fields As XML_CONFIG In Details
        'Dim HeadName As String = dao_insert.fields.XML_HEADER
        '    Dim BodyName As String = dao_insert.fields.XML_BODY
        '    Dim Paths As String = dao_insert.fields.XML_PATH
        '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString

        Dim dt As New DataTable


        'Try
        'steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @Newcode = '" & dao_fda_food.fields.NewCode & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()
        'lb_Field_Name.Text = Field_Name
        'lb_Newcode_food.Text = steps & " " & rows.ToString()

        If dt.Rows.Count > 0 Then

            Dim Ms As New MemoryStream
            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
            xmlwriter.WriteStartElement(BodyName)    'FOOD
            'Dim dao As New DAO_DRUG.TB_XML_FRGN

            For Each dr As DataRow In dt.Rows
                groupname = dr("groupname")
                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
                'IDENTIFY = dr("IDENTIFY")   'ใส้ใน  คือ detail
                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next
                '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

                'Else

                'End If

            Next
            'xmlwriter.WriteEndElement()    'FOOD/

            'Dim dao_food As New DAO_XML.TB_XML_FOOD
            'dao_food.GetDataby_Newcode(Newcode_dt)
            'xmlwriter.WriteRaw(XML_FOOD_DATA(dao_food.fields.fdpdtno)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

            'xmlwriter.WriteEndElement()   'LGTFOOD/ 
            xmlwriter.WriteEndDocument()
            xmlwriter.Flush()

            'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
            'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
            'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
            'dao_fda_cpn.update()



            If groupname = "FE" Or groupname = "FM" Then

                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()

                ''----------------------BC--------------------------
                'Dim pdfBytes As Byte() = clsds.UpLoadImageByte(dao.fields.XML_PATH & Newcode_dt & ".xml")
                'Dim pdf_b64 As String = Convert.ToBase64String(pdfBytes)
                'Dim ws_blockchain As New BLOCK_APP.WS_BLOCKCHAIN
                'Dim ws_fields As New BLOCK_APP.XML_BLOCK
                'ws_fields.TR_ID = Newcode_dt 'เลขTRANSATION
                'ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคล
                'ws_fields.PROCESS_ID = "FOOD" 'เลขนิติบุคคล
                'ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
                'ws_fields.SOP_STATUS = "8" 'สถานะคำขอนะ
                'ws_fields.SYSTEM_ID = "FOOD" 'เลขสารระบบ
                'ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
                'ws_fields.XML_DATA = pdf_b64 'classxml ข้อมูล
                'ws_blockchain.WS_BLOCK_CHAIN(ws_fields)

                update_status_food_fdpdtno(fdpdtno)
                insert_Newcode_tb_temp_fdpdtno(fdpdtno)
                delete_fdpdtno(fdpdtno)
                Return "success"
                'Return "False"
            Else
                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(dao.fields.XML_PATH & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()

                '----------------------BC--------------------------
                Dim pdfBytes As Byte() = clsds.UpLoadImageByte(dao.fields.XML_PATH & Newcode_dt & ".xml")
                Dim pdf_b64 As String = Convert.ToBase64String(pdfBytes)
                Dim ws_blockchain As New BLOCK_APP.WS_BLOCKCHAIN
                Dim ws_fields As New BLOCK_APP.XML_BLOCK
                ws_fields.TR_ID = Newcode_dt 'เลขTRANSATION
                ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคล
                ws_fields.PROCESS_ID = "FOOD" 'เลขนิติบุคคล
                ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
                ws_fields.SOP_STATUS = "8" 'สถานะคำขอนะ
                ws_fields.SYSTEM_ID = "FOOD" 'เลขสารระบบ
                ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
                ws_fields.XML_DATA = pdf_b64 'classxml ข้อมูล
                ws_blockchain.WS_BLOCK_CHAIN(ws_fields)

                update_status_food_fdpdtno(fdpdtno)
                insert_Newcode_tb_temp_fdpdtno(fdpdtno)
                delete_fdpdtno(fdpdtno)
                Return "success"
            End If

        Else
            Return "False"
        End If

        'If dt.Rows.Count > 0 Then

        '    Dim Ms As New MemoryStream
        '    Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
        '    xmlwriter.WriteStartDocument()
        '    xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
        '    xmlwriter.WriteStartElement(BodyName)    'DRUG
        '    'Dim dao As New DAO_DRUG.TB_XML_FRGN

        '    For Each dr As DataRow In dt.Rows

        '        Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
        '        'If Newcode_dt = Newcode_txt Then
        '        For Each dc As DataColumn In dt.Columns
        '            xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
        '        Next
        '        '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

        '        'Else

        '        'End If

        '    Next
        '    xmlwriter.WriteEndElement()    'DRUG/
        '    xmlwriter.WriteEndElement()   'LGTDRUG/ 
        '    xmlwriter.WriteEndDocument()
        '    xmlwriter.Flush()

        '    'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        '    'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
        '    'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
        '    'dao_fda_cpn.update()


        '    Dim byterarrary As Byte() = Ms.ToArray()
        '    Dim oFileStream As System.IO.FileStream
        '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)

        '    oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '    oFileStream.Close()
        '    Ms.Close()

        '    Return "success"
        'Else

        '    Return "False"
        'End If
    End Function

    Private Function XML_FOOD_DATA_FDPDTNO(ByVal FDPDTNO As String) As String
        Dim dao As New DAO_XML_FOOD.TB_XML_FOOD_EDIT_HISTORY
        dao.GetDataby_FDPDTNO(FDPDTNO)

        Dim xx As New XML_FOOD_LICENSE_HISTORY
        xx.XML_FOOD_EDIT_HISTORY = dao.Details
        Return XML_TO_OBJECT_FDPDTNO(xx)
    End Function
    Private Function XML_TO_OBJECT_FDPDTNO(ByVal obb As Object) As String
        Dim mem2 As New MemoryStream()         'เอาค่า xml ที่ได้มาเก็บไว้ใน Memory 

        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8           'เอาค่า xml มาแปลง
        settings.Indent = True
        mem2.Position = 0


        Dim x2 As New XmlSerializer(obb.GetType())

        Using writer As XmlWriter = System.Xml.XmlWriter.Create(mem2, settings)     'แปลง xml ให้อยู่ในรูปแบบ class ที่มันจะเป็นแท๊กฟิลด์เรียงต่อกันลงมา
            mem2.Position = 0                           '
            x2.Serialize(writer, obb)
            writer.Flush()
            writer.Close()
        End Using


        Dim mem As New MemoryStream()
        mem.Write(mem2.GetBuffer(), 0, mem2.Length)
        mem.Position = 0
        'Dim xmlData As String = Encoding.UTF8.GetString(mem.GetBuffer(), 0, mem.Length)

        Dim xmldo As New System.Xml.XmlDocument    '
        xmldo.Load(mem)
        Dim xmldata As String = xmldo.DocumentElement.InnerXml     'เอา xml มาแปลงตัดหัว xml ออก เหลือแต่ใส้xml 
        Return xmldata
    End Function

    Private Sub update_status_food_fdpdtno(ByVal fdpdtno As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_fda_cpn.GetDataby_fdp13(fdpdtno)

        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
    Private Sub insert_Newcode_tb_temp_fdpdtno(ByVal fdpdtno As String)

        Dim dao_food As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_food.GetDataby_fdp13(fdpdtno)
        Dim dao_food_temp As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD_TEMP
        dao_food_temp.GetDataby_fdp13(fdpdtno)

        If dao_food_temp.fields.fdpdtno <> fdpdtno Then  'ถ้าไม่มีข้อมูลเพิ่มเลขสารระบบเข้าตาราง temp 
            dao_food_temp.fields.Newcode = dao_food.fields.Newcode
            dao_food_temp.fields.groupname = dao_food.fields.groupname
            dao_food_temp.fields.Status = dao_food.fields.Status
            dao_food_temp.fields.CREATE_DATE_INSERT_XML = DateTime.Now   'วันที่ xml เข้ามาตอนแรก
            dao_food_temp.fields.CREATE_DATE = dao_food.fields.CREATE_DATE 'วันที่ สร้างxml เสร็จ
            dao_food_temp.fields.fdpdtno = dao_food.fields.fdpdtno
            dao_food_temp.fields.lctlcnno = dao_food.fields.lctlcnno
            dao_food_temp.insert()
        Else  'ถ้ามีเลขนั้นๆในตาราง temp แล้วให้อัพเดทสถานะกับวันที่สร้างxml
            dao_food_temp.fields.Status = "S"
            dao_food_temp.fields.CREATE_DATE = DateTime.Now
            dao_food_temp.update()
        End If
    End Sub
    Private Sub delete_fdpdtno(ByVal fdpdtno As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
        dao_fda_cpn.GetDataby_fdp13(fdpdtno)
        dao_fda_cpn.delete()
    End Sub
    Public Function CLASS_TO_XMLTYPE_FDPDTNO(ByVal cls_xml As DataTable)   'function ไว้แปลง xml ลงไปในtable 
        Dim mem As New MemoryStream()
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim x As New XmlSerializer(cls_xml.GetType())
        Dim abc As String = ""
        Using writer As XmlWriter = XmlWriter.Create(mem, settings)

            x.Serialize(writer, cls_xml)
            writer.Flush()
            writer.Close()
        End Using
        mem.Position = 0
        Dim sr As New StreamReader(mem)
        Dim xml As String = sr.ReadToEnd

        Return XElement.Parse(xml)
    End Function
    Private Sub des_log(ByVal fdpdtno As String, ByVal IDENTIFY_EDIT As String, ByVal des As String, ByVal remark As String)
        'ใคร(เลขบัตรใคร) IDENTIFY_EDIT
        'ทำอะไร(remark)  remark
        'ที่ไหน(ระบบไหนsystem) system
        'เมื่อไร(เวลา) 
        'อย่างไร(ขั้นตอน) des
        Dim dao_log As New DAO_XML_FOOD.TB_tb_log_temp_food
        With dao_log
            .fields.fdpdtno = fdpdtno
            .fields.system = "สร้าง xml จาก WS_INSERT_XML_CPN"
            .fields.log_des = des 'รายละเอียดแต่ละขั้นตอน
            .fields.remark = remark 'แก้ไขอะไร
            .fields.IDENTIFY_EDIT = IDENTIFY_EDIT 'เลขจากใครที่แก้ไข
            .fields.log_date = Date.Now  'เข้ามาเมื่อไร
            .insert()
        End With
    End Sub
    Public Sub SendMail(ByVal Content As String, ByVal email As String, ByVal title As String)
        Dim mm As New WS_MAIL.FDA_MAIL
        Dim mcontent As New WS_MAIL.Fields_Mail
        mcontent.EMAIL_CONTENT = Content
        mcontent.EMAIL_FROM = "fda_info@fda.moph.go.th"
        mcontent.EMAIL_PASS = "deeku181"
        mcontent.EMAIL_TILE = title
        mcontent.EMAIL_TO = email
        mm.SendMail(mcontent)
    End Sub
#End Region
#Region "ใส่lctlcnno(เลขสถานที่อาหาร)"
    <WebMethod(Description:="อาหารทุกประเภท(ใส่เลขสถานที่อาหาร)")>
    Public Function XML_FOOD_LCTLCNNO(ByVal lctlcnno As String)
        Dim ck_ As String = "success"
        BUILD_XML_FOOD_LCTLCNNO_FE(lctlcnno)
        BUILD_XML_FOOD_LCTLCNNO_FM(lctlcnno)
        BUILD_XML_FOOD_LCTLCNNO_FG(lctlcnno)
        BUILD_XML_FOOD_LCTLCNNO_FL(lctlcnno)
        BUILD_XML_FOOD_LCTLCNNO_FR(lctlcnno)
        Return ck_
    End Function

    Private Function BUILD_XML_FOOD_LCTLCNNO_FE(ByVal lctlcnno As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("FE_lctlcnno", "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim dt_detail As New DataTable
        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim dt As New DataTable
        Dim dt_lct As New DataTable

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @lctlcnno = '" & lctlcnno & "'"
        dt_lct = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'dt_lct = bao_food_fg.SP_XML_SPECIFIC_FOOD_lct(lctlcnno)
        rows = dt.Rows.Count()
        'Dim Ms As New MemoryStream
        For Each dr2 As DataRow In dt_lct.Rows
            Newcode_dt = dr2("Newcode")   'ใส้ใน  คือ detail

            'dt = bao_food_fg.SP_XML_SPECIFIC_FOOD(Newcode_dt)

            'For Each dr As DataRow In dt.Rows

            If dt_lct.Rows.Count > 0 Then

                Dim Ms As New MemoryStream
                Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
                xmlwriter.WriteStartElement(BodyName)    'FOOD
                'Dim dao As New DAO_DRUG.TB_XML_FRGN


                groupname = dr2("groupname")

                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt_lct.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
                Next

                xmlwriter.WriteEndElement()    'FOOD/
                xmlwriter.WriteEndElement()   'LGTFOOD/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()



                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                'Return "success"
                'Return "False"


            Else

                Return "False"
            End If

        Next

        'Next

        Return "success"
    End Function
    Private Function BUILD_XML_FOOD_LCTLCNNO_FM(ByVal lctlcnno As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("FM_lctlcnno", "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim dt_detail As New DataTable
        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim dt As New DataTable
        Dim dt_lct As New DataTable

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @lctlcnno = '" & lctlcnno & "'"
        dt_lct = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'dt_lct = bao_food_fg.SP_XML_SPECIFIC_FOOD_lct(lctlcnno)
        rows = dt.Rows.Count()
        'Dim Ms As New MemoryStream
        For Each dr2 As DataRow In dt_lct.Rows
            Newcode_dt = dr2("Newcode")   'ใส้ใน  คือ detail

            'dt = bao_food_fg.SP_XML_SPECIFIC_FOOD(Newcode_dt)

            'For Each dr As DataRow In dt.Rows

            If dt_lct.Rows.Count > 0 Then

                Dim Ms As New MemoryStream
                Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
                xmlwriter.WriteStartElement(BodyName)    'FOOD
                'Dim dao As New DAO_DRUG.TB_XML_FRGN


                groupname = dr2("groupname")

                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt_lct.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
                Next

                xmlwriter.WriteEndElement()    'FOOD/
                xmlwriter.WriteEndElement()   'LGTFOOD/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()


                Dim byterarrary As Byte() = Ms.ToArray()
                    Dim oFileStream As System.IO.FileStream
                    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                    oFileStream.Close()
                    Ms.Close()
                    'Return "success"
                    'Return "False"


                Else
                Return "False"
            End If

        Next

        'Next

        Return "success"
    End Function
    Private Function BUILD_XML_FOOD_LCTLCNNO_FG(ByVal lctlcnno As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("FG_lctlcnno", "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim dt_detail As New DataTable
        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim dt As New DataTable
        Dim dt_lct As New DataTable

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @lctlcnno = '" & lctlcnno & "'"
        dt_lct = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'dt_lct = bao_food_fg.SP_XML_SPECIFIC_FOOD_lct(lctlcnno)
        rows = dt.Rows.Count()
        'Dim Ms As New MemoryStream
        For Each dr2 As DataRow In dt_lct.Rows
            Newcode_dt = dr2("Newcode")   'ใส้ใน  คือ detail

            'dt = bao_food_fg.SP_XML_SPECIFIC_FOOD(Newcode_dt)

            'For Each dr As DataRow In dt.Rows

            If dt_lct.Rows.Count > 0 Then

                Dim Ms As New MemoryStream
                Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
                xmlwriter.WriteStartElement(BodyName)    'FOOD
                'Dim dao As New DAO_DRUG.TB_XML_FRGN


                groupname = dr2("groupname")

                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt_lct.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
                Next

                xmlwriter.WriteEndElement()    'FOOD/
                xmlwriter.WriteEndElement()   'LGTFOOD/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()


                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                'Return "success"
                'Return "False"



            Else
                Return "False"
            End If

        Next

        'Next

        Return "success"
    End Function
    Private Function BUILD_XML_FOOD_LCTLCNNO_FL(ByVal lctlcnno As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("FL_lctlcnno", "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim dt_detail As New DataTable
        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim dt As New DataTable
        Dim dt_lct As New DataTable

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @lctlcnno = '" & lctlcnno & "'"
        dt_lct = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'dt_lct = bao_food_fg.SP_XML_SPECIFIC_FOOD_lct(lctlcnno)
        rows = dt.Rows.Count()
        'Dim Ms As New MemoryStream
        For Each dr2 As DataRow In dt_lct.Rows
            Newcode_dt = dr2("Newcode")   'ใส้ใน  คือ detail

            'dt = bao_food_fg.SP_XML_SPECIFIC_FOOD(Newcode_dt)

            'For Each dr As DataRow In dt.Rows

            If dt_lct.Rows.Count > 0 Then

                Dim Ms As New MemoryStream
                Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
                xmlwriter.WriteStartElement(BodyName)    'FOOD
                'Dim dao As New DAO_DRUG.TB_XML_FRGN


                groupname = dr2("groupname")

                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt_lct.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
                Next

                xmlwriter.WriteEndElement()    'FOOD/
                xmlwriter.WriteEndElement()   'LGTFOOD/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()


                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                'Return "success"
                'Return "False"



            Else
                Return "False"
            End If

        Next

        'Next

        Return "success"
    End Function
    Private Function BUILD_XML_FOOD_LCTLCNNO_FR(ByVal lctlcnno As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("FR_lctlcnno", "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim dt_detail As New DataTable
        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim dt As New DataTable
        Dim dt_lct As New DataTable

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @lctlcnno = '" & lctlcnno & "'"
        dt_lct = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'dt_lct = bao_food_fg.SP_XML_SPECIFIC_FOOD_lct(lctlcnno)
        rows = dt.Rows.Count()
        'Dim Ms As New MemoryStream
        For Each dr2 As DataRow In dt_lct.Rows
            Newcode_dt = dr2("Newcode")   'ใส้ใน  คือ detail

            'dt = bao_food_fg.SP_XML_SPECIFIC_FOOD(Newcode_dt)

            'For Each dr As DataRow In dt.Rows

            If dt_lct.Rows.Count > 0 Then

                Dim Ms As New MemoryStream
                Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
                xmlwriter.WriteStartElement(BodyName)    'FOOD
                'Dim dao As New DAO_DRUG.TB_XML_FRGN


                groupname = dr2("groupname")

                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt_lct.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
                Next

                xmlwriter.WriteEndElement()    'FOOD/
                xmlwriter.WriteEndElement()   'LGTFOOD/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()


                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                'Return "success"
                'Return "False"



            Else
                Return "False"
            End If

        Next

        'Next

        Return "success"
    End Function
#End Region
#Region "สร้างxmlเฉพาะอาหารFG_FM"
    <WebMethod(Description:="อาหารFM(ใส่วันที่)")>
    Public Function XML_FOOD_DATE_FM(ByVal get_date As String)
        Dim ck_ As String = "success"
        BUILD_XML_FOOD_DATE_FM(get_date)
        Return ck_
    End Function
    <WebMethod(Description:="อาหารFG(ใส่วันที่)")>
    Public Function XML_FOOD_DATE_FG(ByVal get_date As String)
        Dim ck_ As String = "success"
        BUILD_XML_FOOD_DATE_FG(get_date)
        Return ck_
    End Function

    Private Function BUILD_XML_FOOD_DATE_FM(ByVal get_date As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("FM_date", "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim dt_detail As New DataTable
        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim dt As New DataTable
        Dim dt_lct As New DataTable

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @get_date = '" & get_date & "'"
        dt_lct = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'dt_lct = bao_food_fg.SP_XML_SPECIFIC_FOOD_lct(lctlcnno)
        rows = dt.Rows.Count()
        'Dim Ms As New MemoryStream
        For Each dr2 As DataRow In dt_lct.Rows
            Newcode_dt = dr2("Newcode")   'ใส้ใน  คือ detail

            'dt = bao_food_fg.SP_XML_SPECIFIC_FOOD(Newcode_dt)

            'For Each dr As DataRow In dt.Rows

            If dt_lct.Rows.Count > 0 Then

                Dim Ms As New MemoryStream
                Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
                xmlwriter.WriteStartElement(BodyName)    'FOOD
                'Dim dao As New DAO_DRUG.TB_XML_FRGN


                groupname = dr2("groupname")

                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt_lct.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
                Next

                xmlwriter.WriteEndElement()    'FOOD/
                xmlwriter.WriteEndElement()   'LGTFOOD/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()



                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                'Return "success"
                'Return "False"


            Else

                Return "False"
            End If

        Next

        'Next

        Return "success"
    End Function
    Private Function BUILD_XML_FOOD_DATE_FG(ByVal get_date As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("FG_date", "1")

        'dao_insert.GetDataby_IDA(FOOD)
        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL

        Dim b As String = ""
        Dim Newcode_dt As String
        Dim groupname As String
        Dim dt_detail As New DataTable
        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim dt As New DataTable
        Dim dt_lct As New DataTable

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @get_date = '" & get_date & "'"
        dt_lct = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'dt_lct = bao_food_fg.SP_XML_SPECIFIC_FOOD_lct(lctlcnno)
        rows = dt.Rows.Count()
        'Dim Ms As New MemoryStream
        For Each dr2 As DataRow In dt_lct.Rows
            Newcode_dt = dr2("Newcode")   'ใส้ใน  คือ detail

            'dt = bao_food_fg.SP_XML_SPECIFIC_FOOD(Newcode_dt)

            'For Each dr As DataRow In dt.Rows

            If dt_lct.Rows.Count > 0 Then

                Dim Ms As New MemoryStream
                Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
                xmlwriter.WriteStartDocument()
                xmlwriter.WriteStartElement(HeadName)   'LGTFOOD 
                xmlwriter.WriteStartElement(BodyName)    'FOOD
                'Dim dao As New DAO_DRUG.TB_XML_FRGN


                groupname = dr2("groupname")

                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt_lct.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
                Next

                xmlwriter.WriteEndElement()    'FOOD/
                xmlwriter.WriteEndElement()   'LGTFOOD/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()



                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                'Return "success"
                'Return "False"


            Else

                Return "False"
            End If

        Next

        'Next

        Return "success"
    End Function


#End Region
End Class
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WS_INSERT_XML_CMT
    Inherits System.Web.Services.WebService
    Dim db As New LGT_XML_CPNDataContext
    Public rows As Integer
    <WebMethod(Description:="เครื่องสำอาง")>
    Public Function XML_CMT(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String) As String
        ' สร้าง xml ยา ที่มีสาร 
        Dim ck_ As String = check_xml_cmt(Newcode, IDENTIFY_EDIT)
        Return ck_
    End Function
    Private Function check_xml_cmt(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String) As String
        Dim ck As String = ""
        Dim type As String
        Dim type_ck As String
        Dim Status As String = ""
        Dim ck_fda_xml As New DAO_XML.TB_XML_CMT
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_CMT
        dao_fda_cpn.GetDataby_Newcode(Newcode)   'ส่ง Newcode เข้ามาเช็คในตารางเช็คสถานะ
        type = dao_fda_cpn.fields.cmtpdpstcd

        If type Is Nothing Then
            Return "False"

        Else
            If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตารางเช็คสถานะ


                insert_Newcode_tb_keep(Newcode) ' insert Newcode ลงตารางเช็คสถานะ
                ck_fda_xml.GetDataby_Newcode(Newcode) 'เอา Newcode จากตารางพี่บิ๊กไป insert 

                If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                    Dim dao_cpn_ck As New DAO_XML_CPN.TB_XML_CPN_KEEP_CMT
                    dao_cpn_ck.GetDataby_Newcode(Newcode)   'ส่ง Newcode เข้ามาเช็คในตารางเช็คสถานะ
                    type_ck = dao_cpn_ck.fields.cmtpdpstcd
                    'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                    ck = BUILD_XML_CMT(Newcode, type_ck, IDENTIFY_EDIT)
                    update_status_cmt(Newcode, ck_fda_xml.fields.Groupname)   '
                End If
            Else
                'เช็คสถานะ ว่าเป็น W หรือ S 
                Status = dao_fda_cpn.fields.Status
                If Status = "W" Then
                    'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                    ck = BUILD_XML_CMT(Newcode, type, IDENTIFY_EDIT)
                    update_status_cmt(Newcode, ck_fda_xml.fields.Groupname)
                ElseIf Status = "S" Then
                    'ไม่ต้องทำอะไร
                    ck = BUILD_XML_CMT(Newcode, type, IDENTIFY_EDIT)
                    update_status_cmt(Newcode, ck_fda_xml.fields.Groupname)
                    'BUILD_XML(Newcode_txt)
                    'update_status(Newcode_txt)
                    'ElseIf Status = "F" Then
                    '    BUILD_XML(Newcode_txt)
                    '    update_status_F(Newcode_txt)
                End If
            End If

        End If

        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Function BUILD_XML_CMT(ByVal Newcode_txt As String, ByVal type As String, ByVal IDENTIFY_EDIT As String)
        Dim type_food As String = "1"
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        Dim type2 As String
        type2 = type.Trim
        dao.GetDataby_GROUPNAME_TYPE(type2, "1")



        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL
        Dim b As String = ""
        Dim Newcode_dt As String
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
        'ถ้าเป็น type 1ส่งไป sto type 1 
        If type2.Trim = "1" Then
            'dt = bao_food_fg.SP_CPN_SPECIFIC_CMT_TYPE_1(Newcode_txผt)
            dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        ElseIf type2.Trim = "2" Then
            dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
            'dt = bao_food_fg.SP_CPN_SPECIFIC_CMT_TYPE_2(Newcode_txt)
        ElseIf type2.Trim = "3" Or type.Trim = "6" Then
            dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
            'dt = bao_food_fg.SP_CPN_SPECIFIC_CMT_TYPE_3_6(Newcode_txt)
        ElseIf type2.Trim = "4" Or type.Trim = "5" Then
            dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
            'dt = bao_food_fg.SP_CPN_SPECIFIC_CMT_TYPE_4_5(Newcode_txt)
        ElseIf type2.Trim = "0" Then
            dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
            'dt = bao_food_fg.SP_CPN_SPECIFIC_CMT_TYPE_4_5(Newcode_txt)
        End If

        'dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()
        'lb_Newcode_food.Text = steps & " " & rows.ToString()

        If dt.Rows.Count > 0 Then

            Dim Ms As New MemoryStream
            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement(HeadName)   'LGTCMT
            xmlwriter.WriteStartElement(BodyName)    'CMT
            'Dim dao As New DAO_DRUG.TB_XML_FRGN

            For Each dr As DataRow In dt.Rows

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
            'xmlwriter.WriteEndElement()    'DRUG/

            'Dim dao_cmt As New DAO_XML.TB_XML_CMT
            'dao_cmt.GetDataby_Newcode(Newcode_dt)
            'xmlwriter.WriteRaw(XML_CMT_DATA(dao_cmt.fields.regnos)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

            'xmlwriter.WriteEndElement()   'LGTDRUG/ 
            xmlwriter.WriteEndDocument()
            xmlwriter.Flush()

            'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_CMT
            'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
            'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
            'dao_fda_cpn.update()
            Dim byterarrary As Byte() = Ms.ToArray()
            Dim oFileStream As System.IO.FileStream
            'oFileStream = New System.IO.FileStream("C:\xml\FDA_LICENSE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
            oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
            oFileStream.Write(byterarrary, 0, byterarrary.Length)
            oFileStream.Close()
            Ms.Close()




            Dim pdfBytes As Byte() = clsds.UpLoadImageByte(dao.fields.XML_PATH & Newcode_dt & ".xml")
            Dim pdf_b64 As String = Convert.ToBase64String(pdfBytes)
            Dim ws_blockchain As New BLOCK_APP.WS_BLOCKCHAIN
            Dim ws_fields As New BLOCK_APP.XML_BLOCK
            ws_fields.TR_ID = Newcode_dt 'เลขTRANSATION
            ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคลของคนที่กดสร้าง xml
            ws_fields.PROCESS_ID = "CMT" 'เลขนิติบุคคล
            ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
            ws_fields.SOP_STATUS = "8" 'สถานะคำขอนะ
            ws_fields.SYSTEM_ID = "CMT" 'เลขสารระบบ
            ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
            ws_fields.XML_DATA = pdf_b64 'classxml ข้อมูล
            ws_blockchain.WS_BLOCK_CHAIN(ws_fields)


            Return "success"
        Else
            Return "False"
        End If
    End Function
    Private Function XML_CMT_DATA(ByVal REF_NO As String) As String
        Dim dao As New DAO_XML_CMT.TB_LICENSE_HISTORY_CMT
        dao.GetDataby_REF_NO(REF_NO)

        Dim xx As New XML_CMT_LICENSE_HISTORY
        xx.CMT_LICENSE_HISTORY = dao.Details
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
    Private Sub update_status_cmt(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_CMT
        dao_fda_cpn.GetDataby_Newcode(Newcode)

        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML.TB_XML_CMT
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_CMT
        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.NewCode
        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.Groupname
        dao_fda_cpn_keep.fields.cmtpdpstcd = dao_fda_cpn.fields.cmtpdpstcd
        dao_fda_cpn_keep.fields.cmttypecd = dao_fda_cpn.fields.cmttypecd
        dao_fda_cpn_keep.fields.Status = "W"
        dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn_keep.insert()
    End Sub
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
    Public Function CLASSTOXMLSTR(ByVal cls_rev As Object) 'เอา class มารับ class ที่ส่งเข้ามา
        Dim x2 As New XmlSerializer(cls_rev.GetType())
        Dim settings As New XmlWriterSettings()
        settings.Encoding = Encoding.UTF8
        settings.Indent = True
        Dim mem2 As New MemoryStream()
        Using writer As XmlWriter = XmlWriter.Create(mem2, settings)
            x2.Serialize(writer, cls_rev)
            writer.Flush()
            writer.Close()
        End Using
        Dim B64 As String = ""
        B64 = Convert.ToBase64String(mem2.GetBuffer())
        Return B64
    End Function
#Region "สร้างxml(Newcode_R)(ให้โจ้ใช้)"
    <WebMethod(Description:="เครื่องสำอาง")>
    Public Function XML_CMT_CHEMICAL(ByVal Newcode As String) As String
        'ส่งNewcode มา where หาประเภท 
        Dim ck_ As String = cmt_chemical(Newcode)
        Return ck_
    End Function
    Public Function cmt_chemical(ByVal Newcode_cmt As String)
        Dim str As String
        Try
            Dim paths As String = "C:\XML\LICENSE\" & "CMT_TYPE1"
            Dim Path_XML As String

            Dim dt As New DataTable
            Dim bao_show As New BAO_DRUG.BAO_DRUG
            dt = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_HEAD(Newcode_cmt)
            For Each dr As DataRow In dt.Rows
                Path_XML = paths & "\" & dr("Newcode_cmt") & ".xml" 'สร้างชื่อ XML
                CREATE_CMT_FORMULA1(Path_XML, dr("Newcode_cmt")) 'ทำการสร้าง XML 
            Next
            str = "SUCCESS"
            Return str
        Catch ex As Exception
            str = "FAIL" & ex.Message
            Return str
        End Try
    End Function
    Private Sub CREATE_CMT_FORMULA1(ByVal PATH_XML As String, ByVal Newcode_cmt As String)
        Dim cls_xml As New XML_CMT
        Dim cls_xml2 As New XML_CMT2
        Dim cls_xml3 As New XML_CMT3
        Dim cls_xml4 As New XML_CMT4
        Dim cls_xml6 As New XML_CMT6
        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO

        Dim dt As New DataTable
        Dim bao_show As New BAO_DRUG.BAO_DRUG
        dt = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_HEAD(Newcode_cmt)

        For Each dr As DataRow In dt.Rows

            If dr("cmtpdpstcd") = "1" Then
                cls_xml = Cls_NCT_LCT.gen_xml_XML_CMT_FORMULA1(Newcode_cmt)
                Dim objStreamWriter As New StreamWriter(PATH_XML)
                Dim x As New XmlSerializer(cls_xml.GetType)
                x.Serialize(objStreamWriter, cls_xml)
                objStreamWriter.Close()
            ElseIf dr("cmtpdpstcd") = "2" Then
                cls_xml2 = Cls_NCT_LCT.gen_xml_XML_CMT_FORMULA2(Newcode_cmt)
                Dim objStreamWriter As New StreamWriter(PATH_XML)
                Dim x As New XmlSerializer(cls_xml2.GetType)
                x.Serialize(objStreamWriter, cls_xml2)
                objStreamWriter.Close()
            ElseIf dr("cmtpdpstcd") = "3" Then
                cls_xml3 = Cls_NCT_LCT.gen_xml_XML_CMT_FORMULA3(Newcode_cmt)
                Dim objStreamWriter As New StreamWriter(PATH_XML)
                Dim x As New XmlSerializer(cls_xml3.GetType)
                x.Serialize(objStreamWriter, cls_xml3)
                objStreamWriter.Close()
            ElseIf dr("cmtpdpstcd") = "4" Or dr("cmtpdpstcd") = "5" Then
                cls_xml4 = Cls_NCT_LCT.gen_xml_XML_CMT_FORMULA4(Newcode_cmt)
                Dim objStreamWriter As New StreamWriter(PATH_XML)
                Dim x As New XmlSerializer(cls_xml4.GetType)
                x.Serialize(objStreamWriter, cls_xml4)
                objStreamWriter.Close()
            ElseIf dr("cmtpdpstcd") = "6" Then
                cls_xml6 = Cls_NCT_LCT.gen_xml_XML_CMT_FORMULA6(Newcode_cmt)
                Dim objStreamWriter As New StreamWriter(PATH_XML)
                Dim x As New XmlSerializer(cls_xml6.GetType)
                x.Serialize(objStreamWriter, cls_xml6)
                objStreamWriter.Close()
            End If
        Next


    End Sub
#End Region
End Class
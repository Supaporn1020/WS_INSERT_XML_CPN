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
Public Class WS_INSERT_XML_MDC
    Inherits System.Web.Services.WebService
    Dim db As New LGT_XML_CPNDataContext
    Public rows As Integer

    <WebMethod(Description:="เครื่องมือแพทย์")>
    Public Function XML_MDC(ByVal Newcode As String)
        Dim ck_ As String = check_xml_mdc(Newcode)
        Return ck_
    End Function
    Private Function check_xml_mdc(ByVal Newcode As String) As String
        Dim ck As String = ""
        Dim Status As String = ""
        Dim groupname As String
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        groupname = dao_fda_cpn.fields.groupname
        Dim ck_fda_xml As New DAO_XML_MDC.TB_XML_MDC2

        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง
            ck_fda_xml.GetDataby_Newcode(Newcode)
            insert_Newcode_tb_keep(Newcode) ' insert Newcode ลงตารางเช็คสถานะ

            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                ck = BUILD_XML_MDC(Newcode, groupname)
                update_status(Newcode, ck_fda_xml.fields.GroupName)   '
            End If
            '.Replace("", "d")
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                ck = BUILD_XML_MDC(Newcode, groupname)
                update_status(Newcode, ck_fda_xml.fields.GroupName)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                ck = BUILD_XML_MDC(Newcode, groupname)
                update_status(Newcode, ck_fda_xml.fields.GroupName)
            End If
        End If
        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Function BUILD_XML_MDC(ByVal Newcode_txt As String, ByVal groupname As String)
        Dim cut As String = Newcode_txt.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL


        Dim b As String = ""
        Dim Newcode_dt As String

        Dim lcnsid As String

        Dim dt_detail As New DataTable

        'For Each fields As XML_CONFIG In Details
        'Dim HeadName As String = dao_insert.fields.XML_HEADER
        '    Dim BodyName As String = dao_insert.fields.XML_BODY
        '    Dim Paths As String = dao_insert.fields.XML_PATH
        '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString

        Dim dt As New DataTable

        ''Try
        ''steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
        'Dim bao_food_fg As New BAO_DRUG.BAO_DRUG

        'Dim type1 As String = "1"
        'Dim type2 As String
        'type2 = groupname.Trim
        ''ถ้าเป็น type 1ส่งไป sto type 1 
        'If type2 = "MA" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MA(Newcode_txt)
        'ElseIf type2 = "MC" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MC(Newcode_txt)
        'ElseIf type2 = "MG" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MG(Newcode_txt)
        'ElseIf type2 = "MN" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MN(Newcode_txt)
        'ElseIf type2 = "MR" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MR(Newcode_txt)
        'End If


        ''dt = bao_food_fg.SP_XML_SPECIFIC_MDC(Newcode_txt)
        ''dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'rows = dt.Rows.Count()
        ''lb_Newcode_food.Text = steps & " " & rows.ToString()

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @Newcode = '" & Newcode_txt & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()

        If dt.Rows.Count > 0 Then

            Dim Ms As New MemoryStream
            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
            xmlwriter.WriteStartElement(BodyName)    'DRUG
            'Dim dao As New DAO_DRUG.TB_XML_FRGN

            For Each dr As DataRow In dt.Rows

                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
                groupname = dr("groupname")   'ใส้ใน  คือ detail
                lcnsid = dr("lcnsid")



                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next


                'Else

                'End If



                'xmlwriter.WriteEndElement()    'DRUG/
                'Dim dao_mdc2 As New DAO_XML_MDC.TB_XML_MDC2
                'dao_mdc2.GetDataby_Newcode(Newcode_dt)
                'xmlwriter.WriteRaw(XML_DRUG_DATA(dao_mdc2.fields.LCN_DISPLAY)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA
                'xmlwriter.WriteEndElement()   'LGTDRUG/ 


                xmlwriter.WriteEndDocument()
                    xmlwriter.Flush()





                'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
                'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
                'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
                'dao_fda_cpn.update()

                If groupname = "MN" Then
                        Dim byterarrary As Byte() = Ms.ToArray()
                        Dim oFileStream As System.IO.FileStream
                        'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                        'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MN\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        oFileStream.Write(byterarrary, 0, byterarrary.Length)
                        oFileStream.Close()
                        Ms.Close()
                        Return "success"

                    ElseIf groupname = "MC" Then
                        If lcnsid >= 1 And lcnsid <= 5000 Then
                            Dim byterarrary As Byte() = Ms.ToArray()
                            Dim oFileStream As System.IO.FileStream
                            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\MDC\MC9\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                            'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream.Write(byterarrary, 0, byterarrary.Length)
                            oFileStream.Close()
                            Ms.Close()
                            Return "success"
                        ElseIf lcnsid > 5000 And lcnsid <= 10000 Then
                            Dim byterarrary As Byte() = Ms.ToArray()
                            Dim oFileStream As System.IO.FileStream
                            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                            'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream.Write(byterarrary, 0, byterarrary.Length)
                            oFileStream.Close()
                            Ms.Close()
                            Return "success"
                        ElseIf lcnsid > 10000 And lcnsid <= 15000 Then
                            Dim byterarrary As Byte() = Ms.ToArray()
                            Dim oFileStream As System.IO.FileStream
                            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                            'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream.Write(byterarrary, 0, byterarrary.Length)
                            oFileStream.Close()
                            Ms.Close()
                            Return "success"
                        ElseIf lcnsid > 15000 Then
                            Dim byterarrary As Byte() = Ms.ToArray()
                            Dim oFileStream As System.IO.FileStream
                            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                            'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                            oFileStream.Write(byterarrary, 0, byterarrary.Length)
                            oFileStream.Close()
                            Ms.Close()
                            Return "success"

                        End If

                    ElseIf groupname = "MR" Then
                        Dim byterarrary As Byte() = Ms.ToArray()
                        Dim oFileStream As System.IO.FileStream
                        'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                        'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MR\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        oFileStream.Write(byterarrary, 0, byterarrary.Length)
                        oFileStream.Close()
                        Ms.Close()
                        Return "success"

                    ElseIf groupname = "MA" Then
                        Dim byterarrary As Byte() = Ms.ToArray()
                        Dim oFileStream As System.IO.FileStream
                        'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                        'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MA\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        Dim path As String
                        path = dao.fields.XML_PATH
                        oFileStream = New System.IO.FileStream(Replace(path.Trim, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        oFileStream.Write(byterarrary, 0, byterarrary.Length)
                        oFileStream.Close()
                        Ms.Close()
                        Return "success"
                    ElseIf groupname = "MG" Then
                        Dim byterarrary As Byte() = Ms.ToArray()
                        Dim oFileStream As System.IO.FileStream
                        'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                        'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MG\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                        oFileStream.Write(byterarrary, 0, byterarrary.Length)
                        oFileStream.Close()
                        Ms.Close()
                        Return "success"
                    End If
                Next

            'For Each dr As DataRow In dt.Rows
            '    Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail

            'Next




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
        '        groupname = dr("groupname")   'ใส้ใน  คือ detail
        '        lcnsid = dr("lcnsid")
        '        'If Newcode_dt = Newcode_txt Then
        '        For Each dc As DataColumn In dt.Columns
        '            xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
        '        Next
        '        '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

        '        'Else

        '        'End If


        '        xmlwriter.WriteEndElement()    'DRUG/
        '        xmlwriter.WriteEndElement()   'LGTDRUG/ 
        '        xmlwriter.WriteEndDocument()
        '        xmlwriter.Flush()

        '        'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
        '        'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
        '        'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
        '        'dao_fda_cpn.update()

        '        If groupname = "MN" Then
        '            Dim byterarrary As Byte() = Ms.ToArray()
        '            Dim oFileStream As System.IO.FileStream
        '            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '            oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MN\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '            oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '            oFileStream.Close()
        '            Ms.Close()
        '            Return "success"

        '        ElseIf groupname = "MC" Then
        '            If lcnsid >= 1 And lcnsid <= 5000 Then
        '                Dim byterarrary As Byte() = Ms.ToArray()
        '                Dim oFileStream As System.IO.FileStream
        '                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\MDC\MC9\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '                oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '                oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '                oFileStream.Close()
        '                Ms.Close()
        '                Return "success"
        '            ElseIf lcnsid > 5000 And lcnsid <= 10000 Then
        '                Dim byterarrary As Byte() = Ms.ToArray()
        '                Dim oFileStream As System.IO.FileStream
        '                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '                oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '                oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '                oFileStream.Close()
        '                Ms.Close()
        '                Return "success"
        '            ElseIf lcnsid > 10000 And lcnsid <= 15000 Then
        '                Dim byterarrary As Byte() = Ms.ToArray()
        '                Dim oFileStream As System.IO.FileStream
        '                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '                oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '                oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '                oFileStream.Close()
        '                Ms.Close()
        '                Return "success"
        '            ElseIf lcnsid > 15000 Then
        '                Dim byterarrary As Byte() = Ms.ToArray()
        '                Dim oFileStream As System.IO.FileStream
        '                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '                oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '                oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '                oFileStream.Close()
        '                Ms.Close()
        '                Return "success"

        '            End If

        '        ElseIf groupname = "MR" Then
        '            Dim byterarrary As Byte() = Ms.ToArray()
        '            Dim oFileStream As System.IO.FileStream
        '            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '            oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MR\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '            oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '            oFileStream.Close()
        '            Ms.Close()
        '            Return "success"

        '        ElseIf groupname = "MA" Then
        '            Dim byterarrary As Byte() = Ms.ToArray()
        '            Dim oFileStream As System.IO.FileStream
        '            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '            oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MA\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '            oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '            oFileStream.Close()
        '            Ms.Close()
        '            Return "success"
        '        ElseIf groupname = "MG" Then
        '            Dim byterarrary As Byte() = Ms.ToArray()
        '            Dim oFileStream As System.IO.FileStream
        '            'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        '            oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MG\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        '            oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '            oFileStream.Close()
        '            Ms.Close()
        '            Return "success"
        '        End If
        '    Next

        'Else
        '    Return "False"
        'End If
    End Function
    Private Function XML_DRUG_DATA(ByVal REF_NO As String) As String
        Dim dao As New DAO_XML_MDC.TB_LICENSE_HISTORY
        dao.GetDataby_REF_NO(REF_NO)

        Dim xx As New XML_MDC_LICENSE_HISTORY
        xx.MDC_LICENSE_HISTORY = dao.Details
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
    Private Sub update_status(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
        dao_fda_cpn.GetDataby_Newcode(Newcode)

        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML_MDC.TB_XML_MDC2
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.Newcode
        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.GroupName
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

#Region "ส่งให้พี่อ๊อฟใช้(ส่ง docno(เลขที่ใบสำคัญ) กับ type(ประเภทใบ))"
#Region "MC"
    <WebMethod(Description:="XML_MDC_DOCNO_MC")>
    Public Function XML_MDC_DOCNO_MC(ByVal doc_no As String, ByVal type As String, ByVal rid As String)
        Dim ck_ As String = "success"
        BUILD_XML_MDC_DOCNO_MC(doc_no, type, rid)

        Return ck_
    End Function
    Private Function BUILD_XML_MDC_DOCNO_MC(ByVal doc_no As String, ByVal type As String, ByVal rid As String)

        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("MC_5001", "2")

        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL


        Dim b As String = ""
        Dim Newcode_dt As String

        Dim lcnsid As String

        Dim dt_detail As New DataTable

        'For Each fields As XML_CONFIG In Details
        'Dim HeadName As String = dao_insert.fields.XML_HEADER
        '    Dim BodyName As String = dao_insert.fields.XML_BODY
        '    Dim Paths As String = dao_insert.fields.XML_PATH
        '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString

        Dim dt As New DataTable

        ''Try
        ''steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
        'Dim bao_food_fg As New BAO_DRUG.BAO_DRUG

        'Dim type1 As String = "1"
        'Dim type2 As String
        'type2 = groupname.Trim
        ''ถ้าเป็น type 1ส่งไป sto type 1 
        'If type2 = "MA" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MA(Newcode_txt)
        'ElseIf type2 = "MC" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MC(Newcode_txt)
        'ElseIf type2 = "MG" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MG(Newcode_txt)
        'ElseIf type2 = "MN" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MN(Newcode_txt)
        'ElseIf type2 = "MR" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MR(Newcode_txt)
        'End If


        ''dt = bao_food_fg.SP_XML_SPECIFIC_MDC(Newcode_txt)
        ''dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'rows = dt.Rows.Count()
        ''lb_Newcode_food.Text = steps & " " & rows.ToString()

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @doc_no = '" & doc_no & "',@type = '" & type & "',@rid = '" & rid & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()

        If dt.Rows.Count > 0 Then

            Dim Ms As New MemoryStream
            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
            xmlwriter.WriteStartElement(BodyName)    'DRUG
            'Dim dao As New DAO_DRUG.TB_XML_FRGN

            For Each dr As DataRow In dt.Rows

                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
                'groupname = dr("groupname")   'ใส้ใน  คือ detail
                'lcnsid = dr("lcnsid")



                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next


                'Else

                'End If



                'xmlwriter.WriteEndElement()    'DRUG/
                'Dim dao_mdc2 As New DAO_XML_MDC.TB_XML_MDC2
                'dao_mdc2.GetDataby_Newcode(Newcode_dt)
                'xmlwriter.WriteRaw(XML_DRUG_DATA(dao_mdc2.fields.LCN_DISPLAY)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA
                'xmlwriter.WriteEndElement()   'LGTDRUG/ 


                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()





                'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
                'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
                'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
                'dao_fda_cpn.update()

                'If groupname = "MN" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MN\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"

                'ElseIf groupname = "MC" Then
                'If lcnsid >= 1 And lcnsid <= 5000 Then
                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\MDC\MC9\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                update_status_doc(doc_no, type, "MC", rid)
                insert_Newcode_tb_temp(doc_no, type, "MC", rid)
                Return "success"
                'ElseIf lcnsid > 5000 And lcnsid <= 10000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 10000 And lcnsid <= 15000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 15000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"

                'End If

                'ElseIf groupname = "MR" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MR\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"

                'ElseIf groupname = "MA" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MA\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    Dim path As String
                '    path = dao.fields.XML_PATH
                '    oFileStream = New System.IO.FileStream(Replace(path.Trim, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf groupname = "MG" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MG\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'End If
            Next

            'For Each dr As DataRow In dt.Rows
            '    Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail

            'Next

        Else
            Return "False"
        End If

    End Function
#End Region
#Region "MN"
    <WebMethod(Description:="XML_MDC_DOCNO_MN")>
    Public Function XML_MDC_DOCNO_MN(ByVal doc_no As String, ByVal type As String, ByVal rid As String)
        Dim ck_ As String = "success"
        BUILD_XML_MDC_DOCNO_MN(doc_no, type, rid)
        Return ck_
    End Function
    Private Function BUILD_XML_MDC_DOCNO_MN(ByVal doc_no As String, ByVal type As String, ByVal rid As String)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("MN", "2")

        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL


        Dim b As String = ""
        Dim Newcode_dt As String

        Dim lcnsid As String

        Dim dt_detail As New DataTable

        'For Each fields As XML_CONFIG In Details
        'Dim HeadName As String = dao_insert.fields.XML_HEADER
        '    Dim BodyName As String = dao_insert.fields.XML_BODY
        '    Dim Paths As String = dao_insert.fields.XML_PATH
        '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString

        Dim dt As New DataTable

        ''Try
        ''steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
        'Dim bao_food_fg As New BAO_DRUG.BAO_DRUG

        'Dim type1 As String = "1"
        'Dim type2 As String
        'type2 = groupname.Trim
        ''ถ้าเป็น type 1ส่งไป sto type 1 
        'If type2 = "MA" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MA(Newcode_txt)
        'ElseIf type2 = "MC" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MC(Newcode_txt)
        'ElseIf type2 = "MG" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MG(Newcode_txt)
        'ElseIf type2 = "MN" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MN(Newcode_txt)
        'ElseIf type2 = "MR" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MR(Newcode_txt)
        'End If


        ''dt = bao_food_fg.SP_XML_SPECIFIC_MDC(Newcode_txt)
        ''dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'rows = dt.Rows.Count()
        ''lb_Newcode_food.Text = steps & " " & rows.ToString()

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @doc_no = '" & doc_no & "',@type = '" & type & "',@rid = '" & rid & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()

        If dt.Rows.Count > 0 Then

            Dim Ms As New MemoryStream
            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
            xmlwriter.WriteStartElement(BodyName)    'DRUG
            'Dim dao As New DAO_DRUG.TB_XML_FRGN

            For Each dr As DataRow In dt.Rows

                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
                'groupname = dr("groupname")   'ใส้ใน  คือ detail
                'lcnsid = dr("lcnsid")



                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next


                'Else

                'End If

                'xmlwriter.WriteEndElement()    'DRUG/
                'Dim dao_mdc2 As New DAO_XML_MDC.TB_XML_MDC2
                'dao_mdc2.GetDataby_Newcode(Newcode_dt)
                'xmlwriter.WriteRaw(XML_DRUG_DATA(dao_mdc2.fields.LCN_DISPLAY)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA
                'xmlwriter.WriteEndElement()   'LGTDRUG/ 


                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()

                'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
                'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
                'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
                'dao_fda_cpn.update()

                'If groupname = "MN" Then
                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MN\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                update_status_doc(doc_no, type, "MN", rid)
                insert_Newcode_tb_temp(doc_no, type, "MN", rid)
                Return "success"

                'ElseIf groupname = "MC" Then
                'If lcnsid >= 1 And lcnsid <= 5000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\MDC\MC9\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 5000 And lcnsid <= 10000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 10000 And lcnsid <= 15000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 15000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"

                'End If

                'ElseIf groupname = "MR" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MR\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"

                'ElseIf groupname = "MA" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MA\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    Dim path As String
                '    path = dao.fields.XML_PATH
                '    oFileStream = New System.IO.FileStream(Replace(path.Trim, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf groupname = "MG" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MG\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'End If
            Next

            'For Each dr As DataRow In dt.Rows
            '    Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail

            'Next

        Else
            Return "False"
        End If

    End Function
#End Region
#Region "MR"
    <WebMethod(Description:="XML_MDC_DOCNO_MR")>
    Public Function XML_MDC_DOCNO_MR(ByVal doc_no As String, ByVal type As String, ByVal rid As String)
        Dim ck_ As String = "success"
        BUILD_XML_MDC_DOCNO_MR(doc_no, type, rid)
        Return ck_
    End Function
    Private Function BUILD_XML_MDC_DOCNO_MR(ByVal doc_no As String, ByVal type As String, ByVal rid As String)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        dao.GetDataby_GROUPNAME_TYPE("MR", "2")

        Dim HeadName As String = dao.fields.XML_HEADER
        Dim BodyName As String = dao.fields.XML_BODY
        Dim Paths As String = dao.fields.XML_PATH
        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
        Dim STO_NAME As String = dao.fields.XML_SQL


        Dim b As String = ""
        Dim Newcode_dt As String

        Dim lcnsid As String

        Dim dt_detail As New DataTable

        'For Each fields As XML_CONFIG In Details
        'Dim HeadName As String = dao_insert.fields.XML_HEADER
        '    Dim BodyName As String = dao_insert.fields.XML_BODY
        '    Dim Paths As String = dao_insert.fields.XML_PATH
        '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString

        Dim dt As New DataTable

        ''Try
        ''steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
        'Dim bao_food_fg As New BAO_DRUG.BAO_DRUG

        'Dim type1 As String = "1"
        'Dim type2 As String
        'type2 = groupname.Trim
        ''ถ้าเป็น type 1ส่งไป sto type 1 
        'If type2 = "MA" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MA(Newcode_txt)
        'ElseIf type2 = "MC" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MC(Newcode_txt)
        'ElseIf type2 = "MG" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MG(Newcode_txt)
        'ElseIf type2 = "MN" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MN(Newcode_txt)
        'ElseIf type2 = "MR" Then
        '    dt = bao_food_fg.SP_CPN_CONVERT_MDC_MR(Newcode_txt)
        'End If


        ''dt = bao_food_fg.SP_XML_SPECIFIC_MDC(Newcode_txt)
        ''dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'rows = dt.Rows.Count()
        ''lb_Newcode_food.Text = steps & " " & rows.ToString()

        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @doc_no = '" & doc_no & "',@type = '" & type & "', @rid = '" & rid & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()

        If dt.Rows.Count > 0 Then

            Dim Ms As New MemoryStream
            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
            xmlwriter.WriteStartDocument()
            xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
            xmlwriter.WriteStartElement(BodyName)    'DRUG
            'Dim dao As New DAO_DRUG.TB_XML_FRGN

            For Each dr As DataRow In dt.Rows

                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
                'groupname = dr("groupname")   'ใส้ใน  คือ detail
                'lcnsid = dr("lcnsid")



                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next


                'Else

                'End If

                'xmlwriter.WriteEndElement()    'DRUG/
                'Dim dao_mdc2 As New DAO_XML_MDC.TB_XML_MDC2
                'dao_mdc2.GetDataby_Newcode(Newcode_dt)
                'xmlwriter.WriteRaw(XML_DRUG_DATA(dao_mdc2.fields.LCN_DISPLAY)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA
                'xmlwriter.WriteEndElement()   'LGTDRUG/ 


                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()

                'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
                'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
                'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
                'dao_fda_cpn.update()

                'If groupname = "MN" Then
                'Dim byterarrary As Byte() = Ms.ToArray()
                'Dim oFileStream As System.IO.FileStream
                ''oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                ''oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MN\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                'oFileStream.Write(byterarrary, 0, byterarrary.Length)
                'oFileStream.Close()
                'Ms.Close()
                'Return "success"

                'ElseIf groupname = "MC" Then
                'If lcnsid >= 1 And lcnsid <= 5000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\MDC\MC9\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 5000 And lcnsid <= 10000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 10000 And lcnsid <= 15000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf lcnsid > 15000 Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MC5\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"

                'End If

                'ElseIf groupname = "MR" Then
                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MR\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                update_status_doc(doc_no, type, "MR", rid)
                insert_Newcode_tb_temp(doc_no, type, "MR", rid)
                Return "success"

                'ElseIf groupname = "MA" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MA\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    Dim path As String
                '    path = dao.fields.XML_PATH
                '    oFileStream = New System.IO.FileStream(Replace(path.Trim, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'ElseIf groupname = "MG" Then
                '    Dim byterarrary As Byte() = Ms.ToArray()
                '    Dim oFileStream As System.IO.FileStream
                '    'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MG\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                '    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                '    oFileStream.Close()
                '    Ms.Close()
                '    Return "success"
                'End If
            Next

            'For Each dr As DataRow In dt.Rows
            '    Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail

            'Next

        Else
            Return "False"
        End If

    End Function
#End Region
    Private Sub update_status_doc(ByVal doc_no As String, ByVal type As String, ByVal groupname As String, ByVal rid As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
        Dim dao_fda_mdc As New DAO_XML_MDC.TB_XML_MDC2
        dao_fda_mdc.GetDataby_doc(doc_no, type, groupname, rid)
        dao_fda_cpn.GetDataby_Newcode(dao_fda_mdc.fields.Newcode)

        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub
    Private Sub insert_Newcode_tb_temp(ByVal doc_no As String, ByVal type As String, ByVal groupname As String, ByVal rid As String)

        Dim dao_mdc As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
        Dim dao_fda_mdc As New DAO_XML_MDC.TB_XML_MDC2
        dao_fda_mdc.GetDataby_doc(doc_no, type, groupname, rid)

        dao_mdc.GetDataby_Newcode(dao_fda_mdc.fields.Newcode)
        Dim dao_mdc_temp As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC_TEMP  'ใช้เก็บเลขที่สร้างแล้ว
        dao_mdc_temp.GetDataby_Newcode(dao_mdc.fields.Newcode)

        If dao_mdc_temp.fields.Newcode <> dao_fda_mdc.fields.Newcode Then
            dao_mdc_temp.fields.Newcode = dao_mdc.fields.Newcode
            dao_mdc_temp.fields.groupname = dao_mdc.fields.groupname
            dao_mdc_temp.fields.Status = dao_mdc.fields.Status
            dao_mdc_temp.fields.CREATE_DATE_INSERT_XML = DateTime.Now
            dao_mdc_temp.fields.CREATE_DATE = dao_mdc.fields.CREATE_DATE
            dao_mdc_temp.insert()
        Else
            dao_mdc_temp.fields.Status = "S"
            dao_mdc_temp.fields.CREATE_DATE_INSERT_XML = DateTime.Now
            dao_mdc_temp.update()
        End If
    End Sub
#End Region
End Class
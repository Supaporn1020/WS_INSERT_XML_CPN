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
Public Class WS_INSERT_XML_SIP
    Inherits System.Web.Services.WebService

    Dim db As New LGT_XML_CPNDataContext
    Public rows As Integer
    <WebMethod(Description:="ด่าน")>
    Public Function XML_SIP(ByVal Newcode As String)
        Dim ck_ As String = check_xml_sip(Newcode)
        Return ck_
    End Function
    Private Function check_xml_sip(ByVal Newcode As String) As String
        Dim ck As String = ""
        Dim Status As String = ""
        Dim groupname As String
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_SIP
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        groupname = dao_fda_cpn.fields.groupname
        'Dim ck_fda_xml As New DAO_XML.TB_XML_MDC
        Dim bao_sip As New BAO_SIP.BAO_SIP
        Dim dt_sip As New DataTable
        dt_sip = bao_sip.SP_SPECIFIC_SIP(Newcode)

        Dim row_count As String
        Dim Newcode_sip As String
        Dim groupname_sip As String = "SF"

        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง
            'ck_fda_xml.GetDataby_Newcode(Newcode)
            bao_sip.SP_SPECIFIC_SIP(Newcode)
            insert_Newcode_tb_keep(Newcode) ' insert Newcode ลงตารางเช็คสถานะ
            For Each dr As DataRow In dt_sip.Rows
                Newcode_sip = dr("Newcode")
                row_count = dt_sip.Rows.Count

                If row_count <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                    'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                    ck = BUILD_XML_SIP(Newcode_sip, groupname_sip) 'สร้าง xml
                    update_status(Newcode_sip, groupname_sip)
                End If
                '.Replace("", "d")
            Next

        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                ck = BUILD_XML_SIP(Newcode, groupname)
                update_status(Newcode, groupname_sip)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                ck = BUILD_XML_SIP(Newcode, groupname_sip)
                update_status(Newcode, groupname_sip)
            End If
        End If
        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Function BUILD_XML_SIP(ByVal Newcode_txt As String, ByVal groupname As String)
        Dim cut As String = Newcode_txt.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "2")

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
                groupname = "SF"   'ใส้ใน  คือ detail
                lcnsid = dr("LCNSID")
                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next
                '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

                'Else

                'End If


                xmlwriter.WriteEndElement()    'DRUG/
                xmlwriter.WriteEndElement()   'LGTDRUG/ 
                xmlwriter.WriteEndDocument()
                xmlwriter.Flush()

                'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_MDC
                'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
                'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
                'dao_fda_cpn.update()

                Dim byterarrary As Byte() = Ms.ToArray()
                Dim oFileStream As System.IO.FileStream
                'oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\MDC2\MN\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                Return "success"
            Next

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
    Private Sub update_status(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_SIP
        dao_fda_cpn.GetDataby_Newcode(Newcode)

        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
        Dim dt_sip As New DataTable
        Dim bao As New BAO_SIP.BAO_SIP
        dt_sip = bao.SP_SPECIFIC_SIP(Newcode)
        For Each dr As DataRow In dt_sip.Rows                   'ให้ dr เป็นแถวของ dt วนทีละ1 แถวของ dt ฉันจะวนในตารางนี้ทีละแถว
            'Dim dao_fda_cpn As New DAO_XML.TB_XML_MDC
            'dao_fda_cpn.GetDataby_Newcode(Newcode)
            Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_SIP
            dao_fda_cpn_keep.fields.Newcode = dr("Newcode").ToString
            dao_fda_cpn_keep.fields.groupname = "SF"
            dao_fda_cpn_keep.fields.Status = "W"
            dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
            dao_fda_cpn_keep.fields.INV_NO = dr("INV_NO").ToString
            dao_fda_cpn_keep.insert()
        Next
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

End Class
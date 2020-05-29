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
Public Class WS_INSERT_XML_TXC
    Inherits System.Web.Services.WebService
    Dim db As New LGT_XML_CPNDataContext
    Public rows As Integer
    <WebMethod(Description:="วัตถุอันตราย")>
    Public Function XML_TXC(ByVal Newcode As String)
        Dim ck_ As String = check_xml_txc(Newcode)
        Return ck_
    End Function
    Private Function check_xml_txc(ByVal Newcode As String)
        Dim ck As String = ""
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_TXC
        Dim ck_fda_xml As New DAO_XML.TB_XML_TXC   'เช็คในตารางพี่บิ๊กว่ามีมั้ย แต่ DRUG ใช้ตารางทราย
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim Status As String = ""

        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง

            ck_fda_xml.GetDataby_Newcode(Newcode)
            insert_Newcode_tb_keep(Newcode)   '

            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                ck = BUILD_XML(Newcode)
                update_status_txc(Newcode, ck_fda_xml.fields.GrouNAME)
            End If
            '.Replace("", "d")
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                ck = BUILD_XML(Newcode)
                update_status_txc(Newcode, ck_fda_xml.fields.GrouNAME)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                ck = BUILD_XML(Newcode)
                update_status_txc(Newcode, ck_fda_xml.fields.GrouNAME)
            End If
        End If
        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    '#Region "codeสร้างxml ลงตารางทราย"
    '    Private Function BUILD_XML(ByVal Newcode As String)   ' สร้าง xml 
    '        Dim cut As String = Newcode.Substring(2, 2)
    '        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '        dao.GetDataby_GROUPNAME_TYPE(cut, "1")
    '        Dim dt As New DataTable
    '        Dim groupname As String

    '        Dim clsds As New ClassDataset
    '        Dim conn As String = db.Connection.ConnectionString

    '        Dim STO_NAME As String = dao.fields.XML_SQL
    '        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
    '        STO_NAME &= " @Newcode = '" & Newcode & "'"
    '        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '        rows = dt.Rows.Count()
    '        'dt = bao_show.SP_XML_SPECIFIC_TXC(Newcode)
    '        'Dim paths As String = "E:\XML\FDA_LICENSE"
    '        'Dim paths As String = "C:\XML\LICENSE\TXC"

    '        If dt.Rows.Count > 0 Then
    '            Dim Path_XML As String
    '            For Each dr As DataRow In dt.Rows
    '                groupname = dr("GrouNAME")
    '                If groupname.Trim = "TR" Then
    '                    Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                    dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    Dim paths_tr As String = dao_dr.fields.XML_PATH
    '                    Path_XML = Replace(paths_tr, vbCrLf, "") & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '                    CREATE_XML_TXC(Path_XML, dr("Newcode"), dr("GrouNAME")) 'ทำการสร้าง XML 
    '                    update_status_txc(Newcode)
    '                    Return "success"
    '                ElseIf groupname.Trim = "TT" Then
    '                    Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                    dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    Dim paths_tt As String = dao_dr.fields.XML_PATH
    '                    Path_XML = Replace(paths_tt, vbCrLf, "") & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '                    CREATE_XML_TXC(Path_XML, dr("Newcode"), dr("GrouNAME")) 'ทำการสร้าง XML 
    '                    update_status_txc(Newcode)
    '                    Return "success"
    '                ElseIf groupname.Trim = "TC" Then
    '                    Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                    dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    Dim paths_tc As String = dao_dr.fields.XML_PATH
    '                    Path_XML = Replace(paths_tc, vbCrLf, "") & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '                    CREATE_XML_TXC(Path_XML, dr("Newcode"), dr("GrouNAME")) 'ทำการสร้าง XML 
    '                    update_status_txc(Newcode)
    '                    Return "success"
    '                ElseIf groupname.Trim = "TL" Then
    '                    Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                    dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    Dim paths_tl As String = dao_dr.fields.XML_PATH
    '                    Path_XML = Replace(paths_tl, vbCrLf, "") & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '                    CREATE_XML_TXC(Path_XML, dr("Newcode"), dr("GrouNAME")) 'ทำการสร้าง XML 
    '                    update_status_txc(Newcode)
    '                    Return "success"
    '                End If
    '            Next
    '            Return "success"
    '        Else
    '            Return "False"

    '        End If

    '        'Return ck_Newcode


    '        'Dim FOOD As String
    '        'FOOD = "37"         '63 คือ สโต NCT 
    '        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        'dao_insert.GetDataby_IDA(FOOD)
    '        'Dim HeadName As String = dao_insert.fields.XML_HEADER
    '        'Dim BodyName As String = dao_insert.fields.XML_BODY
    '        'Dim Paths As String = dao_insert.fields.XML_PATH
    '        'Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

    '        'Dim b As String = ""
    '        'Dim Newcode_dt As String
    '        'Dim dt_detail As New DataTable

    '        ''For Each fields As XML_CONFIG In Details
    '        ''Dim HeadName As String = dao_insert.fields.XML_HEADER
    '        ''    Dim BodyName As String = dao_insert.fields.XML_BODY
    '        ''    Dim Paths As String = dao_insert.fields.XML_PATH
    '        ''    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

    '        'Dim clsds As New ClassDataset
    '        'Dim conn As String = db.Connection.ConnectionString

    '        'Dim dt As New DataTable

    '        ''Try
    '        'steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
    '        'Dim bao_food_fg As New BAO_LO.BAO_LO
    '        'dt = bao_food_fg.SP_CPN_CONVERT_FOOD(Newcode_txt)
    '        ''dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '        'rows = dt.Rows.Count()
    '        'lb_Newcode_food.Text = steps & " " & rows.ToString()

    '        'Dim Ms As New MemoryStream
    '        'Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
    '        'xmlwriter.WriteStartDocument()
    '        'xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
    '        'xmlwriter.WriteStartElement(BodyName)    'DRUG
    '        ''Dim dao As New DAO_DRUG.TB_XML_FRGN

    '        'For Each dr As DataRow In dt.Rows

    '        '    Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
    '        '    'If Newcode_dt = Newcode_txt Then
    '        '    For Each dc As DataColumn In dt.Columns
    '        '        xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
    '        '    Next
    '        '    '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

    '        '    'Else

    '        '    'End If

    '        'Next
    '        'xmlwriter.WriteEndElement()    'DRUG/
    '        'xmlwriter.WriteEndElement()   'LGTDRUG/ 
    '        'xmlwriter.WriteEndDocument()
    '        'xmlwriter.Flush()

    '        'Dim byterarrary As Byte() = Ms.ToArray()
    '        'Dim oFileStream As System.IO.FileStream

    '        ''oFileStream = New System.IO.FileStream(Paths & dr(Field_Name).ToString & ".xml", System.IO.FileMode.Create)
    '        ''oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
    '        'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD_TEST\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
    '        'oFileStream.Write(byterarrary, 0, byterarrary.Length)
    '        'oFileStream.Close()
    '        'Ms.Close()

    '    End Function
    '    'Private Function BUILD_XML(ByVal Newcode As String)   ' สร้าง xml 
    '    '    'Dim paths As String = "E:\XML\FDA_LICENSE\TXC"
    '    '    Dim paths As String = "C:\XML\LICENSE\TXC"

    '    '    Dim dt As New DataTable
    '    '    Dim bao_show As New BAO_DRUG.BAO_DRUG
    '    '    dt = bao_show.SP_XML_SPECIFIC_TXC(Newcode)


    '    '    If dt.Rows.Count > 0 Then
    '    '        Dim Path_XML As String
    '    '        For Each dr As DataRow In dt.Rows
    '    '            Path_XML = paths & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '    '            CREATE_XML_TXC(Path_XML, dr("Newcode"), dr("GrouNAME")) 'ทำการสร้าง XML 
    '    '        Next
    '    '        Return "success"
    '    '    Else
    '    '        Return "False"

    '    '    End If

    '    '    'Return ck_Newcode


    '    '    'Dim FOOD As String
    '    '    'FOOD = "37"         '63 คือ สโต NCT 
    '    '    'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '    '    'dao_insert.GetDataby_IDA(FOOD)
    '    '    'Dim HeadName As String = dao_insert.fields.XML_HEADER
    '    '    'Dim BodyName As String = dao_insert.fields.XML_BODY
    '    '    'Dim Paths As String = dao_insert.fields.XML_PATH
    '    '    'Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

    '    '    'Dim b As String = ""
    '    '    'Dim Newcode_dt As String
    '    '    'Dim dt_detail As New DataTable

    '    '    ''For Each fields As XML_CONFIG In Details
    '    '    ''Dim HeadName As String = dao_insert.fields.XML_HEADER
    '    '    ''    Dim BodyName As String = dao_insert.fields.XML_BODY
    '    '    ''    Dim Paths As String = dao_insert.fields.XML_PATH
    '    '    ''    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

    '    '    'Dim clsds As New ClassDataset
    '    '    'Dim conn As String = db.Connection.ConnectionString

    '    '    'Dim dt As New DataTable

    '    '    ''Try
    '    '    'steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
    '    '    'Dim bao_food_fg As New BAO_LO.BAO_LO
    '    '    'dt = bao_food_fg.SP_CPN_CONVERT_FOOD(Newcode_txt)
    '    '    ''dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '    '    'rows = dt.Rows.Count()
    '    '    'lb_Newcode_food.Text = steps & " " & rows.ToString()

    '    '    'Dim Ms As New MemoryStream
    '    '    'Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
    '    '    'xmlwriter.WriteStartDocument()
    '    '    'xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
    '    '    'xmlwriter.WriteStartElement(BodyName)    'DRUG
    '    '    ''Dim dao As New DAO_DRUG.TB_XML_FRGN

    '    '    'For Each dr As DataRow In dt.Rows

    '    '    '    Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
    '    '    '    'If Newcode_dt = Newcode_txt Then
    '    '    '    For Each dc As DataColumn In dt.Columns
    '    '    '        xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
    '    '    '    Next
    '    '    '    '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

    '    '    '    'Else

    '    '    '    'End If

    '    '    'Next
    '    '    'xmlwriter.WriteEndElement()    'DRUG/
    '    '    'xmlwriter.WriteEndElement()   'LGTDRUG/ 
    '    '    'xmlwriter.WriteEndDocument()
    '    '    'xmlwriter.Flush()

    '    '    'Dim byterarrary As Byte() = Ms.ToArray()
    '    '    'Dim oFileStream As System.IO.FileStream

    '    '    ''oFileStream = New System.IO.FileStream(Paths & dr(Field_Name).ToString & ".xml", System.IO.FileMode.Create)
    '    '    ''oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
    '    '    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD_TEST\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
    '    '    'oFileStream.Write(byterarrary, 0, byterarrary.Length)
    '    '    'oFileStream.Close()
    '    '    'Ms.Close()

    '    'End Function
    '    ''' <summary>
    '    ''' สร้าง ไฟล์ XML
    '    ''' </summary>
    '    ''' <param name="PATH_XML"></param>
    '    ''' <remarks></remarks>
    '    Private Sub CREATE_XML_TXC(ByVal PATH_XML As String, ByVal Newcode As String, ByVal groupname As String)
    '        'Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
    '        'Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE
    '        Dim cls_xml As New LGT_TXC
    '        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '        Dim grouname As String
    '        grouname = groupname.Trim

    '        If grouname.Trim = "TR" Then 'ทะเบียน
    '            cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_TABEAN(Newcode)
    '        ElseIf grouname.Trim = "TT" Then 'วอ1
    '            cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_WO1(Newcode)
    '        ElseIf grouname.Trim = "TC" Then  'วอ2
    '            cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_WO2(Newcode)
    '        ElseIf grouname.Trim = "TL" Then  'วอ3
    '            cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_WO3(Newcode)
    '        End If
    '        Dim objStreamWriter As New StreamWriter(PATH_XML)
    '        Dim x As New XmlSerializer(cls_xml.GetType)
    '        x.Serialize(objStreamWriter, cls_xml)
    '        objStreamWriter.Close()
    '    End Sub

    '    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
    '        Dim dao_fda_cpn As New DAO_XML_TXC.TB_XML_TXC
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_TXC
    '        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.Newcode
    '        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.GrouNAME
    '        dao_fda_cpn_keep.fields.Status = "W"
    '        dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
    '        dao_fda_cpn_keep.insert()
    '    End Sub
    '    Private Sub update_status_txc(ByVal Newcode As String, ByVal groupname As String)
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_TXC
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        dao_fda_cpn.fields.Status = "S"
    '        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
    '        dao_fda_cpn.update()
    '    End Sub
    '    Private Sub update_status_txc(ByVal Newcode As String)
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_TXC
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        dao_fda_cpn.fields.Status = "S"
    '        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
    '        dao_fda_cpn.update()
    '    End Sub
    '#End Region

    Private Function BUILD_XML(ByVal Newcode_txt As String)   ' สร้าง xml 

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
                groupname = dr("grouname")
                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
                'If Newcode_dt = Newcode_txt Then
                For Each dc As DataColumn In dt.Columns
                    xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
                Next
                '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

                'Else

                'End If

            Next
            xmlwriter.WriteEndElement()    'FOOD/
            xmlwriter.WriteEndElement()   'LGTFOOD/ 
            xmlwriter.WriteEndDocument()
            xmlwriter.Flush()

            'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
            'dao_fda_cpn.GetDataby_Newcode(Newcode_txt)
            'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
            'dao_fda_cpn.update()



            Dim byterarrary As Byte() = Ms.ToArray()
            Dim oFileStream As System.IO.FileStream
            'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
            oFileStream = New System.IO.FileStream(dao.fields.XML_PATH & Newcode_dt & ".xml", System.IO.FileMode.Create)
            oFileStream.Write(byterarrary, 0, byterarrary.Length)
            oFileStream.Close()
            Ms.Close()

            Return "success"


        Else
            Return "False"
        End If

    End Function
    Private Sub update_status_txc(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_TXC
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub
    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML.TB_XML_TXC
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_TXC
        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.Newcode
        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.GrouNAME
        dao_fda_cpn_keep.fields.Status = "W"
        dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn_keep.insert()
    End Sub
End Class
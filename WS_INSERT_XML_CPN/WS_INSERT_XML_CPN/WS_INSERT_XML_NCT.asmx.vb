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
Public Class WS_INSERT_XML_NCT
    Inherits System.Web.Services.WebService
    Dim db As New LGT_XML_CPNDataContext
    Public rows As Integer
    '#Region "จากตารางทราย"
    '#Region "วัตถุออกฤทธิ์"
    '    <WebMethod(Description:="วัตถุออกฤทธิ์")>
    '    Public Function XML_NCT(ByVal Newcode As String)
    '        Dim ck_ As String = BUILD_XML(Newcode)
    '        Return ck_
    '    End Function
    '    'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    '    Private Function BUILD_XML(ByVal Newcode As String)

    '        Dim dt As New DataTable
    '        Dim groupname As String
    '        Dim cut As String = Newcode.Substring(2, 2)
    '        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        dao.GetDataby_GROUPNAME_TYPE("N", "1")
    '        Dim HeadName As String = dao.fields.XML_HEADER
    '        Dim BodyName As String = dao.fields.XML_BODY
    '        Dim Paths As String = dao.fields.XML_PATH
    '        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
    '        Dim STO_NAME As String = dao.fields.XML_SQL

    '        Dim clsds As New ClassDataset
    '        Dim conn As String = db.Connection.ConnectionString
    '        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
    '        STO_NAME &= " @Newcode = '" & Newcode & "'"
    '        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '        rows = dt.Rows.Count()
    '        'dt = bao_show.SP_XML_SPECIFIC_NCT_N_NC(Newcode)

    '        If dt.Rows.Count > 0 Then
    '            Dim Path_XML As String

    '            For Each dr As DataRow In dt.Rows
    '                groupname = dr("groupname")
    '                Newcode = dr("Newcode")
    '                If groupname.Trim = "N" Then
    '                    Dim dao_n As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                    dao_n.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    Dim paths_n As String = dao_n.fields.XML_PATH
    '                    Path_XML = Replace(paths_n, vbCrLf, "") & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '                    CREATE_XML_NCT_N(Path_XML, dr("Newcode"), dr("groupname")) 'ทำการสร้าง XML 
    '                    update_status_nct(Newcode, groupname)
    '                ElseIf groupname.Trim = "NC" Then
    '                    BUILD_XML_NC(Newcode)
    '                    update_status_nct(Newcode, groupname)
    '                    'ElseIf groupname.Trim = "NR" Then
    '                    '    Dim dao_n As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    '    'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                    '    dao_n.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    '    Dim paths_n As String = dao_n.fields.XML_PATH
    '                    '    Path_XML = paths_n & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '                    '    CREATE_XML_NCT_NR(Path_XML, dr("Newcode"), dr("groupname")) 'ทำการสร้าง XML 

    '                End If
    '            Next
    '            Return "success"
    '        Else
    '            Return "False"

    '        End If

    '        '------------------------------------------------------------------------------------
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
    '    '    Dim paths As String = "E:\XML\FDA_LICENSE\NCT"
    '    '    'Dim paths As String = "C:\XML\LICENSE\NCT"
    '    '    Dim groupname As String
    '    '    Dim dt As New DataTable
    '    '    Dim bao_show As New BAO_DRUG.BAO_DRUG
    '    '    dt = bao_show.SP_XML_SPECIFIC_NCT_N_NC(Newcode)



    '    '    If dt.Rows.Count > 0 Then
    '    '        Dim Path_XML As String

    '    '        For Each dr As DataRow In dt.Rows
    '    '            groupname = dr("groupname")
    '    '            Newcode = dr("Newcode")
    '    '            If groupname.Trim = "N" Then
    '    '                Path_XML = paths & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '    '                CREATE_XML_NCT_N(Path_XML, dr("Newcode"), dr("groupname")) 'ทำการสร้าง XML 
    '    '            ElseIf groupname.Trim = "NC" Then
    '    '                BUILD_XML_NC(Newcode)
    '    '            End If
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
    '    Private Sub CREATE_XML_NCT_N(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String)
    '        Dim cls_xml As New LGTNCT
    '        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '        If groupname = "N" Then
    '            cls_xml = Cls_NCT_LCT.gen_xml_LGT_SEARCH_XML_NCT_NNN(DownID)
    '        End If
    '        Dim objStreamWriter As New StreamWriter(PATH_XML)
    '        Dim x As New XmlSerializer(cls_xml.GetType)
    '        x.Serialize(objStreamWriter, cls_xml)
    '        objStreamWriter.Close()
    '    End Sub
    '    Private Sub CREATE_XML_NCT_NR_FORMULA(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String)
    '        Dim cls_xml As New LGT_XML_NCT_NR_IOW
    '        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '        cls_xml = Cls_NCT_LCT.gen_xml_XML_NCT_NR_FORMULA(DownID)

    '        Dim objStreamWriter As New StreamWriter(PATH_XML)
    '        Dim x As New XmlSerializer(cls_xml.GetType)
    '        x.Serialize(objStreamWriter, cls_xml)
    '        objStreamWriter.Close()

    '    End Sub
    '    Private Sub CREATE_XML_NCT_NR(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String)
    '        Dim cls_xml As New LGT_XML_NCT_NR_ALL
    '        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO

    '        If groupname = "NR" Then
    '            cls_xml = Cls_NCT_LCT.gen_xml_XML_NCT_NR(DownID)
    '        End If
    '        Dim objStreamWriter As New StreamWriter(PATH_XML)
    '        Dim x As New XmlSerializer(cls_xml.GetType)
    '        x.Serialize(objStreamWriter, cls_xml)
    '        objStreamWriter.Close()

    '    End Sub
    '    Private Sub BUILD_XML_NC(ByVal Newcode As String)

    '        Dim cut As String = Newcode.Substring(2, 2)
    '        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

    '        'dao_insert.GetDataby_IDA(FOOD)
    '        Dim HeadName As String = dao.fields.XML_HEADER
    '        Dim BodyName As String = dao.fields.XML_BODY
    '        Dim Paths As String = dao.fields.XML_PATH
    '        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
    '        Dim STO_NAME As String = dao.fields.XML_SQL


    '        Dim b As String = ""
    '        Dim Newcode_dt As String
    '        Dim groupname As String
    '        Dim dt_detail As New DataTable
    '        Dim clsds As New ClassDataset
    '        Dim conn As String = db.Connection.ConnectionString

    '        'For Each fields As XML_CONFIG In Details
    '        'Dim HeadName As String = dao_insert.fields.XML_HEADER
    '        '    Dim BodyName As String = dao_insert.fields.XML_BODY
    '        '    Dim Paths As String = dao_insert.fields.XML_PATH
    '        '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME



    '        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
    '        Dim dt As New DataTable
    '        Dim dt_ck As New DataTable
    '        STO_NAME &= " @Newcode = '" & Newcode & "'"
    '        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '        rows = dt.Rows.Count()

    '        'Try
    '        'steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
    '        'dt = bao_food_fg.SP_XML_SPECIFIC_NCT_N_NC(Newcode) ' เช็คว่าถ้าสถานะเป็น W ถึงให้ genxml
    '        'dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '        'rows = dt.Rows.Count()
    '        'Label1.Text = steps & " " & rows.ToString()

    '        For Each dr As DataRow In dt.Rows

    '            'Try
    '            Newcode_dt = dr("Newcode")
    '            groupname = dr("groupname")
    '            'dt = bao_food_fg.SP_CPN_CONVERT_FOOD(Newcode_dt)  'เดี๋ยวมาเปิดด้วย
    '            If groupname = "NC" Then


    '                For Each dr2 As DataRow In dt.Rows
    '                    Dim Ms As New MemoryStream
    '                    Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
    '                    xmlwriter.WriteStartDocument()
    '                    xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
    '                    xmlwriter.WriteStartElement(BodyName)    'DRUG


    '                    'Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
    '                    'If Newcode_dt = Newcode_txt Then


    '                    For Each dc As DataColumn In dt.Columns
    '                        xmlwriter.WriteElementString(dc.ColumnName, dr2(dc.ColumnName).ToString())
    '                    Next
    '                    '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

    '                    'Else

    '                    'End If

    '                    xmlwriter.WriteEndElement()    'DRUG/
    '                    xmlwriter.WriteEndElement()   'LGTDRUG/ 
    '                    xmlwriter.WriteEndDocument()
    '                    xmlwriter.Flush()

    '                    '------------------------------------------------------------------------
    '                    'Dim dt_class As New DataTable
    '                    'Dim bao As New BAO_LO.BAO_LO
    '                    'dt_class = bao.SP_CPN_CONVERT_FOOD(Newcode_dt)
    '                    'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_FOOD
    '                    'dao_fda_cpn.GetDataby_Newcode(Newcode_dt)
    '                    'dao_fda_cpn.fields.XML_DATA = CLASS_TO_XMLTYPE(dt_class)      'เอาข้อมูล xml ที่ได้มาอยู่ใน dt แล้วใส่เข้าไปแปลงใน function CLASS_TO_XMLTYPE เพื่อ เอา xmlนั้นใส่ลงไปใน table
    '                    'dao_fda_cpn.update()



    '                    Dim byterarrary As Byte() = Ms.ToArray()
    '                    Dim oFileStream As System.IO.FileStream

    '                    'oFileStream = New System.IO.FileStream(Paths & dr(Field_Name).ToString & ".xml", System.IO.FileMode.Create)
    '                    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\NCT\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
    '                    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\NCT\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
    '                    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
    '                    oFileStream.Write(byterarrary, 0, byterarrary.Length)
    '                    oFileStream.Close()

    '                    Ms.Close()
    '                    'Throw New System.Exception("An exception has occurred.") 'เอาไว้test error
    '                Next
    '            End If
    '            'Catch ex As Exception
    '            'End Try
    '        Next

    '    End Sub
    '    ''' <summary>
    '    ''' สร้าง ไฟล์ XML
    '    ''' </summary>
    '    ''' <param name="PATH_XML"></param>
    '    ''' <remarks></remarks>
    '    'Private Sub CREATE_XML_TXC(ByVal PATH_XML As String, ByVal Newcode As String, ByVal groupname As String)
    '    '    'Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
    '    '    'Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE
    '    '    Dim cls_xml As New LGT_TXC
    '    '    Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '    '    Dim grouname As String
    '    '    grouname = groupname.Trim

    '    '    If grouname.Trim = "TR" Then 'ทะเบียน
    '    '        cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_TABEAN(Newcode)
    '    '    ElseIf grouname.Trim = "TT" Then 'วอ1
    '    '        cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_WO1(Newcode)
    '    '    ElseIf grouname.Trim = "TC" Then  'วอ2
    '    '        cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_WO2(Newcode)
    '    '    ElseIf grouname.Trim = "TL" Then  'วอ3
    '    '        cls_xml = Cls_NCT_LCT.gen_xml_XML_TXC_FORMULA_WO3(Newcode)
    '    '    End If
    '    '    Dim objStreamWriter As New StreamWriter(PATH_XML)
    '    '    Dim x As New XmlSerializer(cls_xml.GetType)
    '    '    x.Serialize(objStreamWriter, cls_xml)
    '    '    objStreamWriter.Close()
    '    'End Sub
    '    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
    '        Dim dao_fda_cpn As New DAO_XML_NCT.TB_XML_NCT
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
    '        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.Newcode
    '        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.GROUPNAME
    '        dao_fda_cpn_keep.fields.Status = "W"
    '        dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
    '        dao_fda_cpn_keep.insert()
    '    End Sub
    '    Private Sub update_status_nct(ByVal Newcode As String, ByVal groupname As String)
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        dao_fda_cpn.fields.Status = "S"
    '        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
    '        dao_fda_cpn.update()
    '    End Sub
    '#End Region
    '#Region "วัตถุออกฤทธิ์(INSERTXMLลงใน folderXML_NCT_LICENSE)"
    '    <WebMethod(Description:="วัตถุออกฤทธิ์ สร้าง xmlใบอนุญาต")>
    '    Public Function XML_NCT_INSERT_XML_LICENSE(ByVal Newcode As String)
    '        Dim ck_ As String = BUILD_XML_INSERT_NCT(Newcode)
    '        Return ck_
    '    End Function
    '    Private Function BUILD_XML_INSERT_NCT(ByVal Newcode As String)

    '        Dim dt As New DataTable
    '        Dim groupname As String
    '        Dim cut As String = Newcode.Substring(2, 2)
    '        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        dao.GetDataby_GROUPNAME_TYPE("N", "1")

    '        Dim HeadName As String = dao.fields.XML_HEADER
    '            Dim BodyName As String = dao.fields.XML_BODY
    '            Dim Paths As String = dao.fields.XML_PATH
    '            Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
    '            Dim STO_NAME As String = dao.fields.XML_SQL

    '            Dim clsds As New ClassDataset
    '            Dim conn As String = db.Connection.ConnectionString
    '            Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
    '            STO_NAME &= " @Newcode = '" & Newcode & "'"
    '            dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '            rows = dt.Rows.Count()
    '        'dt = bao_show.SP_XML_SPECIFIC_NCT_N_NC(Newcode)


    '        If dt.Rows.Count > 0 Then
    '            Dim Path_XML As String

    '            For Each dr As DataRow In dt.Rows
    '                groupname = dr("groupname")
    '                Newcode = dr("Newcode")
    '                If groupname.Trim = "N" Then
    '                    'Dim dao_n As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    'dao_n.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    'Dim paths_n As String = dao_n.fields.XML_PATH
    '                    Dim paths_n As String = "C:\XML\LICENSE\XML_NCT_LICENSE"
    '                    Path_XML = Replace(paths_n, vbCrLf, "") & "\" & dr("Newcode") & ".xml" 'สร้างชื่อ XML
    '                    CREATE_XML_NCT_N(Path_XML, dr("Newcode"), dr("groupname")) 'ทำการสร้าง XML 

    '                End If
    '            Next
    '            Return "success"
    '        Else
    '            Return "False"

    '        End If


    '    End Function
    '#End Region
    '#Region "วัตถุออกฤทธิ์(INSERTXMLลงใน folderXML_NCT_FORMULA)"
    '    <WebMethod(Description:="วัตถุออกฤทธิ์ สร้าง xml ทะเบียน_สาร")>
    '    Public Function XML_NCT_INSERT_XML_FORMULA(ByVal Newcode As String)
    '        Dim ck_ As String = BUILD_XML_INSERT_NCT_FORMULA(Newcode)
    '        Return ck_
    '    End Function
    '    Private Function BUILD_XML_INSERT_NCT_FORMULA(ByVal Newcode As String)

    '        Dim dt As New DataTable
    '        Dim groupname As String
    '        Dim cut As String = Newcode.Substring(2, 2)
    '        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        dao.GetDataby_GROUPNAME_TYPE("NR", "1")

    '        Dim HeadName As String = dao.fields.XML_HEADER
    '        Dim BodyName As String = dao.fields.XML_BODY
    '        Dim Paths As String = dao.fields.XML_PATH
    '        Dim Field_Name As String = dao.fields.XML_FIELDS_NAME
    '        Dim STO_NAME As String = dao.fields.XML_SQL

    '        Dim clsds As New ClassDataset
    '        Dim conn As String = db.Connection.ConnectionString
    '        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
    '        STO_NAME &= " @Newcode = '" & Newcode & "'"
    '        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '        rows = dt.Rows.Count()
    '        'dt = bao_show.SP_XML_SPECIFIC_NCT_N_NC(Newcode)


    '        If dt.Rows.Count > 0 Then
    '            Dim Path_XML As String

    '            For Each dr As DataRow In dt.Rows
    '                groupname = dr("groupname")
    '                Newcode = dr("Newcode")
    '                If groupname.Trim = "NR" Then
    '                    'Dim dao_n As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                    'dao_n.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                    'Dim paths_n As String = dao_n.fields.XML_PATH
    '                    Dim paths_nr As String = "C:\XML\LICENSE\XML_NCT_FORMULA"
    '                    Path_XML = Replace(paths_nr, vbCrLf, "") & "\" & dr("Newcode_R") & ".xml" 'สร้างชื่อ XML
    '                    CREATE_XML_NCT_NR_FORMULA(Path_XML, dr("Newcode"), dr("groupname")) 'ทำการสร้าง XML 
    '                End If
    '            Next
    '            Return "success"
    '        Else
    '            Return "False"
    '        End If
    '    End Function
    '#End Region
    '#End Region
#Region "FDA_XML"
    <WebMethod(Description:="วัตถุออกฤทธิ์")>
    Public Function XML_NCT(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)
        Dim ck_ As String = check_xml_nct(Newcode, IDENTIFY_EDIT)
        Return ck_
    End Function
    Private Function check_xml_nct(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String) As String
        Dim ck As String = ""
        Dim Status As String = ""
        Dim groupname As String
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        groupname = dao_fda_cpn.fields.groupname
        Dim ck_fda_xml As New DAO_NCT.TB_XML_NCT
        ck_fda_xml.GetDataby_Newcode(Newcode)
        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง
            ck_fda_xml.GetDataby_Newcode(Newcode)
            insert_Newcode_tb_keep(Newcode) ' insert Newcode ลงตารางเช็คสถานะ

            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 

                ck = BUILD_XML_NCT(Newcode, ck_fda_xml.fields.GroupName, IDENTIFY_EDIT)
                update_status(Newcode, ck_fda_xml.fields.GroupName)   '
            End If
            '.Replace("", "d")
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                ck = BUILD_XML_NCT(Newcode, ck_fda_xml.fields.GroupName, IDENTIFY_EDIT)
                update_status(Newcode, ck_fda_xml.fields.GroupName)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                ck = BUILD_XML_NCT(Newcode, ck_fda_xml.fields.GroupName, IDENTIFY_EDIT)
                update_status(Newcode, ck_fda_xml.fields.GroupName)
                'ElseIf Status = "F" Then
                '    'ไม่ต้องทำอะไร
                '    ck = BUILD_XML_NCT(Newcode, ck_fda_xml.fields.GroupName)
                '    update_status(Newcode, ck_fda_xml.fields.GroupName)
            End If
        End If
        Return ck
    End Function
    Private Function BUILD_XML_NCT(ByVal Newcode_txt As String, ByVal groupname As String, ByVal IDENTIFY_EDIT As String)
        Dim cut As String = Newcode_txt.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(groupname, "1")

        If dao.fields.GROUPNAME = "N" Then

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


                    Dim pdfBytes As Byte() = clsds.UpLoadImageByte(dao.fields.XML_PATH & Newcode_dt & ".xml")
                    Dim pdf_b64 As String = Convert.ToBase64String(pdfBytes)
                    Dim ws_blockchain As New BLOCK_APP.WS_BLOCKCHAIN
                    Dim ws_fields As New BLOCK_APP.XML_BLOCK
                    ws_fields.TR_ID = Newcode_dt 'เลขTRANSATION
                    ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคล
                    ws_fields.PROCESS_ID = "NCT" 'เลขนิติบุคคล
                    ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
                    ws_fields.SOP_STATUS = "8" 'สถานะคำขอนะ
                    ws_fields.SYSTEM_ID = "NCT" 'เลขสารระบบ
                    ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
                    ws_fields.XML_DATA = pdf_b64 'classxml ข้อมูล
                    ws_blockchain.WS_BLOCK_CHAIN(ws_fields)

                    Return "success"
                Next

            Else
                Return "False"
            End If

        ElseIf dao.fields.GROUPNAME = "NC" Then

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



                    Dim pdfBytes As Byte() = clsds.UpLoadImageByte(dao.fields.XML_PATH & Newcode_dt & ".xml")
                    Dim pdf_b64 As String = Convert.ToBase64String(pdfBytes)
                    Dim ws_blockchain As New BLOCK_APP.WS_BLOCKCHAIN
                    Dim ws_fields As New BLOCK_APP.XML_BLOCK
                    ws_fields.TR_ID = Newcode_dt 'เลขTRANSATION
                    ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคล
                    ws_fields.PROCESS_ID = "NCT" 'เลขนิติบุคคล
                    ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
                    ws_fields.SOP_STATUS = "8" 'สถานะคำขอนะ
                    ws_fields.SYSTEM_ID = "NCT" 'เลขสารระบบ
                    ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
                    ws_fields.XML_DATA = pdf_b64 'classxml ข้อมูล
                    ws_blockchain.WS_BLOCK_CHAIN(ws_fields)

                    Return "success"


                Next

            Else
                Return "False"
            End If
        End If
    End Function
    Private Sub update_status(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.GetDataby_Newcode(Newcode)

        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.ERROR_LOG = Nothing
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
    Private Sub insert_Newcode_tb_keep(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_NCT.TB_XML_NCT
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim dao_fda_cpn_keep As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn_keep.fields.Newcode = dao_fda_cpn.fields.Newcode
        dao_fda_cpn_keep.fields.groupname = dao_fda_cpn.fields.GroupName
        dao_fda_cpn_keep.fields.Status = "W"
        dao_fda_cpn_keep.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn_keep.insert()
    End Sub
#End Region

#Region "ส่ง Newcode มาเพื่อสร้าง xmlทะเบียนNR"
    <WebMethod(Description:="ทะเบียนยาNCT+สาร")>
    Public Function XML_NCT_FORMULA(ByVal Newcode As String) As String
        ' สร้าง xml ยา ที่มีสาร 
        Dim ck_ As String = check_xml_nct_esub(Newcode)
        Return ck_
    End Function
    Private Function check_xml_nct_esub(ByVal Newcode As String)
        Dim ck As String = ""
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim Status As String = ""

        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง
            Dim ck_fda_xml As New DAO_XML_NCT.TB_XML_NCT_NR   'เช็คในตารางพี่บิ๊กว่ามีมั้ย แต่ DRUG ใช้ตารางทราย
            ck_fda_xml.GetDataby_Newcode(Newcode)


            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                BUILD_XML_NCT_ESUB(Newcode)
                insert_xml_nct_esub(Newcode, ck_fda_xml.fields.groupname)   '
            End If
            '.Replace("", "d")
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 

                BUILD_XML_NCT_ESUB(Newcode)
                'update_status(Newcode)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                BUILD_XML_NCT_ESUB(Newcode)
                'update_status(Newcode)
            End If
        End If
        Return ck
    End Function
    Private Function BUILD_XML_NCT_ESUB(ByVal Newcode As String)   ' สร้าง xml 
        'Dim paths As String = "E:\XML\FDA_LICENSE\DRUG"
        'Dim paths As String = "C:\path\XMLALL\XML\" & "XML_DRUG_FORMULA"
        Dim dt As New DataTable
        Dim groupname As String

        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
        'Dim paths_dr As String = "E:\xml\FDA_LICENSE\DR"
        'Dim paths_dh As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DH"
        'Dim paths_dh As String = "E:\xml\FDA_LICENSE\DH\"

        'ส่ง NEwcodeมาไปwhere หา groupname 
        'แยก groupname ไปทำ xml

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim cut As String = Newcode.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

        Dim STO_NAME As String = dao.fields.XML_SQL
        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @Newcode = '" & Newcode & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()

        'dt = bao_show.SP_XML_SPECIFIC_DRUG(Newcode)
        Dim Path_XML As String
        For Each dr2 As DataRow In dt.Rows
            groupname = dr2("groupname")
            'Path_XML = paths & "\" & dr2("Newcode") & ".xml" 'สร้างชื่อ XML
            Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
            'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
            dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
            Dim paths_dr As String = dao_dr.fields.XML_PATH
            Path_XML = Replace(paths_dr, vbCrLf, "") & dr2("Newcode_R") & ".xml" 'สร้างชื่อ XML
            CREATE_XML_NCT_ESUB(Path_XML, dr2("Newcode"), groupname) 'ทำการสร้าง XML
            update_status_nct_esub(Newcode)
            Return "success"
        Next
        Return "False"
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
    Public Sub SEND_XML(ByVal model As LGT_XML_NCT_NR_IOW)
        Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim ws_blockchain_RETURN As New WS_BLOCKCHAIN.XML_RETURN
        Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
        'ws_blockchain_RETURN = ws_blockchain.WS_BLOCK_CHAIN_V2(CLASSTOXMLSTR(model))

        '  ws_fields.PROCESS_ID = model.process_id 'เลขกระบวนการ
        ws_fields.TR_ID = model.LGT_XML_NCT_NR_ALL_TO.NCT.Newcode 'เลขTRANSATION
        ws_fields.REF_TR_ID = "" 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
        ws_fields.IDENTIFY = model.LGT_XML_NCT_NR_ALL_TO.NCT.CITIZEN_AUTHORIZE 'เลขนิติบุคคล
        ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
        ws_fields.SOP_STATUS = model.LGT_XML_NCT_NR_ALL_TO.NCT.cncnm 'สถานะคำขอนะ
        ws_fields.SYSTEM_ID = "NCT" 'เลขสารระบบ
        ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
        ws_fields.XML_DATA = CLASSTOXMLSTR(model) 'classxml ข้อมูล
        ws_blockchain.WS_BLOCK_CHAIN(ws_fields)
    End Sub

    Private Sub CREATE_XML_NCT_ESUB(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String)
        'Dim cls_xml_DH As New LGT_DRUG_DH15
        Dim cls_xml_NR As New LGT_XML_NCT_NR_IOW
        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO

        cls_xml_NR = Cls_NCT_LCT.gen_xml_XML_NCT_NR_FORMULA(DownID)
        Dim objStreamWriter As New StreamWriter(PATH_XML)
        Dim x As New XmlSerializer(cls_xml_NR.GetType)
        x.Serialize(objStreamWriter, cls_xml_NR)
        objStreamWriter.Close()
        SEND_XML(cls_xml_NR)

    End Sub
    Private Sub insert_xml_nct_esub(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.fields.Newcode = Newcode
        dao_fda_cpn.fields.groupname = groupname
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn.insert()
    End Sub
    Private Sub update_status_nct_esub(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
#End Region
#Region "ส่งNewcode มาเพื่อสร้าง xmlสถานที่NCT"
    <WebMethod(Description:="ใบอนุญาตNCT")>
    Public Function XML_NCT_LICENSE(ByVal Newcode As String) As String
        ' สร้าง xml ยา ที่มีสาร 
        Dim ck_ As String = check_xml_nct_n_esub(Newcode)
        Return ck_
    End Function
    Private Function check_xml_nct_n_esub(ByVal Newcode As String)
        Dim ck As String = ""
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim Status As String = ""

        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง
            Dim ck_fda_xml As New DAO_XML_NCT.TB_XML_NCT_N   'เช็คในตารางพี่บิ๊กว่ามีมั้ย แต่ DRUG ใช้ตารางทราย
            ck_fda_xml.GetDataby_Newcode(Newcode)


            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                BUILD_XML_NCT_N_ESUB(Newcode)
                insert_xml_nct_n_esub(Newcode, ck_fda_xml.fields.GROUPNAME)   '
            End If
            '.Replace("", "d")
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 

                BUILD_XML_NCT_N_ESUB(Newcode)
                'update_status(Newcode)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                BUILD_XML_NCT_N_ESUB(Newcode)
                'update_status(Newcode)
            End If
        End If
        Return ck
    End Function
    Private Function BUILD_XML_NCT_N_ESUB(ByVal Newcode As String)   ' สร้าง xml 
        'Dim paths As String = "E:\XML\FDA_LICENSE\DRUG"
        'Dim paths As String = "C:\path\XMLALL\XML\" & "XML_DRUG_FORMULA"
        Dim dt As New DataTable
        Dim groupname As String

        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
        'Dim paths_dr As String = "E:\xml\FDA_LICENSE\DR"
        'Dim paths_dh As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DH"
        'Dim paths_dh As String = "E:\xml\FDA_LICENSE\DH\"

        'ส่ง NEwcodeมาไปwhere หา groupname 
        'แยก groupname ไปทำ xml

        Dim clsds As New ClassDataset
        Dim conn As String = db.Connection.ConnectionString
        Dim cut As String = Newcode.Substring(2, 1)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

        Dim STO_NAME As String = dao.fields.XML_SQL
        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
        STO_NAME &= " @Newcode = '" & Newcode & "'"
        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        rows = dt.Rows.Count()

        'dt = bao_show.SP_XML_SPECIFIC_DRUG(Newcode)
        Dim Path_XML As String
        For Each dr2 As DataRow In dt.Rows
            groupname = dr2("groupname")
            'Path_XML = paths & "\" & dr2("Newcode") & ".xml" 'สร้างชื่อ XML
            Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
            'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
            dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
            Dim paths_dr As String = dao_dr.fields.XML_PATH
            Path_XML = Replace(paths_dr, vbCrLf, "") & dr2("Newcode") & ".xml" 'สร้างชื่อ XML
            CREATE_XML_NCT_N_ESUB(Path_XML, dr2("Newcode"), groupname) 'ทำการสร้าง XML
            update_status_nct_esub(Newcode)
            Return "success"
        Next
        Return "False"
    End Function

    Public Sub SEND_XML_NCT_N(ByVal model As LGTNCT)
        Try
            Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
            Dim ws_blockchain_RETURN As New WS_BLOCKCHAIN.XML_RETURN
            Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
            'ws_blockchain_RETURN = ws_blockchain.WS_BLOCK_CHAIN_V2(CLASSTOXMLSTR(model))

            '  ws_fields.PROCESS_ID = model.process_id 'เลขกระบวนการ
            ws_fields.TR_ID = model.NCT.Newcode 'เลขTRANSATION
            ws_fields.REF_TR_ID = "" 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
            ws_fields.IDENTIFY = model.NCT.CITIZEN_AUTHORIZE 'เลขนิติบุคคล
            ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
            ws_fields.SOP_STATUS = model.NCT.cncnm 'สถานะคำขอนะ
            ws_fields.SYSTEM_ID = "NCT" 'เลขสารระบบ
            ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
            ws_fields.XML_DATA = CLASSTOXMLSTR(model) 'classxml ข้อมูล
            ws_blockchain.WS_BLOCK_CHAIN(ws_fields)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CREATE_XML_NCT_N_ESUB(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String)
        Dim cls_xml As New LGTNCT
        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
        cls_xml = Cls_NCT_LCT.gen_xml_LGT_SEARCH_XML_NCT_NNN(DownID)

        Dim objStreamWriter As New StreamWriter(PATH_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
        SEND_XML_NCT_N(cls_xml)

    End Sub
    Private Sub insert_xml_nct_n_esub(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.fields.Newcode = Newcode
        dao_fda_cpn.fields.groupname = groupname
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn.insert()
    End Sub
    Private Sub insert_xml_nct_n_esub(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_NCT
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub
#End Region
End Class
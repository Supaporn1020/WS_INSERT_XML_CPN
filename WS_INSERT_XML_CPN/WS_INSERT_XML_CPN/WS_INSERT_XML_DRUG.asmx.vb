Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class WS_INSERT_XML_DRUG
    Inherits System.Web.Services.WebService
    Dim db As New LGT_XML_CPNDataContext
    Public rows As Integer
    '#Region "ส่ง Newcode มาเพื่อสร้าง xmlทะเบียนยา"
    '    <WebMethod(Description:="ทะเบียนยา+สาร")>
    '    Public Function XML_DRUG_FORMULA(ByVal Newcode As String) As String
    '        ' สร้าง xml ยา ที่มีสาร 
    '        Dim ck_ As String = check_xml(Newcode)
    '        Return ck_
    '    End Function
    '    Private Function check_xml(ByVal Newcode As String)
    '        Dim ck As String = ""
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        Dim Status As String = ""

    '        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง
    '            Dim ck_fda_xml As New DAO_XML_DRUG.TB_XML_SEARCH_PRODUCT_GROUP   'เช็คในตารางพี่บิ๊กว่ามีมั้ย แต่ DRUG ใช้ตารางทราย
    '            ck_fda_xml.GetDataby_Newcode(Newcode)


    '            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
    '                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
    '                BUILD_XML(Newcode)
    '                insert_xml(Newcode, ck_fda_xml.fields.GROUPNAME)   '
    '            End If
    '            '.Replace("", "d")
    '        Else
    '            'เช็คสถานะ ว่าเป็น W หรือ S 
    '            Status = dao_fda_cpn.fields.Status
    '            If Status = "W" Then
    '                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 

    '                BUILD_XML(Newcode)
    '                'update_status(Newcode)
    '            ElseIf Status = "S" Then
    '                'ไม่ต้องทำอะไร
    '                BUILD_XML(Newcode)
    '                'update_status(Newcode)
    '            End If
    '        End If


    '        '--------------------------------------------------------------------------------------------------
    '        'ของทราย
    '        'Dim ck_xml As String

    '        'Dim path As String = "E:\xml\LICENCE\" & Newcode_txt & ".xml"  ' เช็คไฟล์ใน โฟเดอร์ว่ามีชื่อไฟล์นั้นหรือยัง
    '        'If Directory.Exists(path) Then
    '        '    Label2.Text = "มีไฟล์xmlอยู่แล้ว"    'ถ้ามีไฟล์ ไม่ต้องสร้าง xml
    '        '    'Directory.CreateDirectory(path)
    '        'Else
    '        '    Dim ck_Newcode As String

    '        '    ck_Newcode = dao_fda_cpn.fields.Newcode
    '        '    If ck_Newcode = Newcode_txt Then
    '        '        If dao_fda_cpn.fields.Status = "S" Then ' ถ้าสถานะเป็น S ไม่ต้องทำอะไร
    '        '        ElseIf dao_fda_cpn.fields.Status = "W" Then  ' ถ้าสถานะเป็น W ให้สร้าง xml
    '        '            lb_Status.Text = "W"
    '        '            Dim FOOD As String
    '        '            FOOD = "37"         '63 คือ สโต NCT 

    '        '            Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        '            dao_insert.GetDataby_IDA(FOOD)
    '        '            Dim HeadName As String = dao_insert.fields.XML_HEADER
    '        '            Dim BodyName As String = dao_insert.fields.XML_BODY
    '        '            Dim Paths As String = dao_insert.fields.XML_PATH
    '        '            Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

    '        '            Dim b As String = ""
    '        '            Dim Newcode_dt As String
    '        '            Dim dt_detail As New DataTable

    '        '            'For Each fields As XML_CONFIG In Details
    '        '            'Dim HeadName As String = dao_insert.fields.XML_HEADER
    '        '            '    Dim BodyName As String = dao_insert.fields.XML_BODY
    '        '            '    Dim Paths As String = dao_insert.fields.XML_PATH
    '        '            '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

    '        '            Dim clsds As New ClassDataset
    '        '            Dim conn As String = db.Connection.ConnectionString

    '        '            Dim dt As New DataTable

    '        '            'Try
    '        '            steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION


    '        '            dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0)
    '        '            rows = dt.Rows.Count()
    '        '            Label1.Text = steps & " " & rows.ToString()

    '        '            Dim Ms As New MemoryStream
    '        '            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
    '        '            xmlwriter.WriteStartDocument()
    '        '            xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
    '        '            xmlwriter.WriteStartElement(BodyName)    'DRUG
    '        '            'Dim dao As New DAO_DRUG.TB_XML_FRGN

    '        '            For Each dr As DataRow In dt.Rows

    '        '                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
    '        '                If Newcode_dt = Newcode_txt Then
    '        '                    For Each dc As DataColumn In dt.Columns
    '        '                        xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
    '        '                    Next
    '        '                    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

    '        '                Else

    '        '                End If

    '        '            Next
    '        '            xmlwriter.WriteEndElement()    'DRUG/
    '        '            xmlwriter.WriteEndElement()   'LGTDRUG/ 
    '        '            xmlwriter.WriteEndDocument()
    '        '            xmlwriter.Flush()

    '        '            Dim byterarrary As Byte() = Ms.ToArray()
    '        '            Dim oFileStream As System.IO.FileStream

    '        '            'oFileStream = New System.IO.FileStream(Paths & dr(Field_Name).ToString & ".xml", System.IO.FileMode.Create)
    '        '            oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & dao_fda_cpn.fields.Newcode & ".xml", System.IO.FileMode.Create)
    '        '            oFileStream.Write(byterarrary, 0, byterarrary.Length)
    '        '            oFileStream.Close()
    '        '            Ms.Close()

    '        '            'Next
    '        '            dao_fda_cpn.fields.Status = "S"
    '        '            dao_fda_cpn.update()
    '        '            MsgBox("success")
    '        '        End If

    '        '    End If    'อันกลาง ที่เช็คว่า มีxmlในตารางกลางมั้ย
    '        'End If   ' อันนอกสุด
    '        '--------------------------------------------------------------------------------------------------
    '        Return ck
    '    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    '    Private Function BUILD_XML(ByVal Newcode As String)   ' สร้าง xml 
    '        'Dim paths As String = "E:\XML\FDA_LICENSE\DRUG"
    '        'Dim paths As String = "C:\path\XMLALL\XML\" & "XML_DRUG_FORMULA"
    '        Dim dt As New DataTable
    '        Dim groupname As String

    '        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
    '        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
    '        'Dim paths_dr As String = "E:\xml\FDA_LICENSE\DR"
    '        'Dim paths_dh As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DH"
    '        'Dim paths_dh As String = "E:\xml\FDA_LICENSE\DH\"

    '        'ส่ง NEwcodeมาไปwhere หา groupname 
    '        'แยก groupname ไปทำ xml

    '        Dim clsds As New ClassDataset
    '        Dim conn As String = db.Connection.ConnectionString
    '        Dim cut As String = Newcode.Substring(2, 2)
    '        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

    '        Dim STO_NAME As String = dao.fields.XML_SQL
    '        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
    '        STO_NAME &= " @Newcode = '" & Newcode & "'"
    '        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
    '        rows = dt.Rows.Count()

    '        'dt = bao_show.SP_XML_SPECIFIC_DRUG(Newcode)
    '        Dim Path_XML As String
    '        For Each dr2 As DataRow In dt.Rows
    '            groupname = dr2("groupname")
    '            'Path_XML = paths & "\" & dr2("Newcode") & ".xml" 'สร้างชื่อ XML

    '            If groupname = "DR" Then

    '                Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                Dim paths_dr As String = dao_dr.fields.XML_PATH
    '                Path_XML = Replace(paths_dr, vbCrLf, "") & dr2("Newcode_R") & ".xml" 'สร้างชื่อ XML
    '                CREATE_XML_DRUG(Path_XML, dr2("Newcode"), groupname) 'ทำการสร้าง XML
    '                update_status(Newcode)
    '            ElseIf groupname = "DH" Then

    '                Dim dao_dh As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                dao_dh.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                Dim paths_dh As String = dao_dh.fields.XML_PATH
    '                Path_XML = paths_dh & dr2("Newcode") & ".xml" 'สร้างชื่อ XML
    '                CREATE_XML_DRUG(Path_XML, dr2("Newcode"), groupname) 'ทำการสร้าง XML
    '                update_status(Newcode)

    '                'ElseIf groupname = "DI" Then
    '                '    BUILD_XML_DI(dr2("Newcode"))
    '                '    update_status(Newcode)

    '                'ElseIf groupname = "DP" Then
    '                '    BUILD_XML_DP(dr2("Newcode"))
    '                '    update_status(Newcode)

    '                'ElseIf groupname = "DS" Then
    '                '    BUILD_XML_DS(dr2("Newcode"))
    '                '    update_status(Newcode)
    '                Return "success"
    '            Else
    '                Return "False"
    '            End If
    '        Next



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
    '    '    Dim paths As String = "C:\XML\LICENSE\" & "XML_DRUG_FORMULA"
    '    '    'Dim paths As String = "E:\xml\FDA_LICENSE\"

    '    '    Dim dt As New DataTable
    '    '    Dim bao_show As New BAO_DRUG.BAO_DRUG
    '    '    dt = bao_show.SP_XML_SPECIFIC_DRUG(Newcode)


    '    '    If dt.Rows.Count > 0 Then

    '    '        Dim Path_XML As String

    '    '        For Each dr As DataRow In dt.Rows
    '    '            Path_XML = paths & "\" & dr("Newcode_R") & ".xml" 'สร้างชื่อ XML
    '    '            CREATE_XML_DRUG(Path_XML, dr("Newcode")) 'ทำการสร้าง XML 
    '    '        Next
    '    '        update_status(Newcode)
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

    '    Private Sub CREATE_XML_DRUG(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String)
    '        'Dim cls_xml_DH As New LGT_DRUG_DH15
    '        Dim cls_xml_DR As New LGT_IOW_E
    '        Dim cls_xml_DH As New LGT_DRUG_DH15
    '        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '        If groupname = "DH" Then
    '            cls_xml_DH = Cls_NCT_LCT.gen_xml_XML_DRUG_DH15(DownID)
    '            Dim objStreamWriter As New StreamWriter(PATH_XML)
    '            Dim x As New XmlSerializer(cls_xml_DH.GetType)
    '            x.Serialize(objStreamWriter, cls_xml_DH)
    '            objStreamWriter.Close()

    '        ElseIf groupname = "DR" Then
    '            cls_xml_DR = Cls_NCT_LCT.gen_xml_XML_DR_FORMULA(DownID)
    '            Dim objStreamWriter As New StreamWriter(PATH_XML)
    '            Dim x As New XmlSerializer(cls_xml_DR.GetType)
    '            x.Serialize(objStreamWriter, cls_xml_DR)
    '            objStreamWriter.Close()

    '        End If
    '    End Sub
    '    '''' <summary>
    '    '''' สร้าง ไฟล์ XML
    '    '''' </summary>
    '    '''' <param name="PATH_XML"></param>
    '    '''' <remarks></remarks>
    '    'Private Sub CREATE_XML_DRUG(ByVal PATH_XML As String, ByVal Newcode As String)
    '    '    'Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
    '    '    'Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE
    '    '    Dim cls_xml As New LGT_IOW_E
    '    '    Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '    '    cls_xml = Cls_NCT_LCT.gen_xml_XML_DR_FORMULA(Newcode)


    '    '    Dim objStreamWriter As New StreamWriter(PATH_XML)
    '    '    Dim x As New XmlSerializer(cls_xml.GetType)
    '    '    x.Serialize(objStreamWriter, cls_xml)
    '    '    objStreamWriter.Close()
    '    'End Sub
    '    Private Sub insert_xml(ByVal Newcode As String, ByVal groupname As String)
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
    '        dao_fda_cpn.fields.Newcode = Newcode
    '        dao_fda_cpn.fields.groupname = groupname
    '        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
    '        dao_fda_cpn.fields.Status = "S"
    '        dao_fda_cpn.fields.CREATE_DATE_INSERT_XML = DateTime.Now
    '        dao_fda_cpn.insert()
    '    End Sub
    '    Private Sub update_status(ByVal Newcode As String)
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        dao_fda_cpn.fields.Status = "S"
    '        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
    '        dao_fda_cpn.update()
    '    End Sub      'function update Status 
    '#End Region
    '#Region "ส่ง Newcode มาเพื่อ Delete แล้ว insert ใหม่"
    '    <WebMethod(Description:="ทะเบียนยา+สาร_delete")>
    '    Public Function XML_DRUG_FORMULA_DELETE(ByVal Newcode As String) As String
    '        'ส่ง Newcode มา ลบ แถวนั้นใน table
    '        'แล้วเอา Newcode ไป where ใน query แล้วสร้างใหม่
    '        Dim ck As String = "insert เสร็จ"
    '        Dim ck_Newcode As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
    '        ck_Newcode.GetDataby_Newcode(Newcode)

    '        Try
    '            delete_xml(Newcode)
    '            insert_xml_new(Newcode, ck_Newcode.fields.groupname)
    '        Catch ex As Exception
    '            ck = "False"
    '        End Try
    '        Return ck
    '    End Function
    '    Private Sub delete_xml(ByVal Newcode As String)
    '        Dim dao_fda_cpn As New DAO_XML_DRUG.TB_XML_SEARCH_PRODUCT_GROUP
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        dao_fda_cpn.delete()
    '    End Sub
    '    Private Sub insert_xml_new(ByVal Newcode As String, ByVal groupname As String)
    '        Dim bao_insert As New BAO_DRUG.BAO_DRUG
    '        If groupname = "DR" Then
    '            ' เข้า sto insert DR
    '            bao_insert.SP_INSERT_DRUG_DR(Newcode)
    '        ElseIf groupname = "DH" Then
    '            ' เข้า sto insert DH
    '            bao_insert.SP_INSERT_DRUG_DH(Newcode)
    '        ElseIf groupname = "DI" Then
    '            ' เข้า sto insert DI
    '            bao_insert.SP_INSERT_DRUG_DI(Newcode)
    '        ElseIf groupname = "DP" Then
    '            ' เข้า sto insert DP
    '            bao_insert.SP_INSERT_DRUG_DP(Newcode)
    '        ElseIf groupname = "DS" Then
    '            ' เข้า sto insert DS
    '            bao_insert.SP_INSERT_DRUG_DS(Newcode)
    '        End If
    '    End Sub
    '#End Region
#Region "ส่ง Newcode มาเพื่อสร้าง xmlใบอนุญาตยา"
    <WebMethod(Description:="ใบอนุญาตยา")>
    Public Function XML_DRUG_LICENSE(ByVal Newcode As String) As String
        ' สร้าง xml ยา ที่มีสาร 
        Dim ck_ As String = check_xml_lcn(Newcode)

        Return ck_
    End Function
    Private Function check_xml_lcn(ByVal Newcode As String)
        Dim ck As String = ""
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim Status As String = ""

        If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง
            Dim ck_fda_xml As New DAO_XML_DRUG.TB_XML_SEARCH_DRUG_LCN   'เช็คในตารางพี่บิ๊กว่ามีมั้ย แต่ DRUG ใช้ตารางทราย
            ck_fda_xml.GetDataby_Newcode(Newcode)


            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                ck = BUILD_XML_LCN(Newcode)
                insert_xml_lcn(Newcode, ck_fda_xml.fields.GROUPNAME)   '
            End If
            '.Replace("", "d")
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                ck = BUILD_XML_LCN(Newcode)
                'update_status_lcn(Newcode)

            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                ck = BUILD_XML_LCN(Newcode)
                'update_status_lcn(Newcode)
            End If
        End If


        '--------------------------------------------------------------------------------------------------
        'ของทราย
        'Dim ck_xml As String

        'Dim path As String = "E:\xml\LICENCE\" & Newcode_txt & ".xml"  ' เช็คไฟล์ใน โฟเดอร์ว่ามีชื่อไฟล์นั้นหรือยัง
        'If Directory.Exists(path) Then
        '    Label2.Text = "มีไฟล์xmlอยู่แล้ว"    'ถ้ามีไฟล์ ไม่ต้องสร้าง xml
        '    'Directory.CreateDirectory(path)
        'Else
        '    Dim ck_Newcode As String

        '    ck_Newcode = dao_fda_cpn.fields.Newcode
        '    If ck_Newcode = Newcode_txt Then
        '        If dao_fda_cpn.fields.Status = "S" Then ' ถ้าสถานะเป็น S ไม่ต้องทำอะไร
        '        ElseIf dao_fda_cpn.fields.Status = "W" Then  ' ถ้าสถานะเป็น W ให้สร้าง xml
        '            lb_Status.Text = "W"
        '            Dim FOOD As String
        '            FOOD = "37"         '63 คือ สโต NCT 

        '            Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        '            dao_insert.GetDataby_IDA(FOOD)
        '            Dim HeadName As String = dao_insert.fields.XML_HEADER
        '            Dim BodyName As String = dao_insert.fields.XML_BODY
        '            Dim Paths As String = dao_insert.fields.XML_PATH
        '            Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        '            Dim b As String = ""
        '            Dim Newcode_dt As String
        '            Dim dt_detail As New DataTable

        '            'For Each fields As XML_CONFIG In Details
        '            'Dim HeadName As String = dao_insert.fields.XML_HEADER
        '            '    Dim BodyName As String = dao_insert.fields.XML_BODY
        '            '    Dim Paths As String = dao_insert.fields.XML_PATH
        '            '    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        '            Dim clsds As New ClassDataset
        '            Dim conn As String = db.Connection.ConnectionString

        '            Dim dt As New DataTable

        '            'Try
        '            steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION


        '            dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0)
        '            rows = dt.Rows.Count()
        '            Label1.Text = steps & " " & rows.ToString()

        '            Dim Ms As New MemoryStream
        '            Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
        '            xmlwriter.WriteStartDocument()
        '            xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
        '            xmlwriter.WriteStartElement(BodyName)    'DRUG
        '            'Dim dao As New DAO_DRUG.TB_XML_FRGN

        '            For Each dr As DataRow In dt.Rows

        '                Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
        '                If Newcode_dt = Newcode_txt Then
        '                    For Each dc As DataColumn In dt.Columns
        '                        xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
        '                    Next
        '                    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

        '                Else

        '                End If

        '            Next
        '            xmlwriter.WriteEndElement()    'DRUG/
        '            xmlwriter.WriteEndElement()   'LGTDRUG/ 
        '            xmlwriter.WriteEndDocument()
        '            xmlwriter.Flush()

        '            Dim byterarrary As Byte() = Ms.ToArray()
        '            Dim oFileStream As System.IO.FileStream

        '            'oFileStream = New System.IO.FileStream(Paths & dr(Field_Name).ToString & ".xml", System.IO.FileMode.Create)
        '            oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & dao_fda_cpn.fields.Newcode & ".xml", System.IO.FileMode.Create)
        '            oFileStream.Write(byterarrary, 0, byterarrary.Length)
        '            oFileStream.Close()
        '            Ms.Close()

        '            'Next
        '            dao_fda_cpn.fields.Status = "S"
        '            dao_fda_cpn.update()
        '            MsgBox("success")
        '        End If

        '    End If    'อันกลาง ที่เช็คว่า มีxmlในตารางกลางมั้ย
        'End If   ' อันนอกสุด
        '--------------------------------------------------------------------------------------------------
        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Function BUILD_XML_LCN(ByVal Newcode As String)   ' สร้าง xml 

        Dim paths As String = "C:\XML\LICENSE\" & "XML_DRUG_LICENSE"
        'Dim paths As String = "C:\path\XMLALL\XML\" & "XML_DRUG_LICENSE"

        Dim dt As New DataTable
        Dim bao_show As New BAO_DRUG.BAO_DRUG
        dt = bao_show.SP_GENXML_SEARCH_DRUG_LCN_HEAD(Newcode)


        If dt.Rows.Count > 0 Then

            Dim Path_XML As String
            For Each dr As DataRow In dt.Rows
                Path_XML = paths & "\" & dr("Newcode_not") & ".xml" 'สร้างชื่อ XML
                CREATE_XML_LICENSE(Path_XML, dr("Newcode_not")) 'ทำการสร้าง XML 
            Next
            update_status_lcn(Newcode)
            Return "success"
        Else

            Return "False"
        End If



        'Dim FOOD As String
        'FOOD = "37"         '63 คือ สโต NCT 
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        'dao_insert.GetDataby_IDA(FOOD)
        'Dim HeadName As String = dao_insert.fields.XML_HEADER
        'Dim BodyName As String = dao_insert.fields.XML_BODY
        'Dim Paths As String = dao_insert.fields.XML_PATH
        'Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        'Dim b As String = ""
        'Dim Newcode_dt As String
        'Dim dt_detail As New DataTable

        ''For Each fields As XML_CONFIG In Details
        ''Dim HeadName As String = dao_insert.fields.XML_HEADER
        ''    Dim BodyName As String = dao_insert.fields.XML_BODY
        ''    Dim Paths As String = dao_insert.fields.XML_PATH
        ''    Dim Field_Name As String = dao_insert.fields.XML_FIELDS_NAME

        'Dim clsds As New ClassDataset
        'Dim conn As String = db.Connection.ConnectionString

        'Dim dt As New DataTable

        ''Try
        'steps = "เรียกดูข้อมูล " & dao_insert.fields.XML_DESCRIPTION
        'Dim bao_food_fg As New BAO_LO.BAO_LO
        'dt = bao_food_fg.SP_CPN_CONVERT_FOOD(Newcode_txt)
        ''dt = clsds.dsQueryselect(dao_insert.fields.XML_SQL, conn).Tables(0) 'เอา Newcode มา where ตรงนี้
        'rows = dt.Rows.Count()
        'lb_Newcode_food.Text = steps & " " & rows.ToString()

        'Dim Ms As New MemoryStream
        'Dim xmlwriter As New XmlTextWriter(Ms, System.Text.Encoding.UTF8)
        'xmlwriter.WriteStartDocument()
        'xmlwriter.WriteStartElement(HeadName)   'LGTDRUG 
        'xmlwriter.WriteStartElement(BodyName)    'DRUG
        ''Dim dao As New DAO_DRUG.TB_XML_FRGN

        'For Each dr As DataRow In dt.Rows

        '    Newcode_dt = dr("Newcode")   'ใส้ใน  คือ detail
        '    'If Newcode_dt = Newcode_txt Then
        '    For Each dc As DataColumn In dt.Columns
        '        xmlwriter.WriteElementString(dc.ColumnName, dr(dc.ColumnName).ToString())
        '    Next
        '    '    xmlwriter.WriteRaw(XML_DRUG_DATA(Newcode_dt)) 'head , value   ส่ง Newcodeไปที่ฟังก์ชัน XML_DRUG_DATA

        '    'Else

        '    'End If

        'Next
        'xmlwriter.WriteEndElement()    'DRUG/
        'xmlwriter.WriteEndElement()   'LGTDRUG/ 
        'xmlwriter.WriteEndDocument()
        'xmlwriter.Flush()

        'Dim byterarrary As Byte() = Ms.ToArray()
        'Dim oFileStream As System.IO.FileStream

        ''oFileStream = New System.IO.FileStream(Paths & dr(Field_Name).ToString & ".xml", System.IO.FileMode.Create)
        ''oFileStream = New System.IO.FileStream("E:\xml\LICENCE\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
        'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD_TEST\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
        'oFileStream.Write(byterarrary, 0, byterarrary.Length)
        'oFileStream.Close()
        'Ms.Close()

    End Function
    ''' <summary>
    ''' สร้าง ไฟล์ XML
    ''' </summary>
    ''' <param name="PATH_XML"></param>
    ''' <remarks></remarks>
    Private Sub CREATE_XML_LICENSE(ByVal PATH_XML As String, ByVal DownID As String)
        'Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
        'Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE
        Dim cls_xml As New LGT_XML_DRUG_LCN_CENTER
        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
        cls_xml = Cls_NCT_LCT.gen_xml_LGT_XML_DRUG_LCN(DownID)
        Dim objStreamWriter As New StreamWriter(PATH_XML)
        Dim x As New XmlSerializer(cls_xml.GetType)
        x.Serialize(objStreamWriter, cls_xml)
        objStreamWriter.Close()
    End Sub
    Private Sub insert_xml_lcn(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        dao_fda_cpn.fields.Newcode = Newcode
        dao_fda_cpn.fields.groupname = groupname
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn.insert()
    End Sub
    Private Sub update_status_lcn(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
#End Region
#Region "ส่ง Newcode ใบอนุญาตมา มาเพื่อ Delete แล้ว insert ใหม่"
    <WebMethod(Description:="ใบอนุญาต_delete")>
    Public Function XML_DRUG_LICENSE_DELETE(ByVal Newcode As String) As String
        'ส่ง Newcode มา ลบ แถวนั้นใน table ใบอนุญาต และ table ผู้มีหน้าที่ปฏิบัติการ
        'แล้วเอา Newcode ไป where ใน query แล้วสร้างใหม่
        Dim ck As String = "insert เสร็จ"
        Dim ck_Newcode As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        ck_Newcode.GetDataby_Newcode(Newcode)
        Try
            'delete_xml_lcn(Newcode)
            insert_xml_new_lcn(Newcode, ck_Newcode.fields.groupname)

        Catch ex As Exception
            ck = "False"
        End Try


        Return ck
    End Function

    Private Sub delete_xml_lcn(ByVal Newcode As String)
        Try
            Dim dao_fda_cpn As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_DRUG_LCN_ESUB
            dao_fda_cpn.GetDataby_Newcode(Newcode)
            dao_fda_cpn.delete()

            Dim dao_fda_pharm As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_PHARMACY_ESUB
            dao_fda_pharm.GetDataby_Newcode(Newcode)
            dao_fda_pharm.delete()

            'Dim dao_fda_licen As New DAO_XML_DRUG.TB_XML_SEARCH_DRUG_LCN_LICEN
            'dao_fda_licen.GetDataby_Newcode(Newcode)
            'dao_fda_licen.delete()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub insert_xml_new_lcn(ByVal Newcode As String, ByVal groupname As String)
        Dim bao_insert As New BAO_DRUG.BAO_DRUG
        If groupname = "LCN" Then
            ' เข้า sto insert DR
            bao_insert.SP_INSERT_DRUG_LCN(Newcode)
            bao_insert.SP_INSERT_DRUG_LCN_PHARMACY(Newcode)
            'bao_insert.SP_INSERT_DRUG_LCN_PHARMACY(Newcode)
        Else

        End If




    End Sub

#End Region
    <WebMethod(Description:="DRUG_DH_DI_DP_DS")>
    Public Function XML_DRUG_DH_DI_DP_DS(ByVal Newcode As String)
        Dim ck_ As String = check_xml_DRUG_DH_DI_DP_DS(Newcode)
        Return ck_
    End Function
    Private Function check_xml_DRUG_DH_DI_DP_DS(ByVal Newcode As String) As String
        Dim ck As String = ""
        Dim Status As String = ""
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim ck_fda_xml As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB

        If dao_fda_cpn.fields.IDA = 0 Then 'ไม่มี xml ใน ตารางเช็คสถานะ
            ck_fda_xml.GetDataby_Newcode(Newcode) 'เอา Newcode จากตารางพี่บิ๊กไป insert 
            insert_xml_drug_esub(Newcode, ck_fda_xml.fields.GROUPNAME) ' insert Newcode ลงตารางเช็คสถานะ

            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                ck = BUILD_XML_DRUG_DH_DI_DP_DS(Newcode)
                update_status_drug_esub(Newcode)   '
            End If
        Else
            'เช็คสถานะ ว่าเป็น W หรือ S 
            Status = dao_fda_cpn.fields.Status
            If Status = "W" Then
                'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 
                ck = BUILD_XML_DRUG_DH_DI_DP_DS(Newcode)
                update_status_drug_esub(Newcode)
            ElseIf Status = "S" Then
                'ไม่ต้องทำอะไร
                ck = BUILD_XML_DRUG_DH_DI_DP_DS(Newcode)
                update_status_drug_esub(Newcode)
                'BUILD_XML(Newcode_txt)
                'update_status(Newcode_txt)
                'ElseIf Status = "F" Then
                '    BUILD_XML(Newcode_txt)
                '    update_status_F(Newcode_txt)
            End If
        End If
        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Function BUILD_XML_DRUG_DH_DI_DP_DS(ByVal Newcode_txt As String)
        'sto DH เดิมเป็น exec dbo.SP_CPN_CONVERT_DRUG
        'sto DI_DP_DS เดิมเป็น exec dbo.SP_CPN_CONVERT_DRUG_DI_DP_DS
        Dim cut As String = Newcode_txt.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "2")

        Dim dao_product As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        dao_product.GetDataby_Newcode(Newcode_txt)

        If cut = "DH" Then

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
            STO_NAME &= " @IDA_dh15rqt = '" & dao_product.fields.IDA_dh15rqt & "'"
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
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                Return "success"

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

        Else

            If cut = "DZ" Then

                Dim cut_z As String = Newcode_txt.Substring(2, 3)
                dao.GetDataby_GROUPNAME_TYPE(cut_z, "2")

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
                        'groupname = dr("groupname")
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
                    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                    oFileStream.Close()
                    Ms.Close()
                    Return "success"

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



            Else


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
                        'groupname = dr("groupname")
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
                    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                    oFileStream.Close()
                    Ms.Close()
                    Return "success"

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

            End If

        End If


    End Function

#Region "DBใหม่ส่ง Newcode มาเพื่อสร้าง xmlทะเบียนยา"
    <WebMethod(Description:="ทะเบียนยา+สาร")>
    Public Function XML_DRUG_FORMULA(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String) As String
        ' สร้าง xml ยา ที่มีสาร 
        Dim ck_ As String = check_xml_drug_esub(Newcode, IDENTIFY_EDIT)
        Return ck_
    End Function
    Private Function check_xml_drug_esub(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)
        Dim ck As String = ""
        'Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        'dao_fda_cpn.GetDataby_Newcode(Newcode)
        Dim Status As String = ""
        Dim ck_fda_xml As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB   'เช็คในตารางพี่บิ๊กว่ามีมั้ย แต่ DRUG ใช้ตารางทราย
        ck_fda_xml.GetDataby_Newcode(Newcode)

        Dim des As String
        Dim dao_log As New DAO_XML_DRUG_SEUB.TB_tb_log_temp
        des = "START FC::XML_DRUG_FORMULA"
        des_log(Newcode, IDENTIFY_EDIT, des, "สร้าง xml ทะเบียนยา")
        'ใคร(เลขบัตรใคร) IDENTIFY_EDIT
        'ทำอะไร(remark)  remark
        'ที่ไหน(ระบบไหนsystem) system
        'เมื่อไร(เวลา) 
        'อย่างไร(ขั้นตอน) des


        Try
            'If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง

            '----------------------log_xml
            'des = "START FC:XML_DRUG_FORMULA :check Newcod TB XML_CPN_KEEP_DRUG"
            'dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
            'dao_log.fields.log_date = Date.Now
            'dao_log.fields.log_des = "check Newcod TB XML_CPN_KEEP_DRUG"
            'dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
            'dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
            'dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
            'dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
            'dao_log.insert()
            '----------------------log_xml

            If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
                    'สร้าง xml  แล้ว insert  สถานะ เป็น S 
                    BUILD_XML_DRUG_ESUB(Newcode, IDENTIFY_EDIT)
                    insert_xml_drug_esub(Newcode, ck_fda_xml.fields.GROUPNAME)   '
                End If
            '.Replace("", "d")
            '----------------------log_xml
            'dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
            'dao_log.fields.log_date = Date.Now
            'dao_log.fields.log_des = "check Newcod TB XML_CPN_KEEP_DRUG success"
            'dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
            'dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
            'dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
            'dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
            'dao_log.insert()
            'des = "START FC:XML_DRUG_FORMULA :check Newcod TB XML_CPN_KEEP_DRUG success"
            '----------------------log_xml
            'Else
            '    '----------------------log_xml
            '    'des = "START FC:XML_DRUG_FORMULA :check status  W or S TB XML_CPN_KEEP_DRUG"
            '    'dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
            '    'dao_log.fields.log_date = Date.Now
            '    'dao_log.fields.log_des = "check status  W or S TB XML_CPN_KEEP_DRUG"
            '    'dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
            '    'dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
            '    'dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
            '    'dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
            '    'dao_log.insert()
            '    '----------------------log_xml

            '    ''เช็คสถานะ ว่าเป็น W หรือ S 
            '    'Status = dao_fda_cpn.fields.Status
            '    'If Status = "W" Then
            '    '    'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 

            '    '    BUILD_XML_DRUG_ESUB(Newcode, IDENTIFY_EDIT)
            '    '    'update_status(Newcode)
            '    'ElseIf Status = "S" Then
            '    '    'ไม่ต้องทำอะไร
            '    '    BUILD_XML_DRUG_ESUB(Newcode, IDENTIFY_EDIT)
            '    '    'update_status(Newcode)
            '    'End If

            '    BUILD_XML_DRUG_ESUB(Newcode, IDENTIFY_EDIT)
            'End If
            des = "START FC:XML_DRUG_FORMULA : create xml success"
            des_log(Newcode, IDENTIFY_EDIT, des, "สร้าง xml ทะเบียนยา")
            'dao_log = New DAO_XML_DRUG_SEUB.TB_tb_log_temp
            'dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
            'dao_log.fields.log_date = Date.Now
            'dao_log.fields.log_des = "create xml success"
            'dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
            'dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
            'dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
            'dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
            'dao_log.insert()
        Catch ex As Exception
            Dim title As String
            Dim Content As String
            title = "ERROR การสร้าง xml ยาที่ WS_INSERT_XML_CPN " & Newcode
            des_log(Newcode, IDENTIFY_EDIT, des, ex.Message)
            Content = Newcode & " : " & des

            SendMail(Content, "therdsak@fsa.co.th", title) 'พี่ x
            SendMail(Content, "puwadol@fsa.co.th", title) 'พี่บิ๊ก
            SendMail(Content, "supaporn.s@fsa.co.th", title) 'ทราย
            SendMail(Content, "koeza2009@gmail.com", title) 'ก้อ
            SendMail(Content, "Amornsak.y@fsa.co.th", title) 'นน
            SendMail(Content, "moszazeed9@gmail.com", title) 'มอส

        End Try

        Return ck
    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    Private Function BUILD_XML_DRUG_ESUB(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)   ' สร้าง xml 
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

            If groupname = "DR" Then
                BUILD_XML_DI(dr2("Newcode"))
                Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
                'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
                dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
                Dim paths_dr As String = dao_dr.fields.XML_PATH
                Path_XML = Replace(paths_dr, vbCrLf, "") & dr2("Newcode_R") & ".xml" 'สร้างชื่อ XML 'จากเดิมเป็น Newcode_R
                CREATE_XML_DRUG_ESUB(Path_XML, dr2("Newcode"), groupname, IDENTIFY_EDIT) 'ทำการสร้าง XML 'จากเดิมเป็น Newcode
                update_status_drug_esub(Newcode)

            ElseIf groupname = "DH" Then

                Dim dao_dh As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
                'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
                dao_dh.GetDataby_GROUPNAME_TYPE(groupname, "1")
                Dim paths_dh As String = dao_dh.fields.XML_PATH
                Path_XML = paths_dh & dr2("Newcode") & ".xml" 'สร้างชื่อ XML
                CREATE_XML_DRUG_ESUB(Path_XML, dr2("Newcode"), groupname, IDENTIFY_EDIT) 'ทำการสร้าง XML
                update_status_drug_esub(Newcode)

                'ElseIf groupname = "DI" Then
                '    BUILD_XML_DI(dr2("Newcode"))
                '    update_status(Newcode)

                'ElseIf groupname = "DP" Then
                '    BUILD_XML_DP(dr2("Newcode"))
                '    update_status(Newcode)

                'ElseIf groupname = "DS" Then
                '    BUILD_XML_DS(dr2("Newcode"))
                '    update_status(Newcode)
                Return "success"
            Else
                Return "False"
            End If
        Next
    End Function
    Private Sub CREATE_XML_DRUG_ESUB(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String, ByVal IDENTIFY_EDIT As String)
        'Dim cls_xml_DH As New LGT_DRUG_DH15
        Dim cls_xml_DR As New LGT_IOW_E
        Dim cls_xml_DH As New LGT_DRUG_DH15
        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
        If groupname = "DH" Then
            cls_xml_DH = Cls_NCT_LCT.gen_xml_XML_DRUG_DH15(DownID)
            Dim objStreamWriter As New StreamWriter(PATH_XML)
            Dim x As New XmlSerializer(cls_xml_DH.GetType)
            x.Serialize(objStreamWriter, cls_xml_DH)
            objStreamWriter.Close()
            SEND_XML_DH(cls_xml_DH, DownID, IDENTIFY_EDIT)
        ElseIf groupname = "DR" Then
            cls_xml_DR = Cls_NCT_LCT.gen_xml_XML_DR_FORMULA_E_SUB_TXT(DownID)
            Dim objStreamWriter As New StreamWriter(PATH_XML)
            Dim x As New XmlSerializer(cls_xml_DR.GetType)
            x.Serialize(objStreamWriter, cls_xml_DR)
            objStreamWriter.Close()
            SEND_XML_DR(cls_xml_DR, DownID, IDENTIFY_EDIT)
        End If
    End Sub
    Public Sub SEND_XML_DH(ByVal model As LGT_DRUG_DH15, ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)
        'Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        'Dim ws_blockchain_RETURN As New WS_BLOCKCHAIN.XML_RETURN
        'Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
        ''ws_blockchain_RETURN = ws_blockchain.WS_BLOCK_CHAIN_V2(CLASSTOXMLSTR(model))

        ''  ws_fields.PROCESS_ID = model.process_id 'เลขกระบวนการ
        'ws_fields.TR_ID = Newcode
        'ws_fields.REF_TR_ID = "" 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
        'ws_fields.IDENTIFY = "1309800203775"
        'ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
        'ws_fields.SOP_STATUS = ""
        'ws_fields.SYSTEM_ID = "DRUG" 'เลขสารระบบ
        'ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
        'ws_fields.XML_DATA = CLASSTOXMLSTR(model) 'classxml ข้อมูล
        'ws_blockchain.WS_BLOCK_CHAIN(ws_fields)
        Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
        'Dim ws As New WS_DRUG.WS_DRUG
        'Dim XML_LGT As New LGT_IOW_E
        'Dim xml_str = ws.XML_GET_DRUG_ESUB("DRUG", "XML_PRODUCT", a.Newcode_U) '2.ดึง xml ที่สร้างไว้ที่ 107 มาทำข้อ 3 
        'XML_LGT = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str) '3.เอา xml จากข้อ 2 มาแปลงเป็น str ส่งเข้า BC


        'ws_fields.PROCESS_ID = 3181 'เลขกระบวนการ
        ws_fields.TR_ID = Newcode 'เลขTRANSATION
        ws_fields.REF_TR_ID = "" 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
        ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคล 1103701216867คือเลขบัตรนน
        ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
        ws_fields.SOP_STATUS = 8 'สถานะคำขอนะ
        ws_fields.SYSTEM_ID = "DRUG" 'เลขสารระบบ
        ws_fields.SOP_REMARK = "อัพเดทโดยระบบ" 'ความเห็น จนทที่พิมพ์มา
        ws_fields.XML_DATA = CLASSTOXMLSTR(model) 'classxml ข้อมูล
        ws_blockchain.WS_BLOCK_CHAIN_V3(ws_fields)
    End Sub
    Public Sub SEND_XML_DR(ByVal model As LGT_IOW_E, ByVal Newcode As String, ByVal IDENTIFY_EDIT As String)
        'Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        'Dim ws_blockchain_RETURN As New WS_BLOCKCHAIN.XML_RETURN
        'Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
        ''ws_blockchain_RETURN = ws_blockchain.WS_BLOCK_CHAIN_V2(CLASSTOXMLSTR(model))

        ''  ws_fields.PROCESS_ID = model.process_id 'เลขกระบวนการ
        'ws_fields.TR_ID = Newcode
        'ws_fields.REF_TR_ID = "" 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
        'ws_fields.IDENTIFY = IDENTIFY_EDIT  '1103701216867 เลขนน
        'ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
        'ws_fields.SOP_STATUS = model.XML_SEARCH_DRUG_DR.cncnm
        'ws_fields.SYSTEM_ID = "DRUG" 'เลขสารระบบ
        'ws_fields.SOP_REMARK = "" 'ความเห็น จนทที่พิมพ์มา
        'ws_fields.XML_DATA = CLASSTOXMLSTR(model) 'classxml ข้อมูล
        'ws_blockchain.WS_BLOCK_CHAIN(ws_fields)

        Dim ws_blockchain As New WS_BLOCKCHAIN.WS_BLOCKCHAIN
        Dim ws_fields As New WS_BLOCKCHAIN.XML_BLOCK
        'Dim ws As New WS_DRUG.WS_DRUG
        'Dim XML_LGT As New LGT_IOW_E
        'Dim xml_str = ws.XML_GET_DRUG_ESUB("DRUG", "XML_PRODUCT", a.Newcode_U) '2.ดึง xml ที่สร้างไว้ที่ 107 มาทำข้อ 3 
        'XML_LGT = ConvermXmlstr_TO_CLASS(Of LGT_IOW_E)(xml_str) '3.เอา xml จากข้อ 2 มาแปลงเป็น str ส่งเข้า BC


        'ws_fields.PROCESS_ID = 3181 'เลขกระบวนการ
        ws_fields.TR_ID = Newcode 'เลขTRANSATION
        ws_fields.REF_TR_ID = "" 'ตรงนี้ยังไม่ต้องใส่มาเดียวจะอธิบายอีกที
        ws_fields.IDENTIFY = IDENTIFY_EDIT 'เลขนิติบุคคล 1103701216867คือเลขบัตรนน
        ws_fields.SEND_TIME = Date.Now 'วันเวลาที่ส่งเข้ามา
        ws_fields.SOP_STATUS = 8 'สถานะคำขอนะ
        ws_fields.SYSTEM_ID = "DRUG" 'เลขสารระบบ
        ws_fields.SOP_REMARK = "อัพเดทโดยระบบ" 'ความเห็น จนทที่พิมพ์มา
        ws_fields.XML_DATA = CLASSTOXMLSTR(model) 'classxml ข้อมูล
        ws_blockchain.WS_BLOCK_CHAIN_V3(ws_fields)

    End Sub
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
    '''' <summary>
    '''' สร้าง ไฟล์ XML
    '''' </summary>
    '''' <param name="PATH_XML"></param>
    '''' <remarks></remarks>
    'Private Sub CREATE_XML_DRUG(ByVal PATH_XML As String, ByVal Newcode As String)
    '    'Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
    '    'Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE
    '    Dim cls_xml As New LGT_IOW_E
    '    Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '    cls_xml = Cls_NCT_LCT.gen_xml_XML_DR_FORMULA(Newcode)


    '    Dim objStreamWriter As New StreamWriter(PATH_XML)
    '    Dim x As New XmlSerializer(cls_xml.GetType)
    '    x.Serialize(objStreamWriter, cls_xml)
    '    objStreamWriter.Close()
    'End Sub
    Private Sub insert_xml_drug_esub(ByVal Newcode As String, ByVal groupname As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        dao_fda_cpn.fields.Newcode = Newcode
        dao_fda_cpn.fields.groupname = groupname
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE_INSERT_XML = DateTime.Now
        dao_fda_cpn.insert()
    End Sub
    Private Sub update_status_drug_esub(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        dao_fda_cpn.fields.Status = "S"
        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
        dao_fda_cpn.update()
    End Sub      'function update Status 
    Private Sub des_log(ByVal Newcode As String, ByVal IDENTIFY_EDIT As String, ByVal des As String, ByVal remark As String)
        'ใคร(เลขบัตรใคร) IDENTIFY_EDIT
        'ทำอะไร(remark)  remark
        'ที่ไหน(ระบบไหนsystem) system
        'เมื่อไร(เวลา) 
        'อย่างไร(ขั้นตอน) des
        Dim dao_log As New DAO_XML_DRUG_SEUB.TB_tb_log_temp
        With dao_log
            .fields.Newcode = Newcode
            .fields.system = "สร้าง xml จาก WS_INSERT_XML_CPN"
            .fields.log_des = des 'รายละเอียดแต่ละขั้นตอน
            .fields.remark = remark 'แก้ไขอะไร
            .fields.IDENTIFY_EDIT = IDENTIFY_EDIT 'เลขจากใครที่แก้ไข
            .fields.groupname = "DR"
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

    Private Function BUILD_XML_DRUG_DR(ByVal Newcode_txt As String)
        'sto DH เดิมเป็น exec dbo.SP_CPN_CONVERT_DRUG
        'sto DI_DP_DS เดิมเป็น exec dbo.SP_CPN_CONVERT_DRUG_DI_DP_DS
        Dim cut As String = Newcode_txt.Substring(2, 2)
        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
        dao.GetDataby_GROUPNAME_TYPE(cut, "2")

        Dim dao_product As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        dao_product.GetDataby_Newcode(Newcode_txt)

        If cut = "DH" Then

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
            STO_NAME &= " @IDA_dh15rqt = '" & dao_product.fields.IDA_dh15rqt & "'"
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
                'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                oFileStream.Write(byterarrary, 0, byterarrary.Length)
                oFileStream.Close()
                Ms.Close()
                Return "success"

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

        Else

            If cut = "DZ" Then

                Dim cut_z As String = Newcode_txt.Substring(2, 3)
                dao.GetDataby_GROUPNAME_TYPE(cut_z, "2")

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
                        'groupname = dr("groupname")
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
                    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                    oFileStream.Close()
                    Ms.Close()
                    Return "success"

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



            Else


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
                        'groupname = dr("groupname")
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
                    'oFileStream = New System.IO.FileStream("E:\xml\FDA_LICENSE\FOOD2\" & Newcode_txt & ".xml", System.IO.FileMode.Create)
                    'oFileStream = New System.IO.FileStream("C:\XML\LICENSE\FOOD2\" & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream = New System.IO.FileStream(Replace(dao.fields.XML_PATH, vbCrLf, "") & Newcode_dt & ".xml", System.IO.FileMode.Create)
                    oFileStream.Write(byterarrary, 0, byterarrary.Length)
                    oFileStream.Close()
                    Ms.Close()
                    Return "success"

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

            End If

        End If


    End Function


#End Region
#Region "ส่ง Newcode มาเพื่อ Delete แล้ว insert ใหม่"
    <WebMethod(Description:="ทะเบียนยา+สาร_delete")>
    Public Function XML_DRUG_FORMULA_DELETE(ByVal Newcode As String) As String
        'ส่ง Newcode มา ลบ แถวนั้นใน table
        'แล้วเอา Newcode ไป where ใน query แล้วสร้างใหม่
        Dim ck As String = "insert เสร็จ"
        Dim ck_Newcode As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
        ck_Newcode.GetDataby_Newcode(Newcode)

        Try
            delete_xml(Newcode)
            insert_xml_new(Newcode, ck_Newcode.fields.groupname)
        Catch ex As Exception
            ck = "False"
        End Try
        Return ck
    End Function
    Private Sub delete_xml(ByVal Newcode As String)
        Dim dao_fda_cpn As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        dao_fda_cpn.GetDataby_Newcode(Newcode)
        dao_fda_cpn.delete()
    End Sub
    Private Sub insert_xml_new(ByVal Newcode As String, ByVal groupname As String)
        Dim bao_insert As New BAO_DRUG.BAO_DRUG
        If groupname = "DR" Then
            ' เข้า sto insert DR
            bao_insert.SP_INSERT_DRUG_DR(Newcode)
        ElseIf groupname = "DH" Then
            ' เข้า sto insert DH
            bao_insert.SP_INSERT_DRUG_DH(Newcode)
        ElseIf groupname = "DI" Then
            ' เข้า sto insert DI
            bao_insert.SP_INSERT_DRUG_DI(Newcode)
        ElseIf groupname = "DP" Then
            ' เข้า sto insert DP
            bao_insert.SP_INSERT_DRUG_DP(Newcode)
        ElseIf groupname = "DS" Then
            ' เข้า sto insert DS
            bao_insert.SP_INSERT_DRUG_DS(Newcode)
        End If
    End Sub
#End Region
    '#Region "XML_DRUG_FORMULA_BC"
    '    <WebMethod(Description:="ทะเบียนยา+สาร")>
    '    Public Function XML_DRUG_FORMULA_BC(ByVal Newcode As String) As String
    '        ' สร้าง xml ยา ที่มีสาร 
    '        Dim ck_ As String = check_xml_drug_esub_bc(Newcode)
    '        Return ck_
    '    End Function
    '    Private Function check_xml_drug_esub_bc(ByVal Newcode As String)
    '        Dim ck As String = ""
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        Dim Status As String = ""
    '        Dim ck_fda_xml As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB   'เช็คในตารางพี่บิ๊กว่ามีมั้ย แต่ DRUG ใช้ตารางทราย
    '        ck_fda_xml.GetDataby_Newcode(Newcode)
    '        Try
    '            Dim dao_log As New DAO_XML_DRUG_SEUB.TB_tb_log_temp

    '            If dao_fda_cpn.fields.IDA = 0 Then   'ไม่มี xml ใน ตาราง

    '                '----------------------log_xml

    '                dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
    '                dao_log.fields.log_date = Date.Now
    '                dao_log.fields.log_des = "check Newcod TB XML_CPN_KEEP_DRUG"
    '                dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
    '                dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
    '                dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
    '                dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
    '                dao_log.insert()
    '                '----------------------log_xml

    '                If ck_fda_xml.fields.IDA <> 0 Then   'เช็คแล้วว่ามี xml ในตารางXML_FOOD
    '                    'สร้าง xml  แล้ว insert  สถานะ เป็น S 
    '                    BUILD_XML_DRUG_ESUB_BC(Newcode)
    '                    insert_xml_drug_esub_bc(Newcode, ck_fda_xml.fields.GROUPNAME)   '
    '                End If
    '                '.Replace("", "d")
    '                '----------------------log_xml
    '                dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
    '                dao_log.fields.log_date = Date.Now
    '                dao_log.fields.log_des = "check Newcod TB XML_CPN_KEEP_DRUG success"
    '                dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
    '                dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
    '                dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
    '                dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
    '                dao_log.insert()
    '                '----------------------log_xml
    '            Else
    '                '----------------------log_xml
    '                dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
    '                dao_log.fields.log_date = Date.Now
    '                dao_log.fields.log_des = "check status  W or S TB XML_CPN_KEEP_DRUG"
    '                dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
    '                dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
    '                dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
    '                dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
    '                dao_log.insert()
    '                '----------------------log_xml

    '                'เช็คสถานะ ว่าเป็น W หรือ S 
    '                Status = dao_fda_cpn.fields.Status
    '                If Status = "W" Then
    '                    'สร้าง xml  แล้วอัพเดทสถานะเป็น S แล้วก็วันที่ 

    '                    BUILD_XML_DRUG_ESUB_BC(Newcode)
    '                    'update_status(Newcode)
    '                ElseIf Status = "S" Then
    '                    'ไม่ต้องทำอะไร
    '                    BUILD_XML_DRUG_ESUB_BC(Newcode)
    '                    'update_status(Newcode)
    '                End If


    '            End If

    '            dao_log = New DAO_XML_DRUG_SEUB.TB_tb_log_temp
    '            dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
    '            dao_log.fields.log_date = Date.Now
    '            dao_log.fields.log_des = "create xml success"
    '            dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
    '            dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
    '            dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
    '            dao_log.fields.groupname = ck_fda_xml.fields.GROUPNAME
    '            dao_log.insert()
    '        Catch ex As Exception
    '            Dim dao_log As New DAO_XML_DRUG_SEUB.TB_tb_log_temp
    '            dao_log.fields.drgtpcd = ck_fda_xml.fields.drgtpcd
    '            dao_log.fields.log_date = Date.Now
    '            dao_log.fields.log_des = "insert " & ex.Message
    '            dao_log.fields.pvncd = ck_fda_xml.fields.pvncd
    '            dao_log.fields.rgtno = ck_fda_xml.fields.rgtno
    '            dao_log.fields.rgttpcd = ck_fda_xml.fields.rgttpcd
    '            dao_log.fields.groupname = "DR"
    '            dao_log.insert()
    '        End Try

    '        Return ck
    '    End Function   'function ไว้เช็ค Newcode ว่ามีใน table หรือยัง
    '    Private Function BUILD_XML_DRUG_ESUB_BC(ByVal Newcode As String)   ' สร้าง xml 
    '        'Dim paths As String = "E:\XML\FDA_LICENSE\DRUG"
    '        'Dim paths As String = "C:\path\XMLALL\XML\" & "XML_DRUG_FORMULA"
    '        Dim dt As New DataTable
    '        Dim groupname As String

    '        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
    '        'Dim paths_dr As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DR"
    '        'Dim paths_dr As String = "E:\xml\FDA_LICENSE\DR"
    '        'Dim paths_dh As String = "C:\XML\FDA_LICENSE_XML\DRUG\" & "DH"
    '        'Dim paths_dh As String = "E:\xml\FDA_LICENSE\DH\"

    '        'ส่ง NEwcodeมาไปwhere หา groupname 
    '        'แยก groupname ไปทำ xml

    '        Dim clsds As New ClassDataset
    '        Dim conn As String = db.Connection.ConnectionString
    '        Dim cut As String = Newcode.Substring(2, 2)
    '        Dim dao As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '        'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '        dao.GetDataby_GROUPNAME_TYPE(cut, "1")

    '        Dim STO_NAME As String = dao.fields.XML_SQL
    '        Dim bao_food_fg As New BAO_DRUG.BAO_DRUG
    '        STO_NAME &= " @Newcode = '" & Newcode & "'"
    '        dt = clsds.dsQueryselect(STO_NAME, conn).Tables(0) 'เอา Newcode มา where ตรงนี้

    '        rows = dt.Rows.Count()

    '        'dt = bao_show.SP_XML_SPECIFIC_DRUG(Newcode)
    '        Dim Path_XML As String
    '        For Each dr2 As DataRow In dt.Rows
    '            groupname = dr2("groupname")
    '            'Path_XML = paths & "\" & dr2("Newcode") & ".xml" 'สร้างชื่อ XML

    '            If groupname = "DR" Then

    '                Dim dao_dr As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                dao_dr.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                Dim paths_dr As String = dao_dr.fields.XML_PATH
    '                Path_XML = Replace(paths_dr, vbCrLf, "") & dr2("Newcode") & ".xml" 'สร้างชื่อ XML 'จากเดิมเป็น Newcode_R
    '                CREATE_XML_DRUG_ESUB(Path_XML, dr2("Newcode"), groupname) 'ทำการสร้าง XML
    '                update_status_drug_esub_bc(Newcode)
    '            ElseIf groupname = "DH" Then

    '                Dim dao_dh As New DAO_XML_CPN.TB_XML_CPN_KEEP_PATH
    '                'Dim dao_insert As New DAO_CONFIG.TB_XML_CONFIG
    '                dao_dh.GetDataby_GROUPNAME_TYPE(groupname, "1")
    '                Dim paths_dh As String = dao_dh.fields.XML_PATH
    '                Path_XML = paths_dh & dr2("Newcode") & ".xml" 'สร้างชื่อ XML
    '                CREATE_XML_DRUG_ESUB(Path_XML, dr2("Newcode"), groupname) 'ทำการสร้าง XML
    '                update_status_drug_esub_bc(Newcode)

    '                'ElseIf groupname = "DI" Then
    '                '    BUILD_XML_DI(dr2("Newcode"))
    '                '    update_status(Newcode)

    '                'ElseIf groupname = "DP" Then
    '                '    BUILD_XML_DP(dr2("Newcode"))
    '                '    update_status(Newcode)

    '                'ElseIf groupname = "DS" Then
    '                '    BUILD_XML_DS(dr2("Newcode"))
    '                '    update_status(Newcode)
    '                Return "success"
    '            Else
    '                Return "False"
    '            End If
    '        Next
    '    End Function
    '    Private Sub CREATE_XML_DRUG_ESUB_BC(ByVal PATH_XML As String, ByVal DownID As String, ByVal groupname As String)
    '        'Dim cls_xml_DH As New LGT_DRUG_DH15
    '        Dim cls_xml_DR As New LGT_IOW_E
    '        Dim cls_xml_DH As New LGT_DRUG_DH15
    '        Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '        If groupname = "DH" Then
    '            cls_xml_DH = Cls_NCT_LCT.gen_xml_XML_DRUG_DH15(DownID)
    '            Dim objStreamWriter As New StreamWriter(PATH_XML)
    '            Dim x As New XmlSerializer(cls_xml_DH.GetType)
    '            x.Serialize(objStreamWriter, cls_xml_DH)
    '            objStreamWriter.Close()

    '        ElseIf groupname = "DR" Then
    '            cls_xml_DR = Cls_NCT_LCT.gen_xml_XML_DR_FORMULA_E_SUB_TXT(DownID)
    '            Dim objStreamWriter As New StreamWriter(PATH_XML)
    '            Dim x As New XmlSerializer(cls_xml_DR.GetType)
    '            x.Serialize(objStreamWriter, cls_xml_DR)
    '            objStreamWriter.Close()

    '        End If
    '    End Sub
    '    '''' <summary>
    '    '''' สร้าง ไฟล์ XML
    '    '''' </summary>
    '    '''' <param name="PATH_XML"></param>
    '    '''' <remarks></remarks>
    '    'Private Sub CREATE_XML_DRUG(ByVal PATH_XML As String, ByVal Newcode As String)
    '    '    'Dim LCNSID As String = _CLS.LCNSID_CUSTOMER
    '    '    'Dim CITIZEN_ID_AUTHORIZE As String = _CLS.CITIZEN_ID_AUTHORIZE
    '    '    Dim cls_xml As New LGT_IOW_E
    '    '    Dim Cls_NCT_LCT As New Gen_XML.CENTER.GEN_XML_XML_DRUG_PRO
    '    '    cls_xml = Cls_NCT_LCT.gen_xml_XML_DR_FORMULA(Newcode)


    '    '    Dim objStreamWriter As New StreamWriter(PATH_XML)
    '    '    Dim x As New XmlSerializer(cls_xml.GetType)
    '    '    x.Serialize(objStreamWriter, cls_xml)
    '    '    objStreamWriter.Close()
    '    'End Sub
    '    Private Sub insert_xml_drug_esub_bc(ByVal Newcode As String, ByVal groupname As String)
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
    '        dao_fda_cpn.fields.Newcode = Newcode
    '        dao_fda_cpn.fields.groupname = groupname
    '        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
    '        dao_fda_cpn.fields.Status = "S"
    '        dao_fda_cpn.fields.CREATE_DATE_INSERT_XML = DateTime.Now
    '        dao_fda_cpn.insert()
    '    End Sub
    '    Private Sub update_status_drug_esub_bc(ByVal Newcode As String)
    '        Dim dao_fda_cpn As New DAO_XML_CPN.TB_XML_CPN_KEEP_DRUG
    '        dao_fda_cpn.GetDataby_Newcode(Newcode)
    '        dao_fda_cpn.fields.Status = "S"
    '        dao_fda_cpn.fields.CREATE_DATE = DateTime.Now
    '        dao_fda_cpn.update()
    '    End Sub      'function update Status 
    '#End Region
End Class
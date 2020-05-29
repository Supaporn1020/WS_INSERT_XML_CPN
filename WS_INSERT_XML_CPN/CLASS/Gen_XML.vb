
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Text
Imports System.Globalization
Imports System.IO

Namespace Gen_XML
    Public MustInherit Class CENTER
        Protected Friend Function AddValue(ByVal ob As Object) As Object
            Dim props As System.Reflection.PropertyInfo
            For Each props In ob.GetType.GetProperties()

                '     MsgBox(prop.Name & " " & prop.PropertyType.ToString())
                Dim p_type As String = props.PropertyType.ToString()
                If props.CanWrite = True Then
                    If p_type.ToUpper = "System.String".ToUpper Then
                        props.SetValue(ob, " ", Nothing)
                    ElseIf p_type.ToUpper = "System.Int32".ToUpper Then

                        props.SetValue(ob, 0, Nothing)
                    ElseIf p_type.ToUpper = "System.DateTime".ToUpper Then
                        props.SetValue(ob, Date.Now, Nothing)
                    Else
                        Try
                            props.SetValue(ob, 0, Nothing)
                        Catch ex As Exception
                            props.SetValue(ob, Nothing, Nothing)
                        End Try


                    End If
                End If

                'prop.SetValue(cls1, "")
                'Xml = Xml.Replace("_" & prop.Name, prop.GetValue(ecms, Nothing))
            Next props

            Return ob
        End Function
        Public Class GEN_XML_XML_DRUG_PRO
            Inherits CENTER


            Private _XML_DRUG_IOW_TO1 As New XML_DRUG_IOW_TO
            Public Property XML_DRUG_IOW_TO1() As XML_DRUG_IOW_TO
                Get
                    Return _XML_DRUG_IOW_TO1
                End Get
                Set(ByVal value As XML_DRUG_IOW_TO)
                    _XML_DRUG_IOW_TO1 = value
                End Set
            End Property

            Private _XML_DRUG_IOW_TYPE1 As New XML_DRUG_IOW_TYPE
            Public Property XML_DRUG_IOW_TYPE1() As XML_DRUG_IOW_TYPE
                Get
                    Return _XML_DRUG_IOW_TYPE1
                End Get
                Set(ByVal value As XML_DRUG_IOW_TYPE)
                    _XML_DRUG_IOW_TYPE1 = value
                End Set
            End Property
#Region "DRUG"

            'Public Function gen_xml_XML_DR(ByVal Newcode As String) As LGT_IOW_E   ' ใบอนุญาต ยา XML_DRUG_LICENSE (BAO)

            '    Dim class_xml As New LGT_IOW_E
            '    Dim bao_show As New BAO_DRUG.BAO_DRUG

            '    'Dim Newcode As String = fields.Newcode

            '    Dim dt As New DataTable
            '    dt = bao_show.SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP(Newcode)
            '    For Each dr As DataRow In dt.Rows
            '        class_xml.XML_SEARCH_DRUG_DR.IDA = dr("IDA")


            '        'class_xml.XML_SEARCH_DRUG_DR.lcnsid = dr("lcnsid")
            '        'class_xml.XML_SEARCH_DRUG_DR.lcnno = dr("lcnno")
            '        'class_xml.XML_SEARCH_DRUG_DR.drgtpcd = dr("drgtpcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.rgttpcd = dr("rgttpcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.thargttpnm = dr("thargttpnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = dr("engrgttpnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = dr("GROUPNAME")
            '        'class_xml.XML_SEARCH_DRUG_DR.phm15dgt = dr("phm15dgt")
            '        'class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = dr("CITIZEN_AUTHORIZE")
            '        'class_xml.XML_SEARCH_DRUG_DR.Identify = dr("Identify")
            '        'class_xml.XML_SEARCH_DRUG_DR.rgtno = dr("rgtno")
            '        'class_xml.XML_SEARCH_DRUG_DR.lcntpcd = dr("lcntpcd")
            '        If dr("pvncd") IsNot Nothing Then
            '            class_xml.XML_SEARCH_DRUG_DR.pvncd = dr("pvncd").ToString
            '        End If
            '        If dr("rcvno") IsNot Nothing Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvno = dr("rcvno").ToString
            '        End If

            '        If String.IsNullOrEmpty(dr("rcvno").ToString) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvno = dr("rcvno").ToString
            '        End If

            '        If dr("cnccd") IsNot Nothing Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnccd = dr("cnccd").ToString
            '        End If

            '        class_xml.XML_SEARCH_DRUG_DR.register = dr("register")


            '        If IsNothing(dr("register_rcvno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register_rcvno = dr("register_rcvno").ToString
            '        End If





            '        'class_xml.XML_SEARCH_DRUG_DR.lcnno_no = dr("lcnno_no")
            '        'class_xml.XML_SEARCH_DRUG_DR.thadrgnm = dr("thadrgnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.engdrgnm = dr("engdrgnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.drgperunit = dr("drgperunit")
            '        'class_xml.XML_SEARCH_DRUG_DR.thaclassnm = dr("thaclassnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.thakindnm = dr("thakindnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.licen_loca = dr("licen_loca")
            '        'class_xml.XML_SEARCH_DRUG_DR.fulladdr = dr("fulladdr")
            '        'class_xml.XML_SEARCH_DRUG_DR.cntcd = dr("cntcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.thadsgnm = dr("thadsgnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.ctgthanm = dr("ctgthanm")
            '        'class_xml.XML_SEARCH_DRUG_DR.dsgcd = dr("dsgcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.ctgcd = dr("ctgcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion")
            '        'class_xml.XML_SEARCH_DRUG_DR.agent = dr("agent")
            '        'class_xml.XML_SEARCH_DRUG_DR.cncnm = dr("cncnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.cnccsnm = dr("cnccsnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.rcvdate = dr("rcvdate")
            '        'class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = dr("rcvdate_T")
            '        'class_xml.XML_SEARCH_DRUG_DR.appdate_T = dr("appdate_T")
            '        'class_xml.XML_SEARCH_DRUG_DR.story_edit = dr("story_edit")
            '        'class_xml.XML_SEARCH_DRUG_DR.appdate = dr("appdate")

            '        If dr("cncdate") IsNot Nothing Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdate = dr("cncdate").ToString
            '        End If



            '        'class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th")
            '        'class_xml.XML_SEARCH_DRUG_DR.cncdate_th = dr("cncdate_th")
            '        'class_xml.XML_SEARCH_DRUG_DR.thanm = dr("thanm")
            '        'class_xml.XML_SEARCH_DRUG_DR.cnsdnm = dr("cnsdnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.rid = dr("rid")
            '        'class_xml.XML_SEARCH_DRUG_DR.cncdcd = dr("cncdcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.frn_no = dr("frn_no")
            '        'class_xml.XML_SEARCH_DRUG_DR.itemno = dr("itemno")
            '        'class_xml.XML_SEARCH_DRUG_DR.Ranking = dr("Ranking")
            '        'class_xml.XML_SEARCH_DRUG_DR.typerqt = dr("typerqt")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode = dr("Newcode")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode_U = dr("Newcode_U")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode_R = dr("Newcode_R")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode_not = dr("Newcode_not")
            '        'class_xml.XML_SEARCH_DRUG_DR.register_search = dr("register_search")


            '        If IsNothing(dr("pvncd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.pvncd = dr("pvncd").ToString
            '        End If


            '        If IsNothing(dr("lcnsid")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnsid = dr("lcnsid").ToString
            '        End If


            '        If IsNothing(dr("lcnno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnno = dr("lcnno").ToString
            '        End If


            '        If IsNothing(dr("drgtpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.drgtpcd = dr("drgtpcd").ToString
            '        End If


            '        If IsNothing(dr("rgttpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rgttpcd = dr("rgttpcd").ToString
            '        End If


            '        If IsNothing(dr("thargttpnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thargttpnm = dr("thargttpnm").ToString
            '        End If


            '        If IsNothing(dr("engrgttpnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = dr("engrgttpnm").ToString
            '        End If


            '        If IsNothing(dr("GROUPNAME")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = dr("GROUPNAME").ToString
            '        End If


            '        If IsNothing(dr("phm15dgt")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.phm15dgt = dr("phm15dgt").ToString
            '        End If


            '        If IsNothing(dr("CITIZEN_AUTHORIZE")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = dr("CITIZEN_AUTHORIZE").ToString
            '        End If


            '        If IsNothing(dr("Identify")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Identify = dr("Identify").ToString
            '        End If


            '        If IsNothing(dr("rgtno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rgtno = dr("rgtno").ToString
            '        End If


            '        If IsNothing(dr("lcntpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcntpcd = dr("lcntpcd").ToString
            '        End If




            '        If IsNothing(dr("rcvno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvno = dr("rcvno").ToString
            '        End If

            '        If IsNothing(dr("cnccd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnccd = dr("cnccd").ToString
            '        End If



            '        If IsNothing(dr("register")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register = dr("register").ToString
            '        End If


            '        If IsNothing(dr("register_rcvno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register_rcvno = dr("register_rcvno").ToString
            '        End If


            '        If IsNothing(dr("lcnno_no")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnno_no = dr("lcnno_no").ToString
            '        End If


            '        If IsNothing(dr("thadrgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thadrgnm = dr("thadrgnm").ToString
            '        End If


            '        If IsNothing(dr("engdrgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engdrgnm = dr("engdrgnm").ToString
            '        End If


            '        If IsNothing(dr("drgperunit")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.drgperunit = dr("drgperunit").ToString
            '        End If


            '        If IsNothing(dr("thaclassnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thaclassnm = dr("thaclassnm").ToString
            '        End If


            '        If IsNothing(dr("thakindnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thakindnm = dr("thakindnm").ToString
            '        End If


            '        If IsNothing(dr("licen_loca")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.licen_loca = dr("licen_loca").ToString
            '        End If


            '        If IsNothing(dr("fulladdr")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.fulladdr = dr("fulladdr").ToString
            '        End If


            '        If IsNothing(dr("cntcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cntcd = dr("cntcd").ToString
            '        End If


            '        If IsNothing(dr("thadsgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thadsgnm = dr("thadsgnm").ToString
            '        End If

            '        If IsNothing(dr("ctgthanm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.ctgthanm = dr("ctgthanm").ToString
            '        End If


            '        If IsNothing(dr("dsgcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.dsgcd = dr("dsgcd").ToString
            '        End If


            '        If IsNothing(dr("ctgcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.ctgcd = dr("ctgcd").ToString
            '        End If


            '        If IsNothing(dr("thanm_locaion")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion").ToString
            '        End If
            '        class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion")



            '        If IsNothing(dr("cncnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncnm = dr("cncnm").ToString
            '        End If


            '        If IsNothing(dr("cnccsnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnccsnm = dr("cnccsnm").ToString
            '        End If


            '        If IsNothing(dr("rcvdate")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvdate = dr("rcvdate").ToString
            '        End If

            '        If IsNothing(dr("rcvdate_T")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = dr("rcvdate_T").ToString
            '        End If


            '        If IsNothing(dr("appdate_T")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate_T = dr("appdate_T").ToString
            '        End If


            '        If IsNothing(dr("story_edit")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.story_edit = dr("story_edit").ToString
            '        End If


            '        If IsNothing(dr("appdate")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate = dr("appdate").ToString
            '        End If


            '        If dr("cncdate") IsNot Nothing Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdate = dr("cncdate").ToString
            '        End If

            '        If IsNothing(dr("appdate_th")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th").ToString
            '        End If
            '        class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th")

            '        If IsNothing(dr("cncdate_th")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdate_th = dr("cncdate_th").ToString
            '        End If


            '        If IsNothing(dr("thanm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thanm = dr("thanm").ToString
            '        End If


            '        If IsNothing(dr("cnsdnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnsdnm = dr("cnsdnm").ToString
            '        End If


            '        If IsNothing(dr("engfrgnnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engfrgnnm = dr("engfrgnnm").ToString
            '        End If
            '        If IsNothing(dr("engfrgnnm_addr")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engfrgnnm_addr = dr("engfrgnnm_addr").ToString
            '        End If

            '        If IsNothing(dr("rid")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rid = dr("rid").ToString
            '        End If



            '        If IsNothing(dr("cncdcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdcd = dr("cncdcd").ToString
            '        End If



            '        If IsNothing(dr("frn_no")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.frn_no = dr("frn_no").ToString
            '        End If


            '        If IsNothing(dr("itemno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.itemno = dr("itemno").ToString
            '        End If


            '        If IsNothing(dr("Ranking")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Ranking = dr("Ranking").ToString
            '        End If


            '        If IsNothing(dr("typerqt")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.typerqt = dr("typerqt").ToString
            '        End If


            '        If IsNothing(dr("Newcode")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode = dr("Newcode").ToString
            '        End If

            '        If IsNothing(dr("Newcode_U")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_U = dr("Newcode_U").ToString
            '        End If


            '        If IsNothing(dr("Newcode_R")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_R = dr("Newcode_R").ToString
            '        End If


            '        If IsNothing(dr("Newcode_not")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_not = dr("Newcode_not").ToString
            '        End If


            '        If IsNothing(dr("register_search")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register_search = dr("register_search").ToString
            '        End If


            '        Dim Newcode_st As String
            '        Dim dt2 As New DataTable
            '        Newcode_st = dr("Newcode")
            '        dt2 = bao_show.SP_GENXML_DRUG_STOWAGR_TO(Newcode_st)

            '        For Each dr2 As DataRow In dt2.Rows
            '            Dim lgt_cmt As New LGT_XML_STOWAGR_TO
            '            lgt_cmt.XML_STOWAGR.IDA = dr2("IDA")



            '            If IsNothing(dr2("keepdesc")) = False Then
            '                lgt_cmt.XML_STOWAGR.keepdesc = dr2("keepdesc").ToString
            '            End If
            '            If IsNothing(dr2("drgchrtha")) = False Then
            '                lgt_cmt.XML_STOWAGR.drgchrtha = dr2("drgchrtha").ToString
            '            End If

            '            If IsNothing(dr2("useage")) = False Then
            '                lgt_cmt.XML_STOWAGR.useage = dr2("useage").ToString
            '            End If
            '            If IsNothing(dr2("tplow")) = False Then
            '                lgt_cmt.XML_STOWAGR.tplow = dr2("tplow").ToString
            '            End If
            '            If IsNothing(dr2("tphigh")) = False Then
            '                lgt_cmt.XML_STOWAGR.tphigh = dr2("tphigh").ToString
            '            End If
            '            If IsNothing(dr2("Newcode")) = False Then
            '                lgt_cmt.XML_STOWAGR.Newcode = dr2("Newcode").ToString
            '            End If

            '            'lgt_cmt.XML_STOWAGR.keepdesc = dr2("keepdesc")
            '            'lgt_cmt.XML_STOWAGR.drgchrtha = dr2("drgchrtha")
            '            'lgt_cmt.XML_STOWAGR.useage = dr2("useage")
            '            'lgt_cmt.XML_STOWAGR.tplow = dr2("tplow")
            '            'lgt_cmt.XML_STOWAGR.tphigh = dr2("tphigh")
            '            'lgt_cmt.XML_STOWAGR.Newcode = dr2("Newcode")

            '            class_xml.LGT_XML_STOWAGR_TO.Add(lgt_cmt)
            '        Next


            '        Dim Newcode_reci As String
            '        Dim dt_reci As New DataTable
            '        Newcode_reci = dr("Newcode")
            '        dt_reci = bao_show.SP_GENXML_DRUG_RECIPE_GROUPT_TO(Newcode_reci)

            '        For Each dr2 As DataRow In dt_reci.Rows
            '            Dim lgt_cmt As New LGT_RECIPE_GROUP_TO
            '            lgt_cmt.XML_RECIPE_GROUPT.IDA = dr2("IDA")


            '            Try
            '                lgt_cmt.XML_RECIPE_GROUPT.atccd = dr2("atccd").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_RECIPE_GROUPT.atcnm = dr2("atcnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_RECIPE_GROUPT.Newcode = dr2("Newcode").ToString
            '            Catch ex As Exception

            '            End Try

            '            'lgt_cmt.XML_RECIPE_GROUPT.atccd = dr2("atccd")
            '            'lgt_cmt.XML_RECIPE_GROUPT.atcnm = dr2("atcnm")
            '            'lgt_cmt.XML_RECIPE_GROUPT.Newcode = dr2("Newcode")
            '            class_xml.LGT_RECIPE_GROUP_TO.Add(lgt_cmt)
            '        Next





            '        Dim Newcode_animal As String
            '        Dim dt_animal As New DataTable
            '        Newcode_animal = dr("Newcode")
            '        dt_animal = bao_show.SP_GENXML_DRUG_ANIMAL_DRUGS_TO(Newcode_animal)

            '        For Each dr_animal As DataRow In dt_animal.Rows
            '            Dim lgt_cmt As New LGT_ANIMAL_DRUGS_TO
            '            lgt_cmt.XML_ANIMAL_DRUG.IDA = dr_animal("IDA")


            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.pvncd = dr_animal("pvncd").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.lcnno = dr_animal("lcnno").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.lcnsid = dr_animal("lcnsid").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.rgtno = dr_animal("rgtno").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.thadrgnm = dr_animal("thadrgnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.engdrgnm = dr_animal("engdrgnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.ampartnm = dr_animal("ampartnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.amlsubnm = dr_animal("amlsubnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.amltpnm = dr_animal("amltpnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.usetpnm = dr_animal("usetpnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.Newcode = dr_animal("Newcode").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.stpdrg = dr_animal("stpdrg").ToString
            '            Catch ex As Exception

            '            End Try


            '            'lgt_cmt.XML_ANIMAL_DRUG.pvncd = dr_animal("pvncd")
            '            'lgt_cmt.XML_ANIMAL_DRUG.lcnno = dr_animal("lcnno")
            '            'lgt_cmt.XML_ANIMAL_DRUG.lcnsid = dr_animal("lcnsid")
            '            'lgt_cmt.XML_ANIMAL_DRUG.rgtno = dr_animal("rgtno")

            '            'lgt_cmt.XML_ANIMAL_DRUG.thadrgnm = dr_animal("thadrgnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.engdrgnm = dr_animal("engdrgnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.ampartnm = dr_animal("ampartnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.amlsubnm = dr_animal("amlsubnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.amltpnm = dr_animal("amltpnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.usetpnm = dr_animal("usetpnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.Newcode = dr_animal("Newcode")
            '            'lgt_cmt.XML_ANIMAL_DRUG.stpdrg = dr_animal("stpdrg")
            '            class_xml.LGT_ANIMAL_DRUGS_TO.Add(lgt_cmt)
            '        Next

            '        Dim Newcode_iow As String
            '        Dim dt_iow As New DataTable
            '        Newcode_iow = dr("Newcode")
            '        dt_iow = bao_show.SP_GENXML_DRUG_FORMULA_TO(Newcode_iow)

            '        For Each dr_iow As DataRow In dt_iow.Rows
            '            Dim lgt_cmt As New LGT_IOW_EQ
            '            lgt_cmt.XML_IOW_TO.IDA = dr_iow("IDA")

            '            Try
            '                lgt_cmt.XML_IOW_TO.rgttpcd = dr_iow("rgttpcd").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_IOW_TO.qtytxt_all = dr_iow("qtytxt_all").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_IOW_TO.aori = dr_iow("aori").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_IOW_TO.rid = dr_iow("rid").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.iowacd = dr_iow("iowacd").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.iowanm = dr_iow("iowanm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.aori_description = dr_iow("aori_description").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.Newcode_rid = dr_iow("Newcode_rid").ToString
            '            Catch ex As Exception

            '            End Try

            '            '    'lgt_cmt.XML_IOW_TO.rgttpcd = dr_iow("rgttpcd")
            '            '    'lgt_cmt.XML_IOW_TO.qtytxt_all = dr_iow("qtytxt_all")
            '            '    'lgt_cmt.XML_IOW_TO.aori = dr_iow("aori")
            '            '    'lgt_cmt.XML_IOW_TO.rid = dr_iow("rid")
            '            '    'lgt_cmt.XML_IOW_TO.iowacd = dr_iow("iowacd")
            '            '    'lgt_cmt.XML_IOW_TO.iowanm = dr_iow("iowanm")
            '            '    'lgt_cmt.XML_IOW_TO.aori_description = dr_iow("aori_description")
            '            '    'lgt_cmt.XML_IOW_TO.Newcode_rid = dr_iow("Newcode_rid")
            '            class_xml.LGT_IOW_EQ.Add(lgt_cmt)
            '        Next


            '        Dim Newcode_frgn As String
            '        Dim dt_frgn As New DataTable
            '        Newcode_frgn = dr("Newcode")
            '        dt_frgn = bao_show.SP_GENXML_DRUG_FRGN_TO(Newcode_frgn)

            '        For Each dr_frgn As DataRow In dt_frgn.Rows
            '            Dim lgt_cmt As New LGT_XML_FRGN_ALL_TO
            '            lgt_cmt.XML_FRGN.IDA = dr_frgn("IDA")

            '            Try
            '                lgt_cmt.XML_FRGN.pvncd = dr_frgn("pvncd").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.lcnno = dr_frgn("lcnno").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.lcnsid = dr_frgn("lcnsid").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.CITIZEN_AUTHORIZE = dr_frgn("CITIZEN_AUTHORIZE").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_FRGN.drgtpcd = dr_frgn("drgtpcd").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.rgttpcd = dr_frgn("rgttpcd").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.engcntnm = dr_frgn("engcntnm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.rgtno = dr_frgn("rgtno").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.thadrgnm = dr_frgn("thadrgnm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.engdrgnm = dr_frgn("engdrgnm").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_FRGN.thanm = dr_frgn("thanm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.funcnm = dr_frgn("funcnm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.funccd = dr_frgn("funccd").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_FRGN.fulladdr = dr_frgn("fulladdr")
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.engfrgnnm = dr_frgn("engfrgnnm")
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_FRGN.engfrgnnm_all = dr_frgn("engfrgnnm_all")
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.offengnm = dr_frgn("offengnm")
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.Newcode = dr_frgn("Newcode")
            '            Catch ex As Exception

            '            End Try


            '            '    End Try
            '            '    'lgt_cmt.XML_FRGN_TO.pvncd = dr_frgn("pvncd")
            '            '    'lgt_cmt.XML_FRGN_TO.lcnno = dr_frgn("lcnno")
            '            '    'lgt_cmt.XML_FRGN_TO.lcnsid = dr_frgn("lcnsid")
            '            '    'lgt_cmt.XML_FRGN_TO.CITIZEN_AUTHORIZE = dr_frgn("CITIZEN_AUTHORIZE")

            '            '    'lgt_cmt.XML_FRGN_TO.drgtpcd = dr_frgn("drgtpcd")
            '            '    'lgt_cmt.XML_FRGN_TO.rgttpcd = dr_frgn("rgttpcd")
            '            '    'lgt_cmt.XML_FRGN_TO.engcntnm = dr_frgn("engcntnm")
            '            '    'lgt_cmt.XML_FRGN_TO.rgtno = dr_frgn("rgtno")
            '            '    'lgt_cmt.XML_FRGN_TO.engcntnm = dr_frgn("engcntnm")

            '            '    'lgt_cmt.XML_FRGN_TO.thadrgnm = dr_frgn("thadrgnm")
            '            '    'lgt_cmt.XML_FRGN_TO.engdrgnm = dr_frgn("engdrgnm")
            '            '    'lgt_cmt.XML_FRGN_TO.thanm = dr_frgn("thanm")
            '            '    'lgt_cmt.XML_FRGN_TO.funcnm = dr_frgn("funcnm")
            '            '    'lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd")



            '            '    'If IsNothing(dr_frgn("funccd")) = False Then
            '            '    '    lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd").ToString
            '            '    'End If
            '            '    'If dr_frgn("funccd") IsNot Nothing Then
            '            '    '    lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd").ToString
            '            '    'End If
            '            '    'lgt_cmt.XML_FRGN_TO.fulladdr = dr_frgn("fulladdr")
            '            '    'lgt_cmt.XML_FRGN_TO.engfrgnnm = dr_frgn("engfrgnnm")
            '            '    'lgt_cmt.XML_FRGN_TO.engfrgnnm_all = dr_frgn("engfrgnnm_all")
            '            '    'lgt_cmt.XML_FRGN_TO.offengnm = dr_frgn("offengnm")
            '            '    'lgt_cmt.XML_FRGN_TO.Newcode = dr_frgn("Newcode")

            '            class_xml.LGT_XML_FRGN_ALL_TO.Add(lgt_cmt)
            '        Next

            '    Next
            '    Return class_xml
            'End Function   'ทะเบียนยา (U)
            Public Function gen_xml_LGT_XML_DRUG_LCN(ByVal Newcode_not As String) As LGT_XML_DRUG_LCN_CENTER   ' ใบอนุญาต ยา XML_DRUG_LICENSE (BAO)


                Dim class_xml As New LGT_XML_DRUG_LCN_CENTER                   'เปลี่ยนเป็นคลาสโครงxmlตัวที่จะใช้
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_SEARCH_DRUG_LCN(Newcode_not)
                class_xml.LGT_XML_DRUG_LCN_CENTER_TO.DT1 = dt

                Dim Newcode As String
                For Each dr As DataRow In dt.Rows
                    Newcode = dr("Newcode_not")
                    class_xml.LGT_XML_DRUG_LCN_CENTER_TO.DT2 = bao_show.SP_GENXML_DRUG_PHARMACY_TO(Newcode_not)
                Next

                Dim Newcode_licen As String
                For Each dr As DataRow In dt.Rows
                    Newcode_licen = dr("Newcode_not")
                    class_xml.LGT_XML_DRUG_LCN_CENTER_TO.DT3 = bao_show.SP_GENXML_DRUG_LCN_LICEN(Newcode_not)
                Next

                Return class_xml
            End Function
            'Public Function gen_xml_XML_DR_FORMULA(ByVal Newcode As String) As LGT_IOW_E    'ตัว test ตอนลอง gen DR_สาร  R1 

            '    Dim class_xml As New LGT_IOW_E
            '    Dim bao_show As New BAO_DRUG.BAO_DRUG

            '    Dim dt As New DataTable
            '    dt = bao_show.SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP(Newcode)

            '    For Each dr As DataRow In dt.Rows
            '        class_xml.XML_SEARCH_DRUG_DR.IDA = dr("IDA")


            '        If IsNothing(dr("pvncd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.pvncd = dr("pvncd").ToString
            '        End If


            '        If IsNothing(dr("lcnsid")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnsid = dr("lcnsid").ToString
            '        End If


            '        If IsNothing(dr("lcnno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnno = dr("lcnno").ToString
            '        End If


            '        If IsNothing(dr("drgtpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.drgtpcd = dr("drgtpcd").ToString
            '        End If


            '        If IsNothing(dr("rgttpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rgttpcd = dr("rgttpcd").ToString
            '        End If


            '        If IsNothing(dr("thargttpnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thargttpnm = dr("thargttpnm").ToString
            '        End If


            '        If IsNothing(dr("engrgttpnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = dr("engrgttpnm").ToString
            '        End If


            '        If IsNothing(dr("GROUPNAME")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = dr("GROUPNAME").ToString
            '        End If


            '        If IsNothing(dr("phm15dgt")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.phm15dgt = dr("phm15dgt").ToString
            '        End If


            '        If IsNothing(dr("CITIZEN_AUTHORIZE")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = dr("CITIZEN_AUTHORIZE").ToString
            '        End If


            '        If IsNothing(dr("Identify")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Identify = dr("Identify").ToString
            '        End If


            '        If IsNothing(dr("rgtno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rgtno = dr("rgtno").ToString
            '        End If


            '        If IsNothing(dr("lcntpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcntpcd = dr("lcntpcd").ToString
            '        End If




            '        If IsNothing(dr("rcvno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvno = dr("rcvno").ToString
            '        End If

            '        If IsNothing(dr("cnccd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnccd = dr("cnccd").ToString
            '        End If



            '        If IsNothing(dr("register")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register = dr("register").ToString
            '        End If


            '        If IsNothing(dr("register_rcvno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register_rcvno = dr("register_rcvno").ToString
            '        End If


            '        If IsNothing(dr("lcnno_no")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnno_no = dr("lcnno_no").ToString
            '        End If


            '        If IsNothing(dr("thadrgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thadrgnm = dr("thadrgnm").ToString
            '        End If


            '        If IsNothing(dr("engdrgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engdrgnm = dr("engdrgnm").ToString
            '        End If


            '        If IsNothing(dr("drgperunit")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.drgperunit = dr("drgperunit").ToString
            '        End If


            '        If IsNothing(dr("thaclassnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thaclassnm = dr("thaclassnm").ToString
            '        End If


            '        If IsNothing(dr("thakindnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thakindnm = dr("thakindnm").ToString
            '        End If


            '        If IsNothing(dr("licen_loca")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.licen_loca = dr("licen_loca").ToString
            '        End If


            '        If IsNothing(dr("fulladdr")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.fulladdr = dr("fulladdr").ToString
            '        End If


            '        If IsNothing(dr("cntcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cntcd = dr("cntcd").ToString
            '        End If


            '        If IsNothing(dr("thadsgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thadsgnm = dr("thadsgnm").ToString
            '        End If

            '        If IsNothing(dr("ctgthanm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.ctgthanm = dr("ctgthanm").ToString
            '        End If


            '        If IsNothing(dr("dsgcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.dsgcd = dr("dsgcd").ToString
            '        End If


            '        If IsNothing(dr("ctgcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.ctgcd = dr("ctgcd").ToString
            '        End If


            '        If IsNothing(dr("thanm_locaion")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion").ToString
            '        End If
            '        class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion")



            '        If IsNothing(dr("cncnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncnm = dr("cncnm").ToString
            '        End If


            '        If IsNothing(dr("cnccsnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnccsnm = dr("cnccsnm").ToString
            '        End If


            '        If IsNothing(dr("rcvdate")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvdate = dr("rcvdate").ToString
            '        End If

            '        If IsNothing(dr("rcvdate_T")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = dr("rcvdate_T").ToString
            '        End If


            '        If IsNothing(dr("appdate_T")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate_T = dr("appdate_T").ToString
            '        End If


            '        If IsNothing(dr("story_edit")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.story_edit = dr("story_edit").ToString
            '        End If


            '        If IsNothing(dr("appdate")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate = dr("appdate").ToString
            '        End If


            '        If dr("cncdate") IsNot Nothing Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdate = dr("cncdate").ToString
            '        End If

            '        If IsNothing(dr("appdate_th")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th").ToString
            '        End If
            '        'class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th")

            '        If IsNothing(dr("cncdate_th")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdate_th = dr("cncdate_th").ToString
            '        End If


            '        If IsNothing(dr("thanm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thanm = dr("thanm").ToString
            '        End If


            '        If IsNothing(dr("cnsdnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnsdnm = dr("cnsdnm").ToString
            '        End If


            '        If IsNothing(dr("engfrgnnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engfrgnnm = dr("engfrgnnm").ToString
            '        End If
            '        If IsNothing(dr("engfrgnnm_addr")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engfrgnnm_addr = dr("engfrgnnm_addr").ToString
            '        End If


            '        If IsNothing(dr("rid")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rid = dr("rid").ToString
            '        End If



            '        If IsNothing(dr("cncdcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdcd = dr("cncdcd").ToString
            '        End If



            '        If IsNothing(dr("frn_no")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.frn_no = dr("frn_no").ToString
            '        End If


            '        If IsNothing(dr("itemno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.itemno = dr("itemno").ToString
            '        End If


            '        If IsNothing(dr("Ranking")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Ranking = dr("Ranking").ToString
            '        End If


            '        If IsNothing(dr("typerqt")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.typerqt = dr("typerqt").ToString
            '        End If


            '        If IsNothing(dr("Newcode")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode = dr("Newcode").ToString
            '        End If

            '        If IsNothing(dr("Newcode_U")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_U = dr("Newcode_U").ToString
            '        End If


            '        If IsNothing(dr("Newcode_R")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_R = dr("Newcode_R").ToString
            '        End If


            '        If IsNothing(dr("Newcode_not")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_not = dr("Newcode_not").ToString
            '        End If


            '        If IsNothing(dr("register_search")) = False Then

            '            class_xml.XML_SEARCH_DRUG_DR.register_search = dr("register_search").ToString
            '        End If

            '        If IsNothing(dr("register_search2")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register_search2 = dr("register_search2").ToString
            '        End If


            '        If IsNothing(dr("funcnm")) = False Then

            '            class_xml.XML_SEARCH_DRUG_DR.funcnm = dr("funcnm").ToString
            '        End If



            '        Dim Newcode_U As String
            '        Dim dao As New DAO_XML_DRUG.TB_XML_SEARCH_PRODUCT_GROUP
            '        Dim Newcode_st As String
            '        Dim dt2 As New DataTable
            '        Newcode_st = dr("Newcode")

            '        dao.GetDataby_Newcode(Newcode_st)
            '        Newcode_U = dao.fields.Newcode_U
            '        dt2 = bao_show.SP_GENXML_DRUG_STOWAGR_TO(Newcode_U)

            '        For Each dr2 As DataRow In dt2.Rows
            '            Dim lgt_cmt As New LGT_XML_STOWAGR_TO
            '            lgt_cmt.XML_STOWAGR.IDA = dr2("IDA")


            '            'Try
            '            '    lgt_cmt.XML_STOWAGR.keepdesc = dt2("keepdesc").ToString
            '            'Catch ex As Exception

            '            'End Try

            '            'Try
            '            '    lgt_cmt.XML_STOWAGR.drgchrtha = dt2("drgchrtha").ToString
            '            'Catch ex As Exception

            '            'End Try


            '            'Try
            '            '    lgt_cmt.XML_STOWAGR.useage = dt2("useage").ToString
            '            'Catch ex As Exception

            '            'End Try

            '            'Try
            '            '    lgt_cmt.XML_STOWAGR.tplow = dt2("tplow").ToString
            '            'Catch ex As Exception

            '            'End Try
            '            'Try
            '            '    lgt_cmt.XML_STOWAGR.tphigh = dt2("tphigh").ToString
            '            'Catch ex As Exception

            '            'End Try

            '            'Try
            '            '    lgt_cmt.XML_STOWAGR.Newcode = dt2("Newcode").ToString
            '            'Catch ex As Exception

            '            'End Try


            '            If IsNothing(dr2("keepdesc")) = False Then
            '                lgt_cmt.XML_STOWAGR.keepdesc = dr2("keepdesc").ToString
            '            End If
            '            If IsNothing(dr2("drgchrtha")) = False Then
            '                lgt_cmt.XML_STOWAGR.drgchrtha = dr2("drgchrtha").ToString
            '            End If

            '            If IsNothing(dr2("useage")) = False Then
            '                lgt_cmt.XML_STOWAGR.useage = dr2("useage").ToString
            '            End If
            '            If IsNothing(dr2("tplow")) = False Then
            '                lgt_cmt.XML_STOWAGR.tplow = dr2("tplow").ToString
            '            End If
            '            If IsNothing(dr2("tphigh")) = False Then
            '                lgt_cmt.XML_STOWAGR.tphigh = dr2("tphigh").ToString
            '            End If
            '            If IsNothing(dr2("Newcode")) = False Then
            '                lgt_cmt.XML_STOWAGR.Newcode = dr2("Newcode").ToString
            '            End If
            '            'lgt_cmt.XML_STOWAGR.keepdesc = dr2("keepdesc")
            '            'lgt_cmt.XML_STOWAGR.drgchrtha = dr2("drgchrtha")
            '            'lgt_cmt.XML_STOWAGR.useage = dr2("useage")
            '            'lgt_cmt.XML_STOWAGR.tplow = dr2("tplow")
            '            'lgt_cmt.XML_STOWAGR.tphigh = dr2("tphigh")
            '            'lgt_cmt.XML_STOWAGR.Newcode = dr2("Newcode")

            '            class_xml.LGT_XML_STOWAGR_TO.Add(lgt_cmt)
            '        Next


            '        Dim Newcode_reci As String
            '        Dim dt_reci As New DataTable
            '        Newcode_reci = dr("Newcode")

            '        dt_reci = bao_show.SP_GENXML_DRUG_RECIPE_GROUPT_TO(Newcode_U)

            '        For Each dr2 As DataRow In dt_reci.Rows
            '            Dim lgt_cmt As New LGT_RECIPE_GROUP_TO
            '            lgt_cmt.XML_RECIPE_GROUPT.IDA = dr2("IDA")


            '            If IsNothing(dr2("atccd")) = False Then
            '                lgt_cmt.XML_RECIPE_GROUPT.atccd = dr2("atccd").ToString
            '            End If

            '            If IsNothing(dr2("atcnm")) = False Then
            '                lgt_cmt.XML_RECIPE_GROUPT.atcnm = dr2("atcnm").ToString
            '            End If
            '            If IsNothing(dr2("Newcode")) = False Then
            '                lgt_cmt.XML_RECIPE_GROUPT.Newcode = dr2("Newcode").ToString
            '            End If

            '            'lgt_cmt.XML_RECIPE_GROUPT.atccd = dr2("atccd")
            '            'lgt_cmt.XML_RECIPE_GROUPT.atcnm = dr2("atcnm")
            '            'lgt_cmt.XML_RECIPE_GROUPT.Newcode = dr2("Newcode")
            '            class_xml.LGT_RECIPE_GROUP_TO.Add(lgt_cmt)
            '        Next





            '        Dim Newcode_animal As String
            '        Dim dt_animal As New DataTable
            '        Newcode_animal = dr("Newcode")


            '        dt_animal = bao_show.SP_GENXML_DRUG_ANIMAL_DRUGS_TO(Newcode_U)
            '        For Each dr_animal As DataRow In dt_animal.Rows
            '            Dim lgt_cmt As New LGT_ANIMAL_DRUGS_TO
            '            lgt_cmt.XML_ANIMAL_DRUG.IDA = dr_animal("IDA")

            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.pvncd = dr_animal("pvncd").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.lcnno = dr_animal("lcnno").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.lcnsid = dr_animal("lcnsid").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.rgttpcd = dr_animal("rgttpcd").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.rgtno = dr_animal("rgtno").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.thadrgnm = dr_animal("thadrgnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.engdrgnm = dr_animal("engdrgnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.ampartnm = dr_animal("ampartnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.amlsubnm = dr_animal("amlsubnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.amltpnm = dr_animal("amltpnm").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.usetpnm = dr_animal("usetpnm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.stpdrg = dr_animal("stpdrg").ToString
            '            Catch ex As Exception

            '            End Try



            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.Newcode = dr_animal("Newcode").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_ANIMAL_DRUG.stpdrg = dr_animal("stpdrg").ToString
            '            Catch ex As Exception

            '            End Try


            '            'lgt_cmt.XML_ANIMAL_DRUG.pvncd = dr_animal("pvncd")
            '            'lgt_cmt.XML_ANIMAL_DRUG.lcnno = dr_animal("lcnno")
            '            'lgt_cmt.XML_ANIMAL_DRUG.lcnsid = dr_animal("lcnsid")
            '            'lgt_cmt.XML_ANIMAL_DRUG.rgtno = dr_animal("rgtno")

            '            'lgt_cmt.XML_ANIMAL_DRUG.thadrgnm = dr_animal("thadrgnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.engdrgnm = dr_animal("engdrgnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.ampartnm = dr_animal("ampartnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.amlsubnm = dr_animal("amlsubnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.amltpnm = dr_animal("amltpnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.usetpnm = dr_animal("usetpnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.Newcode = dr_animal("Newcode")
            '            'lgt_cmt.XML_ANIMAL_DRUG.stpdrg = dr_animal("stpdrg")




            '            Dim animal_amlsubnm As String
            '            Dim animal_amltpnm As String
            '            Dim animal_usetpnm As String
            '            Dim Newcode_animal_consume As String


            '            Dim dt_animal_consume As New DataTable
            '            animal_amlsubnm = dr_animal("amlsubnm")
            '            animal_amltpnm = dr_animal("amltpnm")
            '            animal_usetpnm = dr_animal("usetpnm")
            '            Newcode_animal_consume = Newcode_U




            '            dt_animal_consume = bao_show.SP_GENXML_DRUG_ANIMAL_CONSUME_DRUGS_TO(animal_amlsubnm, animal_amltpnm, animal_usetpnm, Newcode_animal_consume)

            '            For Each dr_animal_consume As DataRow In dt_animal_consume.Rows

            '                Dim lgt_animal_consume As New LGT_ANIMAL_CONSUME_DRUGS_TO

            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.pvncd = dr_animal_consume("pvncd").ToString
            '                Catch ex As Exception

            '                End Try

            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.lcnno = dr_animal_consume("lcnno").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.lcnsid = dr_animal_consume("lcnsid").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.rgttpcd = dr_animal_consume("rgttpcd").ToString
            '                Catch ex As Exception

            '                End Try


            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.rgtno = dr_animal_consume("rgtno").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.thadrgnm = dr_animal_consume("thadrgnm").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.engdrgnm = dr_animal_consume("engdrgnm").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.ampartnm = dr_animal_consume("ampartnm").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.amlsubnm = dr_animal_consume("amlsubnm").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.amltpnm = dr_animal_consume("amltpnm").ToString
            '                Catch ex As Exception

            '                End Try
            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.usetpnm = dr_animal_consume("usetpnm").ToString
            '                Catch ex As Exception

            '                End Try

            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.stpdrg = dr_animal_consume("stpdrg").ToString
            '                Catch ex As Exception

            '                End Try


            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.rid = dr_animal_consume("rid").ToString
            '                Catch ex As Exception

            '                End Try


            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.Newcode = dr_animal_consume("Newcode").ToString
            '                Catch ex As Exception

            '                End Try

            '                Try
            '                    lgt_animal_consume.XML_ANIMAL_CONSUME_DRUGS_TO.stpdrg = dr_animal_consume("stpdrg").ToString
            '                Catch ex As Exception

            '                End Try
            '                lgt_cmt.LGT_ANIMAL_CONSUME_DRUGS_TO.Add(lgt_animal_consume)
            '            Next
            '            class_xml.LGT_ANIMAL_DRUGS_TO.Add(lgt_cmt)
            '        Next


            '        Dim Newcode_iow As String
            '        Dim dt_iow As New DataTable
            '        Newcode_iow = dr("Newcode")
            '        dt_iow = bao_show.SP_GENXML_DRUG_FORMULA(Newcode_U)

            '        For Each dr_iow As DataRow In dt_iow.Rows
            '            Dim lgt_cmt As New LGT_IOW_EQ
            '            lgt_cmt.XML_IOW_TO.IDA = dr_iow("IDA")

            '            Try
            '                lgt_cmt.XML_IOW_TO.rgttpcd = dr_iow("rgttpcd").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_IOW_TO.qtytxt_all = dr_iow("qtytxt_all").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_IOW_TO.aori = dr_iow("aori").ToString
            '            Catch ex As Exception

            '            End Try


            '            Try
            '                lgt_cmt.XML_IOW_TO.rid = dr_iow("rid").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.iowacd = dr_iow("iowacd").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.iowanm = dr_iow("iowanm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.aori_description = dr_iow("aori_description").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_IOW_TO.Newcode_R = dr_iow("Newcode_R").ToString
            '            Catch ex As Exception

            '            End Try


            '            Dim Newcode_rid As String
            '            Dim dt_eq As New DataTable
            '            Newcode_rid = dr_iow("Newcode_rid")
            '            dt_eq = bao_show.SP_GENXML_DRUG_FORMULA_EQ_TO(Newcode_rid)

            '            For Each dr_eq As DataRow In dt_eq.Rows
            '                Dim lgt_eq As New LGT_IOW_EQ_TO


            '                lgt_eq.XML_IOW_EQ_TO.IDA = dr_eq("IDA").ToString


            '                If IsNothing(dr_eq("rid")) = False Then
            '                    lgt_eq.XML_IOW_EQ_TO.rid = dr_eq("rid").ToString
            '                End If
            '                If IsNothing(dr_eq("iowanm")) = False Then
            '                    lgt_eq.XML_IOW_EQ_TO.iowanm = dr_eq("iowanm").ToString
            '                End If
            '                If IsNothing(dr_eq("qty")) = False Then
            '                    lgt_eq.XML_IOW_EQ_TO.qty = dr_eq("qty").ToString
            '                End If
            '                If IsNothing(dr_eq("Newcode_rid")) = False Then
            '                    lgt_eq.XML_IOW_EQ_TO.Newcode_rid = dr_eq("Newcode_rid").ToString
            '                End If
            '                'lgt_type2.XML_IOW_EQ_TO.iowanm = dao_XML_CMT_X_TYPE2.fields.iowanm
            '                'lgt_type2.XML_IOW_EQ_TO.qty = dao_XML_CMT_X_TYPE2.fields.qty
            '                'lgt_type2.XML_IOW_EQ_TO.rid = dao_XML_CMT_X_TYPE2.fields.rid
            '                'lgt_type2.XML_IOW_EQ_TO.Newcode_rid = dao_XML_CMT_X_TYPE2.fields.Newcode_rid

            '                lgt_cmt.LGT_IOW_EQ_TO.Add(lgt_eq)
            '            Next
            '            class_xml.LGT_IOW_EQ.Add(lgt_cmt)
            '        Next


            '        Dim Newcode_frgn As String
            '        Dim dt_frgn As New DataTable
            '        Newcode_frgn = dr("Newcode")
            '        dt_frgn = bao_show.SP_GENXML_DRUG_FRGN_TO(Newcode_U)

            '        For Each dr_frgn As DataRow In dt_frgn.Rows
            '            Dim lgt_cmt As New LGT_XML_FRGN_ALL_TO
            '            lgt_cmt.XML_FRGN.IDA = dr_frgn("IDA")



            '            If IsNothing(dr_frgn("pvncd")) = False Then
            '                lgt_cmt.XML_FRGN.pvncd = dr_frgn("pvncd").ToString
            '            End If
            '            If IsNothing(dr_frgn("lcnno")) = False Then
            '                lgt_cmt.XML_FRGN.lcnno = dr_frgn("lcnno").ToString
            '            End If
            '            If IsNothing(dr_frgn("lcnsid")) = False Then
            '                lgt_cmt.XML_FRGN.lcnsid = dr_frgn("lcnsid").ToString
            '            End If

            '            If IsNothing(dr_frgn("CITIZEN_AUTHORIZE")) = False Then
            '                lgt_cmt.XML_FRGN.CITIZEN_AUTHORIZE = dr_frgn("CITIZEN_AUTHORIZE").ToString
            '            End If

            '            If IsNothing(dr_frgn("drgtpcd")) = False Then
            '                lgt_cmt.XML_FRGN.drgtpcd = dr_frgn("drgtpcd").ToString
            '            End If

            '            If IsNothing(dr_frgn("rgttpcd")) = False Then
            '                lgt_cmt.XML_FRGN.rgttpcd = dr_frgn("rgttpcd").ToString
            '            End If

            '            If IsNothing(dr_frgn("engcntnm")) = False Then
            '                lgt_cmt.XML_FRGN.engcntnm = dr_frgn("engcntnm").ToString
            '            End If

            '            If IsNothing(dr_frgn("rgtno")) = False Then
            '                lgt_cmt.XML_FRGN.rgtno = dr_frgn("rgtno").ToString
            '            End If


            '            If IsNothing(dr_frgn("thadrgnm")) = False Then
            '                lgt_cmt.XML_FRGN.thadrgnm = dr_frgn("thadrgnm").ToString
            '            End If

            '            If IsNothing(dr_frgn("engdrgnm")) = False Then
            '                lgt_cmt.XML_FRGN.engdrgnm = dr_frgn("engdrgnm").ToString
            '            End If

            '            If IsNothing(dr_frgn("thanm")) = False Then
            '                lgt_cmt.XML_FRGN.thanm = dr_frgn("thanm").ToString
            '            End If



            '            Try
            '                lgt_cmt.XML_FRGN.funcnm = dr_frgn("funcnm").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.funccd = dr_frgn("funccd").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_FRGN.fulladdr = dr_frgn("fulladdr")
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.engfrgnnm = dr_frgn("engfrgnnm")
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_FRGN.engfrgnnm_all = dr_frgn("engfrgnnm_all")
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                lgt_cmt.XML_FRGN.offengnm = dr_frgn("offengnm")
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                lgt_cmt.XML_FRGN.Newcode = dr_frgn("Newcode")
            '            Catch ex As Exception

            '            End Try
            '            'lgt_cmt.XML_FRGN_TO.pvncd = dr_frgn("pvncd")
            '            'lgt_cmt.XML_FRGN_TO.lcnno = dr_frgn("lcnno")
            '            'lgt_cmt.XML_FRGN_TO.lcnsid = dr_frgn("lcnsid")
            '            'lgt_cmt.XML_FRGN_TO.CITIZEN_AUTHORIZE = dr_frgn("CITIZEN_AUTHORIZE")

            '            'lgt_cmt.XML_FRGN_TO.drgtpcd = dr_frgn("drgtpcd")
            '            'lgt_cmt.XML_FRGN_TO.rgttpcd = dr_frgn("rgttpcd")
            '            'lgt_cmt.XML_FRGN_TO.engcntnm = dr_frgn("engcntnm")
            '            'lgt_cmt.XML_FRGN_TO.rgtno = dr_frgn("rgtno")
            '            'lgt_cmt.XML_FRGN_TO.engcntnm = dr_frgn("engcntnm")

            '            'lgt_cmt.XML_FRGN_TO.thadrgnm = dr_frgn("thadrgnm")
            '            'lgt_cmt.XML_FRGN_TO.engdrgnm = dr_frgn("engdrgnm")
            '            'lgt_cmt.XML_FRGN_TO.thanm = dr_frgn("thanm")
            '            'lgt_cmt.XML_FRGN_TO.funcnm = dr_frgn("funcnm")
            '            'lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd")



            '            'If IsNothing(dr_frgn("funccd")) = False Then
            '            '    lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd").ToString
            '            'End If
            '            'If dr_frgn("funccd") IsNot Nothing Then
            '            '    lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd").ToString
            '            'End If
            '            'lgt_cmt.XML_FRGN_TO.fulladdr = dr_frgn("fulladdr")
            '            'lgt_cmt.XML_FRGN_TO.engfrgnnm = dr_frgn("engfrgnnm")
            '            'lgt_cmt.XML_FRGN_TO.engfrgnnm_all = dr_frgn("engfrgnnm_all")
            '            'lgt_cmt.XML_FRGN_TO.offengnm = dr_frgn("offengnm")
            '            'lgt_cmt.XML_FRGN_TO.Newcode = dr_frgn("Newcode")

            '            class_xml.LGT_XML_FRGN_ALL_TO.Add(lgt_cmt)
            '        Next
            '    Next
            '    Return class_xml
            'End Function
            'Public Function gen_xml_XML_DR(ByVal Newcode As String) As LGT_IOW_E   ' ใบอนุญาต ยา XML_DRUG_LICENSE (BAO)

            '    Dim class_xml As New LGT_IOW_E
            '    Dim bao_show As New BAO_DRUG.BAO_DRUG

            '    'Dim Newcode As String = fields.Newcode

            '    Dim dt As New DataTable
            '    dt = bao_show.SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP(Newcode)
            '    For Each dr As DataRow In dt.Rows
            '        class_xml.XML_SEARCH_DRUG_DR.IDA = dr("IDA")

            '        'If dr("pvncd") IsNot Nothing Then
            '        '    class_xml.XML_SEARCH_DRUG_DR.pvncd = dr("pvncd").ToString
            '        'End If
            '        'class_xml.XML_SEARCH_DRUG_DR.lcnsid = dr("lcnsid")
            '        'class_xml.XML_SEARCH_DRUG_DR.lcnno = dr("lcnno")
            '        'class_xml.XML_SEARCH_DRUG_DR.drgtpcd = dr("drgtpcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.rgttpcd = dr("rgttpcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.thargttpnm = dr("thargttpnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = dr("engrgttpnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = dr("GROUPNAME")
            '        'class_xml.XML_SEARCH_DRUG_DR.phm15dgt = dr("phm15dgt")
            '        'class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = dr("CITIZEN_AUTHORIZE")
            '        'class_xml.XML_SEARCH_DRUG_DR.Identify = dr("Identify")
            '        'class_xml.XML_SEARCH_DRUG_DR.rgtno = dr("rgtno")
            '        'class_xml.XML_SEARCH_DRUG_DR.lcntpcd = dr("lcntpcd")

            '        ''If dr("rcvno") IsNot Nothing Then
            '        ''    class_xml.XML_SEARCH_DRUG_DR.rcvno = dr("rcvno").ToString
            '        ''End If

            '        'If String.IsNullOrEmpty(dr("rcvno").ToString) = False Then
            '        '    class_xml.XML_SEARCH_DRUG_DR.rcvno = dr("rcvno").ToString
            '        'End If

            '        'If dr("cnccd") IsNot Nothing Then
            '        '    class_xml.XML_SEARCH_DRUG_DR.cnccd = dr("cnccd").ToString
            '        'End If

            '        'class_xml.XML_SEARCH_DRUG_DR.register = dr("register")


            '        'If IsNothing(dr("register_rcvno")) = False Then
            '        '    class_xml.XML_SEARCH_DRUG_DR.register_rcvno = dr("register_rcvno").ToString
            '        'End If





            '        'class_xml.XML_SEARCH_DRUG_DR.lcnno_no = dr("lcnno_no")
            '        'class_xml.XML_SEARCH_DRUG_DR.thadrgnm = dr("thadrgnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.engdrgnm = dr("engdrgnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.drgperunit = dr("drgperunit")
            '        'class_xml.XML_SEARCH_DRUG_DR.thaclassnm = dr("thaclassnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.thakindnm = dr("thakindnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.licen_loca = dr("licen_loca")
            '        'class_xml.XML_SEARCH_DRUG_DR.fulladdr = dr("fulladdr")
            '        'class_xml.XML_SEARCH_DRUG_DR.cntcd = dr("cntcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.thadsgnm = dr("thadsgnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.ctgthanm = dr("ctgthanm")
            '        'class_xml.XML_SEARCH_DRUG_DR.dsgcd = dr("dsgcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.ctgcd = dr("ctgcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion")
            '        'class_xml.XML_SEARCH_DRUG_DR.agent = dr("agent")
            '        'class_xml.XML_SEARCH_DRUG_DR.cncnm = dr("cncnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.cnccsnm = dr("cnccsnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.rcvdate = dr("rcvdate")
            '        'class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = dr("rcvdate_T")
            '        'class_xml.XML_SEARCH_DRUG_DR.appdate_T = dr("appdate_T")
            '        'class_xml.XML_SEARCH_DRUG_DR.story_edit = dr("story_edit")
            '        'class_xml.XML_SEARCH_DRUG_DR.appdate = dr("appdate")

            '        'If dr("cncdate") IsNot Nothing Then
            '        '    class_xml.XML_SEARCH_DRUG_DR.cncdate = dr("cncdate").ToString
            '        'End If



            '        'class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th")
            '        'class_xml.XML_SEARCH_DRUG_DR.cncdate_th = dr("cncdate_th")
            '        'class_xml.XML_SEARCH_DRUG_DR.thanm = dr("thanm")
            '        'class_xml.XML_SEARCH_DRUG_DR.cnsdnm = dr("cnsdnm")
            '        'class_xml.XML_SEARCH_DRUG_DR.rid = dr("rid")
            '        'class_xml.XML_SEARCH_DRUG_DR.cncdcd = dr("cncdcd")
            '        'class_xml.XML_SEARCH_DRUG_DR.frn_no = dr("frn_no")
            '        'class_xml.XML_SEARCH_DRUG_DR.itemno = dr("itemno")
            '        'class_xml.XML_SEARCH_DRUG_DR.Ranking = dr("Ranking")
            '        'class_xml.XML_SEARCH_DRUG_DR.typerqt = dr("typerqt")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode = dr("Newcode")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode_U = dr("Newcode_U")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode_R = dr("Newcode_R")
            '        'class_xml.XML_SEARCH_DRUG_DR.Newcode_not = dr("Newcode_not")
            '        'class_xml.XML_SEARCH_DRUG_DR.register_search = dr("register_search")


            '        If IsNothing(dr("pvncd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.pvncd = dr("pvncd").ToString
            '        End If


            '        If IsNothing(dr("lcnsid")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnsid = dr("lcnsid").ToString
            '        End If


            '        If IsNothing(dr("lcnno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnno = dr("lcnno").ToString
            '        End If


            '        If IsNothing(dr("drgtpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.drgtpcd = dr("drgtpcd").ToString
            '        End If


            '        If IsNothing(dr("rgttpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rgttpcd = dr("rgttpcd").ToString
            '        End If


            '        If IsNothing(dr("thargttpnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thargttpnm = dr("thargttpnm").ToString
            '        End If


            '        If IsNothing(dr("engrgttpnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = dr("engrgttpnm").ToString
            '        End If


            '        If IsNothing(dr("GROUPNAME")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = dr("GROUPNAME").ToString
            '        End If


            '        If IsNothing(dr("phm15dgt")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.phm15dgt = dr("phm15dgt").ToString
            '        End If


            '        If IsNothing(dr("CITIZEN_AUTHORIZE")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = dr("CITIZEN_AUTHORIZE").ToString
            '        End If


            '        If IsNothing(dr("Identify")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Identify = dr("Identify").ToString
            '        End If


            '        If IsNothing(dr("rgtno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rgtno = dr("rgtno").ToString
            '        End If


            '        If IsNothing(dr("lcntpcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcntpcd = dr("lcntpcd").ToString
            '        End If




            '        If IsNothing(dr("rcvno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvno = dr("rcvno").ToString
            '        End If

            '        If IsNothing(dr("cnccd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnccd = dr("cnccd").ToString
            '        End If



            '        If IsNothing(dr("register")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register = dr("register").ToString
            '        End If


            '        If IsNothing(dr("register_rcvno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.register_rcvno = dr("register_rcvno").ToString
            '        End If


            '        If IsNothing(dr("lcnno_no")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.lcnno_no = dr("lcnno_no").ToString
            '        End If


            '        If IsNothing(dr("thadrgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thadrgnm = dr("thadrgnm").ToString
            '        End If


            '        If IsNothing(dr("engdrgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.engdrgnm = dr("engdrgnm").ToString
            '        End If


            '        If IsNothing(dr("drgperunit")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.drgperunit = dr("drgperunit").ToString
            '        End If


            '        If IsNothing(dr("thaclassnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thaclassnm = dr("thaclassnm").ToString
            '        End If


            '        If IsNothing(dr("thakindnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thakindnm = dr("thakindnm").ToString
            '        End If


            '        If IsNothing(dr("licen_loca")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.licen_loca = dr("licen_loca").ToString
            '        End If


            '        If IsNothing(dr("fulladdr")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.fulladdr = dr("fulladdr").ToString
            '        End If


            '        If IsNothing(dr("cntcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cntcd = dr("cntcd").ToString
            '        End If


            '        If IsNothing(dr("thadsgnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thadsgnm = dr("thadsgnm").ToString
            '        End If

            '        If IsNothing(dr("ctgthanm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.ctgthanm = dr("ctgthanm").ToString
            '        End If


            '        If IsNothing(dr("dsgcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.dsgcd = dr("dsgcd").ToString
            '        End If


            '        If IsNothing(dr("ctgcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.ctgcd = dr("ctgcd").ToString
            '        End If


            '        If IsNothing(dr("thanm_locaion")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion").ToString
            '        End If
            '        class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dr("thanm_locaion")

            '        If IsNothing(dr("agent")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.agent = dr("agent").ToString
            '        End If


            '        If IsNothing(dr("cncnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncnm = dr("cncnm").ToString
            '        End If


            '        If IsNothing(dr("cnccsnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnccsnm = dr("cnccsnm").ToString
            '        End If


            '        If IsNothing(dr("rcvdate")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvdate = dr("rcvdate").ToString
            '        End If

            '        If IsNothing(dr("rcvdate_T")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = dr("rcvdate_T").ToString
            '        End If


            '        If IsNothing(dr("appdate_T")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate_T = dr("appdate_T").ToString
            '        End If


            '        If IsNothing(dr("story_edit")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.story_edit = dr("story_edit").ToString
            '        End If


            '        If IsNothing(dr("appdate")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate = dr("appdate").ToString
            '        End If


            '        If dr("cncdate") IsNot Nothing Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdate = dr("cncdate").ToString
            '        End If

            '        If IsNothing(dr("appdate_th")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th").ToString
            '        End If
            '        class_xml.XML_SEARCH_DRUG_DR.appdate_th = dr("appdate_th")

            '        If IsNothing(dr("cncdate_th")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdate_th = dr("cncdate_th").ToString
            '        End If


            '        If IsNothing(dr("thanm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.thanm = dr("thanm").ToString
            '        End If


            '        If IsNothing(dr("cnsdnm")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cnsdnm = dr("cnsdnm").ToString
            '        End If



            '        If IsNothing(dr("rid")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.rid = dr("rid").ToString
            '        End If



            '        If IsNothing(dr("cncdcd")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.cncdcd = dr("cncdcd").ToString
            '        End If



            '        If IsNothing(dr("frn_no")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.frn_no = dr("frn_no").ToString
            '        End If


            '        If IsNothing(dr("itemno")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.itemno = dr("itemno").ToString
            '        End If


            '        If IsNothing(dr("Ranking")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Ranking = dr("Ranking").ToString
            '        End If


            '        If IsNothing(dr("typerqt")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.typerqt = dr("typerqt").ToString
            '        End If


            '        If IsNothing(dr("Newcode")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode = dr("Newcode").ToString
            '        End If

            '        If IsNothing(dr("Newcode_U")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_U = dr("Newcode_U").ToString
            '        End If


            '        If IsNothing(dr("Newcode_R")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_R = dr("Newcode_R").ToString
            '        End If


            '        If IsNothing(dr("Newcode_not")) = False Then
            '            class_xml.XML_SEARCH_DRUG_DR.Newcode_not = dr("Newcode_not").ToString
            '        End If


            '        If IsNothing(dr("register_search")) = False Then

            '            class_xml.XML_SEARCH_DRUG_DR.register_search = dr("register_search").ToString
            '        End If


            '        Dim Newcode_st As String
            '        Dim dt2 As New DataTable
            '        Newcode_st = dr("Newcode")
            '        dt2 = bao_show.SP_GENXML_DRUG_STOWAGR_TO(Newcode_st)

            '        For Each dr2 As DataRow In dt2.Rows
            '            Dim lgt_cmt As New LGT_XML_STOWAGR_TO
            '            lgt_cmt.XML_STOWAGR.IDA = dr2("IDA")


            '            Try
            '                lgt_cmt.XML_STOWAGR.keepdesc = dt2("keepdesc").ToString
            '            Catch ex As Exception

            '            End Try

            '            If IsNothing(dt2("drgchrtha")) = False Then
            '                lgt_cmt.XML_STOWAGR.drgchrtha = dt2("drgchrtha").ToString
            '            End If


            '            If IsNothing(dt2("useage")) = False Then
            '                lgt_cmt.XML_STOWAGR.useage = dt2("useage").ToString
            '            End If
            '            If IsNothing(dt2("tplow")) = False Then
            '                lgt_cmt.XML_STOWAGR.tplow = dt2("tplow").ToString
            '            End If
            '            If IsNothing(dt2("tphigh")) = False Then
            '                lgt_cmt.XML_STOWAGR.tphigh = dt2("tphigh").ToString
            '            End If
            '            If IsNothing(dt2("Newcode")) = False Then
            '                lgt_cmt.XML_STOWAGR.Newcode = dt2("Newcode").ToString
            '            End If





            '            'lgt_cmt.XML_STOWAGR.keepdesc = dr2("keepdesc")
            '            'lgt_cmt.XML_STOWAGR.drgchrtha = dr2("drgchrtha")
            '            'lgt_cmt.XML_STOWAGR.useage = dr2("useage")
            '            'lgt_cmt.XML_STOWAGR.tplow = dr2("tplow")
            '            'lgt_cmt.XML_STOWAGR.tphigh = dr2("tphigh")
            '            'lgt_cmt.XML_STOWAGR.Newcode = dr2("Newcode")

            '            class_xml.LGT_XML_STOWAGR_TO.Add(lgt_cmt)
            '        Next


            '        Dim Newcode_reci As String
            '        Dim dt_reci As New DataTable
            '        Newcode_reci = dr("Newcode")
            '        dt_reci = bao_show.SP_GENXML_DRUG_RECIPE_GROUPT_TO(Newcode_reci)

            '        For Each dr2 As DataRow In dt_reci.Rows
            '            Dim lgt_cmt As New LGT_RECIPE_GROUP_TO
            '            lgt_cmt.XML_RECIPE_GROUPT.IDA = dr2("IDA")

            '            If IsNothing(dr2("atccd")) = False Then
            '                lgt_cmt.XML_RECIPE_GROUPT.atccd = dr2("atccd").ToString
            '            End If
            '            If IsNothing(dr2("atcnm")) = False Then
            '                lgt_cmt.XML_RECIPE_GROUPT.atcnm = dr2("atcnm").ToString
            '            End If
            '            If IsNothing(dr2("Newcode")) = False Then
            '                lgt_cmt.XML_RECIPE_GROUPT.Newcode = dr2("Newcode").ToString
            '            End If


            '            'lgt_cmt.XML_RECIPE_GROUPT.atccd = dr2("atccd")
            '            'lgt_cmt.XML_RECIPE_GROUPT.atcnm = dr2("atcnm")
            '            'lgt_cmt.XML_RECIPE_GROUPT.Newcode = dr2("Newcode")
            '            class_xml.LGT_RECIPE_GROUP_TO.Add(lgt_cmt)
            '        Next



            '        Dim Newcode_frgn As String
            '        Dim dt_frgn As New DataTable
            '        Newcode_frgn = dr("Newcode")
            '        dt_frgn = bao_show.SP_GENXML_DRUG_FRGN_TO(Newcode_frgn)

            '        For Each dr_frgn As DataRow In dt_frgn.Rows
            '            Dim lgt_cmt As New LGT_XML_FRGN_TO
            '            lgt_cmt.XML_FRGN_TO.IDA = dr_frgn("IDA")

            '            If IsNothing(dr_frgn("Newcode")) = False Then
            '                lgt_cmt.XML_FRGN_TO.pvncd = dr_frgn("pvncd").ToString
            '            End If

            '            If IsNothing(dr_frgn("lcnno")) = False Then
            '                lgt_cmt.XML_FRGN_TO.lcnno = dr_frgn("lcnno").ToString
            '            End If


            '            If IsNothing(dr_frgn("lcnsid")) = False Then
            '                lgt_cmt.XML_FRGN_TO.lcnsid = dr_frgn("lcnsid").ToString
            '            End If
            '            If IsNothing(dr_frgn("CITIZEN_AUTHORIZE")) = False Then
            '                lgt_cmt.XML_FRGN_TO.CITIZEN_AUTHORIZE = dr_frgn("CITIZEN_AUTHORIZE").ToString
            '            End If
            '            If IsNothing(dr_frgn("drgtpcd")) = False Then
            '                lgt_cmt.XML_FRGN_TO.drgtpcd = dr_frgn("drgtpcd").ToString
            '            End If
            '            If IsNothing(dr_frgn("rgttpcd")) = False Then
            '                lgt_cmt.XML_FRGN_TO.rgttpcd = dr_frgn("rgttpcd").ToString
            '            End If
            '            If IsNothing(dr_frgn("engcntnm")) = False Then
            '                lgt_cmt.XML_FRGN_TO.engcntnm = dr_frgn("engcntnm").ToString
            '            End If

            '            If IsNothing(dr_frgn("rgtno")) = False Then
            '                lgt_cmt.XML_FRGN_TO.rgtno = dr_frgn("rgtno").ToString
            '            End If

            '            If IsNothing(dr_frgn("thadrgnm")) = False Then
            '                lgt_cmt.XML_FRGN_TO.thadrgnm = dr_frgn("thadrgnm").ToString
            '            End If

            '            If IsNothing(dr_frgn("engdrgnm")) = False Then
            '                lgt_cmt.XML_FRGN_TO.engdrgnm = dr_frgn("engdrgnm").ToString
            '            End If


            '            If IsNothing(dr_frgn("thanm")) = False Then
            '                lgt_cmt.XML_FRGN_TO.thanm = dr_frgn("thanm").ToString
            '            End If

            '            If IsNothing(dr_frgn("funcnm")) = False Then
            '                lgt_cmt.XML_FRGN_TO.funcnm = dr_frgn("funcnm").ToString
            '            End If
            '            'lgt_cmt.XML_FRGN_TO.pvncd = dr_frgn("pvncd")
            '            'lgt_cmt.XML_FRGN_TO.lcnno = dr_frgn("lcnno")
            '            'lgt_cmt.XML_FRGN_TO.lcnsid = dr_frgn("lcnsid")
            '            'lgt_cmt.XML_FRGN_TO.CITIZEN_AUTHORIZE = dr_frgn("CITIZEN_AUTHORIZE")

            '            'lgt_cmt.XML_FRGN_TO.drgtpcd = dr_frgn("drgtpcd")
            '            'lgt_cmt.XML_FRGN_TO.rgttpcd = dr_frgn("rgttpcd")
            '            'lgt_cmt.XML_FRGN_TO.engcntnm = dr_frgn("engcntnm")
            '            'lgt_cmt.XML_FRGN_TO.rgtno = dr_frgn("rgtno")
            '            'lgt_cmt.XML_FRGN_TO.engcntnm = dr_frgn("engcntnm")

            '            'lgt_cmt.XML_FRGN_TO.thadrgnm = dr_frgn("thadrgnm")
            '            'lgt_cmt.XML_FRGN_TO.engdrgnm = dr_frgn("engdrgnm")
            '            'lgt_cmt.XML_FRGN_TO.thanm = dr_frgn("thanm")
            '            'lgt_cmt.XML_FRGN_TO.funcnm = dr_frgn("funcnm")

            '            If IsNothing(dr_frgn("funccd")) = False Then
            '                lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd").ToString
            '            End If
            '            'If dr_frgn("funccd") IsNot Nothing Then
            '            '    lgt_cmt.XML_FRGN_TO.funccd = dr_frgn("funccd").ToString
            '            'End If

            '            If IsNothing(dr_frgn("fulladdr")) = False Then
            '                lgt_cmt.XML_FRGN_TO.fulladdr = dr_frgn("fulladdr").ToString
            '            End If
            '            If IsNothing(dr_frgn("engfrgnnm")) = False Then
            '                lgt_cmt.XML_FRGN_TO.engfrgnnm = dr_frgn("engfrgnnm").ToString
            '            End If
            '            If IsNothing(dr_frgn("engfrgnnm_all")) = False Then
            '                lgt_cmt.XML_FRGN_TO.engfrgnnm_all = dr_frgn("engfrgnnm_all").ToString
            '            End If
            '            If IsNothing(dr_frgn("offengnm")) = False Then
            '                lgt_cmt.XML_FRGN_TO.offengnm = dr_frgn("offengnm").ToString
            '            End If
            '            If IsNothing(dr_frgn("Newcode")) = False Then
            '                lgt_cmt.XML_FRGN_TO.Newcode = dr_frgn("Newcode").ToString
            '            End If


            '            'lgt_cmt.XML_FRGN_TO.fulladdr = dr_frgn("fulladdr")
            '            'lgt_cmt.XML_FRGN_TO.engfrgnnm = dr_frgn("engfrgnnm")
            '            'lgt_cmt.XML_FRGN_TO.engfrgnnm_all = dr_frgn("engfrgnnm_all")
            '            'lgt_cmt.XML_FRGN_TO.offengnm = dr_frgn("offengnm")
            '            'lgt_cmt.XML_FRGN_TO.Newcode = dr_frgn("Newcode")

            '            class_xml.LGT_XML_FRGN_TO.Add(lgt_cmt)
            '        Next



            '        Dim Newcode_animal As String
            '        Dim dt_animal As New DataTable
            '        Newcode_animal = dr("Newcode")
            '        dt_animal = bao_show.SP_GENXML_DRUG_ANIMAL_DRUGS_TO(Newcode_animal)

            '        For Each dr_animal As DataRow In dt_animal.Rows
            '            Dim lgt_cmt As New LGT_ANIMAL_DRUGS_TO
            '            lgt_cmt.XML_ANIMAL_DRUG.IDA = dr_animal("IDA")

            '            If IsNothing(dr_animal("pvncd")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.pvncd = dr_animal("pvncd").ToString
            '            End If
            '            If IsNothing(dr_animal("lcnno")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.lcnno = dr_animal("lcnno").ToString
            '            End If
            '            If IsNothing(dr_animal("lcnsid")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.lcnsid = dr_animal("lcnsid").ToString
            '            End If
            '            If IsNothing(dr_animal("rgtno")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.rgtno = dr_animal("rgtno").ToString
            '            End If

            '            If IsNothing(dr_animal("thadrgnm")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.thadrgnm = dr_animal("thadrgnm").ToString
            '            End If

            '            If IsNothing(dr_animal("engdrgnm")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.engdrgnm = dr_animal("engdrgnm").ToString
            '            End If

            '            If IsNothing(dr_animal("ampartnm")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.ampartnm = dr_animal("ampartnm").ToString
            '            End If
            '            If IsNothing(dr_animal("amlsubnm")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.amlsubnm = dr_animal("amlsubnm").ToString
            '            End If

            '            If IsNothing(dr_animal("amltpnm")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.amltpnm = dr_animal("amltpnm").ToString
            '            End If
            '            If IsNothing(dr_animal("usetpnm")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.usetpnm = dr_animal("usetpnm").ToString
            '            End If

            '            If IsNothing(dr_animal("Newcode")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.Newcode = dr_animal("Newcode").ToString
            '            End If
            '            If IsNothing(dr_animal("stpdrg")) = False Then
            '                lgt_cmt.XML_ANIMAL_DRUG.stpdrg = dr_animal("stpdrg").ToString
            '            End If

            '            'lgt_cmt.XML_ANIMAL_DRUG.pvncd = dr_animal("pvncd")
            '            'lgt_cmt.XML_ANIMAL_DRUG.lcnno = dr_animal("lcnno")
            '            'lgt_cmt.XML_ANIMAL_DRUG.lcnsid = dr_animal("lcnsid")
            '            'lgt_cmt.XML_ANIMAL_DRUG.rgtno = dr_animal("rgtno")

            '            'lgt_cmt.XML_ANIMAL_DRUG.thadrgnm = dr_animal("thadrgnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.engdrgnm = dr_animal("engdrgnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.ampartnm = dr_animal("ampartnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.amlsubnm = dr_animal("amlsubnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.amltpnm = dr_animal("amltpnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.usetpnm = dr_animal("usetpnm")
            '            'lgt_cmt.XML_ANIMAL_DRUG.Newcode = dr_animal("Newcode")
            '            'lgt_cmt.XML_ANIMAL_DRUG.stpdrg = dr_animal("stpdrg")
            '            class_xml.LGT_ANIMAL_DRUGS_TO.Add(lgt_cmt)
            '        Next

            '        Dim Newcode_iow As String
            '        Dim dt_iow As New DataTable
            '        Newcode_iow = dr("Newcode")
            '        dt_iow = bao_show.SP_GENXML_DRUG_FORMULA_TO(Newcode_iow)

            '        For Each dr_iow As DataRow In dt_iow.Rows
            '            Dim lgt_cmt As New LGT_IOW_EQ
            '            lgt_cmt.XML_IOW_TO.IDA = dr_iow("IDA")

            '            If IsNothing(dr_iow("rgttpcd")) = False Then
            '                lgt_cmt.XML_IOW_TO.rgttpcd = dr_iow("rgttpcd").ToString
            '            End If

            '            If IsNothing(dr_iow("qtytxt_all")) = False Then
            '                lgt_cmt.XML_IOW_TO.qtytxt_all = dr_iow("qtytxt_all").ToString
            '            End If


            '            If IsNothing(dr_iow("aori")) = False Then
            '                lgt_cmt.XML_IOW_TO.aori = dr_iow("aori").ToString
            '            End If
            '            If IsNothing(dr_iow("rid")) = False Then
            '                lgt_cmt.XML_IOW_TO.rid = dr_iow("rid").ToString
            '            End If
            '            If IsNothing(dr_iow("iowacd")) = False Then
            '                lgt_cmt.XML_IOW_TO.iowacd = dr_iow("iowacd").ToString
            '            End If
            '            If IsNothing(dr_iow("iowanm")) = False Then
            '                lgt_cmt.XML_IOW_TO.iowanm = dr_iow("iowanm").ToString
            '            End If
            '            If IsNothing(dr_iow("aori_description")) = False Then
            '                lgt_cmt.XML_IOW_TO.aori_description = dr_iow("aori_description").ToString
            '            End If
            '            If IsNothing(dr_iow("Newcode_rid")) = False Then
            '                lgt_cmt.XML_IOW_TO.Newcode_rid = dr_iow("Newcode_rid").ToString
            '            End If



            '            'lgt_cmt.XML_IOW_TO.rgttpcd = dr_iow("rgttpcd")
            '            'lgt_cmt.XML_IOW_TO.qtytxt_all = dr_iow("qtytxt_all")
            '            'lgt_cmt.XML_IOW_TO.aori = dr_iow("aori")
            '            'lgt_cmt.XML_IOW_TO.rid = dr_iow("rid")
            '            'lgt_cmt.XML_IOW_TO.iowacd = dr_iow("iowacd")
            '            'lgt_cmt.XML_IOW_TO.iowanm = dr_iow("iowanm")
            '            'lgt_cmt.XML_IOW_TO.aori_description = dr_iow("aori_description")
            '            'lgt_cmt.XML_IOW_TO.Newcode_rid = dr_iow("Newcode_rid")
            '            class_xml.LGT_IOW_EQ.Add(lgt_cmt)
            '        Next

            '    Next
            '    Return class_xml
            'End Function
            Public Function gen_xml_XML_DRUG_DH15(ByVal Newcode As String) As LGT_DRUG_DH15

                'Dim class_xml As New LGT_DRUG_DH15                   'เปลี่ยนเป็นคลาสโครงxmlตัวที่จะใช้
                'Dim bao_show As New BAO_DRUG.BAO_DRUG
                'Dim dt As New DataTable
                'dt = bao_show.SP_GENXML_SEARCH_DRUG_DH15(Newcode)
                'For Each dr As DataRow In dt.Rows
                '    'class_xml.LGT_SHOW_DATA_DRUG_DH15.DT1 = dt
                '    class_xml.LGT_SHOW_DATA_DRUG_DH15.DT1.pvncd = dr("pvncd")

                'Next

                Dim class_xml As New LGT_DRUG_DH15                   'เปลี่ยนเป็นคลาสโครงxmlตัวที่จะใช้
                Dim bao_show As New BAO_DRUG.BAO_DRUG
                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_SEARCH_DRUG_DH15(Newcode)
                Try
                    class_xml.LGT_SHOW_DATA_DRUG_DH15.DT1 = dt
                Catch ex As Exception

                End Try


                Dim Newcode_dh15 As String
                For Each dr As DataRow In dt.Rows
                    Newcode_dh15 = dr("Newcode")
                    Try
                        class_xml.LGT_SHOW_DATA_DRUG_DH15.DT2 = bao_show.SP_GENXML_DRUG_FORMULA_DH15(Newcode)
                    Catch ex As Exception

                    End Try

                Next
                Return class_xml
            End Function

            Public Function gen_xml_XML_DR_FORMULA_E_SUB_TXT(ByVal Newcode_dr As String) As LGT_IOW_E

                Dim class_xml As New LGT_IOW_E
                'class_xml.XML_SEARCH_DRUG_DR = fields
                Dim dao_dr As New DAO_XML_DRUG_SEUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                dao_dr.GetDataby_Newcode(Newcode_dr)

                Dim Newcode As String = dao_dr.fields.Newcode

#Region "DR_HEAD"
                If IsNothing(dao_dr.fields.IDA) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.IDA = dao_dr.fields.IDA
                Else
                    class_xml.XML_SEARCH_DRUG_DR.IDA = 0
                End If

                If IsNothing(dao_dr.fields.pvncd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.pvncd = dao_dr.fields.pvncd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.pvncd = ""
                End If

                If IsNothing(dao_dr.fields.drgtpcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.drgtpcd = dao_dr.fields.drgtpcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.drgtpcd = ""
                End If

                If IsNothing(dao_dr.fields.rgttpcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rgttpcd = dao_dr.fields.rgttpcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rgttpcd = ""
                End If

                If IsNothing(dao_dr.fields.rgtno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rgtno = dao_dr.fields.rgtno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rgtno = ""
                End If

                If IsNothing(dao_dr.fields.thargttpnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thargttpnm = dao_dr.fields.thargttpnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thargttpnm = ""
                End If

                If IsNothing(dao_dr.fields.engrgttpnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = dao_dr.fields.engrgttpnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engrgttpnm = ""
                End If

                If IsNothing(dao_dr.fields.thaclassnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thaclassnm = dao_dr.fields.thaclassnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thaclassnm = ""
                End If

                If IsNothing(dao_dr.fields.engdrgtpnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engdrgtpnm = dao_dr.fields.engdrgtpnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engdrgtpnm = ""
                End If

                If IsNothing(dao_dr.fields.thakindnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thakindnm = dao_dr.fields.thakindnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thakindnm = ""
                End If

                If IsNothing(dao_dr.fields.register) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register = dao_dr.fields.register
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register = ""
                End If

                If IsNothing(dao_dr.fields.rcvno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rcvno = dao_dr.fields.rcvno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rcvno = ""
                End If

                If IsNothing(dao_dr.fields.register_rcvno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register_rcvno = dao_dr.fields.register_rcvno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register_rcvno = ""
                End If

                If IsNothing(dao_dr.fields.lcnsid) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lcnsid = dao_dr.fields.lcnsid
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lcnsid = ""
                End If

                If IsNothing(dao_dr.fields.pvnabbr) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.pvnabbr = dao_dr.fields.pvnabbr
                Else
                    class_xml.XML_SEARCH_DRUG_DR.pvnabbr = ""
                End If

                If IsNothing(dao_dr.fields.lpvncd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lpvncd = dao_dr.fields.lpvncd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lpvncd = ""
                End If


                If IsNothing(dao_dr.fields.lcntpcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lcntpcd = dao_dr.fields.lcntpcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lcntpcd = ""
                End If

                If IsNothing(dao_dr.fields.lcnno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lcnno = dao_dr.fields.lcnno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lcnno = ""
                End If
                If IsNothing(dao_dr.fields.lcnno_no) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lcnno_no = dao_dr.fields.lcnno_no
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lcnno_no = ""
                End If

                If IsNothing(dao_dr.fields.prefix_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.prefix_thanm = dao_dr.fields.prefix_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.prefix_thanm = ""
                End If
                If IsNothing(dao_dr.fields.prefix_licen) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.prefix_licen = dao_dr.fields.prefix_licen
                Else
                    class_xml.XML_SEARCH_DRUG_DR.prefix_licen = ""
                End If

                If IsNothing(dao_dr.fields.thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thanm = dao_dr.fields.thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thanm = ""
                End If


                If IsNothing(dao_dr.fields.thanm_locaion) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = dao_dr.fields.thanm_locaion
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thanm_locaion = ""
                End If

                If IsNothing(dao_dr.fields.licen_loca) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.licen_loca = dao_dr.fields.licen_loca
                Else
                    class_xml.XML_SEARCH_DRUG_DR.licen_loca = ""
                End If


                If IsNothing(dao_dr.fields.fulladdr) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.fulladdr = dao_dr.fields.fulladdr
                Else
                    class_xml.XML_SEARCH_DRUG_DR.fulladdr = ""
                End If


                If IsNothing(dao_dr.fields.thaaddr_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thaaddr_thanm = dao_dr.fields.thaaddr_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thaaddr_thanm = ""
                End If


                If IsNothing(dao_dr.fields.tharoom_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.tharoom_thanm = dao_dr.fields.tharoom_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.tharoom_thanm = ""
                End If


                If IsNothing(dao_dr.fields.thafloor_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thafloor_thanm = dao_dr.fields.thafloor_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thafloor_thanm = ""
                End If


                If IsNothing(dao_dr.fields.thabuilding_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thabuilding_thanm = dao_dr.fields.thabuilding_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thabuilding_thanm = ""
                End If

                If IsNothing(dao_dr.fields.thasoi_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thasoi_thanm = dao_dr.fields.thasoi_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thasoi_thanm = ""
                End If

                If IsNothing(dao_dr.fields.tharoad_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.tharoad_thanm = dao_dr.fields.tharoad_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.tharoad_thanm = ""
                End If


                If IsNothing(dao_dr.fields.thamu_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thamu_thanm = dao_dr.fields.thamu_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thamu_thanm = ""
                End If

                If IsNothing(dao_dr.fields.thathmblnm_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thathmblnm_thanm = dao_dr.fields.thathmblnm_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thathmblnm_thanm = ""
                End If



                If IsNothing(dao_dr.fields.thaamphrnm_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = dao_dr.fields.thaamphrnm_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thaamphrnm_thanm = ""
                End If

                If IsNothing(dao_dr.fields.thachngwtnm_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thachngwtnm_thanm = dao_dr.fields.thachngwtnm_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thachngwtnm_thanm = ""
                End If

                If IsNothing(dao_dr.fields.zipcode_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.zipcode_thanm = dao_dr.fields.zipcode_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.zipcode_thanm = ""
                End If

                If IsNothing(dao_dr.fields.tel_thanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.tel_thanm = dao_dr.fields.tel_thanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.tel_thanm = ""
                End If


                If IsNothing(dao_dr.fields.thadrgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thadrgnm = dao_dr.fields.thadrgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thadrgnm = ""
                End If


                If IsNothing(dao_dr.fields.engdrgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engdrgnm = dao_dr.fields.engdrgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engdrgnm = ""
                End If


                If IsNothing(dao_dr.fields.GROUPNAME) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = dao_dr.fields.GROUPNAME
                Else
                    class_xml.XML_SEARCH_DRUG_DR.GROUPNAME = ""
                End If


                If IsNothing(dao_dr.fields.phm15dgt) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.phm15dgt = dao_dr.fields.phm15dgt
                Else
                    class_xml.XML_SEARCH_DRUG_DR.phm15dgt = ""
                End If
                If IsNothing(dao_dr.fields.CITIZEN_AUTHORIZE) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = dao_dr.fields.CITIZEN_AUTHORIZE
                Else
                    class_xml.XML_SEARCH_DRUG_DR.CITIZEN_AUTHORIZE = ""
                End If

                If IsNothing(dao_dr.fields.Identify) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Identify = dao_dr.fields.Identify
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Identify = ""
                End If


                If IsNothing(dao_dr.fields.drgperunit) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.drgperunit = dao_dr.fields.drgperunit
                Else
                    class_xml.XML_SEARCH_DRUG_DR.drgperunit = ""
                End If


                If IsNothing(dao_dr.fields.cntcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cntcd = dao_dr.fields.cntcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cntcd = ""
                End If



                If IsNothing(dao_dr.fields.thadsgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.thadsgnm = dao_dr.fields.thadsgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.thadsgnm = ""
                End If



                If IsNothing(dao_dr.fields.engdsgnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engdsgnm = dao_dr.fields.engdsgnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engdsgnm = ""
                End If


                If IsNothing(dao_dr.fields.ctgthanm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.ctgthanm = dao_dr.fields.ctgthanm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.ctgthanm = ""
                End If



                If IsNothing(dao_dr.fields.potency) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.potency = dao_dr.fields.potency
                Else
                    class_xml.XML_SEARCH_DRUG_DR.potency = ""
                End If

                If IsNothing(dao_dr.fields.dsgcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.dsgcd = dao_dr.fields.dsgcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.dsgcd = ""
                End If


                If IsNothing(dao_dr.fields.ctgcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.ctgcd = dao_dr.fields.ctgcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.ctgcd = ""
                End If


                If IsNothing(dao_dr.fields.cnccd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cnccd = dao_dr.fields.cnccd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cnccd = ""
                End If

                If IsNothing(dao_dr.fields.cncnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cncnm = dao_dr.fields.cncnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cncnm = ""
                End If

                If IsNothing(dao_dr.fields.cnccsnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cnccsnm = dao_dr.fields.cnccsnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cnccsnm = ""
                End If
                If IsNothing(dao_dr.fields.appdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.appdate = dao_dr.fields.appdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.appdate = Date.Now
                End If
                If IsNothing(dao_dr.fields.cncdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cncdate = dao_dr.fields.cncdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cncdate = Date.Now
                End If

                If IsNothing(dao_dr.fields.rcvdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rcvdate = dao_dr.fields.rcvdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rcvdate = Date.Now
                End If

                If IsNothing(dao_dr.fields.rcvdate_T) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = dao_dr.fields.rcvdate_T
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rcvdate_T = ""
                End If

                If IsNothing(dao_dr.fields.appdate_T) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.appdate_T = dao_dr.fields.appdate_T
                Else
                    class_xml.XML_SEARCH_DRUG_DR.appdate_T = ""
                End If


                If IsNothing(dao_dr.fields.ExpiryDate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.ExpiryDate = dao_dr.fields.ExpiryDate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.ExpiryDate = Date.Now
                End If



                If IsNothing(dao_dr.fields.ExpiryDate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.ExpiryDate = dao_dr.fields.ExpiryDate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.ExpiryDate = Date.Now
                End If


                If IsNothing(dao_dr.fields.story_edit) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.story_edit = dao_dr.fields.story_edit
                Else
                    class_xml.XML_SEARCH_DRUG_DR.story_edit = ""
                End If


                If IsNothing(dao_dr.fields.appdate_th) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.appdate_th = dao_dr.fields.appdate_th
                Else
                    class_xml.XML_SEARCH_DRUG_DR.appdate_th = ""
                End If

                If IsNothing(dao_dr.fields.cncdate_th) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cncdate_th = dao_dr.fields.cncdate_th
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cncdate_th = ""
                End If

                If IsNothing(dao_dr.fields.cnsdnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cnsdnm = dao_dr.fields.cnsdnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cnsdnm = ""
                End If
                If IsNothing(dao_dr.fields.engfrgnnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engfrgnnm = dao_dr.fields.engfrgnnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engfrgnnm = ""
                End If

                If IsNothing(dao_dr.fields.engfrgnnm_addr) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engfrgnnm_addr = dao_dr.fields.engfrgnnm_addr
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engfrgnnm_addr = ""
                End If



                If IsNothing(dao_dr.fields.rid) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.rid = dao_dr.fields.rid
                Else
                    class_xml.XML_SEARCH_DRUG_DR.rid = ""
                End If


                If IsNothing(dao_dr.fields.cncdcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cncdcd = dao_dr.fields.cncdcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cncdcd = ""
                End If



                If IsNothing(dao_dr.fields.expdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.expdate = dao_dr.fields.expdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.expdate = Date.Now
                End If

                If IsNothing(dao_dr.fields.frn_no) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.frn_no = dao_dr.fields.frn_no
                Else
                    class_xml.XML_SEARCH_DRUG_DR.frn_no = ""
                End If

                If IsNothing(dao_dr.fields.itemno) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.itemno = dao_dr.fields.itemno
                Else
                    class_xml.XML_SEARCH_DRUG_DR.itemno = ""
                End If


                If IsNothing(dao_dr.fields.Ranking) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Ranking = dao_dr.fields.Ranking
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Ranking = ""
                End If

                If IsNothing(dao_dr.fields.typerqt) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.typerqt = dao_dr.fields.typerqt
                Else
                    class_xml.XML_SEARCH_DRUG_DR.typerqt = ""
                End If


                If IsNothing(dao_dr.fields.Buyers_through) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Buyers_through = dao_dr.fields.Buyers_through
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Buyers_through = ""
                End If


                If IsNothing(dao_dr.fields.Buyers_through_cntcd) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Buyers_through_cntcd = dao_dr.fields.Buyers_through_cntcd
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Buyers_through_cntcd = ""
                End If

                If IsNothing(dao_dr.fields.Newcode) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode = dao_dr.fields.Newcode
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode = ""
                End If

                If IsNothing(dao_dr.fields.Newcode_U) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_U = dao_dr.fields.Newcode_U
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_U = ""
                End If

                If IsNothing(dao_dr.fields.Newcode_R) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_R = dao_dr.fields.Newcode_R
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_R = ""
                End If

                If IsNothing(dao_dr.fields.Newcode_not) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_not = dao_dr.fields.Newcode_not
                Else
                    class_xml.XML_SEARCH_DRUG_DR.Newcode_not = ""
                End If

                If IsNothing(dao_dr.fields.register_search) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register_search = dao_dr.fields.register_search
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register_search = ""
                End If

                If IsNothing(dao_dr.fields.lmdfdate) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.lmdfdate = dao_dr.fields.lmdfdate
                Else
                    class_xml.XML_SEARCH_DRUG_DR.lmdfdate = Date.Now
                End If



                If IsNothing(dao_dr.fields.register_search2) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.register_search2 = dao_dr.fields.register_search2
                Else
                    class_xml.XML_SEARCH_DRUG_DR.register_search2 = ""
                End If


                If IsNothing(dao_dr.fields.indication) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.indication = dao_dr.fields.indication
                Else
                    class_xml.XML_SEARCH_DRUG_DR.indication = ""
                End If

                If IsNothing(dao_dr.fields.cncnote) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.cncnote = dao_dr.fields.cncnote
                Else
                    class_xml.XML_SEARCH_DRUG_DR.cncnote = ""
                End If


                If IsNothing(dao_dr.fields.CER_FORMAT) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.CER_FORMAT = dao_dr.fields.CER_FORMAT
                Else
                    class_xml.XML_SEARCH_DRUG_DR.CER_FORMAT = ""
                End If



                If IsNothing(dao_dr.fields.engcntnm) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.engcntnm = dao_dr.fields.engcntnm
                Else
                    class_xml.XML_SEARCH_DRUG_DR.engcntnm = ""
                End If
                If IsNothing(dao_dr.fields.IDA_dh15rqt) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.IDA_dh15rqt = dao_dr.fields.IDA_dh15rqt
                Else
                    class_xml.XML_SEARCH_DRUG_DR.IDA_dh15rqt = 0
                End If
                If IsNothing(dao_dr.fields.IDA_drrgt) = False Then
                    class_xml.XML_SEARCH_DRUG_DR.IDA_drrgt = dao_dr.fields.IDA_drrgt
                Else
                    class_xml.XML_SEARCH_DRUG_DR.IDA_drrgt = 0
                End If

#End Region
#Region "สภาวะการเก็บรักษา"
                '-----------------------สภาวะการเก็บรักษา

                Dim dao_stowagr As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_STOWAGR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_stowagr.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                For Each dao_stowagr.fields In dao_stowagr.datas
                    Dim lgt_stowagr As New LGT_XML_STOWAGR_TO

                    If IsNothing(dao_stowagr.fields.IDA) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.IDA = dao_stowagr.fields.IDA
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.IDA = 0
                    End If


                    If IsNothing(dao_stowagr.fields.pvncd) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.pvncd = dao_stowagr.fields.pvncd
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.pvncd = ""
                    End If

                    If IsNothing(dao_stowagr.fields.lcnno) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnno = dao_stowagr.fields.lcnno
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnno = ""
                    End If

                    If IsNothing(dao_stowagr.fields.lcnsid) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnsid = dao_stowagr.fields.lcnsid
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.lcnsid = ""
                    End If


                    If IsNothing(dao_stowagr.fields.rgtno) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.rgtno = dao_stowagr.fields.rgtno
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.rgtno = ""
                    End If
                    If IsNothing(dao_stowagr.fields.rid) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.rid = dao_stowagr.fields.rid
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.rid = ""
                    End If

                    If IsNothing(dao_stowagr.fields.thadrgnm) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.thadrgnm = dao_stowagr.fields.thadrgnm
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.thadrgnm = ""
                    End If

                    If IsNothing(dao_stowagr.fields.engdrgnm) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.engdrgnm = dao_stowagr.fields.engdrgnm
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.engdrgnm = ""
                    End If

                    If IsNothing(dao_stowagr.fields.keepdesc) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.keepdesc = dao_stowagr.fields.keepdesc
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.keepdesc = ""
                    End If


                    If IsNothing(dao_stowagr.fields.drgchrtha) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.drgchrtha = dao_stowagr.fields.drgchrtha
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.drgchrtha = ""
                    End If

                    If IsNothing(dao_stowagr.fields.useage) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.useage = dao_stowagr.fields.useage
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.useage = ""
                    End If
                    If IsNothing(dao_stowagr.fields.tplow) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.tplow = dao_stowagr.fields.tplow
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.tplow = ""
                    End If
                    If IsNothing(dao_stowagr.fields.tphigh) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.tphigh = dao_stowagr.fields.tphigh
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.tphigh = ""
                    End If
                    If IsNothing(dao_stowagr.fields.drug_age_days) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_days = dao_stowagr.fields.drug_age_days
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_days = ""
                    End If
                    If IsNothing(dao_stowagr.fields.drug_age_month) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_month = dao_stowagr.fields.drug_age_month
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.drug_age_month = ""
                    End If

                    If IsNothing(dao_stowagr.fields.Newcode) = False Then
                        lgt_stowagr.XML_DRUG_STOWAGR.Newcode = dao_stowagr.fields.Newcode
                    Else
                        lgt_stowagr.XML_DRUG_STOWAGR.Newcode = ""
                    End If


                    class_xml.LGT_XML_STOWAGR_TO.Add(lgt_stowagr)
                Next
#End Region
#Region "กลุ่มตำรับยา"
                '-----------------------กลุ่มตำรับยา
                Dim dao_RECIPE_GROUP As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_RECIPE_GROUP  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_RECIPE_GROUP.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                For Each dao_RECIPE_GROUP.fields In dao_RECIPE_GROUP.datas
                    Dim lgt_recipe As New LGT_RECIPE_GROUP_TO


                    If IsNothing(dao_RECIPE_GROUP.fields.IDA) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.IDA = dao_RECIPE_GROUP.fields.IDA
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.IDA = 0
                    End If


                    If IsNothing(dao_RECIPE_GROUP.fields.pvncd) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.pvncd = dao_RECIPE_GROUP.fields.pvncd
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.pvncd = ""
                    End If



                    If IsNothing(dao_RECIPE_GROUP.fields.lcnno) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnno = dao_RECIPE_GROUP.fields.lcnno
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnno = ""
                    End If



                    If IsNothing(dao_RECIPE_GROUP.fields.lcnsid) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnsid = dao_RECIPE_GROUP.fields.lcnsid
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.lcnsid = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.rgtno) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rgtno = dao_RECIPE_GROUP.fields.rgtno
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rgtno = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.version) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.version = dao_RECIPE_GROUP.fields.version
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.version = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.register) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.register = dao_RECIPE_GROUP.fields.register
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.register = ""
                    End If
                    If IsNothing(dao_RECIPE_GROUP.fields.rid) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rid = dao_RECIPE_GROUP.fields.rid
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.rid = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.thadrgnm) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.thadrgnm = dao_RECIPE_GROUP.fields.thadrgnm
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.thadrgnm = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.engdrgnm) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.engdrgnm = dao_RECIPE_GROUP.fields.engdrgnm
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.engdrgnm = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.atccd) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atccd = dao_RECIPE_GROUP.fields.atccd
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atccd = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.atcnm) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atcnm = dao_RECIPE_GROUP.fields.atcnm
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.atcnm = ""
                    End If

                    'If IsNothing(dao_RECIPE_GROUP.fields.iowanm) = False Then
                    '    lgt_recipe.XML_RECIPE_GROUPT.iowanm = dao_RECIPE_GROUP.fields.iowanm
                    'Else
                    '    lgt_recipe.XML_RECIPE_GROUPT.iowanm = ""
                    'End If


                    'If IsNothing(dao_RECIPE_GROUP.fields.qty_all) = False Then
                    '    lgt_recipe.XML_RECIPE_GROUPT.qty_all = dao_RECIPE_GROUP.fields.qty_all
                    'Else
                    '    lgt_recipe.XML_RECIPE_GROUPT.qty_all = ""
                    'End If

                    'If IsNothing(dao_RECIPE_GROUP.fields.drgperunit) = False Then
                    '    lgt_recipe.XML_RECIPE_GROUPT.drgperunit = dao_RECIPE_GROUP.fields.drgperunit
                    'Else
                    '    lgt_recipe.XML_RECIPE_GROUPT.drgperunit = ""
                    'End If

                    If IsNothing(dao_RECIPE_GROUP.fields.Newcode) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Newcode = dao_RECIPE_GROUP.fields.Newcode
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Newcode = ""
                    End If


                    If IsNothing(dao_RECIPE_GROUP.fields.ATCCDL1) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL1 = dao_RECIPE_GROUP.fields.ATCCDL1
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL1 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.ATCCDL2) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL2 = dao_RECIPE_GROUP.fields.ATCCDL2
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL2 = ""
                    End If


                    If IsNothing(dao_RECIPE_GROUP.fields.ATCCDL3) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL3 = dao_RECIPE_GROUP.fields.ATCCDL3
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL3 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.ATCCDL4) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL4 = dao_RECIPE_GROUP.fields.ATCCDL4
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL4 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.ATCCDL5) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL5 = dao_RECIPE_GROUP.fields.ATCCDL5
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL5 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.ATCCDL6) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL6 = dao_RECIPE_GROUP.fields.ATCCDL6
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCCDL6 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.ATCNML1) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML1 = dao_RECIPE_GROUP.fields.ATCNML1
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML1 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.ATCNML2) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML2 = dao_RECIPE_GROUP.fields.ATCNML2
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML2 = ""
                    End If


                    If IsNothing(dao_RECIPE_GROUP.fields.ATCNML3) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML3 = dao_RECIPE_GROUP.fields.ATCNML3
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML3 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.ATCNML4) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML4 = dao_RECIPE_GROUP.fields.ATCNML4
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML4 = ""
                    End If
                    If IsNothing(dao_RECIPE_GROUP.fields.ATCNML5) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML5 = dao_RECIPE_GROUP.fields.ATCNML5
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML5 = ""
                    End If


                    If IsNothing(dao_RECIPE_GROUP.fields.ATCNML6) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML6 = dao_RECIPE_GROUP.fields.ATCNML6
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.ATCNML6 = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.WHODDDAmount) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDAmount = dao_RECIPE_GROUP.fields.WHODDDAmount
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDAmount = ""
                    End If


                    If IsNothing(dao_RECIPE_GROUP.fields.WHODDDUnit) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDUnit = dao_RECIPE_GROUP.fields.WHODDDUnit
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.WHODDDUnit = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.DDD) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.DDD = dao_RECIPE_GROUP.fields.DDD
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.DDD = ""
                    End If

                    If IsNothing(dao_RECIPE_GROUP.fields.UNIT_CD) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.UNIT_CD = dao_RECIPE_GROUP.fields.UNIT_CD
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.UNIT_CD = ""
                    End If


                    If IsNothing(dao_RECIPE_GROUP.fields.Adm_R) = False Then
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Adm_R = dao_RECIPE_GROUP.fields.Adm_R
                    Else
                        lgt_recipe.XML_DRUG_RECIPE_GROUP.Adm_R = ""
                    End If

                    class_xml.LGT_RECIPE_GROUP_TO.Add(lgt_recipe)
                Next
#End Region
#Region "ยาสัตว์มีส่วนบริโภคและไม่มีส่วนบริโภค"
                '-----------------------ยาสัตว์มีส่วนบริโภคและไม่มีส่วนบริโภค
                Dim dao_ANIMAL_DRUG As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_ANIMAL  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_ANIMAL_DRUG.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                For Each dao_ANIMAL_DRUG.fields In dao_ANIMAL_DRUG.datas
                    Dim lgt_animal As New LGT_ANIMAL_DRUGS_TO

                    If IsNothing(dao_ANIMAL_DRUG.fields.IDA) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.IDA = dao_ANIMAL_DRUG.fields.IDA
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.IDA = 0
                    End If


                    If IsNothing(dao_ANIMAL_DRUG.fields.pvncd) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.pvncd = dao_ANIMAL_DRUG.fields.pvncd
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.pvncd = ""
                    End If


                    If IsNothing(dao_ANIMAL_DRUG.fields.lcnno) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.lcnno = dao_ANIMAL_DRUG.fields.lcnno
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.lcnno = ""
                    End If


                    If IsNothing(dao_ANIMAL_DRUG.fields.lcnsid) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.lcnsid = dao_ANIMAL_DRUG.fields.lcnsid
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.lcnsid = ""
                    End If


                    If IsNothing(dao_ANIMAL_DRUG.fields.rgttpcd) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.rgttpcd = dao_ANIMAL_DRUG.fields.rgttpcd
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.rgttpcd = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.rgtno) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.rgtno = dao_ANIMAL_DRUG.fields.rgtno
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.rgtno = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.thadrgnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.thadrgnm = dao_ANIMAL_DRUG.fields.thadrgnm
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.thadrgnm = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.engdrgnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.engdrgnm = dao_ANIMAL_DRUG.fields.engdrgnm
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.engdrgnm = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.ampartnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.ampartnm = dao_ANIMAL_DRUG.fields.ampartnm
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.ampartnm = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.amlsubnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.amlsubnm = dao_ANIMAL_DRUG.fields.amlsubnm
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.amlsubnm = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.amltpnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.amltpnm = dao_ANIMAL_DRUG.fields.amltpnm
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.amltpnm = ""
                    End If


                    If IsNothing(dao_ANIMAL_DRUG.fields.usetpnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.usetpnm = dao_ANIMAL_DRUG.fields.usetpnm

                    Else
                        lgt_animal.XML_DRUG_ANIMAL.usetpnm = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.stpdrg) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = dao_ANIMAL_DRUG.fields.stpdrg
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.rid) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.rid = dao_ANIMAL_DRUG.fields.rid
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.rid = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.Newcode) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.Newcode = dao_ANIMAL_DRUG.fields.Newcode
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.Newcode = ""
                    End If


                    If IsNothing(dao_ANIMAL_DRUG.fields.Newcode) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.register = dao_ANIMAL_DRUG.fields.register
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.Newcode = ""
                    End If


                    If IsNothing(dao_ANIMAL_DRUG.fields.licen_loca) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.licen_loca = dao_ANIMAL_DRUG.fields.licen_loca
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.licen_loca = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.thaclassnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.thaclassnm = dao_ANIMAL_DRUG.fields.thaclassnm
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.thaclassnm = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.cncnm) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.cncnm = dao_ANIMAL_DRUG.fields.cncnm
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.cncnm = ""
                    End If

                    If IsNothing(dao_ANIMAL_DRUG.fields.stpdrg) = False Then
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = dao_ANIMAL_DRUG.fields.stpdrg
                    Else
                        lgt_animal.XML_DRUG_ANIMAL.stpdrg = ""
                    End If

                    class_xml.LGT_ANIMAL_DRUGS_TO.Add(lgt_animal)




                    Dim animal_ampartnm As String
                    Dim animal_amlsubnm As String
                    Dim animal_amltpnm As String
                    Dim animal_usetpnm As String
                    Dim Newcode_animal_consume As String


                    Dim dt_animal_consume As New DataTable
                    animal_ampartnm = dao_ANIMAL_DRUG.fields.ampartnm
                    animal_amlsubnm = dao_ANIMAL_DRUG.fields.amlsubnm
                    animal_amltpnm = dao_ANIMAL_DRUG.fields.amltpnm
                    animal_usetpnm = dao_ANIMAL_DRUG.fields.usetpnm
                    Newcode_animal_consume = dao_ANIMAL_DRUG.fields.Newcode



                    Dim dao_ANIMAL_COS_DRUG As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_ANIMAL_CONSUME  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                    dao_ANIMAL_COS_DRUG.GetDataby_animal_consume(animal_ampartnm, animal_amlsubnm, animal_amltpnm, animal_usetpnm, Newcode_animal_consume)

                    For Each dao_ANIMAL_COS_DRUG.fields In dao_ANIMAL_COS_DRUG.datas
                        Dim lgt_animal_consume As New LGT_ANIMAL_CONSUME_DRUGS_TO

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.pvncd) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.pvncd = dao_ANIMAL_COS_DRUG.fields.pvncd
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.pvncd = ""
                        End If


                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.lcnno) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnno = dao_ANIMAL_COS_DRUG.fields.lcnno
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnno = ""
                        End If

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.lcnsid) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnsid = dao_ANIMAL_COS_DRUG.fields.lcnsid
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.lcnsid = ""
                        End If

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.rgttpcd) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgttpcd = dao_ANIMAL_COS_DRUG.fields.rgttpcd
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgttpcd = ""
                        End If




                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.rgtno) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgtno = dao_ANIMAL_COS_DRUG.fields.rgtno
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rgtno = ""
                        End If

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.thadrgnm) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.thadrgnm = dao_ANIMAL_COS_DRUG.fields.thadrgnm
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.thadrgnm = ""
                        End If



                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.engdrgnm) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.engdrgnm = dao_ANIMAL_COS_DRUG.fields.engdrgnm
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.engdrgnm = ""
                        End If


                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.ampartnm) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.ampartnm = dao_ANIMAL_COS_DRUG.fields.ampartnm
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.ampartnm = ""
                        End If


                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.amlsubnm) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amlsubnm = dao_ANIMAL_COS_DRUG.fields.amlsubnm
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amlsubnm = ""
                        End If

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.amltpnm) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amltpnm = dao_ANIMAL_COS_DRUG.fields.amltpnm
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.amltpnm = ""
                        End If



                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.usetpnm) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.usetpnm = dao_ANIMAL_COS_DRUG.fields.usetpnm
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.usetpnm = ""
                        End If


                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.stpdrg) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.stpdrg = dao_ANIMAL_COS_DRUG.fields.stpdrg
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.stpdrg = ""
                        End If
                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.rid) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rid = dao_ANIMAL_COS_DRUG.fields.rid
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.rid = ""
                        End If

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.Newcode) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.Newcode = dao_ANIMAL_COS_DRUG.fields.Newcode
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.Newcode = ""
                        End If

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.packuse) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.packuse = dao_ANIMAL_COS_DRUG.fields.packuse
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.packuse = ""
                        End If

                        If IsNothing(dao_ANIMAL_COS_DRUG.fields.nouse) = False Then
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.nouse = dao_ANIMAL_COS_DRUG.fields.nouse
                        Else
                            lgt_animal_consume.XML_DRUG_ANIMAL_CONSUME.nouse = ""
                        End If

                        lgt_animal.LGT_ANIMAL_CONSUME_DRUGS_TO.Add(lgt_animal_consume)
                    Next

                Next
#End Region
#Region "สาร"

                '-------------เริ่มต้นสาร-----------------------------------------------------------------------------------------------------
                '-----------------------สารสำคัญ + สาร EQ.TO
                Dim dao_iow As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                Dim dao_iow_gp As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW
                dao_iow_gp.GetDataby_Newcode_U_GROUP(dao_dr.fields.Newcode_U)

                For Each dr In dao_iow_gp.datas
                    dao_iow.GetDataby_Newcode_U(dao_dr.fields.Newcode_U, dr.ToString.Substring(12).Replace("}", "")) ' Substring=12 เพ

                    For Each dao_iow.fields In dao_iow.datas
                        Dim lgt_iow As New XML_DRUG_IOW_TO

                        If IsNothing(dao_iow.fields.IDA) = False Then
                            lgt_iow.XML_DRUG_IOW.IDA = dao_iow.fields.IDA
                        Else
                            lgt_iow.XML_DRUG_IOW.IDA = 0
                        End If

                        If IsNothing(dao_iow.fields.pvncd) = False Then
                            lgt_iow.XML_DRUG_IOW.pvncd = dao_iow.fields.pvncd
                        Else
                            lgt_iow.XML_DRUG_IOW.pvncd = ""
                        End If

                        If IsNothing(dao_iow.fields.rgttpcd) = False Then
                            lgt_iow.XML_DRUG_IOW.rgttpcd = dao_iow.fields.rgttpcd
                        Else
                            lgt_iow.XML_DRUG_IOW.rgttpcd = ""
                        End If

                        If IsNothing(dao_iow.fields.rgtno) = False Then
                            lgt_iow.XML_DRUG_IOW.rgtno = dao_iow.fields.rgtno
                        Else
                            lgt_iow.XML_DRUG_IOW.rgtno = ""
                        End If

                        If IsNothing(dao_iow.fields.lcnno) = False Then
                            lgt_iow.XML_DRUG_IOW.lcnno = dao_iow.fields.lcnno
                        Else
                            lgt_iow.XML_DRUG_IOW.lcnno = ""
                        End If
                        If IsNothing(dao_iow.fields.register) = False Then
                            lgt_iow.XML_DRUG_IOW.register = dao_iow.fields.register
                        Else
                            lgt_iow.XML_DRUG_IOW.register = ""
                        End If

                        If IsNothing(dao_iow.fields.lcnsid) = False Then
                            lgt_iow.XML_DRUG_IOW.lcnsid = dao_iow.fields.lcnsid
                        Else
                            lgt_iow.XML_DRUG_IOW.lcnsid = ""
                        End If


                        If IsNothing(dao_iow.fields.CITIZEN_AUTHORIZE) = False Then
                            lgt_iow.XML_DRUG_IOW.CITIZEN_AUTHORIZE = dao_iow.fields.CITIZEN_AUTHORIZE
                        Else
                            lgt_iow.XML_DRUG_IOW.CITIZEN_AUTHORIZE = ""
                        End If

                        If IsNothing(dao_iow.fields.flineno) = False Then
                            lgt_iow.XML_DRUG_IOW.flineno = dao_iow.fields.flineno
                        Else
                            lgt_iow.XML_DRUG_IOW.flineno = ""
                        End If

                        If IsNothing(dao_iow.fields.drgqty) = False Then
                            lgt_iow.XML_DRUG_IOW.drgqty = dao_iow.fields.drgqty
                        Else
                            lgt_iow.XML_DRUG_IOW.drgqty = ""
                        End If

                        If IsNothing(dao_iow.fields.drgperunit) = False Then
                            lgt_iow.XML_DRUG_IOW.drgperunit = dao_iow.fields.drgperunit
                        Else
                            lgt_iow.XML_DRUG_IOW.drgperunit = ""
                        End If

                        If IsNothing(dao_iow.fields.drgcdt) = False Then
                            lgt_iow.XML_DRUG_IOW.drgcdt = dao_iow.fields.drgcdt
                        Else
                            lgt_iow.XML_DRUG_IOW.drgcdt = ""
                        End If

                        If IsNothing(dao_iow.fields.thadsgnm) = False Then
                            lgt_iow.XML_DRUG_IOW.thadsgnm = dao_iow.fields.thadsgnm
                        Else
                            lgt_iow.XML_DRUG_IOW.thadsgnm = ""
                        End If


                        If IsNothing(dao_iow.fields.rid) = False Then
                            lgt_iow.XML_DRUG_IOW.rid = dao_iow.fields.rid
                        Else
                            lgt_iow.XML_DRUG_IOW.rid = ""
                        End If


                        If IsNothing(dao_iow.fields.iowacd) = False Then
                            lgt_iow.XML_DRUG_IOW.iowacd = dao_iow.fields.iowacd
                        Else
                            lgt_iow.XML_DRUG_IOW.iowacd = ""
                        End If


                        If IsNothing(dao_iow.fields.iowanm) = False Then
                            lgt_iow.XML_DRUG_IOW.iowanm = dao_iow.fields.iowanm
                        Else
                            lgt_iow.XML_DRUG_IOW.iowanm = ""
                        End If
                        If IsNothing(dao_iow.fields.SinggleContent) = False Then
                            lgt_iow.XML_DRUG_IOW.SinggleContent = dao_iow.fields.SinggleContent
                        Else
                            lgt_iow.XML_DRUG_IOW.SinggleContent = ""
                        End If

                        If IsNothing(dao_iow.fields.UnitForSinggleContent) = False Then
                            lgt_iow.XML_DRUG_IOW.UnitForSinggleContent = dao_iow.fields.UnitForSinggleContent
                        Else
                            lgt_iow.XML_DRUG_IOW.UnitForSinggleContent = ""
                        End If

                        If IsNothing(dao_iow.fields.qtytxt_all) = False Then
                            lgt_iow.XML_DRUG_IOW.qtytxt_all = dao_iow.fields.qtytxt_all
                        Else
                            lgt_iow.XML_DRUG_IOW.qtytxt_all = ""
                        End If

                        If IsNothing(dao_iow.fields.qtytxt) = False Then
                            lgt_iow.XML_DRUG_IOW.qtytxt = dao_iow.fields.qtytxt
                        Else
                            lgt_iow.XML_DRUG_IOW.qtytxt = ""
                        End If

                        If IsNothing(dao_iow.fields.qty) = False Then
                            lgt_iow.XML_DRUG_IOW.qty = dao_iow.fields.qty
                        Else
                            lgt_iow.XML_DRUG_IOW.qty = ""
                        End If


                        If IsNothing(dao_iow.fields.qty_y) = False Then
                            lgt_iow.XML_DRUG_IOW.qty_y = dao_iow.fields.qty_y
                        Else
                            lgt_iow.XML_DRUG_IOW.qty_y = ""
                        End If



                        If IsNothing(dao_iow.fields.qty_y) = False Then
                            lgt_iow.XML_DRUG_IOW.qty_y = dao_iow.fields.qty_y
                        Else
                            lgt_iow.XML_DRUG_IOW.qty_y = ""
                        End If



                        If IsNothing(dao_iow.fields.sunitengnm) = False Then
                            lgt_iow.XML_DRUG_IOW.sunitengnm = dao_iow.fields.sunitengnm
                        Else
                            lgt_iow.XML_DRUG_IOW.sunitengnm = ""
                        End If


                        If IsNothing(dao_iow.fields.thadrgnm) = False Then
                            lgt_iow.XML_DRUG_IOW.thadrgnm = dao_iow.fields.thadrgnm
                        Else
                            lgt_iow.XML_DRUG_IOW.thadrgnm = ""
                        End If

                        If IsNothing(dao_iow.fields.engdrgnm) = False Then
                            lgt_iow.XML_DRUG_IOW.engdrgnm = dao_iow.fields.engdrgnm
                        Else
                            lgt_iow.XML_DRUG_IOW.engdrgnm = ""
                        End If


                        If IsNothing(dao_iow.fields.aori) = False Then
                            lgt_iow.XML_DRUG_IOW.aori = dao_iow.fields.aori
                        Else
                            lgt_iow.XML_DRUG_IOW.aori = ""
                        End If


                        If IsNothing(dao_iow.fields.aori_description) = False Then
                            lgt_iow.XML_DRUG_IOW.aori_description = dao_iow.fields.aori_description
                        Else
                            lgt_iow.XML_DRUG_IOW.aori_description = ""
                        End If

                        If IsNothing(dao_iow.fields.remark) = False Then
                            lgt_iow.XML_DRUG_IOW.remark = dao_iow.fields.remark
                        Else
                            lgt_iow.XML_DRUG_IOW.remark = ""
                        End If


                        If IsNothing(dao_iow.fields.cncnm) = False Then
                            lgt_iow.XML_DRUG_IOW.cncnm = dao_iow.fields.cncnm
                        Else
                            lgt_iow.XML_DRUG_IOW.cncnm = ""
                        End If



                        If IsNothing(dao_iow.fields.licen_loca) = False Then
                            lgt_iow.XML_DRUG_IOW.licen_loca = dao_iow.fields.licen_loca
                        Else
                            lgt_iow.XML_DRUG_IOW.licen_loca = ""
                        End If

                        If IsNothing(dao_iow.fields.Newcode_U) = False Then
                            lgt_iow.XML_DRUG_IOW.Newcode_U = dao_iow.fields.Newcode_U
                        Else
                            lgt_iow.XML_DRUG_IOW.Newcode_U = ""
                        End If


                        If IsNothing(dao_iow.fields.Newcode_rid) = False Then
                            lgt_iow.XML_DRUG_IOW.Newcode_rid = dao_iow.fields.Newcode_rid
                        Else
                            lgt_iow.XML_DRUG_IOW.Newcode_rid = ""
                        End If

                        If IsNothing(dao_iow.fields.Newcode_R) = False Then
                            lgt_iow.XML_DRUG_IOW.Newcode_R = dao_iow.fields.Newcode_R
                        Else
                            lgt_iow.XML_DRUG_IOW.Newcode_R = ""
                        End If



                        If IsNothing(dao_iow.fields.RoleinFomular) = False Then
                            lgt_iow.XML_DRUG_IOW.RoleinFomular = dao_iow.fields.RoleinFomular
                        Else
                            lgt_iow.XML_DRUG_IOW.RoleinFomular = ""
                        End If

                        If IsNothing(dao_iow.fields.ConditionContent) = False Then
                            lgt_iow.XML_DRUG_IOW.ConditionContent = dao_iow.fields.ConditionContent
                        Else
                            lgt_iow.XML_DRUG_IOW.ConditionContent = ""
                        End If


                        If IsNothing(dao_iow.fields.MultiplyNumberStart) = False Then
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberStart = dao_iow.fields.MultiplyNumberStart
                        Else
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberStart = ""
                        End If


                        If IsNothing(dao_iow.fields.BaseNumberStart) = False Then
                            lgt_iow.XML_DRUG_IOW.BaseNumberStart = dao_iow.fields.BaseNumberStart
                        Else
                            lgt_iow.XML_DRUG_IOW.BaseNumberStart = ""
                        End If



                        If IsNothing(dao_iow.fields.PowerNumberStart) = False Then
                            lgt_iow.XML_DRUG_IOW.PowerNumberStart = dao_iow.fields.PowerNumberStart
                        Else
                            lgt_iow.XML_DRUG_IOW.PowerNumberStart = ""
                        End If




                        If IsNothing(dao_iow.fields.MultiplyNumberEND) = False Then
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberEND = dao_iow.fields.MultiplyNumberEND
                        Else
                            lgt_iow.XML_DRUG_IOW.MultiplyNumberEND = ""
                        End If

                        If IsNothing(dao_iow.fields.BaseNumberEND) = False Then
                            lgt_iow.XML_DRUG_IOW.BaseNumberEND = dao_iow.fields.BaseNumberEND
                        Else
                            lgt_iow.XML_DRUG_IOW.BaseNumberEND = ""
                        End If


                        If IsNothing(dao_iow.fields.PowerNumberEND) = False Then
                            lgt_iow.XML_DRUG_IOW.PowerNumberEND = dao_iow.fields.PowerNumberEND
                        Else
                            lgt_iow.XML_DRUG_IOW.PowerNumberEND = ""
                        End If


                        If IsNothing(dao_iow.fields.UnitForRangeContent) = False Then
                            lgt_iow.XML_DRUG_IOW.UnitForRangeContent = dao_iow.fields.UnitForRangeContent
                        Else
                            lgt_iow.XML_DRUG_IOW.UnitForRangeContent = ""
                        End If
                        If IsNothing(dao_iow.fields.IDA_DRRGT_DETAIL_CAS) = False Then
                            lgt_iow.XML_DRUG_IOW.IDA_DRRGT_DETAIL_CAS = dao_iow.fields.IDA_DRRGT_DETAIL_CAS
                        Else
                            lgt_iow.XML_DRUG_IOW.IDA_DRRGT_DETAIL_CAS = 0
                        End If


                        Dim dao_iow_eq As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_IOW_EQ  ' ถ้าเป็น List of2 ต้องใช้อันนี้ และ การที่นำเข้ามาไว้ใน next คือ List ซ้อน List  ชื่อสารที่อยู่ในแต่ละผลิตภัณฑ์ย่อย
                        dao_iow_eq.GetDataby_Newcode_RID(dao_iow.fields.Newcode_rid)

                        For Each dao_iow_eq.fields In dao_iow_eq.datas
                            Dim lgt_eq As New LGT_IOW_EQ_TO                            ' XML_CMT_TYPE2 คือตารางชื่อสาร  

                            lgt_eq.XML_DRUG_IOW_EQ.IDA = dao_iow_eq.fields.IDA



                            If IsNothing(dao_iow_eq.fields.IDA) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.IDA = dao_iow_eq.fields.IDA
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.IDA = 0
                            End If



                            If IsNothing(dao_iow_eq.fields.pvncd) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.pvncd = dao_iow_eq.fields.pvncd
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.pvncd = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.drgtpcd) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgtpcd = dao_iow_eq.fields.drgtpcd
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgtpcd = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.rgttpcd) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.rgttpcd = dao_iow_eq.fields.rgttpcd
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.rgttpcd = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.rgtno) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.rgtno = dao_iow_eq.fields.rgtno
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.rgtno = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.lcnno) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.lcnno = dao_iow_eq.fields.lcnno
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.lcnno = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.register) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.register = dao_iow_eq.fields.register
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.register = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.CITIZEN_AUTHORIZE) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.CITIZEN_AUTHORIZE = dao_iow_eq.fields.CITIZEN_AUTHORIZE
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.CITIZEN_AUTHORIZE = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.thadrgnm) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.thadrgnm = dao_iow_eq.fields.thadrgnm
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.thadrgnm = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.engdrgnm) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.engdrgnm = dao_iow_eq.fields.engdrgnm
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.engdrgnm = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.flineno) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.flineno = dao_iow_eq.fields.flineno
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.flineno = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.drgqty) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgqty = dao_iow_eq.fields.drgqty
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgqty = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.drgperunit) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgperunit = dao_iow_eq.fields.drgperunit
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgperunit = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.drgcdt) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt = dao_iow_eq.fields.drgcdt
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.drgcdt_condition) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt_condition = dao_iow_eq.fields.drgcdt_condition
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.drgcdt_condition = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.rid) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.rid = dao_iow_eq.fields.rid
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.rid = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.elineno) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.elineno = dao_iow_eq.fields.elineno
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.elineno = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.iowacd) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.iowacd = dao_iow_eq.fields.iowacd
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.iowacd = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.iowanm) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.iowanm = dao_iow_eq.fields.iowanm
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.iowanm = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.SinggleContent) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.SinggleContent = dao_iow_eq.fields.SinggleContent
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.SinggleContent = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.UnitForSinggleContent) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForSinggleContent = dao_iow_eq.fields.UnitForSinggleContent
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForSinggleContent = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.qty) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.qty = dao_iow_eq.fields.qty
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.qty = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.ConditionContent) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.ConditionContent = dao_iow_eq.fields.ConditionContent
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.ConditionContent = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.MultiplyNumberStart) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberStart = dao_iow_eq.fields.MultiplyNumberStart
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberStart = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.BaseNumberStart) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberStart = dao_iow_eq.fields.BaseNumberStart
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberStart = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.PowerNumberStart) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberStart = dao_iow_eq.fields.PowerNumberStart
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberStart = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.MultiplyNumberEND) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberEND = dao_iow_eq.fields.MultiplyNumberEND
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.MultiplyNumberEND = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.BaseNumberEND) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberEND = dao_iow_eq.fields.BaseNumberEND
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.BaseNumberEND = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.PowerNumberEND) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberEND = dao_iow_eq.fields.PowerNumberEND
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.PowerNumberEND = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.UnitForRangeContent) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForRangeContent = dao_iow_eq.fields.UnitForRangeContent
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.UnitForRangeContent = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.aori) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.aori = dao_iow_eq.fields.aori
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.aori = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.Newcode) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode = dao_iow_eq.fields.Newcode
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.Newcode_rid) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_rid = dao_iow_eq.fields.Newcode_rid
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_rid = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.Newcode_R) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_R = dao_iow_eq.fields.Newcode_R
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.Newcode_R = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.licen_loca) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.licen_loca = dao_iow_eq.fields.licen_loca
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.licen_loca = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.thaclassnm) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.thaclassnm = dao_iow_eq.fields.thaclassnm
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.thaclassnm = ""
                            End If


                            If IsNothing(dao_iow_eq.fields.cncnm) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.cncnm = dao_iow_eq.fields.cncnm
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.cncnm = ""
                            End If

                            If IsNothing(dao_iow_eq.fields.remark) = False Then
                                lgt_eq.XML_DRUG_IOW_EQ.remark = dao_iow_eq.fields.remark
                            Else
                                lgt_eq.XML_DRUG_IOW_EQ.remark = ""
                            End If
                            XML_DRUG_IOW_TO1.LGT_IOW_EQ_TO.Add(lgt_eq)
                            'lgt_iow.LGT_IOW_EQ_TO.Add(lgt_eq)

                        Next
                        XML_DRUG_IOW_TO1.XML_DRUG_IOW = lgt_iow.XML_DRUG_IOW

                        XML_DRUG_IOW_TYPE1.XML_DRUG_IOW_TO.Add(XML_DRUG_IOW_TO1)
                        'class_xml.LGT_IOW_EQ.Add(lgt_iow)

                        XML_DRUG_IOW_TO1 = New XML_DRUG_IOW_TO
                    Next


                    class_xml.LGT_IOW_EQ.XML_DRUG_IOW_TYPE.Add(XML_DRUG_IOW_TYPE1)
                    XML_DRUG_IOW_TYPE1 = New XML_DRUG_IOW_TYPE
                Next
#End Region
#Region "ชื่อผู้ผลิตต่างประเทศ"
                '-----------------------ชื่อผู้ผลิตต่างประเทศ
                Dim dao_FRGN As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_FRGN  'คือตารางผู้ผลิตต่างประเทศและในประเทศรวมกัน
                dao_FRGN.GetDataby_Newcode(dao_dr.fields.Newcode_U)

                For Each dao_FRGN.fields In dao_FRGN.datas
                    Dim lgt_frgn As New LGT_XML_FRGN_ALL_TO
                    lgt_frgn.XML_DRUG_FRGN.IDA = dao_FRGN.fields.IDA


                    If IsNothing(dao_FRGN.fields.pvncd) = False Then
                        lgt_frgn.XML_DRUG_FRGN.pvncd = dao_FRGN.fields.pvncd
                    Else
                        lgt_frgn.XML_DRUG_FRGN.pvncd = ""
                    End If
                    If IsNothing(dao_FRGN.fields.drgtpcd) = False Then
                        lgt_frgn.XML_DRUG_FRGN.drgtpcd = dao_FRGN.fields.drgtpcd
                    Else
                        lgt_frgn.XML_DRUG_FRGN.drgtpcd = ""
                    End If

                    If IsNothing(dao_FRGN.fields.rgttpcd) = False Then
                        lgt_frgn.XML_DRUG_FRGN.rgttpcd = dao_FRGN.fields.rgttpcd
                    Else
                        lgt_frgn.XML_DRUG_FRGN.rgttpcd = ""
                    End If
                    If IsNothing(dao_FRGN.fields.rgtno) = False Then
                        lgt_frgn.XML_DRUG_FRGN.rgtno = dao_FRGN.fields.rgtno
                    Else
                        lgt_frgn.XML_DRUG_FRGN.rgtno = ""
                    End If



                    If IsNothing(dao_FRGN.fields.thadrgnm) = False Then
                        lgt_frgn.XML_DRUG_FRGN.thadrgnm = dao_FRGN.fields.thadrgnm
                    Else
                        lgt_frgn.XML_DRUG_FRGN.thadrgnm = ""
                    End If

                    If IsNothing(dao_FRGN.fields.engdrgnm) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engdrgnm = dao_FRGN.fields.engdrgnm
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engdrgnm = ""
                    End If
                    If IsNothing(dao_FRGN.fields.lcnsid) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lcnsid = dao_FRGN.fields.lcnsid
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lcnsid = ""
                    End If
                    If IsNothing(dao_FRGN.fields.CITIZEN_AUTHORIZE) = False Then
                        lgt_frgn.XML_DRUG_FRGN.CITIZEN_AUTHORIZE = dao_FRGN.fields.CITIZEN_AUTHORIZE
                    Else
                        lgt_frgn.XML_DRUG_FRGN.CITIZEN_AUTHORIZE = ""
                    End If

                    If IsNothing(dao_FRGN.fields.lcnno) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lcnno = dao_FRGN.fields.lcnno
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lcnno = ""
                    End If


                    If IsNothing(dao_FRGN.fields.thanm) = False Then
                        lgt_frgn.XML_DRUG_FRGN.thanm = dao_FRGN.fields.thanm
                    Else
                        lgt_frgn.XML_DRUG_FRGN.thanm = ""
                    End If


                    If IsNothing(dao_FRGN.fields.fulladdr) = False Then
                        lgt_frgn.XML_DRUG_FRGN.fulladdr = dao_FRGN.fields.fulladdr
                    Else
                        lgt_frgn.XML_DRUG_FRGN.fulladdr = ""
                    End If


                    If IsNothing(dao_FRGN.fields.engfrgnnm) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm = dao_FRGN.fields.engfrgnnm
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm = ""
                    End If

                    If IsNothing(dao_FRGN.fields.engfrgnnm_all) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm_all = dao_FRGN.fields.engfrgnnm_all
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engfrgnnm_all = ""
                    End If


                    If IsNothing(dao_FRGN.fields.offengnm) = False Then
                        lgt_frgn.XML_DRUG_FRGN.offengnm = dao_FRGN.fields.offengnm
                    Else
                        lgt_frgn.XML_DRUG_FRGN.offengnm = ""
                    End If

                    If IsNothing(dao_FRGN.fields.engcntnm) = False Then
                        lgt_frgn.XML_DRUG_FRGN.engcntnm = dao_FRGN.fields.engcntnm
                    Else
                        lgt_frgn.XML_DRUG_FRGN.engcntnm = ""
                    End If

                    If IsNothing(dao_FRGN.fields.funccd) = False Then
                        lgt_frgn.XML_DRUG_FRGN.funccd = dao_FRGN.fields.funccd
                    Else
                        lgt_frgn.XML_DRUG_FRGN.funccd = ""
                    End If

                    If IsNothing(dao_FRGN.fields.funcnm) = False Then
                        lgt_frgn.XML_DRUG_FRGN.funcnm = dao_FRGN.fields.funcnm
                    Else
                        lgt_frgn.XML_DRUG_FRGN.funcnm = ""
                    End If

                    If IsNothing(dao_FRGN.fields.addr) = False Then
                        lgt_frgn.XML_DRUG_FRGN.addr = dao_FRGN.fields.addr
                    Else
                        lgt_frgn.XML_DRUG_FRGN.addr = ""
                    End If

                    If IsNothing(dao_FRGN.fields.room) = False Then
                        lgt_frgn.XML_DRUG_FRGN.room = dao_FRGN.fields.room
                    Else
                        lgt_frgn.XML_DRUG_FRGN.room = ""
                    End If


                    If IsNothing(dao_FRGN.fields.floor) = False Then
                        lgt_frgn.XML_DRUG_FRGN.floor = dao_FRGN.fields.floor
                    Else
                        lgt_frgn.XML_DRUG_FRGN.floor = ""
                    End If


                    If IsNothing(dao_FRGN.fields.building) = False Then
                        lgt_frgn.XML_DRUG_FRGN.building = dao_FRGN.fields.building
                    Else
                        lgt_frgn.XML_DRUG_FRGN.building = ""
                    End If

                    If IsNothing(dao_FRGN.fields.soi) = False Then
                        lgt_frgn.XML_DRUG_FRGN.soi = dao_FRGN.fields.soi
                    Else
                        lgt_frgn.XML_DRUG_FRGN.soi = ""
                    End If

                    If IsNothing(dao_FRGN.fields.road) = False Then
                        lgt_frgn.XML_DRUG_FRGN.road = dao_FRGN.fields.road
                    Else
                        lgt_frgn.XML_DRUG_FRGN.road = ""
                    End If

                    If IsNothing(dao_FRGN.fields.mu) = False Then
                        lgt_frgn.XML_DRUG_FRGN.mu = dao_FRGN.fields.mu
                    Else
                        lgt_frgn.XML_DRUG_FRGN.mu = ""
                    End If

                    If IsNothing(dao_FRGN.fields.district) = False Then
                        lgt_frgn.XML_DRUG_FRGN.district = dao_FRGN.fields.district
                    Else
                        lgt_frgn.XML_DRUG_FRGN.district = ""
                    End If

                    If IsNothing(dao_FRGN.fields.subdiv) = False Then
                        lgt_frgn.XML_DRUG_FRGN.subdiv = dao_FRGN.fields.subdiv
                    Else
                        lgt_frgn.XML_DRUG_FRGN.subdiv = ""
                    End If


                    If IsNothing(dao_FRGN.fields.Province) = False Then
                        lgt_frgn.XML_DRUG_FRGN.Province = dao_FRGN.fields.Province
                    Else
                        lgt_frgn.XML_DRUG_FRGN.Province = ""
                    End If

                    If IsNothing(dao_FRGN.fields.zipcode) = False Then
                        lgt_frgn.XML_DRUG_FRGN.zipcode = dao_FRGN.fields.zipcode
                    Else
                        lgt_frgn.XML_DRUG_FRGN.zipcode = ""
                    End If

                    If IsNothing(dao_FRGN.fields.tel) = False Then
                        lgt_frgn.XML_DRUG_FRGN.tel = dao_FRGN.fields.tel
                    Else
                        lgt_frgn.XML_DRUG_FRGN.tel = ""
                    End If

                    If IsNothing(dao_FRGN.fields.fax) = False Then
                        lgt_frgn.XML_DRUG_FRGN.fax = dao_FRGN.fields.fax
                    Else
                        lgt_frgn.XML_DRUG_FRGN.fax = ""
                    End If


                    If IsNothing(dao_FRGN.fields.Newcode) = False Then
                        lgt_frgn.XML_DRUG_FRGN.Newcode = dao_FRGN.fields.Newcode
                    Else
                        lgt_frgn.XML_DRUG_FRGN.Newcode = ""
                    End If

                    If IsNothing(dao_FRGN.fields.Newcode_U) = False Then
                        lgt_frgn.XML_DRUG_FRGN.Newcode_U = dao_FRGN.fields.Newcode_U
                    Else
                        lgt_frgn.XML_DRUG_FRGN.Newcode_U = ""
                    End If


                    If IsNothing(dao_FRGN.fields.lcnsid_drpdcin) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lcnsid_drpdcin = dao_FRGN.fields.lcnsid_drpdcin
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lcnsid_drpdcin = ""
                    End If


                    If IsNothing(dao_FRGN.fields.lctnmcd_drpdcin) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lctnmcd_drpdcin = dao_FRGN.fields.lctnmcd_drpdcin
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lctnmcd_drpdcin = ""
                    End If


                    If IsNothing(dao_FRGN.fields.lctcd_drpdcin) = False Then
                        lgt_frgn.XML_DRUG_FRGN.lctcd_drpdcin = dao_FRGN.fields.lctcd_drpdcin
                    Else
                        lgt_frgn.XML_DRUG_FRGN.lctcd_drpdcin = ""
                    End If
                    If IsNothing(dao_FRGN.fields.rid) = False Then
                        lgt_frgn.XML_DRUG_FRGN.rid = dao_FRGN.fields.rid
                    Else
                        lgt_frgn.XML_DRUG_FRGN.rid = ""
                    End If

                    class_xml.LGT_XML_FRGN_ALL_TO.Add(lgt_frgn)
                Next
#End Region
#Region "ชื่อยาเพื่อการส่งออก"
                '-----------------------ชื่อยาเพื่อการส่งออก
                Dim dao_export As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_EXPORT  'คือตารางผู้ผลิตต่างประเทศและในประเทศรวมกัน
                dao_export.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_export.Details.Count <> 0 Then

                    For Each dao_export.fields In dao_export.datas
                        Dim lgt_export As New LGT_XML_DRUG_EXPORT

                        If IsNothing(dao_export.fields.IDA) = False Then
                            lgt_export.XML_DRUG_EXPORT.IDA = dao_export.fields.IDA
                        Else
                            lgt_export.XML_DRUG_EXPORT.IDA = 0
                        End If


                        If IsNothing(dao_export.fields.pvncd) = False Then
                            lgt_export.XML_DRUG_EXPORT.pvncd = dao_export.fields.pvncd
                        Else
                            lgt_export.XML_DRUG_EXPORT.pvncd = ""
                        End If

                        If IsNothing(dao_export.fields.drgtpcd) = False Then
                            lgt_export.XML_DRUG_EXPORT.drgtpcd = dao_export.fields.drgtpcd
                        Else
                            lgt_export.XML_DRUG_EXPORT.drgtpcd = ""
                        End If
                        If IsNothing(dao_export.fields.rgttpcd) = False Then
                            lgt_export.XML_DRUG_EXPORT.rgttpcd = dao_export.fields.rgttpcd
                        Else
                            lgt_export.XML_DRUG_EXPORT.rgttpcd = ""
                        End If

                        If IsNothing(dao_export.fields.rgtno) = False Then
                            lgt_export.XML_DRUG_EXPORT.rgtno = dao_export.fields.rgtno
                        Else
                            lgt_export.XML_DRUG_EXPORT.rgtno = ""
                        End If
                        If IsNothing(dao_export.fields.lcnno) = False Then
                            lgt_export.XML_DRUG_EXPORT.lcnno = dao_export.fields.lcnno
                        Else
                            lgt_export.XML_DRUG_EXPORT.lcnno = ""
                        End If

                        If IsNothing(dao_export.fields.rcvno) = False Then
                            lgt_export.XML_DRUG_EXPORT.rcvno = dao_export.fields.rcvno
                        Else
                            lgt_export.XML_DRUG_EXPORT.rcvno = ""
                        End If

                        If IsNothing(dao_export.fields.rid) = False Then
                            lgt_export.XML_DRUG_EXPORT.rid = dao_export.fields.rid
                        Else
                            lgt_export.XML_DRUG_EXPORT.rid = ""
                        End If

                        If IsNothing(dao_export.fields.drgexp) = False Then
                            lgt_export.XML_DRUG_EXPORT.drgexp = dao_export.fields.drgexp
                        Else
                            lgt_export.XML_DRUG_EXPORT.drgexp = ""
                        End If

                        If IsNothing(dao_export.fields.engcntnm) = False Then
                            lgt_export.XML_DRUG_EXPORT.engcntnm = dao_export.fields.engcntnm
                        Else
                            lgt_export.XML_DRUG_EXPORT.engcntnm = ""
                        End If


                        If IsNothing(dao_export.fields.cntcd) = False Then
                            lgt_export.XML_DRUG_EXPORT.cntcd = dao_export.fields.cntcd
                        Else
                            lgt_export.XML_DRUG_EXPORT.cntcd = ""
                        End If

                        If IsNothing(dao_export.fields.Newcode) = False Then
                            lgt_export.XML_DRUG_EXPORT.Newcode = dao_export.fields.Newcode
                        Else
                            lgt_export.XML_DRUG_EXPORT.Newcode = ""
                        End If
                        class_xml.LGT_XML_DRUG_EXPORT.Add(lgt_export)
                    Next
                Else


                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_export1 As New LGT_XML_DRUG_EXPORT

                    lgt_export1.XML_DRUG_EXPORT.IDA = 0
                    lgt_export1.XML_DRUG_EXPORT.drgtpcd = ""
                    lgt_export1.XML_DRUG_EXPORT.rgttpcd = ""
                    lgt_export1.XML_DRUG_EXPORT.rgtno = ""
                    lgt_export1.XML_DRUG_EXPORT.rcvno = ""
                    lgt_export1.XML_DRUG_EXPORT.rid = ""
                    lgt_export1.XML_DRUG_EXPORT.drgexp = ""
                    lgt_export1.XML_DRUG_EXPORT.cntcd = ""
                    lgt_export1.XML_DRUG_EXPORT.Newcode = ""
                    class_xml.LGT_XML_DRUG_EXPORT.Add(lgt_export1)
                    'Next


                End If
#End Region
#Region "สียา"
                '-----------------------สียา
                Dim dao_color As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_COLOR
                dao_color.GetDataby_Newcode(dao_dr.fields.Newcode_U)

                If dao_color.Details.Count <> 0 Then

                    For Each dao_color.fields In dao_color.datas
                        Dim lgt_color As New LGT_XML_DRUG_COLOR

                        If IsNothing(dao_color.fields.IDA) = False Then
                            lgt_color.XML_DRUG_COLOR.IDA = dao_color.fields.IDA
                        Else
                            lgt_color.XML_DRUG_COLOR.IDA = 0
                        End If

                        If IsNothing(dao_color.fields.pvncd) = False Then
                            lgt_color.XML_DRUG_COLOR.pvncd = dao_color.fields.pvncd
                        Else
                            lgt_color.XML_DRUG_COLOR.pvncd = ""
                        End If


                        If IsNothing(dao_color.fields.drgtpcd) = False Then
                            lgt_color.XML_DRUG_COLOR.drgtpcd = dao_color.fields.drgtpcd
                        Else
                            lgt_color.XML_DRUG_COLOR.drgtpcd = ""
                        End If

                        If IsNothing(dao_color.fields.rgttpcd) = False Then
                            lgt_color.XML_DRUG_COLOR.rgttpcd = dao_color.fields.rgttpcd
                        Else
                            lgt_color.XML_DRUG_COLOR.rgttpcd = ""
                        End If

                        If IsNothing(dao_color.fields.rgtno) = False Then
                            lgt_color.XML_DRUG_COLOR.rgtno = dao_color.fields.rgtno
                        Else
                            lgt_color.XML_DRUG_COLOR.rgtno = ""
                        End If
                        If IsNothing(dao_color.fields.lcnno) = False Then
                            lgt_color.XML_DRUG_COLOR.lcnno = dao_color.fields.lcnno
                        Else
                            lgt_color.XML_DRUG_COLOR.lcnno = ""
                        End If

                        If IsNothing(dao_color.fields.rid) = False Then
                            lgt_color.XML_DRUG_COLOR.rid = dao_color.fields.rid
                        Else
                            lgt_color.XML_DRUG_COLOR.rid = ""
                        End If
                        If IsNothing(dao_color.fields.seqno) = False Then
                            lgt_color.XML_DRUG_COLOR.seqno = dao_color.fields.seqno
                        Else
                            lgt_color.XML_DRUG_COLOR.seqno = ""
                        End If

                        If IsNothing(dao_color.fields.drgchrtha) = False Then
                            lgt_color.XML_DRUG_COLOR.drgchrtha = dao_color.fields.drgchrtha
                        Else
                            lgt_color.XML_DRUG_COLOR.drgchrtha = ""
                        End If

                        If IsNothing(dao_color.fields.drgchreng) = False Then
                            lgt_color.XML_DRUG_COLOR.drgchreng = dao_color.fields.drgchreng
                        Else
                            lgt_color.XML_DRUG_COLOR.drgchreng = ""
                        End If

                        If IsNothing(dao_color.fields.Newcode) = False Then
                            lgt_color.XML_DRUG_COLOR.Newcode = dao_color.fields.Newcode
                        Else
                            lgt_color.XML_DRUG_COLOR.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_COLOR.Add(lgt_color)
                    Next
                Else


                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_color1 As New LGT_XML_DRUG_COLOR

                    lgt_color1.XML_DRUG_COLOR.IDA = 0
                    lgt_color1.XML_DRUG_COLOR.pvncd = ""
                    lgt_color1.XML_DRUG_COLOR.drgtpcd = ""
                    lgt_color1.XML_DRUG_COLOR.rgttpcd = ""
                    lgt_color1.XML_DRUG_COLOR.rgtno = ""
                    lgt_color1.XML_DRUG_COLOR.seqno = ""
                    lgt_color1.XML_DRUG_COLOR.drgchrtha = ""
                    lgt_color1.XML_DRUG_COLOR.drgchreng = ""
                    lgt_color1.XML_DRUG_COLOR.Newcode = ""
                    lgt_color1.XML_DRUG_COLOR.rid = ""

                    class_xml.LGT_XML_DRUG_COLOR.Add(lgt_color1)
                    'Next


                End If
#End Region
#Region "ผู้แทนจำหน่าย"
                '------------------------ผู้แทนจำหน่าย
                Dim dao_agent As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_AGENT
                dao_agent.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_agent.Details.Count <> 0 Then

                    For Each dao_agent.fields In dao_agent.datas
                        Dim lgt_agent As New LGT_XML_DRUG_AGENT

                        If IsNothing(dao_agent.fields.IDA) = False Then
                            lgt_agent.XML_DRUG_AGENT.IDA = dao_agent.fields.IDA
                        Else
                            lgt_agent.XML_DRUG_AGENT.IDA = 0
                        End If

                        If IsNothing(dao_agent.fields.drgtpcd) = False Then
                            lgt_agent.XML_DRUG_AGENT.drgtpcd = dao_agent.fields.drgtpcd
                        Else
                            lgt_agent.XML_DRUG_AGENT.drgtpcd = ""
                        End If

                        If IsNothing(dao_agent.fields.rgttpcd) = False Then
                            lgt_agent.XML_DRUG_AGENT.rgttpcd = dao_agent.fields.rgttpcd
                        Else
                            lgt_agent.XML_DRUG_AGENT.rgttpcd = ""
                        End If

                        If IsNothing(dao_agent.fields.rgtno) = False Then
                            lgt_agent.XML_DRUG_AGENT.rgtno = dao_agent.fields.rgtno
                        Else
                            lgt_agent.XML_DRUG_AGENT.rgtno = ""
                        End If

                        If IsNothing(dao_agent.fields.rcvno) = False Then
                            lgt_agent.XML_DRUG_AGENT.rcvno = dao_agent.fields.rcvno
                        Else
                            lgt_agent.XML_DRUG_AGENT.rcvno = ""
                        End If

                        If IsNothing(dao_agent.fields.lcnno) = False Then
                            lgt_agent.XML_DRUG_AGENT.lcnno = dao_agent.fields.lcnno
                        Else
                            lgt_agent.XML_DRUG_AGENT.lcnno = ""
                        End If

                        If IsNothing(dao_agent.fields.lcnno_no) = False Then
                            lgt_agent.XML_DRUG_AGENT.lcnno_no = dao_agent.fields.lcnno_no
                        Else
                            lgt_agent.XML_DRUG_AGENT.lcnno_no = ""
                        End If

                        If IsNothing(dao_agent.fields.identify) = False Then
                            lgt_agent.XML_DRUG_AGENT.identify = dao_agent.fields.identify
                        Else
                            lgt_agent.XML_DRUG_AGENT.identify = ""
                        End If
                        If IsNothing(dao_agent.fields.rid) = False Then
                            lgt_agent.XML_DRUG_AGENT.rid = dao_agent.fields.rid
                        Else
                            lgt_agent.XML_DRUG_AGENT.rid = ""
                        End If

                        If IsNothing(dao_agent.fields.agent) = False Then
                            lgt_agent.XML_DRUG_AGENT.agent = dao_agent.fields.agent
                        Else
                            lgt_agent.XML_DRUG_AGENT.agent = ""
                        End If

                        If IsNothing(dao_agent.fields.addr) = False Then
                            lgt_agent.XML_DRUG_AGENT.addr = dao_agent.fields.addr
                        Else
                            lgt_agent.XML_DRUG_AGENT.addr = ""
                        End If

                        If IsNothing(dao_agent.fields.tel) = False Then
                            lgt_agent.XML_DRUG_AGENT.tel = dao_agent.fields.tel
                        Else
                            lgt_agent.XML_DRUG_AGENT.tel = ""
                        End If

                        If IsNothing(dao_agent.fields.province) = False Then
                            lgt_agent.XML_DRUG_AGENT.province = dao_agent.fields.province
                        Else
                            lgt_agent.XML_DRUG_AGENT.province = ""
                        End If

                        If IsNothing(dao_agent.fields.Newcode) = False Then
                            lgt_agent.XML_DRUG_AGENT.Newcode = dao_agent.fields.Newcode
                        Else
                            lgt_agent.XML_DRUG_AGENT.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_AGENT.Add(lgt_agent)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_agent1 As New LGT_XML_DRUG_AGENT

                    lgt_agent1.XML_DRUG_AGENT.IDA = 0
                    lgt_agent1.XML_DRUG_AGENT.pvncd = ""
                    lgt_agent1.XML_DRUG_AGENT.drgtpcd = ""
                    lgt_agent1.XML_DRUG_AGENT.rgttpcd = ""
                    lgt_agent1.XML_DRUG_AGENT.rgtno = ""
                    lgt_agent1.XML_DRUG_AGENT.rcvno = ""
                    lgt_agent1.XML_DRUG_AGENT.lcnno = ""
                    lgt_agent1.XML_DRUG_AGENT.lcnno_no = ""
                    lgt_agent1.XML_DRUG_AGENT.identify = ""
                    lgt_agent1.XML_DRUG_AGENT.rid = ""
                    lgt_agent1.XML_DRUG_AGENT.agent = ""
                    lgt_agent1.XML_DRUG_AGENT.addr = ""
                    lgt_agent1.XML_DRUG_AGENT.tel = ""
                    lgt_agent1.XML_DRUG_AGENT.province = ""
                    lgt_agent1.XML_DRUG_AGENT.Newcode = ""


                    class_xml.LGT_XML_DRUG_AGENT.Add(lgt_agent1)
                    'Next
                End If
#End Region
#Region "แก้ไขประวัติ"
                '---------------------------แก้ไขประวัติ
                Dim dao_his As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_STORY_EDIT_HISTORY
                dao_his.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_his.Details.Count <> 0 Then

                    For Each dao_his.fields In dao_his.datas
                        Dim lgt_his As New LGT_XML_DRUG_STORY_EDIT_HISTORY

                        If IsNothing(dao_his.fields.IDA) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.IDA = dao_his.fields.IDA
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.IDA = 0
                        End If

                        If IsNothing(dao_his.fields.pvncd) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.pvncd = dao_his.fields.pvncd
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.pvncd = ""
                        End If

                        If IsNothing(dao_his.fields.drgtpcd) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.drgtpcd = dao_his.fields.drgtpcd
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.drgtpcd = ""
                        End If

                        If IsNothing(dao_his.fields.rgttpcd) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgttpcd = dao_his.fields.rgttpcd
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgttpcd = ""
                        End If

                        If IsNothing(dao_his.fields.rgtno) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgtno = dao_his.fields.rgtno
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rgtno = dao_his.fields.rgtno
                        End If

                        If IsNothing(dao_his.fields.lcnno) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.lcnno = dao_his.fields.lcnno
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.lcnno = dao_his.fields.lcnno
                        End If
                        If IsNothing(dao_his.fields.rcvno) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rcvno = dao_his.fields.rcvno
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rcvno = ""
                        End If


                        If IsNothing(dao_his.fields.rid) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rid = dao_his.fields.rid
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.rid = ""
                        End If

                        If IsNothing(dao_his.fields.story_edit_Title) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_Title = dao_his.fields.story_edit_Title
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_Title = ""
                        End If

                        If IsNothing(dao_his.fields.story_edit_date) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_date = dao_his.fields.story_edit_date
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_date = Date.Now
                        End If

                        If IsNothing(dao_his.fields.story_edit_appdate) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_appdate = dao_his.fields.story_edit_appdate
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_appdate = Date.Now
                        End If

                        If IsNothing(dao_his.fields.story_edit_status) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_status = dao_his.fields.story_edit_status
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_status = ""
                        End If

                        If IsNothing(dao_his.fields.story_edit_desc) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_desc = dao_his.fields.story_edit_desc
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.story_edit_desc = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd1) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd1 = dao_his.fields.edtcd1
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd1 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd2) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd2 = dao_his.fields.edtcd2
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd2 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd3) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd3 = dao_his.fields.edtcd3
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd3 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd4) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd4 = dao_his.fields.edtcd4
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd4 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd5) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd5 = dao_his.fields.edtcd5
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd5 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd6) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd6 = dao_his.fields.edtcd6
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd6 = ""
                        End If
                        If IsNothing(dao_his.fields.edtcd7) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd7 = dao_his.fields.edtcd7
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd7 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd8) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd8 = dao_his.fields.edtcd8
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd8 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd9) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd9 = dao_his.fields.edtcd9
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd9 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd10) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd10 = dao_his.fields.edtcd10
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd10 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd11) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd11 = dao_his.fields.edtcd11
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd11 = ""
                        End If


                        If IsNothing(dao_his.fields.edtcd12) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd12 = dao_his.fields.edtcd12
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd12 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd13) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd13 = dao_his.fields.edtcd13
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd13 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd14) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = dao_his.fields.edtcd14
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd15) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd15 = dao_his.fields.edtcd15
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd15 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd16) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd16 = dao_his.fields.edtcd16
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd16 = ""
                        End If

                        If IsNothing(dao_his.fields.edtcd17) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd17 = dao_his.fields.edtcd17
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.edtcd17 = ""
                        End If

                        If IsNothing(dao_his.fields.csnm) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.csnm = dao_his.fields.csnm
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.csnm = ""
                        End If
                        If IsNothing(dao_his.fields.dtl) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.dtl = dao_his.fields.dtl
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.dtl = ""
                        End If

                        If IsNothing(dao_his.fields.Newcode) = False Then
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.Newcode = dao_his.fields.Newcode
                        Else
                            lgt_his.XML_DRUG_STORY_EDIT_HISTORY.Newcode = ""
                        End If

                        class_xml.LGT_XML_DRUG_STORY_EDIT_HISTORY.Add(lgt_his)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_hit1 As New LGT_XML_DRUG_STORY_EDIT_HISTORY

                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.IDA = 0
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.pvncd = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.drgtpcd = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rgttpcd = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rgtno = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rcvno = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.rid = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_Title = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_date = Date.Now
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_appdate = Date.Now
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.story_edit_status = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd1 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd2 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd3 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd4 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd5 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd6 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd7 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd8 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd9 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd10 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd11 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd12 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd13 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd15 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd16 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd17 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.csnm = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.edtcd14 = ""
                    lgt_hit1.XML_DRUG_STORY_EDIT_HISTORY.dtl = ""

                    class_xml.LGT_XML_DRUG_STORY_EDIT_HISTORY.Add(lgt_hit1)
                    'Next
                End If
#End Region
#Region "เงื่อนไขการขึ้นทะเบียน"
                '----------------------------เงื่อนไขการขึ้นทะเบียน

                Dim dao_con_tatean As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CONDITION_TABEAN
                dao_con_tatean.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_con_tatean.Details.Count <> 0 Then

                    For Each dao_con_tatean.fields In dao_con_tatean.datas
                        Dim lgt_con_tatean As New LGT_XML_DRUG_CONDITION_TABEAN

                        If IsNothing(dao_con_tatean.fields.IDA) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.IDA = dao_con_tatean.fields.IDA
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.IDA = 0
                        End If

                        If IsNothing(dao_con_tatean.fields.drgtpcd) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.drgtpcd = dao_con_tatean.fields.drgtpcd
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.drgtpcd = ""
                        End If

                        If IsNothing(dao_con_tatean.fields.rgttpcd) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgttpcd = dao_con_tatean.fields.rgttpcd
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgttpcd = ""
                        End If

                        If IsNothing(dao_con_tatean.fields.rgtno) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgtno = dao_con_tatean.fields.rgtno
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rgtno = ""
                        End If
                        If IsNothing(dao_con_tatean.fields.rid) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rid = dao_con_tatean.fields.rid
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.rid = ""
                        End If
                        If IsNothing(dao_con_tatean.fields.CONDITION_PUBLIC) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_PUBLIC = dao_con_tatean.fields.CONDITION_PUBLIC
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_PUBLIC = ""
                        End If

                        If IsNothing(dao_con_tatean.fields.CONDITION_SERVANT) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_SERVANT = dao_con_tatean.fields.CONDITION_SERVANT
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.CONDITION_SERVANT = ""
                        End If

                        If IsNothing(dao_con_tatean.fields.Newcode) = False Then
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.Newcode = dao_con_tatean.fields.Newcode
                        Else
                            lgt_con_tatean.XML_DRUG_CONDITION_TABEAN.Newcode = ""
                        End If

                        class_xml.LGT_XML_DRUG_CONDITION_TABEAN.Add(lgt_con_tatean)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_con_tatean1 As New LGT_XML_DRUG_CONDITION_TABEAN

                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.IDA = 0
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.pvncd = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.drgtpcd = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.rgttpcd = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.rgtno = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.rid = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.CONDITION_PUBLIC = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.CONDITION_SERVANT = ""
                    lgt_con_tatean1.XML_DRUG_CONDITION_TABEAN.Newcode = ""

                    class_xml.LGT_XML_DRUG_CONDITION_TABEAN.Add(lgt_con_tatean1)
                    'Next
                End If
#End Region
#Region "เอกสาร pdf"
                '-----------------------------เอกสาร pdf
                Dim dao_doc_pdf As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_DOC_PDF
                dao_doc_pdf.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_doc_pdf.Details.Count <> 0 Then

                    For Each dao_doc_pdf.fields In dao_doc_pdf.datas
                        Dim lgt_doc_pdf As New LGT_XML_DRUG_DOC_PDF

                        If IsNothing(dao_doc_pdf.fields.IDA) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.IDA = dao_doc_pdf.fields.IDA
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.IDA = ""
                        End If
                        If IsNothing(dao_doc_pdf.fields.pvncd) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.pvncd = dao_doc_pdf.fields.pvncd
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.pvncd = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.drgtpcd) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.drgtpcd = dao_doc_pdf.fields.drgtpcd
                        Else

                            lgt_doc_pdf.XML_DRUG_DOC_PDF.drgtpcd = ""
                        End If
                        If IsNothing(dao_doc_pdf.fields.rgttpcd) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgttpcd = dao_doc_pdf.fields.rgttpcd
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgttpcd = ""
                        End If
                        If IsNothing(dao_doc_pdf.fields.rgtno) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgtno = dao_doc_pdf.fields.rgtno
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.rgtno = ""
                        End If
                        If IsNothing(dao_doc_pdf.fields.rid) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.rid = dao_doc_pdf.fields.rid
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.rid = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.PDF_DR_Reg) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_DR_Reg = dao_doc_pdf.fields.PDF_DR_Reg
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_DR_Reg = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.PDF_MA_Application) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_MA_Application = dao_doc_pdf.fields.PDF_MA_Application
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_MA_Application = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.PDF_Production_Process) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Production_Process = dao_doc_pdf.fields.PDF_Production_Process
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Production_Process = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.PDF_Product_information) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Product_information = dao_doc_pdf.fields.PDF_Product_information
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Product_information = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.PDF_Label) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Label = dao_doc_pdf.fields.PDF_Label
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Label = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.PDF_Amendment) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Amendment = dao_doc_pdf.fields.PDF_Amendment
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Amendment = ""
                        End If
                        If IsNothing(dao_doc_pdf.fields.PDF_Carnofile) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Carnofile = dao_doc_pdf.fields.PDF_Carnofile
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Carnofile = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.PDF_Drug_Imange) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Drug_Imange = dao_doc_pdf.fields.PDF_Drug_Imange
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.PDF_Drug_Imange = ""
                        End If

                        If IsNothing(dao_doc_pdf.fields.Newcode) = False Then
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.Newcode = dao_doc_pdf.fields.Newcode
                        Else
                            lgt_doc_pdf.XML_DRUG_DOC_PDF.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_DOC_PDF.Add(lgt_doc_pdf)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_doc_pdf1 As New LGT_XML_DRUG_DOC_PDF


                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.IDA = 0
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.pvncd = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.drgtpcd = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.rgttpcd = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.rgtno = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.rid = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_DR_Reg = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_MA_Application = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Production_Process = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Product_information = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Label = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Amendment = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Carnofile = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.PDF_Drug_Imange = ""
                    lgt_doc_pdf1.XML_DRUG_DOC_PDF.Newcode = ""
                    class_xml.LGT_XML_DRUG_DOC_PDF.Add(lgt_doc_pdf1)
                    'Next
                End If
#End Region
#Region "SPC"
                '-----------------------------SPC
                Dim dao_spc As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_SPC
                dao_spc.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_spc.Details.Count <> 0 Then

                    For Each dao_spc.fields In dao_spc.datas
                        Dim lgt_spc As New LGT_XML_DRUG_SPC

                        If IsNothing(dao_spc.fields.IDA) = False Then
                            lgt_spc.XML_DRUG_SPC.IDA = dao_spc.fields.IDA
                        Else
                            lgt_spc.XML_DRUG_SPC.IDA = 0
                        End If
                        If IsNothing(dao_spc.fields.pvncd) = False Then
                            lgt_spc.XML_DRUG_SPC.pvncd = dao_spc.fields.pvncd
                        Else
                            lgt_spc.XML_DRUG_SPC.pvncd = ""
                        End If
                        If IsNothing(dao_spc.fields.drgtpcd) = False Then
                            lgt_spc.XML_DRUG_SPC.drgtpcd = dao_spc.fields.drgtpcd
                        Else
                            lgt_spc.XML_DRUG_SPC.drgtpcd = ""
                        End If
                        If IsNothing(dao_spc.fields.rgttpcd) = False Then
                            lgt_spc.XML_DRUG_SPC.rgttpcd = dao_spc.fields.rgttpcd
                        Else
                            lgt_spc.XML_DRUG_SPC.rgttpcd = ""
                        End If

                        If IsNothing(dao_spc.fields.rgtno) = False Then
                            lgt_spc.XML_DRUG_SPC.rgtno = dao_spc.fields.rgtno
                        Else
                            lgt_spc.XML_DRUG_SPC.rgtno = ""
                        End If

                        If IsNothing(dao_spc.fields.rid) = False Then
                            lgt_spc.XML_DRUG_SPC.rid = dao_spc.fields.rid
                        Else
                            lgt_spc.XML_DRUG_SPC.rid = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Name_Medicinal_Product) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = dao_spc.fields.SPC_Th_Name_Medicinal_Product
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Name_Medicinal_Product) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = dao_spc.fields.SPC_Th_Name_Medicinal_Product
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Qualitative_Quantitative_Comp) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Qualitative_Quantitative_Comp = dao_spc.fields.SPC_Th_Qualitative_Quantitative_Comp
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Qualitative_Quantitative_Comp = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Pharm_Form) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharm_Form = dao_spc.fields.SPC_Th_Pharm_Form
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharm_Form = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Clinical_Particular) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Clinical_Particular = dao_spc.fields.SPC_Th_Clinical_Particular
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Clinical_Particular = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Therapeutic_Indication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Therapeutic_Indication = dao_spc.fields.SPC_Th_Therapeutic_Indication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Therapeutic_Indication = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Th_Posology_Administration) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Posology_Administration = dao_spc.fields.SPC_Th_Posology_Administration
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Posology_Administration = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Contraindication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Contraindication = dao_spc.fields.SPC_Th_Contraindication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Contraindication = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Special_Warning) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Warning = dao_spc.fields.SPC_Th_Special_Warning
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Warning = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Interaction) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Interaction = dao_spc.fields.SPC_Th_Interaction
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Interaction = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Pregnancy_Lactation) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pregnancy_Lactation = dao_spc.fields.SPC_Th_Pregnancy_Lactation
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pregnancy_Lactation = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Ability_Drive_Machine) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Ability_Drive_Machine = dao_spc.fields.SPC_Th_Ability_Drive_Machine
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Ability_Drive_Machine = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Undesirable_Effect) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Undesirable_Effect = dao_spc.fields.SPC_Th_Undesirable_Effect
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Undesirable_Effect = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Overdose) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Overdose = dao_spc.fields.SPC_Th_Overdose
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Overdose = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Pharmaco_Properties) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaco_Properties = dao_spc.fields.SPC_Th_Pharmaco_Properties
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaco_Properties = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Th_Pharmdynamic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmdynamic = dao_spc.fields.SPC_Th_Pharmdynamic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmdynamic = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Pharmacokinetic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmacokinetic = dao_spc.fields.SPC_Th_Pharmacokinetic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmacokinetic = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Preclinical_Safety_Data) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Preclinical_Safety_Data = dao_spc.fields.SPC_Th_Preclinical_Safety_Data
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Preclinical_Safety_Data = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Pharmaceutical_Particulars) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaceutical_Particulars = dao_spc.fields.SPC_Th_Pharmaceutical_Particulars
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Pharmaceutical_Particulars = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Excipients) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Excipients = dao_spc.fields.SPC_Th_Excipients
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Excipients = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Incompatability) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Incompatability = dao_spc.fields.SPC_Th_Incompatability
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Incompatability = ""
                        End If
                        If IsNothing(dao_spc.fields.SPC_Th_Shelf_Life) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Shelf_Life = dao_spc.fields.SPC_Th_Shelf_Life
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Shelf_Life = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Special_Storage) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Storage = dao_spc.fields.SPC_Th_Special_Storage
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Special_Storage = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Container) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Container = dao_spc.fields.SPC_Th_Container
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Container = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_MA_Holder) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Holder = dao_spc.fields.SPC_Th_MA_Holder
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Holder = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_MA_Number) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Number = dao_spc.fields.SPC_Th_MA_Number
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_MA_Number = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Th_Date_Approve) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Approve = dao_spc.fields.SPC_Th_Date_Approve
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Approve = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Th_Date_Revision) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Revision = dao_spc.fields.SPC_Th_Date_Revision
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Th_Date_Revision = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Name_Medicinal_Product) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Name_Medicinal_Product = dao_spc.fields.SPC_Eng_Name_Medicinal_Product
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Qualitative_Quantitative_Comp) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Qualitative_Quantitative_Comp = dao_spc.fields.SPC_Eng_Qualitative_Quantitative_Comp
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Qualitative_Quantitative_Comp = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Pharm_Form) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharm_Form = dao_spc.fields.SPC_Eng_Pharm_Form
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharm_Form = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Clinical_Particular) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Clinical_Particular = dao_spc.fields.SPC_Eng_Clinical_Particular
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Clinical_Particular = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Therapeutic_Indication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Therapeutic_Indication = dao_spc.fields.SPC_Eng_Therapeutic_Indication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Therapeutic_Indication = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Posology_Administration) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Posology_Administration = dao_spc.fields.SPC_Eng_Posology_Administration
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Posology_Administration = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Contraindication) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Contraindication = dao_spc.fields.SPC_Eng_Contraindication
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Contraindication = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Special_Warning) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Warning = dao_spc.fields.SPC_Eng_Special_Warning
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Warning = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Interaction) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = dao_spc.fields.SPC_Eng_Interaction
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = ""
                        End If
                        If IsNothing(dao_spc.fields.SPC_Eng_Interaction) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = dao_spc.fields.SPC_Eng_Interaction
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Interaction = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Pregnancy_Lactation) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pregnancy_Lactation = dao_spc.fields.SPC_Eng_Pregnancy_Lactation
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pregnancy_Lactation = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Ability_Drive_Machine) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Ability_Drive_Machine = dao_spc.fields.SPC_Eng_Ability_Drive_Machine
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Ability_Drive_Machine = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Undesirable_Effect) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Undesirable_Effect = dao_spc.fields.SPC_Eng_Undesirable_Effect
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Undesirable_Effect = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Overdose) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Overdose = dao_spc.fields.SPC_Eng_Overdose
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Overdose = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmaco_Properties) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaco_Properties = dao_spc.fields.SPC_Eng_Pharmaco_Properties
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaco_Properties = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmdynamic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmdynamic = dao_spc.fields.SPC_Eng_Pharmdynamic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmdynamic = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmacokinetic) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmacokinetic = dao_spc.fields.SPC_Eng_Pharmacokinetic
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmacokinetic = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Preclinical_Safety_Data) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Preclinical_Safety_Data = dao_spc.fields.SPC_Eng_Preclinical_Safety_Data
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Preclinical_Safety_Data = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Pharmaceutical_Particulars) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaceutical_Particulars = dao_spc.fields.SPC_Eng_Pharmaceutical_Particulars
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Pharmaceutical_Particulars = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Excipients) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Excipients = dao_spc.fields.SPC_Eng_Excipients
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Excipients = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Incompatability) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Incompatability = dao_spc.fields.SPC_Eng_Incompatability
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Incompatability = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Shelf_Life) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Shelf_Life = dao_spc.fields.SPC_Eng_Shelf_Life
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Shelf_Life = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_Special_Storage) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Storage = dao_spc.fields.SPC_Eng_Special_Storage
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Special_Storage = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Container) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Container = dao_spc.fields.SPC_Eng_Container
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Container = ""
                        End If

                        If IsNothing(dao_spc.fields.SPC_Eng_MA_Holder) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Holder = dao_spc.fields.SPC_Eng_MA_Holder
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Holder = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Eng_MA_Number) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Number = dao_spc.fields.SPC_Eng_MA_Number
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_MA_Number = ""
                        End If


                        If IsNothing(dao_spc.fields.SPC_Eng_Date_Approve) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Approve = dao_spc.fields.SPC_Eng_Date_Approve
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Approve = ""
                        End If



                        If IsNothing(dao_spc.fields.SPC_Eng_Date_Revision) = False Then
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Revision = dao_spc.fields.SPC_Eng_Date_Revision
                        Else
                            lgt_spc.XML_DRUG_SPC.SPC_Eng_Date_Revision = ""
                        End If


                        If IsNothing(dao_spc.fields.Newcode) = False Then
                            lgt_spc.XML_DRUG_SPC.Newcode = dao_spc.fields.Newcode
                        Else
                            lgt_spc.XML_DRUG_SPC.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_SPC.Add(lgt_spc)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_spc1 As New LGT_XML_DRUG_SPC


                    lgt_spc1.XML_DRUG_SPC.IDA = 0
                    lgt_spc1.XML_DRUG_SPC.pvncd = ""
                    lgt_spc1.XML_DRUG_SPC.drgtpcd = ""
                    lgt_spc1.XML_DRUG_SPC.rgttpcd = ""
                    lgt_spc1.XML_DRUG_SPC.rgtno = ""
                    lgt_spc1.XML_DRUG_SPC.rid = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Name_Medicinal_Product = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Qualitative_Quantitative_Comp = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharm_Form = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Clinical_Particular = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Therapeutic_Indication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Posology_Administration = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Contraindication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Special_Warning = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Interaction = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pregnancy_Lactation = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Ability_Drive_Machine = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Undesirable_Effect = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Overdose = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmaco_Properties = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmdynamic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmacokinetic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Preclinical_Safety_Data = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Pharmaceutical_Particulars = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Excipients = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Incompatability = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Shelf_Life = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Special_Storage = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Container = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_MA_Holder = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_MA_Number = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Date_Approve = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Th_Date_Revision = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Name_Medicinal_Product = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Qualitative_Quantitative_Comp = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharm_Form = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Clinical_Particular = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Therapeutic_Indication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Posology_Administration = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Contraindication = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Special_Warning = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Interaction = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pregnancy_Lactation = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Ability_Drive_Machine = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Undesirable_Effect = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Overdose = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmaco_Properties = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmdynamic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmacokinetic = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Preclinical_Safety_Data = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Pharmaceutical_Particulars = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Excipients = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Incompatability = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Shelf_Life = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Special_Storage = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Container = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_MA_Holder = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_MA_Number = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Date_Approve = ""
                    lgt_spc1.XML_DRUG_SPC.SPC_Eng_Date_Revision = ""
                    lgt_spc1.XML_DRUG_SPC.Newcode = ""


                    class_xml.LGT_XML_DRUG_SPC.Add(lgt_spc1)
                    'Next
                End If
#End Region
#Region "PI"
                '-----------------------------PI
                Dim dao_pi As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_PI
                dao_pi.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_pi.Details.Count <> 0 Then

                    For Each dao_pi.fields In dao_pi.datas
                        Dim lgt_pi As New LGT_XML_DRUG_DOC_PI

                        If IsNothing(dao_pi.fields.IDA) = False Then
                            lgt_pi.XML_DRUG_PI.IDA = dao_spc.fields.IDA
                        Else
                            lgt_pi.XML_DRUG_PI.IDA = 0
                        End If
                        If IsNothing(dao_pi.fields.pvncd) = False Then
                            lgt_pi.XML_DRUG_PI.pvncd = dao_pi.fields.pvncd
                        Else
                            lgt_pi.XML_DRUG_PI.pvncd = ""
                        End If
                        If IsNothing(dao_pi.fields.drgtpcd) = False Then
                            lgt_pi.XML_DRUG_PI.drgtpcd = dao_pi.fields.drgtpcd
                        Else
                            lgt_pi.XML_DRUG_PI.drgtpcd = ""
                        End If
                        If IsNothing(dao_pi.fields.rgttpcd) = False Then
                            lgt_pi.XML_DRUG_PI.rgttpcd = dao_pi.fields.rgttpcd
                        Else
                            lgt_pi.XML_DRUG_PI.rgttpcd = ""
                        End If
                        If IsNothing(dao_pi.fields.rgtno) = False Then
                            lgt_pi.XML_DRUG_PI.rgtno = dao_pi.fields.rgtno
                        Else
                            lgt_pi.XML_DRUG_PI.rgtno = ""
                        End If
                        If IsNothing(dao_pi.fields.rid) = False Then
                            lgt_pi.XML_DRUG_PI.rid = dao_pi.fields.rid
                        Else
                            lgt_pi.XML_DRUG_PI.rid = ""
                        End If
                        If IsNothing(dao_pi.fields.PI_Th_Name_Medicinal_Product) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Name_Medicinal_Product = dao_pi.fields.PI_Th_Name_Medicinal_Product
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Name_Medicinal_Product = ""
                        End If


                        If IsNothing(dao_pi.fields.PI_Th_Active_Ingradient_Strenght) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Active_Ingradient_Strenght = dao_pi.fields.PI_Th_Active_Ingradient_Strenght
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Product_Desc) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Product_Desc = dao_pi.fields.PI_Th_Product_Desc
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Product_Desc = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Administration) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Administration = dao_pi.fields.PI_Th_Administration
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Administration = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Contraindication) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Contraindication = dao_pi.fields.PI_Th_Contraindication
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Contraindication = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Warning_Precaution) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Warning_Precaution = dao_pi.fields.PI_Th_Warning_Precaution
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Warning_Precaution = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Interaction) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Interaction = dao_pi.fields.PI_Th_Interaction
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Interaction = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Pregnancy_Lactation) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Pregnancy_Lactation = dao_pi.fields.PI_Th_Pregnancy_Lactation
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Pregnancy_Lactation = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Undesirable_Effect) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Undesirable_Effect = dao_pi.fields.PI_Th_Undesirable_Effect
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Undesirable_Effect = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Overdose) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Overdose = dao_pi.fields.PI_Th_Overdose
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Overdose = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Storage_Condition) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Storage_Condition = dao_pi.fields.PI_Th_Storage_Condition
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Storage_Condition = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Dose_From_Packaging) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Dose_From_Packaging = dao_pi.fields.PI_Th_Dose_From_Packaging
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Dose_From_Packaging = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_MA_Holder) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Holder = dao_pi.fields.PI_Th_MA_Holder
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Holder = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_MA_Number) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Number = dao_pi.fields.PI_Th_MA_Number
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_MA_Number = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Date_Approve) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Approve = dao_pi.fields.PI_Th_Date_Approve
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Approve = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Th_Date_Revision) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Revision = dao_pi.fields.PI_Th_Date_Revision
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Th_Date_Revision = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Name_Medicinal_Product) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Name_Medicinal_Product = dao_pi.fields.PI_Eng_Name_Medicinal_Product
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Active_Ingradient_Strenght) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Active_Ingradient_Strenght = dao_pi.fields.PI_Eng_Active_Ingradient_Strenght
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Product_Desc) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Product_Desc = dao_pi.fields.PI_Eng_Product_Desc
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Product_Desc = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pharmacody_Pharmacoki) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacody_Pharmacoki = dao_pi.fields.PI_Eng_Pharmacody_Pharmacoki
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacody_Pharmacoki = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pharmdynamic) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmdynamic = dao_pi.fields.PI_Eng_Pharmdynamic
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmdynamic = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pharmacokinetic) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacokinetic = dao_pi.fields.PI_Eng_Pharmacokinetic
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pharmacokinetic = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Indication) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Indication = dao_pi.fields.PI_Eng_Indication
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Indication = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Recommend_Dose) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Recommend_Dose = dao_pi.fields.PI_Eng_Recommend_Dose
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Recommend_Dose = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Administration) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Administration = dao_pi.fields.PI_Eng_Administration
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Administration = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Contraindication) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Contraindication = dao_pi.fields.PI_Eng_Contraindication
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Contraindication = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Warning_Precaution) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Warning_Precaution = dao_pi.fields.PI_Eng_Warning_Precaution
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Warning_Precaution = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Interaction) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Interaction = dao_pi.fields.PI_Eng_Interaction
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Interaction = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Pregnancy_Lactation) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pregnancy_Lactation = dao_pi.fields.PI_Eng_Pregnancy_Lactation
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Pregnancy_Lactation = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Undesirable_Effect) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Undesirable_Effect = dao_pi.fields.PI_Eng_Undesirable_Effect
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Undesirable_Effect = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Overdose) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Overdose = dao_pi.fields.PI_Eng_Overdose
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Overdose = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Storage_Condition) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = dao_pi.fields.PI_Eng_Storage_Condition
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Storage_Condition) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = dao_pi.fields.PI_Eng_Storage_Condition
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Storage_Condition = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Dose_From_Packaging) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Dose_From_Packaging = dao_pi.fields.PI_Eng_Dose_From_Packaging
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Dose_From_Packaging = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_MA_Holder) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Holder = dao_pi.fields.PI_Eng_MA_Holder
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Holder = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_MA_Number) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Number = dao_pi.fields.PI_Eng_MA_Number
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_MA_Number = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Date_Approve) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Approve = dao_pi.fields.PI_Eng_Date_Approve
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Approve = ""
                        End If

                        If IsNothing(dao_pi.fields.PI_Eng_Date_Revision) = False Then
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Revision = dao_pi.fields.PI_Eng_Date_Revision
                        Else
                            lgt_pi.XML_DRUG_PI.PI_Eng_Date_Revision = ""
                        End If

                        If IsNothing(dao_pi.fields.Newcode) = False Then
                            lgt_pi.XML_DRUG_PI.Newcode = dao_pi.fields.Newcode
                        Else
                            lgt_pi.XML_DRUG_PI.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_DOC_PI.Add(lgt_pi)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_pi1 As New LGT_XML_DRUG_DOC_PI
                    lgt_pi1.XML_DRUG_PI.IDA = 0
                    lgt_pi1.XML_DRUG_PI.pvncd = ""
                    lgt_pi1.XML_DRUG_PI.drgtpcd = ""
                    lgt_pi1.XML_DRUG_PI.rgttpcd = ""
                    lgt_pi1.XML_DRUG_PI.rgtno = ""
                    lgt_pi1.XML_DRUG_PI.rid = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Name_Medicinal_Product = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Active_Ingradient_Strenght = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Product_Desc = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pharmacody_Pharmacoki = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pharmdynamic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pharmacokinetic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Indication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Recommend_Dose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Administration = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Contraindication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Warning_Precaution = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Interaction = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Pregnancy_Lactation = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Undesirable_Effect = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Overdose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Storage_Condition = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Dose_From_Packaging = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_MA_Holder = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_MA_Number = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Date_Approve = ""
                    lgt_pi1.XML_DRUG_PI.PI_Th_Date_Revision = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Name_Medicinal_Product = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Active_Ingradient_Strenght = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Product_Desc = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pharmacody_Pharmacoki = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pharmdynamic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pharmacokinetic = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Indication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Recommend_Dose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Administration = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Contraindication = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Warning_Precaution = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Interaction = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Pregnancy_Lactation = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Undesirable_Effect = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Overdose = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Storage_Condition = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Dose_From_Packaging = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_MA_Holder = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_MA_Number = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Date_Approve = ""
                    lgt_pi1.XML_DRUG_PI.PI_Eng_Date_Revision = ""
                    lgt_pi1.XML_DRUG_PI.Newcode = ""
                    class_xml.LGT_XML_DRUG_DOC_PI.Add(lgt_pi1)
                    'Next
                End If
#End Region
#Region "PIL"
                '-----------------------------PIL
                Dim dao_pil As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_PIL
                dao_pil.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_pil.Details.Count <> 0 Then

                    For Each dao_pil.fields In dao_pil.datas
                        Dim lgt_pil As New LGT_XML_DRUG_DOC_PIL

                        If IsNothing(dao_pil.fields.IDA) = False Then
                            lgt_pil.XML_DRUG_PIL.IDA = dao_pil.fields.IDA
                        Else
                            lgt_pil.XML_DRUG_PIL.IDA = 0
                        End If
                        If IsNothing(dao_pil.fields.pvncd) = False Then
                            lgt_pil.XML_DRUG_PIL.pvncd = dao_pil.fields.pvncd
                        Else
                            lgt_pil.XML_DRUG_PIL.pvncd = ""
                        End If

                        If IsNothing(dao_pil.fields.drgtpcd) = False Then
                            lgt_pil.XML_DRUG_PIL.drgtpcd = dao_pil.fields.drgtpcd
                        Else
                            lgt_pil.XML_DRUG_PIL.drgtpcd = ""
                        End If

                        If IsNothing(dao_pil.fields.rgttpcd) = False Then
                            lgt_pil.XML_DRUG_PIL.rgttpcd = dao_pil.fields.rgttpcd
                        Else
                            lgt_pil.XML_DRUG_PIL.rgttpcd = ""
                        End If

                        If IsNothing(dao_pil.fields.rgtno) = False Then
                            lgt_pil.XML_DRUG_PIL.rgtno = dao_pil.fields.rgtno
                        Else
                            lgt_pil.XML_DRUG_PIL.rgtno = ""
                        End If
                        If IsNothing(dao_pil.fields.rid) = False Then
                            lgt_pil.XML_DRUG_PIL.rid = dao_pil.fields.rid
                        Else
                            lgt_pil.XML_DRUG_PIL.rid = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Name_Medicinal_Product) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Name_Medicinal_Product = dao_pil.fields.PIL_Th_Name_Medicinal_Product
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Name_Medicinal_Product = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Product_Desc) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Product_Desc = dao_pil.fields.PIL_Th_Product_Desc
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Product_Desc = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Active_Ingradient_Strenght) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Active_Ingradient_Strenght = dao_pil.fields.PIL_Th_Active_Ingradient_Strenght
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Generic_Name) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Generic_Name = dao_pil.fields.PIL_Th_Generic_Name
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Generic_Name = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Used_For) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Used_For = dao_pil.fields.PIL_Th_Used_For
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Used_For = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Not_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Not_Take = dao_pil.fields.PIL_Th_When_Not_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Not_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Avoid_For_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Avoid_For_Take = dao_pil.fields.PIL_Th_Avoid_For_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Avoid_For_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_How_to_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Take = dao_pil.fields.PIL_Th_How_to_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Miss_Dose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Miss_Dose = dao_pil.fields.PIL_Th_When_Miss_Dose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Miss_Dose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Overdose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Overdose = dao_pil.fields.PIL_Th_Overdose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Overdose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_During_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_During_Take = dao_pil.fields.PIL_Th_During_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_During_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Meet_Doctor_Urgent) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor_Urgent = dao_pil.fields.PIL_Th_When_Meet_Doctor_Urgent
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor_Urgent = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_When_Meet_Doctor) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor = dao_pil.fields.PIL_Th_When_Meet_Doctor
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_How_to_Storage) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Storage = dao_pil.fields.PIL_Th_How_to_Storage
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_How_to_Storage = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_MA_Holder) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Holder = dao_pil.fields.PIL_Th_MA_Holder
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Holder = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_MA_Number) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Number = dao_pil.fields.PIL_Th_MA_Number
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_MA_Number = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Date_Approve) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Approve = dao_pil.fields.PIL_Th_Date_Approve
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Approve = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Th_Date_Revision) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Revision = dao_pil.fields.PIL_Th_Date_Revision
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Th_Date_Revision = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Name_Medicinal_Product) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Name_Medicinal_Product = dao_pil.fields.PIL_Eng_Name_Medicinal_Product
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Name_Medicinal_Product = ""
                        End If


                        If IsNothing(dao_pil.fields.PIL_Eng_Product_Desc) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Product_Desc = dao_pil.fields.PIL_Eng_Product_Desc
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Product_Desc = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Active_Ingradient_Strenght) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Active_Ingradient_Strenght = dao_pil.fields.PIL_Eng_Active_Ingradient_Strenght
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Active_Ingradient_Strenght = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Generic_Name) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Generic_Name = dao_pil.fields.PIL_Eng_Generic_Name
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Generic_Name = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Used_For) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Used_For = dao_pil.fields.PIL_Eng_Used_For
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Used_For = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Not_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Not_Take = dao_pil.fields.PIL_Eng_When_Not_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Not_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Avoid_For_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Avoid_For_Take = dao_pil.fields.PIL_Eng_Avoid_For_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Avoid_For_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_How_to_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Take = dao_pil.fields.PIL_Eng_How_to_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Miss_Dose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Miss_Dose = dao_pil.fields.PIL_Eng_When_Miss_Dose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Miss_Dose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Overdose) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Overdose = dao_pil.fields.PIL_Eng_Overdose
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Overdose = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_During_Take) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_During_Take = dao_pil.fields.PIL_Eng_During_Take
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_During_Take = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Meet_Doctor_Urgent) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor_Urgent = dao_pil.fields.PIL_Eng_When_Meet_Doctor_Urgent
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor_Urgent = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_When_Meet_Doctor) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor = dao_pil.fields.PIL_Eng_When_Meet_Doctor
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_How_to_Storage) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Storage = dao_pil.fields.PIL_Eng_How_to_Storage
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_How_to_Storage = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_MA_Holder) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Holder = dao_pil.fields.PIL_Eng_MA_Holder
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Holder = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_MA_Number) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Number = dao_pil.fields.PIL_Eng_MA_Number
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_MA_Number = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Date_Approve) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Approve = dao_pil.fields.PIL_Eng_Date_Approve
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Approve = ""
                        End If

                        If IsNothing(dao_pil.fields.PIL_Eng_Date_Revision) = False Then
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Revision = dao_pil.fields.PIL_Eng_Date_Revision
                        Else
                            lgt_pil.XML_DRUG_PIL.PIL_Eng_Date_Revision = ""
                        End If

                        If IsNothing(dao_pil.fields.Newcode) = False Then
                            lgt_pil.XML_DRUG_PIL.Newcode = dao_pil.fields.Newcode
                        Else
                            lgt_pil.XML_DRUG_PIL.Newcode = ""
                        End If


                        class_xml.LGT_XML_DRUG_DOC_PIL.Add(lgt_pil)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_pil1 As New LGT_XML_DRUG_DOC_PIL

                    lgt_pil1.XML_DRUG_PIL.IDA = 0
                    lgt_pil1.XML_DRUG_PIL.pvncd = ""
                    lgt_pil1.XML_DRUG_PIL.drgtpcd = ""
                    lgt_pil1.XML_DRUG_PIL.rgttpcd = ""
                    lgt_pil1.XML_DRUG_PIL.rgtno = ""
                    lgt_pil1.XML_DRUG_PIL.rid = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Name_Medicinal_Product = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Product_Desc = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Active_Ingradient_Strenght = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Generic_Name = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Used_For = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Not_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Avoid_For_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_How_to_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Miss_Dose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Overdose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_During_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor_Urgent = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_When_Meet_Doctor = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_How_to_Storage = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_MA_Holder = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_MA_Number = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Date_Approve = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Th_Date_Revision = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Name_Medicinal_Product = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Product_Desc = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Active_Ingradient_Strenght = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Generic_Name = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Used_For = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Not_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Avoid_For_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_How_to_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Miss_Dose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Overdose = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_During_Take = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor_Urgent = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_When_Meet_Doctor = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_How_to_Storage = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_MA_Holder = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_MA_Number = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Date_Approve = ""
                    lgt_pil1.XML_DRUG_PIL.PIL_Eng_Date_Revision = ""
                    lgt_pil1.XML_DRUG_PIL.Newcode = ""


                    class_xml.LGT_XML_DRUG_DOC_PIL.Add(lgt_pil1)
                    'Next
                End If
#End Region
#Region "SOURCE_OF_RM"
                '-----------------------------SOURCE_OF_RM
                Dim dao_sour_rm As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_SOURCE_OF_RM
                dao_sour_rm.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_sour_rm.Details.Count <> 0 Then

                    For Each dao_sour_rm.fields In dao_sour_rm.datas
                        Dim lgt_sour_rm As New LGT_XML_DRUG_SOURCE_OF_RM

                        If IsNothing(dao_sour_rm.fields.IDA) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.IDA = dao_sour_rm.fields.IDA
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.IDA = 0
                        End If
                        If IsNothing(dao_sour_rm.fields.pvncd) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.pvncd = dao_sour_rm.fields.pvncd
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.pvncd = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.drgtpcd) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.drgtpcd = dao_sour_rm.fields.drgtpcd
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.drgtpcd = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.rgttpcd) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgttpcd = dao_sour_rm.fields.rgttpcd
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgttpcd = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.rgtno) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgtno = dao_sour_rm.fields.rgtno
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rgtno = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.rid) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rid = dao_sour_rm.fields.rid
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.rid = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.iowacd) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowacd = dao_sour_rm.fields.iowacd
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowacd = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.iowanm) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowanm = dao_sour_rm.fields.iowanm
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.iowanm = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.phm15dgt) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.phm15dgt = dao_sour_rm.fields.phm15dgt
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.phm15dgt = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.engdrgnm) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engdrgnm = dao_sour_rm.fields.engdrgnm
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engdrgnm = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.engfrgnnm) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm = dao_sour_rm.fields.engfrgnnm
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.engfrgnnm_addr) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm_addr = dao_sour_rm.fields.engfrgnnm_addr
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engfrgnnm_addr = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.engcntnm) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engcntnm = dao_sour_rm.fields.engcntnm
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.engcntnm = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.LICEN_PHM15DGT) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.LICEN_PHM15DGT = dao_sour_rm.fields.LICEN_PHM15DGT
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.LICEN_PHM15DGT = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.STANDARD_PLACE_STAPLE) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.STANDARD_PLACE_STAPLE = dao_sour_rm.fields.STANDARD_PLACE_STAPLE
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.STANDARD_PLACE_STAPLE = ""
                        End If
                        If IsNothing(dao_sour_rm.fields.Newcode) = False Then
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.Newcode = dao_sour_rm.fields.Newcode
                        Else
                            lgt_sour_rm.XML_DRUG_SOURCE_OF_RM.Newcode = ""
                        End If

                        class_xml.LGT_XML_DRUG_SOURCE_OF_RM.Add(lgt_sour_rm)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_sour_rm1 As New LGT_XML_DRUG_SOURCE_OF_RM


                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.IDA = 0
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.pvncd = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.drgtpcd = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.rgttpcd = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.rgtno = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.rid = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.iowacd = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.iowanm = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.phm15dgt = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engdrgnm = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engfrgnnm = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engfrgnnm_addr = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.engcntnm = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.LICEN_PHM15DGT = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.STANDARD_PLACE_STAPLE = ""
                    lgt_sour_rm1.XML_DRUG_SOURCE_OF_RM.Newcode = ""
                    class_xml.LGT_XML_DRUG_SOURCE_OF_RM.Add(lgt_sour_rm1)
                    'Next
                End If
#End Region
#Region "รหัสยา"
                '-----------------------------รหัสยา
                Dim dao_code As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CODE
                dao_code.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_code.Details.Count <> 0 Then

                    For Each dao_code.fields In dao_code.datas
                        Dim lgt_code As New LGT_XML_DRUG_CODE

                        If IsNothing(dao_code.fields.IDA) = False Then
                            lgt_code.XML_DRUG_CODE.IDA = dao_code.fields.IDA
                        Else
                            lgt_code.XML_DRUG_CODE.IDA = 0
                        End If
                        If IsNothing(dao_code.fields.pvncd) = False Then
                            lgt_code.XML_DRUG_CODE.pvncd = dao_code.fields.pvncd
                        Else
                            lgt_code.XML_DRUG_CODE.pvncd = ""
                        End If
                        If IsNothing(dao_code.fields.drgtpcd) = False Then
                            lgt_code.XML_DRUG_CODE.drgtpcd = dao_code.fields.drgtpcd
                        Else
                            lgt_code.XML_DRUG_CODE.drgtpcd = ""
                        End If
                        If IsNothing(dao_code.fields.rgttpcd) = False Then
                            lgt_code.XML_DRUG_CODE.rgttpcd = dao_code.fields.rgttpcd
                        Else
                            lgt_code.XML_DRUG_CODE.rgttpcd = ""
                        End If
                        If IsNothing(dao_code.fields.rgtno) = False Then
                            lgt_code.XML_DRUG_CODE.rgtno = dao_code.fields.rgtno
                        Else
                            lgt_code.XML_DRUG_CODE.rgtno = ""
                        End If
                        If IsNothing(dao_code.fields.rid) = False Then
                            lgt_code.XML_DRUG_CODE.rid = dao_code.fields.rid
                        Else
                            lgt_code.XML_DRUG_CODE.rid = ""
                        End If
                        If IsNothing(dao_code.fields.CODE_DL) = False Then
                            lgt_code.XML_DRUG_CODE.CODE_DL = dao_code.fields.CODE_DL
                        Else
                            lgt_code.XML_DRUG_CODE.CODE_DL = ""
                        End If
                        If IsNothing(dao_code.fields.CODE_ECTD_IDENIFIER) = False Then
                            lgt_code.XML_DRUG_CODE.CODE_ECTD_IDENIFIER = dao_code.fields.CODE_ECTD_IDENIFIER
                        Else
                            lgt_code.XML_DRUG_CODE.CODE_ECTD_IDENIFIER = ""
                        End If
                        If IsNothing(dao_code.fields.TMT_VTM) = False Then
                            lgt_code.XML_DRUG_CODE.TMT_VTM = dao_code.fields.TMT_VTM
                        Else
                            lgt_code.XML_DRUG_CODE.TMT_VTM = ""
                        End If
                        If IsNothing(dao_code.fields.TMT_GP) = False Then
                            lgt_code.XML_DRUG_CODE.TMT_GP = dao_code.fields.TMT_GP
                        Else
                            lgt_code.XML_DRUG_CODE.TMT_GP = ""
                        End If
                        If IsNothing(dao_code.fields.TMT_GPU) = False Then
                            lgt_code.XML_DRUG_CODE.TMT_GPU = dao_code.fields.TMT_GPU
                        Else
                            lgt_code.XML_DRUG_CODE.TMT_GPU = ""
                        End If
                        If IsNothing(dao_code.fields.TMT_TPU) = False Then
                            lgt_code.XML_DRUG_CODE.TMT_TPU = dao_code.fields.TMT_TPU
                        Else
                            lgt_code.XML_DRUG_CODE.TMT_TPU = ""
                        End If
                        If IsNothing(dao_code.fields.GTIN) = False Then
                            lgt_code.XML_DRUG_CODE.GTIN = dao_code.fields.GTIN
                        Else
                            lgt_code.XML_DRUG_CODE.GTIN = ""
                        End If
                        If IsNothing(dao_code.fields.UNII) = False Then
                            lgt_code.XML_DRUG_CODE.UNII = dao_code.fields.UNII
                        Else
                            lgt_code.XML_DRUG_CODE.UNII = ""
                        End If
                        If IsNothing(dao_code.fields.DC24) = False Then
                            lgt_code.XML_DRUG_CODE.DC24 = dao_code.fields.DC24
                        Else
                            lgt_code.XML_DRUG_CODE.DC24 = ""
                        End If
                        If IsNothing(dao_code.fields.Newcode) = False Then
                            lgt_code.XML_DRUG_CODE.Newcode = dao_code.fields.Newcode
                        Else
                            lgt_code.XML_DRUG_CODE.Newcode = ""
                        End If

                        class_xml.LGT_XML_DRUG_CODE.Add(lgt_code)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_code1 As New LGT_XML_DRUG_CODE


                    lgt_code1.XML_DRUG_CODE.IDA = 0
                    lgt_code1.XML_DRUG_CODE.pvncd = ""
                    lgt_code1.XML_DRUG_CODE.drgtpcd = ""
                    lgt_code1.XML_DRUG_CODE.rgttpcd = ""
                    lgt_code1.XML_DRUG_CODE.rgtno = ""
                    lgt_code1.XML_DRUG_CODE.rid = ""
                    lgt_code1.XML_DRUG_CODE.CODE_DL = ""
                    lgt_code1.XML_DRUG_CODE.CODE_ECTD_IDENIFIER = ""
                    lgt_code1.XML_DRUG_CODE.TMT_VTM = ""
                    lgt_code1.XML_DRUG_CODE.TMT_GP = ""
                    lgt_code1.XML_DRUG_CODE.TMT_GPU = ""
                    lgt_code1.XML_DRUG_CODE.TMT_TPU = ""
                    lgt_code1.XML_DRUG_CODE.GTIN = ""
                    lgt_code1.XML_DRUG_CODE.UNII = ""
                    lgt_code1.XML_DRUG_CODE.DC24 = ""
                    lgt_code1.XML_DRUG_CODE.Newcode = ""
                    class_xml.LGT_XML_DRUG_CODE.Add(lgt_code1)
                    'Next
                End If

#End Region
#Region "ขนาดบรรจุ"
                '----------------------------ขนาดบรรจุ
                Dim dao_contain As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CONTAIN
                dao_contain.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_contain.Details.Count <> 0 Then

                    For Each dao_contain.fields In dao_contain.datas
                        Dim lgt_contain As New LGT_XML_DRUG_CONTAIN

                        If IsNothing(dao_contain.fields.IDA) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.IDA = dao_contain.fields.IDA
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.IDA = 0
                        End If
                        If IsNothing(dao_contain.fields.pvncd) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.pvncd = dao_contain.fields.pvncd
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.pvncd = ""
                        End If
                        If IsNothing(dao_contain.fields.drgtpcd) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.drgtpcd = dao_contain.fields.drgtpcd
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.drgtpcd = ""
                        End If
                        If IsNothing(dao_contain.fields.rgttpcd) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.rgttpcd = dao_contain.fields.rgttpcd
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.rgttpcd = ""
                        End If
                        If IsNothing(dao_contain.fields.rgtno) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.rgtno = dao_contain.fields.rgtno
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.rgtno = ""
                        End If
                        If IsNothing(dao_contain.fields.lcnno) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.lcnno = dao_contain.fields.lcnno
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.lcnno = ""
                        End If
                        If IsNothing(dao_contain.fields.rid) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.rid = dao_contain.fields.rid
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.rid = ""
                        End If
                        If IsNothing(dao_contain.fields.SUBTITLE_SIZE_DRUG) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = dao_contain.fields.SUBTITLE_SIZE_DRUG
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
                        End If
                        If IsNothing(dao_contain.fields.SMALL_AMOUNT) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = dao_contain.fields.SMALL_AMOUNT
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_AMOUNT = 0.0
                        End If
                        If IsNothing(dao_contain.fields.SMALL_UNIT) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = dao_contain.fields.SMALL_UNIT
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SMALL_UNIT = ""
                        End If
                        If IsNothing(dao_contain.fields.BIG_UNIT) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = dao_contain.fields.BIG_UNIT
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.BIG_UNIT = ""
                        End If
                        If IsNothing(dao_contain.fields.BIG_AMOUNT) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = dao_contain.fields.BIG_AMOUNT
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.BIG_AMOUNT = 0.0
                        End If
                        If IsNothing(dao_contain.fields.MEDIUM_AMOUNT) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = dao_contain.fields.MEDIUM_AMOUNT
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = 0.0
                        End If
                        If IsNothing(dao_contain.fields.MEDIUM_UNIT) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = dao_contain.fields.MEDIUM_UNIT
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
                        End If
                        If IsNothing(dao_contain.fields.BARCODE) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.BARCODE = dao_contain.fields.BARCODE
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.BARCODE = ""
                        End If
                        If IsNothing(dao_contain.fields.SUM) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.SUM = dao_contain.fields.SUM
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.SUM = ""
                        End If

                        If IsNothing(dao_contain.fields.CONRAIN) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.CONRAIN = dao_contain.fields.CONRAIN
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.CONRAIN = ""
                        End If
                        If IsNothing(dao_contain.fields.STATUS_CONRAIN) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = dao_contain.fields.STATUS_CONRAIN
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
                        End If
                        If IsNothing(dao_contain.fields.updateDate) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.updateDate = dao_contain.fields.updateDate
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.updateDate = Date.Now
                        End If
                        If IsNothing(dao_contain.fields.cncdate) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.cncdate = dao_contain.fields.cncdate
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.cncdate = Date.Now
                        End If
                        If IsNothing(dao_contain.fields.Newcode) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.Newcode = dao_contain.fields.Newcode
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.Newcode = ""
                        End If
                        If IsNothing(dao_contain.fields.IDA_DRRGT_PACKAGE_DETAIL) = False Then
                            lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = dao_contain.fields.IDA_DRRGT_PACKAGE_DETAIL
                        Else
                            lgt_contain.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = ""
                        End If
                        class_xml.LGT_XML_DRUG_CONTAIN.Add(lgt_contain)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_contain1 As New LGT_XML_DRUG_CONTAIN
                    lgt_contain1.XML_DRUG_CONTAIN.IDA = 0
                    lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.drgtpcd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.rgttpcd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.pvncd = ""
                    lgt_contain1.XML_DRUG_CONTAIN.rgtno = ""
                    lgt_contain1.XML_DRUG_CONTAIN.rid = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SUBTITLE_SIZE_DRUG = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SMALL_AMOUNT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SMALL_UNIT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.BIG_UNIT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.BIG_AMOUNT = 0
                    lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_AMOUNT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.MEDIUM_UNIT = ""
                    lgt_contain1.XML_DRUG_CONTAIN.BARCODE = ""
                    lgt_contain1.XML_DRUG_CONTAIN.SUM = ""
                    lgt_contain1.XML_DRUG_CONTAIN.CONRAIN = ""
                    lgt_contain1.XML_DRUG_CONTAIN.STATUS_CONRAIN = ""
                    lgt_contain1.XML_DRUG_CONTAIN.updateDate = Date.Now
                    lgt_contain1.XML_DRUG_CONTAIN.cncdate = Date.Now
                    lgt_contain1.XML_DRUG_CONTAIN.Newcode = ""
                    lgt_contain1.XML_DRUG_CONTAIN.IDA_DRRGT_PACKAGE_DETAIL = 0
                    class_xml.LGT_XML_DRUG_CONTAIN.Add(lgt_contain1)
                    'Next
                End If

#End Region
#Region "วิธีวิเคราะห์ควบคุมคุณภาพ"
                '----------------------------วิธีวิเคราะห์ควบคุมคุณภาพ
                Dim dao_control_ana As New DAO_XML_DRUG_SEUB.TB_XML_DRUG_CONTROL_ANALYZE
                dao_control_ana.GetDataby_Newcode(dao_dr.fields.Newcode_U)
                If dao_control_ana.Details.Count <> 0 Then

                    For Each dao_control_ana.fields In dao_control_ana.datas
                        Dim lgt_control_ana As New LGT_XML_DRUG_CONTROL_ANALYZE

                        If IsNothing(dao_control_ana.fields.IDA) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.IDA = dao_control_ana.fields.IDA
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.IDA = 0
                        End If
                        If IsNothing(dao_control_ana.fields.pvncd) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.pvncd = dao_control_ana.fields.pvncd
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.pvncd = ""
                        End If
                        If IsNothing(dao_control_ana.fields.drgtpcd) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.drgtpcd = dao_control_ana.fields.drgtpcd
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.drgtpcd = ""
                        End If
                        If IsNothing(dao_control_ana.fields.rgttpcd) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgttpcd = dao_control_ana.fields.rgttpcd
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgttpcd = ""
                        End If
                        If IsNothing(dao_control_ana.fields.rgtno) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgtno = dao_control_ana.fields.rgtno
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rgtno = ""
                        End If
                        If IsNothing(dao_control_ana.fields.lcnno) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.lcnno = dao_control_ana.fields.lcnno
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.lcnno = ""
                        End If
                        If IsNothing(dao_control_ana.fields.rid) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rid = dao_control_ana.fields.rid
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.rid = ""
                        End If
                        If IsNothing(dao_control_ana.fields.TOPIC_ANALYZE) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.TOPIC_ANALYZE = dao_control_ana.fields.TOPIC_ANALYZE
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.TOPIC_ANALYZE = ""
                        End If
                        If IsNothing(dao_control_ana.fields.METHOD_ANALYZE) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.METHOD_ANALYZE = dao_control_ana.fields.METHOD_ANALYZE
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.METHOD_ANALYZE = ""
                        End If
                        If IsNothing(dao_control_ana.fields.SET_STANDARDS) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.SET_STANDARDS = dao_control_ana.fields.SET_STANDARDS
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.SET_STANDARDS = ""
                        End If
                        If IsNothing(dao_control_ana.fields.REF_STANDARDS) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.REF_STANDARDS = dao_control_ana.fields.REF_STANDARDS
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.REF_STANDARDS = ""
                        End If
                        If IsNothing(dao_control_ana.fields.Newcode) = False Then
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.Newcode = dao_control_ana.fields.Newcode
                        Else
                            lgt_control_ana.XML_DRUG_CONTROL_ANALYZE.Newcode = ""
                        End If
                        class_xml.LGT_XML_DRUG_CONTROL_ANALYZE.Add(lgt_control_ana)
                    Next
                Else

                    'For Each dao_export.fields In dao_export.Details
                    Dim lgt_control_ana1 As New LGT_XML_DRUG_CONTROL_ANALYZE
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.IDA = 0
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.pvncd = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.drgtpcd = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.rgttpcd = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.rgtno = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.rid = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.TOPIC_ANALYZE = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.METHOD_ANALYZE = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.SET_STANDARDS = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.REF_STANDARDS = ""
                    lgt_control_ana1.XML_DRUG_CONTROL_ANALYZE.Newcode = ""

                    class_xml.LGT_XML_DRUG_CONTROL_ANALYZE.Add(lgt_control_ana1)
                    'Next
                End If

#End Region
                Return class_xml
            End Function
#End Region
#Region "NCT"
            Public Function gen_xml_XML_NCT_NR_FORMULA(ByVal Newcode As String) As LGT_XML_NCT_NR_IOW
                Dim class_xml As New LGT_XML_NCT_NR_IOW
                Dim dao As New DAO_XML_NCT.TB_XML_NCT_NR
                dao.GetDataby_Newcode(Newcode)
                'class_xml.LGT_XML_NCT_NR_TO = dao.datas
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.IDA = dao.fields.IDA
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.pvncd = dao.fields.pvncd                                            ' การเลือกฟิลด์ผลิตภัณฑ์มา
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.pvnabbr = dao.fields.pvnabbr
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rgttpcd = dao.fields.rgttpcd
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.drgtpcd = dao.fields.drgtpcd
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rgtno = dao.fields.rgtno
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcntpcd = dao.fields.lcntpcd
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcnsid = dao.fields.lcnsid
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcnno = dao.fields.lcnno
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rcvno = dao.fields.rcvno
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.register = dao.fields.register
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.register_rcvno = dao.fields.register_rcvno
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.CITIZEN_AUTHORIZE = dao.fields.CITIZEN_AUTHORIZE
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcntpnm = dao.fields.lcntpnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thadrgnm = dao.fields.thadrgnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.engdrgnm = dao.fields.engdrgnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.drgperunit = dao.fields.drgperunit
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.psytype = dao.fields.psytype
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.psytypenm = dao.fields.psytypenm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.drgchr = dao.fields.drgchr
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.ctgthanm = dao.fields.ctgthanm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.ctgengnm = dao.fields.ctgengnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thaclassnm = dao.fields.thaclassnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thadsgnm = dao.fields.thadsgnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thakindnm = dao.fields.thakindnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncnm = dao.fields.cncnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thachngwtnm_thanm = dao.fields.thachngwtnm_thanm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cnccsnm = dao.fields.cnccsnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.licen_loca = dao.fields.licen_loca
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thanm = dao.fields.thanm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thanm_addr = dao.fields.thanm_addr
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rcvdate_th = dao.fields.rcvdate_th
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rcvdate_en = dao.fields.rcvdate_en
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.appdate_th = dao.fields.appdate_th
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncdate_th = dao.fields.cncdate_th
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.appdate_en = dao.fields.appdate_th
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncdate_en = dao.fields.cncdate_en
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.status_num = dao.fields.status_num
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.status = dao.fields.status
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncnm2 = dao.fields.cncnm2
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.Newcode = dao.fields.Newcode
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcnno = dao.fields.lcnno
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.appdate = dao.fields.appdate
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.expdate = dao.fields.expdate
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lmdfdate = dao.fields.lmdfdate
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.frtappdate = dao.fields.frtappdate
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rcvdate = dao.fields.rcvdate

                Dim dao_newcode_producteng As New DAO_XML_NCT.TB_XML_NCT_FRGN_TO ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_newcode_producteng.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_newcode_producteng.fields In dao_newcode_producteng.datas
                    Dim lgt_cmt As New LGT_XML_NCT_FRGN_TO
                    lgt_cmt.XML_NCT_FRGN_TO.engfrgnnm = dao_newcode_producteng.fields.engfrgnnm
                    lgt_cmt.XML_NCT_FRGN_TO.engcntnm = dao_newcode_producteng.fields.engcntnm
                    lgt_cmt.XML_NCT_FRGN_TO.offengnm = dao_newcode_producteng.fields.offengnm

                    lgt_cmt.XML_NCT_FRGN_TO.addr = dao_newcode_producteng.fields.addr
                    lgt_cmt.XML_NCT_FRGN_TO.soi = dao_newcode_producteng.fields.soi
                    lgt_cmt.XML_NCT_FRGN_TO.mu = dao_newcode_producteng.fields.mu
                    lgt_cmt.XML_NCT_FRGN_TO.road = dao_newcode_producteng.fields.road
                    lgt_cmt.XML_NCT_FRGN_TO.district = dao_newcode_producteng.fields.district
                    lgt_cmt.XML_NCT_FRGN_TO.subdiv = dao_newcode_producteng.fields.subdiv
                    lgt_cmt.XML_NCT_FRGN_TO.province = dao_newcode_producteng.fields.province
                    lgt_cmt.XML_NCT_FRGN_TO.zipcode = dao_newcode_producteng.fields.zipcode
                    lgt_cmt.XML_NCT_FRGN_TO.country = dao_newcode_producteng.fields.country
                    lgt_cmt.XML_NCT_FRGN_TO.tel = dao_newcode_producteng.fields.tel
                    lgt_cmt.XML_NCT_FRGN_TO.fax = dao_newcode_producteng.fields.fax
                    class_xml.LGT_XML_NCT_FRGN_TO.Add(lgt_cmt)
                Next

                Dim dao_AGENT_TO As New DAO_XML_NCT.TB_XML_NCT_AGENT_TO  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_AGENT_TO.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_AGENT_TO.fields In dao_AGENT_TO.datas
                    Dim lgt_cmt As New LGT_XML_NCT_AGENT_TO
                    lgt_cmt.XML_NCT_AGENT_TO.pvncd = dao_AGENT_TO.fields.pvncd
                    lgt_cmt.XML_NCT_AGENT_TO.rgtno = dao_AGENT_TO.fields.rgtno
                    lgt_cmt.XML_NCT_AGENT_TO.agent = dao_AGENT_TO.fields.agent                   'ใส่ชื่อฟิลด์ที่ต้องการแสดง ในแท๊กผลิตภัณฑ์ย่อย
                    lgt_cmt.XML_NCT_AGENT_TO.Newcode = dao_newcode_producteng.fields.Newcode
                    class_xml.LGT_XML_NCT_AGENT_TO.Add(lgt_cmt)
                Next

                Dim dao_iow As New DAO_XML_NCT.TB_XML_NCT_IOW_TO  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_iow.GetDataby_Newcode_R(dao.fields.Newcode_R)
                For Each dao_iow.fields In dao_iow.datas
                    Dim lgt_cmt As New LGT_XML_NCT_IOW_EQ
                    lgt_cmt.XML_NCT_IOW_TO.iowanm = dao_iow.fields.iowanm                   'ใส่ชื่อฟิลด์ที่ต้องการแสดง ในแท๊กผลิตภัณฑ์ย่อย
                    lgt_cmt.XML_NCT_IOW_TO.qty = dao_iow.fields.qty
                    lgt_cmt.XML_NCT_IOW_TO.aori = dao_iow.fields.aori
                    lgt_cmt.XML_NCT_IOW_TO.rid = dao_iow.fields.rid
                    lgt_cmt.XML_NCT_IOW_TO.Newcode = dao_iow.fields.Newcode
                    lgt_cmt.XML_NCT_IOW_TO.Newcode_R = dao_iow.fields.Newcode_R
                    Dim dao_XML_CMT_X_TYPE2 As New DAO_XML_NCT.TB_XML_NCT_IOW_EQ_TO  ' ถ้าเป็น List of2 ต้องใช้อันนี้ และ การที่นำเข้ามาไว้ใน next คือ List ซ้อน List  ชื่อสารที่อยู่ในแต่ละผลิตภัณฑ์ย่อย
                    dao_XML_CMT_X_TYPE2.GetDataby_Newcode_RID(dao_iow.fields.Newcode_rid)
                    For Each dao_XML_CMT_X_TYPE2.fields In dao_XML_CMT_X_TYPE2.datas
                        Dim lgt_type2 As New LGT_XML_NCT_IOW_EQ_TO                            ' XML_CMT_TYPE2 คือตารางชื่อสาร  
                        lgt_type2.XML_NCT_IOW_EQ_TO.iowanm = dao_XML_CMT_X_TYPE2.fields.iowanm
                        lgt_type2.XML_NCT_IOW_EQ_TO.qty = dao_XML_CMT_X_TYPE2.fields.qty
                        lgt_type2.XML_NCT_IOW_EQ_TO.rid = dao_XML_CMT_X_TYPE2.fields.rid
                        lgt_type2.XML_NCT_IOW_EQ_TO.Newcode_rid = dao_XML_CMT_X_TYPE2.fields.Newcode_rid

                        lgt_cmt.LGT_XML_NCT_IOW_EQ_TO.Add(lgt_type2)
                    Next
                    class_xml.LGT_XML_NCT_IOW_EQ.Add(lgt_cmt)
                Next

                Dim dao_COLOR_TO As New DAO_XML_NCT.TB_XML_NCT_COLOR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_COLOR_TO.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_COLOR_TO.fields In dao_COLOR_TO.datas
                    Dim lgt_cmt As New LGT_XML_NCT_COLOR_TO
                    lgt_cmt.XML_NCT_COLOR.shapenm = dao_COLOR_TO.fields.shapenm
                    lgt_cmt.XML_NCT_COLOR.colornm = dao_COLOR_TO.fields.colornm
                    lgt_cmt.XML_NCT_COLOR.psytype = dao_COLOR_TO.fields.psytype
                    lgt_cmt.XML_NCT_COLOR.Newcode = dao_COLOR_TO.fields.Newcode
                    class_xml.LGT_XML_NCT_COLOR_TO.Add(lgt_cmt)
                Next


                Dim dao_RECIPE_GROUP_TO As New DAO_XML_NCT.TB_XML_NCT_RECIPE_GROUP  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_RECIPE_GROUP_TO.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_RECIPE_GROUP_TO.fields In dao_RECIPE_GROUP_TO.datas
                    Dim lgt_cmt As New LGT_XML_NCT_RECIPE_GROUP_TO
                    lgt_cmt.XML_NCT_RECIPE_GROUP.atccd = dao_RECIPE_GROUP_TO.fields.atccd
                    lgt_cmt.XML_NCT_RECIPE_GROUP.atcnm = dao_RECIPE_GROUP_TO.fields.atcnm

                    class_xml.LGT_XML_NCT_RECIPE_GROUP_TO.Add(lgt_cmt)
                Next


                Dim dao_qua As New DAO_XML_NCT.TB_XML_QUALITIES_COLOR_DRUG  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_qua.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_qua.fields In dao_qua.datas
                    Dim lgt_cmt As New LGT_XML_QUALITIES_COLOR_DRUG_TO
                    lgt_cmt.XML_QUALITIES_COLOR_DRUG.drgchr = dao_qua.fields.drgchr
                    lgt_cmt.XML_QUALITIES_COLOR_DRUG.Newcode = dao_qua.fields.Newcode

                    class_xml.LGT_XML_QUALITIES_COLOR_DRUG_TO.Add(lgt_cmt)
                Next

                'Dim dao_nqr As New DAO_FDA_XML_NCT.TB_XML_NCT_NR_NQR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                'dao_nqr.GetDataby_Newcode(dao.fields.Newcode)
                'For Each dao_nqr.fields In dao_nqr.datas
                '    Dim lgt_cmt As New LGT_XML_NCT_NR_NQR_TO
                '    lgt_cmt.XML_NCT_NR_NQR.IDA = dao_nqr.fields.IDA
                '    lgt_cmt.XML_NCT_NR_NQR.pvncd = dao_nqr.fields.pvncd                                            ' การเลือกฟิลด์ผลิตภัณฑ์มา
                '    lgt_cmt.XML_NCT_NR_NQR.pvnabbr = dao_nqr.fields.pvnabbr
                '    lgt_cmt.XML_NCT_NR_NQR.rgttpcd = dao_nqr.fields.rgttpcd
                '    lgt_cmt.XML_NCT_NR_NQR.rgtno = dao_nqr.fields.rgtno
                '    lgt_cmt.XML_NCT_NR_NQR.rcvno = dao_nqr.fields.rcvno
                '    lgt_cmt.XML_NCT_NR_NQR.lcntpcd = dao_nqr.fields.lcntpcd
                '    lgt_cmt.XML_NCT_NR_NQR.lcnsid = dao_nqr.fields.lcnsid
                '    lgt_cmt.XML_NCT_NR_NQR.register = dao_nqr.fields.register
                '    lgt_cmt.XML_NCT_NR_NQR.register_rcvno = dao_nqr.fields.register_rcvno
                '    lgt_cmt.XML_NCT_NR_NQR.rcvdate_th = dao_nqr.fields.rcvdate_th
                '    lgt_cmt.XML_NCT_NR_NQR.CITIZEN_AUTHORIZE = dao_nqr.fields.CITIZEN_AUTHORIZE
                '    lgt_cmt.XML_NCT_NR_NQR.lcntpnm = dao_nqr.fields.lcntpnm
                '    lgt_cmt.XML_NCT_NR_NQR.thadrgnm = dao_nqr.fields.thadrgnm
                '    lgt_cmt.XML_NCT_NR_NQR.engdrgnm = dao_nqr.fields.engdrgnm
                '    lgt_cmt.XML_NCT_NR_NQR.drgperunit = dao_nqr.fields.drgperunit
                '    lgt_cmt.XML_NCT_NR_NQR.drgchr = dao_nqr.fields.drgchr
                '    lgt_cmt.XML_NCT_NR_NQR.ctgthanm = dao_nqr.fields.ctgthanm
                '    lgt_cmt.XML_NCT_NR_NQR.thaclassnm = dao_nqr.fields.thaclassnm
                '    lgt_cmt.XML_NCT_NR_NQR.thadsgnm = dao_nqr.fields.thadsgnm
                '    lgt_cmt.XML_NCT_NR_NQR.thakindnm = dao_nqr.fields.thakindnm
                '    lgt_cmt.XML_NCT_NR_NQR.cncnm = dao_nqr.fields.cncnm
                '    lgt_cmt.XML_NCT_NR_NQR.thachngwtnm_thanm = dao_nqr.fields.thachngwtnm_thanm
                '    lgt_cmt.XML_NCT_NR_NQR.cnccsnm = dao_nqr.fields.cnccsnm
                '    lgt_cmt.XML_NCT_NR_NQR.licen_loca = dao_nqr.fields.licen_loca
                '    lgt_cmt.XML_NCT_NR_NQR.thanm = dao_nqr.fields.thanm
                '    lgt_cmt.XML_NCT_NR_NQR.thanm_addr = dao_nqr.fields.thanm_addr
                '    lgt_cmt.XML_NCT_NR_NQR.appdate_th = dao_nqr.fields.appdate_th
                '    lgt_cmt.XML_NCT_NR_NQR.cncdate_th = dao_nqr.fields.cncdate_th
                '    lgt_cmt.XML_NCT_NR_NQR.cncnm2 = dao_nqr.fields.cncnm2
                '    lgt_cmt.XML_NCT_NR_NQR.Newcode = dao_nqr.fields.Newcode
                '    lgt_cmt.XML_NCT_NR_NQR.lcnno = dao_nqr.fields.lcnno
                '    lgt_cmt.XML_NCT_NR_NQR.appdate = dao_nqr.fields.appdate
                '    lgt_cmt.XML_NCT_NR_NQR.expdate = dao_nqr.fields.expdate
                '    lgt_cmt.XML_NCT_NR_NQR.lmdfdate = dao_nqr.fields.lmdfdate
                '    lgt_cmt.XML_NCT_NR_NQR.Newcode_rcvno = dao_nqr.fields.Newcode_rcvno
                '    lgt_cmt.XML_NCT_NR_NQR.frtappdate = dao_nqr.fields.frtappdate

                '    class_xml.LGT_XML_NCT_NR_NQR_TO.Add(lgt_cmt)
                'Next
                'Dim dao_nqr_detail As New DAO_FDA_XML_NCT.TB_XML_NCT_NR_NQR_DETAIL  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                'dao_nqr_detail.GetDataby_Newcode(dao.fields.Newcode)
                'For Each dao_nqr_detail.fields In dao_nqr_detail.datas
                '    Dim lgt_cmt As New LGT_XML_NCT_NR_NQR_DETAIL_TO
                '    lgt_cmt.XML_NCT_NR_NQR_DETAIL.edtcd = dao_nqr_detail.fields.edtcd
                '    lgt_cmt.XML_NCT_NR_NQR_DETAIL.edtnm = dao_nqr_detail.fields.edtnm
                '    lgt_cmt.XML_NCT_NR_NQR_DETAIL.edtnm_change = dao_nqr_detail.fields.edtnm_change
                '    lgt_cmt.XML_NCT_NR_NQR_DETAIL.Newcode = dao_nqr_detail.fields.Newcode
                '    lgt_cmt.XML_NCT_NR_NQR_DETAIL.Newcode_edtcd = dao_nqr_detail.fields.Newcode_edtcd
                '    lgt_cmt.XML_NCT_NR_NQR_DETAIL.Newcode_rcvno = dao_nqr_detail.fields.Newcode_rcvno
                '    lgt_cmt.XML_NCT_NR_NQR_DETAIL.rcvno = dao_nqr_detail.fields.rcvno
                '    class_xml.LGT_XML_NCT_NR_NQR_DETAIL_TO.Add(lgt_cmt)
                'Next

                Dim dao_nqr_canceled As New DAO_XML_NCT.TB_XML_NCT_NR_CANCELED  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_nqr_canceled.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_nqr_canceled.fields In dao_nqr_canceled.datas
                    Dim lgt_cmt As New LGT_XML_NCT_NR_CANCELED_TO
                    lgt_cmt.XML_NCT_NR_CANCELED.register_rcvno = dao_nqr_canceled.fields.register_rcvno
                    lgt_cmt.XML_NCT_NR_CANCELED.appdate_th = dao_nqr_canceled.fields.appdate_th
                    lgt_cmt.XML_NCT_NR_CANCELED.rcvdate_th = dao_nqr_canceled.fields.rcvdate_th
                    lgt_cmt.XML_NCT_NR_CANCELED.appdate_en = dao_nqr_canceled.fields.appdate_en
                    lgt_cmt.XML_NCT_NR_CANCELED.rcvdate_en = dao_nqr_canceled.fields.rcvdate_en
                    lgt_cmt.XML_NCT_NR_CANCELED.cnccsnm = dao_nqr_canceled.fields.cnccsnm
                    lgt_cmt.XML_NCT_NR_CANCELED.Newcode = dao_nqr_canceled.fields.Newcode

                    class_xml.LGT_XML_NCT_NR_CANCELED_TO.Add(lgt_cmt)
                Next

                Return class_xml
            End Function
            'Public Function gen_xml_XML_NCT_NR(ByVal Newcode As String) As LGT_XML_NCT_NR_ALL
            '    Dim class_xml As New LGT_XML_NCT_NR_ALL
            '    Dim dao As New DAO_XML_NCT.TB_XML_NCT_NR
            '    dao.GetDataby_Newcode(Newcode)
            '    'class_xml.LGT_XML_NCT_NR_TO = dao.datas
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.IDA = dao.fields.IDA
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.pvncd = dao.fields.pvncd                                            ' การเลือกฟิลด์ผลิตภัณฑ์มา
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.pvnabbr = dao.fields.pvnabbr
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rgttpcd = dao.fields.rgttpcd
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rgtno = dao.fields.rgtno
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcntpcd = dao.fields.lcntpcd
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcnsid = dao.fields.lcnsid
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.register = dao.fields.register
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.CITIZEN_AUTHORIZE = dao.fields.CITIZEN_AUTHORIZE
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcntpnm = dao.fields.lcntpnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thadrgnm = dao.fields.thadrgnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.engdrgnm = dao.fields.engdrgnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.drgperunit = dao.fields.drgperunit
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.drgchr = dao.fields.drgchr
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.ctgthanm = dao.fields.ctgthanm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.ctgengnm = dao.fields.ctgengnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thaclassnm = dao.fields.thaclassnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thadsgnm = dao.fields.thadsgnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thakindnm = dao.fields.thakindnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncnm = dao.fields.cncnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thachngwtnm_thanm = dao.fields.thachngwtnm_thanm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cnccsnm = dao.fields.cnccsnm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.licen_loca = dao.fields.licen_loca
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thanm = dao.fields.thanm
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thanm_addr = dao.fields.thanm_addr
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.appdate_th = dao.fields.appdate_th
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncdate_th = dao.fields.cncdate_th
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncnm2 = dao.fields.cncnm2
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.Newcode = dao.fields.Newcode
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcnno = dao.fields.lcnno
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.appdate = dao.fields.appdate
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.expdate = dao.fields.expdate
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lmdfdate = dao.fields.lmdfdate
            '    class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.frtappdate = dao.fields.frtappdate

            '    Dim dao_newcode_producteng As New DAO_FDA_XML_NCT.TB_XML_NCT_FRGN_TO ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
            '    dao_newcode_producteng.GetDataby_Newcode(dao.fields.Newcode)
            '    For Each dao_newcode_producteng.fields In dao_newcode_producteng.datas
            '        Dim lgt_cmt As New LGT_XML_NCT_FRGN_TO
            '        lgt_cmt.XML_NCT_FRGN_TO.engfrgnnm = dao_newcode_producteng.fields.engfrgnnm
            '        lgt_cmt.XML_NCT_FRGN_TO.engcntnm = dao_newcode_producteng.fields.engcntnm
            '        lgt_cmt.XML_NCT_FRGN_TO.offengnm = dao_newcode_producteng.fields.offengnm
            '        class_xml.LGT_XML_NCT_FRGN_TO.Add(lgt_cmt)
            '    Next

            '    Dim dao_AGENT_TO As New DAO_FDA_XML_NCT.TB_XML_NCT_AGENT_TO  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
            '    dao_AGENT_TO.GetDataby_Newcode(dao.fields.Newcode)
            '    For Each dao_AGENT_TO.fields In dao_AGENT_TO.datas
            '        Dim lgt_cmt As New LGT_XML_NCT_AGENT_TO
            '        lgt_cmt.XML_NCT_AGENT_TO.pvncd = dao_AGENT_TO.fields.pvncd
            '        lgt_cmt.XML_NCT_AGENT_TO.rgtno = dao_AGENT_TO.fields.rgtno
            '        lgt_cmt.XML_NCT_AGENT_TO.agent = dao_AGENT_TO.fields.agent                   'ใส่ชื่อฟิลด์ที่ต้องการแสดง ในแท๊กผลิตภัณฑ์ย่อย
            '        lgt_cmt.XML_NCT_AGENT_TO.Newcode = dao_newcode_producteng.fields.Newcode
            '        class_xml.LGT_XML_NCT_AGENT_TO.Add(lgt_cmt)
            '    Next

            '    Dim dao_COLOR_TO As New DAO_FDA_XML_NCT.TB_XML_NCT_COLOR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
            '    dao_COLOR_TO.GetDataby_Newcode(dao.fields.Newcode)
            '    For Each dao_COLOR_TO.fields In dao_COLOR_TO.datas
            '        Dim lgt_cmt As New LGT_XML_NCT_COLOR_TO
            '        lgt_cmt.XML_NCT_COLOR.shapenm = dao_COLOR_TO.fields.shapenm
            '        lgt_cmt.XML_NCT_COLOR.colornm = dao_COLOR_TO.fields.colornm
            '        lgt_cmt.XML_NCT_COLOR.Newcode = dao_COLOR_TO.fields.Newcode
            '        class_xml.LGT_XML_NCT_COLOR_TO.Add(lgt_cmt)
            '    Next


            '    Dim dao_qua As New DAO_FDA_XML_NCT.TB_XML_QUALITIES_COLOR_DRUG  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
            '    dao_qua.GetDataby_Newcode(dao.fields.Newcode)
            '    For Each dao_qua.fields In dao_qua.datas
            '        Dim lgt_cmt As New LGT_XML_QUALITIES_COLOR_DRUG_TO
            '        lgt_cmt.XML_QUALITIES_COLOR_DRUG.drgchr = dao_qua.fields.drgchr
            '        lgt_cmt.XML_QUALITIES_COLOR_DRUG.Newcode = dao_qua.fields.Newcode

            '        class_xml.LGT_XML_QUALITIES_COLOR_DRUG_TO.Add(lgt_cmt)
            '    Next
            '    Dim dao_nqr As New DAO_FDA_XML_NCT.TB_XML_NCT_NR_NQR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
            '    dao_nqr.GetDataby_Newcode(dao.fields.Newcode)
            '    For Each dao_nqr.fields In dao_nqr.datas
            '        Dim lgt_cmt As New LGT_XML_NCT_NR_NQR_TO
            '        lgt_cmt.XML_NCT_NR_NQR.IDA = dao_nqr.fields.IDA
            '        lgt_cmt.XML_NCT_NR_NQR.pvncd = dao_nqr.fields.pvncd                                            ' การเลือกฟิลด์ผลิตภัณฑ์มา
            '        lgt_cmt.XML_NCT_NR_NQR.pvnabbr = dao_nqr.fields.pvnabbr
            '        lgt_cmt.XML_NCT_NR_NQR.rgttpcd = dao_nqr.fields.rgttpcd
            '        lgt_cmt.XML_NCT_NR_NQR.rgtno = dao_nqr.fields.rgtno
            '        lgt_cmt.XML_NCT_NR_NQR.rcvno = dao_nqr.fields.rcvno
            '        lgt_cmt.XML_NCT_NR_NQR.lcntpcd = dao_nqr.fields.lcntpcd
            '        lgt_cmt.XML_NCT_NR_NQR.lcnsid = dao_nqr.fields.lcnsid
            '        lgt_cmt.XML_NCT_NR_NQR.register = dao_nqr.fields.register
            '        lgt_cmt.XML_NCT_NR_NQR.register_rcvno = dao_nqr.fields.register_rcvno
            '        lgt_cmt.XML_NCT_NR_NQR.rcvdate_th = dao_nqr.fields.rcvdate_th
            '        lgt_cmt.XML_NCT_NR_NQR.CITIZEN_AUTHORIZE = dao_nqr.fields.CITIZEN_AUTHORIZE
            '        lgt_cmt.XML_NCT_NR_NQR.lcntpnm = dao_nqr.fields.lcntpnm
            '        lgt_cmt.XML_NCT_NR_NQR.thadrgnm = dao_nqr.fields.thadrgnm
            '        lgt_cmt.XML_NCT_NR_NQR.engdrgnm = dao_nqr.fields.engdrgnm
            '        lgt_cmt.XML_NCT_NR_NQR.drgperunit = dao_nqr.fields.drgperunit
            '        lgt_cmt.XML_NCT_NR_NQR.drgchr = dao_nqr.fields.drgchr
            '        lgt_cmt.XML_NCT_NR_NQR.ctgthanm = dao_nqr.fields.ctgthanm
            '        lgt_cmt.XML_NCT_NR_NQR.thaclassnm = dao_nqr.fields.thaclassnm
            '        lgt_cmt.XML_NCT_NR_NQR.thadsgnm = dao_nqr.fields.thadsgnm
            '        lgt_cmt.XML_NCT_NR_NQR.thakindnm = dao_nqr.fields.thakindnm
            '        lgt_cmt.XML_NCT_NR_NQR.cncnm = dao_nqr.fields.cncnm
            '        lgt_cmt.XML_NCT_NR_NQR.thachngwtnm_thanm = dao_nqr.fields.thachngwtnm_thanm
            '        lgt_cmt.XML_NCT_NR_NQR.cnccsnm = dao_nqr.fields.cnccsnm
            '        lgt_cmt.XML_NCT_NR_NQR.licen_loca = dao_nqr.fields.licen_loca
            '        lgt_cmt.XML_NCT_NR_NQR.thanm = dao_nqr.fields.thanm
            '        lgt_cmt.XML_NCT_NR_NQR.thanm_addr = dao_nqr.fields.thanm_addr
            '        lgt_cmt.XML_NCT_NR_NQR.appdate_th = dao_nqr.fields.appdate_th
            '        lgt_cmt.XML_NCT_NR_NQR.cncdate_th = dao_nqr.fields.cncdate_th
            '        lgt_cmt.XML_NCT_NR_NQR.cncnm2 = dao_nqr.fields.cncnm2
            '        lgt_cmt.XML_NCT_NR_NQR.Newcode = dao_nqr.fields.Newcode
            '        lgt_cmt.XML_NCT_NR_NQR.lcnno = dao_nqr.fields.lcnno
            '        lgt_cmt.XML_NCT_NR_NQR.appdate = dao_nqr.fields.appdate
            '        lgt_cmt.XML_NCT_NR_NQR.expdate = dao_nqr.fields.expdate
            '        lgt_cmt.XML_NCT_NR_NQR.lmdfdate = dao_nqr.fields.lmdfdate
            '        lgt_cmt.XML_NCT_NR_NQR.frtappdate = dao_nqr.fields.frtappdate
            '        lgt_cmt.XML_NCT_NR_NQR.cnsddate = dao_nqr.fields.cnsddate
            '        lgt_cmt.XML_NCT_NR_NQR.cnsddate_th = dao_nqr.fields.cnsddate_th

            '        class_xml.LGT_XML_NCT_NR_NQR_TO.Add(lgt_cmt)
            '    Next
            '    Return class_xml
            'End Function
            Public Function gen_xml_LGT_SEARCH_XML_NCT_NNN(ByVal Newcode As String) As LGTNCT        'ข้อมูลทั่วไปสถานที่ยาเสพติด

                Dim class_xml As New LGTNCT
                Dim dao As New DAO_XML_NCT.TB_XML_NCT_N
                dao.GetDataby_Newcode1(Newcode)
                'dao.get("19")
                'For Each dao.fields In dao.datas
                'class_xml.LGTNCT.NCT = dao.fields
                class_xml.NCT.pvncd = dao.fields.pvncd
                class_xml.NCT.lcnno = dao.fields.lcnno
                class_xml.NCT.lcnsid = dao.fields.lcnsid
                class_xml.NCT.lcntpcd = dao.fields.lcntpcd
                class_xml.NCT.rgttpcd = dao.fields.rgttpcd
                class_xml.NCT.rid = dao.fields.rid
                class_xml.NCT.lcntypecd = dao.fields.lcntypecd
                class_xml.NCT.trdnm = dao.fields.trdnm
                class_xml.NCT.gennm = dao.fields.gennm
                class_xml.NCT.itemtype = dao.fields.itemtype

                class_xml.NCT.appdate = dao.fields.appdate
                class_xml.NCT.expdate = dao.fields.expdate
                class_xml.NCT.GROUPNAME = dao.fields.GROUPNAME
                class_xml.NCT.Newcode = dao.fields.Newcode
                class_xml.NCT.engfrgnnm = dao.fields.engfrgnnm
                class_xml.NCT.cntcd = dao.fields.cntcd
                class_xml.NCT.thanm = dao.fields.thanm
                class_xml.NCT.bsnname = dao.fields.bsnname
                class_xml.NCT.lcntpcdname = dao.fields.lcntpcdname
                class_xml.NCT.thanmlct = dao.fields.thanmlct

                class_xml.NCT.thaaddr = dao.fields.thaaddr
                class_xml.NCT.thasoi = dao.fields.thasoi
                class_xml.NCT.tharoad = dao.fields.tharoad
                class_xml.NCT.MU = dao.fields.MU
                class_xml.NCT.thathmblnm = dao.fields.thathmblnm
                class_xml.NCT.thaamphrnm = dao.fields.thaamphrnm
                class_xml.NCT.thachngwtnm = dao.fields.thachngwtnm
                class_xml.NCT.Tel = dao.fields.Tel
                class_xml.NCT.statusname = dao.fields.statusname
                class_xml.NCT.lcntpcd2 = dao.fields.lcntpcd2

                class_xml.NCT.CITIZEN_AUTHORIZE = dao.fields.CITIZEN_AUTHORIZE
                class_xml.NCT.appdate_th = dao.fields.appdate_th
                class_xml.NCT.expdate_en = dao.fields.expdate_en
                class_xml.NCT.gnrcd = dao.fields.gnrcd
                class_xml.NCT.allow = dao.fields.allow
                class_xml.NCT.licen_addr = dao.fields.licen_addr
                class_xml.NCT.thanm_addr = dao.fields.thanm_addr
                class_xml.NCT.grannm_lo = dao.fields.grannm_lo
                class_xml.NCT.grannm_addr = dao.fields.grannm_addr
                class_xml.NCT.lcnno_no = dao.fields.lcnno_no

                class_xml.NCT.lcntpnm = dao.fields.lcntpnm
                class_xml.NCT.thachngwtnm_thanm = dao.fields.thachngwtnm_thanm
                class_xml.NCT.pvnabbr = dao.fields.pvnabbr
                class_xml.NCT.ask_where = dao.fields.ask_where
                class_xml.NCT.cncnm = dao.fields.cncnm
                class_xml.NCT.rcvno = dao.fields.rcvno
                class_xml.NCT.conventpcd2 = dao.fields.conventpcd2
                class_xml.NCT.CreateDate = dao.fields.CreateDate
                class_xml.NCT.UpdateDate = dao.fields.UpdateDate
                class_xml.NCT.convenst = dao.fields.convenst

                class_xml.NCT.zipcode = dao.fields.zipcode
                class_xml.NCT.thanm_no = dao.fields.thanm_no
                class_xml.NCT.prefix_grannm = dao.fields.prefix_grannm
                class_xml.NCT.ID_card_grannm = dao.fields.ID_card_grannm
                class_xml.NCT.Ranking = dao.fields.Ranking

                class_xml.NCT.grannm = dao.fields.grannm
                class_xml.NCT.prefix_allow = dao.fields.prefix_allow
                class_xml.NCT.allow_name = dao.fields.allow_name
                'Next
                Return class_xml
                '--------------------------------------------------------------------------------'
                'Newcode 
                ''Dim class_xml As New LGTNCT

                ' ''Intial Default Value
                ' ''class_xml.LGT_CMT = AddValue(class_xml.LGT_CMT)
                ''Dim dao As New DAO_FDA_XML_NCT.TB_XML_NCT_N_TEST
                ''dao.GetDataby_Newcode(Newcode)
                ' ''dao.get("19")
                ' ''   For Each dao.fields In dao.datas
                ''class_xml.NCT = dao.fields

                ' ''class_xml.LGTNCT.NCT.lcntpcd = dao.fields.lcntpcd
                ' ''class_xml.LGTNCT.NCT.lcntpcd2 = dao.fields.lcntpcd2
                ' ''class_xml.LGTNCT.NCT.pvncd = dao.fields.pvncd
                ' ''class_xml.LGTNCT.NCT.rid = dao.fields.rid
                ' ''class_xml.LGTNCT.NCT.lcnno = dao.fields.lcnno
                ' ''class_xml.LGTNCT.NCT.lcnsid = dao.fields.lcnsid
                ' ''class_xml.LGTNCT.NCT.appdate = dao.fields.appdate
                ' ''class_xml.LGTNCT.NCT.expdate = dao.fields.expdate
                ' ''class_xml.LGTNCT.NCT.trdnm = dao.fields.trdnm
                ' ''class_xml.LGTNCT.NCT.gennm = dao.fields.gennm
                ' ''class_xml.LGTNCT.NCT.cntcd = dao.fields.cntcd
                ' ''class_xml.LGTNCT.NCT.appdate_th = dao.fields.appdate_th
                ' ''class_xml.LGTNCT.NCT.engfrgnnm = dao.fields.engfrgnnm
                ' ''class_xml.LGTNCT.NCT.gnrcd = dao.fields.gnrcd
                ' ''class_xml.LGTNCT.NCT.allow = dao.fields.allow
                ' ''class_xml.LGTNCT.NCT.licen_addr = dao.fields.licen_addr
                ' ''class_xml.LGTNCT.NCT.thanm = dao.fields.thanm
                ' ''class_xml.LGTNCT.NCT.thanm_addr = dao.fields.thanm_addr
                ' ''class_xml.LGTNCT.NCT.grannm_lo = dao.fields.grannm_lo
                ' ''class_xml.LGTNCT.NCT.grannm_addr = dao.fields.grannm_addr
                ' ''class_xml.LGTNCT.NCT.lcnno_no = dao.fields.lcnno_no
                ' ''class_xml.LGTNCT.NCT.lcntpnm = dao.fields.lcntpnm
                ' ''class_xml.LGTNCT.NCT.thachngwtnm_thanm = dao.fields.thachngwtnm_thanm
                ' ''class_xml.LGTNCT.NCT.thaamphrnm = dao.fields.thaamphrnm
                ' ''class_xml.LGTNCT.NCT.pvnabbr = dao.fields.pvnabbr
                ' ''class_xml.LGTNCT.NCT.ask_where = dao.fields.ask_where
                ' ''class_xml.LGTNCT.NCT.thachngwtnm = dao.fields.thachngwtnm
                ' ''class_xml.LGTNCT.NCT.cncnm = dao.fields.cncnm
                ' ''class_xml.LGTNCT.NCT.GROUPNAME = dao.fields.GROUPNAME
                ' ''class_xml.LGTNCT.NCT.convenst = dao.fields.convenst
                ' ''Next

                ''Return class_xml

            End Function
            Public Function gen_xml_XML_NCT_NR(ByVal Newcode As String) As LGT_XML_NCT_NR_ALL
                Dim class_xml As New LGT_XML_NCT_NR_ALL
                Dim dao As New DAO_XML_NCT.TB_XML_NCT_NR
                dao.GetDataby_Newcode(Newcode)
                'class_xml.LGT_XML_NCT_NR_TO = dao.datas
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.IDA = dao.fields.IDA
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.pvncd = dao.fields.pvncd                                            ' การเลือกฟิลด์ผลิตภัณฑ์มา
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.pvnabbr = dao.fields.pvnabbr
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rgttpcd = dao.fields.rgttpcd
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.rgtno = dao.fields.rgtno
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcntpcd = dao.fields.lcntpcd
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcnsid = dao.fields.lcnsid
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.register = dao.fields.register
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.CITIZEN_AUTHORIZE = dao.fields.CITIZEN_AUTHORIZE
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcntpnm = dao.fields.lcntpnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thadrgnm = dao.fields.thadrgnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.engdrgnm = dao.fields.engdrgnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.drgperunit = dao.fields.drgperunit
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.drgchr = dao.fields.drgchr
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.ctgthanm = dao.fields.ctgthanm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.ctgengnm = dao.fields.ctgengnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thaclassnm = dao.fields.thaclassnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thadsgnm = dao.fields.thadsgnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thakindnm = dao.fields.thakindnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncnm = dao.fields.cncnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thachngwtnm_thanm = dao.fields.thachngwtnm_thanm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cnccsnm = dao.fields.cnccsnm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.licen_loca = dao.fields.licen_loca
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thanm = dao.fields.thanm
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.thanm_addr = dao.fields.thanm_addr
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.appdate_th = dao.fields.appdate_th
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncdate_th = dao.fields.cncdate_th
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.cncnm2 = dao.fields.cncnm2
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.Newcode = dao.fields.Newcode
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lcnno = dao.fields.lcnno
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.appdate = dao.fields.appdate
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.expdate = dao.fields.expdate
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.lmdfdate = dao.fields.lmdfdate
                class_xml.LGT_XML_NCT_NR_ALL_TO.NCT.frtappdate = dao.fields.frtappdate

                Dim dao_newcode_producteng As New DAO_XML_NCT.TB_XML_NCT_FRGN_TO ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_newcode_producteng.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_newcode_producteng.fields In dao_newcode_producteng.datas
                    Dim lgt_cmt As New LGT_XML_NCT_FRGN_TO
                    lgt_cmt.XML_NCT_FRGN_TO.engfrgnnm = dao_newcode_producteng.fields.engfrgnnm
                    lgt_cmt.XML_NCT_FRGN_TO.engcntnm = dao_newcode_producteng.fields.engcntnm
                    lgt_cmt.XML_NCT_FRGN_TO.offengnm = dao_newcode_producteng.fields.offengnm
                    class_xml.LGT_XML_NCT_FRGN_TO.Add(lgt_cmt)
                Next

                Dim dao_AGENT_TO As New DAO_XML_NCT.TB_XML_NCT_AGENT_TO  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_AGENT_TO.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_AGENT_TO.fields In dao_AGENT_TO.datas
                    Dim lgt_cmt As New LGT_XML_NCT_AGENT_TO
                    lgt_cmt.XML_NCT_AGENT_TO.pvncd = dao_AGENT_TO.fields.pvncd
                    lgt_cmt.XML_NCT_AGENT_TO.rgtno = dao_AGENT_TO.fields.rgtno
                    lgt_cmt.XML_NCT_AGENT_TO.agent = dao_AGENT_TO.fields.agent                   'ใส่ชื่อฟิลด์ที่ต้องการแสดง ในแท๊กผลิตภัณฑ์ย่อย
                    lgt_cmt.XML_NCT_AGENT_TO.Newcode = dao_newcode_producteng.fields.Newcode
                    class_xml.LGT_XML_NCT_AGENT_TO.Add(lgt_cmt)
                Next

                Dim dao_COLOR_TO As New DAO_XML_NCT.TB_XML_NCT_COLOR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_COLOR_TO.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_COLOR_TO.fields In dao_COLOR_TO.datas
                    Dim lgt_cmt As New LGT_XML_NCT_COLOR_TO
                    lgt_cmt.XML_NCT_COLOR.shapenm = dao_COLOR_TO.fields.shapenm
                    lgt_cmt.XML_NCT_COLOR.colornm = dao_COLOR_TO.fields.colornm
                    lgt_cmt.XML_NCT_COLOR.Newcode = dao_COLOR_TO.fields.Newcode
                    class_xml.LGT_XML_NCT_COLOR_TO.Add(lgt_cmt)
                Next


                Dim dao_qua As New DAO_XML_NCT.TB_XML_QUALITIES_COLOR_DRUG  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_qua.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_qua.fields In dao_qua.datas
                    Dim lgt_cmt As New LGT_XML_QUALITIES_COLOR_DRUG_TO
                    lgt_cmt.XML_QUALITIES_COLOR_DRUG.drgchr = dao_qua.fields.drgchr
                    lgt_cmt.XML_QUALITIES_COLOR_DRUG.Newcode = dao_qua.fields.Newcode

                    class_xml.LGT_XML_QUALITIES_COLOR_DRUG_TO.Add(lgt_cmt)
                Next
                Dim dao_nqr As New DAO_XML_NCT.TB_XML_NCT_NR_NQR  ' ถ้าเป็น List of1 ต้องใช้อันนี้ด้วย  และ เป็นการเรียกมใช้ DAO ของชื่อผลิตภัณฑ์ย่อย
                dao_nqr.GetDataby_Newcode(dao.fields.Newcode)
                For Each dao_nqr.fields In dao_nqr.datas
                    Dim lgt_cmt As New LGT_XML_NCT_NR_NQR_TO
                    lgt_cmt.XML_NCT_NR_NQR.IDA = dao_nqr.fields.IDA
                    lgt_cmt.XML_NCT_NR_NQR.pvncd = dao_nqr.fields.pvncd                                            ' การเลือกฟิลด์ผลิตภัณฑ์มา
                    lgt_cmt.XML_NCT_NR_NQR.pvnabbr = dao_nqr.fields.pvnabbr
                    lgt_cmt.XML_NCT_NR_NQR.rgttpcd = dao_nqr.fields.rgttpcd
                    lgt_cmt.XML_NCT_NR_NQR.rgtno = dao_nqr.fields.rgtno
                    lgt_cmt.XML_NCT_NR_NQR.rcvno = dao_nqr.fields.rcvno
                    lgt_cmt.XML_NCT_NR_NQR.lcntpcd = dao_nqr.fields.lcntpcd
                    lgt_cmt.XML_NCT_NR_NQR.lcnsid = dao_nqr.fields.lcnsid
                    lgt_cmt.XML_NCT_NR_NQR.register = dao_nqr.fields.register
                    lgt_cmt.XML_NCT_NR_NQR.register_rcvno = dao_nqr.fields.register_rcvno
                    lgt_cmt.XML_NCT_NR_NQR.rcvdate_th = dao_nqr.fields.rcvdate_th
                    lgt_cmt.XML_NCT_NR_NQR.CITIZEN_AUTHORIZE = dao_nqr.fields.CITIZEN_AUTHORIZE
                    lgt_cmt.XML_NCT_NR_NQR.lcntpnm = dao_nqr.fields.lcntpnm
                    lgt_cmt.XML_NCT_NR_NQR.thadrgnm = dao_nqr.fields.thadrgnm
                    lgt_cmt.XML_NCT_NR_NQR.engdrgnm = dao_nqr.fields.engdrgnm
                    lgt_cmt.XML_NCT_NR_NQR.drgperunit = dao_nqr.fields.drgperunit
                    lgt_cmt.XML_NCT_NR_NQR.drgchr = dao_nqr.fields.drgchr
                    lgt_cmt.XML_NCT_NR_NQR.ctgthanm = dao_nqr.fields.ctgthanm
                    lgt_cmt.XML_NCT_NR_NQR.thaclassnm = dao_nqr.fields.thaclassnm
                    lgt_cmt.XML_NCT_NR_NQR.thadsgnm = dao_nqr.fields.thadsgnm
                    lgt_cmt.XML_NCT_NR_NQR.thakindnm = dao_nqr.fields.thakindnm
                    lgt_cmt.XML_NCT_NR_NQR.cncnm = dao_nqr.fields.cncnm
                    lgt_cmt.XML_NCT_NR_NQR.thachngwtnm_thanm = dao_nqr.fields.thachngwtnm_thanm
                    lgt_cmt.XML_NCT_NR_NQR.cnccsnm = dao_nqr.fields.cnccsnm
                    lgt_cmt.XML_NCT_NR_NQR.licen_loca = dao_nqr.fields.licen_loca
                    lgt_cmt.XML_NCT_NR_NQR.thanm = dao_nqr.fields.thanm
                    lgt_cmt.XML_NCT_NR_NQR.thanm_addr = dao_nqr.fields.thanm_addr
                    lgt_cmt.XML_NCT_NR_NQR.appdate_th = dao_nqr.fields.appdate_th
                    lgt_cmt.XML_NCT_NR_NQR.cncdate_th = dao_nqr.fields.cncdate_th
                    lgt_cmt.XML_NCT_NR_NQR.cncnm2 = dao_nqr.fields.cncnm2
                    lgt_cmt.XML_NCT_NR_NQR.Newcode = dao_nqr.fields.Newcode
                    lgt_cmt.XML_NCT_NR_NQR.lcnno = dao_nqr.fields.lcnno
                    lgt_cmt.XML_NCT_NR_NQR.appdate = dao_nqr.fields.appdate
                    lgt_cmt.XML_NCT_NR_NQR.expdate = dao_nqr.fields.expdate
                    lgt_cmt.XML_NCT_NR_NQR.lmdfdate = dao_nqr.fields.lmdfdate
                    lgt_cmt.XML_NCT_NR_NQR.frtappdate = dao_nqr.fields.frtappdate
                    lgt_cmt.XML_NCT_NR_NQR.cnsddate = dao_nqr.fields.cnsddate
                    lgt_cmt.XML_NCT_NR_NQR.cnsddate_th = dao_nqr.fields.cnsddate_th

                    class_xml.LGT_XML_NCT_NR_NQR_TO.Add(lgt_cmt)
                Next
                Return class_xml
            End Function
#End Region
#Region "TXC"
            Public Function gen_xml_XML_TXC_FORMULA_TABEAN(ByVal Newcode As String) As LGT_TXC    'ตัว test ตอนลอง gen DR_สาร  R1 

                Dim class_xml As New LGT_TXC                   'เปลี่ยนเป็นคลาสโครงxmlตัวที่จะใช้
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_XML_TXC(Newcode)
                class_xml.TXC.DT1 = dt

                Dim Newcode_R As String
                For Each dr As DataRow In dt.Rows
                    Newcode_R = dr("Newcode_R")
                    class_xml.TXC.DT2 = bao_show.SP_GENXML_TXC_FORMULA(Newcode_R)
                Next

                Dim package As String
                For Each dr_pack As DataRow In dt.Rows
                    package = dr_pack("Newcode")
                    class_xml.TXC.DT3 = bao_show.SP_GENXML_TXC_PACKAGE(Newcode)
                Next
                Return class_xml
            End Function
            Public Function gen_xml_XML_TXC_FORMULA_WO1(ByVal Newcode As String) As LGT_TXC    'ตัว test ตอนลอง gen DR_สาร  R1 

                Dim class_xml As New LGT_TXC                   'เปลี่ยนเป็นคลาสโครงxmlตัวที่จะใช้
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_XML_TXC(Newcode)
                class_xml.TXC.DT1 = dt

                Dim Newcode_R As String
                For Each dr As DataRow In dt.Rows
                    Newcode_R = dr("Newcode_R")
                    class_xml.TXC.DT2 = bao_show.SP_GENXML_TXC_FORMULA_WO1(Newcode_R)
                Next

                Return class_xml
            End Function

            Public Function gen_xml_XML_TXC_FORMULA_WO2(ByVal Newcode As String) As LGT_TXC    'ตัว test ตอนลอง gen DR_สาร  R1 

                Dim class_xml As New LGT_TXC                   'เปลี่ยนเป็นคลาสโครงxmlตัวที่จะใช้
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_XML_TXC(Newcode)
                class_xml.TXC.DT1 = dt

                Dim Newcode_R As String
                For Each dr As DataRow In dt.Rows
                    Newcode_R = dr("Newcode_R")
                    class_xml.TXC.DT2 = bao_show.SP_GENXML_TXC_FORMULA_WO2(Newcode_R)
                Next

                Dim Newcode_contr As String
                For Each dr As DataRow In dt.Rows
                    Newcode_contr = dr("Newcode_contro")
                    class_xml.TXC.DT3 = bao_show.SP_GENXML_TXC_CONTROLLER_WO2(Newcode_contr)
                Next
                Return class_xml
            End Function
            Public Function gen_xml_XML_TXC_FORMULA_WO3(ByVal Newcode As String) As LGT_TXC    'ตัว test ตอนลอง gen DR_สาร  R1 

                Dim class_xml As New LGT_TXC                   'เปลี่ยนเป็นคลาสโครงxmlตัวที่จะใช้
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_XML_TXC(Newcode)
                class_xml.TXC.DT1 = dt

                Dim Newcode_R As String
                For Each dr As DataRow In dt.Rows
                    Newcode_R = dr("Newcode_R")
                    class_xml.TXC.DT2 = bao_show.SP_GENXML_TXC_FORMULA_WO3(Newcode_R)
                Next

                Dim Newcode_contr As String
                For Each dr As DataRow In dt.Rows
                    Newcode_contr = dr("Newcode_contro")
                    class_xml.TXC.DT3 = bao_show.SP_GENXML_TXC_CONTROLLER_WO3(Newcode_contr)
                Next
                Return class_xml
            End Function

#End Region
#Region "CMT"
#Region "1"
            Public Function gen_xml_XML_CMT_FORMULA1(ByVal Newcode As String) As XML_CMT
                Dim class_xml As New XML_CMT
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                'Dim Newcode As String = fields.Newcode

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1(Newcode)
                For Each dr As DataRow In dt.Rows
                    If IsNothing(dr("brandeng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.brandeng = dr("brandeng").ToString
                    End If


                    If IsNothing(dr("productmain_eng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_eng = dr("productmain_eng").ToString
                    End If


                    If IsNothing(dr("productmain_full")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_full = dr("productmain_full").ToString
                    End If

                    If IsNothing(dr("Newcode_cmt")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.Newcode_cmt = dr("Newcode_cmt").ToString
                    End If


                    Dim Newcode_cmt As String
                    Dim dt_iow As New DataTable
                    Newcode_cmt = dr("Newcode_cmt")
                    dt_iow = bao_show.SP_GENXML_CMT_FORMULA_TYPE1(Newcode_cmt)

                    For Each dr_iow As DataRow In dt_iow.Rows
                        Dim lgt_cmt As New XML_CMT_TO
                        lgt_cmt.CMT_CHEMICAL.rcvno = dr_iow("rcvno")

                        Try
                            lgt_cmt.CMT_CHEMICAL.fdanm = dr_iow("fdanm").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL.percent = dr_iow("percent").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL.casno = dr_iow("casno").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL.cmtpdpstcd = dr_iow("cmtpdpstcd").ToString
                        Catch ex As Exception

                        End Try
                        class_xml.XML_CMT_TO.Add(lgt_cmt)
                    Next
                Next
                Return class_xml
            End Function
#End Region
#Region "2"
            Public Function gen_xml_XML_CMT_FORMULA2(ByVal Newcode As String) As XML_CMT2
                Dim class_xml As New XML_CMT2
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                'Dim Newcode As String = fields.Newcode

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1(Newcode)
                For Each dr As DataRow In dt.Rows
                    If IsNothing(dr("brandeng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.brandeng = dr("brandeng").ToString
                    End If


                    If IsNothing(dr("productmain_eng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_eng = dr("productmain_eng").ToString
                    End If


                    If IsNothing(dr("productmain_full")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_full = dr("productmain_full").ToString
                    End If

                    If IsNothing(dr("Newcode_cmt")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.Newcode_cmt = dr("Newcode_cmt").ToString
                    End If


                    Dim Newcode_cmt As String
                    Dim dt_iow As New DataTable
                    Newcode_cmt = dr("Newcode_cmt")
                    dt_iow = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL2(Newcode_cmt)

                    For Each dr_iow As DataRow In dt_iow.Rows
                        Dim lgt_cmt As New XML_CMT2_TO
                        lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.rcvno = dr_iow("rcvno")

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.productmain_tha = dr_iow("productmain_tha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.productmain_eng = dr_iow("productmain_eng").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.attachnmtha = dr_iow("attachnmtha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.attachnmeng = dr_iow("attachnmeng").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.itemno = dr_iow("itemno").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.cmtpdpstcd = dr_iow("cmtpdpstcd").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL2.NewCode_rid = dr_iow("NewCode_rid").ToString
                        Catch ex As Exception

                        End Try



                        Dim Newcode_rid As String
                        Dim dt_eq As New DataTable
                        Newcode_rid = dr_iow("Newcode_rid")
                        dt_eq = bao_show.SP_GENXML_CMT_FORMULA_TYPE2(Newcode_rid)

                        For Each dr_eq As DataRow In dt_eq.Rows
                            Dim lgt_eq As New XML_CMT2_IOW_TO


                            lgt_eq.CMT_CHEMICAL2.fdanm = dr_eq("fdanm").ToString


                            If IsNothing(dr_eq("percent")) = False Then
                                lgt_eq.CMT_CHEMICAL2.percent = dr_eq("percent").ToString
                            End If
                            If IsNothing(dr_eq("casno")) = False Then
                                lgt_eq.CMT_CHEMICAL2.casno = dr_eq("casno").ToString
                            End If
                            If IsNothing(dr_eq("itemno")) = False Then
                                lgt_eq.CMT_CHEMICAL2.itemno = dr_eq("itemno").ToString
                            End If
                            If IsNothing(dr_eq("Newcode_rid")) = False Then
                                lgt_eq.CMT_CHEMICAL2.Newcode_rid = dr_eq("Newcode_rid").ToString
                            End If
                            'lgt_type2.XML_IOW_EQ_TO.iowanm = dao_XML_CMT_X_TYPE2.fields.iowanm
                            'lgt_type2.XML_IOW_EQ_TO.qty = dao_XML_CMT_X_TYPE2.fields.qty
                            'lgt_type2.XML_IOW_EQ_TO.rid = dao_XML_CMT_X_TYPE2.fields.rid
                            'lgt_type2.XML_IOW_EQ_TO.Newcode_rid = dao_XML_CMT_X_TYPE2.fields.Newcode_rid

                            lgt_cmt.XML_CMT2_IOW_TO.Add(lgt_eq)
                        Next
                        class_xml.XML_CMT2_TO.Add(lgt_cmt)
                    Next
                Next
                Return class_xml
            End Function
#End Region
#Region "3"
            Public Function gen_xml_XML_CMT_FORMULA3(ByVal Newcode As String) As XML_CMT3
                Dim class_xml As New XML_CMT3
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                'Dim Newcode As String = fields.Newcode

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1(Newcode)
                For Each dr As DataRow In dt.Rows
                    If IsNothing(dr("brandeng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.brandeng = dr("brandeng").ToString
                    End If


                    If IsNothing(dr("productmain_eng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_eng = dr("productmain_eng").ToString
                    End If


                    If IsNothing(dr("productmain_full")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_full = dr("productmain_full").ToString
                    End If

                    If IsNothing(dr("Newcode_cmt")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.Newcode_cmt = dr("Newcode_cmt").ToString
                    End If


                    Dim Newcode_cmt As String
                    Dim dt_iow As New DataTable
                    Newcode_cmt = dr("Newcode_cmt")
                    dt_iow = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL3(Newcode_cmt)

                    For Each dr_iow As DataRow In dt_iow.Rows
                        Dim lgt_cmt As New XML_CMT3_TO
                        lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.rcvno = dr_iow("rcvno")

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.productmain_tha = dr_iow("productmain_tha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.productmain_eng = dr_iow("productmain_eng").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.attachnmtha = dr_iow("attachnmtha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.attachnmeng = dr_iow("attachnmeng").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.itemno = dr_iow("itemno").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.cmtpdpstcd = dr_iow("cmtpdpstcd").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL3.NewCode_rid = dr_iow("NewCode_rid").ToString
                        Catch ex As Exception

                        End Try



                        Dim Newcode_rid As String
                        Dim dt_eq As New DataTable
                        Newcode_rid = dr_iow("Newcode_rid")
                        dt_eq = bao_show.SP_GENXML_CMT_FORMULA_TYPE3(Newcode_rid)

                        For Each dr_eq As DataRow In dt_eq.Rows
                            Dim lgt_eq As New XML_CMT3_IOW_TO


                            lgt_eq.CMT_CHEMICAL3.fdanm = dr_eq("fdanm").ToString


                            If IsNothing(dr_eq("percent")) = False Then
                                lgt_eq.CMT_CHEMICAL3.percent = dr_eq("percent").ToString
                            End If
                            If IsNothing(dr_eq("casno")) = False Then
                                lgt_eq.CMT_CHEMICAL3.casno = dr_eq("casno").ToString
                            End If
                            If IsNothing(dr_eq("itemno")) = False Then
                                lgt_eq.CMT_CHEMICAL3.itemno = dr_eq("itemno").ToString
                            End If
                            If IsNothing(dr_eq("Newcode_rid")) = False Then
                                lgt_eq.CMT_CHEMICAL3.NewCode_rid = dr_eq("Newcode_rid").ToString
                            End If
                            'lgt_type2.XML_IOW_EQ_TO.iowanm = dao_XML_CMT_X_TYPE2.fields.iowanm
                            'lgt_type2.XML_IOW_EQ_TO.qty = dao_XML_CMT_X_TYPE2.fields.qty
                            'lgt_type2.XML_IOW_EQ_TO.rid = dao_XML_CMT_X_TYPE2.fields.rid
                            'lgt_type2.XML_IOW_EQ_TO.Newcode_rid = dao_XML_CMT_X_TYPE2.fields.Newcode_rid

                            lgt_cmt.XML_CMT3_IOW_TO.Add(lgt_eq)
                        Next
                        class_xml.XML_CMT3_TO.Add(lgt_cmt)
                    Next
                Next
                Return class_xml
            End Function
#End Region

#Region "4"
            Public Function gen_xml_XML_CMT_FORMULA4(ByVal Newcode As String) As XML_CMT4
                Dim class_xml As New XML_CMT4
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                'Dim Newcode As String = fields.Newcode

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1(Newcode)
                For Each dr As DataRow In dt.Rows
                    If IsNothing(dr("brandeng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.brandeng = dr("brandeng").ToString
                    End If


                    If IsNothing(dr("productmain_eng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_eng = dr("productmain_eng").ToString
                    End If


                    If IsNothing(dr("productmain_full")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_full = dr("productmain_full").ToString
                    End If

                    If IsNothing(dr("Newcode_cmt")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.Newcode_cmt = dr("Newcode_cmt").ToString
                    End If


                    Dim Newcode_cmt As String
                    Dim dt_iow As New DataTable
                    Newcode_cmt = dr("Newcode_cmt")
                    dt_iow = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL4(Newcode_cmt)

                    For Each dr_iow As DataRow In dt_iow.Rows
                        Dim lgt_cmt As New XML_CMT4_TO
                        lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.rcvno = dr_iow("rcvno")

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.productmain_tha = dr_iow("productmain_tha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.productmain_eng = dr_iow("productmain_eng").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.attachnmtha = dr_iow("attachnmtha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.attachnmeng = dr_iow("attachnmeng").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.itemno = dr_iow("itemno").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.cmtpdpstcd = dr_iow("cmtpdpstcd").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL4.NewCode_rid = dr_iow("NewCode_rid").ToString
                        Catch ex As Exception

                        End Try



                        Dim Newcode_rid As String
                        Dim dt_eq As New DataTable
                        Newcode_rid = dr_iow("Newcode_rid")
                        dt_eq = bao_show.SP_GENXML_CMT_FORMULA_TYPE4(Newcode_rid)   'ตารางสารประเภท4 ใช้ตารางเดียวกันกับประเภท1ไม่ได้ เพราะใช้ฟิลด์รีเลชั่นสารคนละฟิลด์

                        For Each dr_eq As DataRow In dt_eq.Rows
                            Dim lgt_eq As New XML_CMT4_IOW_TO


                            lgt_eq.CMT_CHEMICAL.fdanm = dr_eq("fdanm").ToString


                            If IsNothing(dr_eq("percent")) = False Then
                                lgt_eq.CMT_CHEMICAL.percent = dr_eq("percent").ToString
                            End If
                            If IsNothing(dr_eq("casno")) = False Then
                                lgt_eq.CMT_CHEMICAL.casno = dr_eq("casno").ToString
                            End If

                            If IsNothing(dr_eq("Newcode_rid")) = False Then
                                lgt_eq.CMT_CHEMICAL.NewCode_rid = dr_eq("Newcode_rid").ToString
                            End If
                            'lgt_type2.XML_IOW_EQ_TO.iowanm = dao_XML_CMT_X_TYPE2.fields.iowanm
                            'lgt_type2.XML_IOW_EQ_TO.qty = dao_XML_CMT_X_TYPE2.fields.qty
                            'lgt_type2.XML_IOW_EQ_TO.rid = dao_XML_CMT_X_TYPE2.fields.rid
                            'lgt_type2.XML_IOW_EQ_TO.Newcode_rid = dao_XML_CMT_X_TYPE2.fields.Newcode_rid

                            lgt_cmt.XML_CMT4_IOW_TO.Add(lgt_eq)
                        Next
                        class_xml.XML_CMT4_TO.Add(lgt_cmt)
                    Next
                Next
                Return class_xml
            End Function
#End Region
#Region "6"
            Public Function gen_xml_XML_CMT_FORMULA6(ByVal Newcode As String) As XML_CMT6
                Dim class_xml As New XML_CMT6
                Dim bao_show As New BAO_DRUG.BAO_DRUG

                'Dim Newcode As String = fields.Newcode

                Dim dt As New DataTable
                dt = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1(Newcode)
                For Each dr As DataRow In dt.Rows
                    If IsNothing(dr("brandeng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.brandeng = dr("brandeng").ToString
                    End If


                    If IsNothing(dr("productmain_eng")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_eng = dr("productmain_eng").ToString
                    End If


                    If IsNothing(dr("productmain_full")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.productmain_full = dr("productmain_full").ToString
                    End If

                    If IsNothing(dr("Newcode_cmt")) = False Then
                        class_xml.CMT_CHEMICAL_PRODUCT.Newcode_cmt = dr("Newcode_cmt").ToString
                    End If


                    Dim Newcode_cmt As String
                    Dim dt_iow As New DataTable
                    Newcode_cmt = dr("Newcode_cmt")
                    dt_iow = bao_show.SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL6(Newcode_cmt)

                    For Each dr_iow As DataRow In dt_iow.Rows
                        Dim lgt_cmt As New XML_CMT6_TO
                        lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.rcvno = dr_iow("rcvno")

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.productmain_tha = dr_iow("productmain_tha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.productmain_eng = dr_iow("productmain_eng").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.attachnmtha = dr_iow("attachnmtha").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.attachnmeng = dr_iow("attachnmeng").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.itemno = dr_iow("itemno").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.cmtpdpstcd = dr_iow("cmtpdpstcd").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            lgt_cmt.CMT_CHEMICAL_PRODUCT_DETAIL6.NewCode_rid = dr_iow("NewCode_rid").ToString
                        Catch ex As Exception

                        End Try



                        Dim Newcode_rid As String
                        Dim dt_eq As New DataTable
                        Newcode_rid = dr_iow("Newcode_rid")
                        dt_eq = bao_show.SP_GENXML_CMT_FORMULA_TYPE6(Newcode_rid)   'ตารางสารประเภท4 ใช้ตารางเดียวกันกับประเภท1ไม่ได้ เพราะใช้ฟิลด์รีเลชั่นสารคนละฟิลด์

                        For Each dr_eq As DataRow In dt_eq.Rows
                            Dim lgt_eq As New XML_CMT6_IOW_TO


                            lgt_eq.CMT_CHEMICAL6.fdanm = dr_eq("fdanm").ToString


                            If IsNothing(dr_eq("percent")) = False Then
                                lgt_eq.CMT_CHEMICAL6.percent = dr_eq("percent").ToString
                            End If
                            If IsNothing(dr_eq("casno")) = False Then
                                lgt_eq.CMT_CHEMICAL6.casno = dr_eq("casno").ToString
                            End If

                            If IsNothing(dr_eq("Newcode_rid")) = False Then
                                lgt_eq.CMT_CHEMICAL6.NewCode_rid = dr_eq("Newcode_rid").ToString
                            End If
                            'lgt_type2.XML_IOW_EQ_TO.iowanm = dao_XML_CMT_X_TYPE2.fields.iowanm
                            'lgt_type2.XML_IOW_EQ_TO.qty = dao_XML_CMT_X_TYPE2.fields.qty
                            'lgt_type2.XML_IOW_EQ_TO.rid = dao_XML_CMT_X_TYPE2.fields.rid
                            'lgt_type2.XML_IOW_EQ_TO.Newcode_rid = dao_XML_CMT_X_TYPE2.fields.Newcode_rid

                            lgt_cmt.XML_CMT6_IOW_TO.Add(lgt_eq)
                        Next
                        class_xml.XML_CMT6_TO.Add(lgt_cmt)
                    Next
                Next
                Return class_xml
            End Function
#End Region
#End Region

        End Class
    End Class
End Namespace

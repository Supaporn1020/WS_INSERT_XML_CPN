Imports System.Data
Imports System.Data.SqlClient
Namespace BAO_DRUG
    Public Class BAO_DRUG
        Dim cmd As New SqlCommand
        Dim ds As DataSet
        Dim da As SqlDataAdapter

        Public Function Queryds_drug(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim str As String = "Data Source=10.111.28.124;Initial Catalog=FDA_XML_DRUG_ESUB;User ID=fusion;Password=P@ssw0rd;Connect Timeout=80000;"
            Dim MyConnection As New SqlConnection(str)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function

        Public Function Queryds_cpn124(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim str As String = "Data Source=10.111.28.124;Initial Catalog=FDA_XML_CPN;User ID=fusion;Password=P@ssw0rd;Connect Timeout=80000;"
            Dim MyConnection As New SqlConnection(str)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function Queryds_cmt(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim str As String = "Data Source=10.111.28.124;Initial Catalog=FDA_XML_CMT;User ID=fusion;Password=P@ssw0rd"
            Dim MyConnection As New SqlConnection(str)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Function SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_CHEMICAL_PRODUCT_TYPE1"
            Return dt
        End Function
        Public Function SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL3(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL3]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL3"
            Return dt
        End Function
        Public Function SP_GENXML_CMT_FORMULA_TYPE6(ByVal Newcode_rid As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_FORMULA_TYPE6]  @Newcode_rid = '" & Newcode_rid & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_FORMULA_TYPE6"
            Return dt
        End Function
        Public Function SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL6(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL6]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL6"
            Return dt
        End Function
        Public Function SP_GENXML_CMT_FORMULA_TYPE4(ByVal Newcode_rid As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_FORMULA_TYPE4]  @Newcode_rid = '" & Newcode_rid & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_FORMULA_TYPE4"
            Return dt
        End Function

        Public Function SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL4(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL4]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL4"
            Return dt
        End Function
        Public Function SP_GENXML_CMT_FORMULA_TYPE3(ByVal Newcode_rid As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_FORMULA_TYPE3]  @Newcode_rid = '" & Newcode_rid & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_FORMULA_TYPE3"
            Return dt
        End Function
        Public Function Queryds_txc(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim str As String = "Data Source=10.111.28.124;Initial Catalog=FDA_XML_TXC;User ID=fusion;Password=P@ssw0rd"
            Dim MyConnection As New SqlConnection(str)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function

        Public Function SP_XML_SPECIFIC_FOOD(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_XML_SPECIFIC_FOOD]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_XML_SPECIFIC_FOOD"
            Return dt
        End Function
        Public Function SP_GENXML_TXC_PACKAGE(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_PACKAGE] @Newcode = '" & Newcode & "'  "
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_TXC_PACKAGE"
            Return dt
        End Function

        Public Function SP_CPN_CONVERT_TXC_TT(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_TXC_TT] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_TXC_TT"
            Return dt
        End Function
        Public Function SP_CPN_CONVERT_TXC_TC(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_TXC_TC] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_TXC_TC"
            Return dt
        End Function
        Public Function SP_CPN_CONVERT_TXC_TL(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_TXC_TL] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_TXC_TL"
            Return dt
        End Function


        Public Function SP_GENXML_TXC_CONTROLLER_WO2(ByVal Newcode_contro As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_CONTROLLER_WO2] @Newcode_contro = '" & Newcode_contro & "'"
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_TXC_CONTROLLER_WO2"
            Return dt
        End Function
        Public Function SP_GENXML_TXC_FORMULA_WO3(ByVal Newcode_R As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_FORMULA_WO3] @Newcode_R = '" & Newcode_R & "'"
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_TXC_FORMULA_WO3"
            Return dt
        End Function
        Public Function SP_GENXML_TXC_CONTROLLER_WO3(ByVal Newcode_contro As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_CONTROLLER_WO3] @Newcode_contro = '" & Newcode_contro & "'"
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_TXC_CONTROLLER_WO2"
            Return dt
        End Function
        Public Function SP_GENXML_TXC_FORMULA_WO2(ByVal Newcode_R As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_FORMULA_WO2] @Newcode_R = '" & Newcode_R & "'"
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_TXC_FORMULA_WO2"
            Return dt
        End Function
        Public Function SP_GENXML_TXC_FORMULA_WO1(ByVal Newcode_R As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_FORMULA_WO1] @Newcode_R = '" & Newcode_R & "'"
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_TXC_FORMULA_WO1"
            Return dt
        End Function
        Public Function SP_XML_SPECIFIC_FOOD_lct(ByVal lctlcnno As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_XML_SPECIFIC_FOOD_lct] @lctlcnno = '" & lctlcnno & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_XML_SPECIFIC_FOOD_lct"
            Return dt
        End Function

        Public Function SP_GENXML_TXC_FORMULA(ByVal Newcode_R As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_FORMULA] @Newcode_R = '" & Newcode_R & "'"
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_TXC_FORMULA"
            Return dt
        End Function
        Public Function SP_GENXML_XML_TXC(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_XML_TXC] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_txc(sql)
            dt.TableName = "SP_GENXML_XML_TXC"
            Return dt
        End Function
        Public Function SP_XML_SPECIFIC_MDC(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_XML_SPECIFIC_MDC]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_XML_SPECIFIC_MDC"
            Return dt
        End Function
        Public Function SP_CPN_CONVERT_MDC_MA(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_MDC_MA]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_MDC_MA"
            Return dt
        End Function
        Public Function SP_CPN_CONVERT_MDC_MC(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_MDC_MC]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_MDC_MC"
            Return dt
        End Function
        Public Function SP_CPN_CONVERT_MDC_MG(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_MDC_MG]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_MDC_MG"
            Return dt
        End Function

        Public Function SP_CPN_CONVERT_MDC_MN(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_MDC_MN]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_MDC_MN"
            Return dt
        End Function
        Public Function SP_CPN_CONVERT_MDC_MR(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_CONVERT_MDC_MR]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_MDC_MR"
            Return dt
        End Function
        Public Function SP_CPN_SPECIFIC_CMT_TYPE_1(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_SPECIFIC_CMT_TYPE_1]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_SPECIFIC_CMT_TYPE_1"
            Return dt
        End Function
        Public Function SP_GENXML_DRUG_FORMULA_DH15(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_FORMULA_DH15] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_FORMULA_DH15"
            Return dt
        End Function
        Public Function SP_GENXML_SEARCH_DRUG_DH15(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_SEARCH_DRUG_DH15] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_SEARCH_DRUG_DH15"
            Return dt
        End Function
        Public Function SP_CPN_SPECIFIC_CMT_TYPE_4_5(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_SPECIFIC_CMT_TYPE_4_5]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_SPECIFIC_CMT_TYPE_4_5"
            Return dt
        End Function


        Public Function SP_CPN_SPECIFIC_CMT_TYPE_2(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_SPECIFIC_CMT_TYPE_2]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_SPECIFIC_CMT_TYPE_2"
            Return dt
        End Function
        Public Function SP_CPN_SPECIFIC_CMT_TYPE_3_6(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_CPN_SPECIFIC_CMT_TYPE_3_6]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_SPECIFIC_CMT_TYPE_3_6"
            Return dt
        End Function


        Public Function SP_SEARCH_XML_DRUG(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_SEARCH_XML_DRUG]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_SEARCH_XML_DRUG"
            Return dt
        End Function
        'Public Function SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP(ByVal Newcode As String) As DataTable
        '    Dim sql As String = "exec [dbo].[SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP]  @Newcode = '" & Newcode & "'"
        '    Dim dt As New DataTable
        '    dt = Queryds_drug(sql)
        '    dt.TableName = "SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP"
        '    Return dt
        'End Function

        Public Function SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP_HEAD() As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP_HEAD] "
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP_HEAD"
            Return dt
        End Function

        Public Function SP_GENXML_CMT_CHEMICAL_PRODUCT_HEAD(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_CHEMICAL_PRODUCT_HEAD] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_CHEMICAL_PRODUCT_HEAD"
            Return dt
        End Function

        Public Function SP_GENXML_CMT_FORMULA_TYPE1(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_FORMULA_TYPE1]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_FORMULA_TYPE1"
            Return dt
        End Function
        Public Function SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL2(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL2]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_CHEMICAL_PRODUCT_DETAIL2"
            Return dt
        End Function
        Public Function SP_GENXML_CMT_FORMULA_TYPE2(ByVal Newcode_rid As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_CMT_FORMULA_TYPE2]  @Newcode_rid = '" & Newcode_rid & "'"
            Dim dt As New DataTable
            dt = Queryds_cmt(sql)
            dt.TableName = "SP_GENXML_CMT_FORMULA_TYPE2"
            Return dt
        End Function
        Public Function SP_XML_SPECIFIC_DRUG(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_XML_SPECIFIC_DRUG]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_CPN_CONVERT_DRUG"
            Return dt
        End Function
        Public Function SP_XML_SPECIFIC_TXC(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_XML_SPECIFIC_TXC]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_XML_SPECIFIC_TXC"
            Return dt
        End Function

        Public Function SP_XML_SPECIFIC_NCT_N_NC(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_XML_SPECIFIC_NCT_N_NC]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_XML_SPECIFIC_NCT_N_NC"
            Return dt
        End Function

        Public Function SP_GENXML_SEARCH_DRUG_LCN_HEAD(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_SEARCH_DRUG_LCN_HEAD]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_GENXML_SEARCH_DRUG_LCN_HEAD"
            Return dt
        End Function



        Public Function SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_SEARCH_DRUG_PRODUCT_GROUP"
            Return dt
        End Function



        Public Function SP_GENXML_DRUG_RECIPE_GROUPT_TO(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_RECIPE_GROUPT_TO]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_RECIPE_GROUPT_TO"
            Return dt
        End Function
        Public Function SP_GENXML_DRUG_FRGN_TO(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_FRGN_TO]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_FRGN_TO"
            Return dt
        End Function
        Public Function SP_GENXML_DRUG_ANIMAL_DRUGS_TO(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_ANIMAL_DRUGS_TO]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_ANIMAL_DRUGS_TO"
            Return dt
        End Function
        Public Function SP_GENXML_DRUG_ANIMAL_CONSUME_DRUGS_TO(ByVal amlsubnm As String, ByVal amltpnm As String, ByVal usetpnm As String, ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_ANIMAL_CONSUME_DRUGS_TO]  @amlsubnm = '" & amlsubnm & "',@amltpnm = '" & amltpnm & "',@usetpnm = '" & usetpnm & "',@Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_ANIMAL_CONSUME_DRUGS_TO"
            Return dt
        End Function
        Public Function SP_GENXML_DRUG_FORMULA_TO(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_FORMULA_TO]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_FORMULA_TO"
            Return dt
        End Function
        Public Function SP_GENXML_DRUG_FORMULA(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_FORMULA]  @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_FORMULA"
            Return dt
        End Function
        Public Function SP_GENXML_DRUG_FORMULA_EQ_TO(ByVal Newcode_rid As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_FORMULA_EQ_TO]  @Newcode_rid = '" & Newcode_rid & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_FORMULA_EQ_TO"
            Return dt
        End Function

        Public Function SP_SEARCH_XML_DRUG_ALL() As DataTable
            Dim sql As String = "exec [dbo].[SP_SEARCH_XML_DRUG_ALL]"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_SEARCH_XML_DRUG_ALL"
            Return dt
        End Function

        Public Function SP_GENXML_TXC_TABEAN() As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_TXC_TABEAN]"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_TXC_TABEAN"
            Return dt
        End Function

        Public Function SP_GENXML_DRUG_PHARMACY_TO(ByVal Newcode_not As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_PHARMACY_TO] @Newcode_not = '" & Newcode_not & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_PHARMACY_TO"

            Return dt
        End Function
        Public Function SP_GENXML_DRUG_STOWAGR_TO(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_STOWAGR_TO] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_STOWAGR_TO"

            Return dt
        End Function



        Public Function SP_GENXML_DRUG_LCN_LICEN(ByVal Newcode_not As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_DRUG_LCN_LICEN] @Newcode_not = '" & Newcode_not & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_DRUG_LCN_LICEN"

            Return dt
        End Function
        Public Function SP_GENXML_SEARCH_DRUG_LCN(ByVal Newcode_not As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_GENXML_SEARCH_DRUG_LCN] @Newcode_not = '" & Newcode_not & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_GENXML_SEARCH_DRUG_LCN"

            Return dt
        End Function
        Public Function SP_INSERT_DRUG_DR(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_INSERT_DRUG_DR] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_INSERT_DRUG_DR"

            Return dt
        End Function
        Public Function SP_INSERT_DRUG_LCN(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_INSERT_DRUG_LCN] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_INSERT_DRUG_LCN"

            Return dt
        End Function
        Public Function SP_INSERT_DRUG_LCN_PHARMACY(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_INSERT_DRUG_LCN_PHARMACY] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_INSERT_DRUG_LCN_PHARMACY"

            Return dt
        End Function


        Public Function SP_INSERT_DRUG_DP(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_INSERT_DRUG_DP] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_INSERT_DRUG_DP"

            Return dt
        End Function
        Public Function SP_INSERT_DRUG_DS(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_INSERT_DRUG_DS] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_INSERT_DRUG_DS"

            Return dt
        End Function
        Public Function SP_INSERT_DRUG_DI(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_INSERT_DRUG_DI] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_INSERT_DRUG_DI"

            Return dt
        End Function
        Public Function SP_INSERT_DRUG_DH(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_INSERT_DRUG_DH] @Newcode = '" & Newcode & "'"
            Dim dt As New DataTable
            dt = Queryds_drug(sql)
            dt.TableName = "SP_INSERT_DRUG_DH"

            Return dt
        End Function
    End Class
End Namespace






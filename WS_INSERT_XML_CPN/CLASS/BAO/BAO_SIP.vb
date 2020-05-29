Imports System.Data
Imports System.Data.SqlClient
Namespace BAO_SIP
    Public Class BAO_SIP
        Dim cmd As New SqlCommand
        Dim ds As DataSet
        Dim da As SqlDataAdapter
        Public Function Queryds_cpn124(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim str As String = "Data Source=164.115.28.124;Initial Catalog=FDA_XML_CPN;User ID=fusion;Password=P@ssw0rd"
            Dim MyConnection As New SqlConnection(str)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function

        Public Function SP_SPECIFIC_SIP(ByVal Newcode As String) As DataTable
            Dim sql As String = "exec [dbo].[SP_SPECIFIC_SIP] @Newcode = '" & Newcode & "'  "
            Dim dt As New DataTable
            dt = Queryds_cpn124(sql)
            dt.TableName = "SP_SPECIFIC_SIP"
            Return dt
        End Function

    End Class
End Namespace






Namespace DAO_XML_TXC
    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XML_TXCDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_XML_TXC
        Inherits MAINCONTEXT1
        Public fields As New XML_TXC1
        Public Sub insert()
            db_cpn.XML_TXC1s.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub

        Public Sub delete()
            db_cpn.XML_TXC1s.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_TXC1s Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_TXC1s Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_TXC1s Where p.Newcode = Newcode Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

End Namespace
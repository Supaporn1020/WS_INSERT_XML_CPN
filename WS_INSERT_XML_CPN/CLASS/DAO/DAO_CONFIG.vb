Namespace DAO_CONFIG

    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XML_CONFIGDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_XML_CONFIG
        Inherits MAINCONTEXT1
        Public fields As New XML_CONFIG
        Public Sub insert()
            db_cpn.XML_CONFIGs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CONFIGs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub


        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_DRs Where p.GROUPNAME = "DR" And p.Identify = "0105516013339" And p.lcntpcd = "ผย1" Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        ' b.GROUPNAME = 'DR' and b.Identify = '0105516013339'  and b.lcntpcd  = 'ผย1'
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_DRs Where p.rgttpcd <> "G" And p.rgttpcd <> "H" And p.rgttpcd <> "K" And p.rgttpcd <> "L" And p.rgttpcd <> "N" Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_DRs Where p.IDA = "75831" Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_CONFIGs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CONFIGs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CONFIGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class

End Namespace

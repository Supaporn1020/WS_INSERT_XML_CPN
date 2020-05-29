Namespace DAO_XML_DRUG

    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XML_DRUGDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_XML_SEARCH_PRODUCT_GROUP
        Inherits MAINCONTEXT1
        Public fields As New XML_SEARCH_PRODUCT_GROUP
        Public Sub insert()
            db_cpn.XML_SEARCH_PRODUCT_GROUPs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_SEARCH_PRODUCT_GROUPs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_SEARCH_PRODUCT_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_SEARCH_PRODUCT_GROUPs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_SEARCH_PRODUCT_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_SEARCH_PRODUCT_GROUPs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db_cpn.XML_SEARCH_PRODUCT_GROUPs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_SEARCH_DRUG_LCN
        Inherits MAINCONTEXT1
        Public fields As New XML_SEARCH_DRUG_LCN
        Public Sub insert()
            db_cpn.XML_SEARCH_DRUG_LCNs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub

        Public Sub delete()
            db_cpn.XML_SEARCH_DRUG_LCNs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_Newcode(ByVal Newcode As String)
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.Newcode_not = Newcode Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.Newcode_not = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_PHARMACY_TO
        Inherits MAINCONTEXT1
        Public fields As New XML_DRUG_PHARMACY_TO
        Public Sub insert()
            db_cpn.XML_DRUG_PHARMACY_TOs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub

        Public Sub delete()
            db_cpn.XML_DRUG_PHARMACY_TOs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_DRUG_PHARMACY_TOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_DRUG_PHARMACY_TOs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_Newcode(ByVal Newcode As String)
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.Newcode_not = Newcode Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_DRUG_PHARMACY_TOs Where p.Newcode_not = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_SEARCH_DRUG_LCN_LICEN
        Inherits MAINCONTEXT1
        Public fields As New XML_SEARCH_DRUG_LCN_LICEN
        Public Sub insert()
            db_cpn.XML_SEARCH_DRUG_LCN_LICENs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub

        Public Sub delete()
            db_cpn.XML_SEARCH_DRUG_LCN_LICENs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_SEARCH_DRUG_LCN_LICENs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_SEARCH_DRUG_LCN_LICENs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_Newcode(ByVal Newcode As String)
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.Newcode_not = Newcode Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_SEARCH_DRUG_LCN_LICENs Where p.Newcode_not = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace
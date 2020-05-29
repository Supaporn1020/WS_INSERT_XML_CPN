Namespace DAO_XML_CMT
    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XML_CMTDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class

    Public Class TB_LICENSE_HISTORY_CMT
        Inherits MAINCONTEXT1
        Private _Details As New List(Of LICENSE_HISTORY_CMT)
        Public Property Details() As List(Of LICENSE_HISTORY_CMT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of LICENSE_HISTORY_CMT))
                _Details = value
            End Set
        End Property
        Private Sub AddDetails()
            Details.Add(fields)
            fields = New LICENSE_HISTORY_CMT
        End Sub
        Public fields As New LICENSE_HISTORY_CMT
        Public Sub insert()
            db_cpn.LICENSE_HISTORY_CMTs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.LICENSE_HISTORY_CMTs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.LICENSE_HISTORY_CMTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.LICENSE_HISTORY_CMTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.LICENSE_HISTORY_CMTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REF_NO(ByVal REF_NO As String)
            datas = (From p In db_cpn.LICENSE_HISTORY_CMTs Where p.REF_NO = REF_NO Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class

End Namespace
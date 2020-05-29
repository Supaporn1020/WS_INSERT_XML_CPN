Namespace DAO_XML_MDC
    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_FDA_XML_MDCDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_XML_MDC2
        Inherits MAINCONTEXT1

        Public fields As New XML_MDC2
        Public Sub insert()
            db_cpn.XML_MDC2s.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_MDC2s.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_MDC2s Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_MDC2s Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_MDC2s Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_MDC2s Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_doc(ByVal docno As String, ByVal type As String, ByVal groupname As String, ByVal rid As String)
            datas = (From p In db_cpn.XML_MDC2s Where p.Doc_no = docno And p.lcntypecd = type And p.GroupName = groupname And p.itemno = rid Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_LICENSE_HISTORY
        Inherits MAINCONTEXT1
        Private _Details As New List(Of LICENSE_HISTORY)
        Public Property Details() As List(Of LICENSE_HISTORY)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of LICENSE_HISTORY))
                _Details = value
            End Set
        End Property
        Private Sub AddDetails()
            Details.Add(fields)
            fields = New LICENSE_HISTORY
        End Sub
        Public fields As New LICENSE_HISTORY
        Public Sub insert()
            db_cpn.LICENSE_HISTORies.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.LICENSE_HISTORies.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.LICENSE_HISTORies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.LICENSE_HISTORies Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.LICENSE_HISTORies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_REF_NO(ByVal REF_NO As String)
            datas = (From p In db_cpn.LICENSE_HISTORies Where p.REF_NO = REF_NO Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class

End Namespace
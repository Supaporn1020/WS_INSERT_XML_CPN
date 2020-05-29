Namespace DAO_XML

    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XMLDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_XML_FOOD
        Inherits MAINCONTEXT1

        Public fields As New XML_FOOD
        Public Sub insert()
            db_cpn.XML_FOODs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_FOODs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_FOODs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_FOODs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_FOODs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_FOODs Where p.NewCode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CMT
        Inherits MAINCONTEXT1

        Public fields As New XML_CMT
        Public Sub insert()
            db_cpn.XML_CMTs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CMTs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CMTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CMTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CMTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CMTs Where p.NewCode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    'Public Class TB_XML_MDC
    '    Inherits MAINCONTEXT1

    '    Public fields As New XML_MDC2
    '    Public Sub insert()
    '        db_cpn.XML_MDC2s.InsertOnSubmit(fields)
    '        db_cpn.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db_cpn.SubmitChanges()
    '    End Sub
    '    Public Sub delete()
    '        db_cpn.XML_MDC2s.DeleteOnSubmit(fields)
    '        db_cpn.SubmitChanges()
    '    End Sub


    '    'Public Sub GetDataAll()
    '    '    datas = (From p In db_cpn.XML_SEARCH_DRUG_DRs Where p.GROUPNAME = "DR" And p.Identify = "0105516013339" And p.lcntpcd = "ผย1" Select p Order By p.IDA)
    '    '    For Each Me.fields In datas
    '    '    Next
    '    'End Sub
    '    ' b.GROUPNAME = 'DR' and b.Identify = '0105516013339'  and b.lcntpcd  = 'ผย1'
    '    'Public Sub GetDataAll()
    '    '    datas = (From p In db_cpn.XML_SEARCH_DRUG_DRs Where p.rgttpcd <> "G" And p.rgttpcd <> "H" And p.rgttpcd <> "K" And p.rgttpcd <> "L" And p.rgttpcd <> "N" Select p Order By p.IDA)
    '    '    For Each Me.fields In datas
    '    '    Next
    '    'End Sub
    '    'Public Sub GetDataAll()
    '    '    datas = (From p In db_cpn.XML_SEARCH_DRUG_DRs Where p.IDA = "75831" Select p Order By p.IDA)
    '    '    For Each Me.fields In datas
    '    '    Next
    '    'End Sub
    '    Public Sub GetDataAll()
    '        datas = (From p In db_cpn.XML_MDC2s Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub

    '    Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
    '        datas = (From p In db_cpn.XML_MDC2s Where p.IDA = lcnsid Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_IDA(ByVal IDA As Integer)
    '        datas = (From p In db_cpn.XML_MDC2s Where p.IDA = IDA Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
    '        datas = (From p In db_cpn.XML_MDC2s Where p.Newcode = NEWCODE Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class
    Public Class TB_XML_TXC
        Inherits MAINCONTEXT1

        Public fields As New XML_TXC
        Public Sub insert()
            db_cpn.XML_TXCs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_TXCs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_TXCs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_TXCs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_TXCs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_TXCs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace


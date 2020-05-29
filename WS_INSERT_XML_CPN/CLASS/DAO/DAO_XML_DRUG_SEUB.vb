Namespace DAO_XML_DRUG_SEUB

    Public MustInherit Class MAIN_CONTEXT
        Public db As New LGT_XML_DRUG_ESUBDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class

    Public Class TB_XML_DRUG_PHARMACY_ESUB
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_PHARMACY_ESUB
        Public Sub insert()
            db.XML_DRUG_PHARMACY_ESUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_DRUG_PHARMACY_ESUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_PHARMACY_ESUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_PHARMACY_ESUBs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_Newcode(ByVal Newcode As String)
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.Newcode_not = Newcode Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_PHARMACY_ESUBs Where p.Newcode_not = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_SEARCH_DRUG_LCN_ESUB
        Inherits MAIN_CONTEXT
        Public fields As New XML_SEARCH_DRUG_LCN_ESUB
        Public Sub insert()
            db.XML_SEARCH_DRUG_LCN_ESUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub delete()
            db.XML_SEARCH_DRUG_LCN_ESUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_Newcode(ByVal Newcode As String)
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.Newcode_not = Newcode Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_SEARCH_DRUG_LCN_ESUBs Where p.Newcode_not = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_SEARCH_PRODUCT_GROUP_ESUB
        Inherits MAIN_CONTEXT
        Public fields As New XML_SEARCH_PRODUCT_GROUP_ESUB
        Public Sub insert()
            db.XML_SEARCH_PRODUCT_GROUP_ESUBs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_SEARCH_PRODUCT_GROUP_ESUBs.DeleteOnSubmit(fields)
            db.SubmitChanges()
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
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db.XML_SEARCH_PRODUCT_GROUP_ESUBs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    'Public Class XML_STOWAGR
    '    Inherits MAIN_CONTEXT

    '    Public fields As New XML_STOWAGR

    '    Private _Details As New List(Of XML_STOWAGR)
    '    Public Property Details() As List(Of XML_STOWAGR)
    '        Get
    '            Return _Details
    '        End Get
    '        Set(ByVal value As List(Of XML_STOWAGR))
    '            _Details = value
    '        End Set
    '    End Property

    '    Private Sub AddDetails()
    '        Details.Add(fields)
    '        fields = New XML_STOWAGR
    '    End Sub
    '    Public Sub GetDataby_Newcode(ByVal Newcode As String)
    '        datas = (From p In db.XML_STOWAGRs Where p.Newcode = Newcode Select p)
    '        For Each Me.fields In datas
    '            AddDetails()
    '        Next
    '    End Sub
    'End Class
    Public Class TB_XML_DRUG_STOWAGR
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_STOWAGR
        Public Sub insert()
            db.XML_DRUG_STOWAGRs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_STOWAGRs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_STOWAGRs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_STOWAGRs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_RECIPE_GROUP
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_RECIPE_GROUP
        Public Sub insert()
            db.XML_DRUG_RECIPE_GROUPs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_RECIPE_GROUPs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_RECIPE_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_RECIPE_GROUPs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_ANIMAL
        Public Sub insert()
            db.XML_DRUG_ANIMALs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_ANIMALs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_ANIMALs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_ANIMALs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_ANIMAL_CONSUME
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_ANIMAL_CONSUME
        Public Sub insert()
            db.XML_DRUG_ANIMAL_CONSUMEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_ANIMAL_CONSUMEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_animal_consume(ByVal ampartnm As String, amlsubnm As String, ByVal amltpnm As String, ByVal usetpnm As String, ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_ANIMAL_CONSUMEs Where p.ampartnm = ampartnm And p.amlsubnm = amlsubnm And p.amltpnm = amltpnm And p.usetpnm = usetpnm And p.Newcode = Newcode Select p)
            For Each Me.fields In datas

            Next
        End Sub

    End Class
    Public Class TB_XML_DRUG_IOW
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_IOW
        Public Sub insert()
            db.XML_DRUG_IOWs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_IOWs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db.XML_IOW_TOs Where p.aori = "A" Select p Order By p.aori)
        '    For Each Me.fields In datas
        '    Next
        'End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_IOWs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        'Public Sub GetDataby_Year_PVNCD_PROCESS_ID_MAX(ByVal PVNCD As String, ByVal YEARS As Integer, ByVal PROCESS_ID As String)
        '    datas = (From p In db.XML_DRUG_IOWs Where p.pvncd = PVNCD And p.YEAR = YEARS And p.PROCESS_ID = PROCESS_ID Order By p.GENNO Descending Select p).Take(1)
        '    For Each Me.fields In datas
        '    Next
        'End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_IOWs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String, ByVal flineno As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_U = Newcode_U And p.flineno = flineno Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_U_GROUP(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_U = Newcode_U Group p By p.flineno Into Group
                     Select New With {flineno})
        End Sub

        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_IOWs Where p.Newcode_U = Newcode_U Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_IOW_EQ
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_IOW_EQ
        Public Sub insert()
            db.XML_DRUG_IOW_EQs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_IOW_EQs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db.XML_IOW_EQ_TOs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_IOW_EQs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_RID(ByVal Newcode_RID As String)
            datas = (From p In db.XML_DRUG_IOW_EQs Where p.Newcode_rid = Newcode_RID Select p Order By p.rid)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_XML_DRUG_FRGN
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_FRGN
        Public Sub insert()
            db.XML_DRUG_FRGNs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_FRGNs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_FRGNs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_FRGNs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_FRGNs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_U(ByVal Newcode_U As String)
            datas = (From p In db.XML_DRUG_FRGNs Where p.Newcode_U = Newcode_U Select p)
            For Each Me.fields In datas
            Next
        End Sub


    End Class
    Public Class TB_XML_DRUG_EXPORT
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_EXPORT


        Private _Details As New List(Of XML_DRUG_EXPORT)
        Public Property Details() As List(Of XML_DRUG_EXPORT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_EXPORT))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_EXPORT
        End Sub
        Public Sub insert()
            db.XML_DRUG_EXPORTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_EXPORTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_EXPORTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_EXPORTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_EXPORTs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_COLOR
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_COLOR


        Private _Details As New List(Of XML_DRUG_COLOR)
        Public Property Details() As List(Of XML_DRUG_COLOR)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_COLOR))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_COLOR
        End Sub
        Public Sub insert()
            db.XML_DRUG_COLORs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_COLORs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_COLORs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_COLORs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_COLORs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_AGENT
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_AGENT


        Private _Details As New List(Of XML_DRUG_AGENT)
        Public Property Details() As List(Of XML_DRUG_AGENT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_AGENT))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_AGENT
        End Sub
        Public Sub insert()
            db.XML_DRUG_AGENTs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_AGENTs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_AGENTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_AGENTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_AGENTs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_STORY_EDIT_HISTORY
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_STORY_EDIT_HISTORY


        Private _Details As New List(Of XML_DRUG_STORY_EDIT_HISTORY)
        Public Property Details() As List(Of XML_DRUG_STORY_EDIT_HISTORY)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_STORY_EDIT_HISTORY))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_STORY_EDIT_HISTORY
        End Sub
        Public Sub insert()
            db.XML_DRUG_STORY_EDIT_HISTORies.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_STORY_EDIT_HISTORies.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_STORY_EDIT_HISTORies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_STORY_EDIT_HISTORies Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_STORY_EDIT_HISTORies Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONDITION_TABEAN
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_CONDITION_TABEAN


        Private _Details As New List(Of XML_DRUG_CONDITION_TABEAN)
        Public Property Details() As List(Of XML_DRUG_CONDITION_TABEAN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONDITION_TABEAN))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONDITION_TABEAN
        End Sub
        Public Sub insert()
            db.XML_DRUG_CONDITION_TABEANs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_CONDITION_TABEANs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_CONDITION_TABEANs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CONDITION_TABEANs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CONDITION_TABEANs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_DOC_PDF
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_DOC_PDF


        Private _Details As New List(Of XML_DRUG_DOC_PDF)
        Public Property Details() As List(Of XML_DRUG_DOC_PDF)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_DOC_PDF))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_DOC_PDF
        End Sub
        Public Sub insert()
            db.XML_DRUG_DOC_PDFs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_DOC_PDFs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_DOC_PDFs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_DOC_PDFs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_DOC_PDFs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_SPC
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_SPC


        Private _Details As New List(Of XML_DRUG_SPC)
        Public Property Details() As List(Of XML_DRUG_SPC)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_SPC))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_SPC
        End Sub
        Public Sub insert()
            db.XML_DRUG_SPCs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_SPCs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_SPCs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_SPCs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_SPCs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_PI
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_PI


        Private _Details As New List(Of XML_DRUG_PI)
        Public Property Details() As List(Of XML_DRUG_PI)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_PI))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_PI
        End Sub
        Public Sub insert()
            db.XML_DRUG_PIs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_PIs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_PIs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_PIs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_PIs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_PIL
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_PIL


        Private _Details As New List(Of XML_DRUG_PIL)
        Public Property Details() As List(Of XML_DRUG_PIL)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_PIL))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_PIL
        End Sub
        Public Sub insert()
            db.XML_DRUG_PILs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_PILs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_PILs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_PILs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_PILs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_SOURCE_OF_RM
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_SOURCE_OF_RM


        Private _Details As New List(Of XML_DRUG_SOURCE_OF_RM)
        Public Property Details() As List(Of XML_DRUG_SOURCE_OF_RM)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_SOURCE_OF_RM))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_SOURCE_OF_RM
        End Sub
        Public Sub insert()
            db.XML_DRUG_SOURCE_OF_RMs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_SOURCE_OF_RMs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_SOURCE_OF_RMs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_SOURCE_OF_RMs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_SOURCE_OF_RMs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_CODE
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_CODE


        Private _Details As New List(Of XML_DRUG_CODE)
        Public Property Details() As List(Of XML_DRUG_CODE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CODE))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CODE
        End Sub
        Public Sub insert()
            db.XML_DRUG_CODEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_CODEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_CODEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CODEs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CODEs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONTAIN
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_CONTAIN


        Private _Details As New List(Of XML_DRUG_CONTAIN)
        Public Property Details() As List(Of XML_DRUG_CONTAIN)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONTAIN))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONTAIN
        End Sub
        Public Sub insert()
            db.XML_DRUG_CONTAINs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_CONTAINs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_CONTAINs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CONTAINs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CONTAINs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_XML_DRUG_CONTROL_ANALYZE
        Inherits MAIN_CONTEXT
        Public fields As New XML_DRUG_CONTROL_ANALYZE


        Private _Details As New List(Of XML_DRUG_CONTROL_ANALYZE)
        Public Property Details() As List(Of XML_DRUG_CONTROL_ANALYZE)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_DRUG_CONTROL_ANALYZE))
                _Details = value
            End Set
        End Property

        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_DRUG_CONTROL_ANALYZE
        End Sub
        Public Sub insert()
            db.XML_DRUG_CONTROL_ANALYZEs.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.XML_DRUG_CONTROL_ANALYZEs.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.XML_DRUG_CONTROL_ANALYZEs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db.XML_DRUG_CONTROL_ANALYZEs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db.XML_DRUG_CONTROL_ANALYZEs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class
    Public Class TB_tb_log_temp
        Inherits MAIN_CONTEXT
        Public fields As New tb_log_temp
        Public Sub insert()
            db.tb_log_temps.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub update()
            db.SubmitChanges()
        End Sub
        Public Sub delete()
            db.tb_log_temps.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub
        Public Sub GetDataAll()
            datas = (From p In db.tb_log_temps Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace
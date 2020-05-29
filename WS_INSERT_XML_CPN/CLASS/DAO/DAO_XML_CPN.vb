Namespace DAO_XML_CPN

    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XML_CPNDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    Public Class TB_XML_CPN_KEEP_PATH
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_PATH
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_PATHs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_PATHs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_PATHs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_PATHs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_PATHs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next

        End Sub

        Public Sub GetDataby_GROUPNAME(ByVal GROUPNAME As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_PATHs Where p.GROUPNAME = GROUPNAME Select p)
            For Each Me.fields In datas
            Next
        End Sub


        Public Sub GetDataby_TYPE_DESCRIPTION(ByVal TYPE_DESCRIPTION As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_PATHs Where p.TYPE_DESCRIPTION = TYPE_DESCRIPTION Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_GROUPNAME_TYPE(ByVal GROUPNAME As String, ByVal TYPE_DESCRIPTION As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_PATHs Where p.GROUPNAME = GROUPNAME And p.TYPE_DESCRIPTION = TYPE_DESCRIPTION Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_PATH_GROUPNAME(ByVal XML_SQL As String, ByVal groupname As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_PATHs Where p.XML_SQL = XML_SQL And p.GROUPNAME = groupname Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_DRUG
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_DRUG
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_DRUGs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_DRUGs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_DRUGs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_DRUGs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_DRUGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_DRUGs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_FOOD
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_FOOD
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_FOODs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_FOODs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_FOODs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOODs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOODs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOODs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_fdp13(ByVal fdpdtno As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOODs Where p.fdpdtno = fdpdtno Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_FOOD_TEMP
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_FOOD_TEMP
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_FOOD_TEMPs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_FOOD_TEMPs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_FOOD_TEMPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOOD_TEMPs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOOD_TEMPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOOD_TEMPs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_fdp13(ByVal fdpdtno As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_FOOD_TEMPs Where p.fdpdtno = fdpdtno Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_CMT
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_CMT
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_CMTs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_CMTs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_CMTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_CMTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_CMTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_CMTs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_MDC
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_MDC
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_MDCs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_MDCs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_MDCs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_MDCs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_MDCs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_MDCs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_XML_CPN_KEEP_MDC_TEMP
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_MDC_TEMP
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_MDC_TEMPs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_MDC_TEMPs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_MDC_TEMPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_MDC_TEMPs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_MDC_TEMPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            db_cpn.CommandTimeout = 0
            datas = (From p In db_cpn.XML_CPN_KEEP_MDC_TEMPs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_TXC
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_TXC
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_TXCs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_TXCs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_TXCs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_TXCs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_TXCs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_TXCs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_NCT
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_NCT
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_NCTs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_NCTs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_NCTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_NCTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_NCTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_NCTs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_CPN_KEEP_SIP
        Inherits MAINCONTEXT1
        'Private _Details As New List(Of XML_NCT)
        'Public Property Details() As List(Of XML_NCT)
        '    Get
        '        Return _Details
        '    End Get
        '    Set(ByVal value As List(Of XML_NCT))
        '        _Details = value
        '    End Set
        'End Property

        'Private Sub AddDetails()
        '    Details.Add(fields)
        '    fields = New XML_CPN_KEEP_FOOD
        'End Sub
        Public fields As New XML_CPN_KEEP_SIP
        Public Sub insert()
            db_cpn.XML_CPN_KEEP_SIPs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_CPN_KEEP_SIPs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_CPN_KEEP_SIPs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_SIPs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_CPN_KEEP_SIPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal NEWCODE As String)
            datas = (From p In db_cpn.XML_CPN_KEEP_SIPs Where p.Newcode = NEWCODE Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
End Namespace

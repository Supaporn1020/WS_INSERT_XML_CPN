Namespace DAO_XML_FOOD
    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XML_FOODDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class

    Public Class TB_XML_FOOD_EDIT_HISTORY
        Inherits MAINCONTEXT1
        Private _Details As New List(Of XML_FOOD_EDIT_HISTORY)
        Public Property Details() As List(Of XML_FOOD_EDIT_HISTORY)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_FOOD_EDIT_HISTORY))
                _Details = value
            End Set
        End Property
        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_FOOD_EDIT_HISTORY
        End Sub
        Public fields As New XML_FOOD_EDIT_HISTORY
        Public Sub insert()
            db_cpn.XML_FOOD_EDIT_HISTORies.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_FOOD_EDIT_HISTORies.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_FOOD_EDIT_HISTORies Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_FOOD_EDIT_HISTORies Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_FOOD_EDIT_HISTORies Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FDPDTNO(ByVal FDPDTNO As String)
            datas = (From p In db_cpn.XML_FOOD_EDIT_HISTORies Where p.FDPDTNO = FDPDTNO Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub
    End Class

    Public Class TB_XML_FOOD_PRODUCT
        Inherits MAINCONTEXT1
        Private _Details As New List(Of XML_FOOD_PRODUCT)
        Public Property Details() As List(Of XML_FOOD_PRODUCT)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of XML_FOOD_PRODUCT))
                _Details = value
            End Set
        End Property
        Private Sub AddDetails()
            Details.Add(fields)
            fields = New XML_FOOD_PRODUCT
        End Sub
        Public fields As New XML_FOOD_PRODUCT
        Public Sub insert()
            db_cpn.XML_FOOD_PRODUCTs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_FOOD_PRODUCTs.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.XML_FOOD_PRODUCTs Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_FOOD_PRODUCTs Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_FOOD_PRODUCTs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FDPDTNO(ByVal FDPDTNO As String)
            datas = (From p In db_cpn.XML_FOOD_PRODUCTs Where p.fdpdtno = FDPDTNO Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetDataby_Newcode(ByVal NewCode As String)
            datas = (From p In db_cpn.XML_FOOD_PRODUCTs Where p.NewCode = NewCode Select p)
            For Each Me.fields In datas

            Next
        End Sub
        Public Sub GetDatabyfdpdtno(ByVal fdpdtno As String)
            datas = (From p In db_cpn.XML_FOOD_PRODUCTs Where p.fdpdtno = fdpdtno Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
    Public Class TB_tb_log_temp_food
        Inherits MAINCONTEXT1
        Private _Details As New List(Of tb_log_temp_food)
        Public Property Details() As List(Of tb_log_temp_food)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of tb_log_temp_food))
                _Details = value
            End Set
        End Property
        Private Sub AddDetails()
            Details.Add(fields)
            fields = New tb_log_temp_food
        End Sub
        Public fields As New tb_log_temp_food
        Public Sub insert()
            db_cpn.tb_log_temp_foods.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.tb_log_temp_foods.DeleteOnSubmit(fields)
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
            datas = (From p In db_cpn.tb_log_temp_foods Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.tb_log_temp_foods Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.tb_log_temp_foods Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_FDPDTNO(ByVal FDPDTNO As String)
            datas = (From p In db_cpn.tb_log_temp_foods Where p.fdpdtno = FDPDTNO Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub


        Public Sub GetDatabyfdpdtno(ByVal fdpdtno As String)
            datas = (From p In db_cpn.tb_log_temp_foods Where p.fdpdtno = fdpdtno Select p)
            For Each Me.fields In datas

            Next
        End Sub
    End Class
End Namespace
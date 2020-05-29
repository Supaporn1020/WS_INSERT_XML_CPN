Public Class CMT_CHEMICAL_PRODUCT
    Private _brandeng As String
    Public Property brandeng() As String
        Get
            Return _brandeng
        End Get
        Set(ByVal value As String)
            _brandeng = value
        End Set
    End Property

    Private _productmain_full As String
    Public Property productmain_full() As String
        Get
            Return _productmain_full
        End Get
        Set(ByVal value As String)
            _productmain_full = value
        End Set
    End Property

    Private _productmain_eng As String
    Public Property productmain_eng() As String
        Get
            Return _productmain_eng
        End Get
        Set(ByVal value As String)
            _productmain_eng = value
        End Set
    End Property
    Private _Newcode_cmt As String
    Public Property Newcode_cmt() As String
        Get
            Return _Newcode_cmt
        End Get
        Set(ByVal value As String)
            _Newcode_cmt = value
        End Set
    End Property
End Class

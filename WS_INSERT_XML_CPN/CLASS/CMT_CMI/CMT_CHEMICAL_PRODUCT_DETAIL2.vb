Public Class CMT_CHEMICAL_PRODUCT_DETAIL2
    Private _rcvno As String
    Public Property rcvno() As String
        Get
            Return _rcvno
        End Get
        Set(ByVal value As String)
            _rcvno = value
        End Set
    End Property

    Private _productmain_tha As String
    Public Property productmain_tha() As String
        Get
            Return _productmain_tha
        End Get
        Set(ByVal value As String)
            _productmain_tha = value
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

    Private _attachnmtha As String
    Public Property attachnmtha() As String
        Get
            Return _attachnmtha
        End Get
        Set(ByVal value As String)
            _attachnmtha = value
        End Set
    End Property
    Private _attachnmeng As String
    Public Property attachnmeng() As String
        Get
            Return _attachnmeng
        End Get
        Set(ByVal value As String)
            _attachnmeng = value
        End Set
    End Property

    Private _itemno As String
    Public Property itemno() As String
        Get
            Return _itemno
        End Get
        Set(ByVal value As String)
            _itemno = value
        End Set
    End Property

    Private _cmtpdpstcd As String
    Public Property cmtpdpstcd() As String
        Get
            Return _cmtpdpstcd
        End Get
        Set(ByVal value As String)
            _cmtpdpstcd = value
        End Set
    End Property

    Private _NewCode_rid As String
    Public Property NewCode_rid() As String
        Get
            Return _NewCode_rid
        End Get
        Set(ByVal value As String)
            _NewCode_rid = value
        End Set
    End Property

End Class

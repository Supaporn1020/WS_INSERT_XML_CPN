Public Class XML_IOW_EQ_TO
    Private _IDA As String
    Public Property IDA() As String
        Get
            Return _IDA
        End Get
        Set(ByVal value As String)
            _IDA = value
        End Set
    End Property
    Private _rid As String
    Public Property rid() As String
        Get
            Return _rid
        End Get
        Set(ByVal value As String)
            _rid = value
        End Set
    End Property
    Private _qty As String
    Public Property qty() As String
        Get
            Return _qty
        End Get
        Set(ByVal value As String)
            _qty = value
        End Set
    End Property
    Private _Newcode_rid As String
    Public Property Newcode_rid() As String
        Get
            Return _Newcode_rid
        End Get
        Set(ByVal value As String)
            _Newcode_rid = value
        End Set
    End Property
    Private _iowanm As String
    Public Property iowanm() As String
        Get
            Return _iowanm
        End Get
        Set(ByVal value As String)
            _iowanm = value
        End Set
    End Property
End Class

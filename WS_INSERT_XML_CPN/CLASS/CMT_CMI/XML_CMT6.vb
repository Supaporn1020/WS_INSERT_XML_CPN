Public Class XML_CMT6
    Private _CMT_CHEMICAL_PRODUCT As New CMT_CHEMICAL_PRODUCT
    Public Property CMT_CHEMICAL_PRODUCT() As CMT_CHEMICAL_PRODUCT
        Get
            Return _CMT_CHEMICAL_PRODUCT
        End Get
        Set(ByVal value As CMT_CHEMICAL_PRODUCT)
            _CMT_CHEMICAL_PRODUCT = value
        End Set
    End Property
    Private _XML_CMT6_TO As New List(Of XML_CMT6_TO)
    Public Property XML_CMT6_TO() As List(Of XML_CMT6_TO)
        Get
            Return _XML_CMT6_TO
        End Get
        Set(ByVal value As List(Of XML_CMT6_TO))
            _XML_CMT6_TO = value
        End Set
    End Property
End Class

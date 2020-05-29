Public Class XML_CMT
    Private _CMT_CHEMICAL_PRODUCT As New CMT_CHEMICAL_PRODUCT
    Public Property CMT_CHEMICAL_PRODUCT() As CMT_CHEMICAL_PRODUCT
        Get
            Return _CMT_CHEMICAL_PRODUCT
        End Get
        Set(ByVal value As CMT_CHEMICAL_PRODUCT)
            _CMT_CHEMICAL_PRODUCT = value
        End Set
    End Property

    Private _XML_CMT_TO As New List(Of XML_CMT_TO)
    Public Property XML_CMT_TO() As List(Of XML_CMT_TO)
        Get
            Return _XML_CMT_TO
        End Get
        Set(ByVal value As List(Of XML_CMT_TO))
            _XML_CMT_TO = value
        End Set
    End Property
End Class

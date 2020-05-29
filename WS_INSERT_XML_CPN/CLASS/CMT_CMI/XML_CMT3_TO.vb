Public Class XML_CMT3_TO
    Private _CMT_CHEMICAL_PRODUCT_DETAIL3 As New CMT_CHEMICAL_PRODUCT_DETAIL3
    Public Property CMT_CHEMICAL_PRODUCT_DETAIL3() As CMT_CHEMICAL_PRODUCT_DETAIL3
        Get
            Return _CMT_CHEMICAL_PRODUCT_DETAIL3
        End Get
        Set(ByVal value As CMT_CHEMICAL_PRODUCT_DETAIL3)
            _CMT_CHEMICAL_PRODUCT_DETAIL3 = value
        End Set
    End Property
    Private _XML_CMT3_IOW_TO As New List(Of XML_CMT3_IOW_TO)
    Public Property XML_CMT3_IOW_TO() As List(Of XML_CMT3_IOW_TO)
        Get
            Return _XML_CMT3_IOW_TO
        End Get
        Set(ByVal value As List(Of XML_CMT3_IOW_TO))
            _XML_CMT3_IOW_TO = value
        End Set
    End Property
End Class

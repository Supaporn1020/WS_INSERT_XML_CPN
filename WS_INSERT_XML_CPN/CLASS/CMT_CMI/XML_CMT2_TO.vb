Public Class XML_CMT2_TO
    Private _CMT_CHEMICAL_PRODUCT_DETAIL2 As New CMT_CHEMICAL_PRODUCT_DETAIL2
    Public Property CMT_CHEMICAL_PRODUCT_DETAIL2() As CMT_CHEMICAL_PRODUCT_DETAIL2
        Get
            Return _CMT_CHEMICAL_PRODUCT_DETAIL2
        End Get
        Set(ByVal value As CMT_CHEMICAL_PRODUCT_DETAIL2)
            _CMT_CHEMICAL_PRODUCT_DETAIL2 = value
        End Set
    End Property
    Private _XML_CMT2_IOW_TO As New List(Of XML_CMT2_IOW_TO)
    Public Property XML_CMT2_IOW_TO() As List(Of XML_CMT2_IOW_TO)
        Get
            Return _XML_CMT2_IOW_TO
        End Get
        Set(ByVal value As List(Of XML_CMT2_IOW_TO))
            _XML_CMT2_IOW_TO = value
        End Set
    End Property
End Class

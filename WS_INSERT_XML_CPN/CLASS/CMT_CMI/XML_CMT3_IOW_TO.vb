Public Class XML_CMT3_IOW_TO
    Private _CMT_CHEMICAL3 As New CMT_CHEMICAL3
    Public Property CMT_CHEMICAL3() As CMT_CHEMICAL3
        Get
            Return _CMT_CHEMICAL3
        End Get
        Set(ByVal value As CMT_CHEMICAL3)
            _CMT_CHEMICAL3 = value
        End Set
    End Property
End Class

Public Class XML_CMT4_IOW_TO
    Private _CMT_CHEMICAL As New CMT_CHEMICAL
    Public Property CMT_CHEMICAL() As CMT_CHEMICAL
        Get
            Return _CMT_CHEMICAL
        End Get
        Set(ByVal value As CMT_CHEMICAL)
            _CMT_CHEMICAL = value
        End Set
    End Property
End Class

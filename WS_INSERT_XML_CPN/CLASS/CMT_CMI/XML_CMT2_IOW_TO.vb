Public Class XML_CMT2_IOW_TO
    Private _CMT_CHEMICAL2 As New CMT_CHEMICAL2
    Public Property CMT_CHEMICAL2() As CMT_CHEMICAL2
        Get
            Return _CMT_CHEMICAL2
        End Get
        Set(ByVal value As CMT_CHEMICAL2)
            _CMT_CHEMICAL2 = value
        End Set
    End Property
End Class

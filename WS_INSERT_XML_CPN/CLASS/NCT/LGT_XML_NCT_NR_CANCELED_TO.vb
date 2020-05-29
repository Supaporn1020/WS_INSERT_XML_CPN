Public Class LGT_XML_NCT_NR_CANCELED_TO
    Private _XML_NCT_NR_CANCELED As New XML_NCT_NR_CANCELED
    Public Property XML_NCT_NR_CANCELED() As XML_NCT_NR_CANCELED
        Get
            Return _XML_NCT_NR_CANCELED
        End Get
        Set(ByVal value As XML_NCT_NR_CANCELED)
            _XML_NCT_NR_CANCELED = value
        End Set
    End Property
End Class

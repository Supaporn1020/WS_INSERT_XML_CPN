Public Class LGT_XML_FRGN_ALL_TO
    Private _XML_FRGN As New XML_FRGN
    Public Property XML_FRGN() As XML_FRGN
        Get
            Return _XML_FRGN
        End Get
        Set(ByVal value As XML_FRGN)
            _XML_FRGN = value
        End Set
    End Property
End Class

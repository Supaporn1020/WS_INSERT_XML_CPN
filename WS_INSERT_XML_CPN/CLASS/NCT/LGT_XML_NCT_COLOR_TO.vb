Public Class LGT_XML_NCT_COLOR_TO
    Private _XML_NCT_COLOR As New XML_NCT_COLOR
    Public Property XML_NCT_COLOR() As XML_NCT_COLOR
        Get
            Return _XML_NCT_COLOR
        End Get
        Set(ByVal value As XML_NCT_COLOR)
            _XML_NCT_COLOR = value
        End Set
    End Property
End Class

Public Class LGT_XML_NCT_FRGN
    Private _XML_NCT_NR As New XML_NCT_NR
    Public Property XML_NCT_NR() As XML_NCT_NR
        Get
            Return _XML_NCT_NR
        End Get
        Set(ByVal value As XML_NCT_NR)
            _XML_NCT_NR = value
        End Set
    End Property

    Private _LGT_XML_NCT_FRGN_TO As New List(Of LGT_XML_NCT_FRGN_TO)
    Public Property LGT_XML_NCT_FRGN_TO() As List(Of LGT_XML_NCT_FRGN_TO)
        Get
            Return _LGT_XML_NCT_FRGN_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_FRGN_TO))
            _LGT_XML_NCT_FRGN_TO = value
        End Set
    End Property
End Class

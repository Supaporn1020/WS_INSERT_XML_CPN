Public Class LGT_XML_NCT_N
    Private _LGTNCT As New LGT_XML_NCT_N_TO
    Public Property LGTNCT() As LGT_XML_NCT_N_TO
        Get
            Return _LGTNCT
        End Get
        Set(ByVal value As LGT_XML_NCT_N_TO)
            _LGTNCT = value
        End Set
    End Property
End Class

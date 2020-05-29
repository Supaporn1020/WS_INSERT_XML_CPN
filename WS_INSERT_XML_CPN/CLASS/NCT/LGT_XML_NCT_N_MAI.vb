Public Class LGT_XML_NCT_N_MAI
    Private _LGTNCT As New LGTNCT
    Public Property LGTNCT() As LGTNCT
        Get
            Return _LGTNCT
        End Get
        Set(ByVal value As LGTNCT)
            _LGTNCT = value
        End Set
    End Property
End Class

Public Class LGTNCT
    Private _NCT As New XML_NCT_N
    Public Property NCT() As XML_NCT_N
        Get
            Return _NCT
        End Get
        Set(ByVal value As XML_NCT_N)
            _NCT = value
        End Set
    End Property
End Class

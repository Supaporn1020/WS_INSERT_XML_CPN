Public Class LGT_XML_NCT_NR_IOW_TO
    Private _NCT As New XML_NCT_NR
    Public Property NCT() As XML_NCT_NR
        Get
            Return _NCT
        End Get
        Set(ByVal value As XML_NCT_NR)
            _NCT = value
        End Set
    End Property
End Class

Public Class LGT_TXC
    Private _TXC As New TXC
    Public Property TXC() As TXC
        Get
            Return _TXC
        End Get
        Set(ByVal value As TXC)
            _TXC = value
        End Set
    End Property
End Class

Public Class XML_MDC_LICENSE_HISTORY

    Private _LICENSE_HISTORYs As New List(Of LICENSE_HISTORY)
    Public Property MDC_LICENSE_HISTORY() As List(Of LICENSE_HISTORY)
        Get
            Return _LICENSE_HISTORYs
        End Get
        Set(ByVal value As List(Of LICENSE_HISTORY))
            _LICENSE_HISTORYs = value
        End Set
    End Property
End Class

Public Class XML_CMT_LICENSE_HISTORY

    Private _LICENSE_HISTORYs As New List(Of LICENSE_HISTORY_CMT)
    Public Property CMT_LICENSE_HISTORY() As List(Of LICENSE_HISTORY_CMT)
        Get
            Return _LICENSE_HISTORYs
        End Get
        Set(ByVal value As List(Of LICENSE_HISTORY_CMT))
            _LICENSE_HISTORYs = value
        End Set
    End Property
End Class

Public Class XML_FOOD_LICENSE_HISTORY
    Private _XML_FOOD_EDIT_HISTORY As New List(Of XML_FOOD_EDIT_HISTORY)
    Public Property XML_FOOD_EDIT_HISTORY() As List(Of XML_FOOD_EDIT_HISTORY)
        Get
            Return _XML_FOOD_EDIT_HISTORY
        End Get
        Set(ByVal value As List(Of XML_FOOD_EDIT_HISTORY))
            _XML_FOOD_EDIT_HISTORY = value
        End Set
    End Property
End Class

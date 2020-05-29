Public Class LGT_RECIPE_GROUP_TO
    Private _XML_RECIPE_GROUPT As New XML_RECIPE_GROUP
    Public Property XML_RECIPE_GROUPT() As XML_RECIPE_GROUP
        Get
            Return _XML_RECIPE_GROUPT
        End Get
        Set(ByVal value As XML_RECIPE_GROUP)
            _XML_RECIPE_GROUPT = value
        End Set
    End Property
End Class

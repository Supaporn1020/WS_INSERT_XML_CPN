Public Class LGT_XML_NCT_RECIPE_GROUP_TO
    Private _XML_NCT_RECIPE_GROUP As New XML_NCT_RECIPE_GROUP
    Public Property XML_NCT_RECIPE_GROUP() As XML_NCT_RECIPE_GROUP
        Get
            Return _XML_NCT_RECIPE_GROUP
        End Get
        Set(ByVal value As XML_NCT_RECIPE_GROUP)
            _XML_NCT_RECIPE_GROUP = value
        End Set
    End Property
End Class

Public Class LGT_IOW_E
    Private _XML_SEARCH_DRUG_DR As New XML_SEARCH_DRUG_DR_TO
    Public Property XML_SEARCH_DRUG_DR() As XML_SEARCH_DRUG_DR_TO
        Get
            Return _XML_SEARCH_DRUG_DR
        End Get
        Set(ByVal value As XML_SEARCH_DRUG_DR_TO)
            _XML_SEARCH_DRUG_DR = value
        End Set
    End Property
    'Private _LGT_XML_STOWAGR_TO As New LGT_XML_STOWAGR_TO
    'Public Property LGT_XML_STOWAGR_TO() As LGT_XML_STOWAGR_TO
    '    Get
    '        Return _LGT_XML_STOWAGR_TO
    '    End Get
    '    Set(ByVal value As LGT_XML_STOWAGR_TO)
    '        _LGT_XML_STOWAGR_TO = value
    '    End Set
    'End Property

    Private _LGT_XML_STOWAGR_TO As New List(Of LGT_XML_STOWAGR_TO)
    Public Property LGT_XML_STOWAGR_TO() As List(Of LGT_XML_STOWAGR_TO)
        Get
            Return _LGT_XML_STOWAGR_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_STOWAGR_TO))
            _LGT_XML_STOWAGR_TO = value
        End Set
    End Property

    Private _LGT_RECIPE_GROUP_TO As New List(Of LGT_RECIPE_GROUP_TO)
    Public Property LGT_RECIPE_GROUP_TO() As List(Of LGT_RECIPE_GROUP_TO)
        Get
            Return _LGT_RECIPE_GROUP_TO
        End Get
        Set(ByVal value As List(Of LGT_RECIPE_GROUP_TO))
            _LGT_RECIPE_GROUP_TO = value
        End Set
    End Property



    'Private _LGT_RECIPE_GROUP_TO As New LGT_RECIPE_GROUP_TO
    'Public Property LGT_RECIPE_GROUP_TO() As LGT_RECIPE_GROUP_TO
    '    Get
    '        Return _LGT_RECIPE_GROUP_TO
    '    End Get
    '    Set(ByVal value As LGT_RECIPE_GROUP_TO)
    '        _LGT_RECIPE_GROUP_TO = value
    '    End Set
    'End Property


    'Private _LGT_XML_FRGN_TO As New LGT_XML_FRGN_TO
    'Public Property LGT_XML_FRGN_TO() As LGT_XML_FRGN_TO
    '    Get
    '        Return _LGT_XML_FRGN_TO
    '    End Get
    '    Set(ByVal value As LGT_XML_FRGN_TO)
    '        _LGT_XML_FRGN_TO = value
    '    End Set
    'End Property
    Private _LGT_ANIMAL_DRUGS_TO As New List(Of LGT_ANIMAL_DRUGS_TO)
    Public Property LGT_ANIMAL_DRUGS_TO() As List(Of LGT_ANIMAL_DRUGS_TO)
        Get
            Return _LGT_ANIMAL_DRUGS_TO
        End Get
        Set(ByVal value As List(Of LGT_ANIMAL_DRUGS_TO))
            _LGT_ANIMAL_DRUGS_TO = value
        End Set
    End Property
    'Private _LGT_ANIMAL_DRUGS_TO As New LGT_ANIMAL_DRUGS_TO
    'Public Property LGT_ANIMAL_DRUGS_TO() As LGT_ANIMAL_DRUGS_TO
    '    Get
    '        Return _LGT_ANIMAL_DRUGS_TO
    '    End Get
    '    Set(ByVal value As LGT_ANIMAL_DRUGS_TO)
    '        _LGT_ANIMAL_DRUGS_TO = value
    '    End Set
    'End Property
    'Private _LGT_IOW_EQ As New LGT_IOW_EQ
    'Public Property LGT_IOW_EQ() As LGT_IOW_EQ
    '    Get
    '        Return _LGT_IOW_EQ
    '    End Get
    '    Set(ByVal value As LGT_IOW_EQ)
    '        _LGT_IOW_EQ = value
    '    End Set
    'End Property

    Private _LGT_IOW_EQ As New List(Of LGT_IOW_EQ)
    Public Property LGT_IOW_EQ() As List(Of LGT_IOW_EQ)
        Get
            Return _LGT_IOW_EQ
        End Get
        Set(ByVal value As List(Of LGT_IOW_EQ))
            _LGT_IOW_EQ = value
        End Set
    End Property

    Private _LGT_XML_FRGN_ALL_TO As New List(Of LGT_XML_FRGN_ALL_TO)
    Public Property LGT_XML_FRGN_ALL_TO() As List(Of LGT_XML_FRGN_ALL_TO)
        Get
            Return _LGT_XML_FRGN_ALL_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_FRGN_ALL_TO))
            _LGT_XML_FRGN_ALL_TO = value
        End Set
    End Property
End Class

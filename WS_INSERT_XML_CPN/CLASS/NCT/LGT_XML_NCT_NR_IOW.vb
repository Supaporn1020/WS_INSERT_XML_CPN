Public Class LGT_XML_NCT_NR_IOW
    Private _LGT_XML_NCT_NR_ALL_TO As New LGT_XML_NCT_NR_ALL_TO
    Public Property LGT_XML_NCT_NR_ALL_TO() As LGT_XML_NCT_NR_ALL_TO
        Get
            Return _LGT_XML_NCT_NR_ALL_TO
        End Get
        Set(ByVal value As LGT_XML_NCT_NR_ALL_TO)
            _LGT_XML_NCT_NR_ALL_TO = value
        End Set
    End Property
    Private _LGT_XML_NCT_FRGN_TO As New List(Of LGT_XML_NCT_FRGN_TO)
    Public Property LGT_XML_NCT_FRGN_TO() As List(Of LGT_XML_NCT_FRGN_TO)
        Get
            Return _LGT_XML_NCT_FRGN_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_FRGN_TO))
            _LGT_XML_NCT_FRGN_TO = value
        End Set
    End Property
    Private _LGT_XML_NCT_AGENT_TO As New List(Of LGT_XML_NCT_AGENT_TO)
    Public Property LGT_XML_NCT_AGENT_TO() As List(Of LGT_XML_NCT_AGENT_TO)
        Get
            Return _LGT_XML_NCT_AGENT_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_AGENT_TO))
            _LGT_XML_NCT_AGENT_TO = value
        End Set
    End Property
    Private _LGT_XML_NCT_IOW_TO As New List(Of LGT_XML_NCT_IOW_TO)
    Public Property LGT_XML_NCT_IOW_TO() As List(Of LGT_XML_NCT_IOW_TO)
        Get
            Return _LGT_XML_NCT_IOW_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_IOW_TO))
            _LGT_XML_NCT_IOW_TO = value
        End Set
    End Property

    Private _LGT_XML_NCT_COLOR_TO As New List(Of LGT_XML_NCT_COLOR_TO)
    Public Property LGT_XML_NCT_COLOR_TO() As List(Of LGT_XML_NCT_COLOR_TO)
        Get
            Return _LGT_XML_NCT_COLOR_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_COLOR_TO))
            _LGT_XML_NCT_COLOR_TO = value
        End Set
    End Property
    Private _LGT_XML_NCT_RECIPE_GROUP_TO As New List(Of LGT_XML_NCT_RECIPE_GROUP_TO)
    Public Property LGT_XML_NCT_RECIPE_GROUP_TO() As List(Of LGT_XML_NCT_RECIPE_GROUP_TO)
        Get
            Return _LGT_XML_NCT_RECIPE_GROUP_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_RECIPE_GROUP_TO))
            _LGT_XML_NCT_RECIPE_GROUP_TO = value
        End Set
    End Property
    Private _LGT_XML_QUALITIES_COLOR_DRUG_TO As New List(Of LGT_XML_QUALITIES_COLOR_DRUG_TO)
    Public Property LGT_XML_QUALITIES_COLOR_DRUG_TO() As List(Of LGT_XML_QUALITIES_COLOR_DRUG_TO)
        Get
            Return _LGT_XML_QUALITIES_COLOR_DRUG_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_QUALITIES_COLOR_DRUG_TO))
            _LGT_XML_QUALITIES_COLOR_DRUG_TO = value
        End Set
    End Property

    Private _LGT_XML_NCT_IOW_EQ As New List(Of LGT_XML_NCT_IOW_EQ)
    Public Property LGT_XML_NCT_IOW_EQ() As List(Of LGT_XML_NCT_IOW_EQ)
        Get
            Return _LGT_XML_NCT_IOW_EQ
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_IOW_EQ))
            _LGT_XML_NCT_IOW_EQ = value
        End Set
    End Property
    'Private _LGT_XML_NCT_NR_NQR_TO As New List(Of LGT_XML_NCT_NR_NQR_TO)
    'Public Property LGT_XML_NCT_NR_NQR_TO() As List(Of LGT_XML_NCT_NR_NQR_TO)
    '    Get
    '        Return _LGT_XML_NCT_NR_NQR_TO
    '    End Get
    '    Set(ByVal value As List(Of LGT_XML_NCT_NR_NQR_TO))
    '        _LGT_XML_NCT_NR_NQR_TO = value
    '    End Set
    'End Property
    'Private _LGT_XML_NCT_NR_NQR_DETAIL_TO As New List(Of LGT_XML_NCT_NR_NQR_DETAIL_TO)
    'Public Property LGT_XML_NCT_NR_NQR_DETAIL_TO() As List(Of LGT_XML_NCT_NR_NQR_DETAIL_TO)
    '    Get
    '        Return _LGT_XML_NCT_NR_NQR_DETAIL_TO
    '    End Get
    '    Set(ByVal value As List(Of LGT_XML_NCT_NR_NQR_DETAIL_TO))
    '        _LGT_XML_NCT_NR_NQR_DETAIL_TO = value
    '    End Set
    'End Property

    Private _LGT_XML_NCT_NR_CANCELED_TO As New List(Of LGT_XML_NCT_NR_CANCELED_TO)
    Public Property LGT_XML_NCT_NR_CANCELED_TO() As List(Of LGT_XML_NCT_NR_CANCELED_TO)
        Get
            Return _LGT_XML_NCT_NR_CANCELED_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_NR_CANCELED_TO))
            _LGT_XML_NCT_NR_CANCELED_TO = value
        End Set
    End Property
End Class

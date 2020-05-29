Public Class LGT_IOW_EQ
    Private _XML_IOW_TO As New XML_IOW_TO
    Public Property XML_IOW_TO() As XML_IOW_TO
        Get
            Return _XML_IOW_TO
        End Get
        Set(ByVal value As XML_IOW_TO)
            _XML_IOW_TO = value
        End Set
    End Property
    Private _LGT_IOW_EQ_TO As New List(Of LGT_IOW_EQ_TO)
    Public Property LGT_IOW_EQ_TO() As List(Of LGT_IOW_EQ_TO)
        Get
            Return _LGT_IOW_EQ_TO
        End Get
        Set(ByVal value As List(Of LGT_IOW_EQ_TO))
            _LGT_IOW_EQ_TO = value
        End Set
    End Property
End Class

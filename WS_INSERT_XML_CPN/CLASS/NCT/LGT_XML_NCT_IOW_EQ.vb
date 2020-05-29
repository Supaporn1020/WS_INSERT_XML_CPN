Public Class LGT_XML_NCT_IOW_EQ
    Private _XML_NCT_IOW_TO As New XML_NCT_IOW_TO
    Public Property XML_NCT_IOW_TO() As XML_NCT_IOW_TO
        Get
            Return _XML_NCT_IOW_TO
        End Get
        Set(ByVal value As XML_NCT_IOW_TO)
            _XML_NCT_IOW_TO = value
        End Set
    End Property
    ''' <summary>
    ''' ตารางผลิตภัณฑ์ย่อย  หลังคำว่า Property คือชื่อตัวแปร
    ''' </summary>
    ''' <remarks></remarks>
    Private _LGT_XML_NCT_IOW_EQ_TO As New List(Of LGT_XML_NCT_IOW_EQ_TO)
    Public Property LGT_XML_NCT_IOW_EQ_TO() As List(Of LGT_XML_NCT_IOW_EQ_TO)
        Get
            Return _LGT_XML_NCT_IOW_EQ_TO
        End Get
        Set(ByVal value As List(Of LGT_XML_NCT_IOW_EQ_TO))
            _LGT_XML_NCT_IOW_EQ_TO = value
        End Set
    End Property
End Class

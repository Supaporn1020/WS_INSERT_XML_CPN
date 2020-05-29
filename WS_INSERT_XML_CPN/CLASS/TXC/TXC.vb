Public Class TXC
    Private _DT1 As DataTable
    Public Property DT1() As DataTable
        Get
            Return _DT1
        End Get
        Set(ByVal value As DataTable)
            _DT1 = value
        End Set
    End Property

    'Private _LGT_FORMULA As New List(Of LGT_FORMULA)
    'Public Property LGT_FORMULA() As List(Of LGT_FORMULA)
    '    Get
    '        Return _LGT_FORMULA
    '    End Get
    '    Set(ByVal value As List(Of LGT_FORMULA))
    '        _LGT_FORMULA = value
    '    End Set
    'End Property
    Private _DT2 As DataTable
    Public Property DT2() As DataTable
        Get
            Return _DT2
        End Get
        Set(ByVal value As DataTable)
            _DT2 = value
        End Set
    End Property

    Private _DT3 As DataTable
    Public Property DT3() As DataTable
        Get
            Return _DT3
        End Get
        Set(ByVal value As DataTable)
            _DT3 = value
        End Set
    End Property

    Private _DT4 As DataTable
    Public Property DT4() As DataTable
        Get
            Return _DT4
        End Get
        Set(ByVal value As DataTable)
            _DT4 = value
        End Set
    End Property
End Class

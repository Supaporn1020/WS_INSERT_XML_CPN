Public Class LGT_ANIMAL_DRUGS_TO
    Private _XML_ANIMAL_DRUG As New XML_ANIMAL_DRUG
    Public Property XML_ANIMAL_DRUG() As XML_ANIMAL_DRUG
        Get
            Return _XML_ANIMAL_DRUG
        End Get
        Set(ByVal value As XML_ANIMAL_DRUG)
            _XML_ANIMAL_DRUG = value
        End Set
    End Property
    Private _LGT_ANIMAL_CONSUME_DRUGS_TO As New List(Of LGT_ANIMAL_CONSUME_DRUGS_TO)
    Public Property LGT_ANIMAL_CONSUME_DRUGS_TO() As List(Of LGT_ANIMAL_CONSUME_DRUGS_TO)
        Get
            Return _LGT_ANIMAL_CONSUME_DRUGS_TO
        End Get
        Set(ByVal value As List(Of LGT_ANIMAL_CONSUME_DRUGS_TO))
            _LGT_ANIMAL_CONSUME_DRUGS_TO = value
        End Set
    End Property
End Class

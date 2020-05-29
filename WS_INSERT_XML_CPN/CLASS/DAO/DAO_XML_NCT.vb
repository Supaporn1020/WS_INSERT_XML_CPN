Namespace DAO_XML_NCT
    Public MustInherit Class MAINCONTEXT1
        Public db_cpn As New LGT_XML_NCTDataContext

        Public datas
        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class
    'Public Class TB_XML_NCT
    '    Inherits MAINCONTEXT1
    '    Public fields As New XML_NCT
    '    Public Sub insert()
    '        db_cpn.XML_NCTs.InsertOnSubmit(fields)
    '        db_cpn.SubmitChanges()
    '    End Sub
    '    Public Sub update()
    '        db_cpn.SubmitChanges()
    '    End Sub

    '    Public Sub delete()
    '        db_cpn.XML_NCTs.DeleteOnSubmit(fields)
    '        db_cpn.SubmitChanges()
    '    End Sub

    '    Public Sub GetDataAll()
    '        datas = (From p In db_cpn.XML_NCTs Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    'Public Sub GetDataAll()
    '    '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
    '    '    For Each Me.fields In datas
    '    '    Next
    '    'End Sub
    '    Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
    '        datas = (From p In db_cpn.XML_NCTs Where p.IDA = lcnsid Select p)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    '    Public Sub GetDataby_Newcode(ByVal Newcode As String)
    '        datas = (From p In db_cpn.XML_NCTs Where p.Newcode = Newcode Select p).Take(1)
    '        For Each Me.fields In datas
    '        Next
    '    End Sub
    'End Class
    Public Class TB_XML_NCT_N
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_N
        Public Sub insert()
            db_cpn.XML_NCT_Ns.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub

        Public Sub delete()
            db_cpn.XML_NCT_Ns.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_Ns Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_SEARCH_DRUG_LCNs Where p.IDA = 1 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_lcnsid(ByVal lcnsid As Integer)
            datas = (From p In db_cpn.XML_NCT_Ns Where p.IDA = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode1(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_Ns Where p.Newcode = Newcode Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_Ns Where p.Newcode = Newcode Select p).Take(1)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_NR
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_NR
        Public Sub insert()
            db_cpn.XML_NCT_NRs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_NRs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.SEARCH_XML_NCT_POPUP_LCNs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_NCT_NRs Where p.IDA = 12 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_NCT_NRs Where p.IDA = 87 Select p Order By p.IDA)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_NRs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        'Public Sub GetDataby_IDA(ByVal IDA As Integer)
        '    datas = (From p In db_cpn.XML_NCT_NRs Where p.IDA = IDA Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_NRs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcntpcd As String)
            datas = (From p In db_cpn.XML_NCT_NRs Where p.lcntpcd = lcntpcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_P(ByVal Newcode_R As String)
            datas = (From p In db_cpn.XML_NCT_NRs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_FRGN_TO
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_FRGN_TO
        Public Sub insert()
            db_cpn.XML_NCT_FRGN_TOs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_FRGN_TOs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.SEARCH_XML_NCT_LCNs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_FRGN_TOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_FRGN_TOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_FRGN_TOs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_NCT_FRGN_TOs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_IOW_TO
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_IOW_TO
        Public Sub insert()
            db_cpn.XML_NCT_IOW_TOs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_IOW_TOs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.SEARCH_XML_NCT_LCNs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_IOW_TOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_IOW_TOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_IOW_TOs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_NCT_IOW_TOs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db_cpn.XML_NCT_IOW_TOs Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_AGENT_TO
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_AGENT_TO
        Public Sub insert()
            db_cpn.XML_NCT_AGENT_TOs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_AGENT_TOs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.SEARCH_XML_NCT_LCNs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_AGENT_TOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_AGENT_TOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_AGENT_TOs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_NCT_AGENT_TOs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_IOW_AORI_A
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_IOW_AORI_A
        Public Sub insert()
            db_cpn.XML_NCT_IOW_AORI_As.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_IOW_AORI_As.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.SEARCH_XML_NCT_LCNs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_IOW_AORI_As Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_IOW_AORI_As Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_IOW_AORI_As Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_NCT_IOW_AORI_As Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_R(ByVal Newcode_R As String)
            datas = (From p In db_cpn.XML_NCT_IOW_AORI_As Where p.Newcode_R = Newcode_R Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_COLOR
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_COLOR
        Public Sub insert()
            db_cpn.XML_NCT_COLORs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_COLORs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_NCT_COLORs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_COLORs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_COLORs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_COLORs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_NCT_COLORs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_XML_NCT_RECIPE_GROUP
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_RECIPE_GROUP
        Public Sub insert()
            db_cpn.XML_NCT_RECIPE_GROUPs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_RECIPE_GROUPs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_NCT_COLORs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_RECIPE_GROUPs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_RECIPE_GROUPs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_RECIPE_GROUPs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_NCT_RECIPE_GROUPs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_XML_QUALITIES_COLOR_DRUG
        Inherits MAINCONTEXT1
        Public fields As New XML_QUALITIES_COLOR_DRUG
        Public Sub insert()
            db_cpn.XML_QUALITIES_COLOR_DRUGs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_QUALITIES_COLOR_DRUGs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_NCT_COLORs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_QUALITIES_COLOR_DRUGs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_QUALITIES_COLOR_DRUGs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_QUALITIES_COLOR_DRUGs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_QUALITIES_COLOR_DRUGs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_XML_NCT_NR_NQR
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_NR_NQR
        Public Sub insert()
            db_cpn.XML_NCT_NR_NQRs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_NR_NQRs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_NCT_COLORs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_NR_NQRs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_NR_NQRs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_NR_NQRs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_rcvno(ByVal Newcode_rcvno As String)
            datas = (From p In db_cpn.XML_NCT_NR_NQRs Where p.Newcode_rcvno = Newcode_rcvno Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_thadrgnmpro(ByVal lcnsid As String)
            datas = (From p In db_cpn.XML_NCT_NR_NQRs Where p.lcnsid = lcnsid Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
    Public Class TB_XML_NCT_IOW_EQ_TO
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_IOW_EQ_TO
        Public Sub insert()
            db_cpn.XML_NCT_IOW_EQ_TOs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_IOW_EQ_TOs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.XML_NCT_COLORs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub
        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_IOW_EQ_TOs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_IOW_EQ_TOs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_IOW_EQ_TOs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub

        Public Sub GetDataby_Newcode_RID(ByVal Newcode_RID As String)
            datas = (From p In db_cpn.XML_NCT_IOW_EQ_TOs Where p.Newcode_rid = Newcode_RID Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_NR_NQR_DETAIL
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_NR_NQR_DETAIL
        Public Sub insert()
            db_cpn.XML_NCT_NR_NQR_DETAILs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_NR_NQR_DETAILs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.SEARCH_XML_NCT_POPUP_LCNs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_NR_NQR_DETAILs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_NR_NQR_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_NR_NQR_DETAILs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode_edtcd(ByVal Newcode_edtcd As String)
            datas = (From p In db_cpn.XML_NCT_NR_NQR_DETAILs Where p.Newcode_edtcd = Newcode_edtcd Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As String)
            datas = (From p In db_cpn.XML_NCT_NR_NQR_DETAILs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
    End Class
    Public Class TB_XML_NCT_NR_CANCELED
        Inherits MAINCONTEXT1
        Public fields As New XML_NCT_NR_CANCELED
        Public Sub insert()
            db_cpn.XML_NCT_NR_CANCELEDs.InsertOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub
        Public Sub update()
            db_cpn.SubmitChanges()
        End Sub
        Public Sub delete()
            db_cpn.XML_NCT_NR_CANCELEDs.DeleteOnSubmit(fields)
            db_cpn.SubmitChanges()
        End Sub

        'Public Sub GetDataAll()
        '    datas = (From p In db_cpn.SEARCH_XML_NCT_POPUP_LCNs Take 500 Select p)
        '    For Each Me.fields In datas
        '    Next
        'End Sub

        Public Sub GetDataAll()
            datas = (From p In db_cpn.XML_NCT_NR_CANCELEDs Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_IDA(ByVal IDA As Integer)
            datas = (From p In db_cpn.XML_NCT_NR_CANCELEDs Where p.IDA = IDA Select p)
            For Each Me.fields In datas
            Next
        End Sub
        Public Sub GetDataby_Newcode(ByVal Newcode As String)
            datas = (From p In db_cpn.XML_NCT_NR_CANCELEDs Where p.Newcode = Newcode Select p)
            For Each Me.fields In datas
            Next
        End Sub

    End Class
End Namespace
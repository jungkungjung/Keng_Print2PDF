Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports CenterClass

Public Class doc_tab
    Dim JK_ini As New JKClass
    Dim data As New DataSet
    Dim dt As New DataTable
    Dim dtv As New DataView
    Dim t_tooltip As New ToolTip
    Dim rpt4 As New ReportDocument 'ประกาศตรงนี้ เพื่อลบ rpt ใน temp windows ตอนปิดหน้าจอ
    Dim File_ini = Path.Combine(System.Windows.Forms.Application.StartupPath, "DB_Config.ini")

    Private Sub usc_so_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        JK_ini.EnableDoubleBuffered(grw) 'วิธีโหลด datagrid ให้เร็วขึ้น
        'Basedate_from.Value = New Date(Now.Year, Now.Month, 1)
        new_call()
        Pn_not_show.Hide()
    End Sub

    Private Sub usc_so_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        grw.ClearSelection()
    End Sub

    Private Sub show_lnk_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles show_lnk.LinkClicked
        If Basedate_from.Value.Date > Basedate_to.Value.Date Then
            MsgBox("รูปแบบการเลือกวันที่ไม่ถูกต้อง", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
        Else
            new_call()
        End If
    End Sub

    Private Sub return_lnk_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles return_lnk.LinkClicked
        list_Guna_search.Text = ""
        ENTER_KEY()
    End Sub
    Public Sub form_refresh() 'refresh ค่า
        new_call()
    End Sub

    Private Sub doc_tab_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        rpt4.Dispose() 'เพื่อปิด rpt ใน temp windows
    End Sub

    Private Sub new_call()
        'If company_licensse() = False Then
        '    MsgBox("ซอฟแวร์เวอร์ชั่นทดลอง โปรดติดต่อเจ้าหน้าที่ เพื่อขอเลขทะเบียน", MsgBoxStyle.Question, "คำเตือน")
        '    Exit Sub 'ถ้า license ไม่ถูกต้อง ออกจาก sub
        'End If
        ' 2023-11-3 แจ้ง lock license ลูกค้าจ่ายเงินแล้ว ให้ปลดล็อด ด้วย

        Try
            If record_multi.Text = 0 Then 'รวมทุกเอกสาร
                dt = JK_ini.documentAll_data(Basedate_from.Value.Date, Basedate_to.Value.Date)
            ElseIf record_multi.Text = 1 Then 'ใบขาย
                dt = JK_ini.invoice_data(Basedate_from.Value.Date, Basedate_to.Value.Date)
            ElseIf record_multi.Text = 2 Then 'ใบรับคืน
                dt = JK_ini.cn_data(Basedate_from.Value.Date, Basedate_to.Value.Date)
            ElseIf record_multi.Text = 23 Then 'ใบรับคืนสด
                dt = JK_ini.cnCash_data(Basedate_from.Value.Date, Basedate_to.Value.Date)
            ElseIf record_multi.Text = 3 Then 'ใบเพิ่มหนี้
                dt = JK_ini.debitnote_data(Basedate_from.Value.Date, Basedate_to.Value.Date)
            ElseIf record_multi.Text = 4 Then 'ใบลดหนี้
                dt = JK_ini.creditnote_data(Basedate_from.Value.Date, Basedate_to.Value.Date)
            ElseIf record_multi.Text = 5 Then 'ใบมัดจำ
                dt = JK_ini.deposit_data(Basedate_from.Value.Date, Basedate_to.Value.Date)
            End If
            If dt Is Nothing Then
                dtv = Nothing
                grw.DataSource = dtv
            Else
                dtv = dt.AsDataView
                grw.DataSource = dtv
                'grw.Columns("TYPE").Visible = False
                grw.Columns("DI_KEY").Visible = False
                grw.Columns("TYPE").Visible = False
                grw.Columns("DT_DOCCODE").Visible = False
                grw.Columns("DT_PROPERTIES").Visible = False
                grw.Columns("DT_THAIDESC").Visible = False
                grw.Columns("DI_ACTIVE").Visible = False
                grw.Columns("DI_DATE").Width = 74
                grw.Columns("DI_REF").Width = 120
                grw.Columns("AR_CODE").Width = 100
                grw.Columns("DI_AMOUNT").Width = 120
                grw.Columns("DI_DATE").HeaderText = "วันที่"
                grw.Columns("DI_REF").HeaderText = "เลขที่เอกสาร"
                grw.Columns("AR_CODE").HeaderText = "รหัสลูกค้า"
                grw.Columns("AR_NAME").HeaderText = "ชื่อลูกค้า"
                grw.Columns("DI_AMOUNT").HeaderText = "ยอดสุทธิ"
                grw.Columns("AR_NAME").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                grw.Columns("DI_AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                grw.Columns("DI_AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                grw.Columns("DI_DATE").DefaultCellStyle.Format = ("dd/MM/yyyy")
                grw.Columns("DI_AMOUNT").DefaultCellStyle.Format = ("N2")
                ENTER_KEY()
            End If
            list_Guna_search.Select()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bt_pdf_Click(sender As Object, e As EventArgs) Handles bt_pdf.Click
        If dtv.Count > 0 Then
            JK_ini.printPDF(dtv.ToTable, Integer.Parse(record_multi.Text), 0)
        Else
            MsgBox("ไม่มีข้อมูล", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
        End If
    End Sub

    Private Sub bt_print_Click(sender As Object, e As EventArgs) Handles bt_print.Click
        If dtv.Count = 0 Then
            Exit Sub '2025-4-2 exit sub
        End If

        Dim dt_print As New DataTable()

        'ดึงชื่อบริษัทฯ()
        Dim ThaiCompanyName As String = ""
        Dim EngCompanyName As String = ""
        Dim ThaiAddress1 As String = ""
        Dim ThaiAddress2 As String = ""
        Dim ThaiAddress3 As String = ""
        Dim CompanyTelNo As String = ""
        Dim CompanyFax As String = ""
        Dim CompanyPost As String = ""
        Dim CompanyRegno As String = ""
        If JK_ini.companyinfo_table.Rows.Count > 0 Then
            ThaiCompanyName = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_TCOMPANYNAME").ToString
            EngCompanyName = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_ECOMPANYNAME").ToString
            ThaiAddress1 = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_TADDRESS_1").ToString
            ThaiAddress2 = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_TADDRESS_2").ToString
            ThaiAddress3 = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_TADDRESS_3").ToString
            CompanyTelNo = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_TELNO").ToString
            CompanyFax = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_FAX").ToString
            CompanyPost = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_POST").ToString
            CompanyRegno = JK_ini.companyinfo_table.Rows(0).Item("CMPNY_REG_NO").ToString
        End If

        Dim FM4 As New preview
        If record_multi.Text = 1 Then 'ใบขาย
            dt_print = JK_ini.invoice_print_table(grw.CurrentRow.Cells(2).Value)
            rpt4.Load(Application.StartupPath & "\Rpt\DOC10604_Sarabun.RPT")
            'rpt4.Load(Application.StartupPath & "\Rpt\DOC10602_2.Sarabun.rpt")
        ElseIf record_multi.Text = 2 Then 'ใบขาย
            dt_print = JK_ini.cn_print_table(grw.CurrentRow.Cells(2).Value)
            rpt4.Load(Application.StartupPath & "\Rpt\DOC10704_Sarabun.RPT")
        ElseIf record_multi.Text = 3 Then 'ใบเพิ่มหนี้
            dt_print = JK_ini.debit_print_table(grw.CurrentRow.Cells(2).Value)
            rpt4.Load(Application.StartupPath & "\Rpt\DOC20101_Sarabun.rpt")
        ElseIf record_multi.Text = 4 Then 'ใบเพิ่มหนี้
            dt_print = JK_ini.debit_print_table(grw.CurrentRow.Cells(2).Value)
            rpt4.Load(Application.StartupPath & "\Rpt\DOC20201_Sarabun.rpt")
        End If
        rpt4.SetDataSource(dt_print)
        FM4.CrystalReportViewer1.ReportSource = rpt4
        rpt4.SetParameterValue("ThaiCompanyName", ThaiCompanyName)
        rpt4.SetParameterValue("ThaiAddress1", ThaiAddress1)
        rpt4.SetParameterValue("ThaiAddress2", ThaiAddress2)
        rpt4.SetParameterValue("ThaiAddress3", ThaiAddress3)
        rpt4.SetParameterValue("CompanyTelNo", CompanyTelNo)
        rpt4.SetParameterValue("CompanyFax", CompanyFax)
        rpt4.SetParameterValue("CompanyPost", CompanyPost)
        rpt4.SetParameterValue("CompanyRegno", CompanyRegno)
        FM4.ShowDialog()
        FM4.CrystalReportViewer1.Zoom(125)
    End Sub

    Private Sub list_Guna_search_TextChanged(sender As Object, e As EventArgs) Handles list_Guna_search.TextChanged
        ENTER_KEY()
    End Sub
    Private Sub ENTER_KEY()
        Try
            If dtv IsNot Nothing Then
                If list_Guna_search.Text.Length = 0 Then 'ป้องกันกรองค่า null ไมได้
                    dtv.RowFilter = Nothing
                    Exit Sub
                End If
                If cmpn_guna_cmb.SelectedIndex = 0 Then
                    dtv.RowFilter = "[DI_REF] Like " & "'%" & list_Guna_search.Text & "%'"
                ElseIf cmpn_guna_cmb.SelectedIndex = 1 Then
                    dtv.RowFilter = "[AR_CODE] Like " & "'%" & list_Guna_search.Text & "%' OR [AR_NAME] Like " & "'%" & list_Guna_search.Text & "%'"
                End If
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Exclamation, "Result")
        End Try
    End Sub
End Class
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class doc_tab
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(doc_tab))
        Me.return_lnk = New System.Windows.Forms.LinkLabel()
        Me.GunaControlBox6 = New Guna.UI.WinForms.GunaControlBox()
        Me.GunaControlBox5 = New Guna.UI.WinForms.GunaControlBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.show_lnk = New System.Windows.Forms.LinkLabel()
        Me.Pn_not_show = New System.Windows.Forms.Panel()
        Me.record_multi = New System.Windows.Forms.TextBox()
        Me.GunaVSeparator1 = New Guna.UI.WinForms.GunaVSeparator()
        Me.GunaVSeparator2 = New Guna.UI.WinForms.GunaVSeparator()
        Me.header_lb = New System.Windows.Forms.Label()
        Me.grw = New Guna.UI.WinForms.GunaDataGridView()
        Me.TDAY = New System.Windows.Forms.TextBox()
        Me.GunaGroupBox1 = New Guna.UI.WinForms.GunaGroupBox()
        Me.bt_print = New Guna.UI.WinForms.GunaButton()
        Me.bt_pdf = New Guna.UI.WinForms.GunaButton()
        Me.GunaGroupBox2 = New Guna.UI.WinForms.GunaGroupBox()
        Me.list_Guna_search = New Guna.UI.WinForms.GunaTextBox()
        Me.GunaCircleButton1 = New Guna.UI.WinForms.GunaCircleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmpn_guna_cmb = New Guna.UI.WinForms.GunaComboBox()
        Me.Basedate_to = New JKInterface.BaseDateTime_blue()
        Me.Basedate_from = New JKInterface.BaseDateTime_blue()
        Me.Pn_not_show.SuspendLayout()
        CType(Me.grw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GunaGroupBox1.SuspendLayout()
        Me.GunaGroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'return_lnk
        '
        Me.return_lnk.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.return_lnk.AutoSize = True
        Me.return_lnk.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.return_lnk.ForeColor = System.Drawing.Color.LightGray
        Me.return_lnk.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.return_lnk.Location = New System.Drawing.Point(3, 5)
        Me.return_lnk.Name = "return_lnk"
        Me.return_lnk.Size = New System.Drawing.Size(51, 16)
        Me.return_lnk.TabIndex = 1484
        Me.return_lnk.TabStop = True
        Me.return_lnk.Text = "Refresh"
        '
        'GunaControlBox6
        '
        Me.GunaControlBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox6.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox6.AnimationSpeed = 0.03!
        Me.GunaControlBox6.IconColor = System.Drawing.Color.Black
        Me.GunaControlBox6.IconSize = 15.0!
        Me.GunaControlBox6.Location = New System.Drawing.Point(1102, 1)
        Me.GunaControlBox6.Name = "GunaControlBox6"
        Me.GunaControlBox6.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.GunaControlBox6.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox6.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox6.Size = New System.Drawing.Size(30, 28)
        Me.GunaControlBox6.TabIndex = 1846
        '
        'GunaControlBox5
        '
        Me.GunaControlBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox5.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox5.AnimationSpeed = 0.03!
        Me.GunaControlBox5.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox
        Me.GunaControlBox5.IconColor = System.Drawing.Color.Black
        Me.GunaControlBox5.IconSize = 15.0!
        Me.GunaControlBox5.Location = New System.Drawing.Point(1069, 1)
        Me.GunaControlBox5.Name = "GunaControlBox5"
        Me.GunaControlBox5.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.GunaControlBox5.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox5.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox5.Size = New System.Drawing.Size(30, 28)
        Me.GunaControlBox5.TabIndex = 1847
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 16)
        Me.Label1.TabIndex = 1849
        Me.Label1.Text = "วันที่"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(147, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 16)
        Me.Label5.TabIndex = 1850
        Me.Label5.Text = "ถึง"
        '
        'show_lnk
        '
        Me.show_lnk.ActiveLinkColor = System.Drawing.Color.LightSteelBlue
        Me.show_lnk.AutoSize = True
        Me.show_lnk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.show_lnk.ForeColor = System.Drawing.Color.LightGray
        Me.show_lnk.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.show_lnk.LinkColor = System.Drawing.Color.SteelBlue
        Me.show_lnk.Location = New System.Drawing.Point(275, 51)
        Me.show_lnk.Name = "show_lnk"
        Me.show_lnk.Size = New System.Drawing.Size(40, 16)
        Me.show_lnk.TabIndex = 3
        Me.show_lnk.TabStop = True
        Me.show_lnk.Text = "- แสดง"
        '
        'Pn_not_show
        '
        Me.Pn_not_show.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Pn_not_show.BackColor = System.Drawing.Color.Transparent
        Me.Pn_not_show.Controls.Add(Me.return_lnk)
        Me.Pn_not_show.Controls.Add(Me.record_multi)
        Me.Pn_not_show.Location = New System.Drawing.Point(837, 864)
        Me.Pn_not_show.Name = "Pn_not_show"
        Me.Pn_not_show.Size = New System.Drawing.Size(101, 26)
        Me.Pn_not_show.TabIndex = 1854
        '
        'record_multi
        '
        Me.record_multi.BackColor = System.Drawing.Color.SlateGray
        Me.record_multi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.record_multi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.record_multi.Location = New System.Drawing.Point(70, 5)
        Me.record_multi.Name = "record_multi"
        Me.record_multi.ReadOnly = True
        Me.record_multi.Size = New System.Drawing.Size(22, 15)
        Me.record_multi.TabIndex = 2037
        Me.record_multi.Text = "0"
        '
        'GunaVSeparator1
        '
        Me.GunaVSeparator1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaVSeparator1.BackColor = System.Drawing.Color.Transparent
        Me.GunaVSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GunaVSeparator1.LineColor = System.Drawing.Color.LightGray
        Me.GunaVSeparator1.Location = New System.Drawing.Point(1116, 77)
        Me.GunaVSeparator1.Name = "GunaVSeparator1"
        Me.GunaVSeparator1.Size = New System.Drawing.Size(1, 844)
        Me.GunaVSeparator1.TabIndex = 1862
        '
        'GunaVSeparator2
        '
        Me.GunaVSeparator2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GunaVSeparator2.BackColor = System.Drawing.Color.Transparent
        Me.GunaVSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GunaVSeparator2.LineColor = System.Drawing.Color.LightGray
        Me.GunaVSeparator2.Location = New System.Drawing.Point(14, 77)
        Me.GunaVSeparator2.Name = "GunaVSeparator2"
        Me.GunaVSeparator2.Size = New System.Drawing.Size(1, 844)
        Me.GunaVSeparator2.TabIndex = 1863
        '
        'header_lb
        '
        Me.header_lb.AutoSize = True
        Me.header_lb.BackColor = System.Drawing.Color.Transparent
        Me.header_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.header_lb.ForeColor = System.Drawing.Color.SteelBlue
        Me.header_lb.Location = New System.Drawing.Point(12, 8)
        Me.header_lb.Name = "header_lb"
        Me.header_lb.Size = New System.Drawing.Size(115, 24)
        Me.header_lb.TabIndex = 1866
        Me.header_lb.Text = "สรุปเอกสารขาย"
        '
        'grw
        '
        Me.grw.AllowUserToAddRows = False
        Me.grw.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.grw.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grw.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grw.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.grw.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grw.CausesValidation = False
        Me.grw.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grw.DefaultCellStyle = DataGridViewCellStyle3
        Me.grw.EnableHeadersVisualStyles = False
        Me.grw.GridColor = System.Drawing.Color.Silver
        Me.grw.Location = New System.Drawing.Point(14, 77)
        Me.grw.Name = "grw"
        Me.grw.ReadOnly = True
        Me.grw.RowHeadersVisible = False
        Me.grw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grw.Size = New System.Drawing.Size(1103, 843)
        Me.grw.TabIndex = 1867
        Me.grw.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.DeepPurple
        Me.grw.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.Lavender
        Me.grw.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.grw.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.grw.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.grw.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.grw.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.grw.ThemeStyle.GridColor = System.Drawing.Color.Silver
        Me.grw.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.grw.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.grw.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grw.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.grw.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.grw.ThemeStyle.HeaderStyle.Height = 23
        Me.grw.ThemeStyle.ReadOnly = True
        Me.grw.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.GhostWhite
        Me.grw.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.[Single]
        Me.grw.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.grw.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black
        Me.grw.ThemeStyle.RowsStyle.Height = 22
        Me.grw.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.grw.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black
        '
        'TDAY
        '
        Me.TDAY.BackColor = System.Drawing.Color.White
        Me.TDAY.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TDAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDAY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TDAY.Location = New System.Drawing.Point(0, 8)
        Me.TDAY.Name = "TDAY"
        Me.TDAY.ReadOnly = True
        Me.TDAY.Size = New System.Drawing.Size(100, 15)
        Me.TDAY.TabIndex = 1855
        Me.TDAY.TabStop = False
        Me.TDAY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GunaGroupBox1
        '
        Me.GunaGroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox1.BaseColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox1.BorderColor = System.Drawing.Color.LightGray
        Me.GunaGroupBox1.Controls.Add(Me.TDAY)
        Me.GunaGroupBox1.LineColor = System.Drawing.Color.LightGray
        Me.GunaGroupBox1.LineTop = 1
        Me.GunaGroupBox1.Location = New System.Drawing.Point(14, 919)
        Me.GunaGroupBox1.Name = "GunaGroupBox1"
        Me.GunaGroupBox1.Size = New System.Drawing.Size(1103, 10)
        Me.GunaGroupBox1.TabIndex = 1967
        Me.GunaGroupBox1.TabStop = False
        Me.GunaGroupBox1.TextLocation = New System.Drawing.Point(10, 8)
        '
        'bt_print
        '
        Me.bt_print.AnimationHoverSpeed = 0.07!
        Me.bt_print.AnimationSpeed = 0.03!
        Me.bt_print.BackColor = System.Drawing.Color.Transparent
        Me.bt_print.BaseColor = System.Drawing.Color.SteelBlue
        Me.bt_print.BorderColor = System.Drawing.Color.DimGray
        Me.bt_print.BorderSize = 1
        Me.bt_print.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_print.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_print.FocusedColor = System.Drawing.Color.Transparent
        Me.bt_print.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bt_print.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_print.Image = Nothing
        Me.bt_print.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_print.Location = New System.Drawing.Point(429, 48)
        Me.bt_print.Name = "bt_print"
        Me.bt_print.OnHoverBaseColor = System.Drawing.Color.Teal
        Me.bt_print.OnHoverBorderColor = System.Drawing.Color.DimGray
        Me.bt_print.OnHoverForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_print.OnHoverImage = Nothing
        Me.bt_print.OnPressedColor = System.Drawing.Color.Black
        Me.bt_print.OnPressedDepth = 0
        Me.bt_print.Radius = 8
        Me.bt_print.Size = New System.Drawing.Size(80, 23)
        Me.bt_print.TabIndex = 4
        Me.bt_print.Text = "Preview"
        Me.bt_print.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt_print.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAliasGridFit
        Me.bt_print.Visible = False
        '
        'bt_pdf
        '
        Me.bt_pdf.AnimationHoverSpeed = 0.07!
        Me.bt_pdf.AnimationSpeed = 0.03!
        Me.bt_pdf.BackColor = System.Drawing.Color.Transparent
        Me.bt_pdf.BaseColor = System.Drawing.Color.SteelBlue
        Me.bt_pdf.BorderColor = System.Drawing.Color.DimGray
        Me.bt_pdf.BorderSize = 1
        Me.bt_pdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_pdf.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_pdf.FocusedColor = System.Drawing.Color.Transparent
        Me.bt_pdf.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.bt_pdf.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_pdf.Image = Nothing
        Me.bt_pdf.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_pdf.Location = New System.Drawing.Point(335, 48)
        Me.bt_pdf.Name = "bt_pdf"
        Me.bt_pdf.OnHoverBaseColor = System.Drawing.Color.Teal
        Me.bt_pdf.OnHoverBorderColor = System.Drawing.Color.DimGray
        Me.bt_pdf.OnHoverForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_pdf.OnHoverImage = Nothing
        Me.bt_pdf.OnPressedColor = System.Drawing.Color.Black
        Me.bt_pdf.OnPressedDepth = 0
        Me.bt_pdf.Radius = 8
        Me.bt_pdf.Size = New System.Drawing.Size(88, 23)
        Me.bt_pdf.TabIndex = 5
        Me.bt_pdf.Text = "Create PDF"
        Me.bt_pdf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.bt_pdf.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAliasGridFit
        '
        'GunaGroupBox2
        '
        Me.GunaGroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox2.BaseColor = System.Drawing.Color.AliceBlue
        Me.GunaGroupBox2.BorderColor = System.Drawing.Color.Silver
        Me.GunaGroupBox2.BorderSize = 1
        Me.GunaGroupBox2.Controls.Add(Me.list_Guna_search)
        Me.GunaGroupBox2.Controls.Add(Me.GunaCircleButton1)
        Me.GunaGroupBox2.LineColor = System.Drawing.Color.Gainsboro
        Me.GunaGroupBox2.LineTop = 0
        Me.GunaGroupBox2.Location = New System.Drawing.Point(945, 44)
        Me.GunaGroupBox2.Name = "GunaGroupBox2"
        Me.GunaGroupBox2.Radius = 10
        Me.GunaGroupBox2.Size = New System.Drawing.Size(171, 26)
        Me.GunaGroupBox2.TabIndex = 1969
        Me.GunaGroupBox2.TextLocation = New System.Drawing.Point(10, 8)
        '
        'list_Guna_search
        '
        Me.list_Guna_search.BaseColor = System.Drawing.Color.AliceBlue
        Me.list_Guna_search.BorderColor = System.Drawing.Color.Silver
        Me.list_Guna_search.BorderSize = 0
        Me.list_Guna_search.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.list_Guna_search.FocusedBaseColor = System.Drawing.Color.AliceBlue
        Me.list_Guna_search.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.list_Guna_search.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.list_Guna_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.list_Guna_search.ForeColor = System.Drawing.Color.DimGray
        Me.list_Guna_search.Location = New System.Drawing.Point(10, 1)
        Me.list_Guna_search.Name = "list_Guna_search"
        Me.list_Guna_search.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.list_Guna_search.Size = New System.Drawing.Size(130, 24)
        Me.list_Guna_search.TabIndex = 2
        '
        'GunaCircleButton1
        '
        Me.GunaCircleButton1.AnimationHoverSpeed = 0.07!
        Me.GunaCircleButton1.AnimationSpeed = 0.03!
        Me.GunaCircleButton1.BaseColor = System.Drawing.Color.AliceBlue
        Me.GunaCircleButton1.BorderColor = System.Drawing.Color.Black
        Me.GunaCircleButton1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaCircleButton1.FocusedColor = System.Drawing.Color.Empty
        Me.GunaCircleButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GunaCircleButton1.ForeColor = System.Drawing.Color.White
        Me.GunaCircleButton1.Image = CType(resources.GetObject("GunaCircleButton1.Image"), System.Drawing.Image)
        Me.GunaCircleButton1.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaCircleButton1.Location = New System.Drawing.Point(141, 1)
        Me.GunaCircleButton1.Name = "GunaCircleButton1"
        Me.GunaCircleButton1.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(152, Byte), Integer), CType(CType(207, Byte), Integer))
        Me.GunaCircleButton1.OnHoverBorderColor = System.Drawing.Color.Black
        Me.GunaCircleButton1.OnHoverForeColor = System.Drawing.Color.White
        Me.GunaCircleButton1.OnHoverImage = CType(resources.GetObject("GunaCircleButton1.OnHoverImage"), System.Drawing.Image)
        Me.GunaCircleButton1.OnPressedColor = System.Drawing.Color.Black
        Me.GunaCircleButton1.OnPressedDepth = 28
        Me.GunaCircleButton1.Size = New System.Drawing.Size(25, 24)
        Me.GunaCircleButton1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(908, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 16)
        Me.Label2.TabIndex = 1968
        Me.Label2.Text = "ค้นหา"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(695, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 1970
        Me.Label3.Text = "ประเภท"
        '
        'cmpn_guna_cmb
        '
        Me.cmpn_guna_cmb.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmpn_guna_cmb.BackColor = System.Drawing.Color.Transparent
        Me.cmpn_guna_cmb.BaseColor = System.Drawing.Color.AliceBlue
        Me.cmpn_guna_cmb.BorderColor = System.Drawing.Color.Silver
        Me.cmpn_guna_cmb.BorderSize = 1
        Me.cmpn_guna_cmb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmpn_guna_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmpn_guna_cmb.FocusedColor = System.Drawing.Color.Empty
        Me.cmpn_guna_cmb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmpn_guna_cmb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmpn_guna_cmb.FormattingEnabled = True
        Me.cmpn_guna_cmb.Items.AddRange(New Object() {"เลขที่เอกสาร", "รหัส - ชื่อลูกค้า"})
        Me.cmpn_guna_cmb.Location = New System.Drawing.Point(740, 46)
        Me.cmpn_guna_cmb.Name = "cmpn_guna_cmb"
        Me.cmpn_guna_cmb.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmpn_guna_cmb.OnHoverItemForeColor = System.Drawing.Color.White
        Me.cmpn_guna_cmb.Radius = 4
        Me.cmpn_guna_cmb.Size = New System.Drawing.Size(161, 23)
        Me.cmpn_guna_cmb.StartIndex = 0
        Me.cmpn_guna_cmb.TabIndex = 1971
        '
        'Basedate_to
        '
        Me.Basedate_to.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Basedate_to.Location = New System.Drawing.Point(172, 49)
        Me.Basedate_to.Name = "Basedate_to"
        Me.Basedate_to.Size = New System.Drawing.Size(98, 22)
        Me.Basedate_to.TabIndex = 2
        Me.Basedate_to.TabStop = False
        '
        'Basedate_from
        '
        Me.Basedate_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Basedate_from.Location = New System.Drawing.Point(44, 49)
        Me.Basedate_from.Name = "Basedate_from"
        Me.Basedate_from.Size = New System.Drawing.Size(98, 22)
        Me.Basedate_from.TabIndex = 1
        Me.Basedate_from.TabStop = False
        '
        'doc_tab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CancelButton = Me.return_lnk
        Me.ClientSize = New System.Drawing.Size(1134, 932)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmpn_guna_cmb)
        Me.Controls.Add(Me.GunaGroupBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Pn_not_show)
        Me.Controls.Add(Me.bt_pdf)
        Me.Controls.Add(Me.bt_print)
        Me.Controls.Add(Me.Basedate_to)
        Me.Controls.Add(Me.Basedate_from)
        Me.Controls.Add(Me.GunaGroupBox1)
        Me.Controls.Add(Me.header_lb)
        Me.Controls.Add(Me.GunaVSeparator2)
        Me.Controls.Add(Me.GunaVSeparator1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.show_lnk)
        Me.Controls.Add(Me.GunaControlBox6)
        Me.Controls.Add(Me.GunaControlBox5)
        Me.Controls.Add(Me.grw)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "doc_tab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "สรุปเอกสารขาย"
        Me.Pn_not_show.ResumeLayout(False)
        Me.Pn_not_show.PerformLayout()
        CType(Me.grw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GunaGroupBox1.ResumeLayout(False)
        Me.GunaGroupBox1.PerformLayout()
        Me.GunaGroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents return_lnk As System.Windows.Forms.LinkLabel
    Friend WithEvents GunaControlBox6 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents GunaControlBox5 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents show_lnk As System.Windows.Forms.LinkLabel
    Friend WithEvents Pn_not_show As System.Windows.Forms.Panel
    Friend WithEvents record_multi As TextBox
    Friend WithEvents GunaVSeparator1 As Guna.UI.WinForms.GunaVSeparator
    Friend WithEvents GunaVSeparator2 As Guna.UI.WinForms.GunaVSeparator
    Friend WithEvents header_lb As Label
    Friend WithEvents grw As Guna.UI.WinForms.GunaDataGridView
    Friend WithEvents TDAY As TextBox
    Friend WithEvents GunaGroupBox1 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents Basedate_from As BaseDateTime_blue
    Friend WithEvents Basedate_to As BaseDateTime_blue
    Friend WithEvents bt_print As Guna.UI.WinForms.GunaButton
    Friend WithEvents bt_pdf As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaGroupBox2 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents list_Guna_search As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents GunaCircleButton1 As Guna.UI.WinForms.GunaCircleButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmpn_guna_cmb As Guna.UI.WinForms.GunaComboBox
    'Friend WithEvents CachedDOC_INV10021 As LADDAWAN_SOFT.CachedDOC_INV1002
End Class

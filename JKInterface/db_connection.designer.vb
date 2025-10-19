<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class db_connection
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
        Me.components = New System.ComponentModel.Container()
        Me.GunaGroupBox1 = New Guna.UI.WinForms.GunaGroupBox()
        Me.lnk_location = New System.Windows.Forms.LinkLabel()
        Me.tb_pdfPath = New Guna.UI.WinForms.GunaTextBox()
        Me.password_guna = New Guna.UI.WinForms.GunaTextBox()
        Me.user_guna = New Guna.UI.WinForms.GunaTextBox()
        Me.database_guna = New Guna.UI.WinForms.GunaTextBox()
        Me.host_guna = New Guna.UI.WinForms.GunaTextBox()
        Me.close_bt = New Guna.UI.WinForms.GunaButton()
        Me.save_bt = New Guna.UI.WinForms.GunaButton()
        Me.Pn_not_show = New System.Windows.Forms.Panel()
        Me.insert_status = New System.Windows.Forms.TextBox()
        Me.SurenameLabel = New System.Windows.Forms.Label()
        Me.test_config_bt = New Guna.UI.WinForms.GunaButton()
        Me.GunaControlBox2 = New Guna.UI.WinForms.GunaControlBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GunaSeparator2 = New Guna.UI.WinForms.GunaSeparator()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_status = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GunaDragControl1 = New Guna.UI.WinForms.GunaDragControl(Me.components)
        Me.GunaGroupBox1.SuspendLayout()
        Me.Pn_not_show.SuspendLayout()
        Me.SuspendLayout()
        '
        'GunaGroupBox1
        '
        Me.GunaGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GunaGroupBox1.BaseColor = System.Drawing.Color.WhiteSmoke
        Me.GunaGroupBox1.BorderColor = System.Drawing.Color.White
        Me.GunaGroupBox1.BorderSize = 1
        Me.GunaGroupBox1.Controls.Add(Me.lnk_location)
        Me.GunaGroupBox1.Controls.Add(Me.tb_pdfPath)
        Me.GunaGroupBox1.Controls.Add(Me.password_guna)
        Me.GunaGroupBox1.Controls.Add(Me.user_guna)
        Me.GunaGroupBox1.Controls.Add(Me.database_guna)
        Me.GunaGroupBox1.Controls.Add(Me.host_guna)
        Me.GunaGroupBox1.Controls.Add(Me.close_bt)
        Me.GunaGroupBox1.Controls.Add(Me.save_bt)
        Me.GunaGroupBox1.Controls.Add(Me.Pn_not_show)
        Me.GunaGroupBox1.Controls.Add(Me.SurenameLabel)
        Me.GunaGroupBox1.Controls.Add(Me.test_config_bt)
        Me.GunaGroupBox1.Controls.Add(Me.GunaControlBox2)
        Me.GunaGroupBox1.Controls.Add(Me.Label2)
        Me.GunaGroupBox1.Controls.Add(Me.GunaSeparator2)
        Me.GunaGroupBox1.Controls.Add(Me.Label5)
        Me.GunaGroupBox1.Controls.Add(Me.Label1)
        Me.GunaGroupBox1.Controls.Add(Me.lb_status)
        Me.GunaGroupBox1.Controls.Add(Me.Label3)
        Me.GunaGroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GunaGroupBox1.ForeColor = System.Drawing.Color.White
        Me.GunaGroupBox1.LineColor = System.Drawing.Color.SteelBlue
        Me.GunaGroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GunaGroupBox1.Name = "GunaGroupBox1"
        Me.GunaGroupBox1.Size = New System.Drawing.Size(630, 320)
        Me.GunaGroupBox1.TabIndex = 1124
        Me.GunaGroupBox1.Text = "Config"
        Me.GunaGroupBox1.TextLocation = New System.Drawing.Point(10, 8)
        '
        'lnk_location
        '
        Me.lnk_location.ActiveLinkColor = System.Drawing.Color.LightGray
        Me.lnk_location.AutoSize = True
        Me.lnk_location.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnk_location.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lnk_location.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lnk_location.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lnk_location.Location = New System.Drawing.Point(468, 214)
        Me.lnk_location.Name = "lnk_location"
        Me.lnk_location.Size = New System.Drawing.Size(29, 16)
        Me.lnk_location.TabIndex = 1588
        Me.lnk_location.TabStop = True
        Me.lnk_location.Text = "เลือก"
        '
        'tb_pdfPath
        '
        Me.tb_pdfPath.BackColor = System.Drawing.Color.Transparent
        Me.tb_pdfPath.BaseColor = System.Drawing.Color.White
        Me.tb_pdfPath.BorderColor = System.Drawing.Color.Silver
        Me.tb_pdfPath.BorderSize = 1
        Me.tb_pdfPath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tb_pdfPath.FocusedBaseColor = System.Drawing.Color.White
        Me.tb_pdfPath.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tb_pdfPath.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.tb_pdfPath.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.tb_pdfPath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tb_pdfPath.Location = New System.Drawing.Point(127, 208)
        Me.tb_pdfPath.Name = "tb_pdfPath"
        Me.tb_pdfPath.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tb_pdfPath.Radius = 2
        Me.tb_pdfPath.Size = New System.Drawing.Size(337, 28)
        Me.tb_pdfPath.TabIndex = 1587
        '
        'password_guna
        '
        Me.password_guna.BackColor = System.Drawing.Color.Transparent
        Me.password_guna.BaseColor = System.Drawing.Color.White
        Me.password_guna.BorderColor = System.Drawing.Color.Silver
        Me.password_guna.BorderSize = 1
        Me.password_guna.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.password_guna.FocusedBaseColor = System.Drawing.Color.White
        Me.password_guna.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.password_guna.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.password_guna.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.password_guna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.password_guna.Location = New System.Drawing.Point(127, 174)
        Me.password_guna.Name = "password_guna"
        Me.password_guna.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.password_guna.Radius = 2
        Me.password_guna.Size = New System.Drawing.Size(337, 28)
        Me.password_guna.TabIndex = 5
        Me.password_guna.UseSystemPasswordChar = True
        '
        'user_guna
        '
        Me.user_guna.BackColor = System.Drawing.Color.Transparent
        Me.user_guna.BaseColor = System.Drawing.Color.White
        Me.user_guna.BorderColor = System.Drawing.Color.Silver
        Me.user_guna.BorderSize = 1
        Me.user_guna.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.user_guna.FocusedBaseColor = System.Drawing.Color.White
        Me.user_guna.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.user_guna.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.user_guna.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.user_guna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.user_guna.Location = New System.Drawing.Point(127, 141)
        Me.user_guna.Name = "user_guna"
        Me.user_guna.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.user_guna.Radius = 2
        Me.user_guna.Size = New System.Drawing.Size(337, 28)
        Me.user_guna.TabIndex = 4
        '
        'database_guna
        '
        Me.database_guna.BackColor = System.Drawing.Color.Transparent
        Me.database_guna.BaseColor = System.Drawing.Color.White
        Me.database_guna.BorderColor = System.Drawing.Color.Silver
        Me.database_guna.BorderSize = 1
        Me.database_guna.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.database_guna.FocusedBaseColor = System.Drawing.Color.White
        Me.database_guna.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.database_guna.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.database_guna.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.database_guna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.database_guna.Location = New System.Drawing.Point(127, 108)
        Me.database_guna.Name = "database_guna"
        Me.database_guna.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.database_guna.Radius = 2
        Me.database_guna.Size = New System.Drawing.Size(337, 28)
        Me.database_guna.TabIndex = 3
        '
        'host_guna
        '
        Me.host_guna.BackColor = System.Drawing.Color.Transparent
        Me.host_guna.BaseColor = System.Drawing.Color.White
        Me.host_guna.BorderColor = System.Drawing.Color.Silver
        Me.host_guna.BorderSize = 1
        Me.host_guna.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.host_guna.FocusedBaseColor = System.Drawing.Color.White
        Me.host_guna.FocusedBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.host_guna.FocusedForeColor = System.Drawing.SystemColors.ControlText
        Me.host_guna.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.host_guna.ForeColor = System.Drawing.SystemColors.WindowText
        Me.host_guna.Location = New System.Drawing.Point(127, 75)
        Me.host_guna.Name = "host_guna"
        Me.host_guna.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.host_guna.Radius = 2
        Me.host_guna.Size = New System.Drawing.Size(337, 28)
        Me.host_guna.TabIndex = 2
        '
        'close_bt
        '
        Me.close_bt.AnimationHoverSpeed = 0.07!
        Me.close_bt.AnimationSpeed = 0.03!
        Me.close_bt.BackColor = System.Drawing.Color.Transparent
        Me.close_bt.BaseColor = System.Drawing.Color.Gray
        Me.close_bt.BorderColor = System.Drawing.Color.DimGray
        Me.close_bt.BorderSize = 1
        Me.close_bt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.close_bt.DialogResult = System.Windows.Forms.DialogResult.None
        Me.close_bt.FocusedColor = System.Drawing.Color.Transparent
        Me.close_bt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.close_bt.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.close_bt.Image = Nothing
        Me.close_bt.ImageSize = New System.Drawing.Size(20, 20)
        Me.close_bt.Location = New System.Drawing.Point(500, 133)
        Me.close_bt.Name = "close_bt"
        Me.close_bt.OnHoverBaseColor = System.Drawing.Color.Teal
        Me.close_bt.OnHoverBorderColor = System.Drawing.Color.DimGray
        Me.close_bt.OnHoverForeColor = System.Drawing.Color.WhiteSmoke
        Me.close_bt.OnHoverImage = Nothing
        Me.close_bt.OnPressedColor = System.Drawing.Color.Black
        Me.close_bt.OnPressedDepth = 0
        Me.close_bt.Radius = 8
        Me.close_bt.Size = New System.Drawing.Size(110, 23)
        Me.close_bt.TabIndex = 1586
        Me.close_bt.Text = "ปิดหน้าจอ"
        Me.close_bt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.close_bt.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAliasGridFit
        '
        'save_bt
        '
        Me.save_bt.AnimationHoverSpeed = 0.07!
        Me.save_bt.AnimationSpeed = 0.03!
        Me.save_bt.BackColor = System.Drawing.Color.Transparent
        Me.save_bt.BaseColor = System.Drawing.Color.Gray
        Me.save_bt.BorderColor = System.Drawing.Color.DimGray
        Me.save_bt.BorderSize = 1
        Me.save_bt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.save_bt.DialogResult = System.Windows.Forms.DialogResult.None
        Me.save_bt.FocusedColor = System.Drawing.Color.Transparent
        Me.save_bt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.save_bt.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.save_bt.Image = Nothing
        Me.save_bt.ImageSize = New System.Drawing.Size(20, 20)
        Me.save_bt.Location = New System.Drawing.Point(500, 106)
        Me.save_bt.Name = "save_bt"
        Me.save_bt.OnHoverBaseColor = System.Drawing.Color.Teal
        Me.save_bt.OnHoverBorderColor = System.Drawing.Color.DimGray
        Me.save_bt.OnHoverForeColor = System.Drawing.Color.WhiteSmoke
        Me.save_bt.OnHoverImage = Nothing
        Me.save_bt.OnPressedColor = System.Drawing.Color.Black
        Me.save_bt.OnPressedDepth = 0
        Me.save_bt.Radius = 8
        Me.save_bt.Size = New System.Drawing.Size(110, 23)
        Me.save_bt.TabIndex = 1586
        Me.save_bt.Text = "บันทึก"
        Me.save_bt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.save_bt.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAliasGridFit
        '
        'Pn_not_show
        '
        Me.Pn_not_show.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Pn_not_show.Controls.Add(Me.insert_status)
        Me.Pn_not_show.Location = New System.Drawing.Point(116, 241)
        Me.Pn_not_show.Name = "Pn_not_show"
        Me.Pn_not_show.Size = New System.Drawing.Size(297, 33)
        Me.Pn_not_show.TabIndex = 852
        '
        'insert_status
        '
        Me.insert_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.insert_status.Location = New System.Drawing.Point(10, 6)
        Me.insert_status.Name = "insert_status"
        Me.insert_status.Size = New System.Drawing.Size(21, 20)
        Me.insert_status.TabIndex = 488
        Me.insert_status.TabStop = False
        Me.insert_status.Text = "0"
        '
        'SurenameLabel
        '
        Me.SurenameLabel.AutoSize = True
        Me.SurenameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.SurenameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SurenameLabel.Location = New System.Drawing.Point(36, 81)
        Me.SurenameLabel.Name = "SurenameLabel"
        Me.SurenameLabel.Size = New System.Drawing.Size(88, 16)
        Me.SurenameLabel.TabIndex = 1407
        Me.SurenameLabel.Text = "Server Name"
        '
        'test_config_bt
        '
        Me.test_config_bt.AnimationHoverSpeed = 0.07!
        Me.test_config_bt.AnimationSpeed = 0.03!
        Me.test_config_bt.BackColor = System.Drawing.Color.Transparent
        Me.test_config_bt.BaseColor = System.Drawing.Color.Gray
        Me.test_config_bt.BorderColor = System.Drawing.Color.DimGray
        Me.test_config_bt.BorderSize = 1
        Me.test_config_bt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.test_config_bt.DialogResult = System.Windows.Forms.DialogResult.None
        Me.test_config_bt.FocusedColor = System.Drawing.Color.Transparent
        Me.test_config_bt.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.test_config_bt.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.test_config_bt.Image = Nothing
        Me.test_config_bt.ImageSize = New System.Drawing.Size(20, 20)
        Me.test_config_bt.Location = New System.Drawing.Point(500, 79)
        Me.test_config_bt.Name = "test_config_bt"
        Me.test_config_bt.OnHoverBaseColor = System.Drawing.Color.Teal
        Me.test_config_bt.OnHoverBorderColor = System.Drawing.Color.DimGray
        Me.test_config_bt.OnHoverForeColor = System.Drawing.Color.WhiteSmoke
        Me.test_config_bt.OnHoverImage = Nothing
        Me.test_config_bt.OnPressedColor = System.Drawing.Color.Black
        Me.test_config_bt.OnPressedDepth = 0
        Me.test_config_bt.Radius = 8
        Me.test_config_bt.Size = New System.Drawing.Size(110, 23)
        Me.test_config_bt.TabIndex = 5
        Me.test_config_bt.Text = "ทดสอบการเชื่อมต่อ"
        Me.test_config_bt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.test_config_bt.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAliasGridFit
        '
        'GunaControlBox2
        '
        Me.GunaControlBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaControlBox2.AnimationHoverSpeed = 0.07!
        Me.GunaControlBox2.AnimationSpeed = 0.03!
        Me.GunaControlBox2.IconColor = System.Drawing.Color.White
        Me.GunaControlBox2.IconSize = 15.0!
        Me.GunaControlBox2.Location = New System.Drawing.Point(584, 0)
        Me.GunaControlBox2.Name = "GunaControlBox2"
        Me.GunaControlBox2.OnHoverBackColor = System.Drawing.Color.FromArgb(CType(CType(103, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.GunaControlBox2.OnHoverIconColor = System.Drawing.Color.White
        Me.GunaControlBox2.OnPressedColor = System.Drawing.Color.Black
        Me.GunaControlBox2.Size = New System.Drawing.Size(45, 29)
        Me.GunaControlBox2.TabIndex = 1540
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(36, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 1415
        Me.Label2.Text = "Database"
        '
        'GunaSeparator2
        '
        Me.GunaSeparator2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GunaSeparator2.LineColor = System.Drawing.Color.LightGray
        Me.GunaSeparator2.Location = New System.Drawing.Point(0, 25)
        Me.GunaSeparator2.Name = "GunaSeparator2"
        Me.GunaSeparator2.Size = New System.Drawing.Size(630, 10)
        Me.GunaSeparator2.TabIndex = 1554
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(36, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 16)
        Me.Label5.TabIndex = 1416
        Me.Label5.Text = "Pdf Path"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(36, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 1416
        Me.Label1.Text = "Password"
        '
        'lb_status
        '
        Me.lb_status.AutoSize = True
        Me.lb_status.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lb_status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lb_status.Location = New System.Drawing.Point(130, 163)
        Me.lb_status.Name = "lb_status"
        Me.lb_status.Size = New System.Drawing.Size(0, 16)
        Me.lb_status.TabIndex = 1538
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(36, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 1417
        Me.Label3.Text = "User"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GunaDragControl1
        '
        Me.GunaDragControl1.TargetControl = Me.GunaGroupBox1
        '
        'db_connection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(630, 320)
        Me.Controls.Add(Me.GunaGroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "db_connection"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Database Config"
        Me.GunaGroupBox1.ResumeLayout(False)
        Me.GunaGroupBox1.PerformLayout()
        Me.Pn_not_show.ResumeLayout(False)
        Me.Pn_not_show.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents SCRSQLDataSet As Reporter3.SCRSQLDataSet
    'Friend WithEvents TbcustomerTableAdapter As Reporter3.SCRSQLDataSetTableAdapters.tbcustomerTableAdapter
    'Friend WithEvents TableAdapterManager As Reporter3.SCRSQLDataSetTableAdapters.TableAdapterManager
    Friend WithEvents GunaGroupBox1 As Guna.UI.WinForms.GunaGroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SurenameLabel As System.Windows.Forms.Label
    Friend WithEvents lb_status As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GunaSeparator2 As Guna.UI.WinForms.GunaSeparator
    Friend WithEvents GunaControlBox2 As Guna.UI.WinForms.GunaControlBox
    Friend WithEvents insert_status As System.Windows.Forms.TextBox
    Friend WithEvents Pn_not_show As System.Windows.Forms.Panel
    Friend WithEvents test_config_bt As Guna.UI.WinForms.GunaButton
    Friend WithEvents GunaDragControl1 As Guna.UI.WinForms.GunaDragControl
    Friend WithEvents close_bt As Guna.UI.WinForms.GunaButton
    Friend WithEvents save_bt As Guna.UI.WinForms.GunaButton
    Friend WithEvents password_guna As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents user_guna As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents database_guna As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents host_guna As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents lnk_location As LinkLabel
    Friend WithEvents tb_pdfPath As Guna.UI.WinForms.GunaTextBox
    Friend WithEvents Label5 As Label
    'Friend WithEvents CachedDOC_INV10021 As LADDAWAN_SOFT.CachedDOC_INV1002
    'Friend WithEvents CachedDOC_INV10022 As LADDAWAN_SOFT.CachedDOC_INV1002
End Class

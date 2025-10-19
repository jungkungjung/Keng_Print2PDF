<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainmenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainmenu))
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.Tool_sales_order = New System.Windows.Forms.ToolStripButton()
        Me.Tool_finance_new = New System.Windows.Forms.ToolStripButton()
        Me.cmpn_name_strip = New System.Windows.Forms.ToolStripLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status_1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pn_sale = New System.Windows.Forms.Panel()
        Me.bt_cnCash = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.bt_all = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.bt_cn = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.bt_sales = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.GunaAdvenceButton4 = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.bt_debitnote2 = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.bt_creditnote2 = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.bt_deposit2 = New Guna.UI.WinForms.GunaAdvenceButton()
        Me.ToolStrip3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pn_sale.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Tool_sales_order, Me.Tool_finance_new, Me.cmpn_name_strip})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(1098, 25)
        Me.ToolStrip3.TabIndex = 5
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'Tool_sales_order
        '
        Me.Tool_sales_order.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Tool_sales_order.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_sales_order.Name = "Tool_sales_order"
        Me.Tool_sales_order.Size = New System.Drawing.Size(65, 22)
        Me.Tool_sales_order.Text = "ระบบซื้อขาย"
        Me.Tool_sales_order.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Tool_sales_order.Visible = False
        '
        'Tool_finance_new
        '
        Me.Tool_finance_new.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.Tool_finance_new.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_finance_new.Name = "Tool_finance_new"
        Me.Tool_finance_new.Size = New System.Drawing.Size(56, 22)
        Me.Tool_finance_new.Text = "    ตั้งค่า   "
        Me.Tool_finance_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Tool_finance_new.ToolTipText = "ตั้งค่า "
        '
        'cmpn_name_strip
        '
        Me.cmpn_name_strip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmpn_name_strip.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.cmpn_name_strip.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmpn_name_strip.Name = "cmpn_name_strip"
        Me.cmpn_name_strip.Size = New System.Drawing.Size(0, 22)
        Me.cmpn_name_strip.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status_1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 615)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1098, 22)
        Me.StatusStrip1.TabIndex = 29
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status_1
        '
        Me.status_1.BackColor = System.Drawing.Color.Transparent
        Me.status_1.ForeColor = System.Drawing.Color.DimGray
        Me.status_1.Name = "status_1"
        Me.status_1.Size = New System.Drawing.Size(40, 17)
        Me.status_1.Text = "เวอร์ชั่น"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.SlateGray
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'pn_sale
        '
        Me.pn_sale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pn_sale.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.pn_sale.Controls.Add(Me.bt_all)
        Me.pn_sale.Controls.Add(Me.bt_deposit2)
        Me.pn_sale.Controls.Add(Me.bt_creditnote2)
        Me.pn_sale.Controls.Add(Me.bt_debitnote2)
        Me.pn_sale.Controls.Add(Me.bt_cnCash)
        Me.pn_sale.Controls.Add(Me.bt_cn)
        Me.pn_sale.Controls.Add(Me.bt_sales)
        Me.pn_sale.Controls.Add(Me.GunaAdvenceButton4)
        Me.pn_sale.Dock = System.Windows.Forms.DockStyle.Left
        Me.pn_sale.Location = New System.Drawing.Point(0, 25)
        Me.pn_sale.Name = "pn_sale"
        Me.pn_sale.Size = New System.Drawing.Size(154, 590)
        Me.pn_sale.TabIndex = 31
        '
        'bt_cnCash
        '
        Me.bt_cnCash.AnimationHoverSpeed = 0.07!
        Me.bt_cnCash.AnimationSpeed = 0.03!
        Me.bt_cnCash.BackColor = System.Drawing.Color.LightSteelBlue
        Me.bt_cnCash.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.bt_cnCash.BorderColor = System.Drawing.Color.Black
        Me.bt_cnCash.CheckedBaseColor = System.Drawing.Color.Gray
        Me.bt_cnCash.CheckedBorderColor = System.Drawing.Color.Black
        Me.bt_cnCash.CheckedForeColor = System.Drawing.Color.White
        Me.bt_cnCash.CheckedImage = CType(resources.GetObject("bt_cnCash.CheckedImage"), System.Drawing.Image)
        Me.bt_cnCash.CheckedLineColor = System.Drawing.Color.DimGray
        Me.bt_cnCash.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_cnCash.Dock = System.Windows.Forms.DockStyle.Top
        Me.bt_cnCash.FocusedColor = System.Drawing.Color.Empty
        Me.bt_cnCash.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cnCash.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_cnCash.Image = CType(resources.GetObject("bt_cnCash.Image"), System.Drawing.Image)
        Me.bt_cnCash.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_cnCash.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_cnCash.Location = New System.Drawing.Point(0, 78)
        Me.bt_cnCash.Name = "bt_cnCash"
        Me.bt_cnCash.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bt_cnCash.OnHoverBorderColor = System.Drawing.Color.Black
        Me.bt_cnCash.OnHoverForeColor = System.Drawing.Color.White
        Me.bt_cnCash.OnHoverImage = Nothing
        Me.bt_cnCash.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_cnCash.OnPressedColor = System.Drawing.Color.Black
        Me.bt_cnCash.Size = New System.Drawing.Size(154, 26)
        Me.bt_cnCash.TabIndex = 35
        Me.bt_cnCash.Text = "ใบรับคืนสด"
        '
        'bt_all
        '
        Me.bt_all.AnimationHoverSpeed = 0.07!
        Me.bt_all.AnimationSpeed = 0.03!
        Me.bt_all.BackColor = System.Drawing.Color.LightSteelBlue
        Me.bt_all.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.bt_all.BorderColor = System.Drawing.Color.Black
        Me.bt_all.CheckedBaseColor = System.Drawing.Color.Gray
        Me.bt_all.CheckedBorderColor = System.Drawing.Color.Black
        Me.bt_all.CheckedForeColor = System.Drawing.Color.White
        Me.bt_all.CheckedImage = CType(resources.GetObject("bt_all.CheckedImage"), System.Drawing.Image)
        Me.bt_all.CheckedLineColor = System.Drawing.Color.DimGray
        Me.bt_all.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_all.Dock = System.Windows.Forms.DockStyle.Top
        Me.bt_all.FocusedColor = System.Drawing.Color.Empty
        Me.bt_all.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_all.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_all.Image = CType(resources.GetObject("bt_all.Image"), System.Drawing.Image)
        Me.bt_all.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_all.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_all.Location = New System.Drawing.Point(0, 182)
        Me.bt_all.Name = "bt_all"
        Me.bt_all.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bt_all.OnHoverBorderColor = System.Drawing.Color.Black
        Me.bt_all.OnHoverForeColor = System.Drawing.Color.White
        Me.bt_all.OnHoverImage = Nothing
        Me.bt_all.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_all.OnPressedColor = System.Drawing.Color.Black
        Me.bt_all.Size = New System.Drawing.Size(154, 26)
        Me.bt_all.TabIndex = 38
        Me.bt_all.Text = "รวมทุกเอกสาร"
        '
        'bt_cn
        '
        Me.bt_cn.AnimationHoverSpeed = 0.07!
        Me.bt_cn.AnimationSpeed = 0.03!
        Me.bt_cn.BackColor = System.Drawing.Color.LightSteelBlue
        Me.bt_cn.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.bt_cn.BorderColor = System.Drawing.Color.Black
        Me.bt_cn.CheckedBaseColor = System.Drawing.Color.Gray
        Me.bt_cn.CheckedBorderColor = System.Drawing.Color.Black
        Me.bt_cn.CheckedForeColor = System.Drawing.Color.White
        Me.bt_cn.CheckedImage = CType(resources.GetObject("bt_cn.CheckedImage"), System.Drawing.Image)
        Me.bt_cn.CheckedLineColor = System.Drawing.Color.DimGray
        Me.bt_cn.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_cn.Dock = System.Windows.Forms.DockStyle.Top
        Me.bt_cn.FocusedColor = System.Drawing.Color.Empty
        Me.bt_cn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_cn.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_cn.Image = CType(resources.GetObject("bt_cn.Image"), System.Drawing.Image)
        Me.bt_cn.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_cn.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_cn.Location = New System.Drawing.Point(0, 52)
        Me.bt_cn.Name = "bt_cn"
        Me.bt_cn.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bt_cn.OnHoverBorderColor = System.Drawing.Color.Black
        Me.bt_cn.OnHoverForeColor = System.Drawing.Color.White
        Me.bt_cn.OnHoverImage = Nothing
        Me.bt_cn.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_cn.OnPressedColor = System.Drawing.Color.Black
        Me.bt_cn.Size = New System.Drawing.Size(154, 26)
        Me.bt_cn.TabIndex = 34
        Me.bt_cn.Text = "ใบรับคืนสินค้า"
        '
        'bt_sales
        '
        Me.bt_sales.AnimationHoverSpeed = 0.07!
        Me.bt_sales.AnimationSpeed = 0.03!
        Me.bt_sales.BackColor = System.Drawing.Color.LightSteelBlue
        Me.bt_sales.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.bt_sales.BorderColor = System.Drawing.Color.Black
        Me.bt_sales.CheckedBaseColor = System.Drawing.Color.Gray
        Me.bt_sales.CheckedBorderColor = System.Drawing.Color.Black
        Me.bt_sales.CheckedForeColor = System.Drawing.Color.White
        Me.bt_sales.CheckedImage = CType(resources.GetObject("bt_sales.CheckedImage"), System.Drawing.Image)
        Me.bt_sales.CheckedLineColor = System.Drawing.Color.DimGray
        Me.bt_sales.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_sales.Dock = System.Windows.Forms.DockStyle.Top
        Me.bt_sales.FocusedColor = System.Drawing.Color.Empty
        Me.bt_sales.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_sales.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_sales.Image = CType(resources.GetObject("bt_sales.Image"), System.Drawing.Image)
        Me.bt_sales.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_sales.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_sales.Location = New System.Drawing.Point(0, 26)
        Me.bt_sales.Name = "bt_sales"
        Me.bt_sales.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bt_sales.OnHoverBorderColor = System.Drawing.Color.Black
        Me.bt_sales.OnHoverForeColor = System.Drawing.Color.White
        Me.bt_sales.OnHoverImage = Nothing
        Me.bt_sales.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_sales.OnPressedColor = System.Drawing.Color.Black
        Me.bt_sales.Size = New System.Drawing.Size(154, 26)
        Me.bt_sales.TabIndex = 33
        Me.bt_sales.Text = "ใบขายสินค้า"
        '
        'GunaAdvenceButton4
        '
        Me.GunaAdvenceButton4.AnimationHoverSpeed = 0.07!
        Me.GunaAdvenceButton4.AnimationSpeed = 0.03!
        Me.GunaAdvenceButton4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GunaAdvenceButton4.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.GunaAdvenceButton4.BorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButton4.CheckedBaseColor = System.Drawing.Color.Gray
        Me.GunaAdvenceButton4.CheckedBorderColor = System.Drawing.Color.Black
        Me.GunaAdvenceButton4.CheckedForeColor = System.Drawing.Color.White
        Me.GunaAdvenceButton4.CheckedImage = CType(resources.GetObject("GunaAdvenceButton4.CheckedImage"), System.Drawing.Image)
        Me.GunaAdvenceButton4.CheckedLineColor = System.Drawing.Color.DimGray
        Me.GunaAdvenceButton4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.GunaAdvenceButton4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GunaAdvenceButton4.FocusedColor = System.Drawing.Color.Empty
        Me.GunaAdvenceButton4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaAdvenceButton4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.GunaAdvenceButton4.Image = Nothing
        Me.GunaAdvenceButton4.ImageSize = New System.Drawing.Size(20, 20)
        Me.GunaAdvenceButton4.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.GunaAdvenceButton4.Location = New System.Drawing.Point(0, 0)
        Me.GunaAdvenceButton4.Name = "GunaAdvenceButton4"
        Me.GunaAdvenceButton4.OnHoverBaseColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButton4.OnHoverBorderColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButton4.OnHoverForeColor = System.Drawing.Color.DarkSlateBlue
        Me.GunaAdvenceButton4.OnHoverImage = Nothing
        Me.GunaAdvenceButton4.OnHoverLineColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButton4.OnPressedColor = System.Drawing.Color.Transparent
        Me.GunaAdvenceButton4.Size = New System.Drawing.Size(154, 26)
        Me.GunaAdvenceButton4.TabIndex = 32
        Me.GunaAdvenceButton4.Text = "เอกสาร"
        '
        'bt_debitnote2
        '
        Me.bt_debitnote2.AnimationHoverSpeed = 0.07!
        Me.bt_debitnote2.AnimationSpeed = 0.03!
        Me.bt_debitnote2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.bt_debitnote2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.bt_debitnote2.BorderColor = System.Drawing.Color.Black
        Me.bt_debitnote2.CheckedBaseColor = System.Drawing.Color.Gray
        Me.bt_debitnote2.CheckedBorderColor = System.Drawing.Color.Black
        Me.bt_debitnote2.CheckedForeColor = System.Drawing.Color.White
        Me.bt_debitnote2.CheckedImage = CType(resources.GetObject("bt_debitnote2.CheckedImage"), System.Drawing.Image)
        Me.bt_debitnote2.CheckedLineColor = System.Drawing.Color.DimGray
        Me.bt_debitnote2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_debitnote2.Dock = System.Windows.Forms.DockStyle.Top
        Me.bt_debitnote2.FocusedColor = System.Drawing.Color.Empty
        Me.bt_debitnote2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_debitnote2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_debitnote2.Image = CType(resources.GetObject("bt_debitnote2.Image"), System.Drawing.Image)
        Me.bt_debitnote2.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_debitnote2.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_debitnote2.Location = New System.Drawing.Point(0, 104)
        Me.bt_debitnote2.Name = "bt_debitnote2"
        Me.bt_debitnote2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bt_debitnote2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.bt_debitnote2.OnHoverForeColor = System.Drawing.Color.White
        Me.bt_debitnote2.OnHoverImage = Nothing
        Me.bt_debitnote2.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_debitnote2.OnPressedColor = System.Drawing.Color.Black
        Me.bt_debitnote2.Size = New System.Drawing.Size(154, 26)
        Me.bt_debitnote2.TabIndex = 36
        Me.bt_debitnote2.Text = "ใบเพิ่มหนี้"
        '
        'bt_creditnote2
        '
        Me.bt_creditnote2.AnimationHoverSpeed = 0.07!
        Me.bt_creditnote2.AnimationSpeed = 0.03!
        Me.bt_creditnote2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.bt_creditnote2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.bt_creditnote2.BorderColor = System.Drawing.Color.Black
        Me.bt_creditnote2.CheckedBaseColor = System.Drawing.Color.Gray
        Me.bt_creditnote2.CheckedBorderColor = System.Drawing.Color.Black
        Me.bt_creditnote2.CheckedForeColor = System.Drawing.Color.White
        Me.bt_creditnote2.CheckedImage = CType(resources.GetObject("bt_creditnote2.CheckedImage"), System.Drawing.Image)
        Me.bt_creditnote2.CheckedLineColor = System.Drawing.Color.DimGray
        Me.bt_creditnote2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_creditnote2.Dock = System.Windows.Forms.DockStyle.Top
        Me.bt_creditnote2.FocusedColor = System.Drawing.Color.Empty
        Me.bt_creditnote2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_creditnote2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_creditnote2.Image = CType(resources.GetObject("bt_creditnote2.Image"), System.Drawing.Image)
        Me.bt_creditnote2.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_creditnote2.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_creditnote2.Location = New System.Drawing.Point(0, 130)
        Me.bt_creditnote2.Name = "bt_creditnote2"
        Me.bt_creditnote2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bt_creditnote2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.bt_creditnote2.OnHoverForeColor = System.Drawing.Color.White
        Me.bt_creditnote2.OnHoverImage = Nothing
        Me.bt_creditnote2.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_creditnote2.OnPressedColor = System.Drawing.Color.Black
        Me.bt_creditnote2.Size = New System.Drawing.Size(154, 26)
        Me.bt_creditnote2.TabIndex = 37
        Me.bt_creditnote2.Text = "ใบลดหนี้"
        '
        'bt_deposit2
        '
        Me.bt_deposit2.AnimationHoverSpeed = 0.07!
        Me.bt_deposit2.AnimationSpeed = 0.03!
        Me.bt_deposit2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.bt_deposit2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.bt_deposit2.BorderColor = System.Drawing.Color.Black
        Me.bt_deposit2.CheckedBaseColor = System.Drawing.Color.Gray
        Me.bt_deposit2.CheckedBorderColor = System.Drawing.Color.Black
        Me.bt_deposit2.CheckedForeColor = System.Drawing.Color.White
        Me.bt_deposit2.CheckedImage = CType(resources.GetObject("bt_deposit2.CheckedImage"), System.Drawing.Image)
        Me.bt_deposit2.CheckedLineColor = System.Drawing.Color.DimGray
        Me.bt_deposit2.DialogResult = System.Windows.Forms.DialogResult.None
        Me.bt_deposit2.Dock = System.Windows.Forms.DockStyle.Top
        Me.bt_deposit2.FocusedColor = System.Drawing.Color.Empty
        Me.bt_deposit2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_deposit2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.bt_deposit2.Image = CType(resources.GetObject("bt_deposit2.Image"), System.Drawing.Image)
        Me.bt_deposit2.ImageSize = New System.Drawing.Size(20, 20)
        Me.bt_deposit2.LineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_deposit2.Location = New System.Drawing.Point(0, 156)
        Me.bt_deposit2.Name = "bt_deposit2"
        Me.bt_deposit2.OnHoverBaseColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bt_deposit2.OnHoverBorderColor = System.Drawing.Color.Black
        Me.bt_deposit2.OnHoverForeColor = System.Drawing.Color.White
        Me.bt_deposit2.OnHoverImage = Nothing
        Me.bt_deposit2.OnHoverLineColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.bt_deposit2.OnPressedColor = System.Drawing.Color.Black
        Me.bt_deposit2.Size = New System.Drawing.Size(154, 26)
        Me.bt_deposit2.TabIndex = 38
        Me.bt_deposit2.Text = "ใบรับมัดจำ"
        '
        'Mainmenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1098, 637)
        Me.Controls.Add(Me.pn_sale)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Mainmenu"
        Me.Text = "TRANSFER_2PDF"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pn_sale.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents Tool_sales_order As ToolStripButton
    Friend WithEvents Tool_finance_new As ToolStripButton
    Friend WithEvents cmpn_name_strip As ToolStripLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents status_1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents pn_sale As Panel
    Friend WithEvents GunaAdvenceButton4 As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents bt_all As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents bt_cn As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents bt_sales As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents bt_cnCash As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents bt_debitnote2 As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents bt_creditnote2 As Guna.UI.WinForms.GunaAdvenceButton
    Friend WithEvents bt_deposit2 As Guna.UI.WinForms.GunaAdvenceButton
End Class

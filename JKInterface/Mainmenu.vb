Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.AccessControl
Imports CenterClass

Public Class Mainmenu
    Private Declare Auto Function SetWindowLong Lib "User32.Dll" (ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    Private Declare Auto Function GetWindowLong Lib "User32.Dll" (ByVal hWnd As System.IntPtr, ByVal nIndex As Integer) As Integer
    Private Const GWL_EXSTYLE = (-20)
    Private Const WS_EX_CLIENTEDGE = &H200
    Dim File_ini = Path.Combine(System.Windows.Forms.Application.StartupPath, "DB_Config.ini")
    Dim JK_ini As New JKClass
    Private Sub Mainmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Control In Me.Controls()
            If TypeOf (c) Is MdiClient Then
                c.BackColor = Me.BackColor 'Color.DimGray
                c.BackColor = SystemColors.ControlLightLight
                Dim windowLong As Integer = GetWindowLong(c.Handle, GWL_EXSTYLE)
                windowLong = windowLong And (Not WS_EX_CLIENTEDGE)
                SetWindowLong(c.Handle, GWL_EXSTYLE, windowLong)
                c.Width = c.Width + 1
                Exit For
            End If
        Next

        read_connection()
        status_show_ini() 'แสดงชื่อ database
        'Check_iniconnect() 'ตรวจสอบไฟล์ ini ถ้าข้อมูลไม่มี ให้เปิดหน้าจอ กำหนด Database

        'Dim frm As New doc_tab
        '    frm.MdiParent = Me
        '    frm.Dock = DockStyle.Fill
        '    frm.Show()

    End Sub
    Private Sub read_connection()
        Dim con_str1 As String = ""
        con_str1 = "Data Source=" & JK_ini.ReadIni(File_ini, "DATABASE", "HOST_NAME", "") & ";Initial Catalog=" & JK_ini.ReadIni(File_ini, "DATABASE", "DB_NAME", "") & ";User ID=" & JK_ini.ReadIni(File_ini, "DATABASE", "USER_ID", "") & "; password=" & JK_ini.ReadIni(File_ini, "DATABASE", "PASSWORD", "")
        'JK_ini.cnn_sql_main = New SqlConnection(con_str1) 'สร้าง sqlconnection ใช้ทั้งโปรแกรม

    End Sub

    Private Sub Check_iniconnect()
        Try
            If File.Exists(File_ini) = True Then
                If JK_ini.ReadIni(File_ini, "DATABASE", "HOST_NAME", "").Trim.Length = 0 Then 'ไม่มีการกำหนดค่า ini หาค่าจาก host_name
                    MsgBox("กรุณาตั้งค่าการเชื่อมต่อ Database" & vbNewLine & Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
                    Close()
                Else
                    If JK_ini.cnn_sql_main.State = ConnectionState.Closed Then
                        Try
                            JK_ini.cnn_sql_main.Open()
                            JK_ini.cnn_sql_main.Close()
                        Catch ex As Exception
                            'MessageBox.Show(Err.Number)
                            MsgBox("พบข้อผิดพลาดในการเชื่อมต่อ Database โปรดตรวจสอบ" & vbNewLine & Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
                            Close()
                        Finally
                        End Try
                    End If
                End If
            Else
                'MsgBox("NO ini FILE") ให้เปิดหน้าจอ การตั้งค่า database
                MsgBox("ไม่พบไฟล์ ini กรุณาตั้งค่าการเชื่อมต่อ Database ใหม่" & vbNewLine & Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
                Close()
                'Dim frm As New db_connection
                'frm.MdiParent = Me
                'frm.Dock = DockStyle.Fill
                'frm.Show()
                'frm.host_txt.Select()
            End If
        Catch ex As Exception
            MessageBox.Show("Failed to connect ini file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub status_show_ini()
        status_1.Text = ProductName & "  Version " & ProductVersion
    End Sub
    Private Function isFormNotOpened(ByVal ThisFrm As Form, frm_text As String) As Boolean
        'เช็คการเปิดฟอร์ม กรณีใช้ฟอร์มเดียว เปิดหลายงาน
        Dim xfrm As Form
        isFormNotOpened = True
        For Each xfrm In Application.OpenForms
            If xfrm.Name = ThisFrm.Name And xfrm.Text = frm_text Then '"สรุปเอกสารขาย" Then
                'MsgBox(" !!! Already Opened !!! ", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation)
                xfrm.Activate()
                isFormNotOpened = False
                Exit Function
            End If
        Next
    End Function
    Private Sub Tool_sales_order_Click(sender As Object, e As EventArgs) Handles Tool_sales_order.Click
        'Dim frm As New doc_tab
        'If isFormNotOpened(frm, "สรุปเอกสารขาย") Then
        '    frm.MdiParent = Me
        '    frm.Dock = DockStyle.Fill
        '    frm.header_lb.Text = "สรุปเอกสารขาย"
        '    frm.Text = "สรุปเอกสารขาย"
        '    frm.record_multi.Text = 1
        '    frm.Show()
        'End If

        Dim frmCollection = System.Windows.Forms.Application.OpenForms
        If frmCollection.OfType(Of doc_tab).Any Then
            frmCollection.Item("doc_tab").Activate()
        Else
            Dim frm As New doc_tab
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.Show()
        End If

    End Sub

    Private Sub Tool_finance_new_Click(sender As Object, e As EventArgs) Handles Tool_finance_new.Click
        'Dim frmCollection = System.Windows.Forms.Application.OpenForms
        'If frmCollection.OfType(Of db_connection).Any Then
        '    frmCollection.Item("db_connection").Activate()
        'Else
        Dim frm As New db_connection
        'frm.MdiParent = Me
        'frm.Dock = DockStyle.Fill
        frm.ShowDialog()
        'End If
    End Sub

    Private Sub exit_strip_Click(sender As Object, e As EventArgs) 
        Close()
    End Sub

    Private Sub bt_sales_Click(sender As Object, e As EventArgs) Handles bt_sales.Click
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปเอกสารขาย") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปเอกสารขาย"
            frm.Text = "สรุปเอกสารขาย"
            frm.record_multi.Text = 1
            frm.Show()
        End If
    End Sub

    Private Sub bt_cn_Click(sender As Object, e As EventArgs) Handles bt_cn.Click
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปเอกสารรับคืน") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปเอกสารรับคืน"
            frm.Text = "สรุปเอกสารรับคืน"
            frm.record_multi.Text = 2
            frm.Show()
        End If
    End Sub

    Private Sub bt_debitnote_Click(sender As Object, e As EventArgs)
        'MsgBox("No Design", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปใบเพิ่มหนี้ลูกหนี้") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปใบเพิ่มหนี้ลูกหนี้"
            frm.Text = "สรุปใบเพิ่มหนี้ลูกหนี้"
            frm.record_multi.Text = 3
            frm.Show()
        End If
    End Sub
    Private Sub bt_creditnote_Click(sender As Object, e As EventArgs)
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปใบลดหนี้ลูกหนี้") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปใบลดหนี้ลูกหนี้"
            frm.Text = "สรุปใบลดหนี้ลูกหนี้"
            frm.record_multi.Text = 4
            frm.Show()
        End If
    End Sub

    Private Sub bt_deposit_Click(sender As Object, e As EventArgs)
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปใบรับมัดจำ") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปใบรับมัดจำ"
            frm.Text = "สรุปใบรับมัดจำ"
            frm.record_multi.Text = 5
            frm.Show()
        End If
    End Sub

    Private Sub bt_all_Click(sender As Object, e As EventArgs) Handles bt_all.Click
        'MsgBox("No Design", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปรวมทุกเอกสาร") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปรวมทุกเอกสาร"
            frm.Text = "สรุปรวมทุกเอกสาร"
            frm.record_multi.Text = 0
            frm.Show()
        End If
    End Sub

    Private Sub bt_cnCash_Click(sender As Object, e As EventArgs) Handles bt_cnCash.Click
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปเอกสารรับคืนสด") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปเอกสารรับคืนสด"
            frm.Text = "สรุปเอกสารรับคืนสด"
            frm.record_multi.Text = 23
            frm.Show()
        End If
    End Sub

    Private Sub bt_debitnote2_Click(sender As Object, e As EventArgs) Handles bt_debitnote2.Click
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปใบเพิ่มหนี้ลูกหนี้") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปใบเพิ่มหนี้ลูกหนี้"
            frm.Text = "สรุปใบเพิ่มหนี้ลูกหนี้"
            frm.record_multi.Text = 3
            frm.Show()
        End If
    End Sub

    Private Sub bt_creditnote2_Click(sender As Object, e As EventArgs) Handles bt_creditnote2.Click
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปใบลดหนี้ลูกหนี้") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปใบลดหนี้ลูกหนี้"
            frm.Text = "สรุปใบลดหนี้ลูกหนี้"
            frm.record_multi.Text = 4
            frm.Show()
        End If
    End Sub

    Private Sub bt_deposit2_Click(sender As Object, e As EventArgs) Handles bt_deposit2.Click
        Dim frm As New doc_tab
        If isFormNotOpened(frm, "สรุปใบรับมัดจำ") Then
            frm.MdiParent = Me
            frm.Dock = DockStyle.Fill
            frm.header_lb.Text = "สรุปใบรับมัดจำ"
            frm.Text = "สรุปใบรับมัดจำ"
            frm.record_multi.Text = 5
            frm.Show()
        End If
    End Sub
End Class
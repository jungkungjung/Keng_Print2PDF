Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CenterClass
Public Class db_connection
    Dim JK_ini As New JKClass
    Dim File_ini = Path.Combine(System.Windows.Forms.Application.StartupPath, "DB_Config.ini")
    Private Sub FrmCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        read_from_ini()
        save_bt.Select()
        Pn_not_show.Hide()
    End Sub

    Private Sub read_from_ini()
        'แสดงค่า connection
        host_guna.Text = JK_ini.ReadIni(File_ini, "DATABASE", "HOST_NAME", "")
        database_guna.Text = JK_ini.ReadIni(File_ini, "DATABASE", "DB_NAME", "")
        user_guna.Text = JK_ini.ReadIni(File_ini, "DATABASE", "USER_ID", "")
        password_guna.Text = JK_ini.ReadIni(File_ini, "DATABASE", "PASSWORD", "")
        tb_pdfPath.Text = JK_ini.ReadIni(File_ini, "PDF", "PDF_PATH", "")
        'read_connection() 'อ่านค่า connection string
    End Sub

    Private Sub write_to_ini()
        'บันทึกค่า connection
        Try
            If File.Exists(File_ini) = False Then
                MsgBox("ไม่พบไฟล์ ini โปรแกรมจะสร้างขึ้นใหม่ ตามข้อมูลที่ระบุ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
                File.Create(File_ini).Dispose()
            End If
            JK_ini.writeIni(File_ini, "DATABASE", "HOST_NAME", host_guna.Text)
            JK_ini.writeIni(File_ini, "DATABASE", "DB_NAME", database_guna.Text)
            JK_ini.writeIni(File_ini, "DATABASE", "USER_ID", user_guna.Text)
            JK_ini.writeIni(File_ini, "DATABASE", "PASSWORD", password_guna.Text)
            JK_ini.writeIni(File_ini, "PDF", "PDF_PATH", tb_pdfPath.Text)

            'read_connection() 'อ่านค่า connect
            'บันทึก ini แล้วอ่านค่า connection string ใหม่
            Dim con_str1 As String = ""
            If JK_ini.ReadIni(File_ini, "DATABASE", "DB_TYPE", "").ToUpper = "MSSQL" Then 'MSSQL ปกติ
                con_str1 = "Data Source=" & JK_ini.ReadIni(File_ini, "DATABASE", "HOST_NAME", "") & ";Initial Catalog=" & JK_ini.ReadIni(File_ini, "DATABASE", "DB_NAME", "") & ";User ID=" & JK_ini.ReadIni(File_ini, "DATABASE", "USER_ID", "") & "; password=" & JK_ini.ReadIni(File_ini, "DATABASE", "PASSWORD", "")
            ElseIf JK_ini.ReadIni(File_ini, "DATABASE", "DB_TYPE", "").ToUpper = "MSSQL DATABASE FILE" Then 'mssql แบบ database file (mssql express)
                con_str1 = "Data Source=" & JK_ini.ReadIni(File_ini, "DATABASE", "HOST_NAME", "") & ";AttachDbFilename=" & JK_ini.ReadIni(File_ini, "DATABASE", "DB_NAME", "") & ";Integrated Security=True;Connect Timeout=30;User Instance=True"
            ElseIf JK_ini.ReadIni(File_ini, "DATABASE", "DB_TYPE", "").ToUpper = "LOCALDB" Then 'แบบ localDb
                con_str1 = "server=" & JK_ini.ReadIni(File_ini, "DATABASE", "HOST_NAME", "") & ";AttachDbFilename=" & JK_ini.ReadIni(File_ini, "DATABASE", "DB_NAME", "") & ";Integrated Security=True;Connect Timeout=30"
            End If
            'JK_ini.cnn_sql_main = New SqlConnection(con_str1)
            MsgBox("บันทึกเรียบร้อย", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ผลลัพท์")
        Catch ex As Exception
            MessageBox.Show("Failed to connect ini file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub save1_Click(sender As System.Object, e As System.EventArgs)
        write_to_ini() 'บันทึกค่า connection และเชื่อมต่อ
        Close()
    End Sub

    Private Sub exit1_Click(sender As System.Object, e As System.EventArgs)
        Close()
    End Sub

    Private Sub test_config_bt_Click(sender As System.Object, e As System.EventArgs) Handles test_config_bt.Click
        Dim con_str_test As String = ""
        con_str_test = "Data Source=" & host_guna.Text & ";Initial Catalog=" & database_guna.Text & ";User ID=" & user_guna.Text & "; password=" & password_guna.Text
        Dim cnn_sql_test As New SqlConnection(con_str_test)

        'ใช้วิธีตรวจสอบจาก textbox ไม่ใช่จาก ini เนื่องจาก user สามารถที่จะทดสอบการเชื่อมต่อ ก่อน ถ้าติดต่อได้ ค่อยบันทึกก็ได้
        If cnn_sql_test.State = ConnectionState.Closed Then
            Try
                cnn_sql_test.Open()
                cnn_sql_test.Close()
                MsgBox("สามารถติดต่อ Database ได้", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Result")
            Catch ex As Exception
                'MessageBox.Show(Err.Number)
                MsgBox("พบข้อผิดพลาดในการเชื่อมต่อ Database โปรดตรวจสอบ" & vbNewLine & Err.Description, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
            Finally
            End Try
        End If
    End Sub

    Private Sub db_path_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        With OpenFileDialog1
            .Title = "เลือกไฟล์"
            .Filter = "All Files (*.*)|*.*"
            .FileName = ""
            .FilterIndex = 2
            '.InitialDirectory = a 'System.IO.Path.GetDirectoryName(doc_path.Text) 'doc_path.Text
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            database_guna.Text = System.IO.Path.GetFullPath(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub save_bt_Click(sender As Object, e As EventArgs) Handles save_bt.Click
        write_to_ini() 'บันทึกค่า connection และเชื่อมต่อ
        Close()
    End Sub

    Private Sub close_bt_Click(sender As Object, e As EventArgs) Handles close_bt.Click
        Close()
    End Sub

    Private Sub host_guna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles host_guna.KeyPress
        If e.KeyChar = ControlChars.Cr Then '   controlchars.cr คือ enter ใช้ = 13 แล้วจะ error
            Me.database_guna.Focus()
        End If
    End Sub
    Private Sub database_guna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles database_guna.KeyPress
        Me.user_guna.Focus()
    End Sub

    Private Sub user_guna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles user_guna.KeyPress
        Me.password_guna.Focus()
    End Sub

    Private Sub lnk_location_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_location.LinkClicked
        If tb_pdfPath.Text.Trim.Length = 0 Then
            With OpenFileDialog1
                .CheckFileExists = "FALSE" 'กรณีไม่มีไฟล์ใน folder สามารถเลือกได้ โดยใส่ default filename ไว้ หรือคีย์อะไรก็ได้ แล้วค่อยกด ok
                .Title = "เลือกไฟล์"
                .Filter = "All Files (*.*)|*.*"
                .FileName = "Folder Selection." 'ตั้งไว้เพื่อ แสดงว่าเลือกไฟล์
                .FilterIndex = 2 'default file type
                '.InitialDirectory = a 'System.IO.Path.GetDirectoryName(doc_path.Text) 'doc_path.Text
            End With
        Else
            With OpenFileDialog1
                .CheckFileExists = "FALSE" 'กรณีไม่มีไฟล์ใน folder สามารถเลือกได้ โดยใส่ default filename ไว้ หรือคีย์อะไรก็ได้ แล้วค่อยกด ok
                .Title = "เลือกไฟล์"
                .Filter = "All Files (*.*)|*.*"
                .FileName = ""
                .FilterIndex = 2 'default file type
                .InitialDirectory = tb_pdfPath.Text.Trim
            End With
        End If
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            tb_pdfPath.Text = System.IO.Path.GetDirectoryName(OpenFileDialog1.FileName)
        End If
    End Sub

End Class
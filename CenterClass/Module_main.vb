Imports System.Windows.Forms

Public Module Module_main
    Dim JK_ini As New JKClass
    Dim dtprint As New DataTable

    Public Sub Main()
        'dtprint.Clear()
        'Dim datefrom As DateTime = New DateTime(2022, 11, 1).Date 'test date
        'dtprint = JK_ini.invoice_data(datefrom, Now.Date) 'ให้เปลี่ยนไป query ทุก doctype แบบ union

        'If dtprint.Rows.Count > 0 Then
        '    'JK_ini.printPDF(dtprint)d
        'Else
        '    MsgBox("ไม่มีข้อมูล", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
        'End If

        Dim a As String = Application.StartupPath

        Dim dt As New DataTable()
        'dt = JK_ini.documentAll_data(New DateTime(2023, 7, 1).Date, Now.Date) 'for test
        dt = JK_ini.documentAll_data(Now.Date, Now.Date)
        If dt.Rows.Count > 0 Then
            JK_ini.printPDF(dt, 0, 1)
            'Else
            '    MsgBox("ไม่มีข้อมูล", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "คำเตือน")
        End If
    End Sub

    ' 2023-11-3 แจ้ง lock license ลูกค้าจ่ายเงินแล้ว ให้ปลดล็อด ด้วย
    Public Function company_licensse() As Boolean
        Try
            Dim RESULT As Boolean
            Dim expire_date = New DateTime(2023, 10, 31)
            If Now.Date > expire_date Then
                RESULT = False
            Else
                RESULT = True
            End If
            Return RESULT
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module

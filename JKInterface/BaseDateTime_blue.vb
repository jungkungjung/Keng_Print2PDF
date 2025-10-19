Public Class BaseDateTime_blue
    Inherits DateTimePicker
    Private _BackColor As Color = SystemColors.Window
    Public Sub New()
        MyBase.New()
        Me.Format = DateTimePickerFormat.Short
        Me.Width = 88
        Me.FontHeight = 25
        Me.BackColor = Color.AliceBlue
    End Sub

    Public Overrides Property BackColor() As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal Value As Color)
            _BackColor = Value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = CInt(&H14) Then ' WM_ERASEBKGND 
            Dim g As Graphics = Graphics.FromHdc(m.WParam)
            g.FillRectangle(New SolidBrush(_BackColor), ClientRectangle)
            g.Dispose()
            Return
        End If
        MyBase.WndProc(m)
    End Sub
End Class

Imports System.Drawing.Drawing2D
Public Class CircleButton
    Inherits Button

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim grPath As GraphicsPath = New GraphicsPath()

        grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height)

        Me.Region = New Region(grPath)

        MyBase.OnPaint(e)

    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub
End Class

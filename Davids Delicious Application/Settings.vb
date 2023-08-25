Public Class Settings
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To 0
            Panel1.Controls.RemoveAt(i)
        Next
        Dim f As New suppliersfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        Panel1.Controls.Add(f)
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim f As New unitsfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Maximized
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        Panel1.Controls.Add(f)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To 0
            Panel1.Controls.RemoveAt(i)
        Next
        Dim f As New unitsfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Maximized
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        Panel1.Controls.Add(f)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i As Integer
        For i = 0 To 0
            Panel1.Controls.RemoveAt(i)
        Next
        Dim f As New Category()
        f.TopLevel = False
        f.WindowState = FormWindowState.Maximized
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        Panel1.Controls.Add(f)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        For i = 0 To 0
            Panel1.Controls.RemoveAt(i)
        Next
        Dim f As New Brand()
        f.TopLevel = False
        f.WindowState = FormWindowState.Maximized
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        Panel1.Controls.Add(f)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
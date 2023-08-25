Public Class Stafffrm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To 0
            mainfront.mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New dashboardfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainfront.mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i As Integer
        For i = 0 To 0
            mainfront.mainpanel.Controls.RemoveAt(i)

        Next
        Dim f As New cashierprofile()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainfront.mainpanel.Controls.Add(f)
    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim i As Integer
        For i = 0 To 0
            mainfront.mainpanel.Controls.RemoveAt(i)

        Next
        Dim f As New trnasactionfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainfront.mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim i As Integer
        For i = 0 To 0
            mainfront.mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New ReportsAndAnalysis()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainfront.mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim i As Integer
        For i = 0 To 0
            mainfront.mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New inventorymngfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainfront.mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim i As Integer
        For i = 0 To 0
            mainfront.mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New Settings()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainfront.mainpanel.Controls.Add(f)
    End Sub
End Class
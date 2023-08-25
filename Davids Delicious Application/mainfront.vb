Public Class mainfront
    Private Sub btnusermanager_Click(sender As Object, e As EventArgs)

        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)

        Next
        Dim f As New manageuserfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub mainfront_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'If lblUsertype.Text = "Staff" Then
        '    btndashboard.Enabled = True
        '    btnproduct.Enabled = True
        '    btnsale.Enabled = True
        '    CircleButton1.Enabled = True
        'ElseIf lblUsertype.Text = "Admin" Then
        '    btndashboard.Enabled = True
        '    btnproduct.Enabled = True
        '    btnsale.Enabled = True
        '    CircleButton1.Enabled = True
        '    btninventory.Enabled = True
        '    btnusermanager.Enabled = True
        'End If
        'btndashboard.Location = New Point(1036, -12)
        'If btndashboard.Location = New Point(1036, -12) Then
        '    btnusermanager.Location = New Point(285, 25)
        '    btnproduct.Location = New Point(675, 25)
        '    btninventory.Location = New Point(480, 25)
        '    btnsale.Location = New Point(869, 25)
        'End If
        'btnproduct.BackColor = Color.Salmon
        'btninventory.BackColor = Color.Salmon
        'btndashboard.BackColor = Color.DarkSeaGreen
        'btnsale.BackColor = Color.Salmon
        'btnusermanager.BackColor = Color.Salmon
        'CircleButton1.BackColor = Color.Salmon
        Dim f As New dashboardfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Maximized
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
        If lblUsertype.Text = "Cashier" Then
            Panel1.Controls.Clear()
            Dim p As New cashierfrm()
            p.TopLevel = False
            p.WindowState = FormWindowState.Maximized
            p.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            p.Visible = True
            Panel1.Controls.Add(p)
        ElseIf lblUsertype.Text = "Staff" Then
            Panel1.Controls.Clear()
            Dim p As New Stafffrm()
            p.TopLevel = False
                p.WindowState = FormWindowState.Maximized
                p.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                p.Visible = True
                Panel1.Controls.Add(p)

            End If
    End Sub


    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New dashboardfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)

        Next
        Dim f As New manageuserfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New frmproductlist()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New trnasactionfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New ReportsAndAnalysis()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New inventorymngfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim i As Integer
        For i = 0 To 0
            mainpanel.Controls.RemoveAt(i)
        Next
        Dim f As New Settings()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Dispose()
        Loginfrm.Show()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
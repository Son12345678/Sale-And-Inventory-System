Public Class Mainfrm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Mainfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btndashboard.Location = New Point(1036, -12)
        If btndashboard.Location = New Point(1036, -12) Then
            btnusermanager.Location = New Point(285, 25)
            btnproduct.Location = New Point(675, 25)
            btninventory.Location = New Point(480, 25)
            btnsale.Location = New Point(869, 25)
        End If
        btnproduct.BackColor = Color.LightYellow
        btninventory.BackColor = Color.LightYellow
        btndashboard.BackColor = Color.Crimson
        btnsale.BackColor = Color.LightYellow
        btnusermanager.BackColor = Color.LightYellow

        Dim f As New dashboardfrm()
        f.TopLevel = False
        f.WindowState = FormWindowState.Maximized
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        mainpanel.Controls.Add(f)
    End Sub
    Private Sub btnusermanager_Click_1(sender As Object, e As EventArgs) Handles btnusermanager.Click
        btnusermanager.Location = New Point(285, -12)
        If btnusermanager.Location = New Point(285, -12) Then
            btnproduct.Location = New Point(675, 25)
            btninventory.Location = New Point(480, 25)
            btnsale.Location = New Point(869, 25)
            btndashboard.Location = New Point(1036, 25)
        End If


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
        btnusermanager.BackColor = Color.Crimson
        btnproduct.BackColor = Color.LightYellow
        btninventory.BackColor = Color.LightYellow
        btndashboard.BackColor = Color.LightYellow
        btnsale.BackColor = Color.LightYellow

        'btnproduct.BackColor = Color.Gold
        'btninventory.BackColor = Color.Gold
        'btndashboard.BackColor = Color.Gold
        'btnsale.BackColor = Color.Gold
        'btnusermanager.BackColor = Color.Gold

    End Sub

    Private Sub btninventory_Click_1(sender As Object, e As EventArgs) Handles btninventory.Click
        btninventory.Location = New Point(480, -12)
        If btninventory.Location = New Point(480, -12) Then
            btnusermanager.Location = New Point(285, 25)
            btnproduct.Location = New Point(675, 25)
            btnsale.Location = New Point(869, 25)
            btndashboard.Location = New Point(1036, 25)
        End If

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
        btninventory.BackColor = Color.Crimson
        btnproduct.BackColor = Color.LightYellow
        btndashboard.BackColor = Color.LightYellow
        btnsale.BackColor = Color.LightYellow
        btnusermanager.BackColor = Color.LightYellow
    End Sub

    Private Sub btnproduct_Click_1(sender As Object, e As EventArgs) Handles btnproduct.Click
        btnproduct.Location = New Point(675, -12)
        If btnproduct.Location = New Point(675, -12) Then
            btnusermanager.Location = New Point(285, 25)
            btninventory.Location = New Point(480, 25)
            btnsale.Location = New Point(869, 25)
            btndashboard.Location = New Point(1036, 25)
        End If

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
        btnproduct.BackColor = Color.Crimson
        btninventory.BackColor = Color.LightYellow
        btndashboard.BackColor = Color.LightYellow
        btnsale.BackColor = Color.LightYellow
        btnusermanager.BackColor = Color.LightYellow
    End Sub

    Private Sub btnsale_Click(sender As Object, e As EventArgs) Handles btnsale.Click
        btnsale.Location = New Point(869, -12)
        If btnsale.Location = New Point(869, -12) Then
            btnusermanager.Location = New Point(285, 25)
            btnproduct.Location = New Point(675, 25)
            btninventory.Location = New Point(480, 25)
            btndashboard.Location = New Point(1036, 25)
        End If

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
        btnproduct.BackColor = Color.LightYellow
        btninventory.BackColor = Color.LightYellow
        btndashboard.BackColor = Color.LightYellow
        btnsale.BackColor = Color.Crimson
        btnusermanager.BackColor = Color.LightYellow
    End Sub

    Private Sub btndashboard_Click(sender As Object, e As EventArgs) Handles btndashboard.Click
        btndashboard.Location = New Point(1036, -12)
        If btndashboard.Location = New Point(1036, -12) Then
            btnusermanager.Location = New Point(285, 25)
            btnproduct.Location = New Point(675, 25)
            btninventory.Location = New Point(480, 25)
            btnsale.Location = New Point(869, 25)
        End If

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
        btnproduct.BackColor = Color.LightYellow
        btninventory.BackColor = Color.LightYellow
        btndashboard.BackColor = Color.Crimson
        btnsale.BackColor = Color.LightYellow
        btnusermanager.BackColor = Color.LightYellow
    End Sub
End Class
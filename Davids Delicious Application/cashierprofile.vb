Public Class cashierprofile
    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click

        If txtpw.Text <> txtcp.Text Then
            MsgBox("Password should match!", vbOKOnly)
            txtpw.Focus()
        Else

            OpenCon()
            cmd.CommandText = "UPDATE usertbl SET id=@a, username=@b, password=@c, usertype=@d, status=@e WHERE username= @b AND id = @a"
            With cmd.Parameters

                .Clear()
                .AddWithValue("a", txtid.Text)
                .AddWithValue("b", txtun.Text)
                .AddWithValue("c", txtpw.Text)
                .AddWithValue("d", cmbut.Text)
                .AddWithValue("e", cmbst.Text)
            End With
            cmd.ExecuteNonQuery()
            con.Close()
            MsgBox("Updated")
            btnedit.Enabled = False
            txtun.Enabled = False
            txtcp.Enabled = False
            txtpw.Enabled = False
        End If
    End Sub

    Private Sub cashierprofile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim name As String = mainfront.lblu.Text
        OpenCon()
        cmd.CommandText = "SELECT * FROM usertbl WHERE username = @username"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@username", name)

        dr = cmd.ExecuteReader()

        If dr.Read() Then
            ' Populate the retrieved values into textboxes

            txtid.Text = dr("id").ToString()
            txtun.Text = dr("username").ToString()
            cmbst.Text = dr("status").ToString()
            cmbut.Text = dr("usertype").ToString()
            txtpw.Text = dr("password").ToString()

            ' Add additional code here to populate more controls as needed

        End If

        con.Close()


        '
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        btnedit.Enabled = True
        txtun.Enabled = True
        txtcp.Enabled = True
        txtpw.Enabled = True
    End Sub
End Class
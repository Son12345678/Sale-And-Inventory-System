Public Class Loginfrm
    Dim astat As String = "active"
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Dispose()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

        OpenCon()
        cmd.CommandText = "Select * from usertbl where username = '" & txtusername.Text & "' and password = '" & txtpassword.Text & "' and status = '" & astat & "'"
        cmd.ExecuteNonQuery()
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            If CStr(dr(3)) = "administrator" = True Then
                mainfront.lblUsertype.Text = "Admin"
                inventorymngfrm.txtrn.Text = CStr(dr("username"))
                mainfront.lblu.Text = CStr(dr("username"))
                con.Close()
                mainfront.Show()
                Me.Hide()
            ElseIf CStr(dr(3)) = "staff" Then
                mainfront.lblUsertype.Text = "Staff"
                'OrderingProcess.lblc.Text = dr("username")
                mainfront.lblu.Text = CStr(dr("username"))
                con.Close()
                mainfront.Show()
                Me.Hide()
            ElseIf CStr(dr(3)) = "cashier" Then
                mainfront.lblUsertype.Text = "Cashier"
                'OrderingProcess.lblc.Text = dr("username")
                mainfront.lblu.Text = CStr(dr("username"))
                con.Close()
                mainfront.Show()
                Me.Hide()
            ElseIf CStr(dr(3)) = "staff" Then
                mainfront.lblUsertype.Text = "Staff"
                'OrderingProcess.lblc.Text = dr("username")
                mainfront.lblu.Text = CStr(dr("username"))
                con.Close()
                mainfront.Show()
                Me.Hide()
            End If
        Else
            MsgBox("Sorry wrong username and password", vbOKOnly)
            txtusername.Text = ""
            txtpassword.Text = ""
            txtusername.Focus()

        End If
        con.Close()
    End Sub

    Private Sub Loginfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

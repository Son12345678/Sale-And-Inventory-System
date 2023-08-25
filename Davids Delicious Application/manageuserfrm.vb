Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class manageuserfrm
    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click

        'edit code'
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
        OpenCon()
        cmd.CommandText = "INSERT INTO recentacttbl VALUES( @re, @ch)"
        With cmd.Parameters
            .Clear()
            .AddWithValue("@re", mainfront.lblu.Text.ToString)
            .AddWithValue("@ch", "edit '" & txtun.Text & "' ")

        End With
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record has been updated!", vbOKOnly)
        Fucntion_clear()
        btnedit.Enabled = False
        btndelete.Enabled = False
        ID_gen()
        refreshdata()


    End Sub
    Private Sub ID_gen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM usertbl"
        f = cmd.ExecuteScalar().ToString()

        Dim id As Integer
        If Integer.TryParse(f, id) Then
            txtid.Text = (id + 1).ToString()
        Else
            txtid.Text = "1" ' Set a default value if the query result is empty or not a valid integer
        End If

        con.Close()
    End Sub
    Private Sub manageuserfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ID_gen()
        btnsave.Enabled = True
        refreshdata()
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click

        OpenCon()
        cmd.CommandText = "DELETE FROM usertbl WHERE id =@un"
        With cmd.Parameters
            .Clear()
            .AddWithValue("un", txtid.Text)

        End With
        cmd.ExecuteNonQuery()
        con.Close()
        OpenCon()
        cmd.CommandText = "INSERT INTO recentacttbl VALUES( @re, @ch)"
        With cmd.Parameters
            .Clear()
            .AddWithValue("@re", mainfront.lblu.Text.ToString)
            .AddWithValue("@ch", "delete '" & txtun.Text & "' ")

        End With
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("Record has been Deleted!", vbOKOnly)

        Fucntion_clear()
        btnedit.Enabled = False
        btndelete.Enabled = False
        ID_gen()
        refreshdata()

    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click


        If txtid.Text = "" Or txtun.Text = "" Or cmbut.Text = "" Or cmbst.Text = "" Or txtpw.Text = "" Or txtcp.Text = "" Then
            MsgBox("All fields are required!", vbOKOnly)
            txtun.Focus()

        ElseIf txtpw.Text <> txtcp.Text Then
            MsgBox("Password should match!", vbOKOnly)
            txtpw.Focus()


        ElseIf txtun.Text <> txtid.Text Then
            OpenCon()
            cmd.CommandText = "Select * from usertbl where username = '" & txtun.Text & "' "
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("Sorry username already exist!", vbOKOnly)
                con.Close()
                txtun.Text = ""
                txtun.Focus()
            Else
                con.Close()
                OpenCon()
                cmd.CommandText = "insert into usertbl values(@un, @pw, @ln, @st, @ut)"
                With cmd.Parameters
                    .Clear()
                    .AddWithValue("un", txtid.Text)
                    .AddWithValue("pw", txtun.Text)
                    .AddWithValue("ln", txtpw.Text)
                    .AddWithValue("st", cmbut.Text)
                    .AddWithValue("ut", cmbst.Text)

                End With
                cmd.ExecuteNonQuery()
                con.Close()
                OpenCon()
                cmd.CommandText = "INSERT INTO recentacttbl VALUES( @re, @ch)"
                With cmd.Parameters
                    .Clear()
                    .AddWithValue("@re", mainfront.lblu.Text.ToString)
                    .AddWithValue("@ch", "add new users '" & txtun.Text & "' ")

                End With
                cmd.ExecuteNonQuery()
                con.Close()
                MsgBox("New record ha been saved!", vbOKOnly)
                Fucntion_clear()

                ID_gen()
                refreshdata()
                con.Close()


            End If
        End If

        'Saving code 

    End Sub


    Private Sub refreshdata()
        OpenCon()
        cmd.CommandText = "SELECT id, username, usertype, status FROM usertbl"
        dr = cmd.ExecuteReader()

        ' Clear existing columns
        DataGridView1.Columns.Clear()

        ' Create and add columns to the DataGridView
        DataGridView1.Columns.Add("id", "ID")
        DataGridView1.Columns.Add("username", "Username")
        DataGridView1.Columns.Add("usertype", "User Type")
        DataGridView1.Columns.Add("status", "Status")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView1.Rows.Add(dr("id"), dr("username"), dr("usertype"), dr("status"))
        End While

        dr.Close()
        con.Close()
    End Sub
    Private Sub Fucntion_clear()
        txtid.Text = ""
        txtun.Text = ""
        cmbst.Text = ""
        cmbut.Text = ""
        txtcp.Text = ""
        txtpw.Text = ""
    End Sub

    Private Sub function_enable()

        txtun.Enabled = True
        cmbst.Enabled = True
        cmbut.Enabled = True
        txtcp.Enabled = True
        txtpw.Enabled = True
    End Sub

    Private Sub txtun_TextChanged(sender As Object, e As EventArgs) Handles txtun.TextChanged

    End Sub

    Private Sub DataGridView1_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        btnsave.Enabled = False
        btnedit.Enabled = True
        btndelete.Enabled = True
        function_enable()
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Get the value from the clicked cell in the second column (index 1)
            Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(1).Value

            ' Copy the value to txtun
            txtun.Text = cellValue.ToString()
        End If
        Dim name As String = txtun.Text.Trim()


        OpenCon()
            cmd.CommandText = "SELECT * FROM usertbl WHERE username = @username"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@username", name)

            dr = cmd.ExecuteReader()

            If dr.Read() Then
                ' Populate the retrieved values into textboxes
                txtid.Text = dr("id").ToString()
                cmbst.Text = dr("status").ToString()
                cmbut.Text = dr("usertype").ToString()
                txtpw.Text = dr("password").ToString()

                ' Add additional code here to populate more controls as needed

            End If

            con.Close()


        '
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim searchText As String = txtsearch.Text.Trim()

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For

            Dim matchFound As Boolean = False

            For Each cell As DataGridViewCell In row.Cells
                If cell.Value IsNot Nothing AndAlso cell.Value.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 Then
                    matchFound = True
                    Exit For
                End If
            Next

            row.Visible = matchFound
        Next
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Fucntion_clear()
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        ID_gen()
    End Sub
End Class
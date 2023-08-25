Public Class Category
    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub ID_gen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM categorytbl"
        f = cmd.ExecuteScalar().ToString()

        Dim id As Integer
        If Integer.TryParse(f, id) Then
            txtID.Text = (id + 1).ToString()
        Else
            txtID.Text = "1" ' Set a default value if the query result is empty or not a valid integer
        End If

        con.Close()

    End Sub
    Private Sub tblload()
        OpenCon()
        cmd.CommandText = "SELECT id, category FROM categorytbl"
        dr = cmd.ExecuteReader()

        ' Clear existing columns
        DataGridView2.Columns.Clear()

        ' Create and add columns to the DataGridView

        DataGridView2.Columns.Add("id", "ID")
        DataGridView2.Columns.Add("category", "Category")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView2.Rows.Add(dr("id"), dr("category"))
        End While

        dr.Close()
        con.Close()
    End Sub

    Private Sub Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblload()
        ID_gen()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtname.Text = "" Then
            MessageBox.Show("insert category")
            txtname.Focus()
        Else
            OpenCon()
            cmd.CommandText = "insert into categorytbl values(@a, @b  )"
            With cmd.Parameters
                .Clear()
                .AddWithValue("@a", txtid.Text.ToString)
                .AddWithValue("@b", txtname.Text.ToString)
            End With
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Category Saved")
            ID_gen()
            txtname.Text = ""
        End If

    End Sub
End Class
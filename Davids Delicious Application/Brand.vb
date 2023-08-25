Public Class Brand
    Private Sub ID_gen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM brandtbl"
        f = cmd.ExecuteScalar().ToString()

        Dim id As Integer
        If Integer.TryParse(f, id) Then
            txtid.Text = (id + 1).ToString()
        Else
            txtid.Text = "1" ' Set a default value if the query result is empty or not a valid integer
        End If

        con.Close()

    End Sub
    Private Sub tblload()
        OpenCon()
        cmd.CommandText = "SELECT id, brand FROM brandtbl"
        dr = cmd.ExecuteReader()

        ' Clear existing columns
        DataGridView2.Columns.Clear()

        ' Create and add columns to the DataGridView

        DataGridView2.Columns.Add("id", "ID")
        DataGridView2.Columns.Add("brand", "Brand Name")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView2.Rows.Add(dr("id"), dr("brand"))
        End While

        dr.Close()
        con.Close()
    End Sub
    Private Sub Brand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ID_gen()
        tblload()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtname.Text = "" Then
            MessageBox.Show("insert Brand")
            txtname.Focus()
        Else
            OpenCon()
            cmd.CommandText = "insert into brandtbl values(@a, @b  )"
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
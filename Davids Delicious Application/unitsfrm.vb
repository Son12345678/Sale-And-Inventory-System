Public Class unitsfrm
    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtunits.Text = "" Then
            MessageBox.Show("insert untis")
            txtunits.Focus()
        Else
            OpenCon()
            cmd.CommandText = "insert into unitstbl values(@a, @b)"
            With cmd.Parameters
                .Clear()
                .AddWithValue("@a", txtID.Text.ToString)
                .AddWithValue("@b", txtunits.Text.ToString)


            End With
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("units Saved")

            txtunits.Text = ""
            ID_gen()
        End If

    End Sub
    Private Sub ID_gen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM unitstbl"
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
        cmd.CommandText = "SELECT id, units FROM unitstbl"
        dr = cmd.ExecuteReader()

        ' Clear existing columns
        DataGridView2.Columns.Clear()

        ' Create and add columns to the DataGridView

        DataGridView2.Columns.Add("id", "ID")
        DataGridView2.Columns.Add("units", "Unit Measure")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView2.Rows.Add(dr("id"), dr("units"))
        End While

        dr.Close()
        con.Close()
    End Sub
    Private Sub unitsfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ID_gen()
        tblload()
    End Sub

    Private Sub txtunits_TextChanged(sender As Object, e As EventArgs) Handles txtunits.TextChanged
        Dim searchText As String = txtunits.Text.Trim()

        If String.IsNullOrEmpty(searchText) Then
            ListBox1.Visible = False
            Return
        End If

        OpenCon()
        cmd.CommandText = "SELECT DISTINCT units FROM unitstbl WHERE units LIKE @searchText"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("searchText", "%" & searchText & "%")
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            ListBox1.Items.Clear()

            While dr.Read()
                ListBox1.Items.Add(dr("units").ToString())
            End While

            ListBox1.Visible = True
        Else
            ListBox1.Visible = False
        End If

        con.Close()
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        txtunits.Text = ListBox1.SelectedItem.ToString()
        ListBox1.Visible = False



        ' Hide the ListBox

    End Sub
End Class
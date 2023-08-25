Public Class suppliersfrm
    Private Sub Label11_Click(sender As Object, e As EventArgs) 

    End Sub
    Private Sub ID_gen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM suppliertbl"
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
        cmd.CommandText = "SELECT id, suppliersid, suppliersname, contactno, location FROM suppliertbl"
        dr = cmd.ExecuteReader()

        ' Clear existing columns
        DataGridView2.Columns.Clear()

        ' Create and add columns to the DataGridView

        DataGridView2.Columns.Add("id", "ID")
        DataGridView2.Columns.Add("suppliersid", "Suppliers ID")
        DataGridView2.Columns.Add("suppliersname", "Suppliers Name")
        DataGridView2.Columns.Add("contactno", "Contact No.")
        DataGridView2.Columns.Add("location", "Location")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView2.Rows.Add(dr("id"), dr("suppliersid"), dr("suppliersname"), dr("contactno"), dr("location"))
        End While

        dr.Close()
        con.Close()
    End Sub
    Private Sub suppliersfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblload()
        ID_gen()
    End Sub



    Private Sub txtsid_TextChanged(sender As Object, e As EventArgs) Handles txtsid.TextChanged


    End Sub

    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        Dim searchText As String = txtname.Text.Trim()

        If String.IsNullOrEmpty(searchText) Then
            ListBox1.Visible = False
            Return
        End If
        con.Close()
        OpenCon()
        cmd.CommandText = "SELECT DISTINCT suppliersname FROM suppliertbl WHERE suppliersname LIKE @searchText"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("searchText", "%" & searchText & "%")
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            ListBox1.Items.Clear()

            While dr.Read()
                ListBox1.Items.Add(dr("suppliersname").ToString())
            End While

            ListBox1.Visible = True
        Else
            ListBox1.Visible = False
        End If

        con.Close()

    End Sub
    'Private Sub LoadSupplierData()
    '    Dim supplierId As String = txtsid.Text.Trim()


    '    ' Check if the values are not empty
    '    If String.IsNullOrEmpty(supplierId) Then
    '        Return
    '    End If

    '    Try
    '        OpenCon()
    '        cmd.CommandText = "SELECT * FROM suppliertbl WHERE suppliersid = @supplierId "
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.AddWithValue("supplierId", supplierId)

    '        dr = cmd.ExecuteReader()

    '        If dr.Read() Then
    '            ' Populate the retrieved values into textboxes
    '            txtID.Text = dr("id").ToString()
    '            txtsid.Text = dr("suppliersidqqq    ").ToString()
    '            txtname.Text = dr("suppliersname").ToString()
    '            txtcontact.Text = dr("contactno").ToString()
    '            txtloaction.Text = dr("location").ToString()
    '            ' Add additional textboxes here to populate more values as needed
    '        Else
    '            ' Clear the textboxes if no matching record is found
    '            txtID.Text = ""
    '            txtsid.Text = ""
    '            txtname.Text = ""
    '            txtcontact.Text = ""
    '            txtloaction.Text = ""
    '            ' Add additional textboxes here to clear their values as needed
    '        End If

    '        con.Close()
    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message)
    '    End Try
    'End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        txtname.Text = ListBox1.SelectedItem.ToString()
        ListBox1.Visible = False


    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtcontact_TextChanged(sender As Object, e As EventArgs) Handles txtcontact.TextChanged
        ' Access the value entered in the MaskedTextBox
        Dim inputValue As String = txtcontact.Text

        ' Validate the input length
        If inputValue.Length = 11 Then
            ' Perform further processing with the valid input value
            ' ...
        End If
    End Sub

    Private Sub txtloaction_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtloaction.KeyPress
        ' Check if the pressed key is valid for a Philippines location
        Dim validKeys As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-,.' "
        If Not validKeys.Contains(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Ignore the invalid key
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If txtname.Text = "" Or txtsid.Text = "" Or txtcontact.Text = "" Or txtloaction.Text = "" Then
            MessageBox.Show("ALL FIELDS REQUIRED")
            txtsid.Focus()

        ElseIf txtname.Text <> txtid.Text Then
            OpenCon()
            cmd.CommandText = "Select * from suppliertbl where suppliersname = '" & txtname.Text & "' "
            cmd.ExecuteNonQuery()
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("Sorry supplier already exist!", vbOKOnly)
                con.Close()
                txtname.Text = ""
                txtname.Focus()
            Else
                OpenCon()
                cmd.CommandText = "insert into suppliertbl values(@a, @b, @c, @d, @e)"
                With cmd.Parameters
                    .Clear()
                    .AddWithValue("@a", txtID.Text.ToString)
                    .AddWithValue("@b", txtsid.Text.ToString)
                    .AddWithValue("@c", txtname.Text.ToString)
                    .AddWithValue("@d", txtcontact.Text.ToString)
                    .AddWithValue("@e", txtloaction.Text.ToString)

                End With
                cmd.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Saved Successfull")
                txtsid.Text = ""
                txtname.Text = ""
                txtcontact.Text = ""
                txtloaction.Text = ""
                ID_gen()
            End If
        End If


    End Sub
End Class
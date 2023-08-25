Imports System.Drawing.Imaging
Imports System.IO

Public Class frmproductlist
    Private Sub LoadSupplierData()
        Dim suppliername As String = txtsn.Text.Trim()



        OpenCon()
            cmd.CommandText = "SELECT * FROM suppliertbl WHERE suppliersname = @suppliername "
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("suppliername", suppliername)

            dr = cmd.ExecuteReader()

            If dr.Read() Then
                ' Populate the retrieved values into textboxes

                txtsid.Text = dr("suppliersid").ToString()
                txtsn.Text = dr("suppliersname").ToString()

                ' Add additional textboxes here to populate more values as needed
            Else
                ' Clear the textboxes if no matching record is found

                txtsid.Text = ""
                txtsn.Text = ""

                ' Add additional textboxes here to clear their values as needed
            End If

            con.Close()
        '
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
    Private Sub brand()
        OpenCon()
        cmd.CommandText = "SELECT * FROM brandtbl"
        dr = cmd.ExecuteReader()

        While dr.Read()
            txtbr.Items.Add(dr("brand"))
        End While

        dr.Close()
        con.Close()

    End Sub
    Private Sub cat()
        OpenCon()
        cmd.CommandText = "SELECT * FROM categorytbl"
        dr = cmd.ExecuteReader()

        While dr.Read()
            txtcat.Items.Add(dr("category"))
        End While

        dr.Close()
        con.Close()

    End Sub
    Private Sub units()
        OpenCon()
        cmd.CommandText = "SELECT * FROM unitstbl"
        dr = cmd.ExecuteReader()

        While dr.Read()
            txtum.Items.Add(dr("units"))
        End While

        dr.Close()
        con.Close()
    End Sub
    Private Sub tblload()
        OpenCon()
        cmd.CommandText = "SELECT suppliersid, suppliername, productcode, productname, category, unitmeasure, brand, costperunit, stocks, criticalstock FROM productlisttbl"
        dr = cmd.ExecuteReader()

        ' Clear existing columns
        DataGridView1.Columns.Clear()

        ' Create and add columns to the DataGridView
        DataGridView1.Columns.Add("suppliersid", "Suppliers ID")
        DataGridView1.Columns.Add("suppliername", "Supplier Name")
        DataGridView1.Columns.Add("productcode", "Product Code")
        DataGridView1.Columns.Add("productname", "Product Name")
        DataGridView1.Columns.Add("category", "Category")
        DataGridView1.Columns.Add("unitmeasure", "Unit Measure")
        DataGridView1.Columns.Add("brand", "Brand")
        DataGridView1.Columns.Add("costperunit", "Cost Per Unit")
        DataGridView1.Columns.Add("stocks", "Stocks")
        DataGridView1.Columns.Add("criticalstock", "Critical Stock")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView1.Rows.Add(dr("suppliersid"), dr("suppliername"), dr("productcode"), dr("productname"), dr("category"), dr("unitmeasure"), dr("brand"), dr("costperunit"), dr("stocks"), dr("criticalstock"))
        End While

        dr.Close()
        con.Close()
    End Sub
    Private Sub frmproductlist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set a temporary image to PictureBox1
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = My.Resources.Logo_removebg_preview ' Replace "DefaultImage" with the name of your default image resource
        sup()
        ID_gen()
        cat()
        brand()
        units()
        tblload()
    End Sub
    Private Sub sup()
        OpenCon()
        cmd.CommandText = "SELECT * FROM suppliertbl"
        dr = cmd.ExecuteReader()

        While dr.Read()
            txtsn.Items.Add(dr("suppliersname"))
        End While

        dr.Close()
        con.Close()
    End Sub


    '    OpenCon()
    '    cmd.CommandText = "INSERT INTO recentacttbl VALUES( @re, @ch)"
    '    With cmd.Parameters
    '        .Clear()
    '        .AddWithValue("@re", mainfront.lblu.Text.ToString)
    '        .AddWithValue("@ch", "added new supplier '" & txtsn.Text.ToString & "' ")

    '    End With
    '    cmd.ExecuteNonQuery()
    '    con.Close()
    '    sup()








    Private Sub ID_gen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM productlisttbl"
        f = cmd.ExecuteScalar().ToString()

        Dim id As Integer
        If Integer.TryParse(f, id) Then
            txtid.Text = (id + 1).ToString()
        Else
            txtid.Text = "1" ' Set a default value if the query result is empty or not a valid integer
        End If

        con.Close()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(txtid.Text) OrElse String.IsNullOrEmpty(txtcode.Text) OrElse String.IsNullOrEmpty(txtpname.Text) OrElse String.IsNullOrEmpty(txtcat.Text) OrElse String.IsNullOrEmpty(txtum.Text) OrElse String.IsNullOrEmpty(txtbr.Text) OrElse String.IsNullOrEmpty(txtsn.Text) OrElse String.IsNullOrEmpty(txtpr.Text) Then
            MsgBox("All fields are required!", vbOKOnly)
            txtcode.Focus()
            CLEAR()
        ElseIf txtcode.Text <> txtpname.Text Then
            OpenCon()
            cmd.CommandText = "SELECT * FROM productlisttbl WHERE productcode = @code"
            cmd.Parameters.AddWithValue("@code", txtcode.Text)
            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                MsgBox("Sorry, Product Code is already exists!", vbOKOnly)
                con.Close()
                txtcode.Text = ""
                txtcode.Focus()
            Else
                con.Close()
                If PictureBox1.Image IsNot Nothing Then
                    ' Convert the image to a byte array
                    Dim sto As Integer = CInt("0")
                    Dim imageBytes As Byte() = ImageToByteArray(PictureBox1.Image)
                    OpenCon()
                    cmd.CommandText = "INSERT INTO productlisttbl(id, suppliersid, suppliername, productcode, productname, category, unitmeasure, brand, costperunit, image, stocks, criticalstock) VALUES(@id, @suppliersid, @suppliername, @productcode, @productname, @category, @unitmeasure, @brand, @costperunit, @image, @stocks, @criticalstock)"
                    With cmd.Parameters
                        .Clear()
                        .AddWithValue("@id", txtid.Text)
                        .AddWithValue("@suppliersid", txtsid.Text)
                        .AddWithValue("@suppliername", txtsn.Text)
                        .AddWithValue("@productcode", txtcode.Text)
                        .AddWithValue("@productname", txtpname.Text)
                        .AddWithValue("@category", txtcat.Text)
                        .AddWithValue("@unitmeasure", txtum.Text)
                        .AddWithValue("@brand", txtbr.Text)
                        .AddWithValue("@costperunit", txtpr.Text)
                        .AddWithValue("@image", imageBytes)
                        .AddWithValue("@stocks", sto)
                        .AddWithValue("@criticalstock", txtcrit.Text)
                    End With
                    cmd.ExecuteNonQuery()

                    con.Close()
                    MsgBox("New Product has been registered")
                    CLEAR()
                    tblload()
                    ID_gen()

                Else
                    MsgBox("Please select an image before uploading.")
                End If


            End If
        End If
        OpenCon()
        cmd.CommandText = "INSERT INTO recentacttbl VALUES( @re, @ch)"
        With cmd.Parameters
            .Clear()
            .AddWithValue("@re", mainfront.lblu.Text.ToString)
            .AddWithValue("@ch", "Add new product")

        End With
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub CLEAR()

        txtid.Text = ""
        txtsid.Text = ""
        txtcode.Text = ""
        txtpname.Text = ""
        txtcat.Text = ""
        txtum.Text = ""
        txtbr.Text = ""
        txtsn.Text = ""
        txtpr.Text = ""
        PictureBox1.Image = Nothing
    End Sub
    Private Sub dis()
        txtcode.Enabled = False
        txtpname.Enabled = False
        txtcat.Enabled = False
        txtum.Enabled = False
        txtbr.Enabled = False
        txtsn.Enabled = False
        txtpr.Enabled = False
    End Sub

    ''Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    ''    CLEAR()
    ''    ID_gen()
    ''    btnedit.Enabled = True
    ''    Button2.Enabled = False
    ''    txtcode.Enabled = True
    ''    txtpname.Enabled = True
    ''    txtcat.Enabled = True
    ''    txtum.Enabled = True
    ''    txtexp.Enabled = True
    ''    txtbr.Enabled = True
    ''    txtsn.Enabled = True
    ''    txtpr.Enabled = True
    ''End Sub

    Private Sub txtpname_TextChanged(sender As Object, e As EventArgs) Handles txtpname.TextChanged
        ListBox1.Visible = True

        Dim searchText As String = txtpname.Text.Trim()

        ' Clear existing items in the ListBox
        ListBox1.Items.Clear()

        If Not String.IsNullOrEmpty(searchText) Then
            OpenCon()
            cmd.CommandText = "SELECT DISTINCT productname FROM productlisttbl WHERE productname LIKE @searchText"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("searchText", "%" & searchText & "%")
            dr = cmd.ExecuteReader

            While dr.Read()
                ListBox1.Items.Add(dr("productname").ToString())
            End While

            con.Close()
        End If

        ' Show the ListBox if there are any suggestions
        ListBox1.Visible = ListBox1.Items.Count > 0


    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ' Set the selected value from the ListBox to the txtcode TextBox
        txtpname.Text = ListBox1.SelectedItem.ToString()

        ' Hide the ListBox
        ListBox1.Visible = False
    End Sub

    Private Sub txtexp_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Allowing numbers, decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtpr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpr.KeyPress
        ' Allowing numbers, decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnupload.Click
        ' Open file dialog and allow the user to select an image file
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Display the selected image in the PictureBox
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
        End If
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

    Private Sub txtsn_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles txtsn.SelectedIndexChanged
        LoadSupplierData()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Get the value from the clicked cell in the second column (index 1)
            Dim cellValue As Object = DataGridView1.Rows(e.RowIndex).Cells(2).Value

            ' Copy the value to txtun
            txtcode.Text = cellValue.ToString()
            txtsubn.Visible = True
            PictureBox1.Image = Nothing
        End If
        Dim pc As String = txtcode.Text.Trim()

        OpenCon()
        cmd.CommandText = "SELECT productname, category, unitmeasure, brand, costperunit, Image, criticalstock FROM productlisttbl WHERE productcode = @code"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@code", pc)
        dr = cmd.ExecuteReader()

        If dr.Read() Then
            ' Populate the retrieved values into textboxes
            txtsubn.Text = dr("productname").ToString()
            txtcat.Text = dr("category").ToString()
            txtum.Text = dr("unitmeasure").ToString()
            txtbr.Text = dr("brand").ToString()
            txtpr.Text = dr("costperunit").ToString()
            txtcrit.Text = dr("criticalstock").ToString()

        End If

        dr.Close()
        con.Close()
        btndelete.Enabled = True
        btnupdate.Enabled = True
        Button1.Enabled = False

        ' Convert the image in PictureBox1 to a byte array


    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        ' Edit code '
        If PictureBox1.Image IsNot Nothing Then
            Dim imageBytes As Byte() = ImageToByteArrayone(PictureBox1.Image)

            OpenCon()
            cmd.CommandText = "UPDATE productlisttbl SET productname = @productname, category = @category, unitmeasure = @unitmeasure, brand = @brand, costperunit = @costperunit, image = @image, criticalstock = @criticalstock WHERE productcode = @productcode"

            With cmd.Parameters
                .Clear()
                .AddWithValue("@productcode", txtcode.Text)
                .AddWithValue("@productname", txtsubn.Text)
                .AddWithValue("@category", txtcat.Text)
                .AddWithValue("@unitmeasure", txtum.Text)
                .AddWithValue("@brand", txtbr.Text)
                .AddWithValue("@costperunit", txtpr.Text)
                .AddWithValue("@image", imageBytes)
                .AddWithValue("@criticalstock", txtcrit.Text)
            End With
            cmd.ExecuteNonQuery()

            con.Close()
            MsgBox("Product and image Updated ")
            tblload()
            CLEAR()
            txtsubn.Visible = False
            btndelete.Enabled = False
            btnupdate.Enabled = False
            Button1.Enabled = True

        Else

            OpenCon()
            cmd.CommandText = "UPDATE productlisttbl SET productname = @productname, category = @category, unitmeasure = @unitmeasure, brand = @brand, costperunit = @costperunit, criticalstock = @criticalstock WHERE productcode = @productcode"

            With cmd.Parameters
                .Clear()
                .AddWithValue("@productcode", txtcode.Text)
                .AddWithValue("@productname", txtsubn.Text)
                .AddWithValue("@category", txtcat.Text)
                .AddWithValue("@unitmeasure", txtum.Text)
                .AddWithValue("@brand", txtbr.Text)
                .AddWithValue("@costperunit", txtpr.Text)
                .AddWithValue("@criticalstock", txtcrit.Text)
            End With
            cmd.ExecuteNonQuery()

            con.Close()
            MsgBox("Product Updated")
            tblload()
            CLEAR()
            txtsubn.Visible = False
            btndelete.Enabled = False
            btnupdate.Enabled = False
            Button1.Enabled = True
        End If


    End Sub

    Private Function ImageToByteArray(image As Image) As Byte()
        Try
            Using memoryStream As New MemoryStream()
                image.Save(memoryStream, ImageFormat.Jpeg) ' You can adjust the image format based on your requirements
                Return memoryStream.ToArray()
            End Using
        Catch ex As Exception
            ' Handle any exceptions that may occur during image conversion
            MessageBox.Show("Error converting image to byte array: " + ex.Message)
            Return Nothing
        End Try
    End Function
    Private Function ImageToByteArrayone(image As Image) As Byte()
        Try
            Using memoryStream As New MemoryStream()
                image.Save(memoryStream, ImageFormat.Jpeg) ' You can adjust the image format based on your requirements
                Return memoryStream.ToArray()
            End Using
        Catch ex As Exception
            ' Handle any exceptions that may occur during image conversion
            MessageBox.Show("Error converting image to byte array: " + ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        OpenCon()
        cmd.CommandText = "DELETE FROM productlisttbl WHERE productcode =@productcode"
        With cmd.Parameters
            .Clear()
            .AddWithValue("productcode", txtcode.Text)

        End With
        cmd.ExecuteNonQuery()
        con.Close()
        tblload()
        txtsubn.Visible = False
        MsgBox("Product Deleted")
        CLEAR()
    End Sub

    Private Sub txtsubn_TextChanged(sender As Object, e As EventArgs) Handles txtsubn.TextChanged

    End Sub
End Class
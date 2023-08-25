Imports System.Net.Security
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports System.Drawing.Printing
Public Class inventorymngfrm
    Private Sub txtname_KeyPress(sender As Object, e As KeyPressEventArgs)
        '' Check if the Enter key is pressed
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    e.Handled = True ' Prevent the beep sound

        '    ' Process the scanned barcode data
        '    ProcessBarcodeData(txtname.Text.Trim())
        '    BTNPayment.Enabled = True
        '    ' Clear the text box
        '    txtname.Text = ""
        'Else
        '    txtstocks.Text = "0"
        'End If
    End Sub
    Private Sub ProcessBarcodeData(barcodeData As String)

        AddScannedBarcode(barcodeData)
    End Sub
    Private Sub AddScannedBarcode(barcodeData As String)

        cmbsn.Enabled = False
        Dim code As String = txtpcode.Text
        Dim stocksToAdd As Integer = 0

        If Integer.TryParse(txtstocks.Text, stocksToAdd) Then
            Dim foundRow As DataGridViewRow = Nothing
            Dim duplicateRow As Boolean = False ' Flag to track if duplicate row is found

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells.Count > 1 AndAlso row.Cells(2).Value IsNot Nothing AndAlso row.Cells(2).Value.ToString() = code Then
                    foundRow = row

                    Exit For
                End If
            Next

            If foundRow IsNot Nothing Then
                Dim currentStocks As Integer = 0
                If Integer.TryParse(foundRow.Cells(10).Value?.ToString(), currentStocks) Then
                    foundRow.Cells(10).Value = currentStocks + stocksToAdd
                    foundRow.Cells(12).Value = CInt(foundRow.Cells(10).Value) * CInt(foundRow.Cells(11).Value) ' calculate total cost
                    txtpcode.Text = ""
                    txtstocks.Text = ""
                End If
            Else
                OpenCon()
                cmd.CommandText = "SELECT * FROM productlisttbl WHERE productcode = @a AND suppliername = @b"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("a", code)
                cmd.Parameters.AddWithValue("b", cmbsn.SelectedItem)
                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    con.Close()
                    OpenCon()
                    cmd.CommandText = "SELECT * FROM productlisttbl WHERE productcode = @a AND suppliername = @b"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("a", code)
                    cmd.Parameters.AddWithValue("b", cmbsn.SelectedItem)
                    dr = cmd.ExecuteReader

                    If dr.HasRows Then
                        While dr.Read()
                            Dim newRow As DataGridViewRow = Nothing
                            For Each row As DataGridViewRow In DataGridView1.Rows
                                If row.Cells.Count > 1 AndAlso row.Cells(2).Value IsNot Nothing AndAlso row.Cells(2).Value.ToString() = dr("productcode").ToString() Then
                                    duplicateRow = True
                                    newRow = row
                                    Exit For
                                End If
                            Next

                            If duplicateRow Then
                                Dim currentStocks As Integer = 0
                                If Not Convert.IsDBNull(newRow.Cells(10).Value) AndAlso Integer.TryParse(newRow.Cells(10).Value.ToString(), currentStocks) Then
                                    newRow.Cells(10).Value = currentStocks + stocksToAdd
                                    newRow.Cells(12).Value = CInt(newRow.Cells(10).Value) * CInt(newRow.Cells(11).Value) ' calculate total cost
                                    txtname.Text = ""
                                    txtstocks.Text = ""
                                End If
                            Else
                                newRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                                newRow.Cells(0).Value = txtid.Text
                                newRow.Cells(1).Value = txtbatchno.Text
                                newRow.Cells(2).Value = code
                                newRow.Cells(3).Value = dr("productname")
                                newRow.Cells(4).Value = dr("brand")
                                newRow.Cells(5).Value = dr("category")
                                newRow.Cells(6).Value = dr("unitmeasure")
                                newRow.Cells(7).Value = DateTimePickerexp.Value
                                newRow.Cells(8).Value = DateTimePickermnf.Value
                                newRow.Cells(10).Value = stocksToAdd
                                newRow.Cells(11).Value = txtcost.Text
                                newRow.Cells(12).Value = CInt(newRow.Cells(10).Value) * CInt(newRow.Cells(11).Value) ' calculate total cost
                                newRow.Cells(13).Value = "Delete"

                                duplicateRow = False
                                con.Close()
                                ID_gen()

                                OpenCon()
                                cmd.CommandText = "SELECT * FROM productlisttbl WHERE productcode = @a"
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("a", code)
                                dr = cmd.ExecuteReader

                                If dr.HasRows Then

                                    While dr.Read()
                                        newRow.Cells(9).Value = If(Not Convert.IsDBNull(dr("stocks")), CInt(dr("stocks")), 0)

                                    End While
                                Else
                                    newRow.Cells(9).Value = "0"
                                End If


                                Exit While
                            End If
                        End While

                        con.Close()
                        txtpcode.Text = ""
                        txtstocks.Text = ""

                    End If
                Else
                    con.Close()


                    MsgBox("register the product first")
                    cmbsn.Enabled = True

                End If
            End If

            'Calculate overall sum of stocks
            Dim overallStocks As Integer = 0
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells.Count > 1 AndAlso row.Cells(12).Value IsNot Nothing Then
                    overallStocks += CInt(row.Cells(12).Value)
                End If
            Next

            ' Update txtstocks with the overall sum
            txttotal.Text = overallStocks.ToString()
        End If



    End Sub
    'Dim WithEvents PD As New PrintDocument
    'Dim PPD As New PrintPreviewDialog
    'Dim longpaper As Integer
    'Sub changelongpaper()
    '    Dim rowcount As Integer
    '    longpaper = 0
    '    rowcount = DataGridView1.Rows.Count
    '    longpaper = rowcount * 15
    '    longpaper = longpaper + 200
    'End Sub
    'Private Sub btnir_Click(sender As Object, e As EventArgs) Handles btnir.Click
    '    Ipanel.Visible = True
    '    DataGridView1.Location = New Point(256, 192)
    '    DataGridView1.Width = 489


    '    'DataGridView1.Visible = False
    '    changelongpaper()
    '    PPD.Document = PD
    '    'Dim f As New Dashboard()

    '    PPD.TopLevel = False
    '    PPD.WindowState = FormWindowState.Maximized
    '    PPD.FormBorderStyle = Windows.Forms.FormBorderStyle.None
    '    PPD.Visible = True
    '    Ipanel.Controls.Add(PPD)



    '    btnir.BackColor = Color.DarkGray
    '    'pnlprint.Visible = True
    '    'DataGridView1.Visible = False
    '    'DataGridView2.Visible = False

    'End Sub
    'Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
    '    Dim pagesetup As New PageSettings
    '    'pagesetup.Margins = New Margins(200, 0, 0, 0)
    '    'pagesetup.PaperSize = New PaperSize("Custom", 250, 500) 'fixed size
    '    pagesetup.PaperSize = New PaperSize("Custom", 300, longpaper)
    '    PD.DefaultPageSettings = pagesetup
    'End Sub
    'Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
    '    Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
    '    Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
    '    Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
    '    Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

    '    Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Right
    '    Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width \ 2
    '    Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

    '    'font alignment
    '    Dim right As New StringFormat
    '    Dim center As New StringFormat

    '    right.Alignment = StringAlignment.Far
    '    center.Alignment = StringAlignment.Center

    '    Dim line As String
    '    line = "--------------------------------------------------------------------------"

    '    'range from top
    '    e.Graphics.DrawString("Davids DElicious Store", f14, Brushes.Black, centermargin, 5, center)
    '    e.Graphics.DrawString("RIZAL Aveneu, Taytay Rizal 1920", f10, Brushes.Black, centermargin, 25, center)
    '    e.Graphics.DrawString("Tel +123456", f10, Brushes.Black, centermargin, 40, center)

    '    e.Graphics.DrawString("SupplierInvoice", f8, Brushes.Black, 0, 60)
    '    e.Graphics.DrawString(":", f8, Brushes.Black, 50, 60)
    '    e.Graphics.DrawString(cmbsn.Text, f8, Brushes.Black, 70, 60)

    '    e.Graphics.DrawString("Cashier", f8, Brushes.Black, 0, 75)
    '    e.Graphics.DrawString(":", f8, Brushes.Black, 50, 75)
    '    e.Graphics.DrawString(txtrn.Text, f8, Brushes.Black, 70, 75)

    '    e.Graphics.DrawString(CStr(DateTimePicker1.Value), f8, Brushes.Black, 0, 90)

    '    e.Graphics.DrawString(line, f8, Brushes.Black, 0, 100)

    '    Dim height As Integer 'DGV Position
    '    Dim i As Long
    '    DataGridView1.AllowUserToAddRows = False
    '    ''If DataGridView1.CurrentCell.Value Is Nothing Then
    '    ''    Exit Sub
    '    ''Else
    '    For row As Integer = 0 To DataGridView1.RowCount - 1
    '        height += 15
    '        e.Graphics.DrawString(DataGridView1.Rows(row).Cells(7).Value.ToString, f10, Brushes.Black, 0, 100 + height)
    '        e.Graphics.DrawString(DataGridView1.Rows(row).Cells(1).Value.ToString, f10, Brushes.Black, 25, 100 + height)

    '        i = CLng(DataGridView1.Rows(row).Cells(8).Value)
    '        DataGridView1.Rows(row).Cells(8).Value = Format(i, "##,##0")
    '        e.Graphics.DrawString(DataGridView1.Rows(row).Cells(8).Value.ToString, f10, Brushes.Black, rightmargin, 100 + height, right)
    '    Next
    '    'End If

    '    Dim height2 As Integer
    '    height2 = 110 + height
    '    sumprice() 'call sub
    '    e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2)
    '    e.Graphics.DrawString("Total: " & Format(t_price, "##,##0"), f10b, Brushes.Black, rightmargin, 10 + height2, right)
    '    e.Graphics.DrawString(t_qty.ToString, f10b, Brushes.Black, 0, 10 + height2)
    '    e.Graphics.DrawString("~ Thanks for shopping ~", f10, Brushes.Black, centermargin, 35 + height2, center)
    '    e.Graphics.DrawString("~ Davids DElicious Store ~", f10, Brushes.Black, centermargin, 50 + height2, center)
    'End Sub
    'Dim t_price As Long
    'Dim t_qty As Long
    'Sub sumprice()
    '    Dim countprice As Long = 0
    '    For i As Integer = 0 To DataGridView1.Rows.Count - 1
    '        countprice = CLng(countprice + Convert.ToDouble(DataGridView1.Rows(i).Cells(8).Value.ToString) * Convert.ToDouble(DataGridView1.Rows(i).Cells(7).Value.ToString))
    '    Next
    '    t_price = countprice

    '    Dim countqty As Long = 0
    '    For rowitem As Integer = 0 To DataGridView1.Rows.Count - 1
    '        countqty = CLng(countqty + Convert.ToDouble(DataGridView1.Rows(rowitem).Cells(7).Value.ToString))
    '    Next
    '    t_qty = countqty
    'End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

    End Sub


    'Private Function GenerateID() As String
    '    Dim month As String = DateTime.Now.Month.ToString("D2") ' Get the current month with leading zero if necessary
    '    Dim day As String = DateTime.Now.Day.ToString("D2") ' Get the current day with leading zero if necessary
    '    Dim year As String = DateTime.Now.Year.ToString().Substring(2) ' Get the last two digits of the current year

    '    ' Combine the components to create the ID
    '    Dim id As String = $"{month}{day}{year}"

    '    Return id
    'End Function
    Private Sub ID_gen()
        Dim maxID As Integer = 0

        ' Find the maximum value in the desired column (column index 1 in this example)
        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim cellValue As String = row.Cells(0).Value.ToString()
            Dim currentID As Integer

            If Integer.TryParse(cellValue, currentID) AndAlso currentID > maxID Then
                maxID = currentID
            End If
        Next

        ' Increment the maximum ID by 1 and display it in the txtid TextBox
        txtid.Text = (maxID + 1).ToString()
    End Sub
    Private Sub idgen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM inventorytbl"
        f = cmd.ExecuteScalar().ToString()

        Dim id As Integer
        If Integer.TryParse(f, id) Then
            txtid.Text = (id + 1).ToString()
        Else
            txtid.Text = "1" ' Set a default value if the query result is empty or not a valid integer
        End If

        con.Close()
    End Sub

    Private Sub inventorymngfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        idgen()
        DataGridView1.Visible = True
        txtrn.Text = mainfront.lblu.Text

        Timer1.Start()

        OpenCon()
        cmd.CommandText = "SELECT suppliersname FROM suppliertbl"
        dr = cmd.ExecuteReader()

        While dr.Read()
            cmbsn.Items.Add(dr("suppliersname"))
        End While

        dr.Close()
        con.Close()



    End Sub



    Private Sub btnih_Click(sender As Object, e As EventArgs)
        Dim i As Integer
        For i = 0 To 0
            Ipanel.Controls.RemoveAt(i)

        Next
        Dim f As New Inventory_history()
        f.TopLevel = False
        f.WindowState = FormWindowState.Normal
        f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        f.Visible = True
        Ipanel.Controls.Add(f)




        'DataGridView2.Visible = True
        'DataGridView1.Visible = False
        'pnlprint.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub

    Private Sub trnasactionfrm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtname.Focus()
    End Sub



    Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellChanged


        For i As Integer = 0 To DataGridView1.Rows.Count - 2 Step +1

            If DataGridView1.Rows(i).Cells(5).Value Is Nothing Then
                DataGridView1.Rows(i).Cells(5).Value = 0

            End If
        Next
    End Sub



    Private Sub PrintPreviewControl1_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub


    Private Sub GetMaxBatchNo()

        Dim productName As String = txtname.Text.Trim()
        Dim productCode As String = txtpcode.Text.Trim()

        If Not String.IsNullOrEmpty(productName) Or Not String.IsNullOrEmpty(productCode) Then
            OpenCon()
            cmd.CommandText = "SELECT MAX(batchno) FROM inventorytbl WHERE productname = @productName OR productcode = @productCode"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@productName", productName)
            cmd.Parameters.AddWithValue("@productCode", productCode)

            Dim maxBatchNo As Object = cmd.ExecuteScalar()

            If maxBatchNo IsNot Nothing AndAlso Not DBNull.Value.Equals(maxBatchNo) Then
                txtbatchno.Text = CStr(CInt(maxBatchNo.ToString()) + 1)
            Else
                txtbatchno.Text = "1"
            End If

            con.Close()
        End If
    End Sub
    Private Sub txtname_TextChanged(sender As Object, e As EventArgs)
        GetMaxBatchNo()
        If txtname.Text = "" Then
            txtstocks.Text = "0"
            Button2.Enabled = False
        Else
            Button2.Enabled = True
            txtstocks.Text = "1"
        End If



        Dim searchText As String = txtname.Text.Trim()


        ' Clear existing items in the ListBox


        If Not String.IsNullOrEmpty(searchText) AndAlso cmbsn.SelectedItem IsNot Nothing Then
            OpenCon()
            cmd.CommandText = "SELECT DISTINCT productname FROM productlisttbl WHERE productname LIKE @searchText AND suppliername = @supplierName GROUP BY productname"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("searchText", "%" & searchText & "%")
            cmd.Parameters.AddWithValue("supplierName", cmbsn.SelectedItem.ToString())

            dr = cmd.ExecuteReader

            While dr.Read()
                txtname.Items.Add(dr("productname").ToString())
            End While

            con.Close()
        End If

        ' Show the ListBox if there are any suggestions


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtpcode.Focus()
        If cmbsn.SelectedItem Is Nothing Then
            MsgBox("Add supplier's name")
        ElseIf txtcost.Text = "" Then
            MsgBox("Add price")
        Else
            Button3.Enabled = True
            cmbsn.Enabled = False
            Dim name As String = txtname.Text
            Dim stocksToAdd As Integer = 0
            If txtpcode.Text IsNot "" Then
                ProcessBarcodeData(txtpcode.Text.Trim())

            Else
                If Integer.TryParse(txtstocks.Text, stocksToAdd) Then
                    Dim foundRow As DataGridViewRow = Nothing
                    Dim duplicateRow As Boolean = False ' Flag to track if duplicate row is found

                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If row.Cells.Count > 1 AndAlso row.Cells(3).Value IsNot Nothing AndAlso row.Cells(3).Value.ToString() = name Then
                            foundRow = row

                            Exit For
                        End If
                    Next

                    If foundRow IsNot Nothing Then
                        Dim currentStocks As Integer = 0
                        If Integer.TryParse(foundRow.Cells(10).Value?.ToString(), currentStocks) Then
                            foundRow.Cells(10).Value = currentStocks + stocksToAdd
                            foundRow.Cells(12).Value = CInt(foundRow.Cells(10).Value) * CInt(foundRow.Cells(11).Value) ' calculate total cost
                            txtname.Text = ""
                            txtstocks.Text = ""
                            txtcost.Text = ""

                        End If
                    Else
                        OpenCon()
                        cmd.CommandText = "SELECT * FROM productlisttbl WHERE productname = @a AND suppliername = @b"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("a", name)
                        cmd.Parameters.AddWithValue("b", cmbsn.SelectedItem)
                        dr = cmd.ExecuteReader

                        If dr.HasRows Then
                            con.Close()
                            OpenCon()
                            cmd.CommandText = "SELECT * FROM productlisttbl WHERE productname = @a AND suppliername = @b"
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("a", name)
                            cmd.Parameters.AddWithValue("b", cmbsn.SelectedItem)
                            dr = cmd.ExecuteReader

                            If dr.HasRows Then
                                While dr.Read()
                                    Dim newRow As DataGridViewRow = Nothing
                                    For Each row As DataGridViewRow In DataGridView1.Rows
                                        If row.Cells.Count > 1 AndAlso row.Cells(3).Value IsNot Nothing AndAlso row.Cells(3).Value.ToString() = dr("productname").ToString() Then
                                            duplicateRow = True
                                            newRow = row
                                            Exit For
                                        End If
                                    Next

                                    If duplicateRow Then
                                        Dim currentStocks As Integer = 0
                                        If Not Convert.IsDBNull(newRow.Cells(10).Value) AndAlso Integer.TryParse(newRow.Cells(10).Value.ToString(), currentStocks) Then
                                            newRow.Cells(10).Value = currentStocks + stocksToAdd
                                            newRow.Cells(12).Value = CInt(newRow.Cells(10).Value) * CInt(newRow.Cells(11).Value) ' calculate total cost
                                            txtname.Text = ""
                                            txtstocks.Text = ""
                                            txtcost.Text = ""

                                        End If
                                    Else
                                        newRow = DataGridView1.Rows(DataGridView1.Rows.Add())
                                        newRow.Cells(0).Value = txtid.Text
                                        newRow.Cells(1).Value = txtbatchno.Text
                                        newRow.Cells(2).Value = dr("productcode")
                                        newRow.Cells(3).Value = name
                                        newRow.Cells(4).Value = dr("brand")
                                        newRow.Cells(5).Value = dr("category")
                                        newRow.Cells(6).Value = dr("unitmeasure")
                                        newRow.Cells(7).Value = DateTimePickermnf.Value
                                        newRow.Cells(8).Value = DateTimePickerexp.Value

                                        newRow.Cells(10).Value = stocksToAdd
                                        newRow.Cells(11).Value = txtcost.Text
                                        newRow.Cells(12).Value = CInt(newRow.Cells(10).Value) * CInt(newRow.Cells(11).Value) ' calculate total cost
                                        newRow.Cells(13).Value = "Delete"

                                        duplicateRow = False
                                        con.Close()
                                        ID_gen()

                                        OpenCon()
                                        cmd.CommandText = "SELECT * FROM productlisttbl WHERE productname = @a"
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("a", name)
                                        dr = cmd.ExecuteReader

                                        If dr.HasRows Then

                                            While dr.Read()
                                                newRow.Cells(9).Value = If(Not Convert.IsDBNull(dr("stocks")), CInt(dr("stocks")), 0)

                                            End While
                                        Else
                                            newRow.Cells(9).Value = "0"
                                        End If


                                        Exit While
                                    End If
                                End While

                                con.Close()
                                txtname.Text = ""
                                txtstocks.Text = ""
                                txtcost.Text = ""

                            End If
                        Else
                            con.Close()
                            MsgBox("register the product first")
                            cmbsn.Enabled = True
                        End If
                    End If

                    'Calculate overall sum of stocks
                    Dim overallStocks As Integer = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        If row.Cells.Count > 1 AndAlso row.Cells(12).Value IsNot Nothing Then
                            overallStocks += CInt(row.Cells(12).Value)
                        End If
                    Next

                    ' Update txtstocks with the overall sum
                    txttotal.Text = overallStocks.ToString()
                End If

            End If
        End If

    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim result As DialogResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            If e.ColumnIndex = 13 Then
                DataGridView1.Rows.RemoveAt(e.RowIndex)
                txttotal.Text = ""
                Me.Refresh()
                Dim totalCostSum As Decimal = 0
                Dim outTotalCost As Decimal = 0 ' Declare the outTotalCost variable

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(12).Value IsNot Nothing AndAlso Decimal.TryParse(row.Cells(12).Value.ToString(), outTotalCost) Then
                        totalCostSum += outTotalCost
                    End If
                Next
                txttotal.Text = totalCostSum.ToString()
            End If
            If DataGridView1.Rows.Count > 0 Then
                Button3.Enabled = True
            Else
                Button3.Enabled = False
            End If

        End If


    End Sub



    'Private Sub comboxmethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboxmethod.SelectedIndexChanged
    '    Dim selectedMethod As String = comboxmethod.SelectedItem.ToString()

    '    If selectedMethod = "Cash" Then
    '        ch.Visible = True
    '        mn.Visible = False

    '    ElseIf selectedMethod = "Mobile Payment" Then
    '        mn.Visible = True
    '        ch.Visible = False

    '    End If
    'End Sub
    'Private Sub txtamount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtamount.KeyPress
    '    ' Allowing numbers, decimal point, and backspace
    '    If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ChrW(Keys.Back) Then
    '        e.Handled = True
    '    End If

    '    ' Check if the Enter key is pressed
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        e.Handled = True ' Prevent the beep sound

    '        Dim totalCost As Decimal = 0
    '        Dim amount As Decimal = 0

    '        If Decimal.TryParse(txttotal.Text, totalCost) AndAlso Decimal.TryParse(txtamount.Text, amount) Then
    '            Dim change As Decimal = amount - totalCost
    '            Button3.Visible = True

    '            If change >= 0 Then
    '                txtchange.Text = change.ToString("N2")
    '            Else
    '                MessageBox.Show("Amount is not enough.", "Insufficient Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                txtchange.Text = "0.00"
    '                Button3.Visible = False
    '            End If
    '        Else
    '            MessageBox.Show("Invalid input. Please enter valid amounts.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            txtchange.Text = "0.00"
    '            Button3.Visible = False
    '        End If

    '        ' Clear the amount TextBox
    '        txtamount.Clear()
    '    End If
    'End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenCon()
        cmd.CommandText = "INSERT INTO inventorytbl VALUES (@id, @batchno, @suppliername, @recievername, @productcode, @productname, @brand, @category, @unit, @quantity, @expiration, @manufacture, @total, @price, @date)"

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            With cmd.Parameters
                .Clear()
                .AddWithValue("id", DataGridView1.Rows(i).Cells(0).Value.ToString())
                .AddWithValue("batchno", DataGridView1.Rows(i).Cells(1).Value.ToString())
                .AddWithValue("suppliername", cmbsn.SelectedItem)
                .AddWithValue("recievername", txtrn.Text)
                .AddWithValue("productcode", DataGridView1.Rows(i).Cells(2).Value.ToString())
                .AddWithValue("productname", DataGridView1.Rows(i).Cells(3).Value.ToString())
                .AddWithValue("brand", DataGridView1.Rows(i).Cells(4).Value.ToString())
                .AddWithValue("category", DataGridView1.Rows(i).Cells(5).Value.ToString())
                .AddWithValue("unit", DataGridView1.Rows(i).Cells(6).Value.ToString())
                .AddWithValue("quantity", DataGridView1.Rows(i).Cells(10).Value.ToString())
                .AddWithValue("expiration", CDate(DataGridView1.Rows(i).Cells(7).Value))
                .AddWithValue("manufacture", CDate(DataGridView1.Rows(i).Cells(8).Value))
                .AddWithValue("total", DataGridView1.Rows(i).Cells(12).Value.ToString())
                .AddWithValue("price", DataGridView1.Rows(i).Cells(11).Value.ToString())
                .AddWithValue("date", CDate(DateTimePicker1.Value))
            End With
            cmd.ExecuteNonQuery()
        Next

        con.Close()
        'End Sub

        'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '    OpenCon()
        '    cmd.CommandText = "INSERT INTO inventorytbl VALUES (@id, @batchno, @suppliername, @recievername, @productcode, @productname, @brand, @category, @unit, @quantity, @expiration, @manufacture, @total, @price, @date)"

        '    For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '        With cmd.Parameters
        '            .Clear()
        '            .AddWithValue("id", DataGridView1.Rows(i).Cells(0).Value.ToString())
        '            .AddWithValue("batchno", DataGridView1.Rows(i).Cells(1).Value.ToString())
        '            .AddWithValue("suppliername", cmbsn.SelectedItem)
        '            .AddWithValue("recievername", txtrn.Text)
        '            .AddWithValue("productcode", DataGridView1.Rows(i).Cells(2).Value.ToString())
        '            .AddWithValue("productname", DataGridView1.Rows(i).Cells(3).Value.ToString())
        '            .AddWithValue("brand", DataGridView1.Rows(i).Cells(4).Value.ToString())
        '            .AddWithValue("category", DataGridView1.Rows(i).Cells(5).Value.ToString())
        '            .AddWithValue("unit", DataGridView1.Rows(i).Cells(6).Value.ToString())
        '            .AddWithValue("quantity", DataGridView1.Rows(i).Cells(10).Value.ToString())
        '            .AddWithValue("expiration", CDate(DataGridView1.Rows(i).Cells(7).Value.ToString()))
        '            .AddWithValue("manufacture", CDate(DataGridView1.Rows(i).Cells(8).Value.ToString()))
        '            .AddWithValue("total", DataGridView1.Rows(i).Cells(12).Value.ToString())
        '            .AddWithValue("price", DataGridView1.Rows(i).Cells(11).Value.ToString())
        '            .AddWithValue("date", CDate(DateTimePicker1.Value))
        '        End With
        '        cmd.ExecuteNonQuery()


        '        con.Close()
        OpenCon()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            ' Retrieve criticalStock value from the database
            cmd.CommandText = "SELECT criticalstock FROM productlisttbl WHERE productcode = @productcode"
            cmd.Parameters.Clear()

            cmd.Parameters.AddWithValue("@productcode", DataGridView1.Rows(i).Cells(2).Value.ToString())
            Dim criticalStockObject As Object = cmd.ExecuteScalar()
            Dim criticalStock As Integer

            If criticalStockObject IsNot Nothing AndAlso Not IsDBNull(criticalStockObject) Then
                criticalStock = CInt(criticalStockObject)
            Else
                ' Assign a default value when criticalStock is DBNull
                criticalStock = 0 ' Change the default value as per your requirement
            End If

            ' Update stocks and criticalstatus based on the retrieved criticalStock value

            Dim stocks As Integer = CInt(DataGridView1.Rows(i).Cells(9).Value) + CInt(DataGridView1.Rows(i).Cells(10).Value)
            Dim criticalStatus As String = If(stocks > criticalStock, "Yes", "No")

            cmd.CommandText = "UPDATE productlisttbl SET stocks = @stocks, criticalstatus = @criticalStatus WHERE productcode = @productcode"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stocks", stocks)
            cmd.Parameters.AddWithValue("@criticalStatus", criticalStatus)
            cmd.Parameters.AddWithValue("@productcode", DataGridView1.Rows(i).Cells(2).Value.ToString())
            cmd.ExecuteNonQuery()
        Next


        con.Close()

        MessageBox.Show("Update successful")
        txttotal.Text = "0.00"
        DataGridView1.Rows.Clear()
        txtbatchno.Text = ""
        Button3.Enabled = False

        'txttotal.Text = "0.00"
        'OpenCon()
        'cmd.CommandText = "INSERT INTO recentacttbl VALUES( @re, @ch)"
        'With cmd.Parameters
        '    .Clear()
        '    .AddWithValue("@re", mainfront.lblu.Text.ToString)
        '    .AddWithValue("@ch", "create an inventory with the Id of '" & txtidinv.Text.ToString & "' at '" & DateTimePicker1.Value.ToString & "'")
        'End With
        'cmd.ExecuteNonQuery()
        'con.Close()

    End Sub

    Private Sub Payment_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    'Private Sub txtCansel_Click(sender As Object, e As EventArgs)
    '    Dim result As DialogResult = MessageBox.Show("Do you want to cancel the transaction? The data from the cart will be restarted.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

    '    If result = DialogResult.Yes Then
    '        txtref.Text = ""
    '        txtchange.Text = ""
    '        TextBox1.Text = ""
    '        txtamount.Text = ""
    '        comboxmethod.Text = ""
    '        Ipanel.Controls.Clear()
    '        ch.Visible = False
    '        mn.Visible = False
    '        txtref.Enabled = False
    '        DataGridView1.Rows.Clear()
    '        txtname.Focus()
    '        txtstocks.Text = "0"
    '        txttotal.Text = "0.00"
    '    Else
    '        ' User selected No, stay on the current page
    '    End If


    'End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub txtpcode_TextChanged(sender As Object, e As EventArgs) Handles txtpcode.TextChanged
        GetMaxBatchNo()

        If txtpcode.Text = "" Then
            txtstocks.Text = "0"
            Button2.Enabled = False
        Else
            txtstocks.Text = "1"
            Button2.Enabled = True
        End If
    End Sub

    Private Sub cmbsn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsn.SelectedIndexChanged
        txtpcode.Enabled = True
        txtname.Enabled = True
        txtpcode.Focus()
        Dim suppliername As String = cmbsn.Text.Trim()
        OpenCon()
        cmd.CommandText = "SELECT productname FROM productlisttbl where suppliername = @supplier"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("supplier", suppliername)
        dr = cmd.ExecuteReader()

        While dr.Read()
            txtname.Items.Add(dr("productname"))
        End While

        dr.Close()
        con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label10.Visible = True
        txtname.Visible = True
        Button4.Visible = True
        Label1.Visible = False
        txtpcode.Visible = False
        Button1.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label10.Visible = False
        txtname.Visible = False
        Button4.Visible = False
        Label1.Visible = True
        txtpcode.Visible = True
        Button1.Visible = True
    End Sub

    Private Sub txtname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtname.SelectedIndexChanged
        GetMaxBatchNo()
        If txtname.Items.Count = 0 Then
            txtstocks.Text = "0"
            Button2.Enabled = False
        Else
            Button2.Enabled = True
            txtstocks.Text = "1"
        End If

    End Sub

    Private Sub txtamount_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
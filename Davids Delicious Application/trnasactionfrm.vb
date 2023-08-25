Imports System.Drawing.Printing
Imports System.IO

Public Class trnasactionfrm
    Private Sub txtqua_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtqua.KeyPress
        ' Allowing numbers, decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If TextBox1.Text.Length <> 11 OrElse Not TextBox1.Text.StartsWith("09") Then
            Button2.Visible = False
            txtref.Enabled = True

        Else
            Button2.Visible = True

        End If

    End Sub
    Private Sub txtamount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtamount.KeyPress
        ' Allowing numbers, decimal point, and backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True


        End If

        ' Check if the Enter key is pressed
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True ' Prevent the beep sound

            Dim totalCost As Decimal = 0
            Dim amount As Decimal = 0

            If Decimal.TryParse(txttotal.Text, totalCost) AndAlso Decimal.TryParse(txtamount.Text, amount) Then
                Dim change As Decimal = amount - totalCost
                Button2.Visible = True

                If change >= 0 Then
                    txtchange.Text = change.ToString("N2")
                Else
                    MessageBox.Show("Amount is not enough.", "Insufficient Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtchange.Text = "0.00"
                End If
            Else
                MessageBox.Show("Invalid input. Please enter valid amounts.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtchange.Text = "0.00"
            End If

            ' Clear the amount TextBox
            txtamount.Clear()
        End If
    End Sub
    'Private Function GetProductData() As DataTable
    '    Dim dataTable As New DataTable()
    '    Try
    '        OpenCon()
    '        cmd.CommandText = "SELECT productname, brand, costperunit, image FROM productlisttbl"
    '        Dim adapter As New MySqlDataAdapter(cmd)
    '        adapter.Fill(dataTable)
    '        con.Close()
    '    Catch ex As Exception
    '        MsgBox("Error retrieving product data: " & ex.Message)
    '    End Try
    '    Return dataTable
    'End Function


    'Private Sub trnasactionfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim productData As DataTable = GetProductData()

    '    ' Bind the product data to the DataGridView
    '    DataGridView2.DataSource = productData

    '    ' Resize the columns to fit the content
    '    DataGridView2.AutoResizeColumns()
    '    Timer1.Start()
    '    txtcash.Text = mainfront.lblu.Text
    '    lbltc.Text = GenerateID()
    '    txtcode.Focus()
    'End Sub


    'Private Sub dataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
    '    If DataGridView2.Columns(e.ColumnIndex).Name = "image" AndAlso e.RowIndex >= 0 Then
    '        Dim cellValue As Object = e.Value
    '        If cellValue IsNot Nothing AndAlso TypeOf cellValue Is Byte() Then
    '            Dim imageData As Byte() = DirectCast(cellValue, Byte())
    '            If imageData.Length > 0 Then
    '                Using memoryStream As New MemoryStream(imageData)
    '                    Dim image As Image = Image.FromStream(memoryStream)
    '                    e.Value = image
    '                End Using
    '            End If
    '        End If
    '    End If
    'End Sub
    Private Function GenerateID() As String
        Dim currentDate As DateTime = DateTime.Now
        Dim month As String = currentDate.Month.ToString("D2") ' Two-digit month
        Dim day As String = currentDate.Day.ToString("D2") ' Two-digit day
        Dim year As String = currentDate.Year.ToString() ' Four-digit year
        Dim time As String = currentDate.ToString("HHmmss") ' Time in format HHmmss

        Dim generatedID As String = month & day & year & time
        Return generatedID
    End Function

    Private Sub txtcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcode.KeyPress

        ' Check if the Enter key is pressed
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim pc As String = txtcode.Text.Trim()
            OpenCon()
            cmd.CommandText = "SELECT image FROM productlisttbl where productcode = @code"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@code", pc)
            dr = cmd.ExecuteReader()

            While dr.Read()
                Dim imageData As Byte() = DirectCast(dr("image"), Byte())
                Using stream As New MemoryStream(imageData)
                    PictureBox1.Image = Image.FromStream(stream)
                End Using
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            End While

            dr.Close()
            con.Close()

            txtqua.Focus()
            txtqua.Text = "1"
        End If
    End Sub

    Private Sub AddScannedBarcode(barcodeData As String)
        Dim productCode As String = barcodeData
        Dim stocksToAdd As Integer = 0

        If Integer.TryParse(txtqua.Text, stocksToAdd) Then
            Dim foundRow As DataGridViewRow = Nothing

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells.Count > 1 AndAlso row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = productCode Then
                    foundRow = row
                    Exit For
                End If
            Next

            If foundRow IsNot Nothing Then
                Dim currentStocks As Integer = 0

                If Integer.TryParse(foundRow.Cells(7).Value?.ToString(), currentStocks) Then
                    foundRow.Cells(7).Value = currentStocks + stocksToAdd
                    foundRow.Cells(10).Value = CInt(foundRow.Cells(4).Value) * CInt(foundRow.Cells(7).Value) ' <-- calculate total cost
                End If
            Else
                ' Perform your database query and data retrieval logic here
                ' Assuming you have a connection object named 'connection' and a command object named 'command'

                Dim productCost As Decimal = 0
                Dim productName As String = ""
                Dim category As String = ""
                Dim unitMeasure As String = ""
                Dim brand As String = ""
                OpenCon()

                ' Execute the database query to retrieve the product details based on the product code
                cmd.CommandText = "SELECT ProductCost, ProductName, Category, UnitMeasure, Brand FROM productlisttbl WHERE ProductCode = @ProductCode"

                ' Clear the parameters before adding a new one
                cmd.Parameters.Clear()

                ' Add the product code parameter
                cmd.Parameters.AddWithValue("@ProductCode", productCode)

                ' Execute the query and retrieve the product details
                dr = cmd.ExecuteReader()
                If dr.Read() Then
                    ' Retrieve the values from the reader
                    productCost = Convert.ToDecimal(dr("ProductCost"))
                    productName = dr("ProductName").ToString()
                    category = dr("Category").ToString()
                    unitMeasure = dr("UnitMeasure").ToString()
                    brand = dr("Brand").ToString()
                End If

                dr.Close()

                ' Calculate the total cost based on the retrieved product cost and quantity
                Dim quantity As Integer = stocksToAdd
                Dim totalCost As Decimal = productCost * quantity

                ' Add the product details to the DataGridView
                DataGridView1.Rows.Add(lbltc.Text, productCode, productName, category, productCost, brand, unitMeasure, quantity, DateTimePicker1.Value, txtcash.Text, totalCost, "Delete")
            End If

            con.Close()

            ' Calculate the total cost sum
            Dim totalCostSum As Decimal = 0

            For Each row As DataGridViewRow In DataGridView1.Rows
                Dim cellValue As Decimal = 0
                If row.Cells(10).Value IsNot Nothing AndAlso Decimal.TryParse(row.Cells(10).Value.ToString(), cellValue) Then
                    totalCostSum += cellValue
                End If
            Next

            txttotal.Text = totalCostSum.ToString()
            UpdateTotalCost()
        End If
    End Sub


    Private Sub UpdateTotalCost()
        Dim totalCostSum As Decimal = 0

        For Each row As DataGridViewRow In DataGridView1.Rows
            Dim cellValue As Decimal = 0
            If row.Cells(8).Value IsNot Nothing AndAlso Decimal.TryParse(row.Cells(8).Value.ToString(), cellValue) Then
                totalCostSum += cellValue
            End If
        Next

        ' Apply discount if total cost is >= 3000
        If totalCostSum >= 3000 Then
            Dim discount As Decimal = CDec(totalCostSum * 0.05) ' 5% discount
            totalCostSum -= discount
        End If

        txttotal.Text = totalCostSum.ToString()
    End Sub

    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
    Sub changelongpaper()
        Dim rowcount As Integer
        longpaper = 0
        rowcount = DataGridView1.Rows.Count
        longpaper = rowcount * 15
        longpaper = longpaper + 200
    End Sub
    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        'pagesetup.Margins = New Margins(200, 0, 0, 0)
        'pagesetup.PaperSize = New PaperSize("Custom", 250, 500) 'fixed size
        pagesetup.PaperSize = New PaperSize("Custom", 300, longpaper)
        PD.DefaultPageSettings = pagesetup
    End Sub
    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Right
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width \ 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        'font alignment
        Dim right As New StringFormat
        Dim center As New StringFormat

        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "--------------------------------------------------------------------------"

        'range from top
        e.Graphics.DrawString("Davids DElicious Store", f14, Brushes.Black, centermargin, 5, center)
        e.Graphics.DrawString("RIZAL Aveneu, Taytay Rizal 1920", f10, Brushes.Black, centermargin, 25, center)
        e.Graphics.DrawString("Tel +123456", f10, Brushes.Black, centermargin, 40, center)

        e.Graphics.DrawString("Invoice ID", f8, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 60)
        e.Graphics.DrawString(lbltc.Text, f8, Brushes.Black, 70, 60)

        e.Graphics.DrawString("Cashier", f8, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 75)
        e.Graphics.DrawString(txtcash.Text, f8, Brushes.Black, 70, 75)

        e.Graphics.DrawString(DateTimePicker1.Value.ToString, f8, Brushes.Black, 0, 90)

        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 100)

        Dim height As Integer 'DGV Position
        Dim i As Long
        DataGridView1.AllowUserToAddRows = False
        ''If DataGridView1.CurrentCell.Value Is Nothing Then
        ''    Exit Sub
        ''Else
        For row As Integer = 0 To DataGridView1.RowCount - 1
            height += 15
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(6).Value.ToString, f10, Brushes.Black, 0, 100 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(2).Value.ToString, f10, Brushes.Black, 25, 100 + height)
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(7).Value.ToString, f10, Brushes.Black, rightmargin - 100, 100 + height)

            i = CLng(DataGridView1.Rows(row).Cells(8).Value)
            DataGridView1.Rows(row).Cells(8).Value = Format(i, "##,##0")
            e.Graphics.DrawString(DataGridView1.Rows(row).Cells(8).Value.ToString, f10, Brushes.Black, rightmargin, 100 + height, right)
        Next
        'End If

        Dim height2 As Integer
        height2 = 110 + height
        sumprice() 'call sub
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2)
        e.Graphics.DrawString("Total: " & Format(t_qty, "##,##0"), f10b, Brushes.Black, rightmargin, 10 + height2, right)
        e.Graphics.DrawString(t_price.ToString, f10b, Brushes.Black, rightmargin - 100, 10 + height2)
        e.Graphics.DrawString("~ Thanks for shopping ~", f10, Brushes.Black, centermargin, 35 + height2, center)
        e.Graphics.DrawString("~ Davids DElicious Store ~", f10, Brushes.Black, centermargin, 50 + height2, center)
    End Sub
    Dim t_price As Long
    Dim t_qty As Long
    Sub sumprice()
        Dim countprice As Long = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            countprice = CLng(countprice + Convert.ToDouble(DataGridView1.Rows(i).Cells(7).Value.ToString))
        Next
        t_price = countprice

        Dim countqty As Long = 0
        For rowitem As Integer = 0 To DataGridView1.Rows.Count - 1
            countqty = CLng(countqty + Convert.ToDouble(DataGridView1.Rows(rowitem).Cells(8).Value.ToString))
        Next
        t_qty = countqty
        Updatestock()
        DataGridView1.Rows.Clear()
        MessageBox.Show("Successfully")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BTNPayment.Enabled = False
        DataGridView2.Visible = False
        Label10.Visible = False
        txtsearch.Visible = False
        'DataGridView1.Visible = False
        changelongpaper()
        PPD.Document = PD
        'Dim f As New Dashboard()

        PPD.TopLevel = False
        PPD.WindowState = FormWindowState.Maximized
        PPD.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        PPD.Visible = True
        Ipanel.Controls.Add(PPD)


    End Sub


    Private Sub Updatestock()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            OpenCon()
            cmd.CommandText = "UPDATE productlisttbl SET stocks = stocks - @Add WHERE productcode = @Code"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Add", DataGridView1.Rows(i).Cells(7).Value.ToString)
            cmd.Parameters.AddWithValue("@Code", DataGridView1.Rows(i).Cells(1).Value.ToString)
            cmd.ExecuteNonQuery()
            con.Close()

            OpenCon()

            ' Retrieve stocks value from the database
            cmd.CommandText = "SELECT stocks FROM productlisttbl WHERE productcode = @productcode"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@productcode", DataGridView1.Rows(i).Cells(1).Value.ToString())
            Dim stocksObject As Object = cmd.ExecuteScalar()
            Dim stocks As Integer

            If stocksObject IsNot Nothing AndAlso Not IsDBNull(stocksObject) Then
                stocks = CInt(stocksObject)
            Else
                ' Assign a default value when stocks is DBNull
                stocks = 0 ' Change the default value as per your requirement
            End If

            ' Retrieve criticalStock value from the database
            cmd.CommandText = "SELECT criticalstock FROM productlisttbl WHERE productcode = @productcode"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@productcode", DataGridView1.Rows(i).Cells(1).Value.ToString())
            Dim criticalStockObject As Object = cmd.ExecuteScalar()
            Dim criticalStock As Integer

            If criticalStockObject IsNot Nothing AndAlso Not IsDBNull(criticalStockObject) Then
                criticalStock = CInt(criticalStockObject)
            Else
                ' Assign a default value when criticalStock is DBNull
                criticalStock = 0 ' Change the default value as per your requirement
            End If

            ' Update stocks and criticalstatus based on the retrieved criticalStock value
            Dim criticalStatus As String = If(stocks > criticalStock, "Yes", "No")

            cmd.CommandText = "UPDATE productlisttbl SET stocks = @stocks, criticalstatus = @criticalStatus WHERE productcode = @productcode"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@stocks", stocks)
            cmd.Parameters.AddWithValue("@criticalStatus", criticalStatus)
            cmd.Parameters.AddWithValue("@productcode", DataGridView1.Rows(i).Cells(1).Value.ToString())
            cmd.ExecuteNonQuery()

            con.Close()
            OpenCon()
            Dim cost As Double = Convert.ToDouble(DataGridView1.Rows(i).Cells(7).Value) * Convert.ToInt32(DataGridView1.Rows(i).Cells(9).Value)

            cmd.CommandText = "INSERT INTO transactiontbl (id, cashier, productcode, productname, brand, category, unit, price, quantity, productcost, netsales, profit, date) VALUES (@id, @cashier, @productcode, @productname, @brand, @category, @unit, @price, @quantity, @productcost, @netsales, @profit, @date)"
            cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@id", DataGridView1.Rows(i).Cells(0).Value.ToString()) ' Assuming the 'id' column is auto-increment
                cmd.Parameters.AddWithValue("@cashier", txtcash.Text)
                cmd.Parameters.AddWithValue("@productcode", DataGridView1.Rows(i).Cells(1).Value.ToString())
                cmd.Parameters.AddWithValue("@productname", DataGridView1.Rows(i).Cells(2).Value.ToString())
                cmd.Parameters.AddWithValue("@brand", DataGridView1.Rows(i).Cells(5).Value.ToString())
                cmd.Parameters.AddWithValue("@category", DataGridView1.Rows(i).Cells(3).Value.ToString())
                cmd.Parameters.AddWithValue("@unit", DataGridView1.Rows(i).Cells(4).Value.ToString())
                cmd.Parameters.AddWithValue("@price", DataGridView1.Rows(i).Cells(6).Value.ToString())
                cmd.Parameters.AddWithValue("@quantity", DataGridView1.Rows(i).Cells(7).Value.ToString())
            cmd.Parameters.AddWithValue("@productcost", cost)
            cmd.Parameters.AddWithValue("@netsales", CDbl(DataGridView1.Rows(i).Cells(8).Value.ToString()))
            cmd.Parameters.AddWithValue("@profit", CDbl(DataGridView1.Rows(i).Cells(8).Value.ToString()) - cost)
            cmd.Parameters.AddWithValue("@date", DateTimePicker1.Value.Date)
            cmd.ExecuteNonQuery()

            con.Close()


            Payment.Visible = False
            txttotal.Text = ""
            BTNPayment.Enabled = True
        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        BTNPayment.Enabled = True
        Dim code As String = txtcode.Text.Trim()

        Dim stocksToAdd As Integer = 0
        OpenCon()

        ' Check if the entered quantity is less than the available stock
        cmd.CommandText = "SELECT stocks FROM productlisttbl WHERE productcode = @productcode"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@productcode", code)

        Dim availableStock As Integer = 0
        Dim enteredQuantity As Integer = 0

        ' Execute the query and retrieve the available stock
        dr = cmd.ExecuteReader()
        If dr.Read() Then
            ' Retrieve the available stock from the reader
            availableStock = Convert.ToInt32(dr("stocks"))
        End If

        dr.Close()
        con.Close()

        If Integer.TryParse(txtqua.Text, enteredQuantity) AndAlso enteredQuantity > 0 AndAlso enteredQuantity <= availableStock Then
            If String.IsNullOrEmpty(code) Then
                MessageBox.Show("Product code is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If Integer.TryParse(txtqua.Text, stocksToAdd) AndAlso stocksToAdd > 0 Then
                Dim foundRow As DataGridViewRow = Nothing

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells.Count > 1 AndAlso row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = code Then
                        foundRow = row
                        Exit For
                    End If
                Next

                If foundRow IsNot Nothing Then
                    Dim currentStocks As Integer = 0

                    If Integer.TryParse(foundRow.Cells(7).Value?.ToString(), currentStocks) Then
                        foundRow.Cells(7).Value = currentStocks + stocksToAdd
                        foundRow.Cells(8).Value = CInt(foundRow.Cells(6).Value) * CInt(foundRow.Cells(7).Value) ' <-- calculate total cost
                    End If
                Else
                    ' Perform your database query and data retrieval logic here
                    ' Assuming you have a connection object named 'connection' and a command object named 'command'

                    Dim costPerUnit As Decimal = 0
                    Dim cost As Decimal = 0
                    Dim productName As String = ""
                    Dim category As String = ""
                    Dim unitMeasure As String = ""
                    Dim brand As String = ""

                    OpenCon()
                    ' Execute the database query to retrieve the product details based on the product code
                    cmd.CommandText = "SELECT productname, category, unitmeasure, brand, costperunit FROM productlisttbl WHERE productcode = @productcode"
                    cmd.Parameters.Clear() ' Clear existing parameters
                    cmd.Parameters.AddWithValue("@productcode", code)

                    ' Execute the query and retrieve the product details
                    dr = cmd.ExecuteReader()
                    If dr.Read() Then
                        ' Retrieve the values from the reader
                        productName = dr("productname").ToString()
                        category = dr("category").ToString()
                        unitMeasure = dr("unitmeasure").ToString()
                        brand = dr("brand").ToString()
                        Decimal.TryParse(dr("costperunit").ToString(), costPerUnit)
                    End If
                    dr.Close()
                    cmd.CommandText = "SELECT * FROM inventorytbl WHERE productcode = @pcode"
                    cmd.Parameters.Clear() ' Clear existing parameters
                    cmd.Parameters.AddWithValue("@pcode", code)

                    ' Execute the query and retrieve the product details
                    dr = cmd.ExecuteReader()
                    If dr.Read() Then
                        ' Retrieve the values from the reader
                        Decimal.TryParse(dr("price").ToString(), cost)
                    End If

                    con.Close()


                    ' Calculate the total cost based on the retrieved product cost and quantity
                    Dim quantity As Integer = stocksToAdd
                    Dim totalCost As Decimal = costPerUnit * quantity

                    ' Add the product details to the DataGridView
                    DataGridView1.Rows.Add(lbltc.Text, code, productName, category, unitMeasure, brand, costPerUnit, quantity, totalCost, cost, "Delete")
                End If

                PictureBox1.Image = Nothing
                txtcode.Text = ""
                txtqua.Text = "0"
                txtcode.Focus()
                ID_gen()

            Else

                MessageBox.Show("Invalid quantity. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            PictureBox1.Image = Nothing
            txtcode.Text = ""
            txtqua.Text = "0"
            txtcode.Focus()
        Else
            MessageBox.Show("Invalid quantity or out of stock. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



        ' Calculate the total cost sum
        Dim totalCostSum As Decimal = 0
        Dim outTotalCost As Decimal = 0 ' Declare the outTotalCost variable

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(8).Value IsNot Nothing AndAlso Decimal.TryParse(row.Cells(8).Value.ToString(), outTotalCost) Then
                totalCostSum += outTotalCost
            End If
        Next

        txttotal.Text = totalCostSum.ToString()
        'UpdateTotalCost()
        'txtcode.Text = ""
        '    txtqua.Text = "0"
        '    txtcode.Focus()
        'End If
    End Sub
    Private Sub dgv()
        If DataGridView1.Rows IsNot Nothing Then
            BTNPayment.Enabled = True
        Else
            BTNPayment.Enabled = False
        End If
    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim result As DialogResult = MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            If e.ColumnIndex = 10 Then
                DataGridView1.Rows.RemoveAt(e.RowIndex)
                txttotal.Text = ""
                Me.Refresh()
                Dim totalCostSum As Decimal = 0
                Dim outTotalCost As Decimal = 0 ' Declare the outTotalCost variable

                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(8).Value IsNot Nothing AndAlso Decimal.TryParse(row.Cells(8).Value.ToString(), outTotalCost) Then
                        totalCostSum += outTotalCost
                    End If
                Next
                txttotal.Text = totalCostSum.ToString()
            End If
            If DataGridView1.Rows.Count > 0 Then
                BTNPayment.Enabled = True
            Else
                BTNPayment.Enabled = False
            End If

        End If

        'If e.ColumnIndex = 10 Then
        '    DataGridView1.Rows.RemoveAt(e.RowIndex)
        '    txttotal.Text = ""
        'End If
    End Sub


    Private Sub Paid()

    End Sub


    Private Sub UpdateButton3Status()
        If Not String.IsNullOrEmpty(txtcode.Text) Then
            Button3.Enabled = True
        Else
            Button3.Enabled = False
            txtqua.Text = "0"
        End If
    End Sub
    Private Sub BTNPayment_Click(sender As Object, e As EventArgs) Handles BTNPayment.Click
        Payment.Visible = True
    End Sub
    Private Sub comboxmethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboxmethod.SelectedIndexChanged
        Dim selectedMethod As String = comboxmethod.SelectedItem.ToString()

        If selectedMethod = "Cash" Then
            Panel2.Visible = True
            Panel3.Visible = False

        ElseIf selectedMethod = "Mobile Payment" Then
            Panel3.Visible = True
            Panel2.Visible = False

        End If
    End Sub
    Private Sub trnasactionfrm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtcode.Focus()
    End Sub

    Private Sub txtCansel_Click(sender As Object, e As EventArgs) Handles txtCansel.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to cancel the transaction? The data from the cart will be restarted.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Payment.Visible = False
            txtref.Text = ""
            txtchange.Text = ""
            TextBox1.Text = ""
            txtamount.Text = ""
            comboxmethod.Text = ""
            Ipanel.Controls.Clear()
            Payment.Visible = False
            Panel3.Visible = False
            Panel2.Visible = False
            txtref.Enabled = False
            BTNPayment.Enabled = False
            txtcode.Focus()
            txtqua.Text = "0"
        Else
            ' User selected No, stay on the current page
        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbltime.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub


    'Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, txtcode.TextChanged
    '    If TextBox1.Text = "" Then
    '        Button3.Enabled = False
    '    Else
    '        Button3.Enabled = False
    '    End If
    'End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If DataGridView1.Rows.Count > 0 Then
            BTNPayment.Enabled = True
        Else
            BTNPayment.Enabled = False
        End If
    End Sub

    Private Sub txtcode_TextChanged(sender As Object, e As EventArgs) Handles txtcode.TextChanged
        PPD.Visible = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
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
        lbltc.Text = (maxID + 1).ToString()
    End Sub
    Private Sub idgen()
        Dim f As String
        OpenCon()
        cmd.CommandText = "SELECT MAX(id) FROM transactiontbl"
        f = cmd.ExecuteScalar().ToString()

        Dim id As Integer
        If Integer.TryParse(f, id) Then
            lbltc.Text = (id + 1).ToString()
        Else
            lbltc.Text = "1" ' Set a default value if the query result is empty or not a valid integer
        End If

        con.Close()
    End Sub
    Private Sub tblload()
        OpenCon()
        cmd.CommandText = "SELECT productcode, productname, brand, costperunit, stocks FROM productlisttbl"
        dr = cmd.ExecuteReader()

        ' Clear existing columns
        DataGridView2.Columns.Clear()

        ' Create and add columns to the DataGridView

        DataGridView2.Columns.Add("productcode", "Product Code")
        DataGridView2.Columns.Add("productname", "Product Name")
        DataGridView2.Columns.Add("brand", "Brand")
        DataGridView2.Columns.Add("costperunit", "Price")
        DataGridView2.Columns.Add("stocks", "Stocks")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView2.Rows.Add(dr("productcode"), dr("productname"), dr("brand"), dr("costperunit"), dr("stocks"))
        End While

        dr.Close()
        con.Close()
    End Sub

    Private Sub trnasactionfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        tblload()
        idgen()
        txtcash.Text = mainfront.lblu.Text
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        PPD.Visible = False
        DataGridView2.Visible = True
        Label10.Visible = True
        txtsearch.Visible = True
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim searchText As String = txtsearch.Text.Trim()

        For Each row As DataGridViewRow In DataGridView2.Rows
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

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            ' Get the value from the clicked cell in the second column (index 1)
            Dim cellValue As Object = DataGridView2.Rows(e.RowIndex).Cells(0).Value

            ' Copy the value to txtun
            txtcode.Text = cellValue.ToString()
        End If
    End Sub

    Private Sub txtcash_TextChanged(sender As Object, e As EventArgs) Handles txtcash.TextChanged

    End Sub

    Private Sub Ipanel_Paint(sender As Object, e As PaintEventArgs) Handles Ipanel.Paint

    End Sub

    Private Sub txtamount_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged

    End Sub

    Private Sub txtchange_TextChanged(sender As Object, e As EventArgs) Handles txtchange.TextChanged

    End Sub
    'Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
    '    ' Set the selected value from the ListBox to the txtcode TextBox
    '    txtcode.Text = ListBox1.SelectedItem.ToString()

    '    ' Hide the ListBox
    '    ListBox1.Visible = False
    'End Sub
    'Private Sub txtcode_TextChanged(sender As Object, e As EventArgs) Handles txtcode.TextChanged
    '    If txtcode.Text = "" Then
    '        txtqua.Text = "0"
    '        Button3.Enabled = False
    '        ListBox1.Visible = False
    '    Else
    '        Button3.Enabled = True
    '        ListBox1.Visible = True
    '    End If


    '    txtqua.Text = "1"
    '    Dim searchText As String = txtcode.Text.Trim()

    '    ' Clear existing items in the ListBox
    '    ListBox1.Items.Clear()

    '    If Not String.IsNullOrEmpty(searchText) Then
    '        OpenCon()
    '        cmd.CommandText = "SELECT DISTINCT productname FROM productlisttbl WHERE productname LIKE @searchText"
    '        cmd.Parameters.Clear()
    '        cmd.Parameters.AddWithValue("searchText", "%" & searchText & "%")
    '        dr = cmd.ExecuteReader

    '        While dr.Read()
    '            ListBox1.Items.Add(dr("productname").ToString())
    '        End While

    '        con.Close()
    '    End If
    'End Sub

    'Private Sub trnasactionfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    txtcash.Text = mainfront.lblu.Text
    '    idgen()
    'End Sub
End Class
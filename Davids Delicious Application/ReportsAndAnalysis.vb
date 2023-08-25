Imports System.Drawing.Printing
Public Class ReportsAndAnalysis
    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles PrintButton.Click
        ' Create a PrintDocument instance
        Dim printDoc As New PrintDocument()

        ' Set up the print page event handler
        AddHandler printDoc.PrintPage, AddressOf PrintPanelContents

        ' Print the document
        printDoc.Print()
    End Sub

    Private Sub PrintPanelContents(sender As Object, e As PrintPageEventArgs)
        ' Create a Graphics object from the PrintPageEventArgs
        Dim graphics As Graphics = e.Graphics

        ' Set up the font and other formatting options
        Dim font As New Font("Arial", 9)
        Dim brush As New SolidBrush(Color.Black)
        Dim xPos As Single = e.MarginBounds.Left
        Dim yPos As Single = CSng(e.MarginBounds.Top / 2)
        Dim spacing As Single = 20 ' Spacing between elements

        ' Loop through each control in the Panel1 and print its contents
        For Each control As Control In Panel1.Controls
            ' Check if the control is a Label
            If TypeOf control Is Label Then
                Dim label As Label = DirectCast(control, Label)
                ' Print the label's text
                Dim textSize As SizeF = graphics.MeasureString(label.Text, font)
                Dim textWidth As Single = textSize.Width
                Dim textHeight As Single = textSize.Height
                Dim textXPos As Single = xPos + (e.MarginBounds.Width - textWidth) / 2 ' Calculate the X position to center the text
                graphics.DrawString(label.Text, font, brush, textXPos, yPos)
                ' Move to the next line
                yPos += textHeight + spacing
            ElseIf TypeOf control Is DataGridView Then
                Dim dataGridView As DataGridView = DirectCast(control, DataGridView)
                ' Print the column headers
                For Each column As DataGridViewColumn In dataGridView.Columns
                    Dim headerTextSize As SizeF = graphics.MeasureString(column.HeaderText, font)
                    Dim headerTextWidth As Single = headerTextSize.Width
                    Dim headerTextHeight As Single = headerTextSize.Height
                    Dim headerTextXPos As Single = xPos + (column.Width - headerTextWidth) / 2 ' Calculate the X position to center the header text
                    Dim headerTextYPos As Single = yPos
                    Dim stringFormat As New StringFormat()
                    stringFormat.Alignment = StringAlignment.Center ' Set the alignment to center
                    stringFormat.LineAlignment = StringAlignment.Center ' Set the vertical alignment to center
                    graphics.DrawString(column.HeaderText, font, brush, New RectangleF(headerTextXPos, headerTextYPos, column.Width, headerTextHeight), stringFormat)
                    xPos += column.Width
                Next

                ' Move to the next line
                yPos += font.Height + spacing

                ' Print the data rows
                For Each row As DataGridViewRow In dataGridView.Rows
                    xPos = e.MarginBounds.Left
                    For Each cell As DataGridViewCell In row.Cells
                        Dim cellTextSize As SizeF = graphics.MeasureString(cell.Value.ToString(), font)
                        Dim cellTextWidth As Single = cellTextSize.Width
                        Dim cellTextHeight As Single = cellTextSize.Height
                        Dim cellTextXPos As Single = xPos + (dataGridView.Columns(cell.ColumnIndex).Width - cellTextWidth) / 2 ' Calculate the X position to center the cell text
                        graphics.DrawString(cell.Value.ToString(), font, brush, cellTextXPos, yPos)
                        xPos += dataGridView.Columns(cell.ColumnIndex).Width
                    Next
                    ' Move to the next line
                    yPos += font.Height + spacing
                Next
            End If
        Next

    End Sub
    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        Dim headerCellStyle As DataGridViewCellStyle = e.Column.HeaderCell.Style
        headerCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        headerCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
        headerCellStyle.Font = New Font(headerCellStyle.Font.FontFamily, 10) ' Adjust the font size as desired

    End Sub
    Private Sub ReportsAndAnalysis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.Image = My.Resources.Logo_removebg_preview
        DataGridView1.RowHeadersVisible = False

        ' Set the gridlines style to None
        DataGridView1.GridColor = Color.White
        DataGridView1.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' Justify column headers to center


    End Sub


    Private Sub txtsales_Click(sender As Object, e As EventArgs) Handles txtsales.Click
        Panel6.Visible = True
        Panel7.Visible = False
        comboxmethod.Text = ""
        OpenCon()
        cmd.CommandText = "SELECT date, SUM(netsales) AS total_netsales, SUM(profit) AS total_profit FROM transactiontbl GROUP BY date"
        dr = cmd.ExecuteReader()

        ' Clear existing columns and rows in DataGridView1
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()

        ' Create and add columns to the DataGridView
        DataGridView1.Columns.Add("date", "Date")
        DataGridView1.Columns.Add("total_netsales", "Total Net Sales")
        DataGridView1.Columns.Add("total_profit", "Total Profit")
        ' Set the date format for the "date" column
        Dim dateColumn As DataGridViewColumn = DataGridView1.Columns("date")
        dateColumn.DefaultCellStyle.Format = "MM/dd/yyyy"

        ' Populate data into the DataGridView
        While dr.Read()
            Dim dateValue As Date = dr.GetDateTime("date")
            Dim totalNetsales As Decimal
            If Not dr.IsDBNull(dr.GetOrdinal("total_netsales")) Then
                totalNetsales = dr.GetDecimal("total_netsales")
            Else
                totalNetsales = 0
            End If

            Dim totalProfit As Decimal
            If Not dr.IsDBNull(dr.GetOrdinal("total_profit")) Then
                totalProfit = dr.GetDecimal("total_profit")
            Else
                totalProfit = 0
            End If

            DataGridView1.Rows.Add(dateValue, totalNetsales, totalProfit)
        End While

        dr.Close()
        con.Close()

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

    Private Sub DateTimePickerexp_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerexp.ValueChanged
        Dim searchText As Date = DateTimePickerexp.Value.Date ' Get the selected date without the time part

        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim cellValue As Object = row.Cells("date").Value ' Assuming the date column is named "date" in DataGridView1

                If cellValue IsNot Nothing AndAlso TypeOf cellValue Is Date AndAlso DirectCast(cellValue, Date).Date = searchText Then
                    row.Visible = True
                Else
                    row.Visible = False
                End If
            End If
        Next
    End Sub
    Private Sub timepick()

        Dim startDate As Date = DateTimePicker1.Value.Date
        Dim endDate As Date = DateTimePicker2.Value.Date

        OpenCon()
        cmd.CommandText = "SELECT date, SUM(netsales) AS total_netsales, SUM(profit) AS total_profit FROM transactiontbl WHERE date >= @startDate AND date <= @endDate GROUP BY date"
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@startDate", startDate)
        cmd.Parameters.AddWithValue("@endDate", endDate)
        dr = cmd.ExecuteReader()

        ' Clear existing columns and rows in DataGridView1
        DataGridView1.Columns.Clear()
        DataGridView1.Rows.Clear()

        ' Create and add columns to the DataGridView
        DataGridView1.Columns.Add("date", "Date")
        DataGridView1.Columns.Add("total_netsales", "Total Net Sales")
        DataGridView1.Columns.Add("total_profit", "Total Profit")

        ' Set the date format for the "date" column
        Dim dateColumn As DataGridViewColumn = DataGridView1.Columns("date")
        dateColumn.DefaultCellStyle.Format = "MM/dd/yyyy"

        ' Populate data into the DataGridView
        While dr.Read()
            Dim dateValue As Date = dr.GetDateTime("date")
            Dim totalNetsales As Decimal = dr.GetDecimal("total_netsales")
            Dim totalProfit As Decimal = dr.GetDecimal("total_profit")
            DataGridView1.Rows.Add(dateValue, totalNetsales, totalProfit)
        End While

        dr.Close()
        con.Close()

    End Sub

    Private Sub comboxmethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboxmethod.SelectedIndexChanged
        Dim selectedMethod As String = comboxmethod.SelectedItem.ToString()

        If selectedMethod = "Inventory List" Then
            Panel7.Visible = True
            Panel6.Visible = False
            OpenCon()
            cmd.CommandText = "SELECT batchno, suppliername, recievername, productcode, productname, quantity, expiration, total, price, date FROM inventorytbl"
            dr = cmd.ExecuteReader()

            ' Clear existing columns
            DataGridView1.Columns.Clear()

            ' Create and add columns to the DataGridView
            DataGridView1.Columns.Add("batchno", "Batch No")
            DataGridView1.Columns.Add("suppliername", "Supplier Name")
            DataGridView1.Columns.Add("recievername", "Receiver Name")
            DataGridView1.Columns.Add("productcode", "Product Code")
            DataGridView1.Columns.Add("productname", "Product Name")
            DataGridView1.Columns.Add("quantity", "Quantity")
            DataGridView1.Columns.Add("expiration", "Expiration")
            DataGridView1.Columns.Add("total", "Total")
            DataGridView1.Columns.Add("price", "Price")
            DataGridView1.Columns.Add("date", "Date")

            ' Populate data into the DataGridView
            While dr.Read()
                DataGridView1.Rows.Add(dr("batchno"), dr("suppliername"), dr("recievername"), dr("productcode"), dr("productname"), dr("quantity"), dr("expiration"), dr("total"), dr("price"), dr("date"))
            End While

            dr.Close()
            con.Close()

        ElseIf selectedMethod = "Product List" Then
            Panel6.Visible = False
            Panel7.Visible = False
            OpenCon()
            cmd.CommandText = "SELECT suppliersid, suppliername, productcode, productname, category, brand, costperunit, stocks FROM productlisttbl"
            dr = cmd.ExecuteReader()

            ' Clear existing columns
            DataGridView1.Columns.Clear()

            ' Create and add columns to the DataGridView
            DataGridView1.Columns.Add("suppliersid", "Suppliers ID")
            DataGridView1.Columns.Add("suppliername", "Supplier Name")
            DataGridView1.Columns.Add("productcode", "Product Code")
            DataGridView1.Columns.Add("productname", "Product Name")
            DataGridView1.Columns.Add("category", "Category")
            DataGridView1.Columns.Add("brand", "Brand")
            DataGridView1.Columns.Add("costperunit", "Price")
            DataGridView1.Columns.Add("stocks", "Stocks")

            ' Populate data into the DataGridView
            While dr.Read()
                DataGridView1.Rows.Add(dr("suppliersid"), dr("suppliername"), dr("productcode"), dr("productname"), dr("category"), dr("brand"), dr("costperunit"), dr("stocks"))
            End While

            dr.Close()
            con.Close()

        ElseIf selectedMethod = "Transactions" Then
            Panel7.Visible = True
            Panel6.Visible = False
            OpenCon()
            cmd.CommandText = "SELECT cashier, productcode, productname, price, quantity, netsales, profit, date FROM transactiontbl"
            dr = cmd.ExecuteReader()

            ' Clear existing columns
            DataGridView1.Columns.Clear()

            ' Create and add columns to the DataGridView
            DataGridView1.Columns.Add("cashier", "Cashier")
            DataGridView1.Columns.Add("productcode", "Product Code")
            DataGridView1.Columns.Add("productname", "Product Name")
            DataGridView1.Columns.Add("price", "Price")
            DataGridView1.Columns.Add("quantity", "Quantity")
            DataGridView1.Columns.Add("netsales", "Net Sales")
            DataGridView1.Columns.Add("profit", "Profit")
            DataGridView1.Columns.Add("date", "Date")

            ' Populate data into the DataGridView
            While dr.Read()
                DataGridView1.Rows.Add(dr("cashier"), dr("productcode"), dr("productname"), dr("price"), dr("quantity"), dr("netsales"), dr("profit"), dr("date"))
            End While

            dr.Close()
            con.Close()

        ElseIf selectedMethod = "Supplier's List" Then
            Panel6.Visible = False
            Panel7.Visible = False
            OpenCon()
            cmd.CommandText = "SELECT suppliersid, suppliersname, contactno, location FROM suppliertbl"
            dr = cmd.ExecuteReader()

            ' Clear existing columns
            DataGridView1.Columns.Clear()

            ' Create and add columns to the DataGridView
            DataGridView1.Columns.Add("suppliersid", "Suppliers ID")
            DataGridView1.Columns.Add("suppliersname", "Supplier Name")
            DataGridView1.Columns.Add("contactno", "Contact Number")
            DataGridView1.Columns.Add("location", "Location")

            ' Populate data into the DataGridView
            While dr.Read()
                DataGridView1.Rows.Add(dr("suppliersid"), dr("suppliersname"), dr("contactno"), dr("location"))
            End While

            dr.Close()
            con.Close()

        ElseIf selectedMethod = "User List" Then
            Panel6.Visible = False
            Panel7.Visible = False
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
        ElseIf selectedMethod = "Expired Products" Then
            Panel7.Visible = True
            Panel6.Visible = False
            OpenCon()
            Dim currentDate As Date = Date.Now
            Dim expirationDateLimit As Date = currentDate.AddDays(7)

            cmd.CommandText = "SELECT batchno, suppliername, recievername, productcode, productname, quantity, expiration, total, price, date FROM inventorytbl WHERE DATEDIFF(expiration, @currentDate) <= 7"
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@currentDate", currentDate)
            dr = cmd.ExecuteReader()
            DataGridView1.Columns.Clear()

            ' Create and add columns to the DataGridView
            DataGridView1.Columns.Add("batchno", "Batch No")
            DataGridView1.Columns.Add("suppliername", "Supplier Name")
            DataGridView1.Columns.Add("recievername", "Receiver Name")
            DataGridView1.Columns.Add("productcode", "Product Code")
            DataGridView1.Columns.Add("productname", "Product Name")
            DataGridView1.Columns.Add("quantity", "Quantity")
            DataGridView1.Columns.Add("expiration", "Expiration")
            DataGridView1.Columns.Add("total", "Total")
            DataGridView1.Columns.Add("price", "Price")
            DataGridView1.Columns.Add("date", "Date")

            ' Populate data into the DataGridView
            While dr.Read()
                Dim expirationDate As Date = CType(dr("expiration"), Date)
                Dim daysUntilExpiration As Integer = expirationDate.Subtract(currentDate).Days
                If daysUntilExpiration <= 7 Then
                    DataGridView1.Rows.Add(dr("batchno"), dr("suppliername"), dr("recievername"), dr("productcode"), dr("productname"), dr("quantity"), expirationDate, dr("total"), dr("price"), dr("date"))
                End If
            End While

            dr.Close()
            con.Close()

        End If
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        timepick()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        timepick()
    End Sub
End Class






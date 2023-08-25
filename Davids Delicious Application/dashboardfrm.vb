Imports System.Windows.Forms.DataVisualization.Charting
Public Class dashboardfrm
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label15.Text = TimeOfDay.ToString("h:mm:ss tt")
    End Sub
    'Private Sub dashboardfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    LoadExpiringProducts()
    '    GetNumberOfUsers()
    '    Timer1.Start()
    '    Dim bp As String
    '    Dim f As String

    '    Chart2.Series.Add("daily_sale")

    '    OpenCon()
    '    cmd.CommandText = "Select * from transactions"
    '    cmd.ExecuteNonQuery()
    '    dr = cmd.ExecuteReader
    '    While dr.Read()

    '        Chart2.Series("daily_sale").Points.AddXY(dr.GetString("date"), dr("total"))

    '    End While
    '    con.Close()


    '    OpenCon()


    '    ' Retrieve the total price for the current month
    '    cmd.CommandText = "SELECT SUM(total) FROM transactions WHERE MONTH(date) = MONTH(CURRENT_DATE)"
    '    f = cmd.ExecuteScalar().ToString()

    '    If String.IsNullOrEmpty(f) Then
    '        Label12.Text = "0"
    '    Else
    '        Label12.Text = f
    '    End If


    '    con.Close()

    '    OpenCon()

    '    ' Retrieve the total price for the last month
    '    cmd.CommandText = "SELECT SUM(total) FROM transactions WHERE MONTH(date) = MONTH(CURRENT_DATE) - 1"
    '    Dim totalPrice As Object = cmd.ExecuteScalar()

    '    If totalPrice IsNot Nothing AndAlso Not Convert.IsDBNull(totalPrice) Then
    '        Label12.Text = totalPrice.ToString()
    '    Else
    '        Label11.Text = "0"
    '    End If

    '    con.Close()

    '    OpenCon()

    '    ' Retrieve the total price for the current day
    '    cmd.CommandText = "SELECT SUM(total) FROM transactions WHERE DAY(date) = DAY(CURRENT_DATE)"
    '    f = cmd.ExecuteScalar().ToString()

    '    If String.IsNullOrEmpty(f) Then
    '        lblsale.Text = "0"
    '    Else
    '        lblsale.Text = f
    '    End If

    '    con.Close()


    '    LoadProductTable()
    '    LoadRecentActivityTable()
    'End Sub

    'Private Sub LoadProductTable()
    '    Dim connection As New MySqlConnection("server=localhost;user id=root;password=password;persistsecurityinfo=True;database=mydatabase")
    '    Dim table As New DataTable()
    '    Dim adapter As New MySqlDataAdapter("SELECT productname, brand, stocks FROM mydatabase.productlisttbl WHERE stocks <= '200'", connection)

    '    adapter.Fill(table)

    '    DataGridView1.DataSource = table
    '    connection.Close()
    '    If DataGridView1.Rows Is Nothing Then
    '        Label2.Visible = False
    '    Else
    '        Label2.Visible = True
    '    End If
    'End Sub

    'Private Sub LoadRecentActivityTable()
    '    Dim connection As New MySqlConnection("server=localhost;user id=root;password=password;persistsecurityinfo=True;database=mydatabase")
    '    Dim table As New DataTable()
    '    Dim adapter As New MySqlDataAdapter("SELECT * FROM mydatabase.recentacttbl", connection)

    '    adapter.Fill(table)

    '    DataGridView2.DataSource = table
    '    connection.Close()

    'End Sub
    Private Sub profit()
        Try
            Dim f As String
            OpenCon()
            ' Retrieve the total price for the current day
            cmd.CommandText = "SELECT Sum(profit) FROM transactiontbl"
            f = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(f) Then
                Label11.Text = "0"
            Else
                Label11.Text = f
            End If
        Catch ex As Exception
            ' Handle any exceptions or display an error message
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub netsale()
        Try
            Dim f As String
            OpenCon()
            ' Retrieve the total price for the current day
            cmd.CommandText = "SELECT Sum(netsales) FROM transactiontbl"
            Label10.Text = cmd.ExecuteScalar().ToString()
            f = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(f) Then
                Label10.Text = "0"
            Else
                Label10.Text = f
            End If
        Catch ex As Exception
            ' Handle any exceptions or display an error message
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub notran()
        Try
            Dim f As String
            OpenCon()
            ' Retrieve the total price for the current day
            cmd.CommandText = "SELECT COUNT(id) FROM transactiontbl"
            Label5.Text = cmd.ExecuteScalar().ToString()
            f = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(f) Then
                Label5.Text = "0"
            Else
                Label5.Text = f
            End If
        Catch ex As Exception
            ' Handle any exceptions or display an error message
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub GetNumberOfUsers()
        Try
            Dim f As String
            OpenCon()
            ' Retrieve the total price for the current day
            cmd.CommandText = "SELECT COUNT(username) FROM usertbl"
            Label7.Text = cmd.ExecuteScalar().ToString()
            f = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(f) Then
                Label7.Text = "0"
            Else
                Label7.Text = f
            End If
        Catch ex As Exception
            ' Handle any exceptions or display an error message
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Sale()
        Dim f As String
        OpenCon()

        ' Retrieve the total price for the current day
        cmd.CommandText = "SELECT SUM(netsales) FROM transactiontbl WHERE DAY(date) = DAY(CURRENT_DATE)"
        f = cmd.ExecuteScalar().ToString()

        If String.IsNullOrEmpty(f) Then
            lblsale.Text = "0"
        Else
            lblsale.Text = f
        End If

        con.Close()
    End Sub
    Private Sub Table()
        If Chart2.Series.IndexOf("Series1") <> -1 Then
            Chart2.Series.RemoveAt(Chart2.Series.IndexOf("Series1"))
        End If


        Chart2.Series.Add("Product Cost")

        OpenCon()
        cmd.CommandText = "SELECT DATE_FORMAT(date, '%b') AS month, SUM(productcost) AS totalcost FROM transactiontbl GROUP BY MONTH(date), DATE_FORMAT(date, '%b')"
        dr = cmd.ExecuteReader()

        While dr.Read()
            Chart2.Series("Product Cost").Points.AddXY(dr.GetString("month"), dr.GetDecimal("totalcost"))
        End While

        dr.Close()
        con.Close()


    End Sub
    Private Sub Table1()
        If Chart2.Series.IndexOf("Series1") <> -1 Then
            Chart2.Series.RemoveAt(Chart2.Series.IndexOf("Series1"))
        End If

        Chart2.Series.Add("Monthly Sales")

        OpenCon()
        'cmd.CommandText = "SELECT DATE_FORMAT(date, '%b') AS month, productcost FROM transactiontbl"
        cmd.CommandText = "SELECT DATE_FORMAT(date, '%b') AS month, SUM(netsales) AS total_netsales FROM transactiontbl GROUP BY MONTH(date), DATE_FORMAT(date, '%b')"

        dr = cmd.ExecuteReader()

        While dr.Read()
            Chart2.Series("Monthly Sales").Points.AddXY(dr.GetString("month"), dr("total_netsales"))
        End While

        dr.Close()
        con.Close()
    End Sub

    Private Sub dashboardfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetNumberOfUsers()
        Sale()
        notran()
        profit()
        netsale()
        Timer1.Start()
        Table()
        Table1()
        Dim sta As String = CStr("No")
        OpenCon()
        cmd.CommandText = "Select suppliersid, suppliername, productcode, productname, category, brand, stocks FROM productlisttbl WHERE criticalstatus = '" & sta & "'"
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
        DataGridView1.Columns.Add("stocks", "Stocks")

        ' Populate data into the DataGridView
        While dr.Read()
            DataGridView1.Rows.Add(dr("suppliersid"), dr("suppliername"), dr("productcode"), dr("productname"), dr("category"), dr("brand"), dr("stocks"))
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

    Private Sub Chart2_Click(sender As Object, e As EventArgs) Handles Chart2.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub




    'Private Sub LoadExpiringProducts()
    '    Dim currentDate As Date = Date.Now.Date
    '    Dim query As String = "SELECT productname, productcode, stocks FROM productlisttbl WHERE expirationdate >= @CurrentDate AND expirationdate <= DATE_ADD(@CurrentDate, INTERVAL 30 DAY)"

    '    Using conn As New MySqlConnection("server=localhost;user id=root;password=password;persistsecurityinfo=True;database=mydatabase")
    '        Using cmd As New MySqlCommand(query, conn)
    '            cmd.Parameters.AddWithValue("@CurrentDate", currentDate)

    '            conn.Open()
    '            Dim adapter As New MySqlDataAdapter(cmd)
    '            Dim dataTable As New DataTable()
    '            adapter.Fill(dataTable)

    '            DataGridView3.DataSource = dataTable
    '        End Using
    '    End Using
    'End Sub

    ''Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    ''    For i As Integer = 0 To DataGridView1.Rows.Count - 1
    ''        Dim f As Integer = CInt(CDbl(DataGridView2.Rows(i).Cells(3).Value.ToString) - 0.1)
    ''        OpenCon()
    ''        cmd.CommandText = "UPDATE productlisttbl SET price = @column4 WHERE productcode = @column2"
    ''        With cmd.Parameters
    ''            .Clear()
    ''            .AddWithValue("@column2", DataGridView2.Rows(i).Cells(1).Value.ToString())
    ''            .AddWithValue("@column4", f - CInt(DataGridView2.Rows(i).Cells(3).Value.ToString()))
    ''        End With
    ''        cmd.ExecuteNonQuery()
    ''        con.Close()

    ''        MessageBox.Show("Successful")
    ''        DataGridView2.Rows.Clear()

    ''    Next

    ''End Sub
End Class

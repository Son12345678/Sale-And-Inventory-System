<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class inventorymngfrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtbatchno = New System.Windows.Forms.TextBox()
        Me.txtrn = New System.Windows.Forms.TextBox()
        Me.cmbsn = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtstocks = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.order = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ipanel = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DateTimePickerexp = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePickermnf = New System.Windows.Forms.DateTimePicker()
        Me.txtpcode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtname = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcost = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label1.Location = New System.Drawing.Point(40, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 22)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Product Code:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Transparent
        Me.DateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.Transparent
        Me.DateTimePicker1.CalendarTrailingForeColor = System.Drawing.Color.Black
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(827, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(125, 29)
        Me.DateTimePicker1.TabIndex = 30
        Me.DateTimePicker1.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(3, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(155, 22)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Inventory Details:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtbatchno)
        Me.Panel2.Controls.Add(Me.txtrn)
        Me.Panel2.Controls.Add(Me.cmbsn)
        Me.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtid)
        Me.Panel2.Location = New System.Drawing.Point(12, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(970, 72)
        Me.Panel2.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label11.Location = New System.Drawing.Point(734, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 22)
        Me.Label11.TabIndex = 70
        Me.Label11.Text = "Batch No."
        '
        'txtbatchno
        '
        Me.txtbatchno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbatchno.Enabled = False
        Me.txtbatchno.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.txtbatchno.Location = New System.Drawing.Point(827, 31)
        Me.txtbatchno.Name = "txtbatchno"
        Me.txtbatchno.Size = New System.Drawing.Size(125, 29)
        Me.txtbatchno.TabIndex = 69
        '
        'txtrn
        '
        Me.txtrn.Enabled = False
        Me.txtrn.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.txtrn.Location = New System.Drawing.Point(509, 29)
        Me.txtrn.Name = "txtrn"
        Me.txtrn.Size = New System.Drawing.Size(165, 29)
        Me.txtrn.TabIndex = 68
        '
        'cmbsn
        '
        Me.cmbsn.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.cmbsn.FormattingEnabled = True
        Me.cmbsn.Location = New System.Drawing.Point(183, 30)
        Me.cmbsn.Name = "cmbsn"
        Me.cmbsn.Size = New System.Drawing.Size(182, 30)
        Me.cmbsn.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label15.Location = New System.Drawing.Point(37, 32)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(140, 22)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Supplier Name:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label16.Location = New System.Drawing.Point(412, 34)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(91, 22)
        Me.Label16.TabIndex = 29
        Me.Label16.Text = "Receiver:"
        '
        'txtid
        '
        Me.txtid.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.Location = New System.Drawing.Point(183, 28)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(85, 32)
        Me.txtid.TabIndex = 66
        Me.txtid.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1060, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(135, 33)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "00:00:00"
        '
        'txtstocks
        '
        Me.txtstocks.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.txtstocks.Location = New System.Drawing.Point(182, 85)
        Me.txtstocks.Name = "txtstocks"
        Me.txtstocks.Size = New System.Drawing.Size(83, 29)
        Me.txtstocks.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label3.Location = New System.Drawing.Point(87, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 22)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Quantity:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column12, Me.id, Me.Column2, Me.Column10, Me.Column1, Me.Column3, Me.Column4, Me.Column11, Me.Column5, Me.order, Me.Column7, Me.Column8, Me.Column9})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 297)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(970, 354)
        Me.DataGridView1.TabIndex = 36
        Me.DataGridView1.Visible = False
        '
        'Column6
        '
        Me.Column6.HeaderText = "ID"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column12
        '
        Me.Column12.HeaderText = "Batch No."
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'id
        '
        Me.id.HeaderText = "Product Code"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Product Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Brand"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Category"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column3
        '
        Me.Column3.HeaderText = "Default Measure"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Expiration Date"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Manufactured Date"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "Stocks"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'order
        '
        Me.order.HeaderText = "QuantityPerUnit"
        Me.order.Name = "order"
        Me.order.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Product Cost"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "Total Price"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Delete"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Ipanel
        '
        Me.Ipanel.Location = New System.Drawing.Point(1107, 64)
        Me.Ipanel.Name = "Ipanel"
        Me.Ipanel.Size = New System.Drawing.Size(151, 73)
        Me.Ipanel.TabIndex = 54
        Me.Ipanel.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Button2.Location = New System.Drawing.Point(271, 85)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(93, 30)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = " Add"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'txttotal
        '
        Me.txttotal.Enabled = False
        Me.txttotal.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.txttotal.Location = New System.Drawing.Point(821, 13)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(131, 29)
        Me.txttotal.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label4.Location = New System.Drawing.Point(760, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 22)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Total:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Enabled = False
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Button3.Location = New System.Drawing.Point(565, 85)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(163, 32)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "Proceed"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'DateTimePickerexp
        '
        Me.DateTimePickerexp.CustomFormat = ""
        Me.DateTimePickerexp.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.DateTimePickerexp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerexp.Location = New System.Drawing.Point(565, 12)
        Me.DateTimePickerexp.Name = "DateTimePickerexp"
        Me.DateTimePickerexp.Size = New System.Drawing.Size(163, 29)
        Me.DateTimePickerexp.TabIndex = 61
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label7.Location = New System.Drawing.Point(419, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(138, 22)
        Me.Label7.TabIndex = 62
        Me.Label7.Text = "Expiration Date"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label9.Location = New System.Drawing.Point(390, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 22)
        Me.Label9.TabIndex = 63
        Me.Label9.Text = "Manufactured Date"
        '
        'DateTimePickermnf
        '
        Me.DateTimePickermnf.CustomFormat = ""
        Me.DateTimePickermnf.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.DateTimePickermnf.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickermnf.Location = New System.Drawing.Point(565, 48)
        Me.DateTimePickermnf.Name = "DateTimePickermnf"
        Me.DateTimePickermnf.Size = New System.Drawing.Size(163, 29)
        Me.DateTimePickermnf.TabIndex = 64
        '
        'txtpcode
        '
        Me.txtpcode.Enabled = False
        Me.txtpcode.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.txtpcode.Location = New System.Drawing.Point(182, 10)
        Me.txtpcode.Name = "txtpcode"
        Me.txtpcode.Size = New System.Drawing.Size(140, 29)
        Me.txtpcode.TabIndex = 67
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label10.Location = New System.Drawing.Point(40, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 22)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Product Name:"
        Me.Label10.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.Panel1.Controls.Add(Me.txtname)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.txtpcode)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txttotal)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DateTimePickermnf)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.txtstocks)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.DateTimePickerexp)
        Me.Panel1.Controls.Add(Me.txtcost)
        Me.Panel1.Location = New System.Drawing.Point(12, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(970, 125)
        Me.Panel1.TabIndex = 69
        '
        'txtname
        '
        Me.txtname.Enabled = False
        Me.txtname.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.txtname.FormattingEnabled = True
        Me.txtname.Location = New System.Drawing.Point(182, 11)
        Me.txtname.Name = "txtname"
        Me.txtname.Size = New System.Drawing.Size(140, 30)
        Me.txtname.TabIndex = 71
        Me.txtname.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(322, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(53, 34)
        Me.Button4.TabIndex = 71
        Me.Button4.Text = "Scan"
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Button1.Location = New System.Drawing.Point(321, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 34)
        Me.Button1.TabIndex = 45
        Me.Button1.Text = "type"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.Label12.Location = New System.Drawing.Point(40, 46)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 22)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "Supplier Price:"
        '
        'txtcost
        '
        Me.txtcost.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.txtcost.Location = New System.Drawing.Point(182, 46)
        Me.txtcost.Name = "txtcost"
        Me.txtcost.Size = New System.Drawing.Size(189, 29)
        Me.txtcost.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Elephant", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(251, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(581, 62)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Inventory Management"
        '
        'inventorymngfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(995, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Ipanel)
        Me.Controls.Add(Me.DataGridView1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "inventorymngfrm"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents txtstocks As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Ipanel As Panel
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents cmbsn As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents txttotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents DateTimePickerexp As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DateTimePickermnf As DateTimePicker
    Friend WithEvents txtid As TextBox
    Friend WithEvents txtpcode As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtbatchno As TextBox
    Friend WithEvents txtrn As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtcost As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents txtname As ComboBox
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents order As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Label5 As Label
End Class

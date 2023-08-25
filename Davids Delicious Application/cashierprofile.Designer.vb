<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cashierprofile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbut = New System.Windows.Forms.ComboBox()
        Me.txtun = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbst = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtpw = New System.Windows.Forms.TextBox()
        Me.btnedit = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtid
        '
        Me.txtid.Enabled = False
        Me.txtid.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtid.Location = New System.Drawing.Point(240, 121)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(191, 29)
        Me.txtid.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(140, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 22)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "User ID"
        '
        'cmbut
        '
        Me.cmbut.Enabled = False
        Me.cmbut.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbut.FormattingEnabled = True
        Me.cmbut.Items.AddRange(New Object() {"staff", "administrator"})
        Me.cmbut.Location = New System.Drawing.Point(731, 124)
        Me.cmbut.Name = "cmbut"
        Me.cmbut.Size = New System.Drawing.Size(183, 30)
        Me.cmbut.TabIndex = 30
        '
        'txtun
        '
        Me.txtun.Enabled = False
        Me.txtun.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtun.Location = New System.Drawing.Point(240, 174)
        Me.txtun.Name = "txtun"
        Me.txtun.Size = New System.Drawing.Size(191, 29)
        Me.txtun.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(118, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 22)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Username"
        '
        'cmbst
        '
        Me.cmbst.Enabled = False
        Me.cmbst.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbst.FormattingEnabled = True
        Me.cmbst.Items.AddRange(New Object() {"active", "inactive"})
        Me.cmbst.Location = New System.Drawing.Point(241, 228)
        Me.cmbst.Name = "cmbst"
        Me.cmbst.Size = New System.Drawing.Size(190, 30)
        Me.cmbst.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(107, 231)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 22)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "User Status"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(544, 234)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 22)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Confirm Password"
        '
        'txtcp
        '
        Me.txtcp.Enabled = False
        Me.txtcp.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcp.Location = New System.Drawing.Point(731, 231)
        Me.txtcp.Name = "txtcp"
        Me.txtcp.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcp.Size = New System.Drawing.Size(183, 29)
        Me.txtcp.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(613, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 22)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "User Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(616, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 22)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Password"
        '
        'txtpw
        '
        Me.txtpw.Enabled = False
        Me.txtpw.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpw.Location = New System.Drawing.Point(731, 177)
        Me.txtpw.Name = "txtpw"
        Me.txtpw.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpw.Size = New System.Drawing.Size(183, 29)
        Me.txtpw.TabIndex = 25
        '
        'btnedit
        '
        Me.btnedit.BackColor = System.Drawing.Color.White
        Me.btnedit.Enabled = False
        Me.btnedit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.btnedit.FlatAppearance.BorderSize = 2
        Me.btnedit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.btnedit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnedit.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnedit.Location = New System.Drawing.Point(281, 334)
        Me.btnedit.Name = "btnedit"
        Me.btnedit.Size = New System.Drawing.Size(207, 35)
        Me.btnedit.TabIndex = 31
        Me.btnedit.Text = "Update Profile"
        Me.btnedit.UseVisualStyleBackColor = False
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.White
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(201, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.btnsave.FlatAppearance.BorderSize = 2
        Me.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsave.Location = New System.Drawing.Point(548, 334)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(223, 35)
        Me.btnsave.TabIndex = 32
        Me.btnsave.Text = "Edit"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'cashierprofile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 661)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnedit)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbut)
        Me.Controls.Add(Me.txtun)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbst)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtcp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtpw)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "cashierprofile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtid As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbut As ComboBox
    Friend WithEvents txtun As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbst As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtcp As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtpw As TextBox
    Friend WithEvents btnedit As Button
    Friend WithEvents btnsave As Button
End Class

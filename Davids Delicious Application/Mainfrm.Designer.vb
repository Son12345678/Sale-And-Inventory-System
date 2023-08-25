<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mainfrm
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
        Me.SuspendLayout()
        '
        'Mainfrm
        '
        Me.ClientSize = New System.Drawing.Size(608, 261)
        Me.Name = "Mainfrm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents mainpanel As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btndashboard As CircleButton
    Friend WithEvents btnsale As CircleButton
    Friend WithEvents btninventory As CircleButton
    Friend WithEvents btnusermanager As CircleButton
    Friend WithEvents btnproduct As CircleButton
End Class

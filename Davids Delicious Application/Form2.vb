Public Class Form2
    Private _form1 As trnasactionfrm

    Public Sub New(form1 As trnasactionfrm)
        InitializeComponent()
        _form1 = form1
    End Sub

    ' Rest of your code...
    Public Property SelectedPayment As String

    Private ReadOnly totalAmount As Decimal

    Private Sub paymentMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles paymentMode.SelectedIndexChanged
        Dim selectedPaymentMode As String = paymentMode.SelectedItem.ToString()

        ' Perform necessary transaction processing steps based on the payment mode
        Select Case selectedPaymentMode
            Case "Cash"
                ' Process cash payment


                Dim amountPaid As Decimal
                If Decimal.TryParse(txtAmountPaid.Text, amountPaid) Then
                    Dim totalAmount As Decimal = Convert.ToDecimal(txtTotalAmount.Text)

                    If amountPaid >= totalAmount Then
                        ' Sufficient cash received
                        Dim change As Decimal = amountPaid - totalAmount

                        ' Perform necessary actions (e.g., update transaction table, print receipt, etc.)

                        MessageBox.Show("Payment successful. Change: " & change.ToString("C"))
                        Me.Close()
                    Else
                        ' Insufficient cash received
                        MessageBox.Show("Insufficient cash received.")

                    End If
                Else
                    ' Invalid amount entered
                    MessageBox.Show("Invalid amount entered.")
                End If

            Case "Credit Card"
                ' Process credit card payment


                Dim cardNumber As String = txtCardNumber.Text
                Dim cardExpiry As String = txtCardExpiry.Text
                Dim cardCVV As String = txtCardCVV.Text

                ' Perform necessary validation and payment processing steps

                ' Perform necessary actions (e.g., update transaction table, print receipt, etc.)

                MessageBox.Show("Credit card payment successful.")
                Me.Close()

            Case "Mobile Payment"
                Dim mobileNumber As String = txtMobileNumber.Text
                ' Process mobile payment
                If TextBox1.Text = "" Or txtMobileNumber.Text = "" Then
                    MessageBox.Show("Mobile payment Failed.")
                Else
                    MessageBox.Show("Mobile payment successful.")
                    Me.Close()
                End If



                ' Perform necessary validation and payment processing steps

                ' Perform necessary actions (e.g., update transaction table, send confirmation, etc.)



            Case Else
                ' Invalid payment mode
                MessageBox.Show("Invalid payment mode.")
        End Select
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Panel1.Visible = True
        Panel2.Visible = False
        Panel3.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Panel1.Visible = False
        Panel2.Visible = True
        Panel3.Visible = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Panel1.Visible = False
        Panel2.Visible = False
        Panel3.Visible = True
    End Sub

    Public Property TextBoxValue As String

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTotalAmount.Text = TextBoxValue ' Set the value to the textbox in the dialog form
    End Sub
End Class
'Imports System.IO.Ports

'Public Class BarcodeScannerForm

'    Private WithEvents serialPort As SerialPort

'    Public Sub New()
'        InitializeComponent()

'        ' Configure the serial port settings
'        serialPort = New SerialPort("COM1", 9600, Parity.None, 8, StopBits.One)
'        serialPort.Handshake = Handshake.None
'    End Sub

'    Private Sub BarcodeScannerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ' Open the serial port
'        Try
'            serialPort.Open()
'        Catch ex As Exception
'            MessageBox.Show("Failed to open serial port: " & ex.Message)
'        End Try
'    End Sub

'    Private Sub BarcodeScannerForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
'        ' Close the serial port when the form is closing
'        If serialPort.IsOpen Then
'            serialPort.Close()
'        End If
'    End Sub

'    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
'        ' Event handler for data received from the serial port (barcode scanner)

'        ' Read the data from the serial port
'        Dim data As String = serialPort.ReadExisting()

'        ' Handle the scanned barcode data (e.g., display, process, etc.)
'        ProcessBarcodeData(data)
'    End Sub

'    Private Sub ProcessBarcodeData(barcodeData As String)
'        ' Custom logic to process the scanned barcode data
'        ' This is just a sample implementation, you can modify it based on your requirements

'        ' Update the UI with the scanned barcode data
'        Invoke(Sub()
'                   textBoxBarcode.Text = barcodeData
'               End Sub)
'    End Sub

'End Class

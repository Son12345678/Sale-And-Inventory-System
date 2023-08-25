Imports MySql.Data.MySqlClient

Module DatabaseCon
    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader
    Sub OpenCon()
        con.ConnectionString = My.Settings.Setting
        con.Open()
        cmd.Connection = con
    End Sub

End Module

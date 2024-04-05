Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text

Public Class ConfigIni
    Private ini As Ini_ = New Ini_()

    Public Function ReadConfig(config As String, endConfig As String, path As String) As String
        Dim objStreamReader As StreamReader
        Dim strLine As String
        Dim match, matchEnd As Boolean
        ReadConfig = vbNullString
        objStreamReader = New StreamReader(path)

        strLine = objStreamReader.ReadLine
        While (Not strLine Is Nothing) And (Not match)
            If strLine = config Then
                strLine = objStreamReader.ReadLine
                While (Not strLine Is Nothing) And (Not strLine = endConfig)
                    ReadConfig = ReadConfig + IIf(match = True, vbCrLf + strLine, strLine)
                    match = True
                    strLine = objStreamReader.ReadLine
                    If strLine = endConfig Then
                        matchEnd = True
                    End If
                End While
                If matchEnd = False Then
                    ReadConfig = vbNullString
                End If
            Else
                strLine = objStreamReader.ReadLine
            End If
        End While
        objStreamReader.Close()
    End Function
    Public Sub ReadIni()
        Try
            ini.Load("Informes.ini")
            'app
            Datos.TrAcE = ini.GetKeyValue("app", "TrAcE")
            Datos.FolderTrace = ini.GetKeyValue("app", "FolderTrace")
            Datos.NombreInstalacion = ini.GetKeyValue("app", "NombreInstalacion")
            Datos.PrefijoAnalogica = ini.GetKeyValue("app", "PrefijoAnalogica")
            Datos.PrefijoTotalizador = ini.GetKeyValue("app", "PrefijoTotalizador")
            Datos.SiemensRockwell = ini.GetKeyValue("app", "SiemensRockwell")
            'sql
            Datos.SQLConnectionStringServer = ini.GetKeyValue("sql", "SQLConnectionStringServer")
            Datos.SQLConnectionStringDataBase = ini.GetKeyValue("sql", "SQLConnectionStringDataBase")
            Datos.SQLConnectionStringUser = ini.GetKeyValue("sql", "SQLConnectionStringUser")
            Datos.SQLConnectionStringPassword = ini.GetKeyValue("sql", "SQLConnectionStringPassword")

            Datos.SQLConnectionStringData = "Data Source=" & Datos.SQLConnectionStringServer & ";Initial Catalog=" & Datos.SQLConnectionStringDataBase & ";Integrated Security=False;TrustServerCertificate=True;User ID=" & Datos.SQLConnectionStringUser & ";Password=" & Datos.SQLConnectionStringPassword
            Datos.SQLConnectionAdminMaster = "Data Source=" & Datos.SQLConnectionStringServer & ";Integrated Security=True;TrustServerCertificate=True"

        Catch
        End Try
    End Sub

    Public Sub WriteIni()
        Try
            'app
            ini.AddSection("app").AddKey("TrAcE").Value = Datos.TrAcE
            ini.AddSection("app").AddKey("FolderTrace").Value = Datos.FolderTrace
            ini.AddSection("app").AddKey("NombreInstalacion").Value = Datos.NombreInstalacion
            ini.AddSection("app").AddKey("PrefijoAnalogica").Value = Datos.PrefijoAnalogica
            ini.AddSection("app").AddKey("PrefijoTotalizador").Value = Datos.PrefijoTotalizador
            ini.AddSection("app").AddKey("SiemensRockwell").Value = Datos.SiemensRockwell
            'sql
            ini.AddSection("sql").AddKey("SQLConnectionStringServer").Value = Datos.SQLConnectionStringServer
            ini.AddSection("sql").AddKey("SQLConnectionStringDataBase").Value = Datos.SQLConnectionStringDataBase
            ini.AddSection("sql").AddKey("SQLConnectionStringUser").Value = Datos.SQLConnectionStringUser
            ini.AddSection("sql").AddKey("SQLConnectionStringPassword").Value = Datos.SQLConnectionStringPassword

            ini.Save("Informes.ini")
            '''MessageBox.Show("Los datos se guardaron correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error = Los datos no se guardaron correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub ReadConfigs()
        Try
            Dim configPath As String
            configPath = My.Application.Info.DirectoryPath & "\Config\ConfigRpt.ini"

            If Not My.Computer.FileSystem.FileExists(configPath) Then
                MessageBox.Show("No se encuentra el archivo de configuración [" & configPath & "].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Application.ExitThread()
            End If

            Datos.configPath = configPath
            Datos.DebugLog = ReadConfig("[DebugLog]", "[ENDCONFIG]", configPath)
            Datos.SQLConnectionStringData = ReadConfig("[SQLConnectionStringData]", "[ENDCONFIG]", configPath)
            Datos.SQLCommandStringData_dsAnalog = ReadConfig("[SQLCommandStringData_dsAnalog]", "[ENDCONFIG]", configPath)
            Datos.SQLCommandStringData_dsDigital = ReadConfig("[SQLCommandStringData_dsDigital]", "[ENDCONFIG]", configPath)

        Catch
        End Try
    End Sub

End Class

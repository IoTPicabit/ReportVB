Imports System
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Public Class dbCon
    Private connection As String = String.Empty
    Private connect As SqlConnection
    Private command As SqlCommand
    Private da As SqlDataAdapter
    Private dt As DataTable
    Private ds As DataSet

    Public Sub New(ByVal cadena As String)
        connect = New SqlConnection()

        Try
            connection = cadena
        Catch ex As Exception
            'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Error: la cadena de conexión no es correcta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Function connecttodb() As SqlConnection
        If connect.State <> ConnectionState.Open Then

            Try
                connect.ConnectionString = connection
                connect.Open()
            Catch ex As Exception
                'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Return connect
    End Function

    Private Sub closeconnection()
        If connect.State <> ConnectionState.Closed Then connect.Close()
    End Sub

    Public Function executecommand(ByVal query As String) As Boolean
        Dim exito As Boolean

        Try
            connecttodb()
            command = New SqlCommand(query, connect)
            command.ExecuteNonQuery()
            exito = True
        Catch ex As Exception
            'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            exito = False
        Finally
            closeconnection()
        End Try

        Return exito
    End Function

    Public Function executeMultiCommand(ByVal query As String) As Boolean
        Dim exito As Boolean = False

        Try
            Dim commands As String() = query.Split(New String() {Environment.NewLine & "GO" & Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

            connecttodb()

            For Each cmd As String In commands
                command = New SqlCommand(cmd, connect)
                command.ExecuteNonQuery()
            Next

            exito = True
        Catch ex As Exception
            'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            exito = False
        Finally
            closeconnection()
        End Try

        Return exito
    End Function


    Public Function ExecuteScalar(ByVal query As String) As Object
        Dim result As Object = Nothing

        Try
            connecttodb()
            command = New SqlCommand(query, connect)
            result = command.ExecuteScalar()
        Catch ex As Exception
            'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeconnection()
        End Try

        Return result
    End Function

    Public Function selectstring(ByVal query As String) As String
        Dim cadena As String = String.Empty

        Try
            connecttodb()
            command = New SqlCommand(query, connect)
            Dim firstColumn = command.ExecuteScalar()

            If firstColumn IsNot Nothing Then
                cadena = firstColumn.ToString()
            End If

        Catch ex As Exception
            ' MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cadena = String.Empty
        Finally
            closeconnection()
        End Try

        Return cadena
    End Function

    Public Function SelectDataTable(ByVal query As String, <Out> ByRef dataTable As DataTable) As Boolean
        Dim result As Boolean = False
        dt = New DataTable()

        Try
            connecttodb()
            da = New SqlDataAdapter(query, connect)
            da.Fill(dt)

            If dt IsNot Nothing Then
                result = True
            End If

        Catch ex As Exception
            ' MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            closeconnection()
        End Try

        dataTable = dt
        Return result
    End Function

End Class

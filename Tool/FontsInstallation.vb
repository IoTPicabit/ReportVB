Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Module FontsInstallation


    ' Importar funciones necesarias desde las bibliotecas de Windows
    <DllImport("gdi32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Function AddFontResourceEx(ByVal lpszFilename As String, ByVal fl As UInteger, ByVal pdv As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Private Const WM_FONTCHANGE As Integer = &H1D

    Private Function IsFontInstalled(ByVal FontName As String) As Boolean
        Using TestFont As Font = New Font(FontName, 10)
            Return CBool(String.Compare(FontName, TestFont.Name, StringComparison.InvariantCultureIgnoreCase) = 0)
        End Using
    End Function
    Public Sub InstallFonts()
        On Error Resume Next
        Dim reload As Boolean

        If Not IsFontInstalled("Segoe Fluent Icons") Then
            ' Obtiene la ruta completa de la primera fuente a partir de la ruta relativa
            Dim path1 As String = Path.Combine(Application.StartupPath, "SEGOEICONS.TTF")
            FileSystem.FileCopy(path1, Path.Combine(Path.GetTempPath, "SEGOEICONS.TTF"))

            ' Instala la primera fuente
            InstallFont(Path.Combine(Path.GetTempPath, "SEGOEICONS.TTF"))
            reload = True
        End If

        If Not IsFontInstalled("Segoe UI Variable Small") Then
            ' Obtiene la ruta completa de la segunda fuente a partir de la ruta relativa
            Dim path2 As String = Path.Combine(Application.StartupPath, "SegoeUI-VF.ttf")
            FileSystem.FileCopy(path2, Path.Combine(Path.GetTempPath, "SegoeUI-VF.ttf"))
            ' Instala la segunda fuente
            InstallFont(Path.Combine(Path.GetTempPath, "SegoeUI-VF.ttf"))
            reload = True
        End If

        If reload Then
            If MsgBox("Las fuentes se han instalado. Debe reiniciar la aplicación para que se visualice correctamente. ¿Desea hacerlo ahora?", vbOKCancel, "Advertencia") = MsgBoxResult.Ok Then
                Application.Restart()
            End If
        End If

    End Sub


    Private Sub InstallFont(ByVal rutaFuente As String)
        ' Llama a la función nativa para agregar la fuente al sistema
        Dim result As Integer = AddFontResourceEx(rutaFuente, 0, IntPtr.Zero)

        ' Si la instalación es exitosa, notifica a Windows que las fuentes han cambiado
        If result <> 0 Then
            SendMessage(IntPtr.Zero, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero)
        Else
            ' Maneja cualquier error que pueda ocurrir durante la instalación de la fuente
            MessageBox.Show("Error al instalar la fuente: " & rutaFuente, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Module

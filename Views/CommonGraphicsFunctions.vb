Imports System.Globalization
Imports System.Text
Imports DocumentFormat.OpenXml.Wordprocessing

Module CommonGraphicsFunctions
    Public Sub ResizeLastColumn(dgv As DataGridView, Optional colName As String = "")
        'Esta función se utiliza para asegurar que la última columna del grid siempre ocupará todo el espacio
        Try
            Dim w As Integer = 0
            Dim di As Integer = 0
            Dim c As Integer = 0
            For Each col As DataGridViewColumn In dgv.Columns
                If col.Visible Then
                    w += col.Width
                    If col.DisplayIndex > di Then
                        di = col.DisplayIndex
                        c = col.Index
                    End If
                End If
            Next
            If colName.Length > 0 Then
                If Not IsNothing(dgv.Columns(colName)) Then
                    dgv.Columns(colName).Width = dgv.Width - (w - dgv.Columns(colName).Width)
                End If
            Else
                If dgv.ColumnCount > 0 Then
                    dgv.Columns(c).Width = dgv.Width - (w - dgv.Columns(c).Width)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
#Region "Filtrado de datagridview"
    Public Sub FilterDGV(dgv As DataGridView, filter As String)
        'Esta función se utiliza para filtrar un datagridview
        Try
            Dim str As String
            Dim backColor As System.Drawing.Color = dgv.RowsDefaultCellStyle.BackColor
            Dim altColor As System.Drawing.Color = dgv.AlternatingRowsDefaultCellStyle.BackColor
            Dim lastColor As System.Drawing.Color = dgv.RowsDefaultCellStyle.BackColor
            For Each r As DataGridViewRow In dgv.Rows
                str = ""
                For Each c As DataGridViewCell In r.Cells
                    If c.ValueType = GetType(String) Then
                        str = str & c.Value
                    End If
                Next
                Try
                    dgv.CurrentCell = Nothing
                    Dim normalizedString1 As String = RemoveDiacritics(str)
                    Dim normalizedString2 As String = RemoveDiacritics(filter)
                    r.Visible = normalizedString1.Contains(normalizedString2, StringComparison.CurrentCultureIgnoreCase)
                    If r.Visible Then
                        r.DefaultCellStyle.BackColor = lastColor
                        lastColor = IIf(lastColor = backColor, altColor, backColor)
                    End If
                Catch ex As Exception
                End Try
            Next
            dgv.Refresh()
        Catch ex As Exception
        End Try
    End Sub

    Private Function RemoveDiacritics(s As String) As String
        'Esta función se utiliza para eliminar tildes, diéresis, etc., con el objetivo de poder comparar cadenas con mayor facilidad
        Dim normalizedString As String = s.Normalize(NormalizationForm.FormD)
        Dim stringBuilder As New System.Text.StringBuilder()

        For Each c As Char In normalizedString
            If CharUnicodeInfo.GetUnicodeCategory(c) <> UnicodeCategory.NonSpacingMark Then
                stringBuilder.Append(c)
            End If
        Next

        Return stringBuilder.ToString()
    End Function
#End Region

#Region "Habilitación o deshabilitación de controles"

    ' Función para habilitar o deshabilitar todos los controles según el parámetro
    Public Sub manageControlEnable(frm As Form, enableControls As Boolean, listStates As List(Of KeyValuePair(Of String, Boolean)))
        If Not enableControls Then
            ' Limpiar la lista antes de cada uso
            listStates.Clear()
        End If
        ' Iterar a través de todos los controles en el formulario
        For Each control As Windows.Forms.Control In frm.Controls
            ' Almacenar el estado original y habilitar o deshabilitar el control según el parámetro
            If Not enableControls Then

                listStates.Add(New KeyValuePair(Of String, Boolean)(control.Name, control.Enabled))
                control.Enabled = enableControls
            Else
                Dim element = listStates.FirstOrDefault(Function(item) item.Key = control.Name)
                If Not IsNothing(element) Then
                    control.Enabled = element.Value
                End If
            End If
        Next

        Dim frmParent As FormMain = GetParentForm(frm)
        If frmParent IsNot frm Then manageControlEnable(frmParent, enableControls, frmParent.listOriginalEnabledStates)

    End Sub

    Private Function GetParentForm(ByVal parent As System.Windows.Forms.Control) As System.Windows.Forms.Control
        Dim parent_control As System.Windows.Forms.Control = TryCast(parent, System.Windows.Forms.Control)
        If parent_control.Parent Is Nothing Then
            Return parent_control
        End If
        If parent IsNot Nothing Then
            Return GetParentForm(parent.Parent)
        End If
        Return Nothing
    End Function
#End Region

End Module

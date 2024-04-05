Imports System.IO
Imports System.Data
Imports System.Text
Imports DevExpress.XtraGantt.Chart.Item
Imports System.Data.SqlTypes
Imports System.Runtime.InteropServices
Imports DevExpress.Utils.Internal
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.Diagram.Core
Imports DevExpress.Utils
Imports DevExpress.XtraPrinting

Imports System
Imports System.Windows.Forms

Imports System.Data.SqlClient
Imports DocumentFormat.OpenXml.Wordprocessing
Imports DocumentFormat.OpenXml.Presentation
Imports DevExpress.CodeParser

Public Class FormCustomerConfig

    Dim config As ConfigIni = New ConfigIni()
    Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
    Dim tt As New ToolTip()
    Dim SelectedTableNow As String
    Dim _OkConnect As Boolean = False
    Dim Init As Boolean = False
    Dim _OkTablesSaved As Boolean = False
    Dim _tempOkTables = False

    Public Property OkTablesSaved As Boolean
        Get
            Return _OkTablesSaved
        End Get
        Set(value As Boolean)
            _OkTablesSaved = value
            ComBoxTables.Enabled = _OkTablesSaved
            ComBoxTables.SelectedIndex = -1
            btnSaveDgvToSQL.Enabled = _OkTablesSaved
        End Set
    End Property

    ' Lista para almacenar el estado original de los controles
    Public listOriginalEnabledStates As New List(Of KeyValuePair(Of String, Boolean))

    Dim TableResult As String = ""
    Dim DataTableResult As New DataTable()
    Dim OutputTypeResult As Integer = 99
    Dim OkResult As Boolean = False
    Dim SQLTableState As Integer = 99
    Private Sub FormCustomerConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtInstallationName.Text = Datos.NombreInstalacion
        txtSQLServer.Text = Datos.SQLConnectionStringServer
        txtSQLDataBase.Text = Datos.SQLConnectionStringDataBase
        txtSQLUser.Text = Datos.SQLConnectionStringUser
        txtSQLPassword.Text = Datos.SQLConnectionStringPassword

        tt.SetToolTip(btnDeleteInstallationName, "Borrar nombre de la instalación")
        tt.SetToolTip(btnSaveInstallationName, "Grabar nombre de la instalación")
        tt.SetToolTip(btnDefaultSqlChain, "Escribir cadena de conexión por defecto")
        tt.SetToolTip(btnSqlCheck, "Verificar cadena de conexión y estructura de la base de datos")
        tt.SetToolTip(btnDeleteSQLConnectionStringData, "Borrar cadena de conexión")
        tt.SetToolTip(btnSaveSQLConnectionStringData, "Grabar cadena de conexión ")
        tt.SetToolTip(BtnImportTagSiemens, "Importar Tags de Siemens ")

        ComBoxTables.DropDownStyle = ComboBoxStyle.DropDownList
        ToComboBoxATables()

        dgv.SelectionMode = DataGridViewSelectionMode.CellSelect
        dgv.MultiSelect = True 'False
        dgv.AllowUserToAddRows = False
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgv.AllowUserToResizeRows = False
        dgv.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)
        dgv.BackgroundColor = System.Drawing.Color.White
        dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 156, 166)
        dgv.ColumnHeadersHeight = 24
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 156, 166)
        dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 156, 166)
        dgv.ScrollBars = ScrollBars.Vertical
        dgv.ContextMenuStrip = ContextMenuStripDgv

        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False

        OkTablesSaved = False
        VerifyTables()

        If Datos.SiemensRockwell = "Siemens" Then
            Init = True
            RadioButtonccSiemens.Checked = True
        Else
            Init = True
            RadioButtonccRockwell.Checked = True
        End If


    End Sub

    'OkResult = StartSqlCheq(TableResult, DataTableResult, OutputTypeResult)
    'TableResult: Nombre de la tabla afectada
    'DataTableResult: Datatable que contiene las lineas con las que operar
    'OutputTypeResult:
    '   0 = Ok
    '   1 = Hay que quitar filas de la ReportTable
    '   2 = Hay filas en la TagTable que no existen en la ReportTable
    '   3 = Hay diferencias en los TagName entre TagTable y ReportTable
    Public Function VerifyTables() As Boolean
        Dim Ok As Boolean = False
        Dim ResultNow As Boolean = False


        While True
            ResultNow = StartSqlCheq(TableResult, DataTableResult, OutputTypeResult)
            SQLTableState = OutputTypeResult

            If ResultNow AndAlso OutputTypeResult = 0 Then
                ' Caso 1: Todo Ok
                Exit While
            ElseIf Not ResultNow AndAlso OutputTypeResult = 1 Then
                ' Caso 2: Sobran datos en ReportTable
                ModifyTables(" > Sobran datos en ReportTable.'Ocultar' o 'Borrar' los cambios para continuar.", TableResult, DataTableResult)
                RadioButtonccArchive.Visible = True
                RadioButtonccDelete.Visible = True
                PanelInitialize.Visible = False
                Exit While
            ElseIf Not ResultNow AndAlso OutputTypeResult = 2 Then
                ' Caso 3: Faltan datos en ReportTable
                ModifyTables(" > Faltan datos en ReportTable. Grabe los cambios para continuar. ", TableResult, DataTableResult)
                Exit While
            ElseIf Not ResultNow AndAlso OutputTypeResult = 3 Then
                ModifyTables(" > Hay diferencias entre TagTable y ReportTable. Grabe los cambios para continuar. ", TableResult, DataTableResult)
                Exit While
            End If
        End While

        Ok = True
        Return Ok

    End Function

    Private Function ModifyTables(Txt As String, OutputTable As String, DataTableNow As DataTable)
        Label5.Visible = False
        txtInstallationName.Visible = False

        Panel2.Visible = False

        PanelInitialize.Visible = False

        lblNotices.Visible = True

        lblNotices.Text = Txt
        btnSaveDgvToSQL.Enabled = True

        For Each item As Object In ComBoxTables.Items
            If item.ToString().Contains(OutputTable) Then
                ComBoxTables.SelectedItem = item
                Exit For
            End If
        Next

        If DataTableNow.Columns.Contains("TagUnit") Then
            If OutputTable.ToString().Contains("Dig") Then
                DataTableNow.Columns.Remove("TagUnit")
            End If
        End If

        dgv.DataSource = DataTableNow

        dgv.Columns("TagIndex").Width = 60
        dgv.Columns("TagName").Width = 370

        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False


        ReloadMode = True
    End Function

    Private Sub ShowMessage()
        Dim resultado As DialogResult = MessageBox.Show("Este mensaje...", "Mensaje", MessageBoxButtons.OKCancel)

        If resultado = DialogResult.OK Then
            MessageBox.Show("Has hecho clic en Aceptar.")
            Me.Reload()
        ElseIf resultado = DialogResult.Cancel Then
            MessageBox.Show("Has hecho clic en Salir.")
            Me.Close()
        End If
    End Sub
    Dim ReloadMode As Boolean = False

    Private Sub Reload()
        Datos.FormCustomerConfigReload = True
        Me.Close()
    End Sub
    Private Sub ToComboBoxATables()
        Array.Sort(Datos.TablesToEdit)
        ComBoxTables.Items.Clear()
        ComBoxTables.Items.AddRange(Datos.TablesToEdit)
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Datos.frmclose = True
        Me.Close()
    End Sub

    Private Sub btnDeleteInstallationName_Click(sender As Object, e As EventArgs) Handles btnDeleteInstallationName.Click
        txtInstallationName.Text = ""
    End Sub

    Private Sub btnSaveInstallationName_Click(sender As Object, e As EventArgs) Handles btnSaveInstallationName.Click
        Datos.NombreInstalacion = txtInstallationName.Text
        config.WriteIni()
    End Sub

    Private Sub btnDefaultSqlChain_Click(sender As Object, e As EventArgs) Handles btnDefaultSqlChain.Click
        txtSQLServer.Text = ".\localhost\SQLExpress,1433"
        txtSQLDataBase.Text = "DB_ReportsTools"
        txtSQLUser.Text = "SQL_User_App"
        txtSQLPassword.Text = "User$Pass"

    End Sub

    Private Sub btnSqlCheck_Click(sender As Object, e As EventArgs) Handles btnSqlCheck.Click
        manageControlEnable(Me, False, listOriginalEnabledStates)
        dgv.DataSource = Nothing
        ComBoxTables.SelectedIndex = -1
        btnSaveSQLConnectionStringData.Enabled = False
        _OkConnect = False
        Dim Tables As DataTable = Nothing
        Dim ChainServer As String = txtSQLServer.Text
        Dim Chain As String = "Data Source=" & txtSQLServer.Text & ";Initial Catalog=" & txtSQLDataBase.Text & ";Integrated Security=False;TrustServerCertificate=True;User ID=" & txtSQLUser.Text & ";Password=" & txtSQLPassword.Text

        txtSQLServer.Text = "Probando conexión. Puede tardar hasta 30 segundos..."
        txtSQLServer.Refresh()
        Try
            _OkConnect = OpenSQL(Chain, Tables)
            If _OkConnect = True Then
                _tempOkTables = CheckTables(Tables)
                If _tempOkTables = True Then
                    MessageBox.Show("La cadena de conexión a la base de datos es correcta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error = La base de datos no cuenta con las tablas necesarias.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Error = La cadena de conexión a la base de datos no es correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch
        End Try
        txtSQLServer.Text = ChainServer
        txtSQLServer.Refresh()
        manageControlEnable(Me, True, listOriginalEnabledStates)
        btnSaveSQLConnectionStringData.Enabled = _tempOkTables And Datos.SQLConnectionStringData <> txtSQLServer.Text
        OkTablesSaved = Datos.SQLConnectionStringData = txtSQLServer.Text And _tempOkTables 'Se revisa que la conexión esté guardada y sea válida
    End Sub


    Private Sub BtnDeleteSQLConnectionStringData_Click(sender As Object, e As EventArgs) Handles btnDeleteSQLConnectionStringData.Click
        btnSaveSQLConnectionStringData.Enabled = False
        txtSQLServer.Text = ""
    End Sub
    Private Sub btnSQLConnectionStringData_Click(sender As Object, e As EventArgs) Handles btnSaveSQLConnectionStringData.Click
        On Error Resume Next
        If _tempOkTables Then
            Datos.SQLConnectionStringServer = txtSQLServer.Text
            Datos.SQLConnectionStringDataBase = txtSQLDataBase.Text
            Datos.SQLConnectionStringUser = txtSQLUser.Text
            Datos.SQLConnectionStringPassword = txtSQLPassword.Text

            config.WriteIni()
            config.ReadIni()

            btnSaveSQLConnectionStringData.Enabled = False
            db = New dbCon(Datos.SQLConnectionStringData)
            OkTablesSaved = True
        End If
    End Sub

    Dim Tables As DataTable = Nothing

    Private Function OpenSQL(ByVal Chain As String, <Out> ByRef Tables As DataTable) As Boolean
        Dim Ok As Boolean = False
        Dim OkConn As Boolean = False

        Dim Sql As String = "SELECT TABLE_SCHEMA, TABLE_NAME
                            FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_TYPE = 'BASE TABLE';"

        OkConn = False
        Try
            Using conexion As New SqlConnection(Chain)
                conexion.Open()
                'Conexión OK
                OkConn = True
            End Using
        Catch ex As Exception
            '
        End Try
        If OkConn Then
            Dim tempTables As DataTable = Nothing
            Dim dbVerify As dbCon = New dbCon(Chain)
            Ok = dbVerify.SelectDataTable(Sql, tempTables)

            If Ok Then
                Tables = tempTables
            End If
        End If
        Return Ok
    End Function

    Private dataTable As New DataTable()
    Private Sub ComBoxTables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComBoxTables.SelectedIndexChanged
        If ComBoxTables.SelectedIndex <> -1 Then
            Dim SelectedTable As String = ComBoxTables.SelectedItem.ToString()
            SelectedTableNow = ComBoxTables.SelectedItem.ToString()

            Dim SqlByReportBefore As String = "If Not EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '@Table' AND COLUMN_NAME = 'Archive')
                                    BEGIN
                                        ALTER TABLE [dbo].[@Table] ADD [Archive] BIT NULL;
                                    End"

            Dim SqlReportBefore As String = SqlByReportBefore.Replace("@Table", SelectedTable)

            If db.executecommand(SqlReportBefore) Then
            Else
            End If

            Dim Query As String

            If SelectedTable = "AnaVinsReportTable" Or SelectedTable = "AnaVtotReportTable" Then
                Query = $"SELECT [TagIndex], [TagName], [TagDescription], [TagUnit] FROM [dbo].[{SelectedTable}] 
                        WHERE [Archive] IS NULL or [Archive] = 0"
            ElseIf SelectedTable = "DigTfunTAutReportTable" Or SelectedTable = "DigNmanTAutReportTable" Then
                Query = $"SELECT [TagIndex], [TagName], [TagDescription] FROM [dbo].[{SelectedTable}] 
                        WHERE [Archive] IS NULL or [Archive] = 0"
            Else
                Query = $"SELECT * FROM [dbo].[{SelectedTable}] 
                        WHERE [Archive] IS NULL or [Archive] = 0"
            End If

            Dim Ok As Boolean = False
            Dim dt As DataTable = New DataTable()
            Try
                Dim dtTemp As DataTable = New DataTable
                If OpenSQL(Datos.SQLConnectionStringData, dtTemp) Then
                    Ok = db.SelectDataTable(Query, dt)
                    dataTable = dt
                    dgv.DataSource = dt
                    FitWidthColumns(dgv)
                    ResizeColumn(dgv, "TagDescription")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub FitWidthColumns(dataGridView As DataGridView)
        For Each columna As DataGridViewColumn In dataGridView.Columns
            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            columna.MinimumWidth = 50

            Dim anchoContenido As Integer = TextRenderer.MeasureText(columna.HeaderText, dataGridView.Font).Width
            anchoContenido += 4
            For Each fila As DataGridViewRow In dataGridView.Rows
                If Not fila.IsNewRow AndAlso fila.Cells(columna.Index).Value IsNot Nothing Then
                    Dim anchoCelda As Integer = TextRenderer.MeasureText(fila.Cells(columna.Index).Value.ToString(), dataGridView.Font).Width
                    anchoContenido = Math.Max(anchoContenido, anchoCelda)
                End If
            Next

            columna.Width = Math.Max(anchoContenido, columna.MinimumWidth)
        Next
    End Sub

    Public Sub ResizeColumn(dgv As DataGridView, Optional colName As String = "")
        Try
            Dim totalWidth As Integer = 0
            Dim ThisColumn As DataGridViewColumn = Nothing

            For Each col As DataGridViewColumn In dgv.Columns
                If col.Visible Then
                    totalWidth += col.Width
                    ThisColumn = col
                End If
            Next

            Dim verticalScrollBarWidth As Integer = 0
            If dgv.Controls.OfType(Of VScrollBar)().FirstOrDefault()?.Visible Then
                verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth
            End If

            If Not String.IsNullOrEmpty(colName) AndAlso dgv.Columns.Contains(colName) Then
                dgv.Columns(colName).Width = dgv.Width - (totalWidth - dgv.Columns(colName).Width) - verticalScrollBarWidth
            ElseIf ThisColumn IsNot Nothing Then
                ThisColumn.Width = dgv.Width - (totalWidth - ThisColumn.Width) - verticalScrollBarWidth
            End If

        Catch 'ex As Exception

        End Try
    End Sub

    Private Sub txtBoxFilter_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBoxFilter.KeyUp
        FilterDGV(dgv, sender.text)
    End Sub

    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown

        If e.Control AndAlso e.KeyCode = Keys.V Then
            Dim dataTableRead As DataTable = GetClipboard()
            WriteInDgv(dataTableRead)
            e.Handled = True
        End If
    End Sub

    Function GetClipboard() As DataTable
        If Clipboard.ContainsText() Then
            Dim clipboardText As String = Clipboard.GetText()

            Dim rows As String() = clipboardText.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            Dim columns As String() = rows(0).Split(vbTab)

            Dim dataTable As New DataTable()

            For i As Integer = 0 To columns.Length - 1
                dataTable.Columns.Add("column_" & (i + 1).ToString()) '"column_1", "column_2", "...
            Next

            For i As Integer = 0 To rows.Length - 1
                Dim values As String() = rows(i).Split(vbTab)
                dataTable.Rows.Add(values)
            Next

            Return dataTable
        Else
            Return New DataTable()
        End If
    End Function

    Function WriteInDgv(ByRef dataTableRead As DataTable)
        Dim selectedRows As DataGridViewSelectedRowCollection = dgv.SelectedRows
        Dim selectedColumns As DataGridViewSelectedColumnCollection = dgv.SelectedColumns

        Dim numRowsToPaste As Integer = Math.Min(DgvSelectedRowsCount, dataTableRead.Rows.Count)
        Dim numColsToPaste As Integer = Math.Min(DgvselectedColumnsCount, dataTableRead.Columns.Count)

        Dim startRowIndex As Integer = DgvFirstSelectedRow
        Dim startColIndex As Integer = DgvFirstSelectedColumn

        If startRowIndex >= 0 AndAlso startColIndex >= 0 Then
            For i As Integer = 0 To numRowsToPaste - 1
                For j As Integer = 0 To numColsToPaste - 1
                    Dim cellValue As Object = dataTableRead.Rows(i)(j)

                    Dim dgvRowIndex As Integer = startRowIndex + i
                    Dim dgvColIndex As Integer = startColIndex + j

                    If dgvRowIndex < dgv.Rows.Count AndAlso dgvColIndex < dgv.Columns.Count Then
                        dgv.Rows(dgvRowIndex).Cells(dgvColIndex).Value = cellValue
                    End If
                Next
            Next
        End If
    End Function

    Sub DelContentInDgv()
        For Each sc In dgv.SelectedCells
            sc.value = ""
        Next
    End Sub
    Dim DgvSelectedRowsCount As Integer
    Dim DgvselectedColumnsCount As Integer
    Dim DgvFirstSelectedRow As Integer
    Dim DgvFirstSelectedColumn As Integer

    Private Sub dgv_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDown
        DgvSelectedRowsCount = 0
        DgvselectedColumnsCount = 0
        DgvFirstSelectedRow = 0
        DgvFirstSelectedColumn = 0
    End Sub

    Private Sub dgv_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseUp
        If e.Button = MouseButtons.Left Then
            CaptureSelectedCells()
        End If
    End Sub

    Private Sub CaptureSelectedCells()
        Dim selectedCells As DataGridViewSelectedCellCollection = dgv.SelectedCells

        DgvSelectedRowsCount = GetSelectedRowCount(selectedCells)
        DgvselectedColumnsCount = GetSelectedColumnCount(selectedCells)

        If DgvSelectedRowsCount > 0 AndAlso DgvselectedColumnsCount > 0 Then
            Dim firstSelectedRow As Integer = Integer.MaxValue
            Dim firstSelectedColumn As Integer = Integer.MaxValue

            For Each cell As DataGridViewCell In selectedCells
                If cell.RowIndex < firstSelectedRow Then
                    firstSelectedRow = cell.RowIndex
                End If

                If cell.ColumnIndex < firstSelectedColumn Then
                    firstSelectedColumn = cell.ColumnIndex
                End If
            Next

            DgvFirstSelectedRow = firstSelectedRow
            DgvFirstSelectedColumn = firstSelectedColumn
        End If
    End Sub

    Private Function GetSelectedRowCount(selectedCells As DataGridViewSelectedCellCollection) As Integer
        Dim distinctRows As New HashSet(Of Integer)()

        For Each cell As DataGridViewCell In selectedCells
            distinctRows.Add(cell.RowIndex)
        Next

        Return distinctRows.Count
    End Function

    Private Function GetSelectedColumnCount(selectedCells As DataGridViewSelectedCellCollection) As Integer
        Dim distinctColumns As New HashSet(Of Integer)()

        For Each cell As DataGridViewCell In selectedCells
            distinctColumns.Add(cell.ColumnIndex)
        Next

        Return distinctColumns.Count
    End Function

    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs) Handles dgv.SelectionChanged
        For Each cell As DataGridViewCell In dgv.SelectedCells
            If cell.ColumnIndex = 0 OrElse cell.ColumnIndex = 1 Then
                cell.Selected = False
            End If
        Next
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        If e.ColumnIndex = 0 OrElse e.ColumnIndex = 1 Then
            dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = False
            dgv.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly = True
        End If
    End Sub

    Private Sub btnSaveDgvToSQL_Click(sender As Object, e As EventArgs) Handles btnSaveDgvToSQL.Click
        Dim Answer As DialogResult = MessageBox.Show("¿Está seguro de grabar estos datos?" & vbCrLf & "Este procedimiento no es reversible.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Answer = DialogResult.Yes Then

            Select Case OutputTypeResult
                Case 0
                    SaveDataInSQL()
                    Exit Select
                Case 1
                    If RadioButtonccArchive.Checked = True Then
                        ArchiveDataInSQL()
                        Exit Select
                    End If
                    If RadioButtonccDelete.Checked = True Then
                        DeleteDataInSQL()
                        Exit Select
                    End If
                Case 2
                    DeleteIndexInSQL()
                    InsertDataInSQL()
                    Exit Select
                Case 3
                    SaveDataInSQL()
                    Exit Select
                Case Else
            End Select

        Else
            Return
        End If

        If ReloadMode Then
            Reload()
        End If

    End Sub
    Private Sub InsertDataInSQL()
        Dim TableNow As DataTable = Nothing
        TableNow = dgv.DataSource
        Dim sql As String

        Try
            Dim tableName = "[dbo].[" & SelectedTableNow & "]"
            sql = "INSERT INTO " & tableName & " (TagIndex, TagName, "

            For Each columna As DataColumn In TableNow.Columns
                If columna.ColumnName <> "TagIndex" AndAlso columna.ColumnName <> "TagName" Then
                    sql &= " [" & columna.ColumnName & "],"
                End If
            Next

            Dim ThereIsColumn As String = "IF EXISTS (
                                            SELECT 1 
                                            FROM INFORMATION_SCHEMA.COLUMNS 
                                            WHERE TABLE_NAME = '" & tableName & "' 
                                            AND COLUMN_NAME = 'TagPrint'
                                            )
                                                SELECT '1';
                                           ELSE
                                                SELECT '0';"

            Dim Result As String = Convert.ToString(db.ExecuteScalar(ThereIsColumn))

            If Result = "0" Then
                sql = sql.TrimEnd(",") & ") VALUES "
            ElseIf Result = "1" Then
                sql = sql.TrimEnd(",") & ", [TagPrint]) VALUES "
            End If


            For Each fila As DataRow In TableNow.Rows
                sql &= "(" & fila("TagIndex").ToString() & ", '" & fila("TagName").ToString() & "',"

                For Each columna As DataColumn In TableNow.Columns
                    If columna.ColumnName <> "TagIndex" AndAlso columna.ColumnName <> "TagName" Then
                        sql &= If(fila(columna.ColumnName) IsNot Nothing, "'" & fila(columna.ColumnName).ToString() & "'", "NULL") & ","
                    End If
                Next

                If Result = "0" Then
                    sql = sql.TrimEnd(",") & " ),"
                ElseIf Result = "1" Then
                    sql = sql.TrimEnd(",") & ", 1),"
                End If

            Next

            sql = sql.TrimEnd(",")
            If db.executecommand(sql) Then
                MessageBox.Show("Datos insertados correctamente en SQL.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Error al insertar, Sql= " + sql)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al insertar: " & ex.Message)
        End Try
    End Sub

    Private Sub SaveDataInSQL()
        Dim TableNow As DataTable = Nothing
        TableNow = dgv.DataSource
        Dim sql As String

        Try
            Dim tableName = "[dbo].[" & SelectedTableNow & "]"
            sql = "UPDATE " & tableName & " SET "

            For Each columna As DataColumn In TableNow.Columns
                If columna.ColumnName <> "TagIndex" Then
                    sql &= "[" & columna.ColumnName & "] = '@" & columna.ColumnName & "',"
                End If
            Next

            sql = sql.TrimEnd(",")
            sql &= " WHERE TagIndex = @TagIndex"

            For Each fila As DataRow In TableNow.Rows
                Dim sqlQuery As String = sql

                For Each columna As DataColumn In TableNow.Columns
                    Dim marcador As String = "@" & columna.ColumnName
                    Dim valor As Object = fila(columna.ColumnName)
                    sqlQuery = sqlQuery.Replace(marcador, If(valor IsNot Nothing, valor.ToString(), "NULL"))
                Next

                If db.executecommand(sqlQuery) Then
                Else
                    MessageBox.Show("Error al actualizar, Sql= " + sqlQuery)
                End If
            Next

            MessageBox.Show("Datos guardados correctamente en SQL.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteDataInSQL()
        Dim TableNow As DataTable = Nothing
        TableNow = dgv.DataSource
        Dim sql As String

        Try
            Dim tableName = "[dbo].[" & SelectedTableNow & "]"
            sql = "DELETE FROM " & tableName & " WHERE TagIndex IN ("

            For Each fila As DataRow In TableNow.Rows
                Dim tagIndexValue As Object = fila("TagIndex")
                If tagIndexValue IsNot Nothing Then
                    sql &= tagIndexValue.ToString() & ","
                End If
            Next

            If TableNow.Rows.Count > 0 Then
                sql = sql.TrimEnd(",")
                sql &= ")"

                If db.executecommand(sql) Then
                    MessageBox.Show("Datos eliminados correctamente en SQL.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al eliminar, Sql= " + sql)
                End If
            Else
                MessageBox.Show("No hay filas para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message)
        End Try
    End Sub

    Private Sub DeleteIndexInSQL()
        Dim TableNow As DataTable = Nothing
        TableNow = dgv.DataSource
        Dim sql As String

        Try
            Dim tableName = "[dbo].[" & SelectedTableNow & "]"
            sql = "DELETE FROM " & tableName & " WHERE TagIndex IN ("

            For Each fila As DataRow In TableNow.Rows
                Dim tagIndexValue As Object = fila("TagIndex")
                If tagIndexValue IsNot Nothing Then
                    sql &= tagIndexValue.ToString() & ","
                End If
            Next

            If TableNow.Rows.Count > 0 Then
                sql = sql.TrimEnd(",")
                sql &= ")"

                If db.executecommand(sql) Then
                Else
                End If
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ArchiveDataInSQL()
        Dim TableNow As DataTable = Nothing
        TableNow = dgv.DataSource
        Dim sql As String

        Try
            Dim tableName = "[dbo].[" & SelectedTableNow & "]"

            If Not DoesColumnExist(SelectedTableNow, "Archive") Then
                sql = "ALTER TABLE " & tableName & " ADD Archive BIT;"
                If db.executecommand(sql) Then
                    MessageBox.Show("Columna 'Archive' creada correctamente en la tabla.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al crear la columna 'Archive', Sql= " + sql)
                    Exit Sub
                End If
            End If

            sql = "UPDATE " & tableName & " SET Archive = 1 WHERE TagIndex IN ("

            For Each fila As DataRow In TableNow.Rows
                Dim tagIndexValue As Object = fila("TagIndex")
                If tagIndexValue IsNot Nothing Then
                    sql &= tagIndexValue.ToString() & ","
                End If
            Next

            If TableNow.Rows.Count > 0 Then
                sql = sql.TrimEnd(",")
                sql &= ")"

                If db.executecommand(sql) Then
                    MessageBox.Show("Datos archivados correctamente en SQL.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error al archivar, Sql= " + sql)
                End If
            Else
                MessageBox.Show("No hay filas para archivar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al archivar: " & ex.Message)
        End Try
    End Sub

    Private Sub dgv_Resize(sender As Object, e As EventArgs) Handles dgv.Resize
        ResizeLastColumn(dgv, "TagDescription")
    End Sub

    Private Sub dgv_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv.RowsAdded
        ResizeLastColumn(dgv, "TagDescription")
    End Sub

    Private Sub dgv_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv.RowsRemoved
        ResizeLastColumn(dgv, "TagDescription")
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        Clipboard.SetDataObject(dgv.GetClipboardContent())
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        If Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) Then

            dgv.BeginEdit(True)
            Dim dataTableRead As DataTable = GetClipboard()
            CaptureSelectedCells()
            WriteInDgv(dataTableRead)
            dgv.EndEdit()
        Else
            MessageBox.Show("Sin datos en el portapapeles a pegar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SuprToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuprToolStripMenuItem.Click
        dgv.BeginEdit(True)
        DelContentInDgv()
        dgv.EndEdit()
    End Sub

    Private Sub ContextMenuStripDgv_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripDgv.Opening

    End Sub

    Private Sub btnSqlAdminCheck_Click(sender As Object, e As EventArgs) Handles btnSqlAdminCheck.Click
        'manageControlEnable(Me, False, listOriginalEnabledStates)
        Dim Answer As DialogResult = MessageBox.Show("¿Está seguro de Inicializar Tablas?" & vbCrLf & "Este procedimiento no es reversible.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If Answer = DialogResult.Yes Then
            _OkConnect = False
            Dim Chain As String = Datos.SQLConnectionAdminMaster

            Dim FileNow As String = Datos.RouteAPP + "QueryCreateTable.sql"
            Dim Sql As String = ""

            If File.Exists(FileNow) Then
                Using reader As New StreamReader(FileNow)
                    Sql = reader.ReadToEnd()
                End Using
            Else
                MessageBox.Show("El archivo 'QueryCreateTable.sql' no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Try
                Dim dbWin As dbCon = New dbCon(Chain)
                If dbWin.executeMultiCommand(Sql) Then
                Else
                End If
                TablesVerify()
            Catch ex As Exception
                'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("No ha sido posible la creación correcta de las tablas." & vbCrLf & "Verifique que el usuario de Windows cuenta con permisos de administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            Return
        End If
        ' manageControlEnable(Me, True, listOriginalEnabledStates)
    End Sub

    Private Sub TablesVerify(Optional SQLChain As String = Nothing)
        _OkConnect = False
        Dim Tables As DataTable = Nothing
        Dim Chain As String = If(SQLChain, Datos.SQLConnectionStringData)

        Try
            _OkConnect = OpenSQL(Chain, Tables)
            If _OkConnect = True Then
                _tempOkTables = CheckTables(Tables)
                If _tempOkTables = True Then
                    MessageBox.Show("Se han inicializado correctamente las tablas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No se han inicializado correctamente las tablas." & vbCrLf & "✏️" & vbCrLf & " La base de datos no cuenta con las tablas necesarias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Error = La cadena de conexión a la base de datos del usuario no es correcta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch
        End Try

    End Sub

    Private Sub RadioButtonccSiemens_CheckedChange() Handles RadioButtonccSiemens.CheckedChange
        If RadioButtonccSiemens.Checked AndAlso Init Then
            BtnImportTagSiemens.Visible = True
            Datos.SiemensRockwell = "Siemens"
            config.WriteIni()
        End If
    End Sub

    Private Sub RadioButtonccRockwell_CheckedChange() Handles RadioButtonccRockwell.CheckedChange
        If RadioButtonccRockwell.Checked AndAlso Init Then
            BtnImportTagSiemens.Visible = False
            Datos.SiemensRockwell = "Rockwell"
            config.WriteIni()
        End If
    End Sub

    Private Sub BtnImportTagSiemens_Click(sender As Object, e As EventArgs) Handles BtnImportTagSiemens.Click
        Datos.frmUtilTagsImport = True
    End Sub

    Private Sub txtInstallationName_KeyUp(sender As Object, e As KeyEventArgs) Handles txtInstallationName.KeyUp
        Datos.NombreInstalacion = txtInstallationName.Text
        config.WriteIni()
    End Sub

End Class
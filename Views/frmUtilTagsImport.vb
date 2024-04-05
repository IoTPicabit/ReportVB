Imports System.Data
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports ClosedXML.Excel
Imports DocumentFormat.OpenXml.Spreadsheet
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class frmUtilTagsImport
    Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
    Dim dt_AnaVal As DataTable = New DataTable()
    Dim dt_AnaTot As DataTable = New DataTable()
    Dim dt_DigVal As DataTable = New DataTable()
    Dim dt_DigMan As DataTable = New DataTable()

    Dim SqlAnaVal As String = "SELECT [TagName]
                          ,[TagIndex]
                          --,[TagType]
                          --,[TagDataType]
                            FROM [dbo].[AnaVinsTagTable]
                            order by [TagIndex]"

    Dim SqlAnaTot As String = "SELECT [TagName]
                          ,[TagIndex]
                          --,[TagType]
                          --,[TagDataType]
                            FROM [dbo].[AnaVtotTagTable]
                            order by [TagIndex]"

    Dim SqlDigVal As String = "SELECT [TagName]
                          ,[TagIndex]
                          --,[TagType]
                          --,[TagDataType]
                            FROM [dbo].[DigTfunTAutTagTable] 
                            order by [TagIndex]"

    Dim SqlDigMan As String = "SELECT [TagName]
                          ,[TagIndex]
                          --,[TagType]
                          --,[TagDataType]
                            FROM [dbo].[DigNmanTAutTagTable] 
                            order by [TagIndex]"

    Dim config As ConfigIni = New ConfigIni()

    Dim tt As New ToolTip()

    ' Lista para almacenar el estado original de los controles
    Public listOriginalEnabledStates As New List(Of KeyValuePair(Of String, Boolean))

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        db = New dbCon(Datos.SQLConnectionStringData)
        MiroDgv()
        tt.SetToolTip(BtnSearchFile, "Buscar archivo exportación TAG desde TiaPortal")

        tt.SetToolTip(BtnBorrarAnaVal, "Borrar fila seleccionada de la tabla AnaVinsTagTable")
        tt.SetToolTip(BtnInsertarAnaVal, "Insertar fila seleccionada ✅ de la tabla TAG desde TiaPortal en la tabla AnaVinsTagTable")

        tt.SetToolTip(BtnBorrarAnaTot, "Borrar fila seleccionada de la tabla AnaVtotTagTable")
        tt.SetToolTip(BtnInsertarAnaTot, "Insertar fila seleccionada ✅ de la tabla TAG desde TiaPortal en la tabla AnaVtotTagTable")

        tt.SetToolTip(BtnBorrarDigVal, "Borrar fila seleccionada de la tabla DigTfunTAutTagTable ")
        tt.SetToolTip(BtnInsertarDigVal, "Insertar fila seleccionada ✅ de la tabla TAG desde TiaPortal en la tabla DigTfunTAutTagTable")

        tt.SetToolTip(BtnBorrarDigMan, "Borrar fila seleccionada de la tabla DigNmanTAutTagTable")
        tt.SetToolTip(BtnInsertarDigMan, "Insertar fila seleccionada ✅ de la tabla TAG desde TiaPortal en la tabla DigNmanTAutTagTable")


    End Sub
    Dim selectedRow_dgvAnaVal
    Dim selectedRow_dgvAnaTot
    Dim selectedRow_dgvDigVal
    Dim selectedRow_dgvDigMan
    Private Sub MiroDgv()
        Dim Ok_AnaVal As Boolean = False
        Ok_AnaVal = db.SelectDataTable(SqlAnaVal, dt_AnaVal)
        dgvAnaVal.DataSource = dt_AnaVal
        If Ok_AnaVal Then
            dgvAnaVal.Columns("TagName").Width = 270
            dgvAnaVal.Columns("TagIndex").Width = 60
        End If

        Dim Ok_AnaTot As Boolean = False
        Ok_AnaTot = db.SelectDataTable(SqlAnaTot, dt_AnaTot)
        dgvAnaTot.DataSource = dt_AnaTot
        If Ok_AnaTot Then
            dgvAnaTot.Columns("TagName").Width = 270
            dgvAnaTot.Columns("TagIndex").Width = 60
        End If

        Dim Ok_DigVal As Boolean = False
        Ok_DigVal = db.SelectDataTable(SqlDigVal, dt_DigVal)
        dgvDigVal.DataSource = dt_DigVal
        If Ok_DigVal Then
            dgvDigVal.Columns("TagName").Width = 270
            dgvDigVal.Columns("TagIndex").Width = 60
        End If

        Dim Ok_DigMan As Boolean = False
        Ok_DigMan = db.SelectDataTable(SqlDigMan, dt_DigMan)
        dgvDigMan.DataSource = dt_DigMan
        If Ok_DigMan Then
            dgvDigMan.Columns("TagName").Width = 270
            dgvDigMan.Columns("TagIndex").Width = 60
        End If

        dgv1.ClearSelection()
        dgvAnaVal.ClearSelection()
        dgvAnaTot.ClearSelection()
        dgvDigVal.ClearSelection()
        dgvDigMan.ClearSelection()
        selectedRow_dgvAnaVal = ""
        selectedRow_dgvAnaTot = ""
        selectedRow_dgvDigVal = ""
        selectedRow_dgvDigMan = ""
        dgv1.MultiSelect = False
        dgv1.AllowUserToAddRows = False
        dgvAnaVal.MultiSelect = False
        dgvAnaTot.MultiSelect = False
        dgvDigVal.MultiSelect = False
        dgvDigMan.MultiSelect = False

        dgvAnaVal.AllowUserToAddRows = False
        dgvAnaVal.AllowUserToDeleteRows = False
        If dgvAnaVal.Rows.Count > 0 Then
            For Each col As DataGridViewColumn In dgvAnaVal.Columns
                col.[ReadOnly] = True
            Next
        End If

        dgvAnaTot.AllowUserToAddRows = False
        dgvAnaTot.AllowUserToDeleteRows = False
        If dgvAnaTot.Rows.Count > 0 Then
            For Each col As DataGridViewColumn In dgvAnaTot.Columns
                col.[ReadOnly] = True
            Next
        End If

        dgvDigVal.AllowUserToAddRows = False
        dgvDigVal.AllowUserToDeleteRows = False
        If dgvDigVal.Rows.Count > 0 Then
            For Each col As DataGridViewColumn In dgvDigVal.Columns
                col.[ReadOnly] = True
            Next
        End If

        dgvDigMan.AllowUserToAddRows = False
        dgvDigMan.AllowUserToDeleteRows = False
        If dgvDigMan.Rows.Count > 0 Then
            For Each col As DataGridViewColumn In dgvDigMan.Columns
                col.[ReadOnly] = True
            Next
        End If

        TimerDgv.Enabled = True
    End Sub
    Private Sub BtnSearchFile_Click(sender As Object, e As EventArgs) Handles BtnSearchFile.Click
        dgv1.DataSource = Nothing
        dgv1.Rows.Clear()
        dgv1.Columns.Clear()

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*"
        openFileDialog.Title = "Seleccionar archivo Tag TiaPortal"

        If openFileDialog.ShowDialog() = DialogResult.OK Then

            Dim filePath As String = openFileDialog.FileName
            txtRutaImport.Text = filePath

            Try
                Using workbook As New XLWorkbook(filePath)

                    Dim worksheet As IXLWorksheet = workbook.Worksheet(1)

                    Dim dataTable As New DataTable()

                    For Each cell In worksheet.FirstRow().Cells()
                        dataTable.Columns.Add(cell.Value.ToString())
                    Next

                    If dataTable.Columns.Count >= 24 AndAlso dataTable.Columns(4).ColumnName = "DataType" Then
                        ' Es Tia Portal
                    Else
                        MessageBox.Show("El archivo seleccionado..." & vbCrLf & "... no es una exportación de Tag ..." & vbCrLf & "... de TiaPortal.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    For Each row In worksheet.RowsUsed().Skip(1)
                        Dim rowData = row.Cells().Select(Function(cell) cell.Value.ToString()).ToArray()
                        dataTable.Rows.Add(rowData)
                    Next


                    If dataTable.Columns.Count >= 24 AndAlso dataTable.Columns(4).ColumnName = "DataType" Then
                        ' Es Tia Portal
                        dgv1.DataSource = dataTable

                        'Add Columna imagen
                        Dim imgColumn As New DataGridViewImageColumn()
                        imgColumn.HeaderText = "✏️"
                        imgColumn.Width = 30
                        imgColumn.Name = "✏️"

                        'Add Columna CheckBox
                        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                        checkBoxColumn.HeaderText = "OK"
                        checkBoxColumn.Width = 30
                        checkBoxColumn.Name = "checkBoxColumn"

                        If dataTable.Rows.Count > 0 Then
                            dgv1.Columns.Insert(0, imgColumn)
                            dgv1.Columns.Insert(1, checkBoxColumn)
                            dgv1.Columns(2).Width = 500 'Name
                            dgv1.Columns(3).Width = 250 'Path
                            dgv1.Columns(4).Visible = False
                            dgv1.Columns(5).Visible = False
                            dgv1.Columns(6).Width = 200 'DataType

                            For i As Integer = 7 To 26
                                dgv1.Columns(i).Visible = False
                            Next
                        End If

                        For Each row As DataGridViewRow In dgv1.Rows
                            row.Cells("✏️").Value = My.Resources.no
                            'row.Cells(0).Value = My.Resources.no
                        Next

                        dgv1.Columns(1).Visible = False

                    Else
                        If dataTable.Rows.Count > 0 Then
                            dataTable.Clear()
                        End If
                        MessageBox.Show("El archivo seleccionado..." & vbCrLf & "... no es una exportación de Tag ..." & vbCrLf & "... de TiaPortal.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            dgv1.AllowUserToAddRows = False
            'dgv1.AllowUserToDeleteRows = False

            If dgv1.Rows.Count > 0 Then
                For Each col As DataGridViewColumn In dgv1.Columns
                    col.[ReadOnly] = True
                Next
            End If

        End If
    End Sub


    Private Sub dgvAnaVal_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        selectedRow_dgvAnaVal = Convert.ToString(e.RowIndex)
    End Sub
    Private Sub dgvAnaTot_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        selectedRow_dgvAnaTot = Convert.ToString(e.RowIndex)
    End Sub
    Private Sub dgvDigVal_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        selectedRow_dgvDigVal = Convert.ToString(e.RowIndex)
    End Sub
    Private Sub dgvDigMan_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        selectedRow_dgvDigMan = Convert.ToString(e.RowIndex)
    End Sub
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Datos.frmclose = True
        Me.Close()
    End Sub

    Private Sub BtnInsertarAnaVal_Click(sender As Object, e As EventArgs) Handles BtnInsertarAnaVal.Click
        Dim dt As New DataTable()
        dt = dgvAnaVal.DataSource

        Dim dtTagFree As New DataTable()

        Dim Sql As String = "WITH NumerosCTE AS (
                                    SELECT TOP 1 MAX(TagIndex) AS MaximoTagIndex
                                    FROM AnaVinsTagTable
	                                GROUP BY AnaVinsTagTable.TagIndex
                                    ORDER BY TagIndex DESC
                                ), SecuenciaCTE AS (
                                    SELECT DISTINCT TOP (SELECT MaximoTagIndex FROM NumerosCTE) 
                                        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Numero
                                    FROM master..spt_values -- tabla auxiliar con la secuencia
                                )

                                SELECT Numero
                                FROM SecuenciaCTE
                                WHERE NOT EXISTS (
                                    SELECT 1
                                    FROM AnaVinsTagTable
                                    WHERE AnaVinsTagTable.TagIndex = SecuenciaCTE.Numero
                                );"

        If CheckBoxCcAnaVal.Checked Then
            ' Busco TagIndex Libres
            Dim Ok As Boolean = False
            Ok = db.SelectDataTable(Sql, dtTagFree)
        End If

        Dim NewIndex As Integer
        NewIndex = Convert.ToInt64(db.selectstring("SELECT ISNULL(MAX(TagIndex), 0) + 1 AS SiguienteTagIndex FROM dbo.AnaVinsTagTable"))
        Dim NumOldIndex As Integer
        Dim IdFreeTagIndex As Integer = 0

        NumOldIndex = 0
        If dtTagFree.Rows.Count > 0 Then
            NumOldIndex = dtTagFree.Rows.Count
        End If

        Dim NumReg As Integer = 0

        For Each row As DataGridViewRow In dgv1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("checkBoxColumn").Value)
            If isSelected Then
                If dtTagFree.Rows.Count > 0 Then
                    If NumOldIndex > 0 Then
                        If db.executecommand("INSERT INTO [dbo].[AnaVinsTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(dtTagFree.Rows(IdFreeTagIndex)(0)) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If
                        NumOldIndex = NumOldIndex - 1
                        IdFreeTagIndex += 1
                    Else
                        If db.executecommand("INSERT INTO [dbo].[AnaVinsTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If

                        NewIndex += 1
                    End If
                Else
                    If db.executecommand("INSERT INTO [dbo].[AnaVinsTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                        dt.Rows.Add(row.Cells(1).Value, NewIndex)
                    Else
                        MessageBox.Show("Error en SQL Query >>> " & Sql)
                    End If
                    NewIndex += 1
                End If
            End If
        Next

        MiroDgv()

        txtBoxFilterAnaVinsTagTable.Text = ""
    End Sub

    Private Sub BtnBorrarAnaVal_Click(sender As Object, e As EventArgs) Handles BtnBorrarAnaVal.Click
        Dim ahoraInicio = selectedRow_dgvAnaVal

        If Not String.IsNullOrEmpty(selectedRow_dgvAnaVal) Then
            Dim ahora = selectedRow_dgvAnaVal
            ' Extraer campos desde DataGridView
            Dim _Nombre As String = Convert.ToString(dgvAnaVal.Rows(selectedRow_dgvAnaVal).Cells(0).Value)
            Dim _Index As String = Convert.ToString(dgvAnaVal.Rows(selectedRow_dgvAnaVal).Cells(1).Value)
            Dim respuesta As DialogResult = MessageBox.Show("¿Esta seguro de borrar ? " & vbCrLf & " " & vbCrLf & "El Tag: ... " & vbCrLf & " " + _Nombre + " " & vbCrLf & "con IndexTag: ..." & vbCrLf & " " + _Index + "", "Confirmación", MessageBoxButtons.YesNo)

            If respuesta = DialogResult.Yes Then
                'Borro'
                If db.executecommand("DELETE FROM [dbo].[AnaVinsTagTable] WHERE [TagName] = '" + _Nombre + "' and [TagIndex] = " + _Index + " ") Then
                    MiroDgv()
                    Return
                Else
                    MessageBox.Show("Error en SQL al borrar.")
                End If


            ElseIf respuesta = DialogResult.No Then
                Return
            End If
        Else
            MessageBox.Show("Seleccione primero el dato a borrar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        txtBoxFilterAnaVinsTagTable.Text = ""

    End Sub

    Private Sub BtnInsertarAnaTot_Click(sender As Object, e As EventArgs) Handles BtnInsertarAnaTot.Click

        Dim dt As New DataTable()
        dt = dgvAnaTot.DataSource

        Dim dtTagFree As New DataTable()

        Dim Sql As String = "WITH NumerosCTE AS (
                                    SELECT TOP 1 MAX(TagIndex) AS MaximoTagIndex
                                    FROM AnaVtotTagTable
	                                GROUP BY AnaVtotTagTable.TagIndex
                                    ORDER BY TagIndex DESC
                                ), SecuenciaCTE AS (
                                    SELECT DISTINCT TOP (SELECT MaximoTagIndex FROM NumerosCTE) 
                                        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Numero
                                    FROM master..spt_values -- tabla auxiliar con la secuencia
                                )

                                SELECT Numero
                                FROM SecuenciaCTE
                                WHERE NOT EXISTS (
                                    SELECT 1
                                    FROM AnaVtotTagTable
                                    WHERE AnaVtotTagTable.TagIndex = SecuenciaCTE.Numero
                                );"

        If CheckBoxCcAnaTot.Checked Then
            ' Busco TagIndex Libres
            Dim Ok As Boolean = False
            Ok = db.SelectDataTable(Sql, dtTagFree)
        End If

        Dim NewIndex As Integer
        NewIndex = Convert.ToInt64(db.selectstring("SELECT ISNULL(MAX(TagIndex), 0) + 1 AS SiguienteTagIndex FROM dbo.AnaVtotTagTable"))
        Dim NumOldIndex As Integer
        Dim IdFreeTagIndex As Integer = 0

        NumOldIndex = 0
        If dtTagFree.Rows.Count > 0 Then
            NumOldIndex = dtTagFree.Rows.Count
        End If

        Dim NumReg As Integer = 0

        For Each row As DataGridViewRow In dgv1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("checkBoxColumn").Value)
            If isSelected Then
                If dtTagFree.Rows.Count > 0 Then
                    If NumOldIndex > 0 Then
                        If db.executecommand("INSERT INTO [dbo].[AnaVtotTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(dtTagFree.Rows(IdFreeTagIndex)(0)) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If
                        NumOldIndex = NumOldIndex - 1
                        IdFreeTagIndex += 1
                    Else
                        If db.executecommand("INSERT INTO [dbo].[AnaVtotTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If

                        NewIndex += 1
                    End If
                Else
                    If db.executecommand("INSERT INTO [dbo].[AnaVtotTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                        dt.Rows.Add(row.Cells(1).Value, NewIndex)
                    Else
                        MessageBox.Show("Error en SQL Query >>> " & Sql)
                    End If
                    NewIndex += 1
                End If
            End If
        Next

        MiroDgv()
        txtBoxFilterAnaVtotTagTable.Text = ""

    End Sub

    Private Sub BtnBorrarAnaTot_Click(sender As Object, e As EventArgs) Handles BtnBorrarAnaTot.Click
        Dim ahoraInicio = selectedRow_dgvAnaTot
        If Not String.IsNullOrEmpty(selectedRow_dgvAnaTot) Then
            Dim ahora = selectedRow_dgvAnaTot
            ' Extraer campos desde DataGridView
            Dim _Nombre As String = Convert.ToString(dgvAnaTot.Rows(selectedRow_dgvAnaTot).Cells(0).Value)
            Dim _Index As String = Convert.ToString(dgvAnaTot.Rows(selectedRow_dgvAnaTot).Cells(1).Value)
            Dim respuesta As DialogResult = MessageBox.Show("¿Esta seguro de borrar ? " & vbCrLf & " " & vbCrLf & "El Tag: ... " & vbCrLf & " " + _Nombre + " " & vbCrLf & "con IndexTag: ..." & vbCrLf & " " + _Index + "", "Confirmación", MessageBoxButtons.YesNo)

            If respuesta = DialogResult.Yes Then
                'Borro'
                If db.executecommand("DELETE FROM [dbo].[AnaVtotTagTable] WHERE [TagName] = '" + _Nombre + "' and [TagIndex] = " + _Index + " ") Then
                    MiroDgv()
                    Return
                Else
                    MessageBox.Show("Error en SQL al borrar.")
                End If


            ElseIf respuesta = DialogResult.No Then
                Return
            End If
        Else
            MessageBox.Show("Seleccione primero el dato a borrar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        txtBoxFilterAnaVtotTagTable.Text = ""
    End Sub

    Private Sub BtnInsertarDigVal_Click(sender As Object, e As EventArgs) Handles BtnInsertarDigVal.Click

        Dim dt As New DataTable()

        dt = dgvDigVal.DataSource

        Dim dtTagFree As New DataTable()

        Dim Sql As String = "WITH NumerosCTE AS (
                                    SELECT TOP 1 MAX(TagIndex) AS MaximoTagIndex
                                    FROM DigTfunTAutTagTable
	                                GROUP BY DigTfunTAutTagTable.TagIndex
                                    ORDER BY TagIndex DESC
                                ), SecuenciaCTE AS (
                                    SELECT DISTINCT TOP (SELECT MaximoTagIndex FROM NumerosCTE) 
                                        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Numero
                                    FROM master..spt_values -- tabla auxiliar con la secuencia
                                )

                                SELECT Numero
                                FROM SecuenciaCTE
                                WHERE NOT EXISTS (
                                    SELECT 1
                                    FROM DigTfunTAutTagTable
                                    WHERE DigTfunTAutTagTable.TagIndex = SecuenciaCTE.Numero
                                );"

        If CheckBoxCcDigVal.Checked Then
            ' Busco TagIndex Libres
            Dim Ok As Boolean = False
            Ok = db.SelectDataTable(Sql, dtTagFree)
        End If

        Dim NewIndex As Integer
        NewIndex = Convert.ToInt64(db.selectstring("SELECT ISNULL(MAX(TagIndex), 0) + 1 AS SiguienteTagIndex FROM dbo.DigTfunTAutTagTable"))
        Dim NumOldIndex As Integer
        Dim IdFreeTagIndex As Integer = 0

        NumOldIndex = 0
        If dtTagFree.Rows.Count > 0 Then
            NumOldIndex = dtTagFree.Rows.Count
        End If

        Dim NumReg As Integer = 0

        For Each row As DataGridViewRow In dgv1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("checkBoxColumn").Value)
            If isSelected Then
                If dtTagFree.Rows.Count > 0 Then
                    If NumOldIndex > 0 Then
                        If db.executecommand("INSERT INTO [dbo].[DigTfunTAutTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(dtTagFree.Rows(IdFreeTagIndex)(0)) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If
                        NumOldIndex = NumOldIndex - 1
                        IdFreeTagIndex += 1
                    Else
                        If db.executecommand("INSERT INTO [dbo].[DigTfunTAutTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If

                        NewIndex += 1
                    End If
                Else
                    If db.executecommand("INSERT INTO [dbo].[DigTfunTAutTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                        dt.Rows.Add(row.Cells(1).Value, NewIndex)
                    Else
                        MessageBox.Show("Error en SQL Query >>> " & Sql)
                    End If
                    NewIndex += 1
                End If
            End If
        Next

        MiroDgv()
        txtBoxFilterDigTfunTAutTagTable.Text = ""
    End Sub

    Private Sub BtnBorrarDigVal_Click(sender As Object, e As EventArgs) Handles BtnBorrarDigVal.Click

        Dim ahoraInicio = selectedRow_dgvDigVal

        If Not String.IsNullOrEmpty(selectedRow_dgvDigVal) Then
            Dim ahora = selectedRow_dgvDigVal
            ' Extraer campos desde DataGridView
            Dim _Nombre As String = Convert.ToString(dgvDigVal.Rows(selectedRow_dgvDigVal).Cells(0).Value)
            Dim _Index As String = Convert.ToString(dgvDigVal.Rows(selectedRow_dgvDigVal).Cells(1).Value)
            Dim respuesta As DialogResult = MessageBox.Show("¿Esta seguro de borrar ? " & vbCrLf & " " & vbCrLf & "El Tag: ... " & vbCrLf & " " + _Nombre + " " & vbCrLf & "con IndexTag: ..." & vbCrLf & " " + _Index + "", "Confirmación", MessageBoxButtons.YesNo)

            If respuesta = DialogResult.Yes Then
                'Borro'
                If db.executecommand("DELETE FROM [dbo].[DigTfunTAutTagTable] WHERE [TagName] = '" + _Nombre + "' and [TagIndex] = " + _Index + " ") Then
                    MiroDgv()
                    Return
                Else
                    MessageBox.Show("Error en SQL al borrar.")
                End If


            ElseIf respuesta = DialogResult.No Then
                Return
            End If
        Else
            MessageBox.Show("Seleccione primero el dato a borrar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        txtBoxFilterDigTfunTAutTagTable.Text = ""

    End Sub

    Private Sub BtnInsertarDigMan_Click(sender As Object, e As EventArgs) Handles BtnInsertarDigMan.Click

        Dim dt As New DataTable()

        dt = dgvDigMan.DataSource

        Dim dtTagFree As New DataTable()

        Dim Sql As String = "WITH NumerosCTE AS (
                                    SELECT TOP 1 MAX(TagIndex) AS MaximoTagIndex
                                    FROM DigNmanTAutTagTable
	                                GROUP BY DigNmanTAutTagTable.TagIndex
                                    ORDER BY TagIndex DESC
                                ), SecuenciaCTE AS (
                                    SELECT DISTINCT TOP (SELECT MaximoTagIndex FROM NumerosCTE) 
                                        ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS Numero
                                    FROM master..spt_values -- tabla auxiliar con la secuencia
                                )

                                SELECT Numero
                                FROM SecuenciaCTE
                                WHERE NOT EXISTS (
                                    SELECT 1
                                    FROM DigNmanTAutTagTable
                                    WHERE DigNmanTAutTagTable.TagIndex = SecuenciaCTE.Numero
                                );"

        If CheckBoxCcDigMan.Checked Then
            ' Busco TagIndex Libres
            Dim Ok As Boolean = False
            Ok = db.SelectDataTable(Sql, dtTagFree)
        End If

        Dim NewIndex As Integer
        NewIndex = Convert.ToInt64(db.selectstring("SELECT ISNULL(MAX(TagIndex), 0) + 1 AS SiguienteTagIndex FROM dbo.DigNmanTAutTagTable"))
        Dim NumOldIndex As Integer
        Dim IdFreeTagIndex As Integer = 0

        NumOldIndex = 0
        If dtTagFree.Rows.Count > 0 Then
            NumOldIndex = dtTagFree.Rows.Count
        End If

        Dim NumReg As Integer = 0

        For Each row As DataGridViewRow In dgv1.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("checkBoxColumn").Value)
            If isSelected Then
                If dtTagFree.Rows.Count > 0 Then
                    If NumOldIndex > 0 Then
                        If db.executecommand("INSERT INTO [dbo].[DigNmanTAutTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(dtTagFree.Rows(IdFreeTagIndex)(0)) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If
                        NumOldIndex = NumOldIndex - 1
                        IdFreeTagIndex += 1
                    Else
                        If db.executecommand("INSERT INTO [dbo].[DigNmanTAutTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                            dt.Rows.Add(row.Cells(1).Value, NewIndex)
                        Else
                            MessageBox.Show("Error en SQL Query >>> " & Sql)
                        End If

                        NewIndex += 1
                    End If
                Else
                    If db.executecommand("INSERT INTO [dbo].[DigNmanTAutTagTable] ([TagName] ,[TagIndex] ,[TagType] ,[TagDataType])
                                                VALUES ('" + Convert.ToString(row.Cells(2).Value) + "' , " + Convert.ToString(NewIndex) + " , 0 , 0)") Then
                        dt.Rows.Add(row.Cells(1).Value, NewIndex)
                    Else
                        MessageBox.Show("Error en SQL Query >>> " & Sql)
                    End If
                    NewIndex += 1
                End If
            End If
        Next

        MiroDgv()
        txtBoxFilterDigNmanTAutTagTable.Text = ""
    End Sub

    Private Sub BtnBorrarDigMan_Click(sender As Object, e As EventArgs) Handles BtnBorrarDigMan.Click

        Dim ahoraInicio = selectedRow_dgvDigMan

        If Not String.IsNullOrEmpty(selectedRow_dgvDigMan) Then
            Dim ahora = selectedRow_dgvDigMan
            ' Extraer campos desde DataGridView
            Dim _Nombre As String = Convert.ToString(dgvDigMan.Rows(selectedRow_dgvDigMan).Cells(0).Value)
            Dim _Index As String = Convert.ToString(dgvDigMan.Rows(selectedRow_dgvDigMan).Cells(1).Value)
            Dim respuesta As DialogResult = MessageBox.Show("¿Esta seguro de borrar ? " & vbCrLf & " " & vbCrLf & "El Tag: ... " & vbCrLf & " " + _Nombre + " " & vbCrLf & "con IndexTag: ..." & vbCrLf & " " + _Index + "", "Confirmación", MessageBoxButtons.YesNo)

            If respuesta = DialogResult.Yes Then
                'Borro'
                If db.executecommand("DELETE FROM [dbo].[DigNmanTAutTagTable] WHERE [TagName] = '" + _Nombre + "' and [TagIndex] = " + _Index + " ") Then
                    MiroDgv()
                    Return
                Else
                    MessageBox.Show("Error en SQL al borrar.")
                End If


            ElseIf respuesta = DialogResult.No Then
                Return
            End If
        Else
            MessageBox.Show("Seleccione primero el dato a borrar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        txtBoxFilterDigNmanTAutTagTable.Text = ""
    End Sub

    Private Sub frmUtilTagsImport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not IsNothing(Application.OpenForms("FormMain")) Then
            Dim mainForm As FormMain = DirectCast(Application.OpenForms("FormMain"), FormMain)
            mainForm.ButtonImportTIAPORTAL.Visible = False
        End If
    End Sub



    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick ''''
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            dgv1.Rows(e.RowIndex).Cells(1).Value = Not CBool(dgv1.Rows(e.RowIndex).Cells(1).Value)

            Dim imageName As String
            If CBool(dgv1.Rows(e.RowIndex).Cells(1).Value) Then
                imageName = "yes"
            Else
                imageName = "no"
            End If

            Dim image As Image = DirectCast(My.Resources.ResourceManager.GetObject(imageName), Image)
            dgv1.Rows(e.RowIndex).Cells(0).Value = image
        End If
    End Sub

    Private Sub txtBoxFilter_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBoxFilter.KeyUp
        FilterDGV(dgv1, sender.text)
    End Sub

    Private Sub txtBoxFilterAnaVinsTagTable_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBoxFilterAnaVinsTagTable.KeyUp
        FilterDGV(dgvAnaVal, sender.text)
    End Sub

    Private Sub txtBoxFilterAnaVtotTagTable_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBoxFilterAnaVtotTagTable.KeyUp
        FilterDGV(dgvAnaTot, sender.text)
    End Sub

    Private Sub txtBoxFilterDigTfunTAutTagTable_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBoxFilterDigTfunTAutTagTable.KeyUp
        FilterDGV(dgvDigVal, sender.text)
    End Sub

    Private Sub txtBoxFilterDigNmanTAutTagTable_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBoxFilterDigNmanTAutTagTable.KeyUp
        FilterDGV(dgvDigMan, sender.text)
    End Sub

    Private Sub dgvAnaVal_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnaVal.CellClick
        selectedRow_dgvAnaVal = Convert.ToString(e.RowIndex)
    End Sub

    Private Sub dgvAnaTot_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnaTot.CellClick
        selectedRow_dgvAnaTot = Convert.ToString(e.RowIndex)
    End Sub

    Private Sub dgvDigVal_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDigVal.CellClick
        selectedRow_dgvDigVal = Convert.ToString(e.RowIndex)
    End Sub

    Private Sub dgvDigMan_CellClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDigMan.CellClick
        selectedRow_dgvDigMan = Convert.ToString(e.RowIndex)
    End Sub

    Private Sub TimerDgv_Tick(sender As Object, e As EventArgs) Handles TimerDgv.Tick
        If dgvAnaVal.Rows.Count > 0 Then
            dgvAnaVal.Rows(0).Selected = False
            dgvAnaVal.Columns(0).Selected = False
        End If

        If dgvAnaTot.Rows.Count > 0 Then
            dgvAnaTot.Rows(0).Selected = False
            dgvAnaTot.Columns(0).Selected = False
        End If

        If dgvDigVal.Rows.Count > 0 Then
            dgvDigVal.Rows(0).Selected = False
            dgvDigVal.Columns(0).Selected = False
        End If

        If dgvDigMan.Rows.Count > 0 Then
            dgvDigMan.Rows(0).Selected = False
            dgvDigMan.Columns(0).Selected = False
        End If
        TimerDgv.Enabled = False

    End Sub
End Class

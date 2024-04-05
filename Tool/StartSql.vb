Imports System.Runtime.InteropServices
Imports Microsoft.ReportingServices.Rendering.ExcelOpenXmlRenderer.Rels

Module StartSql
    Public Function StartSqlCheq(<Out> ByRef OutputTable As String, <Out> ByRef OutputDataTable As DataTable, <Out> ByRef OutputType As Integer) As Boolean
        Dim result As Boolean = False
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim Ok As Boolean = False

        Dim TablesTagReport As New DataTable()
        TablesTagReport.Columns.Add("TableTag", GetType(String))
        TablesTagReport.Columns.Add("TableReport", GetType(String))

        TablesTagReport.Rows.Add("AnaVinsTagTable", "AnaVinsReportTable")
        TablesTagReport.Rows.Add("AnaVtotTagTable", "AnaVtotReportTable")
        TablesTagReport.Rows.Add("DigTfunTAutTagTable", "DigTfunTAutReportTable")
        TablesTagReport.Rows.Add("DigNmanTAutTagTable", "DigNmanTAutReportTable")

        Dim DataTableTag As DataTable = Nothing
        Dim DataTableReport As DataTable = Nothing
        OutputTable = "SinTabla"
        OutputDataTable = Nothing
        OutputType = 99

        Dim SqlByTag As String = "Select [TagIndex], [TagName] FROM [dbo].[@Table] Order by [TagIndex]"

        Dim SqlByReportBefore As String = "If Not EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '@Table' AND COLUMN_NAME = 'Archive')
                                    BEGIN
                                        ALTER TABLE [dbo].[@Table] ADD [Archive] BIT NULL;
                                    End"

        Dim SqlByReport As String = "Select [TagIndex], [TagName], [TagDescription], [TagUnit]
                                    From [dbo].[@Table]
                                    Where [Archive] Is NULL Or [Archive] = 0
                                    Order By [TagIndex];"
        Try
            For Each row As DataRow In TablesTagReport.Rows
                Dim sqlTag As String = SqlByTag.Replace("[dbo].[@Table]", "[dbo].[" & row("TableTag").ToString() & "]")
                Ok = db.SelectDataTable(sqlTag, DataTableTag)
                Dim SqlReportBefore As String = SqlByReportBefore.Replace("@Table", row("TableReport").ToString())
                Dim sqlReport As String = SqlByReport.Replace("[dbo].[@Table]", "[dbo].[" & row("TableReport").ToString() & "]")

                If row("TableReport").ToString().Contains("Dig") Then
                    sqlReport = sqlReport.Replace(", [TagUnit]", "")
                End If

                If db.executecommand(SqlReportBefore) Then
                Else
                End If

                Ok = db.SelectDataTable(sqlReport, DataTableReport)
                Dim rowsTag As Integer = If(DataTableTag IsNot Nothing, DataTableTag.Rows.Count, 0)
                Dim rowsReport As Integer = If(DataTableReport IsNot Nothing, DataTableReport.Rows.Count, 0)

                If rowsTag = rowsReport Then
                    'Caso 0: El número de filas es igual en ambas tablas
                    OutputType = 0
                    OutputTable = row("TableReport")
                    Ok = True
                    Try
                        ' Comparamos si son iguales los campos TagName
                        For Each rowTag As DataRow In DataTableTag.Rows
                            Dim tagIndexTag As Integer = Convert.ToInt32(rowTag("TagIndex"))
                            Dim tagNameTag As String = rowTag("TagName").ToString()

                            For Each rowReport As DataRow In DataTableReport.Rows
                                Dim tagIndexReport As Integer = Convert.ToInt32(rowReport("TagIndex"))
                                Dim tagNameReport As String = rowReport("TagName").ToString()

                                If tagIndexTag = tagIndexReport AndAlso Not String.Equals(tagNameTag, tagNameReport) Then
                                    If OutputDataTable Is Nothing Then
                                        OutputDataTable = New DataTable()
                                        OutputDataTable.Columns.Add("TagIndex", GetType(Integer))
                                        OutputDataTable.Columns.Add("TagName", GetType(String))
                                        OutputDataTable.Columns.Add("TagDescription", GetType(String))
                                        If Not row("TableReport").ToString().Contains("Dig") Then
                                            OutputDataTable.Columns.Add("TagUnit", GetType(String))
                                        End If
                                    End If

                                    'Añado fila difente
                                    Dim newRow As DataRow = OutputDataTable.NewRow()
                                    newRow("TagIndex") = tagIndexTag
                                    newRow("TagName") = tagNameTag
                                    newRow("TagDescription") = ""
                                    If Not row("TableReport").ToString().Contains("Dig") Then
                                        newRow("TagUnit") = ""
                                    End If
                                    OutputDataTable.Rows.Add(newRow)
                                    OutputType = 3
                                    Ok = False
                                    Exit For
                                End If
                            Next
                        Next
                        OutputType = OutputType
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                    End Try

                ElseIf rowsReport > rowsTag Then
                    'Caso 1: El número de filas en la  ReportTable es mayor que en la TagTable
                    FilterRowsByTagIndex1(DataTableReport, DataTableTag) 'Obtenemos las filas que sobran
                    OutputType = 1
                    OutputTable = row("TableReport")
                    OutputDataTable = DataTableReport
                    Ok = False
                    Exit For

                ElseIf rowsTag > rowsReport Then
                    'Caso 2: El número de filas en la TagTable es mayor que en la ReportTable
                    FilterRowsByTagIndex2(DataTableReport, DataTableTag, OutputTable) 'Obtenemos las filas que faltan
                    OutputType = 2
                    OutputTable = row("TableReport")
                    OutputDataTable = DataTableTag
                    Ok = False
                    Exit For
                End If
                OutputType = 0
                OutputTable = row("TableReport")
            Next
        Catch
        Finally
        End Try
        OutputType = OutputType
        OutputTable = OutputTable
        Return Ok
    End Function
    Private Sub FilterRowsByTagIndex1(ByRef dataTableReport As DataTable, ByVal dataTableTag As DataTable)
        'TagIndex que no existe en DataTableTag
        Dim tagIndexList As List(Of Object) = dataTableTag.AsEnumerable().Select(Function(row) row("TagIndex")).ToList()

        Dim rowsToDelete As New List(Of DataRow)
        For Each rowReport As DataRow In dataTableReport.Rows
            Dim tagIndexReport = rowReport("TagIndex")

            If tagIndexList.Contains(tagIndexReport) Then
                rowsToDelete.Add(rowReport)
            End If
        Next

        For Each rowToDelete In rowsToDelete
            dataTableReport.Rows.Remove(rowToDelete)
        Next
    End Sub
    Private Sub FilterRowsByTagIndex2(ByVal dataTableReport As DataTable, ByRef dataTableTag As DataTable, ByRef OutputTable As String)
        'Valores de TagIndex
        Dim tagIndexSet As New HashSet(Of Integer)(dataTableReport.AsEnumerable().Select(Function(row) Convert.ToInt32(row("TagIndex"))))
        'TagIndex que no existen en ReportTable
        Dim filteredRows As IEnumerable(Of DataRow) = dataTableTag.AsEnumerable().Where(
        Function(row) Not tagIndexSet.Contains(Convert.ToInt32(row("TagIndex")))
        )
        Dim resultTable As New DataTable()
        resultTable.Columns.Add("TagIndex", GetType(Integer))
        resultTable.Columns.Add("TagName", GetType(String))
        resultTable.Columns.Add("TagDescription", GetType(String))
        If Not OutputTable.ToString().Contains("Dig") Then
            resultTable.Columns.Add("TagUnit", GetType(String))
        End If
        'Filas que no existen en ReportTable
        For Each filteredRow In filteredRows
            Dim newRow As DataRow = resultTable.NewRow()
            newRow("TagIndex") = Convert.ToInt32(filteredRow("TagIndex"))
            newRow("TagName") = filteredRow("TagName").ToString()
            newRow("TagDescription") = String.Empty
            If Not OutputTable.ToString().Contains("Dig") Then
                newRow("TagUnit") = String.Empty
            End If
            resultTable.Rows.Add(newRow)
        Next
        dataTableTag = resultTable
    End Sub
    Public Function DoesColumnExist(tableName As String, columnName As String) As Boolean
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim sql = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & tableName & "' AND COLUMN_NAME = '" & columnName & "'"
        Dim count As Integer = Convert.ToInt32(db.ExecuteScalar(sql))
        Return count > 0
    End Function
End Module

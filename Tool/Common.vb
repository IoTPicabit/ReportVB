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


Module Common
    Public formParameters As New Dictionary(Of String, Dictionary(Of String, String))() 'Se utiliza para la visualización parametrizada del formulario
    Public Sub InitFormParameters()
        formParameters.Add("SignalsType", New Dictionary(Of String, String) From {
            {"Equipment", "equipos"},
            {"Signals", "señales"}
        })

        formParameters.Add("SavedTemplatesFileName", New Dictionary(Of String, String) From {
            {"Equipment", "Templates_Equipment.bin"},
            {"Signals", "Templates_Signals.bin"}
        })

        formParameters.Add("MainDataName", New Dictionary(Of String, String) From {
            {"Equipment", "Horas de funcionamiento"},
            {"Signals", "Señales analógicas"}
        })

        formParameters.Add("SecondaryDataName", New Dictionary(Of String, String) From {
            {"Equipment", "Número de maniobras"},
            {"Signals", "Totalizadores"}
        })

        formParameters.Add("Query1", New Dictionary(Of String, String) From {
            {"Equipment", "Número de maniobras"},
            {"Signals", "Totalizadores"}
        })
    End Sub
    Public Function GetFormParameter(ByVal nombreParametro As String, ByVal tipo As String) As String
        If formParameters.ContainsKey(nombreParametro) AndAlso formParameters(nombreParametro).ContainsKey(tipo) Then
            Return formParameters(nombreParametro)(tipo)
        Else
            Return "NotFound"
        End If
    End Function
    Public Sub ExportarDtToBin(dataTable As DataTable, rutaArchivo As String)
        Try
            Dim Total As Integer = dataTable.Columns.Count
            Dim NumCol As Integer = 1

            Using writer As New StreamWriter(rutaArchivo)
                For Each columna As DataColumn In dataTable.Columns
                    writer.Write(columna.ColumnName)
                    If NumCol <> Total Then
                        writer.Write(vbTab)
                    End If
                    NumCol = NumCol + 1
                Next
                writer.WriteLine()

                For Each fila As DataRow In dataTable.Rows
                    NumCol = 1
                    For Each columna As DataColumn In dataTable.Columns
                        writer.Write(fila(columna))
                        If NumCol <> Total Then
                            writer.Write(vbTab)
                        End If
                        NumCol = NumCol + 1
                    Next
                    writer.WriteLine()
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al exportar plantillas a fichero: " & ex.Message)
        End Try
    End Sub
    Public Function CreateDtConsultasAna() As DataTable

        Dim DtConsultas As New DataTable()

        DtConsultas.Columns.Add("Id", GetType(String))
        DtConsultas.Columns.Add("Consulta", GetType(String))
        DtConsultas.Columns.Add("SeñalesAnalogicas", GetType(String))
        DtConsultas.Columns.Add("Totalizadores", GetType(String))
        DtConsultas.Columns.Add("MostrarValoresIniciales", GetType(String))
        DtConsultas.Columns.Add("MostrarValoresFinales", GetType(String))
        DtConsultas.Columns.Add("IncluirTotalizadores", GetType(String))
        DtConsultas.Columns.Add("Diario", GetType(String))
        DtConsultas.Columns.Add("Semanal", GetType(String))
        DtConsultas.Columns.Add("Mensual", GetType(String))
        DtConsultas.Columns.Add("Libre", GetType(String))
        DtConsultas.Columns.Add("PorHoras", GetType(String))
        DtConsultas.Columns.Add("PorDias", GetType(String))
        DtConsultas.Columns.Add("DesdeDia", GetType(String))
        DtConsultas.Columns.Add("DesdeHora", GetType(String))
        DtConsultas.Columns.Add("HastaDia", GetType(String))
        DtConsultas.Columns.Add("HastaHora", GetType(String))
        DtConsultas.Columns.Add("APdf", GetType(String))
        DtConsultas.Columns.Add("APantalla", GetType(String))
        DtConsultas.Columns.Add("X", GetType(String))
        DtConsultas.Columns.Add("Tags", GetType(String))
        DtConsultas.Columns.Add("SaveDates", GetType(Boolean))

        Return DtConsultas
    End Function
    Public Function CreateDtQuery() As DataTable

        Dim DtConsultas As New DataTable()
        DtConsultas.Columns.Add("Id", GetType(String))
        DtConsultas.Columns.Add("Consulta", GetType(String))
        DtConsultas.Columns.Add("MainData", GetType(String))
        DtConsultas.Columns.Add("SecondaryData", GetType(String))
        DtConsultas.Columns.Add("MostrarValoresIniciales", GetType(String))
        DtConsultas.Columns.Add("MostrarValoresFinales", GetType(String))
        DtConsultas.Columns.Add("IncludeDataTot", GetType(String))
        DtConsultas.Columns.Add("Diario", GetType(String))
        DtConsultas.Columns.Add("Semanal", GetType(String))
        DtConsultas.Columns.Add("Mensual", GetType(String))
        DtConsultas.Columns.Add("Libre", GetType(String))
        DtConsultas.Columns.Add("PorHoras", GetType(String))
        DtConsultas.Columns.Add("PorDias", GetType(String))
        DtConsultas.Columns.Add("DesdeDia", GetType(String))
        DtConsultas.Columns.Add("DesdeHora", GetType(String))
        DtConsultas.Columns.Add("HastaDia", GetType(String))
        DtConsultas.Columns.Add("HastaHora", GetType(String))
        DtConsultas.Columns.Add("APdf", GetType(String))
        DtConsultas.Columns.Add("APantalla", GetType(String))
        DtConsultas.Columns.Add("X", GetType(String))
        DtConsultas.Columns.Add("Tags", GetType(String))
        DtConsultas.Columns.Add("SaveDates", GetType(Boolean))

        Return DtConsultas
    End Function
    Public Function LoadBintToDT(ByVal filePath As String) As DataTable
        'Esta función se utiliza para cargar plantillas almacenadas en fichero
        Dim tabla As New DataTable()
        Dim DtConsultas As New DataTable()

        DtConsultas = CreateDtQuery()
        tabla = DtConsultas
        Dim rowOrdered As String()

        If File.Exists(filePath) Then
            Try
                Using sr As New StreamReader(filePath)
                    Dim encabezados As String() = sr.ReadLine().Split(vbTab) 'RPM
                    If encabezados.Count > 0 And tabla.Columns.Count > 0 Then
                        While Not sr.EndOfStream
                            Dim row As String() = sr.ReadLine().Split(vbTab)
                            rowOrdered = Nothing
                            ReDim rowOrdered(row.Count - 1)
                            For i As Integer = 0 To encabezados.Count - 1
                                For j As Integer = 0 To tabla.Columns.Count - 1
                                    If tabla.Columns(j).ColumnName = encabezados(i) Then
                                        rowOrdered(j) = row(i)
                                    End If
                                Next
                            Next
                            tabla.Rows.Add(rowOrdered)
                        End While
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error al cargar el archivo de consultas: " & ex.Message)
            End Try
        End If

        Return tabla
    End Function
    Public Sub OpenReport(ByVal sfile As String)

        Dim psi As New ProcessStartInfo

        With psi
            .FileName = sfile
            .UseShellExecute = True
        End With

        System.Diagnostics.Process.Start(psi)
    End Sub
    Public Function ConsultaToDt(ByVal SqlBase As String, ByVal SqlIndexOut As String, ByVal SqlIn As String, <Out> ByRef IndexOutOk As String, <Out> ByRef RecIndex As DataTable, <Out> ByRef dataTable As DataTable) As Boolean
        Dim result As Boolean = False
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim Ok As Boolean = False

        IndexOutOk = ""

        Try
            Dim OkIndex As Boolean
            Dim Sql1 As String
            Dim SqlOut As String = "use ✏️;"

            OkIndex = db.SelectDataTable(SqlIndexOut, RecIndex)
            Dim count2 As Integer = RecIndex.Rows.Count
            Dim iIndex As Integer = 0
            If OkIndex Then
                While count2 > 0
                    count2 = count2 - 1
                    IndexOutOk = IndexOutOk + RecIndex.Rows(iIndex)("TagIndexOut").ToString() + ","
                    iIndex = iIndex + 1
                End While
                IndexOutOk = IndexOutOk.Trim(",".ToCharArray())
            End If
            Sql1 = SqlBase.Replace(SqlOut, SqlIn)
            Ok = db.SelectDataTable(Sql1, dataTable)
        Catch
        Finally
        End Try
        Return Ok
    End Function
    Public Function BringDt(FormType As String, TypeTags As String, Info As String, InitialDate As Date, FinalDate As Date, Type As Int32, Type2 As Int32, Mode As Int32, FileOut As String, <Out> ByRef RecIndex As DataTable, <Out> ByRef dataTable1 As DataTable, <Out> ByRef dataTable2 As DataTable) As Boolean
        Dim result As Boolean = False
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim Ok As Boolean = False
        Dim IndexOutOk As String = ""

        Dim SqlIndexOut = ""
        Dim SqlBase = ""

        If FormType = "Equipment" Then
            SqlIndexOut = Datos.SqlIndexOutDig
            SqlIndexOut = SqlIndexOut.Replace("TagsOk", "'" + TypeTags + "'")
            SqlBase = Datos.SQLCommandStringData_dsDigital
        End If

        If FormType = "Signals" Then
            SqlIndexOut = Datos.SqlIndexOutAna
            SqlIndexOut = SqlIndexOut.Replace("TagsOk", "'" + TypeTags + "'")
            SqlBase = Datos.SQLCommandStringData_dsAnalog
        End If

        Try
            Dim OkIndex As Boolean
            Dim Sql1 As String
            Dim Sql2 As String
            Dim SqlOut As String = "use ✏️;"

            OkIndex = db.SelectDataTable(SqlIndexOut, RecIndex)
            Dim count2 As Integer = RecIndex.Rows.Count
            Dim iIndex As Integer = 0
            If OkIndex Then
                While count2 > 0
                    count2 = count2 - 1
                    IndexOutOk = IndexOutOk + RecIndex.Rows(iIndex)("TagIndexOut").ToString() + ","
                    iIndex = iIndex + 1
                End While
                IndexOutOk = IndexOutOk.Trim(",".ToCharArray())
            End If

            Dim SqlIn As String = Datos.SqlIn
            'SqlIn = SqlIn.Replace("StartDate", "'" + InitialDate + "'")
            SqlIn = SqlIn.Replace("StartDate", "'" + InitialDate.ToString("yyyy-MM-dd HH:mm:ss") + "'")
            'SqlIn = SqlIn.Replace("EndDate", "'" + FinalDate + "'")
            SqlIn = SqlIn.Replace("EndDate", "'" + FinalDate.ToString("yyyy-MM-dd HH:mm:ss") + "'")
            SqlIn = SqlIn.Replace("TagsOk", "'" + TypeTags + "'")
            SqlIn = SqlIn.Replace("Range", "" + Convert.ToString(Type) + "")

            Sql1 = SqlBase.Replace(SqlOut, SqlIn)

            Ok = db.SelectDataTable(Sql1, dataTable1)

            SqlIn = Datos.SqlIn
            'SqlIn = SqlIn.Replace("StartDate", "'" + InitialDate + "'")
            SqlIn = SqlIn.Replace("StartDate", "'" + InitialDate.ToString("yyyy-MM-dd HH:mm:ss") + "'")
            'SqlIn = SqlIn.Replace("EndDate", "'" + FinalDate + "'")
            SqlIn = SqlIn.Replace("EndDate", "'" + FinalDate.ToString("yyyy-MM-dd HH:mm:ss") + "'")
            SqlIn = SqlIn.Replace("TagsOk", "'" + IndexOutOk + "'")
            SqlIn = SqlIn.Replace("Range", "" + Convert.ToString(Type2) + "")

            Sql2 = SqlBase.Replace(SqlOut, SqlIn)

            Ok = db.SelectDataTable(Sql2, dataTable2)
        Catch ex As Exception
            MessageBox.Show("Error al generar query: " & ex.Message)
        Finally
        End Try
        Return Ok
    End Function
    Public Function GrowDt(ByRef dt1 As DataTable, ByRef dt2 As DataTable) As DataTable

        Dim dtOut As DataTable = dt1.Copy
        Try
            For Each column As DataColumn In dt2.Columns
                dtOut.Columns.Add(column.ColumnName, column.DataType)
            Next
        Catch ex As Exception
            MessageBox.Show("Error = " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
        Return dtOut
    End Function
    Public Function AllDt(ByVal TagNameOutKey As String, ByVal Columnas As String(), ByRef dtOut As DataTable, ByRef RecIndex As DataTable, ByRef dt2 As DataTable, ByVal Modo As String) As DataTable
        Try
            Dim TagIndexIn As Integer = -1
            Dim TagIndexOut As Integer = -1
            Dim TagNameOut As String = ""
            Dim DayOut As String = ""

            If Modo = "Day" Then
                For Each row As DataRow In dtOut.Rows
                    TagIndexIn = -1
                    DayOut = ""

                    TagIndexIn = row("TagIndex").ToString
                    DayOut = row("Day").ToString

                    For Each row2 As DataRow In RecIndex.Rows
                        TagIndexOut = -1
                        TagNameOut = ""
                        If (TagIndexIn = row2("TagIndex").ToString) Then
                            If Not IsDBNull(row2("TagIndexOut")) Then
                                TagIndexOut = row2("TagIndexOut").ToString()
                                TagNameOut = row2("TagNameOut").ToString
                            End If

                            Exit For
                        End If
                    Next

                    For Each row3 As DataRow In dt2.Rows
                        If (TagIndexOut = row3("TagIndexT").ToString) Then
                            If (TagNameOut = row3("TagOnlyNameT").ToString + TagNameOutKey) Then
                                If (DayOut = row3("DayT").ToString) Then
                                    'Copiamos valores según la columna
                                    For Each colName As String In Columnas
                                        If row.Table.Columns.Contains(colName) AndAlso row3.Table.Columns.Contains(colName) Then
                                            row(colName) = row3(colName)
                                        End If
                                    Next
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                Next
            End If

            If Modo = "Week" OrElse Modo = "Month" Then
                For Each row As DataRow In dtOut.Rows
                    TagIndexIn = -1
                    DayOut = ""

                    TagIndexIn = row("TagIndex").ToString

                    For Each row2 As DataRow In RecIndex.Rows
                        TagIndexOut = -1
                        TagNameOut = ""
                        If (TagIndexIn = row2("TagIndex").ToString) Then
                            If Not IsDBNull(row2("TagIndexOut")) Then
                                TagIndexOut = row2("TagIndexOut").ToString()
                                TagNameOut = row2("TagNameOut").ToString
                            End If
                            Exit For
                        End If
                    Next

                    For Each row3 As DataRow In dt2.Rows
                        If (TagIndexOut = row3("TagIndexT").ToString) Then
                            If (TagNameOut = row3("TagOnlyNameT").ToString + TagNameOutKey) Then
                                For Each colName As String In Columnas
                                    If row.Table.Columns.Contains(colName) AndAlso row3.Table.Columns.Contains(colName) Then
                                        row(colName) = row3(colName)
                                    End If
                                Next
                                Exit For
                            End If
                        End If
                    Next
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error = " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
        Return dtOut
    End Function
    Public Function FillOutDt(FormType As String, ByRef RecIndex As DataTable, ByRef dtAll As DataTable, ByRef TagIndexTable As DataTable) As Boolean
        Dim result As Boolean = False
        Dim Ok As Boolean = False

        If Not dtAll.Columns.Contains("TagIndex") Then dtAll.Columns.Add("TagIndex", GetType(String))
        If Not dtAll.Columns.Contains("TagName") Then dtAll.Columns.Add("TagName", GetType(String))
        If Not dtAll.Columns.Contains("TagDescription") Then dtAll.Columns.Add("TagDescription", GetType(String))
        If Not dtAll.Columns.Contains("TagIndexT") Then dtAll.Columns.Add("TagIndexT", GetType(String))
        If Not dtAll.Columns.Contains("TagNameT") Then dtAll.Columns.Add("TagNameT", GetType(String))
        If Not dtAll.Columns.Contains("TagDescriptionT") Then dtAll.Columns.Add("TagDescriptionT", GetType(String))

        For Each row As DataRow In RecIndex.Rows
            Dim tagIndexValue As String = row("TagIndex").ToString()

            Dim existingRow As DataRow() = dtAll.Select("TagIndex = '" & tagIndexValue & "'")

            If existingRow.Length = 0 Then
                Dim newRow As DataRow = dtAll.NewRow()

                newRow("TagIndex") = row("TagIndex")
                newRow("TagName") = row("TagName")

                If FormType = "Signals" Then
                    Dim matchingRow As DataRow = TagIndexTable.AsEnumerable().FirstOrDefault(Function(r) Convert.ToInt32(r("TagIndex")) = tagIndexValue)
                    If matchingRow IsNot Nothing AndAlso Not matchingRow.IsNull("TagDescription") Then
                        newRow("TagDescription") = matchingRow("TagDescription")
                    End If

                    newRow("TagIndexT") = row("TagIndex")
                    newRow("TagNameT") = row("TagName")

                    If matchingRow IsNot Nothing AndAlso Not matchingRow.IsNull("TagDescription") Then
                        newRow("TagDescriptionT") = matchingRow("TagDescription")
                    End If
                Else ' FormType = "Equipment"
                    newRow("TagDescription") = row("TagDescription")
                    newRow("TagIndexT") = row("TagIndex")
                    newRow("TagNameT") = row("TagName")
                    newRow("TagDescriptionT") = row("TagDescription")
                End If
                dtAll.Rows.Add(newRow)
            End If
        Next
        Return Ok
    End Function
    Public Sub GenerateReport(ByVal RePoRt As XtraReport, ByVal dtOut As DataTable, ByVal InitialDate As Date, ByVal FinalDate As Date, ByVal Type As Int32, ByVal Mode As Int32, ByVal FileOut As String)
        RePoRt.DataSource = dtOut

        Dim parameter0 As New Parameter()
        parameter0.Name = "NombreInstalacion"
        parameter0.Type = GetType(System.String)
        parameter0.Value = Datos.NombreInstalacion
        parameter0.Visible = False
        RePoRt.Parameters.Add(parameter0)

        Dim parameter1 As New Parameter()
        parameter1.Name = "FechaIni"
        parameter1.Type = GetType(System.DateTime)
        parameter1.Value = InitialDate
        parameter1.Visible = False
        RePoRt.Parameters.Add(parameter1)

        Dim parameter2 As New Parameter()
        parameter2.Name = "FechaFin"
        parameter2.Type = GetType(System.DateTime)
        parameter2.Value = FinalDate
        parameter2.Visible = False
        RePoRt.Parameters.Add(parameter2)

        RePoRt.RequestParameters = False

        Select Case Mode
            Case 0
                Dim tool As ReportPrintTool = New ReportPrintTool(RePoRt)
                tool.ShowPreview()

            Case 1
                RePoRt.ExportToPdf(FileOut)
                OpenReport(FileOut)

            Case 2
                Dim tool As ReportPrintTool = New ReportPrintTool(RePoRt)
                Dim xlsxExportOptions As New XlsxExportOptions() With {.ExportMode = XlsxExportMode.SingleFile, .ShowGridLines = True, .FitToPrintedPageHeight = True}
                Dim xlsxExportFile As String = FileOut.Replace(".pdf", ".xlsx")
                RePoRt.ExportToXlsx(xlsxExportFile, xlsxExportOptions)
                Try
                    OpenReport(xlsxExportFile)
                Catch ex As Exception
                    MessageBox.Show("Error = " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
        End Select
    End Sub
    Public Function CheckTables(dataTable As DataTable) As Boolean
        Dim TablesToReview As String() = Datos.TablesToReview

        For Each tabla In TablesToReview
            If Not TableExistsInDataTable(tabla, dataTable) Then
                Return False
            End If
        Next
        Return True
    End Function
    Function TableExistsInDataTable(tabla As String, dataTable As DataTable) As Boolean
        For Each row As DataRow In dataTable.Rows
            If row("TABLE_NAME").ToString() = tabla Then
                Return True
            End If
        Next
        Return False
    End Function

End Module

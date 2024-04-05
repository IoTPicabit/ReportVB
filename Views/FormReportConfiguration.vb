#Region "NameSpace"
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows
Imports DevExpress.Utils.Drawing.Helpers.NativeMethods
Imports DevExpress.XtraGauges.Win.Gauges
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraRichEdit.API.Layout
Imports DocumentFormat.OpenXml.Presentation


#End Region 'NameSpace

Public Class FormReportConfiguration
    Private _formType As String = "Signals"
    Private _formTypeParameter As Integer
    ' Lista para almacenar el estado original de los controles
    Public listOriginalEnabledStates As New List(Of KeyValuePair(Of String, Boolean))

    Public ReadOnly Property formTypeParameter As Integer
        Get
            Return _formTypeParameter
        End Get
    End Property

#Region "Start"
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(formTypeParameter) '
        InitializeComponent()
        _formTypeParameter = formTypeParameter
        If _formTypeParameter = 0 Then
            _formType = "Signals"
        Else
            _formType = "Equipment"
        End If
        FrmLoad()
    End Sub

    Sub FrmLoad()
        ComBoxTemplates.DropDownStyle = ComboBoxStyle.DropDownList
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
        dgv.ClearSelection()
        BindGrid()
        LabelTitle.Text = "Informe de " & GetFormParameter("SignalsType", _formType)
        RadioBtnMainData.LabelText = GetFormParameter("MainDataName", _formType)
        RadioBtnSecondaryData.LabelText = GetFormParameter("SecondaryDataName", _formType)
        DT_Templates = LoadBintToDT(GetFormParameter("SavedTemplatesFileName", _formType))

        LoadTemplatesComboBox(DT_Templates)
        CreateImgCheck()

        dTPickerDateFrom.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
        dTPickerDateTo.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
        dTPickerHourFrom.Value = Convert.ToDateTime("00:00:00")
        dTPickerHourTo.Value = Convert.ToDateTime("23:59:59")

        FillControlsFromSettings()

    End Sub
    Private Sub TimerInicio_Tick(sender As Object, e As EventArgs) Handles TimerInicio.Tick
        ReDim valoresOK(dgv.Rows.Count - 1)
        For i As Integer = 0 To dgv.Rows.Count - 1
            valoresOK(i) = False
        Next

        If dgv.SelectedRows.Count > 0 Then
            dgv.Rows(0).Selected = False
            dgv.Columns(0).Selected = False
        End If

        dgv.Visible = True
        TimerInicio.Enabled = False


    End Sub
#End Region ' Start

#Region "Statements"
    Dim TagsOk As String = ""
    Dim TagsTotOk As String
    Dim imgCheckAll As New CheckBoxCC 'Checkbox para seleccionar o deseleccionar toda la lista
    Dim DT_Templates As New DataTable()
    Dim TagIndexTable As DataTable = Nothing
#End Region ' Statements

#Region "Functions"
    Private Sub LoadTemplatesComboBox(dataTable As DataTable)
        ComBoxTemplates.Items.Clear()
        Try
            For Each fila As DataRow In dataTable.Rows
                Dim consulta As String = fila("Consulta").ToString()
                ComBoxTemplates.Items.Add(consulta)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar Consultas: " & ex.Message)
        End Try
    End Sub
    Private Sub btnSaveTemplate_Click(sender As Object, e As EventArgs) Handles btnSaveTemplate.Click
        Dim userInput As String = ""
        Dim export As Boolean = True
        Dim nuevaFila = DT_Templates.NewRow
        Dim foundRow As DataRow
        Dim valorColumna = 1

        If Not IsNothing(ComBoxTemplates.SelectedItem) AndAlso ComBoxTemplates.SelectedItem.Length > 0 AndAlso MsgBox("¿Desea sobreescribir la plantilla actual?", Title:="Guardar plantilla", Buttons:=MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
            userInput = ComBoxTemplates.SelectedItem
            foundRow = DT_Templates.Select("Consulta='" & userInput & "'").FirstOrDefault
            If Not IsNothing(foundRow) Then
                DT_Templates.Rows.Remove(foundRow)
            End If
        Else
            userInput = InputBox("Por favor, Introduzca el nombre de la plantilla:", "Guardar consulta")
        End If
        If userInput.Length > 0 Then
            If DT_Templates.Rows.Count > 0 Then
                Dim ultimaFila = DT_Templates.Rows(DT_Templates.Rows.Count - 1)

                'Dim valorColumna As Object = ultimaFila("Id")
                valorColumna = Convert.ToInt32(ultimaFila("Id")) + 1
            Else

            End If

            If Not String.IsNullOrEmpty(userInput) AndAlso userInput.Length > 0 Then

                nuevaFila("Id") = Convert.ToString(valorColumna)
                nuevaFila("Consulta") = userInput

                If RadioBtnMainData.Checked Or CheckBoxDigiIncludeBothData.Checked Then 'RPM
                    nuevaFila("MainData") = "True"
                Else
                    nuevaFila("MainData") = "False"
                End If

                If RadioBtnSecondaryData.Checked Then
                    nuevaFila("SecondaryData") = "True"
                Else
                    nuevaFila("SecondaryData") = "False"
                End If

                If CheckBoxDigi_y_TotIni.Checked Then
                    nuevaFila("MostrarValoresIniciales") = "True"
                Else
                    nuevaFila("MostrarValoresIniciales") = "False"
                End If

                If CheckBoxDigi_y_TotFin.Checked Then
                    nuevaFila("MostrarValoresFinales") = "True"
                Else
                    nuevaFila("MostrarValoresFinales") = "False"
                End If

                If CheckBoxDigiIncludeBothData.Checked Then
                    nuevaFila("IncludeDataTot") = "True"
                Else
                    nuevaFila("IncludeDataTot") = "False"
                End If

                If RadioButtonccDiario.Checked Then
                    nuevaFila("Diario") = "True"
                Else
                    nuevaFila("Diario") = "False"
                End If

                If RadioButtonccSemanal.Checked Then
                    nuevaFila("Semanal") = "True"
                Else
                    nuevaFila("Semanal") = "False"
                End If

                If RadioButtonccMensual.Checked Then
                    nuevaFila("Mensual") = "True"
                Else
                    nuevaFila("Mensual") = "False"
                End If

                If RadioButtonccLibre.Checked Then
                    nuevaFila("Libre") = "True"
                Else
                    nuevaFila("Libre") = "False"
                End If

                If RadioButtonccFreeHourly.Checked Then
                    nuevaFila("PorHoras") = "True"
                Else
                    nuevaFila("PorHoras") = "False"
                End If

                If RadioButtonccFreeDays.Checked Then
                    nuevaFila("PorDias") = "True"
                Else
                    nuevaFila("PorDias") = "False"
                End If

                'Fechas Horas
                nuevaFila("DesdeDia") = dTPickerDateFrom.Value.ToString("yyyy-MM-dd")
                nuevaFila("DesdeHora") = dTPickerHourFrom.Value.Hour
                nuevaFila("HastaDia") = dTPickerDateTo.Value.ToString("yyyy-MM-dd")
                nuevaFila("HastaHora") = dTPickerHourTo.Value.Hour

                If RadioButtonPdf.Checked Then
                    nuevaFila("APdf") = "True"
                Else
                    nuevaFila("APdf") = "False"
                End If

                If RadioButtonScr.Checked Then
                    nuevaFila("APantalla") = "True"
                Else
                    nuevaFila("APantalla") = "False"
                End If

                nuevaFila("X") = "False"
                Dim str As String = ""
                For Each r As DataGridViewRow In dgv.Rows
                    If Not IsNothing(r.Cells("Ok").Value) AndAlso Not IsDBNull(r.Cells("Ok").Value) AndAlso r.Cells("Ok").Value = True Then
                        str = str & IIf(str.Length > 0, ",", "") & r.Cells("TagIndex").Value
                    End If
                Next
                nuevaFila("Tags") = str
                foundRow = DT_Templates.Select("Consulta='" & userInput & "'").FirstOrDefault
                If Not IsNothing(foundRow) Then
                    If MsgBox("Ya existe una plantilla con ese nombre. ¿Desea sustituirla?", Title:="Guardar plantilla", Buttons:=MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                        DT_Templates.Rows.Remove(foundRow)
                    Else
                        export = False
                    End If
                End If
                If MsgBox("¿Desea almacenar la fecha y hora de inicio y fin de informe?", Title:="Guardar marcas de tiempo", Buttons:=MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    nuevaFila("SaveDates") = "True"
                Else
                    nuevaFila("SaveDates") = "False"
                End If
            End If

            If export Then
                DT_Templates.Rows.Add(nuevaFila)
                LoadTemplatesComboBox(DT_Templates)
                ExportarDtToBin(DT_Templates, GetFormParameter("SavedTemplatesFileName", _formType))
            End If
            Try
                ComBoxTemplates.SelectedItem = userInput
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub ComBoxTemplates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComBoxTemplates.SelectedIndexChanged
        'Esta función se utiliza para rellenar los controles desde la plantilla
        On Error Resume Next 'Se puede utilizar aquí ya que no hay dependencias entre sentencias
        Dim str = ComBoxTemplates.SelectedItem.ToString
        Dim fila As DataRow
        fila = DT_Templates.Select("Consulta='" & str & "'").FirstOrDefault
        If Not IsNothing(fila) Then
            If CStr(fila("MainData")) = "True" Then
                RadioBtnMainData.Checked = True
            Else
                RadioBtnMainData.Checked = False
            End If

            If CStr(fila("SecondaryData")) = "True" Then
                RadioBtnSecondaryData.Checked = True
            Else
                RadioBtnSecondaryData.Checked = False
            End If


            If CStr(fila("IncludeDataTot")) = "True" Then
                CheckBoxDigiIncludeBothData.Checked = True
            Else
                CheckBoxDigiIncludeBothData.Checked = False
            End If

            If CStr(fila("MostrarValoresIniciales")) = "True" Then
                CheckBoxDigi_y_TotIni.Checked = True
            Else
                CheckBoxDigi_y_TotIni.Checked = False
            End If

            If CStr(fila("MostrarValoresFinales")) = "True" Then
                CheckBoxDigi_y_TotFin.Checked = True
            Else
                CheckBoxDigi_y_TotFin.Checked = False
            End If

            If CStr(fila("Diario")) = "True" Then
                RadioButtonccDiario.Checked = True
            Else
                RadioButtonccDiario.Checked = False
            End If

            If CStr(fila("Semanal")) = "True" Then
                RadioButtonccSemanal.Checked = True
            Else
                RadioButtonccSemanal.Checked = False
            End If

            If CStr(fila("Mensual")) = "True" Then
                RadioButtonccMensual.Checked = True
            Else
                RadioButtonccMensual.Checked = False
            End If

            If CStr(fila("Libre")) = "True" Then
                RadioButtonccLibre.Checked = True
            Else
                RadioButtonccLibre.Checked = False
            End If

            If CStr(fila("PorHoras")) = "True" Then
                RadioButtonccFreeHourly.Checked = True
            Else
                RadioButtonccFreeHourly.Checked = False
            End If

            If CStr(fila("PorDias")) = "True" Then
                RadioButtonccFreeDays.Checked = True
            Else
                RadioButtonccFreeDays.Checked = False
            End If

            If CStr(fila("SaveDates")) = "True" Then
                dTPickerDateFrom.Value = Convert.ToDateTime(CStr(fila("DesdeDia")))
                dTPickerHourFrom.Value = dTPickerDateFrom.Value.AddHours(CInt(fila("DesdeHora")))
                dTPickerDateTo.Value = Convert.ToDateTime(CStr(fila("HastaDia")))
                dTPickerHourTo.Value = dTPickerDateTo.Value.AddHours(CInt(fila("HastaHora")))
            End If

            If CStr(fila("APdf")) = "True" Then
                RadioButtonPdf.Checked = True
            Else
                If CStr(fila("APantalla")) = "True" Then
                    RadioButtonScr.Checked = True
                Else
                    RadioButtonExcel.Checked = True
                End If
            End If

            Dim tags() As String = fila("Tags").ToString.Split(",")
            For Each r As DataGridViewRow In dgv.Rows
                r.Cells("ColImg").Value = My.Resources.no
                r.Cells("Ok").Value = False
            Next
            For Each tag As String In tags
                For Each r As DataGridViewRow In dgv.Rows
                    If Not IsNothing(r.Cells("TagIndex").Value) AndAlso Not IsDBNull(r.Cells("TagIndex").Value) AndAlso r.Cells("TagIndex").Value = tag Then
                        r.Cells("ColImg").Value = My.Resources.yes
                        r.Cells("Ok").Value = True
                    End If
                Next
            Next
            txtBoxFilter.Text = ""
            RadioButtoncc_CheckedChanged()
        Else
            MessageBox.Show("No se encontró ninguna cadena correcta.")
        End If

        imgCheckAllSee() 'MGG

    End Sub
    Private Sub dTPickerFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dTPickerDateFrom.ValueChanged

        dTPickerDateTo.MinDate = dTPickerDateFrom.Value

        ' Monday   Tuesday    Wednesday   Thursday   Friday   Saturday   Sunday

        If RadioButtonccDiario.Checked Then
            SelectDia()
        End If

        If RadioButtonccSemanal.Checked Then
            SelectSemana()
        End If

        If RadioButtonccMensual.Checked Then
            SelectMes()
        End If
    End Sub
    Private Sub SelectDia()
        dTPickerDateTo.Value = dTPickerDateFrom.Value
    End Sub
    Private Sub SelectSemana()
        Try
            Dim dayOfWeek As Integer = dTPickerDateFrom.Value.DayOfWeek
            dTPickerDateFrom.Value = dTPickerDateFrom.Value.AddDays(-dayOfWeek + 1)
            dTPickerDateTo.Value = dTPickerDateFrom.Value.AddDays(6)
        Catch
        End Try
    End Sub
    Private Sub SelectMes()

        Dim FechaMesAhora = dTPickerDateFrom.Value

        Dim PrimerDiaDelMes As DateTime = New DateTime(FechaMesAhora.Year, FechaMesAhora.Month, 1)
        Dim UltimoDiaDelMes As DateTime = PrimerDiaDelMes.AddMonths(1).AddDays(-1)

        dTPickerDateFrom.Value = PrimerDiaDelMes
        dTPickerDateTo.Value = UltimoDiaDelMes



    End Sub
    Private Sub dTPickerHourFrom_ValueChanged(sender As Object, e As EventArgs) Handles dTPickerHourFrom.ValueChanged
        dTPickerHourTo.MinDate = dTPickerHourFrom.Value
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs)
        dTPickerDateFrom.Value = Convert.ToDateTime("2023-03-01 00:00:00")
        dTPickerHourFrom.Value = Convert.ToDateTime("2023-03-01 00:00:00")
        dTPickerDateTo.Value = Convert.ToDateTime("2023-03-02 23: 59:59")
        dTPickerHourTo.Value = Convert.ToDateTime("2023-03-02 23: 59:59")

        If RadioButtonccDiario.Checked Then
            SelectDia()
        End If

        If RadioButtonccSemanal.Checked Then
            SelectSemana()
        End If

        If RadioButtonccMensual.Checked Then
            SelectMes()
        End If
    End Sub
    Private Sub blbForzar2_Click(sender As Object, e As EventArgs)
        dTPickerDateFrom.Value = Convert.ToDateTime("2023-02-20 00:00:00")
        dTPickerHourFrom.Value = Convert.ToDateTime("2023-02-20 00:00:00")
        dTPickerDateTo.Value = Convert.ToDateTime("2023-02-26 23: 59:59")
        dTPickerHourTo.Value = Convert.ToDateTime("2023-02-26 23: 59:59")

        If RadioButtonccDiario.Checked Then
            SelectDia()
        End If

        If RadioButtonccSemanal.Checked Then
            SelectSemana()
        End If

        If RadioButtonccMensual.Checked Then
            SelectMes()
        End If
    End Sub
    Private headerCheckBox As System.Windows.Forms.CheckBox = New System.Windows.Forms.CheckBox()
    Private Sub BindGrid()
        Try
            dgv.Rows.Clear()
        Catch
        End Try
        Try
            dgv.Columns.Clear()
        Catch
        End Try
        dgv.Refresh()
        Dim SqlForIndex = ""

        'Digital
        If _formType = "Equipment" Then
            SqlForIndex = "declare @tags nvarchar(max)
                        set @tags = '" + TagsOk + "'
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.DigNmanTAutTagTable A
                        Left JOIN DigTfunTAutTagTable T
                        ON (REPLACE(A.TagName, 'ODValStartT', 'ODValHourT')) = T.TagName
						Left JOIN DigNmanTAutReportTable D
                        ON D.TagName = A.TagName
                        Order by A.TagIndex"
        End If
        'Analog
        If _formType = "Signals" Then
            SqlForIndex = "declare @tags nvarchar(max)
                        set @tags = '" + TagsOk + "'
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName
						Left JOIN AnaVinsReportTable D
                        ON D.TagName = A.TagName
                        Order by A.TagIndex"
        End If

        Dim dtIn As DataTable = New DataTable()

        Try
            Using con As SqlConnection = New SqlConnection(Datos.SQLConnectionStringData)
                Using cmd As SqlCommand = New SqlCommand(SqlForIndex, con)
                    cmd.CommandType = CommandType.Text
                    Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                        Using dt As DataTable = New DataTable()
                            dt.Columns.Add(New DataColumn("Ok", GetType(Boolean)))
                            dt.Columns.Add(New DataColumn("TagIndex", GetType(System.String)))
                            dt.Columns.Add(New DataColumn("TagName", GetType(System.String)))
                            dt.Columns.Add(New DataColumn("TagDescription", GetType(System.String)))
                            dt.Columns.Add(New DataColumn("TagIndexOut", GetType(System.String)))

                            sda.Fill(dt)
                            Dim filteredData = dt.[Select]("TagIndexOut" <> "").CopyToDataTable()

                            dgv.DataSource = dt
                            TagIndexTable = dt
                        End Using
                    End Using
                End Using
            End Using
            dgv.Columns("Ok").Visible = False
            dgv.Columns("TagIndex").HeaderText = "Índice"
            dgv.Columns("TagName").HeaderText = "Tag"
            dgv.Columns("TagDescription").HeaderText = "Descripción"

            dtIn = dgv.DataSource

            dgv.Columns(0).Width = 48
            dgv.Columns(1).Width = 60
            dgv.Columns(2).Width = 360
            dgv.Columns(3).Width = 686

            'Bloquemos la posibilidad añadir y borrar columnas
            dgv.AllowUserToAddRows = False
            dgv.AllowUserToDeleteRows = False

            'Bloquemos la edición de todas las columnas
            If dgv.Rows.Count > 0 Then
                For Each col As DataGridViewColumn In dgv.Columns
                    col.[ReadOnly] = True
                Next
            End If

            HideOrShowTotalizedTags()

            'ResizeLastColumn(dgv)
            dgv.Refresh()
            'SafeValoresOK()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub HideOrShowTotalizedTags()
        'Esta función se utiliza para mostrar únicamente los tags de totalizadores
        Dim columnOkExists As Boolean = False
        If dgv.Columns.Contains("Ok") Then
            columnOkExists = True
        End If

        If columnOkExists Then
            Try
                dgv.Columns("Ok").Visible = False
                dgv.Columns("TagIndexOut").Visible = False
                dgv.Columns("TagNameOUT").Visible = False
                dgv.Columns("TagType").Visible = False
                dgv.Columns("TagDataType").Visible = False
                If (RadioBtnSecondaryData.Checked) Then
                    If dgv.Rows.Count > 0 Then
                        For i As Integer = 0 To (dgv.Rows.Count - 1)
                            If IsDBNull(dgv.Rows(i).Cells("TagIndexOut").Value) OrElse dgv.Rows(i).Cells("TagIndexOut").Value = "" Then
                                dgv.Rows(i).Visible = False
                            End If
                        Next
                    End If
                Else
                    If dgv.Rows.Count > 0 Then
                        For i As Integer = 0 To (dgv.Rows.Count - 1)
                            If Convert.ToString(dgv.Rows.Item(i).Cells("TagIndexOut").Value) = "" Then
                                dgv.Rows(i).Visible = True
                            End If
                        Next
                    End If
                End If
            Catch
            End Try
        End If
    End Sub
    Private Sub RadioButtoncc_CheckedChanged()
        RadioButtonccFreeDays.Enabled = False
        RadioButtonccFreeHourly.Enabled = False

        If RadioButtonccDiario.Checked Then
            SelectDia()
            dTPickerDateTo.Enabled = False
            dTPickerHourFrom.Enabled = False
            dTPickerHourTo.Enabled = False
            dTPickerHourFrom.Value = Convert.ToDateTime("00:00:00")
            dTPickerHourTo.Value = Convert.ToDateTime("23:59:59")
        End If
        If RadioButtonccSemanal.Checked Then
            SelectSemana()
            dTPickerDateTo.Enabled = False
            dTPickerHourFrom.Enabled = False
            dTPickerHourTo.Enabled = False
            dTPickerHourFrom.Value = Convert.ToDateTime("00:00:00")
            dTPickerHourTo.Value = Convert.ToDateTime("23:59:59")
        End If
        If RadioButtonccMensual.Checked Then
            SelectMes()
            dTPickerHourFrom.Enabled = False
            dTPickerDateTo.Enabled = False
            dTPickerHourTo.Enabled = False
            dTPickerHourFrom.Value = Convert.ToDateTime("00:00:00")
            dTPickerHourTo.Value = Convert.ToDateTime("23:59:59")
        End If
        If RadioButtonccLibre.Checked Then
            dTPickerDateTo.Enabled = True
            RadioButtonccFreeDays.Enabled = True
            RadioButtonccFreeHourly.Enabled = True
            dTPickerHourFrom.Enabled = RadioButtonccFreeHourly.Checked
            dTPickerHourTo.Enabled = RadioButtonccFreeHourly.Checked
        End If
        CheckBoxDigi_y_TotIni.Enabled = Not RadioBtnMainData.Checked
        CheckBoxDigi_y_TotFin.Enabled = Not RadioBtnMainData.Checked
    End Sub
#End Region 'Functions

#Region "Generate report"
    Private Sub BtnReport_Start()
        TagsOk = ""

        Dim desde = dTPickerDateFrom.Value.ToString("yyyy-MM-dd") + " " + dTPickerHourFrom.Value.ToString("00:00:00")
        Dim hasta = dTPickerDateTo.Value.ToString("yyyy-MM-dd") + " " + dTPickerHourTo.Value.ToString("23:59:59")
        Dim Salida = 0
        Dim Range = 0
        Dim Range2 = 100
        Dim File = "EDAR_Informe.pdf"

        For Each r As DataGridViewRow In dgv.Rows
            If Not IsNothing(r.Cells("Ok").Value) AndAlso Not IsDBNull(r.Cells("Ok").Value) AndAlso r.Cells("Ok").Value = True Then
                TagsOk = TagsOk & IIf(TagsOk.Length > 0, ",", "") & r.Cells("TagIndex").Value
            End If
        Next
        If TagsOk.Length <= 0 Then
            MsgBox("No se seleccionado ningún elemento", vbOKOnly, "Error")
            Return
        End If
        If RadioButtonPdf.Checked = True Then
            Salida = 1
        End If

        If RadioButtonExcel.Checked = True Then
            Salida = 2
        End If

        If RadioButtonccDiario.Checked Then
            File = "EDAR_InformeDiario.pdf"

            If _formType = "Equipment" Then
                Range = 100
                Range2 = 104
                If RadioBtnSecondaryData.Checked Then
                    GenerateFreeReportDay(_formType, TagsOk, "Man", desde, hasta, Range, Range2, Salida, File)
                Else
                    If CheckBoxDigiIncludeBothData.Checked Then
                        GenerateReportDay(_formType, TagsOk, "DigMan", desde, hasta, Range, Range2, Salida, File)
                    Else
                        GenerateReportDay(_formType, TagsOk, "Dig", desde, hasta, Range, Range2, Salida, File)
                    End If
                End If
            End If

            If _formType = "Signals" Then
                Range = 0
                Range2 = 4
                If RadioBtnSecondaryData.Checked Then
                    GenerateReportDay(_formType, TagsOk, "Tot", desde, hasta, Range, Range2, Salida, File)
                Else
                    If CheckBoxDigiIncludeBothData.Checked Then
                        GenerateReportDay(_formType, TagsOk, "AnaTot", desde, hasta, Range, Range2, Salida, File)
                    Else
                        GenerateReportDay(_formType, TagsOk, "Ana", desde, hasta, Range, Range2, Salida, File)
                    End If
                End If
            End If
        End If

        If RadioButtonccSemanal.Checked Then
            File = "EDAR_InformeSemanal.pdf"
            dTPickerHourTo.Enabled = False
            dTPickerHourFrom.Value = Convert.ToDateTime("00:00:00")
            dTPickerHourTo.Value = Convert.ToDateTime("23:59:59")

            If _formType = "Equipment" Then
                Range = 102
                Range2 = 106
                If RadioBtnSecondaryData.Checked Then
                    GenerateFreeReportWeek(_formType, TagsOk, "Man", desde, hasta, Range, Range2, Salida, File)
                Else
                    If CheckBoxDigiIncludeBothData.Checked Then
                        GenerateFreeReportWeek(_formType, TagsOk, "DigMan", desde, hasta, Range, Range2, Salida, File)
                    Else
                        GenerateFreeReportWeek(_formType, TagsOk, "Dig", desde, hasta, Range, Range2, Salida, File)
                    End If
                End If
            End If

            If _formType = "Signals" Then
                Range = 2
                Range2 = 4
                If RadioBtnSecondaryData.Checked Then
                    GenerateFreeReportWeek(_formType, TagsOk, "Tot", desde, hasta, Range, Range2, Salida, File)
                Else
                    If CheckBoxDigiIncludeBothData.Checked Then
                        GenerateFreeReportWeek(_formType, TagsOk, "AnaTot", desde, hasta, Range, Range2, Salida, File)
                    Else
                        GenerateFreeReportWeek(_formType, TagsOk, "Ana", desde, hasta, Range, Range2, Salida, File)
                    End If
                End If
            End If
        End If

        If RadioButtonccMensual.Checked Then
            File = "EDAR_InformeMensual.pdf"

            If _formType = "Equipment" Then
                Range = 103
                Range2 = 107
                If RadioBtnSecondaryData.Checked Then
                    GenerateFreeReportMonth(_formType, TagsOk, "Man", desde, hasta, Range, Range2, Salida, File)
                Else
                    If CheckBoxDigiIncludeBothData.Checked Then
                        GenerateFreeReportMonth(_formType, TagsOk, "DigMan", desde, hasta, Range, Range2, Salida, File)
                    Else
                        GenerateFreeReportMonth(_formType, TagsOk, "Dig", desde, hasta, Range, Range2, Salida, File)
                    End If
                End If
            End If

            If _formType = "Signals" Then
                Range = 3
                Range2 = 6
                If RadioBtnSecondaryData.Checked Then
                    GenerateFreeReportMonth(_formType, TagsOk, "Tot", desde, hasta, Range, Range2, Salida, File)
                Else
                    If CheckBoxDigiIncludeBothData.Checked Then
                        GenerateFreeReportMonth(_formType, TagsOk, "AnaTot", desde, hasta, Range, Range2, Salida, File)
                    Else
                        GenerateFreeReportMonth(_formType, TagsOk, "Tot", desde, hasta, Range, Range2, Salida, File)
                    End If
                End If
            End If
        End If

        If RadioButtonccLibre.Checked Then
            File = "EDAR_InformeLibrePorHoras.pdf"
            If _formType = "Equipment" Then
                If RadioButtonccFreeHourly.Checked Then
                    Range = 100
                    Range2 = 104
                    If RadioBtnSecondaryData.Checked Then
                        GenerateFreeReportHours(_formType, TagsOk, "Man", desde, hasta, Range, Range2, Salida, File)
                    Else
                        If CheckBoxDigiIncludeBothData.Checked Then
                            GenerateFreeReportHours(_formType, TagsOk, "DigMan", desde, hasta, Range, Range2, Salida, File)
                        Else
                            GenerateFreeReportHours(_formType, TagsOk, "Dig", desde, hasta, Range, Range2, Salida, File)
                        End If
                    End If
                End If

                If RadioButtonccFreeDays.Checked Then '
                    Range = 101
                    Range2 = 105
                    File = "EDAR_InformeLibrePorDias.pdf"

                    If RadioBtnSecondaryData.Checked Then
                        GenerateFreeReportDay(_formType, TagsOk, "Man", desde, hasta, Range, Range2, Salida, File)
                    Else
                        If CheckBoxDigiIncludeBothData.Checked Then
                            GenerateFreeReportDay(_formType, TagsOk, "DigMan", desde, hasta, Range, Range2, Salida, File)
                        Else
                            GenerateFreeReportDay(_formType, TagsOk, "Dig", desde, hasta, Range, Range2, Salida, File)
                        End If
                    End If
                End If
            End If
            If _formType = "Signals" Then
                If RadioButtonccFreeHourly.Checked Then
                    Range = 0
                    Range2 = 4
                    If RadioBtnSecondaryData.Checked Then
                        GenerateFreeReportHours(_formType, TagsOk, "Tot", desde, hasta, Range, Range2, Salida, File)
                    Else
                        If CheckBoxDigiIncludeBothData.Checked Then
                            GenerateFreeReportHours(_formType, TagsOk, "AnaTot", desde, hasta, Range, Range2, Salida, File)
                        Else
                            GenerateFreeReportHours(_formType, TagsOk, "Ana", desde, hasta, Range, Range2, Salida, File)
                        End If
                    End If
                End If

                If RadioButtonccFreeDays.Checked Then
                    Range = 1
                    Range2 = 5
                    File = "EDAR_InformeLibrePorDias.pdf"

                    If RadioBtnSecondaryData.Checked Then
                        GenerateFreeReportDay(_formType, TagsOk, "Tot", desde, hasta, Range, Range2, Salida, File)
                    Else
                        If CheckBoxDigiIncludeBothData.Checked Then
                            GenerateFreeReportDay(_formType, TagsOk, "AnaTot", desde, hasta, Range, Range2, Salida, File)
                        Else
                            GenerateFreeReportDay(_formType, TagsOk, "Ana", desde, hasta, Range, Range2, Salida, File)
                        End If
                    End If
                End If
            End If
        End If
        PanelNotices.Visible = False
    End Sub

#Region "Both"
    Private Sub GenerateFreeReportHours(FormType As String, TypeTags As String, Info As String, InitialDate As Date, FinalDate As Date, Type As Int32, Type2 As Int32, Mode As Int32, FileOut As String)
        lblLog.Text = ""
        Dim dt1 As DataTable = Nothing
        Dim dt2 As DataTable = Nothing
        Dim RecIndex As DataTable = Nothing
        Dim dtOut As DataTable = Nothing

        lblNotices.Text = "Ejecutando Query .... Espere"
        PanelNotices.Visible = True
        PanelNotices.Refresh()

        Dim Ok As Boolean = False
        Ok = BringDt(FormType, TypeTags, Info, InitialDate, FinalDate, Type, Type2, Mode, FileOut, RecIndex, dt1, dt2)

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        lblNotices.Text = "Cruzando datos Digitales... Espere"

        dtOut = GrowDt(dt1, dt2)

        lblNotices.Text = "Añadiendo Maniobras Tiempos... Espere"

        Dim Columnas As String()
        Dim dtAll As DataTable = Nothing

        If _formType = "Equipment" Then
            Columnas = Datos.ColumnasDigFreeHour
            dtAll = AllDt(".ODValHourT", Columnas, dtOut, RecIndex, dt2, "Day")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportDigFreeHour(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)
        End If

        If _formType = "Signals" Then
            Columnas = Datos.ColumnasAnaFreeHour
            dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Day")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportAnaFreeHour(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)
        End If

        lblNotices.Text = ""
        PanelNotices.Visible = False
    End Sub
    Private Sub GenerateFreeReportDay(FormType As String, TypeTags As String, Info As String, InitialDate As Date, FinalDate As Date, Type As Int32, Type2 As Int32, Mode As Int32, FileOut As String)
        lblLog.Text = ""
        Dim dt1 As DataTable = Nothing
        Dim dt2 As DataTable = Nothing
        Dim RecIndex As DataTable = Nothing
        Dim dtOut As DataTable = Nothing

        lblNotices.Text = "Ejecutando Query .... Espere"
        PanelNotices.Visible = True
        PanelNotices.Refresh()

        Dim Ok As Boolean = False
        Ok = BringDt(FormType, TypeTags, Info, InitialDate, FinalDate, Type, Type2, Mode, FileOut, RecIndex, dt1, dt2) ' <<<

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        lblNotices.Text = "Cruzando datos Digitales... Espere"

        dtOut = GrowDt(dt1, dt2) '''

        lblNotices.Text = "Añadiendo Maniobras Tiempos... Espere"

        Dim Columnas As String()
        Dim dtAll As DataTable

        If _formType = "Equipment" Then
            Columnas = Datos.ColumnasDigFreeDays
            dtAll = AllDt(".ODValHourT", Columnas, dtOut, RecIndex, dt2, "Day")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportDigFreeDays(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)

        End If

        If _formType = "Signals" Then
            Columnas = Datos.ColumnasAnaFreeDays
            dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Day")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportAnaFreeDays(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)

        End If

        lblNotices.Text = ""
        PanelNotices.Visible = False

    End Sub
    Private Sub GenerateReportDay(FormType As String, TypeTags As String, Info As String, InitialDate As Date, FinalDate As Date, Type As Int32, Type2 As Int32, Mode As Int32, FileOut As String)
        lblLog.Text = ""
        Dim dt1 As DataTable = Nothing
        Dim dt2 As DataTable = Nothing
        Dim RecIndex As DataTable = Nothing
        Dim dtOut As DataTable = Nothing

        lblNotices.Text = "Ejecutando Query .... Espere"
        PanelNotices.Visible = True
        PanelNotices.Refresh()

        Dim Ok As Boolean = False
        Ok = BringDt(FormType, TypeTags, Info, InitialDate, FinalDate, Type, Type2, Mode, FileOut, RecIndex, dt1, dt2) ' <<<

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        lblNotices.Text = "Cruzando datos Digitales... Espere"

        dtOut = GrowDt(dt1, dt2) '''

        lblNotices.Text = "Añadiendo Maniobras Tiempos... Espere"

        Dim Columnas As String()
        Dim dtAll As DataTable

        If _formType = "Equipment" Then
            Columnas = Datos.ColumnasDigFreeHour
            dtAll = AllDt(".ODValHourT", Columnas, dtOut, RecIndex, dt2, "Day")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportDigDays(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)

        End If

        If _formType = "Signals" Then
            Columnas = Datos.ColumnasAnaFreeHour
            dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Day")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportAnaDays(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)

        End If

        lblNotices.Text = ""
        PanelNotices.Visible = False

    End Sub
    Private Sub GenerateFreeReportWeek(FormType As String, TypeTags As String, Info As String, InitialDate As Date, FinalDate As Date, Type As Int32, Type2 As Int32, Mode As Int32, FileOut As String)
        lblLog.Text = ""
        Dim dt1 As DataTable = Nothing
        Dim dt2 As DataTable = Nothing
        Dim RecIndex As DataTable = Nothing
        Dim dtOut As DataTable = Nothing

        lblNotices.Text = "Ejecutando Query .... Espere"
        PanelNotices.Visible = True
        PanelNotices.Refresh()

        Dim Ok As Boolean = False
        Ok = BringDt(FormType, TypeTags, Info, InitialDate, FinalDate, Type, Type2, Mode, FileOut, RecIndex, dt1, dt2)

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        lblNotices.Text = "Cruzando datos Digitales... Espere"

        dtOut = GrowDt(dt1, dt2) '''

        lblNotices.Text = "Añadiendo Maniobras Tiempos... Espere"

        Dim Columnas As String()
        Dim dtAll As DataTable

        If _formType = "Equipment" Then
            Columnas = Datos.ColumnasDigWeek
            dtAll = AllDt(".ODValHourT", Columnas, dtOut, RecIndex, dt2, "Week")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportDigWeek(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)
        End If

        If _formType = "Signals" Then
            Columnas = Datos.ColumnasAnaWeek
            dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Week")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportAnaWeek(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)

        End If

        lblNotices.Text = ""
        PanelNotices.Visible = False

    End Sub
    Private Sub GenerateFreeReportMonth(FormType As String, TypeTags As String, Info As String, InitialDate As Date, FinalDate As Date, Type As Int32, Type2 As Int32, Mode As Int32, FileOut As String)
        lblLog.Text = ""
        Dim dt1 As DataTable = Nothing
        Dim dt2 As DataTable = Nothing
        Dim RecIndex As DataTable = Nothing
        Dim dtOut As DataTable = Nothing

        lblNotices.Text = "Ejecutando Query .... Espere"
        PanelNotices.Visible = True
        PanelNotices.Refresh()

        Dim Ok As Boolean = False
        Ok = BringDt(FormType, TypeTags, Info, InitialDate, FinalDate, Type, Type2, Mode, FileOut, RecIndex, dt1, dt2)

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        lblNotices.Text = "Cruzando datos Digitales... Espere"

        dtOut = GrowDt(dt1, dt2) '''

        lblNotices.Text = "Añadiendo Maniobras Tiempos... Espere"

        Dim Columnas As String()
        Dim dtAll As DataTable

        If _formType = "Equipment" Then
            Columnas = Datos.ColumnasDigMonth
            dtAll = AllDt(".ODValHourT", Columnas, dtOut, RecIndex, dt2, "Month")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportDigMonth(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)
        End If

        If _formType = "Signals" Then
            Columnas = Datos.ColumnasAnaMonth
            dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Month")

            FillOutDt(_formType, RecIndex, dtAll, TagIndexTable)

            lblNotices.Text = "Creando el informe... Espere"
            ReportAnaMonth(Info, dtAll, InitialDate, FinalDate, Type, Mode, FileOut)
        End If

        lblNotices.Text = ""
        PanelNotices.Visible = False

    End Sub
#End Region ' Both

#Region "Digital"
    Private Sub ReportDigFreeHour(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "DigMan" AndAlso Type = 100 Then
            GenerateReport(New XRptDigHourMan(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Dig" AndAlso Type = 100 Then
            GenerateReport(New XRptDigHour(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Man" AndAlso Type = 100 Then
            GenerateReport(New XRptManHourDeDig(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportDigFreeDays(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "DigMan" AndAlso Type = 100 Then
            GenerateReport(New XRpDigHourTotDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Dig" AndAlso Type = 100 Then
            GenerateReport(New XRpDigHourDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Man" AndAlso Type = 100 Then
            GenerateReport(New XRpDigHourManDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
        If Info = "DigMan" AndAlso Type = 101 Then
            GenerateReport(New XRptDigDayMan(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Dig" AndAlso Type = 101 Then
            GenerateReport(New XRptDigDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Man" AndAlso Type = 101 Then
            GenerateReport(New XRptManDayDeDig(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportDigDays(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "DigMan" AndAlso Type = 100 Then
            GenerateReport(New XRpDigHourTotDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Dig" AndAlso Type = 100 Then
            GenerateReport(New XRpDigHourDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Man" AndAlso Type = 100 Then
            GenerateReport(New XRpDigHourManDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportDigWeek(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "DigMan" AndAlso Type = 102 Then
            GenerateReport(New XRptDigManWeek(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Dig" AndAlso Type = 102 Then
            GenerateReport(New XRptDigWeek(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Man" AndAlso Type = 102 Then
            GenerateReport(New XRptManWeek(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportDigMonth(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        Dim selectedDate As DateTime = dTPickerDateTo.Value
        Dim dayOfMonth As Integer = selectedDate.Day

        If dayOfMonth = 28 Then
            If Info = "DigMan" AndAlso Type = 103 Then
                GenerateReport(New XRptDigManMonth28(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Dig" AndAlso Type = 103 Then
                GenerateReport(New XRptDigMonth28(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Man" AndAlso Type = 103 Then
                GenerateReport(New XRptManMonth28(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If
        If dayOfMonth = 29 Then
            If Info = "DigMan" AndAlso Type = 103 Then
                GenerateReport(New XRptDigManMonth29(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Dig" AndAlso Type = 103 Then
                GenerateReport(New XRptDigMonth29(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Man" AndAlso Type = 103 Then
                GenerateReport(New XRptManMonth29(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If
        If dayOfMonth = 30 Then
            If Info = "DigMan" AndAlso Type = 103 Then
                GenerateReport(New XRptDigManMonth30(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Dig" AndAlso Type = 103 Then
                GenerateReport(New XRptDigMonth30_(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Man" AndAlso Type = 103 Then
                GenerateReport(New XRptManMonth30(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If
        If dayOfMonth = 31 Then
            If Info = "DigMan" AndAlso Type = 103 Then
                GenerateReport(New XRptDigManMonth31(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Dig" AndAlso Type = 103 Then
                GenerateReport(New XRptDigMonth31(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Man" AndAlso Type = 103 Then
                GenerateReport(New XRptManMonth31(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If
    End Sub
#End Region ' Digital

#Region "Analog"
    Private Sub ReportAnaFreeHour(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "AnaTot" AndAlso Type = 0 Then
            GenerateReport(New XRptAnaHourTot(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Ana" AndAlso Type = 0 Then
            GenerateReport(New XRptAnaHour(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Tot" AndAlso Type = 0 Then
            GenerateReport(New XRptManHourDeDig(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportAnaFreeDays(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "AnaTot" AndAlso Type = 1 Then
            GenerateReport(New XRptAnaDayTot(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Ana" AndAlso Type = 1 Then
            GenerateReport(New XRptAnaDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Tot" AndAlso Type = 1 Then
            GenerateReport(New XRptVtotDayDeAna(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportAnaDays(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "AnaTot" AndAlso Type = 0 Then
            GenerateReport(New XRptAnaHourTotDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Ana" AndAlso Type = 0 Then
            GenerateReport(New XRptAnaHourDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Tot" AndAlso Type = 0 Then
            GenerateReport(New XRptVtotDayDeAnaDay(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportAnaWeek(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        If Info = "AnaTot" AndAlso Type = 2 Then
            GenerateReport(New XRptAnaTotWeek(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Ana" AndAlso Type = 2 Then
            GenerateReport(New XRptAnaWeek(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        ElseIf Info = "Tot" AndAlso Type = 2 Then
            GenerateReport(New XRptTotWeek(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
        End If
    End Sub
    Private Sub ReportAnaMonth(Info As String, ByVal dtOut As DataTable, InitialDate As Date, FinalDate As Date, Type As Int32, Mode As Int32, FileOut As String)
        Dim selectedDate As DateTime = dTPickerDateTo.Value
        Dim dayOfMonth As Integer = selectedDate.Day

        If dayOfMonth = 28 Then
            If Info = "AnaTot" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaTotMonth28(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Ana" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaMonth28(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Tot" AndAlso Type = 3 Then
                GenerateReport(New XRptManMonth28(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If
        If dayOfMonth = 29 Then
            If Info = "AnaTot" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaTotMonth29(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Ana" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaMonth29(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Tot" AndAlso Type = 3 Then
                GenerateReport(New XRptManMonth29(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If
        If dayOfMonth = 30 Then
            If Info = "AnaTot" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaTotMonth30(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Ana" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaMonth30(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Tot" AndAlso Type = 3 Then
                GenerateReport(New XRptManMonth30(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If
        If dayOfMonth = 31 Then
            If Info = "AnaTot" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaTotMonth(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Ana" AndAlso Type = 3 Then
                GenerateReport(New XRptAnaMonth31(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            ElseIf Info = "Tot" AndAlso Type = 3 Then
                GenerateReport(New XRptManMonth31(), dtOut, InitialDate, FinalDate, Type, Mode, FileOut)
            End If
        End If


    End Sub
#End Region ' Analog

#End Region 'Gender Report 

#Region "GUI functions"
    'En esta región se agruparán las funciones relacionadas con la interfaz de usuario
#Region "Check all"
    'En esta región se gestiona la selección/deselección del grid al completo
    Private prevTimeClick As New DateTime 'Se almacena la marca de tiempo previa, para evitar clicks repetidos en cuestión de milisegundos causados por la propia interfaz

    Private Sub checkAll()
        Dim nowTime As DateTime = Now
        Try
            For Each r As DataGridViewRow In dgv.Rows
                r.Cells("ColImg").Value = IIf(imgCheckAll.Checked, My.Resources.yes, My.Resources.no)
                r.Cells("Ok").Value = IIf(imgCheckAll.Checked, True, False)
            Next

        Catch ex As Exception
        Finally
            imgCheckAllSee() 'MGG
        End Try
    End Sub
#End Region 'Check all

    Private Sub CreateImgCheck()
        Try
            Dim ColImage As New DataGridViewImageColumn 'Se crea la columna que visualizará los checkbox
            ColImage.CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            ColImage.Width = dgv.ColumnHeadersHeight
            Dim Img As New DataGridViewImageCell
            ColImage.Name = "ColImg"
            ColImage.HeaderText = ""
            ColImage.Image = My.Resources.no
            dgv.Columns.Add(ColImage)
            dgv.Columns("ColImg").DisplayIndex = 0
            dgv.Columns("Ok").Visible = False
            dgv.Columns("ColImg").Resizable = DataGridViewTriState.False
            dgv.Columns("TagIndex").Resizable = DataGridViewTriState.False
            dgv.Columns("TagIndex").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            If Not dgv.Controls.Contains(imgCheckAll) Then
                imgCheckAll.Size = New System.Drawing.Size(18, 18)
                imgCheckAll.BackColor = System.Drawing.Color.Transparent 'dgv.ColumnHeadersDefaultCellStyle.BackColor
                'Se agrega un checkbox a la celda del encabezado.
                'Se busca la ubicación de la celda del encabezado.
                Dim headerCellLocation As System.Drawing.Point = Me.dgv.GetCellDisplayRectangle(0, -1, True).Location
                Dim wi As Integer = Me.dgv.Columns("ColImg").Width
                Dim h As Integer = Me.dgv.ColumnHeadersHeight
                Dim hOffset As Integer = wi / 2 - imgCheckAll.Width / 2
                Dim vOffset As Integer = h / 2 - imgCheckAll.Height / 2
                imgCheckAll.Location = New System.Drawing.Point(headerCellLocation.X + hOffset, headerCellLocation.Y + vOffset)

                imgCheckAll.Refresh()

                dgv.Controls.Add(imgCheckAll)
                AddHandler imgCheckAll.Click, AddressOf imgCheckAll_Click
            End If
            ResizeLastColumn(dgv)
            If dgv.RowCount > 0 And dgv.ColumnCount > 2 Then
                dgv.CurrentCell = dgv.Rows(1).Cells(3) ' Con esto, pierde el foco la celda
            End If
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub
    Private Sub FillControlsFromSettings()
        'Esta función se usa para precargar los controles en base a la configuración guardada
        On Error Resume Next 'Se puede utilizar aquí ya que no hay dependencias entre sentencias
        'Digital MGG
        If _formType = "Equipment" Then
            RadioBtnMainData.Checked = Not My.Settings.D_FormDig_HoursOrStarts 'A false, horas
            RadioBtnSecondaryData.Checked = Not RadioBtnMainData.Checked
            CheckBoxDigiIncludeBothData.Checked = My.Settings.D_FormDig_IncludeStarts
            CheckBoxDigi_y_TotIni.Checked = My.Settings.D_FormDig_ShowInitVal
            CheckBoxDigi_y_TotFin.Checked = My.Settings.D_FormDig_ShowEndVal

            Select Case My.Settings.D_FormDig_TimeType
                Case 0
                    RadioButtonccDiario.Checked = True 'Diario
                Case 1
                    RadioButtonccSemanal.Checked = True 'Semanal
                Case 2
                    RadioButtonccMensual.Checked = True 'Mensual
                Case 3
                    RadioButtonccLibre.Checked = True 'Libre
                Case Else
                    RadioButtonccDiario.Checked = True 'Diario
            End Select

            PanelFreeTimeSelect.Enabled = RadioButtonccLibre.Checked

            Select Case My.Settings.D_FormDig_OutputType
                Case 0
                    RadioButtonScr.Checked = True 'Por pantalla
                Case 1
                    RadioButtonPdf.Checked = True 'A PDF
                Case 2
                    RadioButtonExcel.Checked = True 'A Excel
            End Select

            dTPickerDateFrom.Value = Convert.ToDateTime(My.Settings.D_FormDig_DateFrom)
            dTPickerHourFrom.Value = dTPickerDateFrom.Value.AddHours(My.Settings.D_FormDig_HourFrom)
            dTPickerDateTo.Value = Convert.ToDateTime(My.Settings.D_FormDig_DateTo)
            dTPickerHourTo.Value = dTPickerDateTo.Value.AddHours(My.Settings.D_FormDig_HourTo)

            Dim tags() As String = My.Settings.D_FormDig_Tags.Split(",")
            For Each r As DataGridViewRow In dgv.Rows
                r.Cells("ColImg").Value = My.Resources.no
                r.Cells("Ok").Value = False
            Next
            For Each tag As String In tags
                For Each r As DataGridViewRow In dgv.Rows
                    If Not IsNothing(r.Cells("TagIndex").Value) AndAlso Not IsDBNull(r.Cells("TagIndex").Value) AndAlso r.Cells("TagIndex").Value = tag Then
                        r.Cells("ColImg").Value = My.Resources.yes
                        r.Cells("Ok").Value = True
                    End If
                Next
            Next
            RadioButtonccFreeHourly.Checked = My.Settings.D_FormDig_FreeTimeType 'A false, por horas
            RadioButtonccFreeDays.Checked = Not RadioButtonccFreeHourly.Checked 'A false, por días
        End If
        'Analog MGG
        If _formType = "Signals" Then
            RadioBtnMainData.Checked = Not My.Settings.A_FormDig_HoursOrStarts 'A false, horas
            RadioBtnSecondaryData.Checked = Not RadioBtnMainData.Checked
            CheckBoxDigiIncludeBothData.Checked = My.Settings.A_FormDig_IncludeStarts
            CheckBoxDigi_y_TotIni.Checked = My.Settings.A_FormDig_ShowInitVal
            CheckBoxDigi_y_TotFin.Checked = My.Settings.A_FormDig_ShowEndVal

            Select Case My.Settings.A_FormDig_TimeType
                Case 0
                    RadioButtonccDiario.Checked = True 'Diario
                Case 1
                    RadioButtonccSemanal.Checked = True 'Semanal
                Case 2
                    RadioButtonccMensual.Checked = True 'Mensual
                Case 3
                    RadioButtonccLibre.Checked = True 'Libre
                Case Else
                    RadioButtonccDiario.Checked = True 'Diario
            End Select

            PanelFreeTimeSelect.Enabled = RadioButtonccLibre.Checked

            Select Case My.Settings.A_FormDig_OutputType
                Case 0
                    RadioButtonScr.Checked = True 'Por pantalla
                Case 1
                    RadioButtonPdf.Checked = True 'A PDF
                Case 2
                    RadioButtonExcel.Checked = True 'A Excel
            End Select

            dTPickerDateFrom.Value = Convert.ToDateTime(My.Settings.A_FormDig_DateFrom)
            dTPickerHourFrom.Value = dTPickerDateFrom.Value.AddHours(My.Settings.A_FormDig_HourFrom)
            dTPickerDateTo.Value = Convert.ToDateTime(My.Settings.A_FormDig_DateTo)
            dTPickerHourTo.Value = dTPickerDateTo.Value.AddHours(My.Settings.A_FormDig_HourTo)

            Dim tags() As String = My.Settings.A_FormDig_Tags.Split(",")
            For Each r As DataGridViewRow In dgv.Rows
                r.Cells("ColImg").Value = My.Resources.no
                r.Cells("Ok").Value = False
            Next
            For Each tag As String In tags
                For Each r As DataGridViewRow In dgv.Rows
                    If Not IsNothing(r.Cells("TagIndex").Value) AndAlso Not IsDBNull(r.Cells("TagIndex").Value) AndAlso r.Cells("TagIndex").Value = tag Then
                        r.Cells("ColImg").Value = My.Resources.yes
                        r.Cells("Ok").Value = True
                    End If
                Next
            Next
            RadioButtonccFreeHourly.Checked = My.Settings.A_FormDig_FreeTimeType 'A false, por horas
            RadioButtonccFreeDays.Checked = Not RadioButtonccFreeHourly.Checked 'A false, por días
        End If
    End Sub
    Private Sub SaveSettingsFromControls()
        'Esta función se utiliza para guardar la última configuración del usuario
        On Error Resume Next 'Se puede utilizar aquí ya que no hay dependencias entre sentencias
        'Digital MGG
        If _formType = "Equipment" Then
            My.Settings.D_FormDig_HoursOrStarts = Not RadioBtnMainData.Checked   'A false, horas
            My.Settings.D_FormDig_IncludeStarts = CheckBoxDigiIncludeBothData.Checked
            My.Settings.D_FormDig_ShowInitVal = CheckBoxDigi_y_TotIni.Checked
            My.Settings.D_FormDig_ShowEndVal = CheckBoxDigi_y_TotFin.Checked
            My.Settings.D_FormDig_TimeType = IIf(RadioButtonccDiario.Checked, 0, IIf(RadioButtonccSemanal.Checked, 1, IIf(RadioButtonccMensual.Checked, 2, IIf(RadioButtonccLibre.Checked, 3, 0))))
            My.Settings.D_FormDig_OutputType = IIf(RadioButtonScr.Checked, 0, IIf(RadioButtonPdf.Checked, 1, IIf(RadioButtonExcel.Checked, 2, 0)))
            My.Settings.D_FormDig_FreeTimeType = RadioButtonccFreeHourly.Checked  'A false, por horas

            My.Settings.D_FormDig_DateFrom = dTPickerDateFrom.Value.ToString("yyyy-MM-dd")
            My.Settings.D_FormDig_HourFrom = dTPickerHourFrom.Value.Hour.ToString
            My.Settings.D_FormDig_DateTo = dTPickerDateTo.Value.ToString("yyyy-MM-dd")
            My.Settings.D_FormDig_HourTo = dTPickerHourTo.Value.Hour.ToString
            Dim str As String = ""
            For Each r As DataGridViewRow In dgv.Rows
                If Not IsNothing(r.Cells("Ok").Value) AndAlso Not IsDBNull(r.Cells("Ok").Value) AndAlso r.Cells("Ok").Value = True Then
                    str = str & IIf(str.Length > 0, ",", "") & r.Cells("TagIndex").Value
                End If
            Next
            My.Settings.D_FormDig_Tags = str

            My.Settings.Save()
        End If
        'Analog MGG
        If _formType = "Signals" Then
            My.Settings.A_FormDig_HoursOrStarts = Not RadioBtnMainData.Checked   'A false, horas
            My.Settings.A_FormDig_IncludeStarts = CheckBoxDigiIncludeBothData.Checked
            My.Settings.A_FormDig_ShowInitVal = CheckBoxDigi_y_TotIni.Checked
            My.Settings.A_FormDig_ShowEndVal = CheckBoxDigi_y_TotFin.Checked
            My.Settings.A_FormDig_TimeType = IIf(RadioButtonccDiario.Checked, 0, IIf(RadioButtonccSemanal.Checked, 1, IIf(RadioButtonccMensual.Checked, 2, IIf(RadioButtonccLibre.Checked, 3, 0))))
            My.Settings.A_FormDig_OutputType = IIf(RadioButtonScr.Checked, 0, IIf(RadioButtonPdf.Checked, 1, IIf(RadioButtonExcel.Checked, 2, 0)))
            My.Settings.A_FormDig_FreeTimeType = RadioButtonccFreeHourly.Checked  'A false, por horas

            My.Settings.A_FormDig_DateFrom = dTPickerDateFrom.Value.ToString("yyyy-MM-dd")
            My.Settings.A_FormDig_HourFrom = dTPickerHourFrom.Value.Hour.ToString
            My.Settings.A_FormDig_DateTo = dTPickerDateTo.Value.ToString("yyyy-MM-dd")
            My.Settings.A_FormDig_HourTo = dTPickerHourTo.Value.Hour.ToString
            Dim str As String = ""
            For Each r As DataGridViewRow In dgv.Rows
                If Not IsNothing(r.Cells("Ok").Value) AndAlso Not IsDBNull(r.Cells("Ok").Value) AndAlso r.Cells("Ok").Value = True Then
                    str = str & IIf(str.Length > 0, ",", "") & r.Cells("TagIndex").Value
                End If
            Next
            My.Settings.A_FormDig_Tags = str

            My.Settings.Save()
        End If
    End Sub
#End Region 'GUI functions

#Region "Events"
    'En esta región se agruparán los eventos de los controles del formulario
    Private Sub FormInformesDigitales_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveSettingsFromControls()
    End Sub
    Private Sub dgv_Resize(sender As Object, e As EventArgs) Handles dgv.Resize
        ResizeLastColumn(dgv)
    End Sub
    Private Sub dgv_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseClick
        Dim col As DataGridViewColumn = Nothing
        Dim row As DataGridViewRow = Nothing
        If e.ColumnIndex >= 0 Then
            col = dgv.Columns(e.ColumnIndex)
        End If
        If e.RowIndex >= 0 Then
            row = dgv.Rows(e.RowIndex)
        End If
        If Not IsNothing(row) Then
            If Not IsNothing(col) AndAlso Not IsNothing(row) AndAlso col.Name = "ColImg" Then
                If Not IsDBNull(row.Cells("Ok").Value) AndAlso row.Cells("Ok").Value Then
                    row.Cells("ColImg").Value = My.Resources.no
                    row.Cells("Ok").Value = False
                Else
                    row.Cells("ColImg").Value = My.Resources.yes
                    row.Cells("Ok").Value = True
                End If
                dgv.Refresh()
            End If
        ElseIf Not IsNothing(col) AndAlso col.Name = "ColImg" And e.RowIndex = -1 Then 'Encabezado de seleccionar todo
            checkAll()
        End If

        imgCheckAllSee() 'MGG

    End Sub
    Private Sub btnDeleteTemplate_Click(sender As Object, e As EventArgs) Handles btnDeleteTemplate.Click 'Borrar la plantilla guardada
        Dim seleccion = ComBoxTemplates.SelectedItem

        If seleccion IsNot Nothing Then
            Dim valor = seleccion.ToString
            If valor.Length >= 0 Then
                Dim resultado = MessageBox.Show("Desea borrar la plantilla '" & valor & "'", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resultado = DialogResult.Yes Then
                    Dim foundRow As DataRow
                    foundRow = DT_Templates.Select("Consulta='" & seleccion & "'").FirstOrDefault
                    Dim export As Boolean = True
                    If Not IsNothing(foundRow) Then
                        DT_Templates.Rows.Remove(foundRow)
                        LoadTemplatesComboBox(DT_Templates)
                        ExportarDtToBin(DT_Templates, GetFormParameter("SavedTemplatesFileName", _formType))
                    End If
                ElseIf resultado = DialogResult.No Then
                    Return
                End If
            End If
        Else
            MessageBox.Show("Seleccione primero una configuración a borrar.")
        End If
    End Sub
    Private Sub imgCheckAll_Click() ' No tiene cláusula Handles, ya que viene de un control creado dinámicamente
        'Click del checkbox del encabezado
        checkAll()
    End Sub
    Private Sub imgCheckAllSee() 'MGG
        If dgv.Rows.Count > 0 Then
            Dim File0 As DataGridViewRow = dgv.Rows(0)
            Dim ValueOk As Boolean = CBool(File0.Cells("Ok").Value)
            File0.Cells("ColImg").Value = If(ValueOk, My.Resources.yes, My.Resources.no)
        End If

        Dim isChecked As Boolean = True
        For Each row As DataGridViewRow In dgv.Rows
            If Convert.ToBoolean(row.Cells("Ok").EditedFormattedValue) = False Then
                isChecked = False

                Exit For
            End If
        Next

        headerCheckBox.Checked = isChecked
        imgCheckAll.Checked = isChecked

    End Sub
    Private Sub txtBoxFilter_KeyUp(sender As Object, e As KeyEventArgs) Handles txtBoxFilter.KeyUp
        FilterDGV(dgv, sender.text)
    End Sub
    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Datos.frmclose = True
        Me.Close()
    End Sub
    Private Sub RadioBtnNumeroDeManiobras_CheckedChanged() Handles RadioBtnSecondaryData.CheckedChange
        HideOrShowTotalizedTags()
        FilterDGV(dgv, "")
    End Sub
    Private valoresOK As Boolean()
    Private Sub dgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgv.CellFormatting

        If valoresOK IsNot Nothing AndAlso e.RowIndex >= 0 Then 'AndAlso e.RowIndex <valoresOK.Length Then
            Dim MiroValorOk = dgv.Rows(e.RowIndex).Cells("Ok").Value
            Dim MiroValorPng = valoresOK(e.RowIndex)

            dgv.Rows(e.RowIndex).Selected = False

            If Not DBNull.Value.Equals(MiroValorOk) AndAlso Not DBNull.Value.Equals(valoresOK(e.RowIndex)) Then
                If MiroValorOk <> MiroValorPng Then
                    'son diferentes
                    If MiroValorOk = False Then
                        dgv.Rows(e.RowIndex).Cells("ColImg").Value = My.Resources.no
                        valoresOK(e.RowIndex) = False
                        imgCheckAll.Checked = False 'RPM
                    End If

                    If MiroValorOk = True Then
                        dgv.Rows(e.RowIndex).Cells("ColImg").Value = My.Resources.yes
                        valoresOK(e.RowIndex) = True
                        imgCheckAll.Checked = True 'RPM
                    End If
                End If
            Else

            End If
        End If
    End Sub
    Private Sub RadioButtonccDiario_Click(sender As Object, e As EventArgs) Handles RadioButtonccDiario.Click
        RadioButtoncc_CheckedChanged()
    End Sub
    Private Sub RadioButtonccSemanal_Click(sender As Object, e As EventArgs) Handles RadioButtonccSemanal.Click
        RadioButtoncc_CheckedChanged()
    End Sub
    Private Sub RadioButtonccMensual_Click(sender As Object, e As EventArgs) Handles RadioButtonccMensual.Click
        RadioButtoncc_CheckedChanged()
    End Sub
    Private Sub RadioButtonccLibre_Click(sender As Object, e As EventArgs) Handles RadioButtonccLibre.Click
        RadioButtoncc_CheckedChanged()
        PanelFreeTimeSelect.Enabled = RadioButtonccLibre.Checked
    End Sub
    Private Sub BtnInforme_Click(sender As Object, e As EventArgs) Handles BtnInforme.Click
        BtnReport_Start()
        SaveSettingsFromControls()
    End Sub
    Private Sub RadioBtnTiempoDeFuncionamiento_CheckedChange() Handles RadioBtnMainData.CheckedChange
        RadioButtoncc_CheckedChanged()
        FilterDGV(dgv, "")
    End Sub
    Private Sub RadioButtonccLibrePorDias_CheckedChange() Handles RadioButtonccFreeDays.CheckedChange
        RadioButtoncc_CheckedChanged()
    End Sub
    Private Sub RadioButtonccLibrePorHoras_CheckedChange() Handles RadioButtonccFreeHourly.CheckedChange
        RadioButtoncc_CheckedChanged()
    End Sub
    Private Sub TimerAll_Tick(sender As Object, e As EventArgs) Handles TimerAll.Tick
        imgCheckAllSee() 'MGG
        TimerAll.Enabled = False
    End Sub
    Private Sub FormReportConfiguration_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
#End Region ' Events

End Class


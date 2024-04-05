#Region "NameSpace"
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI

Imports DevExpress.XtraReports.Parameters
Imports System.IO
Imports System.Text
Imports DevExpress.DataProcessing.InMemoryDataProcessor.GraphGenerator
Imports System.Windows.Media
Imports DevExpress.XtraCharts
Imports DevExpress.Utils
Imports System.Windows.Forms
Imports DevExpress.CodeParser
Imports DevExpress.Utils.Internal
Imports System.Windows.Controls
Imports DevExpress.XtraRichEdit.Import.Html



#End Region 'NameSpace

#Region "Inicio"
Public Class FormInformesAnalogicas
    Public Sub New()
        InitializeComponent()
        FrmLoad()
    End Sub
    Public Sub New(stepForm As Integer)
        InitializeComponent()
        FrmLoad()
    End Sub
    Sub FrmLoad()

    End Sub

    Private Sub FormInformes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComBoxConsultas.DropDownStyle = ComboBoxStyle.DropDownList

        DtConsultas = CreateDtConsultasAna()

        DtConsultas = LoadBintToDT("Templates_Signals.bin")
        CargoComBoxConsultas(DtConsultas)

        ControlFileSafe()

        dTPickerFechaDesde.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
        dTPickerFechaHasta.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
        dTPickerDesdeHora.Value = Convert.ToDateTime("00:00:00")
        dTPickerHastaHora.Value = Convert.ToDateTime("23:59:59")
    End Sub
#End Region ' Inicio

#Region "Declaraciones"
    Dim TagsOk As String
    Dim TagsTotOk As String
    Dim DtConsultas As New DataTable()

#End Region ' Declaraciones

#Region "Functions"

    Private Sub CargoComBoxConsultas(dataTable As DataTable)

        ComBoxConsultas.Items.Clear()

        Try
            For Each fila As DataRow In dataTable.Rows
                Dim id As Integer = CInt(fila("Id"))
                Dim consulta As String = fila("Consulta").ToString()
                ComBoxConsultas.Items.Add(New KeyValuePair(Of Integer, String)(id, consulta))
            Next

            'MessageBox.Show("Consultas cargadas exitosamente.")
        Catch ex As Exception
            MessageBox.Show("Error al cargar Consultas: " & ex.Message)
        End Try
    End Sub

    Dim userInput As String

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click
        userInput = ""
        userInput = InputBox("Por favor, Introduzca el nombre de la Consulta a salvar:", "Salvar consulta")

        Dim valorColumna As Integer = 1

        If DtConsultas.Rows.Count > 0 Then
            Dim ultimaFila As DataRow = DtConsultas.Rows(DtConsultas.Rows.Count - 1)

            'Dim valorColumna As Object = ultimaFila("Id")
            valorColumna = Convert.ToInt32(ultimaFila("Id")) + 1
        Else

        End If

        If Not String.IsNullOrEmpty(userInput) Then
            Dim nuevaFila As DataRow = DtConsultas.NewRow()

            nuevaFila("Id") = Convert.ToString(valorColumna)
            nuevaFila("Consulta") = userInput

            If RadioBtnAnalogicasOnly.Checked Then
                nuevaFila("SeñalesAnalogicas") = "True"
            Else
                nuevaFila("SeñalesAnalogicas") = "False"
            End If

            If RadioBtnTotalizadoresDeAnalogicas.Checked Then
                nuevaFila("Totalizadores") = "True"
            Else
                nuevaFila("Totalizadores") = "False"
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

            If CheckBoxAnaIncuTot.Checked Then
                nuevaFila("IncluirTotalizadores") = "True"
            Else
                nuevaFila("IncluirTotalizadores") = "False"
            End If

            If RadioBtnDiario.Checked Then
                nuevaFila("Diario") = "True"
            Else
                nuevaFila("Diario") = "False"
            End If

            If RadioBtnSemanal.Checked Then
                nuevaFila("Semanal") = "True"
            Else
                nuevaFila("Semanal") = "False"
            End If

            If RadioBtnMensual.Checked Then
                nuevaFila("Mensual") = "True"
            Else
                nuevaFila("Mensual") = "False"
            End If

            If RadioBtnLibre.Checked Then
                nuevaFila("Libre") = "True"
            Else
                nuevaFila("Libre") = "False"
            End If

            If RadioBtnLibrePorHoras.Checked Then
                nuevaFila("PorHoras") = "True"
            Else
                nuevaFila("PorHoras") = "False"
            End If

            If RadioBtnLibrePorDias.Checked Then
                nuevaFila("PorDias") = "True"
            Else
                nuevaFila("PorDias") = "False"
            End If

            'Fechas Horas
            nuevaFila("DesdeDia") = dTPickerFechaDesde.Value.ToString("yyyy-MM-dd")
            nuevaFila("DesdeHora") = dTPickerDesdeHora.Value.ToString("00:00:00")
            nuevaFila("HastaDia") = dTPickerFechaHasta.Value.ToString("yyyy-MM-dd")
            nuevaFila("HastaHora") = dTPickerHastaHora.Value.ToString("23:59:59")

            If RadioBtnPdf.Checked Then
                nuevaFila("APdf") = "True"
            Else
                nuevaFila("APdf") = "False"
            End If

            If RadioBtnPantalla.Checked Then
                nuevaFila("APantalla") = "True"
            Else
                nuevaFila("APantalla") = "False"
            End If

            nuevaFila("X") = "False"

            DtConsultas.Rows.Add(nuevaFila)

            CargoComBoxConsultas(DtConsultas)

            ExportarDtToBin(DtConsultas, "Templates_Signals.bin")

        End If
    End Sub


    Private Sub BtnBorrar_Click(sender As Object, e As EventArgs) Handles BtnBorrar.Click

        Dim seleccion As Object = ComBoxConsultas.SelectedItem

        If seleccion IsNot Nothing Then
            Dim valor As String = seleccion.ToString()
            Dim valorS As String = seleccion.ToString()
            If valorS.Length >= 2 Then
                valorS = valorS.Substring(1, valorS.Length - 2)
                'valorS = valorS.Replace(",", vbTab, 1)
                valorS = valorS.Replace(",", "")
                valorS = valorS.Replace(" ", "")

                Dim resultado As DialogResult = MessageBox.Show("Desea borrar la configuración: " & vbNewLine & valor.Substring(1, valorS.Length - 2), "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resultado = DialogResult.Yes Then
                    BorraConfig(valorS)
                ElseIf resultado = DialogResult.No Then
                    Return
                End If


            End If

        Else
            MessageBox.Show("Seleccione primero una configuración a borrar.")
        End If
    End Sub

    Private Sub BorraConfig(ByVal config As String)

        Dim fileBin As String = "Templates_Signals.bin"
        Dim TempBin As String = "MisConsultasAnalogicas_temp.bin"

        If File.Exists(TempBin) Then
            Try
                File.Delete(TempBin)
            Catch ex As Exception
                Console.WriteLine("Error al borrar el archivo: " & ex.Message)
            End Try
        End If

        Dim configABorrar As String = config

        Using sr As New StreamReader(fileBin)
            Using sw As New StreamWriter(TempBin)
                While Not sr.EndOfStream
                    Dim linea As String = sr.ReadLine()
                    Dim lineaMiro As String = (linea.Replace(vbTab, "")).Replace(" ", "")
                    If Not lineaMiro.StartsWith(configABorrar) Then

                        sw.WriteLine(linea)
                    End If
                End While
            End Using
        End Using

        File.Delete(fileBin)
        File.Move(TempBin, fileBin)

        DtConsultas = LoadBintToDT("Templates_Signals.bin")
        CargoComBoxConsultas(DtConsultas)
    End Sub

    Private Sub ComBoxConsultas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComBoxConsultas.SelectedIndexChanged
        Dim cadena As String = ComBoxConsultas.SelectedItem.ToString()
        Dim partes() As String = cadena.Split(",")

        If partes.Length > 0 Then
            Dim Indice As String = (partes(0).Trim()).Replace("[", "")

            For Each fila As DataRow In DtConsultas.Rows

                If Not IsDBNull(fila(0)) AndAlso CStr(fila(0)) = Indice Then

                    If CStr(fila(2)) = "True" Then
                        RadioBtnAnalogicasOnly.Checked = True
                    Else
                        RadioBtnAnalogicasOnly.Checked = False
                    End If

                    If CStr(fila(3)) = "True" Then
                        RadioBtnTotalizadoresDeAnalogicas.Checked = True
                    Else
                        RadioBtnTotalizadoresDeAnalogicas.Checked = False
                    End If

                    If CStr(fila(4)) = "True" Then
                        CheckBoxDigi_y_TotIni.Checked = True
                    Else
                        CheckBoxDigi_y_TotIni.Checked = False
                    End If

                    If CStr(fila(5)) = "True" Then
                        CheckBoxDigi_y_TotFin.Checked = True
                    Else
                        CheckBoxDigi_y_TotFin.Checked = False
                    End If

                    If CStr(fila(6)) = "True" Then
                        CheckBoxAnaIncuTot.Checked = True
                    Else
                        CheckBoxAnaIncuTot.Checked = False
                    End If

                    If CStr(fila(7)) = "True" Then
                        RadioBtnDiario.Checked = True
                    Else
                        RadioBtnDiario.Checked = False
                    End If

                    If CStr(fila(8)) = "True" Then
                        RadioBtnSemanal.Checked = True
                    Else
                        RadioBtnSemanal.Checked = False
                    End If

                    If CStr(fila(9)) = "True" Then
                        RadioBtnMensual.Checked = True
                    Else
                        RadioBtnMensual.Checked = False
                    End If

                    If CStr(fila(10)) = "True" Then
                        RadioBtnLibre.Checked = True
                    Else
                        RadioBtnLibre.Checked = False
                    End If

                    If CStr(fila(11)) = "True" Then
                        RadioBtnLibrePorHoras.Checked = True
                    Else
                        RadioBtnLibrePorHoras.Checked = False
                    End If

                    If CStr(fila(12)) = "True" Then
                        RadioBtnLibrePorDias.Checked = True
                    Else
                        RadioBtnLibrePorDias.Checked = False
                    End If

                    dTPickerFechaDesde.Value = Convert.ToDateTime(CStr(fila(13)))
                    dTPickerDesdeHora.Value = Convert.ToDateTime(CStr(fila(14)))
                    dTPickerFechaHasta.Value = Convert.ToDateTime(CStr(fila(15)))
                    dTPickerHastaHora.Value = Convert.ToDateTime(CStr(fila(16)))


                    If CStr(fila(17)) = "True" Then
                        RadioBtnPdf.Checked = True
                    Else
                        RadioBtnPdf.Checked = False
                    End If

                    If CStr(fila(18)) = "True" Then
                        RadioBtnPantalla.Checked = True
                    Else
                        RadioBtnPantalla.Checked = False
                    End If
                    Exit For
                End If
            Next


        Else
            MessageBox.Show("No se encontró ninguna cadena correcta.")
        End If
    End Sub

    Private Sub ControlFileSafe() 'Mod 28/11/2023 por MG por petición de RP de solo guardar el CheqBox y el TagIndex

        Dim FileName = "SafeSelectDgvAna.dat"

        Me.BindGrid()

        Dim fileError As Boolean = False
        If File.Exists(FileName) Then
            Try
                CargarDatos(FileName)
            Catch ex As IOException
                fileError = True
                MessageBox.Show("No fue posible leer los datos en el disco." & ex.Message)
            End Try
        End If

        TagsOkSafe()

    End Sub

    Private Sub dTPickerFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dTPickerFechaDesde.ValueChanged

        dTPickerFechaHasta.MinDate = dTPickerFechaDesde.Value

        ' Monday   Tuesday    Wednesday   Thursday   Friday   Saturday   Sunday

        If (RadioBtnDiario.Checked) Then
            SelectDia()

        End If

        If (RadioBtnSemanal.Checked) Then
            SelectSemana()

        End If

        If (RadioBtnMensual.Checked) Then
            SelectMes()

        End If
    End Sub

    Private Sub SelectDia()

        dTPickerFechaHasta.Value = dTPickerFechaDesde.Value

    End Sub

    Private Sub SelectSemana()


        Dim DiaSemana = dTPickerFechaDesde.Value.DayOfWeek.ToString()

        If (DiaSemana = "Monday") Then
            dTPickerFechaHasta.Value = dTPickerFechaDesde.Value.AddDays(6)
        End If
        If (DiaSemana = "Tuesday") Then
            dTPickerFechaDesde.Value = dTPickerFechaDesde.Value.AddDays(-1)
            dTPickerFechaHasta.Value = dTPickerFechaDesde.Value.AddDays(6)
        End If
        If (DiaSemana = "Wednesday") Then
            dTPickerFechaDesde.Value = dTPickerFechaDesde.Value.AddDays(-2)
            dTPickerFechaHasta.Value = dTPickerFechaDesde.Value.AddDays(6)
        End If
        If (DiaSemana = "Thursday") Then
            dTPickerFechaDesde.Value = dTPickerFechaDesde.Value.AddDays(-3)
            dTPickerFechaHasta.Value = dTPickerFechaDesde.Value.AddDays(6)
        End If
        If (DiaSemana = "Friday") Then
            dTPickerFechaDesde.Value = dTPickerFechaDesde.Value.AddDays(-4)
            dTPickerFechaHasta.Value = dTPickerFechaDesde.Value.AddDays(6)
        End If
        If (DiaSemana = "Saturday") Then
            dTPickerFechaDesde.Value = dTPickerFechaDesde.Value.AddDays(-5)
            dTPickerFechaHasta.Value = dTPickerFechaDesde.Value.AddDays(6)
        End If
        If (DiaSemana = "Sunday") Then
            dTPickerFechaDesde.Value = dTPickerFechaDesde.Value.AddDays(-6)
            dTPickerFechaHasta.Value = dTPickerFechaDesde.Value.AddDays(6)
        End If

    End Sub

    Private Sub SelectMes()

        Dim FechaMesAhora = dTPickerFechaDesde.Value

        Dim PrimerDiaDelMes As DateTime = New DateTime(FechaMesAhora.Year, FechaMesAhora.Month, 1)
        Dim UltimoDiaDelMes As DateTime = PrimerDiaDelMes.AddMonths(1).AddDays(-1)

        dTPickerFechaDesde.Value = PrimerDiaDelMes
        dTPickerFechaHasta.Value = UltimoDiaDelMes



    End Sub

    Private Sub dTPickerDesdeHora_ValueChanged(sender As Object, e As EventArgs) Handles dTPickerDesdeHora.ValueChanged
        dTPickerHastaHora.MinDate = dTPickerDesdeHora.Value
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        dTPickerFechaDesde.Value = Convert.ToDateTime("2023-03-01 00:00:00")
        dTPickerDesdeHora.Value = Convert.ToDateTime("2023-03-01 00:00:00")
        dTPickerFechaHasta.Value = Convert.ToDateTime("2023-03-02 23: 59:59")
        dTPickerHastaHora.Value = Convert.ToDateTime("2023-03-02 23: 59:59")

        If (RadioBtnDiario.Checked) Then
            SelectDia()

        End If

        If (RadioBtnSemanal.Checked) Then
            SelectSemana()

        End If

        If (RadioBtnMensual.Checked) Then
            SelectMes()

        End If
        SafeSelect()
    End Sub

    Private Sub blbForzar2_Click(sender As Object, e As EventArgs) Handles blbForzar2.Click
        dTPickerFechaDesde.Value = Convert.ToDateTime("2023-02-20 00:00:00")
        dTPickerDesdeHora.Value = Convert.ToDateTime("2023-02-20 00:00:00")
        dTPickerFechaHasta.Value = Convert.ToDateTime("2023-02-26 23: 59:59")
        dTPickerHastaHora.Value = Convert.ToDateTime("2023-02-26 23: 59:59")

        If (RadioBtnDiario.Checked) Then
            SelectDia()

        End If

        If (RadioBtnSemanal.Checked) Then
            SelectSemana()

        End If

        If (RadioBtnMensual.Checked) Then
            SelectMes()

        End If
        SafeSelect()
    End Sub

    Private headerCheckBox As System.Windows.Forms.CheckBox = New System.Windows.Forms.CheckBox()

    Private Sub BindGrid()
        Dim SqlForIndex = ""

        SqlForIndex = "declare @tags nvarchar(max)
                        set @tags = '" + TagsOk + "'
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName
						Left JOIN AnaVinsReportTable D
                        ON D.TagName = A.TagName
                        Order by A.TagIndex"

        Dim dtIn As DataTable = New DataTable() 'ñ

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
                        For Each row As DataGridViewRow In dgv.Rows
                            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("Ok"), DataGridViewCheckBoxCell))
                            checkBox.Value = False
                        Next

                    End Using
                End Using
            End Using
        End Using

        'Agregamos una columna CheckBox a la celda del encabezado DataGridView.
        'Buscamos la ubicación de la celda del encabezado.
        Dim headerCellLocation As Point = Me.dgv.GetCellDisplayRectangle(0, -1, True).Location

        'Colocamos la casilla de verificación del encabezado en la ubicación de la celda del encabezado.
        headerCheckBox.Location = New Point(headerCellLocation.X + 26, headerCellLocation.Y + 2)
        headerCheckBox.Size = New Size(16, 16)

        'Asignamos el evento Click a la casilla de verificación del encabezado.
        AddHandler headerCheckBox.Click, AddressOf HeaderCheckBox_Clicked
        dgv.Controls.Add(headerCheckBox)

        Dim columnCount1 As Integer = dgv.Columns.Count

        AddHandler dgv.CellContentClick, AddressOf DataGridView_CellClick

        dtIn = dgv.DataSource

        Dim columnCount2 As Integer = dgv.Columns.Count

        dgv.Columns(0).Width = 48
        dgv.Columns(1).Width = 60
        dgv.Columns(2).Width = 360
        dgv.Columns(3).Width = 686

        'Bloquemos la añadir y borrar columnas
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False

        'Bloquemos la edidción de todaslas columnas excepto e ChekBox
        If dgv.Rows.Count > 0 Then
            For Each col As DataGridViewColumn In dgv.Columns
                If col.Name <> "Ok" Then col.[ReadOnly] = True
            Next
        End If

        Ocultar()

    End Sub

    Private Sub Ocultar()
        dgv.Columns(4).Visible = False
        dgv.Columns(5).Visible = False
        dgv.Columns(6).Visible = False
        dgv.Columns(7).Visible = False

        If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then
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


    End Sub

    Private Sub HeaderCheckBox_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        'Finalizo el modo de edición de la celda.
        dgv.EndEdit()

        'Hago un bucle que marque y desmarque todas las casillas de verificación de las filas según la casilla de verificación de la celda del encabezado.
        For Each row As DataGridViewRow In dgv.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("Ok"), DataGridViewCheckBoxCell))
            checkBox.Value = headerCheckBox.Checked
        Next
        SafeSelect()
    End Sub

    Private Sub DataGridView_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)  '<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<XXX
        'Verifico que se haga clic en la fila CheckBox.
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = 0 Then

            'Bucle para verificar si todas las casillas de verificación de las filas están marcadas o no.
            Dim isChecked As Boolean = True
            For Each row As DataGridViewRow In dgv.Rows
                If Convert.ToBoolean(row.Cells("Ok").EditedFormattedValue) = False Then
                    isChecked = False

                    Exit For
                End If
            Next

            headerCheckBox.Checked = isChecked
            CheckBoxSafe()
        End If

    End Sub

    Private Sub CheckBoxSafe()
        'Finalizar el modo de edición de la celda.
        dgv.EndEdit()

        'Hago un bucle que marque y desmarque todas las casillas de verificación de las filas según la casilla de verificación de la celda del encabezado.
        For Each row As DataGridViewRow In dgv.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("Ok"), DataGridViewCheckBoxCell))
            checkBox.Value = checkBox.Value
        Next
        SafeSelect()
    End Sub

    Private Sub FormInformesAnalogicas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SafeSelect()
    End Sub

    Private Sub TagsOkSafe()
        Try
            If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then

            Else

            End If

            TagsOk = ""
            TagsTotOk = ""

            For Each fila As DataGridViewRow In dgv.Rows

                If ((fila.Cells(0).Value.ToString) = True) Then
                    TagsOk = TagsOk & (fila.Cells(1).Value.ToString) & ","

                    If ((fila.Cells(4).Value.ToString) <> "") Then
                        TagsTotOk = TagsTotOk & (fila.Cells(4).Value.ToString) & ","

                    End If

                End If

            Next
            TagsOk = TagsOk.Trim(",".ToCharArray())
            TagsTotOk = TagsTotOk.Trim(",".ToCharArray())
        Catch ex As Exception
            MessageBox.Show("Error :" & ex.Message)
        End Try

    End Sub

    Private Sub SafeSelect() 'Mod 28/11/2023 por MG por petición de RP de solo guardar el CheqBox y el TagIndex

        TagsOkSafe()

        If dgv.Rows.Count > 0 Then

            Dim FileName = "SafeSelectDgvAna.dat"

            Try
                Using Guardo As New StreamWriter(FileName)
                    For Each fila As DataGridViewRow In dgv.Rows

                        Dim id As String = fila.Cells("TagIndex").Value.ToString()
                        Dim valorCheckbox As Boolean = Convert.ToBoolean(fila.Cells("Ok").Value)

                        If valorCheckbox Then
                            Guardo.WriteLine(id & ":True")
                        End If
                    Next
                End Using

            Catch ex As Exception
                MessageBox.Show("Error :" & ex.Message)
            End Try

        Else
            MessageBox.Show("No hay registros para exportar !!!", "Info")
        End If
    End Sub

    Private Sub CargarDatos(ByVal fichero As String)  'Mod 28/11/2023 por MG por petición de RP de solo guardar el CheqBox y el TagIndex

        If File.Exists(fichero) Then
            Using lector As New StreamReader(fichero)
                Dim linea As String
                While Not lector.EndOfStream
                    linea = lector.ReadLine()

                    Dim partes() As String = linea.Split(":"c)
                    If partes.Length = 2 Then
                        Dim id As String = partes(0)
                        Dim valor As String = partes(1)

                        For Each fila As DataGridViewRow In dgv.Rows
                            If fila.Cells("TagIndex").Value.ToString() = id Then
                                fila.Cells("OK").Value = (valor = "True")
                                Exit For
                            End If
                        Next
                    End If
                End While
            End Using
        Else
            MessageBox.Show("El archivo no existe.")
        End If
    End Sub

    Private Sub btnInicializar_Click(sender As Object, e As EventArgs) Handles btnInicializar.Click

        Dim FileName = "SafeSelectDgvAna.dat"

        Dim fileError As Boolean = False

        If File.Exists(FileName) Then

            Try
                File.Delete(FileName)
            Catch ex As IOException
                fileError = True
                MessageBox.Show("No fue posible borrar los datos en el disco." & ex.Message)
            End Try
        End If

        For Each row As DataGridViewRow In dgv.Rows
            Dim checkBox As DataGridViewCheckBoxCell = (TryCast(row.Cells("Ok"), DataGridViewCheckBoxCell))
            checkBox.Value = False
        Next

        headerCheckBox.Checked = False

        BindGrid()

    End Sub

    Private Sub RadioBtnDiario_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnDiario.CheckedChanged
        If (RadioBtnDiario.Checked) Then
            SelectDia()
            dTPickerFechaHasta.Enabled = False
            dTPickerDesdeHora.Enabled = False
            dTPickerHastaHora.Enabled = False
            dTPickerDesdeHora.Value = Convert.ToDateTime("00:00:00")
            dTPickerHastaHora.Value = Convert.ToDateTime("23:59:59")
        Else


        End If
    End Sub

    Private Sub RadioBtnSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnSemanal.CheckedChanged
        If (RadioBtnSemanal.Checked) Then
            SelectSemana()
            dTPickerFechaHasta.Enabled = False
            dTPickerDesdeHora.Enabled = False
            dTPickerHastaHora.Enabled = False
            dTPickerDesdeHora.Value = Convert.ToDateTime("00:00:00")
            dTPickerHastaHora.Value = Convert.ToDateTime("23:59:59")
        Else


        End If
    End Sub

    Private Sub RadioBtnMensual_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnMensual.CheckedChanged
        If (RadioBtnMensual.Checked) Then
            SelectMes()
            dTPickerDesdeHora.Enabled = False
            dTPickerFechaHasta.Enabled = False
            dTPickerHastaHora.Enabled = False
            dTPickerDesdeHora.Value = Convert.ToDateTime("00:00:00")
            dTPickerHastaHora.Value = Convert.ToDateTime("23:59:59")
        Else


        End If
    End Sub

    Private Sub RadioBtnLibre_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnLibre.CheckedChanged
        If (RadioBtnLibre.Checked) Then
            dTPickerFechaHasta.Enabled = True
            RadioBtnLibrePorDias.Enabled = True
            RadioBtnLibrePorHoras.Enabled = True

            dTPickerDesdeHora.Enabled = True
            dTPickerHastaHora.Enabled = True
        Else
            RadioBtnLibrePorDias.Enabled = False
            RadioBtnLibrePorHoras.Enabled = False
        End If
    End Sub

    Private Sub RadioBtnTotalizadoresDeAnalogicas_CheckedChanged(sender As Object, e As EventArgs) Handles RadioBtnTotalizadoresDeAnalogicas.CheckedChanged
        If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then
            CheckBoxAnaIncuTot.Checked = True
            CheckBoxAnaIncuTot.Enabled = False
        Else
            CheckBoxAnaIncuTot.Checked = False
            CheckBoxAnaIncuTot.Enabled = True

        End If

        Ocultar()

    End Sub

#End Region 'Functions

#Region "Genero Informe"
    Private Sub BtnInforme_Click(sender As Object, e As EventArgs) Handles BtnInforme.Click

        TagsOk = ""
        TagsTotOk = ""

        Dim desde = dTPickerFechaDesde.Value.ToString("yyyy-MM-dd") + " " + dTPickerDesdeHora.Value.ToString("00:00:00")
        Dim hasta = dTPickerFechaHasta.Value.ToString("yyyy-MM-dd") + " " + dTPickerHastaHora.Value.ToString("23:59:59")
        Dim Salida As Integer = 0
        Dim Rango As Integer = 0
        Dim File As String = "EDAR_Informe.pdf"

        If (RadioBtnPdf.Checked) Then
            Salida = 1
        End If

        If (RadioBtnDiario.Checked) Then
            Rango = 1
            File = "EDAR_InformeDiario.pdf"
            If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then
                GeneraInformeAnaLibDias("Tot", desde, hasta, TagsOk, Rango, Salida, File)
            Else
                If (CheckBoxAnaIncuTot.Checked) Then
                    GeneraInformeAnaLibDias("AnaTot", desde, hasta, TagsOk, Rango, Salida, File)
                Else
                    GeneraInformeAnaLibDias("Ana", desde, hasta, TagsOk, Rango, Salida, File)
                End If
            End If
        End If

        If (RadioBtnSemanal.Checked) Then
            File = "EDAR_InformeSemanal.pdf"

            dTPickerHastaHora.Enabled = False
            dTPickerDesdeHora.Value = Convert.ToDateTime("00:00:00")
            dTPickerHastaHora.Value = Convert.ToDateTime("23:59:59")

            If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then
                Rango = 2
                GeneraInformeAnaWeek("Tot", desde, hasta, TagsOk, Rango, Salida, File)
            Else
                If (CheckBoxAnaIncuTot.Checked) Then
                    Rango = 2
                    GeneraInformeAnaWeek("AnaTot", desde, hasta, TagsOk, Rango, Salida, File)
                Else
                    Rango = 2
                    GeneraInformeAnaWeek("Ana", desde, hasta, TagsOk, Rango, Salida, File)
                End If
            End If

        End If

        If (RadioBtnMensual.Checked) Then
            Rango = 3
            File = "EDAR_InformeMensual.pdf"

            If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then
                GeneraInformeAnaMonth("Tot", desde, hasta, TagsOk, Rango, Salida, File)
            Else
                If (CheckBoxAnaIncuTot.Checked) Then
                    GeneraInformeAnaMonth("AnaTot", desde, hasta, TagsOk, Rango, Salida, File)
                Else
                    GeneraInformeAnaMonth("Ana", desde, hasta, TagsOk, Rango, Salida, File)
                End If
            End If
        End If

        If (RadioBtnLibre.Checked) Then
            If (RadioBtnLibrePorHoras.Checked) Then
                Rango = 0
                File = "EDAR_InformeLibrePorHoras.pdf"

                If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then
                    GeneraInformeAnaLibHoras("Tot", desde, hasta, TagsOk, Rango, Salida, File) ' "Dig" "Man" "DigMan"
                Else
                    If (CheckBoxAnaIncuTot.Checked) Then
                        GeneraInformeAnaLibHoras("AnaTot", desde, hasta, TagsOk, Rango, Salida, File)
                    Else
                        GeneraInformeAnaLibHoras("Ana", desde, hasta, TagsOk, Rango, Salida, File)
                    End If
                End If
            End If

            If (RadioBtnLibrePorDias.Checked) Then
                Rango = 1
                File = "EDAR_InformeLibrePorDias.pdf"

                If (RadioBtnTotalizadoresDeAnalogicas.Checked) Then
                    GeneraInformeAnaLibDias("Tot", desde, hasta, TagsOk, Rango, Salida, File)
                Else
                    If (CheckBoxAnaIncuTot.Checked) Then
                        GeneraInformeAnaLibDias("AnaTot", desde, hasta, TagsOk, Rango, Salida, File)
                    Else
                        GeneraInformeAnaLibDias("Ana", desde, hasta, TagsOk, Rango, Salida, File)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GeneraInformeAnaLibHoras(Info As String, FechaIni As Date, FechaFin As Date, Tags As String, Tipo As Int32, Mode As Int32, FileOut As String)
#Region "Declaraciones"
        lblLog.Text = ""
        Dim Rango As Integer = 0 'Tipo de informe
        Dim SqlOut As String = "use ✏️;"
        Dim SqlIn1 As String
        Dim SqlIn2 As String
        Dim Sql1 As String
        Dim Sql2 As String
        '************************************************

        Dim _Total As Stopwatch = New Stopwatch()
        Dim _Sql1 As Stopwatch = New Stopwatch()
        Dim _Sql2 As Stopwatch = New Stopwatch()
        Dim _SqlTotal As Stopwatch = New Stopwatch()
        Dim _CreaDt As Stopwatch = New Stopwatch()
        Dim _CreaInforme As Stopwatch = New Stopwatch()
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim IndexOutOk As String = ""
        Dim RecIndex As DataTable = Nothing
#End Region ' Declaraciones
        Dim SqlIndexOut = "declare @tags nvarchar(max)
                        set @tags = '" + TagsOk + "'
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName
 						Left JOIN DigNmanTAutReportTable D
                        ON D.TagName = A.TagName
                        where A.TagIndex in (select * from STRING_SPLIT(@tags, ','))
                        Order by A.TagIndex"
        'Inicia
        PanelAvisos.Visible = True
        lblAviso.Text = "Ejecutando Query Totalizadores.... Espere"
        Application.DoEvents()
        '************************************************
        SqlIn1 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + TagsOk + "'
                 set @timeBase = " + Convert.ToString(Tipo) + "" ' IndexOutOk para mode 104
        _Total.Start()
        _SqlTotal.Start()
        _Sql1.Start()

        Dim dt1 As DataTable = New DataTable()
        Dim Ok As Boolean = False
        Ok = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn1, IndexOutOk, RecIndex, dt1)
        Dim count As Integer = dt1.Rows.Count

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos de totalizadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _Sql1.[Stop]()
        lblAviso.Text = "Ejecutando Query Tiempos...... Espere"
        Application.DoEvents()
        '************************************************
        _Sql2.Start()
        SqlIn2 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + IndexOutOk + "'
                 set @timeBase = 4"    'TagsOk para mode 0
        lblAviso.Text = "Ejecutando Query Analógicas... Espere"
        Application.DoEvents()

        Dim dt2 As DataTable = Nothing
        Dim Ok3 As Boolean
        Ok3 = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn2, IndexOutOk, RecIndex, dt2)
        Dim count3 As Integer = dt2.Rows.Count

        If Ok3 = False Then
            MessageBox.Show("No se ha encontrado datos Analógicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim dtOut As DataTable
        dtOut = GrowDt(dt1, dt2) '''
        _Sql2.[Stop]()
        '************************************************
        lblAviso.Text = "Añadiendo Totalizadores... Espere"
        Application.DoEvents()
        _CreaDt.Start()
        Dim Columnas As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT", "DayT",
                            "TOT_Ini00", "TOT_Dif00", "TOT_Fin00", "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                            "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06", "TOT_Ini07", "TOT_Dif07", "TOT_Fin07",
                            "TOT_Ini08", "TOT_Dif08", "TOT_Fin08", "TOT_Ini09", "TOT_Dif09", "TOT_Fin09", "TOT_Ini10", "TOT_Dif10", "TOT_Fin10", "TOT_Ini11", "TOT_Dif11", "TOT_Fin11",
                            "TOT_Ini12", "TOT_Dif12", "TOT_Fin12", "TOT_Ini13", "TOT_Dif13", "TOT_Fin13", "TOT_Ini14", "TOT_Dif14", "TOT_Fin14", "TOT_Ini15", "TOT_Dif15", "TOT_Fin15",
                            "TOT_Ini16", "TOT_Dif16", "TOT_Fin16", "TOT_Ini17", "TOT_Dif17", "TOT_Fin17", "TOT_Ini18", "TOT_Dif18", "TOT_Fin18", "TOT_Ini19", "TOT_Dif19", "TOT_Fin19",
                            "TOT_Ini20", "TOT_Dif20", "TOT_Fin20", "TOT_Ini21", "TOT_Dif21", "TOT_Fin21", "TOT_Ini22", "TOT_Dif22", "TOT_Fin22", "TOT_Ini23", "TOT_Dif23", "TOT_Fin23"}
        Dim dtAll As DataTable
        dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Day")
        '************************************************
        _SqlTotal.[Stop]()
        _CreaDt.[Stop]()
        lblAviso.Text = "Creando el informe... Espere"
        Application.DoEvents()
        _CreaInforme.Start()
        InformeAnaLibHoras(Info, dtAll, FechaIni, FechaFin, Tipo, Mode, FileOut) 'Tipo = Tipo datos en informe   'Mode= 0= Pantalla 1= PDF
        _CreaInforme.[Stop]()
        _Total.[Stop]()
        lblAviso.Text = ""
        PanelAvisos.Visible = False
        lblLog.Text = ">Tiempo T O T A L = " + _Total.Elapsed.Seconds.ToString() & "(s)," + _Total.Elapsed.Milliseconds.ToString() & "(ms) 
                       >SqlAna=" + _Sql1.Elapsed.Seconds.ToString() & "(s)," + _Sql1.Elapsed.Milliseconds.ToString() & "(ms)  
                       >SqlIndex=" + _Sql2.Elapsed.Seconds.ToString() & "(s)," + _Sql2.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Total Sql= " + _SqlTotal.Elapsed.Seconds.ToString() & "(s)," + _SqlTotal.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea dt= " + _CreaDt.Elapsed.Seconds.ToString() & "(s)," + _CreaDt.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea Informe= " + _CreaInforme.Elapsed.Seconds.ToString() & "(s)," + _CreaInforme.Elapsed.Milliseconds.ToString() & "(ms) "
        Application.DoEvents()
    End Sub
    Private Sub InformeAnaLibHoras(Info As String, ByVal dtOut As DataTable, FechaIni As Date, FechaFin As Date, Tipo As Int32, Mode As Int32, FileOut As String)
        If Info = "AnaTot" Then
            If Tipo = 0 Then
                If Mode = 0 Then
                    Dim Report1 As XRptAnaHourTot = New XRptAnaHourTot()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptAnaHourTot = New XRptAnaHourTot()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If
        If Info = "Ana" Then
            If Tipo = 0 Then
                If Mode = 0 Then
                    Dim Report1 As XRptAnaHour = New XRptAnaHour()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptAnaHour = New XRptAnaHour()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If
        If Info = "Tot" Then
            If Tipo = 0 Then
                If Mode = 0 Then
                    Dim Report1 As XRptManHourDeDig = New XRptManHourDeDig()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptManHourDeDig = New XRptManHourDeDig()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If

    End Sub
    Private Sub GeneraInformeAnaLibDias(Info As String, FechaIni As Date, FechaFin As Date, Tags As String, Tipo As Int32, Mode As Int32, FileOut As String)
#Region "Declaraciones"
        lblLog.Text = ""
        Dim Rango As Integer = 0 'Tipo de informe
        Dim SqlOut As String = "use ✏️;"
        Dim SqlIn1 As String
        Dim SqlIn2 As String
        Dim Sql1 As String
        Dim Sql2 As String
        '************************************************

        Dim _Total As Stopwatch = New Stopwatch()
        Dim _Sql1 As Stopwatch = New Stopwatch()
        Dim _Sql2 As Stopwatch = New Stopwatch()
        Dim _SqlTotal As Stopwatch = New Stopwatch()
        Dim _CreaDt As Stopwatch = New Stopwatch()
        Dim _CreaInforme As Stopwatch = New Stopwatch()
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim IndexOutOk As String = ""
        Dim RecIndex As DataTable = Nothing
#End Region ' Declaraciones

        Dim SqlIndexOut = "declare @tags nvarchar(max)
                        set @tags = '" + TagsOk + "'
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName            
						Left JOIN DigNmanTAutReportTable D
                        ON D.TagName = A.TagName
                        where A.TagIndex in (select * from STRING_SPLIT(@tags, ','))
                        Order by A.TagIndex"
        'Inicia
        PanelAvisos.Visible = True
        lblAviso.Text = "Ejecutando Query Totalizadores.... Espere"
        Application.DoEvents()

        '************************************************
        SqlIn1 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + TagsOk + "'
                 set @timeBase = " + Convert.ToString(Tipo) + "" ' IndexOutOk para mode 105

        _Total.Start()
        _SqlTotal.Start()
        _Sql1.Start()

        Dim dt1 As DataTable = New DataTable()
        Dim Ok As Boolean = False
        Ok = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn1, IndexOutOk, RecIndex, dt1)
        Dim count As Integer = dt1.Rows.Count

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos de totalizadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _Sql1.[Stop]()
        lblAviso.Text = "Ejecutando Query Totalizadores...... Espere"
        Application.DoEvents()
        _Sql1.[Stop]()
        '************************************************

        _Sql2.Start()

        SqlIn2 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + IndexOutOk + "'
                 set @timeBase = 5"    'TagsOk para mode 1

        lblAviso.Text = "Ejecutando Query Analógicas... Espere"
        Application.DoEvents()

        Dim dt2 As DataTable = Nothing
        Dim Ok3 As Boolean

        Ok3 = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn2, IndexOutOk, RecIndex, dt2)
        Dim count3 As Integer = dt2.Rows.Count

        If Ok3 = False Then
            MessageBox.Show("No se ha encontrado datos Analógicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim dtOut As DataTable
        dtOut = GrowDt(dt1, dt2) '''
        _Sql2.[Stop]()
        '************************************************

        lblAviso.Text = "Añadiendo Totalizadores... Espere"
        Application.DoEvents()
        _CreaDt.Start()

        Dim Columnas As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT", "DayT",
            "TOT_Ini", "TOT_Dif", "TOT_Fin", "TOT_TOT_Ini", "TOT_TOT_Dif", "TOT_TOT_Fin"}

        Dim dtAll As DataTable
        dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Day")
        '************************************************
        _SqlTotal.[Stop]()
        _CreaDt.[Stop]()
        lblAviso.Text = "Creando el informe... Espere"
        Application.DoEvents()
        _CreaInforme.Start()

        InformeAnaLibDias(Info, dtAll, FechaIni, FechaFin, Tipo, Mode, FileOut) 'Tipo = Tipo datos en informe   'Mode= 0= Pantalla 1= PDF

        _CreaInforme.[Stop]()
        _Total.[Stop]()
        lblAviso.Text = ""
        PanelAvisos.Visible = False
        Application.DoEvents()

        lblLog.Text = ">Tiempo T O T A L = " + _Total.Elapsed.Seconds.ToString() & "(s)," + _Total.Elapsed.Milliseconds.ToString() & "(ms) 
                       >SqlAna=" + _Sql1.Elapsed.Seconds.ToString() & "(s)," + _Sql1.Elapsed.Milliseconds.ToString() & "(ms)  
                       >SqlIndex=" + _Sql2.Elapsed.Seconds.ToString() & "(s)," + _Sql2.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Total Sql= " + _SqlTotal.Elapsed.Seconds.ToString() & "(s)," + _SqlTotal.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea dt= " + _CreaDt.Elapsed.Seconds.ToString() & "(s)," + _CreaDt.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea Informe= " + _CreaInforme.Elapsed.Seconds.ToString() & "(s)," + _CreaInforme.Elapsed.Milliseconds.ToString() & "(ms) "
    End Sub
    Private Sub InformeAnaLibDias(Info As String, ByVal dtOut As DataTable, FechaIni As Date, FechaFin As Date, Tipo As Int32, Mode As Int32, FileOut As String)
        If Info = "AnaTot" Then
            If Tipo = 1 Then
                If Mode = 0 Then
                    Dim Report1 As XRptAnaDayTot = New XRptAnaDayTot()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptAnaDayTot = New XRptAnaDayTot()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If
        If Info = "Ana" Then
            If Tipo = 1 Then
                If Mode = 0 Then
                    Dim Report1 As XRptAnaDay = New XRptAnaDay()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptAnaDay = New XRptAnaDay()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If
        If Info = "Tot" Then
            If Tipo = 1 Then
                If Mode = 0 Then
                    Dim Report1 As XRptVtotDayDeAna = New XRptVtotDayDeAna()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptVtotDayDeAna = New XRptVtotDayDeAna()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If

    End Sub
    Private Sub GeneraInformeAnaWeek(Info As String, FechaIni As Date, FechaFin As Date, Tags As String, Tipo As Int32, Mode As Int32, FileOut As String)
#Region "Declaraciones"
        lblLog.Text = ""
        Dim Rango As Integer = 0 'Tipo de informe
        Dim SqlOut As String = "use ✏️;"
        Dim SqlIn1 As String
        Dim SqlIn2 As String
        Dim Sql1 As String
        Dim Sql2 As String

        '************************************************

        Dim _Total As Stopwatch = New Stopwatch()
        Dim _Sql1 As Stopwatch = New Stopwatch()
        Dim _Sql2 As Stopwatch = New Stopwatch()
        Dim _SqlTotal As Stopwatch = New Stopwatch()
        Dim _CreaDt As Stopwatch = New Stopwatch()
        Dim _CreaInforme As Stopwatch = New Stopwatch()
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim IndexOutOk As String = ""
        Dim RecIndex As DataTable = Nothing
#End Region ' Declaraciones

        Dim SqlIndexOut = "declare @tags nvarchar(max)
                        set @tags = '" + TagsOk + "'
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName
						Left JOIN DigNmanTAutReportTable D
                        ON D.TagName = A.TagName
                        where A.TagIndex in (select * from STRING_SPLIT(@tags, ','))
                        Order by A.TagIndex"

        'Inicia
        PanelAvisos.Visible = True
        lblAviso.Text = "Ejecutando Query Totalizadores.... Espere"
        Application.DoEvents()

        '************************************************
        SqlIn1 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + TagsOk + "'
                 set @timeBase = " + Convert.ToString(Tipo) + "" ' IndexOutOk para mode 105

        _Total.Start()
        _SqlTotal.Start()
        _Sql1.Start()

        Dim dt1 As DataTable = New DataTable()
        Dim Ok As Boolean = False

        Ok = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn1, IndexOutOk, RecIndex, dt1)
        Dim count As Integer = dt1.Rows.Count

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos de Totalizadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        _Sql1.[Stop]()
        lblAviso.Text = "Ejecutando Query Totalizadores...... Espere"
        Application.DoEvents()
        '************************************************

        _Sql2.Start()

        SqlIn2 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + IndexOutOk + "'
                 set @timeBase = 4"

        lblAviso.Text = "Ejecutando Query Aalogicas... Espere"
        Application.DoEvents()

        Dim dt2 As DataTable = Nothing
        Dim Ok3 As Boolean

        Ok3 = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn2, IndexOutOk, RecIndex, dt2)
        Dim count3 As Integer = dt2.Rows.Count

        If Ok3 = False Then
            MessageBox.Show("No se ha encontrado datos Analógicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        Dim dtOut As DataTable
        dtOut = GrowDt(dt1, dt2) '''
        _Sql2.[Stop]()
        '************************************************

        lblAviso.Text = "Añadiendo Totalizadores Tiempos... Espere"
        Application.DoEvents()
        _CreaDt.Start()

        Dim Columnas As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT", "DayT",
                            "TOT_Ini00", "TOT_Dif00", "TOT_Fin00", "TOT_Ini01", "TOT_Dif01", "TOT_Fin01",
                            "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                            "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05",
                            "TOT_Ini06", "TOT_Dif06", "TOT_Fin06"}

        Dim dtAll As DataTable
        dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Week")
        '************************************************
        _SqlTotal.[Stop]()
        _CreaDt.[Stop]()
        lblAviso.Text = "Creando el informe... Espere"
        Application.DoEvents()
        _CreaInforme.Start()

        InformeAnaWeek(Info, dtAll, FechaIni, FechaFin, Tipo, Mode, FileOut) 'Tipo = Tipo datos en informe   'Mode= 0= Pantalla 1= PDF
        _CreaInforme.[Stop]()
        _Total.[Stop]()
        lblAviso.Text = ""
        PanelAvisos.Visible = False
        Application.DoEvents()

        lblLog.Text = ">Tiempo T O T A L = " + _Total.Elapsed.Seconds.ToString() & "(s)," + _Total.Elapsed.Milliseconds.ToString() & "(ms) 
                       >SqlAna=" + _Sql1.Elapsed.Seconds.ToString() & "(s)," + _Sql1.Elapsed.Milliseconds.ToString() & "(ms)  
                       >SqlIndex=" + _Sql2.Elapsed.Seconds.ToString() & "(s)," + _Sql2.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Total Sql= " + _SqlTotal.Elapsed.Seconds.ToString() & "(s)," + _SqlTotal.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea dt= " + _CreaDt.Elapsed.Seconds.ToString() & "(s)," + _CreaDt.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea Informe= " + _CreaInforme.Elapsed.Seconds.ToString() & "(s)," + _CreaInforme.Elapsed.Milliseconds.ToString() & "(ms) "
    End Sub
    Private Sub InformeAnaWeek(Info As String, ByVal dtOut As DataTable, FechaIni As Date, FechaFin As Date, Tipo As Int32, Mode As Int32, FileOut As String)
        If Info = "AnaTot" Then
            If Tipo = 2 Then
                If Mode = 0 Then
                    Dim Report1 As XRptAnaTotWeek = New XRptAnaTotWeek()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptAnaTotWeek = New XRptAnaTotWeek()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If
        If Info = "Ana" Then
            If Tipo = 2 Then
                If Mode = 0 Then
                    Dim Report1 As XRptAnaWeek = New XRptAnaWeek()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptAnaWeek = New XRptAnaWeek()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If
        If Info = "Tot" Then
            If Tipo = 2 Then
                If Mode = 0 Then
                    Dim Report1 As XRptTotWeek = New XRptTotWeek()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                    Tool.ShowPreview()
                End If

                If Mode = 1 Then
                    Dim Report1 As XRptTotWeek = New XRptTotWeek()
                    Report1.DataSource = dtOut

                    Dim parameter0 As New Parameter()
                    parameter0.Name = "NombreInstalacion"
                    parameter0.Type = GetType(System.String)
                    parameter0.Value = Datos.NombreInstalacion
                    parameter0.Visible = False
                    Report1.Parameters.Add(parameter0)

                    Dim parameter1 As New Parameter()
                    parameter1.Name = "FechaIni"
                    parameter1.Type = GetType(System.DateTime)
                    parameter1.Value = FechaIni
                    parameter1.Visible = False
                    Report1.Parameters.Add(parameter1)

                    Dim parameter2 As New Parameter()
                    parameter2.Name = "FechaFin"
                    parameter2.Type = GetType(System.DateTime)
                    parameter2.Value = FechaFin
                    parameter2.Visible = False
                    Report1.Parameters.Add(parameter2)
                    Report1.RequestParameters = False
                    Report1.ExportToPdf(FileOut)
                    lblAviso.Text = "Abriendo Visor PDF.... Espere"
                    Application.DoEvents()
                    OpenReport(FileOut)
                    PanelAvisos.Visible = False
                End If
            End If
        End If

    End Sub
    Private Sub GeneraInformeAnaMonth(Info As String, FechaIni As Date, FechaFin As Date, Tags As String, Tipo As Int32, Mode As Int32, FileOut As String)

#Region "Declaraciones"
        lblLog.Text = ""
        Dim Rango As Integer = 0 'Tipo de informe
        Dim SqlOut As String = "use ✏️;"
        Dim SqlIn1 As String
        Dim SqlIn2 As String
        Dim Sql1 As String
        Dim Sql2 As String
        '************************************************

        Dim _Total As Stopwatch = New Stopwatch()
        Dim _Sql1 As Stopwatch = New Stopwatch()
        Dim _Sql2 As Stopwatch = New Stopwatch()
        Dim _SqlTotal As Stopwatch = New Stopwatch()
        Dim _CreaDt As Stopwatch = New Stopwatch()
        Dim _CreaInforme As Stopwatch = New Stopwatch()
        Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
        Dim IndexOutOk As String = ""
        Dim RecIndex As DataTable = Nothing
#End Region ' Declaraciones

        Dim SqlIndexOut = "declare @tags nvarchar(max)
                        set @tags = '" + TagsOk + "'
		
                        SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName
						Left JOIN DigNmanTAutReportTable D
                        ON D.TagName = A.TagName
                        where A.TagIndex in (select * from STRING_SPLIT(@tags, ','))
                        Order by A.TagIndex"

        'Inicia
        PanelAvisos.Visible = True
        lblAviso.Text = "Ejecutando Query Totalizadores.... Espere"
        Application.DoEvents()

        '************************************************
        SqlIn1 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + TagsOk + "'
                 set @timeBase = " + Convert.ToString(Tipo) + "" ' IndexOutOk para mode 105

        _Total.Start()
        _SqlTotal.Start()
        _Sql1.Start()

        Dim dt1 As DataTable = New DataTable()
        Dim Ok As Boolean = False

        Ok = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn1, IndexOutOk, RecIndex, dt1)
        Dim count As Integer = dt1.Rows.Count

        If Ok = False Then
            MessageBox.Show("No se ha encontrado datos de totalizadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        lblAviso.Text = "Ejecutando Query Totalizadores...... Espere"
        Application.DoEvents()
        _Sql1.[Stop]()
        '************************************************

        _Sql2.Start()
        SqlIn2 = "use Datos
                 declare @timeBase integer
                 declare @fechaini datetime2
                 declare @fechafin datetime2
                 declare @tags nvarchar(max)

                 set @fechaini = '" + FechaIni + "'
                 set @fechafin = '" + FechaFin + "'
                 set @tags = '" + IndexOutOk + "'
                 set @timeBase = 6"



        lblAviso.Text = "Ejecutando Query Analógicas... Espere"
        Application.DoEvents()

        Dim dt2 As DataTable = Nothing
        Dim Ok3 As Boolean

        Ok3 = ConsultaToDt(Datos.SQLCommandStringData_dsAnalog, SqlIndexOut, SqlIn2, IndexOutOk, RecIndex, dt2)
        Dim count3 As Integer = dt2.Rows.Count

        If Ok3 = False Then
            MessageBox.Show("No se ha encontrado datos Analógicos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim dtOut As DataTable
        dtOut = GrowDt(dt1, dt2) '''
        _Sql2.[Stop]()
        '************************************************

        lblAviso.Text = "Añadiendo Totalizadores... Espere"
        Application.DoEvents()
        _CreaDt.Start()

        Dim Columnas As String() = {"TagIndexT", "TagOnlyNameT", "TagDescriptionT", "TagUnitT",
                                "TOT_Ini01", "TOT_Dif01", "TOT_Fin01", "TOT_Ini02", "TOT_Dif02", "TOT_Fin02", "TOT_Ini03", "TOT_Dif03", "TOT_Fin03",
                                "TOT_Ini04", "TOT_Dif04", "TOT_Fin04", "TOT_Ini05", "TOT_Dif05", "TOT_Fin05", "TOT_Ini06", "TOT_Dif06", "TOT_Fin06", "TOT_Ini07", "TOT_Dif07", "TOT_Fin07",
                                "TOT_Ini08", "TOT_Dif08", "TOT_Fin08", "TOT_Ini09", "TOT_Dif09", "TOT_Fin09", "TOT_Ini10", "TOT_Dif10", "TOT_Fin10", "TOT_Ini11", "TOT_Dif11", "TOT_Fin11",
                                "TOT_Ini12", "TOT_Dif12", "TOT_Fin12", "TOT_Ini13", "TOT_Dif13", "TOT_Fin13", "TOT_Ini14", "TOT_Dif14", "TOT_Fin14", "TOT_Ini15", "TOT_Dif15", "TOT_Fin15",
                                "TOT_Ini16", "TOT_Dif16", "TOT_Fin16", "TOT_Ini17", "TOT_Dif17", "TOT_Fin17", "TOT_Ini18", "TOT_Dif18", "TOT_Fin18", "TOT_Ini19", "TOT_Dif19", "TOT_Fin19",
                                "TOT_Ini20", "TOT_Dif20", "TOT_Fin20", "TOT_Ini21", "TOT_Dif21", "TOT_Fin21", "TOT_Ini22", "TOT_Dif22", "TOT_Fin22", "TOT_Ini23", "TOT_Dif23", "TOT_Fin23",
                                "TOT_Ini24", "TOT_Dif24", "TOT_Fin24", "TOT_Ini25", "TOT_Dif25", "TOT_Fin25", "TOT_Ini26", "TOT_Dif26", "TOT_Fin26", "TOT_Ini27", "TOT_Dif27", "TOT_Fin27",
                                "TOT_Ini28", "TOT_Dif28", "TOT_Fin28", "TOT_Ini29", "TOT_Dif29", "TOT_Fin29", "TOT_Ini30", "TOT_Dif30", "TOT_Fin30", "TOT_Ini31", "TOT_Dif31", "TOT_Fin31"}

        Dim dtAll As DataTable
        dtAll = AllDt(".OFValTotSumCal", Columnas, dtOut, RecIndex, dt2, "Month")
        '************************************************

        _SqlTotal.[Stop]()
        _CreaDt.[Stop]()
        lblAviso.Text = "Creando el informe... Espere"
        Application.DoEvents()
        _CreaInforme.Start()

        InformeAnaMonth(Info, dtAll, FechaIni, FechaFin, Tipo, Mode, FileOut) 'Tipo = Tipo datos en informe   'Mode= 0= Pantalla 1= PDF

        _CreaInforme.[Stop]()
        _Total.[Stop]()
        lblAviso.Text = ""
        PanelAvisos.Visible = False
        Application.DoEvents()

        lblLog.Text = ">Tiempo T O T A L = " + _Total.Elapsed.Seconds.ToString() & "(s)," + _Total.Elapsed.Milliseconds.ToString() & "(ms) 
                       >SqlAna=" + _Sql1.Elapsed.Seconds.ToString() & "(s)," + _Sql1.Elapsed.Milliseconds.ToString() & "(ms)  
                       >SqlIndex=" + _Sql2.Elapsed.Seconds.ToString() & "(s)," + _Sql2.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Total Sql= " + _SqlTotal.Elapsed.Seconds.ToString() & "(s)," + _SqlTotal.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea dt= " + _CreaDt.Elapsed.Seconds.ToString() & "(s)," + _CreaDt.Elapsed.Milliseconds.ToString() & "(ms)  
                       >Crea Informe= " + _CreaInforme.Elapsed.Seconds.ToString() & "(s)," + _CreaInforme.Elapsed.Milliseconds.ToString() & "(ms) "
    End Sub
    Private Sub InformeAnaMonth(Info As String, ByVal dtOut As DataTable, FechaIni As Date, FechaFin As Date, Tipo As Int32, Mode As Int32, FileOut As String)

        Dim selectedDate As DateTime = dTPickerFechaHasta.Value
        Dim dayOfMonth As Integer = selectedDate.Day

        If dayOfMonth = 28 Then
            'Mount28
            If Info = "AnaTot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaTotMonth28 = New XRptAnaTotMonth28()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaTotMonth28 = New XRptAnaTotMonth28()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Ana" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaMonth28 = New XRptAnaMonth28()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaMonth28 = New XRptAnaMonth28()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Tot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptManMonth28 = New XRptManMonth28()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptManMonth28 = New XRptManMonth28()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
        End If
        If dayOfMonth = 29 Then
            'Mount29
            If Info = "AnaTot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaTotMonth29 = New XRptAnaTotMonth29()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaTotMonth29 = New XRptAnaTotMonth29()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Ana" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaMonth29 = New XRptAnaMonth29()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaMonth29 = New XRptAnaMonth29()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Tot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptManMonth29 = New XRptManMonth29()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptManMonth29 = New XRptManMonth29()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
        End If
        If dayOfMonth = 30 Then
            'Mount30
            If Info = "AnaTot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaTotMonth30 = New XRptAnaTotMonth30()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaTotMonth30 = New XRptAnaTotMonth30()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Ana" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaMonth30 = New XRptAnaMonth30()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaMonth30 = New XRptAnaMonth30()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Tot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptManMonth30 = New XRptManMonth30()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptManMonth30 = New XRptManMonth30()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
        End If
        If dayOfMonth = 31 Then
            'Mount31
            If Info = "AnaTot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaTotMonth = New XRptAnaTotMonth()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaTotMonth = New XRptAnaTotMonth()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Ana" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptAnaMonth31 = New XRptAnaMonth31()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptAnaMonth31 = New XRptAnaMonth31()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
            If Info = "Tot" Then
                If Tipo = 3 Then
                    If Mode = 0 Then
                        Dim Report1 As XRptManMonth31 = New XRptManMonth31()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Dim Tool As ReportPrintTool = New ReportPrintTool(Report1)
                        Tool.ShowPreview()
                    End If

                    If Mode = 1 Then
                        Dim Report1 As XRptManMonth31 = New XRptManMonth31()
                        Report1.DataSource = dtOut

                        Dim parameter0 As New Parameter()
                        parameter0.Name = "NombreInstalacion"
                        parameter0.Type = GetType(System.String)
                        parameter0.Value = Datos.NombreInstalacion
                        parameter0.Visible = False
                        Report1.Parameters.Add(parameter0)

                        Dim parameter1 As New Parameter()
                        parameter1.Name = "FechaIni"
                        parameter1.Type = GetType(System.DateTime)
                        parameter1.Value = FechaIni
                        parameter1.Visible = False
                        Report1.Parameters.Add(parameter1)

                        Dim parameter2 As New Parameter()
                        parameter2.Name = "FechaFin"
                        parameter2.Type = GetType(System.DateTime)
                        parameter2.Value = FechaFin
                        parameter2.Visible = False
                        Report1.Parameters.Add(parameter2)
                        Report1.RequestParameters = False
                        Report1.ExportToPdf(FileOut)
                        lblAviso.Text = "Abriendo Visor PDF.... Espere"
                        Application.DoEvents()
                        OpenReport(FileOut)
                        PanelAvisos.Visible = False
                    End If
                End If
            End If
        End If

    End Sub

#End Region 'Genero Informe

#Region "xxx"
    ' Code
#End Region ' xxx

End Class

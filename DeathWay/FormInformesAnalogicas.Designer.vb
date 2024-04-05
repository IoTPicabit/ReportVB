<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInformesAnalogicas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormInformesAnalogicas))
        ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        dTPickerHastaHora = New DateTimePicker()
        dTPickerFechaHasta = New DateTimePicker()
        dTPickerDesdeHora = New DateTimePicker()
        dTPickerFechaDesde = New DateTimePicker()
        dgv = New DataGridView()
        Label4 = New Label()
        btnInicializar = New Button()
        PanelAvisos = New Panel()
        lblAviso = New Label()
        StackPanel1 = New DevExpress.Utils.Layout.StackPanel()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        CheckBoxAnaValMini = New CheckBox()
        CheckBoxAnaValMax = New CheckBox()
        Panel1 = New Panel()
        Panel4 = New Panel()
        Panel5 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        CheckBoxDigi_y_TotFin = New CheckBox()
        CheckBoxDigi_y_TotIni = New CheckBox()
        Label8 = New Label()
        RadioBtnDiario = New RadioButton()
        RadioBtnSemanal = New RadioButton()
        RadioBtnMensual = New RadioButton()
        RadioBtnLibre = New RadioButton()
        Panel6 = New Panel()
        Panel7 = New Panel()
        Panel8 = New Panel()
        Panel9 = New Panel()
        RadioBtnLibrePorDias = New RadioButton()
        RadioBtnLibrePorHoras = New RadioButton()
        Panel10 = New Panel()
        PanelGrupo1 = New Panel()
        PanelGrupo2 = New Panel()
        Panel11 = New Panel()
        Panel12 = New Panel()
        Panel13 = New Panel()
        Panel14 = New Panel()
        PanelGrupo3 = New Panel()
        RadioBtnPdf = New RadioButton()
        RadioBtnPantalla = New RadioButton()
        BtnInforme = New Button()
        CheckBoxAnaIncuTot = New CheckBox()
        Panel15 = New Panel()
        RadioBtnAnalogicasOnly = New RadioButton()
        RadioBtnTotalizadoresDeAnalogicas = New RadioButton()
        Panel16 = New Panel()
        Panel17 = New Panel()
        Panel18 = New Panel()
        Panel19 = New Panel()
        lblLog = New Label()
        blbForzar2 = New Label()
        BtnSalvar = New Button()
        ComBoxConsultas = New ComboBox()
        BtnBorrar = New Button()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        PanelAvisos.SuspendLayout()
        CType(StackPanel1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        PanelGrupo1.SuspendLayout()
        PanelGrupo2.SuspendLayout()
        Panel11.SuspendLayout()
        Panel12.SuspendLayout()
        PanelGrupo3.SuspendLayout()
        Panel15.SuspendLayout()
        Panel16.SuspendLayout()
        Panel17.SuspendLayout()
        SuspendLayout()
        ' 
        ' ReportViewer1
        ' 
        ReportViewer1.Location = New Point(0, 0)
        ReportViewer1.Name = "ReportViewer"
        ReportViewer1.ServerReport.BearerToken = Nothing
        ReportViewer1.Size = New Size(396, 246)
        ReportViewer1.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.Blue
        Label3.Location = New Point(833, 692)
        Label3.Name = "Label3"
        Label3.Size = New Size(61, 21)
        Label3.TabIndex = 26
        Label3.Text = "Hasta :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.Blue
        Label2.Location = New Point(833, 660)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 21)
        Label2.TabIndex = 25
        Label2.Text = "Desde :"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.ButtonShadow
        Label1.Location = New Point(961, 741)
        Label1.Name = "Label1"
        Label1.Size = New Size(271, 15)
        Label1.TabIndex = 24
        Label1.Text = "Forzar A: 2023-03-01 00:00:00   2023-03-02 23:59:59"
        Label1.Visible = False
        ' 
        ' dTPickerHastaHora
        ' 
        dTPickerHastaHora.Format = DateTimePickerFormat.Time
        dTPickerHastaHora.Location = New Point(1150, 691)
        dTPickerHastaHora.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerHastaHora.MinDate = New Date(2023, 1, 1, 0, 0, 0, 0)
        dTPickerHastaHora.Name = "dTPickerHastaHora"
        dTPickerHastaHora.Size = New Size(75, 23)
        dTPickerHastaHora.TabIndex = 23
        ' 
        ' dTPickerFechaHasta
        ' 
        dTPickerFechaHasta.Location = New Point(903, 691)
        dTPickerFechaHasta.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerFechaHasta.MinDate = New Date(2022, 1, 1, 0, 0, 0, 0)
        dTPickerFechaHasta.Name = "dTPickerFechaHasta"
        dTPickerFechaHasta.Size = New Size(237, 23)
        dTPickerFechaHasta.TabIndex = 22
        ' 
        ' dTPickerDesdeHora
        ' 
        dTPickerDesdeHora.Format = DateTimePickerFormat.Time
        dTPickerDesdeHora.Location = New Point(1150, 660)
        dTPickerDesdeHora.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerDesdeHora.MinDate = New Date(2023, 1, 1, 0, 0, 0, 0)
        dTPickerDesdeHora.Name = "dTPickerDesdeHora"
        dTPickerDesdeHora.Size = New Size(75, 23)
        dTPickerDesdeHora.TabIndex = 21
        ' 
        ' dTPickerFechaDesde
        ' 
        dTPickerFechaDesde.Location = New Point(903, 660)
        dTPickerFechaDesde.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerFechaDesde.MinDate = New Date(2022, 1, 1, 0, 0, 0, 0)
        dTPickerFechaDesde.Name = "dTPickerFechaDesde"
        dTPickerFechaDesde.Size = New Size(237, 23)
        dTPickerFechaDesde.TabIndex = 20
        ' 
        ' dgv
        ' 
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgv.DefaultCellStyle = DataGridViewCellStyle2
        dgv.Location = New Point(14, 33)
        dgv.Name = "dgv"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgv.RowTemplate.Height = 25
        dgv.Size = New Size(1218, 550)
        dgv.TabIndex = 31
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.ForeColor = Color.Blue
        Label4.Location = New Point(12, 9)
        Label4.Name = "Label4"
        Label4.Size = New Size(221, 21)
        Label4.TabIndex = 32
        Label4.Text = "Señales Informe Analógicas"
        ' 
        ' btnInicializar
        ' 
        btnInicializar.Location = New Point(1155, 9)
        btnInicializar.Name = "btnInicializar"
        btnInicializar.Size = New Size(75, 23)
        btnInicializar.TabIndex = 33
        btnInicializar.Text = "Inicializar"
        btnInicializar.UseVisualStyleBackColor = True
        ' 
        ' PanelAvisos
        ' 
        PanelAvisos.BackColor = Color.Silver
        PanelAvisos.Controls.Add(lblAviso)
        PanelAvisos.Location = New Point(37, 139)
        PanelAvisos.Name = "PanelAvisos"
        PanelAvisos.Size = New Size(1166, 100)
        PanelAvisos.TabIndex = 34
        PanelAvisos.Visible = False
        ' 
        ' lblAviso
        ' 
        lblAviso.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblAviso.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point)
        lblAviso.ForeColor = Color.Blue
        lblAviso.Location = New Point(11, 17)
        lblAviso.Name = "lblAviso"
        lblAviso.Size = New Size(1152, 65)
        lblAviso.TabIndex = 0
        lblAviso.Text = "---"
        lblAviso.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' StackPanel1
        ' 
        StackPanel1.Location = New Point(445, 627)
        StackPanel1.Name = "StackPanel1"
        StackPanel1.Size = New Size(8, 8)
        StackPanel1.TabIndex = 35
        StackPanel1.UseSkinIndents = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.Blue
        Label5.Location = New Point(12, 593)
        Label5.Name = "Label5"
        Label5.Size = New Size(184, 21)
        Label5.TabIndex = 36
        Label5.Text = "Configuración Informe"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = Color.Blue
        Label6.Location = New Point(23, 619)
        Label6.Name = "Label6"
        Label6.Size = New Size(179, 17)
        Label6.TabIndex = 37
        Label6.Text = "Informe señales analógicas "
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label7.ForeColor = Color.Silver
        Label7.Location = New Point(209, 619)
        Label7.Name = "Label7"
        Label7.Size = New Size(260, 17)
        Label7.TabIndex = 38
        Label7.Text = "Informe señales digitales y Totalizadores"
        Label7.Visible = False
        ' 
        ' CheckBoxAnaValMini
        ' 
        CheckBoxAnaValMini.AutoSize = True
        CheckBoxAnaValMini.Checked = True
        CheckBoxAnaValMini.CheckState = CheckState.Checked
        CheckBoxAnaValMini.Enabled = False
        CheckBoxAnaValMini.Location = New Point(34, 709)
        CheckBoxAnaValMini.Name = "CheckBoxAnaValMini"
        CheckBoxAnaValMini.Size = New Size(153, 19)
        CheckBoxAnaValMini.TabIndex = 39
        CheckBoxAnaValMini.Text = "Mostar valores mínimos"
        CheckBoxAnaValMini.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxAnaValMax
        ' 
        CheckBoxAnaValMax.AutoSize = True
        CheckBoxAnaValMax.Checked = True
        CheckBoxAnaValMax.CheckState = CheckState.Checked
        CheckBoxAnaValMax.Enabled = False
        CheckBoxAnaValMax.Location = New Point(34, 734)
        CheckBoxAnaValMax.Name = "CheckBoxAnaValMax"
        CheckBoxAnaValMax.Size = New Size(155, 19)
        CheckBoxAnaValMax.TabIndex = 40
        CheckBoxAnaValMax.Text = "Mostar valores máximos"
        CheckBoxAnaValMax.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Black
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel2)
        Panel1.Location = New Point(8, 639)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(200, 2)
        Panel1.TabIndex = 41
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Black
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(Panel5)
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(464, 2)
        Panel4.TabIndex = 43
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.Black
        Panel5.BorderStyle = BorderStyle.FixedSingle
        Panel5.Location = New Point(-1, -1)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(464, 2)
        Panel5.TabIndex = 42
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Black
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Location = New Point(-1, -1)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(200, 2)
        Panel2.TabIndex = 42
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Black
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Location = New Point(200, 651)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(2, 140)
        Panel3.TabIndex = 43
        ' 
        ' CheckBoxDigi_y_TotFin
        ' 
        CheckBoxDigi_y_TotFin.AutoSize = True
        CheckBoxDigi_y_TotFin.Enabled = False
        CheckBoxDigi_y_TotFin.Location = New Point(209, 674)
        CheckBoxDigi_y_TotFin.Name = "CheckBoxDigi_y_TotFin"
        CheckBoxDigi_y_TotFin.Size = New Size(140, 19)
        CheckBoxDigi_y_TotFin.TabIndex = 45
        CheckBoxDigi_y_TotFin.Text = "Mostar valores finales"
        CheckBoxDigi_y_TotFin.UseVisualStyleBackColor = True
        CheckBoxDigi_y_TotFin.Visible = False
        ' 
        ' CheckBoxDigi_y_TotIni
        ' 
        CheckBoxDigi_y_TotIni.AutoSize = True
        CheckBoxDigi_y_TotIni.Enabled = False
        CheckBoxDigi_y_TotIni.Location = New Point(209, 649)
        CheckBoxDigi_y_TotIni.Name = "CheckBoxDigi_y_TotIni"
        CheckBoxDigi_y_TotIni.Size = New Size(148, 19)
        CheckBoxDigi_y_TotIni.TabIndex = 44
        CheckBoxDigi_y_TotIni.Text = "Mostar valores iníciales"
        CheckBoxDigi_y_TotIni.UseVisualStyleBackColor = True
        CheckBoxDigi_y_TotIni.Visible = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.ForeColor = Color.Blue
        Label8.Location = New Point(573, 593)
        Label8.Name = "Label8"
        Label8.Size = New Size(295, 21)
        Label8.TabIndex = 46
        Label8.Text = "Selección de los tiempos del  Informe"
        ' 
        ' RadioBtnDiario
        ' 
        RadioBtnDiario.AutoSize = True
        RadioBtnDiario.Location = New Point(3, 4)
        RadioBtnDiario.Name = "RadioBtnDiario"
        RadioBtnDiario.Size = New Size(56, 19)
        RadioBtnDiario.TabIndex = 47
        RadioBtnDiario.Text = "Diario"
        RadioBtnDiario.UseVisualStyleBackColor = True
        ' 
        ' RadioBtnSemanal
        ' 
        RadioBtnSemanal.AutoSize = True
        RadioBtnSemanal.Location = New Point(3, 29)
        RadioBtnSemanal.Name = "RadioBtnSemanal"
        RadioBtnSemanal.Size = New Size(70, 19)
        RadioBtnSemanal.TabIndex = 48
        RadioBtnSemanal.Text = "Semanal"
        RadioBtnSemanal.UseVisualStyleBackColor = True
        ' 
        ' RadioBtnMensual
        ' 
        RadioBtnMensual.AutoSize = True
        RadioBtnMensual.Location = New Point(3, 54)
        RadioBtnMensual.Name = "RadioBtnMensual"
        RadioBtnMensual.Size = New Size(70, 19)
        RadioBtnMensual.TabIndex = 49
        RadioBtnMensual.Text = "Mensual"
        RadioBtnMensual.UseVisualStyleBackColor = True
        ' 
        ' RadioBtnLibre
        ' 
        RadioBtnLibre.AutoSize = True
        RadioBtnLibre.Checked = True
        RadioBtnLibre.Location = New Point(3, 87)
        RadioBtnLibre.Name = "RadioBtnLibre"
        RadioBtnLibre.Size = New Size(51, 19)
        RadioBtnLibre.TabIndex = 50
        RadioBtnLibre.TabStop = True
        RadioBtnLibre.Text = "Libre"
        RadioBtnLibre.UseVisualStyleBackColor = True
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.Black
        Panel6.BorderStyle = BorderStyle.FixedSingle
        Panel6.Controls.Add(Panel7)
        Panel6.Controls.Add(Panel9)
        Panel6.Location = New Point(-6, 78)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(200, 2)
        Panel6.TabIndex = 51
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.Black
        Panel7.BorderStyle = BorderStyle.FixedSingle
        Panel7.Controls.Add(Panel8)
        Panel7.Location = New Point(0, 0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(464, 2)
        Panel7.TabIndex = 43
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = Color.Black
        Panel8.BorderStyle = BorderStyle.FixedSingle
        Panel8.Location = New Point(-1, -1)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(464, 2)
        Panel8.TabIndex = 42
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = Color.Black
        Panel9.BorderStyle = BorderStyle.FixedSingle
        Panel9.Location = New Point(-1, -1)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(464, 2)
        Panel9.TabIndex = 42
        ' 
        ' RadioBtnLibrePorDias
        ' 
        RadioBtnLibrePorDias.AutoSize = True
        RadioBtnLibrePorDias.Location = New Point(3, 30)
        RadioBtnLibrePorDias.Name = "RadioBtnLibrePorDias"
        RadioBtnLibrePorDias.Size = New Size(67, 19)
        RadioBtnLibrePorDias.TabIndex = 53
        RadioBtnLibrePorDias.Text = "Por días"
        RadioBtnLibrePorDias.UseVisualStyleBackColor = True
        ' 
        ' RadioBtnLibrePorHoras
        ' 
        RadioBtnLibrePorHoras.AutoSize = True
        RadioBtnLibrePorHoras.Checked = True
        RadioBtnLibrePorHoras.Location = New Point(3, 6)
        RadioBtnLibrePorHoras.Name = "RadioBtnLibrePorHoras"
        RadioBtnLibrePorHoras.Size = New Size(75, 19)
        RadioBtnLibrePorHoras.TabIndex = 52
        RadioBtnLibrePorHoras.TabStop = True
        RadioBtnLibrePorHoras.Text = "Por horas"
        RadioBtnLibrePorHoras.UseVisualStyleBackColor = True
        ' 
        ' Panel10
        ' 
        Panel10.BackColor = Color.Black
        Panel10.BorderStyle = BorderStyle.FixedSingle
        Panel10.Location = New Point(805, 664)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(2, 120)
        Panel10.TabIndex = 54
        ' 
        ' PanelGrupo1
        ' 
        PanelGrupo1.Controls.Add(PanelGrupo2)
        PanelGrupo1.Controls.Add(RadioBtnDiario)
        PanelGrupo1.Controls.Add(RadioBtnSemanal)
        PanelGrupo1.Controls.Add(RadioBtnMensual)
        PanelGrupo1.Controls.Add(RadioBtnLibre)
        PanelGrupo1.Controls.Add(Panel6)
        PanelGrupo1.Location = New Point(582, 657)
        PanelGrupo1.Name = "PanelGrupo1"
        PanelGrupo1.Size = New Size(201, 131)
        PanelGrupo1.TabIndex = 55
        ' 
        ' PanelGrupo2
        ' 
        PanelGrupo2.Controls.Add(RadioBtnLibrePorHoras)
        PanelGrupo2.Controls.Add(RadioBtnLibrePorDias)
        PanelGrupo2.Location = New Point(88, 82)
        PanelGrupo2.Name = "PanelGrupo2"
        PanelGrupo2.Size = New Size(86, 63)
        PanelGrupo2.TabIndex = 56
        ' 
        ' Panel11
        ' 
        Panel11.BackColor = Color.Black
        Panel11.BorderStyle = BorderStyle.FixedSingle
        Panel11.Controls.Add(Panel12)
        Panel11.Controls.Add(Panel14)
        Panel11.Location = New Point(830, 725)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(400, 2)
        Panel11.TabIndex = 56
        ' 
        ' Panel12
        ' 
        Panel12.BackColor = Color.Black
        Panel12.BorderStyle = BorderStyle.FixedSingle
        Panel12.Controls.Add(Panel13)
        Panel12.Location = New Point(0, 0)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(464, 2)
        Panel12.TabIndex = 43
        ' 
        ' Panel13
        ' 
        Panel13.BackColor = Color.Black
        Panel13.BorderStyle = BorderStyle.FixedSingle
        Panel13.Location = New Point(-1, -1)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(464, 2)
        Panel13.TabIndex = 42
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = Color.Black
        Panel14.BorderStyle = BorderStyle.FixedSingle
        Panel14.Location = New Point(-1, -1)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(464, 2)
        Panel14.TabIndex = 42
        ' 
        ' PanelGrupo3
        ' 
        PanelGrupo3.Controls.Add(RadioBtnPdf)
        PanelGrupo3.Controls.Add(RadioBtnPantalla)
        PanelGrupo3.Location = New Point(849, 729)
        PanelGrupo3.Name = "PanelGrupo3"
        PanelGrupo3.Size = New Size(115, 63)
        PanelGrupo3.TabIndex = 57
        ' 
        ' RadioBtnPdf
        ' 
        RadioBtnPdf.AutoSize = True
        RadioBtnPdf.Location = New Point(3, 6)
        RadioBtnPdf.Name = "RadioBtnPdf"
        RadioBtnPdf.Size = New Size(57, 19)
        RadioBtnPdf.TabIndex = 52
        RadioBtnPdf.TabStop = True
        RadioBtnPdf.Text = "A PDF"
        RadioBtnPdf.UseVisualStyleBackColor = True
        ' 
        ' RadioBtnPantalla
        ' 
        RadioBtnPantalla.AutoSize = True
        RadioBtnPantalla.Checked = True
        RadioBtnPantalla.Location = New Point(3, 30)
        RadioBtnPantalla.Name = "RadioBtnPantalla"
        RadioBtnPantalla.Size = New Size(78, 19)
        RadioBtnPantalla.TabIndex = 53
        RadioBtnPantalla.TabStop = True
        RadioBtnPantalla.Text = "A pantalla"
        RadioBtnPantalla.UseVisualStyleBackColor = True
        ' 
        ' BtnInforme
        ' 
        BtnInforme.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnInforme.ForeColor = Color.Blue
        BtnInforme.Location = New Point(961, 786)
        BtnInforme.Name = "BtnInforme"
        BtnInforme.Size = New Size(264, 61)
        BtnInforme.TabIndex = 58
        BtnInforme.Text = "Informe"
        BtnInforme.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxAnaIncuTot
        ' 
        CheckBoxAnaIncuTot.AutoSize = True
        CheckBoxAnaIncuTot.Location = New Point(34, 759)
        CheckBoxAnaIncuTot.Name = "CheckBoxAnaIncuTot"
        CheckBoxAnaIncuTot.Size = New Size(129, 19)
        CheckBoxAnaIncuTot.TabIndex = 59
        CheckBoxAnaIncuTot.Text = "Incluir totalizadores"
        CheckBoxAnaIncuTot.UseVisualStyleBackColor = True
        ' 
        ' Panel15
        ' 
        Panel15.Controls.Add(RadioBtnAnalogicasOnly)
        Panel15.Controls.Add(RadioBtnTotalizadoresDeAnalogicas)
        Panel15.Location = New Point(32, 644)
        Panel15.Name = "Panel15"
        Panel15.Size = New Size(157, 49)
        Panel15.TabIndex = 60
        ' 
        ' RadioBtnAnalogicasOnly
        ' 
        RadioBtnAnalogicasOnly.AutoSize = True
        RadioBtnAnalogicasOnly.Checked = True
        RadioBtnAnalogicasOnly.Location = New Point(3, 6)
        RadioBtnAnalogicasOnly.Name = "RadioBtnAnalogicasOnly"
        RadioBtnAnalogicasOnly.Size = New Size(123, 19)
        RadioBtnAnalogicasOnly.TabIndex = 52
        RadioBtnAnalogicasOnly.TabStop = True
        RadioBtnAnalogicasOnly.Text = "Señales analógicas"
        RadioBtnAnalogicasOnly.UseVisualStyleBackColor = True
        ' 
        ' RadioBtnTotalizadoresDeAnalogicas
        ' 
        RadioBtnTotalizadoresDeAnalogicas.AutoSize = True
        RadioBtnTotalizadoresDeAnalogicas.Location = New Point(3, 30)
        RadioBtnTotalizadoresDeAnalogicas.Name = "RadioBtnTotalizadoresDeAnalogicas"
        RadioBtnTotalizadoresDeAnalogicas.Size = New Size(93, 19)
        RadioBtnTotalizadoresDeAnalogicas.TabIndex = 53
        RadioBtnTotalizadoresDeAnalogicas.Text = "Totalizadores"
        RadioBtnTotalizadoresDeAnalogicas.UseVisualStyleBackColor = True
        ' 
        ' Panel16
        ' 
        Panel16.BackColor = Color.Black
        Panel16.BorderStyle = BorderStyle.FixedSingle
        Panel16.Controls.Add(Panel17)
        Panel16.Controls.Add(Panel19)
        Panel16.Location = New Point(23, 701)
        Panel16.Name = "Panel16"
        Panel16.Size = New Size(170, 2)
        Panel16.TabIndex = 61
        ' 
        ' Panel17
        ' 
        Panel17.BackColor = Color.Black
        Panel17.BorderStyle = BorderStyle.FixedSingle
        Panel17.Controls.Add(Panel18)
        Panel17.Location = New Point(0, 0)
        Panel17.Name = "Panel17"
        Panel17.Size = New Size(464, 2)
        Panel17.TabIndex = 43
        ' 
        ' Panel18
        ' 
        Panel18.BackColor = Color.Black
        Panel18.BorderStyle = BorderStyle.FixedSingle
        Panel18.Location = New Point(-1, -1)
        Panel18.Name = "Panel18"
        Panel18.Size = New Size(464, 2)
        Panel18.TabIndex = 42
        ' 
        ' Panel19
        ' 
        Panel19.BackColor = Color.Black
        Panel19.BorderStyle = BorderStyle.FixedSingle
        Panel19.Location = New Point(-1, -1)
        Panel19.Name = "Panel19"
        Panel19.Size = New Size(464, 2)
        Panel19.TabIndex = 42
        ' 
        ' lblLog
        ' 
        lblLog.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        lblLog.ForeColor = SystemColors.ControlDarkDark
        lblLog.Location = New Point(209, 697)
        lblLog.Name = "lblLog"
        lblLog.Size = New Size(361, 155)
        lblLog.TabIndex = 63
        lblLog.Text = "---"
        lblLog.Visible = False
        ' 
        ' blbForzar2
        ' 
        blbForzar2.AutoSize = True
        blbForzar2.ForeColor = SystemColors.ButtonShadow
        blbForzar2.Location = New Point(961, 760)
        blbForzar2.Name = "blbForzar2"
        blbForzar2.Size = New Size(271, 15)
        blbForzar2.TabIndex = 64
        blbForzar2.Text = "Forzar A: 2023-02-20 00:00:00   2023-02-26 23:59:59"
        blbForzar2.Visible = False
        ' 
        ' BtnSalvar
        ' 
        BtnSalvar.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        BtnSalvar.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnSalvar.ForeColor = Color.Blue
        BtnSalvar.Image = CType(resources.GetObject("BtnSalvar.Image"), Image)
        BtnSalvar.Location = New Point(1200, 590)
        BtnSalvar.Name = "BtnSalvar"
        BtnSalvar.Size = New Size(30, 31)
        BtnSalvar.TabIndex = 85
        BtnSalvar.UseVisualStyleBackColor = False
        ' 
        ' ComBoxConsultas
        ' 
        ComBoxConsultas.FormattingEnabled = True
        ComBoxConsultas.Location = New Point(573, 629)
        ComBoxConsultas.Name = "ComBoxConsultas"
        ComBoxConsultas.Size = New Size(652, 23)
        ComBoxConsultas.TabIndex = 84
        ' 
        ' BtnBorrar
        ' 
        BtnBorrar.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        BtnBorrar.Font = New Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnBorrar.ForeColor = Color.Blue
        BtnBorrar.Image = CType(resources.GetObject("BtnBorrar.Image"), Image)
        BtnBorrar.Location = New Point(1164, 590)
        BtnBorrar.Name = "BtnBorrar"
        BtnBorrar.Size = New Size(30, 31)
        BtnBorrar.TabIndex = 87
        BtnBorrar.UseVisualStyleBackColor = False
        ' 
        ' FormInformesAnalogicas
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1244, 819)
        Controls.Add(BtnBorrar)
        Controls.Add(BtnInforme)
        Controls.Add(BtnSalvar)
        Controls.Add(ComBoxConsultas)
        Controls.Add(blbForzar2)
        Controls.Add(lblLog)
        Controls.Add(Panel16)
        Controls.Add(Panel15)
        Controls.Add(CheckBoxAnaIncuTot)
        Controls.Add(PanelGrupo3)
        Controls.Add(Panel11)
        Controls.Add(PanelGrupo1)
        Controls.Add(Panel10)
        Controls.Add(Label8)
        Controls.Add(CheckBoxDigi_y_TotFin)
        Controls.Add(CheckBoxDigi_y_TotIni)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(CheckBoxAnaValMax)
        Controls.Add(CheckBoxAnaValMini)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(StackPanel1)
        Controls.Add(PanelAvisos)
        Controls.Add(btnInicializar)
        Controls.Add(dgv)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dTPickerHastaHora)
        Controls.Add(dTPickerFechaHasta)
        Controls.Add(dTPickerDesdeHora)
        Controls.Add(dTPickerFechaDesde)
        Controls.Add(Label4)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FormInformesAnalogicas"
        Text = "Informe Analógicas"
        TransparencyKey = Color.FromArgb(CByte(255), CByte(192), CByte(255))
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        PanelAvisos.ResumeLayout(False)
        CType(StackPanel1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        PanelGrupo1.ResumeLayout(False)
        PanelGrupo1.PerformLayout()
        PanelGrupo2.ResumeLayout(False)
        PanelGrupo2.PerformLayout()
        Panel11.ResumeLayout(False)
        Panel12.ResumeLayout(False)
        PanelGrupo3.ResumeLayout(False)
        PanelGrupo3.PerformLayout()
        Panel15.ResumeLayout(False)
        Panel15.PerformLayout()
        Panel16.ResumeLayout(False)
        Panel17.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dTPickerHastaHora As DateTimePicker
    Private WithEvents dTPickerFechaHasta As DateTimePicker
    Friend WithEvents dTPickerDesdeHora As DateTimePicker
    Private WithEvents dTPickerFechaDesde As DateTimePicker
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents btnInicializar As Button
    Friend WithEvents PanelAvisos As Panel
    Friend WithEvents lblAviso As Label
    Friend WithEvents StackPanel1 As DevExpress.Utils.Layout.StackPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckBoxAnaValMini As CheckBox
    Friend WithEvents CheckBoxAnaValMax As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents CheckBoxDigi_y_TotFin As CheckBox
    Friend WithEvents CheckBoxDigi_y_TotIni As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents RadioBtnDiario As RadioButton
    Friend WithEvents RadioBtnSemanal As RadioButton
    Friend WithEvents RadioBtnMensual As RadioButton
    Friend WithEvents RadioBtnLibre As RadioButton
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents RadioBtnLibrePorDias As RadioButton
    Friend WithEvents RadioBtnLibrePorHoras As RadioButton
    Friend WithEvents Panel10 As Panel
    Friend WithEvents PanelGrupo1 As Panel
    Friend WithEvents PanelGrupo2 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents PanelGrupo3 As Panel
    Friend WithEvents RadioBtnPdf As RadioButton
    Friend WithEvents RadioBtnPantalla As RadioButton
    Friend WithEvents BtnInforme As Button
    Friend WithEvents CheckBoxAnaIncuTot As CheckBox
    Friend WithEvents Panel15 As Panel
    Friend WithEvents RadioBtnAnalogicasOnly As RadioButton
    Friend WithEvents RadioBtnTotalizadoresDeAnalogicas As RadioButton
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents lblLog As Label
    Friend WithEvents blbForzar2 As Label
    Friend WithEvents BtnSalvar As Button
    Friend WithEvents ComBoxConsultas As ComboBox
    Friend WithEvents BtnBorrar As Button
End Class

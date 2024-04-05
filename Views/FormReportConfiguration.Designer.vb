<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormReportConfiguration
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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormReportConfiguration))
        ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        tlp_main = New TableLayoutPanel()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel3 = New Panel()
        PanelGrupo1 = New Panel()
        RadioButtonccMensual = New RadioButtonCC()
        RadioButtonccSemanal = New RadioButtonCC()
        RadioButtonccDiario = New RadioButtonCC()
        RadioButtonccLibre = New RadioButtonCC()
        PanelFreeTimeSelect = New Panel()
        RadioButtonccFreeDays = New RadioButtonCC()
        RadioButtonccFreeHourly = New RadioButtonCC()
        dTPickerDateFrom = New DateTimePicker()
        dTPickerHourFrom = New DateTimePicker()
        dTPickerDateTo = New DateTimePicker()
        dTPickerHourTo = New DateTimePicker()
        Label2 = New Label()
        Label3 = New Label()
        Label8 = New Label()
        Panel4 = New Panel()
        ComBoxTemplates = New ComboBox()
        blbForzar2 = New Label()
        Label6 = New Label()
        Label1 = New Label()
        btnSaveTemplate = New Button()
        btnDeleteTemplate = New Button()
        tlp_Title = New TableLayoutPanel()
        ButtonClose = New Button()
        LabelTitle = New Label()
        txtBoxFilter = New TextBox()
        Panel20 = New Panel()
        CheckBoxDigi_y_TotFin = New CheckBoxCC()
        CheckBoxDigi_y_TotIni = New CheckBoxCC()
        Label5 = New Label()
        Panel15 = New Panel()
        CheckBoxDigiIncludeBothData = New RadioButtonCC()
        RadioBtnSecondaryData = New RadioButtonCC()
        RadioBtnMainData = New RadioButtonCC()
        lblLog = New Label()
        dgv = New DataGridView()
        PanelNotices = New Panel()
        lblNotices = New Label()
        Panel2 = New Panel()
        RadioButtonScr = New RadioButtonCC()
        RadioButtonPdf = New RadioButtonCC()
        RadioButtonExcel = New RadioButtonCC()
        BtnInforme = New Button()
        TimerInicio = New Timer(components)
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        Timer3 = New Timer(components)
        Timer4 = New Timer(components)
        TimerAll = New Timer(components)
        tlp_main.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        Panel3.SuspendLayout()
        PanelGrupo1.SuspendLayout()
        PanelFreeTimeSelect.SuspendLayout()
        Panel4.SuspendLayout()
        tlp_Title.SuspendLayout()
        Panel20.SuspendLayout()
        Panel15.SuspendLayout()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        PanelNotices.SuspendLayout()
        Panel2.SuspendLayout()
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
        ' tlp_main
        ' 
        tlp_main.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        tlp_main.ColumnCount = 2
        tlp_main.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 18.81029F))
        tlp_main.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 81.18971F))
        tlp_main.Controls.Add(TableLayoutPanel1, 1, 3)
        tlp_main.Controls.Add(tlp_Title, 0, 0)
        tlp_main.Controls.Add(Panel20, 0, 3)
        tlp_main.Controls.Add(dgv, 0, 1)
        tlp_main.Controls.Add(PanelNotices, 0, 2)
        tlp_main.Controls.Add(Panel2, 1, 4)
        tlp_main.Dock = DockStyle.Fill
        tlp_main.Location = New Point(0, 0)
        tlp_main.Margin = New Padding(0)
        tlp_main.Name = "tlp_main"
        tlp_main.RowCount = 5
        tlp_main.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        tlp_main.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlp_main.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlp_main.RowStyles.Add(New RowStyle(SizeType.Absolute, 233F))
        tlp_main.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        tlp_main.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        tlp_main.Size = New Size(1244, 819)
        tlp_main.TabIndex = 89
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 31.97211F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 68.0278854F))
        TableLayoutPanel1.Controls.Add(Panel3, 0, 0)
        TableLayoutPanel1.Controls.Add(Panel4, 1, 0)
        TableLayoutPanel1.Dock = DockStyle.Fill
        TableLayoutPanel1.Location = New Point(237, 555)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1004, 227)
        TableLayoutPanel1.TabIndex = 104
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(PanelGrupo1)
        Panel3.Controls.Add(dTPickerDateFrom)
        Panel3.Controls.Add(dTPickerHourFrom)
        Panel3.Controls.Add(dTPickerDateTo)
        Panel3.Controls.Add(dTPickerHourTo)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(Label8)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 0)
        Panel3.Margin = New Padding(0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(321, 227)
        Panel3.TabIndex = 0
        ' 
        ' PanelGrupo1
        ' 
        PanelGrupo1.Controls.Add(RadioButtonccMensual)
        PanelGrupo1.Controls.Add(RadioButtonccSemanal)
        PanelGrupo1.Controls.Add(RadioButtonccDiario)
        PanelGrupo1.Controls.Add(RadioButtonccLibre)
        PanelGrupo1.Controls.Add(PanelFreeTimeSelect)
        PanelGrupo1.Location = New Point(3, 29)
        PanelGrupo1.Name = "PanelGrupo1"
        PanelGrupo1.Size = New Size(220, 129)
        PanelGrupo1.TabIndex = 96
        ' 
        ' RadioButtonccMensual
        ' 
        RadioButtonccMensual.BackColor = Color.Transparent
        RadioButtonccMensual.Checked = False
        RadioButtonccMensual.LabelText = "Mensual"
        RadioButtonccMensual.Location = New Point(3, 51)
        RadioButtonccMensual.MaximumSize = New Size(300, 18)
        RadioButtonccMensual.MinimumSize = New Size(18, 18)
        RadioButtonccMensual.Name = "RadioButtonccMensual"
        RadioButtonccMensual.Size = New Size(80, 18)
        RadioButtonccMensual.TabIndex = 108
        ' 
        ' RadioButtonccSemanal
        ' 
        RadioButtonccSemanal.BackColor = Color.Transparent
        RadioButtonccSemanal.Checked = False
        RadioButtonccSemanal.LabelText = "Semanal"
        RadioButtonccSemanal.Location = New Point(3, 27)
        RadioButtonccSemanal.MaximumSize = New Size(300, 18)
        RadioButtonccSemanal.MinimumSize = New Size(18, 18)
        RadioButtonccSemanal.Name = "RadioButtonccSemanal"
        RadioButtonccSemanal.Size = New Size(80, 18)
        RadioButtonccSemanal.TabIndex = 107
        ' 
        ' RadioButtonccDiario
        ' 
        RadioButtonccDiario.BackColor = Color.Transparent
        RadioButtonccDiario.Checked = False
        RadioButtonccDiario.LabelText = "Diario"
        RadioButtonccDiario.Location = New Point(3, 3)
        RadioButtonccDiario.MaximumSize = New Size(300, 18)
        RadioButtonccDiario.MinimumSize = New Size(18, 18)
        RadioButtonccDiario.Name = "RadioButtonccDiario"
        RadioButtonccDiario.Size = New Size(64, 18)
        RadioButtonccDiario.TabIndex = 106
        ' 
        ' RadioButtonccLibre
        ' 
        RadioButtonccLibre.BackColor = Color.Transparent
        RadioButtonccLibre.Checked = False
        RadioButtonccLibre.LabelText = "Libre"
        RadioButtonccLibre.Location = New Point(3, 74)
        RadioButtonccLibre.MaximumSize = New Size(300, 18)
        RadioButtonccLibre.MinimumSize = New Size(18, 18)
        RadioButtonccLibre.Name = "RadioButtonccLibre"
        RadioButtonccLibre.Size = New Size(58, 18)
        RadioButtonccLibre.TabIndex = 105
        ' 
        ' PanelFreeTimeSelect
        ' 
        PanelFreeTimeSelect.Controls.Add(RadioButtonccFreeDays)
        PanelFreeTimeSelect.Controls.Add(RadioButtonccFreeHourly)
        PanelFreeTimeSelect.Location = New Point(79, 72)
        PanelFreeTimeSelect.Name = "PanelFreeTimeSelect"
        PanelFreeTimeSelect.Size = New Size(138, 53)
        PanelFreeTimeSelect.TabIndex = 104
        ' 
        ' RadioButtonccFreeDays
        ' 
        RadioButtonccFreeDays.BackColor = Color.Transparent
        RadioButtonccFreeDays.Checked = False
        RadioButtonccFreeDays.LabelText = "Por días"
        RadioButtonccFreeDays.Location = New Point(3, 29)
        RadioButtonccFreeDays.MaximumSize = New Size(300, 18)
        RadioButtonccFreeDays.MinimumSize = New Size(18, 18)
        RadioButtonccFreeDays.Name = "RadioButtonccFreeDays"
        RadioButtonccFreeDays.Size = New Size(77, 18)
        RadioButtonccFreeDays.TabIndex = 96
        ' 
        ' RadioButtonccFreeHourly
        ' 
        RadioButtonccFreeHourly.BackColor = Color.Transparent
        RadioButtonccFreeHourly.Checked = False
        RadioButtonccFreeHourly.LabelText = "Por horas"
        RadioButtonccFreeHourly.Location = New Point(3, 5)
        RadioButtonccFreeHourly.MaximumSize = New Size(300, 18)
        RadioButtonccFreeHourly.MinimumSize = New Size(18, 18)
        RadioButtonccFreeHourly.Name = "RadioButtonccFreeHourly"
        RadioButtonccFreeHourly.Size = New Size(87, 18)
        RadioButtonccFreeHourly.TabIndex = 95
        ' 
        ' dTPickerDateFrom
        ' 
        dTPickerDateFrom.CustomFormat = "ddd dd/MM/yyyy"
        dTPickerDateFrom.Font = New Font("Segoe UI Variable Small Light", 9F, FontStyle.Regular, GraphicsUnit.Point)
        dTPickerDateFrom.Format = DateTimePickerFormat.Custom
        dTPickerDateFrom.Location = New Point(76, 170)
        dTPickerDateFrom.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerDateFrom.MinDate = New Date(2022, 1, 1, 0, 0, 0, 0)
        dTPickerDateFrom.Name = "dTPickerDateFrom"
        dTPickerDateFrom.Size = New Size(144, 23)
        dTPickerDateFrom.TabIndex = 87
        ' 
        ' dTPickerHourFrom
        ' 
        dTPickerHourFrom.CustomFormat = "HH"
        dTPickerHourFrom.Font = New Font("Segoe UI Variable Small Light", 9F, FontStyle.Regular, GraphicsUnit.Point)
        dTPickerHourFrom.Format = DateTimePickerFormat.Custom
        dTPickerHourFrom.Location = New Point(226, 170)
        dTPickerHourFrom.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerHourFrom.MinDate = New Date(2023, 1, 1, 0, 0, 0, 0)
        dTPickerHourFrom.Name = "dTPickerHourFrom"
        dTPickerHourFrom.ShowUpDown = True
        dTPickerHourFrom.Size = New Size(39, 23)
        dTPickerHourFrom.TabIndex = 88
        ' 
        ' dTPickerDateTo
        ' 
        dTPickerDateTo.CalendarFont = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point)
        dTPickerDateTo.CustomFormat = "ddd dd/MM/yyyy"
        dTPickerDateTo.Font = New Font("Segoe UI Variable Small Light", 9F, FontStyle.Regular, GraphicsUnit.Point)
        dTPickerDateTo.Format = DateTimePickerFormat.Custom
        dTPickerDateTo.Location = New Point(76, 201)
        dTPickerDateTo.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerDateTo.MinDate = New Date(2022, 1, 1, 0, 0, 0, 0)
        dTPickerDateTo.Name = "dTPickerDateTo"
        dTPickerDateTo.Size = New Size(144, 23)
        dTPickerDateTo.TabIndex = 89
        ' 
        ' dTPickerHourTo
        ' 
        dTPickerHourTo.CustomFormat = "HH"
        dTPickerHourTo.Font = New Font("Segoe UI Variable Small Light", 9F, FontStyle.Regular, GraphicsUnit.Point)
        dTPickerHourTo.Format = DateTimePickerFormat.Custom
        dTPickerHourTo.Location = New Point(226, 201)
        dTPickerHourTo.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        dTPickerHourTo.MinDate = New Date(2023, 1, 1, 0, 0, 0, 0)
        dTPickerHourTo.Name = "dTPickerHourTo"
        dTPickerHourTo.ShowUpDown = True
        dTPickerHourTo.Size = New Size(39, 23)
        dTPickerHourTo.TabIndex = 90
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(6, 170)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 21)
        Label2.TabIndex = 92
        Label2.Text = "Desde :"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(6, 202)
        Label3.Name = "Label3"
        Label3.Size = New Size(61, 21)
        Label3.TabIndex = 93
        Label3.Text = "Hasta :"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label8.ForeColor = Color.White
        Label8.Location = New Point(3, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(290, 21)
        Label8.TabIndex = 94
        Label8.Text = "Selección de los tiempos del informe"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(ComBoxTemplates)
        Panel4.Controls.Add(blbForzar2)
        Panel4.Controls.Add(Label6)
        Panel4.Controls.Add(Label1)
        Panel4.Controls.Add(btnSaveTemplate)
        Panel4.Controls.Add(btnDeleteTemplate)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(321, 0)
        Panel4.Margin = New Padding(0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(683, 227)
        Panel4.TabIndex = 1
        ' 
        ' ComBoxTemplates
        ' 
        ComBoxTemplates.DropDownStyle = ComboBoxStyle.DropDownList
        ComBoxTemplates.Font = New Font("Segoe UI Variable Small", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ComBoxTemplates.FormattingEnabled = True
        ComBoxTemplates.Location = New Point(6, 32)
        ComBoxTemplates.MaxDropDownItems = 20
        ComBoxTemplates.Name = "ComBoxTemplates"
        ComBoxTemplates.Size = New Size(323, 24)
        ComBoxTemplates.Sorted = True
        ComBoxTemplates.TabIndex = 100
        ' 
        ' blbForzar2
        ' 
        blbForzar2.AutoSize = True
        blbForzar2.ForeColor = SystemColors.ButtonShadow
        blbForzar2.Location = New Point(17, 164)
        blbForzar2.Name = "blbForzar2"
        blbForzar2.Size = New Size(271, 15)
        blbForzar2.TabIndex = 99
        blbForzar2.Text = "Forzar A: 2023-02-20 00:00:00   2023-02-26 23:59:59"
        blbForzar2.Visible = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(6, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(76, 21)
        Label6.TabIndex = 103
        Label6.Text = "Plantillas"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = SystemColors.ButtonShadow
        Label1.Location = New Point(17, 145)
        Label1.Name = "Label1"
        Label1.Size = New Size(271, 15)
        Label1.TabIndex = 91
        Label1.Text = "Forzar A: 2023-03-01 00:00:00   2023-03-02 23:59:59"
        Label1.Visible = False
        ' 
        ' btnSaveTemplate
        ' 
        btnSaveTemplate.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnSaveTemplate.BackgroundImageLayout = ImageLayout.Center
        btnSaveTemplate.FlatAppearance.BorderSize = 0
        btnSaveTemplate.FlatStyle = FlatStyle.Flat
        btnSaveTemplate.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSaveTemplate.ForeColor = Color.White
        btnSaveTemplate.Location = New Point(6, 67)
        btnSaveTemplate.Name = "btnSaveTemplate"
        btnSaveTemplate.Size = New Size(30, 31)
        btnSaveTemplate.TabIndex = 101
        btnSaveTemplate.Text = ""
        btnSaveTemplate.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteTemplate
        ' 
        btnDeleteTemplate.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnDeleteTemplate.FlatAppearance.BorderSize = 0
        btnDeleteTemplate.FlatStyle = FlatStyle.Flat
        btnDeleteTemplate.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnDeleteTemplate.ForeColor = Color.White
        btnDeleteTemplate.Location = New Point(42, 67)
        btnDeleteTemplate.Name = "btnDeleteTemplate"
        btnDeleteTemplate.Size = New Size(30, 31)
        btnDeleteTemplate.TabIndex = 102
        btnDeleteTemplate.Text = ""
        btnDeleteTemplate.UseVisualStyleBackColor = False
        ' 
        ' tlp_Title
        ' 
        tlp_Title.BackColor = Color.FromArgb(CByte(0), CByte(196), CByte(213))
        tlp_Title.ColumnCount = 3
        tlp_main.SetColumnSpan(tlp_Title, 2)
        tlp_Title.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        tlp_Title.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 200F))
        tlp_Title.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 46F))
        tlp_Title.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        tlp_Title.Controls.Add(ButtonClose, 2, 0)
        tlp_Title.Controls.Add(LabelTitle, 0, 0)
        tlp_Title.Controls.Add(txtBoxFilter, 1, 0)
        tlp_Title.Dock = DockStyle.Fill
        tlp_Title.Location = New Point(0, 0)
        tlp_Title.Margin = New Padding(0)
        tlp_Title.Name = "tlp_Title"
        tlp_Title.RowCount = 1
        tlp_Title.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        tlp_Title.Size = New Size(1244, 34)
        tlp_Title.TabIndex = 6
        ' 
        ' ButtonClose
        ' 
        ButtonClose.BackColor = Color.FromArgb(CByte(0), CByte(132), CByte(201))
        ButtonClose.Dock = DockStyle.Right
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ButtonClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(196), CByte(43), CByte(28))
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.Font = New Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonClose.ForeColor = Color.Gainsboro
        ButtonClose.ImageAlign = ContentAlignment.MiddleLeft
        ButtonClose.Location = New Point(1198, 0)
        ButtonClose.Margin = New Padding(0)
        ButtonClose.MaximumSize = New Size(46, 34)
        ButtonClose.MinimumSize = New Size(46, 34)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(46, 34)
        ButtonClose.TabIndex = 92
        ButtonClose.Text = ""
        ButtonClose.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonClose.UseVisualStyleBackColor = False
        ' 
        ' LabelTitle
        ' 
        LabelTitle.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point)
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(3, 3)
        LabelTitle.Margin = New Padding(3, 3, 3, 0)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(541, 28)
        LabelTitle.TabIndex = 32
        LabelTitle.Text = "Informe de equipos"
        LabelTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' txtBoxFilter
        ' 
        txtBoxFilter.BorderStyle = BorderStyle.None
        txtBoxFilter.Dock = DockStyle.Fill
        txtBoxFilter.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtBoxFilter.Location = New Point(1001, 8)
        txtBoxFilter.Margin = New Padding(3, 8, 8, 3)
        txtBoxFilter.MaximumSize = New Size(194, 28)
        txtBoxFilter.MinimumSize = New Size(194, 18)
        txtBoxFilter.Name = "txtBoxFilter"
        txtBoxFilter.PlaceholderText = "Filtrar..."
        txtBoxFilter.Size = New Size(194, 22)
        txtBoxFilter.TabIndex = 93
        ' 
        ' Panel20
        ' 
        Panel20.Controls.Add(CheckBoxDigi_y_TotFin)
        Panel20.Controls.Add(CheckBoxDigi_y_TotIni)
        Panel20.Controls.Add(Label5)
        Panel20.Controls.Add(Panel15)
        Panel20.Controls.Add(lblLog)
        Panel20.Dock = DockStyle.Left
        Panel20.Location = New Point(0, 552)
        Panel20.Margin = New Padding(0)
        Panel20.Name = "Panel20"
        Panel20.Size = New Size(231, 233)
        Panel20.TabIndex = 89
        ' 
        ' CheckBoxDigi_y_TotFin
        ' 
        CheckBoxDigi_y_TotFin.Checked = False
        CheckBoxDigi_y_TotFin.LabelText = "Mostrar valores finales"
        CheckBoxDigi_y_TotFin.Location = New Point(5, 132)
        CheckBoxDigi_y_TotFin.MaximumSize = New Size(300, 18)
        CheckBoxDigi_y_TotFin.MinimumSize = New Size(18, 18)
        CheckBoxDigi_y_TotFin.Name = "CheckBoxDigi_y_TotFin"
        CheckBoxDigi_y_TotFin.Size = New Size(166, 18)
        CheckBoxDigi_y_TotFin.TabIndex = 68
        ' 
        ' CheckBoxDigi_y_TotIni
        ' 
        CheckBoxDigi_y_TotIni.Checked = False
        CheckBoxDigi_y_TotIni.LabelText = "Mostrar valores iniciales"
        CheckBoxDigi_y_TotIni.Location = New Point(5, 109)
        CheckBoxDigi_y_TotIni.MaximumSize = New Size(300, 18)
        CheckBoxDigi_y_TotIni.MinimumSize = New Size(18, 18)
        CheckBoxDigi_y_TotIni.Name = "CheckBoxDigi_y_TotIni"
        CheckBoxDigi_y_TotIni.Size = New Size(174, 18)
        CheckBoxDigi_y_TotIni.TabIndex = 67
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(3, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(207, 21)
        Label5.TabIndex = 36
        Label5.Text = "Configuración de informe"
        ' 
        ' Panel15
        ' 
        Panel15.Controls.Add(CheckBoxDigiIncludeBothData)
        Panel15.Controls.Add(RadioBtnSecondaryData)
        Panel15.Controls.Add(RadioBtnMainData)
        Panel15.Location = New Point(5, 35)
        Panel15.Name = "Panel15"
        Panel15.Size = New Size(185, 72)
        Panel15.TabIndex = 60
        ' 
        ' CheckBoxDigiIncludeBothData
        ' 
        CheckBoxDigiIncludeBothData.BackColor = Color.Transparent
        CheckBoxDigiIncludeBothData.Checked = False
        CheckBoxDigiIncludeBothData.LabelText = "Ambos"
        CheckBoxDigiIncludeBothData.Location = New Point(0, 42)
        CheckBoxDigiIncludeBothData.MaximumSize = New Size(300, 18)
        CheckBoxDigiIncludeBothData.MinimumSize = New Size(18, 18)
        CheckBoxDigiIncludeBothData.Name = "CheckBoxDigiIncludeBothData"
        CheckBoxDigiIncludeBothData.Size = New Size(185, 18)
        CheckBoxDigiIncludeBothData.TabIndex = 109
        ' 
        ' RadioBtnSecondaryData
        ' 
        RadioBtnSecondaryData.BackColor = Color.Transparent
        RadioBtnSecondaryData.Checked = False
        RadioBtnSecondaryData.LabelText = "SecondaryData"
        RadioBtnSecondaryData.Location = New Point(0, 21)
        RadioBtnSecondaryData.Margin = New Padding(3, 8, 3, 3)
        RadioBtnSecondaryData.MaximumSize = New Size(300, 18)
        RadioBtnSecondaryData.MinimumSize = New Size(18, 18)
        RadioBtnSecondaryData.Name = "RadioBtnSecondaryData"
        RadioBtnSecondaryData.Size = New Size(120, 18)
        RadioBtnSecondaryData.TabIndex = 111
        ' 
        ' RadioBtnMainData
        ' 
        RadioBtnMainData.BackColor = Color.Transparent
        RadioBtnMainData.Checked = False
        RadioBtnMainData.Font = New Font("Segoe UI Variable Small", 9F, FontStyle.Regular, GraphicsUnit.Point)
        RadioBtnMainData.LabelText = "MainData"
        RadioBtnMainData.Location = New Point(0, 0)
        RadioBtnMainData.MaximumSize = New Size(300, 19)
        RadioBtnMainData.MinimumSize = New Size(18, 19)
        RadioBtnMainData.Name = "RadioBtnMainData"
        RadioBtnMainData.Size = New Size(87, 19)
        RadioBtnMainData.TabIndex = 110
        ' 
        ' lblLog
        ' 
        lblLog.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        lblLog.ForeColor = SystemColors.ControlDarkDark
        lblLog.Location = New Point(10, 188)
        lblLog.Name = "lblLog"
        lblLog.Size = New Size(185, 28)
        lblLog.TabIndex = 63
        lblLog.Text = "---"
        lblLog.Visible = False
        ' 
        ' dgv
        ' 
        dgv.BackgroundColor = SystemColors.ButtonFace
        dgv.BorderStyle = BorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tlp_main.SetColumnSpan(dgv, 2)
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgv.DefaultCellStyle = DataGridViewCellStyle2
        dgv.Dock = DockStyle.Fill
        dgv.Location = New Point(0, 34)
        dgv.Margin = New Padding(0)
        dgv.MultiSelect = False
        dgv.Name = "dgv"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Control
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgv.RowHeadersVisible = False
        dgv.RowTemplate.Height = 25
        dgv.ShowEditingIcon = False
        dgv.Size = New Size(1244, 498)
        dgv.TabIndex = 31
        dgv.Visible = False
        ' 
        ' PanelNotices
        ' 
        PanelNotices.BackColor = SystemColors.ButtonFace
        tlp_main.SetColumnSpan(PanelNotices, 2)
        PanelNotices.Controls.Add(lblNotices)
        PanelNotices.Dock = DockStyle.Fill
        PanelNotices.Location = New Point(0, 532)
        PanelNotices.Margin = New Padding(0)
        PanelNotices.Name = "PanelNotices"
        PanelNotices.Size = New Size(1244, 20)
        PanelNotices.TabIndex = 34
        PanelNotices.Visible = False
        ' 
        ' lblNotices
        ' 
        lblNotices.BackColor = SystemColors.ButtonFace
        lblNotices.Dock = DockStyle.Fill
        lblNotices.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblNotices.ForeColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        lblNotices.Location = New Point(0, 0)
        lblNotices.Margin = New Padding(0)
        lblNotices.Name = "lblNotices"
        lblNotices.Size = New Size(1244, 20)
        lblNotices.TabIndex = 1
        lblNotices.Text = "---"
        lblNotices.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(RadioButtonScr)
        Panel2.Controls.Add(RadioButtonPdf)
        Panel2.Controls.Add(RadioButtonExcel)
        Panel2.Controls.Add(BtnInforme)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(359, 785)
        Panel2.Margin = New Padding(0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(885, 34)
        Panel2.TabIndex = 91
        ' 
        ' RadioButtonScr
        ' 
        RadioButtonScr.BackColor = Color.Transparent
        RadioButtonScr.Checked = False
        RadioButtonScr.LabelText = "Pantalla"
        RadioButtonScr.Location = New Point(535, 8)
        RadioButtonScr.MaximumSize = New Size(300, 18)
        RadioButtonScr.MinimumSize = New Size(18, 18)
        RadioButtonScr.Name = "RadioButtonScr"
        RadioButtonScr.Size = New Size(76, 18)
        RadioButtonScr.TabIndex = 96
        ' 
        ' RadioButtonPdf
        ' 
        RadioButtonPdf.BackColor = Color.Transparent
        RadioButtonPdf.Checked = False
        RadioButtonPdf.LabelText = "Pdf"
        RadioButtonPdf.Location = New Point(460, 8)
        RadioButtonPdf.MaximumSize = New Size(300, 18)
        RadioButtonPdf.MinimumSize = New Size(18, 18)
        RadioButtonPdf.Name = "RadioButtonPdf"
        RadioButtonPdf.Size = New Size(48, 18)
        RadioButtonPdf.TabIndex = 95
        ' 
        ' RadioButtonExcel
        ' 
        RadioButtonExcel.BackColor = Color.Transparent
        RadioButtonExcel.Checked = False
        RadioButtonExcel.LabelText = "Excel"
        RadioButtonExcel.Location = New Point(377, 8)
        RadioButtonExcel.MaximumSize = New Size(300, 18)
        RadioButtonExcel.MinimumSize = New Size(18, 18)
        RadioButtonExcel.Name = "RadioButtonExcel"
        RadioButtonExcel.Size = New Size(58, 18)
        RadioButtonExcel.TabIndex = 94
        ' 
        ' BtnInforme
        ' 
        BtnInforme.BackColor = Color.FromArgb(CByte(0), CByte(132), CByte(201))
        BtnInforme.Dock = DockStyle.Right
        BtnInforme.FlatAppearance.BorderColor = Color.FromArgb(CByte(0), CByte(196), CByte(213))
        BtnInforme.FlatAppearance.BorderSize = 2
        BtnInforme.FlatStyle = FlatStyle.Flat
        BtnInforme.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
        BtnInforme.ForeColor = Color.White
        BtnInforme.Location = New Point(651, 0)
        BtnInforme.Margin = New Padding(0)
        BtnInforme.Name = "BtnInforme"
        BtnInforme.Size = New Size(234, 34)
        BtnInforme.TabIndex = 59
        BtnInforme.Text = "Generar informe"
        BtnInforme.UseVisualStyleBackColor = False
        ' 
        ' TimerInicio
        ' 
        TimerInicio.Enabled = True
        TimerInicio.Interval = 1000
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 1500
        ' 
        ' Timer2
        ' 
        Timer2.Enabled = True
        Timer2.Interval = 1500
        ' 
        ' Timer3
        ' 
        Timer3.Enabled = True
        Timer3.Interval = 1500
        ' 
        ' Timer4
        ' 
        Timer4.Enabled = True
        Timer4.Interval = 1500
        ' 
        ' TimerAll
        ' 
        TimerAll.Enabled = True
        TimerAll.Interval = 1100
        ' 
        ' FormReportConfiguration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ClientSize = New Size(1244, 819)
        Controls.Add(tlp_main)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FormReportConfiguration"
        Text = "Informe Digitales"
        TransparencyKey = Color.FromArgb(CByte(255), CByte(192), CByte(255))
        tlp_main.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        PanelGrupo1.ResumeLayout(False)
        PanelFreeTimeSelect.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        tlp_Title.ResumeLayout(False)
        tlp_Title.PerformLayout()
        Panel20.ResumeLayout(False)
        Panel20.PerformLayout()
        Panel15.ResumeLayout(False)
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        PanelNotices.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tlp_main As TableLayoutPanel
    Protected WithEvents btnDeleteTemplate As Button
    Friend WithEvents btnSaveTemplate As Button
    Friend WithEvents ComBoxTemplates As ComboBox
    Friend WithEvents blbForzar2 As Label
    Friend WithEvents PanelGrupo1 As Panel
    Friend WithEvents PanelGrupo2 As Panel
    Friend WithEvents RadioBtnLibrePorHoras As RadioButton
    Friend WithEvents RadioBtnLibrePorDias As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dTPickerHourTo As DateTimePicker
    Private WithEvents dTPickerDateTo As DateTimePicker
    Friend WithEvents dTPickerHourFrom As DateTimePicker
    Private WithEvents dTPickerDateFrom As DateTimePicker
    Friend WithEvents tlp_Title As TableLayoutPanel
    Friend WithEvents ButtonClose As Button
    Friend WithEvents LabelTitle As Label
    Friend WithEvents txtBoxFilter As TextBox
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents lblLog As Label
    Friend WithEvents dgv As DataGridView
    Friend WithEvents PanelNotices As Panel
    Friend WithEvents lblNotices As Label
    Friend WithEvents Slider1 As slider
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BtnInforme As Button
    Friend WithEvents SliderPrintType As slider
    Friend WithEvents RadioButtonExcel As RadioButtonCC
    Friend WithEvents RadioButtonScr As RadioButtonCC
    Friend WithEvents RadioButtonPdf As RadioButtonCC
    Friend WithEvents PanelFreeTimeSelect As Panel
    Friend WithEvents RadioButtonccFreeDays As RadioButtonCC
    Friend WithEvents RadioButtonccFreeHourly As RadioButtonCC
    Friend WithEvents RadioButtonccLibre As RadioButtonCC
    Friend WithEvents RadioButtonccDiario As RadioButtonCC
    Friend WithEvents RadioButtonccMensual As RadioButtonCC
    Friend WithEvents RadioButtonccSemanal As RadioButtonCC
    Friend WithEvents TimerInicio As Timer
    Friend WithEvents RadioBtnMainData As RadioButtonCC
    Friend WithEvents CheckBoxDigiIncludeBothData As RadioButtonCC
    Friend WithEvents RadioBtnSecondaryData As RadioButtonCC
    Friend WithEvents CheckBoxDigi_y_TotIni As CheckBoxCC
    Friend WithEvents CheckBoxDigi_y_TotFin As CheckBoxCC
    Friend WithEvents Label6 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents Timer3 As Timer
    Friend WithEvents Timer4 As Timer
    Friend WithEvents TimerAll As Timer
End Class

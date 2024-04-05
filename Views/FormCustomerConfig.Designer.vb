<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCustomerConfig
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormCustomerConfig))
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        ContextMenuStripDgv = New ContextMenuStrip(components)
        CopiarToolStripMenuItem = New ToolStripMenuItem()
        PegarToolStripMenuItem = New ToolStripMenuItem()
        SuprToolStripMenuItem = New ToolStripMenuItem()
        PanelInitialize = New Panel()
        Label7 = New Label()
        BtnImportTagSiemens = New Button()
        Label6 = New Label()
        Label4 = New Label()
        RadioButtonccSiemens = New RadioButtonCC()
        RadioButtonccRockwell = New RadioButtonCC()
        btnSqlAdminCheck = New Button()
        Label3 = New Label()
        btnSaveDgvToSQL = New Button()
        Panel2 = New Panel()
        Panel13 = New Panel()
        Panel11 = New Panel()
        txtSQLServer = New TextBox()
        Panel4 = New Panel()
        txtSQLPassword = New TextBox()
        Panel5 = New Panel()
        txtSQLUser = New TextBox()
        Panel9 = New Panel()
        txtSQLDataBase = New TextBox()
        Panel12 = New Panel()
        Panel10 = New Panel()
        Label1 = New Label()
        Panel6 = New Panel()
        Label9 = New Label()
        Panel7 = New Panel()
        Label10 = New Label()
        Panel8 = New Panel()
        Label8 = New Label()
        btnDefaultSqlChain = New Button()
        btnSaveSQLConnectionStringData = New Button()
        btnDeleteSQLConnectionStringData = New Button()
        btnSqlCheck = New Button()
        dgv = New DataGridView()
        Panel1 = New Panel()
        PanelDifferentTables = New Panel()
        PanelFreeTimeSelect = New Panel()
        RadioButtonccDelete = New RadioButtonCC()
        RadioButtonccArchive = New RadioButtonCC()
        lblNotices = New DevExpress.XtraEditors.LabelControl()
        Button5 = New Button()
        Button6 = New Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        txtInstallationName = New TextBox()
        Label5 = New Label()
        btnDeleteInstallationName = New Button()
        btnSaveInstallationName = New Button()
        TlpTitle = New TableLayoutPanel()
        ButtonClose = New Button()
        LabelTitle = New Label()
        Panel3 = New Panel()
        TableLayoutPanel3 = New TableLayoutPanel()
        Label2 = New Label()
        ComBoxTables = New ComboBox()
        txtBoxFilter = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        TlpMain = New TableLayoutPanel()
        ContextMenuStripDgv.SuspendLayout()
        PanelInitialize.SuspendLayout()
        Panel2.SuspendLayout()
        Panel13.SuspendLayout()
        Panel11.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel9.SuspendLayout()
        Panel12.SuspendLayout()
        Panel10.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        Panel8.SuspendLayout()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        PanelDifferentTables.SuspendLayout()
        PanelFreeTimeSelect.SuspendLayout()
        TableLayoutPanel1.SuspendLayout()
        TlpTitle.SuspendLayout()
        Panel3.SuspendLayout()
        TableLayoutPanel3.SuspendLayout()
        TlpMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' ContextMenuStripDgv
        ' 
        ContextMenuStripDgv.Items.AddRange(New ToolStripItem() {CopiarToolStripMenuItem, PegarToolStripMenuItem, SuprToolStripMenuItem})
        ContextMenuStripDgv.Name = "ContextMenuStripDgv"
        ContextMenuStripDgv.Size = New Size(137, 70)
        ' 
        ' CopiarToolStripMenuItem
        ' 
        CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        CopiarToolStripMenuItem.Size = New Size(136, 22)
        CopiarToolStripMenuItem.Text = "Copiar"
        ' 
        ' PegarToolStripMenuItem
        ' 
        PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        PegarToolStripMenuItem.Size = New Size(136, 22)
        PegarToolStripMenuItem.Text = "Pegar"
        ' 
        ' SuprToolStripMenuItem
        ' 
        SuprToolStripMenuItem.Name = "SuprToolStripMenuItem"
        SuprToolStripMenuItem.Size = New Size(136, 22)
        SuprToolStripMenuItem.Text = "Borrar texto"
        ' 
        ' PanelInitialize
        ' 
        PanelInitialize.Controls.Add(Label7)
        PanelInitialize.Controls.Add(BtnImportTagSiemens)
        PanelInitialize.Controls.Add(Label6)
        PanelInitialize.Controls.Add(Label4)
        PanelInitialize.Controls.Add(RadioButtonccSiemens)
        PanelInitialize.Controls.Add(RadioButtonccRockwell)
        PanelInitialize.Controls.Add(btnSqlAdminCheck)
        PanelInitialize.Controls.Add(Label3)
        PanelInitialize.Dock = DockStyle.Fill
        PanelInitialize.Location = New Point(3, 109)
        PanelInitialize.Name = "PanelInitialize"
        PanelInitialize.Size = New Size(1238, 44)
        PanelInitialize.TabIndex = 121
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.White
        Label7.Location = New Point(846, 11)
        Label7.Name = "Label7"
        Label7.Size = New Size(129, 21)
        Label7.TabIndex = 117
        Label7.Text = "Tipo del sistema"
        ' 
        ' BtnImportTagSiemens
        ' 
        BtnImportTagSiemens.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnImportTagSiemens.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        BtnImportTagSiemens.FlatAppearance.BorderSize = 0
        BtnImportTagSiemens.FlatStyle = FlatStyle.Flat
        BtnImportTagSiemens.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        BtnImportTagSiemens.ForeColor = Color.White
        BtnImportTagSiemens.Image = CType(resources.GetObject("BtnImportTagSiemens.Image"), Image)
        BtnImportTagSiemens.Location = New Point(978, 5)
        BtnImportTagSiemens.Name = "BtnImportTagSiemens"
        BtnImportTagSiemens.Size = New Size(30, 31)
        BtnImportTagSiemens.TabIndex = 116
        BtnImportTagSiemens.UseVisualStyleBackColor = False
        BtnImportTagSiemens.Visible = False
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.White
        Label6.Location = New Point(1149, 11)
        Label6.Name = "Label6"
        Label6.Size = New Size(75, 21)
        Label6.TabIndex = 115
        Label6.Text = "Rockwell"
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.White
        Label4.Location = New Point(1040, 11)
        Label4.Name = "Label4"
        Label4.Size = New Size(71, 21)
        Label4.TabIndex = 114
        Label4.Text = "Siemens"
        ' 
        ' RadioButtonccSiemens
        ' 
        RadioButtonccSiemens.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        RadioButtonccSiemens.BackColor = Color.Transparent
        RadioButtonccSiemens.Checked = False
        RadioButtonccSiemens.LabelText = ""
        RadioButtonccSiemens.Location = New Point(1016, 14)
        RadioButtonccSiemens.MaximumSize = New Size(300, 18)
        RadioButtonccSiemens.MinimumSize = New Size(18, 18)
        RadioButtonccSiemens.Name = "RadioButtonccSiemens"
        RadioButtonccSiemens.Size = New Size(18, 18)
        RadioButtonccSiemens.TabIndex = 113
        ' 
        ' RadioButtonccRockwell
        ' 
        RadioButtonccRockwell.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        RadioButtonccRockwell.BackColor = Color.Transparent
        RadioButtonccRockwell.Checked = True
        RadioButtonccRockwell.LabelText = ""
        RadioButtonccRockwell.Location = New Point(1125, 14)
        RadioButtonccRockwell.MaximumSize = New Size(300, 18)
        RadioButtonccRockwell.MinimumSize = New Size(18, 18)
        RadioButtonccRockwell.Name = "RadioButtonccRockwell"
        RadioButtonccRockwell.Size = New Size(18, 18)
        RadioButtonccRockwell.TabIndex = 112
        ' 
        ' btnSqlAdminCheck
        ' 
        btnSqlAdminCheck.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnSqlAdminCheck.FlatAppearance.BorderSize = 0
        btnSqlAdminCheck.FlatStyle = FlatStyle.Flat
        btnSqlAdminCheck.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSqlAdminCheck.ForeColor = Color.White
        btnSqlAdminCheck.Image = CType(resources.GetObject("btnSqlAdminCheck.Image"), Image)
        btnSqlAdminCheck.Location = New Point(145, 5)
        btnSqlAdminCheck.Name = "btnSqlAdminCheck"
        btnSqlAdminCheck.Size = New Size(30, 31)
        btnSqlAdminCheck.TabIndex = 111
        btnSqlAdminCheck.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(1, 11)
        Label3.Name = "Label3"
        Label3.Size = New Size(125, 21)
        Label3.TabIndex = 110
        Label3.Text = "Inicializar Tablas"
        ' 
        ' btnSaveDgvToSQL
        ' 
        btnSaveDgvToSQL.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSaveDgvToSQL.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnSaveDgvToSQL.BackgroundImageLayout = ImageLayout.Center
        btnSaveDgvToSQL.FlatAppearance.BorderSize = 0
        btnSaveDgvToSQL.FlatStyle = FlatStyle.Flat
        btnSaveDgvToSQL.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSaveDgvToSQL.ForeColor = Color.White
        btnSaveDgvToSQL.Location = New Point(1194, 785)
        btnSaveDgvToSQL.Margin = New Padding(3, 3, 20, 3)
        btnSaveDgvToSQL.Name = "btnSaveDgvToSQL"
        btnSaveDgvToSQL.Size = New Size(30, 31)
        btnSaveDgvToSQL.TabIndex = 115
        btnSaveDgvToSQL.Text = ""
        btnSaveDgvToSQL.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Panel2.Controls.Add(Panel13)
        Panel2.Controls.Add(Panel12)
        Panel2.Controls.Add(btnDefaultSqlChain)
        Panel2.Controls.Add(btnSaveSQLConnectionStringData)
        Panel2.Controls.Add(btnDeleteSQLConnectionStringData)
        Panel2.Controls.Add(btnSqlCheck)
        Panel2.Location = New Point(0, 156)
        Panel2.Margin = New Padding(0)
        Panel2.Name = "Panel2"
        Panel2.Padding = New Padding(0, 8, 8, 0)
        Panel2.Size = New Size(1244, 199)
        Panel2.TabIndex = 119
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(Panel11)
        Panel13.Controls.Add(Panel4)
        Panel13.Controls.Add(Panel5)
        Panel13.Controls.Add(Panel9)
        Panel13.Location = New Point(195, 8)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(1041, 140)
        Panel13.TabIndex = 122
        ' 
        ' Panel11
        ' 
        Panel11.Controls.Add(txtSQLServer)
        Panel11.Dock = DockStyle.Top
        Panel11.Location = New Point(0, 96)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(1041, 32)
        Panel11.TabIndex = 119
        ' 
        ' txtSQLServer
        ' 
        txtSQLServer.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSQLServer.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtSQLServer.ForeColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        txtSQLServer.Location = New Point(0, 0)
        txtSQLServer.Margin = New Padding(0)
        txtSQLServer.Name = "txtSQLServer"
        txtSQLServer.Size = New Size(1041, 29)
        txtSQLServer.TabIndex = 105
        txtSQLServer.Text = "---"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(txtSQLPassword)
        Panel4.Dock = DockStyle.Top
        Panel4.Location = New Point(0, 64)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1041, 32)
        Panel4.TabIndex = 113
        ' 
        ' txtSQLPassword
        ' 
        txtSQLPassword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSQLPassword.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtSQLPassword.ForeColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        txtSQLPassword.Location = New Point(0, 0)
        txtSQLPassword.Margin = New Padding(0)
        txtSQLPassword.Name = "txtSQLPassword"
        txtSQLPassword.Size = New Size(1041, 29)
        txtSQLPassword.TabIndex = 105
        txtSQLPassword.Text = "---"
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(txtSQLUser)
        Panel5.Dock = DockStyle.Top
        Panel5.Location = New Point(0, 32)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1041, 32)
        Panel5.TabIndex = 114
        ' 
        ' txtSQLUser
        ' 
        txtSQLUser.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSQLUser.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtSQLUser.ForeColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        txtSQLUser.Location = New Point(0, 0)
        txtSQLUser.Margin = New Padding(0)
        txtSQLUser.Name = "txtSQLUser"
        txtSQLUser.Size = New Size(1041, 29)
        txtSQLUser.TabIndex = 105
        txtSQLUser.Text = "---"
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(txtSQLDataBase)
        Panel9.Dock = DockStyle.Top
        Panel9.Location = New Point(0, 0)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(1041, 32)
        Panel9.TabIndex = 117
        ' 
        ' txtSQLDataBase
        ' 
        txtSQLDataBase.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSQLDataBase.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtSQLDataBase.ForeColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        txtSQLDataBase.Location = New Point(0, 0)
        txtSQLDataBase.Margin = New Padding(0)
        txtSQLDataBase.Name = "txtSQLDataBase"
        txtSQLDataBase.Size = New Size(1041, 29)
        txtSQLDataBase.TabIndex = 105
        txtSQLDataBase.Text = "---"
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(Panel10)
        Panel12.Controls.Add(Panel6)
        Panel12.Controls.Add(Panel7)
        Panel12.Controls.Add(Panel8)
        Panel12.Location = New Point(4, 11)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(196, 137)
        Panel12.TabIndex = 121
        ' 
        ' Panel10
        ' 
        Panel10.Controls.Add(Label1)
        Panel10.Dock = DockStyle.Top
        Panel10.Location = New Point(0, 96)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(196, 32)
        Panel10.TabIndex = 120
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.White
        Label1.Location = New Point(0, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(160, 21)
        Label1.TabIndex = 104
        Label1.Text = "Servidor SQLSERVER"
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(Label9)
        Panel6.Dock = DockStyle.Top
        Panel6.Location = New Point(0, 64)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(196, 32)
        Panel6.TabIndex = 115
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.ForeColor = Color.White
        Label9.Location = New Point(0, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(65, 21)
        Label9.TabIndex = 104
        Label9.Text = "Usuario"
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(Label10)
        Panel7.Dock = DockStyle.Top
        Panel7.Location = New Point(0, 32)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(196, 32)
        Panel7.TabIndex = 116
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.White
        Label10.Location = New Point(0, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(78, 21)
        Label10.TabIndex = 104
        Label10.Text = "Password"
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(Label8)
        Panel8.Dock = DockStyle.Top
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(196, 32)
        Panel8.TabIndex = 118
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = Color.White
        Label8.Location = New Point(0, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(115, 21)
        Label8.TabIndex = 104
        Label8.Text = "Base de datos "
        ' 
        ' btnDefaultSqlChain
        ' 
        btnDefaultSqlChain.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDefaultSqlChain.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnDefaultSqlChain.FlatAppearance.BorderSize = 0
        btnDefaultSqlChain.FlatStyle = FlatStyle.Flat
        btnDefaultSqlChain.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnDefaultSqlChain.ForeColor = Color.White
        btnDefaultSqlChain.Image = CType(resources.GetObject("btnDefaultSqlChain.Image"), Image)
        btnDefaultSqlChain.Location = New Point(1090, 158)
        btnDefaultSqlChain.Name = "btnDefaultSqlChain"
        btnDefaultSqlChain.Size = New Size(30, 31)
        btnDefaultSqlChain.TabIndex = 109
        btnDefaultSqlChain.UseVisualStyleBackColor = False
        ' 
        ' btnSaveSQLConnectionStringData
        ' 
        btnSaveSQLConnectionStringData.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSaveSQLConnectionStringData.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnSaveSQLConnectionStringData.BackgroundImageLayout = ImageLayout.Center
        btnSaveSQLConnectionStringData.Enabled = False
        btnSaveSQLConnectionStringData.FlatAppearance.BorderSize = 0
        btnSaveSQLConnectionStringData.FlatStyle = FlatStyle.Flat
        btnSaveSQLConnectionStringData.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSaveSQLConnectionStringData.ForeColor = Color.White
        btnSaveSQLConnectionStringData.Location = New Point(1197, 158)
        btnSaveSQLConnectionStringData.Name = "btnSaveSQLConnectionStringData"
        btnSaveSQLConnectionStringData.Size = New Size(30, 31)
        btnSaveSQLConnectionStringData.TabIndex = 106
        btnSaveSQLConnectionStringData.Text = ""
        btnSaveSQLConnectionStringData.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteSQLConnectionStringData
        ' 
        btnDeleteSQLConnectionStringData.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteSQLConnectionStringData.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnDeleteSQLConnectionStringData.FlatAppearance.BorderSize = 0
        btnDeleteSQLConnectionStringData.FlatStyle = FlatStyle.Flat
        btnDeleteSQLConnectionStringData.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnDeleteSQLConnectionStringData.ForeColor = Color.White
        btnDeleteSQLConnectionStringData.Location = New Point(1161, 158)
        btnDeleteSQLConnectionStringData.Name = "btnDeleteSQLConnectionStringData"
        btnDeleteSQLConnectionStringData.Size = New Size(30, 31)
        btnDeleteSQLConnectionStringData.TabIndex = 107
        btnDeleteSQLConnectionStringData.Text = ""
        btnDeleteSQLConnectionStringData.UseVisualStyleBackColor = False
        ' 
        ' btnSqlCheck
        ' 
        btnSqlCheck.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSqlCheck.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnSqlCheck.FlatAppearance.BorderSize = 0
        btnSqlCheck.FlatStyle = FlatStyle.Flat
        btnSqlCheck.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSqlCheck.ForeColor = Color.White
        btnSqlCheck.Image = CType(resources.GetObject("btnSqlCheck.Image"), Image)
        btnSqlCheck.Location = New Point(1126, 158)
        btnSqlCheck.Name = "btnSqlCheck"
        btnSqlCheck.Size = New Size(30, 31)
        btnSqlCheck.TabIndex = 108
        btnSqlCheck.UseVisualStyleBackColor = False
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
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgv.DefaultCellStyle = DataGridViewCellStyle2
        dgv.Dock = DockStyle.Fill
        dgv.Location = New Point(0, 404)
        dgv.Margin = New Padding(0, 8, 0, 8)
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
        dgv.Size = New Size(1244, 367)
        dgv.TabIndex = 113
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(PanelDifferentTables)
        Panel1.Controls.Add(TableLayoutPanel1)
        Panel1.Controls.Add(btnDeleteInstallationName)
        Panel1.Controls.Add(btnSaveInstallationName)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 34)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(0, 8, 8, 0)
        Panel1.Size = New Size(1244, 72)
        Panel1.TabIndex = 116
        ' 
        ' PanelDifferentTables
        ' 
        PanelDifferentTables.Controls.Add(PanelFreeTimeSelect)
        PanelDifferentTables.Controls.Add(lblNotices)
        PanelDifferentTables.Controls.Add(Button5)
        PanelDifferentTables.Controls.Add(Button6)
        PanelDifferentTables.Dock = DockStyle.Fill
        PanelDifferentTables.Location = New Point(0, 37)
        PanelDifferentTables.Margin = New Padding(0)
        PanelDifferentTables.Name = "PanelDifferentTables"
        PanelDifferentTables.Padding = New Padding(0, 8, 8, 0)
        PanelDifferentTables.Size = New Size(1236, 35)
        PanelDifferentTables.TabIndex = 117
        ' 
        ' PanelFreeTimeSelect
        ' 
        PanelFreeTimeSelect.Controls.Add(RadioButtonccDelete)
        PanelFreeTimeSelect.Controls.Add(RadioButtonccArchive)
        PanelFreeTimeSelect.Dock = DockStyle.Right
        PanelFreeTimeSelect.Location = New Point(1070, 8)
        PanelFreeTimeSelect.Name = "PanelFreeTimeSelect"
        PanelFreeTimeSelect.Size = New Size(158, 27)
        PanelFreeTimeSelect.TabIndex = 106
        ' 
        ' RadioButtonccDelete
        ' 
        RadioButtonccDelete.BackColor = Color.Transparent
        RadioButtonccDelete.Checked = False
        RadioButtonccDelete.LabelText = "Borrar"
        RadioButtonccDelete.Location = New Point(87, 5)
        RadioButtonccDelete.MaximumSize = New Size(300, 18)
        RadioButtonccDelete.MinimumSize = New Size(18, 18)
        RadioButtonccDelete.Name = "RadioButtonccDelete"
        RadioButtonccDelete.Size = New Size(67, 18)
        RadioButtonccDelete.TabIndex = 96
        RadioButtonccDelete.Visible = False
        ' 
        ' RadioButtonccArchive
        ' 
        RadioButtonccArchive.BackColor = Color.Transparent
        RadioButtonccArchive.Checked = True
        RadioButtonccArchive.LabelText = "Ocultar"
        RadioButtonccArchive.Location = New Point(3, 5)
        RadioButtonccArchive.MaximumSize = New Size(300, 18)
        RadioButtonccArchive.MinimumSize = New Size(18, 18)
        RadioButtonccArchive.Name = "RadioButtonccArchive"
        RadioButtonccArchive.Size = New Size(73, 18)
        RadioButtonccArchive.TabIndex = 95
        RadioButtonccArchive.Visible = False
        ' 
        ' lblNotices
        ' 
        lblNotices.AccessibleRole = AccessibleRole.TitleBar
        lblNotices.Appearance.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        lblNotices.Appearance.ForeColor = Color.White
        lblNotices.Appearance.Options.UseFont = True
        lblNotices.Appearance.Options.UseForeColor = True
        lblNotices.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        lblNotices.Dock = DockStyle.Left
        lblNotices.Location = New Point(0, 8)
        lblNotices.Name = "lblNotices"
        lblNotices.Size = New Size(1225, 27)
        lblNotices.TabIndex = 105
        lblNotices.Text = "- - - Notices"
        lblNotices.Visible = False
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button5.ForeColor = Color.White
        Button5.Location = New Point(2194, 51)
        Button5.Name = "Button5"
        Button5.Size = New Size(30, 31)
        Button5.TabIndex = 103
        Button5.Text = ""
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button6.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        Button6.BackgroundImageLayout = ImageLayout.Center
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button6.ForeColor = Color.White
        Button6.Location = New Point(2230, 51)
        Button6.Name = "Button6"
        Button6.Size = New Size(30, 31)
        Button6.TabIndex = 102
        Button6.Text = ""
        Button6.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.ColumnCount = 2
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 200F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Controls.Add(txtInstallationName, 1, 0)
        TableLayoutPanel1.Controls.Add(Label5, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Top
        TableLayoutPanel1.Location = New Point(0, 8)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 29F))
        TableLayoutPanel1.Size = New Size(1236, 29)
        TableLayoutPanel1.TabIndex = 104
        ' 
        ' txtInstallationName
        ' 
        txtInstallationName.Dock = DockStyle.Fill
        txtInstallationName.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtInstallationName.ForeColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        txtInstallationName.Location = New Point(200, 0)
        txtInstallationName.Margin = New Padding(0)
        txtInstallationName.Name = "txtInstallationName"
        txtInstallationName.Size = New Size(1036, 29)
        txtInstallationName.TabIndex = 38
        txtInstallationName.Text = "---"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.White
        Label5.Location = New Point(3, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(191, 21)
        Label5.TabIndex = 37
        Label5.Text = "Nombre de la instalación"
        ' 
        ' btnDeleteInstallationName
        ' 
        btnDeleteInstallationName.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnDeleteInstallationName.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnDeleteInstallationName.FlatAppearance.BorderSize = 0
        btnDeleteInstallationName.FlatStyle = FlatStyle.Flat
        btnDeleteInstallationName.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnDeleteInstallationName.ForeColor = Color.White
        btnDeleteInstallationName.Location = New Point(1166, 43)
        btnDeleteInstallationName.Name = "btnDeleteInstallationName"
        btnDeleteInstallationName.Size = New Size(30, 31)
        btnDeleteInstallationName.TabIndex = 103
        btnDeleteInstallationName.Text = ""
        btnDeleteInstallationName.UseVisualStyleBackColor = False
        ' 
        ' btnSaveInstallationName
        ' 
        btnSaveInstallationName.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSaveInstallationName.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        btnSaveInstallationName.BackgroundImageLayout = ImageLayout.Center
        btnSaveInstallationName.FlatAppearance.BorderSize = 0
        btnSaveInstallationName.FlatStyle = FlatStyle.Flat
        btnSaveInstallationName.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSaveInstallationName.ForeColor = Color.White
        btnSaveInstallationName.Location = New Point(1202, 43)
        btnSaveInstallationName.Name = "btnSaveInstallationName"
        btnSaveInstallationName.Size = New Size(30, 31)
        btnSaveInstallationName.TabIndex = 102
        btnSaveInstallationName.Text = ""
        btnSaveInstallationName.UseVisualStyleBackColor = False
        ' 
        ' TlpTitle
        ' 
        TlpTitle.ColumnCount = 2
        TlpTitle.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TlpTitle.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 46F))
        TlpTitle.Controls.Add(ButtonClose, 1, 0)
        TlpTitle.Controls.Add(LabelTitle, 0, 0)
        TlpTitle.Dock = DockStyle.Fill
        TlpTitle.Location = New Point(0, 0)
        TlpTitle.Margin = New Padding(0)
        TlpTitle.Name = "TlpTitle"
        TlpTitle.RowCount = 1
        TlpTitle.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TlpTitle.Size = New Size(1244, 34)
        TlpTitle.TabIndex = 118
        ' 
        ' ButtonClose
        ' 
        ButtonClose.BackColor = Color.FromArgb(CByte(0), CByte(132), CByte(201))
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
        ButtonClose.TabIndex = 110
        ButtonClose.Text = ""
        ButtonClose.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonClose.UseVisualStyleBackColor = False
        ' 
        ' LabelTitle
        ' 
        LabelTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        LabelTitle.BackColor = Color.FromArgb(CByte(0), CByte(196), CByte(213))
        LabelTitle.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point)
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(0, 0)
        LabelTitle.Margin = New Padding(0)
        LabelTitle.Name = "LabelTitle"
        LabelTitle.Size = New Size(1198, 34)
        LabelTitle.TabIndex = 33
        LabelTitle.Text = "Configuración de la instalación "
        LabelTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(TableLayoutPanel3)
        Panel3.Controls.Add(Button1)
        Panel3.Controls.Add(Button2)
        Panel3.Controls.Add(Button3)
        Panel3.Controls.Add(Button4)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 356)
        Panel3.Margin = New Padding(0)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(0, 8, 8, 0)
        Panel3.Size = New Size(1244, 40)
        Panel3.TabIndex = 120
        ' 
        ' TableLayoutPanel3
        ' 
        TableLayoutPanel3.ColumnCount = 3
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 200F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 194F))
        TableLayoutPanel3.Controls.Add(Label2, 0, 0)
        TableLayoutPanel3.Controls.Add(ComBoxTables, 1, 0)
        TableLayoutPanel3.Controls.Add(txtBoxFilter, 2, 0)
        TableLayoutPanel3.Dock = DockStyle.Top
        TableLayoutPanel3.Location = New Point(0, 8)
        TableLayoutPanel3.Margin = New Padding(0)
        TableLayoutPanel3.Name = "TableLayoutPanel3"
        TableLayoutPanel3.RowCount = 1
        TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Absolute, 29F))
        TableLayoutPanel3.Size = New Size(1236, 29)
        TableLayoutPanel3.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(136, 21)
        Label2.TabIndex = 111
        Label2.Text = "Gestión de tablas"
        ' 
        ' ComBoxTables
        ' 
        ComBoxTables.Dock = DockStyle.Fill
        ComBoxTables.DropDownStyle = ComboBoxStyle.DropDownList
        ComBoxTables.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ComBoxTables.FormattingEnabled = True
        ComBoxTables.Location = New Point(200, 0)
        ComBoxTables.Margin = New Padding(0, 0, 3, 0)
        ComBoxTables.MaxDropDownItems = 20
        ComBoxTables.Name = "ComBoxTables"
        ComBoxTables.Size = New Size(839, 29)
        ComBoxTables.Sorted = True
        ComBoxTables.TabIndex = 112
        ' 
        ' txtBoxFilter
        ' 
        txtBoxFilter.BorderStyle = BorderStyle.None
        txtBoxFilter.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtBoxFilter.Location = New Point(1042, 0)
        txtBoxFilter.Margin = New Padding(0)
        txtBoxFilter.MaximumSize = New Size(194, 29)
        txtBoxFilter.MinimumSize = New Size(194, 29)
        txtBoxFilter.Name = "txtBoxFilter"
        txtBoxFilter.PlaceholderText = "Filtrar..."
        txtBoxFilter.Size = New Size(194, 29)
        txtBoxFilter.TabIndex = 114
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.Location = New Point(2131, 50)
        Button1.Name = "Button1"
        Button1.Size = New Size(30, 31)
        Button1.TabIndex = 109
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        Button2.BackgroundImageLayout = ImageLayout.Center
        Button2.Enabled = False
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(2238, 50)
        Button2.Name = "Button2"
        Button2.Size = New Size(30, 31)
        Button2.TabIndex = 106
        Button2.Text = ""
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button3.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button3.ForeColor = Color.White
        Button3.Location = New Point(2202, 50)
        Button3.Name = "Button3"
        Button3.Size = New Size(30, 31)
        Button3.TabIndex = 107
        Button3.Text = ""
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button4.BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Segoe Fluent Icons", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Button4.ForeColor = Color.White
        Button4.Image = CType(resources.GetObject("Button4.Image"), Image)
        Button4.Location = New Point(2167, 50)
        Button4.Name = "Button4"
        Button4.Size = New Size(30, 31)
        Button4.TabIndex = 108
        Button4.UseVisualStyleBackColor = False
        ' 
        ' TlpMain
        ' 
        TlpMain.ColumnCount = 1
        TlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        TlpMain.Controls.Add(Panel3, 0, 4)
        TlpMain.Controls.Add(TlpTitle, 0, 0)
        TlpMain.Controls.Add(Panel1, 0, 1)
        TlpMain.Controls.Add(dgv, 0, 5)
        TlpMain.Controls.Add(btnSaveDgvToSQL, 0, 6)
        TlpMain.Controls.Add(PanelInitialize, 0, 2)
        TlpMain.Controls.Add(Panel2, 0, 3)
        TlpMain.Dock = DockStyle.Fill
        TlpMain.Location = New Point(0, 0)
        TlpMain.Margin = New Padding(0)
        TlpMain.Name = "TlpMain"
        TlpMain.RowCount = 7
        TlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        TlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 72F))
        TlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 50F))
        TlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 200F))
        TlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        TlpMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TlpMain.RowStyles.Add(New RowStyle(SizeType.Absolute, 40F))
        TlpMain.Size = New Size(1244, 819)
        TlpMain.TabIndex = 117
        ' 
        ' FormCustomerConfig
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(4), CByte(41), CByte(68))
        ClientSize = New Size(1244, 819)
        Controls.Add(TlpMain)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FormCustomerConfig"
        Text = "Configuración de la instalación "
        TransparencyKey = Color.FromArgb(CByte(255), CByte(192), CByte(255))
        ContextMenuStripDgv.ResumeLayout(False)
        PanelInitialize.ResumeLayout(False)
        PanelInitialize.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        Panel12.ResumeLayout(False)
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        PanelDifferentTables.ResumeLayout(False)
        PanelFreeTimeSelect.ResumeLayout(False)
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TlpTitle.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        TableLayoutPanel3.ResumeLayout(False)
        TableLayoutPanel3.PerformLayout()
        TlpMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents ContextMenuStripDgv As ContextMenuStrip
    Friend WithEvents CopiarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PegarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SuprToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PanelInitialize As Panel
    Private WithEvents BtnImportTagSiemens As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents RadioButtonccSiemens As RadioButtonCC
    Friend WithEvents RadioButtonccRockwell As RadioButtonCC
    Private WithEvents btnSqlAdminCheck As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSaveDgvToSQL As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtSQLServer As TextBox
    Private WithEvents btnDefaultSqlChain As Button
    Friend WithEvents btnSaveSQLConnectionStringData As Button
    Protected WithEvents btnDeleteSQLConnectionStringData As Button
    Private WithEvents btnSqlCheck As Button
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelDifferentTables As Panel
    Friend WithEvents PanelFreeTimeSelect As Panel
    Friend WithEvents RadioButtonccDelete As RadioButtonCC
    Friend WithEvents RadioButtonccArchive As RadioButtonCC
    Friend WithEvents lblNotices As DevExpress.XtraEditors.LabelControl
    Protected WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents txtInstallationName As TextBox
    Friend WithEvents Label5 As Label
    Protected WithEvents btnDeleteInstallationName As Button
    Friend WithEvents btnSaveInstallationName As Button
    Friend WithEvents TlpTitle As TableLayoutPanel
    Friend WithEvents ButtonClose As Button
    Friend WithEvents LabelTitle As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents ComBoxTables As ComboBox
    Friend WithEvents txtBoxFilter As TextBox
    Private WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Protected WithEvents Button3 As Button
    Private WithEvents Button4 As Button
    Friend WithEvents TlpMain As TableLayoutPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSQLPassword As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSQLUser As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSQLDataBase As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel12 As Panel
End Class

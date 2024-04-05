<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormMain))
        PanelContenedor = New Panel()
        PanelForms = New Panel()
        LblVersion = New Label()
        PictureBox1 = New PictureBox()
        PanelMenu = New Panel()
        BtnInformeDigitales = New Button()
        ButtonImportTIAPORTAL = New Button()
        ButtonImportTIAPORTALMark = New Button()
        ButtonAnalog = New Button()
        ButtonAnalogMark = New Button()
        BtnInformeAnalogicas = New Button()
        BtnPruebaInformeMark = New Button()
        ButtonConfig = New Button()
        ButtonConfigMark = New Button()
        BtnInformeDigitalMark = New Button()
        PanelBarraTitulo = New Panel()
        Label2 = New Label()
        BtnFormClose = New Button()
        BtnFormMinimize = New Button()
        BtnFormRestore = New Button()
        BtnFormMaximize = New Button()
        TimerReload = New Timer(components)
        TimerPaintCorner = New Timer(components)
        PanelContenedor.SuspendLayout()
        PanelForms.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        PanelMenu.SuspendLayout()
        PanelBarraTitulo.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelContenedor
        ' 
        PanelContenedor.BackColor = SystemColors.ActiveCaption
        PanelContenedor.Controls.Add(PanelForms)
        PanelContenedor.Controls.Add(PanelMenu)
        PanelContenedor.Controls.Add(PanelBarraTitulo)
        PanelContenedor.Dock = DockStyle.Fill
        PanelContenedor.Location = New Point(0, 0)
        PanelContenedor.Margin = New Padding(2, 3, 2, 3)
        PanelContenedor.Name = "PanelContenedor"
        PanelContenedor.Size = New Size(1440, 900)
        PanelContenedor.TabIndex = 0
        ' 
        ' PanelForms
        ' 
        PanelForms.BackColor = SystemColors.Control
        PanelForms.Controls.Add(LblVersion)
        PanelForms.Controls.Add(PictureBox1)
        PanelForms.Dock = DockStyle.Fill
        PanelForms.Location = New Point(200, 40)
        PanelForms.Margin = New Padding(2, 3, 2, 3)
        PanelForms.Name = "PanelForms"
        PanelForms.Size = New Size(1240, 860)
        PanelForms.TabIndex = 2
        ' 
        ' LblVersion
        ' 
        LblVersion.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        LblVersion.Font = New Font("Segoe UI Variable Display", 18F, FontStyle.Regular, GraphicsUnit.Point)
        LblVersion.ForeColor = Color.FromArgb(CByte(0), CByte(132), CByte(201))
        LblVersion.Location = New Point(252, 813)
        LblVersion.Margin = New Padding(2, 0, 2, 0)
        LblVersion.Name = "LblVersion"
        LblVersion.Size = New Size(977, 32)
        LblVersion.TabIndex = 11
        LblVersion.Text = "System Version"
        LblVersion.TextAlign = ContentAlignment.TopRight
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Dock = DockStyle.Fill
        PictureBox1.Image = My.Resources.Resources.CYII_Logo
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(1240, 860)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' PanelMenu
        ' 
        PanelMenu.BackColor = Color.FromArgb(CByte(0), CByte(132), CByte(201))
        PanelMenu.Controls.Add(BtnInformeDigitales)
        PanelMenu.Controls.Add(ButtonImportTIAPORTAL)
        PanelMenu.Controls.Add(ButtonImportTIAPORTALMark)
        PanelMenu.Controls.Add(ButtonAnalog)
        PanelMenu.Controls.Add(ButtonAnalogMark)
        PanelMenu.Controls.Add(BtnInformeAnalogicas)
        PanelMenu.Controls.Add(BtnPruebaInformeMark)
        PanelMenu.Controls.Add(ButtonConfig)
        PanelMenu.Controls.Add(ButtonConfigMark)
        PanelMenu.Controls.Add(BtnInformeDigitalMark)
        PanelMenu.Dock = DockStyle.Left
        PanelMenu.Location = New Point(0, 40)
        PanelMenu.Margin = New Padding(2, 3, 2, 3)
        PanelMenu.Name = "PanelMenu"
        PanelMenu.Size = New Size(200, 860)
        PanelMenu.TabIndex = 1
        ' 
        ' BtnInformeDigitales
        ' 
        BtnInformeDigitales.FlatAppearance.BorderSize = 0
        BtnInformeDigitales.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnInformeDigitales.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        BtnInformeDigitales.FlatStyle = FlatStyle.Flat
        BtnInformeDigitales.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BtnInformeDigitales.ForeColor = Color.Gainsboro
        BtnInformeDigitales.Image = CType(resources.GetObject("BtnInformeDigitales.Image"), Image)
        BtnInformeDigitales.ImageAlign = ContentAlignment.MiddleLeft
        BtnInformeDigitales.Location = New Point(5, 40)
        BtnInformeDigitales.Margin = New Padding(2, 3, 2, 3)
        BtnInformeDigitales.Name = "BtnInformeDigitales"
        BtnInformeDigitales.Size = New Size(195, 40)
        BtnInformeDigitales.TabIndex = 6
        BtnInformeDigitales.Text = "  Informe  Digitales"
        BtnInformeDigitales.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnInformeDigitales.UseVisualStyleBackColor = True
        ' 
        ' ButtonImportTIAPORTAL
        ' 
        ButtonImportTIAPORTAL.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonImportTIAPORTAL.FlatAppearance.BorderSize = 0
        ButtonImportTIAPORTAL.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ButtonImportTIAPORTAL.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        ButtonImportTIAPORTAL.FlatStyle = FlatStyle.Flat
        ButtonImportTIAPORTAL.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonImportTIAPORTAL.ForeColor = Color.Gainsboro
        ButtonImportTIAPORTAL.Image = My.Resources.Resources.diy
        ButtonImportTIAPORTAL.ImageAlign = ContentAlignment.MiddleLeft
        ButtonImportTIAPORTAL.Location = New Point(5, 773)
        ButtonImportTIAPORTAL.Margin = New Padding(2, 3, 2, 3)
        ButtonImportTIAPORTAL.Name = "ButtonImportTIAPORTAL"
        ButtonImportTIAPORTAL.Size = New Size(195, 40)
        ButtonImportTIAPORTAL.TabIndex = 1
        ButtonImportTIAPORTAL.Text = "  Importar Tags"
        ButtonImportTIAPORTAL.TextAlign = ContentAlignment.MiddleLeft
        ButtonImportTIAPORTAL.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonImportTIAPORTAL.UseVisualStyleBackColor = True
        ButtonImportTIAPORTAL.Visible = False
        ' 
        ' ButtonImportTIAPORTALMark
        ' 
        ButtonImportTIAPORTALMark.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonImportTIAPORTALMark.BackColor = Color.FromArgb(CByte(167), CByte(123), CByte(202))
        ButtonImportTIAPORTALMark.Enabled = False
        ButtonImportTIAPORTALMark.FlatAppearance.BorderSize = 0
        ButtonImportTIAPORTALMark.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ButtonImportTIAPORTALMark.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        ButtonImportTIAPORTALMark.FlatStyle = FlatStyle.Flat
        ButtonImportTIAPORTALMark.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonImportTIAPORTALMark.ForeColor = Color.Gainsboro
        ButtonImportTIAPORTALMark.ImageAlign = ContentAlignment.MiddleLeft
        ButtonImportTIAPORTALMark.Location = New Point(0, 773)
        ButtonImportTIAPORTALMark.Margin = New Padding(2, 3, 2, 3)
        ButtonImportTIAPORTALMark.Name = "ButtonImportTIAPORTALMark"
        ButtonImportTIAPORTALMark.Size = New Size(12, 40)
        ButtonImportTIAPORTALMark.TabIndex = 4
        ButtonImportTIAPORTALMark.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonImportTIAPORTALMark.UseVisualStyleBackColor = False
        ' 
        ' ButtonAnalog
        ' 
        ButtonAnalog.FlatAppearance.BorderSize = 0
        ButtonAnalog.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ButtonAnalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        ButtonAnalog.FlatStyle = FlatStyle.Flat
        ButtonAnalog.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonAnalog.ForeColor = Color.Gainsboro
        ButtonAnalog.Image = My.Resources.Resources.wave
        ButtonAnalog.ImageAlign = ContentAlignment.MiddleLeft
        ButtonAnalog.Location = New Point(2, 267)
        ButtonAnalog.Margin = New Padding(2, 3, 2, 3)
        ButtonAnalog.Name = "ButtonAnalog"
        ButtonAnalog.Size = New Size(198, 40)
        ButtonAnalog.TabIndex = 0
        ButtonAnalog.Text = "  Señales analógicas"
        ButtonAnalog.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonAnalog.UseVisualStyleBackColor = True
        ButtonAnalog.Visible = False
        ' 
        ' ButtonAnalogMark
        ' 
        ButtonAnalogMark.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        ButtonAnalogMark.Enabled = False
        ButtonAnalogMark.FlatAppearance.BorderSize = 0
        ButtonAnalogMark.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ButtonAnalogMark.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        ButtonAnalogMark.FlatStyle = FlatStyle.Flat
        ButtonAnalogMark.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonAnalogMark.ForeColor = Color.Gainsboro
        ButtonAnalogMark.ImageAlign = ContentAlignment.MiddleLeft
        ButtonAnalogMark.Location = New Point(0, 267)
        ButtonAnalogMark.Margin = New Padding(2, 3, 2, 3)
        ButtonAnalogMark.Name = "ButtonAnalogMark"
        ButtonAnalogMark.Size = New Size(12, 40)
        ButtonAnalogMark.TabIndex = 3
        ButtonAnalogMark.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonAnalogMark.UseVisualStyleBackColor = False
        ButtonAnalogMark.Visible = False
        ' 
        ' BtnInformeAnalogicas
        ' 
        BtnInformeAnalogicas.FlatAppearance.BorderSize = 0
        BtnInformeAnalogicas.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnInformeAnalogicas.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        BtnInformeAnalogicas.FlatStyle = FlatStyle.Flat
        BtnInformeAnalogicas.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BtnInformeAnalogicas.ForeColor = Color.Gainsboro
        BtnInformeAnalogicas.Image = CType(resources.GetObject("BtnInformeAnalogicas.Image"), Image)
        BtnInformeAnalogicas.ImageAlign = ContentAlignment.MiddleLeft
        BtnInformeAnalogicas.Location = New Point(5, 0)
        BtnInformeAnalogicas.Margin = New Padding(2, 3, 2, 3)
        BtnInformeAnalogicas.Name = "BtnInformeAnalogicas"
        BtnInformeAnalogicas.Size = New Size(195, 40)
        BtnInformeAnalogicas.TabIndex = 3
        BtnInformeAnalogicas.Text = "  Informe Analógicas"
        BtnInformeAnalogicas.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnInformeAnalogicas.UseVisualStyleBackColor = True
        ' 
        ' BtnPruebaInformeMark
        ' 
        BtnPruebaInformeMark.BackColor = Color.FromArgb(CByte(167), CByte(123), CByte(202))
        BtnPruebaInformeMark.Enabled = False
        BtnPruebaInformeMark.FlatAppearance.BorderSize = 0
        BtnPruebaInformeMark.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnPruebaInformeMark.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        BtnPruebaInformeMark.FlatStyle = FlatStyle.Flat
        BtnPruebaInformeMark.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BtnPruebaInformeMark.ForeColor = Color.Gainsboro
        BtnPruebaInformeMark.ImageAlign = ContentAlignment.MiddleLeft
        BtnPruebaInformeMark.Location = New Point(0, 0)
        BtnPruebaInformeMark.Margin = New Padding(2, 3, 2, 3)
        BtnPruebaInformeMark.Name = "BtnPruebaInformeMark"
        BtnPruebaInformeMark.Size = New Size(12, 40)
        BtnPruebaInformeMark.TabIndex = 5
        BtnPruebaInformeMark.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnPruebaInformeMark.UseVisualStyleBackColor = False
        ' 
        ' ButtonConfig
        ' 
        ButtonConfig.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonConfig.FlatAppearance.BorderSize = 0
        ButtonConfig.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ButtonConfig.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        ButtonConfig.FlatStyle = FlatStyle.Flat
        ButtonConfig.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonConfig.ForeColor = Color.Gainsboro
        ButtonConfig.Image = My.Resources.Resources.Config
        ButtonConfig.ImageAlign = ContentAlignment.MiddleLeft
        ButtonConfig.Location = New Point(5, 813)
        ButtonConfig.Margin = New Padding(2, 3, 2, 3)
        ButtonConfig.Name = "ButtonConfig"
        ButtonConfig.Size = New Size(195, 40)
        ButtonConfig.TabIndex = 3
        ButtonConfig.Text = "  Configuración"
        ButtonConfig.TextAlign = ContentAlignment.MiddleLeft
        ButtonConfig.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonConfig.UseVisualStyleBackColor = True
        ' 
        ' ButtonConfigMark
        ' 
        ButtonConfigMark.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ButtonConfigMark.BackColor = Color.FromArgb(CByte(167), CByte(123), CByte(202))
        ButtonConfigMark.Enabled = False
        ButtonConfigMark.FlatAppearance.BorderSize = 0
        ButtonConfigMark.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        ButtonConfigMark.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        ButtonConfigMark.FlatStyle = FlatStyle.Flat
        ButtonConfigMark.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ButtonConfigMark.ForeColor = Color.Gainsboro
        ButtonConfigMark.ImageAlign = ContentAlignment.MiddleLeft
        ButtonConfigMark.Location = New Point(0, 813)
        ButtonConfigMark.Margin = New Padding(2, 3, 2, 3)
        ButtonConfigMark.Name = "ButtonConfigMark"
        ButtonConfigMark.Size = New Size(12, 40)
        ButtonConfigMark.TabIndex = 5
        ButtonConfigMark.TextImageRelation = TextImageRelation.ImageBeforeText
        ButtonConfigMark.UseVisualStyleBackColor = False
        ' 
        ' BtnInformeDigitalMark
        ' 
        BtnInformeDigitalMark.BackColor = Color.FromArgb(CByte(167), CByte(123), CByte(202))
        BtnInformeDigitalMark.Enabled = False
        BtnInformeDigitalMark.FlatAppearance.BorderSize = 0
        BtnInformeDigitalMark.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnInformeDigitalMark.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        BtnInformeDigitalMark.FlatStyle = FlatStyle.Flat
        BtnInformeDigitalMark.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BtnInformeDigitalMark.ForeColor = Color.Gainsboro
        BtnInformeDigitalMark.ImageAlign = ContentAlignment.MiddleLeft
        BtnInformeDigitalMark.Location = New Point(0, 40)
        BtnInformeDigitalMark.Margin = New Padding(2, 3, 2, 3)
        BtnInformeDigitalMark.Name = "BtnInformeDigitalMark"
        BtnInformeDigitalMark.Size = New Size(12, 40)
        BtnInformeDigitalMark.TabIndex = 7
        BtnInformeDigitalMark.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnInformeDigitalMark.UseVisualStyleBackColor = False
        ' 
        ' PanelBarraTitulo
        ' 
        PanelBarraTitulo.BackColor = Color.FromArgb(CByte(0), CByte(132), CByte(201))
        PanelBarraTitulo.Controls.Add(Label2)
        PanelBarraTitulo.Controls.Add(BtnFormClose)
        PanelBarraTitulo.Controls.Add(BtnFormMinimize)
        PanelBarraTitulo.Controls.Add(BtnFormRestore)
        PanelBarraTitulo.Controls.Add(BtnFormMaximize)
        PanelBarraTitulo.Dock = DockStyle.Top
        PanelBarraTitulo.Location = New Point(0, 0)
        PanelBarraTitulo.Margin = New Padding(2, 3, 2, 3)
        PanelBarraTitulo.Name = "PanelBarraTitulo"
        PanelBarraTitulo.Size = New Size(1440, 40)
        PanelBarraTitulo.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Variable Display", 18F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.White
        Label2.Location = New Point(0, 4)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(479, 32)
        Label2.TabIndex = 2
        Label2.Text = "Canal de Isabel II - Herramienta de informes"
        ' 
        ' BtnFormClose
        ' 
        BtnFormClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnFormClose.BackColor = Color.FromArgb(CByte(0), CByte(132), CByte(201))
        BtnFormClose.FlatAppearance.BorderSize = 0
        BtnFormClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnFormClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(196), CByte(43), CByte(28))
        BtnFormClose.FlatStyle = FlatStyle.Flat
        BtnFormClose.Font = New Font("Segoe Fluent Icons", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BtnFormClose.ForeColor = Color.Gainsboro
        BtnFormClose.ImageAlign = ContentAlignment.MiddleLeft
        BtnFormClose.Location = New Point(1393, 0)
        BtnFormClose.Margin = New Padding(2, 3, 2, 3)
        BtnFormClose.Name = "BtnFormClose"
        BtnFormClose.Size = New Size(46, 28)
        BtnFormClose.TabIndex = 9
        BtnFormClose.Text = ""
        BtnFormClose.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnFormClose.UseVisualStyleBackColor = False
        ' 
        ' BtnFormMinimize
        ' 
        BtnFormMinimize.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnFormMinimize.FlatAppearance.BorderSize = 0
        BtnFormMinimize.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnFormMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        BtnFormMinimize.FlatStyle = FlatStyle.Flat
        BtnFormMinimize.Font = New Font("Segoe Fluent Icons", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        BtnFormMinimize.ForeColor = Color.Gainsboro
        BtnFormMinimize.ImageAlign = ContentAlignment.MiddleLeft
        BtnFormMinimize.Location = New Point(1301, 0)
        BtnFormMinimize.Margin = New Padding(2, 3, 2, 3)
        BtnFormMinimize.Name = "BtnFormMinimize"
        BtnFormMinimize.Size = New Size(46, 28)
        BtnFormMinimize.TabIndex = 8
        BtnFormMinimize.Text = ""
        BtnFormMinimize.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnFormMinimize.UseVisualStyleBackColor = True
        ' 
        ' BtnFormRestore
        ' 
        BtnFormRestore.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnFormRestore.FlatAppearance.BorderSize = 0
        BtnFormRestore.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnFormRestore.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        BtnFormRestore.FlatStyle = FlatStyle.Flat
        BtnFormRestore.Font = New Font("Segoe Fluent Icons", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        BtnFormRestore.ForeColor = Color.Gainsboro
        BtnFormRestore.ImageAlign = ContentAlignment.MiddleLeft
        BtnFormRestore.Location = New Point(1347, 0)
        BtnFormRestore.Margin = New Padding(2, 3, 2, 3)
        BtnFormRestore.Name = "BtnFormRestore"
        BtnFormRestore.Size = New Size(46, 28)
        BtnFormRestore.TabIndex = 3
        BtnFormRestore.Text = ""
        BtnFormRestore.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnFormRestore.UseVisualStyleBackColor = True
        ' 
        ' BtnFormMaximize
        ' 
        BtnFormMaximize.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnFormMaximize.FlatAppearance.BorderSize = 0
        BtnFormMaximize.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(33), CByte(50), CByte(70))
        BtnFormMaximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(12), CByte(61), CByte(92))
        BtnFormMaximize.FlatStyle = FlatStyle.Flat
        BtnFormMaximize.Font = New Font("Segoe Fluent Icons", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        BtnFormMaximize.ForeColor = Color.Gainsboro
        BtnFormMaximize.ImageAlign = ContentAlignment.MiddleLeft
        BtnFormMaximize.Location = New Point(1345, 0)
        BtnFormMaximize.Margin = New Padding(2, 3, 2, 3)
        BtnFormMaximize.Name = "BtnFormMaximize"
        BtnFormMaximize.Size = New Size(46, 28)
        BtnFormMaximize.TabIndex = 7
        BtnFormMaximize.Text = ""
        BtnFormMaximize.TextImageRelation = TextImageRelation.ImageBeforeText
        BtnFormMaximize.UseVisualStyleBackColor = True
        ' 
        ' TimerReload
        ' 
        TimerReload.Enabled = True
        TimerReload.Interval = 1000
        ' 
        ' TimerPaintCorner
        ' 
        TimerPaintCorner.Enabled = True
        ' 
        ' FormMain
        ' 
        AutoScaleDimensions = New SizeF(96F, 96F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(1440, 900)
        Controls.Add(PanelContenedor)
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(2, 3, 2, 3)
        MinimumSize = New Size(440, 400)
        Name = "FormMain"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "Herramienta de informes"
        WindowState = FormWindowState.Maximized
        PanelContenedor.ResumeLayout(False)
        PanelForms.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        PanelMenu.ResumeLayout(False)
        PanelBarraTitulo.ResumeLayout(False)
        PanelBarraTitulo.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelContenedor As Panel
    Friend WithEvents PanelBarraTitulo As Panel
    Friend WithEvents PanelFormularios As Panel
    Friend WithEvents PanelMenu As Panel
    Friend WithEvents ButtonConfig As Button
    Friend WithEvents ButtonMotors As Button
    Friend WithEvents ButtonAnalog As Button
    Friend WithEvents BtnInformeAnalogicas As Button
    Friend WithEvents LOGO As PictureBox
    Friend WithEvents BtnFormRestore As Button
    Friend WithEvents BtnFormClose As Button
    Friend WithEvents BtnFormMinimize As Button
    Friend WithEvents BtnFormMaximize As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ButtonAnalogMark As Button
    Friend WithEvents ButtonConfigMark As Button
    Friend WithEvents ButtonMotorsMark As Button
    Friend WithEvents BtnPruebaInformeMark As Button
    Friend WithEvents BtnInformeDigitales As Button
    Friend WithEvents BtnInformeDigitalMark As Button
    Friend WithEvents PanelForms As Panel
    Friend WithEvents ButtonImportTIAPORTAL As Button
    Friend WithEvents ButtonImportTIAPORTALMark As Button
    Friend WithEvents TimerReload As Timer
    Friend WithEvents LblVersion As Label
    Friend WithEvents TimerPaintCorner As Timer
End Class

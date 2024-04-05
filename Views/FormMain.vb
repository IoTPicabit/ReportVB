Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports DevExpress.CodeParser
Imports DevExpress.DataAccess

Public Class FormMain
    ' Lista para almacenar el estado original de los controles
    Public listOriginalEnabledStates As New List(Of KeyValuePair(Of String, Boolean))

#Region "FUNCIONALIDADES DEL FORMULARIO"
    'RESIZE DEL FORMULARIO- CAMBIAR TAMAÑO
    Dim cGrip As Integer = 10

    Protected Overrides Sub WndProc(ByRef m As Message)
        If (m.Msg = 132) Then
            Dim pos As Point = New Point((m.LParam.ToInt32 And 65535), (m.LParam.ToInt32 + 16))
            pos = Me.PointToClient(pos)
            If ((pos.X _
                        >= (Me.ClientSize.Width - cGrip)) _
                        AndAlso (pos.Y _
                        >= (Me.ClientSize.Height - cGrip))) Then
                m.Result = CType(17, IntPtr)
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub
    '----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
    Dim sizeGripRectangle As Rectangle
    Dim tolerance As Integer = 15

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        Dim region = New Region(New Rectangle(0, 0, Me.ClientRectangle.Width, Me.ClientRectangle.Height))
        sizeGripRectangle = New Rectangle((Me.ClientRectangle.Width - tolerance), (Me.ClientRectangle.Height - tolerance), tolerance, tolerance)
        region.Exclude(sizeGripRectangle)
        Me.PanelContenedor.Region = region
        Me.Invalidate()
    End Sub

    Private colorBackgroundCurrent As Color = Color.FromArgb(240, 240, 240)
    'colorBackgroundCurrent = Color.FromArgb(240, 240, 240) '> Control
    'colorBackgroundCurrent = Color.FromArgb(4, 41, 68) '> Azul
    'colorBackgroundCurrent = Color.FromArgb(0, 132, 201) '> Celeste
    'colorBackgroundCurrent = Color.FromArgb(127, 127, 127) '> Gris


    '----------------COLOR Y GRIP DE RECTANGULO INFERIOR
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        'Dim blueBrush As SolidBrush = New SolidBrush(Color.FromArgb(244, 244, 244))
        'Dim blueBrush As SolidBrush = New SolidBrush(Color.FromArgb(4, 41, 68))
        Dim blueBrush As SolidBrush = New SolidBrush(colorBackgroundCurrent)
        e.Graphics.FillRectangle(blueBrush, sizeGripRectangle)
        MyBase.OnPaint(e)
        'ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle)
        'ControlPaint.DrawSizeGrip(e.Graphics, Color.White, sizeGripRectangle)
        ControlPaint.DrawSizeGrip(e.Graphics, Color.FromArgb(127, 127, 127), sizeGripRectangle)
    End Sub
    'ARRASTRAR EL FORMULARIO
    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

    Private Sub PanelBarraTitulo_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelBarraTitulo.MouseMove
        ReleaseCapture()
        SendMessage(Me.Handle, &H112&, &HF012&, 0)
    End Sub


    Dim lx, ly As Integer
    Dim sw, sh As Integer



#End Region

    'METODO DE ABRIR FORMULARIO
    Public Sub AbrirFormEnPanel(Of Miform As {Form, New})(Optional param As Integer = Nothing)
        Dim Formulario As Form
        Formulario = PanelForms.Controls.OfType(Of Miform)().FirstOrDefault() 'Busca el formulario en la coleccion
        'Si form no fue econtrado/ no existe
        If Formulario Is Nothing Then
            If GetType(Miform).Equals(GetType(FormReportConfiguration)) Then
                Dim frm As New FormReportConfiguration(param)
                Formulario = frm
            Else
                Formulario = New Miform()
            End If
            Formulario.TopLevel = False
            Formulario.FormBorderStyle = FormBorderStyle.None
            Formulario.Dock = DockStyle.Fill
            PanelForms.Controls.Add(Formulario)
            PanelForms.Tag = Formulario
            AddHandler Formulario.FormClosed, AddressOf Me.CloseForm

            Formulario.Show()
            Formulario.BringToFront()
        Else
            If GetType(Miform).Equals(GetType(FormReportConfiguration)) Then
                Dim forms() As FormReportConfiguration = PanelForms.Controls.OfType(Of FormReportConfiguration)().ToArray
                Dim found As Boolean = False
                For Each frm As FormReportConfiguration In forms
                    If frm.formTypeParameter = param Then
                        Formulario = frm
                        Formulario.BringToFront()
                        found = True
                        Exit For
                    End If
                Next
                If Not found Then
                    Dim frm As New FormReportConfiguration(param)
                    Formulario = frm
                    Formulario.TopLevel = False
                    Formulario.FormBorderStyle = FormBorderStyle.None
                    Formulario.Dock = DockStyle.Fill
                    PanelForms.Controls.Add(Formulario)
                    PanelForms.Tag = Formulario
                    AddHandler Formulario.FormClosed, AddressOf Me.CloseForm
                    Formulario.Show()
                    Formulario.BringToFront()
                End If
            Else

                Formulario.BringToFront()
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonAnalog.Click
        AbrirFormEnPanel(Of Form1)()
        'ButtonAnalog.BackColor = Color.FromArgb(12, 61, 92)
        ButtonAnalogMark.Visible = True
        ButtonImportTIAPORTALMark.Visible = False
        ButtonConfigMark.Visible = False
        BtnPruebaInformeMark.Visible = False
        BtnInformeDigitalMark.Visible = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonMotors.Click, ButtonImportTIAPORTAL.Click
        colorBackgroundCurrent = Color.FromArgb(4, 41, 68)
        Me.Invalidate()

        AbrirFormEnPanel(Of frmUtilTagsImport)()
        ButtonAnalogMark.Visible = False
        ButtonImportTIAPORTALMark.Visible = True
        ButtonConfigMark.Visible = False
        BtnPruebaInformeMark.Visible = False
        BtnInformeDigitalMark.Visible = False
        Me.Update()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonConfig.Click
        colorBackgroundCurrent = Color.FromArgb(4, 41, 68)
        Me.Invalidate()

        AbrirFormEnPanel(Of FormCustomerConfig)()
        ButtonAnalogMark.Visible = False
        ButtonImportTIAPORTALMark.Visible = False
        ButtonConfigMark.Visible = True
        BtnPruebaInformeMark.Visible = False
        BtnInformeDigitalMark.Visible = False
        Me.Update()

    End Sub

    Private Sub BtnPruebaInforme_Click(sender As Object, e As EventArgs) Handles BtnInformeAnalogicas.Click
        colorBackgroundCurrent = Color.FromArgb(0, 132, 201)
        Me.Invalidate()

        If Check("Signals") Then
            AbrirFormEnPanel(Of FormReportConfiguration)(0)
            ButtonAnalogMark.Visible = False
            ButtonImportTIAPORTALMark.Visible = False
            ButtonConfigMark.Visible = False
            BtnPruebaInformeMark.Visible = True
            BtnInformeDigitalMark.Visible = False
            ButtonConfigMark.Visible = False
            ButtonImportTIAPORTALMark.Visible = False
        Else
        End If
        Me.Update()
    End Sub


    Private Sub BtnInformeDigitales_Click(sender As Object, e As EventArgs) Handles BtnInformeDigitales.Click
        colorBackgroundCurrent = Color.FromArgb(0, 132, 201)
        Me.Invalidate()

        If Check("Equipment") Then
            AbrirFormEnPanel(Of FormReportConfiguration)(1)
            ButtonAnalogMark.Visible = False
            ButtonImportTIAPORTALMark.Visible = False
            ButtonConfigMark.Visible = False
            BtnPruebaInformeMark.Visible = False
            BtnInformeDigitalMark.Visible = True
            ButtonConfigMark.Visible = False
            ButtonImportTIAPORTALMark.Visible = False
        Else
        End If
        Me.Update()
    End Sub


    'METODO/EVENTO AL CERRAR FORMS
    Private Sub CloseForm(ByVal sender As Object, ByVal e As FormClosedEventArgs)
        'CONDICION SI FORMS ESTA ABIERTO
        Dim frontCtl As New Form
        Dim closedCtl As New Form
        Dim ix As Integer = 99
        Dim ix2 As Integer = 99
        Dim chIx As Integer

        For Each ctl As Control In PanelForms.Controls
            chIx = PanelForms.Controls.GetChildIndex(ctl)
            If chIx = 1 And TypeOf ctl Is Form Then
                frontCtl = ctl
            End If
        Next

        Dim frm As Form = frontCtl
        If Not IsNothing(frm) AndAlso frm.Name = "FormReportConfiguration" Then
            Dim frm2 As FormReportConfiguration = frm
            BtnInformeDigitalMark.Visible = frm2.formTypeParameter = 1
            BtnPruebaInformeMark.Visible = frm2.formTypeParameter = 0
        Else
            BtnInformeDigitalMark.Visible = False
            BtnPruebaInformeMark.Visible = False
        End If
        ButtonImportTIAPORTALMark.Visible = Not IsNothing(frm) AndAlso frm.Name = "frmUtilTagsImport"
        ButtonConfigMark.Visible = Not IsNothing(frm) AndAlso frm.Name = "FormCustomerConfig"
    End Sub

    Private Sub PanelBarraTitulo_DoubleClick(sender As Object, e As EventArgs) Handles PanelBarraTitulo.DoubleClick
        If My.Settings.A_FormState Then
            FormRestore()
        Else
            FormMaximize()
        End If
    End Sub

    Sub FormMaximize()
        lx = Me.Location.X
        ly = Me.Location.Y
        sw = Me.Size.Width
        sh = Me.Size.Height

        BtnFormMaximize.Visible = False
        BtnFormRestore.Visible = True

        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        My.Settings.A_FormState = True
        My.Settings.Save()

    End Sub

    Sub FormRestore()

        Me.Size = New Size(sw, sh)
        Me.Location = New Point(lx, ly)
        BtnFormMaximize.Visible = True
        BtnFormRestore.Visible = False

        My.Settings.A_FormState = False
        My.Settings.Save()
    End Sub

    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim config As ConfigIni = New ConfigIni()
        config.ReadIni()
        LblVersion.Text = Datos.Version
        getDPI()
        ScaleForm(Me)
        ButtonAnalogMark.Visible = False
        ButtonImportTIAPORTALMark.Visible = False
        ButtonConfigMark.Visible = False
        BtnPruebaInformeMark.Visible = False
        BtnInformeDigitalMark.Visible = False

        If sw = 0 Or sh = 0 Then
            sw = Me.Width
            sh = Me.Height
        End If
        'Dim b = DirectCast(BtnFormClose, Button)
        'b.FlatAppearance.MouseOverBackColor = Color.FromArgb(196, 43, 28)
        If My.Settings.A_FormState Then
            FormMaximize()
        Else
            FormRestore()
        End If

        FontsInstallation.InstallFonts()

        InitFormParameters() 'Para cargar el diccionario del formulario de configuración de informe

        'If InitSQL() Then
        '    BtnInformeAnalogicas.Enabled = True
        '    BtnInformeDigitales.Enabled = True
        '    ButtonAnalog.Enabled = True
        '    ButtonImportTIAPORTAL.Enabled = True
        'Else
        '    BtnInformeAnalogicas.Enabled = False
        '    BtnInformeDigitales.Enabled = False
        '    ButtonAnalog.Enabled = False
        '    ButtonImportTIAPORTAL.Enabled = False
        '    MessageBox.Show("La conexión SQL no es correcta," & vbCrLf & vbCrLf & "o no cuenta con las tablas necesarias." & vbCrLf & vbCrLf & "¡Pulse 'Configuración' para corregir el problema.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End If

    End Sub

    Sub getDPI()
        Dim g As Graphics = Me.CreateGraphics()
        fScale = 96 / g.DpiX
        'fScale = 0.5
    End Sub

    Private Sub BtnFormRestore_Click(sender As Object, e As EventArgs) Handles BtnFormRestore.Click
        FormRestore()
    End Sub

    Private Sub BtnFormClose_Click(sender As Object, e As EventArgs) Handles BtnFormClose.Click
        Application.Exit()
    End Sub

    Private Sub BtnFormMinimize_Click(sender As Object, e As EventArgs) Handles BtnFormMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtnFormMaximize_Click(sender As Object, e As EventArgs) Handles BtnFormMaximize.Click
        FormMaximize()
    End Sub

    Private Sub TimerReload_Tick(sender As Object, e As EventArgs) Handles TimerReload.Tick
        If Datos.FormCustomerConfigReload Then
            Datos.FormCustomerConfigReload = False

            colorBackgroundCurrent = Color.FromArgb(4, 41, 68)
            Me.Invalidate()

            AbrirFormEnPanel(Of FormCustomerConfig)()
            ButtonAnalogMark.Visible = False
            ButtonImportTIAPORTALMark.Visible = False
            ButtonConfigMark.Visible = True
            BtnPruebaInformeMark.Visible = False
            BtnInformeDigitalMark.Visible = False
            Me.Update()
        End If
        If Datos.frmUtilTagsImport Then
            Datos.frmUtilTagsImport = False
            ButtonImportTIAPORTAL.Visible = True

            colorBackgroundCurrent = Color.FromArgb(4, 41, 68)
            Me.Invalidate()

            AbrirFormEnPanel(Of frmUtilTagsImport)()
            ButtonAnalogMark.Visible = False
            ButtonImportTIAPORTALMark.Visible = True
            ButtonConfigMark.Visible = False
            BtnPruebaInformeMark.Visible = False
            BtnInformeDigitalMark.Visible = False
            Me.Update()
        End If

        If InitSQL() Then
            BtnInformeAnalogicas.Enabled = True
            BtnInformeDigitales.Enabled = True
            ButtonAnalog.Enabled = True
            ButtonImportTIAPORTAL.Enabled = True
        Else
            BtnInformeAnalogicas.Enabled = False
            BtnInformeDigitales.Enabled = False
            ButtonAnalog.Enabled = False
            ButtonImportTIAPORTAL.Enabled = False
        End If
    End Sub

    Private Function InitSQL() As Boolean
        Dim Ok As Boolean = False
        Dim _OkConnect As Boolean = False

        Dim Tables As DataTable = Nothing
        Dim Chain As String = Datos.SQLConnectionStringData
        Dim _tempOkTables = False

        Try
            _OkConnect = OpenSQL(Chain, Tables)
            If _OkConnect = True Then
                _tempOkTables = CheckTables(Tables)
                If _tempOkTables = True Then
                    Ok = True
                Else
                    Ok = False
                End If
            Else
                Ok = False
            End If
        Catch
            Ok = False
        End Try
        Return Ok
    End Function

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
                ' La conexión fue exitosa si no se lanzó ninguna excepción
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

    Private Function Check(_formType As String) As Boolean
        Dim Ok As Boolean = False
        Dim SqlForIndex = ""
        'Digital
        If _formType = "Equipment" Then
            SqlForIndex = "SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.DigNmanTAutTagTable A
                        Left JOIN DigTfunTAutTagTable T
                        ON (REPLACE(A.TagName, 'ODValStartT', 'ODValHourT')) = T.TagName
						Left JOIN DigNmanTAutReportTable D
                        ON D.TagName = A.TagName
                        Order by A.TagIndex"
        End If
        'Analog
        If _formType = "Signals" Then
            SqlForIndex = "SELECT A.TagIndex, A.TagName, D.TagDescription, T.TagIndex as TagIndexOut , T.TagName as TagNameOUT, A.TagType, A.TagDataType 
                        FROM dbo.AnaVinsTagTable A
                        Left JOIN AnaVtotTagTable T
                        ON (REPLACE(A.TagName, 'OFValEU', 'OFValTotSumCal')) = T.TagName
						Left JOIN AnaVinsReportTable D
                        ON D.TagName = A.TagName
                        Order by A.TagIndex"
        End If
        Dim dtIn As DataTable = New DataTable()
        Try
            Dim db As dbCon = New dbCon(Datos.SQLConnectionStringData)
            db.SelectDataTable(SqlForIndex, dtIn)

            If dtIn IsNot Nothing AndAlso dtIn.Rows.Count = 0 Then
                'Digital
                If _formType = "Equipment" Then
                    MessageBox.Show("Error no existen Tag Digitales")
                End If
                'Analog
                If _formType = "Signals" Then
                    MessageBox.Show("Error no existen Tag Analogicos")
                End If
                Return Ok
            Else
                Ok = True
                Return Ok
            End If
        Catch ex As Exception
        End Try
        Return Ok
    End Function

    Private Sub TimerPaintCorner_Tick(sender As Object, e As EventArgs) Handles TimerPaintCorner.Tick
        If Datos.frmclose Then
            Datos.frmclose = False

            If BtnPruebaInformeMark.Visible Then
                colorBackgroundCurrent = Color.FromArgb(0, 132, 201) '> Celeste
                Me.Invalidate()
            ElseIf BtnInformeDigitalMark.Visible Then
                colorBackgroundCurrent = Color.FromArgb(0, 132, 201) '> Celeste
                Me.Invalidate()
            ElseIf ButtonImportTIAPORTALMark.Visible Then
                colorBackgroundCurrent = Color.FromArgb(4, 41, 68) '> Azul
                Me.Invalidate()
            ElseIf ButtonConfigMark.Visible Then
                colorBackgroundCurrent = Color.FromArgb(4, 41, 68) '> Azul
                Me.Invalidate()
            Else
                colorBackgroundCurrent = Color.FromArgb(240, 240, 240) '> Control
                Me.Invalidate()
            End If
            Me.Update()


        End If

    End Sub
End Class

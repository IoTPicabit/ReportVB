Imports System.Diagnostics.Contracts
Imports System.Drawing.Imaging
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class RadioButtonCC
#Region "Declarations"
    Private _Checked As Boolean = False
    Private _labelText As String = ""
    Private _label As New System.Windows.Forms.Label
    Private _foreColorText As New System.Drawing.Color
    Private ReadOnly _Inmutable_Size As Size = New Size(18, 18)
    Private _Enabled As Boolean = True
#End Region
#Region "Init"
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        _foreColorText = System.Drawing.Color.White
        _label.Visible = False
        _label.Location = New Point(21, 0)
        _label.Size = New Size(200, Me.Width)
        _label.Margin = New Padding(0, 0, 0, 0)
        _label.Font = New System.Drawing.Font("Segoe UI Variable Small", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        _label.AutoSize = True
        _label.ForeColor = _foreColorText
        _label.BackColor = System.Drawing.Color.Transparent
        _label.Visible = True
        AddHandler _label.Click, AddressOf _Label_Click
        Me.Controls.Add(_label)
        If LabelText.Length > 0 Then
            Me.Width = 21 + _label.Width
            Me.Width = Me.Width
        Else
            Me.Width = 18
        End If
    End Sub
#End Region
#Region "Properties"

    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            Dim imgAux As Image
            _Checked = value
            imgAux = IIf(_Checked = True, My.Resources.AuxRadioButtonCC._select, My.Resources.AuxRadioButtonCC._deselect)
            If Enabled = True Then
                _radioButtonPic.Image = imgAux
                _foreColorText = System.Drawing.Color.White
            Else
                _radioButtonPic.Image = DarkenImage(imgAux, 0.6F)
                _foreColorText = System.Drawing.Color.SlateGray
            End If
            _label.ForeColor = _foreColorText
            If _Checked Then UnCheckOthers()
            RaiseEvent CheckedChange()
        End Set
    End Property

    Public Property LabelText As String 'Texto que se mostrará
        Get
            Return _labelText
        End Get
        Set(ByVal value As String)
            _labelText = value
            _label.Text = _labelText
            If _labelText.Length > 0 Then
                Me.Width = 21 + _label.Width
                Me.Width = Me.Width
            Else
                Me.Width = 18
            End If
            Refresh()
        End Set
    End Property
    Public Shadows Property Size As Size
        Get
            Return MyBase.Size
        End Get
        Set(value As Size)
            If value.Width < _Inmutable_Size.Width Then value.Width = _Inmutable_Size.Width
            value.Height = _Inmutable_Size.Height + IIf(Dock <> DockStyle.None, Padding.Top + Padding.Bottom, 0)
            MyBase.Size = value
        End Set
    End Property
    Public Overloads Property Enabled() As Boolean
        Get
            Return _Enabled
        End Get
        Set(ByVal value As Boolean)
            _radioButtonPic.Enabled = True
            _label.Enabled = True
            _Enabled = value
            Dim imgAux As Image
            imgAux = IIf(_Checked = True, My.Resources.AuxRadioButtonCC._select, My.Resources.AuxRadioButtonCC._deselect)
            If _Enabled = True Then
                _radioButtonPic.Image = imgAux
                _foreColorText = System.Drawing.Color.White
            Else
                _radioButtonPic.Image = DarkenImage(imgAux, 0.6F)
                _foreColorText = System.Drawing.Color.SlateGray
            End If
            _label.ForeColor = _foreColorText
        End Set
    End Property

#End Region

#Region "Functions"


    Private Sub UnCheckOthers()
        'Se utiliza para deseleccionar el resto de radio buttons en el mismo panel

        Dim parentControl As System.Windows.Forms.Control = Me.Parent

        ' Buscar el panel padre o llegar al formulario principal
        If TypeOf parentControl Is Panel Then

            ' Verificar si se encontró un Panel
            If TypeOf parentControl Is Panel Then
                ' Recorrer los controles dentro del panel y deseleccionar los RadioButtonCC
                For Each control As System.Windows.Forms.Control In parentControl.Controls
                    If TypeOf control Is RadioButtonCC AndAlso control IsNot Me Then
                        DirectCast(control, RadioButtonCC).Checked = False
                    End If
                Next
            End If
        End If
    End Sub

    Private Function DarkenImage(originalImage As Image, darkenFactor As Single) As Image
        ' Crear una imagen en blanco del mismo tamaño
        Dim imagenOscurecida As New Bitmap(originalImage.Width, originalImage.Height)
        ' Crear un objeto Graphics para trabajar con la imagen en blanco
        Using g As Graphics = Graphics.FromImage(imagenOscurecida)
            ' Crear una matriz de color para aplicar el oscurecimiento
            Dim matrizColor As New ColorMatrix(New Single()() _
                        {New Single() {darkenFactor, 0, 0, 0, 0},
                         New Single() {0, darkenFactor, 0, 0, 0},
                         New Single() {0, 0, darkenFactor, 0, 0},
                         New Single() {0, 0, 0, 1, 0},
                         New Single() {0, 0, 0, 0, 1}})

            ' Crear un objeto ImageAttributes y establecer la matriz de color
            Dim atributos As New ImageAttributes()
            atributos.SetColorMatrix(matrizColor)
            ' Dibujar la imagen original en la imagen en blanco con el oscurecimiento aplicado
            g.DrawImage(originalImage, New Rectangle(0, 0, originalImage.Width, originalImage.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, atributos)
        End Using
        ' Devolver la imagen oscurecida
        Return imagenOscurecida
    End Function
#End Region


#Region "Events"
    Private Sub _RadioButtonPic_Click(sender As Object, e As EventArgs) Handles _radioButtonPic.Click
        If Enabled Then
            Checked = True
            Me.OnClick(e)
        End If
    End Sub
    Private Sub me_Click(sender As Object, e As EventArgs) Handles Me.Click
        If Enabled Then Checked = True

    End Sub
    Private Sub _Label_Click(sender As Object, e As EventArgs)
        If Enabled Then
            Checked = True
            Me.OnClick(e)
        End If
    End Sub
    Private Sub RadioButtonCC_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        Checked = _Checked
        _radioButtonPic.Enabled = True
    End Sub

    Private Sub RadioButtonCC_PaddingChanged(sender As Object, e As EventArgs) Handles Me.PaddingChanged
        Me.Height = _Inmutable_Size.Height
    End Sub

    Event CheckedChange()
#End Region

End Class

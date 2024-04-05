Imports System.Diagnostics.Contracts
Imports System.Drawing.Imaging
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class CheckBoxCC
#Region "Declarations"
    Private _Checked As Boolean
    Private ReadOnly _Inmutable_Size As Size = New Size(18, 18)
    Private _labelText As String = ""
    Private _label As New System.Windows.Forms.Label
    Private _foreColorText As New System.Drawing.Color
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
            imgAux = IIf(_Checked = True, My.Resources.AuxCheckBox.yes, My.Resources.AuxCheckBox.no)
            If Enabled = True Then
                _CheckBoxPic.Image = imgAux
                _foreColorText = System.Drawing.Color.White
            Else
                _CheckBoxPic.Image = DarkenImage(imgAux, 0.6F)
                _foreColorText = System.Drawing.Color.SlateGray
            End If
            _label.ForeColor = _foreColorText
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
            value.Height = _Inmutable_Size.Height
            MyBase.Size = value
        End Set
    End Property
    Public Overloads Property Enabled() As Boolean
        Get
            Return _Enabled
        End Get
        Set(ByVal value As Boolean)
            _CheckBoxPic.Enabled = True
            _label.Enabled = True
            _Enabled = value
            Checked = _Checked
        End Set
    End Property
#End Region
#Region "Functions"
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
    'Protected Overrides Sub OnSizeChanged(e As System.EventArgs)
    '    MyBase.Size = _Inmutable_Size
    '    MyBase.OnSizeChanged(e)
    'End Sub

    Private Sub CheckBoxPic_Click(sender As Object, e As EventArgs) Handles _CheckBoxPic.Click
        If Enabled Then
            Checked = Not Checked
            Me.OnClick(e)
        End If
    End Sub
    Private Sub _Label_Click(sender As Object, e As EventArgs)
        If Enabled Then
            Checked = Not Checked
            Me.OnClick(e)
        End If
    End Sub

    Event CheckedChange()
#End Region

End Class

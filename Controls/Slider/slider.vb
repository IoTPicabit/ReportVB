Imports System.Diagnostics.Contracts
Imports DocumentFormat.OpenXml.Bibliography

Public Class slider
    Private _Value As Direction
    Enum Direction
        Left = 0
        Right = 1
    End Enum

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Public Property Value As Direction
        Get
            Return _Value
        End Get
        Set(ByVal value As Direction)
            Contract.Requires(value >= 0 And value <= 1)
            _Value = value
            SliderPic.Image = IIf(_Value = Direction.Right, My.Resources.AuxSlider.slider_R, My.Resources.AuxSlider.slider_L)
        End Set
    End Property
    Public ReadOnly Property ValueBool As Boolean
        Get
            Return IIf(_Value = Direction.Right, True, False)
        End Get
    End Property

    Private ReadOnly INMUTABLE_SIZE As Size = New Size(30, 16)

    Public Shadows Property Size As Size
        Get
            Return INMUTABLE_SIZE
        End Get
        Set(value As Size)
            MyBase.Size = INMUTABLE_SIZE
        End Set
    End Property

    Protected Overrides Sub OnSizeChanged(e As System.EventArgs)
        MyBase.Size = INMUTABLE_SIZE
        MyBase.OnSizeChanged(e)
    End Sub


    Private Sub SliderPic_Click(sender As Object, e As EventArgs) Handles SliderPic.Click
        Value = IIf(Value = Direction.Right, Direction.Left, Direction.Right)
    End Sub
End Class

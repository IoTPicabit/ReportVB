<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class slider
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        SliderPic = New PictureBox()
        CType(SliderPic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SliderPic
        ' 
        SliderPic.Image = My.Resources.AuxSlider.slider_L
        SliderPic.Location = New Point(0, 0)
        SliderPic.Margin = New Padding(0)
        SliderPic.Name = "SliderPic"
        SliderPic.Size = New Size(30, 16)
        SliderPic.TabIndex = 0
        SliderPic.TabStop = False
        ' 
        ' slider
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(SliderPic)
        MaximumSize = New Size(30, 16)
        MinimumSize = New Size(30, 16)
        Name = "slider"
        Size = New Size(30, 16)
        CType(SliderPic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SliderPic As PictureBox

End Class

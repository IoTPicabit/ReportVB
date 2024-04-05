<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RadioButtonCC
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
        _radioButtonPic = New PictureBox()
        CType(_radioButtonPic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' RadioButtonPic
        ' 
        _radioButtonPic.Dock = DockStyle.Left
        _radioButtonPic.Image = My.Resources.AuxRadioButtonCC._select
        _radioButtonPic.Location = New Point(0, 0)
        _radioButtonPic.Margin = New Padding(0)
        _radioButtonPic.MaximumSize = New Size(18, 18)
        _radioButtonPic.MinimumSize = New Size(18, 18)
        _radioButtonPic.Name = "RadioButtonPic"
        _radioButtonPic.Size = New Size(18, 18)
        _radioButtonPic.TabIndex = 1
        _radioButtonPic.TabStop = False
        ' 
        ' RadioButtonCC
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Transparent
        Controls.Add(_radioButtonPic)
        MaximumSize = New Size(300, 18)
        MinimumSize = New Size(18, 18)
        Name = "RadioButtonCC"
        Size = New Size(18, 18)
        CType(_radioButtonPic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents _radioButtonPic As PictureBox

End Class

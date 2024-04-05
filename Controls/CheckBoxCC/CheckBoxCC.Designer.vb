<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckBoxCC
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
        _CheckBoxPic = New PictureBox()
        CType(_CheckBoxPic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' CheckBoxPic
        ' 
        _CheckBoxPic.Image = My.Resources.AuxCheckBox.yes
        _CheckBoxPic.Location = New Point(0, 0)
        _CheckBoxPic.Margin = New Padding(0)
        _CheckBoxPic.MaximumSize = New Size(18, 18)
        _CheckBoxPic.MinimumSize = New Size(18, 18)
        _CheckBoxPic.Name = "CheckBoxPic"
        _CheckBoxPic.Size = New Size(18, 18)
        _CheckBoxPic.TabIndex = 0
        _CheckBoxPic.TabStop = False
        ' 
        ' CheckBoxCC
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(_CheckBoxPic)
        MaximumSize = New Size(18, 18)
        MinimumSize = New Size(18, 18)
        Name = "CheckBoxCC"
        Size = New Size(18, 18)
        CType(_CheckBoxPic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents _CheckBoxPic As PictureBox

End Class

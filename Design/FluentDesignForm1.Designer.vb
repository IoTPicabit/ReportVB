<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FluentDesignForm1
    Inherits DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        FluentDesignFormContainer1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
        AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        FluentDesignFormControl1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl()
        FluentFormDefaultManager1 = New DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components)
        CType(AccordionControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(FluentDesignFormControl1, ComponentModel.ISupportInitialize).BeginInit()
        CType(FluentFormDefaultManager1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' FluentDesignFormContainer1
        ' 
        FluentDesignFormContainer1.Dock = DockStyle.Fill
        FluentDesignFormContainer1.Location = New Point(202, 39)
        FluentDesignFormContainer1.Margin = New Padding(2, 3, 2, 3)
        FluentDesignFormContainer1.Name = "FluentDesignFormContainer1"
        FluentDesignFormContainer1.Size = New Size(534, 466)
        FluentDesignFormContainer1.TabIndex = 0
        ' 
        ' AccordionControl1
        ' 
        AccordionControl1.Dock = DockStyle.Left
        AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {AccordionControlElement1})
        AccordionControl1.Location = New Point(0, 39)
        AccordionControl1.Margin = New Padding(2, 3, 2, 3)
        AccordionControl1.Name = "AccordionControl1"
        AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        AccordionControl1.Size = New Size(202, 466)
        AccordionControl1.TabIndex = 1
        AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        ' 
        ' AccordionControlElement1
        ' 
        AccordionControlElement1.Name = "AccordionControlElement1"
        AccordionControlElement1.Text = "Element1"
        ' 
        ' FluentDesignFormControl1
        ' 
        FluentDesignFormControl1.FluentDesignForm = Me
        FluentDesignFormControl1.Location = New Point(0, 0)
        FluentDesignFormControl1.Manager = FluentFormDefaultManager1
        FluentDesignFormControl1.Margin = New Padding(2, 3, 2, 3)
        FluentDesignFormControl1.Name = "FluentDesignFormControl1"
        FluentDesignFormControl1.Size = New Size(736, 39)
        FluentDesignFormControl1.TabIndex = 2
        FluentDesignFormControl1.TabStop = False
        ' 
        ' FluentFormDefaultManager1
        ' 
        FluentFormDefaultManager1.Form = Me
        ' 
        ' FluentDesignForm1
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(736, 505)
        ControlContainer = FluentDesignFormContainer1
        Controls.Add(FluentDesignFormContainer1)
        Controls.Add(AccordionControl1)
        Controls.Add(FluentDesignFormControl1)
        FluentDesignFormControl = FluentDesignFormControl1
        Margin = New Padding(2, 3, 2, 3)
        Name = "FluentDesignForm1"
        NavigationControl = AccordionControl1
        Text = "FluentDesignForm1"
        CType(AccordionControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(FluentDesignFormControl1, ComponentModel.ISupportInitialize).EndInit()
        CType(FluentFormDefaultManager1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents FluentDesignFormContainer1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents FluentDesignFormControl1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl
    Friend WithEvents FluentFormDefaultManager1 As DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager
End Class

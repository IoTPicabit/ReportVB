Public Class Form1
    Public Sub New()
        InitializeComponent()
        FrmLoad()
    End Sub
    Public Sub New(stepForm As Integer)
        InitializeComponent()
        FrmLoad()
    End Sub
    Sub FrmLoad()
        Me.ReportViewer1.Refresh()
    End Sub
End Class

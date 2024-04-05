Imports System
Imports System.Windows.Forms

Module Program
        ''' <summary>
        ''' Punto de entrada principal para la aplicación.
        ''' </summary>
        <STAThread>
        Sub Main()
            Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Dim config As ConfigIni = New ConfigIni()
        config.ReadIni()
        config.ReadConfigs()
        Application.Run(New FormMain())
    End Sub

End Module







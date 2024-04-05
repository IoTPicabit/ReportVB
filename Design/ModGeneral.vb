Module ModGeneral
    Public fScale As Double


    Sub ScaleForm(frm As Control)
        For Each ctl As Control In frm.Controls
            Try
                ForceScale(ctl)
                ScaleForm(ctl)
            Catch ex As Exception

            End Try
        Next
    End Sub
    Public Sub ForceScale(ctl As Control)
        ctl.Font = New Font(ctl.Font.Name, ctl.Font.Size * fScale, FontStyle.Regular, GraphicsUnit.Point, (CByte((0))))
    End Sub

End Module

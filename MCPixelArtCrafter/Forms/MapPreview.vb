Public Class MapPreview
    Public Property MapResult As MapResult

    Private Sub MapPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PB.SetImage(MapResult.OutImage)
        FLP_UsedColors.Controls.Clear()
        For Each ColorCount In MapResult.UsedMapColors
            Dim cc = New MapColorCount(ColorCount)
            cc.SetToolTip(TT_Color)
            FLP_UsedColors.Controls.Add(cc)
            'TT_Color.SetToolTip(cc, cc.Blocks)

        Next
    End Sub
End Class
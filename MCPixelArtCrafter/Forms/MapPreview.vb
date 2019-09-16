Public Class MapPreview
    Public Property MapResult As MapResult

    Private Sub MapPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PB.SetImage(MapResult.OutImage)
        FLP_UsedColors.Controls.Clear()
        For Each mapcolor In MapResult.UsedMapColors
            'FLP_UsedColors.Controls.Add(New MapColorCount(mapcolor))
        Next


        TT_Color.Show("trtr", Me)
    End Sub
End Class
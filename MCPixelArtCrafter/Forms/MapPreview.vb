Public Class MapPreview
    Public Property MapResult As MapResult

    Private Sub MapPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PB.SetImage(MapResult.OutImage)
        With FlowLayoutPanel1.Controls
            .Add(New CheckBlock)
            .Add(New CheckBlock)
            .Add(New CheckBlock)
        End With
    End Sub
End Class
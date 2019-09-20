Public Class MapResult
    Private Map(0, 0) As MapColor
    Public ReadOnly Property OutImage As Bitmap
    Public UsedMapColors As New Dictionary(Of MapColor, Integer)
    Public Async Function Generate(Image As Bitmap, progress As IProgress(Of Integer)) As Task
        Dim InImage = New Bitmap(Image)
        Dim w = InImage.Width
        Dim h = InImage.Height
        'ReDim Map(w, h)
        _OutImage = New Bitmap(w, h)
        Dim closest As MapColor
        Await Task.Run(
            Sub()
                For x = 0 To w - 1
                    For y = 0 To h - 1
                        'progress.Report(x * h + (y + 1))
                        If InImage.GetPixel(x, y).A < 256 / 2 Then Continue For
                        closest = MapColorsCollection.GetClosest(InImage.GetPixel(x, y))
                        'Map(x, y) = closest
                        OutImage.SetPixel(x, y, closest.Color)
                        If Not UsedMapColors.ContainsKey(closest) Then UsedMapColors.Add(closest, 0)
                        UsedMapColors(closest) += 1
                    Next
                    progress.Report((x + 1) * h)
                Next
            End Sub)
        Await Task.Delay(1 * 500)
        'MapColorsCollection.GetClosest()
    End Function
End Class

Public Class MapResult
    Implements IResult
    Private Map(0, 0) As MapColor
    Public ReadOnly Property OutImage As Bitmap Implements IResult.OutImage
    Public UsedMapColors As New Dictionary(Of MapColor, Integer)
    Public Async Function Generate(Image As Bitmap, progress As IProgress(Of Integer), token As Threading.CancellationToken) As Task Implements IResult.Generate
        Dim InImage = New Bitmap(Image)
        Dim w = InImage.Width
        Dim h = InImage.Height
        ReDim Map(w, h)
        _OutImage = New Bitmap(w, h)
        Dim closest As MapColor
        Await Task.Run(
            Sub()
                For x = 0 To w - 1
                    For y = 0 To h - 1
                        'progress.Report(x * h + (y + 1))
                        If token.IsCancellationRequested Then
                            token.ThrowIfCancellationRequested()
                        End If
                        If InImage.GetPixel(x, y).A < 256 / 2 Then Continue For
                        closest = MapColorsCollection.GetClosest(InImage.GetPixel(x, y))
                        Map(x, y) = closest
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
    Public Function ColorAtPixel(p As Point) As MapColor
        Return Map(p.X - 1, p.Y - 1)
    End Function
End Class

Imports Newtonsoft.Json
Public Class MapResult
    Implements IResult
    Private Map(,) As MapColor
    Public ReadOnly Property OutImage As Bitmap Implements IResult.OutImage
    Public UsedMapColors As New Dictionary(Of MapColor, Integer)
    Public Async Function Generate(Image As Bitmap, progress As IProgress(Of Integer), token As Threading.CancellationToken) As Task Implements IResult.Generate
        Dim InImage = New Bitmap(Image)
        Dim w = InImage.Width
        Dim h = InImage.Height
        ReDim Map(w - 1, h - 1)
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

    Structure MapJSON
        Public Map(,) As Integer
        Public MapColors() As MapColor

    End Structure

    Public Function SaveToJSON() As String
        Dim f As MapJSON
        ReDim f.Map(Map.GetUpperBound(0), Map.GetUpperBound(1))
        f.MapColors = UsedMapColors.Keys.ToArray

        For i = 0 To Map.GetUpperBound(0)
            For j = 0 To Map.GetUpperBound(1)
                f.Map(i, j) = Map(i, j).ID
            Next
        Next

        'Return JsonConvert.SerializeObject(Map, New JsonSerializerSettings With {.PreserveReferencesHandling = PreserveReferencesHandling.Objects})
        Return JsonConvert.SerializeObject(f)
    End Function
End Class

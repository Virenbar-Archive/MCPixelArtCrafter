Imports Newtonsoft.Json
Imports MCPixelArtCrafter.DataIO

Public Class MapResult
    Implements IResult
    Private Map(,) As MapColor
    Public ReadOnly Property OutImage As Bitmap Implements IResult.OutImage
    Public ReadOnly UsedMapColors As New Dictionary(Of MapColor, Integer)
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

    Public Function ToJSON() As String
        Dim tmp As MapJSON
        ReDim tmp.Map(Map.GetUpperBound(0), Map.GetUpperBound(1))
        tmp.MapColors = UsedMapColors.Keys.ToArray

        For i = 0 To Map.GetUpperBound(0)
            For j = 0 To Map.GetUpperBound(1)
                tmp.Map(i, j) = Map(i, j).ID
            Next
        Next
        Return JsonConvert.SerializeObject(tmp)
        'Return tmp
    End Function

    Public Sub LoadMCPAC(infile As String)
        Dim json = LoadFromMCPAC(infile)
        Dim w = json.Map.GetLength(0), h = json.Map.GetLength(1)
        ReDim Map(w - 1, h - 1)
        _OutImage = New Bitmap(w, h)

        For x = 0 To w - 1
            For y = 0 To h - 1
                Dim color = json.MapColors(json.Map(x, y))

                Map(x, y) = color
                OutImage.SetPixel(x, y, color.Color)

                If Not UsedMapColors.ContainsKey(color) Then UsedMapColors.Add(color, 0)
                UsedMapColors(color) += 1
            Next
        Next
    End Sub
End Class

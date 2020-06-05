Imports Newtonsoft.Json

Namespace Data.IO
    Public Class JSONConverter
        Const Version As Integer = 2000

        Public Shared Function FromJSON(jsoni As String) As MapResult
            Dim json = JsonConvert.DeserializeObject(Of MapJSON)(jsoni)
            Dim map = New MapResult(json.Width, json.Heigth)
            Dim w = json.Width, h = json.Heigth

            For x = 0 To w - 1
                For y = 0 To h - 1
                    Dim color = json.MapColors(json.Map(x + y * w))

                    map(x, y) = color
                    map.CountUsedMapColors()
                    map.RedoImage()
                Next
            Next
            Return map
        End Function

        Public Shared Function ToJSON(map As MapResult) As String
            Dim tmp As MapJSON
            tmp.Width = map.Width
            tmp.Heigth = map.Height
            Dim index = New Dictionary(Of UInteger, Integer)
            tmp.MapColors = map.UsedMapColors.Keys.ToArray
            For i = 0 To tmp.MapColors.GetUpperBound(0)
                index.Add(tmp.MapColors(i).ID_map, i)
            Next

            tmp.Map = Array.ConvertAll(map.Map, Function(x) index(x.ID_map))

            tmp.Version = Version
            Return JsonConvert.SerializeObject(tmp)
            'Return tmp
        End Function

        Public Structure MapJSON
            Public Width As Integer
            Public Heigth As Integer
            Public Map() As Integer
            Public MapColors() As MapColor
            Public Version As Integer
        End Structure

    End Class
End Namespace
Imports System.IO
Imports System.IO.Compression
Imports Newtonsoft.Json

Namespace Data.IO
    Module DataConvertion
        Private ReadOnly MapResultFN As String = "MapResult.json"
        Private ReadOnly ImageFN As String = ""
        Public Structure MapJSON
            Public Map(,) As Integer
            Public MapColors() As MapColor
            Public Function ToJSON() As String
                Return JsonConvert.SerializeObject(Me)
            End Function
        End Structure

        Public Sub SaveToMCPAC(outfile As String, map As MapResult)
            Try
                Dim TempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())
                Directory.CreateDirectory(TempDir)
                File.WriteAllText(Path.Combine(TempDir, MapResultFN), map.ToJSON)
                File.Delete(outfile)
                ZipFile.CreateFromDirectory(TempDir, outfile)
                Directory.Delete(TempDir, True)
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Sub

        Public Function LoadFromMCPAC(infile As String) As MapJSON
            Try
                Dim zip = ZipFile.Open(infile, ZipArchiveMode.Read)
                Dim map = zip.GetEntry(MapResultFN).Open
                Dim str = New StreamReader(map)
                Dim json = str.ReadToEnd
                Return JsonConvert.DeserializeObject(Of MapJSON)(json)
            Catch ex As Exception
                ShowError(ex)
                Return Nothing
            End Try
        End Function
    End Module
End Namespace
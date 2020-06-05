Imports System.IO
Imports System.IO.Compression

Namespace Data.IO
    Class MCPACConverter
        Private Shared ReadOnly ImageFN As String = ""
        Private Shared ReadOnly MapResultFN As String = "MapResult.json"

        Public Shared Function LoadFromMCPAC(infile As String) As MapResult
            Try
                Dim zip = ZipFile.Open(infile, ZipArchiveMode.Read)
                Dim map = zip.GetEntry(MapResultFN).Open
                Dim str = New StreamReader(map)
                Dim json = str.ReadToEnd
                Return JSONConverter.FromJSON(json)
            Catch ex As Exception
                ShowError(ex)
                Return Nothing
            End Try
        End Function

        Public Shared Sub SaveToMCPAC(outfile As String, map As MapResult)
            Try
                Dim TempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName())
                Directory.CreateDirectory(TempDir)
                File.WriteAllText(Path.Combine(TempDir, MapResultFN), JSONConverter.ToJSON(map))
                File.Delete(outfile)
                ZipFile.CreateFromDirectory(TempDir, outfile)
                Directory.Delete(TempDir, True)
            Catch ex As Exception
                ShowError(ex)
            End Try
        End Sub

    End Class
End Namespace
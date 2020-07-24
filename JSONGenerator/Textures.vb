Imports Newtonsoft.Json
Imports System.IO
Imports System.Drawing

Public Class Textures
    Private Shared TexturesFolder = "SortedTextures"

    Public Shared Sub CreateFolders()
        Dim colors = JsonConvert.DeserializeObject(Of List(Of MapBaseColor))(File.ReadAllText(TexturesFolder + Path.DirectorySeparatorChar + "MapColors.json"))
        For Each c In colors
            Directory.CreateDirectory(Path.Combine(TexturesFolder, $"{c.ID}-{c.ID_str}"))
        Next
    End Sub

    Public Class MapBaseColor
        Public Property ID As Byte
        Public Property ID_str As String
        Public Property Full As String
        Public Property Transparent As String
        Public Property Color As Color
    End Class

End Class
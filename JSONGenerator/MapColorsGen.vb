Imports Newtonsoft.Json
Imports System.IO
Imports System.Drawing

Module MapColorsGen
    Class OldMapColor
        Public Property ID As String
        Public Property ColorStr As String
        Public Property Full As String
        Public Property Transparent As String
    End Class
    Class MapColor
        Public Property ID As UInteger
        Public Property ID_str As String
        Public Property Full As String
        Public Property Transparent As String
        Public Property Color As Color
    End Class

    Public Sub OldToNew()
        Dim config = Path.GetFullPath(DefaultDir + Path.DirectorySeparatorChar + "OldMapColors.json")
        Dim OldMapColors = JsonConvert.DeserializeObject(Of OldMapColor())(File.ReadAllText(config))

        Dim MapColors = New List(Of MapColor)
        For Each OldMC In OldMapColors
            Dim MC = New MapColor
            Dim RGB() = Array.ConvertAll(OldMC.ColorStr.Split(", "), Function(str) Int32.Parse(str))
            MC.Color = Color.FromArgb(RGB(0), RGB(1), RGB(2))

            Dim ID() = OldMC.ID.Split(" ")
            MC.ID = CUInt(ID(0))
            MC.ID_str = ID(1)

            MC.Full = OldMC.Full
            MC.Transparent = OldMC.Transparent
            MapColors.Add(MC)
        Next
        Dim NewConfig = JsonConvert.SerializeObject(MapColors, Formatting.Indented)
        File.WriteAllText("MapColors.json", NewConfig)
        Process.Start(Directory.GetCurrentDirectory())
    End Sub
End Module

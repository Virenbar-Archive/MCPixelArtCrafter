Imports System.IO
Imports Newtonsoft.Json
Imports Colourful
''' <summary>
''' Storage for MapColors
''' </summary>
Public NotInheritable Class MapColorsCollection
    Private Shared MapColors() As MapColor
    Private Shared Converter As New Conversion.ColourfulConverter
    Private Shared Comparer As New Difference.CIEDE2000ColorDifference
    Public Sub New()
    End Sub
    ''' <summary>
    ''' Loads config from folder and converts colors to Lab
    ''' </summary>
    ''' <param name="folder">Folder with config</param>
    Public Shared Sub Load(Optional folder As String = "Default")
        Dim config = Path.GetFullPath(folder + Path.DirectorySeparatorChar + "MapColors.json")
        If Not File.Exists(config) Then
            MessageBox.Show(String.Format("Can't find {0}", config), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        MapColors = JsonConvert.DeserializeObject(Of MapColor())(File.ReadAllText(config))
        For Each MC In MapColors
            MC.ColorStr.Split(", ")
            Dim RGB = Array.ConvertAll(MC.ColorStr.Split(", "), Function(str) Int32.Parse(str))
            MC.Color = Color.FromArgb(RGB(0), RGB(1), RGB(2))
            MC.LabColor = Converter.ToLab(New RGBColor(MC.Color))
        Next
    End Sub
    ''' <summary>
    ''' Returns closest color
    ''' </summary>
    ''' <param name="color">Color to search</param>
    ''' <returns>Closest color</returns>
    Public Shared Function GetClosest(color As Color) As MapColor
        Dim colorLab = Converter.ToLab(New RGBColor(color))
        Dim Closest As MapColor = Nothing
        Dim min, diff As Double
        min = Double.PositiveInfinity
        For Each MC In MapColors
            diff = Comparer.ComputeDifference(colorLab, MC.LabColor)
            If diff < min Then
                min = diff
                Closest = MC
            End If
        Next
        GetClosest = Closest
    End Function
End Class

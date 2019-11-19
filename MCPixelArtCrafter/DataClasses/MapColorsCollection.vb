Imports System.IO
Imports MCPixelArtCrafter.SettingsHelper
Imports Newtonsoft.Json
Imports Colourful
''' <summary>
''' Storage for MapColors
''' </summary>
Public NotInheritable Class MapColorsCollection
    Public Shared MapColorsFull() As MapColor
    Private Shared MapColors() As MapColor
    Private Shared Converter As New Conversion.ColourfulConverter
    Private Shared Comparer As New Difference.CIEDE2000ColorDifference
    Private Shared ColorCache As New Dictionary(Of Color, Integer)
    Public Shared Property LabMode As Boolean = False
    Public Sub New()
    End Sub
    ''' <summary>
    ''' Loads config from folder and converts colors to Lab
    ''' </summary>
    ''' <param name="folder">Folder with config</param>
    Public Shared Sub Load(Optional folder As String = "Default")
        MapColors = Nothing
        Dim config = Path.GetFullPath(folder + Path.DirectorySeparatorChar + "MapColors.json")
        If Not File.Exists(config) Then
            MessageBox.Show(String.Format("Can't find {0}", config), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        MapColorsFull = JsonConvert.DeserializeObject(Of MapColor())(File.ReadAllText(config))
        For Each MC In MapColorsFull
            MC.LabColor = Converter.ToLab(New RGBColor(MC.Color))
        Next
        CheckConfig()
    End Sub
    Public Shared Sub CheckConfig()
        LabMode = Config.LabMode
        If Config.BlacklistMC.Count = 0 Then
            MapColors = MapColorsFull
        Else
            Dim tmp = New List(Of MapColor)
            For Each MC In MapColorsFull
                If Config.BlacklistMC.Contains(MC.ID_str) Then Continue For
                tmp.Add(MC)
            Next
            MapColors = tmp.ToArray
            ColorCache.Clear()
        End If
    End Sub
    ''' <summary>
    ''' Returns closest color
    ''' </summary>
    ''' <param name="color">Color to search</param>
    ''' <returns>Closest color</returns>
    Public Shared Function GetClosest(color As Color) As MapColor
        Dim id As Integer
        If ColorCache.TryGetValue(color, id) Then Return MapColors(id)
        If LabMode Then
            GetClosest = FindClosest(Converter.ToLab(New RGBColor(color)), id)
        Else
            GetClosest = FindClosest(color, id)
        End If
        If Not ColorCache.ContainsKey(color) Then ColorCache.Add(color, id)
    End Function
    Private Shared Function FindClosest(color As Color, ByRef id As Integer) As MapColor
        Dim Closest As MapColor = Nothing
        Dim min, diff As Double
        min = Double.PositiveInfinity
        For i = 0 To MapColors.Count - 1
            Dim MC = MapColors(i)
            diff = Math.Sqrt((CInt(color.R) - CInt(MC.Color.R)) ^ 2 + (CInt(color.G) - CInt(MC.Color.G)) ^ 2 + (CInt(color.B) - CInt(MC.Color.B)) ^ 2)
            If diff < min Then
                min = diff
                Closest = MC
                id = i
            End If
        Next
        FindClosest = Closest
    End Function
    Private Shared Function FindClosest(color As LabColor, ByRef id As Integer) As MapColor
        Dim Closest As MapColor = Nothing
        Dim min, diff As Double
        min = Double.PositiveInfinity
        For i = 0 To MapColors.Count - 1
            Dim MC = MapColors(i)
            diff = Comparer.ComputeDifference(color, MC.LabColor)
            If diff < min Then
                min = diff
                Closest = MC
                id = i
            End If
        Next
        FindClosest = Closest
    End Function
End Class

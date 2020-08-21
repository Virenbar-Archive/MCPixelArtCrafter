Imports System.Drawing
Imports System.IO
Imports Colourful
Imports Newtonsoft.Json
Imports MCPACLib.Helpers.Configuration

Namespace Helpers
	''' <summary>
	''' Storage for MapColors
	''' </summary>
	Public NotInheritable Class MapColorsCollection
		Public Shared MapBaseColors As List(Of MapBaseColor)
		Public Shared MapColorsFull As New List(Of MapColor)
		Private Shared ColorNone As MapColor
		Private Shared ColorCache As New Dictionary(Of Color, Integer)
		Private Shared Comparer As New Difference.CIEDE2000ColorDifference
		Private Shared Converter As New Conversion.ColourfulConverter
		Private Shared DefaultCache As New Dictionary(Of Color, Integer)
		Private Shared MapColors As New List(Of MapColor)

		Public Shared ReadOnly Property Palette As List(Of Color)
			Get
				Return DefaultCache.Keys.ToList
			End Get
		End Property

		Public Shared Property ColorTypes As MapColor.Type() = {MapColor.Type.Up}
		Public Shared Property LabMode As Boolean = False

		Public Shared Sub CheckConfig()
			LabMode = Config.LabMode
			MapColors.Clear()
			For Each MC In MapColorsFull
				If Config.BlacklistMC.Contains(MC.ID_str) OrElse Not ColorTypes.Contains(MC.TypeT) Then Continue For
				MapColors.Add(MC)
			Next
			CreateCache()
		End Sub

		''' <summary>
		''' Returns closest color
		''' </summary>
		''' <param name="color">Color to search</param>
		''' <returns>Closest color</returns>
		Public Shared Function GetClosest(color As Color) As MapColor
			If color.A < 256 / 2 Then Return ColorNone
			Dim id As Integer
			If ColorCache.TryGetValue(color, id) Then Return MapColors(id)
			If LabMode Then
				GetClosest = FindClosest(Converter.ToLab(New RGBColor(color)), id)
			Else
				GetClosest = FindClosest(color, id)
			End If
			If Not ColorCache.ContainsKey(color) Then ColorCache.Add(color, id)
		End Function

		''' <summary>
		''' Loads config from folder and converts colors to Lab
		''' </summary>
		''' <param name="folder">Folder with config</param>
		Public Shared Sub Load(Optional folder As String = "Default")
			Dim config = Path.GetFullPath(folder + Path.DirectorySeparatorChar + "MapColors.json")
			If Not File.Exists(config) Then
				ShowError($"Can't find {config}")
				Exit Sub
			End If
			MapBaseColors = JsonConvert.DeserializeObject(Of List(Of MapBaseColor))(File.ReadAllText(config))
			ColorNone = New MapColor(MapBaseColors(0), MapColor.Type.Up)
			MapBaseColors.RemoveAt(0)
			For Each MC In MapBaseColors
				MapColorsFull.Add(New MapColor(MC, MapColor.Type.Down))
				MapColorsFull.Add(New MapColor(MC, MapColor.Type.Normal))
				MapColorsFull.Add(New MapColor(MC, MapColor.Type.Up)) 'Same as base color
				MapColorsFull.Add(New MapColor(MC, MapColor.Type.Dark))
			Next
			CheckConfig()
		End Sub

		Private Shared Sub CreateCache()
			DefaultCache.Clear()
			ColorCache.Clear()
			For Each color In MapColors
				DefaultCache.Add(color.Color, color.ID_map)
				'ColorCache.Add(color.Color, color.ID_map)
			Next
		End Sub

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
End Namespace
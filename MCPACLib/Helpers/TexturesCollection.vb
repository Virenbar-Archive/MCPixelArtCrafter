Imports System.Drawing
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Windows.Media.Imaging
Imports MCPACLib.Helpers.Configuration

Namespace Helpers
	Public Class TexturesCollection
		Public Shared Selections As New List(Of TextureSelection)
		Private Shared EmptyImage As New Bitmap(16, 16)
		Private Shared Textures As Dictionary(Of Integer, Image)

		Shared Sub New()

		End Sub

		Public Shared ReadOnly Property Item(id As Integer) As Image
			Get
				Return If(Textures.ContainsKey(id), Textures(id), EmptyImage)
			End Get
		End Property

		Public Shared Sub CheckConfig()
			Textures = Selections.ToDictionary(Function(x) x.ID, Function(x) x.List.First.Img)
			If Config.ColorToBlock.Count > 0 Then
				Dim ImageDict = Selections.SelectMany(Function(x) x.List).ToDictionary(Function(x) x.Filename, Function(x) x.Img)
				For Each CBT In Config.ColorToBlock
					If Textures.ContainsKey(CBT.Key) AndAlso ImageDict.ContainsKey(CBT.Value) Then
						Textures(CBT.Key) = ImageDict(CBT.Value)
					End If
				Next
			End If
		End Sub

		Public Shared Sub Load(Optional folder As String = "Default")
			Dim FolderRegex = New Regex("(?'ID'\d+)-\w+", RegexOptions.ExplicitCapture)
			Dim TI = Globalization.CultureInfo.CurrentCulture.TextInfo
			Dim files = Directory.GetFiles(folder, "*.png", SearchOption.AllDirectories)
			Dim lists As ILookup(Of String, String) = files.ToLookup(Function(x) Path.GetFileName(Path.GetDirectoryName(x)), Function(x) x)
			For Each group In lists
				Dim m = FolderRegex.Match(group.Key)
				If m.Success Then
					Dim ID = Integer.Parse(m.Groups("ID").Value)
					Dim h As List(Of Texture) = group.ToList.ConvertAll(
						Function(x)
							Return New Texture With {
							.Filename = Path.GetFileNameWithoutExtension(x),
							.Name = TI.ToTitleCase(String.Join(" ", .Filename.Split("_"c))),
							.Img = New Bitmap(x),
							.Image = New BitmapImage(New Uri(Path.GetFullPath(x)))
							}
						End Function)
					Selections.Add(New TextureSelection() With {.ID = ID, .Name = group.Key, .List = h})
				End If
			Next
			Selections.Sort()
			'For Each mc In MapColorsCollection.MapBaseColors
			'    Dim ColorDirectory = Path.Combine(folder, "Textures", $"{mc.ID}-{mc.ID_str}")
			'    Dim ColorTextures = Directory.GetFiles(ColorDirectory, "*.png", SearchOption.AllDirectories)
			'    If ColorTextures.Count = 0 Then Continue For
			'    Dim ff = ColorTextures.ToList.con
			'    Dim TL = New List(Of Texture)
			'    For Each file In ColorTextures
			'        TL.Add(New Texture With {.Img = New Bitmap(file), .Name = Path.GetFileNameWithoutExtension(file)})
			'    Next
			'    d.Add(mc.ID, TL)
			'Next
			CheckConfig()
		End Sub

	End Class
End Namespace
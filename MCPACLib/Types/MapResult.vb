Imports System.Drawing
Imports MCPACLib.Data
Imports MCPACLib.Helpers

Public Class MapResult
	Private _Image As Bitmap
	Private _TextureImage As Bitmap

	Public Sub New(w As Integer, h As Integer, Optional type As MapType = MapType.Flat)
		Width = w
		Height = h
		Map = New MapColor(w * h - 1) {}
		_Image = New Bitmap(w, h)
		MapType = type
	End Sub

	Public ReadOnly Property Height As Integer
	Public ReadOnly Property Width As Integer
	Public ReadOnly Property MapType As MapType

	Public ReadOnly Property Image As Bitmap
		Get
			Return _Image
		End Get
	End Property

	Public ReadOnly Property ImageTex As Bitmap
		Get
			Return _TextureImage
		End Get
	End Property

	Public ReadOnly Property Map As MapColor()
	Public ReadOnly Property UsedMapColors As New Dictionary(Of MapColor, Integer)

	Default Public Property Item(X As Integer, Y As Integer) As MapColor
		Get
			If 0 > X Or X > Width - 1 Or 0 > Y Or Y > Height - 1 Then Return Nothing
			Return Map(X + Y * Width)
		End Get
		Set(value As MapColor)
			Map(X + Y * Width) = value
		End Set
	End Property

	Default Public ReadOnly Property Item(P As Windows.Point) As MapColor
		Get
			Return Item(CInt(P.X) - 1, CInt(P.Y) - 1)
		End Get
	End Property

	Default Public ReadOnly Property Item(P As Point) As MapColor
		Get
			Return Item(P.X - 1, P.Y - 1)
		End Get
	End Property

	Friend Sub CountUsedMapColors()
		UsedMapColors.Clear()
		For Each MC In Map
			If MC Is Nothing Then Continue For
			If Not UsedMapColors.ContainsKey(MC) Then UsedMapColors.Add(MC, 0)
			UsedMapColors(MC) += 1
		Next
	End Sub

	Friend Sub RedoImage()
		Using tmpImage = New DirectBitmap(Width, Height)
			For x = 0 To Width - 1
				For y = 0 To Height - 1
					tmpImage.SetPixel(x, y, If(Item(x, y) Is Nothing, Color.Transparent, Item(x, y).Color))
				Next
			Next
			_Image = New Bitmap(tmpImage.Bitmap)
		End Using
	End Sub

	Public Async Function RedoImageTex() As Task
		_TextureImage = Await Task.Run(
		Function()
			Dim Image = New Bitmap(Width * 16, Height * 16)
			Using G = Graphics.FromImage(Image)
				G.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
				For y = 0 To Height - 1
					For x = 0 To Width - 1
						Dim Texture = TexturesCollection.Item(Item(x, y).ID)
						If Texture Is Nothing Then
							Using brush = New SolidBrush(Item(x, y).Color)
								G.FillRectangle(brush, x * 16, y * 16, 16, 16)
							End Using
						Else
							G.DrawImage(Texture, x * 16, y * 16, 16, 16)
						End If
					Next
				Next
			End Using
			Return Image
		End Function)
	End Function

End Class
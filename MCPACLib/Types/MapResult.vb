Imports System.Drawing
Imports MCPACLib.Data

Public Class MapResult
	Private _Image As Bitmap

	Public Sub New(w As Integer, h As Integer)
		Width = w
		Height = h
		Map = New MapColor(w * h - 1) {}
		_Image = New Bitmap(w, h)
	End Sub

	Public ReadOnly Property Height As Integer

	Public ReadOnly Property Image As Bitmap
		Get
			Return _Image
		End Get
	End Property

	Public ReadOnly Property Map As MapColor()
	Public ReadOnly Property UsedMapColors As New Dictionary(Of MapColor, Integer)
	Public ReadOnly Property Width As Integer

	Default Public Property Item(X As Integer, Y As Integer) As MapColor
		Get
			If 0 > X Or X > Width - 1 Or 0 > Y Or Y > Height - 1 Then Return Nothing
			Return Map(X + Y * Width)
		End Get
		Set(value As MapColor)
			Map(X + Y * Width) = value
			'Image.SetPixel(X, Y, value.Color)
		End Set
	End Property

	Default Public ReadOnly Property Item(P As Point) As MapColor
		Get
			If 1 > P.X Or P.X > Width - 1 Or 0 > P.Y Or P.Y > Height - 1 Then Return Nothing
			Return Item(P.X, P.Y)
		End Get
	End Property

	Public Function ColorAtPixel(p As Point) As MapColor
		If 1 > p.X Or p.X > Width - 1 Or 0 > p.Y Or p.Y > Height - 1 Then Return Nothing
		Return Item(p.X - 1, p.Y - 1)
	End Function

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

	''' <summary>
	''' Sets color on map and image
	''' </summary>
	''' <param name="x"></param>
	''' <param name="y"></param>
	''' <param name="MC"></param>
	Friend Sub SetColor(x As Integer, y As Integer, MC As MapColor)
		Item(x, y) = MC
		Image.SetPixel(x, y, MC.Color)
	End Sub

End Class
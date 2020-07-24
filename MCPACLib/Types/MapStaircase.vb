Imports System.Drawing
Imports MCPACLib.Data

Public Class MapStaircase
	Private ReadOnly Map As MapResult
	Private MaxH, MinH As Integer

	'Private Columns As List(Of MapColumn)
	Public Sub New(mr As MapResult)
		Map = mr
		Width = mr.Width
		Height = mr.Height
		HeightMap = New Integer(Width * Height - 1) {}
	End Sub

	Public ReadOnly Property Height As Integer
	Public ReadOnly Property HeightMap As Integer()
	Public ReadOnly Property Width As Integer
	Public Property Image As Bitmap

	Default Public Property Item(X As Integer, Y As Integer) As Integer
		Get
			If 0 > X Or X > Width - 1 Or 0 > Y Or Y > Height - 1 Then Return Nothing
			Return HeightMap(X + Y * Width)
		End Get
		Set(value As Integer)
			HeightMap(X + Y * Width) = value
		End Set
	End Property

	Public Sub CalculateHeights()
		For W = 0 To Width - 1
			Dim PrevHeight = 0
			'From south to north
			For H = Height - 1 To 0
				Select Case Map(W, H).TypeT
					Case MapColor.Type.Down : PrevHeight -= 1
					'Case MapColor.Type.Normal : PrevHeight += 0
					Case MapColor.Type.Up : PrevHeight += 1
					Case Else
				End Select
				Item(W, H) = PrevHeight
			Next
		Next
		MaxH = Math.Max(HeightMap.Max, 0)
		MinH = Math.Min(HeightMap.Min, 0)
	End Sub

	Public Sub OptimizeHeights()
		'
	End Sub

	Public Sub UpdateImage(column As Integer)
		Using DB = New DirectBitmap(Height + 1, MaxH - MinH + 1)
			Dim Zero = (DB.Height - 1) + MinH 'Уровень нулевой высоты
			DB.SetPixel(0, (DB.Height - 1) + MinH, Color.Black)
			For Y = 1 To DB.Width - 1
				DB.SetPixel(Y, Zero - Item(column, Y), Map(column, Y).Color)
			Next
			Image = New Bitmap(DB.Bitmap)
		End Using
	End Sub

End Class
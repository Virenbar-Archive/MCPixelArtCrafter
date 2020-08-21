Imports System.Drawing
Imports MCPACLib.Data

Namespace Helpers
	Public Class FSDither

		'Private Shared Distr() As Single = {7 / 16, 3 / 16, 5 / 16, 1 / 16}
		''' <summary>
		''' Floyd–Steinberg dithering distribution
		''' x,y - offset
		''' p - proportion for offset
		''' </summary>
		Private Shared ReadOnly Proportions() As (x As Short, y As Short, p As Single) = {(1, 0, 7 / 16), (-1, 1, 3 / 16), (0, 1, 5 / 16), (1, 1, 1 / 16)}

		' . * 1
		' 2 3 4
		Public Shared Sub ApplyDither(image As Bitmap, newColor As Color, oldColor As Color, x As Integer, y As Integer)
			Dim nPixel As Color
			Dim diffR = CType(oldColor.R, Short) - newColor.R
			Dim diffG = CType(oldColor.G, Short) - newColor.G
			Dim diffB = CType(oldColor.B, Short) - newColor.B
			For Each P In Proportions
				If 0 <= x + P.x AndAlso x + P.x <= image.Width - 1 AndAlso y + P.y <= image.Height - 1 Then
					nPixel = image.GetPixel(x + P.x, y + P.y)
					Dim newPixel = Color.FromArgb(
						(nPixel.A),
						(nPixel.R + diffR * P.p).ToByte,
						(nPixel.G + diffG * P.p).ToByte,
						(nPixel.B + diffB * P.p).ToByte)
					image.SetPixel(x + P.x, y + P.y, newPixel)
				End If
			Next
		End Sub

		Public Shared Sub ApplyDither(image As DirectBitmap, newColor As Color, oldColor As Color, x As Integer, y As Integer)
			Dim nPixel As Color
			Dim diffR = CType(oldColor.R, Short) - newColor.R
			Dim diffG = CType(oldColor.G, Short) - newColor.G
			Dim diffB = CType(oldColor.B, Short) - newColor.B
			For Each P In Proportions
				If 0 <= x + P.x AndAlso x + P.x <= image.Width - 1 AndAlso y + P.y <= image.Height - 1 Then
					nPixel = image.GetPixel(x + P.x, y + P.y)
					Dim newPixel = Color.FromArgb(
						(nPixel.A),
						(nPixel.R + diffR * P.p).ToByte,
						(nPixel.G + diffG * P.p).ToByte,
						(nPixel.B + diffB * P.p).ToByte)
					image.SetPixel(x + P.x, y + P.y, newPixel)
				End If
			Next
		End Sub

	End Class
End Namespace
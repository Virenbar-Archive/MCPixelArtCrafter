Imports System.Runtime.CompilerServices
Imports System.Reflection
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Media.Imaging
Imports System.Drawing.Imaging
Imports System.IO

Public Module Extensions

	<Extension>
	Public Function Divide(p As Point, n As Double) As PointF
		Return New PointF(CSng(p.X / n), CSng(p.Y / n))
	End Function

	''' <summary>
	''' Включает двойную буферизацию
	''' </summary>
	<Extension()>
	Public Sub DoubleBuffered(Ctrl As Control, Optional setting As Boolean = True)
		Dim CtrlType As Type = Ctrl.GetType()
		Dim propInfo As PropertyInfo = CtrlType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
		propInfo.SetValue(Ctrl, setting, Nothing)
	End Sub

	<Extension>
	Public Function Multiply(p As Point, n As Double) As PointF
		Return New PointF(CSng(p.X * n), CSng(p.Y * n))
	End Function

	<Extension>
	Public Function Substract(p1 As Point, p2 As Point) As Point
		Return New Point(p1.X - p2.X, p1.Y - p2.X)
	End Function

	<Extension>
	Public Function ToByte(val As Integer) As Byte
		If val > Byte.MaxValue Then
			Return Byte.MaxValue
		ElseIf val < 0 Then
			Return Byte.MinValue
		Else
			Return CByte(val)
		End If
	End Function

	<Extension>
	Public Function ToByte(val As Single) As Byte
		Return CInt(val).ToByte
	End Function

	<Extension>
	Public Function ToBitmapImage(bitmap As Bitmap) As BitmapImage
		Using memory = New MemoryStream()
			bitmap.Save(memory, ImageFormat.Bmp)
			memory.Position = 0
			Dim BitmapImage = New BitmapImage()
			BitmapImage.BeginInit()
			BitmapImage.StreamSource = memory
			BitmapImage.CacheOption = BitmapCacheOption.OnLoad
			BitmapImage.EndInit()
			Return BitmapImage
		End Using
	End Function

	'Public Function BitmapImage2Bitmap(bitmapImage As BitmapImage) As Bitmap
	'	Return New Bitmap(bitmapImage.StreamSource)
	'End Function

End Module
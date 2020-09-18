Imports System.Runtime.CompilerServices

Module Extensions

	''' <summary>
	''' Copy color and set alpha value
	''' </summary>
	''' <param name="C"></param>
	''' <param name="A"></param>
	''' <returns></returns>
	<Extension>
	Public Function CopyColor(C As Color, Optional A As Byte = 255) As Color
		Return Color.FromArgb(A, C.R, C.G, C.B)
	End Function

	''' <summary>
	''' Clamp number by min, max
	''' </summary>
	''' <param name="n">Number to clamp</param>
	''' <param name="min">Min value</param>
	''' <param name="max">Max value</param>
	''' <returns></returns>
	<Extension>
	Public Function Clamp(n As Double, min As Double, max As Double) As Double
		Return Math.Max(Math.Min(max, n), min)
	End Function

End Module
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

End Module
Imports System.Drawing

''' <summary>
''' Base map color
''' </summary>
Public Class MapBaseColor

	''' <summary>
	''' Base ID
	''' </summary>
	''' <returns></returns>
	Public Property ID As Byte

	''' <summary>
	''' Name of color
	''' </summary>
	''' <returns></returns>
	Public Property ID_str As String

	''' <summary>
	''' Full blocks with this color
	''' </summary>
	''' <returns></returns>
	Public Property Full As String

	''' <summary>
	''' Transparent blocks with this color
	''' </summary>
	''' <returns></returns>
	Public Property Transparent As String

	''' <summary>
	''' RGB color
	''' </summary>
	''' <returns></returns>
	Public Property Color As Color

End Class
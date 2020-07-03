Imports System.Drawing
Imports Colourful
Imports Newtonsoft.Json

Public Class MapColor
	Private Shared Converter As New Conversion.ColourfulConverter

	Public Sub New(base As MapBaseColor, type As Type)
		ID_map = base.ID * CByte(4) + type
		TypeT = type
		BaseColor = base
		Select Case TypeT
			Case Type.Down : Color = Convert(BaseColor.Color, 180)
			Case Type.Normal : Color = Convert(BaseColor.Color, 220)
			Case Type.Up : Color = BaseColor.Color 'Convert(BaseColor.Color, 255)
			Case Type.Dark : Color = Convert(BaseColor.Color, 135)
		End Select
		LabColor = Converter.ToLab(New RGBColor(Color))
	End Sub

	''' <summary>
	''' Base ID
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property ID As Byte
		Get
			Return BaseColor.ID
		End Get
	End Property

	''' <summary>
	''' Name of color
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property ID_str As String
		Get
			Return BaseColor.ID_str
		End Get
	End Property

	''' <summary>
	''' Full blocks with this color
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property Full As String
		Get
			Return BaseColor.Full
		End Get
	End Property

	''' <summary>
	''' Transparent blocks with this color
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property Transparent As String
		Get
			Return BaseColor.Transparent
		End Get
	End Property

	''' <summary>
	''' In game map color ID
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property ID_map As Byte

	''' <summary>
	''' Type of placement
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property TypeT As Type

	''' <summary>
	''' Base color of block
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property BaseColor As MapBaseColor

	''' <summary>
	''' RGB color
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property Color As Color

	''' <summary>
	''' CIELab Color
	''' </summary>
	''' <returns></returns>
	<JsonIgnore>
	Public ReadOnly Property LabColor As LabColor

	Private Shared Function Convert(color As Color, mult As Integer) As Color
		Return Color.FromArgb(CInt(Math.Floor(color.R * mult / 255)), CInt(Math.Floor(color.G * mult / 255)), CInt(Math.Floor(color.B * mult / 255)))
	End Function

	Public Enum Type As Byte
		Down = 0
		Normal = 1
		Up = 2
		Dark = 3
	End Enum

End Class
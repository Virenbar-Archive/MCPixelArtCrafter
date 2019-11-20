Imports Colourful
Imports Newtonsoft.Json

Public Class MapColor
    ''' <summary>
    ''' Base ID
    ''' </summary>
    ''' <returns></returns>
    Public Property ID As UInteger
    ''' <summary>
    ''' Name of color
    ''' </summary>
    ''' <returns></returns>
    Public Property ID_str As String
    ''' <summary>
    ''' In game map color ID
    ''' </summary>
    ''' <returns></returns>
    Public Property ID_map As UInteger
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
    ''' <summary>
    ''' CIELab Color
    ''' </summary>
    ''' <returns></returns>
    <JsonIgnore>
    Public Property LabColor As LabColor
End Class

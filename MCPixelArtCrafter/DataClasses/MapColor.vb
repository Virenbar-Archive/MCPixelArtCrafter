Imports Colourful
Imports Newtonsoft.Json
Imports System.Runtime.Serialization

Public Class MapColor
    Public Property ID As UInteger
    Public Property ID_str As String
    Public Property Full As String
    Public Property Transparent As String
    Public Property Color As Color
    <JsonIgnore>
    Public Property LabColor As LabColor
End Class

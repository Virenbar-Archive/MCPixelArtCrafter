Imports System.Runtime.CompilerServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Namespace Data.IO
	Public Class JSONConverter
		Const Version As Integer = 2000

		Public Shared Function FromJSON(jsoni As String) As MapResult
			Dim Settings = New JsonSerializerSettings()
			Settings.Converters.Add(New MapColorConverter())
			Dim json = JsonConvert.DeserializeObject(Of MapJSON)(jsoni, Settings)
			Dim map = New MapResult(json.Width, json.Heigth)
			Dim w = json.Width, h = json.Heigth

			For x = 0 To w - 1
				For y = 0 To h - 1
					Dim color = json.MapColors(json.Map(x + y * w))
					map(x, y) = color
				Next
			Next
			map.CountUsedMapColors()
			map.RedoImage()
			Return map
		End Function

		Public Shared Function ToJSON(map As MapResult) As String
			Dim tmp As MapJSON
			tmp.Width = map.Width
			tmp.Heigth = map.Height
			Dim index = New Dictionary(Of UInteger, Integer)
			tmp.MapColors = map.UsedMapColors.Keys.ToArray
			For i = 0 To tmp.MapColors.GetUpperBound(0)
				index.Add(tmp.MapColors(i).ID_map, i)
			Next

			tmp.Map = Array.ConvertAll(map.Map, Function(x) index(x.ID_map))

			tmp.Version = Version
			Return JsonConvert.SerializeObject(tmp)
			'Return tmp
		End Function

		Public Structure MapJSON
			Public Width As Integer
			Public Heigth As Integer
			Public Map() As Integer
			Public MapColors() As MapColor
			Public Version As Integer
		End Structure

	End Class
	Class MapColorConverter
		Inherits Newtonsoft.Json.JsonConverter

		Public Overrides Function CanConvert(objectType As Type) As Boolean
			Return objectType Is GetType(MapColor)
		End Function

		Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
			'// Load the JSON for the Result into a JObject
			Dim jo As JObject = JObject.Load(reader)

			'// Read the properties which will be used as constructor parameters
			Dim base As MapBaseColor = jo("BaseColor").ToObject(Of MapBaseColor)
			Dim type = jo("TypeT").ToObject(Of MapColor.Type)

			'// Construct the Result object using the non-default constructor
			Dim result As MapColor = New MapColor(base, type)
			Return result
		End Function

		Public Overrides ReadOnly Property CanWrite As Boolean
			Get
				Return False
			End Get
		End Property

		Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
			Throw New NotImplementedException()
		End Sub

	End Class
End Namespace
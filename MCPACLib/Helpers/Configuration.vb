Imports System.IO
Imports Newtonsoft.Json

Namespace Helpers
	Public Class Configuration
		Public Shared Config As New ConfigType
		Const ConfigFile As String = "Settings.json"

		Public Shared Sub Load()
			If Not File.Exists(ConfigFile) Then Exit Sub
			Config = JsonConvert.DeserializeObject(Of ConfigType)(File.ReadAllText(ConfigFile))
		End Sub

		Public Shared Sub Save()
			Try
				Dim json = JsonConvert.SerializeObject(Config)
				File.WriteAllText(ConfigFile, json)
			Catch ex As Exception
				ShowError(ex)
			End Try
		End Sub

	End Class
End Namespace
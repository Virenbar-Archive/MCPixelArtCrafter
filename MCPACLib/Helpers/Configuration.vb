Imports System.IO
Imports Newtonsoft.Json

Namespace Helpers
	Public Class Configuration
		Public Shared Config As New ConfigType With {.BlacklistMC = New HashSet(Of String), .ColorToBlock = New Dictionary(Of Integer, String)}
		Const ConfigFile As String = "Settings.json"

		Public Shared Property TempFolder As String = Path.Combine(FileIO.SpecialDirectories.Temp, "MCPAC")

		Public Shared Sub LoadConfig()
			If Not File.Exists(ConfigFile) Then Exit Sub
			Config = JsonConvert.DeserializeObject(Of ConfigType)(File.ReadAllText(ConfigFile))
		End Sub

		Public Shared Sub SaveConfig()
			Try
				Dim json = JsonConvert.SerializeObject(Config)
				File.WriteAllText(ConfigFile, json)
			Catch ex As Exception
				ShowError(ex)
			End Try
		End Sub

	End Class
End Namespace
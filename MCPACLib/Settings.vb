Imports System.IO
Imports Newtonsoft.Json

Public Module SettingsHelper

	'Public Config As New Settings
	Const ConfigFile As String = "Settings.json"

	'Public Class Settings
	'	Public BlacklistMC As New List(Of String)
	'	Public ColorToBlock As New Dictionary(Of Integer, String)
	'	Public Dither As Boolean = True
	'	Public LabMode As Boolean = False

	'	Public Shared Sub Load()
	'		If Not File.Exists(ConfigFile) Then Exit Sub
	'		Config = JsonConvert.DeserializeObject(Of Settings)(File.ReadAllText(ConfigFile))
	'	End Sub

	'	Public Shared Sub Save()
	'		Try
	'			Dim json = JsonConvert.SerializeObject(Config)
	'			File.WriteAllText(ConfigFile, json)
	'		Catch ex As Exception
	'			ShowError(ex)
	'		End Try
	'	End Sub

	'End Class
End Module
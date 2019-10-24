Imports System.IO
Imports Newtonsoft.Json

Class SettingsHelper
    Private Shared SettingsFile As String = "Settings.json"
    Public Shared Config As New Settings
    Public Shared Sub Load()
        If Not File.Exists(SettingsFile) Then Exit Sub
        Config = JsonConvert.DeserializeObject(Of Settings)(File.ReadAllText(SettingsFile))
    End Sub
    Public Shared Sub Save()
        Dim json = JsonConvert.SerializeObject(Config)
        File.WriteAllText(SettingsFile, json)
    End Sub
    Public Class Settings
        Public BlacklistMC As New List(Of String)
        Public BlacklistB As New List(Of String)
        Public LabMode As Boolean = True
    End Class
End Class


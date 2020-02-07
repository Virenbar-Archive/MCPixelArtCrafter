Imports System.IO
Imports Newtonsoft.Json

Module SettingsHelper
    Private ReadOnly ConfigFile As String = "Settings.json"
    Public Config As New Settings
    Public Class Settings
        Public BlacklistMC As New List(Of String)
        Public BlacklistB As New List(Of String)
        Public LabMode As Boolean = False

        Public Shared Sub Load()
            If Not File.Exists(ConfigFile) Then Exit Sub
            Config = JsonConvert.DeserializeObject(Of Settings)(File.ReadAllText(ConfigFile))
        End Sub
        Public Shared Sub Save()
            Dim json = JsonConvert.SerializeObject(Config)
            File.WriteAllText(ConfigFile, json)
        End Sub
    End Class
End Module


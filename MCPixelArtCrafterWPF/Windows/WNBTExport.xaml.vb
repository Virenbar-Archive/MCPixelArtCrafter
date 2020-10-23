Imports MCPACLib
Imports MCPACLib.Data.IO
Imports MCPACLib.Helpers.Configuration
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class WNBTExport
	Private Result As MapResult

	Public Shadows Sub Show(_result As MapResult)
		Result = _result
		MyBase.Show()
	End Sub

	Public ReadOnly Property VersionEnum As Dictionary(Of MCVersion, String)
		Get
			Return New Dictionary(Of MCVersion, String) From {
				{MCVersion.Pre116, ""},
				{MCVersion.V116, ""}}
		End Get
	End Property

	Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
		NBTExporter.CountMaps(Result)
		DataContext = Config
	End Sub

	Private Sub B_Info_Click(sender As Object, e As RoutedEventArgs) Handles B_Info.Click

	End Sub

	Private Sub B_Export_Click(sender As Object, e As RoutedEventArgs) Handles B_Export.Click
		Dim COFD = New CommonOpenFileDialog With {
			.IsFolderPicker = True}
		If COFD.ShowDialog <> CommonFileDialogResult.Ok Then Exit Sub

	End Sub

	Private Sub L_Drop_Drop(sender As Object, e As DragEventArgs) Handles L_Drop.Drop
		Try
			If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then Exit Sub
			Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
			Config.NBTConfig.FirstID = NBTExporter.ParceID(files(0))
		Catch ex As Exception
		End Try
	End Sub

End Class
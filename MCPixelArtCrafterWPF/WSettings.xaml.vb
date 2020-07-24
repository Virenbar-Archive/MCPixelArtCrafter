Imports MCPACLib
Imports MCPACLib.Helpers
Imports MCPACLib.Helpers.Configuration

Public Class WSettings

	Private Sub B_Cancel_Click(sender As Object, e As RoutedEventArgs)
		Close()
	End Sub

	Private Sub B_OK_Click(sender As Object, e As RoutedEventArgs)
		'Config = CType(DataContext, ConfigType)
		Save()
		Close()
	End Sub

	Private Sub WSettings_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
		DataContext = Config
		WP_MapColors.Children.Clear()
		For Each MC In MapColorsCollection.MapBaseColors
			Dim M As New MapColorCheckBox(MC)
			M.IsChecked = Not Config.BlacklistMC.Contains(MC.ID_str)
			AddHandler M.CheckedChanged, AddressOf MapColorCheckBox_CheckedChanged
			WP_MapColors.Children.Add(M)
		Next

		WP_Selectors.Children.Clear()
		For Each TX In TexturesCollection.Selections
			Dim S = New TextureSelector(TX)
			If Config.ColorToBlock.ContainsKey(TX.ID) Then
				S.Filename = Config.ColorToBlock(TX.ID)
			End If
			AddHandler S.TextureChanged, AddressOf TextureSelector_TextureChanged
			WP_Selectors.Children.Add(S)
		Next
	End Sub

	Private Sub MapColorCheckBox_CheckedChanged(sender As Object, e As EventArgs)
		Dim M = DirectCast(sender, MapColorCheckBox)
		If M.IsChecked And Config.BlacklistMC.Contains(M.ID_str) Then
			Config.BlacklistMC.Remove(M.ID_str)
		ElseIf Not M.IsChecked And Not Config.BlacklistMC.Contains(M.ID_str) Then
			Config.BlacklistMC.Add(M.ID_str)
		End If
	End Sub

	Private Sub TextureSelector_TextureChanged(sender As Object, e As EventArgs)
		Dim ts = DirectCast(sender, TextureSelector)
		If Config.ColorToBlock.ContainsKey(ts.ID) Then
			Config.ColorToBlock(ts.ID) = ts.Filename
		Else
			Config.ColorToBlock.Add(ts.ID, ts.Filename)
		End If
	End Sub

	Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
		Configuration.Load()
		MapColorsCollection.CheckConfig()
		TexturesCollection.CheckConfig()
	End Sub

End Class
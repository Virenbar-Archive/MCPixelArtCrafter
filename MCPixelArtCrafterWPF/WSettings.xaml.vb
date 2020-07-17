Imports MCPACLib
Imports MCPACLib.Helpers
Imports MCPACLib.Helpers.Configuration

Public Class WSettings

	Private Sub B_Cancel_Click(sender As Object, e As RoutedEventArgs)
		Close()
	End Sub

	Private Sub B_OK_Click(sender As Object, e As RoutedEventArgs)
		Save()
		Close()
	End Sub

	Private Sub WSettings_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
		DataContext = Config
		'CB_Lab.IsChecked = Config.LabMode
		'CB_Dither.IsChecked = Config.Dither
		'CB_LabMode.DataBindings.Add(New Binding("Checked",Config,"LabMode"))
		'DGV_MapColors.Rows.Clear()
		'For Each MC In MapColorsCollection.MapBaseColors
		'	Dim i = DGV_MapColors.Rows.Add()

		'	DGV_MapColors.Rows(i).Cells(_ID.Index).Value = MC.ID_str
		'	If Config.BlacklistMC.Contains(MC.ID_str) Then
		'		DGV_MapColors.Rows(i).Cells(_Use.Index).Value = False
		'	Else
		'		DGV_MapColors.Rows(i).Cells(_Use.Index).Value = True
		'	End If

		'	Dim img = New Bitmap(1, 1)
		'	img.SetPixel(0, 0, MC.Color)
		'	DGV_MapColors.Rows(i).Cells(_Color.Index).Value = img
		'	DGV_MapColors.Rows(i).Cells(_Full.Index).Value = MC.Full
		'Next
		WP_MapColors.Children.Clear()
		For Each MC In MapColorsCollection.MapBaseColors
			Dim M As New MapColorCheckBox(MC)
			AddHandler M.CheckedChanged, AddressOf MapColorCheckBox_CheckedChanged
			If Config.BlacklistMC.Contains(MC.ID_str) Then
				M.IsChecked = False
			End If
			WP_MapColors.Children.Add(M)
		Next

		WP_Selectors.Children.Clear()
		For Each TX In TexturesCollection.Selections
			Dim S = New TextureSelector(TX)
			AddHandler S.TextureChanged, AddressOf TextureSelector_TextureChanged
			If Config.ColorToBlock.ContainsKey(TX.ID) Then
				S.Filename = Config.ColorToBlock(TX.ID)
			End If
			WP_Selectors.Children.Add(S)
		Next
	End Sub

	Private Sub MapColorCheckBox_CheckedChanged(sender As Object, e As EventArgs)
		Dim M = DirectCast(sender, MapColorCheckBox)
		If M.IsChecked And Config.BlacklistMC.Contains(M.ID_str) Then
			Config.BlacklistMC.Remove(M.ID_str)
		Else
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
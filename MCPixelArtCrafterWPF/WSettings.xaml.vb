﻿Imports MCPACLib
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

	Private Sub TextureSelector_TextureChanged(sender As Object, e As EventArgs)
		Dim ts = DirectCast(sender, TextureSelector)
		If Config.ColorToBlock.ContainsKey(ts.ID) Then
			Config.ColorToBlock(ts.ID) = ts.Filename
		Else
			Config.ColorToBlock.Add(ts.ID, ts.Filename)
		End If
	End Sub

	'Private Sub DGV_MapColors_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_MapColors.CellValueChanged
	'	If Not DirectCast(sender, Control).Focused Then Exit Sub
	'	If e.ColumnIndex = _Use.Index Then
	'		If CBool(DGV_MapColors.Rows(e.RowIndex).Cells(_Use.Index).Value) Then
	'			Config.BlacklistMC.Remove(CStr(DGV_MapColors.Rows(e.RowIndex).Cells(_ID.Index).Value))
	'		Else
	'			Config.BlacklistMC.Add(CStr(DGV_MapColors.Rows(e.RowIndex).Cells(_ID.Index).Value))
	'		End If
	'	End If
	'End Sub

	'Private Sub CB_LabMode_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Lab.Checked
	'	If Not CType(sender, Control).Focused Then Exit Sub
	'	Config.LabMode = CB_LabMode.Checked
	'End Sub

	'Private Sub CB_Dither_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Dither.CheckedChanged
	'	If Not CType(sender, Control).Focused Then Exit Sub
	'	Config.Dither = CB_Dither.Checked
	'End Sub

	Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
		Configuration.Load()
		MapColorsCollection.CheckConfig()
		TexturesCollection.CheckConfig()
	End Sub

End Class
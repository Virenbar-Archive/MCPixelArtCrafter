Imports MCPACLib
Imports System.IO
Imports Microsoft.Win32
Imports MCPACLib.Data.IO
Imports MCPACLib.Helpers

Public Class WMapPreview
	Private SFD As New SaveFileDialog
	Private ClickedColor As MapColorCount
	Public Property MapResult As MapResult
	Private TextureImage As BitmapImage

	Public Overloads Sub Show(result As MapResult)
		MapResult = result
		Show()
	End Sub

	Private Sub B_Save_Click(sender As Object, e As RoutedEventArgs) Handles B_Save.Click
		SFD.FileName = ""
		SFD.Filter = "PNG|*.png|Export to mcpac|*.mcpac|Export to JSON|*.json"
		If SFD.ShowDialog Then
			Select Case Path.GetExtension(SFD.FileName)
				Case ".png"
					MapResult.Image.Save(SFD.FileName, System.Drawing.Imaging.ImageFormat.Png)
				Case ".mcpac"
					MCPACConverter.SaveToMCPAC(SFD.FileName, MapResult)
				Case ".json"
					File.WriteAllText(SFD.FileName, JSONConverter.ToJSON(MapResult))
			End Select
		End If
	End Sub

	Private Sub CB_Grid_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Grid.Checked, CB_Grid.Unchecked
		'PB.ShowGrid = CB_Grid.IsChecked
		'PB.Invalidate()
	End Sub

	Private Sub PB_Click(sender As Object, e As EventArgs) 'Handles PB.MouseClick
		Console.WriteLine(PB.MousePos.ToString)
		Try
			If Not IsNothing(ClickedColor) Then ClickedColor.Highlight = False
			Dim clr = MapResult(CInt(PB.MousePos.X), CInt(PB.MousePos.Y))
			If IsNothing(clr) Then Exit Sub

			ClickedColor = DirectCast(FLP_UsedColors.FindName("ID" + clr.ID_map.ToString), MapColorCount)
			If ClickedColor IsNot Nothing Then ClickedColor.Highlight = True
		Catch ex As Exception
		End Try
	End Sub

	Private Sub PB_MouseMove(sender As Object, e As MouseEventArgs) Handles PB.MouseMove
		TS_MousePos.Text = String.Format("X:{0}|Y:{1}", PB.MousePos.X, PB.MousePos.Y)
	End Sub

	Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
		PB.Source = MapResult.Image.ToBitmapImage
		PB.GridSpacing = 16
		FLP_UsedColors.Children.Clear()
		For Each ColorCount In MapResult.UsedMapColors
			Dim cc = New MapColorCount(ColorCount)
			FLP_UsedColors.Children.Add(cc)
		Next
	End Sub

	Private Sub Window_Closed(sender As Object, e As EventArgs)
		MapResult = Nothing
		'Windows.Application.Current.MainWindow.Focus()
	End Sub

	Private Sub TC_MV_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles TC_MV.SelectionChanged
		If TextureImage Is Nothing And TI_Texture.IsSelected And TI_Texture.IsEnabled Then
			CreateTexture()
		End If
	End Sub

	Private Async Sub CreateTexture()
		TI_Texture.IsEnabled = False
		TB_Status.Text = "Creating Image"
		TextureImage = (Await MapResultCreator.CreateTextureImage(MapResult)).ToBitmapImage
		PB2.Source = TextureImage
		TB_Status.Text = ""
		TI_Texture.IsEnabled = True
	End Sub

	Private Sub PB2_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles PB2.MouseLeftButtonDown

	End Sub

	Private Sub PB2_MouseMove(sender As Object, e As MouseEventArgs) Handles PB2.MouseMove
		TS_MousePos.Text = String.Format("X:{0}|Y:{1}", PB2.MousePos.X, PB2.MousePos.Y)
	End Sub

	'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
	'	FormTextureView.Show(MapResult)
	'End Sub

End Class
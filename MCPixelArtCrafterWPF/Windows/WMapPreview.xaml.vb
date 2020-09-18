Imports MCPACLib
Imports System.IO
Imports Microsoft.Win32
Imports MCPACLib.Data.IO
Imports MCPACLib.Helpers

Public Class WMapPreview
	Private ClickedMapColor As MapColorCount
	Private ClickedTexture As TextureCount
	Private SFD As New SaveFileDialog
	Private TextureImage As BitmapImage
	Public Property MapResult As MapResult

	Public Overloads Sub Show(result As MapResult)
		MapResult = result
		Show()
		PB.Reset()
	End Sub

	Private Sub B_Save_Click(sender As Object, e As RoutedEventArgs) Handles B_Save.Click
		SFD.FileName = ""
		SFD.Filter = "PNG|*.png|Export to mcpac|*.mcpac|Export to JSON|*.json"
		If SFD.ShowDialog Then
			Select Case Path.GetExtension(SFD.FileName)
				Case ".png"
					If TI_Map.IsSelected Then
						MapResult.Image.Save(SFD.FileName, System.Drawing.Imaging.ImageFormat.Png)
					ElseIf TI_Texture.IsSelected Then
						TextureImage.Save(SFD.FileName)
					End If
				Case ".mcpac"
					MCPACConverter.SaveToMCPAC(SFD.FileName, MapResult)
				Case ".json"
					File.WriteAllText(SFD.FileName, JSONConverter.ToJSON(MapResult))
			End Select
		End If
	End Sub

	Private Async Sub CreateTexture()
		Try
			TI_Texture.IsEnabled = False
			TB_Status.Text = My.Resources.MyStrings.T_TexCr
			Await MapResult.RedoImageTex
			PB2.Source = MapResult.ImageTex.ToBitmapImage
			TB_Status.Text = ""
			TI_Texture.IsEnabled = True
		Catch ex As Exception
			MessageBoxWPF.ShowError(My.Resources.MyStrings.T_TexCrErr)
		End Try
	End Sub

	Private Sub PB_MouseMove(sender As Object, e As MouseEventArgs) Handles PB.MouseMove
		TS_MousePos.Text = String.Format("X:{0}|Y:{1}", PB.MousePos.X, PB.MousePos.Y)
	End Sub

	Private Sub PB_MouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PB.MouseRightButtonUp
		Console.WriteLine(PB.MousePos.ToString)
		Try
			If ClickedMapColor IsNot Nothing Then ClickedMapColor.Highlight = False
			Dim clr = MapResult(PB.MousePos)
			If IsNothing(clr) Then Exit Sub

			ClickedMapColor = DirectCast(LogicalTreeHelper.FindLogicalNode(WP_UsedColors, "ID" + clr.ID_map.ToString), MapColorCount)
			If ClickedMapColor IsNot Nothing Then ClickedMapColor.Highlight = True
		Catch ex As Exception
		End Try
	End Sub

	Private Sub PB2_MouseMove(sender As Object, e As MouseEventArgs) Handles PB2.MouseMove
		TS_MousePos.Text = String.Format("X:{0}|Y:{1}", CInt(PB2.MousePos.X) \ 16, CInt(PB2.MousePos.Y) \ 16)
	End Sub

	Private Sub PB2_MouseRightButtonUp(sender As Object, e As MouseButtonEventArgs) Handles PB2.MouseRightButtonUp
		Console.WriteLine(PB2.MousePos.ToString)
		Try
			If ClickedTexture IsNot Nothing Then ClickedTexture.Highlight = False
			Dim MP = PB2.MousePos
			Dim clr = MapResult(CInt(MP.X) \ 16, CInt(MP.Y) \ 16)
			If IsNothing(clr) Then Exit Sub

			Dim tex = TexturesCollection.ItemTex(clr.ID)
			ClickedTexture = DirectCast(LogicalTreeHelper.FindLogicalNode(WP_UsedTextures, "ID" + tex.Filename), TextureCount)
			If ClickedTexture IsNot Nothing Then ClickedTexture.Highlight = True
		Catch ex As Exception
		End Try
	End Sub

	Private Sub TC_MV_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles TC_MV.SelectionChanged
		If PB2.Source Is Nothing And TI_Texture.IsSelected And TI_Texture.IsEnabled Then
			CreateTexture()
		End If
	End Sub

	Private Sub Window_Closed(sender As Object, e As EventArgs)
		MapResult = Nothing
		'Windows.Application.Current.MainWindow.Focus()
	End Sub

	Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
		PB.Source = MapResult.Image.ToBitmapImage
		WP_UsedColors.Children.Clear()
		WP_UsedTextures.Children.Clear()
		For Each ColorCount In MapResult.UsedMapColors
			Dim cc = New MapColorCount(ColorCount)
			WP_UsedColors.Children.Add(cc)
			Dim tc = New TextureCount(ColorCount)
			WP_UsedTextures.Children.Add(tc)
		Next
		PB.InvalidateVisual()
		PB.Reset()
	End Sub

	'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
	'	FormTextureView.Show(MapResult)
	'End Sub

End Class
Imports System.IO

Namespace Data.IO

	Public Class FileSaver

		''' <summary>
		'''   _o
		'''  //\_
		''' _/\
		'''   /
		''' </summary>
		''' <param name="map"></param>
		''' <param name="filename"></param>
		Public Shared Sub Save(map As MapResult, filename As String)
			Select Case Path.GetExtension(filename)
				Case ".png"
					'If TI_Map.IsSelected Then
					'	MapResult.Image.Save(filename, Drawing.Imaging.ImageFormat.Png)
					'ElseIf TI_Texture.IsSelected Then
					'	TextureImage.Save(filename)
					'End If
				Case ".mcpac"
					MCPACConverter.SaveToMCPAC(filename, map)
				Case ".json"
					File.WriteAllText(filename, JSONConverter.ToJSON(map))
			End Select
		End Sub

	End Class
End Namespace
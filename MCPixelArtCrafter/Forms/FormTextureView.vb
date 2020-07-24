Imports MCPACLib.Helpers
Imports MCPACLib

Public Class FormTextureView
	Private Map As MapResult
	Private Image As Bitmap

	Public Overloads Sub Show(imap As MapResult)
		Map = imap
		Show()
	End Sub

	Private Sub FormTextureView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Image = New Bitmap(Map.Width * 16, Map.Height * 16)
		Dim G = Graphics.FromImage(Image)
		For y = 0 To Map.Height - 1
			For x = 0 To Map.Width - 1
				G.DrawImage(TexturesCollection.Item(Map(x, y).ID), x * 16, y * 16)
			Next
		Next
		PB_PAZ.SetImage(Image)
	End Sub

End Class
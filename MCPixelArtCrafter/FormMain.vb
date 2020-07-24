Imports System.IO
Imports System.Reflection
Imports MCPACLib.Data.IO
Imports MCPACLib.Helpers
Imports MCPACLib

Public Class FormMain
	Private ImagePath As String, InputImage As Bitmap
	Private Task As Task(Of MapResult), CTS As Threading.CancellationTokenSource
	Private Progress As IProgress(Of Integer) = New Progress(Of Integer)(Sub(val) SH.Count = val)
	Private WithEvents SH As New StatusHelper(50)

	Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Text += " (v" + Assembly.GetEntryAssembly().GetName().Version.ToString + ")"
		OFD.Filter = "Image Files|*.PNG;*.BMP;*.JPG;*.GIF|Import mcpac|*.mcpac|Import JSON|*.json|All files (*.*)|*.*"
		CType(PB, Control).AllowDrop = True

		SetImage(Path.GetFullPath("DefaultImage.png"))
		Configuration.Load()
		MapColorsCollection.Load()
		TexturesCollection.Load()
	End Sub

	Private Sub Bt_Settings_Click(sender As Object, e As EventArgs) Handles Bt_Settings.Click
		FormSettings.ShowDialog()
	End Sub

	Private Sub SelectImage_Click(sender As Object, e As EventArgs) Handles SelectImage.Click
		If OFD.ShowDialog() = DialogResult.OK Then
			Select Case Path.GetExtension(OFD.FileName)
				Case ".mcpac"
					Dim Result = MCPACConverter.LoadFromMCPAC(OFD.FileName)
					MapPreview.Close()
					MapPreview.MapResult = Result
					MapPreview.Show()
				Case ".json"                    'JSONConverter.l
				Case Else : SetImage(OFD.FileName)
			End Select
		End If
	End Sub

	Private Sub SetImage(ImagePath As String)
		Try
			ImagePathText.Text = ImagePath
			InputImage = New Bitmap(ImagePath)
			PB.SetImage(InputImage)
			SH.Amount = InputImage.Width * InputImage.Height : TSProgressBar.Maximum = SH.Amount
		Catch ex As Exception
			MessageBox.Show("Can't load image: " + ImagePath, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub UpdateProgress() Handles SH.Tick
		'TSProgressBar.Value = SH.Count
		AnimationLabel.Text = SH.NextFrame
		lbl_Progress.Text = SH.Progress
		lbl_Elapsed.Text = SH.Elapsed
	End Sub

	Private Sub ColorModeChanged(sender As Object, e As EventArgs) Handles RB_Staircase.CheckedChanged, RB_Flat.CheckedChanged, RB_All.CheckedChanged
		If RB_Flat.Checked Then
			MapColorsCollection.ColorTypes = {MapColor.Type.Normal}
		ElseIf RB_Staircase.Checked Then
			MapColorsCollection.ColorTypes = {MapColor.Type.Normal, MapColor.Type.Up, MapColor.Type.Down}
		ElseIf RB_All.Checked Then
			MapColorsCollection.ColorTypes = {MapColor.Type.Normal, MapColor.Type.Up, MapColor.Type.Down, MapColor.Type.Dark}
		End If
		If CType(sender, Control).Focused Then MapColorsCollection.CheckConfig()
	End Sub

	Private Sub PB_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles PB.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effect = DragDropEffects.Copy
		Else
			e.Effect = DragDropEffects.None
		End If
	End Sub

	Private Sub PB_DragDrop(sender As Object, e As DragEventArgs) Handles PB.DragDrop
		SetImage(CType(e.Data.GetData(DataFormats.FileDrop), String()).First)
	End Sub

	Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
		If Not SH.IsActive Then
			Create.Text = My.Resources.MyStrings.B_Cancel
			RunGenerator()
		Else
			CTS.Cancel()
		End If
	End Sub

	Private Async Sub RunGenerator()
		SH.Start()
		'Dim result As IResult = IIf(RB_Map.Checked, New MapResult, Nothing)
		Dim result As MapResult
		CTS = New Threading.CancellationTokenSource
		Task = MapResultCreator.Generate(InputImage, Progress, CTS.Token)
		Try
			result = Await Task
			lbl_Elapsed.Text = SH.Elapsed
			'MapPreview.MapResult = result
			'MapPreview.Show()
		Catch ex As OperationCanceledException
			lbl_Elapsed.Text = "Canceled"
			Exit Sub
		Catch ex As Exception
			lbl_Elapsed.Text = "Error"
			Exit Sub
		Finally
			SH.Stop()
			Task.Dispose()
			CTS.Dispose()
			Create.Text = "Create image"
		End Try
		MapPreview.Close()
		MapPreview.MapResult = result
		MapPreview.Show()
	End Sub

End Class
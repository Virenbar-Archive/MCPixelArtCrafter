Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports MCPACLib
Imports MCPACLib.Data.IO
Imports MCPACLib.Helpers
Imports Microsoft.Win32
Imports Microsoft.WindowsAPICodePack.Taskbar

Class WMain
	Private ImagePath As String, InputImage As Bitmap
	Private Task As Task(Of MapResult), CTS As Threading.CancellationTokenSource
	Private Progress As IProgress(Of Integer) = New Progress(Of Integer)(Sub(val) SH.Count = val)
	Private WithEvents SH As New StatusHelper(50)
	Private OFD As New OpenFileDialog

	Public Sub New()

		' Этот вызов является обязательным для конструктора.
		InitializeComponent()

		' Добавить код инициализации после вызова InitializeComponent().
		Rot.Wait()
		Rot.Work()
	End Sub

	Private Sub WMain_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
		Dim V = Assembly.GetEntryAssembly().GetName().Version
		Title += $" (v{V.Major}.{V.Minor}.{V.Build})"
		OFD.Filter = "Image Files|*.PNG;*.BMP;*.JPG;*.GIF|Import mcpac|*.mcpac|Import JSON|*.json|All files (*.*)|*.*"
		PB.AllowDrop = True

		SetImage(Path.GetFullPath("DefaultImage.png"))
		Configuration.LoadConfig()
		MapColorsCollection.Load()
		TexturesCollection.Load()
	End Sub

	Private Sub B_Settings_Click(sender As Object, e As EventArgs)
		Dim s = New WSettings
		s.ShowDialog()
	End Sub

	Private Sub B_Select_Click(sender As Object, e As EventArgs) Handles B_Select.Click
		If OFD.ShowDialog() Then
			Select Case Path.GetExtension(OFD.FileName)
				Case ".mcpac"
					Dim Result = MCPACConverter.LoadFromMCPAC(OFD.FileName)
					Dim MP = New WMapPreview
					MP.Show(Result)
				Case ".json"                    'JSONConverter.l
				Case Else : SetImage(OFD.FileName)
			End Select
		End If
	End Sub

	Private Sub SetImage(ImagePath As String)
		Try
			ImagePathText.Text = ImagePath
			InputImage = New Bitmap(ImagePath)
			PB.Source = New BitmapImage(New Uri(ImagePath))
			SH.Amount = InputImage.Width * InputImage.Height : PB_Progress.Maximum = SH.Amount
		Catch ex As Exception
			MessageBox.Show("Can't load image: " + ImagePath, "", MessageBoxButton.OK, MessageBoxImage.Error)
		End Try
	End Sub

	Private Sub UpdateProgress() Handles SH.Tick
		PB_Progress.Value = SH.Count
		lbl_Progress.Text = SH.Progress
		lbl_Elapsed.Text = SH.Elapsed
	End Sub

	Private Sub ColorModeChanged(sender As Object, e As EventArgs) Handles RB_Staircase.Checked, RB_Flat.Checked, RB_All.Checked
		If RB_Flat.IsChecked Then
			MapColorsCollection.ColorTypes = {MapColor.Type.Normal}
		ElseIf RB_Staircase.IsChecked Then
			MapColorsCollection.ColorTypes = {MapColor.Type.Normal, MapColor.Type.Up, MapColor.Type.Down}
		ElseIf RB_All.IsChecked Then
			MapColorsCollection.ColorTypes = {MapColor.Type.Normal, MapColor.Type.Up, MapColor.Type.Down, MapColor.Type.Dark}
		End If
		If CType(sender, Control).IsFocused Then MapColorsCollection.CheckConfig()
	End Sub

	Private Sub PB_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles PB.DragEnter
		If e.Data.GetDataPresent(DataFormats.FileDrop) Then
			e.Effects = DragDropEffects.Copy
		Else
			e.Effects = DragDropEffects.None
		End If
	End Sub

	Private Sub PB_DragDrop(sender As Object, e As DragEventArgs) Handles PB.Drop
		SetImage(CType(e.Data.GetData(DataFormats.FileDrop), String()).First)
	End Sub

	Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
		If Not SH.IsActive Then
			Create.Content = My.Resources.MyStrings.B_Cancel
			RunGenerator()
		Else
			CTS.Cancel()
		End If
	End Sub

	Public Sub Start()

	End Sub

	Public Sub Cancel()

	End Sub

	Public Sub [Stop]()

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
			Create.Content = My.Resources.MyStrings.B_CreateImage
		End Try
		Dim MP = New WMapPreview
		MP.Show(result)
	End Sub

End Class
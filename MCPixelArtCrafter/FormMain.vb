Imports System.IO

Public Class FormMain
    Private ImagePath As String
    Private InputImage As Bitmap
    Dim Progress As IProgress(Of Integer) = New Progress(Of Integer)(Sub(val) Count = val)
    Private frame = 0 : Private Count = 0 : Private Amount = 0
    Private Frames As Char() = {"|", "/", "-", "\"}

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetImage(Path.GetFullPath("DefaultImage.png"))
        MapColorsCollection.Load()
    End Sub

    Private Sub Bt_Settings_Click(sender As Object, e As EventArgs) Handles Bt_Settings.Click
        FormSettings.ShowDialog()
    End Sub

    Private Sub SelectImage_Click(sender As Object, e As EventArgs) Handles SelectImage.Click
        If OFD.ShowDialog() = DialogResult.OK Then
            SetImage(OFD.FileName)
        End If
    End Sub

    Private Sub SetImage(ImagePath As String)
        ImagePathText.Text = ImagePath
        InputImage = New Bitmap(ImagePath)
        PB.SetImage(InputImage)
        Amount = InputImage.Width * InputImage.Height
    End Sub

    Private Sub UpdateProgress() Handles ProgressTimer.Tick
        TSProgressBar.Value = Count
        lbl_Progress.Text = "Progress: " + Format(Count, "N0") + "\" + Format(Amount, "N0") + " (" + Format(Count / Amount, "P") + ")"
    End Sub
    Private Sub Animate() Handles ProgressTimer.Tick
        AnimationLabel.Text = Frames(frame)
        frame = (frame + 1) Mod 4
    End Sub
    Private Async Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        Amount = InputImage.Width * InputImage.Height : TSProgressBar.Maximum = Amount
        Dim sw = Stopwatch.StartNew()
        ProgressTimer.Start()

        Dim map As New MapResult
        Await map.Generate(InputImage, Progress)

        ProgressTimer.Stop()
        lbl_Elapsed.Text = "Elapsed: " + Format(sw.Elapsed.TotalSeconds, "N0") + "s"

        MapPreview.MapResult = map
        MapPreview.ShowDialog()
    End Sub

End Class

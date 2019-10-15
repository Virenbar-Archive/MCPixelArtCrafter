Imports System.IO

Public Class FormMain
    Private ImagePath As String, InputImage As Bitmap
    Private Task As Task, CTS As Threading.CancellationTokenSource
    Dim Progress As IProgress(Of Integer) = New Progress(Of Integer)(Sub(val) SH.Count = val)
    Private WithEvents SH As New StatusHelper(50)

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OFD.Filter = "Image Files|*.PNG;*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"

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
        Try
            ImagePathText.Text = ImagePath
            InputImage = New Bitmap(ImagePath)
            PB.SetImage(InputImage)
            SH.Amount = InputImage.Width * InputImage.Height : TSProgressBar.Maximum = SH.Amount
        Catch ex As Exception
            MessageBox.Show("Can't load image: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateProgress() Handles SH.Tick
        'TSProgressBar.Value = SH.Count
        AnimationLabel.Text = SH.NextFrame
        lbl_Progress.Text = SH.Progress
        lbl_Elapsed.Text = SH.Elapsed
    End Sub

    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        If Not SH.IsActive Then
            Create.Text = "Cancel"
            RunGenerator()
        Else
            CTS.Cancel()
        End If
    End Sub

    Private Async Sub RunGenerator()
        SH.Start()
        Dim result As IResult = IIf(RB_Map.Checked, New MapResult, Nothing)
        CTS = New Threading.CancellationTokenSource
        Task = result.Generate(InputImage, Progress, CTS.Token)
        Try
            Await Task
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

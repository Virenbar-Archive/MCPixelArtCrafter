Imports System.IO
Imports Newtonsoft.Json
Public Class FormMain
    Dim ImagePath As String
    Dim InputImage As Bitmap
    'Dim MCC As New MapColorsCollection
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetImage(Path.GetFullPath("DefaultImage.png"))
        'MCC.Load()
        MapColorsCollection.Load()
        'JsonConvert.DeserializeObject(Of Block)("")
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
        InputImage = New Bitmap(ImagePath)
        PB.SetImage(InputImage)
        TextBox1.Text = ImagePath
        'PanAndZoomPictureBox1.Image = InputImage
    End Sub

    Private Sub Create_Click(sender As Object, e As EventArgs) Handles Create.Click
        MapPreview.Generate(InputImage)
        MapPreview.ShowDialog()
        'AboutBox1.Show()
    End Sub
End Class

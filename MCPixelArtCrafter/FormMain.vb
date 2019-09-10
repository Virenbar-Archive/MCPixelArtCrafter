Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Newtonsoft.Json

Public Class FormMain
    Dim ImagePath As String
    Dim InputImage As Bitmap
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetImage(Path.GetFullPath("DefaultImage.png"))

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
        SmartPB1.SetImage(InputImage)
        TextBox1.Text = ImagePath
    End Sub
End Class

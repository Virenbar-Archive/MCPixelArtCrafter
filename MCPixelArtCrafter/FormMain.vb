Imports System.Runtime.Serialization.json
Public Class FormMain
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Bt_Settings_Click(sender As Object, e As EventArgs) Handles Bt_Settings.Click
        FormSettings.ShowDialog()
    End Sub

    Private Sub Zoom(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseWheel
        'e.Delta
    End Sub
End Class

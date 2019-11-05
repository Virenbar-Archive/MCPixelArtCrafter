Imports System.ComponentModel

Public Class MapPreview
    Public Property MapResult As MapResult

    Private Sub MapPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PB.SetImage(MapResult.OutImage)
        PB.GridSpacing = 16
        FLP_UsedColors.Controls.Clear()
        For Each ColorCount In MapResult.UsedMapColors
            Dim cc = New MapColorCount(ColorCount)
            cc.SetToolTip(TT_Color)
            FLP_UsedColors.Controls.Add(cc)
            'TT_Color.SetToolTip(cc, cc.Blocks)
        Next
    End Sub

    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click
        If SFD.ShowDialog = DialogResult.OK Then
            MapResult.OutImage.Save(SFD.FileName, Imaging.ImageFormat.Png)
        End If
    End Sub

    Private Sub CB_Grid_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Grid.CheckedChanged
        PB.ShowGrid = CB_Grid.Checked
        PB.Invalidate()
    End Sub

    Private Sub MapPreview_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MapResult = Nothing
    End Sub

    Private Sub PB_Click(sender As Object, e As EventArgs) Handles PB.Click
        Console.WriteLine(PB.MousePos.ToString)
    End Sub

    Private Sub PB_MouseMove(sender As Object, e As MouseEventArgs) Handles PB.MouseMove
        TS_MousePos.Text = String.Format("X:{0}|Y:{1}", PB.MousePos.X, PB.MousePos.Y)
    End Sub
End Class
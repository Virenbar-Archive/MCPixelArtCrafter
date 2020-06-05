Imports System.ComponentModel
Imports System.IO
Imports MCPixelArtCrafter.Data.IO

Public Class MapPreview
    Private ClickedColor As MapColorCount
    Public Property MapResult As MapResult

    Private Sub B_Save_Click(sender As Object, e As EventArgs) Handles B_Save.Click
        SFD.FileName = ""
        SFD.Filter = "PNG|*.png|Export to mcpac|*.mcpac|Export to JSON|*.json"
        If SFD.ShowDialog = DialogResult.OK Then
            Select Case Path.GetExtension(SFD.FileName)
                Case ".png"
                    MapResult.Image.Save(SFD.FileName, Imaging.ImageFormat.Png)
                Case ".mcpac"
                    MCPACConverter.SaveToMCPAC(SFD.FileName, MapResult)
                Case ".json"
                    File.WriteAllText(SFD.FileName, JSONConverter.ToJSON(MapResult))
            End Select
        End If
    End Sub

    Private Sub CB_Grid_CheckedChanged(sender As Object, e As EventArgs) Handles CB_Grid.CheckedChanged
        PB.ShowGrid = CB_Grid.Checked
        PB.Invalidate()
    End Sub

    Private Sub MapPreview_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        FormMain.Focus()
    End Sub

    Private Sub MapPreview_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MapResult = Nothing
    End Sub

    Private Sub MapPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PB.SetImage(MapResult.Image)
        PB.GridSpacing = 16
        FLP_UsedColors.Controls.Clear()
        For Each ColorCount In MapResult.UsedMapColors
            Dim cc = New MapColorCount(ColorCount)
            cc.SetToolTip(TT_Color)
            FLP_UsedColors.Controls.Add(cc)
            'TT_Color.SetToolTip(cc, cc.Blocks)
        Next
    End Sub

    Private Sub PB_Click(sender As Object, e As EventArgs) Handles PB.MouseClick
        Console.WriteLine(PB.MousePos.ToString)
        Try
            If Not IsNothing(ClickedColor) Then ClickedColor.Highlight = False
            Dim clr = MapResult(PB.MousePos)
            If IsNothing(clr) Then Exit Sub
            If FLP_UsedColors.Controls.ContainsKey(clr.ID_map.ToString) Then
                ClickedColor = FLP_UsedColors.Controls(clr.ID_map.ToString)
                ClickedColor.Highlight = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PB_MouseMove(sender As Object, e As MouseEventArgs) Handles PB.MouseMove
        TS_MousePos.Text = String.Format("X:{0}|Y:{1}", PB.MousePos.X, PB.MousePos.Y)
    End Sub

End Class
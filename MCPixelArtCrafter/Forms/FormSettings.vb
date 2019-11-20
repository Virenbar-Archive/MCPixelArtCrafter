Imports System.ComponentModel

Public Class FormSettings
    Private Sub FormSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CB_LabMode.Checked = Config.LabMode

        DGV_MapColors.Rows.Clear()
        For Each MC In MapColorsCollection.MapColorsFull
            Dim i = DGV_MapColors.Rows.Add()

            DGV_MapColors.Rows(i).Cells(_ID.Index).Value = MC.ID_str
            If Config.BlacklistMC.Contains(MC.ID_str) Then
                DGV_MapColors.Rows(i).Cells(_Use.Index).Value = False
            Else
                DGV_MapColors.Rows(i).Cells(_Use.Index).Value = True
            End If

            Dim img = New Bitmap(1, 1)
            img.SetPixel(0, 0, MC.Color)
            DGV_MapColors.Rows(i).Cells(_Color.Index).Value = img
            DGV_MapColors.Rows(i).Cells(_Full.Index).Value = MC.Full
        Next
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_MapColors.CellValueChanged
        If Not CType(sender, Control).Focused Then Exit Sub
        If e.ColumnIndex = _Use.Index Then
            If DGV_MapColors.Rows(e.RowIndex).Cells(_Use.Index).Value Then
                Config.BlacklistMC.Remove(DGV_MapColors.Rows(e.RowIndex).Cells(_ID.Index).Value)
            Else
                Config.BlacklistMC.Add(DGV_MapColors.Rows(e.RowIndex).Cells(_ID.Index).Value)
            End If
        End If
    End Sub

    Private Sub FormSettings_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MapColorsCollection.CheckConfig()
        Settings.Save()
    End Sub

    Private Sub CB_LabMode_CheckedChanged(sender As Object, e As EventArgs) Handles CB_LabMode.CheckedChanged
        If Not CType(sender, Control).Focused Then Exit Sub
        Config.LabMode = CB_LabMode.Checked
    End Sub

    Private Sub B_Cancel_Click(sender As Object, e As EventArgs) Handles B_Cancel.Click
        Settings.Load()
        MapColorsCollection.CheckConfig()
        Me.Close()
    End Sub

    Private Sub B_OK_Click(sender As Object, e As EventArgs) Handles B_OK.Click
        Settings.Save()
        MapColorsCollection.CheckConfig()
        Me.Close()
    End Sub
End Class
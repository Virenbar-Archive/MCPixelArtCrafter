Public Class SmartPB
    Dim OldPoint As Point
    Private Sub PB_MouseDown(sender As Object, e As MouseEventArgs) Handles PB.MouseDown
        OldPoint = e.Location
    End Sub

    Private Sub PB_MouseMove(sender As Object, e As MouseEventArgs) Handles PB.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PB.Location += e.Location - OldPoint
        End If
    End Sub

    Private Sub Zoom(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        If e.Delta <> 0 Then
            If e.Delta <= 0 Then
                If PB.Width < Math.Min(PB.Image.Width, MyPanel.ClientSize.Width) Then Exit Sub
            Else
                If PB.Width > PB.Image.Width * 10 Then Exit Sub
            End If

            PB.Width += CInt(PB.Width * e.Delta / 1000)
            PB.Height += CInt(PB.Height * e.Delta / 1000)
        End If
    End Sub

    Public Sub SetImage(_image As Image)
        PB.Image = _image
        PB.Size = _image.Size
        PB.Location = New Point(MyPanel.Width / 2 - PB.Width / 2, MyPanel.Height / 2 - PB.Height / 2)
    End Sub

    Private Sub SetFocus(sender As Object, e As EventArgs) Handles MyPanel.MouseEnter
        Me.Focus()
    End Sub

    Private Sub LeaveSPB(sender As Object, e As EventArgs) Handles MyPanel.MouseLeave

    End Sub
End Class

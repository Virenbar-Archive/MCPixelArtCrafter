Public Class MapPreview
    Private Map(0, 0) As MapColor
    Private OutImage As Bitmap
    Private UsedMapColors As New Dictionary(Of MapColor, Integer)
    Public Sub Generate(ByRef InImage As Bitmap)
        Dim w = InImage.Width
        Dim h = InImage.Height
        ReDim Map(w, h)
        OutImage = New Bitmap(w, h)


        Dim closest As MapColor
        For x = 0 To w - 1
            For y = 0 To h - 1
                If InImage.GetPixel(x, y).A < 256 / 2 Then Continue For
                closest = MapColorsCollection.GetClosest(InImage.GetPixel(x, y))
                Map(x, y) = closest
                OutImage.SetPixel(x, y, closest.Color)
                If Not UsedMapColors.ContainsKey(closest) Then UsedMapColors.Add(closest, 0)
                UsedMapColors(closest) += 1
            Next
        Next
        'MapColorsCollection.GetClosest()
    End Sub

    Private Sub MapPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SmartPB1.SetImage(OutImage)
    End Sub
End Class
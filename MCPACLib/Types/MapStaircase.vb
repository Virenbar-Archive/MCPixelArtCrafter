Public Class MapStaircase

    Public Shared Function Create(res As MapResult) As MapStaircase
        Throw New NotImplementedException
    End Function

    Private Class MapCollumn

        'Public image as Bitmap
        Public Height As Dictionary(Of MapColor, Integer)

        Public ReadOnly UsedMapColors As New Dictionary(Of MapColor, Integer)
    End Class
End Class
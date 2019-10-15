Imports System.Threading

Public Class BlockResult
    Implements IResult

    Public ReadOnly Property OutImage As Bitmap Implements IResult.OutImage

    Public Async Function Generate(Image As Bitmap, progress As IProgress(Of Integer), token As CancellationToken) As Task Implements IResult.Generate
        Throw New NotImplementedException()

    End Function
End Class

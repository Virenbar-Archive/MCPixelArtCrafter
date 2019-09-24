Public Interface IResult
    ReadOnly Property OutImage As Bitmap
    Function Generate(Image As Bitmap, progress As IProgress(Of Integer), token As Threading.CancellationToken) As Task
End Interface

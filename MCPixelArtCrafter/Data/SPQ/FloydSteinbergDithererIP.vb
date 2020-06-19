Imports SimplePaletteQuantizer.Ditherers.ErrorDiffusion
Imports SimplePaletteQuantizer.Helpers

Namespace Data.SPQ
    ''' <summary>
    ''' Floyd Steinberg Ditherer with InPlace = true
    ''' </summary>
    Public Class FloydSteinbergDithererIP
        Inherits FloydSteinbergDitherer

        Public Overrides ReadOnly Property IsInplace As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides Sub OnPrepare()
            MyBase.OnPrepare()
            'CachedMatrix = CreateCoeficientMatrix()
            Dim width = CachedMatrix.GetLength(1)
            Dim height = CachedMatrix.GetLength(0)

            For y = 0 To height - 1
                For x = 0 To width - 1
                    CachedSummedMatrix(y, x) = CSng(CachedMatrix(y, x) / 16)
                Next
            Next
        End Sub

        Protected Overrides Function OnProcessPixel(sourcePixel As Pixel, targetPixel As Pixel) As Boolean
            MyBase.OnProcessPixel(sourcePixel, targetPixel)
            Return True
        End Function

    End Class

End Namespace
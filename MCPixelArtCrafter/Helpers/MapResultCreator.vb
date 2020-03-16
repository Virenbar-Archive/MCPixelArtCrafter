Imports MCPixelArtCrafter.Data.SPQ
Imports SimplePaletteQuantizer.Ditherers
Imports SimplePaletteQuantizer.Ditherers.Ordered
Imports SimplePaletteQuantizer.Ditherers.ErrorDiffusion
Imports SimplePaletteQuantizer.Helpers
Imports SimplePaletteQuantizer.Quantizers

Namespace Helpers
    Public Class MapResultCreator
        Dim targetImage As Image
        Private Shared activeQuantizer As IColorQuantizer = New MapColorQuantizer
        Private Shared activeDitherer As IColorDitherer = New FilterLiteSierra 'New FloydSteinbergDitherer
        Public Shared Async Function CreateMap(image As Image) As Task(Of Object)
            MapColorQuantizer.SetPalette(MapColorsCollection.Palette)
            Dim targetImage = Await Quantize(image.Clone)
            targetImage.Save("D:\test.png", Imaging.ImageFormat.Png)
            Return targetImage
        End Function
        Private Shared Async Function Quantize(img As Image) As Task(Of Image)
            Dim targetImage As Image = Nothing
            Dim sourceImage = img

            ' tries to retrieve an image based on HSB quantization
            Dim parallelTaskCount = If(activeQuantizer.AllowParallel, Convert.ToInt32(1), 1)
            Dim uiScheduler = TaskScheduler.FromCurrentSynchronizationContext()
            Dim colorCount = MapColorsCollection.Palette.Count

            ' disables all the controls And starts running
            Dim before = Now

            ' quantization process
            Dim quantization = Task.Factory.StartNew(
                Sub() targetImage = ImageBuffer.QuantizeImage(sourceImage, activeQuantizer, activeDitherer, colorCount, parallelTaskCount),
                TaskCreationOptions.LongRunning)

            ' finishes after running
            Await quantization.ContinueWith(
                Sub()
                    ' detects operation duration
                    Dim duration = Now - before
                    Dim perPixel = New TimeSpan(duration.Ticks / (sourceImage.Width * sourceImage.Height))

                    ' detects error And color count
                    Dim originalColorCount = activeQuantizer.GetColorCount()
                    Dim nrmsdString = String.Empty

                    ' calculates NRMSD error, if requested
                    If (True) Then
                        Dim nrmsd = ImageBuffer.CalculateImageNormalizedMeanError(sourceImage, targetImage, parallelTaskCount)
                        nrmsdString = String.Format(" (NRMSD = {0:0.#####})", nrmsd)
                    End If

                    ' spits some duration statistics (those actually slow the processing quite a bit, turn them off to make it quicker)
                    ' editSourceInfo.Text = String.Format("Original: {0} colors ({1} x {2})", originalColorCount, sourceImage.Width, sourceImage.Height)
                    ' editTargetInfo.Text = String.Format("Quantized: {0} colors{1}", colorCount, nrmsdString)
                End Sub,
                uiScheduler)
            Return targetImage
        End Function
    End Class
End Namespace

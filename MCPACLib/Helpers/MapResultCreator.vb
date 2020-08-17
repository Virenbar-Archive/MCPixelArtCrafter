Imports System.Drawing
Imports MCPACLib.Data
Imports MCPACLib.Data.SPQ
Imports MCPACLib.Helpers.Configuration
Imports SimplePaletteQuantizer.Ditherers
Imports SimplePaletteQuantizer.Ditherers.ErrorDiffusion
Imports SimplePaletteQuantizer.Helpers
Imports SimplePaletteQuantizer.Quantizers

Namespace Helpers
	Public Class MapResultCreator
		Private Shared activeDitherer As IColorDitherer = New FilterLiteSierra
		Private Shared activeQuantizer As IColorQuantizer = New MapColorQuantizer
		Dim targetImage As Image
		'New FloydSteinbergDitherer

		Public Shared Async Function CreateMap(image As Image) As Task(Of Object)
			MapColorQuantizer.SetPalette(MapColorsCollection.Palette)
			Dim targetImage = Await Quantize(New Bitmap(image))
			targetImage.Save("D:\test.png", Imaging.ImageFormat.Png)
			Return targetImage
		End Function

		Public Shared Async Function Generate(Image As Bitmap, progress As IProgress(Of Integer), token As Threading.CancellationToken) As Task(Of MapResult)
			Dim w = Image.Width
			Dim h = Image.Height
			Dim MR As MapResult
			Using InImage = New DirectBitmap(Image)
				MR = Await Task.Run(
					Function() As MapResult
						Dim closest As MapColor
						Dim Result = New MapResult(w, h)
						For x = 0 To w - 1
							For y = 0 To h - 1
								'progress.Report(x * h + (y + 1))
								If token.IsCancellationRequested Then
									token.ThrowIfCancellationRequested()
								End If
								Dim sPixel = InImage.GetPixel(x, y)
								If sPixel.A < 256 / 2 Then Continue For
								closest = MapColorsCollection.GetClosest(sPixel)

								If Config.Dither Then
									FSDither.ApplyDither(InImage, closest.Color, sPixel, x, y)
								End If

								Result(x, y) = closest
							Next
							progress.Report((x + 1) * h)
						Next
						Result.CountUsedMapColors()
						Result.RedoImage()
						Return Result
					End Function)
			End Using
			Await Task.Delay(1 * 500)
			Return MR
		End Function

		Public Shared Async Function CreateTextureImage(map As MapResult) As Task(Of Bitmap)
			Dim w = map.Width
			Dim h = map.Height
			Return Await Task.Run(
			Function()
				Dim Image = New Bitmap(w * 16, h * 16)
				Using G = Graphics.FromImage(Image)
					G.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
					For y = 0 To h - 1
						For x = 0 To w - 1
							Dim Texture = TexturesCollection.Item(map(x, y).ID)
							If Texture Is Nothing Then
								Using brush = New SolidBrush(map(x, y).Color)
									G.FillRectangle(brush, x * 16, y * 16, 16, 16)
								End Using
							Else
								G.DrawImage(Texture, x * 16, y * 16, 16, 16)
							End If
						Next
					Next
				End Using
				Return Image
			End Function)
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
					Dim perPixel = New TimeSpan(CLng(duration.Ticks / (sourceImage.Width * sourceImage.Height)))

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
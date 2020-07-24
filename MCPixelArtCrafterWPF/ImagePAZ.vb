''' <summary>
''' Image with pan and zoom functionality
''' </summary>
Public Class ImagePAZ
	Inherits Image
	Const _zoomMax As Double = 10
	Private Shared ReadOnly BorderPen As New Pen(New SolidColorBrush(Colors.Black), 1)
	Private Shared ReadOnly DefCursor As Cursor = Cursors.Cross
	Private _mouseDownPosition As Point
	Private _zoomScale, _zoomMin As Double
	Private tX, tY As Double

	Public Sub New()
		SnapsToDevicePixels = True
		RenderOptions.SetBitmapScalingMode(Me, BitmapScalingMode.NearestNeighbor)
	End Sub

	Public Property GridBrush As Brush

	''' <summary>
	''' Grid spacing (0-No grid)
	''' </summary>
	Public Property GridSpacing As Integer = 0

	Public ReadOnly Property MousePos As Point
		Get
			Dim CP = Mouse.GetPosition(Me) + New Vector(1, 1)
			Return New Point(CInt(Math.Ceiling((CP.X - tX) / _zoomScale)),
							 CInt(Math.Ceiling((CP.Y - tY) / _zoomScale)))
		End Get
	End Property

	Public ReadOnly Property OriginPos As Point
		Get
			Return New Point(tX, tY)
		End Get
	End Property

	Public Shared ReadOnly IsShowGridProperty As DependencyProperty = DependencyProperty.Register("IsShowGrid", GetType(Boolean), GetType(ImagePAZ))

	Public Property IsShowGrid() As Boolean
		Get
			Return CBool(GetValue(IsShowGridProperty))
		End Get
		Set(ByVal value As Boolean)
			SetValue(IsShowGridProperty, value)
		End Set
	End Property

	Public Property pp As Pen
	Public Property ShowGrid As Boolean
	Public Property SubGridBrush As Brush

	Protected ReadOnly Property ImageSize As Size
		Get
			Dim b = DirectCast(Source, BitmapSource)
			Return New Size(CInt(Math.Round(b.PixelWidth * _zoomScale)), CInt(Math.Round(b.PixelHeight * _zoomScale)))
		End Get
	End Property

	''' <summary>
	''' Set the new zoom scale for the displayed image
	''' </summary>
	''' <param name="newZoom">The new zoom scale</param>
	''' <param name="fixPoint">The point to be fixed, in display coordinate</param>
	Public Sub SetZoomScale(ByVal newZoom As Double, ByVal fixPoint As Point)
		If Source IsNot Nothing AndAlso _zoomScale <> newZoom Then
			'fixPoint.X = Math.Min(fixPoint.X, CInt((Me.Image.Size.Width * _zoomScale)))
			'fixPoint.Y = Math.Min(fixPoint.Y, CInt((Me.Image.Size.Height * _zoomScale)))
			Dim shiftX As Integer = CInt(-((fixPoint.X - tX) / _zoomScale * (newZoom - _zoomScale)))
			Dim shiftY As Integer = CInt(-((fixPoint.Y - tY) / _zoomScale * (newZoom - _zoomScale)))
			_zoomScale = newZoom
			tX += shiftX
			tY += shiftY
			CheckT()
			InvalidateVisual()
		End If
	End Sub

	Protected Overrides Sub OnPropertyChanged(e As DependencyPropertyChangedEventArgs)
		Select Case e.Property.Name
			Case SourceProperty.Name
				'RenderOptions.SetEdgeMode(Source, EdgeMode.Unspecified)
				'RenderOptions.SetBitmapScalingMode(Source, BitmapScalingMode.NearestNeighbor)
				Reset()
			Case IsShowGridProperty.Name
				InvalidateVisual()
		End Select
		MyBase.OnPropertyChanged(e)
	End Sub

	Protected Overrides Sub OnRender(dc As DrawingContext)
		If Source IsNot Nothing Then

			With dc
				'Dim mode As InterpolationMode = If(_zoomScale < 0, InterpolationMode.Default, InterpolationMode)
				'If .InterpolationMode <> mode Then .InterpolationMode = mode
				'If .PixelOffsetMode <> PixelOffsetMode.Half Then .PixelOffsetMode = PixelOffsetMode.Half
				.DrawRectangle(New SolidColorBrush(Colors.Transparent), Nothing, New Rect(New Point(0, 0), RenderSize))
				.DrawImage(Source, New Rect(OriginPos, ImageSize))
				.DrawRectangle(Nothing, BorderPen, New Rect(OriginPos, ImageSize))
			End With
			If IsShowGrid Then
				If _zoomScale > 7.5 Then DrawGrid(dc, SubGridBrush, GridSpacing \ 16)
				DrawGrid(dc, GridBrush, GridSpacing)
			End If
		Else
			MyBase.OnRender(dc)
		End If

	End Sub

	Protected Overrides Sub OnRenderSizeChanged(sizeInfo As SizeChangedInfo)
		g()
	End Sub

	Private Sub CheckT()
		'd*: Positive - Free client space, Negative - Hidden image space
		Dim dx = RenderSize.Width - ImageSize.Width '* 1 / _zoomScale
		Dim dy = RenderSize.Height - ImageSize.Height '* 1 / _zoomScale
		tX = If(dx > 0, Math.Max(Math.Min(tX, dx), 0), Math.Min(Math.Max(tX, dx), 0))
		tY = If(dy > 0, Math.Max(Math.Min(tY, dy), 0), Math.Min(Math.Max(tY, dy), 0))
	End Sub

	Private Sub DrawGrid(dc As DrawingContext, Optional gridsize As Integer = 1)
		DrawGrid(dc, GridBrush, gridsize)
	End Sub

	Private Sub DrawGrid(dc As DrawingContext, brs As Brush, Optional gridsize As Integer = 1)
		Dim pen = New Pen(brs, 1)
		Dim ZP = New Point(tX, tY),
			X1 = New Point(ZP.X, ZP.Y), X2 = New Point(ZP.X, ZP.Y + ImageSize.Height),
			Y1 = New Point(ZP.X, ZP.Y), Y2 = New Point(ZP.X + ImageSize.Width, ZP.Y)
		Dim delta = gridsize * _zoomScale, Xd As Double = ZP.X, Yd As Double = ZP.Y
		'delta = ImageSize.Width
		For i = 1 To Math.Floor(Source.Width / gridsize)
			'Xd += delta
			X1.Offset(delta, 0) : X2.Offset(delta, 0)
			'X1.X = Xd : X2.X = Xd
			dc.DrawLine(pen, X1, X2)
		Next
		For i = 1 To Math.Floor(Source.Height / gridsize)
			'Yd += delta
			Y1.Offset(0, delta) : Y2.Offset(0, delta)
			'Y1.Y = Yd : Y2.Y = Yd
			dc.DrawLine(pen, Y1, Y2)
		Next
	End Sub

	Private Sub g() 'Handles Me.SizeChanged
		SetZoomMin()
		CheckT()
	End Sub

	Private Sub Reset()
		_zoomScale = 1
		SetZoomMin()
		tX = CInt(RenderSize.Width / 2 - Source.Width / 2)
		tY = CInt(RenderSize.Height / 2 - Source.Height / 2)
	End Sub

	Private Sub SetZoomMin(Optional min As Double = 0)
		_zoomMin = If(min = 0, Math.Min(Math.Min(RenderSize.Width / Source.Width, RenderSize.Height / Source.Height), 1), min)
		_zoomScale = Math.Max(_zoomScale, _zoomMin)
	End Sub

#Region "Mouse Overrides"

	Protected Overrides Sub OnMouseDown(e As MouseButtonEventArgs)
		MyBase.OnMouseDown(e)
	End Sub

	Protected Overrides Sub OnMouseLeftButtonDown(e As MouseButtonEventArgs)
		_mouseDownPosition = e.GetPosition(Me)
		Cursor = Cursors.Hand
		MyBase.OnMouseLeftButtonDown(e)
	End Sub

	Protected Overrides Sub OnMouseLeftButtonUp(e As MouseButtonEventArgs)
		Cursor = DefCursor
		MyBase.OnMouseLeftButtonDown(e)
	End Sub

	Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
		If e.LeftButton = MouseButtonState.Pressed Then
			Dim dV = _mouseDownPosition - e.GetPosition(Me)
			If (dV.X = 0) AndAlso (dV.Y = 0) Then Return

			tX += -dV.X
			tY += -dV.Y
			CheckT()
			_mouseDownPosition = e.GetPosition(Me)
			InvalidateVisual()
		End If
		MyBase.OnMouseMove(e)
	End Sub

	Protected Overrides Sub OnMouseRightButtonDown(e As MouseButtonEventArgs)
		MyBase.OnMouseRightButtonDown(e)
	End Sub

	Protected Overrides Sub OnMouseWheel(e As MouseWheelEventArgs)
		If e.Delta <> 0 Then
			Dim zoom As Double = Math.Max(Math.Min(_zoomScale + _zoomScale * e.Delta / 1000, _zoomMax), _zoomMin)
			If zoom <> _zoomScale Then SetZoomScale(zoom, e.GetPosition(Me))

		End If
		MyBase.OnMouseWheel(e)
	End Sub

#End Region

End Class
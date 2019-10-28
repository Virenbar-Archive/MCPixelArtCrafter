'----------------------------------------------------------------------------
' Based on Emgu.CV.UI.PanAndZoomPictureBox.cs   
'----------------------------------------------------------------------------
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
''' <summary>
''' A picture box with pan and zoom functionality
''' </summary>
Public Class PictureBoxPAZ
    Inherits PictureBox

    Private _panableAndZoomable As Boolean
    Private _zoomScale, _zoomMin As Double
    Private ReadOnly _zoomMax As Double = 10
    Private _mouseDownPosition As Point
    Private _mouseDownButton As MouseButtons
    Private Shared ReadOnly _defaultCursor As Cursor = Cursors.Cross
    Private tX, tY As Integer

    ''' <summary>
    ''' Create a picture box with pan and zoom functionality
    ''' </summary>
    Public Sub New()
        MyBase.New
        _zoomScale = 1
        tX = 0
        tY = 0
        'Enable double buffering
        ResizeRedraw = False
        DoubleBuffered = True
        BorderStyle = BorderStyle.Fixed3D
        PanableAndZoomable = True
    End Sub

    ''' <summary>
    ''' Get or Set the property to enable(disable) Pan and Zoom
    ''' </summary>
    Protected Property PanableAndZoomable As Boolean
        Get
            Return Me._panableAndZoomable
        End Get
        Set
            If (Me._panableAndZoomable <> Value) Then
                Me._panableAndZoomable = Value
                If Me._panableAndZoomable Then
                    AddHandler MouseEnter, AddressOf OnMouseEnter
                    AddHandler MouseWheel, AddressOf OnMouseWheel
                    AddHandler MouseMove, AddressOf OnMouseMove
                    AddHandler MouseDown, AddressOf OnMouseDown
                    AddHandler MouseUp, AddressOf OnMouseUp
                    AddHandler ClientSizeChanged, AddressOf OnResize
                Else
                    RemoveHandler MouseEnter, AddressOf OnMouseEnter
                    RemoveHandler MouseWheel, AddressOf OnMouseWheel
                    RemoveHandler MouseMove, AddressOf OnMouseMove
                    RemoveHandler MouseDown, AddressOf OnMouseDown
                    RemoveHandler MouseUp, AddressOf OnMouseUp
                    RemoveHandler ClientSizeChanged, AddressOf OnResize
                End If
            End If
        End Set
    End Property

    Protected ReadOnly Property ImageSize() As Size
        Get
            Return New Size(CInt(Math.Round(Image.Size.Width * _zoomScale)), CInt(Math.Round(Image.Size.Height * _zoomScale)))
        End Get
    End Property

    ''' <summary>
    ''' Get or Set the interpolation mode for zooming operation
    ''' </summary>
    Public Property InterpolationMode As InterpolationMode = InterpolationMode.NearestNeighbor
    ''' <summary>
    ''' Get or Set drawing of grid
    ''' </summary>
    ''' <returns></returns>
    Public Property ShowGrid As Boolean = False
    ''' <summary>
    ''' Grid spacing (0-No grid)
    ''' </summary>
    Public Property GridSpacing As Integer = 0
    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        If IsDisposed Then Return

        If Image IsNot Nothing Then
            With pe.Graphics
                Dim mode As InterpolationMode = IIf(_zoomScale < 0, InterpolationMode.Default, InterpolationMode)
                If .InterpolationMode <> mode Then .InterpolationMode = mode
                If .PixelOffsetMode <> PixelOffsetMode.Half Then .PixelOffsetMode = PixelOffsetMode.Half
                'DrawBox(pe)
                Using transform As Matrix = .Transform
                    If _zoomScale <> 1.0 Then transform.Scale(_zoomScale, _zoomScale, MatrixOrder.Append)
                    If tX <> 0 OrElse tY <> 0 Then transform.Translate(tX, tY)

                    .Transform = transform
                    MyBase.OnPaint(pe)
                    'DrawBox(pe)
                End Using
            End With
            DrawBox(pe.Graphics)
            If ShowGrid Then DrawGrid(pe.Graphics)
        Else
            MyBase.OnPaint(pe)
        End If
    End Sub
    Private Sub DrawBox(g As Graphics)
        g.ResetTransform()
        Dim p1 = New Point(tX * _zoomScale, tY * _zoomScale)
        Dim p2 = New Point(p1.X + ImageSize.Width, p1.Y)
        Dim p3 = New Point(p1.X + ImageSize.Width, p1.Y + ImageSize.Height)
        Dim p4 = New Point(p1.X, p1.Y + ImageSize.Height)
        'pe.Graphics.DrawLine(New Pen(Color.Black, 1), p1, p2)
        g.DrawLines(New Pen(Color.Black, 1), {p1, p2, p3, p4, p1})
        'pe.Graphics.
    End Sub
    Private Sub DrawGrid(g As Graphics)
        Dim ZP = New Point(tX * _zoomScale, tY * _zoomScale),
            X1 = New Point(ZP), X2 = New Point(ZP.X, ZP.Y + ImageSize.Height),
            Y1 = New Point(ZP), Y2 = New Point(ZP.X + ImageSize.Width, ZP.Y)
        Dim delta = GridSpacing * _zoomScale, Xd As Double = ZP.X, Yd As Double = ZP.Y
        For i = 1 To Math.Floor(Image.Width / GridSpacing) - 1
            Xd += delta
            X1.X = Xd : X2.X = Xd
            g.DrawLine(New Pen(Color.Black, 1), X1, X2)
        Next
        For i = 1 To Math.Floor(Image.Height / GridSpacing) - 1
            Yd += delta
            Y1.Y = Yd : Y2.Y = Yd
            g.DrawLine(New Pen(Color.Black, 1), Y1, Y2)
        Next
    End Sub

    Private Shadows Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Me._mouseDownButton = MouseButtons.Left Then
            Dim shiftX As Integer = (e.X - Me._mouseDownPosition.X) / Me._zoomScale
            Dim shiftY As Integer = (e.Y - Me._mouseDownPosition.Y) / Me._zoomScale
            If (shiftX = 0) AndAlso (shiftY = 0) Then
                Return
            End If

            tX += shiftX
            tY += shiftY
            CheckT()

            If (shiftX <> 0) Then
                _mouseDownPosition.X = e.Location.X
            End If
            If (shiftY <> 0) Then
                _mouseDownPosition.Y = e.Location.Y
            End If

            Invalidate()
        End If
    End Sub

    Private Shadows Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        _mouseDownPosition = e.Location
        _mouseDownButton = e.Button
        If e.Button = MouseButtons.Left Then
            Cursor = Cursors.Hand
        End If
    End Sub

    Private Shadows Sub OnMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Cursor = _defaultCursor
        _mouseDownButton = MouseButtons.None
    End Sub

    Private Shadows Sub OnMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        'set this as the active control 
        Dim f As Form = CType(TopLevelControl, Form)
        If (Not (f) Is Nothing) Then
            f.ActiveControl = Me
        End If
    End Sub

    Private Shadows Sub OnMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Delta <> 0 Then
            Dim zoom As Double = Math.Max(Math.Min(_zoomScale + _zoomScale * e.Delta / 1000, _zoomMax), _zoomMin)
            If zoom <> _zoomScale Then SetZoomScale((zoom), e.Location)
        End If
    End Sub

    Private Shadows Sub OnResize(ByVal sender As Object, ByVal e As EventArgs)
        If Image IsNot Nothing AndAlso ClientSize.Width > 0 AndAlso ClientSize.Height > 0 Then
            SetZoomMin()
            CheckT()
            Invalidate()
        End If
    End Sub
    Private Sub CheckT()
        'd*: Positive - Free client space, Negative - Hidden image space
        Dim dx = (ClientSize.Width - ImageSize.Width) * 1 / _zoomScale
        Dim dy = (ClientSize.Height - ImageSize.Height) * 1 / _zoomScale
        tX = IIf(dx > 0, Math.Max(Math.Min(tX, dx), 0), Math.Min(Math.Max(tX, dx), 0))
        tY = IIf(dy > 0, Math.Max(Math.Min(tY, dy), 0), Math.Min(Math.Max(tY, dy), 0))
    End Sub

    ''' <summary>
    ''' Set the new zoom scale for the displayed image
    ''' </summary>
    ''' <param name="zoomScale">The new zoom scale</param>
    ''' <param name="fixPoint">The point to be fixed, in display coordinate</param>
    Public Sub SetZoomScale(ByVal zoomScale As Double, ByVal fixPoint As Point)
        If Image IsNot Nothing AndAlso _zoomScale <> zoomScale Then
            'fixPoint.X = Math.Min(fixPoint.X, CInt((Me.Image.Size.Width * _zoomScale)))
            'fixPoint.Y = Math.Min(fixPoint.Y, CInt((Me.Image.Size.Height * _zoomScale)))
            Dim shiftX As Integer = (fixPoint.X * (zoomScale - _zoomScale) / zoomScale / _zoomScale)
            Dim shiftY As Integer = (fixPoint.Y * (zoomScale - _zoomScale) / zoomScale / _zoomScale)
            _zoomScale = zoomScale
            tX += -shiftX
            tY += -shiftY
            CheckT()
            Invalidate()
        End If
    End Sub
    ''' <summary>
    ''' Set image and center it
    ''' </summary>
    ''' <param name="_image">Image to set</param>
    Public Sub SetImage(_image As Image)
        Image = _image
        _zoomScale = 1
        SetZoomMin()
        tX = ClientSize.Width / 2 - Image.Width / 2
        tY = ClientSize.Height / 2 - Image.Height / 2
    End Sub

    Private Sub SetZoomMin(Optional min As Double = 0)
        _zoomMin = IIf(min = 0, Math.Min(Math.Min(ClientSize.Width / Image.Width, ClientSize.Height / Image.Height), 1), min)
        _zoomScale = Math.Max(_zoomScale, _zoomMin)
    End Sub
End Class

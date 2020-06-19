'----------------------------------------------------------------------------
' Based on Emgu.CV.UI.PanAndZoomPictureBox.cs
'----------------------------------------------------------------------------
Imports System.Drawing.Drawing2D
Imports System.Windows.Media.Imaging

''' <summary>
''' A picture box with pan and zoom functionality
''' </summary>
Public Class PictureBoxPAZ
    Inherits PictureBox

    Private Shared ReadOnly _defaultCursor As Cursor = Cursors.Cross
    Private ReadOnly _zoomMax As Double = 10
    Private _mouseDownButton As MouseButtons
    Private _mouseDownPosition As Point
    Private _panableAndZoomable As Boolean
    Private _zoomScale, _zoomMin As Double
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

#Region "Properties"

    ''' <summary>
    ''' Grid spacing (0-No grid)
    ''' </summary>
    Public Property GridSpacing As Integer = 0

    ''' <summary>
    ''' Get or Set the interpolation mode for zooming operation
    ''' </summary>
    Public Property InterpolationMode As InterpolationMode = InterpolationMode.NearestNeighbor

    Public ReadOnly Property MousePos As Point
        Get
            Dim CP = PointToClient(MousePosition)
            Return New Point(CInt(Math.Ceiling((CP.X - tX) / _zoomScale)),
                             CInt(Math.Ceiling((CP.Y - tY) / _zoomScale)))
        End Get
    End Property

    Public ReadOnly Property OriginPos As Point
        Get
            Return New Point(tX, tY)
        End Get
    End Property

    ''' <summary>
    ''' Get or Set drawing of grid
    ''' </summary>
    ''' <returns></returns>
    Public Property ShowGrid As Boolean = False

    Protected ReadOnly Property ImageSize As Size
        Get
            Return New Size(CInt(Math.Round(Image.Size.Width * _zoomScale)), CInt(Math.Round(Image.Size.Height * _zoomScale)))
        End Get
    End Property

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

#End Region

    ''' <summary>
    ''' Set image and center it
    ''' </summary>
    ''' <param name="_image">Image to set</param>
    Public Sub SetImage(_image As Image)
        Image = _image
        _zoomScale = 1
        SetZoomMin()
        tX = CInt(ClientSize.Width / 2 - Image.Width / 2)
        tY = CInt(ClientSize.Height / 2 - Image.Height / 2)
    End Sub

    ''' <summary>
    ''' Set the new zoom scale for the displayed image
    ''' </summary>
    ''' <param name="newZoom">The new zoom scale</param>
    ''' <param name="fixPoint">The point to be fixed, in display coordinate</param>
    Public Sub SetZoomScale(ByVal newZoom As Double, ByVal fixPoint As Point)
        If Image IsNot Nothing AndAlso _zoomScale <> newZoom Then
            'fixPoint.X = Math.Min(fixPoint.X, CInt((Me.Image.Size.Width * _zoomScale)))
            'fixPoint.Y = Math.Min(fixPoint.Y, CInt((Me.Image.Size.Height * _zoomScale)))
            Dim shiftX As Integer = CInt(-((fixPoint.X - tX) / _zoomScale * (newZoom - _zoomScale)))
            Dim shiftY As Integer = CInt(-((fixPoint.Y - tY) / _zoomScale * (newZoom - _zoomScale)))
            _zoomScale = newZoom
            tX += shiftX
            tY += shiftY
            CheckT()
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        If IsDisposed Then Return

        If Image IsNot Nothing Then
            With pe.Graphics
                Dim mode As InterpolationMode = If(_zoomScale < 0, InterpolationMode.Default, InterpolationMode)
                If .InterpolationMode <> mode Then .InterpolationMode = mode
                If .PixelOffsetMode <> PixelOffsetMode.Half Then .PixelOffsetMode = PixelOffsetMode.Half
                .DrawImage(Image, New Rectangle(OriginPos, ImageSize))
                .DrawRectangle(New Pen(Color.Black, 1), New Rectangle(OriginPos, ImageSize))
            End With
            If ShowGrid Then
                If _zoomScale > 7.5 Then DrawGrid(pe.Graphics, Color.Gray)
                DrawGrid(pe.Graphics, 16)
            End If
        Else
            MyBase.OnPaint(pe)
        End If
    End Sub

    Private Sub DrawGrid(g As Graphics, Optional gridsize As Integer = 1)
        DrawGrid(g, Color.Black, gridsize)
    End Sub

    Private Sub DrawGrid(g As Graphics, clr As Color, Optional gridsize As Integer = 1)
        Dim ZP = New Point(tX, tY),
            X1 = New Point(ZP.X, ZP.Y), X2 = New Point(ZP.X, ZP.Y + ImageSize.Height),
            Y1 = New Point(ZP.X, ZP.Y), Y2 = New Point(ZP.X + ImageSize.Width, ZP.Y)
        Dim delta = gridsize * _zoomScale, Xd As Double = ZP.X, Yd As Double = ZP.Y

        For i = 1 To Math.Floor(Image.Width / gridsize) - 1
            Xd += delta
            X1.X = CInt(Xd) : X2.X = CInt(Xd)
            g.DrawLine(New Pen(clr, 1), X1, X2)
        Next
        For i = 1 To Math.Floor(Image.Height / gridsize) - 1
            Yd += delta
            Y1.Y = CInt(Yd) : Y2.Y = CInt(Yd)
            g.DrawLine(New Pen(clr, 1), Y1, Y2)
        Next
    End Sub

#Region "Handlers"

    Private Sub CheckT()
        'd*: Positive - Free client space, Negative - Hidden image space
        Dim dx = ClientSize.Width - ImageSize.Width '* 1 / _zoomScale
        Dim dy = ClientSize.Height - ImageSize.Height '* 1 / _zoomScale
        tX = If(dx > 0, Math.Max(Math.Min(tX, dx), 0), Math.Min(Math.Max(tX, dx), 0))
        tY = If(dy > 0, Math.Max(Math.Min(tY, dy), 0), Math.Min(Math.Max(tY, dy), 0))
    End Sub

    Private Shadows Sub OnMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        _mouseDownPosition = e.Location
        _mouseDownButton = e.Button
        If e.Button = MouseButtons.Left Then
            Cursor = Cursors.Hand
        End If
    End Sub

    Private Shadows Sub OnMouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        'set this as the active control
        Dim f As Form = CType(TopLevelControl, Form)
        If Not f Is Nothing Then
            f.ActiveControl = Me
        End If
    End Sub

    Private Shadows Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
        If Me._mouseDownButton = MouseButtons.Left Then
            Dim shiftX As Integer = (e.X - _mouseDownPosition.X)
            Dim shiftY As Integer = (e.Y - _mouseDownPosition.Y)
            If (shiftX = 0) AndAlso (shiftY = 0) Then
                Return
            End If

            tX += shiftX
            tY += shiftY
            CheckT()
            _mouseDownPosition = e.Location
            Invalidate()
        End If
    End Sub

    Private Shadows Sub OnMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Cursor = _defaultCursor
        _mouseDownButton = MouseButtons.None
    End Sub

    Private Shadows Sub OnMouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs)
        If e.Delta <> 0 Then
            Dim zoom As Double = Math.Max(Math.Min(_zoomScale + _zoomScale * e.Delta / 1000, _zoomMax), _zoomMin)
            If zoom <> _zoomScale Then SetZoomScale(zoom, e.Location)
        End If
    End Sub

    Private Shadows Sub OnResize(ByVal sender As Object, ByVal e As EventArgs)
        If Image IsNot Nothing AndAlso ClientSize.Width > 0 AndAlso ClientSize.Height > 0 Then
            SetZoomMin()
            CheckT()
            Invalidate()
        End If
    End Sub

#End Region

    Private Sub SetZoomMin(Optional min As Double = 0)
        _zoomMin = If(min = 0, Math.Min(Math.Min(ClientSize.Width / Image.Width, ClientSize.Height / Image.Height), 1), min)
        _zoomScale = Math.Max(_zoomScale, _zoomMin)
    End Sub

End Class
'TODO: Fix grid - Done
'-Try alternative pixel render https://stackoverflow.com/questions/40498312/c-sharp-create-grid-for-painting-pixels-and-rendering-text
'>>>Or make new bitmap with max zoom and grid
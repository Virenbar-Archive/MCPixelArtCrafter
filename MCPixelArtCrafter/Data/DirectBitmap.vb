Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Namespace Data
    Public Class DirectBitmap
        Implements IDisposable

        Public ReadOnly Property Bitmap As Bitmap
        Public ReadOnly Property Bits As Integer()
        Public ReadOnly Property Disposed As Boolean
        Public ReadOnly Property Height As Integer
        Public ReadOnly Property Width As Integer

        Protected Property BitsHandle As GCHandle

        Public Sub New(iwidth As Integer, iheight As Integer)
            Width = iwidth
            Height = iheight
            Bits = New Integer(iwidth * iheight) {}
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned)
            Bitmap = New Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject())
        End Sub
        Public Sub New(bitmapIn As Bitmap)
            Width = bitmapIn.Width
            Height = bitmapIn.Height
            Bits = New Integer(Width * Height) {}
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned)
            Bitmap = New Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject())
            Using g = Graphics.FromImage(Bitmap)
                g.DrawImage(bitmapIn, New PointF(0, 0))
            End Using
        End Sub

        Public Sub SetPixel(x As Integer, y As Integer, colour As Color)
            Dim Index = x + (y * Width)
            Dim col = colour.ToArgb()

            Bits(Index) = col
        End Sub

        Public Function GetPixel(x As Integer, y As Integer) As Color
            Dim Index = x + (y * Width)
            Dim col = Bits(Index)
            Dim result = Color.FromArgb(col)

            Return result
        End Function

        Public Sub Dispose() Implements IDisposable.Dispose
            If (Disposed) Then Return
            _Disposed = True
            Bitmap.Dispose()
            BitsHandle.Free()
        End Sub
    End Class
End Namespace
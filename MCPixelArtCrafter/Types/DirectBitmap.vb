Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Namespace Data
    Public Class DirectBitmap
        Implements IDisposable

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
                g.DrawImage(bitmapIn, New RectangleF(0, 0, Width, Height))
            End Using
            'Bitmap.Save("D:\test.png", Imaging.ImageFormat.Png)
        End Sub

        Public ReadOnly Property Bitmap As Bitmap
        Public ReadOnly Property Bits As Integer()
        Public ReadOnly Property Disposed As Boolean
        Public ReadOnly Property Height As Integer
        Public ReadOnly Property Width As Integer

        Protected Property BitsHandle As GCHandle

        Public Function GetPixel(x As Integer, y As Integer) As Color
            Dim Index = x + (y * Width)
            Dim col = Bits(Index)
            Dim result = Color.FromArgb(col)

            Return result
        End Function

        Public Sub SetPixel(x As Integer, y As Integer, colour As Color)
            Dim Index = x + (y * Width)
            Dim col = colour.ToArgb()

            Bits(Index) = col
        End Sub

#Region "Disposing"

        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            BitsHandle.Free()
            If disposing Then
                Bitmap.Dispose()
            End If
        End Sub

#End Region

    End Class
End Namespace
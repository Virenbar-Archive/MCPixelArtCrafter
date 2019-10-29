Imports System.Runtime.CompilerServices
Module Extensions
    <Extension>
    Public Function Divide(p As Point, n As Double) As PointF
        Return New PointF(p.X / n, p.Y / n)
    End Function
    <Extension>
    Public Function Multiply(p As Point, n As Double) As PointF
        Return New PointF(p.X * n, p.Y * n)
    End Function
    <Extension>
    Public Function Substract(p1 As Point, p2 As Point) As Point
        Return New Point(p1.X - p2.X, p1.Y - p2.X)
    End Function
End Module

Imports System.Runtime.CompilerServices
Imports System.Reflection

Module Extensions

    <Extension>
    Public Function Divide(p As Point, n As Double) As PointF
        Return New PointF(p.X / n, p.Y / n)
    End Function

    ''' <summary>
    ''' Включает двойную буферизацию
    ''' </summary>
    <Extension()>
    Public Sub DoubleBuffered(Ctrl As Control, Optional setting As Boolean = True)
        Dim CtrlType As Type = Ctrl.GetType()
        Dim propInfo As PropertyInfo = CtrlType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        propInfo.SetValue(Ctrl, setting, Nothing)
    End Sub

    <Extension>
    Public Function Multiply(p As Point, n As Double) As PointF
        Return New PointF(p.X * n, p.Y * n)
    End Function

    <Extension>
    Public Function Substract(p1 As Point, p2 As Point) As Point
        Return New Point(p1.X - p2.X, p1.Y - p2.X)
    End Function

    <Extension>
    Public Function ToByte(val As Integer) As Byte
        If val > Byte.MaxValue Then
            Return Byte.MaxValue
        ElseIf val < 0 Then
            Return Byte.MinValue
        Else
            Return Convert.ToByte(val)
        End If
    End Function

    <Extension>
    Public Function ToByte(val As Single) As Byte
        Return Convert.ToInt32(val).ToByte
    End Function

End Module
Namespace Data
    ''' <summary>
    ''' 2 dimensional list with row major order
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public Class List2D(Of T)
        Private ReadOnly List As List(Of T)

        Sub New(w As Integer, h As Integer)
            Width = w
            Height = h
            List = New List(Of T)(w * h)
        End Sub

        Public ReadOnly Property Height As Integer
        Public ReadOnly Property Width As Integer
        Public ReadOnly Property InlineList As List(Of T)

        Public ReadOnly Property Count As Integer
            Get
                Return List.Count
            End Get
        End Property

        Default Public Property Item(x As Integer, y As Integer) As T
            Get
                Return List(x + y * Width)
            End Get
            Set(value As T)
                List(x + y * Width) = value
            End Set
        End Property

    End Class
End Namespace
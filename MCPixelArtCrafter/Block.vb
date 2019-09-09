Public Class Block
    Public Sub New(_id As String, _name As String, _texture As Image, Optional group As String = "")
        ID = _id
        Name = _name
        Texture = _texture
    End Sub

    Public Property ID() As String
    Public Property Name() As String
    Public Property Texture As Image
    Public Property Color() As Color

End Class

Imports System.IO
Imports System.Text.RegularExpressions

Namespace Helpers
    Public Class TexturesCollection
        Public Shared d As Dictionary(Of Integer, Image)
        Public Shared EmptyImage = New Bitmap(16, 16)
        Public Shared Selections As New List(Of TextureSelection)
        Private Shared FolderRegex = New Regex("(?'ID'\d+)-\w+", RegexOptions.ExplicitCapture)
        Private Shared Textures As Dictionary(Of Integer, Image)

        Public Shared ReadOnly Property Item(id As Integer) As Image
            Get
                Return If(d.ContainsKey(id), d(id), EmptyImage)
            End Get
        End Property

        Public Shared Sub CheckConfig()
            If Config.ColorToBlock.Count = 0 Then
                Dim d As Dictionary(Of Integer, Image) = Selections.ToDictionary(Function(x) x.ID, Function(x) x.List.First.Img)
            Else

            End If
        End Sub

        Public Shared Sub Load(Optional folder As String = "Default")
            Dim TI = Globalization.CultureInfo.CurrentCulture.TextInfo
            Dim files = Directory.GetFiles(folder, "*.png", SearchOption.AllDirectories)
            Dim lists As Lookup(Of String, String) = files.ToLookup(Function(x) Path.GetFileName(Path.GetDirectoryName(x)), Function(x) x)
            For Each group In lists
                Dim m = FolderRegex.Match(group.Key)
                If m.Success Then
                    Dim ID = Integer.Parse(m.Groups("ID").Value)
                    Dim h As List(Of Texture) = group.ToList.ConvertAll(
                        Function(x)
                            Return New Texture With {.Img = New Bitmap(x), .Filename = Path.GetFileNameWithoutExtension(x), .Name = TI.ToTitleCase(String.Join(" ", .Filename.Split("_")))}
                        End Function)
                    Selections.Add(New TextureSelection() With {.ID = ID, .Name = group.Key, .List = h})
                End If
            Next
            Selections.Sort()
            'For Each mc In MapColorsCollection.MapBaseColors
            '    Dim ColorDirectory = Path.Combine(folder, "Textures", $"{mc.ID}-{mc.ID_str}")
            '    Dim ColorTextures = Directory.GetFiles(ColorDirectory, "*.png", SearchOption.AllDirectories)
            '    If ColorTextures.Count = 0 Then Continue For
            '    Dim ff = ColorTextures.ToList.con
            '    Dim TL = New List(Of Texture)
            '    For Each file In ColorTextures
            '        TL.Add(New Texture With {.Img = New Bitmap(file), .Name = Path.GetFileNameWithoutExtension(file)})
            '    Next
            '    d.Add(mc.ID, TL)
            'Next
            CheckConfig()
        End Sub

#Region "Structures"

        Public Structure Texture
            Public Property Filename As String
            Public Property Img As Image
            Public Property Name As String
        End Structure

        Public Structure TextureSelection
            Implements IComparable(Of TextureSelection)
            Public ID As Integer
            Public List As List(Of Texture)
            Public Name As String

            Public Function CompareTo(other As TextureSelection) As Integer Implements IComparable(Of TextureSelection).CompareTo
                Return ID.CompareTo(other.ID)
            End Function

        End Structure

#End Region

    End Class
End Namespace
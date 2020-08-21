Imports MCPACLib
Imports MCPACLib.Helpers

Public Class TextureCount
	Private _highlight As Boolean
	Private ReadOnly Texture As Texture
	'Private ToolTip As ToolTip

	Public Sub New(ByRef _color As Texture, count As Integer)
		InitializeComponent()
		Texture = _color
		Name = "ID" + Texture.Filename
		I_Texture.Source = Texture.Image
		lbl_Count.Content = "x" + Format(count, "N0")
		ToolTip = Texture.Name
	End Sub

	Sub New(ByRef count As KeyValuePair(Of MapColor, Integer))
		InitializeComponent()
		Texture = TexturesCollection.ItemTex(count.Key.ID)
		Name = "ID" + Texture.Filename
		I_Texture.Source = Texture.Image
		'Dim C = Color.FromRgb(count.Key.Color.R, count.Key.Color.G, count.Key.Color.B)
		'I_Texture.Source = New DrawingImage With {.Drawing = New GeometryDrawing(New SolidColorBrush(C), Nothing, New RectangleGeometry(New Rect(0, 0, 16, 16)))}
		lbl_Count.Content = "x" + Format(count.Value, "N0")
		ToolTip = Texture.Name
	End Sub

	Public Property Highlight As Boolean
		Get
			Return _highlight
		End Get
		Set(value As Boolean)
			_highlight = value
			lbl_Count.Foreground = New SolidColorBrush(If(_highlight, Colors.Red, Colors.Black))
		End Set
	End Property

	Sub SetToolTip(ByRef tt As ToolTip)
		'ToolTip = tt
		'Dim text = MapColor.TypeT.ToString + ": " + MapColor.Full
		'ToolTip.SetToolTip(Me, text)
		'ToolTip.SetToolTip(Me.lbl_count, text)
		'ToolTip.SetToolTip(Me.p_color, text)
	End Sub

End Class
Imports MCPACLib

Public Class MapColorCount
	Private _highlight As Boolean
	Private MapColor As MapColor
	'Private ToolTip As ToolTip

	Public Sub New(ByRef _color As MapColor, ByRef count As Integer)
		InitializeComponent()
		MapColor = _color
		Name = MapColor.ID_str
		R_Color.Fill = New SolidColorBrush(Color.FromRgb(MapColor.Color.R, MapColor.Color.G, MapColor.Color.B))
		lbl_Count.Content = "x" + Format(count, "N0")
		ToolTip = MapColor.TypeT.ToString + ": " + MapColor.Full
	End Sub

	Sub New(ByRef count As KeyValuePair(Of MapColor, Integer))
		InitializeComponent()
		MapColor = count.Key
		Name = "ID" + MapColor.ID_map.ToString
		R_Color.Fill = New SolidColorBrush(Color.FromRgb(MapColor.Color.R, MapColor.Color.G, MapColor.Color.B))
		lbl_Count.Content = "x" + Format(count.Value, "N0")
		ToolTip = MapColor.TypeT.ToString + ": " + MapColor.Full
	End Sub

	ReadOnly Property Blocks As String
		Get
			Return MapColor.Full
		End Get
	End Property

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
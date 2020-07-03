Imports MCPACLib

Public Class MapColorCount
	Private _highlight As Boolean
	Private MapColor As MapColor
	Private ToolTip As ToolTip

	Sub New(ByRef _color As MapColor, ByRef count As Integer)
		InitializeComponent()
		MapColor = _color
		Name = MapColor.ID_str
		p_color.BackColor = MapColor.Color
		lbl_count.Text = "x" + Format(count, "N0")
	End Sub

	Sub New(ByRef count As KeyValuePair(Of MapColor, Integer))
		InitializeComponent()
		MapColor = count.Key
		Name = MapColor.ID_map.ToString
		p_color.BackColor = MapColor.Color
		lbl_count.Text = "x" + Format(count.Value, "N0")
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
			lbl_count.ForeColor = If(_highlight, Drawing.Color.Red, DefaultForeColor)
		End Set
	End Property

	Sub SetToolTip(ByRef tt As ToolTip)
		ToolTip = tt
		Dim text = MapColor.TypeT.ToString + ": " + MapColor.Full
		ToolTip.SetToolTip(Me, text)
		ToolTip.SetToolTip(Me.lbl_count, text)
		ToolTip.SetToolTip(Me.p_color, text)
	End Sub

End Class
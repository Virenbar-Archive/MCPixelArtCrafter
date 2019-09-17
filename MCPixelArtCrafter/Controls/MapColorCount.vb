Public Class MapColorCount
    Private Color As MapColor
    Private ToolTip As ToolTip
    ReadOnly Property Blocks As String
        Get
            Return Color.Full
        End Get
    End Property

    Sub New(ByRef _color As MapColor, ByRef count As Integer)
        InitializeComponent()
        Color = _color
        p_color.BackColor = Color.Color
        lbl_count.Text = "x" + Format(count, "N0")
    End Sub
    Sub New(ByRef count As KeyValuePair(Of MapColor, Integer))
        InitializeComponent()
        Color = count.Key
        p_color.BackColor = Color.Color
        lbl_count.Text = "x" + Format(count.Value, "N0")
    End Sub

    Sub SetToolTip(ByRef tt As ToolTip)
        ToolTip = tt
        ToolTip.SetToolTip(Me, Color.Full)
        ToolTip.SetToolTip(Me.lbl_count, Color.Full)
        ToolTip.SetToolTip(Me.p_color, Color.Full)
    End Sub
End Class

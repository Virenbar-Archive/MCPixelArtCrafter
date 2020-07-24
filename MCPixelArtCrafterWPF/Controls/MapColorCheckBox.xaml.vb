Imports MCPACLib

Public Class MapColorCheckBox

	'Public Shared ReadOnly IsCheckedProperty As DependencyProperty = DependencyProperty.Register("IsChecked", GetType(Boolean), GetType(MapColorCheckBox), New PropertyMetadata(True))

	Public Sub New(Color As MapBaseColor)
		InitializeComponent()
		DataContext = Color
		ID_str = Color.ID_str
		Rect.Fill = New SolidColorBrush(Media.Color.FromRgb(Color.Color.R, Color.Color.G, Color.Color.B))
	End Sub

	Public ReadOnly Property ID_str As String

	Public Property IsChecked As Boolean?
		Get
			'Return CBool(GetValue(IsCheckedProperty))
			Return CB.IsChecked
		End Get

		Set(ByVal value As Boolean?)
			'SetValue(IsCheckedProperty, value)
			CB.IsChecked = value
		End Set
	End Property

	Private Sub CB_Click(sender As Object, e As RoutedEventArgs) Handles CB.Click
		RaiseEvent CheckedChanged(Me, New EventArgs)
	End Sub

	Public Event CheckedChanged As EventHandler

End Class
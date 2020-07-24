Imports MCPACLib.Helpers.TexturesCollection
Imports MCPACLib

Public Class TextureSelector
	Public Shared ReadOnly SelectionProperty As DependencyProperty = DependencyProperty.Register("Selection", GetType(TextureSelection), GetType(TextureSelector), New PropertyMetadata(Nothing))

	Public Sub New(s As TextureSelection)
		' Этот вызов является обязательным для конструктора.
		InitializeComponent()

		' Добавить код инициализации после вызова InitializeComponent().
		DataContext = s
		ID = s.ID
		'lbl_ID_str.Content = s.Name
		'CB_Texture.ItemsSource = s.List
		If s.List.Count = 1 Then IsEnabled = False
	End Sub

	Public Property Filename As String
		Get
			Return CStr(CB_Texture.SelectedValue)
		End Get
		Set(value As String)
			CB_Texture.SelectedValue = If(value, "")
		End Set
	End Property

	Public ReadOnly Property ID As Integer

	Public Property Selection As TextureSelection
		Get
			Return DirectCast(GetValue(SelectionProperty), TextureSelection)
		End Get

		Set(ByVal value As TextureSelection)
			SetValue(SelectionProperty, value)
		End Set
	End Property

	Public ReadOnly Property Selection2 As TextureSelection

	Protected Sub OnTextureChanged()
		RaiseEvent TextureChanged(Me, New EventArgs)
	End Sub

	Private Sub CB_Texture_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_Texture.SelectionChanged
		OnTextureChanged()
	End Sub

	Public Event TextureChanged As EventHandler

End Class
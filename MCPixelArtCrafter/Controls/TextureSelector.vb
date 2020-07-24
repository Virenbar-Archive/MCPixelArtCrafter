Imports MCPACLib.Helpers.TexturesCollection
Imports MCPACLib

Public Class TextureSelector
	Public ReadOnly Property ID As Integer

	Public Sub New(s As TextureSelection)
		' Этот вызов является обязательным для конструктора.
		InitializeComponent()

		' Добавить код инициализации после вызова InitializeComponent().
		ID = s.ID
		Lbl_ID_str.Text = s.Name
		TextureBindingSource.DataSource = s.List
		If s.List.Count = 1 Then Enabled = False
		DoubleBuffered = True
		TableLayoutPanel1.DoubleBuffered()
		'CB_Texture.DoubleBuffered()
		PB_Texture.DoubleBuffered()
		'Lbl_ID_str.DoubleBuffered()
	End Sub

	Public Event TextureChanged As EventHandler

	Public Property Filename As String
		Get
			Return DirectCast(CB_Texture.SelectedValue, String)
		End Get
		Set(value As String)
			CB_Texture.SelectedValue = If(value, "")
		End Set
	End Property

	Protected Sub OnTextureChanged()
		RaiseEvent TextureChanged(Me, New EventArgs)
	End Sub

	Private Sub CB_Texture_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_Texture.SelectedValueChanged
		OnTextureChanged()
	End Sub

End Class
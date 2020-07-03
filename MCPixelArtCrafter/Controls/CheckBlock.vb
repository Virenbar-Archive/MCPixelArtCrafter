Imports MCPACLib

Public Class CheckBlock

	Public Property Checked() As Boolean
		Get
			Return CheckBox1.Checked
		End Get
		Set(ByVal value As Boolean)
			CheckBox1.Checked = value
		End Set
	End Property

	Public Property Block() As Block

	Public Sub MySub()
		'PictureBox1.Image.
	End Sub

End Class
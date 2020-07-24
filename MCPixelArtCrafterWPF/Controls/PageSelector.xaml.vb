Public Class PageSelector

	Public Shared ReadOnly CurrentPageProperty As DependencyProperty = DependencyProperty.Register("CurrentPage", GetType(Integer), GetType(PageSelector), New PropertyMetadata(1))

	Public Shared ReadOnly MaxPageProperty As DependencyProperty = DependencyProperty.Register("MaxPage", GetType(Integer), GetType(PageSelector), New PropertyMetadata(1))

	Public Shared ReadOnly TextProperty As DependencyProperty = DependencyProperty.Register("Text", GetType(String), GetType(PageSelector), New PropertyMetadata("Page"))

	Public Event PageChanged()

	Public Property CurrentPage As Integer
		Get
			Return CInt(GetValue(CurrentPageProperty))
		End Get

		Set(ByVal value As Integer)
			SetValue(CurrentPageProperty, Math.Min(MaxPage, value))
		End Set
	End Property

	Public Property MaxPage As Integer
		Get
			Return CInt(GetValue(MaxPageProperty))
		End Get

		Set(ByVal value As Integer)
			SetValue(MaxPageProperty, value)
			If CurrentPage > value Then CurrentPage = value
		End Set
	End Property

	Public Property Text As String
		Get
			Return CStr(GetValue(TextProperty))
		End Get

		Set(ByVal value As String)
			SetValue(TextProperty, value)
		End Set
	End Property

	Protected Sub OnPageChanged()
		RaiseEvent PageChanged()
	End Sub

	Private Sub B_Left_Click(sender As Object, e As RoutedEventArgs) Handles B_Left.Click
		If CurrentPage > 1 Then
			CurrentPage -= 1
			OnPageChanged()
		End If
	End Sub

	Private Sub B_Right_Click(sender As Object, e As RoutedEventArgs) Handles B_Right.Click
		If CurrentPage < MaxPage Then
			CurrentPage += 1
			OnPageChanged()
		End If
	End Sub

End Class
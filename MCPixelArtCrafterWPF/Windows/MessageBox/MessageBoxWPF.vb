Public Class MessageBoxWPF
	Private Shared WithEvents W As WMessageBox
	Private Shared ReadOnly T As String

	Shared Sub New()
		W = New WMessageBox
		T = Reflection.Assembly.GetExecutingAssembly().GetName().Name
		AddHandler W.Closing, AddressOf Window_Closing
	End Sub

	Public Shared Function ShowError(Text As String) As MessageBoxResult
		Return Show(Text, T, MessageBoxButton.OK, MessageBoxImage.Error)
	End Function

	Public Shared Function Show(Text As String) As MessageBoxResult
		Return Show(Text, T, MessageBoxButton.OK, MessageBoxImage.None)
	End Function

	Public Shared Function Show(Text As String, Title As String) As MessageBoxResult
		Return Show(Text, Title, MessageBoxButton.OK, MessageBoxImage.None)
	End Function

	Public Shared Function Show(Text As String, Title As String, Buttons As MessageBoxButton) As MessageBoxResult
		Return Show(Text, Title, Buttons, MessageBoxImage.None)
	End Function

	Public Shared Function Show(Text As String, Title As String, Buttons As MessageBoxButton, Image As MessageBoxImage) As MessageBoxResult
		'W = New WMessageBox
		W.Show(Text, Title, Buttons, Image)
		Return W.Result
	End Function

	Private Shared Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
		W.Visibility = Visibility.Hidden
		e.Cancel = True
	End Sub

End Class
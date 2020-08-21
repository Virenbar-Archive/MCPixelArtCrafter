Imports System.Windows.Interop

Public Class WMessageBox

	Public Shadows Function Show(Text As String, Title As String, Buttons As MessageBoxButton, Image As MessageBoxImage) As MessageBoxResult
		Me.Title = Title
		Me.Text.Text = Text

		Yes.Visibility = If(Buttons = MessageBoxButton.YesNo Or Buttons = MessageBoxButton.YesNoCancel, Visibility.Visible, Visibility.Collapsed)
		No.Visibility = If(Buttons = MessageBoxButton.YesNo Or Buttons = MessageBoxButton.YesNoCancel, Visibility.Visible, Visibility.Collapsed)
		OK.Visibility = If(Buttons = MessageBoxButton.OK Or Buttons = MessageBoxButton.OKCancel, Visibility.Visible, Visibility.Collapsed)
		Cancel.Visibility = If(Buttons = MessageBoxButton.OKCancel Or Buttons = MessageBoxButton.YesNoCancel, Visibility.Visible, Visibility.Collapsed)

		Me.Image.Source = MBItoBS(Image)

		Result = MessageBoxResult.None
		Me.ShowDialog()
		Return Me.Result
	End Function

	Private Shared Function MBItoBS(Image As MessageBoxImage) As BitmapSource
		Dim icon As System.Drawing.Icon
		Select Case CInt(Image)
			Case 16
				icon = System.Drawing.SystemIcons.Hand
			Case 32
				icon = System.Drawing.SystemIcons.Question
			Case 48
				icon = System.Drawing.SystemIcons.Exclamation
			Case 64
				icon = System.Drawing.SystemIcons.Asterisk
			Case Else
				Return Nothing
		End Select
		Return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())
	End Function

	Public Property Result As MessageBoxResult

	Private Sub Cancel_Click(sender As Object, e As RoutedEventArgs) Handles Cancel.Click
		Result = MessageBoxResult.Cancel
		Close()
	End Sub

	Private Sub OK_Click(sender As Object, e As RoutedEventArgs) Handles OK.Click
		Result = MessageBoxResult.OK
		Close()
	End Sub

	Private Sub No_Click(sender As Object, e As RoutedEventArgs) Handles No.Click
		Result = MessageBoxResult.No
		Close()
	End Sub

	Private Sub Yes_Click(sender As Object, e As RoutedEventArgs) Handles Yes.Click
		Result = MessageBoxResult.Yes
		Close()
	End Sub

End Class
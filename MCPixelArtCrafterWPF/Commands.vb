Public Class Commands

	Public Shared Property OpenWAbout As ICommand = New RelayCommand(
		Sub()
			Dim W = New WAbout() With {.Owner = Application.Current.MainWindow}
			W.ShowDialog()
		End Sub)

End Class
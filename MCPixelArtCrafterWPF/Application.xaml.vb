Class Application

	' События приложения, например, Startup, Exit и DispatcherUnhandledException,
	' можно обрабатывать в данном файле.
	Protected Overrides Sub OnStartup(e As StartupEventArgs)
		MyBase.OnStartup(e)
		'Dim WTest = New WStaircase
		'WTest.Show()
	End Sub

End Class
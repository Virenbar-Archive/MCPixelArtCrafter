Imports MCPACLib.Helpers

Class Application

	Public Sub New()

	End Sub

	' События приложения, например, Startup, Exit и DispatcherUnhandledException,
	' можно обрабатывать в данном файле.
	Protected Overrides Sub OnStartup(e As StartupEventArgs)
		MyBase.OnStartup(e)
		'Dim WTest = New WStaircase
		'WTest.Show()
	End Sub

	Protected Overrides Sub OnExit(e As ExitEventArgs)
		Configuration.SaveConfig()
		MyBase.OnExit(e)
	End Sub

End Class
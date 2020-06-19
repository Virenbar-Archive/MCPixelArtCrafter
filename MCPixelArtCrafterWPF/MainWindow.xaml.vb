Class MainWindow

	Public Sub New()

		' Этот вызов является обязательным для конструктора.
		InitializeComponent()

		' Добавить код инициализации после вызова InitializeComponent().
		Ring.Start()
		Rot.Start()
	End Sub

	Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
		Console.WriteLine("Test 1")
		ww()
		Console.WriteLine("Test 2")
	End Sub

	Private Async Sub ww()
		Await Task.Delay(10 * 1000)
		Console.WriteLine("Test 3")
	End Sub

End Class
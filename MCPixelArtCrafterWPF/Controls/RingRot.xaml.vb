Imports System.Runtime.CompilerServices
Imports System.Windows.Media.Animation

Public Class RingRot
	Private Shared WaitColor As Color = DirectCast(ColorConverter.ConvertFromString("#FFFFCC00"), Color)
	Private Shared WorkColor As Color = DirectCast(ColorConverter.ConvertFromString("#FF54CD00"), Color)

	Public Sub New()
		' Этот вызов является обязательным для конструктора.
		InitializeComponent()
		' Добавить код инициализации после вызова InitializeComponent().
	End Sub

	Public Sub Pause()

	End Sub

	Public Sub Wait()
		DirectCast(Resources("AWait"), Storyboard).Begin()
		Resources("RR") = ColorConverter.ConvertFromString("#FFFFF100")
		Resources("RInner") = WaitColor 'ColorConverter.ConvertFromString("#FFFFCC00")
		Resources("ROuter") = WaitColor.CopyColor(0) 'ColorConverter.ConvertFromString("#00FFCC00")
	End Sub

	Public Sub Work()
		DirectCast(Resources("AWork"), Storyboard).Begin()
		Resources("RR") = ColorConverter.ConvertFromString("#FF6CED00")
		Resources("RInner") = WorkColor 'ColorConverter.ConvertFromString("#FF54CD00")
		Resources("ROuter") = WorkColor.CopyColor(0) 'ColorConverter.ConvertFromString("#0054CD00")
	End Sub

End Class
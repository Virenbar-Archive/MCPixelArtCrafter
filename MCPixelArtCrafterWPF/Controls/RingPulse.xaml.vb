Imports System.Windows.Media.Animation

Public Class RingPulse
	Private SB As Storyboard

	Public Sub New()

		' Этот вызов является обязательным для конструктора.
		InitializeComponent()

		' Добавить код инициализации после вызова InitializeComponent().
		SB = DirectCast(Me.FindResource("Animation"), Storyboard)
		'Storyboard.SetTarget(SB, Me.CBT)
	End Sub

	Public Sub [Stop]()
		SB.Stop()
	End Sub

	Public Sub Start()
		SB.Begin()
	End Sub

End Class
Public Class WAbout

	Private Sub Hyperlink_RequestNavigate(sender As Object, e As RequestNavigateEventArgs)
		Process.Start(e.Uri.ToString())
	End Sub

End Class
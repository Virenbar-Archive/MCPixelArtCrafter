Namespace CBSources
	Public Class MCVersionList

		Public Shared ReadOnly Property MCVersionList As New Dictionary(Of MCVersion, String) From {
				{MCVersion.Pre116, "Pre 1.16"},
				{MCVersion.V116, "1.16+"}}

		Public Function Gett() As Dictionary(Of MCVersion, String)
			Return MCVersionList
		End Function

		Shared Sub New()

		End Sub

	End Class
End Namespace
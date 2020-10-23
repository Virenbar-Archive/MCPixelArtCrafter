Namespace CBSources
	Public Class MCVersionList

		Shared ReadOnly list As New Dictionary(Of MCVersion, String) From {
				{MCVersion.Pre116, ""},
				{MCVersion.V116, ""}}

		Public Shared ReadOnly Property MCVersionList As Dictionary(Of MCVersion, String)
			Get
				Return list
			End Get
		End Property

		Public Function Gett() As Dictionary(Of MCVersion, String)
			Return list
		End Function

		Shared Sub New()

		End Sub

	End Class
End Namespace
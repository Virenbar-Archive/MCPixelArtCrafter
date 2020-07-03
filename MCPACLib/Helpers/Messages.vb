Imports System.Windows.Forms

Public Module Messages
	Private ReadOnly Title As String = Reflection.Assembly.GetExecutingAssembly().GetName().Name

	Public Sub ShowInfo(text As String)
		MessageBox.Show(text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
	End Sub

	Public Sub ShowWarning(text As String)
		MessageBox.Show(text, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	End Sub

	Public Sub ShowError(text As String)
		MessageBox.Show(text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
	End Sub

	Public Sub ShowError(prefix As String, ex As Exception)
		MessageBox.Show(prefix.Trim + " " + ex.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
	End Sub

	Public Sub ShowError(ex As Exception)
		MessageBox.Show(ex.Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
	End Sub

	Public Sub ShowErrorStack(ex As Exception)
		MessageBox.Show(ex.Message + vbNewLine + ex.StackTrace, Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
	End Sub

	Public Function AskYesNo(text As String) As DialogResult
		Return MessageBox.Show(text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
	End Function

End Module
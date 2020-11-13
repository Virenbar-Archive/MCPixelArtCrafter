''' <summary>
''' Relay command
''' </summary>
''' <remarks>Отсюда https://www.codeproject.com/script/Articles/ViewDownloads.aspx?aid=32101</remarks>

Public NotInheritable Class RelayCommand
	Implements ICommand

	Private ReadOnly _objCanExecuteMethod As Predicate(Of Object) = Nothing
	Private ReadOnly _objExecuteMethod As Action(Of Object) = Nothing

#Region " Events "

	Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
		AddHandler(ByVal value As EventHandler)
			If _objCanExecuteMethod IsNot Nothing Then
				AddHandler CommandManager.RequerySuggested, value
			End If
		End AddHandler

		RemoveHandler(ByVal value As EventHandler)
			If _objCanExecuteMethod IsNot Nothing Then
				RemoveHandler CommandManager.RequerySuggested, value
			End If
		End RemoveHandler

		RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
			If _objCanExecuteMethod IsNot Nothing Then
				CommandManager.InvalidateRequerySuggested()
			End If
		End RaiseEvent
	End Event

#End Region

#Region " Constructor "

	Public Sub New(ByVal objExecuteMethod As Action(Of Object))
		Me.New(objExecuteMethod, Nothing)
	End Sub

	Public Sub New(ByVal objExecuteMethod As Action(Of Object), ByVal objCanExecuteMethod As Predicate(Of Object))

		If objExecuteMethod Is Nothing Then
			Throw New ArgumentNullException("objExecuteMethod", "Delegate comamnds can not be null")
		End If

		_objExecuteMethod = objExecuteMethod
		_objCanExecuteMethod = objCanExecuteMethod
	End Sub

#End Region

#Region " Methods "

	Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute

		If _objCanExecuteMethod Is Nothing Then
			Return True
		Else
			Return _objCanExecuteMethod(parameter)
		End If

	End Function

	Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute

		If _objExecuteMethod Is Nothing Then
			Return
		Else
			_objExecuteMethod(parameter)
		End If

	End Sub

#End Region

End Class

Public NotInheritable Class RelayCommand(Of T)
	Implements ICommand

	Private ReadOnly _objCanExecuteMethod As Predicate(Of T) = Nothing
	Private ReadOnly _objExecuteMethod As Action(Of T) = Nothing

#Region " Events "

	Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
		AddHandler(ByVal value As EventHandler)

			If _objCanExecuteMethod IsNot Nothing Then
				AddHandler CommandManager.RequerySuggested, value
			End If

		End AddHandler
		'
		RemoveHandler(ByVal value As EventHandler)

			If _objCanExecuteMethod IsNot Nothing Then
				RemoveHandler CommandManager.RequerySuggested, value
			End If

		End RemoveHandler
		'
		RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)

			If _objCanExecuteMethod IsNot Nothing Then
				CommandManager.InvalidateRequerySuggested()
			End If

		End RaiseEvent
	End Event

#End Region

#Region " Constructors "

	Public Sub New(ByVal objExecuteMethod As Action(Of T))
		Me.New(objExecuteMethod, Nothing)
	End Sub

	Public Sub New(ByVal objExecuteMethod As Action(Of T), ByVal objCanExecuteMethod As Predicate(Of T))

		If objExecuteMethod Is Nothing Then
			Throw New ArgumentNullException("objExecuteMethod", "Delegate comamnds can not be null")
		End If

		_objExecuteMethod = objExecuteMethod
		_objCanExecuteMethod = objCanExecuteMethod
	End Sub

#End Region

#Region " Methods "

	Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute

		If _objCanExecuteMethod Is Nothing Then
			Return True
		Else
			Return _objCanExecuteMethod(DirectCast(parameter, T))
		End If

	End Function

	Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
		_objExecuteMethod(DirectCast(parameter, T))
	End Sub

#End Region

End Class
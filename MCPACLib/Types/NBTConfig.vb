Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Public Class NBTConfig
	Implements INotifyPropertyChanged

	Private _FirstID As Integer

	Public Sub New()
		Version = MCVersion.V116
		FirstID = -9000
		CreateIDCounts = False
	End Sub

	Public Property CreateIDCounts As Boolean

	Public Property FirstID As Integer
		Get
			Return _FirstID
		End Get
		Set(value As Integer)
			_FirstID = value
			NotifyPropertyChanged()
		End Set
	End Property

	Public Property Version As MCVersion

	Private Sub NotifyPropertyChanged(<CallerMemberName()> Optional ByVal propertyName As String = Nothing)
		RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
	End Sub

	Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

End Class
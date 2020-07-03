Public Structure TextureSelection
	Implements IComparable(Of TextureSelection)
	Public Property ID As Integer
	Public Property List As List(Of Texture)
	Public Property Name As String

	Public Function CompareTo(other As TextureSelection) As Integer Implements IComparable(Of TextureSelection).CompareTo
		Return ID.CompareTo(other.ID)
	End Function

End Structure
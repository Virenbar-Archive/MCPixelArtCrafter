Public Class ConfigType

	Public Sub New()
		BlacklistMC = New HashSet(Of String)
		ColorToBlock = New Dictionary(Of Integer, String)
		Dither = True
		LabMode = False
		MapType = MapType.Flat
	End Sub

	Public Property BlacklistMC As HashSet(Of String)
	Public Property ColorToBlock As Dictionary(Of Integer, String)
	Public Property Dither As Boolean
	Public Property LabMode As Boolean
	Public Property MapType As MapType
End Class
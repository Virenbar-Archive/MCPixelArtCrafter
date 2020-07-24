Imports SimplePaletteQuantizer.ColorCaches
Imports SimplePaletteQuantizer.ColorCaches.EuclideanDistance
Imports SimplePaletteQuantizer.Quantizers
Imports System.Drawing

Namespace Data.SPQ
	Public Class MapColorQuantizer
		Inherits BaseColorCacheQuantizer
		Private Shared MapColors As List(Of Color)

		Shared Sub New()
		End Sub

		Public Shared Sub SetPalette(colors As List(Of Color))
			MapColors = colors
		End Sub

#Region "BaseColorCacheQuantizer"

		Protected Overrides Function OnCreateDefaultCache() As IColorCache
			Return New EuclideanDistanceColorCache()
		End Function

		Protected Overrides Function OnGetPaletteToCache(colorCount As Integer) As List(Of Color)
			Return MapColors
		End Function

#End Region

#Region "IColorQuantizer"

		Public Overrides ReadOnly Property AllowParallel As Boolean
			Get
				Return True
			End Get
		End Property

#End Region

	End Class
End Namespace
Imports fNbt
Imports MCPACLib.Helpers.Configuration

Namespace Data.IO
	Public Class NBTExporter
		Const MapSize = 16384
		Const MapSide = 128

		Public Shared Sub ExportToMaps(result As MapResult, path As String)
			Dim PM = Prepare(result)
			Dim r = 6 * 60 * 1000
			For i = 0 To PM.XC - 1
				For j = 0 To PM.YC - 1
					Dim map = GetMap(PM, MapSide * i, MapSide * j)
					Dim nbt = MakeMap(map)
					nbt.SaveToFile("", NbtCompression.GZip)
				Next
			Next
			'ii.ArraySaveToFile("", NbtCompression.GZip)
		End Sub

		''' <summary>
		'''
		''' </summary>
		Private Shared Function Prepare(result As MapResult) As PreparedMaps
			Dim S = CountMaps(result)
			Dim PM As New PreparedMaps With {
				.Count = S.C,
				.XC = S.XC,
				.YC = S.YC
			}
			Dim maps = Array.ConvertAll(result.Map, Function(x) x.ID_map)
			If maps.Length Mod 16384 = 0 Then
				PM.Maps = maps
				Return PM
			End If

			Dim colors(MapSize * S.C - 1) As Byte

			Dim w = MapSide * S.XC
			Dim h = MapSide * S.YC

			Dim wOffset = CInt((w - result.Width) / 2)
			Dim hOffset = CInt((h - result.Height) / 2)

			For i = 0 To result.Height - 1
				Array.Copy(maps, i * result.Width, colors, wOffset + (i + hOffset) * w, result.Width)
			Next
			PM.Maps = colors
			Return PM
		End Function

		Private Shared Function GetMap(PM As PreparedMaps, ix As Integer, iy As Integer) As Byte()
			Dim map(MapSize - 1) As Byte
			Dim t = New Byte()
			For y = 0 To MapSide - 1
				Array.Copy(PM.Maps, ix + (iy + y) * MapSide * PM.XC, map, y * MapSide, MapSide)
			Next
			Return map
		End Function

		Public Shared Function MakeMap(map As Byte()) As NbtFile
			Dim DimTag As NbtTag = If(Config.NBTConfig.Version = MCVersion.V116, CType(New NbtString("dimension", "MCPAC"), NbtTag), New NbtByte("dimension", Convert.ToByte(42)))

			Dim MapFile = New NbtFile()
			Dim data = New NbtCompound("data")
			data.Add(New NbtByte("scale", 0))
			data.Add(DimTag)
			'If (Config.NBTConfig.Version = MCVersion.V116) Then
			'	data.Add(New NbtString("dimension", "MCPAC"))
			'Else
			'	data.Add(New NbtByte("dimension", Convert.ToByte(42)))
			'End If
			data.Add(New NbtByte("trackingPosition", Convert.ToByte(0)))
			data.Add(New NbtByte("unlimitedTracking", Convert.ToByte(0)))
			data.Add(New NbtByte("locked", Convert.ToByte(1)))
			data.Add(New NbtInt("xCenter", 0))
			data.Add(New NbtInt("zCenter", 0))
			data.Add(New NbtList("banners"))
			data.Add(New NbtList("frames"))
			data.Add(New NbtByteArray("colors", map))

			MapFile.RootTag.Add(data)
			MapFile.RootTag.Add(New NbtInt("DataVersion", 1343))
			Return MapFile
		End Function

		Public Shared Function ParceID(path As String) As Integer
			Dim nbt = New NbtFile(path)
			Dim id = nbt.RootTag("Data")("map").IntValue
			Return id
		End Function

		''' <summary>
		'''
		''' </summary>
		''' <param name="result"></param>
		''' <returns></returns>
		Public Shared Function CountMaps(result As MapResult) As (XC As Integer, YC As Integer, C As Integer)
			Dim n = CInt(Math.Ceiling(result.Width \ 128))
			Dim m = CInt(Math.Ceiling(result.Height \ 128))
			Return (n, m, n * m)
		End Function

		Public Structure PreparedMaps
			Public Property XC As Integer
			Public Property YC As Integer
			Public Property Count As Integer
			Public Property Maps As Byte()
		End Structure

	End Class
End Namespace
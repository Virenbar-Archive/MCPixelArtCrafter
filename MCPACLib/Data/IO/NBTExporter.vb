Imports fNbt

Namespace Data.IO
    Public Class NBTExporter

        Public Shared Sub ExportToMap(result As MapResult)
            Dim i = result.Width \ 128
            'ii.ArraySaveToFile("", NbtCompression.GZip)
        End Sub

        Public Shared Function MakeMap(map As MapColor()) As NbtFile
            Dim colors(16384) As Byte
            colors = Array.ConvertAll(map, Function(x) x.ID_map)
            Dim MapFile = New NbtFile()
            Dim data = New NbtCompound("data")
            data.Add(New NbtByte("scale", Convert.ToByte(0)))
            data.Add(New NbtByte("dimension", Convert.ToByte(42)))
            data.Add(New NbtByte("trackingPosition", Convert.ToByte(0)))
            data.Add(New NbtByte("unlimitedTracking", Convert.ToByte(0)))
            data.Add(New NbtByte("locked", Convert.ToByte(1)))
            data.Add(New NbtInt("xCenter", 0))
            data.Add(New NbtInt("zCenter", 0))
            data.Add(New NbtList("banners"))
            data.Add(New NbtList("frames"))
            data.Add(New NbtByteArray("colors", colors))

            MapFile.RootTag.Add(data)
            MapFile.RootTag.Add(New NbtInt("DataVersion", 1343))
            Return MapFile
        End Function

    End Class
End Namespace
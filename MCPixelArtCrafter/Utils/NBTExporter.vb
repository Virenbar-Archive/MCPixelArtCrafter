Imports fNbt

Namespace DataIO
    Public Class NBTExporter
        Public Shared Sub ExportToMap(result As MapResult)
            Dim i = result.W \ 128
            'ii.ArraySaveToFile("", NbtCompression.GZip)
        End Sub

        Public Shared Function MakeMap(map As MapColor(,)) As NbtFile
            Dim colors(16384) As Byte
            For y = 0 To 127
                For x = 0 To 127
                    colors(x + y * 128) = map(x, y).ID_map
                Next
            Next
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
            'Dim colors = New NbtByteArray("colors",)

            MapFile.RootTag.Add(data)
            MapFile.RootTag.Add(New NbtInt("DataVersion", 1343))
            Return MapFile
        End Function
    End Class
End Namespace

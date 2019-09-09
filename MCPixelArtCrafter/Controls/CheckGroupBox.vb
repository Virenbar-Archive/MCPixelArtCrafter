Public Class CheckGroupBox
    Public Property Checked() As Boolean
        Get
            Return CB.Checked
        End Get
        Set(ByVal value As Boolean)
            CB.Checked = value
        End Set
    End Property
    Private Sub CB_CheckedChanged(sender As Object, e As EventArgs) Handles CB.CheckedChanged


    End Sub
End Class

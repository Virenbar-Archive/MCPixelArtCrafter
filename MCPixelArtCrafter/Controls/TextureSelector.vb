Imports MCPixelArtCrafter.Helpers.TexturesCollection

Public Class TextureSelector

    Public Sub New(s As TextureSelection)

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавить код инициализации после вызова InitializeComponent().
        TextureBindingSource.DataSource = s.List
        Lbl_ID_str.Text = s.Name
        If s.List.Count = 1 Then Enabled = False
        DoubleBuffered = True
        TableLayoutPanel1.DoubleBuffered()
        CB_Texture.DoubleBuffered()
        PB_Texture.DoubleBuffered
        Lbl_ID_str.DoubleBuffered()
    End Sub

    Private Sub TextureSelector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CB_Texture_SelectedValueChanged(sender As Object, e As EventArgs) Handles CB_Texture.SelectedValueChanged

    End Sub

    Public ReadOnly Property SelectedFile As String
        Get
            Return DirectCast(CB_Texture.SelectedValue, String)
        End Get
    End Property

End Class
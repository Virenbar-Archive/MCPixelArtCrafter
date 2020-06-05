<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextureSelector
    Inherits System.Windows.Forms.UserControl

    'Пользовательский элемент управления (UserControl) переопределяет метод Dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.CB_Texture = New System.Windows.Forms.ComboBox()
        Me.TextureBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Lbl_ID_str = New System.Windows.Forms.Label()
        Me.PB_Texture = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        CType(Me.TextureBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Texture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CB_Texture
        '
        Me.CB_Texture.DataSource = Me.TextureBindingSource
        Me.CB_Texture.DisplayMember = "Name"
        Me.CB_Texture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB_Texture.FormattingEnabled = True
        Me.CB_Texture.Location = New System.Drawing.Point(3, 3)
        Me.CB_Texture.Name = "CB_Texture"
        Me.CB_Texture.Size = New System.Drawing.Size(154, 21)
        Me.CB_Texture.TabIndex = 0
        Me.CB_Texture.ValueMember = "Filename"
        '
        'TextureBindingSource
        '
        Me.TextureBindingSource.DataSource = GetType(MCPixelArtCrafter.Helpers.TexturesCollection.Texture)
        '
        'Lbl_ID_str
        '
        Me.Lbl_ID_str.AutoSize = True
        Me.Lbl_ID_str.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Lbl_ID_str.Location = New System.Drawing.Point(190, 0)
        Me.Lbl_ID_str.Name = "Lbl_ID_str"
        Me.Lbl_ID_str.Size = New System.Drawing.Size(133, 27)
        Me.Lbl_ID_str.TabIndex = 1
        Me.Lbl_ID_str.Text = "eeeeeeeeeeeeeeeeeeeee"
        Me.Lbl_ID_str.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PB_Texture
        '
        Me.PB_Texture.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.TextureBindingSource, "Img", True))
        Me.PB_Texture.Location = New System.Drawing.Point(163, 3)
        Me.PB_Texture.Name = "PB_Texture"
        Me.PB_Texture.Size = New System.Drawing.Size(21, 21)
        Me.PB_Texture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_Texture.TabIndex = 2
        Me.PB_Texture.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.CB_Texture, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Lbl_ID_str, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PB_Texture, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(326, 27)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'TextureSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(0, 21)
        Me.Name = "TextureSelector"
        Me.Size = New System.Drawing.Size(329, 30)
        CType(Me.TextureBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Texture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CB_Texture As ComboBox
    Friend WithEvents Lbl_ID_str As Label
    Friend WithEvents PB_Texture As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TextureBindingSource As BindingSource
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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
        Me.Create = New System.Windows.Forms.Button()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB_Block = New System.Windows.Forms.RadioButton()
        Me.RB_Map = New System.Windows.Forms.RadioButton()
        Me.Bt_Settings = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.SelectImage = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PB = New MCPixelArtCrafter.PictureBoxPAZ()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Create
        '
        Me.Create.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Create.Location = New System.Drawing.Point(344, 435)
        Me.Create.Name = "Create"
        Me.Create.Size = New System.Drawing.Size(118, 23)
        Me.Create.TabIndex = 2
        Me.Create.Text = "Create image"
        Me.Create.UseVisualStyleBackColor = True
        '
        'OFD
        '
        Me.OFD.FileName = "OFD"
        Me.OFD.Filter = "Images|*.png"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.RB_Block)
        Me.GroupBox1.Controls.Add(Me.RB_Map)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 382)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(127, 67)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mode"
        '
        'RB_Block
        '
        Me.RB_Block.AutoSize = True
        Me.RB_Block.Location = New System.Drawing.Point(6, 42)
        Me.RB_Block.Name = "RB_Block"
        Me.RB_Block.Size = New System.Drawing.Size(104, 17)
        Me.RB_Block.TabIndex = 1
        Me.RB_Block.Text = "Use block colors"
        Me.RB_Block.UseVisualStyleBackColor = True
        '
        'RB_Map
        '
        Me.RB_Map.AutoSize = True
        Me.RB_Map.Checked = True
        Me.RB_Map.Location = New System.Drawing.Point(6, 19)
        Me.RB_Map.Name = "RB_Map"
        Me.RB_Map.Size = New System.Drawing.Size(98, 17)
        Me.RB_Map.TabIndex = 0
        Me.RB_Map.TabStop = True
        Me.RB_Map.Text = "Use map colors"
        Me.RB_Map.UseVisualStyleBackColor = True
        '
        'Bt_Settings
        '
        Me.Bt_Settings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Bt_Settings.Location = New System.Drawing.Point(703, 10)
        Me.Bt_Settings.Name = "Bt_Settings"
        Me.Bt_Settings.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Settings.TabIndex = 4
        Me.Bt_Settings.Text = "Settings"
        Me.Bt_Settings.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 461)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(790, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'SelectImage
        '
        Me.SelectImage.Location = New System.Drawing.Point(12, 10)
        Me.SelectImage.Name = "SelectImage"
        Me.SelectImage.Size = New System.Drawing.Size(96, 23)
        Me.SelectImage.TabIndex = 7
        Me.SelectImage.Text = "Select Image"
        Me.SelectImage.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(114, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(583, 20)
        Me.TextBox1.TabIndex = 8
        '
        'PB
        '
        Me.PB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PB.Location = New System.Drawing.Point(12, 39)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(766, 337)
        Me.PB.TabIndex = 9
        Me.PB.TabStop = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(790, 483)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.SelectImage)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Bt_Settings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Create)
        Me.Name = "FormMain"
        Me.Text = "MC PixelArtCrafter"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Create As Button
    Friend WithEvents OFD As OpenFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RB_Block As RadioButton
    Friend WithEvents RB_Map As RadioButton
    Friend WithEvents Bt_Settings As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents SelectImage As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PB As PictureBoxPAZ
End Class

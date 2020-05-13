<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormSettings
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TC_Settings = New System.Windows.Forms.TabControl()
        Me.MapColorsSettings = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DGV_MapColors = New System.Windows.Forms.DataGridView()
        Me._ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._Color = New System.Windows.Forms.DataGridViewImageColumn()
        Me._Use = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me._Full = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BlocksSettings = New System.Windows.Forms.TabPage()
        Me.CheckGroupBox1 = New MCPixelArtCrafter.CheckGroupBox()
        Me.CB_LabMode = New System.Windows.Forms.CheckBox()
        Me.SettingsTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.B_Cancel = New System.Windows.Forms.Button()
        Me.B_OK = New System.Windows.Forms.Button()
        Me.CB_Dither = New System.Windows.Forms.CheckBox()
        Me.TC_Settings.SuspendLayout()
        Me.MapColorsSettings.SuspendLayout()
        CType(Me.DGV_MapColors, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlocksSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'TC_Settings
        '
        Me.TC_Settings.Controls.Add(Me.MapColorsSettings)
        Me.TC_Settings.Controls.Add(Me.BlocksSettings)
        Me.TC_Settings.Dock = System.Windows.Forms.DockStyle.Top
        Me.TC_Settings.Location = New System.Drawing.Point(0, 0)
        Me.TC_Settings.Name = "TC_Settings"
        Me.TC_Settings.SelectedIndex = 0
        Me.TC_Settings.Size = New System.Drawing.Size(800, 376)
        Me.TC_Settings.TabIndex = 1
        '
        'MapColorsSettings
        '
        Me.MapColorsSettings.Controls.Add(Me.Button1)
        Me.MapColorsSettings.Controls.Add(Me.DGV_MapColors)
        Me.MapColorsSettings.Location = New System.Drawing.Point(4, 22)
        Me.MapColorsSettings.Name = "MapColorsSettings"
        Me.MapColorsSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.MapColorsSettings.Size = New System.Drawing.Size(792, 350)
        Me.MapColorsSettings.TabIndex = 0
        Me.MapColorsSettings.Text = "Map Colors"
        Me.MapColorsSettings.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 321)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DGV_MapColors
        '
        Me.DGV_MapColors.AllowUserToAddRows = False
        Me.DGV_MapColors.AllowUserToDeleteRows = False
        Me.DGV_MapColors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_MapColors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me._ID, Me._Color, Me._Use, Me._Full})
        Me.DGV_MapColors.Dock = System.Windows.Forms.DockStyle.Top
        Me.DGV_MapColors.Location = New System.Drawing.Point(3, 3)
        Me.DGV_MapColors.MultiSelect = False
        Me.DGV_MapColors.Name = "DGV_MapColors"
        Me.DGV_MapColors.Size = New System.Drawing.Size(786, 312)
        Me.DGV_MapColors.TabIndex = 0
        '
        '_ID
        '
        Me._ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me._ID.HeaderText = "ID"
        Me._ID.Name = "_ID"
        Me._ID.Visible = False
        '
        '_Color
        '
        Me._Color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me._Color.HeaderText = "Color"
        Me._Color.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me._Color.Name = "_Color"
        Me._Color.Width = 37
        '
        '_Use
        '
        Me._Use.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me._Use.HeaderText = "Use"
        Me._Use.Name = "_Use"
        Me._Use.Width = 32
        '
        '_Full
        '
        Me._Full.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me._Full.HeaderText = "Full Blocks"
        Me._Full.Name = "_Full"
        Me._Full.ReadOnly = True
        Me._Full.Width = 83
        '
        'BlocksSettings
        '
        Me.BlocksSettings.Controls.Add(Me.CheckGroupBox1)
        Me.BlocksSettings.Location = New System.Drawing.Point(4, 22)
        Me.BlocksSettings.Name = "BlocksSettings"
        Me.BlocksSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.BlocksSettings.Size = New System.Drawing.Size(792, 350)
        Me.BlocksSettings.TabIndex = 1
        Me.BlocksSettings.Text = "Blocks"
        Me.BlocksSettings.UseVisualStyleBackColor = True
        '
        'CheckGroupBox1
        '
        Me.CheckGroupBox1.Checked = False
        Me.CheckGroupBox1.Location = New System.Drawing.Point(228, 103)
        Me.CheckGroupBox1.Name = "CheckGroupBox1"
        Me.CheckGroupBox1.Size = New System.Drawing.Size(145, 64)
        Me.CheckGroupBox1.TabIndex = 0
        '
        'CB_LabMode
        '
        Me.CB_LabMode.AutoSize = True
        Me.CB_LabMode.Location = New System.Drawing.Point(12, 421)
        Me.CB_LabMode.Name = "CB_LabMode"
        Me.CB_LabMode.Size = New System.Drawing.Size(64, 17)
        Me.CB_LabMode.TabIndex = 2
        Me.CB_LabMode.Text = "CIE Lab"
        Me.SettingsTT.SetToolTip(Me.CB_LabMode, "Use CIE Lab color space for closest color" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sligtly slower, but better color match" &
        ".")
        Me.CB_LabMode.UseVisualStyleBackColor = True
        '
        'B_Cancel
        '
        Me.B_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.B_Cancel.Location = New System.Drawing.Point(713, 421)
        Me.B_Cancel.Name = "B_Cancel"
        Me.B_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.B_Cancel.TabIndex = 3
        Me.B_Cancel.Text = "Cancel"
        Me.B_Cancel.UseVisualStyleBackColor = True
        '
        'B_OK
        '
        Me.B_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.B_OK.Location = New System.Drawing.Point(632, 421)
        Me.B_OK.Name = "B_OK"
        Me.B_OK.Size = New System.Drawing.Size(75, 23)
        Me.B_OK.TabIndex = 4
        Me.B_OK.Text = "OK"
        Me.B_OK.UseVisualStyleBackColor = True
        '
        'CB_Dither
        '
        Me.CB_Dither.AutoSize = True
        Me.CB_Dither.Location = New System.Drawing.Point(82, 421)
        Me.CB_Dither.Name = "CB_Dither"
        Me.CB_Dither.Size = New System.Drawing.Size(74, 17)
        Me.CB_Dither.TabIndex = 5
        Me.CB_Dither.Text = "Use dither"
        Me.SettingsTT.SetToolTip(Me.CB_Dither, "Use dither")
        Me.CB_Dither.UseVisualStyleBackColor = True
        '
        'FormSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.CB_Dither)
        Me.Controls.Add(Me.B_OK)
        Me.Controls.Add(Me.B_Cancel)
        Me.Controls.Add(Me.CB_LabMode)
        Me.Controls.Add(Me.TC_Settings)
        Me.Name = "FormSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Settings"
        Me.TC_Settings.ResumeLayout(False)
        Me.MapColorsSettings.ResumeLayout(False)
        CType(Me.DGV_MapColors, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlocksSettings.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckGroupBox1 As CheckGroupBox
    Friend WithEvents TC_Settings As TabControl
    Friend WithEvents MapColorsSettings As TabPage
    Friend WithEvents BlocksSettings As TabPage
    Friend WithEvents DGV_MapColors As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents _ID As DataGridViewTextBoxColumn
    Friend WithEvents _Color As DataGridViewImageColumn
    Friend WithEvents _Use As DataGridViewCheckBoxColumn
    Friend WithEvents _Full As DataGridViewTextBoxColumn
    Friend WithEvents CB_LabMode As CheckBox
    Friend WithEvents SettingsTT As ToolTip
    Friend WithEvents B_Cancel As Button
    Friend WithEvents B_OK As Button
    Friend WithEvents CB_Dither As CheckBox
End Class

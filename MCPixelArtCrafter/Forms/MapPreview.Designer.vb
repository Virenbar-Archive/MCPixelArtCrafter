<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MapPreview
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
        Me.FLP_UsedColors = New System.Windows.Forms.FlowLayoutPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PB = New MCPixelArtCrafter.PictureBoxPAZ()
        Me.TT_Color = New System.Windows.Forms.ToolTip(Me.components)
        Me.B_Save = New System.Windows.Forms.Button()
        Me.SFD = New System.Windows.Forms.SaveFileDialog()
        Me.CB_Grid = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TS_MousePos = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FLP_UsedColors
        '
        Me.FLP_UsedColors.AutoScroll = True
        Me.FLP_UsedColors.BackColor = System.Drawing.SystemColors.Control
        Me.FLP_UsedColors.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FLP_UsedColors.Location = New System.Drawing.Point(0, 0)
        Me.FLP_UsedColors.Name = "FLP_UsedColors"
        Me.FLP_UsedColors.Size = New System.Drawing.Size(846, 92)
        Me.FLP_UsedColors.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 12)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PB)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.FLP_UsedColors)
        Me.SplitContainer1.Size = New System.Drawing.Size(848, 450)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 0
        '
        'PB
        '
        Me.PB.BackColor = System.Drawing.SystemColors.Window
        Me.PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB.GridSpacing = 0
        Me.PB.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor
        Me.PB.Location = New System.Drawing.Point(0, 0)
        Me.PB.Name = "PB"
        Me.PB.ShowGrid = False
        Me.PB.Size = New System.Drawing.Size(846, 348)
        Me.PB.TabIndex = 0
        Me.PB.TabStop = False
        '
        'TT_Color
        '
        Me.TT_Color.IsBalloon = True
        '
        'B_Save
        '
        Me.B_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.B_Save.Location = New System.Drawing.Point(781, 475)
        Me.B_Save.Name = "B_Save"
        Me.B_Save.Size = New System.Drawing.Size(78, 23)
        Me.B_Save.TabIndex = 1
        Me.B_Save.Text = "Save image"
        Me.B_Save.UseVisualStyleBackColor = True
        '
        'SFD
        '
        Me.SFD.Filter = "PNG|*.png"
        '
        'CB_Grid
        '
        Me.CB_Grid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CB_Grid.AutoSize = True
        Me.CB_Grid.Location = New System.Drawing.Point(13, 481)
        Me.CB_Grid.Name = "CB_Grid"
        Me.CB_Grid.Size = New System.Drawing.Size(75, 17)
        Me.CB_Grid.TabIndex = 2
        Me.CB_Grid.Text = "Show Grid"
        Me.CB_Grid.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TS_MousePos})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 501)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(872, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TS_MousePos
        '
        Me.TS_MousePos.Name = "TS_MousePos"
        Me.TS_MousePos.Size = New System.Drawing.Size(33, 17)
        Me.TS_MousePos.Text = "X: |Y:"
        '
        'MapPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(872, 523)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CB_Grid)
        Me.Controls.Add(Me.B_Save)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "MapPreview"
        Me.ShowIcon = False
        Me.Text = "Map Preview"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PB As PictureBoxPAZ
    Friend WithEvents FLP_UsedColors As FlowLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TT_Color As ToolTip
    Friend WithEvents B_Save As Button
    Friend WithEvents SFD As SaveFileDialog
    Friend WithEvents CB_Grid As CheckBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TS_MousePos As ToolStripStatusLabel
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.Create = New System.Windows.Forms.Button()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB_Block = New System.Windows.Forms.RadioButton()
        Me.RB_Map = New System.Windows.Forms.RadioButton()
        Me.Bt_Settings = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.AnimationLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_Progress = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_Elapsed = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SelectImage = New System.Windows.Forms.Button()
        Me.ImagePathText = New System.Windows.Forms.TextBox()
        Me.ProgressTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PB = New MCPixelArtCrafter.PictureBoxPAZ()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RB_All = New System.Windows.Forms.RadioButton()
        Me.RB_Staircase = New System.Windows.Forms.RadioButton()
        Me.RB_Flat = New System.Windows.Forms.RadioButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Create
        '
        resources.ApplyResources(Me.Create, "Create")
        Me.Create.Name = "Create"
        Me.Create.UseVisualStyleBackColor = True
        '
        'OFD
        '
        Me.OFD.FileName = "OFD"
        resources.ApplyResources(Me.OFD, "OFD")
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.RB_Block)
        Me.GroupBox1.Controls.Add(Me.RB_Map)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'RB_Block
        '
        resources.ApplyResources(Me.RB_Block, "RB_Block")
        Me.RB_Block.Name = "RB_Block"
        Me.RB_Block.UseVisualStyleBackColor = True
        '
        'RB_Map
        '
        resources.ApplyResources(Me.RB_Map, "RB_Map")
        Me.RB_Map.Checked = True
        Me.RB_Map.Name = "RB_Map"
        Me.RB_Map.TabStop = True
        Me.RB_Map.UseVisualStyleBackColor = True
        '
        'Bt_Settings
        '
        resources.ApplyResources(Me.Bt_Settings, "Bt_Settings")
        Me.Bt_Settings.Name = "Bt_Settings"
        Me.Bt_Settings.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSProgressBar, Me.AnimationLabel, Me.lbl_Progress, Me.lbl_Elapsed})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'TSProgressBar
        '
        Me.TSProgressBar.Name = "TSProgressBar"
        resources.ApplyResources(Me.TSProgressBar, "TSProgressBar")
        '
        'AnimationLabel
        '
        resources.ApplyResources(Me.AnimationLabel, "AnimationLabel")
        Me.AnimationLabel.Name = "AnimationLabel"
        '
        'lbl_Progress
        '
        Me.lbl_Progress.Name = "lbl_Progress"
        resources.ApplyResources(Me.lbl_Progress, "lbl_Progress")
        '
        'lbl_Elapsed
        '
        Me.lbl_Elapsed.Name = "lbl_Elapsed"
        resources.ApplyResources(Me.lbl_Elapsed, "lbl_Elapsed")
        '
        'SelectImage
        '
        resources.ApplyResources(Me.SelectImage, "SelectImage")
        Me.SelectImage.Name = "SelectImage"
        Me.SelectImage.UseVisualStyleBackColor = True
        '
        'ImagePathText
        '
        resources.ApplyResources(Me.ImagePathText, "ImagePathText")
        Me.ImagePathText.Name = "ImagePathText"
        Me.ImagePathText.ReadOnly = True
        '
        'ProgressTimer
        '
        Me.ProgressTimer.Interval = 50
        '
        'PB
        '
        resources.ApplyResources(Me.PB, "PB")
        Me.PB.BackColor = System.Drawing.SystemColors.Control
        Me.PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PB.GridSpacing = 0
        Me.PB.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor
        Me.PB.Name = "PB"
        Me.PB.ShowGrid = False
        Me.PB.TabStop = False
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.RB_All)
        Me.GroupBox2.Controls.Add(Me.RB_Staircase)
        Me.GroupBox2.Controls.Add(Me.RB_Flat)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'RB_All
        '
        resources.ApplyResources(Me.RB_All, "RB_All")
        Me.RB_All.Name = "RB_All"
        Me.ToolTip1.SetToolTip(Me.RB_All, resources.GetString("RB_All.ToolTip"))
        Me.RB_All.UseVisualStyleBackColor = True
        '
        'RB_Staircase
        '
        resources.ApplyResources(Me.RB_Staircase, "RB_Staircase")
        Me.RB_Staircase.Name = "RB_Staircase"
        Me.ToolTip1.SetToolTip(Me.RB_Staircase, resources.GetString("RB_Staircase.ToolTip"))
        Me.RB_Staircase.UseVisualStyleBackColor = True
        '
        'RB_Flat
        '
        resources.ApplyResources(Me.RB_Flat, "RB_Flat")
        Me.RB_Flat.Checked = True
        Me.RB_Flat.Name = "RB_Flat"
        Me.RB_Flat.TabStop = True
        Me.RB_Flat.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.IsBalloon = True
        '
        'FormMain
        '
        Me.AllowDrop = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PB)
        Me.Controls.Add(Me.ImagePathText)
        Me.Controls.Add(Me.SelectImage)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Bt_Settings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Create)
        Me.Name = "FormMain"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents TSProgressBar As ToolStripProgressBar
    Friend WithEvents SelectImage As Button
    Friend WithEvents ImagePathText As TextBox
    Friend WithEvents PB As PictureBoxPAZ
    Friend WithEvents AnimationLabel As ToolStripStatusLabel
    Friend WithEvents lbl_Progress As ToolStripStatusLabel
    Friend WithEvents ProgressTimer As Timer
    Friend WithEvents lbl_Elapsed As ToolStripStatusLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RB_All As RadioButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents RB_Staircase As RadioButton
    Friend WithEvents RB_Flat As RadioButton
End Class

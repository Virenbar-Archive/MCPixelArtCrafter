<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapPreview
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
        Me.PB = New MCPixelArtCrafter.PictureBoxPAZ()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PB
        '
        Me.PB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PB.Location = New System.Drawing.Point(12, 12)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(776, 283)
        Me.PB.TabIndex = 0
        Me.PB.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(222, 319)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(416, 119)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'MapPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.PB)
        Me.Name = "MapPreview"
        Me.ShowIcon = False
        Me.Text = "Map Preview"
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PB As PictureBoxPAZ
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class

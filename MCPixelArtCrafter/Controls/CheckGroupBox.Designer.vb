<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckGroupBox
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
        Me.CB = New System.Windows.Forms.CheckBox()
        Me.GB = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GB.SuspendLayout()
        Me.SuspendLayout()
        '
        'CB
        '
        Me.CB.AutoSize = True
        Me.CB.Location = New System.Drawing.Point(5, 0)
        Me.CB.Name = "CB"
        Me.CB.Size = New System.Drawing.Size(81, 17)
        Me.CB.TabIndex = 0
        Me.CB.Text = "CheckBox1"
        Me.CB.UseVisualStyleBackColor = True
        '
        'GB
        '
        Me.GB.Controls.Add(Me.FlowLayoutPanel1)
        Me.GB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GB.Location = New System.Drawing.Point(0, 0)
        Me.GB.Name = "GB"
        Me.GB.Size = New System.Drawing.Size(517, 339)
        Me.GB.TabIndex = 1
        Me.GB.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(60, 72)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(253, 170)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'CheckGroupBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CB)
        Me.Controls.Add(Me.GB)
        Me.Name = "CheckGroupBox"
        Me.Size = New System.Drawing.Size(517, 339)
        Me.GB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CB As CheckBox
    Friend WithEvents GB As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class

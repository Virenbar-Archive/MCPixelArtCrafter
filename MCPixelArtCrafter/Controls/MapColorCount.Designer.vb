<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MapColorCount
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
        Me.lbl_count = New System.Windows.Forms.Label()
        Me.p_color = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'lbl_count
        '
        Me.lbl_count.AutoSize = True
        Me.lbl_count.Location = New System.Drawing.Point(25, 5)
        Me.lbl_count.Name = "lbl_count"
        Me.lbl_count.Size = New System.Drawing.Size(75, 13)
        Me.lbl_count.TabIndex = 0
        Me.lbl_count.Text = "Color x 10 000"
        '
        'p_color
        '
        Me.p_color.Location = New System.Drawing.Point(3, 3)
        Me.p_color.Name = "p_color"
        Me.p_color.Size = New System.Drawing.Size(16, 16)
        Me.p_color.TabIndex = 1
        '
        'MapColorCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.p_color)
        Me.Controls.Add(Me.lbl_count)
        Me.MaximumSize = New System.Drawing.Size(200, 22)
        Me.MinimumSize = New System.Drawing.Size(110, 22)
        Me.Name = "MapColorCount"
        Me.Size = New System.Drawing.Size(110, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_count As Label
    Friend WithEvents p_color As Panel
End Class

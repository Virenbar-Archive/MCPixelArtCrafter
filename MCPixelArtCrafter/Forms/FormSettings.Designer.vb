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
        Me.CheckGroupBox1 = New MCPixelArtCrafter.CheckGroupBox()
        Me.SuspendLayout()
        '
        'CheckGroupBox1
        '
        Me.CheckGroupBox1.Checked = False
        Me.CheckGroupBox1.Location = New System.Drawing.Point(127, 60)
        Me.CheckGroupBox1.Name = "CheckGroupBox1"
        Me.CheckGroupBox1.Size = New System.Drawing.Size(500, 323)
        Me.CheckGroupBox1.TabIndex = 0
        '
        'FormSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CheckGroupBox1)
        Me.Name = "FormSettings"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CheckGroupBox1 As CheckGroupBox
End Class

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
        Me.SmartPB1 = New MCPixelArtCrafter.SmartPB()
        Me.SuspendLayout()
        '
        'SmartPB1
        '
        Me.SmartPB1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SmartPB1.Location = New System.Drawing.Point(12, 12)
        Me.SmartPB1.Name = "SmartPB1"
        Me.SmartPB1.Size = New System.Drawing.Size(776, 369)
        Me.SmartPB1.TabIndex = 0
        '
        'MapPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SmartPB1)
        Me.Name = "MapPreview"
        Me.ShowIcon = False
        Me.Text = "Map Preview"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SmartPB1 As SmartPB
End Class

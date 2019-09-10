<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmartPB
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
        Me.PB = New System.Windows.Forms.PictureBox()
        Me.MyPanel = New System.Windows.Forms.Panel()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MyPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'PB
        '
        Me.PB.Location = New System.Drawing.Point(217, 146)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(100, 50)
        Me.PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB.TabIndex = 0
        Me.PB.TabStop = False
        '
        'MyPanel
        '
        Me.MyPanel.AutoScroll = True
        Me.MyPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MyPanel.Controls.Add(Me.PB)
        Me.MyPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyPanel.Location = New System.Drawing.Point(0, 0)
        Me.MyPanel.Name = "MyPanel"
        Me.MyPanel.Size = New System.Drawing.Size(610, 369)
        Me.MyPanel.TabIndex = 1
        '
        'SmartPB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MyPanel)
        Me.Name = "SmartPB"
        Me.Size = New System.Drawing.Size(610, 369)
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MyPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PB As PictureBox
    Friend WithEvents MyPanel As Panel
End Class

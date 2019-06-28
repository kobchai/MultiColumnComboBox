<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtMsg2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtMsg4 = New System.Windows.Forms.TextBox()
        Me.MultiColumnComboBox1 = New CustomComboBox.MultiColumnComboBox()
        Me.SuspendLayout()
        '
        'txtMsg2
        '
        Me.txtMsg2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMsg2.Location = New System.Drawing.Point(12, 12)
        Me.txtMsg2.Multiline = True
        Me.txtMsg2.Name = "txtMsg2"
        Me.txtMsg2.ReadOnly = True
        Me.txtMsg2.Size = New System.Drawing.Size(261, 46)
        Me.txtMsg2.TabIndex = 10
        Me.txtMsg2.TabStop = False
        Me.txtMsg2.Text = "AutoComplete set to true. AutoDropdown set to true. Behaves like a DropDown. Hit " & _
    "the number ""2"" and type in a valid Product Code."
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(76, 65)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(190, 20)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.TabStop = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(76, 91)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(190, 20)
        Me.TextBox2.TabIndex = 12
        Me.TextBox2.TabStop = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(76, 117)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(190, 20)
        Me.TextBox3.TabIndex = 13
        Me.TextBox3.TabStop = False
        '
        'txtMsg4
        '
        Me.txtMsg4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMsg4.Location = New System.Drawing.Point(12, 442)
        Me.txtMsg4.Multiline = True
        Me.txtMsg4.Name = "txtMsg4"
        Me.txtMsg4.ReadOnly = True
        Me.txtMsg4.Size = New System.Drawing.Size(563, 21)
        Me.txtMsg4.TabIndex = 14
        Me.txtMsg4.TabStop = False
        Me.txtMsg4.Text = "Hit the <DEL> or <ESC> key to clear a ComboBox. Hit <F3> to search. Hit <F4> to d" & _
    "rop down."
        '
        'MultiColumnComboBox1
        '
        Me.MultiColumnComboBox1.AutoComplete = True
        Me.MultiColumnComboBox1.AutoDropdown = True
        Me.MultiColumnComboBox1.BackColorEven = System.Drawing.Color.LightGray
        Me.MultiColumnComboBox1.BackColorOdd = System.Drawing.Color.White
        Me.MultiColumnComboBox1.ColumnNames = ""
        Me.MultiColumnComboBox1.ColumnWidthDefault = 75
        Me.MultiColumnComboBox1.ColumnWidths = ""
        Me.MultiColumnComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.MultiColumnComboBox1.FormattingEnabled = True
        Me.MultiColumnComboBox1.LinkedColumnIndex1 = 0
        Me.MultiColumnComboBox1.LinkedColumnIndex2 = 1
        Me.MultiColumnComboBox1.LinkedColumnIndex3 = 2
        Me.MultiColumnComboBox1.LinkedTextBox1 = Nothing
        Me.MultiColumnComboBox1.LinkedTextBox2 = Me.TextBox2
        Me.MultiColumnComboBox1.LinkedTextBox3 = Me.TextBox3
        Me.MultiColumnComboBox1.Location = New System.Drawing.Point(13, 65)
        Me.MultiColumnComboBox1.Name = "MultiColumnComboBox1"
        Me.MultiColumnComboBox1.Size = New System.Drawing.Size(57, 21)
        Me.MultiColumnComboBox1.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 475)
        Me.Controls.Add(Me.txtMsg4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.MultiColumnComboBox1)
        Me.Controls.Add(Me.txtMsg2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test Form"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtMsg2 As System.Windows.Forms.TextBox
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MultiColumnComboBox1 As CustomComboBox.MultiColumnComboBox
    Private WithEvents TextBox2 As System.Windows.Forms.TextBox
    Private WithEvents TextBox3 As System.Windows.Forms.TextBox
    Private WithEvents txtMsg4 As System.Windows.Forms.TextBox
End Class

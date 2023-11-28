<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class info
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDomain = New System.Windows.Forms.TextBox()
        Me.txtOSPlatform = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtOS = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtLogon = New System.Windows.Forms.TextBox()
        Me.btnRemote = New System.Windows.Forms.Button()
        Me.btnMapDrives = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtScreen = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnRemote)
        Me.GroupBox1.Controls.Add(Me.btnMapDrives)
        Me.GroupBox1.Location = New System.Drawing.Point(285, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(183, 264)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tools"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtScreen)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtLogon)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtDomain)
        Me.GroupBox2.Controls.Add(Me.txtOSPlatform)
        Me.GroupBox2.Controls.Add(Me.txtUsername)
        Me.GroupBox2.Controls.Add(Me.txtOS)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtIP)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 264)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Information"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Domain"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "OS Platform"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Username:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Operating System:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Computer Name:"
        '
        'txtDomain
        '
        Me.txtDomain.Location = New System.Drawing.Point(100, 71)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.ReadOnly = True
        Me.txtDomain.Size = New System.Drawing.Size(161, 20)
        Me.txtDomain.TabIndex = 36
        '
        'txtOSPlatform
        '
        Me.txtOSPlatform.Location = New System.Drawing.Point(100, 188)
        Me.txtOSPlatform.Name = "txtOSPlatform"
        Me.txtOSPlatform.ReadOnly = True
        Me.txtOSPlatform.Size = New System.Drawing.Size(161, 20)
        Me.txtOSPlatform.TabIndex = 35
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(100, 19)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.ReadOnly = True
        Me.txtUsername.Size = New System.Drawing.Size(161, 20)
        Me.txtUsername.TabIndex = 34
        '
        'txtOS
        '
        Me.txtOS.Location = New System.Drawing.Point(100, 162)
        Me.txtOS.Name = "txtOS"
        Me.txtOS.ReadOnly = True
        Me.txtOS.Size = New System.Drawing.Size(161, 20)
        Me.txtOS.TabIndex = 32
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(100, 45)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(161, 20)
        Me.txtName.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "IP Address:"
        '
        'txtIP
        '
        Me.txtIP.BackColor = System.Drawing.SystemColors.Control
        Me.txtIP.Location = New System.Drawing.Point(100, 97)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.ReadOnly = True
        Me.txtIP.Size = New System.Drawing.Size(161, 20)
        Me.txtIP.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 130)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Logon Server:"
        '
        'txtLogon
        '
        Me.txtLogon.BackColor = System.Drawing.SystemColors.Control
        Me.txtLogon.Location = New System.Drawing.Point(100, 123)
        Me.txtLogon.Name = "txtLogon"
        Me.txtLogon.ReadOnly = True
        Me.txtLogon.Size = New System.Drawing.Size(161, 20)
        Me.txtLogon.TabIndex = 43
        '
        'btnRemote
        '
        Me.btnRemote.Location = New System.Drawing.Point(22, 19)
        Me.btnRemote.Name = "btnRemote"
        Me.btnRemote.Size = New System.Drawing.Size(126, 43)
        Me.btnRemote.TabIndex = 21
        Me.btnRemote.Text = "Launch TeamViewer (Remote Support)"
        Me.btnRemote.UseVisualStyleBackColor = True
        '
        'btnMapDrives
        '
        Me.btnMapDrives.Location = New System.Drawing.Point(22, 68)
        Me.btnMapDrives.Name = "btnMapDrives"
        Me.btnMapDrives.Size = New System.Drawing.Size(126, 23)
        Me.btnMapDrives.TabIndex = 20
        Me.btnMapDrives.Text = "Map Drives"
        Me.btnMapDrives.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 231)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Screen Size:"
        '
        'txtScreen
        '
        Me.txtScreen.Location = New System.Drawing.Point(100, 224)
        Me.txtScreen.Name = "txtScreen"
        Me.txtScreen.ReadOnly = True
        Me.txtScreen.Size = New System.Drawing.Size(161, 20)
        Me.txtScreen.TabIndex = 45
        '
        'info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 291)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "info"
        Me.Text = "Triumph System Info"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDomain As TextBox
    Friend WithEvents txtOSPlatform As TextBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtOS As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIP As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtLogon As TextBox
    Friend WithEvents btnRemote As Button
    Friend WithEvents btnMapDrives As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtScreen As TextBox
End Class

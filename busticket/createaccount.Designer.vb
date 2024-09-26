<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class createaccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(createaccount))
        Me.txtCreateName = New System.Windows.Forms.TextBox()
        Me.lblCreateName = New System.Windows.Forms.Label()
        Me.lblCreateAddress = New System.Windows.Forms.Label()
        Me.lblCreateContact = New System.Windows.Forms.Label()
        Me.lblCreatePassword = New System.Windows.Forms.Label()
        Me.lblCreateEmail = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtCreateAddress = New System.Windows.Forms.TextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtCreatePassword = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtCreateMobile = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtCreateEmail = New System.Windows.Forms.TextBox()
        Me.pnlLeftSide = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.pnlLeftSide.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCreateName
        '
        Me.txtCreateName.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.txtCreateName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateName.ForeColor = System.Drawing.Color.Silver
        Me.txtCreateName.Location = New System.Drawing.Point(24, 20)
        Me.txtCreateName.Name = "txtCreateName"
        Me.txtCreateName.Size = New System.Drawing.Size(238, 23)
        Me.txtCreateName.TabIndex = 1
        Me.txtCreateName.Text = "First Name"
        '
        'lblCreateName
        '
        Me.lblCreateName.AutoSize = True
        Me.lblCreateName.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.lblCreateName.Location = New System.Drawing.Point(1191, 179)
        Me.lblCreateName.Name = "lblCreateName"
        Me.lblCreateName.Size = New System.Drawing.Size(126, 27)
        Me.lblCreateName.TabIndex = 6
        Me.lblCreateName.Text = "Firstname "
        '
        'lblCreateAddress
        '
        Me.lblCreateAddress.AutoSize = True
        Me.lblCreateAddress.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateAddress.Location = New System.Drawing.Point(1191, 296)
        Me.lblCreateAddress.Name = "lblCreateAddress"
        Me.lblCreateAddress.Size = New System.Drawing.Size(102, 26)
        Me.lblCreateAddress.TabIndex = 7
        Me.lblCreateAddress.Text = "Address "
        '
        'lblCreateContact
        '
        Me.lblCreateContact.AutoSize = True
        Me.lblCreateContact.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateContact.Location = New System.Drawing.Point(1191, 414)
        Me.lblCreateContact.Name = "lblCreateContact"
        Me.lblCreateContact.Size = New System.Drawing.Size(90, 26)
        Me.lblCreateContact.TabIndex = 8
        Me.lblCreateContact.Text = "Mobile :"
        '
        'lblCreatePassword
        '
        Me.lblCreatePassword.AutoSize = True
        Me.lblCreatePassword.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreatePassword.Location = New System.Drawing.Point(1202, 668)
        Me.lblCreatePassword.Name = "lblCreatePassword"
        Me.lblCreatePassword.Size = New System.Drawing.Size(124, 26)
        Me.lblCreatePassword.TabIndex = 9
        Me.lblCreatePassword.Text = "Password :"
        '
        'lblCreateEmail
        '
        Me.lblCreateEmail.AutoSize = True
        Me.lblCreateEmail.Font = New System.Drawing.Font("Arial", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreateEmail.Location = New System.Drawing.Point(1202, 537)
        Me.lblCreateEmail.Name = "lblCreateEmail"
        Me.lblCreateEmail.Size = New System.Drawing.Size(79, 26)
        Me.lblCreateEmail.TabIndex = 10
        Me.lblCreateEmail.Text = "Email :"
        '
        'btnCreate
        '
        Me.btnCreate.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCreate.FlatAppearance.BorderSize = 0
        Me.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreate.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCreate.Location = New System.Drawing.Point(1694, 894)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(218, 68)
        Me.btnCreate.TabIndex = 11
        Me.btnCreate.Text = "Sign Up"
        Me.btnCreate.UseVisualStyleBackColor = False
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = True
        Me.chkShowPassword.Font = New System.Drawing.Font("Myanmar Text", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkShowPassword.Location = New System.Drawing.Point(1694, 782)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(150, 34)
        Me.chkShowPassword.TabIndex = 22
        Me.chkShowPassword.Text = "show password"
        Me.chkShowPassword.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel3.Controls.Add(Me.txtCreateName)
        Me.Panel3.Location = New System.Drawing.Point(1196, 209)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(305, 62)
        Me.Panel3.TabIndex = 23
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel4.Controls.Add(Me.txtCreateAddress)
        Me.Panel4.Location = New System.Drawing.Point(1195, 325)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(649, 62)
        Me.Panel4.TabIndex = 24
        '
        'txtCreateAddress
        '
        Me.txtCreateAddress.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.txtCreateAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateAddress.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateAddress.ForeColor = System.Drawing.Color.Silver
        Me.txtCreateAddress.Location = New System.Drawing.Point(33, 22)
        Me.txtCreateAddress.Name = "txtCreateAddress"
        Me.txtCreateAddress.Size = New System.Drawing.Size(566, 23)
        Me.txtCreateAddress.TabIndex = 1
        Me.txtCreateAddress.Text = "Address"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel5.Controls.Add(Me.txtCreatePassword)
        Me.Panel5.Location = New System.Drawing.Point(1199, 704)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(645, 62)
        Me.Panel5.TabIndex = 24
        '
        'txtCreatePassword
        '
        Me.txtCreatePassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.txtCreatePassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreatePassword.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreatePassword.ForeColor = System.Drawing.Color.Silver
        Me.txtCreatePassword.Location = New System.Drawing.Point(29, 22)
        Me.txtCreatePassword.Name = "txtCreatePassword"
        Me.txtCreatePassword.Size = New System.Drawing.Size(528, 23)
        Me.txtCreatePassword.TabIndex = 1
        Me.txtCreatePassword.Text = "Password"
        Me.txtCreatePassword.UseSystemPasswordChar = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel6.Controls.Add(Me.txtCreateMobile)
        Me.Panel6.Location = New System.Drawing.Point(1196, 443)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(648, 62)
        Me.Panel6.TabIndex = 24
        '
        'txtCreateMobile
        '
        Me.txtCreateMobile.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.txtCreateMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateMobile.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateMobile.ForeColor = System.Drawing.Color.Silver
        Me.txtCreateMobile.Location = New System.Drawing.Point(32, 20)
        Me.txtCreateMobile.MaxLength = 10
        Me.txtCreateMobile.Name = "txtCreateMobile"
        Me.txtCreateMobile.Size = New System.Drawing.Size(534, 23)
        Me.txtCreateMobile.TabIndex = 1
        Me.txtCreateMobile.Text = "Mobile"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel7.Controls.Add(Me.txtCreateEmail)
        Me.Panel7.Location = New System.Drawing.Point(1199, 566)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(645, 62)
        Me.Panel7.TabIndex = 24
        '
        'txtCreateEmail
        '
        Me.txtCreateEmail.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.txtCreateEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtCreateEmail.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreateEmail.ForeColor = System.Drawing.Color.Silver
        Me.txtCreateEmail.Location = New System.Drawing.Point(29, 19)
        Me.txtCreateEmail.Name = "txtCreateEmail"
        Me.txtCreateEmail.Size = New System.Drawing.Size(528, 23)
        Me.txtCreateEmail.TabIndex = 1
        Me.txtCreateEmail.Text = "Email"
        '
        'pnlLeftSide
        '
        Me.pnlLeftSide.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.pnlLeftSide.Controls.Add(Me.Label7)
        Me.pnlLeftSide.Controls.Add(Me.Panel1)
        Me.pnlLeftSide.Controls.Add(Me.Label6)
        Me.pnlLeftSide.Controls.Add(Me.Label5)
        Me.pnlLeftSide.Controls.Add(Me.Button3)
        Me.pnlLeftSide.Controls.Add(Me.Button2)
        Me.pnlLeftSide.Controls.Add(Me.Button1)
        Me.pnlLeftSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeftSide.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftSide.Name = "pnlLeftSide"
        Me.pnlLeftSide.Size = New System.Drawing.Size(1030, 1055)
        Me.pnlLeftSide.TabIndex = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Meiryo", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(264, 261)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(235, 60)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "BUSBOOK"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(163, 224)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(134, 122)
        Me.Panel1.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Meiryo", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(215, 454)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(220, 50)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "quick access"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Meiryo", 19.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(215, 403)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(529, 50)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Login using social media to get "
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.BlueViolet
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Meiryo", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button3.Location = New System.Drawing.Point(224, 831)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(546, 71)
        Me.Button3.TabIndex = 32
        Me.Button3.Text = "Sign in with google"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.BlueViolet
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Meiryo", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button2.Location = New System.Drawing.Point(224, 583)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(546, 71)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Sign in with facebook"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.BlueViolet
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Meiryo", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button1.Location = New System.Drawing.Point(224, 705)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(546, 71)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Sign in with twitter"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DodgerBlue
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Button4.Location = New System.Drawing.Point(1185, 894)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(184, 68)
        Me.Button4.TabIndex = 26
        Me.Button4.Text = "Back"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.Panel2.Controls.Add(Me.txtLastName)
        Me.Panel2.Location = New System.Drawing.Point(1532, 209)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(312, 62)
        Me.Panel2.TabIndex = 25
        '
        'txtLastName
        '
        Me.txtLastName.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.ForeColor = System.Drawing.Color.Silver
        Me.txtLastName.Location = New System.Drawing.Point(24, 19)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(238, 23)
        Me.txtLastName.TabIndex = 1
        Me.txtLastName.Text = "Last Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(1527, 179)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 27)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Lastname"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo", 26.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1174, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 66)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Sign Up"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo", 14.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(1187, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(235, 36)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "It's quick and easy"
        '
        'createaccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.pnlLeftSide)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.chkShowPassword)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.lblCreateEmail)
        Me.Controls.Add(Me.lblCreatePassword)
        Me.Controls.Add(Me.lblCreateContact)
        Me.Controls.Add(Me.lblCreateAddress)
        Me.Controls.Add(Me.lblCreateName)
        Me.Name = "createaccount"
        Me.Text = "createaccount"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.pnlLeftSide.ResumeLayout(False)
        Me.pnlLeftSide.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCreateName As TextBox
    Friend WithEvents lblCreateName As Label
    Friend WithEvents lblCreateAddress As Label
    Friend WithEvents lblCreateContact As Label
    Friend WithEvents lblCreatePassword As Label
    Friend WithEvents lblCreateEmail As Label
    Friend WithEvents btnCreate As Button
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtCreateAddress As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtCreatePassword As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtCreateMobile As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtCreateEmail As TextBox
    Friend WithEvents pnlLeftSide As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class

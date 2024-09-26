Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D

Public Class createaccount
    Dim cmd As SqlCommand
    Dim connection As New SqlConnection("Data Source=Prajon-PC\SQLEXPRESS01;Initial Catalog=bus_booking;Integrated Security=True;")

    Private Sub email_Enter(sender As Object, e As EventArgs) Handles txtCreateEmail.Enter
        If txtCreateEmail.Text = "Email" Then
            txtCreateEmail.Text = ""
            txtCreateEmail.ForeColor = Color.Black
        End If
    End Sub

    Private Sub email_Leave(sender As Object, e As EventArgs) Handles txtCreateEmail.Leave
        If txtCreateEmail.Text = "" Then
            txtCreateEmail.Text = "Email"
            txtCreateEmail.ForeColor = Color.Silver
        End If
        If Not txtCreateEmail.Text.EndsWith("@gmail.com") Then
            MessageBox.Show("Email must end with '@gmail.com'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCreateEmail.Focus()
        End If
    End Sub

    Private Sub last_enter(sender As Object, e As EventArgs) Handles txtLastName.Enter
        If txtLastName.Text = "Last Name" Then
            txtLastName.Text = ""
            txtLastName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub last_leave(sender As Object, e As EventArgs) Handles txtLastName.Leave
        If txtLastName.Text = "" Then
            txtLastName.Text = "Last Name"
            txtLastName.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub name_Enter(sender As Object, e As EventArgs) Handles txtCreateName.Enter
        If txtCreateName.Text = "First Name" Then
            txtCreateName.Text = ""
            txtCreateName.ForeColor = Color.Black
        End If
    End Sub

    Private Sub name_leave(sender As Object, e As EventArgs) Handles txtCreateName.Leave
        If txtCreateName.Text = "" Then
            txtCreateName.Text = "First Name"
            txtCreateName.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub address_enter(sender As Object, e As EventArgs) Handles txtCreateAddress.Enter
        If txtCreateAddress.Text = "Address" Then
            txtCreateAddress.Text = ""
            txtCreateAddress.ForeColor = Color.Black
        End If
    End Sub

    Private Sub adddress_leave(sender As Object, e As EventArgs) Handles txtCreateAddress.Leave
        If txtCreateAddress.Text = "" Then
            txtCreateAddress.Text = "Address"
            txtCreateAddress.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub mobile_enter(sender As Object, e As EventArgs) Handles txtCreateMobile.Enter
        If txtCreateMobile.Text = "Mobile" Then
            txtCreateMobile.Text = ""
            txtCreateMobile.ForeColor = Color.Black
        End If
    End Sub

    Private Sub mobile_leave(sender As Object, e As EventArgs) Handles txtCreateMobile.Leave
        If txtCreateMobile.Text = "" Then
            txtCreateMobile.Text = "Mobile"
            txtCreateMobile.ForeColor = Color.Silver
        End If
        If txtCreateMobile.Text.Length < 10 OrElse Not IsNumeric(txtCreateMobile.Text) Then
            MessageBox.Show("Mobile number must contain at least 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCreateMobile.Focus()
        End If
    End Sub

    Private Sub pass_enter(sender As Object, e As EventArgs) Handles txtCreatePassword.Enter
        If txtCreatePassword.Text = "Password" Then
            txtCreatePassword.Text = ""
            txtCreatePassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub pass_leave(sender As Object, e As EventArgs) Handles txtCreatePassword.Leave
        Dim hasUpperCase As Boolean = txtCreatePassword.Text.Any(AddressOf Char.IsUpper)
        Dim hasLowerCase As Boolean = txtCreatePassword.Text.Any(AddressOf Char.IsLower)
        Dim hasNumber As Boolean = txtCreatePassword.Text.Any(AddressOf Char.IsDigit)

        If txtCreatePassword.Text = "" Then
            txtCreatePassword.Text = "Password"
            txtCreatePassword.ForeColor = Color.Silver
        End If

        If Not (hasUpperCase And hasLowerCase And hasNumber) Then
            MessageBox.Show("Password must contain at least one uppercase letter, one lowercase letter, and one number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCreatePassword.Focus()
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        DrawRoundedPanel(Panel3, e, 40)
    End Sub

    ' Handle the Paint event for Panel2
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        DrawRoundedPanel(Panel2, e, 40)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        DrawRoundedPanel(Panel4, e, 40)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        DrawRoundedPanel(Panel5, e, 40)
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint
        DrawRoundedPanel(Panel6, e, 40)
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint
        DrawRoundedPanel(Panel7, e, 40)
    End Sub
    ' Method to draw a rounded panel without a border
    Private Sub DrawRoundedPanel(panel As Panel, e As PaintEventArgs, cornerRadius As Integer)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Create a rectangle that defines the bounds of the panel
        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)

        ' Create a GraphicsPath to define the rounded corners
        Dim path As New Drawing2D.GraphicsPath()

        ' Add rounded corners using arcs
        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90) ' Top-left
        path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90) ' Top-right
        path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90) ' Bottom-right
        path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90) ' Bottom-left

        path.CloseFigure()

        ' Set the panel's region to the rounded corners
        panel.Region = New Region(path)

        ' Optional: Fill the panel with its background color
        e.Graphics.FillPath(New SolidBrush(panel.BackColor), path)
    End Sub

    Private Function GetRoundedRectanglePath(rect As Rectangle, radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        Dim diameter As Integer = radius * 2

        ' Top-left arc
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90)

        ' Top-right arc
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90)

        ' Bottom-right arc
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90)

        ' Bottom-left arc
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90)

        path.CloseFigure()

        Return path
    End Function

    Private Sub Button_Paint(sender As Object, e As PaintEventArgs) Handles Button2.Paint, Button1.Paint, Button3.Paint, btnCreate.Paint, Button4.Paint
        Dim btn As Button = DirectCast(sender, Button)

        ' Create a rounded rectangle path
        Dim path As Drawing2D.GraphicsPath = GetRoundedRectanglePath(New Rectangle(0, 0, btn.Width, btn.Height), 20) ' Use 20 for better rounding

        ' Apply the rounded path to the button's region to create rounded corners
        btn.Region = New Region(path)

        ' Set different background colors for each button
        Dim backgroundColor As Color

        Select Case btn.Name
            Case "Button1"
                backgroundColor = Color.SkyBlue
            Case "Button2"
                backgroundColor = ColorTranslator.FromHtml("#4793AF")
            Case "Button3"
                backgroundColor = ColorTranslator.FromHtml("#E72929")
            Case "btnCreate"
                backgroundColor = Color.DodgerBlue
            Case "Button4"
                backgroundColor = Color.Black
            Case Else
                backgroundColor = Color.White ' Default background color
        End Select

        ' Set the button background to the specific color
        e.Graphics.FillPath(New SolidBrush(backgroundColor), path)

        ' Allow the default button text rendering
        TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click

        If String.IsNullOrWhiteSpace(txtCreateName.Text) OrElse txtCreateName.Text = "First Name" OrElse
       String.IsNullOrWhiteSpace(txtLastName.Text) OrElse txtLastName.Text = "Last Name" OrElse
       String.IsNullOrWhiteSpace(txtCreateAddress.Text) OrElse txtCreateAddress.Text = "Address" OrElse
       String.IsNullOrWhiteSpace(txtCreateMobile.Text) OrElse txtCreateMobile.Text = "Mobile" OrElse
       String.IsNullOrWhiteSpace(txtCreateEmail.Text) OrElse txtCreateEmail.Text = "Email" OrElse
       String.IsNullOrWhiteSpace(txtCreatePassword.Text) OrElse txtCreatePassword.Text = "Password" Then
            MessageBox.Show("Please fill in all fields before creating the account.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub ' Exit the function if any field is empty
        End If

        Try

            connection.Open()

            ' Check if the email already exists
            Dim emailCmd As New SqlCommand("SELECT COUNT(*) FROM bus_login WHERE email = @Email", connection)
            emailCmd.Parameters.AddWithValue("@Email", txtCreateEmail.Text)

            Dim emailExists As Integer = Convert.ToInt32(emailCmd.ExecuteScalar())

            If emailExists > 0 Then
                ' If email already exists, show a message
                MessageBox.Show("The email is already registered. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                ' Proceed with creating the account if the email is unique
                Dim Idcmd As New SqlCommand("SELECT ISNULL(MAX(id), 0) + 1 FROM bus_login", connection)
                Dim Id As String = Convert.ToString(Idcmd.ExecuteScalar())

                ' Insert the new user data into bus_login table
                cmd = New SqlCommand("INSERT INTO bus_login (id, name, address, mobile, password, email, lastname) " &
                                 "VALUES (@Id, @Name, @Address, @Mobile, @Password, @Email, @lastName)", connection)

                cmd.Parameters.AddWithValue("@Id", Id)
                cmd.Parameters.AddWithValue("@Name", UCase$(txtCreateName.Text))
                cmd.Parameters.AddWithValue("@Address", UCase$(txtCreateAddress.Text))
                cmd.Parameters.AddWithValue("@Mobile", txtCreateMobile.Text)
                cmd.Parameters.AddWithValue("@Password", txtCreatePassword.Text)
                cmd.Parameters.AddWithValue("@Email", txtCreateEmail.Text)
                cmd.Parameters.AddWithValue("@lastName", UCase$(txtLastName.Text))

                If cmd.ExecuteNonQuery() = 1 Then
                    MessageBox.Show("Account Created", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Error creating account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtCreatePassword.UseSystemPasswordChar = False
        Else
            txtCreatePassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        loginpage.Show()
        Me.Hide()
        txtCreateAddress.Text = "Address"
        txtCreateAddress.ForeColor = Color.Silver
        txtCreateEmail.Text = "Email"
        txtCreateEmail.ForeColor = Color.Silver
        txtCreateMobile.Text = "Mobile"
        txtCreateMobile.ForeColor = Color.Silver
        txtCreateName.Text = "First Name"
        txtCreateName.ForeColor = Color.Silver
        txtCreatePassword.Text = "Password"
        txtCreatePassword.ForeColor = Color.Silver
        txtLastName.Text = "Last Name"
        txtLastName.ForeColor = Color.Silver
    End Sub


End Class

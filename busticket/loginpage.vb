Imports System.Data.SqlClient
Imports System.Data
Public Class loginpage
    Dim cmd As SqlCommand
    Dim connection As New SqlConnection("Data Source=Prajon-PC\SQLEXPRESS01;Initial Catalog=bus_booking;Integrated Security=True;")
    Private seatmap As seatmapping = Nothing
    Private Sub email_Enter(sender As Object, e As EventArgs) Handles txtEmail.Enter
        If txtEmail.Text = "Email Address" Then
            txtEmail.Text = ""
            txtEmail.ForeColor = Color.Black
        End If
    End Sub

    Private Sub email_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        If txtEmail.Text = "" Then
            txtEmail.Text = "Email Address"
            txtEmail.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub password_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.ForeColor = Color.Black
        End If

    End Sub

    Private Sub password_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim query As String = "SELECT id, name FROM bus_login WHERE email = @Email AND password = @Password"
        cmd = New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text)

        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)
        If dt.Rows.Count > 0 Then
            connection.Open()

            ' Get user ID and name from the result
            Dim name As String = dt.Rows(0)("name").ToString()

            ' Close and dispose of existing forms if they are open
            If homepage IsNot Nothing Then
                homepage.Close()
                homepage.Dispose()
            End If

            homepage.lblName.Text = name ' Set user-specific data like name
            homepage.Show()

            ' Create and show the seatmapping form
            Dim userId As Integer = Convert.ToInt32(dt.Rows(0)("id"))
            GlobalVariable.UserId = userId

            ' Hide the login form
            Me.Hide()
        Else
            MessageBox.Show("Login Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        connection.Close()

        ' Reset login form fields to default
        txtEmail.Text = "Email Address"
        txtEmail.ForeColor = Color.Silver
        txtPassword.Text = "Password"
        txtPassword.ForeColor = Color.Silver
    End Sub

    ' Handle the Paint event for Panel1
    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint
        DrawRoundedPanel(Panel3, e, 40)
    End Sub

    ' Handle the Paint event for Panel2
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        DrawRoundedPanel(Panel2, e, 40)
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

    Private Sub Button_Paint(sender As Object, e As PaintEventArgs) Handles Button2.Paint, Button1.Paint, Button3.Paint, btnLogin.Paint
        Dim btn As Button = DirectCast(sender, Button)

        ' Create a rounded rectangle path
        Dim path As Drawing2D.GraphicsPath = GetRoundedRectanglePath(New Rectangle(0, 0, btn.Width, btn.Height), 10) ' Use 20 for better rounding

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
            Case "btnLogin"
                backgroundColor = Color.DodgerBlue
            Case Else
                backgroundColor = Color.White ' Default background color
        End Select

        ' Set the button background to the specific color
        e.Graphics.FillPath(New SolidBrush(backgroundColor), path)

        ' Allow the default button text rendering
        TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        createaccount.Show()
        Me.Hide()
    End Sub
End Class

Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D

Public Class homepage
    Private drawRectangles As List(Of Rectangle) = New List(Of Rectangle)
    Private drawLines As List(Of Tuple(Of Point, Point)) = New List(Of Tuple(Of Point, Point)) ' List for line coordinates
    Private currentSeatMappingForm As seatmapping = Nothing
    Private currentBusId As Integer
    Private previousButton As Button = Nothing
    Private customerId As Integer

    Dim departuringCmd As SqlCommand
    Dim reachingCmd As SqlCommand
    Dim cmd As SqlCommand
    Dim connection As New SqlConnection("Data Source=Prajon-PC\SQLEXPRESS01;Initial Catalog=bus_booking;Integrated Security=True;")

    Private Sub DrawRoundedPanel(ByVal panel As Panel, ByVal e As PaintEventArgs, ByVal cornerRadius As Integer, ByVal startColor As Color, ByVal endColor As Color)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim graphicsPath As New GraphicsPath()

        Dim rect As New Rectangle(0, 0, panel.Width, panel.Height)

        graphicsPath.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        graphicsPath.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        graphicsPath.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        graphicsPath.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90)

        graphicsPath.CloseFigure()

        panel.Region = New Region(graphicsPath)

        Using gradientBrush As New LinearGradientBrush(
            rect,
            startColor,
            endColor,
            LinearGradientMode.Vertical
        )
            e.Graphics.FillPath(gradientBrush, graphicsPath)
        End Using
    End Sub

    Private Sub Panel2_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel2.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(Panel2, e, 40, ColorTranslator.FromHtml("#98DED9"), ColorTranslator.FromHtml("#D2E0FB"))
    End Sub

    Private Sub Panel3_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel7.Paint, Panel3.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(Panel3, e, 40, ColorTranslator.FromHtml("#9ADE7B"), ColorTranslator.FromHtml("#B0EBB4"))
    End Sub

    Private Sub Panel4_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel6.Paint, Panel4.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(Panel4, e, 40, ColorTranslator.FromHtml("#FB6D48"), ColorTranslator.FromHtml("#FF9B9B"))
    End Sub

    Private Sub Panel24_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel24.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(Panel24, e, 40, ColorTranslator.FromHtml("#FCFAEE"), ColorTranslator.FromHtml("#FCFAEE"))
    End Sub

    Private Sub Panel8_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel8.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(Panel8, e, 40, ColorTranslator.FromHtml("#98DED9"), ColorTranslator.FromHtml("#D2E0FB"))
    End Sub

    Private Sub Panel7_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel7.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(Panel7, e, 40, ColorTranslator.FromHtml("#9ADE7B"), ColorTranslator.FromHtml("#B0EBB4"))
    End Sub

    Private Sub Panel6_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Panel6.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(Panel6, e, 40, ColorTranslator.FromHtml("#FB6D48"), ColorTranslator.FromHtml("#FF9B9B"))
    End Sub

    Private Sub Panel9_Paint(sender As Object, e As PaintEventArgs) Handles Panel9.Paint
        DrawRoundedPanel(sender, e)
    End Sub

    Private Sub Panel11_Paint(sender As Object, e As PaintEventArgs) Handles Panel11.Paint
        DrawRoundedPanel(sender, e)
    End Sub

    Private Sub DrawRoundedPanel(sender As Object, e As PaintEventArgs)
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim graphics As Graphics = e.Graphics

        ' Clear the background
        graphics.Clear(panel.BackColor)

        ' Define the radius of the curve
        Dim cornerRadius As Integer = 40

        ' Create the GraphicsPath object
        Dim path As New GraphicsPath()

        ' Add rounded rectangle to the GraphicsPath
        path.AddArc(New Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90)
        path.AddArc(New Rectangle(panel.Width - cornerRadius, 0, cornerRadius, cornerRadius), 270, 90)
        path.AddArc(New Rectangle(panel.Width - cornerRadius, panel.Height - cornerRadius, cornerRadius, cornerRadius), 0, 90)
        path.AddArc(New Rectangle(0, panel.Height - cornerRadius, cornerRadius, cornerRadius), 90, 90)
        path.CloseFigure()

        ' Set the region of the panel to the GraphicsPath
        panel.Region = New Region(path)
    End Sub


    Private Sub LeftPanel_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles leftPanel.Paint
        ' Call the method to draw the panel with rounded corners and gradient
        DrawRoundedPanel(leftPanel, e, 40, ColorTranslator.FromHtml("#6256CA"), ColorTranslator.FromHtml("#E3A5C7"))
    End Sub

    Private Sub topPanel_Paint(sender As Object, e As PaintEventArgs) Handles topPanel.Paint
        Dim panel As Panel = DirectCast(sender, Panel)
        Dim graphics As Graphics = e.Graphics

        ' Clear the background
        graphics.Clear(panel.BackColor)

        ' Define the radius for the rounded corners
        Dim cornerRadius As Integer = 40

        ' Create a GraphicsPath object for the rounded top-left and bottom-left corners
        Dim path As New GraphicsPath()

        ' Top-left corner (rounded)
        path.AddArc(New Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90)

        ' Top-right corner (sharp, straight line)
        path.AddLine(cornerRadius, 0, panel.Width, 0)

        ' Right side (straight line down)
        path.AddLine(panel.Width, 0, panel.Width, panel.Height)

        ' Bottom-right corner (sharp, straight line)
        path.AddLine(panel.Width, panel.Height, cornerRadius, panel.Height)

        ' Bottom-left corner (rounded)
        path.AddArc(New Rectangle(0, panel.Height - cornerRadius, cornerRadius, cornerRadius), 90, 90)

        ' Left side (straight line up)
        path.AddLine(0, panel.Height - cornerRadius, 0, cornerRadius)

        ' Close the figure
        path.CloseFigure()

        ' Set the panel's region to the rounded shape
        panel.Region = New Region(path)

        ' Create a LinearGradientBrush for the vertical gradient (top to bottom)
        Dim topColor As Color = ColorTranslator.FromHtml("#A084DC")
        Dim bottomColor As Color = ColorTranslator.FromHtml("#E3A5C7")
        Dim gradientBrush As New LinearGradientBrush(panel.ClientRectangle, topColor, bottomColor, LinearGradientMode.Horizontal)

        ' Fill the panel with the gradient
        graphics.FillRectangle(gradientBrush, panel.ClientRectangle)
    End Sub

    Private Sub AdjustPanelSizeToLabel()
        ' Get the label inside Panel24
        Dim labelInPanel As Label = lblName ' Assuming Label1 is the label inside Panel24

        ' Set Panel24's size based on the label's size, with some padding if needed
        Panel24.Width = labelInPanel.Width + 50 ' Add padding if necessary

    End Sub

    Private Sub Label1_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        AdjustPanelSizeToLabel()
    End Sub


    Private Sub homepage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler btnViewSeat.Click, AddressOf btnViewSeat_Click
        AddHandler btnViewSeat2.Click, AddressOf btnViewSeat2_Click
        AddHandler btnViewSeat3.Click, AddressOf btnViewSeat3_Click
        AddHandler btnViewSeat4.Click, AddressOf btnViewSeat4_Click

        AdjustPanelSizeToLabel()
        dateandtime.MinDate = DateTime.Today

        ApplyRoundedEdges(btnSearch, 40) ' Apply to the search button
        ApplyRoundedEdges(btnViewSeat, 20) ' Apply to the first view seat button
        ApplyRoundedEdges(btnViewSeat2, 20) ' Apply to the second view seat button
        ApplyRoundedEdges(btnViewSeat3, 20) ' Apply to the third view seat button
        ApplyRoundedEdges(btnViewSeat4, 20)

        ' Set ComboBox styles to prevent typing
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList

        ' Load departure cities
        departuringCmd = New SqlCommand("select distinct departuringcity from address_info", connection)
        Dim dsda As SqlDataAdapter = New SqlDataAdapter(departuringCmd)
        Dim ddt As DataTable = New DataTable()
        dsda.Fill(ddt)

        ' Insert an empty row at the top of the DataTable
        Dim emptyRow As DataRow = ddt.NewRow()
        emptyRow("departuringcity") = "" ' Set empty value
        ddt.Rows.InsertAt(emptyRow, 0)

        ComboBox1.DataSource = ddt
        ComboBox1.DisplayMember = "departuringcity"
        ComboBox1.ValueMember = "departuringcity"
        ComboBox1.SelectedIndex = -1 ' No selection initially

        ' Load reaching cities
        reachingCmd = New SqlCommand("select distinct reachingcity from address_info", connection)
        Dim rsda As SqlDataAdapter = New SqlDataAdapter(reachingCmd)
        Dim rdt As DataTable = New DataTable()
        rsda.Fill(rdt)

        ' Insert an empty row at the top of the DataTable
        Dim emptyReachingRow As DataRow = rdt.NewRow()
        emptyReachingRow("reachingcity") = "" ' Set empty value
        rdt.Rows.InsertAt(emptyReachingRow, 0)

        ComboBox2.DataSource = rdt
        ComboBox2.DisplayMember = "reachingcity"
        ComboBox2.ValueMember = "reachingcity"
        ComboBox2.SelectedIndex = -1 ' No selection initially
        Try
            If connection.State = ConnectionState.Closed Then connection.Open()

            Dim cmd As New SqlCommand("select count(bid) from bus_info", connection)
            Dim userCmd As New SqlCommand("select count(id) from bus_login", connection)
            Dim numberOfBus As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            Dim numberOfUser As Integer = Convert.ToInt32(userCmd.ExecuteScalar())
            Label10.Text = numberOfUser
            Label9.Text = numberOfUser
            lblNumberOfBus.Text = numberOfBus
            Label6.Text = numberOfBus

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
        btnhome.ForeColor = Color.DodgerBlue
        btnhome.FlatStyle = FlatStyle.Flat ' Set Flat style to customize border
        btnhome.FlatAppearance.BorderSize = 1 ' Set the border size
        btnhome.FlatAppearance.BorderColor = Color.DodgerBlue
        previousButton = btnhome
        Panel11.Hide()
        Panel5.Hide()
        Panel10.Hide()
        Panel18.Hide()
    End Sub

    Private Sub LoadBusData()
        Try
            ' Hide row headers if not needed (first column empty issue)
            DataGridView1.RowHeadersVisible = False
            DataGridView2.RowHeadersVisible = False

            ' Prevent the automatic addition of an empty row (last row empty issue)
            DataGridView1.AllowUserToAddRows = False
            DataGridView2.AllowUserToAddRows = False

            If connection.State = ConnectionState.Closed Then connection.Open()

            Dim userIdCmd As New SqlCommand("select id from bus_login where name = @Name", connection)
            userIdCmd.Parameters.AddWithValue("@Name", lblName.Text)
            Dim userId As Integer = Convert.ToInt32(userIdCmd.ExecuteScalar())

            Dim dataCmd As New SqlCommand("SELECT bs.bookedId, b.bname, a.departuringcity, a.reachingcity, b.departuretime, sm.seat_number, b.busdate, b.price
                                   FROM booked_seat bs
                                   INNER JOIN seat_map sm ON bs.bo_seatid = sm.seatId
                                   INNER JOIN seat s ON sm.sid = s.sid
                                   INNER JOIN bus_info b ON s.bid = b.bid
                                   INNER JOIN address_info a ON b.bid = a.a_bid
                                   INNER JOIN bus_login l ON bs.bo_id = l.id WHERE l.id = @userId", connection)
            dataCmd.Parameters.AddWithValue("@userId", userId)

            Dim adapter As New SqlDataAdapter(dataCmd)
            Dim dataTable As New DataTable()
            adapter.Fill(dataTable)

            dataTable.Columns.Add("Status", GetType(String))

            ' Loop through each row and set the status
            For Each row As DataRow In dataTable.Rows
                Dim busDate As DateTime
                Dim departureTime As DateTime

                ' Try to parse the busdate string (in yyyy:MM:dd format) to DateTime
                If DateTime.TryParseExact(row("busdate").ToString(), "yyyy-MM-dd", Nothing, Globalization.DateTimeStyles.None, busDate) Then
                    ' Concatenate busdate and departuretime to form full DateTime
                    Dim fullDateTimeString As String = row("busdate").ToString() & " " & row("departuretime").ToString()

                    ' If departure time includes AM/PM, parse with tt (AM/PM) included
                    If DateTime.TryParseExact(fullDateTimeString, "yyyy-MM-dd hh:mm tt", Nothing, Globalization.DateTimeStyles.None, departureTime) Then
                        ' Compare current date and time to determine status
                        If departureTime > DateTime.Now Then
                            row("Status") = "Booked"
                        Else
                            row("Status") = "Expired"
                        End If
                    Else
                        ' Handle invalid departure time format
                        row("Status") = "Invalid Departure Time"
                    End If
                Else
                    ' Handle invalid bus date format
                    row("Status") = "Invalid Bus Date"
                End If
            Next


            DataGridView1.DataSource = dataTable

            ' Set DataGridView styles...
            DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Regular)
            DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
            DataGridView1.DefaultCellStyle.BackColor = Color.White
            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.EnableHeadersVisualStyles = False
            DataGridView1.RowTemplate.Height = 40
            DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView1.DefaultCellStyle.Padding = New Padding(10, 0, 10, 0)
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            DataGridView1.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None
            DataGridView1.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
            DataGridView1.AdvancedColumnHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
            DataGridView1.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None

            Dim data2Cmd As New SqlCommand("Select b.bname, b.bustype, a.departuringcity, a.reachingcity, b.departuretime, b.reachingtime, b.busdate, b.price, b.availableseat from bus_info b inner join address_info a on b.bid = a.a_bid  WHERE CONVERT(DATE, b.busdate) >= CONVERT(DATE, GETDATE())", connection)

            Dim adapter2 As New SqlDataAdapter(data2Cmd)
            Dim dataTable2 As New DataTable()
            adapter2.Fill(dataTable2)



            DataGridView2.DataSource = dataTable2

            DataGridView2.DefaultCellStyle.Font = New Font("Segoe UI", 12, FontStyle.Regular)
            DataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
            DataGridView2.DefaultCellStyle.BackColor = Color.White
            DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
            DataGridView2.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
            DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView2.EnableHeadersVisualStyles = False
            DataGridView2.RowTemplate.Height = 40
            DataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None
            DataGridView2.DefaultCellStyle.Padding = New Padding(10, 0, 10, 0)
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            DataGridView2.AdvancedColumnHeadersBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None
            DataGridView2.AdvancedColumnHeadersBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
            DataGridView2.AdvancedColumnHeadersBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
            DataGridView2.AdvancedColumnHeadersBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None

            ' Check if the "Cancel" column already exists before adding it
            If Not DataGridView1.Columns.Contains("Cancel") Then
                ' Add the "Cancel" button column
                Dim cancelBtn As New DataGridViewButtonColumn()
                cancelBtn.HeaderText = "Cancelation"
                cancelBtn.Name = "Cancel"
                cancelBtn.Text = "Cancel"
                cancelBtn.UseColumnTextForButtonValue = True
                DataGridView1.Columns.Add(cancelBtn)
            End If

            ' Set header texts
            DataGridView1.Columns("bname").HeaderText = "Bus Name"
            DataGridView1.Columns("departuringcity").HeaderText = "Departuring City"
            DataGridView1.Columns("reachingcity").HeaderText = "Destination"
            DataGridView1.Columns("departuretime").HeaderText = "Departure Time"
            DataGridView1.Columns("seat_number").HeaderText = "Seat Number"
            DataGridView1.Columns("busdate").HeaderText = "Bus Date"
            DataGridView1.Columns("price").HeaderText = "Price"
            DataGridView1.Columns("Status").HeaderText = "Status"

            DataGridView2.Columns("bname").HeaderText = "Bus Name"
            DataGridView2.Columns("bustype").HeaderText = "Bus Type"
            DataGridView2.Columns("departuringcity").HeaderText = "Departuring City"
            DataGridView2.Columns("reachingcity").HeaderText = "Destination"
            DataGridView2.Columns("departuretime").HeaderText = "Departure Time"
            DataGridView2.Columns("reachingtime").HeaderText = "Reaching Time"
            DataGridView2.Columns("busdate").HeaderText = "Bus Date"
            DataGridView2.Columns("price").HeaderText = "Price"
            DataGridView2.Columns("availableseat").HeaderText = "Available Seat"

            ' Hide the "Id" column if it doesn't need to be visible
            DataGridView1.Columns("bookedId").Visible = False

            ' Optional: Make the DataGridView columns read-only, except the Cancel button column
            For Each col As DataGridViewColumn In DataGridView1.Columns
                If col.Name <> "Cancel" Then
                    col.ReadOnly = True
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading bus data: " & ex.Message)
        Finally
            If connection.State = ConnectionState.Open Then connection.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        ' Check if the current column is the "Status" column
        If DataGridView1.Columns(e.ColumnIndex).Name = "Status" Then
            If e.Value IsNot Nothing Then
                Dim status As String = e.Value.ToString()
                If status = "Booked" Then
                    e.CellStyle.ForeColor = Color.Green ' Optional: change text color for better readability
                ElseIf status = "Expired" Then
                    e.CellStyle.ForeColor = Color.Red ' Optional: change text color for better readability
                End If
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.ColumnIndex = DataGridView1.Columns("Cancel").Index AndAlso e.RowIndex >= 0 Then
            ' Cancel the default painting for this cell
            e.Handled = True

            ' Paint the background of the cell
            e.Graphics.FillRectangle(New SolidBrush(Color.White), e.CellBounds)

            ' Calculate button size and position to center it within the cell
            Dim buttonWidth As Integer = 80  ' Width of the button
            Dim buttonHeight As Integer = 20  ' Height of the button
            Dim buttonX As Integer = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2  ' Center horizontally
            Dim buttonY As Integer = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2  ' Center vertically

            Dim buttonBounds As Rectangle = New Rectangle(buttonX, buttonY, buttonWidth, buttonHeight)

            ' Create a rounded rectangle path for the button
            Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
            Dim radius As Integer = 20
            path.AddArc(buttonBounds.Left, buttonBounds.Top, radius, radius, 180, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Top, radius, radius, 270, 90)
            path.AddArc(buttonBounds.Right - radius, buttonBounds.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(buttonBounds.Left, buttonBounds.Bottom - radius, radius, radius, 90, 90)
            path.CloseAllFigures()

            ' Paint the button background
            e.Graphics.FillPath(New SolidBrush(ColorTranslator.FromHtml("#FF6969")), path)

            ' Draw the button text centered within the button
            TextRenderer.DrawText(e.Graphics, "Cancel", DataGridView1.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
        End If
    End Sub





    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        ' Create a GraphicsPath object to define the custom panel shape
        Dim gp As New GraphicsPath()

        ' Define the panel's rectangle
        Dim rect As Rectangle = Panel1.ClientRectangle
        Dim radius As Integer = 40 ' The radius of the curved corners

        gp.AddArc(New Rectangle(rect.X, rect.Y, radius, radius), 180, 90)

        ' Top-left corner (straight)
        gp.AddLine(rect.X, rect.Y, rect.X + rect.Width, rect.Y) ' Top edge

        ' Bottom-right corner (curved)
        gp.AddLine(rect.X + rect.Width, rect.Y, rect.X + rect.Width, rect.Y + rect.Height - radius) ' Right edge (straight)
        gp.AddArc(New Rectangle(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius), 0, 90) ' Bottom-right corner (curved)

        ' Bottom-left corner (curved)
        gp.AddLine(rect.X + radius, rect.Y + rect.Height, rect.X + rect.Width - radius, rect.Y + rect.Height) ' Bottom edge (straight)
        gp.AddArc(New Rectangle(rect.X, rect.Y + rect.Height - radius, radius, radius), 90, 90) ' Bottom-left corner (curved)

        ' Connect back to the top-left
        gp.AddLine(rect.X, rect.Y + rect.Height - radius, rect.X, rect.Y) ' Left edge (straight)

        ' Set the panel's Region to the custom GraphicsPath
        Panel1.Region = New Region(gp)
    End Sub

    Private Sub ApplyRoundedEdges(ByVal btn As Button, ByVal radius As Integer)
        ' Create a rounded rectangle path
        Dim path As New Drawing2D.GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90) ' Top-left corner
        path.AddArc(New Rectangle(btn.Width - radius, 0, radius, radius), 270, 90) ' Top-right corner
        path.AddArc(New Rectangle(btn.Width - radius, btn.Height - radius, radius, radius), 0, 90) ' Bottom-right corner
        path.AddArc(New Rectangle(0, btn.Height - radius, radius, radius), 90, 90) ' Bottom-left corner
        path.CloseFigure()

        ' Set the button's region to the rounded path
        btn.Region = New Region(path)
    End Sub




    ' Update showBus to use DataRow data directly
    Public Sub showBus(row As DataRow, ByVal lblBusName As Label, ByVal lblBusType As Label, ByVal lblDepartureTime As Label, ByVal lblReachingTime As Label, ByVal lblDeparturingCity As Label, ByVal lblReachingcity As Label, ByVal lblPriceAmount As Label, ByVal x As Integer, ByVal y As Integer)
        lblBusName.Text = row("bname").ToString()
        lblBusType.Text = row("bustype").ToString()
        lblDepartureTime.Text = row("departuretime").ToString()
        lblReachingTime.Text = row("reachingtime").ToString()
        lblDeparturingCity.Text = row("departuringcity").ToString()
        lblReachingcity.Text = row("reachingcity").ToString()
        lblPriceAmount.Text = row("price").ToString()

        If lblBusName.Visible AndAlso lblBusType.Visible AndAlso lblDepartureTime.Visible AndAlso lblReachingTime.Visible AndAlso lblDeparturingCity.Visible AndAlso lblReachingcity.Visible AndAlso lblPriceAmount.Visible Then
            drawRectangles.Add(New Rectangle(x, y, 580, 280))
            AddLine(x + 420, y + 15, x + 420, y + 265)
            AddLine(x + 120, y + 165, x + 300, y + 165)
        End If

        Panel10.Invalidate()
    End Sub

    ' Handles form painting
    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint
        ' Define a brush for the rectangle fill
        Dim fillBrush As New SolidBrush(Color.White) ' You can change the color here
        Dim p As Pen = New Pen(Brushes.Black, 1) ' Pen for drawing rectangle border
        Dim lp As Pen = New Pen(Brushes.Gray, 1) ' Pen for drawing lines

        ' Loop through each rectangle in drawRectangles list
        For Each rect As Rectangle In drawRectangles
            ' Fill the rectangle with the desired color
            e.Graphics.FillRectangle(fillBrush, rect)

            ' Draw the rectangle border
            e.Graphics.DrawRectangle(p, rect)
        Next

        ' Draw the lines after the rectangles
        For Each line In drawLines
            e.Graphics.DrawLine(lp, line.Item1, line.Item2)
        Next
    End Sub


    Private Sub AddLine(startX As Integer, startY As Integer, endX As Integer, endY As Integer)
        ' Add the line coordinates to the list
        drawLines.Add(New Tuple(Of Point, Point)(New Point(startX, startY), New Point(endX, endY)))
        Panel10.Invalidate() ' Redraw the panel to reflect the changes
    End Sub




    ' Search for buses and display results
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        drawRectangles.Clear()
        drawLines.Clear()

        Dim selectedDate As String = dateandtime.Value.ToString("yyyy-MM-dd")

        cmd = New SqlCommand("select b.bname, b.bustype, b.departuretime, b.reachingtime, a.departuringcity, a.reachingcity, b.price " &
                             "from bus_info b FULL JOIN address_info a ON b.bid = a.a_bid " &
                             "where a.departuringcity = @departuringcity AND a.reachingcity = @reachingcity AND b.busdate = @dateandtime", connection)

        cmd.Parameters.AddWithValue("@departuringcity", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@reachingcity", ComboBox2.Text)
        cmd.Parameters.AddWithValue("@dateandtime", selectedDate)

        Dim sda As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dt As DataTable = New DataTable()
        sda.Fill(dt)

        HideAllLabels()

        If dt.Rows.Count > 0 Then
            ' Display bus data using DataRow values
            If dt.Rows.Count >= 1 Then
                ShowLabelsForBus(lblBusName, lblBusType, lblDepartureTime, lblReachingTime, lblDeparturingCity, lblReachingcity, lblPriceAmount, lblPrice, btnViewSeat, lblRs)
                showBus(dt.Rows(0), lblBusName, lblBusType, lblDepartureTime, lblReachingTime, lblDeparturingCity, lblReachingcity, lblPriceAmount, 30, 120)
            End If
            If dt.Rows.Count >= 2 Then
                ShowLabelsForBus(lblBusName2, lblBusType2, lblDepartTime2, lblReachTime2, lblDepartCity2, lblReachCity2, lblPriceAmount2, lblPrice2, btnViewSeat2, lblRs2)
                showBus(dt.Rows(1), lblBusName2, lblBusType2, lblDepartTime2, lblReachTime2, lblDepartCity2, lblReachCity2, lblPriceAmount2, 650, 120)
            End If
            If dt.Rows.Count >= 3 Then
                ShowLabelsForBus(lblBusName3, lblBusType3, lblDepartTime3, lblReachTime3, lblDepartCity3, lblReachCity3, lblPriceAmount3, lblPrice3, btnViewSeat3, lblRs3)
                showBus(dt.Rows(2), lblBusName3, lblBusType3, lblDepartTime3, lblReachTime3, lblDepartCity3, lblReachCity3, lblPriceAmount3, 30, 420)
            End If
            If dt.Rows.Count >= 4 Then
                ShowLabelsForBus(lblBusName4, lblBusType4, lblDepartTime4, lblReachTime4, lblDepartCity4, lblReachCity4, lblPriceAmount4, lblPrice4, btnViewSeat4, lblRs4)
                showBus(dt.Rows(3), lblBusName4, lblBusType4, lblDepartTime4, lblReachTime4, lblDepartCity4, lblReachCity4, lblPriceAmount4, 650, 420)
            End If
        Else
            MessageBox.Show("No buses found for the selected cities.")
        End If

        Panel10.Invalidate()
    End Sub

    Private Sub HideAllLabels()
        lblBusName.Visible = False
        lblBusType.Visible = False
        lblDepartureTime.Visible = False
        lblReachingTime.Visible = False
        lblDeparturingCity.Visible = False
        lblReachingcity.Visible = False
        lblPriceAmount.Visible = False
        lblPrice.Visible = False
        btnViewSeat.Visible = False
        lblRs.Visible = False

        lblBusName2.Visible = False
        lblBusType2.Visible = False
        lblDepartTime2.Visible = False
        lblReachTime2.Visible = False
        lblDepartCity2.Visible = False
        lblReachCity2.Visible = False
        lblPriceAmount2.Visible = False
        lblPrice2.Visible = False
        btnViewSeat2.Visible = False
        lblRs2.Visible = False


        lblBusName3.Visible = False
        lblBusType3.Visible = False
        lblDepartTime3.Visible = False
        lblReachTime3.Visible = False
        lblDepartCity3.Visible = False
        lblReachCity3.Visible = False
        lblPriceAmount3.Visible = False
        lblPrice3.Visible = False
        btnViewSeat3.Visible = False
        lblRs3.Visible = False


        lblBusName4.Visible = False
        lblBusType4.Visible = False
        lblDepartTime4.Visible = False
        lblReachTime4.Visible = False
        lblDepartCity4.Visible = False
        lblReachCity4.Visible = False
        lblPriceAmount4.Visible = False
        lblPrice4.Visible = False
        btnViewSeat4.Visible = False
        lblRs4.Visible = False
    End Sub

    ' Subroutine to show specific labels when there is bus information
    Private Sub ShowLabelsForBus(ByVal lblBusName As Label, ByVal lblBusType As Label, ByVal lblDepartureTime As Label, ByVal lblReachingTime As Label, ByVal lblDeparturingCity As Label, ByVal lblReachingcity As Label, ByVal lblPriceAmount As Label, ByVal lblPrice As Label, ByVal btnViewSeat As Button, ByVal lblRs As Label)
        lblBusName.Visible = True
        lblBusType.Visible = True
        lblDepartureTime.Visible = True
        lblReachingTime.Visible = True
        lblDeparturingCity.Visible = True
        lblReachingcity.Visible = True
        lblPriceAmount.Visible = True
        lblPrice.Visible = True
        btnViewSeat.Visible = True
        lblRs.Visible = True
    End Sub

    Private Sub btnViewSeat_Click(sender As Object, e As EventArgs)
        seatmapping.ClearSelectedSeats()
        ShowNewSeatMappingForm(lblBusName)
    End Sub

    Private Sub btnViewSeat2_Click(sender As Object, e As EventArgs)
        seatmapping.ClearSelectedSeats()
        ShowNewSeatMappingForm(lblBusName2)
    End Sub

    Private Sub btnViewSeat3_Click(sender As Object, e As EventArgs)
        seatmapping.ClearSelectedSeats()
        ShowNewSeatMappingForm(lblBusName3)
    End Sub

    Private Sub btnViewSeat4_Click(sender As Object, e As EventArgs)
        seatmapping.ClearSelectedSeats()
        ShowNewSeatMappingForm(lblBusName4)
    End Sub

    Private Sub ShowNewSeatMappingForm(lblBusName As Label)
        ' Close the previous seat mapping form if it's open and dispose of it
        If currentSeatMappingForm IsNot Nothing AndAlso Not currentSeatMappingForm.IsDisposed Then
            currentSeatMappingForm.Close()
            currentSeatMappingForm.Dispose()
            currentSeatMappingForm = Nothing ' Reset the form reference
        End If

        ' Create a new instance of the seat mapping form


        ' Perform seat management for the new form
        Dim selectedDate As String = dateandtime.Value.ToString("yyyy-MM-dd")
        Dim busIdCmd As New SqlCommand("SELECT bid FROM bus_info WHERE bname = @lblBusName AND busdate = @dateandtime", connection)
        busIdCmd.Parameters.AddWithValue("@lblBusName", lblBusName.Text)
        busIdCmd.Parameters.AddWithValue("@dateandtime", selectedDate)

        connection.Open()
        currentBusId = Convert.ToInt32(busIdCmd.ExecuteScalar()) ' Store the bus ID in currentBusId
        connection.Close()


        currentSeatMappingForm = New seatmapping()
        currentSeatMappingForm.BusName = lblBusName.Text ' Pass the bus name
        currentSeatMappingForm.BusId = currentBusId
        currentSeatMappingForm.Show()

        ' Call seatManagement for the new seat mapping form
        seatManagement(currentBusId, currentSeatMappingForm)
    End Sub

    Public Sub seatManagement(ByVal busId As Integer, seatMappingForm As seatmapping)
        Dim seatCmd As New SqlCommand("SELECT sm.seat_number, sm.isBooked FROM seat_map sm INNER JOIN seat s ON sm.sid = s.sid inner join bus_info b on s.bid = b.bid WHERE b.bid = @busId", connection)
        seatCmd.Parameters.AddWithValue("@busId", busId)
        Dim seatda As SqlDataAdapter = New SqlDataAdapter(seatCmd)
        Dim seatdt As DataTable = New DataTable()
        seatda.Fill(seatdt)

        If seatdt.Rows.Count > 0 Then
            For Each row As DataRow In seatdt.Rows
                seatMap(row, seatMappingForm, busId)
            Next
        End If
    End Sub

    Public Sub seatMap(row As DataRow, seatMappingForm As seatmapping, ByVal busId As Integer)

        Dim seatNumber As Integer = Convert.ToInt32(row("seat_number")) ' Get the seat number from the row
        Dim seatButtonName As String = "seat" & seatNumber ' Construct the button name (e.g., "seat1", "seat2", ...)

        ' Find the button by name in the seatmapping form's controls
        Dim seatButton As Button = seatMappingForm.Controls(seatButtonName)

        If seatButton IsNot Nothing Then ' If the button is found
            If Convert.ToBoolean(row("isBooked")) = True Then
                seatButton.BackColor = ColorTranslator.FromHtml("#FF7777")
                seatButton.Enabled = False
            Else
                seatButton.BackColor = Color.SkyBlue ' Available seats are skyblue
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = DataGridView1.Columns("Cancel").Index AndAlso e.RowIndex >= 0 Then
            Dim bookedId As Integer = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("bookedId").Value)

            Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to cancel this booking?", "Confirm Cancellation", MessageBoxButtons.YesNo)
            If confirmResult = DialogResult.Yes Then
                Try
                    If connection.State = ConnectionState.Closed Then connection.Open()

                    Dim seatCmd As New SqlCommand("select s.seat_number from seat_map s inner join booked_seat b on s.seatId = b.bo_seatid where bookedId = @bookedId", connection)
                    seatCmd.Parameters.AddWithValue("@bookedId", bookedId)
                    Dim seatNumber As Integer = Convert.ToInt32(seatCmd.ExecuteScalar())

                    Dim cancelCmd As New SqlCommand("DELETE FROM booked_seat WHERE bookedId = @bookedId", connection)
                    cancelCmd.Parameters.AddWithValue("@bookedId", bookedId)

                    Dim updateCmd As New SqlCommand("UPDATE seat_map SET isBooked='0' WHERE seat_number = @seatNumber", connection)
                    updateCmd.Parameters.AddWithValue("@seatNumber", seatNumber)

                    Dim updateavailableseat As SqlCommand = New SqlCommand("UPDATE b
                                                                SET b.availableseat = (SELECT COUNT(*) 
                                                                                       FROM seat_map sm
                                                                                       WHERE sm.sid = s.sid AND sm.isBooked = 0)
                                                                FROM bus_info b
                                                                INNER JOIN seat s
                                                                ON b.bid = s.bid 
                                                                inner join seat_map sm 
                                                                on s.sid = sm.sid;", connection)


                    cancelCmd.ExecuteNonQuery()
                    updateCmd.ExecuteNonQuery()
                    updateavailableseat.ExecuteNonQuery()
                    DataGridView1.Rows.RemoveAt(e.RowIndex)
                    MessageBox.Show("Booking cancelled successfully.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error cancelling the booking: " & ex.Message)
                Finally
                    If connection.State = ConnectionState.Open Then connection.Close()
                End Try
            End If
        End If
    End Sub

    Private Sub BusInformationForm_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        LoadBusData()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.BackColor = ColorTranslator.FromHtml("#FAF7F0")
        lblHeader.Text = "MY BOOKING"
        Panel5.Show()
        Panel1.Hide()
        Panel10.Hide()
        Panel11.Hide()
        Panel18.Hide()
        seatmapping.ClearSelectedSeats()
    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        lblHeader.Text = "HOME"
        Me.BackColor = ColorTranslator.FromHtml("#d0c8ff")
        Panel1.Show()
        Panel5.Hide()
        Panel10.Hide()
        Panel11.Hide()
        Panel18.Hide()
        seatmapping.ClearSelectedSeats()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Me.BackColor = ColorTranslator.FromHtml("#FFFFEA")
        loginpage.Show()
        Me.Hide()
        seatmapping.ClearSelectedSeats()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.BackColor = ColorTranslator.FromHtml("#FAF7F0")
        lblHeader.Text = "RESERVATION"
        Panel10.Show()
        Panel1.Hide()
        Panel5.Hide()
        Panel11.Hide()
        Panel18.Hide()
        seatmapping.ClearSelectedSeats()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Panel8.Click, Panel2.Click
        Me.BackColor = ColorTranslator.FromHtml("#d0c8ff")
        If previousButton IsNot Nothing Then
            previousButton.ForeColor = Color.Black ' Reset the text color (or default color)
            previousButton.BackColor = Color.Transparent
            previousButton.FlatStyle = FlatStyle.Flat ' Reset border style
            previousButton.FlatAppearance.BorderSize = 0 ' Remove border
        End If
        Button3.ForeColor = Color.DodgerBlue
        Button3.FlatStyle = FlatStyle.Flat ' Set Flat style to customize border
        Button3.FlatAppearance.BorderSize = 1 ' Set the border size
        Button3.FlatAppearance.BorderColor = Color.DodgerBlue
        previousButton = Button3
        lblHeader.Text = "BUS AND SCHEDULE"
        Panel11.Show()
        Panel10.Hide()
        Panel1.Hide()
        Panel5.Hide()
        Panel18.Hide()
        seatmapping.ClearSelectedSeats()
    End Sub



    ' Function to create a rounded rectangle path for the button
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


    Private Sub Button_Paint(sender As Object, e As PaintEventArgs) Handles Button2.Paint, Button1.Paint, Button3.Paint, btnLogOut.Paint, btnhome.Paint
        Dim btn As Button = DirectCast(sender, Button)

        ' Create a rounded rectangle path
        Dim path As Drawing2D.GraphicsPath = GetRoundedRectanglePath(New Rectangle(0, 0, btn.Width, btn.Height), 5)

        ' Apply the rounded path to the button's region to create rounded corners
        btn.Region = New Region(path)

        ' Set the button background to white
        e.Graphics.FillPath(New SolidBrush(Color.White), path)

        ' Draw the border only for the clicked button
        If btn Is previousButton Then
            Dim borderColor As Color = Color.DodgerBlue ' Set border color to gold
            Dim borderPen As New Pen(borderColor, 3) ' Thicker border for visibility
            e.Graphics.DrawPath(borderPen, path) ' Draw border only for the clicked button
        End If

        ' Allow the default button text rendering
        TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter)
    End Sub


    ' Button click event to handle clicked button styles and invalidate previous button
    Private Sub btnclicked(sender As Object, e As EventArgs) Handles Button2.Click, Button1.Click, btnLogOut.Click, btnhome.Click
        ' Get the currently clicked button
        Dim clickedButton As Button = DirectCast(sender, Button)

        ' If there is a previously clicked button, reset its style
        If previousButton IsNot Nothing AndAlso previousButton IsNot clickedButton Then
            ' Reset the previous button style
            previousButton.ForeColor = Color.Black ' Reset text color to default
            previousButton.BackColor = Color.Transparent ' Reset background color
            previousButton.FlatStyle = FlatStyle.Flat ' Reset the border style
            previousButton.FlatAppearance.BorderSize = 0 ' Remove the border
            previousButton.Region = Nothing ' Reset the rounded region
            previousButton.Invalidate() ' Force repaint of the previous button
        End If

        ' Set the forecolor, background, and border for the clicked button
        clickedButton.ForeColor = Color.DodgerBlue ' Set the text color to light blue
        clickedButton.BackColor = Color.White ' Set the background color to white
        clickedButton.FlatStyle = FlatStyle.Flat ' Use Flat style for border customization
        clickedButton.FlatAppearance.BorderSize = 0 ' We handle the border manually in Paint event

        ' Store the clicked button as the previous one for future reference
        previousButton = clickedButton

        ' Invalidate the clicked button to repaint it with rounded corners and white background
        clickedButton.Invalidate()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        seatmapping.ClearSelectedSeats()
        seatmapping.ClearBoardingPoint()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Panel18.Hide()
        Panel10.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or ComboBox3.Text = "" Then
            MsgBox("Please fill up all of your details")
        Else
            customerId = GetNextCustomerId()
            currentSeatMappingForm.handleAfterBook()
            Dim customerCmd As SqlCommand = New SqlCommand("insert into customer_info values(@cid,@name,@email,@boardingpoint,@mobile);", connection)
            customerCmd.Parameters.AddWithValue("@cid", customerId)
            customerCmd.Parameters.AddWithValue("@name", TextBox1.Text)
            customerCmd.Parameters.AddWithValue("@email", TextBox2.Text)
            customerCmd.Parameters.AddWithValue("@boardingpoint", ComboBox3.Text)
            customerCmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
            connection.Open()
            customerCmd.ExecuteNonQuery()
            connection.Close()
            SavePanelScreenshot()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            seatmapping.ClearBoardingPoint()
            Panel18.Hide()
            Panel10.Show()
        End If
    End Sub

    Private Sub name_leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Label27.Text = TextBox1.Text.ToUpper()
        Label27.Show()
        Label28.Show()
    End Sub

    Private Function GetNextCustomerId() As Integer
        Dim nextId As Integer = 1
        Dim query As String = "SELECT ISNULL(MAX(cid), 0) + 1 FROM customer_info"
        Using cmd As New SqlCommand(query, connection)
            connection.Open()
            Dim result As Object = cmd.ExecuteScalar()
            connection.Close()
            If result IsNot Nothing AndAlso IsNumeric(result) Then
                nextId = Convert.ToInt32(result)
            End If
        End Using
        Return nextId
    End Function

    Private Sub SavePanelScreenshot()
        Try
            ' Ensure Panel22 has a valid size before attempting to save
            If Panel22.Width > 0 AndAlso Panel22.Height > 0 Then
                Using saveFileDialog As New SaveFileDialog()
                    saveFileDialog.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|All files (*.*)|*.*"
                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        ' Create a bitmap with a compatible pixel format (24 bits per pixel, RGB)
                        Using bmp As New Bitmap(Panel22.Width, Panel22.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
                            ' Draw the Panel onto the Bitmap
                            Panel22.DrawToBitmap(bmp, New Rectangle(0, 0, Panel22.Width, Panel22.Height))

                            ' Ensure the file is saved in the correct format based on extension
                            Dim fileExt As String = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower()
                            If fileExt = ".png" Then
                                bmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)
                            ElseIf fileExt = ".jpg" OrElse fileExt = ".jpeg" Then
                                bmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                            Else
                                ' Default to PNG if no valid format is selected
                                bmp.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png)
                            End If

                            MessageBox.Show("Panel screenshot saved successfully.")
                        End Using
                    End If
                End Using
            Else
                MessageBox.Show("Panel has an invalid size. Cannot save image.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error saving image: {ex.Message}")
        End Try
    End Sub

    Private Sub email_leave(sender As Object, e As EventArgs) Handles TextBox2.Leave
        If Not TextBox2.Text.EndsWith("@gmail.com") Then
            MessageBox.Show("Email must end with '@gmail.com'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox2.Focus()
        End If
    End Sub

    Private Sub mobile_leave(sender As Object, e As EventArgs) Handles TextBox3.Leave
        If TextBox3.Text.Length < 10 OrElse Not IsNumeric(TextBox3.Text) Then
            MessageBox.Show("Mobile number must contain at least 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBox3.Focus()
        End If
    End Sub

End Class

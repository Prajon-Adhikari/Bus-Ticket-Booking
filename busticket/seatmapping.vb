Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Reflection.Emit
Public Class seatmapping

    Dim connection As New SqlConnection("Data Source=Prajon-PC\SQLEXPRESS01;Initial Catalog=bus_booking;Integrated Security=True;")
    Dim selectedSeats As New List(Of Integer)
    Public Property BusName As String
    Public Property BusId As Integer

    Public price As Integer
    Public numberofseat As Integer

    Public departcity As String
    Public reachcity As String
    Private Sub seatmapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnBook.Enabled = False ' Disable book button initially
        For i As Integer = 1 To 25
            Dim seatButton As Button = CType(Me.Controls("seat" & i.ToString()), Button)
            If seatButton IsNot Nothing Then
                AddHandler seatButton.Click, AddressOf SeatSelect
            End If
        Next
    End Sub

    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click

        FillComboBoxWithDatabaseData()
        Dim ticketCmd As SqlCommand = New SqlCommand("select b.bname, b.price, b.bustype, b.busdate, b.departuretime, b.reachingtime, a.departuringcity, a.reachingcity from bus_info b inner join address_info a on b.bid = a.a_bid where b.bid =  @bid", connection)
        ticketCmd.Parameters.AddWithValue("@bid", BusId)

        Dim ticketdataadapter As SqlDataAdapter = New SqlDataAdapter(ticketCmd)
        Dim ticketdt As DataTable = New DataTable
        ticketdataadapter.Fill(ticketdt)

        If ticketdt.Rows.Count > 0 Then
            Dim Row As DataRow = ticketdt.Rows(0)
            departcity = Row("departuringcity").ToString()
            reachcity = Row("reachingcity").ToString()

            homepage.Label26.Text = departcity + " to " + reachcity
            homepage.Label29.Text = Row("busdate").ToString()
            homepage.Label20.Text = Row("bname").ToString()
            homepage.Label21.Text = Row("bustype").ToString()
            homepage.Label22.Text = Row("departuretime").ToString()
            homepage.Label23.Text = Row("reachingtime").ToString()
            homepage.Label24.Text = Row("departuringcity").ToString()
            homepage.Label25.Text = Row("reachingcity").ToString()
            price = Row("price").ToString()
        End If
        homepage.Label39.Text = departcity + " - " + reachcity
        homepage.Label40.Text = homepage.Label29.Text
        homepage.Label42.Text = homepage.Label20.Text

        For Each i As Integer In selectedSeats
            numberofseat += 1
        Next

        homepage.Label43.Text = numberofseat * price
        homepage.Label44.Text = CInt(homepage.Label43.Text) * 0.1
        homepage.Label45.Text = CInt(homepage.Label43.Text) - CInt(homepage.Label44.Text)

        homepage.Panel18.Show()
        homepage.Panel1.Hide()
        homepage.Panel5.Hide()
        homepage.Panel10.Hide()
        homepage.Panel11.Hide()
        homepage.Label27.Hide()
        homepage.Label28.Hide()
        Me.Hide()
    End Sub

    Public Sub ClearBoardingPoint()
        homepage.ComboBox3.Items.Clear()
    End Sub
    Private Sub FillComboBoxWithDatabaseData()
        ' Connection string to your database
        Dim connectionString As String = "Data Source=Prajon-PC\SQLEXPRESS01;Initial Catalog=bus_booking;Integrated Security=True"

        ' SQL query to get the data for ComboBox
        Dim query As String = "SELECT p.places FROM places p where p.bid = @bid"


        ' Using block ensures that the connection is closed properly
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Try
                    ' Open the database connection
                    command.Parameters.AddWithValue("@bid", BusId)
                    connection.Open()

                    ' Execute the command and read data
                    Using reader As SqlDataReader = command.ExecuteReader()

                        ' Add an empty item at the first place in the ComboBox
                        homepage.ComboBox3.Items.Add("")

                        ' Loop through the data from the database
                        While reader.Read()
                            ' Add items to the ComboBox
                            homepage.ComboBox3.Items.Add(reader("places").ToString())
                        End While

                    End Using
                Catch ex As Exception
                    ' Handle any errors that occur during database connection
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub handleAfterBook()
        Dim bookedId As Integer = GetNextBookedId()

        For Each seatNumber In selectedSeats
            Dim seatId As Integer = GetSeatId(seatNumber)

            ' Update seat_map to mark seat as booked
            Dim updateSeatQuery As String = "UPDATE seat_map 
                                 SET isBooked = '1' 
                                 WHERE seat_number = @seatNumber 
                                 AND sid = (SELECT sid FROM seat WHERE bid = @busId)"
            Using cmd As New SqlCommand(updateSeatQuery, connection)
                cmd.Parameters.AddWithValue("@seatNumber", seatNumber)
                cmd.Parameters.AddWithValue("@busId", BusId)  ' Add busId to ensure only this bus is updated
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using


            ' Insert booking into booked_seat
            Dim insertBookingQuery As String = "INSERT INTO booked_seat (bookedId, bo_id, bo_seatid) VALUES (@bookedId, @userId, @seatId)"
            Using cmd As New SqlCommand(insertBookingQuery, connection)
                cmd.Parameters.AddWithValue("@bookedId", bookedId)
                cmd.Parameters.AddWithValue("@userId", GlobalVariable.UserId) ' Adjust to use the correct userId
                cmd.Parameters.AddWithValue("@seatId", seatId)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            ' Increment bookedId for the next seat
            bookedId += 1
        Next

        Dim updateavailableseat As SqlCommand = New SqlCommand("UPDATE b
                                                       SET b.availableseat = (SELECT COUNT(*)
                                                                              FROM seat_map sm
                                                                              WHERE sm.sid = s.sid AND sm.isBooked = 0)
                                                       FROM bus_info b
                                                       INNER JOIN seat s ON b.bid = s.bid
                                                       INNER JOIN seat_map sm ON s.sid = sm.sid
                                                      ", connection)

        connection.Open()
        updateavailableseat.ExecuteNonQuery()
        connection.Close()

        ' Disable all booked seats
        DisableBookedSeats()

        ' Show confirmation message
        MessageBox.Show("Booking Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Clear the selected seats list after booking
        selectedSeats.Clear()
    End Sub


    Private Sub DisableBookedSeats()
        For Each seatNumber In selectedSeats
            Dim seatButton As Button = CType(Me.Controls("seat" & seatNumber.ToString()), Button)
            If seatButton IsNot Nothing Then
                seatButton.BackColor = Color.Gray  ' Change booked seat color
                seatButton.Enabled = False         ' Disable the seat
            End If
        Next
    End Sub


    Private Function GetNextBookedId() As Integer
        Dim nextId As Integer = 1
        Dim query As String = "SELECT ISNULL(MAX(bookedId), 0) + 1 FROM booked_seat"
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


    Private Function GetSeatId(seatNumber As Integer) As Integer
        Dim seatId As Integer = 0
        Dim query As String = "SELECT seatId FROM seat_map sm inner join seat s on sm.sid = s.sid inner join bus_info b on s.bid = b.bid WHERE sm.seat_number = @seatNumber and b.bname = @busName"
        Using cmd As New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@seatNumber", seatNumber)
            cmd.Parameters.AddWithValue("@busName", BusName)
            connection.Open()
            Dim result As Object = cmd.ExecuteScalar()
            connection.Close()
            If result IsNot Nothing AndAlso IsNumeric(result) Then
                seatId = Convert.ToInt32(result)
            End If
        End Using
        Return seatId
    End Function

    Private Sub SeatSelect(sender As Object, e As EventArgs)
        Dim clickedSeat As Button = CType(sender, Button)
        Dim seatNumber As Integer = Convert.ToInt32(clickedSeat.Name.Replace("seat", ""))
        Dim selectedSeatsText As String = homepage.Label41.Text

        If selectedSeats.Contains(seatNumber) Then
            ' Remove the seat number from the list
            selectedSeats.Remove(seatNumber)
            clickedSeat.BackColor = Color.SkyBlue

            ' Remove seatNumber from Label41.Text
            Dim seatNumbers As List(Of String) = selectedSeatsText.Split(","c).ToList()
            seatNumbers.Remove(CStr(seatNumber))
            homepage.Label41.Text = String.Join(",", seatNumbers)
        Else
            ' Add the seat number to the list
            selectedSeats.Add(seatNumber)
            clickedSeat.BackColor = ColorTranslator.FromHtml("#FFDC7F")

            ' Add seatNumber to Label41.Text
            If selectedSeatsText = "" Then
                homepage.Label41.Text = CStr(seatNumber)
            Else
                homepage.Label41.Text = selectedSeatsText + "," + CStr(seatNumber)
            End If
        End If

        btnBook.Enabled = selectedSeats.Count > 0
    End Sub

    Public Sub ClearSelectedSeats()
        selectedSeats.Clear()
        homepage.Label41.Text = ""
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim p As Pen = New Pen(Brushes.Black, 1)
        Dim lp As Pen = New Pen(Brushes.Gray, 1)
        e.Graphics.DrawLine(p, 0, 80, 300, 80)
    End Sub

End Class

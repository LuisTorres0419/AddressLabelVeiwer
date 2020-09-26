'Luis Torres
'RCET0265
'Spring 2020
'Address Label
'https://github.com/LuisTorres0419/AddressLabelVeiwer.git


Public Class AddressLabelVeiwerForm

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

        Dim textBox As Control

        AddressLabelLabel.Text = ""

        For Each textBox In Me.Controls

            If TypeOf textBox Is TextBox Then

                textBox.Text = ""

            End If

        Next



    End Sub

    Private Sub DisplayLabelButton_Click(sender As Object, e As EventArgs) Handles DisplayLabelButton.Click
        ValidateTextBoxes()

        If Accumulatemessage("", False) <> "" Then
            AlertUser(Accumulatemessage("", False))
        Else
            Display()
        End If

    End Sub


    Sub ValidateTextBoxes()
        Dim problem As Boolean = False
        If FirstNamedTextBox.Text = "" Then
            Accumulatemessage("First Name Pls", False)
            FirstNamedTextBox.Focus()
            problem = False
        End If

        If LastNameTextBox.Text = "" Then
            Accumulatemessage("Last Name Pls", False)
            LastNameTextBox.Focus()
            problem = False
        End If

        If StreetAddressTextBox.Text = "" Then
            Accumulatemessage("Street name Pls", False)
            StreetAddressTextBox.Focus()
            problem = False
        End If

        If CityTextBox.Text = "" Then
            Accumulatemessage("City Name Pls", False)
            CityTextBox.Focus()
            problem = False
        End If

        If StateTextBox.Text = "" Then
            Accumulatemessage("State Name Pls", False)
            StateTextBox.Focus()
            problem = False
        End If


        If ZipCodeTextBox.Text = "" And Not problem Then
            CreateZipCode()
        End If

    End Sub

    Sub AlertUser(ByVal messege As String)
        MsgBox(messege)
        Accumulatemessage("", True)
    End Sub

    Function Accumulatemessage(ByVal newMessage As String, ByVal clear As Boolean) As String

        Static message As String

        If clear Then
            message = ""
        ElseIf newMessage <> "" Then
            message &= newMessage & vbNewLine
        End If

        Return message
    End Function

    Sub CreateZipCode()
        ZipCodeTextBox.Text = "83***"
    End Sub

    Sub Display()


        AddressLabelLabel.Text = FirstNamedTextBox.Text _
            & vbNewLine & LastNameTextBox.Text _
            & vbNewLine & StreetAddressTextBox.Text _
            & vbNewLine & CityTextBox.Text _
            & vbNewLine & StateTextBox.Text & "," _
            & ZipCodeTextBox.Text


    End Sub

End Class

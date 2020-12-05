Imports System.IO

Class BoardingPass
    Public row As Integer
    Public column As Integer
    Public seat As Integer

End Class

Module InputReaderDay5
    Public Function readInput(filename As String) As ArrayList

        Dim boardingPasses As ArrayList = New ArrayList

        Dim reader As StreamReader = New StreamReader(filename)


        While (reader.Peek <> -1)

            Dim boardingPass As BoardingPass = New BoardingPass

            Dim line = reader.ReadLine

            Dim lineChars() = line.ToCharArray()

            Dim row As Integer = 0
            Dim column As Integer = 0

            For index As Integer = 0 To 6
                If lineChars(index) = "B" Then
                    row = row << 1
                    row = row Or 1
                Else
                    row = row << 1
                End If
            Next

            For index As Integer = 7 To 9
                If lineChars(index) = "R" Then
                    column = column << 1
                    column = column Or 1
                Else
                    column = column << 1
                End If
            Next

            boardingPass.row = row
            boardingPass.column = column
            boardingPass.seat = row * 8 + column

            boardingPasses.Add(boardingPass)

        End While
        Return boardingPasses
    End Function
End Module

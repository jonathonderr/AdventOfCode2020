Imports System.IO
Imports System.Numerics
Module Day11
    Public Function readInput(filename As String) As BigInteger

        Dim reader As StreamReader = New StreamReader(filename)


        Dim seats = New List(Of List(Of Char))


        While reader.Peek <> -1
            Dim line = reader.ReadLine

            Dim seatLine = New List(Of Char)

            For Each seat As Char In line.ToArray
                seatLine.Add(seat)
            Next

            seats.Add(seatLine)

        End While

        For seatIterator = 1 To 200

            Dim newList = New List(Of List(Of Char))

            Dim y = 0

            While y < seats.Count

                Dim x = 0
                Dim seatLine = seats.Item(y)

                Dim newSeatLine = New List(Of Char)



                While x < seatLine.Count
                    Dim seat = seats.Item(y).Item(x)

                    Dim adjacentArray = New List(Of Char)

                    For adjacentYOffset = -1 To 1
                        For adjacentXOffset = -1 To 1
                            Dim adjacentX = x + adjacentXOffset
                            Dim adjacentY = y + adjacentYOffset
                            Dim isCurrSeat = adjacentX = x And adjacentY = y

                            If Not adjacentX < 0 And Not adjacentX >= seatLine.Count And Not adjacentY < 0 And Not adjacentY >= seats.Count And Not isCurrSeat Then
                                Dim foundSeat = False
                                While Not adjacentX < 0 And Not adjacentX >= seatLine.Count And Not adjacentY < 0 And Not adjacentY >= seats.Count And Not foundSeat
                                    Dim adjacentSeat = seats.Item(adjacentY).Item(adjacentX)
                                    'Console.WriteLine(adjacentSeat & ": " & adjacentY & ", " & adjacentX)


                                    If adjacentSeat = "L" Or adjacentSeat = "#" Then
                                        foundSeat = True
                                        adjacentArray.Add(adjacentSeat)
                                    End If

                                    adjacentY += adjacentYOffset
                                    adjacentX += adjacentXOffset
                                End While
                            End If
                        Next
                    Next

                    If Not adjacentArray.Contains("#") And seat = "L" Then
                        newSeatLine.Add("#")
                    ElseIf seat = "#" And adjacentArray.FindAll(Function(c) c = "#").Count >= 5 Then
                        newSeatLine.Add("L")
                    Else
                        newSeatLine.Add(seat)
                    End If

                    x += 1
                End While

                newList.Add(newSeatLine)
                y += 1
            End While

            seats = New List(Of List(Of Char))


            For Each line In newList
                Dim newSeatLine = New List(Of Char)
                For Each seat In line
                    newSeatLine.Add(seat)
                Next
                seats.Add(newSeatLine)
            Next


            Dim count = 0

            For Each seatLine In seats
                For Each seat In seatLine
                    If seat = "#" Then
                        count += 1
                    End If
                    'Console.Write(seat)
                Next
                'Console.WriteLine()
            Next

            Console.WriteLine(count)

        Next



        Return 0
    End Function

End Module

Imports System.IO
Module Day9
    Public Function readInput(filename As String) As Long

        Dim reader As StreamReader = New StreamReader(filename)

        Dim line = reader.ReadLine

        Dim currentPreamble As List(Of Long) = New List(Of Long)

        Dim preamble = 25

        Dim nonRule = 0

        Dim vals = New List(Of Long)

        For index = 0 To preamble - 1
            currentPreamble.Add(line)
            line = reader.ReadLine
            vals.Add(line)
        Next

        While reader.Peek <> -1

            Dim followsRules = False

            For Each value In currentPreamble
                followsRules = currentPreamble.Contains(line - value) Or followsRules
            Next

            If Not followsRules Then
                Console.WriteLine(line)
                nonRule = line
            End If

            currentPreamble.RemoveRange(0, 1)
            currentPreamble.Insert(currentPreamble.Count, line)
            vals.Add(line)
            line = reader.ReadLine
        End While

        Dim sum = 177777905
        Dim range = New List(Of Long)
        Dim currentSum = 0
        Dim start = 0

        For index = 0 To 490

            currentSum += vals.Item(index)

            While currentSum > sum And start < index
                currentSum = currentSum - vals.Item(start)
                start += 1
            End While

            If currentSum = sum Then
                Console.WriteLine("Found Range between " & start & ": " & vals.Item(start) & "and " & index & ": " & vals.Item(index))
            End If

        Next

        Dim min = -1
        Dim max = 0

        For testIndex = 465 To 481
            Dim item = vals.Item(testIndex)
            If item < min Or min = -1 Then
                min = item
            End If

            If item > max Then
                max = item
            End If
        Next

        Console.WriteLine(min)
        Console.WriteLine(max)
        Console.WriteLine(min + max)



        Return nonRule = 0
    End Function

End Module

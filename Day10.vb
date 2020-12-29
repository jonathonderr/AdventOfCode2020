Imports System.IO
Imports System.Numerics
Module Day10
    Public Function readInput(filename As String) As BigInteger

        Dim reader As StreamReader = New StreamReader(filename)

        Dim line = reader.ReadLine

        Dim adapters = New List(Of BigInteger)

        While reader.Peek <> -1
            adapters.Add(line)

            line = reader.ReadLine
        End While

        adapters.Add(line)

        adapters.Sort()

        Dim prevAdapter = 0
        Dim jumps1 = 0
        Dim jumps3 = 0

        Dim diffs = New List(Of BigInteger)

        For Each adapter As ULong In adapters
            Console.Write(adapter & ", ")

            Dim diff = (adapter - prevAdapter)
            If diff = 1 Then
                jumps1 += 1
            ElseIf diff = 3 Then
                jumps3 += 1
            End If

            diffs.Add(diff)

            prevAdapter = adapter
        Next

        Console.WriteLine(jumps1)
        Console.WriteLine(jumps3 + 1)

        Dim gaps = New List(Of BigInteger)

        Dim num1 = 0

        Console.WriteLine("-----------------------------")

        adapters.Insert(0, 0)
        adapters.Add(adapters.Last() + 3)

        Dim array = New List(Of BigInteger)
        array.Add(1)

        For i = 1 To adapters.Count - 1
            Dim ans As BigInteger = 0
            For j = 0 To i - 1
                If adapters.Item(j) + 3 >= adapters.Item(i) Then
                    ans += array.Item(j)
                End If
            Next
            array.Add(ans)
        Next

        For Each value In array
            Console.WriteLine(value)
        Next


        Return 0
    End Function

End Module

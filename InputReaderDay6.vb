Imports System.IO

Module InputReaderDay6
    Public Function readInput(filename As String) As ArrayList

        Dim groups As ArrayList = New ArrayList

        Dim reader As StreamReader = New StreamReader(filename)


        Dim finalCount = 0

        While (reader.Peek <> -1)


            Dim line = reader.ReadLine


            Dim chars = "abcdefghijklmnopqrstuvwxyz".ToCharArray

            While (Not String.IsNullOrEmpty(line))

                chars = chars.Intersect(line.ToCharArray).ToArray

                line = reader.ReadLine

            End While

            finalCount += chars.Length

            Console.WriteLine(finalCount)


        End While
        Return groups
    End Function
End Module

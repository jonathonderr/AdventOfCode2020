Module Day3
    Public Function countTrees(inputArray As ArrayList) As Integer

        Dim i = 2
        Dim x = 0

        Dim treeCount = 0

        While (i < inputArray.Count)
            x += 1

            Dim treeline As String = inputArray.Item(i)


            Dim tree As Boolean = (GetChar(treeline, (x Mod treeline.Length) + 1) = "#")

            If tree Then
                treeCount += 1
            End If

            i += 2

        End While

        Console.WriteLine("N-Count: " & inputArray.Count)
        Return treeCount
    End Function
End Module

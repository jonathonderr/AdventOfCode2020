Module Day5
    Public Function findBoardingPass(boardingPasses As ArrayList) As Integer

        Dim orderedPasses = boardingPasses.Cast(Of BoardingPass)() _
            .OrderBy(Function(pass As BoardingPass) Convert.ToInt32(pass.seat))

        Dim max = 0

        For Each boardingPass As BoardingPass In boardingPasses
            If max < boardingPass.seat Then
                max = boardingPass.seat
            End If
        Next


        For index As Integer = 0 To orderedPasses.Count
            Dim boardingPass As BoardingPass = orderedPasses(index)
            Dim nextBoardingPass As BoardingPass = orderedPasses(index + 1)

            If boardingPass.seat + 1 <> nextBoardingPass.seat Then
                Console.WriteLine(boardingPass.seat + 1)
            End If
        Next


        Return 0
    End Function
End Module

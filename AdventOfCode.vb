Imports System

Module AdventOfCode
    Sub Main(args As String())
        Dim boardingPasses = InputReaderDay5.readInput("input.txt")
        Console.WriteLine(Day5.findBoardingPass(boardingPasses))
    End Sub
End Module

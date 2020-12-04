Imports System

Module AdventOfCode
    Sub Main(args As String())
        Dim treeLines = InputReader.readInput("input.txt")
        Console.WriteLine(Day4.validPassports(treeLines))
    End Sub
End Module

Imports System.IO
Module Day8
    Public Function readInput(filename As String) As ArrayList

        Dim groups As ArrayList = New ArrayList

        Dim reader As StreamReader = New StreamReader(filename)

        Dim line = reader.ReadLine

        Dim upIndex = 0

        While reader.Peek <> -1

            Dim accumulator = 0

            Dim offset = 0

            Dim visited As List(Of Integer) = New List(Of Integer)

            Dim index = 1

            Dim inst = line.Split(" ")(0)

            If inst.Equals("jmp") Or inst.Equals("nop") Then

                inst = If(inst = "jmp", "nop", "jmp")
                Dim terminated = Not visited.Contains(index)

                While index < 652 And terminated
                    Dim i = index
                    visited.Add(i)

                    Dim instruction = ReadLineWithNumberFrom(filename, index)

                    Dim parts = instruction.Split(" ")

                    Dim cmd = parts(0)

                    If index = (upIndex + 1) Then
                        cmd = inst
                    End If


                    Dim amnt As Integer = parts(1)

                    Select Case cmd
                        Case "acc"
                            accumulator += amnt
                            index += 1
                        Case "jmp"
                            index += amnt
                        Case Else
                            index += 1
                    End Select

                    terminated = Not visited.Contains(index)

                End While

                If terminated Then
                    Console.WriteLine(upIndex & ":" & terminated & " : " & accumulator)

                End If

            End If

            line = reader.ReadLine

            upIndex += 1

        End While


        Return groups
    End Function

    Function ReadLineWithNumberFrom(filePath As String, ByVal lineNumber As Integer) As String
        Using file As New StreamReader(filePath)
            ' Skip all preceding lines: '
            For i As Integer = 1 To lineNumber - 1
                If file.ReadLine() Is Nothing Then
                    Throw New ArgumentOutOfRangeException("lineNumber")
                End If
            Next
            ' Attempt to read the line you're interested in: '
            Dim line As String = file.ReadLine()
            If line Is Nothing Then
                Throw New ArgumentOutOfRangeException("lineNumber")
            End If
            ' Succeded!
            Return line
        End Using
    End Function

End Module

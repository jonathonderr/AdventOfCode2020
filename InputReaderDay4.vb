Imports System.IO
Module InputReaderDay4
    Public Function readInput(filename As String) As ArrayList
        Dim passports As ArrayList = New ArrayList

        Dim reader As StreamReader = New StreamReader(filename)


        While (reader.Peek <> -1)

            Dim passport As Passport = New Passport

            Dim line = reader.ReadLine


            While (Not String.IsNullOrEmpty(line))

                Dim parts() As String = Text.RegularExpressions.Regex.Split(line, "\:|\s")

                Dim i = 0
                While (i < parts.Count)
                    Select Case parts(i)
                        Case "byr"
                            passport.byr = parts(i + 1)
                        Case "iyr"
                            passport.iyr = parts(i + 1)
                        Case "eyr"
                            passport.eyr = parts(i + 1)
                        Case "hgt"
                            passport.hgt = parts(i + 1)
                        Case "hcl"
                            passport.hcl = parts(i + 1)
                        Case "ecl"
                            passport.ecl = parts(i + 1)
                        Case "pid"
                            passport.pid = parts(i + 1)
                        Case "cid"
                            passport.cid = parts(i + 1)
                    End Select
                    i += 2
                End While

                line = reader.ReadLine
            End While

            passports.Add(passport)
        End While
        Return passports
    End Function
End Module

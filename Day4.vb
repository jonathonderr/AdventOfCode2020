Imports System.IO
Imports System.Text.RegularExpressions

Class Passport
    Public byr As Integer
    Public iyr As Integer
    Public eyr As Integer
    Public hgt As String
    Public hcl As String
    Public ecl As String
    Public pid As String
    Public cid As Integer
End Class

Module Day4
    Public Function validPassports(passports As ArrayList)

        Dim i = 0

        Dim validCount = 0

        While (i < passports.Count)

            Dim passport As Passport = passports.Item(i)

            If (passport.byr And passport.iyr And passport.eyr And passport.hgt IsNot Nothing And passport.hcl IsNot Nothing And passport.ecl IsNot Nothing And passport.pid IsNot Nothing) Then
                Dim byrValid As Boolean = (passport.byr >= 1920 And passport.byr <= 2002)
                Dim iyrValid As Boolean = (passport.iyr >= 2010 And passport.iyr <= 2020)
                Dim eyrValid As Boolean = (passport.eyr >= 2020 And passport.eyr <= 2030)

                Dim hgtValid = Regex.Match(passport.hgt, "^(1([5-8][0-9]|9[0-3])cm)|(59|6[0-9]|7[0-6])in$").Success
                Dim hclValid = Regex.Match(passport.hcl, "^#(\d|[abcdef]){6}$").Success
                Dim eclValid = Regex.Match(passport.ecl, "^(amb|blu|brn|gry|grn|hzl|oth)$").Success
                Dim pidValid = Regex.Match(passport.pid, "^\d{9}(\d{2})?$").Success

                If (byrValid And iyrValid And eyrValid And hgtValid And hclValid And eclValid And pidValid) Then
                    validCount += 1
                End If
            End If

            i += 1
        End While

        Return validCount

    End Function
End Module

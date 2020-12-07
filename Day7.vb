Imports System.IO

Class Bag
    Public name As String
    Public amnt As Integer
    Public contains As List(Of Bag) = New List(Of Bag)
    Public containsAmnt As List(Of Integer) = New List(Of Integer)
    Public containedBy As List(Of Bag) = New List(Of Bag)

    Public Overrides Function ToString() As String
        Return name
    End Function
End Class

Module Day7
    Public Function readInput(filename As String) As ArrayList

        Dim groups As ArrayList = New ArrayList

        Dim reader As StreamReader = New StreamReader(filename)


        Dim finalCount = 0
        Dim bags = New List(Of Bag)

        Dim line = reader.ReadLine


        While (reader.Peek <> -1)


            Dim partSpace As String() = line.Split(" ")

            Dim bagName = partSpace(0) & " " & partSpace(1)

            Dim bag = bags.Find(Function(b) b.name = bagName)

            If bags.Find(Function(b) b.name = bagName) Is Nothing Then
                bag = New Bag
                bag.name = bagName
                bags.Add(bag)
            End If


            Dim partsAmount = line.Split("contain ")(1)
            Dim containedBagsString() = partsAmount.Split(", ")

            If Not containedBagsString(0).Equals("no other bags.") Then
                For Each bagString In containedBagsString
                    Dim bagParts = bagString.Split(" ")
                    Dim containedBag = bags.Find(Function(b) b.name = (bagParts(1) & " " & bagParts(2)))
                    If containedBag Is Nothing Then
                        containedBag = New Bag
                        containedBag.amnt = 0
                        containedBag.name = bagParts(1) & " " & bagParts(2)
                        bags.Add(containedBag)
                    End If

                    containedBag.containedBy.Add(bag)
                    bag.containsAmnt.Add(Convert.ToInt32(bagParts(0)))
                    bag.contains.Add(containedBag)


                Next
            End If
            line = reader.ReadLine
        End While



        Dim validBags = New List(Of Bag)
        Dim searching = New ArrayList
        searching.Add("shiny gold")

        While searching.Count()

            'Console.WriteLine(String.Join(", ", searching.ToArray))

            Dim name = searching.Item(0)
            searching.RemoveAt(0)

            Dim bag = bags.Find(Function(b) b.name = name)

            For Each containedByBag As Bag In bag.containedBy
                If validBags.Find(Function(b) b.name = containedByBag.name) Is Nothing Then
                    validBags.Add(containedByBag)
                    searching.Add(containedByBag.name)
                End If
            Next

        End While

        'For Each bag In bags
        'Console.WriteLine(bag)
        'Console.WriteLine(bag.amnt & ": " & String.Join(", ", bag.contains))
        'Console.WriteLine()
        'Next
        Console.WriteLine(validBags.Count)
        ' Bag includes itself hence the subtract 1
        Console.WriteLine(countBags(bags.Find(Function(b) b.name = "shiny gold")) - 1)
        Return groups
    End Function

    Function countBags(b As Bag) As Integer
        Dim retVal = 1
        If b.contains.Count <> 0 Then
            For index = 0 To b.contains.Count - 1
                retVal += b.containsAmnt(index) * countBags(b.contains(index))
            Next
        End If
        Return retVal
    End Function

End Module

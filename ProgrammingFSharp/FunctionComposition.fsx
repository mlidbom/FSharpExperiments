open System.IO

let sizeOfFolder = 
    let getFiles folder = Directory.GetFiles(folder)
    getFiles >> Seq.map (fun file -> new FileInfo(file)) >> Seq.map (fun info -> info.Length) >> Seq.sum

let sizeOfFolder2 x =
    let getFiles folder = Directory.GetFiles(folder)
    getFiles x |> Seq.map (fun file -> new FileInfo(file)) |> Seq.map (fun info -> info.Length) |> Seq.sum 


let square x = x * x
let toString x = x.ToString()
let strLen (s:string) = s.Length

let lengthOfSquare = square >> toString >> strLen



let negate x = -x

//Useless examples of backward composition operator
(negate >> square) 10
(square << negate) 10
(square >> negate) 10
(square >> negate) 10

//useful examples of backwards composition operator

let listWithEmptyLists = [[];[1;2];[3];[];[];[4;5;6]]

let cleanedList = listWithEmptyLists |> List.filter (not << List.isEmpty) |> List.concat //"not list.isempty" Reads better than "list.isempty not"
let cleanedList2 = listWithEmptyLists |> List.filter (List.isEmpty >> not) |> List.concat


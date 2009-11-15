
//ordinare recursive reverse.
let rec reverse theList = 
    match theList with
    | [] -> []
    | head::tail -> (reverse tail) @ [head]



let reverseWithFold theList = List.fold (fun reversed current -> current :: reversed ) [] theList
let reverseWithFoldBack theList = List.foldBack (fun current reversed -> reversed @ [current]) theList [] //Not recommended, append(@) is slow

let myInts = [1..10]
let reversed = myInts |> reverse
let reversedWithFold =  myInts |> reverseWithFold
let reversedWithFoldBack =  myInts |> reverseWithFoldBack

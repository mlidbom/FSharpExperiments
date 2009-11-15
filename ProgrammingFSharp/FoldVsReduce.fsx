open System

let ints = [1..10]

//Folds are more complex for the simple case...
let sumReduce = ints |> List.reduce (+)
let sumFold = ints |> List.fold (+) 0

//Only folds can return a different type from the content elements of the list
let stringOfInts = ints |> List.fold (fun aggregate current -> aggregate + "," + current.ToString()) ""

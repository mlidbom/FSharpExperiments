
open System
open System.Numerics

let product1  numbers = numbers |> Seq.fold (*) (1I)

let rec product2 numbers = 
    match numbers with
    | [] -> 1I
    | head::tail -> head * product2 tail
    

let factorial1 n = product1 [1I..n]
let factorial2 n = product2 [1I..n]


let biggerThanStack = 37000I

let test1 = factorial1 biggerThanStack
let test2 = factorial2 biggerThanStack

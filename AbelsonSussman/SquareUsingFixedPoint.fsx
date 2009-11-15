
#load "Algorithms.fsx"
open Algorithms

let averageDamp f = 
    let average x y = (x + y) / 2.
    fun x -> average x (f x)

let withinTolerance tolerance x y =
    abs(x - y) < tolerance 

let sqrtFixedPoint x = fixedPoint (averageDamp ((/) x)) (withinTolerance 0.0000001) 1.



let derivate f x =   
    let dx = 0.00000001
    ( f (x + dx) - f x) / dx

let newtonRoot f startGuess = 
    let f' = derivate f
    let newtonFormula x = x - (f x) / (f' x)
    fixedPoint newtonFormula (withinTolerance 0.0000001) startGuess

let sqrtNewton x = newtonRoot (fun y -> x - (y ** 2.0) ) 1.

let my2 = sqrtFixedPoint 35.0

let sqrtByNewton = sqrtNewton 35.

 
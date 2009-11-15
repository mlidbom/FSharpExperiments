
let fixedPoint nextGuess initialGuess x =     
    let tolerance = 0.000001
    let rec tryGuess lastGuess guess =  
        if abs(lastGuess - guess) < tolerance 
        then guess 
        else tryGuess guess (nextGuess guess)
    
    tryGuess initialGuess (nextGuess initialGuess)

let averageDamp f = 
    let average x y = (x + y) / 2.
    fun x -> average x (f x)

let sqrtFixedPoint x = fixedPoint (averageDamp ((/) x)) 1. x



let derivate f x =   
    let dx = 0.00000001
    ( f (x + dx) - f x) / dx

let newtonRoot f startGuess = 
    let f' = derivate f
    let newtonFormula x = x - (f x) / (f' x)
    fixedPoint newtonFormula startGuess

let sqrtNewton x = newtonRoot (fun y -> x - (y ** 2.0) ) 1. x

let my2 = sqrtFixedPoint 35.0

let sqrtByNewton = sqrtNewton 35.

 
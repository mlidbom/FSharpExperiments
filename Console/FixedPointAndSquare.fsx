
let squareRootGoodEnough guess x = (abs (guess * guess - x)) < 0.0001

let fixedPoint goodEnough x = 
    let average (x:float) y = (x + y) / 2.
    let improve guess x = average guess (x / guess)
    
    let rec tryGuess guess = if goodEnough guess x then guess else tryGuess (improve guess x)
    tryGuess 1.

let sqrt = fixedPoint squareRootGoodEnough


let my2 = sqrt 36.0


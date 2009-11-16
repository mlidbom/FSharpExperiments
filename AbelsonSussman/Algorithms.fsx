
module Algorithms

let fixedPoint nextGuess goodEnough initialGuess =         
    let rec tryGuess lastGuess guess =  
        if goodEnough lastGuess guess
        then guess 
        else tryGuess guess (nextGuess guess)
    
    tryGuess initialGuess (nextGuess initialGuess)

let monteCarlo trials test =
    let rec doTest passed remaining = 
        match remaining with
        | 0 -> float passed / float trials
        | n -> doTest (if test() then passed + 1 else passed) (remaining - 1)

    doTest 0 trials        
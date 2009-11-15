
module Algorithms
let fixedPoint nextGuess goodEnough initialGuess =         
    let rec tryGuess lastGuess guess =  
        if goodEnough lastGuess guess
        then guess 
        else tryGuess guess (nextGuess guess)
    
    tryGuess initialGuess (nextGuess initialGuess)
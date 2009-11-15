
module Algorithms
    let fixedPoint nextGuess initialGuess x =     
        let tolerance = 0.000001
        let rec tryGuess lastGuess guess =  
            if abs(lastGuess - guess) < tolerance 
            then guess 
            else tryGuess guess (nextGuess guess)
        
        tryGuess initialGuess (nextGuess initialGuess)

    let fixedPoint nextGuess initialGuess x =     
        let tolerance = 0.000001
        let rec tryGuess lastGuess guess =  
            if abs(lastGuess - guess) < tolerance 
            then guess 
            else tryGuess guess (nextGuess guess)
        
        tryGuess initialGuess (nextGuess initialGuess)
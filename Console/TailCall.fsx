let largerThanMaxStack = 50000

let rec multiply_naive number times = 
        match times with
        | 0 -> 0
        | 1 -> number        
        | n -> number + multiply_naive number (times - 1)


let multiply number times = 
    let rec multiply_with_accumulator number times accu =
        match times with
        | 0 -> 0
        | 1 -> accu + number        
        | n -> multiply_with_accumulator number (times - 1) (number + accu)
    multiply_with_accumulator number times 0


let broken = multiply_naive 1 largerThanMaxStack
let result = multiply 1 largerThanMaxStack
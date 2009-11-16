#load "Algorithms.fsx"
open Algorithms


//##########THIS IS VERY BADLY BROKEN. I'M GUESSING IT'S BECAUSE OF THE .NET RANDOM NUMBER GENERATOR############333

let rec gcd x y = if y = 0 then x else gcd y (x % y)

let rnd() = abs(int ((new System.Random()).NextDouble() * 100.0 - 10.0))

let noCommonDenominator x y = 
    gcd x y = 1

let randomNumbersHaveNoCommonDenominator() = 
    noCommonDenominator (rnd()) (rnd())

let cesaro(n) = sqrt (6.0 / (monteCarlo n randomNumbersHaveNoCommonDenominator) )

let my2 = gcd 7 10
let test = monteCarlo 2000000 randomNumbersHaveNoCommonDenominator

let test2 = cesaro(2000000)





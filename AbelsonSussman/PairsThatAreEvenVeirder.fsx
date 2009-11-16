


let MakePair =  fun first second -> fun selector -> selector first second
let First  = fun pair -> pair (fun first second -> first)
let Second = fun pair -> pair (fun first second -> second)

let oneAndTwo = MakePair 1 2
let one = First oneAndTwo
let two = Second oneAndTwo


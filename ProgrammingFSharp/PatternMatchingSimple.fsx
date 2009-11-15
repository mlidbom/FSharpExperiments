
let testXor x y = 
    match x, y with
    | tuple when fst tuple = snd tuple -> true
    | true, true -> false
    | false, false -> false

let testXor2 x y = 
    match x, y with
    | tuple when fst tuple <> snd tuple -> true
    | _, _ -> false


testXor true false
testXor false true

testXor false false
testXor true true 

testXor2 true false
testXor2 false true

testXor2 false false
testXor2 true true 



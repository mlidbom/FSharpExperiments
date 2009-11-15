
type pairIndex = First | Second

let makePair x y = function 
    | First -> x
    | Second -> y

let first x = x First
let second x = x Second

let pairOf2And4 = makePair 2 4

let first2 =  first pairOf2And4
let second4 = second pairOf2And4



 

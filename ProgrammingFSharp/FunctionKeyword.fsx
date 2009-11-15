
//Convenient way to go directly to pattern matching over the last parameter
let add2IfTrue x = function 
    | true -> x + 2
    | false -> x

//single tuple argument
let myAnd = function
    | true, true -> true
    | _, _ -> false

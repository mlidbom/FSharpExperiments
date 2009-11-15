//All methods in this file are EXACLY SEMANTICALLY IDENTICAL!
//all but the first form simply uses different amounts of syntactic sugar 
//whenever you encounter a -> operator, everything to the right of it is what the function returns. None of it is parameters to that function, it's what the function RETURNS!

let mytuple = fun x -> (fun y -> (fun z -> (x, y, z)))

let mytuple2 = fun x -> fun y -> fun z -> (x, y, z) //you can ommit the parenthesis since -> operator binds right

let mytuple3 x = fun y -> fun z -> (x, y, z) //move the first function's argument to the left hand side 
let mytuple4 x y = fun z -> (x, y, z)        //move the second function's argument to the left hand side 
let mytuple5 x y z = (x,  y, z)              //move the third function's argument to the left hand side

//All these calls are exactly identical since function calls bind left
//all calls but the first simply use the fact that function calls bind left
let result1 = (((mytuple 1) 2) 3)
let result2  = ((mytuple 1) 2) 3
let result3  = (mytuple 1) 2 3
let result4  = mytuple 1 2 3
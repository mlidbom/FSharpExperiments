//woa, that's uncomfortable.

let abs x = if x < 0 then -x else x 

let rec isOdd x = if x = 0 then false else isEven (abs x - 1)
and isEven x = if x = 0 then true else isOdd (abs x - 1)


let rec odd n = (n <> 0) && even (abs n - 1)
and even n = (n = 0) || odd (abs n - 1)

even 4
even 5
odd 4
odd 5

even -4
even -5
odd -4
odd -5


isEven 4
isEven 5
isOdd 4
isOdd 5

isEven -4
isEven -5
isOdd -4
isOdd -5




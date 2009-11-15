

//forward is a beauty.
[1..10] |> List.map ((*)2)


let square x = x * x
//Backwards... Not seen convincing use for it yet. This is the example from the book
//Backwards pipe lets:
printf "%d" (square 12)
//become:
printf "%d" <| square 12 //And what was the point? Getting rid of a parenthesis apparently

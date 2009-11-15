open System

let asInt str = 
    let successful , result = Int32.TryParse str//note handling the out parameter and the actual return value as a tuple return value....
    if successful then Some result
    else None

let isInt str = 
    match asInt str with
    | Some int -> true
    | None -> false

let blah = asInt "12"
let blah1 = asInt "12oeu"

let test = isInt "12"
let test2 = isInt "12o"
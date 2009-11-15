open System

let add1 x = x + 1

let apply2 f = f << f
let apply4 f = (apply2 << apply2) f

let add2 = apply2 add1
let add4 = (apply2 << apply2) add1

let i2 = add2 0
let i4 = add4 0


let rec apply_times n f = 
    match n with
    | 0 -> fun x -> x
    | 1 -> f
    | n -> f << apply_times (n - 1) f

let add10 = apply_times 10 add1

let i10 = add10 0




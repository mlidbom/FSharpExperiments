open System.Diagnostics
open System.Collections.Generic

let memoize (f : 'a -> 'b) = 
    let dict = new Dictionary<'a,'b>()

    let memoizedFunc (input: 'a) =         
        match dict.TryGetValue(input) with
        | true, x -> x
        | false, _ ->
            let answer = f input
            dict.Add (input, answer)
            answer
    memoizedFunc

let rec fib = function 
    | 0 | 1 -> 1
    | 2 -> 2
    | n -> fib( n - 1 ) + fib( n - 2 )

let wrongMemFib = 
    let rec fib = function 
        | 0 | 1 -> 1
        | 2 -> 2
        | n -> fib( n - 1 ) + fib( n - 2 )
    memoize fib

let rec rightMemFib = 
    let fib = function
        |0 | 1 -> 1
        | 2 -> 2
        | n -> rightMemFib( n - 1 ) + rightMemFib( n - 2 )
    
    memoize fib

let time f x = 
    let watch = new Stopwatch()
    watch.Start()
    let result = f x
    result, watch.ElapsedMilliseconds

let result1, wrongTime = time wrongMemFib 45 // Real: 00:00:21.574, CPU: 00:00:21.574, GC gen0: 0, gen1: 0, gen2: 0
let result2, rightTime = time rightMemFib 45 // Real: 00:00:00.003, CPU: 00:00:00.000, GC gen0: 0, gen1: 0, gen2: 0

let factor = double wrongTime / double rightTime // About 6,000 times faster!

#r "nunit.framework.dll"
#r "FSharp.PowerPack.Parallel.Seq.dll"

open Microsoft.FSharp.Collections
open System.Threading

 
let workItems = seq{
        for i in 1..100 -> async { 
        printfn "Executing step %d on thread %A" i Thread.CurrentThread.ManagedThreadId
        return i
        }
    }


let result = workItems |> Async.Parallel |> Async.RunSynchronously

open NUnit.Framework

Assert.That(result, Is.EquivalentTo [1..100])

let workItemsThatThrow = seq{
        for i in 1..100 -> async { 
        printfn "Executing step %d on thread %A" i Thread.CurrentThread.ManagedThreadId
        if i > 50 then failwith "Duh"
        return i 
        }
    }

try 
    let result2 = workItemsThatThrow |> Async.Parallel |> Async.RunSynchronously
    printfn "Done"
    printfn "got here1"
with 
    | e -> printfn "%A" e

printfn "got here2"

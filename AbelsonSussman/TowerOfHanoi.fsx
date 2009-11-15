
#r "System.Core.dll"

open System
open System.Collections.Generic
open System.Threading
open System.Linq

let t1 = new LinkedList<int>(seq{4..-1..1})

let t2 = new LinkedList<int>()
let t3 = new LinkedList<int>()

let moves = ref 0
let printStacks() =
       printfn "move %d" !moves
       printfn "%A" (t1.ToArray())
       printfn "%A" (t2.ToArray())
       printfn "%A" (t3.ToArray()) 

let rec moveTower tower (source:LinkedList<'a>) (target:LinkedList<'a>) (spare:LinkedList<'a>) =    
    match tower with
    | [] -> ()
    | head::tail -> 
           moveTower tail source spare target           
           let disc = source.Last
           source.RemoveLast()
           target.AddLast(disc)           
           incr moves
           printStacks()           
           moveTower tail spare target source   


let tower = List.ofSeq t1
moveTower tower t1 t3 t2

open System 

type IntDelegate = Func<int,int>

let doubleInt = new Func<int,int>(fun x -> x *2)
let doubleInt2:IntDelegate  = doubleInt
let myDouble x = x * 2

let threadBody() = ()
//let doubleInt3:IntDelegate = myDouble //Doesn't work!


let doubleIntFunc = new Func<int, int>(fun x -> x *2)

type DelegateInvoker(func:Action) =
    static member Apply(t:IntDelegate, x) = t.Invoke(x)
    static member Apply(t:Action) = t.Invoke()
    member this.Apply(t:Action) = t.Invoke()
    member this.Invoke() = func.Invoke()

DelegateInvoker.Apply(doubleInt, 2)

DelegateInvoker.Apply((fun x -> x * 2), 2)
//DelegateInvoker.Apply(myDouble, 2) //Doesn't work!
//DelegateInvoker.Apply(threadBody) //Doesn't work!

//let invoker = new DelegateInvoker(threadBody) //no go.
let invoker = new DelegateInvoker(new Action(threadBody))
let result = invoker.Invoke()

open System.Threading
let thread = new Thread(threadBody)
open System

let eventAggregate = new Event<_>()
let event, fire = eventAggregate.Publish, eventAggregate.Trigger


event.Add(printfn "Fired %d")
fire 25

Console.ReadLine() |> ignore

type StateFulFunc<'state, 'result> = 
    | StateFulFunc of ('state -> 'result * 'state)
    member this.Run state = match this with | StateFulFunc f -> f state

let Run (StateFulFunc f) initialState = f initialState



type StateBuilder() =
    member this.Bind(
                        result: StateFulFunc<'state, 'a>, 
                        restOfComputation: 'a -> StateFulFunc<'state, 'b>
                    ) =
        StateFulFunc(fun state -> 
            let result, newState = Run result state
            Run (restOfComputation result) newState
            )

    member this.Return(x:'a) =
        StateFulFunc(fun initialState -> x, initialState)


let GetState = StateFulFunc (fun state -> state, state)
let SetState newState = StateFulFunc (fun oldState -> (), newState)

let state = StateBuilder()

let Add x = state {
    let! currentTotal, history = GetState
    do! SetState (currentTotal + x, (sprintf "Added %d" x) :: history)
}

let Subtract x = state {
    let! currentTotal, history = GetState
    do! SetState (currentTotal - x, (sprintf "Subtracted %d" x) :: history)
}

let Multiply x = state {
    let! currentTotal , history = GetState
    do! SetState (currentTotal * x, (sprintf "Multiplied by %d" x) :: history)
}

let Divide x = state {
    let! currentTotal , history = GetState
    do! SetState (currentTotal / x, (sprintf "Divided by %d" x) :: history)
}

let calculatorActions = state {
    do! Add 2
    do! Subtract 2
    do! Multiply 10
    do! Divide 5
    do! Subtract 8

    return "Finished"
}

let sfResult, finalState = Run calculatorActions (0, [])
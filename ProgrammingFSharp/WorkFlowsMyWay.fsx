
type StateBuilder() =
    member this.Bind(
                        result: 'state -> 'a * 'state, 
                        restOfComputation: 'a -> ('state -> 'b)
                    ) =
            fun state -> 
            let result, newState = result state
            (restOfComputation result) newState

    member this.Return(x:'a) = fun state -> x, state

let GetState = fun state -> state, state
let SetState newState = fun oldState -> (), newState

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

let sfResult, finalState = calculatorActions (0, [])
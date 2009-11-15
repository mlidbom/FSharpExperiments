let isMultipleOf factors  number = 
    factors |> Seq.exists (fun x -> number % x = 0)

let multiplesOfFactorsBelow factors limit =       
   seq{1..(limit - 1)} |> Seq.filter (isMultipleOf factors)  |> Seq.sum

multiplesOfFactorsBelow [3;5] 1000

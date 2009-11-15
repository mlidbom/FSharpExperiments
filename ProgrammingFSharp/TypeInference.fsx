
//Type inference works left to right, so this will not compile.
let printStuff = List.iter (fun s -> printfn "s has longth %d" s.Length) ["Pipe"; "Forward"]

//The pipe forward operator is your friend here.
let printStuff2 = ["Pipe"; "Forward"] |> List.iter (fun s -> printfn "s has longth %d" s.Length)


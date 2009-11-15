type Tree = 
    | Branch of int * Tree * Tree
    | Leaf of int

let rec printInOrder tree = 
    match tree with
    | Leaf (value) -> printfn "%d" value
    | Branch (value, left, right) ->  
        printInOrder left
        printfn "%d" value
        printInOrder right

let myTree = Branch(2, 
                Leaf(1), 
                Branch(4, 
                    Leaf(3), 
                    Leaf(5)))

printInOrder myTree
    
let rec flatten tree = 
        match tree with
        | Branch (value, left, right) -> 
            flatten left @ [value] @ flatten right
        | Leaf value -> [value]

flatten myTree

let myMatch x y = 
    match x, y with
    | a, b when a = b -> "Equals"
    |_, _ -> "Different"

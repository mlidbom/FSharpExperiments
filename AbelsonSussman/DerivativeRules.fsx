



type Expression =
    | Constant of int
    | Sum of Expression * Expression
    | Product of Expression * Expression
    | Variable of string

let simplify expr = 
    let rec simplify = function
        | Sum(Constant(val1), Constant(val2)) -> Constant(val1 + val2)
        | Product(Constant(val1), Constant(val2)) -> Constant(val1 * val2)
        | Sum(Constant(0), expr) -> expr
        | Sum(expr, Constant(0)) -> expr
        | Product(Constant(0), expr) -> Constant(0)
        | Product(expr, Constant(0)) -> Constant(0)
        | Product(Constant(1), expr) -> expr
        | Product(expr, Constant(1)) -> expr
        | Product(expr, Constant(value)) -> Product(Constant(value), expr)
        | Product(expr1, Product(Constant(value), expr2)) -> Product(Constant(value), Product(expr1, expr2))
        | Sum(expr1, expr2) when expr1 = expr2 -> Product(Constant(2), expr2)
        | Sum(expr1, expr2) -> Sum(simplify expr1, simplify expr2)
        | Product(expr1, expr2) -> Product(simplify expr1, simplify expr2)
        | expr -> expr
    //Do a few passes. Should use fixed point or similar to make as many passes as necessary..
    expr |> simplify |> simplify |> simplify |> simplify|> simplify 

let rec derivative expression variable = 
    match expression with
    | Constant(value) -> Constant(0)
    | Variable(name)  when name = variable -> Constant(1)
    | Variable(name) -> Constant(0)
    | Sum(expr1, expr2) -> Sum (derivative expr1 variable, 
                                derivative expr2 variable)
    | Product(expr1, expr2) -> Sum(Product(expr1, 
                                           derivative expr2 variable), 
                                   Product(derivative expr1 variable, 
                                           expr2))

let printExpr expr = 
    let rec printI = function 
        | Constant(value) -> printf "%d" value
        | Sum(expression1, expression2) 
            -> printI expression1
               printf " + "
               printI expression2
        | Product(expression1, expression2)
            -> printI expression1
               printf " * "
               printI expression2
        | Variable(name) -> printf "%s" name
    printI expr
    printfn ""

let addX = Sum(Constant(0), Variable("x"))
let addX' = derivative addX "x"
printExpr addX'
printExpr (simplify addX')

//a*x*x + b*x + c
let a, x, b, c = Variable("a"), Variable("x"), Variable("b"), Variable("c")
let equation = Sum(Product(a, Product(x, x)), Sum(Product(b,x), c))
let equation'x = derivative equation "x"
printExpr equation
printExpr equation'x
printExpr (simplify equation'x)
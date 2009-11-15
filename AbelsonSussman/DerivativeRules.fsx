#load "Algorithms.fsx"
open Algorithms

type Expression =
    | Constant of int
    | Sum of Expression * Expression
    | Product of Expression * Expression
    | Variable of string

let simplify expr = 
    let rec simplify = function                
        | Sum(e1__, e2__) -> 
            match e1__, e2__ with
            | Constant(val1), Constant(val2) -> Constant(val1 + val2)        
            | Constant(0), e2 -> e2
            | e1, Constant(0) -> e1
            | e1, e2 when e1 = e2 -> Product(Constant(2), e2)
            | e1, e2 -> Sum(simplify e1, simplify e2)
        | Product(e1__, e2__) ->
            match e1__, e2__ with
            | Constant(val1), Constant(val2) -> Constant(val1 * val2)
            | Constant(0), _ -> Constant(0)
            | _, Constant(0) -> Constant(0)
            | Constant(1), e2 -> e2
            | e1, Constant(1) -> e1
            | e1, Constant(value) -> Product(Constant(value), expr)
            | e1, Product(Constant(value), expr2) -> Product(Constant(value), Product(e1, expr2))                
            | e1, e2 -> Product(simplify e1, simplify e2)
        | expr -> expr

    fixedPoint simplify (=) expr

let rec derivative expression (Variable varName) = 
    match expression with
    | Constant(value) -> Constant(0)
    | Variable(name)  when name = varName -> Constant(1)
    | Variable(name) -> Constant(0)
    | Sum(expr1, expr2) -> Sum (derivative expr1 (Variable(varName)), 
                                derivative expr2 (Variable(varName)))
    | Product(expr1, expr2) -> Sum(Product(expr1, 
                                           derivative expr2 (Variable(varName))), 
                                   Product(derivative expr1 (Variable(varName)), 
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

let a, b, c, x, y = Variable("a"), Variable("b"), Variable("c"), Variable("x"), Variable("y")

let addX = Sum(Constant(0), x)
let addX' = derivative addX x
printExpr addX'
printExpr (simplify addX')

//a*x*x + b*x + c
let equation = Sum(Product(a, Product(x, x)), Sum(Product(b,x), c))
let equation'x = derivative equation x
printExpr equation
printExpr equation'x //prints a * x * 1 + 1 * x + 0 * x * x + b * 1 + 0 * x + 0 . Yuck

printExpr (simplify equation'x)//2*a*x +b .  Nice :)

//ok, so it can do x how about a b c?
printExpr (simplify (derivative equation a))//x * x
printExpr (simplify (derivative equation b))//x. 
printExpr (simplify (derivative equation c))//1.
//Wohoo! not too shabby.


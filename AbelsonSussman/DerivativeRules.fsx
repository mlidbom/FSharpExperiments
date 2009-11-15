#load "Algorithms.fsx"
open Algorithms

module Expressions =
    type Expression =
        | Constant of int
        | Sum of Expression * Expression
        | Product of Expression * Expression
        | Variable of string

        static member simplify expr = 
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

        member this.Simplified = Expression.simplify this

        static member derivative (Variable varName) expression =
            let rec derivative expression varName = 
                match expression with              
                | Constant(value) -> Constant(0)              
                | Variable(name)  when name = varName -> Constant(1)
                | Variable(name) -> Constant(0)
                | Sum(expr1, expr2) -> Sum (derivative expr1 varName, 
                                            derivative expr2 varName)
                | Product(expr1, expr2) -> Sum(Product(expr1, 
                                                       derivative expr2 varName), 
                                               Product(derivative expr1 varName, 
                                                       expr2))            
            derivative expression varName
        
        member this.Derivative variable = Expression.derivative this variable

        static member toString expression =
            let rec toString = function 
                | Constant(value) -> sprintf "%d" value
                | Sum(expression1, expression2) 
                    -> sprintf "%s + %s"  (toString expression1) (toString expression2)
                | Product(expression1, expression2)
                    -> sprintf "%s * %s" (toString expression1) (toString expression2)
                | Variable(name) -> sprintf "%s" name
            toString expression

        override this.ToString() = Expression.toString this
            

    let simplify = Expression.simplify
    let derivative = Expression.derivative
    let toString = Expression.toString

    let printExpr expr = printfn "%O" expr    

open Expressions
let a, b, c, x, y = Variable("a"), Variable("b"), Variable("c"), Variable("x"), Variable("y")

let addX = Sum(Constant(0), x)
let addX' = derivative x addX
printExpr addX'
printExpr (simplify addX')

//a*x*x + b*x + c
let equation = Sum(Product(a, Product(x, x)), Sum(Product(b,x), c))
let equation'x = derivative x equation
printExpr equation
printExpr equation'x //prints a * x * 1 + 1 * x + 0 * x * x + b * 1 + 0 * x + 0 . Yuck

printExpr (simplify equation'x)//2 * a * x + b .  Nice :)

//ok, so it can do x how about a b c?
printExpr (simplify (derivative a equation))//x * x
printExpr (simplify (derivative b equation))//x 
printExpr (simplify (derivative c equation))//1
//Wohoo! not too shabby.

//Let's use the members:
//ok, so it can do x how about a b c?
printExpr (derivative x equation).Simplified//2 * a * x + b
printExpr (derivative a equation).Simplified//x * x
printExpr (derivative b equation).Simplified//x
printExpr (derivative c equation).Simplified//1

//nicer call structure:
equation |> derivative x |> simplify |> toString |> (printfn "%s")  //2*a*x + b

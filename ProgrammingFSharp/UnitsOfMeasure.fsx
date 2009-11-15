
[<Measure>]
type fahrenheit =         
    static member FahrenheitPerCelcius = 9.0<fahrenheit> / 5.0<celcius>
    static member FahrenheitCelciusZeroOffset = 32.0<fahrenheit>
    static member InCelcius(x : float<fahrenheit>) = 
        (celcius.CelciusPerFarenheit * x) + celcius.CelsiusFahrenheitZeroOffset
and [<Measure>] celcius =
    static member CelciusPerFarenheit = 1.0 / fahrenheit.FahrenheitPerCelcius
    static member CelsiusFahrenheitZeroOffset = -fahrenheit.FahrenheitCelciusZeroOffset * celcius.CelciusPerFarenheit
    static member InFahrenheit(x : float<celcius>) = 
        (fahrenheit.FahrenheitPerCelcius * x) + fahrenheit.FahrenheitCelciusZeroOffset

fahrenheit.InCelcius(100.<fahrenheit>)

fahrenheit.InCelcius(celcius.InFahrenheit(98.<celcius>))

celcius.CelciusPerFarenheit
celcius.CelsiusFahrenheitZeroOffset

fahrenheit.FahrenheitCelciusZeroOffset
fahrenheit.FahrenheitPerCelcius

let printTemperature (temp : float<fahrenheit>) = 
    if temp < 32.<_> then
        printfn "Below freezing"
    elif temp < 65.<_> then 
        printfn "Cold"
    elif temp < 75.<_> then 
        printfn "Just right!"
    elif temp < 100.<_> then
        printfn "Hot!"
    else
        printfn "Scorching!"


[<Measure>]
type second

[<Measure>]
type meter

[<Measure>]
type velocity = meter / second

[<Measure>]
type acceleration = meter / second ^ 2


let height = 3.<meter>
let earthAcceleration = 9.82<meter/second^2>
let time = 3.<second>
let speed = time * earthAcceleration

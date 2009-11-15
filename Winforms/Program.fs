
open System
open System.Windows.Forms

let form = new Form(Visible=true, TopMost=true, Text="Event Sample")

let (overEvent, underEvent) =
    form.MouseMove
    |> Event.merge form.MouseDown
    |> Event.filter (fun args -> args.Button = MouseButtons.Left)
    |> Event.map (fun args -> (args.X, args.Y))
    |> Event.partition (fun (x, y) -> x > 100 && y > 100)

overEvent |> Event.add (fun (x, y) -> printfn "Over (%d, %d)" x y)
underEvent |> Event.add (fun (x, y) -> printfn "Under (%d, %d)" x y);;

Application.Run form
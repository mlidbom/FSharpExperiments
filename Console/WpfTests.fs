module WpfTests

open System
open System.Threading
open System.Windows
open System.Windows.Controls
open System.Windows.Input
open System.Windows.Markup
open System.Windows.Media
open System.Windows.Shapes

let getPosition (e : #IInputElement) (args : #MouseEventArgs) =
  let pt = args.GetPosition e
  (pt.X, pt.Y)

let createMouseTracker (e : #IInputElement) = 
  e.MouseLeftButtonDown
  |> Event.map (fun args -> args :> MouseEventArgs)
  |> Event.merge e.MouseMove
  |> Event.filter (fun args -> args.LeftButton = MouseButtonState.Pressed)
  |> Event.map (getPosition e)

type System.Windows.IInputElement with
  member this.MouseTrack = createMouseTracker this

let drawLine stroke (x1, y1) (x2, y2) (e : #IAddChild) =
  let line = new LineGeometry(StartPoint = Point(x1, y1), EndPoint = Point(x2, y2))
  let path = new Path(Stroke = stroke, StrokeThickness = 5., Data = line)
  e.AddChild(path)

let trackMouse (e : #UIElement) (guiContext : SynchronizationContext) =
  let rec firstEvent () =
    async { let! args = Async.AwaitEvent e.MouseTrack
            return! loop args } 
  and loop prev =
    async { let! current = Async.AwaitEvent e.MouseTrack
            do! Async.SwitchToContext guiContext
            do drawLine Brushes.Red prev current e
            do! Async.SwitchToThreadPool()
            return! loop current }
  firstEvent()

let window = new Window(Visibility = Visibility.Visible)
let canvas = new Canvas(RenderSize = window.RenderSize, 
                        Background = Brushes.AliceBlue)
window.Content <- canvas

[<STAThread>]
let run = 
    window.Loaded.Add(fun _ -> trackMouse canvas SynchronizationContext.Current |> Async.Start)

    (fun () -> (new Application()).Run(window))
 
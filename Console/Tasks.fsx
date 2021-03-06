﻿#r "FSharp.PowerPack.dll"

open System.IO
open System.Net
open Microsoft.FSharp.Control.CommonExtensions 

type System.Net.WebRequest with
  member x.GetResponseAsync() =
    Async.FromBeginEnd(x.BeginGetResponse, x.EndGetResponse)

let run () =        
    let download(url:string) = 
      async { let request = WebRequest.Create(url) 
              use! response = request.GetResponseAsync()
              use stream = response.GetResponseStream() 
              use reader = new StreamReader(stream) 
              let! html = reader.AsyncReadToEnd() 
              return (url, html)
            }
            
    let siteList = ["http://www.microsoft.com/";"http://msn.com/"]
    siteList 
        |> Seq.map download 
        |> Async.Parallel 
        |> Async.RunSynchronously
        |> Seq.iter(fun x -> printfn "%s : %s" (fst x) (snd x))

run()
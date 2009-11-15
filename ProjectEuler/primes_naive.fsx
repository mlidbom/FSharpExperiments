//let odds limit = Seq.unfold (fun n -> if n > limit then None else Some(n,n+2L)) 3L //Original 
let odds limit = seq { 3L..2L..limit } //simpler

let isPrime n =
  let limit = int64 (sqrt (float n))
  odds limit |> Seq.forall (fun x -> n%x <> 0L)

let primes =
  seq { yield 2L
        yield! odds System.Int64.MaxValue |> Seq.filter isPrime } 

primes |> Seq.nth 10000
// Learn more about F# at http://fsharp.org

open System

let rec getFibonacciNumber(index:int64) = 
    if index = 0L then
        0L
    else if index = 1L then
        1L
    else
        getFibonacciNumber(index - 1L) + getFibonacciNumber(index - 2L) 

let getFibonacciNumberIterative(index:int64) = 
    if index = 0L then
        0L
    else if index = 1L then
        1L
    else
        let mutable fn:int64 = 0L
        let mutable f0:int64 = 0L
        let mutable f1:int64 = 1L
        for i in 2L .. index do
            fn <- f0 + f1
            f0 <- f1
            f1 <- fn
        fn
      

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    Console.WriteLine(getFibonacciNumberIterative(50L))
    0 // return an integer exit code


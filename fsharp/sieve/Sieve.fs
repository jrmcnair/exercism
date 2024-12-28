module Sieve

open System.Collections.Generic

let primes limit =
    let nonPrimes = HashSet<int>()
    
    for num in 2 .. limit do
        for j in (num*2) .. num .. limit do
            nonPrimes.Add(j) |> ignore

    [2..limit]
    |> List.choose (fun num -> if nonPrimes.Contains(num) then None else Some num)

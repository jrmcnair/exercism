module Sieve

let primes limit =
    let rec sieve (primes: int list) (nums: int list) =
        match nums with
        | [] -> primes |> List.rev
        | prime::rest ->
            let nonPrimes = [prime * 2 .. prime .. limit]
            sieve (prime::primes) (rest |> List.except nonPrimes)
    
    [2..limit] |> sieve [] 

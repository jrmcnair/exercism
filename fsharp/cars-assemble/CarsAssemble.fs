module CarsAssemble

let successRate = function
    | 1 | 2 | 3 | 4 -> 1.
    | 5 | 6 | 7 | 8 -> 0.9
    | 9 -> 0.8
    | 10 -> 0.77
    | _ -> 0.

let productionRatePerHour (speed: int): float =
    (float speed) * 221. * successRate speed

let workingItemsPerMinute(speed: int): int =
    productionRatePerHour speed / 60.
    |> floor
    |> int

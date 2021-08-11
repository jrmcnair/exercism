module Raindrops

let isDivisibleBy (divisor: int) (number: int) =
    number % divisor = 0

let sounds =
    [
        (3, "Pling")
        (5, "Plang")
        (7, "Plong")
    ]

let convert (number: int): string =
    sounds
    |> List.filter(fun (divisor,_) -> isDivisibleBy divisor number)
    |> function
        | [] -> string number
        | filteredSounds ->
            List.map(fun (_, sound) -> sound) filteredSounds
            |> List.reduce(+)

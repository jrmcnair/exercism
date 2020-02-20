module Raindrops

let isDivisibleBy (divisor: int) (number: int) =
    number % divisor = 0

let sounds = [
    (3, "Pling");
    (5, "Plang");
    (7, "Plong");
]

let convert (number: int): string =
    let result =
        List.fold (fun state (divisor,sound) ->
            match isDivisibleBy divisor number with
            | true -> sprintf "%s%s" state sound
            | false -> state
        ) "" sounds

    match result with
    | "" -> string number
    | _ -> result

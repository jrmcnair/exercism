module HighScores

let scores (values: int list): int list = values

let latest (values: int list): int =
    match values with
    | [] -> 0
    | values -> values |> List.last

let personalBest (values: int list): int =
    match values with
    | [] -> 0
    | values -> values |> List.max

let personalTopThree (values: int list): int list =
    values
    |> List.sortDescending
    |> List.truncate 3

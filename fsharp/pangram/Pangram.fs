module Pangram

let alphabet = set ['a'..'z']

let isPangram (input: string): bool =
    match input with
    | input when isNull input || input.Length < 26 -> false
    | input ->
        set (input.ToLowerInvariant())
        |> Set.isSubset alphabet

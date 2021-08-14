module Bob

open System

let private toUnitOption (b: bool) = if b then Some () else None

let (|Empty|_|) (input: string) =
    input = "" |> toUnitOption

let (|Question|_|) (input: string) =
    input |> Seq.last = '?' |> toUnitOption

let (|Yelling|_|) (input: string) =
    (input |> Seq.exists Char.IsLetter
    && input = input.ToUpper())
    |> toUnitOption

let response (input: string): string =
    match input.Trim() with
    | Empty -> "Fine. Be that way!"
    | Yelling & Question -> "Calm down, I know what I'm doing!"
    | Question -> "Sure."
    | Yelling -> "Whoa, chill out!"
    | _ -> "Whatever."

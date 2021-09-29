module PhoneNumber

open System

let checkDigits = function
    | x when x |> Seq.exists Char.IsLetter -> Error "letters not permitted"
    | x when x |> Seq.exists Char.IsPunctuation -> Error "punctuations not permitted"
    | x -> Ok x

let checkLength (input: string) =
    match input.Length with
    | x when x < 10 -> Error "incorrect number of digits"
    | x when x > 11 -> Error "more than 11 digits"
    | x when x = 11 && input.[0] <> '1' -> Error "11 digits must start with 1"
    | 11 -> Ok input.[1..]
    | _ -> Ok input

let checkAreaCode (input: string) =
    match input.[0] with
    | '0' -> Error "area code cannot start with zero"
    | '1' -> Error "area code cannot start with one"
    | _ -> Ok input

let checkExchangeCode (input: string) =
    match input.[3] with
    | '0' -> Error "exchange code cannot start with zero"
    | '1' -> Error "exchange code cannot start with one"
    | _ -> Ok input

let filterValidPunctuation (input: string) =
    input |> String.filter(fun x -> not ("+.-() ".Contains x))

let clean (input: string) =
    input
    |> filterValidPunctuation
    |> checkDigits
    |> Result.bind checkLength
    |> Result.bind checkAreaCode
    |> Result.bind checkExchangeCode
    |> Result.map uint64

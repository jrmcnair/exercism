module Bob

open System

let isAllUppercase (input: string) =
    let letters = input |> Seq.filter Char.IsLetter
    if Seq.isEmpty letters
    then false
    else letters |> Seq.forall Char.IsUpper

let (|YelledQuestion|Yelled|Question|Empty|Talking|) (input: string) =
    let input = input.Trim()

    if String.IsNullOrWhiteSpace input
    then Empty
    else
        match isAllUppercase input, input |> Seq.last = '?' with
        | true, true -> YelledQuestion
        | true, false -> Yelled
        | false, true -> Question
        | _ -> Talking

let response (input: string): string =
    match input with
    | YelledQuestion -> "Calm down, I know what I'm doing!"
    | Yelled ->  "Whoa, chill out!"
    | Question -> "Sure."
    | Empty -> "Fine. Be that way!"
    | Talking -> "Whatever."

module RunLengthEncoding

open System

let private encodeLetter (input: string) =
    let matchingCharCount = 
        input
        |> Seq.takeWhile((=) input.[0])
        |> Seq.length

    match matchingCharCount with
    | 1 -> (input.[0].ToString(), input.[1..])
    | x -> ($"{x}{input.[0]}", input.[x..])

let private decodeLetter (input: string) =
    let numberCharCount = input |> Seq.takeWhile Char.IsDigit |> Seq.length
    match numberCharCount with
    | 0 -> (input.[0].ToString(), input.[1..])
    | x ->
        let count = input.Substring(0, x) |> int
        let letter =
            seq {1..count}
            |> Seq.map (fun _ -> input.[x])
            |> String.Concat
        (letter, input.[x+1..])

let rec encode (input: string) =
    if input.Length = 0
    then ""
    else
        match encodeLetter input with
        | letter, "" -> letter
        | letter, remainder -> letter + encode remainder

let rec decode (input: string) =
    if input.Length = 0
    then ""
    else
        match decodeLetter input with
        | letter, "" -> letter
        | letter, remainder -> letter + decode remainder
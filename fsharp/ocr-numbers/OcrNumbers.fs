module OcrNumbers

let isValid (input: string list) =
    input.Length % 4 = 0
    && input |> List.forall(fun x -> x.Length % 3 = 0)

let toDigit = function
    | (" _ ", "| |", "|_|") -> "0"
    | ("   ", "  |", "  |") -> "1"
    | (" _ ", " _|", "|_ ") -> "2"
    | (" _ ", " _|", " _|") -> "3"
    | ("   ", "|_|", "  |") -> "4"
    | (" _ ", "|_ ", " _|") -> "5"
    | (" _ ", "|_ ", "|_|") -> "6"
    | (" _ ", "  |", "  |") -> "7"
    | (" _ ", "|_|", "|_|") -> "8"
    | (" _ ", "|_|", " _|") -> "9"
    | _ -> "?"

let toDigits (parsedInput: string list list) =
    List.zip3 parsedInput.[0] parsedInput.[1] parsedInput.[2]
    |> List.map toDigit
    |> String.concat ""

let parseLine (line: string) =
    [0..3..(line.Length - 1)]
    |> List.map (fun idx -> line.Substring(idx, 3))

let parse (input: string list) =
    input
    |> List.map parseLine
    |> List.chunkBySize 4
    |> List.map toDigits
    |> String.concat ","

let convert (input: string list) =
    if isValid input
    then input |> parse |> Some
    else None

module OcrNumbers

type DigitPart =
    |Horizontal
    |Left
    |Right
    |Sides
    |LeftAngle
    |RightAngle
    |All
    |Blank
    |Invalid
    |Unknown

let toDigitPart = function
    | x when String.length x <> 3 -> Invalid
    | " _ " -> Horizontal
    | "| |" -> Sides
    | "|  " -> Left
    | "  |" -> Right
    | "|_ " -> LeftAngle
    | " _|" -> RightAngle
    | "|_|" -> All
    | "   " -> Blank
    | _ -> Unknown

let toDigitParts (input:string) =
    [0..3..(input.Length - 1)]
    |> List.map (fun x -> input.Substring(x, 3) |> toDigitPart)

let toDigit = function
    | x when x |> List.contains Invalid -> None
    | [ Horizontal; Sides; All; Blank ] -> Some "0"
    | [ Blank; Right; Right; Blank ] -> Some "1"
    | [ Horizontal; RightAngle; LeftAngle; Blank ] -> Some "2"
    | [ Horizontal; RightAngle; RightAngle; Blank ] -> Some "3"
    | [ Blank; All; Right; Blank ] -> Some "4"
    | [ Horizontal; LeftAngle; RightAngle; Blank ] -> Some "5"
    | [ Horizontal; LeftAngle; All; Blank ] -> Some "6"
    | [ Horizontal; Right; Right; Blank ] -> Some "7"
    | [ Horizontal; All; All; Blank ] -> Some "8"
    | [ Horizontal; All; RightAngle; Blank ] -> Some "9"
    | _ -> Some "?"

let toDigits (parts: DigitPart list list) =
    [0..(List.length parts.[0] - 1)]
    |> List.map (fun x -> [ parts.[0].[x]; parts.[1].[x]; parts.[2].[x]; parts.[3].[x] ])
    |> List.map toDigit

let toNumber input =
    let t1 = input |> List.map toDigitParts
    let t2 = t1 |> toDigits
    t2 |> List.reduce (Option.map2 (+))

let toNumbers input =
    input
    |> List.chunkBySize 4
    |> List.map toNumber

let combineNumbers numbers =
    numbers
    |> List.reduce (
        Option.map2 (fun x y ->
            match x with
            | "" -> y
            | _ -> $"{x},{y}"
        )
    )

let validateInput = function
    | x when (x |> List.length) % 4 <> 0 -> None
    | x when x |> List.exists (fun (y: string) -> y.Length % 3 <> 0) -> None
    | x -> Some x

let convert input =
    let result =
        input
        |> validateInput
        |> Option.map toNumbers
        |> Option.map combineNumbers

    match result with
    | Some number -> number
    | _ -> None

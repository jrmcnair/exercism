module TisburyTreasureHunt

open System

let getCoordinate (line: string * string): string =
    snd line

let convertCoordinate (coordinate: string): int * char =
    (Char.GetNumericValue coordinate.[0] |> int, coordinate.[1])

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool =
    let c1 =
        azarasData
        |> getCoordinate
        |> convertCoordinate
    let (_, c2, _) = ruisData
    c1 = c2

let createRecord (azarasData: string * string) (ruisData: string * (int * char) * string) : (string * string * string * string) =
    if compareRecords azarasData ruisData
        then
            let (treasure, coords) = azarasData
            let (location, _, quadrant) = ruisData
            (coords, location, quadrant, treasure)
        else ("", "", "", "")


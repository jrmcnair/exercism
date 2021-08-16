module KindergartenGarden

type Plant =
    | Clover
    | Grass
    | Radishes
    | Violets
    | Unknown

let students =
    [ "Alice"; "Bob"; "Charlie"; "David"; "Eve"; "Fred";
      "Ginny"; "Harriet"; "Ileana"; "Joseph"; "Kincaid"; "Larry" ]

let charToPlant = function
    | 'C' -> Clover
    | 'G' -> Grass
    | 'R' -> Radishes
    | 'V' -> Violets
    | _ -> Unknown

let getStudentIndex (student: string) =
    students |> List.findIndex (fun x -> x = student)

let plants (diagram: string) (student: string) =
    let rows = diagram.Split("\n")
    let gardenPosition = (getStudentIndex student) * 2

    [
        rows.[0].[gardenPosition]
        rows.[0].[gardenPosition + 1]
        rows.[1].[gardenPosition]
        rows.[1].[gardenPosition + 1]
    ] |> List.map charToPlant

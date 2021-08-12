module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School): School =
    match Map.tryFind grade school with
    | Some students -> school |> Map.add grade (List.append students [ student ])
    | None -> school |> Map.add grade [ student ]

let roster (school: School) =
    let addStudentsToRoster (roster: string list) (_: int) (students: string list) =
        List.append roster (List.sort students)

    school |> Map.fold addStudentsToRoster []

let grade (number: int) (school: School) =
    match Map.tryFind number school with
    | Some students -> List.sort students
    | None -> []

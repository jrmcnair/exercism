module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty<int, string list>

let add (student: string) (grade: int) (school: School): School =
    match Map.tryFind grade school with
    | Some students ->
        school
        |> Map.remove grade
        |> Map.add grade (List.append students [ student ])

        // Using Map.remove/add seems cleaner to me than Map.change
        // both pass the tests, but I'm not sure which is considered best practice

        // school
        // |> Map.change grade ( fun existing ->
        //     match existing with
        //     | Some students -> List.append students [ student ] |> Some
        //     | None -> [ student ] |> Some )

    | None -> school |> Map.add grade [ student ]

let roster (school: School) =
    let addStudentsToRoster (roster: string list) (_: int) (students: string list) =
        List.append roster (List.sort students)

    school |> Map.fold addStudentsToRoster []

let grade (number: int) (school: School) =
    match Map.tryFind number school with
    | Some students -> List.sort students
    | None -> []

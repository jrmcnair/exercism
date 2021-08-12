module RobotName

let mutable existingNames : string list = []

let rnd = System.Random()
let alphabet = [|'A'..'Z'|]

let rec generateName () =
    let letters =
        sprintf "%c%c"
            alphabet.[rnd.Next 25]
            alphabet.[rnd.Next 25]

    let numbers =
        match rnd.Next 999 with
        | x when x < 10 -> sprintf "00%d" x
        | x when x < 100 -> sprintf "0%d" x
        | x -> x.ToString ()

    let name = sprintf "%s%s" letters numbers
    if List.contains name existingNames
        then generateName ()
        else name

type RobotName =
    | Unnamed
    | Named of string

type Robot () =
    let mutable _name : RobotName = Unnamed

    member __.Name
        with get () =
            match _name with
            | Unnamed ->
                let newName = generateName ()
                existingNames <- newName :: existingNames
                _name <- Named newName
                newName
            | Named name -> name

    member __.ResetName =
        _name <- Unnamed

let mkRobot () = new Robot()

let name (robot: Robot) : string = robot.Name

let reset (robot: Robot) =
    robot.ResetName
    robot
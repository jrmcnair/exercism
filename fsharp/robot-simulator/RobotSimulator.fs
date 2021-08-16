module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

let create direction position =
    { direction = direction; position = position }

let rightTurn = function
    | North -> East
    | East -> South
    | South -> West
    | West -> North

let leftTurn = function
    | North -> West
    | East -> North
    | South -> East
    | West -> South

let advance (x:int, y:int) = function
    | North -> (x, y + 1)
    | East -> (x + 1, y)
    | South -> (x, y - 1)
    | West -> (x - 1 , y)

let processInstruction robot = function
    | 'R' -> { robot with direction = rightTurn robot.direction }
    | 'L' -> { robot with direction = leftTurn robot.direction }
    | 'A' -> { robot with position = advance robot.position robot.direction }
    | _ -> robot

let move instructions robot =
    (robot, instructions)
    ||> Seq.fold(fun state instruction -> processInstruction state instruction)


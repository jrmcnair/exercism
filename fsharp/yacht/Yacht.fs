module Yacht

type Category = 
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One = 1
    | Two = 2
    | Three = 3
    | Four = 4
    | Five = 5
    | Six = 6

let score (category: Category) (dice: Die list) : int =
    let sorted = dice |> List.map int |> List.sort
    let counted = sorted |> List.countBy id |> List.sortByDescending snd
    let score die: int = dice |> List.filter (fun d -> d = die) |> List.length |> (*) (int die)
        
    match category with
    | Ones -> score Die.One
    | Twos -> score Die.Two
    | Threes -> score Die.Three
    | Fours -> score Die.Four
    | Fives -> score Die.Five
    | Sixes -> score Die.Six
    | FullHouse when counted.Length = 2 && snd counted[0] = 3 -> List.sum sorted
    | FourOfAKind when snd counted[0] >= 4 -> fst counted[0] * 4
    | LittleStraight when sorted = [1..5] -> 30
    | BigStraight when sorted = [2..6] -> 30
    | Choice -> List.sum sorted
    | Yacht when counted.Length = 1 -> 50
    | _ -> 0

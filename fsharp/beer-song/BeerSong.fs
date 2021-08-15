module BeerSong

let private verse (number: int) =
    match number with
    | 0 ->
        ("No more bottles of beer on the wall, no more bottles of beer.",
         "Go to the store and buy some more, 99 bottles of beer on the wall.")
    | 1 ->
        ("1 bottle of beer on the wall, 1 bottle of beer.",
         "Take it down and pass it around, no more bottles of beer on the wall.")
    | 2 ->
        ("2 bottles of beer on the wall, 2 bottles of beer.",
         "Take one down and pass it around, 1 bottle of beer on the wall.")
    | _ ->
        ($"{number} bottles of beer on the wall, {number} bottles of beer.",
         $"Take one down and pass it around, {number - 1} bottles of beer on the wall.")

let recite (firstBottle: int) (takeDown: int) =
    let lastBottle = firstBottle - takeDown + 1

    [lastBottle .. firstBottle]
    |> List.fold (fun acc bottle ->
        let (line1, line2) = verse bottle
        let acc = if List.isEmpty acc then acc else "" :: acc
        line1 :: line2 :: acc
    ) []

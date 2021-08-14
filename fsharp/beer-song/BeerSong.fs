module BeerSong

let private bottles (number: int) =
    // could handle 0 here too, but I thought the init cap handling made it much less clean
    if number = 1 then "1 bottle"
    else sprintf "%d bottles" number

let private verse (number: int) =
    [
        match number with 
        | 0 -> "No more bottles of beer on the wall, no more bottles of beer."
        | _ -> System.String.Format("{0} of beer on the wall, {0} of beer.", (bottles number))

        match number with
        | 0 -> "Go to the store and buy some more, 99 bottles of beer on the wall."
        | 1 -> "Take it down and pass it around, no more bottles of beer on the wall."
        | _ -> sprintf "Take one down and pass it around, %s of beer on the wall." (bottles (number - 1))
    ]

let recite (firstBottle: int) (takeDown: int) =
    let lastBottle = firstBottle - takeDown + 1

    [firstBottle .. -1 .. lastBottle]
    |> List.fold ( fun acc bottle ->
            let spacer = if not (List.isEmpty acc) then [ "" ] else []
            verse bottle |> List.append spacer |> List.append acc
        ) []

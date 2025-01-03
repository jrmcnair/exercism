module ResistorColorTrio

let toNumber = function
  | "black" -> 0L
  | "brown" -> 1L
  | "red" -> 2L
  | "orange" -> 3L
  | "yellow" -> 4L
  | "green" -> 5L
  | "blue" -> 6L
  | "violet" -> 7L
  | "grey" -> 8L
  | "white" -> 9L
  | _ -> failwith "unknown color"

let label (colors: string list) =
    let number = (10L * (toNumber colors[0]) + (toNumber colors[1])) * (pown 10L (toNumber colors[2] |> int))

    if number >= 1_000_000_000L then $"{number / 1_000_000_000L } gigaohms"
    elif number >= 1_000_000L then $"{number / 1_000_000L } megaohms"
    elif number >= 1_000L then $"{number / 1_000L } kiloohms"
    else $"{number} ohms"

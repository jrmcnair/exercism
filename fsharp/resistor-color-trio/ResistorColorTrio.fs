module ResistorColorTrio

let toNumber = function
  | "black" -> 0
  | "brown" -> 1
  | "red" -> 2
  | "orange" -> 3
  | "yellow" -> 4
  | "green" -> 5
  | "blue" -> 6
  | "violet" -> 7
  | "grey" -> 8
  | "white" -> 9
  | _ -> failwith "unknown color"

let label (colors: string list) =
    let root = 10 * (toNumber colors[0]) + (toNumber colors[1])
    let zeros = pown 10 (toNumber colors[2])
    let number = uint64 root * uint64 zeros

    if number >= 1_000_000_000UL then $"{number / 1_000_000_000UL } gigaohms"
    elif number >= 1_000_000UL then $"{number / 1_000_000UL } megaohms"
    elif number >= 1_000UL then $"{number / 1_000UL } kiloohms"
    else $"{number} ohms"

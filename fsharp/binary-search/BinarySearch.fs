module BinarySearch

let find (input: int[]) (value: int) =
    let rec search (min: int) (max: int) =
        if min > max then None
        else
            let mid = (max + min) / 2
            match input[mid] with
            | v when v = value -> Some mid
            | v when v < value -> search (mid + 1) max 
            | v when v > value -> search min (mid - 1)
            | _ -> failwith "invalid"

    search 0 (input.Length - 1)

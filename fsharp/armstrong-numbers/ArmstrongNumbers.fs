module ArmstrongNumbers

let isArmstrongNumber (number: int): bool =
    let digits = number |> string |> Seq.map (string >> int)
    let len = Seq.length digits

    digits |> Seq.sumBy (fun n -> pown n len) = number

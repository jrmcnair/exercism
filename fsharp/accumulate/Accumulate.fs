module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list): 'b list =
    //input |> List.map func

    let rec tailRecursion (f: 'a -> 'b) (acc: 'b list) = function
        | [] -> acc
        | headItem::remainingItems ->
            let convertedHeadItem = f headItem
            let updatedAcc = convertedHeadItem :: acc

            tailRecursion f updatedAcc remainingItems
        
    tailRecursion func [] input
    |> List.rev

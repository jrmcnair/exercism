module CollatzConjecture

let steps (number: int): int option =
    let rec go (n: int) (depth: int) =
        if n = 1 then depth
        elif n % 2 = 0 then go (n/2) (depth + 1)
        else go (3 * n + 1) (depth + 1)

    if number < 1 then None
    else go number 0 |> Some
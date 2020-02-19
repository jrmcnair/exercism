module Hamming

open System

let private hamm (strand1: string) (strand2: string): int =
    Seq.map2(fun x y ->
        match x = y with
        | true -> 0
        | false -> 1
    ) strand1 strand2 |> Seq.sum

let distance (strand1: string) (strand2: string): int option =
    match (strand1, strand2) with
    | (s1, s2) when not (s1.Length = s2.Length) -> None
    | (s1, s2) -> hamm s1 s2 |> Some

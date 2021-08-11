module Grains

open System

let squareValue (n: int) : uint64 =
    pown 2UL (n - 1)

let square (n: int): Result<uint64, string> =
    if (n < 1 || n > 64)
    then sprintf "square must be between 1 and 64" |> Error
    else squareValue n |> Ok

let total: Result<uint64, string> =
    [ 1 .. 64 ]
    |> List.sumBy squareValue
    |> Ok

module Darts

let (|Outside|Outer|Middle|Inner|) (distance: double) =
    match distance with
    | d when d <= 1. -> Inner
    | d when d <= 5. -> Middle
    | d when d <= 10. -> Outer
    | _ -> Outside

let distance (x: float, y:float) =
    (x*x + y*y) |> sqrt

let score (x: double) (y: double): int =
    match distance (x, y) with
    | Inner -> 10
    | Middle -> 5
    | Outer -> 1
    | Outside -> 0
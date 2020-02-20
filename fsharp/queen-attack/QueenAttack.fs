module QueenAttack

open System

let create (position: int * int) =
    let x, y = position
    x >= 0 && x <= 7 && y >= 0 && y <= 7

let canAttack (queen1: int * int) (queen2: int * int) =
    let x1, y1 = queen1
    let x2, y2 = queen2

    let horizontalAttack =
        x1 = x2

    let verticalAttack =
        y1 = y2

    let diagonalAttack =
        abs (y2 - y1) = abs (x2 - x1)

    create queen1 && create queen2
    && (horizontalAttack || verticalAttack || diagonalAttack)

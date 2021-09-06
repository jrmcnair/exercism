module GuessingGame

let number = 42

let reply = function
    | x when x = number -> "Correct"
    | x when x = number - 1 || x = number + 1 -> "So close"
    | x when x < number -> "Too low"
    | _ -> "Too high"
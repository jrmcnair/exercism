module PizzaPricing

type Pizza =
    | Margherita
    | Caprese
    | Formaggio
    | ExtraSauce of Pizza
    | ExtraToppings of Pizza

let rec pizzaPrice = function
    | Margherita -> 7
    | Caprese -> 9
    | Formaggio -> 10
    | ExtraSauce x -> 1 + pizzaPrice x
    | ExtraToppings x -> 2 + pizzaPrice x

let calculateFee = function
    | 1 -> 3
    | 2 -> 2
    | _ -> 0

let orderPrice(pizzas: Pizza list): int =
    let fee = pizzas.Length |> calculateFee
    let cost = 
        pizzas
        |> List.map pizzaPrice
        |> List.fold (+) 0

    cost + fee

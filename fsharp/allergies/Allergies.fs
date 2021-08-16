module Allergies

type Allergen =
    | Eggs
    | Peanuts
    | Shellfish
    | Strawberries
    | Tomatoes
    | Chocolate
    | Pollen
    | Cats

let private allergenCodes =
    [ (Eggs, 1); (Peanuts, 2); (Shellfish, 4); (Strawberries, 8);
      (Tomatoes, 16); (Chocolate, 32); (Pollen, 64); (Cats, 128) ]
    |> Map.ofList

let private allergenCodeFound codedAllergies allergenCode =
    (codedAllergies &&& allergenCode) = allergenCode

let allergicTo codedAllergies allergen =
    allergenCodes.[allergen] |> allergenCodeFound codedAllergies

let list (codedAllergies: int) : Allergen list =
    allergenCodes
    |> Map.toList
    |> List.choose ( fun (allergen, allergenCode) ->
        match allergenCodeFound codedAllergies allergenCode with
        | true -> Some allergen
        | _ -> None )

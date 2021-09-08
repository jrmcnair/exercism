module FoodChain

let animals =
    [ ("fly", None)
      ("spider", Some "It wriggled and jiggled and tickled inside her.")
      ("bird", Some "How absurd to swallow a bird!")
      ("cat", Some "Imagine that, to swallow a cat!")
      ("dog", Some "What a hog, to swallow a dog!")
      ("goat", Some "Just opened her throat and swallowed a goat!")
      ("cow", Some "I don't know how she swallowed a cow!")
      ("horse", None)
    ]

let swallowed index =
    let (animal, maybeSaying) = animals.[index - 1]
    [
        yield $"I know an old lady who swallowed a {animal}."
        if maybeSaying.IsSome then yield maybeSaying.Value
    ]

let catch index =
    [
        if index < animals.Length then
            for i in [index.. -1 .. 2] do
            match i with
            | 3 -> $"She swallowed the bird to catch the spider that wriggled and jiggled and tickled inside her."
            | x -> $"She swallowed the {fst animals.[x - 1]} to catch the {fst animals.[x - 2]}."
    ]

let conclusion = function
    | x when x = animals.Length -> "She's dead, of course!"
    | x -> "I don't know why she swallowed the fly. Perhaps she'll die."
  

let verse index =
    swallowed index
    @ catch index
    @ [ conclusion index ]

let recite start stop: string list =
    [start..stop]
    |> List.map verse
    |> List.reduce (fun x y -> x @ [ "" ] @ y)
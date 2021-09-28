module TwelveDays

let days = [ "first"; "second"; "third"; "fourth"; "fifth"; "sixth"
             "seventh"; "eighth"; "ninth"; "tenth"; "eleventh"; "twelfth" ]

let gifts = [
    "a Partridge in a Pear Tree"
    "two Turtle Doves"
    "three French Hens"
    "four Calling Birds"
    "five Gold Rings"
    "six Geese-a-Laying"
    "seven Swans-a-Swimming"
    "eight Maids-a-Milking"
    "nine Ladies Dancing"
    "ten Lords-a-Leaping"
    "eleven Pipers Piping"
    "twelve Drummers Drumming"
]

let line idx =
    match idx with
    | 1 -> $"{gifts.[0]}"
    | idx -> 
        [1 .. idx-1]
        |> List.map (fun x -> gifts.[x])
        |> List.reduce (fun acc gift -> $"{gift}, {acc}")
        |> (fun x -> $"{x}, and {gifts.[0]}")
    |> sprintf "On the %s day of Christmas my true love gave to me: %s." days.[idx-1]

let recite start stop =
    [start..stop]
    |> List.map line

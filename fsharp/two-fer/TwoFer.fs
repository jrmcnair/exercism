module TwoFer

let private msg (name: string): string =
    sprintf "One for %s, one for me." name

let twoFer (input: string option): string =
    match input with
    | None | Some "" -> msg "you"
    | Some name -> msg name

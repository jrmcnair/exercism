module PasswordChecker

open System

type PasswordError =
    | LessThan12Characters
    | MissingUppercaseLetter
    | MissingLowercaseLetter
    | MissingDigit
    | MissingSymbol

let checkPassword (password:string) : Result<string, PasswordError> =
    match password with
    | _ when password.Length < 12 -> Error LessThan12Characters
    | _ when not (password |> Seq.exists Char.IsUpper) -> Error MissingUppercaseLetter
    | _ when not (password |> Seq.exists Char.IsLower) -> Error MissingLowercaseLetter
    | _ when not (password |> Seq.exists Char.IsDigit) -> Error MissingDigit
    | _ when not (password |> Seq.exists "!@#$%^&*".Contains) -> Error MissingSymbol
    | _ -> Ok password

let getStatusMessage (result: Result<string, PasswordError>) : string =
    match result with
    | Ok _ -> "OK"
    | Error LessThan12Characters -> "Error: does not have at least 12 characters"
    | Error MissingUppercaseLetter -> "Error: does not have at least one uppercase letter"
    | Error MissingLowercaseLetter -> "Error: does not have at least one lowercase letter"
    | Error MissingDigit -> "Error: does not have at least one digit"
    | Error MissingSymbol -> "Error: does not have at least one symbol"

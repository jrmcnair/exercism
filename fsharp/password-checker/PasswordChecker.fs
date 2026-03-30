module PasswordChecker

type PasswordError =
    | LessThan12Characters
    | MissingUppercaseLetter
    | MissingLowercaseLetter
    | MissingDigit
    | MissingSymbol

let checkLength (password: string) =
    if String.length password < 12
    then Result.Error LessThan12Characters
    else Ok password

let checkCharacters (chars: char seq) (error: PasswordError) (password:string) =
    if chars |> Seq.exists password.Contains
    then Ok password
    else Error error

let checkPassword (password:string) : Result<string, PasswordError> =
    password |> checkLength
    |> Result.bind (checkCharacters (seq {'A' .. 'Z'}) MissingUppercaseLetter)
    |> Result.bind (checkCharacters (seq {'a' .. 'z'}) MissingLowercaseLetter)
    |> Result.bind (checkCharacters (seq {'0' .. '9'}) MissingDigit)
    |> Result.bind (checkCharacters "!@#$%^&*" MissingSymbol) 

/// Return a human-readable message indicating the meaning of the given result value.
let getStatusMessage (result: Result<string, PasswordError>) : string =
    match result with
    | Ok _ -> "OK"
    | Error LessThan12Characters -> "Error: does not have at least 12 characters"
    | Error MissingUppercaseLetter -> "Error: does not have at least one uppercase letter"
    | Error MissingLowercaseLetter -> "Error: does not have at least one lowercase letter"
    | Error MissingDigit -> "Error: does not have at least one digit"
    | Error MissingSymbol -> "Error: does not have at least one symbol"

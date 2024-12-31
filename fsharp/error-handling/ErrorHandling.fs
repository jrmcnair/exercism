module ErrorHandling

open System

let handleErrorByThrowingException() =
    Exception() |> raise

let handleErrorByReturningOption (input: string) =
    match Int32.TryParse(input) with
    | true, n -> Some n
    | false, _ -> None

let handleErrorByReturningResult (input: string) =
    match Int32.TryParse(input) with
    | true, n -> Ok n
    | false, _ -> Error "Could not convert input to integer"

let bind switchFunction twoTrackInput =
    twoTrackInput
    |> Result.bind switchFunction

let cleanupDisposablesWhenThrowingException (resource: IDisposable) =
    try
        Exception() |> raise
    finally
        resource.Dispose()

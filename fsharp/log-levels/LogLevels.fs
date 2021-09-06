module LogLevels

open System.Text.RegularExpressions

let parse (logLine: string) : (string * string) =
    let result = Regex.Match(logLine, "\[(INFO|WARNING|ERROR)\]: (.+)")
    match result.Success with
    | true -> (result.Groups.[1].Value.ToLower(), result.Groups.[2].Value.Trim())
    | false -> failwith "Invalid log line" 

let message (logLine: string) : string =
    parse logLine |> snd

let logLevel (logLine: string): string =
    parse logLine |> fst

let reformat (logLine: string) : string =
    let (level, message) = parse logLine
    $"{message} ({level})"

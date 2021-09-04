module LogLevels

open System.Text.RegularExpressions

let parse (logLine: string) : (string * string) =
    let result = Regex.Match(logLine, "\[(INFO|WARNING|ERROR)\]: (.+)\s*")
    match result.Success with
    | true -> (result.Groups.[1], result.Groups.[2])
    | false -> failwith "Invalid log line" 

let message (logLine: string): string =
    parse logLine |> snd

let logLevel(logLine: string): string = failwith "Please implement the 'logLevel' function"

let reformat(logLine: string): string = failwith "Please implement the 'reformat' function"
(*

let (|Consonant|_|) word =
    let result = Regex.Match(word, "^([^aeiou]*qu|[^aeiou][^aeiouy]+|[^aeiou]+)(.+)")
    match result.Success with
    | true -> Some (result.Groups.[1], result.Groups.[2])
    | false -> None

*)
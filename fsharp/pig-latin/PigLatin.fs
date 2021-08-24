module PigLatin

open System.Text.RegularExpressions

let (|Vowel|_|) word =
    match Regex.Match(word, "^([aeiou]|xr|yt)").Success with
    | true -> Some word
    | false -> None

let (|Consonant|_|) word =
    let result = Regex.Match(word, "^([^aeiou]*qu|[^aeiou][^aeiouy]+|[^aeiou]+)(.+)")
    match result.Success with
    | true -> Some (result.Groups.[1], result.Groups.[2])
    | false -> None

let translateWord (word: string) =
    match word with
    | Vowel word -> $"{word}ay"
    | Consonant (consonant, remainder) -> $"{remainder}{consonant}ay"
    | _ -> failwith $"unable to translate '{word}'"

let translate (input: string) =
    input.Split(' ') 
    |> Seq.map translateWord
    |> String.concat " "

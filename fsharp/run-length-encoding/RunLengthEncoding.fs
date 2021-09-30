module RunLengthEncoding

open System
open System.Text.RegularExpressions

let encode (input: string) =
    Regex.Matches(input, "(.)\1*")
    |> Seq.map (fun x ->
        match x.Value.Length with
        | 1 -> x.Groups.[1].Value
        | count -> $"{count}{x.Groups.[1].Value}")
    |> String.Concat

let decode (input: string) =
    Regex.Matches(input, "(\d*)(.)")
    |> Seq.map (fun x ->
        match x.Groups.[1].Value with
        | "" -> x.Groups.[2].Value
        | num -> Seq.init (int num) (fun _ -> x.Groups.[2].Value) |> String.Concat)
    |> String.Concat

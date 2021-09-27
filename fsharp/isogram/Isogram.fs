module Isogram

open System

let isIsogram (word: string) =
    let letters =
        word
        |> Seq.filter(fun letter -> letter <> ' ' && letter <> '-')
        |> Seq.map Char.ToLower

    letters |> Seq.length = (letters |> Seq.distinct |> Seq.length)

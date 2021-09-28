module Isogram

open System

let isIsogram (str: string) =
    let letters =
        str.ToLower()
        |> Seq.filter Char.IsLetter
        |> Seq.toList

    letters = List.distinct letters

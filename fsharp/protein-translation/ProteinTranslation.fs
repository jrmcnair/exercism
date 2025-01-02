module ProteinTranslation

let toCodons (rna: string) =
    rna
    |> Seq.chunkBySize 3
    |> Seq.map System.String
    |> List.ofSeq

let proteins (rna: string) =
    let rec translate (codons: string list) (output: string list) =
        if codons.Length = 0 then List.rev output
        else
            match List.head codons, List.tail codons with
            | "AUG", c -> translate c ("Methionine"::output)
            | "UUU", c | "UUC", c -> translate c ("Phenylalanine"::output)
            | "UUA", c | "UUG", c -> translate c ("Leucine"::output)
            | "UCU", c | "UCC", c | "UCA", c | "UCG", c -> translate c ("Serine"::output)
            | "UAU", c | "UAC", c -> translate c ("Tyrosine"::output)
            | "UGU", c | "UGC", c -> translate c ("Cysteine"::output)
            | "UGG", c -> translate c ("Tryptophan"::output)
            | "UAA", _ | "UAG", _ | "UGA", _ -> List.rev output
            | _ -> failwith "invalid codon"

    translate (toCodons rna) []

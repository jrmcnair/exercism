module ProteinTranslation

let proteins (rna: string) =
    let rec translate (rna: string) (output: string list) =
        if rna.Length = 0 then List.rev output
        else
            match rna[0..2] with
            | "AUG" -> translate rna[3..] ("Methionine"::output)
            | "UUU" | "UUC" -> translate rna[3..] ("Phenylalanine"::output)
            | "UUA" | "UUG" -> translate rna[3..] ("Leucine"::output)
            | "UCU" | "UCC" | "UCA" | "UCG" -> translate rna[3..] ("Serine"::output)
            | "UAU" | "UAC" -> translate rna[3..] ("Tyrosine"::output)
            | "UGU" | "UGC" -> translate rna[3..] ("Cysteine"::output)
            | "UGG" -> translate rna[3..] ("Tryptophan"::output)
            | "UAA" | "UAG" | "UGA" -> List.rev output
            | _ -> failwith "invalid codon"

    translate rna []

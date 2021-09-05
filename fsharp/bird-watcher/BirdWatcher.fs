module BirdWatcher

let lastWeek: int[] = [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday(counts: int[]): int = counts.[5]

let total(counts: int[]): int =
  counts |> Array.reduce (+)

let dayWithoutBirds(counts: int[]): bool =
  counts |> Array.exists (fun x -> x = 0)

let incrementTodaysCount(counts: int[]): int[] =
    Array.append counts.[0..5] [| counts.[6] + 1 |]

let oddWeek(counts: int[]): bool =
  counts = [| 1; 0; 1; 0; 1; 0; 1 |]

module Seq

let keep (pred: 'a -> bool) (xs: 'a seq) =
    seq {
        for x in xs do
            if pred x then yield x
    }

let discard (pred: 'a -> bool) (xs: 'a seq) =
    seq {
        for x in xs do
            if not (pred x) then yield x
    }

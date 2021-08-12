module Clock

type Clock =
  { Hours: int
    Minutes: int }

let processMinutes (minutes: int) : (int * int) =
    let minute = minutes % 60
    let hourOffset = minutes / 60

    match minute with
    | x when x >= 0 -> (hourOffset, minute)
    | _ -> (hourOffset - 1, 60 + minute)

let processHours (hours: int) : int =
    match hours % 24 with
    | hour when hour >= 0 -> hour
    | hour -> 24 + hour

let create (hours:int) (minutes: int) =
    let (hourOffset, minute) = processMinutes minutes
    let hour = processHours (hours + hourOffset)

    { Hours = hour; Minutes = minute }

let add minutes clock =
   create clock.Hours (clock.Minutes + minutes)

let subtract minutes clock =
   create clock.Hours (clock.Minutes - minutes)

let display clock =
    let to24Hour (num: int) = num.ToString("D2")

    sprintf "%s:%s" (to24Hour clock.Hours) (to24Hour clock.Minutes)
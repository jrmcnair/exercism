module Clock

type Clock =
  { Hours: int
    Minutes: int }

let processMinutes (minutes: int) : (int * int) =
    let minute = minutes % 60
    let hourOffset = minutes / 60

    if minute >= 0
        then (hourOffset, minute)
        else (hourOffset - 1, 60 + minute)

let processHours (hours: int) : int =
    let hour = hours % 24
    if hour >= 0
        then hour
        else 24 + hour

let create (hours:int) (minutes: int) =
    let (hourOffset, minute) = processMinutes minutes
    let hour = processHours (hours + hourOffset)

    { Hours = hour; Minutes = minute }

let add minutes clock =
   create clock.Hours (clock.Minutes + minutes)

let subtract minutes clock =
   create clock.Hours (clock.Minutes - minutes)

let display clock =
    sprintf "%02d:%02d" clock.Hours clock.Minutes
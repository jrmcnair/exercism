module Meetup

open System

type Week = First | Second | Third | Fourth | Last | Teenth

let getDaysForDayOfWeek year month dayOfWeek =
    [1..DateTime.DaysInMonth(year, month)]
    |> List.choose (fun day ->
        if DateTime(year, month, day).DayOfWeek = dayOfWeek
        then Some day
        else None)

let getTeenthDay days =
    days |> List.find (fun day -> day > 12)

let meetup year month week dayOfWeek =
    let days = getDaysForDayOfWeek year month dayOfWeek

    match week with
    | First -> DateTime(year, month, days |> List.head)
    | Last -> DateTime(year, month, days |> List.last)
    | Second -> DateTime(year, month, days.[1])
    | Third -> DateTime(year, month, days.[2])
    | Fourth -> DateTime(year, month, days.[3])
    | Teenth -> DateTime(year, month, days |> getTeenthDay)

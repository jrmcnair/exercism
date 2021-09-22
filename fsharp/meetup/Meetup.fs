module Meetup

open System

type Week = First | Second | Third | Fourth | Last | Teenth

let getStartDate year month week =
    if week = Last
    then DateTime(year, month, DateTime.DaysInMonth(year, month))
    else DateTime(year, month, 1)

let getDiff (first: DayOfWeek, last: DayOfWeek) =
    match (int) last - (int) first with
    | x when x < 0 -> x + 7
    | x -> x
    |> float

let getDayShift (date:DateTime) (dayOfWeek: DayOfWeek) (week: Week) =
    if week = Last
    then (dayOfWeek, date.DayOfWeek)
    else (date.DayOfWeek,dayOfWeek)
    |> getDiff

let rec findTeenth (date: DateTime) =
    if date.Day < 13
    then date.AddDays 7. |> findTeenth 
    else date
        
let meetup year month week dayOfWeek =
    let startDate = getStartDate year month week
    let shift = getDayShift startDate dayOfWeek week

    match week with
    | First -> shift |> startDate.AddDays
    | Second -> shift + 7. |> startDate.AddDays
    | Third -> shift + 14. |> startDate.AddDays
    | Fourth -> shift + 21. |> startDate.AddDays
    | Last -> shift * -1. |> startDate.AddDays
    | Teenth -> shift |> startDate.AddDays |> findTeenth

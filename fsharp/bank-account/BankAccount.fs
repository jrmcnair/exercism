module BankAccount

type Account = { mutable State: State }
and State = | Pending | Open of balance: decimal | Closed

let mkBankAccount() = { State = Pending }

let openAccount account =
    match account.State with
    | Pending | Closed -> account.State <- Open 0.0m
    | _ -> failwith "invalid account state"
    account

let closeAccount account =
    match account.State with
    | Open _ | Pending -> account.State <- Closed
    | _ -> failwith "invalid account state"
    account

let getBalance account =
    match account.State with
    | Open balance -> Some balance
    | _ -> None


let updateBalance change account =
    lock account (fun _ ->
        match account.State with
        | Open balance -> account.State <- Open (balance + change)
        | _ -> failwith "invalid account state")
    account

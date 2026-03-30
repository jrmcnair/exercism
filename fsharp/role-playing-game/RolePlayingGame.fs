module RolePlayingGame

type Player = { 
    Name: string option
    Level: int
    Health: int
    Mana: int option
}

let introduce (player: Player): string =
    match player.Name with
    | Some name -> name
    | None -> "Mighty Magician"

let revive (player: Player): Player option =
    match player.Health with
    | 0 when player.Level >= 10 -> Some { player with Health = 100; Mana = Some 100 }
    | 0 ->  Some { player with Health = 100 }
    | _ -> None

let castSpell (manaCost: int) (player: Player): Player * int =
    let lowerHealth =
        if manaCost > player.Health then 0
        else player.Health - manaCost

    match player.Mana with
    | Some mana when mana >= manaCost -> { player with Mana = Some (mana - manaCost) }, manaCost * 2
    | Some _ -> player, 0
    | None -> { player with Health = lowerHealth }, 0

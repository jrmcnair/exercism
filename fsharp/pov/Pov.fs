module Pov

type Graph<'T> = {
    value: 'T
    children: Graph<'T> list
}

let mkGraph value children = { value = value; children = children }

let fromPOV (target: 'T) (tree: Graph<'T>) =
    let rec pov (parent: Graph<'T> option) (node: Graph<'T>) =
        match parent, node.value with
        | None, v when v = target -> Some node
        | Some p, v when v = target -> Some { node with children = p::node.children }
        | None, _ ->
            node.children |> List.tryPick (fun child ->
                let children = node.children |> List.except [child]
                pov (Some { node with children = children }) child)
        | Some p, _ ->
            node.children |> List.tryPick (fun child ->
                let children = p::node.children |> List.except [child]
                pov (Some { node with children = children }) child)

    pov None tree
    
let tracePathBetween (a: 'T) (b: 'T) (tree: Graph<'T>) =
    let rec trace (curr: Graph<'T>) (path: 'T list) =
        let newPath = curr.value :: path
        if curr.value = b then Some (List.rev newPath)
        else curr.children |> List.tryPick (fun c -> trace c newPath)

    fromPOV a tree
    |> Option.bind (fun start -> trace start [])

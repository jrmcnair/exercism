module Pov

type Graph<'a> = {
    value: 'a
    children: Graph<'a> list
}

let mkGraph (value: 'a) (children: Graph<'a> list) : Graph<'a> =
    { value = value
      children = children }

let findMatchingChildNode (value: 'a) (nodes: Graph<'a> list) =
    nodes |> List.tryFind(fun x -> x.value = value)

let fromPOV (value: 'a) (tree: Graph<'a>) : Graph<'a> option =
    if tree.value = value
        then Some tree
        else None

    // TODO: find node, keeping track of how we get there?
    // TODO: re-parent if found
    // TODO: fail if not found

let tracePathBetween (value: 'a) (parent: 'a) (tree: Graph<'a>) : 'a list option =
    failwith "not implemented"
module BinarySearchTree

type Node<'a> =
  { Value: 'a
    mutable Left: Node<'a> option
    mutable Right: Node<'a> option }

let left node  = node.Left

let right node = node.Right

let data node = node.Value

let create (items: 'a list) =
    let root = { Value = List.head items; Left = None; Right = None }

    let rec add (node: Node<'a>) (parent: Node<'a>) =
        if node.Value <= parent.Value then
            if Option.isNone parent.Left then parent.Left <- Some node
            else add node (Option.get parent.Left)
        else
            if Option.isNone parent.Right then parent.Right <- Some node
            else add node (Option.get parent.Right)

    items
    |> Seq.tail
    |> Seq.iter (fun v -> add { Value = v; Left = None; Right = None } root)
    
    root
    

let sortedData node =
    let rec sort (node: Node<'a>) : 'a list =
        match node.Left, node.Right with
        | Some l, Some r -> sort l @ [ node.Value ] @ sort r
        | Some l, None -> sort l @ [ node.Value ]
        | None, Some r -> node.Value::(sort r)
        | None, None -> [ node.Value ]
    
    sort node

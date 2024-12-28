module Zipper

type Tree<'a> = { Value: 'a; Left: Tree<'a> option; Right: Tree<'a> option }
type Zipper<'a> = { Focus: Tree<'a>; Path: (Direction * Tree<'a>) list }
and Direction = | Left | Right

let left z =
    z.Focus.Left |> Option.bind (fun t -> Some { Focus = t; Path = (Left, z.Focus)::z.Path })
let setLeft left z = { z with Focus.Left = left }

let right z =
    z.Focus.Right |> Option.bind (fun t -> Some { Focus = t; Path = (Right, z.Focus)::z.Path })
let setRight right z = { z with Focus.Right = right }

let value z = z.Focus.Value
let setValue value z = { z with Focus.Value = value }

let up z =
    match z.Path with
    | [] -> None
    | (Left, tree)::path -> Some { Focus = { tree with Left = Some z.Focus }; Path = path }
    | (Right, tree)::path -> Some { Focus = { tree with Right = Some z.Focus }; Path = path }

let tree v l r = { Value = v; Left = l; Right = r }
let fromTree root = { Focus = root; Path = [] }

let rec toTree z =
    if z.Path = [] then z.Focus
    else toTree (up z |> Option.get)

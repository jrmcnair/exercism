// This file was created manually and its version is 1.0.0.

module RobotNameTest

open Xunit
open FsUnit.Xunit
open System.Text.RegularExpressions
open RobotName

[<Fact>]
let ``Robot has a name`` () =     
    let robot = mkRobot()
    Regex.IsMatch(name robot, @"^[A-Z]{2}\d{3}$") |> should equal true
    
[<Fact>]
let ``Name is the same each time`` () =     
    let robot = mkRobot()
    name robot |> should equal (name robot)

[<Fact>]
let ``2 Different robots have different names`` () = 
    let robot = mkRobot()
    let robot2 = mkRobot()
    name robot |> should not' (equal (name robot2))

[<Fact>] 
let ``2500 Different robots have different names``() =
    let robotCount = 2500
    seq { 1 .. robotCount }
    |> Seq.map (fun _ -> mkRobot())
    |> Seq.map (fun robot -> name robot)
    |> Set
    |> Set.count
    |> should equal robotCount
    
[<Fact>]
let ``Can reset the name`` () =  
    let robot = mkRobot()
    let originalName = name robot
    let resetRobot = reset robot
    originalName |> should not' (equal (name resetRobot))

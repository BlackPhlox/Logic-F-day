﻿//#load "C:/Users/thelu/source/repos/Logic-F-day/logic-f-day/PrintUtil.fs";;

module Tests
    //Load in interactive from here V
    open Program
    //Tests

    //Tree Tests

    let type01 = OUT("O1", OUT("O2",((IN "A") .&. B true)) .&. (IN "B"))
    printfn "%A" (type01.ToString())
    type01.PrintTree()

    let type02 = (B true) .&. (B false)
    printfn "%A" (type02.ToString())
    type02.PrintTree()

    let type03 = ((IN "A") .*|. (IN "A")) .&. (IN "B")
    printfn "%A" (type03.ToString())
    type03.PrintTree()

    let st01 = (IN "A").&.(NOT (IN "A"))

    gateSimplify st01

    let st = Map.ofList [("A", B true)]
    let ft = NOT (IN "B") .-|. IN "B"
    ft.PrintTree()
    let ou2 = gateSimplify ft
    let out = gateEval ft st

    let v1 = gateEval (NOT (B true)) st
    let v2 = gateEval (NOT (IN("B"))) st
    let v3 = gateEval (NOT (AND(IN("A"),IN("B")))) st
    let v4 = gateEval (OUT("O",NOT (B true)).|.(AND(IN("A"),IN("B")))) st

    let gs01 = gateSimplify (NOT (NOT(IN("B"))))
    let gs02 = gateSimplify (NOT (AND(IN("A"),IN("B"))))

    //let gs03 = nandGateSimplify (gateSimplify (NOT (AND(IN("A"),IN("B")))))
    
    let gs04 = gateSimplify(OR(IN "A",IN "A"))

    let gs05 = gateSimplify(AND(IN "x",OR(IN "x",IN "B")))

    //Test Simplify rules

    //Identity
    let sr_i00 = "Identity"
    let sr_i01 = string (gateSimplify(IN "A" .&. IN "A"))//A
    let sr_i02 = string (gateSimplify(IN "A" .|. IN "A"))//A
    let sr_i03 = string (gateSimplify((IN "A" .&. IN "B") .|. (IN "A" .&. (NOT (IN "B"))))) //A //Precedence mistake(No pre.)
    let sr_i04 = string (gateSimplify((IN "A" .|. IN "B") .&. (IN "A" .|. (NOT (IN "B"))))) //A

    //Redundancy
    let sr_r00 = "Redundancy"
    let sr_r01 = string (gateSimplify((IN "A" .&. (IN "A" .|. IN "B"))))    //A
    let sr_r02 = string (gateSimplify((IN "A" .|. (IN "A" .&. IN "B"))))    //A
    let sr_r03 = string (gateSimplify( B false .&. IN "A"))                 //False
    let sr_r04 = string (gateSimplify( B false .|. IN "A"))                 //A
    let sr_r05 = string (gateSimplify( B true  .&. IN "A"))                 //A
    let sr_r06 = string (gateSimplify( B true  .|. IN "A"))                 //True
    let sr_r07 = string (gateSimplify( NOT(IN "A") .&. IN "A"))             //False
    let sr_r071= string (gateSimplify( IN "A" .&. NOT(IN "A")))             //False
    let sr_r08 = string (gateSimplify( NOT(IN "A") .|. IN "A"))             //True
    let sr_r081= string (gateSimplify( IN "A" .|. NOT (IN "A")))            //True

    let sr_o00 = "Other"
    let sr_o01 = string (gateSimplify((IN "A" .*|. (IN "A" .|. IN "B")))) //~A * B
    let sr_o02 = string (gateSimplify((IN "B" .*|. (IN "A" .|. IN "B")))) //~B * A

    let gs1 = (*nandGateSimplify*) (gateSimplify ((NOT (IN "A").-&. IN "B") .*|. NOT (IN "A" .|. NOT(IN "A"))))

    let p1 = string gs1

    let e1 = gateEval gs1 st

    printfn "%A" (gs1)
    gs1.PrintTree()

    gs1.PrintTree();


    let t01 = (NOT (B false) .&. (B true) .-&. (IN "A" .-|. IN "B"))
    t01.ToString()
    let t01simp = gateSimplify t01
    t01.PrintTree()
    TruthTable t01
    t01simp.PrintTree()
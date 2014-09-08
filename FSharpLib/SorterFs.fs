namespace SorterFs

type Switch =
    {
        Low: int;
        High: int;
    }

type BitonicSwtichBlock = 
    {
        KeyCount: int;
    }

module BasicMath =
   
    let IntPow x y =
       (int) (((float)x)**((float)y))

// End of BasicMath


module SwitchFunctions =

    let IsValid (switch:Switch) =
        if switch.Low < 0 then false
        elif  switch.High < 0 then false
        elif switch.Low >= switch.High then false
        else true
    
    let SpanFolder (keyCount:int) =
            let span = keyCount/2
            [0 .. (keyCount - span - 1)]
            |> List.map (fun x -> { Low =x; High =keyCount-x-1})
    
    let SpanFoldPow (logKeys:int) =
        SpanFolder(BasicMath.IntPow 2 logKeys)


    let SpanStepper (keyCount:int) =
            let span = keyCount/2
            [0 .. (keyCount - span - 1)]
            |> List.map (fun x -> { Low =x; High =x+span})

    let SpanStepPow (logKeys:int) =
        SpanStepper(BasicMath.IntPow 2 logKeys)

    let AppendBelow switches offset =
       [
            for sw in switches 
                do yield! [sw;  {Low= sw.Low + offset; High=sw.High + offset}]
       ]

    
    let AppendBelowPow switches logOffset =
        AppendBelow (switches) (BasicMath.IntPow 2 logOffset)
   
    let SwitchOffset switchList (offset : int) =
       switchList |> Seq.map (fun x -> { Low = x.Low + offset; High = x.High + offset})


    let SwitchMultiOffset (switchList : seq<Switch>) (offset : int) (reps : int) =
        let rec Bs sv =
            match sv with
            | (a, s, o, 0) -> (Seq.append a s, Seq.empty, o, 0)
            | (a, s, o, m) -> Bs (Seq.append a s, (SwitchOffset s o), o, m-1)

        let (a,b,c,d) = Bs (Seq.empty, switchList, offset, reps-1)
        a

    let BitonicSuffix (logKeyCount : int) =
        let rec Bs sv =
            match sv with
            | (a, s, k, 0) -> (Seq.append a s, Seq.empty, k, 0)
            | (a, s, k, m) -> Bs (Seq.append a s, (SwitchOffset s k), k, m-1)

        let (a,b,c,d) = Bs (Seq.empty, Seq.empty, logKeyCount, logKeyCount)
        a

    let SwitchReport sw = sprintf "[%d, %d]; " sw.Low sw.High

    let SwitchIndex sw = sprintf "%i" (((sw.High-1) * sw.High)/2 + sw.Low) + ";"
        
    let SwitchListReport switchList = 
        Seq.fold (fun acc sw -> (acc + SwitchReport(sw))) "" switchList 

    let SwitchListIndexes (switchList : Switch list) = 
        List.fold (fun acc sw -> (acc + SwitchIndex(sw))) "" switchList 
        

// End of SwitchFunctions


module BitonicFunctions = 

    let BitonicSwitchCount logKeyCount =
        let rec Bct  lv =
            match lv with
            | (0, 0, 0, t) -> Bct (0, 1, 1, t)
            | (p, s, r, 0) -> (p, s, r, 0)
            | (p, s, r, t) -> Bct(2*(p+s), 2*s + (BasicMath.IntPow 2 r), r+1, t-1)

        let (a,b,c,d) = Bct (0,0,0,logKeyCount)
        a + b

   
    let BitonicSwitchesOld logKeyCount =
        let rec Bs sv =
            match sv with
            | (p, s, 0, t) -> Bs (List.Empty, [ {Low=0; High=1} ], 1, t)
            | (p, s, r, 0) -> (p, s, r, 0)
            | (p, s, r, t) 
                -> Bs (
                        SwitchFunctions.AppendBelowPow (p@s) (r), 
                        (SwitchFunctions.SpanStepPow(r+1))@( SwitchFunctions.AppendBelowPow s r), 
                        r+1, 
                        t-1
                      )

        let (a,b,c,d) = Bs (List.Empty, List.Empty, 0, logKeyCount-1)
        a@b


    let BitonicSwitches logKeyCount =
        let rec Bs sv =
            match sv with
            | (p, s, 0, t) -> Bs (List.Empty, [ {Low=0; High=1} ], 1, t)
            | (p, s, r, 0) -> (p, s, r, 0)
            | (p, s, r, t) 
                -> Bs (
                        SwitchFunctions.AppendBelowPow (p@s) (r), 
                        (SwitchFunctions.SpanFoldPow(r+1))@( SwitchFunctions.AppendBelowPow s r), 
                        r+1, 
                        t-1
                      )

        let (a,b,c,d) = Bs (List.Empty, List.Empty, 0, logKeyCount-1)
        a@b

// End of BitonicFunctions

module Play = 

    let Cw (switchList : Switch list) =
        switchList@switchList

    let CwSeq (switchList : seq<Switch>) =
        Cw (switchList |> Seq.toList)


namespace SorterFsOld

type Switch =
    {
        Low: int;
        High: int;
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

    let IndexOf (sw:Switch) =
        (((sw.High-1) * sw.High)/2 + sw.Low) 
    
    let SpanFolder (keyCount:int) =
        let span = keyCount/2
        {0 .. (keyCount - span - 1)}
        |> Seq.map (fun x -> { Low=x; High=keyCount-x-1})

    let SpanFoldPow (logKeys:int) =
        SpanFolder(BasicMath.IntPow 2 logKeys)


    let SpanStepper (keyCount:int) =
            let span = keyCount/2
            [0 .. (keyCount - span - 1)]
            |> List.map (fun x -> { Low =x; High =x+span})

    let SpanStepPow (logKeys:int) =
        SpanStepper(BasicMath.IntPow 2 logKeys)

    let AppendBelow switches offset =
        switches |> Seq.map (fun (sw) -> seq [sw;  {Low=sw.Low + offset; High=sw.High + offset}]) 
                 |> Seq.concat


    let AppendBelowPow switches logOffset =
        AppendBelow (switches) (BasicMath.IntPow 2 logOffset)
   
    let SwitchListOffset switchList (offset : int) =
       switchList |> Seq.map (fun x -> { Low = x.Low + offset; High = x.High + offset})


    let SwitchListArrayExtend (switchList : seq<Switch>) (offset : int) (reps : int) =
        let rec Bs sv =
            match sv with
            | (a, s, o, 0) -> (Seq.append a s, Seq.empty, o, 0)
            | (a, s, o, m) -> Bs (Seq.append a s, (SwitchListOffset s o), o, m-1)

        let (a,b,c,d) = Bs (Seq.empty, switchList, offset, reps-1)
        a

    let NestedSwitchArray (switch : Switch) (offset1 : int) (reps1 : int) (offset2 : int) (reps2 : int) =
       SwitchListArrayExtend (SwitchListArrayExtend [switch] offset1 reps1) offset2 reps2
    
    let BitonicNestedSwitchArray (logKeyCount : int) (level : int)=
       let switchLength = BasicMath.IntPow 2 (level)
       let nestSize = BasicMath.IntPow 2 (level)
       let nestCount = BasicMath.IntPow 2 (logKeyCount-level-1)
       let nestGap = BasicMath.IntPow 2 (level+1)
       NestedSwitchArray {Low = 0; High=switchLength} 1 nestSize nestGap nestCount

    let BitonicSuffix (logKeyCount : int) =
        let rec Bs sv =
            match sv with
            | (a, s, k, m) when k<2 -> (Seq.empty, Seq.empty, k, -1)
            | (a, s, k, -1) -> (Seq.append a s, Seq.empty, k, -1)
            | (a, s, k, m) -> Bs (Seq.append a s, (BitonicNestedSwitchArray k m), k, m-1)

        let (a, s, k, m) = Bs (Seq.empty, Seq.empty, logKeyCount, logKeyCount-2)
        a

    let SwitchReport sw = sprintf "[%d, %d]; " sw.Low sw.High

    let SwitchIndex sw = sprintf "%i" (((sw.High-1) * sw.High)/2 + sw.Low) + ","
        
    let SwitchListReport switchList = 
        Seq.fold (fun acc sw -> (acc + SwitchReport(sw))) "" switchList 

//    let SwitchListIndexes (switchList : Switch list) = 
//        List.fold (fun acc sw -> (acc + SwitchIndex(sw))) "" switchList 
        
    let SwitchListIndexes (switchList : seq<Switch>) =
        Seq.fold (fun acc sw -> (acc + SwitchIndex(sw))) "" switchList 
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


    let BitonicSwitches logKeyCount =
        let rec Bs sv =
            match sv with
            | (a, k, t) when k < 1 -> (Seq.empty, 0, 0)
            | (a, k, 0) -> (a, k, 0)
            | (p, k, t) 
                -> Bs (
                        SwitchFunctions.BitonicSuffix(k-t+1)
                        |> Seq.append (SwitchFunctions.SpanFoldPow (k-t+1))
                        |> Seq.append (SwitchFunctions.AppendBelowPow p (k-t)),
                        k, 
                        t-1
                      )

        let (a,k,t) = Bs (seq [ {Low=0; High=1} ], logKeyCount, logKeyCount-1)
        a

// End of BitonicFunctions

module Play = 

    let Cw (switchList : Switch list) =
        switchList@switchList

    let CwSeq (switchList : seq<Switch>) =
        Cw (switchList |> Seq.toList)


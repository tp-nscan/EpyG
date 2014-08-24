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

    let Spanner (keyCount:int) =
            let span = keyCount/2
            [0 .. (keyCount - span - 1)]
            |> List.map (fun x -> { Low =x; High =x+span})

    let SpanPow (logKeys:int) =
        Spanner(BasicMath.IntPow 2 logKeys)


    let AppendBelow switches offset =
       [
            for sw in switches 
                do yield! [sw;  {Low= sw.Low + offset; High=sw.High + offset}]
       ]

    let AppendBelowPow switches logOffset =
        AppendBelow (switches) (BasicMath.IntPow 2 logOffset)


    let SwitchReport sw = sprintf "[%d, %d]; " sw.Low sw.High

//    let SwitchListReport switchList = 
//        switchList |> List.fold (fun r s -> r + SwitchReport(s) + "\n") ""

    let SwitchListReport switchList = 
        List.fold (fun acc sw -> (acc+ SwitchReport(sw))) "" switchList 
        

// End of SwitchFunctions


module BitonicFunctions = 

    let func1 x = x*x + 3     


    let rec Multiple x =
        if x = 1000 then 0
        elif x%3 = 0 || x%5 = 0 then x + Multiple (x+1)
        else Multiple (x+1)



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
            | (p, s, 0, t) -> Bs (List.Empty, [ {Low=0; High=1} ], 1, t)
            | (p, s, r, 0) -> (p, s, r, 0)
            | (p, s, r, t) 
                -> Bs (
                        SwitchFunctions.AppendBelowPow (p@s) (r), 
                        (SwitchFunctions.SpanPow(r+1))@( SwitchFunctions.AppendBelowPow s r), 
                        r+1, 
                        t-1
                      )

        let (a,b,c,d) = Bs (List.Empty, List.Empty, 0, logKeyCount-1)
        a@b



// End of BitonicFunctions

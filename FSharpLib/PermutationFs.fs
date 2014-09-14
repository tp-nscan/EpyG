namespace PermutationFs
open System

type PermutationType = {Degree:int; RepArray:int array }

module Permutation =
   
    let create (sequence:int array) = {Degree=sequence.Length; RepArray=sequence}

    let KnuthShuffle (lst : array<'a>) (rng: Random) =                
        let Swap i j =                                               
            let item = lst.[i]
            lst.[i] <- lst.[j]
            lst.[j] <- item
        let ln = lst.Length
        [0..(ln - 2)]                                                
        |> Seq.iter (fun i -> Swap i (rng.Next(i, ln)))        
        lst                         

    let createUnit degree = {Degree=degree; RepArray=[|0..(degree-1)|]}

    let createFromSeed degree seed =
        {Degree=degree; RepArray= (KnuthShuffle [|0..(degree-1)|]) (Random(seed))}

    let swappedIndex low high current (sequence: int array) =
        match current with
        | low -> sequence.[high]
        | high -> sequence.[low]
        | _ -> sequence.[current]


    let swap lhs rhs permutation = 
        ( [|0..permutation.Degree|] |> Array.map (fun i->(swappedIndex lhs rhs i permutation.RepArray)))

    let apply permutation sequence =
        sequence |> Seq.map (fun x-> permutation.RepArray.[x])

    let pp2 = create [|1;3;2;4;0;|]

    let trans = apply pp2 [1; 3; 2; 4; 0]
    


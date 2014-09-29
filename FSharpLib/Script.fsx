

#load "SorterFsOld.fs"
open SorterFsOld

let sw = {Low=0; High=1}

let swd = BitonicFunctions.BitonicSwitches 3

let rep = SwitchFunctions.SwitchListReport swd

open System
let sleepWorkflow  = async{
    printfn "Starting sleep workflow at %O" DateTime.Now.TimeOfDay
    do! Async.Sleep 2000
    printfn "Finished sleep workflow at %O" DateTime.Now.TimeOfDay
    }
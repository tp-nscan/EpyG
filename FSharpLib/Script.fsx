

#load "SorterFsOld.fs"
open SorterFsOld

let sw = {Low=0; High=1}

let swd = BitonicFunctions.BitonicSwitches 3

let rep = SwitchFunctions.SwitchListReport swd
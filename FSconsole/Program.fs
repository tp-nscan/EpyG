module DefiningClasses

    [<EntryPoint>]
    let main argv = 


        let vector1 = Person.Vector2D(3.0, 4.0)

        let vectorPrint (x : Person.Vector2D) =
            printfn "Vector: %f" x.DX


        let square x = x*x

        let squareprint x =
            printfn "N^2 = %A"x

        let squareprint2 (x : string) =
            System.Console.WriteLine(x)

        let numbers = [1 .. 10]

        let squares = List.filter (fun x -> x % 2 = 0) numbers

        squareprint squares

        squareprint2 (sprintf "N^2 = %A" squares)

        vectorPrint vector1





        System.Console.ReadKey()



        0 // return an integer exit code

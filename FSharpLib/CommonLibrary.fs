namespace test

module Railroad =
    type EmailAddress = EmailAddress of string
    type ZipCode = ZipCode of string
    type StateCode = StateCode of string

    let CreateEmailAddress (s:string) = 
        if System.Text.RegularExpressions.Regex.IsMatch(s,@"^\S+@\S+\.\S+$") 
            then Some (EmailAddress s)
            else None









//let ada = ["a"; "b"; "c"] |> List.map Railroad.EmailAddress;;
//let (Railroad.EmailAddress a') = a;;


namespace Core

open System
open System.Text

module c=begin
    type System.String with
        member this.Contains( c : char) : bool = 
            this.IndexOf(c) >= 0
end

open c

[<AbstractClass; Sealed>]
type PhonewordTranslator private() =
    static member ToNumber(_raw : String) : String =
        if String.IsNullOrWhiteSpace(_raw) then
                null
            else
                let raw = _raw.ToUpperInvariant()
                let newNumber = new StringBuilder()
                for c in raw.ToCharArray() do
                    if " -0123456789".Contains(c) then
                        newNumber.Append(c) |> ignore
                    else
                        let result = PhonewordTranslator.TranslateToNumber(c)
                        if result.HasValue then
                            newNumber.Append(result) |> ignore
                        // Bad character?
                        else
                            () |> ignore
                newNumber.ToString()
 
    static member digits = [| "ABC"; "DEF"; "GHI"; "JKL"; "MNO"; "PQRS"; "TUV"; "WXYZ" |]
 
    static member TranslateToNumber(c : char) : Nullable<int> =
        let mutable ret : Nullable<int> = new Nullable<int>()
        for i in 0 .. PhonewordTranslator.digits.Length - 1 do
            if PhonewordTranslator.digits.[i].Contains(c) then ret <- new Nullable<int>(2 + i)
        ret
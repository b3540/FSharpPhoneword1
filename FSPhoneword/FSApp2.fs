namespace Phoneword

type FSApp2() =
    static member val PhoneNumbers : ResizeArray<string> = new ResizeArray<string>()  with  get, set

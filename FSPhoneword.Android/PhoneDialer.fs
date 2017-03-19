namespace Phoneword.Droid

open System.Linq
open Xamarin.Forms
open Phoneword
open Android.Telephony
open Android.Content
open Android.Net

type PhoneDialer =
    new () = {}
    member self.IsIntentAvailable(context : Context, intent : Intent) : bool =
        let packageManager = context.PackageManager
 
        let list = packageManager.QueryIntentServices(intent, enum<PM.PackageInfoFlags> 0).Union(packageManager.QueryIntentActivities(intent, enum<PM.PackageInfoFlags> 0))
 
        if list.Any() then
                true
            else
 
        let manager = TelephonyManager.FromContext(context)
        not (manager.PhoneType = PhoneType.None)

    interface IDialer with
        member self.Dial(number : string) : bool =
            let context = Forms.Context
            if context = null then
                    false
                 else
 
            let intent = new Intent(Intent.ActionCall)
            intent.SetData(Uri.Parse("tel:" + number)) |> ignore
 
            if self.IsIntentAvailable(context, intent) then
                    context.StartActivity(intent)
                    true
                else

            false
 
[<assembly: Dependency(typeof<PhoneDialer>)>] 
do()

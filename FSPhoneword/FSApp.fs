namespace Phoneword

open System
open System.Collections.Generic
open Xamarin.Forms

type FSApp() as self =
    inherit App()
    do
        self.MainPage <- new NavigationPage(new Phoneword.FSMainPage());

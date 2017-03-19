namespace Phoneword

open Xamarin.Forms

type CallHistoryPage() as self =
    inherit ContentPage()
    do
        self.Title <- "Recent Call"
        let stackLayout = new StackLayout()
        stackLayout.VerticalOptions <- LayoutOptions.FillAndExpand
        stackLayout.Orientation <- StackOrientation.Vertical
        let listView = new ListView()
        listView.ItemsSource <- FSApp2.PhoneNumbers
        stackLayout.Children.Add(listView)
        self.Content <- stackLayout

using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResults : ContentPage
    {
        public SearchResults(List<ChildItem> results, MainPage main)
        {
            InitializeComponent();

            //Output results
            CountResults.Text = results.Count + " results";

            if (results.Count == 0)
            {
                CountResults.Text = "0 results :/";
            }
            else if (results.Count == 1)
            {
                CountResults.Text = results.Count + " result";
            }

            SearchResultsList.ItemsSource = results;
            SearchResultsList.ItemSelected += (sender, EventArgs) => ViewItem(sender, EventArgs, main);
        }

        async void ViewItem(object sender, SelectedItemChangedEventArgs e, MainPage main)
        {
            //Navigate to view of selected item
            var page = new NavigationPage(new ObjectView(e.SelectedItem as TierItem, main));
            page.BindingContext = e.SelectedItem;

            await Navigation.PushAsync(new MainPage(main.BindingContext as User)
            {
                Detail = page
            });
        }
    }
}
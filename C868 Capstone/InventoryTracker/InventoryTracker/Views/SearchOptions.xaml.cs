using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchOptions : ContentPage
    {
        public SearchOptions(TierItem tierItem, MainPage main)
        {
            InitializeComponent();
            //Event handlers
            SearchButton.Clicked += (sender, EventArgs) => Search(sender, EventArgs, tierItem, main);
            CancelButton.Clicked += (sender, EventArgs) => Cancel(sender, EventArgs, tierItem, main);
        }

        async void Search(object sender, EventArgs e, TierItem tierItem, MainPage main)
        {
            //If searchBox is empty
            if (string.IsNullOrEmpty(LocalSearch.Text))
            {
                await DisplayAlert("Enter search term", "Please enter a keyword or phrase to search.", "OK");
                return;
            }

            //If no items are checked
            if (!AddedCheck.IsChecked && !ChangedCheck.IsChecked &&
                !DescCheck.IsChecked && !NameCheck.IsChecked)
            {
                await DisplayAlert("Check, please", "Please select one or more attirbutes to search by.", "OK");
                return;
            }

            //If no Sort By item is selected
            if (SortPicker.SelectedItem == null)
            {
                await DisplayAlert("Choose sort option", "Please select a sort option.", "OK");
                return;
            }

            //Do search
            //Pass list of results and main to SearchResults
            string searchTerm = LocalSearch.Text;
            string queryPartOne;
            string queryPartTwo = " AND (";
            
            //Global search if toggled
            if (!ScopeToggle.IsToggled || tierItem.Type == "User")
            {
                queryPartOne = ($"SELECT * FROM ChildItem WHERE User = {(main.BindingContext as User).Username} AND (Name LIKE '%{searchTerm}%' OR Description LIKE '%{searchTerm}%' OR CreatedOn LIKE '%{searchTerm}%' OR LastChangedOn LIKE '%{searchTerm}%') ORDER BY {SortPicker.SelectedItem} COLLATE NOCASE ASC");
                var results = new List<ChildItem> { };

                try
                {
                    results = await App.Database.GlobalSearch(queryPartOne);
                    results.OrderBy(o => o.Name).ToList();
                    results.OrderBy(o => o.Type).ToList();
                }
                catch 
                { 
                    //Do nothing
                    //Returns as zero results
                }
                
                await Navigation.PushAsync(new SearchResults(results, main));
            }

            //Searches only descendants of current object
            else
            {
                List<ChildItem> parents = new List<ChildItem> { tierItem as ChildItem };
                List<ChildItem> results = new List<ChildItem> { };
                List<bool> areChecked = new List<bool> { false, false, false, false };

                //Check which options are checked
                if (NameCheck.IsChecked)
                    areChecked[0] = true;
                if (DescCheck.IsChecked)
                    areChecked[1] = true;
                if (AddedCheck.IsChecked)
                    areChecked[2] = true;
                if (ChangedCheck.IsChecked)
                    areChecked[3] = true;

                queryPartOne = $"SELECT * FROM ChildItem WHERE User = '{(main.BindingContext as User).Username}' AND ParentID = ";
                //List of string options
                List<string> queryVals = new List<string> { "Name LIKE '%" + searchTerm + "%'", "Description LIKE '%" + searchTerm + "%'", "CreatedOn LIKE '%" + searchTerm + "%'", "LastChangedOn LIKE '%" + searchTerm + "%'" };


                int trueCount = 0;

                //Create string based on checked options
                for (int i = 0; i < areChecked.Count; i++)
                {
                    if (trueCount == 0 && areChecked[i])
                    {
                        queryPartTwo += queryVals[i];
                        trueCount++;
                    }
                    else if (trueCount > 0 && areChecked[i])
                    {
                        queryPartTwo += " OR " + queryVals[i];
                        trueCount++;
                    }
                }

                queryPartTwo += $") ORDER BY {SortPicker.SelectedItem} COLLATE NOCASE ASC";

                try
                {
                    //Query and sort
                    results = await App.Database.LocalSearch(parents, queryPartOne, queryPartTwo, results);
                    results.OrderBy(o => o.Name).ToList();
                    results.OrderBy(o => o.Type).ToList();
                }
                catch
                {
                    //Do nothing
                    //Returns as zero results
                }
                //Send results
                await Navigation.PushAsync(new SearchResults(results, main));
            }
        }

        void Cancel(object sender, EventArgs e, TierItem tierItem, MainPage main)
        {
            var page = new NavigationPage(new ObjectView(tierItem, main));
            page.BindingContext = tierItem;
            main.Detail = page;
        }
    }
}
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidBozin_C971_LAP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTerm : ContentPage
    {
        public NewTerm()
        {
            InitializeComponent();
        }

        async void Save(object sender, EventArgs e)
        {
            //If term is being edited, rather than new,
            //then navigation goes back two pages to avoid showing un-updated data
            //This is done in other functions and with other pages
            bool editFlag = false;
            var term = (Term)BindingContext;
            if (term.ID != 0)
                editFlag = true;

            if (!string.IsNullOrWhiteSpace(NameEntry.Text) &&
                StartDate.Date < EndDate.Date)
            {
                await App.Database.SaveTermAsync(term);
                if (editFlag)
                {
                    for (var counter = 1; counter < 2; counter++)
                    {
                        Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                    }
                }

                MainPage.CheckNotifications();
                await Navigation.PopAsync();
            }
        }

        void Cancel(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        async void Delete(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            await App.Database.DeleteTermAsync(term);
            for (var counter = 1; counter < 2; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
        }
    }
}
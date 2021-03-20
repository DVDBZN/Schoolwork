using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        async void Save(object sender, EventArgs e)
        {
            ErrorText.IsVisible = false;

            User user = BindingContext as User;


            //Handle empty forms
            if (user.Password == OldPasswordEntry.Text &&
                !string.IsNullOrEmpty(UsernameEntry.Text) &&
                !string.IsNullOrEmpty(OldPasswordEntry.Text) &&
                !string.IsNullOrEmpty(NewPasswordEntry.Text))
            {
                //If username and password match, update account
                user.Username = UsernameEntry.Text;
                user.Password = NewPasswordEntry.Text;

                await App.Database.SaveUserAsync(user);
                ErrorText.IsVisible = true;
                ErrorText.Text = "Account updated successfully!";
                await Navigation.PopAsync();
            }

            //Handle incorrect password
            else if (user.Password != OldPasswordEntry.Text)
            {
                ErrorText.IsVisible = true;
                ErrorText.Text = "Incorrect password";
            }

            else
            {
                ErrorText.IsVisible = true;
                ErrorText.Text = "Please fill in all forms";
            }
        }

        void Cancel(object sender, EventArgs e)
        {
            ErrorText.IsVisible = false;
            Navigation.PopAsync();
        }
    }
}
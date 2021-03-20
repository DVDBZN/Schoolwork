using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            CheckLoggedIn();
        }

        async void Login(object sender, EventArgs e)
        {
            ErrorText.IsVisible = false;

            //Handle empty forms
            if (string.IsNullOrWhiteSpace(UsernameEntry.Text) ||
                string.IsNullOrWhiteSpace(PasswordEntry.Text))
            {
                ErrorText.Text = "Please fill in both forms.";
                ErrorText.IsVisible = true;
                return;
            }


            //Create new account if selected
            if (NewAccountCheck.IsChecked)
            {
                var user = await App.Database.CheckUsername(UsernameEntry.Text);

                //Check if username is available
                foreach (var i in user)
                {
                    if (UsernameEntry.Text == i.Username)
                    {
                        ErrorText.Text = "User already exists.";
                        ErrorText.IsVisible = true;
                        UsernameEntry.Text = null;
                        PasswordEntry.Text = null;
                        return;
                    }
                }

                //Create new user
                var newUser = new User
                {
                    User = UsernameEntry.Text,
                    Type = "User",
                    Description = "User",
                    Username = UsernameEntry.Text,
                    Password = PasswordEntry.Text,
                    LoggedIn = true,
                    CreatedOn = DateTime.UtcNow,
                    LastChangedOn = DateTime.UtcNow
                };

                await App.Database.SaveUserAsync(newUser);

                ErrorText.Text = "Successfully created new account!";
                ErrorText.IsVisible = true;
                UsernameEntry.Text = null;
                PasswordEntry.Text = null;

                App.IsUserLoggedIn = true;

                await Navigation.PushAsync(new MainPage(newUser));
            }

            else
            {
                var user = await App.Database.GetUserAsync(UsernameEntry.Text);

                //Log in user
                foreach (var i in user)
                {
                    if (i.Username == UsernameEntry.Text
                        && i.Password == PasswordEntry.Text)
                    {
                        i.LoggedIn = true;
                        await App.Database.SaveUserAsync(i);
                        App.IsUserLoggedIn = true;

                        await Navigation.PushAsync(new MainPage(i));
                    }
                }

                ErrorText.Text = "Username and password do not match.";
                ErrorText.IsVisible = true;
                UsernameEntry.Text = null;
                PasswordEntry.Text = null;
                return;
            }
        }

        async public void CheckLoggedIn()
        {
            var users = await App.Database.GetUserAsync();

            //If previous user did not log out, automatically log in
            foreach (var i in users)
            {
                if (i.LoggedIn)
                {
                    await Navigation.PushAsync(new MainPage(i));
                }
            }
        }

        //Prevent back gesture/button from logging user back in without password
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
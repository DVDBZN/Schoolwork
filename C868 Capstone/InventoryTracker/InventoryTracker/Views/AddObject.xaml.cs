using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddObject : ContentPage
    {
        //Hold MainPage object
        public class MP
        {
            public MP(MainPage main)
            {
                Main = main;
            }
            static public MainPage Main { get; set; }
        }

        public AddObject(TierItem tierItem, MainPage main)
        {
            InitializeComponent();
            MP mainPage = new MP(main);
            BindingContext = tierItem;
        }

        protected override void OnAppearing()
        {
            string type = (BindingContext as TierItem).Type;

            //Different constructors for different types
            switch (type)
            {
                case "Profile":
                case "Building":
                case "Room":
                case "Unit":
                case "Box":
                    BindingContext = BindingContext as ChildItem;
                    PageConstructor((BindingContext as ChildItem).ParentID, type, MP.Main);
                    break;
                case "Item":
                    BindingContext = BindingContext as Item;
                    PageConstructor((BindingContext as Item).ParentID, type, MP.Main);
                    break;
                default:
                    break;
            }

        }

        void PageConstructor(int parentID, string type, MainPage main)
        {
            Entry Name = new Entry
            {
                Placeholder = "Name",
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Name.SetBinding(Entry.TextProperty, new Binding("Name"));

            Editor Description = new Editor
            {
                Placeholder = "Description...",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 300
            };
            Description.SetBinding(Editor.TextProperty, new Binding("Description"));

            Label ReminderLabel = new Label
            {
                Text = "Expiration Reminder",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20,
                IsEnabled = false
            };

            DatePicker Date = new DatePicker
            {
                Date = DateTime.Now,
                MinimumDate = new DateTime(1970, 1, 1),
                MaximumDate = new DateTime(2100, 1, 1),
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 100,
                IsEnabled = false
            };

            TimePicker Time = new TimePicker
            {
                Time = DateTime.Now.TimeOfDay,
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 100,
                IsEnabled = false
            };

            if (type == "Item")
            {
                if ((BindingContext as Item).ExpirationNotify != new DateTime(1970, 1, 1, 16, 0, 0))
                {
                    Date.Date = (BindingContext as Item).ExpirationNotify.ToLocalTime().Date;
                    Time.Time = (BindingContext as Item).ExpirationNotify.ToLocalTime().TimeOfDay;
                }
                else
                {
                    Date.Date = Date.MinimumDate;
                    Time.Time = new TimeSpan(16, 0, 0);
                }
            }

            CheckBox AddRemindCheck = new CheckBox
            {
                IsChecked = false
            };

            Label AddRemindLabel = new Label
            {
                Text = "Add Reminder",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20
            };

            StackLayout AddRemindStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    AddRemindCheck,
                    AddRemindLabel
                }
            };

            StackLayout ReminderStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                IsEnabled = false,
                Children =
                {
                    ReminderLabel,
                    Date,
                    Time
                }
            };

            //Checked/unchecked event handler
            AddRemindCheck.CheckedChanged += (sender, EventArgs) =>
            {
                //Toggle ability to modify reminder controls
                ReminderLabel.IsEnabled = !ReminderLabel.IsEnabled;
                Date.IsEnabled = !Date.IsEnabled;
                Time.IsEnabled = !Time.IsEnabled;
                ReminderStack.IsEnabled = !ReminderStack.IsEnabled;

                //Set date and time of controls depending on state of object
                
                //For new object
                if ((BindingContext as Item).ExpirationNotify.ToLocalTime() == new DateTime(1970, 1, 1, 16, 0, 0) &&
                   AddRemindCheck.IsChecked)
                {
                    //Set to now for convenience
                    Date.Date = DateTime.Now;
                    Time.Time = DateTime.Now.TimeOfDay;
                }

                else if (!AddRemindCheck.IsChecked)
                {
                    //Otherwise, set to minimum date/time for storage (used as a null value)
                    Date.Date = Date.MinimumDate;
                    Time.Time = new TimeSpan(16, 0, 0);
                }

                //For existing item that is being edited
                else if ((BindingContext as Item).ExpirationNotify.ToLocalTime() != new DateTime(1970, 1, 1, 16, 0, 0) &&
                        AddRemindCheck.IsChecked)
                {
                    //Set to item's DateTime value
                    Date.Date = (BindingContext as Item).ExpirationNotify.Date.ToLocalTime();
                    Time.Time = (BindingContext as Item).ExpirationNotify.ToLocalTime().TimeOfDay;
                }
            };

            //TAGS (Unused)
            //Construct tags and Expiration Reminder, but make them invisible
            //TODO: Create tags
            //https://stackoverflow.com/questions/41186660/xamarin-forms-stacklayout-with-rounded-corners
            //Add Frame with cornerradius, StackLayout with Tag children

            /*if (type != "Box" && type != "Item")
            {
                //Hide tags
            }*/

            if (type != "Item")
            {
                AddRemindStack.IsVisible = false;
                ReminderStack.IsVisible = false;
            }

            //If not "null" value, display stored date
            else if ((BindingContext as Item).ExpirationNotify.ToLocalTime() != new DateTime(1970, 1, 1, 16, 0, 0))
            {
                AddRemindCheck.IsChecked = true;
            }

            Button SaveButton = new Button
            {
                Text = "Save",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 28,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                WidthRequest = 200
            };
            SaveButton.Clicked += async (sender, EventArgs) => 
            {
                if (string.IsNullOrEmpty(Name.Text))
                {
                    await DisplayAlert("Name required", "Please enter a name for the object.", "OK");
                    return;
                }
                Save(sender, EventArgs, main, Date.Date, Time.Time); 
            };

            Button CancelButton = new Button
            {
                Text = "Cancel",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 28,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                WidthRequest = 200
            };
            CancelButton.Clicked += Cancel;

            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(32),
                Children =
                {
                    Name,
                    Description,
                    //Tags,
                    AddRemindStack,
                    ReminderStack,
                    SaveButton,
                    CancelButton
                }
            };
        }

        //Save object and navigate to its view
        async void Save(object sender, EventArgs e, MainPage main, DateTime date, TimeSpan time)
        {
            (BindingContext as TierItem).LastChangedOn = DateTime.UtcNow;

            if ((BindingContext as TierItem).Type == "Item")
            {
                var item = BindingContext as Item;
                item.ExpirationNotify = (date + time).ToUniversalTime();

                await App.Database.SaveItemAsync(item);
            }
            else
            {
                await App.Database.SaveObjectAsync(BindingContext as ChildItem);
            }

            var page = new NavigationPage(new ObjectView(BindingContext as TierItem, main));
            page.BindingContext = BindingContext;

            await DisplayAlert("Saved successfully!", "Item saved successfully!", "OK!");

            await Navigation.PushAsync(new MainPage(main.BindingContext as User)
            {
                Detail = page
            });
        }

        async void Cancel(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ObjectView : ContentPage
    {
        //Store MainPage for navigation
        public class MP
        {
            public MP(MainPage main)
            {
                Main = main;
            }
            static public MainPage Main { get; set; }
        }

        public ObjectView(TierItem tierItem, MainPage main)
        {
            InitializeComponent();
            MP mainPage = new MP(main);
            BindingContext = tierItem;
        }

        protected override void OnAppearing()
        {
            TierItem tierItem = BindingContext as TierItem;
            string type = tierItem.Type;

            switch (type)
            {
                case "User":
                    PageConstructor(tierItem as User, MP.Main);
                    break;
                case "Profile":
                case "Building":
                case "Room":
                case "Unit":
                case "Box":
                    PageConstructor(tierItem as ChildItem, MP.Main);
                    break;
                case "Item":
                    PageConstructor(tierItem as Item, MP.Main);
                    break;
                default:
                    break;
            }
        }

        //User contructor
        //Could have been more compact by combining with other constructors and using if statements
        async void PageConstructor(User user, MainPage main)
        {
            LocalSearch.Focused += (sender, EventArgs) => Search(sender, EventArgs, user, main);

            DataTemplate ListViewItem = new DataTemplate(() =>
            {
                Label Name = new Label
                {
                    Text = "",
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 24
                };
                Name.SetBinding(Label.TextProperty, new Binding("Name"));

                StackLayout stack = new StackLayout
                {
                    Children =
                    {
                        Name
                    }
                };

                Frame frame = new Frame
                {
                    Padding = new Thickness(32,8),
                    Margin = new Thickness(1),
                    HasShadow = true,
                    Content = stack
                };

                return new ViewCell { View = frame };
            });

            Label Title = new Label
            {
                Text = user.Username,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(32)
            };

            Button EditButton = new Button
            {
                Text = "Edit",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64,
                Margin = new Thickness(32, 4)
            };
            EditButton.Clicked += (sender, EventArgs) => { Edit(sender, EventArgs, user); };

            Button StatisticsButton = new Button
            {
                Text = "Statistics",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64
            };
            StatisticsButton.Clicked += (sender, EventArgs) => { Statistics(sender, EventArgs, user); };

            Button DeleteButton = new Button
            {
                Text = "Delete",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.FromHex("#e00000"),
                BackgroundColor = Color.White,
                BorderColor = Color.FromHex("#e00000"),
                BorderWidth = 6,
                CornerRadius = 32,
                HeightRequest = 64
            };
            DeleteButton.Clicked += (sender, EventArgs) => { Delete(sender, EventArgs, user, main); };

            StackLayout ButtonsStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(32, 4),
                Children =
                {
                    StatisticsButton,
                    DeleteButton
                }
            };

            Button AddProfile = new Button
            {
                Text = "Add Profile",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64,
                Margin = new Thickness(32,4,32,24)
            };
            AddProfile.Clicked += (sender, EventArgs) => { AddObject(sender, EventArgs, user.ID, "Profile", main); };

            ListView ProfileList = new ListView
            {
                ItemsSource = await App.Database.GetChildItems(user.ID),
                HasUnevenRows = true,
                RowHeight = -1,
                ItemTemplate = ListViewItem
            };
            ProfileList.ItemSelected += (sender, SelectedItemChangedEventArgs) => { ObjectSelected(sender, SelectedItemChangedEventArgs, main); };

            StackLayout ListStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    AddProfile,
                    ProfileList
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    Title,
                    EditButton,
                    ButtonsStack,
                    ListStack
                }
            };
        }

        //ChildItem constructor (Profile, Building, etc.)
        async void PageConstructor(ChildItem child, MainPage main)
        {
            LocalSearch.Focused += (sender, EventArgs) => Search(sender, EventArgs, child, main);
            main.GetBreadCrumbs(child as TierItem);

            DataTemplate ListViewItem = new DataTemplate(() =>
            {
                Label Name = new Label
                {
                    Text = "",
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 24
                };
                Name.SetBinding(Label.TextProperty, new Binding("Name"));

                StackLayout stack = new StackLayout
                {
                    Children =
                    {
                        Name
                    }
                };

                Frame frame = new Frame
                {
                    Padding = new Thickness(32, 8),
                    Margin = new Thickness(1),
                    HasShadow = true,
                    Content = stack
                };

                return new ViewCell { View = frame };
            });

            Label Title = new Label
            {
                Text = child.Name,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(32, 32, 32, 0)
            };

            Label Description = new Label
            {
                Text = child.Description,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 16,
                Margin = new Thickness(32, 0, 32, 32)
            };

            //TAGS
            /*if (child.Type == "Box")
            {
                //TODO: https://stackoverflow.com/questions/41186660/xamarin-forms-stacklayout-with-rounded-corners
                //Add Frame with cornerradius, StackLayout with Tag children
            }*/

            Button MoveButton = new Button
            {
                Text = "Move",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64
            };
            MoveButton.Clicked += (sender, EventArgs) => { Move(sender, EventArgs, child, main); };

            Button EditButton = new Button
            {
                Text = "Edit",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64
            };
            EditButton.Clicked += (sender, EventArgs) => { Edit(sender, EventArgs, child, main); };

            StackLayout FirstRowButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(32, 4),
                Children =
                {
                    MoveButton,
                    EditButton
                }
            };

            Button StatisticsButton = new Button
            {
                Text = "Statistics",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64
            };
            StatisticsButton.Clicked += (sender, EventArgs) => { Statistics(sender, EventArgs, child); };

            Button DeleteButton = new Button
            {
                Text = "Delete",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.FromHex("#e00000"),
                BackgroundColor = Color.White,
                BorderColor = Color.FromHex("#e00000"),
                BorderWidth = 6,
                CornerRadius = 32,
                HeightRequest = 64
            };
            DeleteButton.Clicked += (sender, EventArgs) => { Delete(sender, EventArgs, child, main); };

            StackLayout SecondRowButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(32, 4),
                Children =
                {
                    StatisticsButton,
                    DeleteButton
                }
            };

            StackLayout ButtonsStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    FirstRowButtons,
                    SecondRowButtons
                }
            };

            string ButtonText = "";

            //Set button text depending on type
            switch (child.Type)
            {
                case "Profile":
                    MoveButton.IsVisible = false;
                    ButtonText = "Building";
                    break;
                case "Building":
                    ButtonText = "Room";
                    break;
                case "Room":
                    ButtonText = "Unit";
                    break;
                case "Unit":
                    ButtonText = "Box";
                    break;
                case "Box":
                    ButtonText = "Box";
                    break;
                default:
                    break;
            }

            Button AddChild = new Button
            {
                Text = "Add " + ButtonText,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64,
                Margin = new Thickness(32, 4, 32, 24)
            };
            AddChild.Clicked += (sender, EventArgs) => { AddObject(sender, EventArgs, child.ID, ButtonText, main); };

            ListView ChildList = new ListView
            {
                ItemsSource = await App.Database.GetChildItems(child.ID),
                HasUnevenRows = true,
                RowHeight = -1,
                ItemTemplate = ListViewItem
            };
            ChildList.ItemSelected += (sender, SelectedItemChangedEventArgs) => { ObjectSelected(sender, SelectedItemChangedEventArgs, main); };

            //Boxes can contain Boxes and Items
            //Making another button and ListView for Item
            if (child.Type == "Box")
            {
                Button AddChildTwo = new Button
                {
                    Text = "Add Item",
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 24,
                    TextColor = Color.Black,
                    BackgroundColor = Color.White,
                    BorderColor = Color.Black,
                    BorderWidth = 4,
                    CornerRadius = 32,
                    HeightRequest = 64,
                    Margin = new Thickness(32, 4, 32, 24)
                };
                AddChildTwo.Clicked += (sender, EventArgs) => { AddObject(sender, EventArgs, child.ID, "Item", main); };

                ListView ChildListTwo = new ListView
                {
                    ItemsSource = await App.Database.GetItemChildren(child.ID),
                    HasUnevenRows = true,
                    RowHeight = -1,
                    ItemTemplate = ListViewItem
                };
                ChildListTwo.ItemSelected += (sender, SelectedItemChangedEventArgs) => { ObjectSelected(sender, SelectedItemChangedEventArgs, main); };

                StackLayout ListStack = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        AddChild,
                        ChildList,
                        AddChildTwo,
                        ChildListTwo
                    }
                };

                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        Title,
                        Description,
                        ButtonsStack,
                        ListStack
                    }
                };
            }

            else
            {
                StackLayout ListStack = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        AddChild,
                        ChildList
                    }
                };

                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        Title,
                        Description,
                        ButtonsStack,
                        ListStack
                    }
                };
            }
        }

        //Item constructor
        void PageConstructor(Item item, MainPage main)
        {
            LocalSearch.IsVisible = false;
            main.GetBreadCrumbs(item as TierItem);

            Label Name = new Label
            {
                Text = item.Name,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(32, 32, 32, 0)
            };

            Label Description = new Label
            {
                Text = item.Description,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 16,
                Margin = new Thickness(32, 0, 32, 32)
            };

            //TAGS
            //TODO: https://stackoverflow.com/questions/41186660/xamarin-forms-stacklayout-with-rounded-corners
            //Add Frame with cornerradius, StackLayout with Tag children

            Button MoveButton = new Button
            {
                Text = "Move",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64
            };
            MoveButton.Clicked += (sender, EventArgs) => { Move(sender, EventArgs, item, main); };

            Button EditButton = new Button
            {
                Text = "Edit",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64
            };
            EditButton.Clicked += (sender, EventArgs) => { Edit(sender, EventArgs, item, main); };

            StackLayout FirstRowButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(32, 4),
                Children =
                {
                    MoveButton,
                    EditButton
                }
            };

            Button StatisticsButton = new Button
            {
                Text = "Statistics",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                BorderColor = Color.Black,
                BorderWidth = 4,
                CornerRadius = 32,
                HeightRequest = 64
            };
            StatisticsButton.Clicked += (sender, EventArgs) => { Statistics(sender, EventArgs, item); };

            Button DeleteButton = new Button
            {
                Text = "Delete",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 24,
                TextColor = Color.FromHex("#e00000"),
                BackgroundColor = Color.White,
                BorderColor = Color.FromHex("#e00000"),
                BorderWidth = 6,
                CornerRadius = 32,
                HeightRequest = 64
            };
            DeleteButton.Clicked += (sender, EventArgs) => { Delete(sender, EventArgs, item, main); };

            StackLayout SecondRowButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(32, 4),
                Children =
                {
                    StatisticsButton,
                    DeleteButton
                }
            };

            StackLayout ButtonsStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    FirstRowButtons,
                    SecondRowButtons
                }
            };

            Label DateLabel = new Label
            {
                Text = "Expiration Reminder",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20
            };

            DatePicker Date = new DatePicker
            {
                Date = item.ExpirationNotify.ToLocalTime(),
                MinimumDate = new DateTime(1970, 1, 1),
                MaximumDate = new DateTime(2100, 1, 1),
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 100,
                IsEnabled = false
            };

            TimePicker Time = new TimePicker
            {
                Time = item.ExpirationNotify.ToLocalTime().TimeOfDay,
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 100,
                IsEnabled = false
            };

            StackLayout ReminderStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                IsVisible = false,
                Margin = new Thickness(0,8),
                Children =
                {
                    DateLabel,
                    Date,
                    Time
                }
            };

            if (item.ExpirationNotify.ToLocalTime() != new DateTime(1970, 1, 1, 16, 0, 0))
            {
                ReminderStack.IsVisible = true;
            }

            Label InUseLabel = new Label
            {
                Text = "In Use",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 20
            };

            Switch InUseSwitch = new Switch
            {
                IsToggled = item.InUse,
                HorizontalOptions = LayoutOptions.End,
                WidthRequest = 150
            };

            StackLayout InUseStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    InUseLabel,
                    InUseSwitch
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    Name,
                    Description,
                    ButtonsStack,
                    ReminderStack
                    //Currently not in use (pun intended)
                    //InUseStack
                }
            };
        }

        //Navigate to search with current item
        void Search(object sender, EventArgs e, TierItem tierItem, MainPage main)
        {
            var page = new NavigationPage(new SearchOptions(tierItem, main));
            page.BindingContext = BindingContext;
            main.Detail = page;
        }

        //Navigate to move with current item
        async void Move(object sender, EventArgs e, ChildItem child, MainPage main)
        {
            await Navigation.PushAsync(new MoveObject(child, main)
            { 
                BindingContext = child
            });
        }

        //Navigate to edit with current item
        async void Edit(object sender, EventArgs e, ChildItem child, MainPage main)
        {
            await Navigation.PushAsync(new AddObject(child, main)
            {
                BindingContext = child
            });
        }

        //Navigate to settings (edit for user)
        async void Edit(object sender, EventArgs e, User user)
        {
            await Navigation.PushAsync(new Settings
            {
                BindingContext = user
            });
        }

        //Navigate to statistics with item
        async void Statistics(object sender, EventArgs e, TierItem tierItem)
        {
            await Navigation.PushAsync(new StatisticsView
            {
                BindingContext = tierItem
            });
        }

        async void Delete(object sender, EventArgs e, TierItem item, MainPage main)
        {
            //To display number of child objects that will also get deleted
            List<int> counts = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
            List<int> searchIDs = new List<int> { (BindingContext as TierItem).ID };
            string type = item.Type;
            counts = await App.Database.GetCounts(searchIDs, counts);
            //Confirm or deny choice to delete
            bool answer = await DisplayAlert("DELETE Object", "Are you sure you would like to permanently delete this object? (This will also delete " + counts[0] + " child objects.)", "Yes", "No");

            if (answer)
            {
                TierItem parent = main.BindingContext as TierItem;

                //Get parent of object for navigation
                if (type != "User" && type != "Profile")
                {
                    var list = await App.Database.GetParent((item as ChildItem).ParentID);
                    parent = list[0];
                }

                main.GetBreadCrumbs(parent as TierItem);
                //DELETE!
                await App.Database.DeleteObject(item);

                //If user is deleted, log out
                if (type == "User")
                    await Navigation.PushAsync(new LoginPage());
                else
                {
                    //Navigate to parent of selected (deleted) object
                    var page = new NavigationPage(new ObjectView(parent as TierItem, main));
                    page.BindingContext = BindingContext;
                    main.Detail = page;
                }
            }
        }

        async void AddObject(object sender, EventArgs e, int parentID, string type, MainPage main)
        {
            if (type == "Item")
            {
                //Create new item with default values
                var item = new Item
                {
                    User = (main.BindingContext as User).Username,
                    ParentID = parentID,
                    Type = type,
                    Name = "",
                    Description = "",
                    InUse = false,
                    CreatedOn = DateTime.UtcNow,
                    LastChangedOn = DateTime.UtcNow,
                    ExpirationNotify = new DateTime(1970, 1, 1, 16, 0, 0).ToUniversalTime().ToLocalTime()
                };

                await Navigation.PushAsync(new AddObject(item, main)
                {
                    BindingContext = item as TierItem
                });
            }

            //Creat new childItem with default values
            else
            {
                var childItem = new ChildItem
                {
                    User = (main.BindingContext as User).Username,
                    ParentID = parentID,
                    Type = type,
                    Name = "",
                    Description = "",
                    CreatedOn = DateTime.UtcNow,
                    LastChangedOn = DateTime.UtcNow
                };

                await Navigation.PushAsync(new AddObject(childItem, main)
                {
                    BindingContext = childItem as TierItem
                });
            }
        }

        //Navigate to new ObjectView with selected object
        void ObjectSelected(object sender, SelectedItemChangedEventArgs e, MainPage main)
        {
            var page = new NavigationPage(new ObjectView(e.SelectedItem as TierItem, main));
            page.BindingContext = BindingContext;
            main.Detail = page;
        }
    }
}
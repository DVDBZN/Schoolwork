using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsView : ContentPage
    {
        public StatisticsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            PageConstructor();
        }

        async public void PageConstructor()
        {
            //From BindingContext display Created and LastChanged DateTimes
            //From query display total child items and child items of each type
            //  Keep variables of total count, type counts, and list of IDs to check
            //  Will need to be recursive to account for boxes

            Label Name = new Label
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 36
            };

            if ((BindingContext as TierItem).Type == "User")
            {
                Name.Text = "Name: " + (BindingContext as User).Username;
            }

            else
            {
                Name.Text = "Name: " + (BindingContext as ChildItem).Name;
            }

            Label Type = new Label
            {
                Text = "Type: " + (BindingContext as TierItem).Type,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 32
            };

            Label ID = new Label
            {
                Text = "ID: " + (BindingContext as TierItem).ID,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 28
            };

            Label DateCreatedLabel = new Label
            {
                Text = "Date Created: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 28
            };

            Label DateCreated = new Label
            {
                Text = (BindingContext as TierItem).CreatedOn.ToLocalTime().ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout DateCreatedStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(32, 4),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    DateCreatedLabel,
                    DateCreated
                }
            };

            Label LastChangeLabel = new Label
            {
                Text = "Date Last Changed: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = 28
            };

            Label LastChangeDate = new Label
            {
                Text = (BindingContext as TierItem).LastChangedOn.ToLocalTime().ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout LastChangedStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(32, 4),
                Children =
                {
                    LastChangeLabel,
                    LastChangeDate
                }
            };

            //Format: GetCounts(IDList, countsList)
            //IDList is which IDs to search for as ParentIDs
            //countsList tracks totals of counted items and will be returned to here
            //List format: Total#, Profiles#, Buildings#, Rooms#, Units#, Boxes#, Items#

            List<int> counts = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
            List<int> searchIDs = new List<int> { (BindingContext as TierItem).ID };

            if ((BindingContext as TierItem).Type != "Item")
                counts = await App.Database.GetCounts(searchIDs, counts);

            Label TotalCountLabel = new Label
            {
                Text = "Total Children: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 28
            };

            Label TotalCount = new Label
            {
                Text = counts[0].ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout TotalStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    TotalCountLabel,
                    TotalCount
                }
            };

            Label ProfileCountLabel = new Label
            {
                Text = "Child Profiles: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 28
            };

            Label ProfileCount = new Label
            {
                Text = counts[1].ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout ProfileStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    ProfileCountLabel,
                    ProfileCount
                }
            };

            Label BuildingCountLabel = new Label
            {
                Text = "Child Buildings: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 28
            };

            Label BuildingCount = new Label
            {
                Text = counts[2].ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout BuildingStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    BuildingCountLabel,
                    BuildingCount
                }
            };

            Label RoomCountLabel = new Label
            {
                Text = "Child Rooms: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 28
            };

            Label RoomCount = new Label
            {
                Text = counts[3].ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout RoomStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    RoomCountLabel,
                    RoomCount
                }
            };

            Label UnitCountLabel = new Label
            {
                Text = "Child Units: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 28
            };

            Label UnitCount = new Label
            {
                Text = counts[4].ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout UnitStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    UnitCountLabel,
                    UnitCount
                }
            };

            Label BoxCountLabel = new Label
            {
                Text = "Child Boxes: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 28
            };

            Label BoxCount = new Label
            {
                Text = counts[5].ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout BoxStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    BoxCountLabel,
                    BoxCount
                }
            };

            Label ItemCountLabel = new Label
            {
                Text = "Child Items: ",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                FontSize = 28
            };

            Label ItemCount = new Label
            {
                Text = counts[6].ToString(),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                FontSize = 28
            };

            StackLayout ItemStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    ItemCountLabel,
                    ItemCount
                }
            };

            StackLayout ChildrenStack = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            //Don't add children counters if Item
            if ((BindingContext as TierItem).Type != "Item")
            {
                ChildrenStack.Children.Add(TotalStack);
                ChildrenStack.Children.Add(ProfileStack);
                ChildrenStack.Children.Add(BuildingStack);
                ChildrenStack.Children.Add(RoomStack);
                ChildrenStack.Children.Add(UnitStack);
                ChildrenStack.Children.Add(BoxStack);
                ChildrenStack.Children.Add(ItemStack);
            }

            Frame Frame = new Frame
            {
                CornerRadius = 32,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 300,
                Content = ChildrenStack
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    Name,
                    Type,
                    ID,
                    DateCreatedStack,
                    LastChangedStack,
                    Frame
                }
            };
        }
    }
}
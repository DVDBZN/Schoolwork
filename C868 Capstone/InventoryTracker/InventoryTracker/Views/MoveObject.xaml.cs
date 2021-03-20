using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoveObject : ContentPage
    {
        public class MP
        {
            public MP(MainPage main)
            {
                Main = main;
            }
            static public MainPage Main { get; set; }
        }

        public MoveObject(ChildItem child, MainPage main)
        {
            InitializeComponent();
            MP mainPage = new MP(main);
            BindingContext = child;
        }

        async protected override void OnAppearing()
        {
            UserList.ItemsSource = await App.Database.GetChildItems((MP.Main.BindingContext as User).ID);
        }

        //Change moved object's ParentID to selected object's ID
        async void Select(object sender, EventArgs e)
        {
            List<string> tiers = new List<string> { "User", "Profile", "Building", "Room", "Unit", "Box", "Item" };
            //The BindingContext of the StackLayout parent of the clicked Button
            TierItem newParent = ((StackLayout)((Button)sender).Parent).BindingContext as TierItem;

            int index = tiers.IndexOf((BindingContext as TierItem).Type);

            //Confirming that object is adopted into correct tier
            if (newParent.Type != tiers[index - 1])
            {
                await DisplayAlert("Incorrect tier", "Please select an object of the type '" + tiers[index - 1] + "'.", "OK");
                return;
            }

            //Should never reach this
            else if (newParent == BindingContext)
            {
                await DisplayAlert("Cannot adopt self", "Object cannot be its own parent/child.", "No u");
                return;
            }

            int newParentID = Convert.ToInt32(newParent.ID);
            (this.BindingContext as ChildItem).ParentID = newParentID;
            
            //Save to database
            if ((BindingContext as TierItem).Type != "Item")
                await App.Database.SaveObjectAsync(BindingContext as ChildItem);
            else
                await App.Database.SaveItemAsync(BindingContext as Item);

            var page = new NavigationPage(new ObjectView(BindingContext as TierItem, MP.Main));
            page.BindingContext = BindingContext;
            await Navigation.PushAsync(new MainPage(MP.Main.BindingContext as User)
            {
                Detail = page
            });
        }

        //Find and add child items of selected object, if exist
        async void Expand(object sender, SelectedItemChangedEventArgs e)
        {
            //This could have been done much simpler
            //For example, a list objects with ChildItem variables
            //  Only activate (and indent) those that are direct children of the selected ViewCell

            //Template for ViewCell structure and appearance
            DataTemplate listItemTemplate = new DataTemplate(() =>
            {
                Label Name = new Label
                {
                    Text = "",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    FontSize = 20,
                    LineBreakMode = LineBreakMode.MiddleTruncation
                };
                Name.SetBinding(Label.TextProperty, new Binding("Name"));

                Label ID = new Label
                {
                    Text = "",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    FontSize = 16,
                    TextColor = Color.LightGray,
                    LineBreakMode = LineBreakMode.NoWrap
                };
                ID.SetBinding(Label.TextProperty, new Binding("Type")
                {
                    StringFormat = "({0})"
                });

                Button SelectButton = new Button
                {
                    Text = "Select",
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };
                SelectButton.Clicked += Select;


                StackLayout stack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        Name,
                        ID,
                        SelectButton
                    }
                };

                Frame frame = new Frame
                {
                    Padding = new Thickness(1),
                    Margin = new Thickness(0.5, 0.5),
                    Content = stack
                };

                return new ViewCell { View = frame };
            });

            ListView listView = new ListView
            {
                HasUnevenRows = true,
                RowHeight = 40,
                ItemTemplate = listItemTemplate
            };
            listView.ItemsSource = await App.Database.GetChildItems((e.SelectedItem as TierItem).ID);

            int count = (listView.ItemsSource as List<ChildItem>).Count;

            //If object has no children, do nothing
            if (count == 0)
                return;
            listView.ItemSelected += Expand;

            //Very complex and convoluted way of doing this. Comments galore ahead
            //Gets control/view objects associated with selected item list
            IEnumerable<PropertyInfo> pInfos = (sender as ItemsView<Cell>).GetType().GetRuntimeProperties();
            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
            if (templatedItems != null)
            {
                //Gets (view)cells of item list
                var cells = templatedItems.GetValue(sender as ListView);
                foreach(ViewCell cell in cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>)
                {
                    //Find selected cell
                    if (cell.BindingContext as TierItem == e.SelectedItem as TierItem)
                    {
                        //Get StackLayout child of selected cell
                        StackLayout targetStack = (cell.View as Frame).Children.OfType<StackLayout>().FirstOrDefault();

                        if (targetStack != null)
                        {
                            //Creat new Frame to hold child ListView
                            Frame newFrame = new Frame
                            {
                                Padding = new Thickness(1),
                                Margin = new Thickness(0.5, 0.5),
                                Content = new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Start,
                                    Orientation = StackOrientation.Vertical,
                                    Children =
                                    {
                                        //Place previously found StackLayout into new Frame, along with new child ListView
                                        targetStack,
                                        listView
                                    }
                                }
                            };

                            (cell.View as Frame).Content = newFrame;
                            //Expand parent ViewCell to fit new ListViews
                            Grow(count, cell);
                        }
                    }
                }
            }
        }

        void Grow(int amount, ViewCell cell)
        {
            List<ViewCell> parents = new List<ViewCell>() { cell };

            //Start with highest ViewCell and add to its height, then work down
            //Create List<ViewCell> then add same amount to each
            while(cell.GetType().Equals(typeof(ViewCell)))
            {
                if (cell.GetType().Equals(typeof(ViewCell)))
                {
                    //Finds parent ViewCell of selected ViewCell and adds to list
                    cell = cell.Parent.Parent.Parent.Parent.Parent as ViewCell;
                    
                    if (cell == null || !cell.GetType().Equals(typeof(ViewCell)))
                    {
                        break;
                    }

                    parents.Add(cell);
                }

                else
                    break;
            }
            //TODO: Works, but causes extra gaps in some places
            //Try removing padding and margin of parent objects

            //Once parent hierarchy is found, expand each ViewCell to fit new ListViews/ViewCells
            for(int i = parents.Count; i > 0; i--)
            {
                if (parents[i - 1].Height < 0)
                    parents[i - 1].Height = 40;
                parents[i - 1].Height += amount * 80;
            }
        }
    }
}
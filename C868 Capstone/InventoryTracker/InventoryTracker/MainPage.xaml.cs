using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using InventoryTracker.Views;

namespace InventoryTracker
{
    //MasterPageItem object that stores menu buttons
    public class MasterPageItem
    {
        public MasterPageItem()
        {
            TargetType = typeof(MasterPageItem);
        }
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
    }

    //BreadCrumbItem object that stores variables associated with breadcrumb trail
    public class BreadCrumbItem
    {
        //Get item and assign variables
        public BreadCrumbItem(TierItem tierItem, int pad)
        {
            Item = tierItem;
            Type = tierItem.Type;
            if (Type == "User")
                Name = (tierItem as User).Username;
            else
                Name = (tierItem as ChildItem).Name;
            Pad = new Thickness(pad, 6, 0, 6);
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public TierItem Item { get; set; }
        public Thickness Pad { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(User user)
        {
            InitializeComponent();

            //Set initial values
            BindingContext = user;
            MenuList.ItemsSource = GetMenuList();
            MenuList.ItemSelected += OnMenuItemSelected;
            //Event handler for GlobalSearch
            GlobalSearch.SearchButtonPressed += (sender, EventArgs) => Search(sender, EventArgs, this);

            GetBreadCrumbs(user);

            //Navigate to currently logged in user view
            var page = new NavigationPage(new ObjectView(user as TierItem, this));
            page.BindingContext = user;
            Detail = page;
            IsPresented = false;
        }

        public List<MasterPageItem> GetMenuList()
        {
            //Create a couple buttons for the menu
            var list = new List<MasterPageItem>
            {
                new MasterPageItem()
                {
                    Title = "Statistics",
                    IconSource = "",
                    TargetType = typeof(StatisticsView)
                },
                new MasterPageItem()
                {
                    Title = "Settings",
                    IconSource = "",
                    TargetType = typeof(Settings)
                }
            };
            return list;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //When button is selected, navigate to that type of page with user as BindingContext
            var selectedMenuItem = e.SelectedItem as MasterPageItem;
            if (selectedMenuItem != null)
            {
                var page = new NavigationPage((Page)Activator.CreateInstance(selectedMenuItem.TargetType));
                page.BindingContext = BindingContext;
                Detail = page;
                MenuList.SelectedItem = null;
                IsPresented = false;
            }
        }

        async public void GetBreadCrumbs(TierItem tierItem)
        {
            //Create new breadcrumb trail from scratch with each view change
            var list = new List<BreadCrumbItem>() { new BreadCrumbItem(tierItem, 0) };

            //Loop to work our way up the family tree
            while (tierItem.Type != "User")
            {
                //Since Users (parents of Profiles) are in separate table, they need to be searched with a different query/method
                if (tierItem.Type == "Profile")
                {
                    var userParent = await App.Database.GetUserAsync((tierItem as ChildItem).User);
                    //Pad crumbs
                    foreach (BreadCrumbItem crumb in list)
                    {
                        //Once padding gets too wide, leave it at a standard width
                        if (crumb.Pad.Left >= 120)
                        {
                            crumb.Pad = new Thickness(120, 6, 0, 6);
                        }
                        crumb.Pad = new Thickness(crumb.Pad.Left + 24, 6, 0, 6);
                    }
                    //Add User parent to list and return list
                    list.Insert(0, new BreadCrumbItem(userParent[0] as TierItem, 0));
                    BreadCrumbs.ItemsSource = list;
                    return;
                }

                var parent = await App.Database.GetParent((tierItem as ChildItem).ParentID);
                foreach(TierItem i in parent)
                {
                    //Pad previous BreadCrumbs then add to list
                    foreach (BreadCrumbItem crumb in list)
                        crumb.Pad = new Thickness(crumb.Pad.Left + 24, 6, 0, 6);
                    list.Insert(0, new BreadCrumbItem(i, 0));
                    //Prepared to get next parent
                    tierItem = i;
                }
            }
            BreadCrumbs.ItemsSource = list;
        }

        private void BreadcrumbSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = BreadCrumbs.ItemsSource as List<BreadCrumbItem>;

            //If only one breadcrumb exists (User), stay on page
            if (list.Count >= 1)
            {
                if (e.SelectedItem != null)
                {
                    //Reset breadcrumb trail to selected object
                    GetBreadCrumbs((e.SelectedItem as BreadCrumbItem).Item);

                    //Navigate to new page of selected object
                    var page = new NavigationPage(new ObjectView((e.SelectedItem as BreadCrumbItem).Item as TierItem, this));
                    page.BindingContext = (e.SelectedItem as BreadCrumbItem).Item as TierItem;
                    Detail = page;
                    ((ListView)sender).SelectedItem = null;
                    IsPresented = false;
                }
            }
            return;
        }

        async void Logout(object sender, EventArgs e)
        {
            var users = await App.Database.GetUserAsync();
            //Logout all logged in users and navigate to LoginPage
            foreach (var i in users)
            {
                if (i.LoggedIn)
                {
                    i.LoggedIn = false;
                    await App.Database.SaveUserAsync(i);
                }
            }

            App.IsUserLoggedIn = false;
            await Navigation.PushAsync(new LoginPage());
        }

        async void Search(object sender, EventArgs e, MainPage main)
        {
            //Handle empty input
            if (string.IsNullOrEmpty(GlobalSearch.Text))
            {
                await DisplayAlert("Enter search term", "Please enter a keyword or phrase to search.)", "OK");
                return;
            }
            
            //Craft query and prepare list for accepting results
            string searchTerm = GlobalSearch.Text;
            string query = ($"SELECT * FROM ChildItem WHERE User = '{(BindingContext as User).Username}' AND (Name LIKE '%{searchTerm}%' OR Description LIKE '%{searchTerm}%' OR CreatedOn LIKE '%{searchTerm}%' OR LastChangedOn LIKE '%{searchTerm}%') ORDER BY Type COLLATE NOCASE ASC");
            var results = new List<ChildItem> { };

            try
            {
                //Get results of query
                results = await App.Database.GlobalSearch(query);
                //Didn't use this because it may cause problems if user has an object named "ChildItem":
                //query = query.Replace("ChildItem", "Item");
                query = ($"SELECT * FROM Item WHERE User = '{(BindingContext as User).Username}' AND (Name LIKE '%{searchTerm}%' OR Description LIKE '%{searchTerm}%' OR CreatedOn LIKE '%{searchTerm}%' OR LastChangedOn LIKE '%{searchTerm}%') ORDER BY Type ASC");

                //Also query other table(s)
                results.AddRange(await App.Database.GlobalItemSearch(query));
                //Sort option is useless since results are sorted here again
                //TODO: (Eventually) make switch to determine how to sort
                results.OrderBy(o => o.Name).ToList();
                results.OrderBy(o => o.Type).ToList();
            }
            catch
            {
                //Do nothing
                //For searches that fail for one reason or another
            }

            await Navigation.PushAsync(new SearchResults(results, this));
        }

        //Set back button/gesture to do nothing
        //Cruel, but easier to manage the application manually
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
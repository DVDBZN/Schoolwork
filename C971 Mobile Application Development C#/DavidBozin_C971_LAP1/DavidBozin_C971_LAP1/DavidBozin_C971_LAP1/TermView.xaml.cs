using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidBozin_C971_LAP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermView : ContentPage
    {
        public TermView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await App.Database.GetCoursesAsync(Convert.ToInt32(IDTag.Text));
            CoursesList.ItemsSource = list;

            //Limit number of courses to 6
            if (list.Count >= 6)
                AddButton.IsEnabled = false;
            else
                AddButton.IsEnabled = true;
        }

        async void AddCourse(object sender, EventArgs args)
        {
            var course = new Course
            {
                TermID = Convert.ToInt32(IDTag.Text),
                Start = DateTime.Now,
                End = DateTime.Now
            };

            await Navigation.PushAsync(new NewCourse
            {
                BindingContext = course
            });
        }
        async void ViewCourse(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CourseView
                {
                    BindingContext = e.SelectedItem as Course
                });
            }
        }

        async void EditTerm(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            await Navigation.PushAsync(new NewTerm
            {
                BindingContext = term
            });
        }
    }
}
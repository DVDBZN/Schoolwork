using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidBozin_C971_LAP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseView : ContentPage
    {
        public CourseView()
        {
            InitializeComponent();
        }

        async void CourseDetails(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailedCourseView
            {
                BindingContext = BindingContext as Course
            });
        }

        async void Delete(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await App.Database.DeleteCourseAsync(course);
            await Navigation.PopAsync();
        }
    }
}
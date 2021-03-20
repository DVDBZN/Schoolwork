using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidBozin_C971_LAP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCourse : ContentPage
    {
        public NewCourse()
        {
            InitializeComponent();
        }

        async void SaveCourse(object sender, EventArgs e)
        {
            bool editFlag = false;
            var course = (Course)BindingContext;
            if (course.ID != 0)
                editFlag = true;

            //Prevent saving with empty or invalid input
            if (!string.IsNullOrWhiteSpace(NameEntry.Text) &&
                !string.IsNullOrWhiteSpace(InstructorEntry.Text) &&
                !string.IsNullOrWhiteSpace(PhoneEntry.Text) &&
                !string.IsNullOrWhiteSpace(EmailEntry.Text) &&
                !(StatusPicker.SelectedIndex == -1) &&
                StartDate.Date <= EndDate.Date)
            {
                await App.Database.SaveCourseAsync(course);
                if (editFlag)
                {
                    for (var counter = 1; counter < 3; counter++)
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
            var course = (Course)BindingContext;
            await App.Database.DeleteCourseAsync(course);
            for (var counter = 1; counter < 3; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
        }
    }
}
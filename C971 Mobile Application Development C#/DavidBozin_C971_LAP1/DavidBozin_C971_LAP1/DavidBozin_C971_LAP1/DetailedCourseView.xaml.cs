using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace DavidBozin_C971_LAP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailedCourseView : ContentPage
    {
        public DetailedCourseView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await App.Database.GetAssessmentsAsync(Convert.ToInt32(IDTag.Text));
            TermsList.ItemsSource = list;

            LimitAssessments(list);
        }

        async void AddAssessmentClicked(object sender, EventArgs args)
        {
            var assessment = new Assessment
            {
                CourseID = Convert.ToInt32(IDTag.Text),
                Start = DateTime.Now,
                End = DateTime.Now
            };

            await Navigation.PushAsync(new NewAssessment
            {
                BindingContext = assessment
            });
        }
        async void ViewAssessmentClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NewAssessment
                {
                    BindingContext = e.SelectedItem as Assessment
                });
            }
        }

        async void Save(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await App.Database.SaveCourseAsync(course);
            await Navigation.PopAsync();
        }

        async void EditCourse(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await Navigation.PushAsync(new NewCourse
            {
                BindingContext = course
            });
        }

        async void ShareClicked(object sender, EventArgs e)
        {
            await ShareNote(Notes.Text);
        }

        public async Task ShareNote(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Note"
            });
        }

        void LimitAssessments(List<Assessment> list)
        {
            //If one type of assessment exists, prevent user from craeting same type

            bool hasObjective = false;
            bool hasPerformance = false;

            foreach (Assessment assessment in list)
            {
                if (assessment.Type == "Objective")
                    hasObjective = true;
                if (assessment.Type == "Performance")
                    hasPerformance = true;
            }

            if (hasObjective && hasPerformance)
                AddButton.IsEnabled = false;
            else
                AddButton.IsEnabled = true;
        }
    }
}
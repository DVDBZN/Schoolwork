using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DavidBozin_C971_LAP1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewAssessment : ContentPage
    {
        public NewAssessment()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var assessment = (Assessment)BindingContext;
            var list = await App.Database.GetAssessmentsAsync(assessment.CourseID);
            //Set date and time individually from one database variable
            StartTime.Time = assessment.Start.TimeOfDay;
            EndTime.Time = assessment.End.TimeOfDay;

            //If assessment is new, set default time to now
            if (!string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                StartTime.Time = assessment.Start.TimeOfDay;
                EndTime.Time = assessment.End.TimeOfDay;
            }

            //If two assessments exist, return to previous page
            //This should never run, but is just a backup
            if (list.Count == 2 && string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                await Navigation.PopAsync();
            }

            //If one assessment exists, sets typepicker to other type
            else if (list.Count == 1 && string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                if (list[0].Type == "Objective")
                {
                    TypePicker.SelectedItem = "Performance";
                }
                else
                {
                    TypePicker.SelectedItem = "Objective";
                }

                TypePicker.IsEnabled = false;
            }

            else
                TypePicker.IsEnabled = true;
        }

        async void SaveAssessment(object sender, EventArgs e)
        {
            //Adds together datepicker and timepicker values
            DateTime start = new DateTime(StartDate.Date.Add(StartTime.Time).Ticks);
            DateTime end = new DateTime(EndDate.Date.Add(EndTime.Time).Ticks);

            //Validation before saving assessment
            if (!string.IsNullOrWhiteSpace(NameEntry.Text) &&
                !(TypePicker.SelectedIndex == -1) &&
                start < end)
            {
                var assessment = (Assessment)BindingContext;
                assessment.Start = start;
                assessment.End = end;

                await App.Database.SaveAssessmentAsync(assessment);

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
            var assessment = (Assessment)BindingContext;
            await App.Database.DeleteAssessmentAsync(assessment);
            await Navigation.PopAsync();
        }
    }
}
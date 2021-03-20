using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace DavidBozin_C971_LAP1
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static INotificationManager notificationManager = DependencyService.Get<INotificationManager>();

        public MainPage()
        {
            InitializeComponent();

            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
            };

            CheckNotifications();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //Associate all terms with listview
            TermsList.ItemsSource = await App.Database.GetTermsAsync();
        }

        public static async void CheckNotifications()
        {
            //Find all notifications and trigger those scheduled with 24 hours of now
            var termNotify = await App.Database.TermNotifications();
            var courseNotify = await App.Database.CourseNotifications();
            var assessmentNotify = await App.Database.AssessmentNotifications();

            foreach (Term i in termNotify)
            {
                if (i.Start < DateTime.Now.AddHours(24) && i.Start >= DateTime.Now)
                    notificationManager.ScheduleNotification("Term beginning tomorrow", i.Name + " starts " + i.Start.ToString());

                else if (i.End < DateTime.Now.AddHours(24) && i.End >= DateTime.Now)
                    notificationManager.ScheduleNotification("Term ends tomorrow", i.Name + " ends " + i.End.ToString());
            }

            foreach (Course i in courseNotify)
            {
                if (i.Start < DateTime.Now.AddHours(24) && i.Start >= DateTime.Now)
                    notificationManager.ScheduleNotification("Course beginning tomorrow", i.Name + " starts " + i.Start.ToString());

                else if (i.End < DateTime.Now.AddHours(24) && i.End >= DateTime.Now)
                    notificationManager.ScheduleNotification("Course ends tomorrow", i.Name + " ends " + i.End.ToString());
            }

            foreach (Assessment i in assessmentNotify)
            {
                if (i.Start < DateTime.Now.AddHours(24) && i.Start >= DateTime.Now)
                    notificationManager.ScheduleNotification("Assessment beginning tomorrow", i.Name + " starts " + i.Start.ToString());

                else if (i.End < DateTime.Now.AddHours(24) && i.End >= DateTime.Now)
                    notificationManager.ScheduleNotification("Assessment ends tomorrow", i.Name + " ends " + i.End.ToString());
            }
        }

        async void AddTerm(object sender, EventArgs e)
        {
            var term = new Term
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };

            await Navigation.PushAsync(new NewTerm
            {
                BindingContext = term
            });
        }

        async void ViewTerm(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TermView
                {
                    BindingContext = e.SelectedItem as Term
                });
            }
        }

        async void GenerateData(object sender, EventArgs e)
        {
            //Button click function that generates required testing data

            var term = new Term
            {
                Name = "First Term",
                Start = new DateTime(2020, 8, 1, 0, 0, 0),
                End = new DateTime(2021, 1, 31, 23, 59, 59),
                Notify = true
            };

            await App.Database.SaveTermAsync(term);

            var course = new Course
            {
                TermID = term.ID,
                Name = "C101-Orientation",
                Start = new DateTime(2020, 8, DateTime.Now.Day, 0, 0, 0),
                End = new DateTime(2020, 8, DateTime.Now.Day + 1, 0, 0, 0),
                Notify = true,
                Status = "In progress",
                Notes = "Orientation for new students.",
                InstructorName = "David Bozin",
                InstructorEmail = "dbozin9@wgu.edu",
                InstructorPhone = "699-1555"
            };

            await App.Database.SaveCourseAsync(course);

            var assessment = new Assessment
            {
                CourseID = course.ID,
                Name = "Orientation",
                Type = "Performance",
                Start = course.Start.Add(new TimeSpan(0, 10, 0, 0)),
                End = course.Start.Add(new TimeSpan(0, 11, 0, 0)),
                Notify = false
            };

            await App.Database.SaveAssessmentAsync(assessment);

            //Refresh notifications and term list
            CheckNotifications();
            TermsList.ItemsSource = await App.Database.GetTermsAsync();
        }
    }
}
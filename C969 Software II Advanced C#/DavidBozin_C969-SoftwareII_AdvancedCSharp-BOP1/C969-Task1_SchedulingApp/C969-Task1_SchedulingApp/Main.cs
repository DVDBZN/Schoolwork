using System;
using System.Collections;
using System.Windows.Forms;

namespace C969_Task1_SchedulingApp
{
    public partial class Main : Form
    {
        public Main(string user)
        {
            InitializeComponent();
            //Save username from Login form
            UsernameLabel.Text = user;

            //Refresh calendar views
            RefreshDaysOfWeek(user);
            RefreshAppointmentsList(user);

            DateTime date = DateTime.Today.ToUniversalTime();
            ArrayList appts = new ArrayList();

            string stm = "SELECT a.type, a.start, a.end, c.customerName " +
                  "FROM appointment AS a " +
                      "LEFT JOIN customer AS c ON a.customerId = c.customerId " +
                      "LEFT JOIN user AS u ON a.userId = u.userId " +
                  "WHERE a.start " +
                      "BETWEEN '" + date.ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss") + "' AND '" + date.AddHours(24).AddSeconds(-1).ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss") + "' " +
                      "AND u.userName = '" + user + "'";

            appts = Program.GetData(stm);

            for (int j = 0; j < appts.Count; j++)
            {
                try
                {
                    appts[j] = Convert.ToDateTime(appts[j]).ToLocalTime();

                    //If an appointment is within 15 minutes of now, show alert with details
                    if (j - 1 % 4 == 0 && DateTime.Now.AddMinutes(15) >= Convert.ToDateTime(appts[j]) && DateTime.Now <= Convert.ToDateTime(appts[j]))
                        MessageBox.Show("You have an appointment with " + appts[j + 2] + " at " + Convert.ToDateTime(appts[j]).ToShortTimeString(), "Upcoming appointment");
                }

                catch { }
            }
        }

        //Show proper controls based on selected parameters
        private void CalendarRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (CalendarRadio.Checked && WeekRadio.Checked)
            {
                SundayBox.Visible = true;
                MondayBox.Visible = true;
                TuesdayBox.Visible = true;
                WednesdayBox.Visible = true;
                ThursdayBox.Visible = true;
                FridayBox.Visible = true;
                SaturdayBox.Visible = true;
                CalendarBox.Visible = true;

                Calendar.Visible = false;
                AppointmentsList.Visible = false;
            }

            else if (CalendarRadio.Checked && MonthRadio.Checked)
            {
                Calendar.Visible = true;
                AppointmentsList.Visible = true;
                CalendarBox.Visible = true;

                SundayBox.Visible = false;
                MondayBox.Visible = false;
                TuesdayBox.Visible = false;
                WednesdayBox.Visible = false;
                ThursdayBox.Visible = false;
                FridayBox.Visible = false;
                SaturdayBox.Visible = false;
            }

            else
            {
                SundayBox.Visible = false;
                MondayBox.Visible = false;
                TuesdayBox.Visible = false;
                WednesdayBox.Visible = false;
                ThursdayBox.Visible = false;
                FridayBox.Visible = false;
                SaturdayBox.Visible = false;
                Calendar.Visible = false;
                AppointmentsList.Visible = false;
                CalendarBox.Visible = false;
            }

            RefreshDaysOfWeek(UsernameLabel.Text);
            RefreshAppointmentsList(UsernameLabel.Text);
        }

        //Show proper controls based on selected parameters
        private void DatabaseRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (DatabaseRadio.Checked)
            {
                DBGridView.Visible = true;
                ControlsBox.Visible = true;
                TableBox.Visible = true;
            }

            else
            {
                DBGridView.Visible = false;
                ControlsBox.Visible = false;
                TableBox.Visible = false;
            }
        }

        //Show proper controls based on selected parameters
        private void ReportsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (ReportsRadio.Checked)
            {
                ReportsTextbox.Visible = true;
                ReportBox.Visible = true;
            }

            else
            {
                ReportsTextbox.Visible = false;
                ReportBox.Visible = false;
            }
        }

        //Show proper controls based on selected parameters
        private void WeekRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (WeekRadio.Checked)
            {
                SundayBox.Visible = true;
                MondayBox.Visible = true;
                TuesdayBox.Visible = true;
                WednesdayBox.Visible = true;
                ThursdayBox.Visible = true;
                FridayBox.Visible = true;
                SaturdayBox.Visible = true;

                Calendar.Visible = false;
                AppointmentsList.Visible = false;
            }

            else
            {
                SundayBox.Visible = false;
                MondayBox.Visible = false;
                TuesdayBox.Visible = false;
                WednesdayBox.Visible = false;
                ThursdayBox.Visible = false;
                FridayBox.Visible = false;
                SaturdayBox.Visible = false;

                Calendar.Visible = true;
                AppointmentsList.Visible = true;
            }
        }

        //Show proper controls based on selected parameters
        private void MonthRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (MonthRadio.Checked)
            {
                SundayBox.Visible = false;
                MondayBox.Visible = false;
                TuesdayBox.Visible = false;
                WednesdayBox.Visible = false;
                ThursdayBox.Visible = false;
                FridayBox.Visible = false;
                SaturdayBox.Visible = false;

                Calendar.Visible = true;
                AppointmentsList.Visible = true;
            }

            else
            {
                SundayBox.Visible = true;
                MondayBox.Visible = true;
                TuesdayBox.Visible = true;
                WednesdayBox.Visible = true;
                ThursdayBox.Visible = true;
                FridayBox.Visible = true;
                SaturdayBox.Visible = true;

                Calendar.Visible = false;
                AppointmentsList.Visible = false;
            }
        }

        //Refresh list of appointments based on newly selected date
        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            RefreshAppointmentsList(UsernameLabel.Text);
        }

        //Update datagrid content based on selected parameter
        private void CustomerTableRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomerTableRadio.Checked)
                RefreshGrid("SELECT c.customerId, c.customerName, a.address, a.address2, a.postalCode, city.city, country.country, a.phone " +
                            "FROM customer AS c " +
                                "LEFT JOIN address AS a ON c.addressId = a.addressId " +
                                "LEFT JOIN city ON a.cityId = city.cityId " +
                                "LEFT JOIN country ON city.countryId = country.countryId");
        }

        //Update datagrid content based on selected parameter
        private void AppointmentTableRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (AppointmentTableRadio.Checked)
                RefreshGrid("SELECT a.appointmentId, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end, c.customerName, u.userName " +
                            "FROM customer AS c " +
                                "INNER JOIN appointment AS a ON a.customerId = c.customerId " +
                                "INNER JOIN user AS u ON a.userId = u.userId");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Lambda expression assigned to Action delegate
            //Justification for using lambda expressions:
            //Without the lambda expression, its contents would have been redundant in both if and else if statements.
            //This saved two lines of code.
            Action<string, string> openForm = (table, s) =>
            {
                //Opens new AddRecord form, updated datagrid with new content, and closes new form
                AddRecord form = new AddRecord(UsernameLabel.Text, table);
                form.ShowDialog();
                RefreshGrid(s);
                form.Dispose();
            };

            if (CustomerTableRadio.Checked)
                openForm("customer", "SELECT c.customerId, c.customerName, a.address, a.address2, a.postalCode, city.city, country.country, a.phone " +
                                     "FROM customer AS c " +
                                         "LEFT JOIN address AS a ON c.addressId = a.addressId " +
                                         "LEFT JOIN city ON a.cityId = city.cityId " +
                                         "LEFT JOIN country ON city.countryId = country.countryId");
            else if (AppointmentTableRadio.Checked)
                openForm("appointment", "SELECT a.appointmentId, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end, c.customerName, u.userName " +
                                        "FROM customer AS c " +
                                            "INNER JOIN appointment AS a ON a.customerId = c.customerId " +
                                            "INNER JOIN user AS u ON a.userId = u.userId");
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            //Stores selected record's data to pass to ModifyRecord form
            ArrayList row = new ArrayList();
            for (int i = 0; i < DBGridView.ColumnCount; i++)
                row.Add(DBGridView.CurrentRow.Cells[i].Value);

            //Lambda expression assigned to Action delegate
            //Justification for using lambda expressions:
            //Without the lambda expression, its contents would have been redundant in both if and else if statements.
            //This saved two lines of code.
            Action<string, string> openForm = (table, s) =>
            {
                //Opens new AddRecord form, updated datagrid with new content, and closes new form
                ModifyRecord form = new ModifyRecord(UsernameLabel.Text, table, row, Convert.ToInt32(DBGridView.SelectedCells[0].Value));
                form.ShowDialog();
                RefreshGrid(s);
                form.Dispose();
            };

            if (CustomerTableRadio.Checked)
                openForm("customer", "SELECT c.customerId, c.customerName, a.address, a.address2, a.postalCode, city.city, country.country, a.phone " +
                                     "FROM customer AS c " +
                                         "LEFT JOIN address AS a ON c.addressId = a.addressId " +
                                         "LEFT JOIN city ON a.cityId = city.cityId " +
                                         "LEFT JOIN country ON city.countryId = country.countryId");
            else if (AppointmentTableRadio.Checked)
                openForm("appointment", "SELECT a.appointmentId, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end, c.customerName, u.userName " +
                                        "FROM customer AS c " +
                                            "INNER JOIN appointment AS a ON a.customerId = c.customerId " +
                                            "INNER JOIN user AS u ON a.userId = u.userId");
        }

        //Delete selected record
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (CustomerTableRadio.Checked)
            {
                Program.SetData("DELETE FROM customer WHERE customerId = " + DBGridView.SelectedCells[0].Value + "");
                RefreshGrid("SELECT c.customerId, c.customerName, a.address, a.address2, a.postalCode, city.city, country.country, a.phone " +
                            "FROM customer AS c " +
                                "LEFT JOIN address AS a ON c.addressId = a.addressId " +
                                "LEFT JOIN city ON a.cityId = city.cityId " +
                                "LEFT JOIN country ON city.countryId = country.countryId");
            }

            else if (AppointmentTableRadio.Checked)
            {
                Program.SetData("DELETE FROM appointment WHERE appointmentId = " + DBGridView.SelectedCells[0].Value + "");
                RefreshGrid("SELECT a.appointmentId, a.title, a.description, a.location, a.contact, a.type, a.url, a.start, a.end, c.customerName, u.userName " +
                            "FROM customer AS c " +
                                "INNER JOIN appointment AS a ON a.customerId = c.customerId " +
                                "INNER JOIN user AS u ON a.userId = u.userId");
            }
        }

        private void ReportRadio1_CheckedChanged(object sender, EventArgs e)
        {
            //Number of appointments by type per month
            if (ReportRadio1.Checked)
            {
                //Query report data
                ArrayList report = Program.GetData("SELECT start, COUNT(*), type " +
                                                   "FROM appointment " +
                                                   "GROUP BY type " +
                                                   "ORDER BY start");

                //Header text
                ReportsTextbox.Text = "Year | Month | Count | Type" + Environment.NewLine + new String('-', 40) + Environment.NewLine;

                //Output query data, four lines at a time
                //This allows for some variables to be formatted
                for (int j = 0; j <= report.Count - 4; j += 4)
                {
                    ReportsTextbox.Text += String.Format("{0,-8}", Convert.ToDateTime(report[j]).ToLocalTime().ToString("yyyy"));
                    ReportsTextbox.Text += String.Format("{0,-9}", Convert.ToDateTime(report[j]).ToLocalTime().ToString("MMM"));
                    ReportsTextbox.Text += String.Format("{0,-6}", report[j + 1]);
                    ReportsTextbox.Text += report[j + 2];
                    ReportsTextbox.Text += report[j + 3];
                }
            }
        }

        private void ReportRadio2_CheckedChanged(object sender, EventArgs e)
        {
            //Schedule of each consultant
            if (ReportRadio2.Checked)
            {
                //Query report data
                ArrayList report = Program.GetData("SELECT u.userName, a.type, a.start, a.end, c.customerName " +
                                                   "FROM user AS u " +
                                                       "LEFT JOIN appointment AS a ON u.userId = a.userId " +
                                                       "LEFT JOIN customer AS c ON a.customerId = c.customerID " +
                                                   "ORDER BY u.userName, a.start");

                //Header text
                ReportsTextbox.Text = "Consultant Name | Appointment Type |   Date   |     Time Frame     | Customer" + Environment.NewLine + new String('-', 80) + Environment.NewLine;
                string name = "";

                //Output query data, six lines at a time
                //This allows for some variables to be formatted
                for (int j = 0; j <= report.Count - 6; j += 6)
                {
                    //If a name appears for the first time, print it and save as variable
                    if (report[j].ToString() != name)
                    {
                        ReportsTextbox.Text += String.Format("{0,-18}", report[j]);
                        name = report[j].ToString();
                    }

                    //Otherwise, don't print name to remove unnecessary clutter
                    else
                        ReportsTextbox.Text += String.Format("{0,-18}", "");

                    ReportsTextbox.Text += String.Format("{0,-19}", report[j + 1]);
                    ReportsTextbox.Text += String.Format("{0,-10}", Convert.ToDateTime(report[j + 2]).ToLocalTime().ToShortDateString());
                    ReportsTextbox.Text += String.Format("{0,-22}", Convert.ToDateTime(report[j + 2]).ToLocalTime().ToShortTimeString() + " to " + Convert.ToDateTime(report[j + 3]).ToLocalTime().ToShortTimeString());
                    ReportsTextbox.Text += String.Format("{0,-20}", report[j + 4]);
                    ReportsTextbox.Text += report[j + 5];
                }
            }
        }

        private void ReportRadio3_CheckedChanged(object sender, EventArgs e)
        {
            //Number of appointments per consultant per month
            if (ReportRadio3.Checked)
            {
                //Query report
                ArrayList report = Program.GetData("SELECT u.userName, a.start, COUNT(a.appointmentId) AS 'count' " +
                                                   "FROM user AS u " +
                                                       "LEFT JOIN appointment AS a ON u.userId = a.userId " +
                                                   "GROUP BY u.userName, EXTRACT(YEAR_MONTH FROM a.start) " +
                                                   "ORDER BY u.userName, a.start");

                //Header text
                ReportsTextbox.Text = "Consultant Name |  Month  | Appointments" + Environment.NewLine + new String('-', 40) + Environment.NewLine;
                string name = "";

                //Output query data, four lines at a time
                //This allows for some variables to be formatted
                for (int j = 0; j <= report.Count - 4; j += 4)
                {
                    //If a name appears for the first time, print it and save as variable
                    if (report[j].ToString() != name)
                    {
                        ReportsTextbox.Text += String.Format("{0,-17}", report[j]);
                        name = report[j].ToString();
                    }

                    //Otherwise, don't print name to remove unnecessary clutter
                    else
                        ReportsTextbox.Text += String.Format("{0,-17}", "");

                    ReportsTextbox.Text += String.Format("{0,-11}", Convert.ToDateTime(report[j + 1]).ToLocalTime().ToString("yyyy-MMM"));
                    ReportsTextbox.Text += report[j + 2];
                    ReportsTextbox.Text += report[j + 3];
                }
            }
        }

        private void RefreshAppointmentsList(string user)
        {
            DateTime date = new DateTime();
            ArrayList appts = new ArrayList();

            date = Calendar.SelectionStart;

            AppointmentsList.Text = "Appointments for " + Calendar.SelectionStart.ToShortDateString() + Environment.NewLine + Environment.NewLine;

            //Query appointments of selected date
            string stm = "SELECT a.type, a.start, a.end, c.customerName " +
                         "FROM appointment AS a " +
                            "LEFT JOIN customer AS c ON a.customerId = c.customerId " +
                            "LEFT JOIN user AS u ON a.userId = u.userId " +
                         "WHERE a.start " +
                            "BETWEEN '" + date.ToUniversalTime().ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss") + "' AND '" + date.ToUniversalTime().AddHours(24).AddSeconds(-1).ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss") + "' " +
                            "AND u.userName = '" + user + "'";

            appts = Program.GetData(stm);

            for (int j = 0; j < appts.Count; j++)
            {
                //Attempt to convert to local time
                try
                {
                    appts[j] = Convert.ToDateTime(appts[j]).ToLocalTime();
                    AppointmentsList.Text += appts[j] + Environment.NewLine;
                }
                //If datatype is not DateTime, just add to output
                catch
                {
                    AppointmentsList.Text += appts[j] + Environment.NewLine;
                }
            }

            //Bolds all dates with appointments in displayed month
            ArrayList boldDates = Program.GetData("SELECT start FROM appointment WHERE MONTH(start) = " + Calendar.SelectionStart.ToUniversalTime().Month +
                                                 " AND YEAR(start) = " + Calendar.SelectionStart.ToUniversalTime().Year);

            for (int i = 0; i < boldDates.Count; i += 2)
                Calendar.AddBoldedDate(DateTime.Parse(boldDates[i].ToString()).ToLocalTime());

            Calendar.UpdateBoldedDates();
        }

        private void RefreshDaysOfWeek(string user)
        {
            DateTime date = new DateTime();
            ArrayList appts = new ArrayList();
            //Array of textboxes for easy iteration
            TextBox[] dayOfWeek = new TextBox[] { SundayText, MondayText, TuesdayText, WednesdayText, ThursdayText, FridayText, SaturdayText };
            int weekDay = (int)DateTime.Now.DayOfWeek;
            string stm = "";
            int i = 0;

            //TODO: Replace the lambda expression
            //Lambda expression assigned to Action delegate
            //Justification for using lambda expressions:
            //The only difference between these two lambda expression calls is whether to use UTC time or local time.
            //Using the lambda expression saves approximately as many lines of code as it uses.
            Action<DateTime> check = (time) =>
            {
                for (int j = 0; j < appts.Count; j++)
                {
                    //Attempt to convert data to local time
                    try
                    {
                        appts[j] = Convert.ToDateTime(appts[j]).ToLocalTime();
                        dayOfWeek[i].Text += Convert.ToString(Convert.ToDateTime(appts[j]).ToShortTimeString()) + Environment.NewLine;
                    }

                    //If datatype is not DateTime, simply add to control
                    catch
                    {
                        dayOfWeek[i].Text += Convert.ToString(appts[j]) + Environment.NewLine;
                    }
                }
            };

            //Iterate over each day of the week text box
            for (i = 0; i < 7; i++)
            {
                //Default text
                dayOfWeek[i].Text = "No scheduled appointments";

                //Set to start on first day of this week
                date = DateTime.Today.AddDays(-weekDay + i).ToUniversalTime();

                stm = "SELECT a.type, a.start, a.end, c.customerName " +
                      "FROM appointment AS a " +
                          "LEFT JOIN customer AS c ON a.customerId = c.customerId " +
                          "LEFT JOIN user AS u ON a.userId = u.userId " +
                      "WHERE a.start " +
                          "BETWEEN '" + date.ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss") + "' AND '" + date.AddHours(24).AddSeconds(-1).ToString("yyyy’-‘MM’-‘dd’ ’HH’:’mm’:’ss") + "' " +
                          "AND u.userName = '" + user + "'";

                appts = Program.GetData(stm);

                //If not empty, reset default text
                if (appts.Count != 0)
                    dayOfWeek[i].Text = "";

                //Calls the lambda expression
                check(DateTime.Now);
            }
        }

        //Refresh datagrid with queried data
        private void RefreshGrid(string stm)
        {
            Program.SetData("SET time_zone = '-7:00'");
            Program.BindGridView(stm, DBGridView);
        }
    }
}
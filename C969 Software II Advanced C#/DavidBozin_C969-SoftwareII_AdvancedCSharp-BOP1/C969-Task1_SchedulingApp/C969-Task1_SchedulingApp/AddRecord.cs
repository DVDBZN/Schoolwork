using System;
using System.Windows.Forms;

namespace C969_Task1_SchedulingApp
{
    public partial class AddRecord : Form
    {
        public AddRecord(string user, string table)
        {
            InitializeComponent();
            //Store some variables for later use 
            UserNameLabel.Text = user;
            TableLabel.Text = table;

            //If modifying a record in customer table...
            //  Change text for labels
            //  Hide unused controls
            if (table == "customer")
            {
                Label1.Text = "Name";
                Label2.Text = "Address";
                Label3.Text = "Address 2";
                Label4.Text = "Postal Code";
                Label5.Text = "City";
                Label6.Text = "Country";
                Label7.Text = "Phone #";

                Label8.Visible = false;
                TextBox8.Visible = false;
                Label9.Visible = false;
                AppointmentStart.Visible = false;
                Label10.Visible = false;
                AppointmentEnd.Visible = false;
            }

            //If modifying a record in appointment table...
            //  Change text for labels
            //  Show extra controls
            else if (table == "appointment")
            {
                Label1.Text = "Title";
                Label2.Text = "Description";
                Label3.Text = "Location";
                Label4.Text = "Contact";
                Label5.Text = "Type";
                Label6.Text = "URL";
                Label7.Text = "Customer";

                Label8.Visible = true;
                TextBox8.Visible = true;
                Label9.Visible = true;
                AppointmentStart.Visible = true;
                Label10.Visible = true;
                AppointmentEnd.Visible = true;
            }
        }

        //Cancel button closes form
        private void CancelButton_Click(object sender, EventArgs e) { Close(); }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Save data to database
            if (TableLabel.Text == "customer")
            {
                //If name, address, city, or country textbox is left empty
                if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox5.Text == "" || TextBox6.Text == "")
                {
                    //Error message and return
                    MessageBox.Show("Please fill out address data.", "Missing data");
                    return;
                }

                //If country does not exist, create new record
                if (Program.GetData("SELECT * FROM country WHERE country = '" + TextBox6.Text + "'").Count == 0)
                    Program.SetData("INSERT INTO country (country, createDate, createdBy, lastUpdateBy) " +
                                    "VALUES ('" + TextBox6.Text + "','" + DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss") + "','" 
                                                + UserNameLabel.Text + "','" + UserNameLabel.Text + "')");

                //If city does not exist, create new record
                if (Program.GetData("SELECT * FROM city WHERE city = '" + TextBox5.Text + "'").Count == 0)
                    Program.SetData("INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) " +
                                    "VALUES ('" + TextBox5.Text + "',(SELECT countryId FROM country WHERE country = '" + TextBox6.Text + "'),'"
                                                + DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss") + "','" + UserNameLabel.Text + "','" + UserNameLabel.Text + "')");

                //If address + address2 are new, create new address record
                if (Program.GetData("SELECT * FROM address WHERE address = '" + TextBox2.Text + "' AND address2 = '" + TextBox3.Text + "'").Count == 0)
                    Program.SetData("INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                                    "VALUES ('" + TextBox2.Text + "','" + TextBox3.Text + "',(SELECT cityId FROM city WHERE city = '" + TextBox5.Text + "'),'"
                                                + TextBox4.Text + "','" + TextBox7.Text + "','" + DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss") + "','"
                                                + UserNameLabel.Text + "','" + UserNameLabel.Text + "')");

                //If customer is new, create new customer record
                if (Program.GetData("SELECT * FROM customer WHERE customerName = '" + TextBox1.Text + "'").Count == 0)
                    Program.SetData("INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) " +
                                    "VALUES ('" + TextBox1.Text + "',(SELECT addressId FROM address WHERE address = '" + TextBox2.Text + "' AND address2 = '"
                                                + TextBox3.Text + "'),1,'" + DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss") + "','" 
                                                + UserNameLabel.Text + "','" + UserNameLabel.Text + "')");

                //If customer exists, show error message and cancel
                else
                    MessageBox.Show("Record already exists. Consider modifying existing record.", "Record exists");
            }

            else if (TableLabel.Text == "appointment")
            {
                //If customer record with inputted name does not exist, show error message and cancel
                if (Program.GetData("SELECT * FROM customer WHERE customerName = '" + TextBox7.Text + "'").Count == 0)
                    MessageBox.Show("This customer does not exist. Please add customer to database.", "Customer does not exist");

                //If appointment overlaps with an existing appointment for same user, show error message and cancel
                else if (Program.GetData("SELECT * FROM appointment " +
                                         "WHERE (start BETWEEN '" + AppointmentStart.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "' " +
                                                "AND '" + AppointmentEnd.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "')" +
                                             " OR (end BETWEEN '" + AppointmentStart.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "' " +
                                                 "AND '" + AppointmentEnd.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "') " +
                                             "AND userId = (SELECT userId FROM user WHERE userName = '" + UserNameLabel.Text + "')").Count != 0)
                    MessageBox.Show("This time slot overlaps with another appointment.", "Appointment overlap");

                //If new appointment starts or ends outside of regular business hours, show error message and cancel
                else if (Convert.ToDateTime(AppointmentStart.Value).Hour < 8 || Convert.ToDateTime(AppointmentStart.Value).Hour > 17 || Convert.ToDateTime(AppointmentEnd.Value).Hour < 8 || Convert.ToDateTime(AppointmentEnd.Value).Hour > 17)
                    MessageBox.Show("This time slot is outside regular business hours.", "Outside business hours");

                //If no errors interfere, record is created with all input parameters
                else
                    Program.SetData("INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) " +
                                    "VALUES ((SELECT customerId FROM customer WHERE customerName = '" + TextBox7.Text + "'),(SELECT userId FROM user WHERE userName = '"
                                            + UserNameLabel.Text + "'),'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','"
                                            + TextBox5.Text + "','" + TextBox6.Text + "','" + AppointmentStart.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "','" 
                                            + AppointmentEnd.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "','" + DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss") + "','" 
                                            + UserNameLabel.Text + "','" + UserNameLabel.Text + "')");
            }

            Close();
        }
    }
}
using System;
using System.Windows.Forms;
using System.Collections;

namespace C969_Task1_SchedulingApp
{
    public partial class ModifyRecord : Form
    {
        public ModifyRecord(string user, string table, ArrayList row, int index)
        {
            InitializeComponent();
            //Collecting a few variables that will be used later
            UserNameLabel.Text = user;
            TableLabel.Text = table;
            RecordLabel.Text = index.ToString();

            //If modifying a record in customer table...
            //  Change text for labels
            //  Hide unused controls
            //  Populate text inputs with existing data
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

                TextBox1.Text = row[1].ToString();
                TextBox2.Text = row[2].ToString();
                TextBox3.Text = row[3].ToString();
                TextBox4.Text = row[4].ToString();
                TextBox5.Text = row[5].ToString();
                TextBox6.Text = row[6].ToString();
                TextBox7.Text = row[7].ToString();
            }

            //If modifying a record in appointment table...
            //  Change text for labels
            //  Show extra controls
            //  Populate text inputs with existing data
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

                TextBox1.Text = row[1].ToString();
                TextBox2.Text = row[2].ToString();
                TextBox3.Text = row[3].ToString();
                TextBox4.Text = row[4].ToString();
                TextBox5.Text = row[5].ToString();
                TextBox6.Text = row[6].ToString();
                TextBox7.Text = row[9].ToString();
                TextBox8.Text = row[10].ToString();
                AppointmentStart.Value = Convert.ToDateTime(Convert.ToDateTime(row[7]).ToString("MM/dd/yyyy HH:mm:ss"));
                AppointmentEnd.Value = Convert.ToDateTime(Convert.ToDateTime(row[8]).ToString("MM/dd/yyyy HH:mm:ss"));
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

                //Update countryId of new or existing city record
                Program.SetData("UPDATE city SET countryId = (SELECT countryId FROM country WHERE country = '" + TextBox6.Text + "') " +
                                "WHERE city = '" + TextBox5.Text + "'");

                //If any of the address fields are new...
                if (Program.GetData("SELECT * FROM address WHERE address = '" + TextBox2.Text + "' AND address2 = '" + TextBox3.Text + "' AND postalCode = '" + TextBox4.Text + "' AND phone = '" + TextBox7.Text + "'").Count == 0)
                {
                    //If address + address2 is new, add new address record
                    if (Program.GetData("SELECT * FROM address WHERE address = '" + TextBox2.Text + "' AND address2 = '" + TextBox3.Text + "'").Count == 0)
                        Program.SetData("INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                                        "VALUES ('" + TextBox2.Text + "','" + TextBox3.Text + "',(SELECT cityId FROM city WHERE city = '" + TextBox5.Text + "'),'"
                                        + TextBox4.Text + "','" + TextBox7.Text + "','" + DateTime.UtcNow.ToString("yyyy-MM-dd H:mm:ss") + "','"
                                        + UserNameLabel.Text + "','" + UserNameLabel.Text + "')");

                    //If address + address2 is same, but one or more fields need updating
                    else
                        Program.SetData("UPDATE address SET " +
                                            "address = '" + TextBox2.Text + "', " +
                                            "address2 = '" + TextBox3.Text + "', " +
                                            "cityId = (SELECT cityId FROM city WHERE city = '" + TextBox5.Text +"'), " +
                                            "postalCode = '" + TextBox4.Text + "', phone = '" + TextBox7.Text + "', " +
                                            "lastUpdateBy = '" + UserNameLabel.Text + "' " +
                                        "WHERE addressId = (SELECT addressId FROM customer WHERE customerId = " + RecordLabel.Text + ")");
                }

                //Update cityId of new or existing address record
                Program.SetData("UPDATE address SET cityId = (SELECT cityId FROM city WHERE city = '" + TextBox5.Text + "') " +
                                "WHERE addressId = (SELECT addressId FROM customer " +
                                    "WHERE customerId = " + RecordLabel.Text + ")");

                //Update customer record
                Program.SetData("UPDATE customer SET " +
                                    "customerName = '" + TextBox1.Text + "', " +
                                    "addressId = (SELECT addressId FROM address WHERE address = '" + TextBox2.Text + "' AND address2 = '" + TextBox3.Text + "'), " +
                                    "lastUpdateBy = '" + UserNameLabel.Text + "' " +
                                "WHERE customerId = " + RecordLabel.Text);
            }

            else if (TableLabel.Text == "appointment")
            {
                //If customer record with inputted name does not exist, show error message and cancel
                if (Program.GetData("SELECT * FROM customer WHERE customerName = '" + TextBox7.Text + "'").Count == 0)
                    MessageBox.Show("This customer does not exist. Please add customer to database.", "Customer does not exist");

                //If appointment overlaps with an existing appointment for same user, show error message and cancel
                else if (Program.GetData("SELECT * FROM appointment " +
                                         "WHERE ((start BETWEEN '" + AppointmentStart.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "' " +
                                                 "AND '" + AppointmentEnd.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "') " +
                                             "OR (end BETWEEN '" + AppointmentStart.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "' " +
                                                 "AND '" + AppointmentEnd.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "')) " +
                                             "AND userId = (SELECT userId FROM user WHERE userName = '" + UserNameLabel.Text + "')").Count != 0)
                    MessageBox.Show("This time slot overlaps with another appointment.", "Appointment overlap");

                //If new appointment starts or ends outside of regular business hours, show error message and cancel
                else if (Convert.ToDateTime(AppointmentStart.Value).Hour < 8 ||
                        Convert.ToDateTime(AppointmentStart.Value).Hour > 17 ||
                        Convert.ToDateTime(AppointmentEnd.Value).Hour < 8 ||
                        Convert.ToDateTime(AppointmentEnd.Value).Hour > 17)
                    MessageBox.Show("This time slot is outside regular business hours.", "Outside business hours");

                //If no errors interfere, record is updated with all input parameters
                else
                    Program.SetData("UPDATE appointment SET " +
                                        "customerId = (SELECT customerId FROM customer WHERE customerName = '" + TextBox7.Text + "'), " +
                                        "userId = (SELECT userId FROM user WHERE userName = '" + UserNameLabel.Text + "'), " +
                                        "title = '" + TextBox1.Text + "', " +
                                        "description = '" + TextBox2.Text + "', " +
                                        "location = '" + TextBox3.Text + "', " +
                                        "contact = '" + TextBox4.Text + "', " +
                                        "type = '" + TextBox5.Text + "', " +
                                        "url = '" + TextBox6.Text + "', " +
                                        "start = '" + AppointmentStart.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "', " +
                                        "end = '" + AppointmentEnd.Value.ToUniversalTime().ToString("yyyy-MM-dd H:mm:ss") + "', " +
                                        "lastUpdateBy = '" + UserNameLabel.Text + "' " +
                                    "WHERE appointmentId = " + RecordLabel.Text);
            }

            Close();
        }
    }
}
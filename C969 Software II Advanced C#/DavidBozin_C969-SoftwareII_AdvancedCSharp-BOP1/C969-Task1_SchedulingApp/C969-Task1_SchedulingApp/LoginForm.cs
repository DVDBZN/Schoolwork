using System;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace C969_Task1_SchedulingApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            if (CultureInfo.CurrentCulture.Name == "ru-RU")
            {
                ErrorLabel.Text = "Неправильный логин";
                UsernameLabel.Text = "Имя пользователя";
                PasswordLabel.Text = "Пароль";
                SubmitButton.Text = "Войти";
                UsernameInput.Width -= 10;
                PasswordInput.Width -= 10;
                UsernameInput.Left += 50;
                PasswordInput.Left += 50;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //If username/password match
            if (Program.Login(UsernameInput.Text, PasswordInput.Text))
            {
                //Add successful login to log file
                using (StreamWriter w = File.AppendText("loginLog.txt"))
                {
                    string message = $"Successful login : {UsernameInput.Text} at {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}";
                    Log(message, w);
                }

                //Open Main form
                //Reset and close this form
                Main main = new Main(UsernameInput.Text);
                ErrorLabel.Visible = false;
                UsernameInput.Text = "";
                PasswordInput.Text = "";
                Console.WriteLine("Logged in");
                main.Closed += (s, args) => this.Close();
                main.Show();
                Hide();
            }

            else
            {
                //Add unsuccessful login to log file
                using (StreamWriter w = File.AppendText("loginLog.txt"))
                {
                    string message = $"Unsuccessful login : {UsernameInput.Text} at {DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}";
                    Log(message, w);
                }

                //Display error message and reset input fields
                ErrorLabel.Visible = true;
                UsernameInput.Text = "";
                PasswordInput.Text = "";
                Console.WriteLine("Not logged in");
            }
        }

        //Write message to file
        private static void Log(string message, TextWriter w) { w.WriteLine(message); }
    }
}
using System;
using System.Windows.Forms;

namespace Factorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Parse value if possible
            try
            {
                //Call custom method that finds factorial
                label1.Text = factorial(Int32.Parse(textBox1.Text)).ToString();
            }
            //If not, display as Error
            catch
            {
                label1.Text = "Error";
            }
        }

        double factorial(int num)
        {
            double factorial = 1;

            //Loop that counts to number entered
            for (int i = 1; i <= num; i++)
                //On last iteration, factorial will be final answer
                factorial *= i;
            return factorial;
        }
    }
}
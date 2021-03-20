using System;
using System.Windows.Forms;

namespace C968_Software1CSharp_DBozin9
{
    public partial class AddPartForm : Form
    {
        public AddPartForm()
        {
            InitializeComponent();
        }

        //Event handlers
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Exception handling for min > max cases
            try
            {
                if (Convert.ToInt32(MinTextBox.Text) > Convert.ToInt32(MaxTextBox.Text))
                    throw new ArgumentOutOfRangeException("Min cannot exceed Max");
            }

            //Handle min > max exception
            catch (ArgumentOutOfRangeException ex)
            {
                var result = MessageBox.Show("Minimum count cannot exceed Maximum count.\n\nContact your IT department for assistance.",
                    "Min > Max", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }

            //Handle in case min or max are not integers
            catch (Exception ex)
            {
                var result = MessageBox.Show("Please use integers for Inventory, Minimum, and Maximum.\n" +
                    "Please use doubles for the Price.\n\nContact your IT department for assistance.",
                    "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }

            //Create Inhouse or Outsourced object that inherits Part
            if (InHouseRadio.Checked)
            {
                try
                {
                    //Create inhouse part
                    var part = new Inhouse(Program.inventory.allParts.Count, NameTextBox.Text, Convert.ToDouble(PriceTextBox.Text), Convert.ToInt32(InvTextBox.Text), Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text), Convert.ToInt32(VariableTextBox.Text));
                    Program.inventory.addPart(part);
                }

                //Handle overflow and type exceptions
                catch (Exception ex)
                {
                    var result = MessageBox.Show("Please use integers for Inventory, Minimum, and Maximum.\n" +
                        "Please use doubles for the Price.\n\nContact your IT department for assistance.",
                        "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                        return;
                }
            }

            else if (OutsourcedRadio.Checked)
            {
                try
                {
                    //Create outsourced part
                    var part = new Outsourced(Program.inventory.allParts.Count, NameTextBox.Text, Convert.ToDouble(PriceTextBox.Text), Convert.ToInt32(InvTextBox.Text), Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text), VariableTextBox.Text);
                    Program.inventory.addPart(part);
                }

                //Handle overflow and type exceptions
                catch (FormatException ex)
                {
                    var result = MessageBox.Show("Please use integers for Inventory, Minimum, and Maximum.\n" +
                        "Please use doubles for the Price.\n\nContact your IT department for assistance.",
                        "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                        return;
                }
            }
            Program.title.UpdateLists();
            Close();
        }

        private void InHouseRadio_CheckedChanged(object sender, EventArgs e)
        {
            //Change labels when radios change
            if (InHouseRadio.Checked)
            {
                VariableLabel.Text = "Machine ID";
            }

            else
            {
                VariableLabel.Text = "Company Name";
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Confirm message box
            var result = MessageBox.Show("Unsaved data will be lost.\nContinue?", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            Program.title.UpdateLists();

            //Close form
            if (result == DialogResult.OK)
                Close();
        }
    }
}
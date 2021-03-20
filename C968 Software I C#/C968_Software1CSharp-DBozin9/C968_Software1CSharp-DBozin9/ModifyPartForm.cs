using System;
using System.Windows.Forms;

namespace C968_Software1CSharp_DBozin9
{
    public partial class ModifyPartForm : Form
    {
        public ModifyPartForm(int i)
        {
            InitializeComponent();

            //Populate machineID or company name textbox depending on part type
            //Also changes checked radio to correct one
            if (Program.inventory.allParts[i] is Inhouse)
            {
                VariableTextBox.Text = Convert.ToString(((Inhouse)Program.inventory.allParts[i]).MachineID);
                InHouseRadio.Checked = true;
            }
            else
            {
                VariableTextBox.Text = Convert.ToString(((Outsourced)Program.inventory.allParts[i]).CompanyName);
                OutsourcedRadio.Checked = true;
            }

            //Populate textboxes with part variables
            IDTextBox.Text = Convert.ToString(Program.inventory.allParts[i].PartID);
            NameTextBox.Text = Program.inventory.allParts[i].Name;
            InvTextBox.Text = Convert.ToString(Program.inventory.allParts[i].InStock);
            PriceTextBox.Text = Convert.ToString(Program.inventory.allParts[i].Price);
            MinTextBox.Text = Convert.ToString(Program.inventory.allParts[i].Min);
            MaxTextBox.Text = Convert.ToString(Program.inventory.allParts[i].Max);
        }

        //Event handlers
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Handle min > max case
            try
            {
                if (Convert.ToInt32(MinTextBox.Text) > Convert.ToInt32(MaxTextBox.Text))
                    throw new ArgumentOutOfRangeException("Min cannot exceed Max");
            }

            //Min > max
            catch (ArgumentOutOfRangeException ex)
            {
                var result = MessageBox.Show("Minimum count cannot exceed Maximum count.\n\nContact your IT department for assistance.",
                    "Min > Max", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }

            //Non-integer value for min or max
            catch (Exception ex)
            {
                var result = MessageBox.Show("Please use integers for Inventory, Minimum, and Maximum.\n" +
                    "Please use doubles for the Price.\n\nContact your IT department for assistance.",
                    "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }

            //Create Inhouse or Outsourced opject that inherits Part
            if (InHouseRadio.Checked)
            {
                try
                {
                    //Create inhouse part
                    var part = new Inhouse(Convert.ToInt32(IDTextBox.Text), NameTextBox.Text, Convert.ToDouble(PriceTextBox.Text), Convert.ToInt32(InvTextBox.Text), Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text), Convert.ToInt32(VariableTextBox.Text));
                    Program.inventory.allParts[Convert.ToInt32(IDTextBox.Text)] = part;
                }

                //Handle type and overflow exceptions
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
                    int i = Convert.ToInt32(IDTextBox.Text);
                    var part = new Outsourced(Convert.ToInt32(IDTextBox.Text), NameTextBox.Text, Convert.ToDouble(PriceTextBox.Text), Convert.ToInt32(InvTextBox.Text), Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text), VariableTextBox.Text);
                    Program.inventory.allParts[i] = part;
                }

                //Handle type and overflow exceptions
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

        private void OutsourcedRadio_CheckedChanged(object sender, EventArgs e)
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
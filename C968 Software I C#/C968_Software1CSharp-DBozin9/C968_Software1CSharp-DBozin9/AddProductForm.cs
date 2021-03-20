using System;
using System.Windows.Forms;

namespace C968_Software1CSharp_DBozin9
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
            SearchedPartsList.FullRowSelect = true;
            ProductPartsList.FullRowSelect = true;
            UpdateLists();
        }

        //Event handlers
        private void SearchPartButton_Click(object sender, EventArgs e)
        {
            UpdateLists();

            //If search is blank, output all items
            if (SearchTextPart.Text == "")
            {
                return;
            }

            string term = SearchTextPart.Text.ToUpper();

            //Create list of false bools for flagging removal
            bool[] remove = new bool[SearchedPartsList.Items.Count];
            for (int j = 0; j < remove.Length; j++)
                remove[j] = false;

            //Loop through all items
            for (int i = 0; i < SearchedPartsList.Items.Count; i++)
            {
                if (Program.inventory.allParts[i] is Outsourced)
                {
                    //If search does not exist in all variables
                    if (!((Convert.ToString(Program.inventory.allParts[i].PartID)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Name)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].InStock)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Price)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Min)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Max)).ToUpper().Contains(term)
                        || (Convert.ToString(((Outsourced)Program.inventory.allParts[i]).CompanyName)).ToUpper().Contains(term)))
                    {
                        //Flag index for removal
                        remove[i] = true;
                    }
                }

                else if (Program.inventory.allParts[i] is Inhouse)
                {
                    //If search does not exist in all variables
                    if (!((Convert.ToString(Program.inventory.allParts[i].PartID)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Name)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].InStock)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Price)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Min)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.allParts[i].Max)).ToUpper().Contains(term)
                        || (Convert.ToString(((Inhouse)Program.inventory.allParts[i]).MachineID)).ToUpper().Contains(term)))
                    {
                        //Flag index for removal
                        remove[i] = true;
                    }
                }
            }

            //Remove each item with index flagged for removal
            //Start from end, since items are removed, making the list shorter
            for (int i = remove.Length - 1; i >= 0; i--)
                if (remove[i])
                    SearchedPartsList.Items.RemoveAt(i);
        }

        private void AddPartButton_Click(object sender, EventArgs e)
        {
            //Exception handling for click without item selected
            try
            {
                //Add selected part from list into Product's AssociatedParts list
                ProductPartsList.Items.Add((ListViewItem)SearchedPartsList.SelectedItems[0].Clone());
            }

            catch (ArgumentOutOfRangeException ex)
            {
                var result = MessageBox.Show("Please select an item.\n\nContact your IT department for assistance.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }
        }

        private void DeletePartButton_Click(object sender, EventArgs e)
        {
            //Exception handling for click without item selected
            try
            {
                //Delete selected part from list from Product's AssociatedParts list
                ProductPartsList.Items.RemoveAt(ProductPartsList.SelectedItems[0].Index);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                var result = MessageBox.Show("Please select an item.\n\nContact your IT department for assistance.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Exception handling for min > max cases
            try
            {
                if (Convert.ToInt32(MinTextBox.Text) > Convert.ToInt32(MaxTextBox.Text))
                    throw new ArgumentOutOfRangeException("Min cannot exceed Max");
            }

            //Catch min > max cases
            catch (ArgumentOutOfRangeException ex)
            {
                var result = MessageBox.Show("Minimum count cannot exceed Maximum count.\n\nContact your IT department for assistance.",
                    "Min > Max", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }

            //Catch type exception for min or max
            catch (Exception ex)
            {
                var result = MessageBox.Show("Please use integers for Inventory, Minimum, and Maximum.\n" +
                    "Please use doubles for the Price.\n\nContact your IT department for assistance.",
                    "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }

            try
            {
                //Save all fields into a new product
                var product = new Product(Program.inventory.Products.Count, NameTextBox.Text, Convert.ToDouble(PriceTextBox.Text), Convert.ToInt32(InvTextBox.Text), Convert.ToInt32(MinTextBox.Text), Convert.ToInt32(MaxTextBox.Text));
                Program.inventory.addProduct(product);

                //Convert each ProductPartsList.Item into a Part object and call addAssocaitedPart(Part) for all parts
                for (int i = 0; i < ProductPartsList.Items.Count; i++)
                {
                    product.addAssociatedPart(Program.inventory.allParts[Convert.ToInt32(ProductPartsList.Items[i].SubItems[1].Text)]);
                }
            }

            //Catch overflow and type exceptions
            catch (Exception ex)
            {
                var result = MessageBox.Show("Please use integers for Inventory, Minimum, and Maximum.\n" +
                    "Please use doubles for the Price.\n\nContact your IT department for assistance.",
                    "Format Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                    return;
            }

            Program.title.UpdateLists();
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //Confirmation message box
            var result = MessageBox.Show("Unsaved data will be lost.\nContinue?", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            Program.title.UpdateLists();

            //Close form
            if (result == DialogResult.OK)
                Close();
        }

        private void UpdateLists()
        {
            //Clear list items
            SearchedPartsList.Items.Clear();

            //Loop through all inventory parts and add to list view
            for (int i = 0; i < Program.inventory.allParts.Count; i++)
            {
                ListViewItem item = new ListViewItem("Part" + i.ToString(), i);
                item.SubItems.Add(Program.inventory.allParts[i].PartID.ToString());
                item.SubItems.Add(Program.inventory.allParts[i].Name);
                item.SubItems.Add(Program.inventory.allParts[i].InStock.ToString());
                item.SubItems.Add(Program.inventory.allParts[i].Price.ToString());
                item.SubItems.Add(Program.inventory.allParts[i].Min.ToString());
                item.SubItems.Add(Program.inventory.allParts[i].Max.ToString());
                if (Program.inventory.allParts[i] is Inhouse)
                    item.SubItems.Add(((Inhouse)Program.inventory.allParts[i]).MachineID.ToString());
                else if (Program.inventory.allParts[i] is Outsourced)
                    item.SubItems.Add(((Outsourced)Program.inventory.allParts[i]).CompanyName);

                SearchedPartsList.Items.Add(item);
            }
        }
    }
}
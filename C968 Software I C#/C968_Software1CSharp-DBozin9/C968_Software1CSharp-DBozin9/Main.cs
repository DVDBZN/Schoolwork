using System;
using System.Windows.Forms;

namespace C968_Software1CSharp_DBozin9
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //Set selection to select entire row, rather than just one space
            PartList.FullRowSelect = true;
            ProductList.FullRowSelect = true;
        }

        //Making certain variables accessible to other forms
        public Part SelectedPart()
        {
            return Program.inventory.allParts[PartList.SelectedItems[0].Index];
        }

        public Product SelectedProduct()
        {
            return Program.inventory.Products[ProductList.SelectedItems[0].Index];
        }

        public ListView PartView()
        {
            return PartList;
        }

        public ListView ProductView()
        {
            return ProductList;
        }

        //Event handlers
        private void AddPartButton_Click(object sender, EventArgs e)
        {
            //Redirect to "Add Part" form
            AddPartForm form = new AddPartForm();
            form.Show();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            //Redirect to "Add Product" form
            AddProductForm form = new AddProductForm();
            form.Show();
        }

        private void ModifyPartButton_Click(object sender, EventArgs e)
        {
            //Exception handling for click without item selected
            try
            {
                //Redirect to "Modify Part" form
                ModifyPartForm form = new ModifyPartForm(PartList.SelectedItems[0].Index);
                form.Show();
            }

            catch (ArgumentOutOfRangeException ex)
            {
                //Show error message
                var result = MessageBox.Show("Please select an item.\n\nContact your IT department for assistance.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //After acknowledgement, return to main form
                if (result == DialogResult.OK)
                    return;
            }
        }

        private void ModifyProductButton_Click(object sender, EventArgs e)
        {
            //Exception handling for click without item selected
            try
            {
                //Redirect to "Modify Product" form
                ModifyProductForm form = new ModifyProductForm(ProductList.SelectedItems[0].Index);
                form.Show();
            }

            catch (ArgumentOutOfRangeException ex)
            {
                //Show error message
                var result = MessageBox.Show("Please select an item.\n\nContact your IT department for assistance.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //After acknowledgement, return to main form
                if (result == DialogResult.OK)
                    return;
            }
        }

        private void DeletePartButton_Click(object sender, EventArgs e)
        {
            //Exception handling for click without item selected
            try
            {
                ListViewItem item = PartList.SelectedItems[0];
                //Confirmation message box
                var result = MessageBox.Show("Permanently delete this record?", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                //Delete selected part in grid view
                if (result == DialogResult.OK)
                    Program.inventory.deletePart(Program.inventory.allParts[item.Index]);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                //Show error message
                var result = MessageBox.Show("Please select an item.\n\nContact your IT department for assistance.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //After acknowledgement, return to main form
                if (result == DialogResult.OK)
                    return;
            }

            UpdateLists();
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            //Exception handling for click without item selected
            try
            {
                ListViewItem item = ProductList.SelectedItems[0];
                //Confirmation message box
                var result = MessageBox.Show("Permanently delete this record?", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                //Delete selected product in grid view
                if (result == DialogResult.OK)
                    Program.inventory.removeProduct(item.Index);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                //Show error message
                var result = MessageBox.Show("Please select an item.\n\nContact your IT department for assistance.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //After acknowledgement, return to main form
                if (result == DialogResult.OK)
                    return;
            }

            UpdateLists();
        }

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
            bool[] remove = new bool[PartList.Items.Count];
            for (int j = 0; j < remove.Length; j++)
                remove[j] = false;

            //Loop through all items
            for (int i = 0; i < PartList.Items.Count; i++)
            {
                //Can probably be consolidated into one statement, but kept for simplicity
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
                    PartList.Items.RemoveAt(i);
        }

        private void SearchProductButton_Click(object sender, EventArgs e)
        {
            UpdateLists();

            //If search is blank, output all items
            if (SearchTextProduct.Text == null)
            {
                return;
            }

            string term = SearchTextProduct.Text.ToUpper();

            //Create list of false bools for flagging removal
            bool[] remove = new bool[ProductList.Items.Count];
            for (int j = 0; j < remove.Length; j++)
                remove[j] = false;

            //Loop through all items
            for (int i = 0; i < ProductList.Items.Count; i++)
            {
                //If search does not exist in all variables
                if (!((Convert.ToString(Program.inventory.Products[i].ProductID)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.Products[i].Name)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.Products[i].InStock)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.Products[i].Price)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.Products[i].Min)).ToUpper().Contains(term)
                        || (Convert.ToString(Program.inventory.Products[i].Max)).ToUpper().Contains(term)))
                {
                    //Flag index for removal
                    remove[i] = true;
                }
            }

            //Remove each item with index flagged for removal
            //Start from end, since items are removed, making the list shorter
            for (int i = remove.Length - 1; i >= 0; i--)
                if (remove[i])
                    ProductList.Items.RemoveAt(i);
        }

        //Call this function after each update to inventory (add, delete, modify)
        public void UpdateLists()
        {
            //Clear list items
            PartList.Items.Clear();
            ProductList.Items.Clear();

            for (int i = 0; i <  Program.inventory.allParts.Count; i++)
            {
                //Create list item and name it Part#
                ListViewItem item = new ListViewItem("Part" + i.ToString(), i);
                //Add variables from inventory items
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

                //Add new item to list view
                PartList.Items.Add(item);
            }

            for (int i = 0; i < Program.inventory.Products.Count; i++)
            {
                //Create list item and name it Part#
                ListViewItem item = new ListViewItem("Product" + i.ToString(), i);
                //Add variables from inventory items
                item.SubItems.Add(Program.inventory.Products[i].ProductID.ToString());
                item.SubItems.Add(Program.inventory.Products[i].Name);
                item.SubItems.Add(Program.inventory.Products[i].InStock.ToString());
                item.SubItems.Add(Program.inventory.Products[i].Price.ToString());
                item.SubItems.Add(Program.inventory.Products[i].Min.ToString());
                item.SubItems.Add(Program.inventory.Products[i].Max.ToString());

                //Add new item to list view
                ProductList.Items.Add(item);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //Warning
            var result = MessageBox.Show("Unsaved data will be lost.\nContinue?", "Confirm?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (result == DialogResult.OK)
                Application.Exit();
        }
    }
}
namespace C968_Software1CSharp_DBozin9
{
    partial class AddProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddProductTitle = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.MaxTextBox = new System.Windows.Forms.TextBox();
            this.MinTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.InvTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.MaxLabel = new System.Windows.Forms.Label();
            this.MinLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.InvLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.SearchPartButton = new System.Windows.Forms.Button();
            this.SearchTextPart = new System.Windows.Forms.TextBox();
            this.AddPartButton = new System.Windows.Forms.Button();
            this.DeletePartButton = new System.Windows.Forms.Button();
            this.SearchedPartsList = new System.Windows.Forms.ListView();
            this.IntentionallyLeftBlank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PartID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PartName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InventoryLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductPartsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // AddProductTitle
            // 
            this.AddProductTitle.AutoSize = true;
            this.AddProductTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddProductTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.AddProductTitle.Location = new System.Drawing.Point(12, 9);
            this.AddProductTitle.Name = "AddProductTitle";
            this.AddProductTitle.Size = new System.Drawing.Size(131, 25);
            this.AddProductTitle.TabIndex = 20;
            this.AddProductTitle.Text = "Add Product";
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Location = new System.Drawing.Point(796, 490);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 32);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveButton.Location = new System.Drawing.Point(612, 490);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 32);
            this.SaveButton.TabIndex = 10;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // MaxTextBox
            // 
            this.MaxTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaxTextBox.ForeColor = System.Drawing.Color.Black;
            this.MaxTextBox.Location = new System.Drawing.Point(210, 389);
            this.MaxTextBox.Name = "MaxTextBox";
            this.MaxTextBox.Size = new System.Drawing.Size(162, 26);
            this.MaxTextBox.TabIndex = 5;
            // 
            // MinTextBox
            // 
            this.MinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinTextBox.ForeColor = System.Drawing.Color.Black;
            this.MinTextBox.Location = new System.Drawing.Point(210, 322);
            this.MinTextBox.Name = "MinTextBox";
            this.MinTextBox.Size = new System.Drawing.Size(162, 26);
            this.MinTextBox.TabIndex = 4;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceTextBox.ForeColor = System.Drawing.Color.Black;
            this.PriceTextBox.Location = new System.Drawing.Point(210, 258);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(162, 26);
            this.PriceTextBox.TabIndex = 3;
            // 
            // InvTextBox
            // 
            this.InvTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InvTextBox.ForeColor = System.Drawing.Color.Black;
            this.InvTextBox.Location = new System.Drawing.Point(210, 197);
            this.InvTextBox.Name = "InvTextBox";
            this.InvTextBox.Size = new System.Drawing.Size(162, 26);
            this.InvTextBox.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameTextBox.ForeColor = System.Drawing.Color.Black;
            this.NameTextBox.Location = new System.Drawing.Point(210, 130);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(162, 26);
            this.NameTextBox.TabIndex = 1;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Enabled = false;
            this.IDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IDTextBox.Location = new System.Drawing.Point(210, 66);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.ReadOnly = true;
            this.IDTextBox.Size = new System.Drawing.Size(162, 26);
            this.IDTextBox.TabIndex = 20;
            this.IDTextBox.TabStop = false;
            this.IDTextBox.Text = "Auto Generated";
            this.IDTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MaxLabel
            // 
            this.MaxLabel.AutoSize = true;
            this.MaxLabel.Location = new System.Drawing.Point(53, 392);
            this.MaxLabel.Name = "MaxLabel";
            this.MaxLabel.Size = new System.Drawing.Size(76, 20);
            this.MaxLabel.TabIndex = 20;
            this.MaxLabel.Text = "Maximum";
            // 
            // MinLabel
            // 
            this.MinLabel.AutoSize = true;
            this.MinLabel.Location = new System.Drawing.Point(53, 325);
            this.MinLabel.Name = "MinLabel";
            this.MinLabel.Size = new System.Drawing.Size(72, 20);
            this.MinLabel.TabIndex = 20;
            this.MinLabel.Text = "Minimum";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(53, 261);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(81, 20);
            this.PriceLabel.TabIndex = 20;
            this.PriceLabel.Text = "Price/Cost";
            // 
            // InvLabel
            // 
            this.InvLabel.AutoSize = true;
            this.InvLabel.Location = new System.Drawing.Point(53, 200);
            this.InvLabel.Name = "InvLabel";
            this.InvLabel.Size = new System.Drawing.Size(115, 20);
            this.InvLabel.TabIndex = 20;
            this.InvLabel.Text = "Inventory Level";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(53, 133);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 20);
            this.NameLabel.TabIndex = 20;
            this.NameLabel.Text = "Name";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(53, 69);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(26, 20);
            this.IDLabel.TabIndex = 20;
            this.IDLabel.Text = "ID";
            // 
            // SearchPartButton
            // 
            this.SearchPartButton.Location = new System.Drawing.Point(486, 63);
            this.SearchPartButton.Name = "SearchPartButton";
            this.SearchPartButton.Size = new System.Drawing.Size(120, 32);
            this.SearchPartButton.TabIndex = 7;
            this.SearchPartButton.Text = "Search";
            this.SearchPartButton.UseVisualStyleBackColor = true;
            this.SearchPartButton.Click += new System.EventHandler(this.SearchPartButton_Click);
            // 
            // SearchTextPart
            // 
            this.SearchTextPart.Location = new System.Drawing.Point(612, 64);
            this.SearchTextPart.Name = "SearchTextPart";
            this.SearchTextPart.Size = new System.Drawing.Size(304, 26);
            this.SearchTextPart.TabIndex = 6;
            // 
            // AddPartButton
            // 
            this.AddPartButton.Location = new System.Drawing.Point(796, 229);
            this.AddPartButton.Name = "AddPartButton";
            this.AddPartButton.Size = new System.Drawing.Size(120, 32);
            this.AddPartButton.TabIndex = 8;
            this.AddPartButton.Text = "Add";
            this.AddPartButton.UseVisualStyleBackColor = true;
            this.AddPartButton.Click += new System.EventHandler(this.AddPartButton_Click);
            // 
            // DeletePartButton
            // 
            this.DeletePartButton.Location = new System.Drawing.Point(796, 421);
            this.DeletePartButton.Name = "DeletePartButton";
            this.DeletePartButton.Size = new System.Drawing.Size(120, 32);
            this.DeletePartButton.TabIndex = 9;
            this.DeletePartButton.Text = "Delete";
            this.DeletePartButton.UseVisualStyleBackColor = true;
            this.DeletePartButton.Click += new System.EventHandler(this.DeletePartButton_Click);
            // 
            // SearchedPartsList
            // 
            this.SearchedPartsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IntentionallyLeftBlank,
            this.PartID,
            this.PartName,
            this.InventoryLevel,
            this.Price});
            this.SearchedPartsList.GridLines = true;
            this.SearchedPartsList.Location = new System.Drawing.Point(486, 100);
            this.SearchedPartsList.MultiSelect = false;
            this.SearchedPartsList.Name = "SearchedPartsList";
            this.SearchedPartsList.Size = new System.Drawing.Size(430, 123);
            this.SearchedPartsList.TabIndex = 20;
            this.SearchedPartsList.TabStop = false;
            this.SearchedPartsList.TileSize = new System.Drawing.Size(30, 10);
            this.SearchedPartsList.UseCompatibleStateImageBehavior = false;
            this.SearchedPartsList.View = System.Windows.Forms.View.Details;
            // 
            // IntentionallyLeftBlank
            // 
            this.IntentionallyLeftBlank.Text = "";
            this.IntentionallyLeftBlank.Width = 0;
            // 
            // PartID
            // 
            this.PartID.Text = "Part ID";
            this.PartID.Width = 65;
            // 
            // PartName
            // 
            this.PartName.Text = "Part Name";
            this.PartName.Width = 180;
            // 
            // InventoryLevel
            // 
            this.InventoryLevel.Text = "Inv";
            // 
            // Price
            // 
            this.Price.Text = " Price per Unit";
            this.Price.Width = 120;
            // 
            // ProductPartsList
            // 
            this.ProductPartsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.ProductPartsList.GridLines = true;
            this.ProductPartsList.Location = new System.Drawing.Point(486, 292);
            this.ProductPartsList.MultiSelect = false;
            this.ProductPartsList.Name = "ProductPartsList";
            this.ProductPartsList.Size = new System.Drawing.Size(430, 123);
            this.ProductPartsList.TabIndex = 20;
            this.ProductPartsList.TabStop = false;
            this.ProductPartsList.TileSize = new System.Drawing.Size(30, 10);
            this.ProductPartsList.UseCompatibleStateImageBehavior = false;
            this.ProductPartsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Part ID";
            this.columnHeader2.Width = 65;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Part Name";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Inv";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = " Price per Unit";
            this.columnHeader5.Width = 120;
            // 
            // AddProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(928, 534);
            this.Controls.Add(this.ProductPartsList);
            this.Controls.Add(this.SearchedPartsList);
            this.Controls.Add(this.DeletePartButton);
            this.Controls.Add(this.AddPartButton);
            this.Controls.Add(this.SearchTextPart);
            this.Controls.Add(this.SearchPartButton);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.InvLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.MinLabel);
            this.Controls.Add(this.MaxLabel);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.InvTextBox);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.MinTextBox);
            this.Controls.Add(this.MaxTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddProductTitle);
            this.Name = "AddProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddProductTitle;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox MaxTextBox;
        private System.Windows.Forms.TextBox MinTextBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.TextBox InvTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label MaxLabel;
        private System.Windows.Forms.Label MinLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label InvLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button SearchPartButton;
        private System.Windows.Forms.TextBox SearchTextPart;
        private System.Windows.Forms.Button AddPartButton;
        private System.Windows.Forms.Button DeletePartButton;
        private System.Windows.Forms.ListView SearchedPartsList;
        private System.Windows.Forms.ColumnHeader IntentionallyLeftBlank;
        private System.Windows.Forms.ColumnHeader PartID;
        private System.Windows.Forms.ColumnHeader PartName;
        private System.Windows.Forms.ColumnHeader InventoryLevel;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ListView ProductPartsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
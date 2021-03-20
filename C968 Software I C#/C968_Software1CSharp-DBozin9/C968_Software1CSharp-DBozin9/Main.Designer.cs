namespace C968_Software1CSharp_DBozin9
{
    partial class MainForm
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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.MainTitle = new System.Windows.Forms.Label();
            this.ProductPanel = new System.Windows.Forms.Panel();
            this.ProductList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchTextProduct = new System.Windows.Forms.TextBox();
            this.SearchProductButton = new System.Windows.Forms.Button();
            this.ProductLabel = new System.Windows.Forms.Label();
            this.ModifyProductButton = new System.Windows.Forms.Button();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PartPanel = new System.Windows.Forms.Panel();
            this.PartList = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchTextPart = new System.Windows.Forms.TextBox();
            this.SearchPartButton = new System.Windows.Forms.Button();
            this.PartLabel = new System.Windows.Forms.Label();
            this.ModifyPartButton = new System.Windows.Forms.Button();
            this.AddPartButton = new System.Windows.Forms.Button();
            this.DeletePartButton = new System.Windows.Forms.Button();
            this.ProductPanel.SuspendLayout();
            this.PartPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTitle
            // 
            this.MainTitle.AutoSize = true;
            this.MainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.MainTitle.Location = new System.Drawing.Point(12, 9);
            this.MainTitle.Name = "MainTitle";
            this.MainTitle.Size = new System.Drawing.Size(310, 25);
            this.MainTitle.TabIndex = 20;
            this.MainTitle.Text = "Inventory Management System";
            // 
            // ProductPanel
            // 
            this.ProductPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductPanel.Controls.Add(this.ProductList);
            this.ProductPanel.Controls.Add(this.SearchTextProduct);
            this.ProductPanel.Controls.Add(this.SearchProductButton);
            this.ProductPanel.Controls.Add(this.ProductLabel);
            this.ProductPanel.Controls.Add(this.ModifyProductButton);
            this.ProductPanel.Controls.Add(this.AddProductButton);
            this.ProductPanel.Controls.Add(this.DeleteProductButton);
            this.ProductPanel.Location = new System.Drawing.Point(720, 52);
            this.ProductPanel.Margin = new System.Windows.Forms.Padding(4);
            this.ProductPanel.MinimumSize = new System.Drawing.Size(64, 64);
            this.ProductPanel.Name = "ProductPanel";
            this.ProductPanel.Size = new System.Drawing.Size(685, 466);
            this.ProductPanel.TabIndex = 6;
            // 
            // ProductList
            // 
            this.ProductList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.ProductList.GridLines = true;
            this.ProductList.Location = new System.Drawing.Point(8, 38);
            this.ProductList.MultiSelect = false;
            this.ProductList.Name = "ProductList";
            this.ProductList.Size = new System.Drawing.Size(665, 385);
            this.ProductList.TabIndex = 11;
            this.ProductList.TabStop = false;
            this.ProductList.TileSize = new System.Drawing.Size(30, 10);
            this.ProductList.UseCompatibleStateImageBehavior = false;
            this.ProductList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Product ID";
            this.columnHeader2.Width = 64;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 176;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Inv";
            this.columnHeader4.Width = 48;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Price";
            this.columnHeader5.Width = 56;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Min";
            this.columnHeader6.Width = 48;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Max";
            this.columnHeader7.Width = 48;
            // 
            // SearchTextProduct
            // 
            this.SearchTextProduct.Location = new System.Drawing.Point(317, 4);
            this.SearchTextProduct.Name = "SearchTextProduct";
            this.SearchTextProduct.Size = new System.Drawing.Size(356, 26);
            this.SearchTextProduct.TabIndex = 6;
            // 
            // SearchProductButton
            // 
            this.SearchProductButton.Location = new System.Drawing.Point(191, 3);
            this.SearchProductButton.Name = "SearchProductButton";
            this.SearchProductButton.Size = new System.Drawing.Size(120, 32);
            this.SearchProductButton.TabIndex = 7;
            this.SearchProductButton.Text = "Search";
            this.SearchProductButton.UseVisualStyleBackColor = true;
            this.SearchProductButton.Click += new System.EventHandler(this.SearchProductButton_Click);
            // 
            // ProductLabel
            // 
            this.ProductLabel.AutoSize = true;
            this.ProductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductLabel.Location = new System.Drawing.Point(3, 6);
            this.ProductLabel.Name = "ProductLabel";
            this.ProductLabel.Size = new System.Drawing.Size(116, 29);
            this.ProductLabel.TabIndex = 20;
            this.ProductLabel.Text = "Products";
            // 
            // ModifyProductButton
            // 
            this.ModifyProductButton.Location = new System.Drawing.Point(427, 429);
            this.ModifyProductButton.Name = "ModifyProductButton";
            this.ModifyProductButton.Size = new System.Drawing.Size(120, 32);
            this.ModifyProductButton.TabIndex = 9;
            this.ModifyProductButton.Text = "Modify";
            this.ModifyProductButton.UseVisualStyleBackColor = true;
            this.ModifyProductButton.Click += new System.EventHandler(this.ModifyProductButton_Click);
            // 
            // AddProductButton
            // 
            this.AddProductButton.Location = new System.Drawing.Point(301, 429);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(120, 32);
            this.AddProductButton.TabIndex = 8;
            this.AddProductButton.Text = "Add";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.Location = new System.Drawing.Point(553, 429);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(120, 32);
            this.DeleteProductButton.TabIndex = 10;
            this.DeleteProductButton.Text = "Delete";
            this.DeleteProductButton.UseVisualStyleBackColor = true;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ExitButton.Location = new System.Drawing.Point(1274, 540);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(120, 32);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PartPanel
            // 
            this.PartPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PartPanel.Controls.Add(this.PartList);
            this.PartPanel.Controls.Add(this.SearchTextPart);
            this.PartPanel.Controls.Add(this.SearchPartButton);
            this.PartPanel.Controls.Add(this.PartLabel);
            this.PartPanel.Controls.Add(this.ModifyPartButton);
            this.PartPanel.Controls.Add(this.AddPartButton);
            this.PartPanel.Controls.Add(this.DeletePartButton);
            this.PartPanel.Location = new System.Drawing.Point(13, 52);
            this.PartPanel.Margin = new System.Windows.Forms.Padding(4);
            this.PartPanel.Name = "PartPanel";
            this.PartPanel.Size = new System.Drawing.Size(685, 466);
            this.PartPanel.TabIndex = 1;
            // 
            // PartList
            // 
            this.PartList.AutoArrange = false;
            this.PartList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.Title,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.PartList.GridLines = true;
            this.PartList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PartList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.PartList.Location = new System.Drawing.Point(8, 38);
            this.PartList.MultiSelect = false;
            this.PartList.Name = "PartList";
            this.PartList.Size = new System.Drawing.Size(665, 385);
            this.PartList.TabIndex = 10;
            this.PartList.TabStop = false;
            this.PartList.TileSize = new System.Drawing.Size(30, 10);
            this.PartList.UseCompatibleStateImageBehavior = false;
            this.PartList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Part ID";
            this.columnHeader9.Width = 48;
            // 
            // Title
            // 
            this.Title.DisplayIndex = 3;
            this.Title.Name = "Title";
            this.Title.Text = "Name";
            this.Title.Width = 88;
            // 
            // columnHeader11
            // 
            this.columnHeader11.DisplayIndex = 2;
            this.columnHeader11.Text = "Inv";
            this.columnHeader11.Width = 48;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Price";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Min";
            this.columnHeader13.Width = 48;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Max";
            this.columnHeader14.Width = 48;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Source";
            this.columnHeader15.Width = 100;
            // 
            // SearchTextPart
            // 
            this.SearchTextPart.Location = new System.Drawing.Point(317, 4);
            this.SearchTextPart.Name = "SearchTextPart";
            this.SearchTextPart.Size = new System.Drawing.Size(356, 26);
            this.SearchTextPart.TabIndex = 1;
            // 
            // SearchPartButton
            // 
            this.SearchPartButton.Location = new System.Drawing.Point(191, 3);
            this.SearchPartButton.Name = "SearchPartButton";
            this.SearchPartButton.Size = new System.Drawing.Size(120, 32);
            this.SearchPartButton.TabIndex = 2;
            this.SearchPartButton.Text = "Search";
            this.SearchPartButton.UseVisualStyleBackColor = true;
            this.SearchPartButton.Click += new System.EventHandler(this.SearchPartButton_Click);
            // 
            // PartLabel
            // 
            this.PartLabel.AutoSize = true;
            this.PartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PartLabel.Location = new System.Drawing.Point(3, 6);
            this.PartLabel.Name = "PartLabel";
            this.PartLabel.Size = new System.Drawing.Size(73, 29);
            this.PartLabel.TabIndex = 20;
            this.PartLabel.Text = "Parts";
            // 
            // ModifyPartButton
            // 
            this.ModifyPartButton.Location = new System.Drawing.Point(427, 429);
            this.ModifyPartButton.Name = "ModifyPartButton";
            this.ModifyPartButton.Size = new System.Drawing.Size(120, 32);
            this.ModifyPartButton.TabIndex = 4;
            this.ModifyPartButton.Text = "Modify";
            this.ModifyPartButton.UseVisualStyleBackColor = true;
            this.ModifyPartButton.Click += new System.EventHandler(this.ModifyPartButton_Click);
            // 
            // AddPartButton
            // 
            this.AddPartButton.Location = new System.Drawing.Point(301, 429);
            this.AddPartButton.Name = "AddPartButton";
            this.AddPartButton.Size = new System.Drawing.Size(120, 32);
            this.AddPartButton.TabIndex = 3;
            this.AddPartButton.Text = "Add";
            this.AddPartButton.UseVisualStyleBackColor = true;
            this.AddPartButton.Click += new System.EventHandler(this.AddPartButton_Click);
            // 
            // DeletePartButton
            // 
            this.DeletePartButton.Location = new System.Drawing.Point(553, 429);
            this.DeletePartButton.Name = "DeletePartButton";
            this.DeletePartButton.Size = new System.Drawing.Size(120, 32);
            this.DeletePartButton.TabIndex = 5;
            this.DeletePartButton.Text = "Delete";
            this.DeletePartButton.UseVisualStyleBackColor = true;
            this.DeletePartButton.Click += new System.EventHandler(this.DeletePartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1418, 584);
            this.Controls.Add(this.PartPanel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ProductPanel);
            this.Controls.Add(this.MainTitle);
            this.Name = "MainForm";
            this.ProductPanel.ResumeLayout(false);
            this.ProductPanel.PerformLayout();
            this.PartPanel.ResumeLayout(false);
            this.PartPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainTitle;
        private System.Windows.Forms.Panel ProductPanel;
        private System.Windows.Forms.TextBox SearchTextProduct;
        private System.Windows.Forms.Button SearchProductButton;
        private System.Windows.Forms.Label ProductLabel;
        private System.Windows.Forms.Button ModifyProductButton;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.Button DeleteProductButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel PartPanel;
        private System.Windows.Forms.TextBox SearchTextPart;
        private System.Windows.Forms.Button SearchPartButton;
        private System.Windows.Forms.Label PartLabel;
        private System.Windows.Forms.Button ModifyPartButton;
        private System.Windows.Forms.Button AddPartButton;
        private System.Windows.Forms.Button DeletePartButton;
        private System.Windows.Forms.ListView PartList;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView ProductList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader Title;
    }
}


namespace C969_Task1_SchedulingApp
{
    partial class Main
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
            this.CalendarBox = new System.Windows.Forms.GroupBox();
            this.MonthRadio = new System.Windows.Forms.RadioButton();
            this.WeekRadio = new System.Windows.Forms.RadioButton();
            this.AppointmentsList = new System.Windows.Forms.TextBox();
            this.SundayBox = new System.Windows.Forms.GroupBox();
            this.SundayText = new System.Windows.Forms.TextBox();
            this.MondayBox = new System.Windows.Forms.GroupBox();
            this.MondayText = new System.Windows.Forms.TextBox();
            this.TuesdayBox = new System.Windows.Forms.GroupBox();
            this.TuesdayText = new System.Windows.Forms.TextBox();
            this.WednesdayBox = new System.Windows.Forms.GroupBox();
            this.WednesdayText = new System.Windows.Forms.TextBox();
            this.ThursdayBox = new System.Windows.Forms.GroupBox();
            this.ThursdayText = new System.Windows.Forms.TextBox();
            this.FridayBox = new System.Windows.Forms.GroupBox();
            this.FridayText = new System.Windows.Forms.TextBox();
            this.SaturdayBox = new System.Windows.Forms.GroupBox();
            this.SaturdayText = new System.Windows.Forms.TextBox();
            this.LoggedInLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ViewBox = new System.Windows.Forms.GroupBox();
            this.ReportsRadio = new System.Windows.Forms.RadioButton();
            this.DatabaseRadio = new System.Windows.Forms.RadioButton();
            this.CalendarRadio = new System.Windows.Forms.RadioButton();
            this.DBGridView = new System.Windows.Forms.DataGridView();
            this.TableBox = new System.Windows.Forms.GroupBox();
            this.AppointmentTableRadio = new System.Windows.Forms.RadioButton();
            this.CustomerTableRadio = new System.Windows.Forms.RadioButton();
            this.ControlsBox = new System.Windows.Forms.GroupBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ModifyButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ReportBox = new System.Windows.Forms.GroupBox();
            this.ReportRadio2 = new System.Windows.Forms.RadioButton();
            this.ReportRadio3 = new System.Windows.Forms.RadioButton();
            this.ReportRadio1 = new System.Windows.Forms.RadioButton();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.ReportsTextbox = new System.Windows.Forms.TextBox();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.CalendarBox.SuspendLayout();
            this.SundayBox.SuspendLayout();
            this.MondayBox.SuspendLayout();
            this.TuesdayBox.SuspendLayout();
            this.WednesdayBox.SuspendLayout();
            this.ThursdayBox.SuspendLayout();
            this.FridayBox.SuspendLayout();
            this.SaturdayBox.SuspendLayout();
            this.ViewBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridView)).BeginInit();
            this.TableBox.SuspendLayout();
            this.ControlsBox.SuspendLayout();
            this.ReportBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalendarBox
            // 
            this.CalendarBox.Controls.Add(this.MonthRadio);
            this.CalendarBox.Controls.Add(this.WeekRadio);
            this.CalendarBox.Location = new System.Drawing.Point(12, 155);
            this.CalendarBox.Name = "CalendarBox";
            this.CalendarBox.Size = new System.Drawing.Size(315, 115);
            this.CalendarBox.TabIndex = 1;
            this.CalendarBox.TabStop = false;
            this.CalendarBox.Text = "Calendar View";
            // 
            // MonthRadio
            // 
            this.MonthRadio.AutoSize = true;
            this.MonthRadio.Checked = true;
            this.MonthRadio.Location = new System.Drawing.Point(45, 55);
            this.MonthRadio.Name = "MonthRadio";
            this.MonthRadio.Size = new System.Drawing.Size(117, 24);
            this.MonthRadio.TabIndex = 1;
            this.MonthRadio.TabStop = true;
            this.MonthRadio.Text = "Month View";
            this.MonthRadio.UseVisualStyleBackColor = true;
            this.MonthRadio.CheckedChanged += new System.EventHandler(this.MonthRadio_CheckedChanged);
            // 
            // WeekRadio
            // 
            this.WeekRadio.AutoSize = true;
            this.WeekRadio.Location = new System.Drawing.Point(45, 25);
            this.WeekRadio.Name = "WeekRadio";
            this.WeekRadio.Size = new System.Drawing.Size(113, 24);
            this.WeekRadio.TabIndex = 0;
            this.WeekRadio.Text = "Week View";
            this.WeekRadio.UseVisualStyleBackColor = true;
            this.WeekRadio.CheckedChanged += new System.EventHandler(this.WeekRadio_CheckedChanged);
            // 
            // AppointmentsList
            // 
            this.AppointmentsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AppointmentsList.Location = new System.Drawing.Point(12, 276);
            this.AppointmentsList.Multiline = true;
            this.AppointmentsList.Name = "AppointmentsList";
            this.AppointmentsList.ReadOnly = true;
            this.AppointmentsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AppointmentsList.Size = new System.Drawing.Size(315, 690);
            this.AppointmentsList.TabIndex = 3;
            // 
            // SundayBox
            // 
            this.SundayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SundayBox.Controls.Add(this.SundayText);
            this.SundayBox.Location = new System.Drawing.Point(330, 12);
            this.SundayBox.Name = "SundayBox";
            this.SundayBox.Size = new System.Drawing.Size(172, 954);
            this.SundayBox.TabIndex = 4;
            this.SundayBox.TabStop = false;
            this.SundayBox.Text = "Sunday";
            this.SundayBox.Visible = false;
            // 
            // SundayText
            // 
            this.SundayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SundayText.Location = new System.Drawing.Point(6, 25);
            this.SundayText.Multiline = true;
            this.SundayText.Name = "SundayText";
            this.SundayText.ReadOnly = true;
            this.SundayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SundayText.Size = new System.Drawing.Size(160, 923);
            this.SundayText.TabIndex = 0;
            this.SundayText.Text = "No scheduled appointments";
            // 
            // MondayBox
            // 
            this.MondayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MondayBox.Controls.Add(this.MondayText);
            this.MondayBox.Location = new System.Drawing.Point(508, 12);
            this.MondayBox.Name = "MondayBox";
            this.MondayBox.Size = new System.Drawing.Size(172, 954);
            this.MondayBox.TabIndex = 5;
            this.MondayBox.TabStop = false;
            this.MondayBox.Text = "Monday";
            this.MondayBox.Visible = false;
            // 
            // MondayText
            // 
            this.MondayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MondayText.Location = new System.Drawing.Point(6, 25);
            this.MondayText.Multiline = true;
            this.MondayText.Name = "MondayText";
            this.MondayText.ReadOnly = true;
            this.MondayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MondayText.Size = new System.Drawing.Size(160, 923);
            this.MondayText.TabIndex = 1;
            this.MondayText.Text = "No scheduled appointments";
            // 
            // TuesdayBox
            // 
            this.TuesdayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TuesdayBox.Controls.Add(this.TuesdayText);
            this.TuesdayBox.Location = new System.Drawing.Point(686, 12);
            this.TuesdayBox.Name = "TuesdayBox";
            this.TuesdayBox.Size = new System.Drawing.Size(172, 954);
            this.TuesdayBox.TabIndex = 5;
            this.TuesdayBox.TabStop = false;
            this.TuesdayBox.Text = "Tuesday";
            this.TuesdayBox.Visible = false;
            // 
            // TuesdayText
            // 
            this.TuesdayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TuesdayText.Location = new System.Drawing.Point(6, 25);
            this.TuesdayText.Multiline = true;
            this.TuesdayText.Name = "TuesdayText";
            this.TuesdayText.ReadOnly = true;
            this.TuesdayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TuesdayText.Size = new System.Drawing.Size(160, 923);
            this.TuesdayText.TabIndex = 1;
            this.TuesdayText.Text = "No scheduled appointments";
            // 
            // WednesdayBox
            // 
            this.WednesdayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WednesdayBox.Controls.Add(this.WednesdayText);
            this.WednesdayBox.Location = new System.Drawing.Point(864, 12);
            this.WednesdayBox.Name = "WednesdayBox";
            this.WednesdayBox.Size = new System.Drawing.Size(172, 954);
            this.WednesdayBox.TabIndex = 6;
            this.WednesdayBox.TabStop = false;
            this.WednesdayBox.Text = "Wednesday";
            this.WednesdayBox.Visible = false;
            // 
            // WednesdayText
            // 
            this.WednesdayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WednesdayText.Location = new System.Drawing.Point(6, 25);
            this.WednesdayText.Multiline = true;
            this.WednesdayText.Name = "WednesdayText";
            this.WednesdayText.ReadOnly = true;
            this.WednesdayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WednesdayText.Size = new System.Drawing.Size(160, 923);
            this.WednesdayText.TabIndex = 1;
            this.WednesdayText.Text = "No scheduled appointments";
            // 
            // ThursdayBox
            // 
            this.ThursdayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ThursdayBox.Controls.Add(this.ThursdayText);
            this.ThursdayBox.Location = new System.Drawing.Point(1042, 12);
            this.ThursdayBox.Name = "ThursdayBox";
            this.ThursdayBox.Size = new System.Drawing.Size(172, 954);
            this.ThursdayBox.TabIndex = 6;
            this.ThursdayBox.TabStop = false;
            this.ThursdayBox.Text = "Thursday";
            this.ThursdayBox.Visible = false;
            // 
            // ThursdayText
            // 
            this.ThursdayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ThursdayText.Location = new System.Drawing.Point(6, 25);
            this.ThursdayText.Multiline = true;
            this.ThursdayText.Name = "ThursdayText";
            this.ThursdayText.ReadOnly = true;
            this.ThursdayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ThursdayText.Size = new System.Drawing.Size(160, 923);
            this.ThursdayText.TabIndex = 1;
            this.ThursdayText.Text = "No scheduled appointments";
            // 
            // FridayBox
            // 
            this.FridayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FridayBox.Controls.Add(this.FridayText);
            this.FridayBox.Location = new System.Drawing.Point(1220, 12);
            this.FridayBox.Name = "FridayBox";
            this.FridayBox.Size = new System.Drawing.Size(172, 954);
            this.FridayBox.TabIndex = 6;
            this.FridayBox.TabStop = false;
            this.FridayBox.Text = "Friday";
            this.FridayBox.Visible = false;
            // 
            // FridayText
            // 
            this.FridayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FridayText.Location = new System.Drawing.Point(6, 25);
            this.FridayText.Multiline = true;
            this.FridayText.Name = "FridayText";
            this.FridayText.ReadOnly = true;
            this.FridayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FridayText.Size = new System.Drawing.Size(160, 923);
            this.FridayText.TabIndex = 1;
            this.FridayText.Text = "No scheduled appointments";
            // 
            // SaturdayBox
            // 
            this.SaturdayBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SaturdayBox.Controls.Add(this.SaturdayText);
            this.SaturdayBox.Location = new System.Drawing.Point(1398, 12);
            this.SaturdayBox.Name = "SaturdayBox";
            this.SaturdayBox.Size = new System.Drawing.Size(172, 954);
            this.SaturdayBox.TabIndex = 6;
            this.SaturdayBox.TabStop = false;
            this.SaturdayBox.Text = "Saturday";
            this.SaturdayBox.Visible = false;
            // 
            // SaturdayText
            // 
            this.SaturdayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SaturdayText.Location = new System.Drawing.Point(6, 25);
            this.SaturdayText.Multiline = true;
            this.SaturdayText.Name = "SaturdayText";
            this.SaturdayText.ReadOnly = true;
            this.SaturdayText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SaturdayText.Size = new System.Drawing.Size(160, 923);
            this.SaturdayText.TabIndex = 1;
            this.SaturdayText.Text = "No scheduled appointments";
            // 
            // LoggedInLabel
            // 
            this.LoggedInLabel.AutoSize = true;
            this.LoggedInLabel.Location = new System.Drawing.Point(8, 8);
            this.LoggedInLabel.Name = "LoggedInLabel";
            this.LoggedInLabel.Size = new System.Drawing.Size(104, 20);
            this.LoggedInLabel.TabIndex = 7;
            this.LoggedInLabel.Text = "Logged in as ";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(108, 8);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(101, 20);
            this.UsernameLabel.TabIndex = 8;
            this.UsernameLabel.Text = "USERNAME";
            // 
            // ViewBox
            // 
            this.ViewBox.Controls.Add(this.ReportsRadio);
            this.ViewBox.Controls.Add(this.DatabaseRadio);
            this.ViewBox.Controls.Add(this.CalendarRadio);
            this.ViewBox.Location = new System.Drawing.Point(12, 32);
            this.ViewBox.Name = "ViewBox";
            this.ViewBox.Size = new System.Drawing.Size(315, 117);
            this.ViewBox.TabIndex = 9;
            this.ViewBox.TabStop = false;
            this.ViewBox.Text = "Function";
            // 
            // ReportsRadio
            // 
            this.ReportsRadio.AutoSize = true;
            this.ReportsRadio.Location = new System.Drawing.Point(44, 87);
            this.ReportsRadio.Name = "ReportsRadio";
            this.ReportsRadio.Size = new System.Drawing.Size(91, 24);
            this.ReportsRadio.TabIndex = 2;
            this.ReportsRadio.Text = "Reports";
            this.ReportsRadio.UseVisualStyleBackColor = true;
            this.ReportsRadio.CheckedChanged += new System.EventHandler(this.ReportsRadio_CheckedChanged);
            // 
            // DatabaseRadio
            // 
            this.DatabaseRadio.AutoSize = true;
            this.DatabaseRadio.Location = new System.Drawing.Point(44, 57);
            this.DatabaseRadio.Name = "DatabaseRadio";
            this.DatabaseRadio.Size = new System.Drawing.Size(104, 24);
            this.DatabaseRadio.TabIndex = 1;
            this.DatabaseRadio.Text = "Database";
            this.DatabaseRadio.UseVisualStyleBackColor = true;
            this.DatabaseRadio.CheckedChanged += new System.EventHandler(this.DatabaseRadio_CheckedChanged);
            // 
            // CalendarRadio
            // 
            this.CalendarRadio.AutoSize = true;
            this.CalendarRadio.Checked = true;
            this.CalendarRadio.Location = new System.Drawing.Point(44, 26);
            this.CalendarRadio.Name = "CalendarRadio";
            this.CalendarRadio.Size = new System.Drawing.Size(98, 24);
            this.CalendarRadio.TabIndex = 0;
            this.CalendarRadio.TabStop = true;
            this.CalendarRadio.Text = "Calendar";
            this.CalendarRadio.UseVisualStyleBackColor = true;
            this.CalendarRadio.CheckedChanged += new System.EventHandler(this.CalendarRadio_CheckedChanged);
            // 
            // DBGridView
            // 
            this.DBGridView.AllowUserToAddRows = false;
            this.DBGridView.AllowUserToDeleteRows = false;
            this.DBGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DBGridView.Location = new System.Drawing.Point(330, 8);
            this.DBGridView.MultiSelect = false;
            this.DBGridView.Name = "DBGridView";
            this.DBGridView.ReadOnly = true;
            this.DBGridView.RowTemplate.Height = 28;
            this.DBGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DBGridView.Size = new System.Drawing.Size(1240, 958);
            this.DBGridView.TabIndex = 10;
            this.DBGridView.Visible = false;
            // 
            // TableBox
            // 
            this.TableBox.Controls.Add(this.AppointmentTableRadio);
            this.TableBox.Controls.Add(this.CustomerTableRadio);
            this.TableBox.Location = new System.Drawing.Point(12, 155);
            this.TableBox.Name = "TableBox";
            this.TableBox.Size = new System.Drawing.Size(315, 87);
            this.TableBox.TabIndex = 10;
            this.TableBox.TabStop = false;
            this.TableBox.Text = "Table";
            this.TableBox.Visible = false;
            // 
            // AppointmentTableRadio
            // 
            this.AppointmentTableRadio.AutoSize = true;
            this.AppointmentTableRadio.Location = new System.Drawing.Point(47, 55);
            this.AppointmentTableRadio.Name = "AppointmentTableRadio";
            this.AppointmentTableRadio.Size = new System.Drawing.Size(168, 24);
            this.AppointmentTableRadio.TabIndex = 1;
            this.AppointmentTableRadio.Text = "Appointment Table";
            this.AppointmentTableRadio.UseVisualStyleBackColor = true;
            this.AppointmentTableRadio.CheckedChanged += new System.EventHandler(this.AppointmentTableRadio_CheckedChanged);
            // 
            // CustomerTableRadio
            // 
            this.CustomerTableRadio.AutoSize = true;
            this.CustomerTableRadio.Location = new System.Drawing.Point(47, 25);
            this.CustomerTableRadio.Name = "CustomerTableRadio";
            this.CustomerTableRadio.Size = new System.Drawing.Size(146, 24);
            this.CustomerTableRadio.TabIndex = 0;
            this.CustomerTableRadio.Text = "Customer Table";
            this.CustomerTableRadio.UseVisualStyleBackColor = true;
            this.CustomerTableRadio.CheckedChanged += new System.EventHandler(this.CustomerTableRadio_CheckedChanged);
            // 
            // ControlsBox
            // 
            this.ControlsBox.Controls.Add(this.DeleteButton);
            this.ControlsBox.Controls.Add(this.ModifyButton);
            this.ControlsBox.Controls.Add(this.AddButton);
            this.ControlsBox.Location = new System.Drawing.Point(12, 248);
            this.ControlsBox.Name = "ControlsBox";
            this.ControlsBox.Size = new System.Drawing.Size(315, 139);
            this.ControlsBox.TabIndex = 11;
            this.ControlsBox.TabStop = false;
            this.ControlsBox.Text = "Controls";
            this.ControlsBox.Visible = false;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(45, 101);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(226, 32);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ModifyButton
            // 
            this.ModifyButton.Location = new System.Drawing.Point(45, 63);
            this.ModifyButton.Name = "ModifyButton";
            this.ModifyButton.Size = new System.Drawing.Size(226, 32);
            this.ModifyButton.TabIndex = 1;
            this.ModifyButton.Text = "Modify";
            this.ModifyButton.UseVisualStyleBackColor = true;
            this.ModifyButton.Click += new System.EventHandler(this.ModifyButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(45, 25);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(226, 32);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ReportBox
            // 
            this.ReportBox.Controls.Add(this.ReportRadio2);
            this.ReportBox.Controls.Add(this.ReportRadio3);
            this.ReportBox.Controls.Add(this.ReportRadio1);
            this.ReportBox.Location = new System.Drawing.Point(12, 155);
            this.ReportBox.Name = "ReportBox";
            this.ReportBox.Size = new System.Drawing.Size(315, 115);
            this.ReportBox.TabIndex = 12;
            this.ReportBox.TabStop = false;
            this.ReportBox.Text = "Reports";
            this.ReportBox.Visible = false;
            // 
            // ReportRadio2
            // 
            this.ReportRadio2.AutoSize = true;
            this.ReportRadio2.Location = new System.Drawing.Point(44, 55);
            this.ReportRadio2.Name = "ReportRadio2";
            this.ReportRadio2.Size = new System.Drawing.Size(187, 24);
            this.ReportRadio2.TabIndex = 1;
            this.ReportRadio2.TabStop = true;
            this.ReportRadio2.Text = "Consultant schedules";
            this.ReportRadio2.UseVisualStyleBackColor = true;
            this.ReportRadio2.CheckedChanged += new System.EventHandler(this.ReportRadio2_CheckedChanged);
            // 
            // ReportRadio3
            // 
            this.ReportRadio3.AutoSize = true;
            this.ReportRadio3.Location = new System.Drawing.Point(44, 85);
            this.ReportRadio3.Name = "ReportRadio3";
            this.ReportRadio3.Size = new System.Drawing.Size(241, 24);
            this.ReportRadio3.TabIndex = 2;
            this.ReportRadio3.TabStop = true;
            this.ReportRadio3.Text = "Appointments per Consultant";
            this.ReportRadio3.UseVisualStyleBackColor = true;
            this.ReportRadio3.CheckedChanged += new System.EventHandler(this.ReportRadio3_CheckedChanged);
            // 
            // ReportRadio1
            // 
            this.ReportRadio1.AutoSize = true;
            this.ReportRadio1.Location = new System.Drawing.Point(44, 25);
            this.ReportRadio1.Name = "ReportRadio1";
            this.ReportRadio1.Size = new System.Drawing.Size(228, 24);
            this.ReportRadio1.TabIndex = 0;
            this.ReportRadio1.TabStop = true;
            this.ReportRadio1.Text = "Appointment type by month";
            this.ReportRadio1.UseVisualStyleBackColor = true;
            this.ReportRadio1.CheckedChanged += new System.EventHandler(this.ReportRadio1_CheckedChanged);
            // 
            // ReportsTextbox
            // 
            this.ReportsTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReportsTextbox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReportsTextbox.Location = new System.Drawing.Point(330, 8);
            this.ReportsTextbox.Multiline = true;
            this.ReportsTextbox.Name = "ReportsTextbox";
            this.ReportsTextbox.ReadOnly = true;
            this.ReportsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReportsTextbox.Size = new System.Drawing.Size(1240, 958);
            this.ReportsTextbox.TabIndex = 3;
            this.ReportsTextbox.Visible = false;
            this.ReportsTextbox.WordWrap = false;
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(330, 18);
            this.Calendar.Margin = new System.Windows.Forms.Padding(0);
            this.Calendar.MaxSelectionCount = 1;
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 978);
            this.Controls.Add(this.ReportsTextbox);
            this.Controls.Add(this.DBGridView);
            this.Controls.Add(this.ControlsBox);
            this.Controls.Add(this.ViewBox);
            this.Controls.Add(this.TableBox);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.LoggedInLabel);
            this.Controls.Add(this.SaturdayBox);
            this.Controls.Add(this.FridayBox);
            this.Controls.Add(this.ThursdayBox);
            this.Controls.Add(this.WednesdayBox);
            this.Controls.Add(this.TuesdayBox);
            this.Controls.Add(this.MondayBox);
            this.Controls.Add(this.SundayBox);
            this.Controls.Add(this.AppointmentsList);
            this.Controls.Add(this.ReportBox);
            this.Controls.Add(this.CalendarBox);
            this.Controls.Add(this.Calendar);
            this.Name = "Main";
            this.Text = "Main";
            this.CalendarBox.ResumeLayout(false);
            this.CalendarBox.PerformLayout();
            this.SundayBox.ResumeLayout(false);
            this.SundayBox.PerformLayout();
            this.MondayBox.ResumeLayout(false);
            this.MondayBox.PerformLayout();
            this.TuesdayBox.ResumeLayout(false);
            this.TuesdayBox.PerformLayout();
            this.WednesdayBox.ResumeLayout(false);
            this.WednesdayBox.PerformLayout();
            this.ThursdayBox.ResumeLayout(false);
            this.ThursdayBox.PerformLayout();
            this.FridayBox.ResumeLayout(false);
            this.FridayBox.PerformLayout();
            this.SaturdayBox.ResumeLayout(false);
            this.SaturdayBox.PerformLayout();
            this.ViewBox.ResumeLayout(false);
            this.ViewBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DBGridView)).EndInit();
            this.TableBox.ResumeLayout(false);
            this.TableBox.PerformLayout();
            this.ControlsBox.ResumeLayout(false);
            this.ReportBox.ResumeLayout(false);
            this.ReportBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox CalendarBox;
        private System.Windows.Forms.RadioButton MonthRadio;
        private System.Windows.Forms.RadioButton WeekRadio;
        private System.Windows.Forms.TextBox AppointmentsList;
        private System.Windows.Forms.GroupBox SundayBox;
        private System.Windows.Forms.GroupBox MondayBox;
        private System.Windows.Forms.GroupBox TuesdayBox;
        private System.Windows.Forms.GroupBox WednesdayBox;
        private System.Windows.Forms.GroupBox ThursdayBox;
        private System.Windows.Forms.GroupBox FridayBox;
        private System.Windows.Forms.GroupBox SaturdayBox;
        private System.Windows.Forms.TextBox SundayText;
        private System.Windows.Forms.TextBox MondayText;
        private System.Windows.Forms.TextBox TuesdayText;
        private System.Windows.Forms.TextBox WednesdayText;
        private System.Windows.Forms.TextBox ThursdayText;
        private System.Windows.Forms.TextBox FridayText;
        private System.Windows.Forms.TextBox SaturdayText;
        private System.Windows.Forms.Label LoggedInLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.GroupBox ViewBox;
        private System.Windows.Forms.RadioButton ReportsRadio;
        private System.Windows.Forms.RadioButton DatabaseRadio;
        private System.Windows.Forms.RadioButton CalendarRadio;
        private System.Windows.Forms.DataGridView DBGridView;
        private System.Windows.Forms.GroupBox TableBox;
        private System.Windows.Forms.RadioButton AppointmentTableRadio;
        private System.Windows.Forms.RadioButton CustomerTableRadio;
        private System.Windows.Forms.GroupBox ControlsBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ModifyButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.GroupBox ReportBox;
        private System.Windows.Forms.RadioButton ReportRadio2;
        private System.Windows.Forms.RadioButton ReportRadio1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox ReportsTextbox;
        private System.Windows.Forms.RadioButton ReportRadio3;
        private System.Windows.Forms.MonthCalendar Calendar;
    }
}
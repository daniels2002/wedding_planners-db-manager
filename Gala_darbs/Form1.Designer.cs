namespace Gala_darbs
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.table_list = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Create_wedding = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.View_guests = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.wedding_table_view = new System.Windows.Forms.DataGridView();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.index_table_view = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.main_table_view = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.reception_comboBox = new System.Windows.Forms.ComboBox();
            this.venue_comboBox = new System.Windows.Forms.ComboBox();
            this.pastor_comboBox = new System.Windows.Forms.ComboBox();
            this.married_couple_comboBox = new System.Windows.Forms.ComboBox();
            this.invintation_comboBox = new System.Windows.Forms.ComboBox();
            this.guests_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.total_records = new System.Windows.Forms.TextBox();
            this.budget_comboBox = new System.Windows.Forms.ComboBox();
            this.Search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wedding_table_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.index_table_view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_table_view)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(43, 25);
            this.toolStripButton1.Text = "Sync";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // table_list
            // 
            this.table_list.Items.AddRange(new object[] {
            "budget",
            "married_couple",
            "pastor",
            "venue"});
            this.table_list.Name = "table_list";
            this.table_list.Size = new System.Drawing.Size(113, 28);
            this.table_list.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.table_list,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator4,
            this.Create_wedding,
            this.toolStripSeparator5,
            this.View_guests});
            this.toolStrip1.Location = new System.Drawing.Point(0, 525);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1371, 28);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(108, 25);
            this.toolStripButton2.Text = "Show contacts";
            this.toolStripButton2.Click += new System.EventHandler(this.Contacts_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(80, 25);
            this.toolStripButton4.Text = "Reception";
            this.toolStripButton4.Click += new System.EventHandler(this.Reception_hierarchy);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(101, 25);
            this.toolStripButton3.Text = "Insert budget";
            this.toolStripButton3.Click += new System.EventHandler(this.Insert_budget_click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // Create_wedding
            // 
            this.Create_wedding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Create_wedding.Image = ((System.Drawing.Image)(resources.GetObject("Create_wedding.Image")));
            this.Create_wedding.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Create_wedding.Name = "Create_wedding";
            this.Create_wedding.Size = new System.Drawing.Size(118, 25);
            this.Create_wedding.Text = "Create wedding";
            this.Create_wedding.Click += new System.EventHandler(this.Create_wedding_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // View_guests
            // 
            this.View_guests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.View_guests.Image = ((System.Drawing.Image)(resources.GetObject("View_guests.Image")));
            this.View_guests.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.View_guests.Name = "View_guests";
            this.View_guests.Size = new System.Drawing.Size(92, 25);
            this.View_guests.Text = "View Guests";
            this.View_guests.Click += new System.EventHandler(this.View_guests_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Size = new System.Drawing.Size(150, 100);
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(240, 150);
            this.dataGridView2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Size = new System.Drawing.Size(150, 100);
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.reception_comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.venue_comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.pastor_comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.married_couple_comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.invintation_comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.guests_comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.total_records);
            this.splitContainer1.Panel2.Controls.Add(this.budget_comboBox);
            this.splitContainer1.Panel2.Controls.Add(this.Search);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1371, 525);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label5);
            this.splitContainer4.Panel1.Controls.Add(this.wedding_table_view);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Panel2.Controls.Add(this.label3);
            this.splitContainer4.Size = new System.Drawing.Size(1371, 381);
            this.splitContainer4.SplitterDistance = 256;
            this.splitContainer4.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(0, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "wedding table";
            // 
            // wedding_table_view
            // 
            this.wedding_table_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wedding_table_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wedding_table_view.Location = new System.Drawing.Point(0, 0);
            this.wedding_table_view.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wedding_table_view.Name = "wedding_table_view";
            this.wedding_table_view.RowHeadersWidth = 51;
            this.wedding_table_view.RowTemplate.Height = 24;
            this.wedding_table_view.Size = new System.Drawing.Size(256, 381);
            this.wedding_table_view.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.label6);
            this.splitContainer5.Panel1.Controls.Add(this.index_table_view);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.label7);
            this.splitContainer5.Panel2.Controls.Add(this.main_table_view);
            this.splitContainer5.Size = new System.Drawing.Size(1111, 381);
            this.splitContainer5.SplitterDistance = 165;
            this.splitContainer5.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(0, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Index table";
            // 
            // index_table_view
            // 
            this.index_table_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.index_table_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.index_table_view.Location = new System.Drawing.Point(0, 0);
            this.index_table_view.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.index_table_view.Name = "index_table_view";
            this.index_table_view.RowHeadersWidth = 51;
            this.index_table_view.RowTemplate.Height = 24;
            this.index_table_view.Size = new System.Drawing.Size(165, 381);
            this.index_table_view.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label7.Location = new System.Drawing.Point(0, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Main table";
            // 
            // main_table_view
            // 
            this.main_table_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.main_table_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_table_view.Location = new System.Drawing.Point(0, 0);
            this.main_table_view.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.main_table_view.Name = "main_table_view";
            this.main_table_view.RowHeadersWidth = 51;
            this.main_table_view.RowTemplate.Height = 24;
            this.main_table_view.Size = new System.Drawing.Size(942, 381);
            this.main_table_view.TabIndex = 0;
            this.main_table_view.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.main_table_view_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(751, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Index Table";
            // 
            // reception_comboBox
            // 
            this.reception_comboBox.FormattingEnabled = true;
            this.reception_comboBox.Items.AddRange(new object[] {
            "receptionist_type",
            "working_time",
            "buffet",
            "id_planner",
            "reports_to"});
            this.reception_comboBox.Location = new System.Drawing.Point(68, 30);
            this.reception_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reception_comboBox.Name = "reception_comboBox";
            this.reception_comboBox.Size = new System.Drawing.Size(168, 24);
            this.reception_comboBox.TabIndex = 12;
            // 
            // venue_comboBox
            // 
            this.venue_comboBox.FormattingEnabled = true;
            this.venue_comboBox.Items.AddRange(new object[] {
            "venue_name",
            "price_per_day",
            "description"});
            this.venue_comboBox.Location = new System.Drawing.Point(68, 30);
            this.venue_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.venue_comboBox.Name = "venue_comboBox";
            this.venue_comboBox.Size = new System.Drawing.Size(168, 24);
            this.venue_comboBox.TabIndex = 11;
            // 
            // pastor_comboBox
            // 
            this.pastor_comboBox.FormattingEnabled = true;
            this.pastor_comboBox.Items.AddRange(new object[] {
            "name",
            "surname",
            "price_per_ceremony",
            "church"});
            this.pastor_comboBox.Location = new System.Drawing.Point(68, 30);
            this.pastor_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pastor_comboBox.Name = "pastor_comboBox";
            this.pastor_comboBox.Size = new System.Drawing.Size(168, 24);
            this.pastor_comboBox.TabIndex = 10;
            // 
            // married_couple_comboBox
            // 
            this.married_couple_comboBox.FormattingEnabled = true;
            this.married_couple_comboBox.Items.AddRange(new object[] {
            "bride_name",
            "bride_surname",
            "groom_name",
            "groom_surname",
            "wedding_carriers"});
            this.married_couple_comboBox.Location = new System.Drawing.Point(68, 30);
            this.married_couple_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.married_couple_comboBox.Name = "married_couple_comboBox";
            this.married_couple_comboBox.Size = new System.Drawing.Size(168, 24);
            this.married_couple_comboBox.TabIndex = 9;
            // 
            // invintation_comboBox
            // 
            this.invintation_comboBox.FormattingEnabled = true;
            this.invintation_comboBox.Items.AddRange(new object[] {
            "invintation_text",
            "invintation_type",
            "recipient"});
            this.invintation_comboBox.Location = new System.Drawing.Point(68, 30);
            this.invintation_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.invintation_comboBox.Name = "invintation_comboBox";
            this.invintation_comboBox.Size = new System.Drawing.Size(168, 24);
            this.invintation_comboBox.TabIndex = 8;
            // 
            // guests_comboBox
            // 
            this.guests_comboBox.FormattingEnabled = true;
            this.guests_comboBox.Items.AddRange(new object[] {
            " name",
            " surname",
            " invintation_sent"});
            this.guests_comboBox.Location = new System.Drawing.Point(68, 30);
            this.guests_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guests_comboBox.Name = "guests_comboBox";
            this.guests_comboBox.Size = new System.Drawing.Size(168, 24);
            this.guests_comboBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1045, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total records:";
            // 
            // total_records
            // 
            this.total_records.Location = new System.Drawing.Point(1141, 22);
            this.total_records.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.total_records.Name = "total_records";
            this.total_records.Size = new System.Drawing.Size(175, 22);
            this.total_records.TabIndex = 5;
            // 
            // budget_comboBox
            // 
            this.budget_comboBox.FormattingEnabled = true;
            this.budget_comboBox.Items.AddRange(new object[] {
            "food_costs",
            "reception_cost",
            "venue_rent",
            "musician_costs",
            "total_costs"});
            this.budget_comboBox.Location = new System.Drawing.Point(68, 30);
            this.budget_comboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.budget_comboBox.Name = "budget_comboBox";
            this.budget_comboBox.Size = new System.Drawing.Size(168, 24);
            this.budget_comboBox.TabIndex = 4;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(68, 94);
            this.Search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(168, 22);
            this.Search.TabIndex = 3;
            this.Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Search";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Wedding_planner";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wedding_table_view)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.index_table_view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_table_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox table_list;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView main_table_view;
        private System.Windows.Forms.DataGridView index_table_view;
        private System.Windows.Forms.DataGridView wedding_table_view;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ComboBox budget_comboBox;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox total_records;
        private System.Windows.Forms.ComboBox pastor_comboBox;
        private System.Windows.Forms.ComboBox married_couple_comboBox;
        private System.Windows.Forms.ComboBox invintation_comboBox;
        private System.Windows.Forms.ComboBox guests_comboBox;
        private System.Windows.Forms.ComboBox reception_comboBox;
        private System.Windows.Forms.ComboBox venue_comboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton Create_wedding;
        private System.Windows.Forms.ToolStripButton View_guests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}


namespace CO_Driver
{
    partial class comparison_screen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_end_date = new System.Windows.Forms.DateTimePicker();
            this.dt_start_date = new System.Windows.Forms.DateTimePicker();
            this.cb_cabins = new System.Windows.Forms.ComboBox();
            this.btn_save_user_settings = new System.Windows.Forms.Button();
            this.cb_modules = new System.Windows.Forms.ComboBox();
            this.cb_versions = new System.Windows.Forms.ComboBox();
            this.cb_weapons = new System.Windows.Forms.ComboBox();
            this.cb_movement = new System.Windows.Forms.ComboBox();
            this.cb_power_score = new System.Windows.Forms.ComboBox();
            this.cb_grouped = new System.Windows.Forms.ComboBox();
            this.cb_game_modes = new System.Windows.Forms.ComboBox();
            this.lb_user_name = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ch_comparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbXaxis = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYaxis = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cbMinSampleSize = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.cbReturnLimit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMaximum = new System.Windows.Forms.Button();
            this.btnAverage = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            this.btnMinimum = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_comparison)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(-2, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "(Compare Grouped Performance Metrics)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dt_end_date
            // 
            this.dt_end_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_end_date.CalendarForeColor = System.Drawing.Color.Lime;
            this.dt_end_date.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dt_end_date.CalendarTitleBackColor = System.Drawing.Color.Black;
            this.dt_end_date.CalendarTitleForeColor = System.Drawing.Color.Lime;
            this.dt_end_date.CalendarTrailingForeColor = System.Drawing.Color.Lime;
            this.dt_end_date.Checked = false;
            this.dt_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_end_date.Location = new System.Drawing.Point(519, 31);
            this.dt_end_date.Name = "dt_end_date";
            this.dt_end_date.Size = new System.Drawing.Size(114, 22);
            this.dt_end_date.TabIndex = 71;
            // 
            // dt_start_date
            // 
            this.dt_start_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_start_date.CalendarForeColor = System.Drawing.Color.Lime;
            this.dt_start_date.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dt_start_date.CalendarTitleBackColor = System.Drawing.Color.Black;
            this.dt_start_date.CalendarTitleForeColor = System.Drawing.Color.Lime;
            this.dt_start_date.CalendarTrailingForeColor = System.Drawing.Color.Lime;
            this.dt_start_date.Checked = false;
            this.dt_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt_start_date.Location = new System.Drawing.Point(399, 31);
            this.dt_start_date.Name = "dt_start_date";
            this.dt_start_date.Size = new System.Drawing.Size(114, 22);
            this.dt_start_date.TabIndex = 70;
            this.dt_start_date.Value = new System.DateTime(2016, 4, 5, 0, 0, 0, 0);
            // 
            // cb_cabins
            // 
            this.cb_cabins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_cabins.BackColor = System.Drawing.Color.Black;
            this.cb_cabins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cabins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_cabins.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cabins.ForeColor = System.Drawing.Color.Lime;
            this.cb_cabins.FormattingEnabled = true;
            this.cb_cabins.Location = new System.Drawing.Point(639, 31);
            this.cb_cabins.MaxDropDownItems = 32;
            this.cb_cabins.Name = "cb_cabins";
            this.cb_cabins.Size = new System.Drawing.Size(136, 22);
            this.cb_cabins.TabIndex = 69;
            // 
            // btn_save_user_settings
            // 
            this.btn_save_user_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save_user_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_user_settings.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_user_settings.Location = new System.Drawing.Point(1062, 3);
            this.btn_save_user_settings.Name = "btn_save_user_settings";
            this.btn_save_user_settings.Size = new System.Drawing.Size(130, 22);
            this.btn_save_user_settings.TabIndex = 68;
            this.btn_save_user_settings.Text = "Reset";
            this.btn_save_user_settings.UseVisualStyleBackColor = true;
            // 
            // cb_modules
            // 
            this.cb_modules.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_modules.BackColor = System.Drawing.Color.Black;
            this.cb_modules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_modules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_modules.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_modules.ForeColor = System.Drawing.Color.Lime;
            this.cb_modules.FormattingEnabled = true;
            this.cb_modules.Location = new System.Drawing.Point(923, 31);
            this.cb_modules.MaxDropDownItems = 32;
            this.cb_modules.Name = "cb_modules";
            this.cb_modules.Size = new System.Drawing.Size(109, 22);
            this.cb_modules.TabIndex = 67;
            // 
            // cb_versions
            // 
            this.cb_versions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_versions.BackColor = System.Drawing.Color.Black;
            this.cb_versions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_versions.DropDownWidth = 280;
            this.cb_versions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_versions.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_versions.ForeColor = System.Drawing.Color.Lime;
            this.cb_versions.FormattingEnabled = true;
            this.cb_versions.Location = new System.Drawing.Point(399, 4);
            this.cb_versions.MaxDropDownItems = 32;
            this.cb_versions.Name = "cb_versions";
            this.cb_versions.Size = new System.Drawing.Size(234, 22);
            this.cb_versions.TabIndex = 66;
            // 
            // cb_weapons
            // 
            this.cb_weapons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_weapons.BackColor = System.Drawing.Color.Black;
            this.cb_weapons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_weapons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_weapons.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_weapons.ForeColor = System.Drawing.Color.Lime;
            this.cb_weapons.FormattingEnabled = true;
            this.cb_weapons.Location = new System.Drawing.Point(781, 31);
            this.cb_weapons.MaxDropDownItems = 32;
            this.cb_weapons.Name = "cb_weapons";
            this.cb_weapons.Size = new System.Drawing.Size(136, 22);
            this.cb_weapons.TabIndex = 65;
            // 
            // cb_movement
            // 
            this.cb_movement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_movement.BackColor = System.Drawing.Color.Black;
            this.cb_movement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_movement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_movement.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_movement.ForeColor = System.Drawing.Color.Lime;
            this.cb_movement.FormattingEnabled = true;
            this.cb_movement.Location = new System.Drawing.Point(1038, 31);
            this.cb_movement.MaxDropDownItems = 32;
            this.cb_movement.Name = "cb_movement";
            this.cb_movement.Size = new System.Drawing.Size(154, 22);
            this.cb_movement.TabIndex = 64;
            // 
            // cb_power_score
            // 
            this.cb_power_score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_power_score.BackColor = System.Drawing.Color.Black;
            this.cb_power_score.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_power_score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_power_score.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_power_score.ForeColor = System.Drawing.Color.Lime;
            this.cb_power_score.FormattingEnabled = true;
            this.cb_power_score.Location = new System.Drawing.Point(639, 3);
            this.cb_power_score.MaxDropDownItems = 32;
            this.cb_power_score.Name = "cb_power_score";
            this.cb_power_score.Size = new System.Drawing.Size(141, 22);
            this.cb_power_score.TabIndex = 63;
            // 
            // cb_grouped
            // 
            this.cb_grouped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_grouped.BackColor = System.Drawing.Color.Black;
            this.cb_grouped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_grouped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_grouped.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_grouped.ForeColor = System.Drawing.Color.Lime;
            this.cb_grouped.FormattingEnabled = true;
            this.cb_grouped.Location = new System.Drawing.Point(786, 3);
            this.cb_grouped.MaxDropDownItems = 32;
            this.cb_grouped.Name = "cb_grouped";
            this.cb_grouped.Size = new System.Drawing.Size(131, 22);
            this.cb_grouped.TabIndex = 62;
            // 
            // cb_game_modes
            // 
            this.cb_game_modes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_game_modes.BackColor = System.Drawing.Color.Black;
            this.cb_game_modes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_game_modes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_game_modes.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_game_modes.ForeColor = System.Drawing.Color.Lime;
            this.cb_game_modes.FormattingEnabled = true;
            this.cb_game_modes.Location = new System.Drawing.Point(923, 4);
            this.cb_game_modes.MaxDropDownItems = 32;
            this.cb_game_modes.Name = "cb_game_modes";
            this.cb_game_modes.Size = new System.Drawing.Size(133, 22);
            this.cb_game_modes.TabIndex = 61;
            // 
            // lb_user_name
            // 
            this.lb_user_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_user_name.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_user_name.Location = new System.Drawing.Point(-5, 0);
            this.lb_user_name.Name = "lb_user_name";
            this.lb_user_name.Size = new System.Drawing.Size(398, 40);
            this.lb_user_name.TabIndex = 60;
            this.lb_user_name.Text = "Performance Comparison";
            this.lb_user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ch_comparison, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1195, 542);
            this.tableLayoutPanel1.TabIndex = 73;
            // 
            // ch_comparison
            // 
            this.ch_comparison.BackImageTransparentColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.ch_comparison.ChartAreas.Add(chartArea1);
            this.ch_comparison.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.AutoFitMinFontSize = 5;
            legend1.Font = new System.Drawing.Font("Consolas", 8F);
            legend1.IsTextAutoFit = false;
            legend1.MaximumAutoSize = 20F;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch_comparison.Legends.Add(legend1);
            this.ch_comparison.Location = new System.Drawing.Point(3, 121);
            this.ch_comparison.Name = "ch_comparison";
            this.ch_comparison.Size = new System.Drawing.Size(1189, 418);
            this.ch_comparison.TabIndex = 4;
            this.ch_comparison.Text = "chart1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.Controls.Add(this.cbXaxis, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbYaxis, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1189, 75);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // cbXaxis
            // 
            this.cbXaxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbXaxis.BackColor = System.Drawing.Color.Black;
            this.cbXaxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbXaxis.DropDownWidth = 280;
            this.cbXaxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbXaxis.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXaxis.ForeColor = System.Drawing.Color.Lime;
            this.cbXaxis.FormattingEnabled = true;
            this.cbXaxis.Location = new System.Drawing.Point(502, 24);
            this.cbXaxis.MaxDropDownItems = 32;
            this.cbXaxis.Name = "cbXaxis";
            this.cbXaxis.Size = new System.Drawing.Size(291, 27);
            this.cbXaxis.TabIndex = 69;
            this.cbXaxis.SelectedIndexChanged += new System.EventHandler(this.cbXaxis_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(300, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 75);
            this.label2.TabIndex = 68;
            this.label2.Text = "Grouped By";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbYaxis
            // 
            this.cbYaxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbYaxis.BackColor = System.Drawing.Color.Black;
            this.cbYaxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYaxis.DropDownWidth = 280;
            this.cbYaxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYaxis.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYaxis.ForeColor = System.Drawing.Color.Lime;
            this.cbYaxis.FormattingEnabled = true;
            this.cbYaxis.Location = new System.Drawing.Point(3, 24);
            this.cbYaxis.MaxDropDownItems = 32;
            this.cbYaxis.Name = "cbYaxis";
            this.cbYaxis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbYaxis.Size = new System.Drawing.Size(291, 27);
            this.cbYaxis.TabIndex = 67;
            this.cbYaxis.SelectedIndexChanged += new System.EventHandler(this.cbYaxis_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(799, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(387, 69);
            this.tableLayoutPanel3.TabIndex = 70;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Controls.Add(this.cbMinSampleSize, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 37);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(381, 29);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // cbMinSampleSize
            // 
            this.cbMinSampleSize.BackColor = System.Drawing.Color.Black;
            this.cbMinSampleSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMinSampleSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMinSampleSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMinSampleSize.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMinSampleSize.ForeColor = System.Drawing.Color.Lime;
            this.cbMinSampleSize.FormattingEnabled = true;
            this.cbMinSampleSize.Location = new System.Drawing.Point(269, 3);
            this.cbMinSampleSize.MaxDropDownItems = 32;
            this.cbMinSampleSize.Name = "cbMinSampleSize";
            this.cbMinSampleSize.Size = new System.Drawing.Size(109, 21);
            this.cbMinSampleSize.TabIndex = 75;
            this.cbMinSampleSize.SelectedIndexChanged += new System.EventHandler(this.cbMinSampleSize_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 29);
            this.label4.TabIndex = 74;
            this.label4.Text = "Minimum Sample Size:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.cbReturnLimit, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(381, 28);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // cbReturnLimit
            // 
            this.cbReturnLimit.BackColor = System.Drawing.Color.Black;
            this.cbReturnLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbReturnLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReturnLimit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbReturnLimit.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReturnLimit.ForeColor = System.Drawing.Color.Lime;
            this.cbReturnLimit.FormattingEnabled = true;
            this.cbReturnLimit.Location = new System.Drawing.Point(269, 3);
            this.cbReturnLimit.MaxDropDownItems = 32;
            this.cbReturnLimit.Name = "cbReturnLimit";
            this.cbReturnLimit.Size = new System.Drawing.Size(109, 21);
            this.cbReturnLimit.TabIndex = 74;
            this.cbReturnLimit.SelectedIndexChanged += new System.EventHandler(this.cbReturnLimit_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 28);
            this.label3.TabIndex = 73;
            this.label3.Text = "Showing Top:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Controls.Add(this.btnMaximum, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnAverage, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnTotal, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnMinimum, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 84);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1189, 31);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // btnMaximum
            // 
            this.btnMaximum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaximum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximum.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximum.Location = new System.Drawing.Point(597, 3);
            this.btnMaximum.Name = "btnMaximum";
            this.btnMaximum.Size = new System.Drawing.Size(291, 25);
            this.btnMaximum.TabIndex = 72;
            this.btnMaximum.Text = "Maximum";
            this.btnMaximum.UseVisualStyleBackColor = true;
            this.btnMaximum.Click += new System.EventHandler(this.btnMaximum_Click);
            // 
            // btnAverage
            // 
            this.btnAverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAverage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAverage.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAverage.Location = new System.Drawing.Point(894, 3);
            this.btnAverage.Name = "btnAverage";
            this.btnAverage.Size = new System.Drawing.Size(292, 25);
            this.btnAverage.TabIndex = 71;
            this.btnAverage.Text = "Average";
            this.btnAverage.UseVisualStyleBackColor = true;
            this.btnAverage.Click += new System.EventHandler(this.btnAverage_Click);
            // 
            // btnTotal
            // 
            this.btnTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTotal.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotal.Location = new System.Drawing.Point(3, 3);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(291, 25);
            this.btnTotal.TabIndex = 70;
            this.btnTotal.Text = "Total";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // btnMinimum
            // 
            this.btnMinimum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMinimum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimum.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimum.Location = new System.Drawing.Point(300, 3);
            this.btnMinimum.Name = "btnMinimum";
            this.btnMinimum.Size = new System.Drawing.Size(291, 25);
            this.btnMinimum.TabIndex = 69;
            this.btnMinimum.Text = "Minimum";
            this.btnMinimum.UseVisualStyleBackColor = true;
            this.btnMinimum.Click += new System.EventHandler(this.btnMinimum_Click);
            // 
            // comparison_screen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt_end_date);
            this.Controls.Add(this.dt_start_date);
            this.Controls.Add(this.cb_cabins);
            this.Controls.Add(this.btn_save_user_settings);
            this.Controls.Add(this.cb_modules);
            this.Controls.Add(this.cb_versions);
            this.Controls.Add(this.cb_weapons);
            this.Controls.Add(this.cb_movement);
            this.Controls.Add(this.cb_power_score);
            this.Controls.Add(this.cb_grouped);
            this.Controls.Add(this.cb_game_modes);
            this.Controls.Add(this.lb_user_name);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.MinimumSize = new System.Drawing.Size(1195, 601);
            this.Name = "comparison_screen";
            this.Size = new System.Drawing.Size(1195, 601);
            this.Load += new System.EventHandler(this.comparison_screen_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_comparison)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_end_date;
        private System.Windows.Forms.DateTimePicker dt_start_date;
        private System.Windows.Forms.ComboBox cb_cabins;
        private System.Windows.Forms.Button btn_save_user_settings;
        private System.Windows.Forms.ComboBox cb_modules;
        private System.Windows.Forms.ComboBox cb_versions;
        private System.Windows.Forms.ComboBox cb_weapons;
        private System.Windows.Forms.ComboBox cb_movement;
        private System.Windows.Forms.ComboBox cb_power_score;
        private System.Windows.Forms.ComboBox cb_grouped;
        private System.Windows.Forms.ComboBox cb_game_modes;
        private System.Windows.Forms.Label lb_user_name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbXaxis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYaxis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ComboBox cbMinSampleSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox cbReturnLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_comparison;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnMaximum;
        private System.Windows.Forms.Button btnAverage;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Button btnMinimum;
    }
}

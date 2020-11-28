namespace XOPartOptimizer
{
    partial class user_settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_local_user_input = new System.Windows.Forms.TextBox();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chk_preserve_historical_data = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chk_beep_at_score = new System.Windows.Forms.CheckBox();
            this.num_min_beep_score = new System.Windows.Forms.NumericUpDown();
            this.num_engineer_level = new System.Windows.Forms.NumericUpDown();
            this.num_lunatic_level = new System.Windows.Forms.NumericUpDown();
            this.num_nomad_level = new System.Windows.Forms.NumericUpDown();
            this.num_scavenger_level = new System.Windows.Forms.NumericUpDown();
            this.num_steppenwolf_level = new System.Windows.Forms.NumericUpDown();
            this.num_dawns_children_level = new System.Windows.Forms.NumericUpDown();
            this.num_firestarter_level = new System.Windows.Forms.NumericUpDown();
            this.num_founders_level = new System.Windows.Forms.NumericUpDown();
            this.chk_prestigue_parts = new System.Windows.Forms.CheckBox();
            this.num_preserved_file_count = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_language_drop_down = new System.Windows.Forms.ComboBox();
            this.txt_log_file_location = new System.Windows.Forms.TextBox();
            this.txt_historic_log_location = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_min_beep_score)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_engineer_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_lunatic_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_nomad_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scavenger_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_steppenwolf_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_dawns_children_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_firestarter_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_founders_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_preserved_file_count)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(1169, 579);
            this.label1.TabIndex = 0;
            this.label1.Text = "USER SETTINGS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(3, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "In Game Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(3, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Log Files Location";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(3, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Preserve Historical Data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(3, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Historical File Location";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Lime;
            this.label6.Location = new System.Drawing.Point(3, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(266, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Max Preserved File Count (0 for none)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Lime;
            this.label13.Location = new System.Drawing.Point(588, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(161, 14);
            this.label13.TabIndex = 12;
            this.label13.Text = "Engineers Level (1-30)";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Lime;
            this.label14.Location = new System.Drawing.Point(588, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 14);
            this.label14.TabIndex = 13;
            this.label14.Text = "Lunatics Level (0-15)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Lime;
            this.label15.Location = new System.Drawing.Point(588, 175);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 14);
            this.label15.TabIndex = 14;
            this.label15.Text = "Nomads Level (0-15)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Lime;
            this.label16.Location = new System.Drawing.Point(588, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(168, 14);
            this.label16.TabIndex = 15;
            this.label16.Text = "Scavengers Level (0-15)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Lime;
            this.label17.Location = new System.Drawing.Point(588, 235);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(182, 14);
            this.label17.TabIndex = 16;
            this.label17.Text = "Steppenwolfs Level (0-15)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Lime;
            this.label18.Location = new System.Drawing.Point(588, 265);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(161, 14);
            this.label18.TabIndex = 17;
            this.label18.Text = "Dawn\'s Children (0-15)";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Lime;
            this.label19.Location = new System.Drawing.Point(588, 295);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 14);
            this.label19.TabIndex = 18;
            this.label19.Text = "Firestarters (0-15)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Lime;
            this.label20.Location = new System.Drawing.Point(588, 325);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 14);
            this.label20.TabIndex = 19;
            this.label20.Text = "Founders (0-75)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Lime;
            this.label21.Location = new System.Drawing.Point(588, 355);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(154, 14);
            this.label21.TabIndex = 20;
            this.label21.Text = "Prestigue/Pack Parts?";
            this.label21.Click += new System.EventHandler(this.label21_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Lime;
            this.label23.Location = new System.Drawing.Point(588, 85);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(49, 14);
            this.label23.TabIndex = 22;
            this.label23.Text = "Levels";
            // 
            // txt_local_user_input
            // 
            this.txt_local_user_input.BackColor = System.Drawing.Color.Black;
            this.txt_local_user_input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_local_user_input.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_local_user_input.ForeColor = System.Drawing.Color.Lime;
            this.txt_local_user_input.Location = new System.Drawing.Point(295, 77);
            this.txt_local_user_input.MaxLength = 32;
            this.txt_local_user_input.Name = "txt_local_user_input";
            this.txt_local_user_input.Size = new System.Drawing.Size(154, 22);
            this.txt_local_user_input.TabIndex = 1;
            this.txt_local_user_input.Text = "Rot_Fish_Bandit";
            this.txt_local_user_input.WordWrap = false;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // chk_preserve_historical_data
            // 
            this.chk_preserve_historical_data.AutoSize = true;
            this.chk_preserve_historical_data.Checked = true;
            this.chk_preserve_historical_data.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_preserve_historical_data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_preserve_historical_data.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_preserve_historical_data.ForeColor = System.Drawing.Color.Lime;
            this.chk_preserve_historical_data.Location = new System.Drawing.Point(297, 141);
            this.chk_preserve_historical_data.Name = "chk_preserve_historical_data";
            this.chk_preserve_historical_data.Size = new System.Drawing.Size(12, 11);
            this.chk_preserve_historical_data.TabIndex = 5;
            this.chk_preserve_historical_data.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(1, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "Beep at In Game Score";
            this.label7.Click += new System.EventHandler(this.label7_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(1, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "Minimum Score to Beep";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chk_beep_at_score
            // 
            this.chk_beep_at_score.AutoSize = true;
            this.chk_beep_at_score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_beep_at_score.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_beep_at_score.ForeColor = System.Drawing.Color.Lime;
            this.chk_beep_at_score.Location = new System.Drawing.Point(295, 261);
            this.chk_beep_at_score.Name = "chk_beep_at_score";
            this.chk_beep_at_score.Size = new System.Drawing.Size(12, 11);
            this.chk_beep_at_score.TabIndex = 25;
            this.chk_beep_at_score.UseVisualStyleBackColor = true;
            // 
            // num_min_beep_score
            // 
            this.num_min_beep_score.BackColor = System.Drawing.Color.Black;
            this.num_min_beep_score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_min_beep_score.ForeColor = System.Drawing.Color.Lime;
            this.num_min_beep_score.Location = new System.Drawing.Point(295, 281);
            this.num_min_beep_score.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_min_beep_score.Name = "num_min_beep_score";
            this.num_min_beep_score.Size = new System.Drawing.Size(240, 22);
            this.num_min_beep_score.TabIndex = 26;
            this.num_min_beep_score.ThousandsSeparator = true;
            this.num_min_beep_score.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // num_engineer_level
            // 
            this.num_engineer_level.BackColor = System.Drawing.Color.Black;
            this.num_engineer_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_engineer_level.ForeColor = System.Drawing.Color.Lime;
            this.num_engineer_level.Location = new System.Drawing.Point(894, 107);
            this.num_engineer_level.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.num_engineer_level.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_engineer_level.Name = "num_engineer_level";
            this.num_engineer_level.Size = new System.Drawing.Size(240, 22);
            this.num_engineer_level.TabIndex = 27;
            this.num_engineer_level.ThousandsSeparator = true;
            this.num_engineer_level.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // num_lunatic_level
            // 
            this.num_lunatic_level.BackColor = System.Drawing.Color.Black;
            this.num_lunatic_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_lunatic_level.ForeColor = System.Drawing.Color.Lime;
            this.num_lunatic_level.Location = new System.Drawing.Point(894, 137);
            this.num_lunatic_level.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_lunatic_level.Name = "num_lunatic_level";
            this.num_lunatic_level.Size = new System.Drawing.Size(240, 22);
            this.num_lunatic_level.TabIndex = 28;
            this.num_lunatic_level.ThousandsSeparator = true;
            this.num_lunatic_level.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // num_nomad_level
            // 
            this.num_nomad_level.BackColor = System.Drawing.Color.Black;
            this.num_nomad_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_nomad_level.ForeColor = System.Drawing.Color.Lime;
            this.num_nomad_level.Location = new System.Drawing.Point(894, 167);
            this.num_nomad_level.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_nomad_level.Name = "num_nomad_level";
            this.num_nomad_level.Size = new System.Drawing.Size(240, 22);
            this.num_nomad_level.TabIndex = 29;
            this.num_nomad_level.ThousandsSeparator = true;
            this.num_nomad_level.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // num_scavenger_level
            // 
            this.num_scavenger_level.BackColor = System.Drawing.Color.Black;
            this.num_scavenger_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_scavenger_level.ForeColor = System.Drawing.Color.Lime;
            this.num_scavenger_level.Location = new System.Drawing.Point(894, 197);
            this.num_scavenger_level.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_scavenger_level.Name = "num_scavenger_level";
            this.num_scavenger_level.Size = new System.Drawing.Size(240, 22);
            this.num_scavenger_level.TabIndex = 30;
            this.num_scavenger_level.ThousandsSeparator = true;
            this.num_scavenger_level.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // num_steppenwolf_level
            // 
            this.num_steppenwolf_level.BackColor = System.Drawing.Color.Black;
            this.num_steppenwolf_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_steppenwolf_level.ForeColor = System.Drawing.Color.Lime;
            this.num_steppenwolf_level.Location = new System.Drawing.Point(894, 227);
            this.num_steppenwolf_level.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_steppenwolf_level.Name = "num_steppenwolf_level";
            this.num_steppenwolf_level.Size = new System.Drawing.Size(240, 22);
            this.num_steppenwolf_level.TabIndex = 31;
            this.num_steppenwolf_level.ThousandsSeparator = true;
            this.num_steppenwolf_level.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // num_dawns_children_level
            // 
            this.num_dawns_children_level.BackColor = System.Drawing.Color.Black;
            this.num_dawns_children_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_dawns_children_level.ForeColor = System.Drawing.Color.Lime;
            this.num_dawns_children_level.Location = new System.Drawing.Point(894, 258);
            this.num_dawns_children_level.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_dawns_children_level.Name = "num_dawns_children_level";
            this.num_dawns_children_level.Size = new System.Drawing.Size(240, 22);
            this.num_dawns_children_level.TabIndex = 32;
            this.num_dawns_children_level.ThousandsSeparator = true;
            this.num_dawns_children_level.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // num_firestarter_level
            // 
            this.num_firestarter_level.BackColor = System.Drawing.Color.Black;
            this.num_firestarter_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_firestarter_level.ForeColor = System.Drawing.Color.Lime;
            this.num_firestarter_level.Location = new System.Drawing.Point(894, 293);
            this.num_firestarter_level.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.num_firestarter_level.Name = "num_firestarter_level";
            this.num_firestarter_level.Size = new System.Drawing.Size(240, 22);
            this.num_firestarter_level.TabIndex = 33;
            this.num_firestarter_level.ThousandsSeparator = true;
            this.num_firestarter_level.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // num_founders_level
            // 
            this.num_founders_level.BackColor = System.Drawing.Color.Black;
            this.num_founders_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_founders_level.ForeColor = System.Drawing.Color.Lime;
            this.num_founders_level.Location = new System.Drawing.Point(894, 323);
            this.num_founders_level.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.num_founders_level.Name = "num_founders_level";
            this.num_founders_level.Size = new System.Drawing.Size(240, 22);
            this.num_founders_level.TabIndex = 34;
            this.num_founders_level.ThousandsSeparator = true;
            this.num_founders_level.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // chk_prestigue_parts
            // 
            this.chk_prestigue_parts.AutoSize = true;
            this.chk_prestigue_parts.Checked = true;
            this.chk_prestigue_parts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_prestigue_parts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_prestigue_parts.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_prestigue_parts.ForeColor = System.Drawing.Color.Lime;
            this.chk_prestigue_parts.Location = new System.Drawing.Point(894, 358);
            this.chk_prestigue_parts.Name = "chk_prestigue_parts";
            this.chk_prestigue_parts.Size = new System.Drawing.Size(12, 11);
            this.chk_prestigue_parts.TabIndex = 35;
            this.chk_prestigue_parts.UseVisualStyleBackColor = true;
            // 
            // num_preserved_file_count
            // 
            this.num_preserved_file_count.BackColor = System.Drawing.Color.Black;
            this.num_preserved_file_count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.num_preserved_file_count.ForeColor = System.Drawing.Color.Lime;
            this.num_preserved_file_count.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_preserved_file_count.Location = new System.Drawing.Point(297, 197);
            this.num_preserved_file_count.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_preserved_file_count.Name = "num_preserved_file_count";
            this.num_preserved_file_count.Size = new System.Drawing.Size(240, 22);
            this.num_preserved_file_count.TabIndex = 36;
            this.num_preserved_file_count.ThousandsSeparator = true;
            this.num_preserved_file_count.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(3, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 37;
            this.label9.Text = "Language";
            // 
            // cmb_language_drop_down
            // 
            this.cmb_language_drop_down.BackColor = System.Drawing.Color.Black;
            this.cmb_language_drop_down.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_language_drop_down.ForeColor = System.Drawing.Color.Lime;
            this.cmb_language_drop_down.IntegralHeight = false;
            this.cmb_language_drop_down.Items.AddRange(new object[] {
            "English",
            "Español",
            "Pусский"});
            this.cmb_language_drop_down.Location = new System.Drawing.Point(295, 226);
            this.cmb_language_drop_down.MaxDropDownItems = 3;
            this.cmb_language_drop_down.Name = "cmb_language_drop_down";
            this.cmb_language_drop_down.Size = new System.Drawing.Size(242, 22);
            this.cmb_language_drop_down.TabIndex = 38;
            // 
            // txt_log_file_location
            // 
            this.txt_log_file_location.BackColor = System.Drawing.Color.Black;
            this.txt_log_file_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_log_file_location.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_log_file_location.ForeColor = System.Drawing.Color.Lime;
            this.txt_log_file_location.Location = new System.Drawing.Point(295, 107);
            this.txt_log_file_location.MaxLength = 256;
            this.txt_log_file_location.Name = "txt_log_file_location";
            this.txt_log_file_location.Size = new System.Drawing.Size(240, 22);
            this.txt_log_file_location.TabIndex = 39;
            this.txt_log_file_location.Text = "C:\\Users\\morgh_000.000\\Documents\\my games\\Crossout\\logs";
            this.txt_log_file_location.WordWrap = false;
            // 
            // txt_historic_log_location
            // 
            this.txt_historic_log_location.BackColor = System.Drawing.Color.Black;
            this.txt_historic_log_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_historic_log_location.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_historic_log_location.ForeColor = System.Drawing.Color.Lime;
            this.txt_historic_log_location.Location = new System.Drawing.Point(295, 167);
            this.txt_historic_log_location.MaxLength = 256;
            this.txt_historic_log_location.Name = "txt_historic_log_location";
            this.txt_historic_log_location.Size = new System.Drawing.Size(240, 22);
            this.txt_historic_log_location.TabIndex = 40;
            this.txt_historic_log_location.Text = "C:\\Users\\morgh_000.000\\Desktop\\screen_element_loc\\historic_logs";
            this.txt_historic_log_location.WordWrap = false;
            // 
            // user_settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.txt_historic_log_location);
            this.Controls.Add(this.txt_log_file_location);
            this.Controls.Add(this.cmb_language_drop_down);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.num_preserved_file_count);
            this.Controls.Add(this.chk_prestigue_parts);
            this.Controls.Add(this.num_founders_level);
            this.Controls.Add(this.num_firestarter_level);
            this.Controls.Add(this.num_dawns_children_level);
            this.Controls.Add(this.num_steppenwolf_level);
            this.Controls.Add(this.num_scavenger_level);
            this.Controls.Add(this.num_nomad_level);
            this.Controls.Add(this.num_lunatic_level);
            this.Controls.Add(this.num_engineer_level);
            this.Controls.Add(this.num_min_beep_score);
            this.Controls.Add(this.chk_beep_at_score);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chk_preserve_historical_data);
            this.Controls.Add(this.txt_local_user_input);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "user_settings";
            this.Size = new System.Drawing.Size(1169, 579);
            ((System.ComponentModel.ISupportInitialize)(this.num_min_beep_score)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_engineer_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_lunatic_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_nomad_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scavenger_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_steppenwolf_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_dawns_children_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_firestarter_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_founders_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_preserved_file_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_local_user_input;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chk_preserve_historical_data;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chk_beep_at_score;
        private System.Windows.Forms.NumericUpDown num_min_beep_score;
        private System.Windows.Forms.NumericUpDown num_engineer_level;
        private System.Windows.Forms.NumericUpDown num_lunatic_level;
        private System.Windows.Forms.NumericUpDown num_nomad_level;
        private System.Windows.Forms.NumericUpDown num_scavenger_level;
        private System.Windows.Forms.NumericUpDown num_steppenwolf_level;
        private System.Windows.Forms.NumericUpDown num_dawns_children_level;
        private System.Windows.Forms.NumericUpDown num_firestarter_level;
        private System.Windows.Forms.NumericUpDown num_founders_level;
        private System.Windows.Forms.CheckBox chk_prestigue_parts;
        private System.Windows.Forms.NumericUpDown num_preserved_file_count;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_language_drop_down;
        private System.Windows.Forms.TextBox txt_log_file_location;
        private System.Windows.Forms.TextBox txt_historic_log_location;
    }
}

namespace CO_Driver
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.num_engineer_level = new System.Windows.Forms.NumericUpDown();
            this.num_lunatic_level = new System.Windows.Forms.NumericUpDown();
            this.num_nomad_level = new System.Windows.Forms.NumericUpDown();
            this.num_scavenger_level = new System.Windows.Forms.NumericUpDown();
            this.num_steppenwolf_level = new System.Windows.Forms.NumericUpDown();
            this.num_dawns_children_level = new System.Windows.Forms.NumericUpDown();
            this.num_firestarter_level = new System.Windows.Forms.NumericUpDown();
            this.num_founders_level = new System.Windows.Forms.NumericUpDown();
            this.chk_prestigue_parts = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_language_drop_down = new System.Windows.Forms.ComboBox();
            this.txt_log_file_location = new System.Windows.Forms.TextBox();
            this.btn_save_user_settings = new System.Windows.Forms.Button();
            this.btn_default_user_settings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_twitch_mode = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_historic_log_location = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_engineer_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_lunatic_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_nomad_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scavenger_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_steppenwolf_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_dawns_children_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_firestarter_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_founders_level)).BeginInit();
            this.SuspendLayout();
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
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(3, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Historical File Location";
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
            this.txt_local_user_input.Enabled = false;
            this.txt_local_user_input.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_local_user_input.ForeColor = System.Drawing.Color.Lime;
            this.txt_local_user_input.Location = new System.Drawing.Point(295, 77);
            this.txt_local_user_input.MaxLength = 32;
            this.txt_local_user_input.Name = "txt_local_user_input";
            this.txt_local_user_input.Size = new System.Drawing.Size(154, 22);
            this.txt_local_user_input.TabIndex = 1;
            this.txt_local_user_input.WordWrap = false;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Lime;
            this.label9.Location = new System.Drawing.Point(3, 205);
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
            this.cmb_language_drop_down.Location = new System.Drawing.Point(293, 197);
            this.cmb_language_drop_down.MaxDropDownItems = 3;
            this.cmb_language_drop_down.Name = "cmb_language_drop_down";
            this.cmb_language_drop_down.Size = new System.Drawing.Size(242, 22);
            this.cmb_language_drop_down.TabIndex = 38;
            // 
            // txt_log_file_location
            // 
            this.txt_log_file_location.BackColor = System.Drawing.Color.Black;
            this.txt_log_file_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_log_file_location.Enabled = false;
            this.txt_log_file_location.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_log_file_location.ForeColor = System.Drawing.Color.Lime;
            this.txt_log_file_location.Location = new System.Drawing.Point(295, 107);
            this.txt_log_file_location.MaxLength = 256;
            this.txt_log_file_location.Name = "txt_log_file_location";
            this.txt_log_file_location.Size = new System.Drawing.Size(240, 22);
            this.txt_log_file_location.TabIndex = 39;
            this.txt_log_file_location.WordWrap = false;
            // 
            // btn_save_user_settings
            // 
            this.btn_save_user_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_user_settings.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_user_settings.Location = new System.Drawing.Point(928, 548);
            this.btn_save_user_settings.Name = "btn_save_user_settings";
            this.btn_save_user_settings.Size = new System.Drawing.Size(206, 34);
            this.btn_save_user_settings.TabIndex = 41;
            this.btn_save_user_settings.Text = "Save User Settings";
            this.btn_save_user_settings.UseVisualStyleBackColor = true;
            this.btn_save_user_settings.Click += new System.EventHandler(this.save_user_settings);
            // 
            // btn_default_user_settings
            // 
            this.btn_default_user_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_default_user_settings.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_default_user_settings.Location = new System.Drawing.Point(828, 548);
            this.btn_default_user_settings.Name = "btn_default_user_settings";
            this.btn_default_user_settings.Size = new System.Drawing.Size(94, 34);
            this.btn_default_user_settings.TabIndex = 42;
            this.btn_default_user_settings.Text = "Default";
            this.btn_default_user_settings.UseVisualStyleBackColor = true;
            this.btn_default_user_settings.Click += new System.EventHandler(this.restore_default_settings);
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
            this.label1.Size = new System.Drawing.Size(1169, 601);
            this.label1.TabIndex = 0;
            this.label1.Text = "USER SETTINGS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chk_twitch_mode
            // 
            this.chk_twitch_mode.AutoSize = true;
            this.chk_twitch_mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_twitch_mode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_twitch_mode.ForeColor = System.Drawing.Color.Lime;
            this.chk_twitch_mode.Location = new System.Drawing.Point(295, 171);
            this.chk_twitch_mode.Name = "chk_twitch_mode";
            this.chk_twitch_mode.Size = new System.Drawing.Size(12, 11);
            this.chk_twitch_mode.TabIndex = 43;
            this.chk_twitch_mode.UseVisualStyleBackColor = true;
            this.chk_twitch_mode.CheckedChanged += new System.EventHandler(this.chk_twitch_mode_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(2, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 14);
            this.label10.TabIndex = 44;
            this.label10.Text = "Twitch/YT Streaming Mode";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txt_historic_log_location
            // 
            this.txt_historic_log_location.BackColor = System.Drawing.Color.Black;
            this.txt_historic_log_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_historic_log_location.Enabled = false;
            this.txt_historic_log_location.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_historic_log_location.ForeColor = System.Drawing.Color.Lime;
            this.txt_historic_log_location.Location = new System.Drawing.Point(295, 135);
            this.txt_historic_log_location.MaxLength = 256;
            this.txt_historic_log_location.Name = "txt_historic_log_location";
            this.txt_historic_log_location.Size = new System.Drawing.Size(240, 22);
            this.txt_historic_log_location.TabIndex = 40;
            this.txt_historic_log_location.WordWrap = false;
            // 
            // user_settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chk_twitch_mode);
            this.Controls.Add(this.btn_default_user_settings);
            this.Controls.Add(this.btn_save_user_settings);
            this.Controls.Add(this.txt_historic_log_location);
            this.Controls.Add(this.txt_log_file_location);
            this.Controls.Add(this.cmb_language_drop_down);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.chk_prestigue_parts);
            this.Controls.Add(this.num_founders_level);
            this.Controls.Add(this.num_firestarter_level);
            this.Controls.Add(this.num_dawns_children_level);
            this.Controls.Add(this.num_steppenwolf_level);
            this.Controls.Add(this.num_scavenger_level);
            this.Controls.Add(this.num_nomad_level);
            this.Controls.Add(this.num_lunatic_level);
            this.Controls.Add(this.num_engineer_level);
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
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "user_settings";
            this.Size = new System.Drawing.Size(1169, 601);
            ((System.ComponentModel.ISupportInitialize)(this.num_engineer_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_lunatic_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_nomad_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_scavenger_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_steppenwolf_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_dawns_children_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_firestarter_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_founders_level)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown num_engineer_level;
        private System.Windows.Forms.NumericUpDown num_lunatic_level;
        private System.Windows.Forms.NumericUpDown num_nomad_level;
        private System.Windows.Forms.NumericUpDown num_scavenger_level;
        private System.Windows.Forms.NumericUpDown num_steppenwolf_level;
        private System.Windows.Forms.NumericUpDown num_dawns_children_level;
        private System.Windows.Forms.NumericUpDown num_firestarter_level;
        private System.Windows.Forms.NumericUpDown num_founders_level;
        private System.Windows.Forms.CheckBox chk_prestigue_parts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_language_drop_down;
        private System.Windows.Forms.TextBox txt_log_file_location;
        private System.Windows.Forms.Button btn_save_user_settings;
        private System.Windows.Forms.Button btn_default_user_settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_twitch_mode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_historic_log_location;
    }
}

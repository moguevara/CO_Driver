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
            System.DirectoryServices.SortOption sortOption2 = new System.DirectoryServices.SortOption();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            num_engineer_level = new System.Windows.Forms.NumericUpDown();
            num_lunatic_level = new System.Windows.Forms.NumericUpDown();
            num_nomad_level = new System.Windows.Forms.NumericUpDown();
            num_scavenger_level = new System.Windows.Forms.NumericUpDown();
            num_steppenwolf_level = new System.Windows.Forms.NumericUpDown();
            num_dawns_children_level = new System.Windows.Forms.NumericUpDown();
            num_firestarter_level = new System.Windows.Forms.NumericUpDown();
            num_founders_level = new System.Windows.Forms.NumericUpDown();
            chk_prestigue_parts = new System.Windows.Forms.CheckBox();
            label9 = new System.Windows.Forms.Label();
            cmb_language_drop_down = new System.Windows.Forms.ComboBox();
            txt_log_file_location = new System.Windows.Forms.TextBox();
            btn_save_user_settings = new System.Windows.Forms.Button();
            btn_default_user_settings = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            chk_twitch_mode = new System.Windows.Forms.CheckBox();
            label10 = new System.Windows.Forms.Label();
            txt_historic_log_location = new System.Windows.Forms.TextBox();
            cmb_themes = new System.Windows.Forms.ComboBox();
            label4 = new System.Windows.Forms.Label();
            tb_theme_warning = new System.Windows.Forms.TextBox();
            chk_save_screen_shots = new System.Windows.Forms.CheckBox();
            label6 = new System.Windows.Forms.Label();
            cmb_user_names = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            chk_group_ram = new System.Windows.Forms.CheckBox();
            button1 = new System.Windows.Forms.Button();
            label11 = new System.Windows.Forms.Label();
            chk_upload_post_match = new System.Windows.Forms.CheckBox();
            label8 = new System.Windows.Forms.Label();
            chk_update = new System.Windows.Forms.CheckBox();
            cmb_fullscreen_monitor = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)num_engineer_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_lunatic_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_nomad_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_scavenger_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_steppenwolf_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_dawns_children_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_firestarter_level).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_founders_level).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.Lime;
            label2.Location = new System.Drawing.Point(3, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(119, 14);
            label2.TabIndex = 1;
            label2.Text = "In Game Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.ForeColor = System.Drawing.Color.Lime;
            label3.Location = new System.Drawing.Point(3, 115);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(196, 14);
            label3.TabIndex = 2;
            label3.Text = "Crossout Log Files Location";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.Lime;
            label5.Location = new System.Drawing.Point(3, 143);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(210, 14);
            label5.TabIndex = 4;
            label5.Text = "CO_Driver Saved File Location";
            // 
            // label13
            // 
            label13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label13.ForeColor = System.Drawing.Color.Lime;
            label13.Location = new System.Drawing.Point(637, 115);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(161, 14);
            label13.TabIndex = 12;
            label13.Text = "Engineers Level (1-30)";
            // 
            // label14
            // 
            label14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label14.ForeColor = System.Drawing.Color.Lime;
            label14.Location = new System.Drawing.Point(637, 145);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(154, 14);
            label14.TabIndex = 13;
            label14.Text = "Lunatics Level (0-15)";
            // 
            // label15
            // 
            label15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label15.ForeColor = System.Drawing.Color.Lime;
            label15.Location = new System.Drawing.Point(637, 175);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(140, 14);
            label15.TabIndex = 14;
            label15.Text = "Nomads Level (0-15)";
            // 
            // label16
            // 
            label16.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label16.ForeColor = System.Drawing.Color.Lime;
            label16.Location = new System.Drawing.Point(637, 205);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(168, 14);
            label16.TabIndex = 15;
            label16.Text = "Scavengers Level (0-15)";
            // 
            // label17
            // 
            label17.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label17.ForeColor = System.Drawing.Color.Lime;
            label17.Location = new System.Drawing.Point(637, 235);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(182, 14);
            label17.TabIndex = 16;
            label17.Text = "Steppenwolfs Level (0-15)";
            // 
            // label18
            // 
            label18.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label18.AutoSize = true;
            label18.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label18.ForeColor = System.Drawing.Color.Lime;
            label18.Location = new System.Drawing.Point(637, 265);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(161, 14);
            label18.TabIndex = 17;
            label18.Text = "Dawn's Children (0-15)";
            // 
            // label19
            // 
            label19.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label19.ForeColor = System.Drawing.Color.Lime;
            label19.Location = new System.Drawing.Point(637, 295);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(140, 14);
            label19.TabIndex = 18;
            label19.Text = "Firestarters (0-15)";
            // 
            // label20
            // 
            label20.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label20.AutoSize = true;
            label20.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label20.ForeColor = System.Drawing.Color.Lime;
            label20.Location = new System.Drawing.Point(637, 325);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(112, 14);
            label20.TabIndex = 19;
            label20.Text = "Founders (0-75)";
            // 
            // label21
            // 
            label21.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label21.AutoSize = true;
            label21.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label21.ForeColor = System.Drawing.Color.Lime;
            label21.Location = new System.Drawing.Point(637, 355);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(147, 14);
            label21.TabIndex = 20;
            label21.Text = "Prestige/Pack Parts?";
            // 
            // label23
            // 
            label23.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label23.AutoSize = true;
            label23.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label23.ForeColor = System.Drawing.Color.Lime;
            label23.Location = new System.Drawing.Point(637, 85);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(49, 14);
            label23.TabIndex = 22;
            label23.Text = "Levels";
            // 
            // directorySearcher1
            // 
            directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            directorySearcher1.Sort = sortOption2;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // num_engineer_level
            // 
            num_engineer_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_engineer_level.BackColor = System.Drawing.Color.Black;
            num_engineer_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_engineer_level.ForeColor = System.Drawing.Color.Lime;
            num_engineer_level.Location = new System.Drawing.Point(943, 107);
            num_engineer_level.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            num_engineer_level.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_engineer_level.Name = "num_engineer_level";
            num_engineer_level.Size = new System.Drawing.Size(240, 22);
            num_engineer_level.TabIndex = 27;
            num_engineer_level.ThousandsSeparator = true;
            num_engineer_level.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // num_lunatic_level
            // 
            num_lunatic_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_lunatic_level.BackColor = System.Drawing.Color.Black;
            num_lunatic_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_lunatic_level.ForeColor = System.Drawing.Color.Lime;
            num_lunatic_level.Location = new System.Drawing.Point(943, 137);
            num_lunatic_level.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            num_lunatic_level.Name = "num_lunatic_level";
            num_lunatic_level.Size = new System.Drawing.Size(240, 22);
            num_lunatic_level.TabIndex = 28;
            num_lunatic_level.ThousandsSeparator = true;
            num_lunatic_level.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // num_nomad_level
            // 
            num_nomad_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_nomad_level.BackColor = System.Drawing.Color.Black;
            num_nomad_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_nomad_level.ForeColor = System.Drawing.Color.Lime;
            num_nomad_level.Location = new System.Drawing.Point(943, 167);
            num_nomad_level.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            num_nomad_level.Name = "num_nomad_level";
            num_nomad_level.Size = new System.Drawing.Size(240, 22);
            num_nomad_level.TabIndex = 29;
            num_nomad_level.ThousandsSeparator = true;
            num_nomad_level.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // num_scavenger_level
            // 
            num_scavenger_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_scavenger_level.BackColor = System.Drawing.Color.Black;
            num_scavenger_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_scavenger_level.ForeColor = System.Drawing.Color.Lime;
            num_scavenger_level.Location = new System.Drawing.Point(943, 197);
            num_scavenger_level.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            num_scavenger_level.Name = "num_scavenger_level";
            num_scavenger_level.Size = new System.Drawing.Size(240, 22);
            num_scavenger_level.TabIndex = 30;
            num_scavenger_level.ThousandsSeparator = true;
            num_scavenger_level.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // num_steppenwolf_level
            // 
            num_steppenwolf_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_steppenwolf_level.BackColor = System.Drawing.Color.Black;
            num_steppenwolf_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_steppenwolf_level.ForeColor = System.Drawing.Color.Lime;
            num_steppenwolf_level.Location = new System.Drawing.Point(943, 227);
            num_steppenwolf_level.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            num_steppenwolf_level.Name = "num_steppenwolf_level";
            num_steppenwolf_level.Size = new System.Drawing.Size(240, 22);
            num_steppenwolf_level.TabIndex = 31;
            num_steppenwolf_level.ThousandsSeparator = true;
            num_steppenwolf_level.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // num_dawns_children_level
            // 
            num_dawns_children_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_dawns_children_level.BackColor = System.Drawing.Color.Black;
            num_dawns_children_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_dawns_children_level.ForeColor = System.Drawing.Color.Lime;
            num_dawns_children_level.Location = new System.Drawing.Point(943, 258);
            num_dawns_children_level.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            num_dawns_children_level.Name = "num_dawns_children_level";
            num_dawns_children_level.Size = new System.Drawing.Size(240, 22);
            num_dawns_children_level.TabIndex = 32;
            num_dawns_children_level.ThousandsSeparator = true;
            num_dawns_children_level.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // num_firestarter_level
            // 
            num_firestarter_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_firestarter_level.BackColor = System.Drawing.Color.Black;
            num_firestarter_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_firestarter_level.ForeColor = System.Drawing.Color.Lime;
            num_firestarter_level.Location = new System.Drawing.Point(943, 293);
            num_firestarter_level.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            num_firestarter_level.Name = "num_firestarter_level";
            num_firestarter_level.Size = new System.Drawing.Size(240, 22);
            num_firestarter_level.TabIndex = 33;
            num_firestarter_level.ThousandsSeparator = true;
            num_firestarter_level.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // num_founders_level
            // 
            num_founders_level.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_founders_level.BackColor = System.Drawing.Color.Black;
            num_founders_level.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            num_founders_level.ForeColor = System.Drawing.Color.Lime;
            num_founders_level.Location = new System.Drawing.Point(943, 323);
            num_founders_level.Maximum = new decimal(new int[] { 75, 0, 0, 0 });
            num_founders_level.Name = "num_founders_level";
            num_founders_level.Size = new System.Drawing.Size(240, 22);
            num_founders_level.TabIndex = 34;
            num_founders_level.ThousandsSeparator = true;
            num_founders_level.Value = new decimal(new int[] { 75, 0, 0, 0 });
            // 
            // chk_prestigue_parts
            // 
            chk_prestigue_parts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chk_prestigue_parts.AutoSize = true;
            chk_prestigue_parts.Checked = true;
            chk_prestigue_parts.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_prestigue_parts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chk_prestigue_parts.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chk_prestigue_parts.ForeColor = System.Drawing.Color.Lime;
            chk_prestigue_parts.Location = new System.Drawing.Point(945, 358);
            chk_prestigue_parts.Name = "chk_prestigue_parts";
            chk_prestigue_parts.Size = new System.Drawing.Size(12, 11);
            chk_prestigue_parts.TabIndex = 35;
            chk_prestigue_parts.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label9.ForeColor = System.Drawing.Color.Lime;
            label9.Location = new System.Drawing.Point(3, 244);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(63, 14);
            label9.TabIndex = 37;
            label9.Text = "Language";
            // 
            // cmb_language_drop_down
            // 
            cmb_language_drop_down.BackColor = System.Drawing.Color.Black;
            cmb_language_drop_down.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_language_drop_down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmb_language_drop_down.ForeColor = System.Drawing.Color.Lime;
            cmb_language_drop_down.IntegralHeight = false;
            cmb_language_drop_down.Items.AddRange(new object[] { "English", "Pусский", "Deutsch", "Español", "Français", "हिन्दी", "Polski", "한국어", "Ελληνικά", "简体中文", "繁體中文" });
            cmb_language_drop_down.Location = new System.Drawing.Point(293, 236);
            cmb_language_drop_down.MaxDropDownItems = 10;
            cmb_language_drop_down.Name = "cmb_language_drop_down";
            cmb_language_drop_down.Size = new System.Drawing.Size(242, 22);
            cmb_language_drop_down.TabIndex = 38;
            // 
            // txt_log_file_location
            // 
            txt_log_file_location.BackColor = System.Drawing.Color.Black;
            txt_log_file_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_log_file_location.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txt_log_file_location.ForeColor = System.Drawing.Color.Lime;
            txt_log_file_location.Location = new System.Drawing.Point(295, 107);
            txt_log_file_location.MaxLength = 256;
            txt_log_file_location.Name = "txt_log_file_location";
            txt_log_file_location.Size = new System.Drawing.Size(240, 22);
            txt_log_file_location.TabIndex = 39;
            txt_log_file_location.WordWrap = false;
            // 
            // btn_save_user_settings
            // 
            btn_save_user_settings.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_save_user_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_save_user_settings.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn_save_user_settings.Location = new System.Drawing.Point(977, 548);
            btn_save_user_settings.Name = "btn_save_user_settings";
            btn_save_user_settings.Size = new System.Drawing.Size(206, 34);
            btn_save_user_settings.TabIndex = 41;
            btn_save_user_settings.Text = "Save User Settings";
            btn_save_user_settings.UseVisualStyleBackColor = true;
            btn_save_user_settings.Click += save_user_settings;
            // 
            // btn_default_user_settings
            // 
            btn_default_user_settings.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_default_user_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_default_user_settings.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn_default_user_settings.Location = new System.Drawing.Point(765, 548);
            btn_default_user_settings.Name = "btn_default_user_settings";
            btn_default_user_settings.Size = new System.Drawing.Size(206, 34);
            btn_default_user_settings.TabIndex = 42;
            btn_default_user_settings.Text = "Default";
            btn_default_user_settings.UseVisualStyleBackColor = true;
            btn_default_user_settings.Click += restore_default_settings;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.Black;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Lime;
            label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            label1.Size = new System.Drawing.Size(1195, 601);
            label1.TabIndex = 0;
            label1.Text = "USER SETTINGS";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chk_twitch_mode
            // 
            chk_twitch_mode.AutoSize = true;
            chk_twitch_mode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chk_twitch_mode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chk_twitch_mode.ForeColor = System.Drawing.Color.Lime;
            chk_twitch_mode.Location = new System.Drawing.Point(295, 171);
            chk_twitch_mode.Name = "chk_twitch_mode";
            chk_twitch_mode.Size = new System.Drawing.Size(12, 11);
            chk_twitch_mode.TabIndex = 43;
            chk_twitch_mode.UseVisualStyleBackColor = true;
            chk_twitch_mode.CheckedChanged += chk_twitch_mode_CheckedChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label10.ForeColor = System.Drawing.Color.Lime;
            label10.Location = new System.Drawing.Point(2, 175);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(175, 14);
            label10.TabIndex = 44;
            label10.Text = "Generate Stream Overlays";
            label10.Click += label10_Click;
            // 
            // txt_historic_log_location
            // 
            txt_historic_log_location.BackColor = System.Drawing.Color.Black;
            txt_historic_log_location.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txt_historic_log_location.Enabled = false;
            txt_historic_log_location.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txt_historic_log_location.ForeColor = System.Drawing.Color.Lime;
            txt_historic_log_location.Location = new System.Drawing.Point(295, 135);
            txt_historic_log_location.MaxLength = 256;
            txt_historic_log_location.Name = "txt_historic_log_location";
            txt_historic_log_location.Size = new System.Drawing.Size(240, 22);
            txt_historic_log_location.TabIndex = 40;
            txt_historic_log_location.WordWrap = false;
            // 
            // cmb_themes
            // 
            cmb_themes.BackColor = System.Drawing.Color.Black;
            cmb_themes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            cmb_themes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_themes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            cmb_themes.ForeColor = System.Drawing.Color.Lime;
            cmb_themes.IntegralHeight = false;
            cmb_themes.Location = new System.Drawing.Point(293, 274);
            cmb_themes.MaxDropDownItems = 20;
            cmb_themes.Name = "cmb_themes";
            cmb_themes.Size = new System.Drawing.Size(242, 23);
            cmb_themes.TabIndex = 45;
            cmb_themes.DrawItem += cmb_themes_DrawItem;
            cmb_themes.SelectedIndexChanged += cmb_themes_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.Color.Lime;
            label4.Location = new System.Drawing.Point(3, 274);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 14);
            label4.TabIndex = 46;
            label4.Text = "Theme";
            // 
            // tb_theme_warning
            // 
            tb_theme_warning.BackColor = System.Drawing.Color.Black;
            tb_theme_warning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tb_theme_warning.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tb_theme_warning.ForeColor = System.Drawing.Color.Lime;
            tb_theme_warning.Location = new System.Drawing.Point(6, 526);
            tb_theme_warning.Multiline = true;
            tb_theme_warning.Name = "tb_theme_warning";
            tb_theme_warning.ReadOnly = true;
            tb_theme_warning.Size = new System.Drawing.Size(743, 67);
            tb_theme_warning.TabIndex = 47;
            tb_theme_warning.TabStop = false;
            // 
            // chk_save_screen_shots
            // 
            chk_save_screen_shots.AutoSize = true;
            chk_save_screen_shots.Checked = true;
            chk_save_screen_shots.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_save_screen_shots.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chk_save_screen_shots.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chk_save_screen_shots.ForeColor = System.Drawing.Color.Lime;
            chk_save_screen_shots.Location = new System.Drawing.Point(295, 308);
            chk_save_screen_shots.Name = "chk_save_screen_shots";
            chk_save_screen_shots.Size = new System.Drawing.Size(12, 11);
            chk_save_screen_shots.TabIndex = 48;
            chk_save_screen_shots.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.ForeColor = System.Drawing.Color.Lime;
            label6.Location = new System.Drawing.Point(3, 308);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(154, 14);
            label6.TabIndex = 49;
            label6.Text = "Save Screen Captures ";
            // 
            // cmb_user_names
            // 
            cmb_user_names.BackColor = System.Drawing.Color.Black;
            cmb_user_names.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_user_names.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmb_user_names.ForeColor = System.Drawing.Color.Lime;
            cmb_user_names.IntegralHeight = false;
            cmb_user_names.Location = new System.Drawing.Point(295, 77);
            cmb_user_names.MaxDropDownItems = 3;
            cmb_user_names.Name = "cmb_user_names";
            cmb_user_names.Size = new System.Drawing.Size(242, 22);
            cmb_user_names.TabIndex = 50;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label7.ForeColor = System.Drawing.Color.Lime;
            label7.Location = new System.Drawing.Point(3, 334);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(210, 14);
            label7.TabIndex = 51;
            label7.Text = "Group Ram Damage into Ramming";
            // 
            // chk_group_ram
            // 
            chk_group_ram.AutoSize = true;
            chk_group_ram.Checked = true;
            chk_group_ram.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_group_ram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chk_group_ram.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chk_group_ram.ForeColor = System.Drawing.Color.Lime;
            chk_group_ram.Location = new System.Drawing.Point(295, 336);
            chk_group_ram.Name = "chk_group_ram";
            chk_group_ram.Size = new System.Drawing.Size(12, 11);
            chk_group_ram.TabIndex = 52;
            chk_group_ram.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(553, 548);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(206, 34);
            button1.TabIndex = 53;
            button1.Text = "Recalculate Logs";
            button1.UseVisualStyleBackColor = true;
            button1.Click += recalculate_logs;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label11.ForeColor = System.Drawing.Color.Lime;
            label11.Location = new System.Drawing.Point(3, 395);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(266, 14);
            label11.TabIndex = 55;
            label11.Text = "Upload to CrossoutDB after each match";
            // 
            // chk_upload_post_match
            // 
            chk_upload_post_match.AutoSize = true;
            chk_upload_post_match.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chk_upload_post_match.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chk_upload_post_match.ForeColor = System.Drawing.Color.Lime;
            chk_upload_post_match.Location = new System.Drawing.Point(295, 398);
            chk_upload_post_match.Name = "chk_upload_post_match";
            chk_upload_post_match.Size = new System.Drawing.Size(12, 11);
            chk_upload_post_match.TabIndex = 56;
            chk_upload_post_match.UseVisualStyleBackColor = true;
            chk_upload_post_match.CheckedChanged += chk_upload_post_match_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label8.ForeColor = System.Drawing.Color.Lime;
            label8.Location = new System.Drawing.Point(3, 364);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(224, 14);
            label8.TabIndex = 57;
            label8.Text = "Update screens after each match";
            // 
            // chk_update
            // 
            chk_update.AutoSize = true;
            chk_update.Checked = true;
            chk_update.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chk_update.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chk_update.ForeColor = System.Drawing.Color.Lime;
            chk_update.Location = new System.Drawing.Point(295, 366);
            chk_update.Name = "chk_update";
            chk_update.Size = new System.Drawing.Size(12, 11);
            chk_update.TabIndex = 58;
            chk_update.UseVisualStyleBackColor = true;
            // 
            // cmb_fullscreen_monitor
            // 
            cmb_fullscreen_monitor.BackColor = System.Drawing.Color.Black;
            cmb_fullscreen_monitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmb_fullscreen_monitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmb_fullscreen_monitor.ForeColor = System.Drawing.Color.Lime;
            cmb_fullscreen_monitor.IntegralHeight = false;
            cmb_fullscreen_monitor.Location = new System.Drawing.Point(293, 197);
            cmb_fullscreen_monitor.MaxDropDownItems = 10;
            cmb_fullscreen_monitor.Name = "cmb_fullscreen_monitor";
            cmb_fullscreen_monitor.Size = new System.Drawing.Size(242, 22);
            cmb_fullscreen_monitor.TabIndex = 60;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label12.ForeColor = System.Drawing.Color.Lime;
            label12.Location = new System.Drawing.Point(3, 205);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(133, 14);
            label12.TabIndex = 59;
            label12.Text = "Fullscreen Monitor";
            // 
            // user_settings
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoSize = true;
            BackColor = System.Drawing.Color.Black;
            Controls.Add(cmb_fullscreen_monitor);
            Controls.Add(label12);
            Controls.Add(chk_update);
            Controls.Add(label8);
            Controls.Add(chk_upload_post_match);
            Controls.Add(label11);
            Controls.Add(button1);
            Controls.Add(chk_group_ram);
            Controls.Add(label7);
            Controls.Add(cmb_user_names);
            Controls.Add(label6);
            Controls.Add(chk_save_screen_shots);
            Controls.Add(tb_theme_warning);
            Controls.Add(label4);
            Controls.Add(cmb_themes);
            Controls.Add(label10);
            Controls.Add(chk_twitch_mode);
            Controls.Add(btn_default_user_settings);
            Controls.Add(btn_save_user_settings);
            Controls.Add(txt_historic_log_location);
            Controls.Add(txt_log_file_location);
            Controls.Add(cmb_language_drop_down);
            Controls.Add(label9);
            Controls.Add(chk_prestigue_parts);
            Controls.Add(num_founders_level);
            Controls.Add(num_firestarter_level);
            Controls.Add(num_dawns_children_level);
            Controls.Add(num_steppenwolf_level);
            Controls.Add(num_scavenger_level);
            Controls.Add(num_nomad_level);
            Controls.Add(num_lunatic_level);
            Controls.Add(num_engineer_level);
            Controls.Add(label23);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ForeColor = System.Drawing.Color.Lime;
            MinimumSize = new System.Drawing.Size(1195, 601);
            Name = "user_settings";
            Size = new System.Drawing.Size(1195, 601);
            Load += user_settings_Load;
            Enter += user_settings_Enter;
            Resize += user_settings_Resize;
            ((System.ComponentModel.ISupportInitialize)num_engineer_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_lunatic_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_nomad_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_scavenger_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_steppenwolf_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_dawns_children_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_firestarter_level).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_founders_level).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ComboBox cmb_themes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_theme_warning;
        private System.Windows.Forms.CheckBox chk_save_screen_shots;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_user_names;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chk_group_ram;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chk_upload_post_match;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chk_update;
        private System.Windows.Forms.ComboBox cmb_fullscreen_monitor;
        private System.Windows.Forms.Label label12;
    }
}

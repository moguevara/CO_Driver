namespace CO_Driver.user_controls
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1195, 542);
            this.tableLayoutPanel1.TabIndex = 73;
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
    }
}

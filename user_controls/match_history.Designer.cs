namespace CO_Driver
{
    partial class match_history
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_match_history_view = new System.Windows.Forms.DataGridView();
            this.match_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_round_start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_round_duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_build_used = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_power_score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_kills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_assists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_drone_kills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_damage_taken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.match_reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_user_name = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dg_match_history_view)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_match_history_view
            // 
            this.dg_match_history_view.AllowUserToDeleteRows = false;
            this.dg_match_history_view.AllowUserToOrderColumns = true;
            this.dg_match_history_view.AllowUserToResizeColumns = false;
            this.dg_match_history_view.AllowUserToResizeRows = false;
            this.dg_match_history_view.BackgroundColor = System.Drawing.Color.Black;
            this.dg_match_history_view.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_match_history_view.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dg_match_history_view.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dg_match_history_view.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_match_history_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.dg_match_history_view.ColumnHeadersHeight = 32;
            this.dg_match_history_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_match_history_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.match_type,
            this.match_round_start,
            this.match_round_duration,
            this.Column1,
            this.match_build_used,
            this.match_power_score,
            this.match_score,
            this.match_kills,
            this.match_assists,
            this.match_drone_kills,
            this.match_damage,
            this.match_damage_taken,
            this.match_result,
            this.match_reward});
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_match_history_view.DefaultCellStyle = dataGridViewCellStyle42;
            this.dg_match_history_view.EnableHeadersVisualStyles = false;
            this.dg_match_history_view.GridColor = System.Drawing.Color.Lime;
            this.dg_match_history_view.Location = new System.Drawing.Point(0, 56);
            this.dg_match_history_view.Margin = new System.Windows.Forms.Padding(0);
            this.dg_match_history_view.Name = "dg_match_history_view";
            this.dg_match_history_view.ReadOnly = true;
            this.dg_match_history_view.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dg_match_history_view.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle43.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle43.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_match_history_view.RowHeadersDefaultCellStyle = dataGridViewCellStyle43;
            this.dg_match_history_view.RowHeadersVisible = false;
            this.dg_match_history_view.RowHeadersWidth = 10;
            this.dg_match_history_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle44.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_match_history_view.RowsDefaultCellStyle = dataGridViewCellStyle44;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Lime;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lime;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_match_history_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_match_history_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dg_match_history_view.Size = new System.Drawing.Size(1195, 545);
            this.dg_match_history_view.StandardTab = true;
            this.dg_match_history_view.TabIndex = 1;
            this.dg_match_history_view.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_match_history_view_CellDoubleClick);
            // 
            // match_type
            // 
            this.match_type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_type.HeaderText = "Match  Type";
            this.match_type.Name = "match_type";
            this.match_type.ReadOnly = true;
            this.match_type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_type.Width = 68;
            // 
            // match_round_start
            // 
            this.match_round_start.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_round_start.HeaderText = "Start Time";
            this.match_round_start.MinimumWidth = 160;
            this.match_round_start.Name = "match_round_start";
            this.match_round_start.ReadOnly = true;
            this.match_round_start.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_round_start.Width = 160;
            // 
            // match_round_duration
            // 
            this.match_round_duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_round_duration.HeaderText = "Duration";
            this.match_round_duration.Name = "match_round_duration";
            this.match_round_duration.ReadOnly = true;
            this.match_round_duration.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_round_duration.Width = 87;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Map";
            this.Column1.MinimumWidth = 130;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // match_build_used
            // 
            this.match_build_used.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_build_used.HeaderText = "Build";
            this.match_build_used.MinimumWidth = 10;
            this.match_build_used.Name = "match_build_used";
            this.match_build_used.ReadOnly = true;
            this.match_build_used.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_build_used.Width = 66;
            // 
            // match_power_score
            // 
            this.match_power_score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_power_score.HeaderText = "PS";
            this.match_power_score.Name = "match_power_score";
            this.match_power_score.ReadOnly = true;
            this.match_power_score.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_power_score.Width = 45;
            // 
            // match_score
            // 
            this.match_score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_score.HeaderText = "Score";
            this.match_score.Name = "match_score";
            this.match_score.ReadOnly = true;
            this.match_score.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_score.Width = 66;
            // 
            // match_kills
            // 
            this.match_kills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_kills.HeaderText = "Kills";
            this.match_kills.MinimumWidth = 60;
            this.match_kills.Name = "match_kills";
            this.match_kills.ReadOnly = true;
            this.match_kills.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_kills.Width = 60;
            // 
            // match_assists
            // 
            this.match_assists.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_assists.HeaderText = "Assists";
            this.match_assists.MinimumWidth = 60;
            this.match_assists.Name = "match_assists";
            this.match_assists.ReadOnly = true;
            this.match_assists.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_assists.Width = 60;
            // 
            // match_drone_kills
            // 
            this.match_drone_kills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_drone_kills.HeaderText = "Drone Kills";
            this.match_drone_kills.MinimumWidth = 60;
            this.match_drone_kills.Name = "match_drone_kills";
            this.match_drone_kills.ReadOnly = true;
            this.match_drone_kills.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_drone_kills.Width = 60;
            // 
            // match_damage
            // 
            this.match_damage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_damage.HeaderText = "Dmg";
            this.match_damage.MinimumWidth = 10;
            this.match_damage.Name = "match_damage";
            this.match_damage.ReadOnly = true;
            this.match_damage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_damage.Width = 86;
            // 
            // match_damage_taken
            // 
            this.match_damage_taken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_damage_taken.HeaderText = "Dmg Taken";
            this.match_damage_taken.MinimumWidth = 10;
            this.match_damage_taken.Name = "match_damage_taken";
            this.match_damage_taken.ReadOnly = true;
            this.match_damage_taken.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_damage_taken.Width = 86;
            // 
            // match_result
            // 
            this.match_result.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_result.HeaderText = "Result";
            this.match_result.MinimumWidth = 60;
            this.match_result.Name = "match_result";
            this.match_result.ReadOnly = true;
            this.match_result.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_result.Width = 60;
            // 
            // match_reward
            // 
            this.match_reward.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_reward.HeaderText = "Rewards";
            this.match_reward.Name = "match_reward";
            this.match_reward.ReadOnly = true;
            this.match_reward.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_reward.Width = 140;
            // 
            // lb_user_name
            // 
            this.lb_user_name.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_user_name.Location = new System.Drawing.Point(3, 0);
            this.lb_user_name.Name = "lb_user_name";
            this.lb_user_name.Size = new System.Drawing.Size(398, 53);
            this.lb_user_name.TabIndex = 48;
            this.lb_user_name.Text = "Match History";
            this.lb_user_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dt_end_date
            // 
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
            this.dt_end_date.TabIndex = 69;
            this.dt_end_date.ValueChanged += new System.EventHandler(this.dt_end_date_ValueChanged);
            // 
            // dt_start_date
            // 
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
            this.dt_start_date.TabIndex = 68;
            this.dt_start_date.Value = new System.DateTime(2016, 4, 5, 0, 0, 0, 0);
            this.dt_start_date.ValueChanged += new System.EventHandler(this.dt_start_date_ValueChanged);
            // 
            // cb_cabins
            // 
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
            this.cb_cabins.TabIndex = 67;
            this.cb_cabins.SelectedIndexChanged += new System.EventHandler(this.cb_cabins_SelectedIndexChanged);
            // 
            // btn_save_user_settings
            // 
            this.btn_save_user_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save_user_settings.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_user_settings.Location = new System.Drawing.Point(1062, 3);
            this.btn_save_user_settings.Name = "btn_save_user_settings";
            this.btn_save_user_settings.Size = new System.Drawing.Size(130, 22);
            this.btn_save_user_settings.TabIndex = 66;
            this.btn_save_user_settings.Text = "Reset";
            this.btn_save_user_settings.UseVisualStyleBackColor = true;
            this.btn_save_user_settings.Click += new System.EventHandler(this.btn_save_user_settings_Click);
            // 
            // cb_modules
            // 
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
            this.cb_modules.TabIndex = 65;
            this.cb_modules.SelectedIndexChanged += new System.EventHandler(this.cb_modules_SelectedIndexChanged);
            // 
            // cb_versions
            // 
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
            this.cb_versions.TabIndex = 64;
            this.cb_versions.SelectedIndexChanged += new System.EventHandler(this.cb_versions_SelectedIndexChanged);
            // 
            // cb_weapons
            // 
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
            this.cb_weapons.TabIndex = 63;
            this.cb_weapons.SelectedIndexChanged += new System.EventHandler(this.cb_weapons_SelectedIndexChanged);
            // 
            // cb_movement
            // 
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
            this.cb_movement.TabIndex = 62;
            this.cb_movement.SelectedIndexChanged += new System.EventHandler(this.cb_movement_SelectedIndexChanged);
            // 
            // cb_power_score
            // 
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
            this.cb_power_score.TabIndex = 61;
            this.cb_power_score.SelectedIndexChanged += new System.EventHandler(this.cb_power_score_SelectedIndexChanged);
            // 
            // cb_grouped
            // 
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
            this.cb_grouped.TabIndex = 60;
            this.cb_grouped.SelectedIndexChanged += new System.EventHandler(this.cb_grouped_SelectedIndexChanged);
            // 
            // cb_game_modes
            // 
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
            this.cb_game_modes.TabIndex = 59;
            this.cb_game_modes.SelectedIndexChanged += new System.EventHandler(this.cb_game_modes_SelectedIndexChanged);
            // 
            // match_history
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
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
            this.Controls.Add(this.dg_match_history_view);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.MaximumSize = new System.Drawing.Size(1195, 601);
            this.MinimumSize = new System.Drawing.Size(1195, 601);
            this.Name = "match_history";
            this.Size = new System.Drawing.Size(1195, 601);
            ((System.ComponentModel.ISupportInitialize)(this.dg_match_history_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dg_match_history_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_round_start;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_round_duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_build_used;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_power_score;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_score;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_kills;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_assists;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_drone_kills;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_damage_taken;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_result;
        private System.Windows.Forms.DataGridViewTextBoxColumn match_reward;
        private System.Windows.Forms.Label lb_user_name;
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
    }
}

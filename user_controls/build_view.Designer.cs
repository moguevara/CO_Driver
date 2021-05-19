namespace CO_Driver
{
    partial class build_view
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_build_view_grid = new System.Windows.Forms.DataGridView();
            this.build_build_hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_games = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_avg_damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_damage_taken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_win_loss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb_build_header = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_build_parts = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_build_description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_cabin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_weapons = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_movement = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_short_desc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_modules = new System.Windows.Forms.TextBox();
            this.cb_build_game_modes = new System.Windows.Forms.ComboBox();
            this.cb_grouped = new System.Windows.Forms.ComboBox();
            this.cb_map = new System.Windows.Forms.ComboBox();
            this.cb_power_score = new System.Windows.Forms.ComboBox();
            this.cb_client_version = new System.Windows.Forms.ComboBox();
            this.btn_reset_filters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_build_view_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_build_view_grid
            // 
            this.dg_build_view_grid.AllowUserToOrderColumns = true;
            this.dg_build_view_grid.AllowUserToResizeColumns = false;
            this.dg_build_view_grid.AllowUserToResizeRows = false;
            this.dg_build_view_grid.BackgroundColor = System.Drawing.Color.Black;
            this.dg_build_view_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_build_view_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dg_build_view_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dg_build_view_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_build_view_grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_build_view_grid.ColumnHeadersHeight = 20;
            this.dg_build_view_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_build_view_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.build_build_hash,
            this.build_deaths,
            this.build_games,
            this.build_kills,
            this.build_kills_deaths,
            this.build_avg_damage,
            this.build_damage_taken,
            this.build_wins,
            this.build_win_loss});
            this.dg_build_view_grid.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_build_view_grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_build_view_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dg_build_view_grid.EnableHeadersVisualStyles = false;
            this.dg_build_view_grid.GridColor = System.Drawing.Color.Lime;
            this.dg_build_view_grid.Location = new System.Drawing.Point(5, 96);
            this.dg_build_view_grid.Margin = new System.Windows.Forms.Padding(0);
            this.dg_build_view_grid.Name = "dg_build_view_grid";
            this.dg_build_view_grid.ReadOnly = true;
            this.dg_build_view_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_build_view_grid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_build_view_grid.RowHeadersWidth = 10;
            this.dg_build_view_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_build_view_grid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_build_view_grid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_build_view_grid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dg_build_view_grid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_build_view_grid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Lime;
            this.dg_build_view_grid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lime;
            this.dg_build_view_grid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_build_view_grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_build_view_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dg_build_view_grid.Size = new System.Drawing.Size(500, 488);
            this.dg_build_view_grid.StandardTab = true;
            this.dg_build_view_grid.TabIndex = 2;
            this.dg_build_view_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_build_view_grid_CellClick);
            this.dg_build_view_grid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dg_build_view_grid_CellPainting);
            this.dg_build_view_grid.SelectionChanged += new System.EventHandler(this.dg_build_view_grid_SelectionChanged);
            // 
            // build_build_hash
            // 
            this.build_build_hash.HeaderText = "Hash";
            this.build_build_hash.MinimumWidth = 65;
            this.build_build_hash.Name = "build_build_hash";
            this.build_build_hash.ReadOnly = true;
            this.build_build_hash.Width = 65;
            // 
            // build_deaths
            // 
            this.build_deaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_deaths.HeaderText = "PS";
            this.build_deaths.Name = "build_deaths";
            this.build_deaths.ReadOnly = true;
            this.build_deaths.Width = 44;
            // 
            // build_games
            // 
            this.build_games.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_games.HeaderText = "# G";
            this.build_games.Name = "build_games";
            this.build_games.ReadOnly = true;
            this.build_games.Width = 51;
            // 
            // build_kills
            // 
            this.build_kills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_kills.HeaderText = "K";
            this.build_kills.Name = "build_kills";
            this.build_kills.ReadOnly = true;
            this.build_kills.Width = 37;
            // 
            // build_kills_deaths
            // 
            this.build_kills_deaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_kills_deaths.HeaderText = "K/D";
            this.build_kills_deaths.Name = "build_kills_deaths";
            this.build_kills_deaths.ReadOnly = true;
            this.build_kills_deaths.Width = 51;
            // 
            // build_avg_damage
            // 
            this.build_avg_damage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_avg_damage.HeaderText = "Dmg";
            this.build_avg_damage.Name = "build_avg_damage";
            this.build_avg_damage.ReadOnly = true;
            this.build_avg_damage.Width = 51;
            // 
            // build_damage_taken
            // 
            this.build_damage_taken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_damage_taken.HeaderText = "Dmg Rec";
            this.build_damage_taken.Name = "build_damage_taken";
            this.build_damage_taken.ReadOnly = true;
            this.build_damage_taken.Width = 79;
            // 
            // build_wins
            // 
            this.build_wins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_wins.HeaderText = "W";
            this.build_wins.Name = "build_wins";
            this.build_wins.ReadOnly = true;
            this.build_wins.Width = 37;
            // 
            // build_win_loss
            // 
            this.build_win_loss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_win_loss.HeaderText = "WR";
            this.build_win_loss.Name = "build_win_loss";
            this.build_win_loss.ReadOnly = true;
            this.build_win_loss.Width = 44;
            // 
            // lb_build_header
            // 
            this.lb_build_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_build_header.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_build_header.Location = new System.Drawing.Point(0, 0);
            this.lb_build_header.Name = "lb_build_header";
            this.lb_build_header.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lb_build_header.Size = new System.Drawing.Size(1195, 65);
            this.lb_build_header.TabIndex = 0;
            this.lb_build_header.Text = "Build View";
            this.lb_build_header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(515, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parts:";
            // 
            // tb_build_parts
            // 
            this.tb_build_parts.BackColor = System.Drawing.Color.Black;
            this.tb_build_parts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_build_parts.ForeColor = System.Drawing.Color.Lime;
            this.tb_build_parts.Location = new System.Drawing.Point(518, 446);
            this.tb_build_parts.Multiline = true;
            this.tb_build_parts.Name = "tb_build_parts";
            this.tb_build_parts.ReadOnly = true;
            this.tb_build_parts.Size = new System.Drawing.Size(664, 138);
            this.tb_build_parts.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Build Description:";
            // 
            // tb_build_description
            // 
            this.tb_build_description.BackColor = System.Drawing.Color.Black;
            this.tb_build_description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_build_description.ForeColor = System.Drawing.Color.Lime;
            this.tb_build_description.Location = new System.Drawing.Point(518, 113);
            this.tb_build_description.Name = "tb_build_description";
            this.tb_build_description.ReadOnly = true;
            this.tb_build_description.Size = new System.Drawing.Size(664, 15);
            this.tb_build_description.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Cabin:";
            // 
            // tb_cabin
            // 
            this.tb_cabin.BackColor = System.Drawing.Color.Black;
            this.tb_cabin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_cabin.ForeColor = System.Drawing.Color.Lime;
            this.tb_cabin.Location = new System.Drawing.Point(518, 183);
            this.tb_cabin.Name = "tb_cabin";
            this.tb_cabin.ReadOnly = true;
            this.tb_cabin.Size = new System.Drawing.Size(664, 15);
            this.tb_cabin.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Weapons:";
            // 
            // tb_weapons
            // 
            this.tb_weapons.BackColor = System.Drawing.Color.Black;
            this.tb_weapons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_weapons.ForeColor = System.Drawing.Color.Lime;
            this.tb_weapons.Location = new System.Drawing.Point(518, 218);
            this.tb_weapons.Name = "tb_weapons";
            this.tb_weapons.ReadOnly = true;
            this.tb_weapons.Size = new System.Drawing.Size(664, 15);
            this.tb_weapons.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(515, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Movement:";
            // 
            // tb_movement
            // 
            this.tb_movement.BackColor = System.Drawing.Color.Black;
            this.tb_movement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_movement.ForeColor = System.Drawing.Color.Lime;
            this.tb_movement.Location = new System.Drawing.Point(518, 253);
            this.tb_movement.Name = "tb_movement";
            this.tb_movement.ReadOnly = true;
            this.tb_movement.Size = new System.Drawing.Size(664, 15);
            this.tb_movement.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(515, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 14);
            this.label8.TabIndex = 17;
            this.label8.Text = "Short Description:";
            // 
            // tb_short_desc
            // 
            this.tb_short_desc.BackColor = System.Drawing.Color.Black;
            this.tb_short_desc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_short_desc.ForeColor = System.Drawing.Color.Lime;
            this.tb_short_desc.Location = new System.Drawing.Point(518, 148);
            this.tb_short_desc.Name = "tb_short_desc";
            this.tb_short_desc.ReadOnly = true;
            this.tb_short_desc.Size = new System.Drawing.Size(664, 15);
            this.tb_short_desc.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(515, 271);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Modules:";
            // 
            // tb_modules
            // 
            this.tb_modules.BackColor = System.Drawing.Color.Black;
            this.tb_modules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_modules.ForeColor = System.Drawing.Color.Lime;
            this.tb_modules.Location = new System.Drawing.Point(518, 288);
            this.tb_modules.Name = "tb_modules";
            this.tb_modules.ReadOnly = true;
            this.tb_modules.Size = new System.Drawing.Size(664, 15);
            this.tb_modules.TabIndex = 14;
            // 
            // cb_build_game_modes
            // 
            this.cb_build_game_modes.BackColor = System.Drawing.Color.Black;
            this.cb_build_game_modes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_build_game_modes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_build_game_modes.ForeColor = System.Drawing.Color.Lime;
            this.cb_build_game_modes.FormattingEnabled = true;
            this.cb_build_game_modes.Location = new System.Drawing.Point(879, 65);
            this.cb_build_game_modes.MaxDropDownItems = 32;
            this.cb_build_game_modes.Name = "cb_build_game_modes";
            this.cb_build_game_modes.Size = new System.Drawing.Size(171, 22);
            this.cb_build_game_modes.TabIndex = 19;
            this.cb_build_game_modes.SelectedIndexChanged += new System.EventHandler(this.cb_build_game_modes_SelectedIndexChanged);
            // 
            // cb_grouped
            // 
            this.cb_grouped.BackColor = System.Drawing.Color.Black;
            this.cb_grouped.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_grouped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_grouped.ForeColor = System.Drawing.Color.Lime;
            this.cb_grouped.FormattingEnabled = true;
            this.cb_grouped.Location = new System.Drawing.Point(719, 65);
            this.cb_grouped.MaxDropDownItems = 32;
            this.cb_grouped.Name = "cb_grouped";
            this.cb_grouped.Size = new System.Drawing.Size(154, 22);
            this.cb_grouped.TabIndex = 20;
            this.cb_grouped.SelectedIndexChanged += new System.EventHandler(this.cb_grouped_SelectedIndexChanged);
            // 
            // cb_map
            // 
            this.cb_map.BackColor = System.Drawing.Color.Black;
            this.cb_map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_map.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_map.ForeColor = System.Drawing.Color.Lime;
            this.cb_map.FormattingEnabled = true;
            this.cb_map.Location = new System.Drawing.Point(518, 65);
            this.cb_map.MaxDropDownItems = 32;
            this.cb_map.Name = "cb_map";
            this.cb_map.Size = new System.Drawing.Size(194, 22);
            this.cb_map.TabIndex = 21;
            this.cb_map.SelectedIndexChanged += new System.EventHandler(this.cb_map_SelectedIndexChanged);
            // 
            // cb_power_score
            // 
            this.cb_power_score.BackColor = System.Drawing.Color.Black;
            this.cb_power_score.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_power_score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_power_score.ForeColor = System.Drawing.Color.Lime;
            this.cb_power_score.FormattingEnabled = true;
            this.cb_power_score.Location = new System.Drawing.Point(368, 65);
            this.cb_power_score.MaxDropDownItems = 32;
            this.cb_power_score.Name = "cb_power_score";
            this.cb_power_score.Size = new System.Drawing.Size(144, 22);
            this.cb_power_score.TabIndex = 22;
            this.cb_power_score.SelectedIndexChanged += new System.EventHandler(this.cb_power_score_SelectedIndexChanged);
            // 
            // cb_client_version
            // 
            this.cb_client_version.BackColor = System.Drawing.Color.Black;
            this.cb_client_version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_client_version.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_client_version.ForeColor = System.Drawing.Color.Lime;
            this.cb_client_version.FormattingEnabled = true;
            this.cb_client_version.Location = new System.Drawing.Point(5, 65);
            this.cb_client_version.MaxDropDownItems = 32;
            this.cb_client_version.Name = "cb_client_version";
            this.cb_client_version.Size = new System.Drawing.Size(357, 22);
            this.cb_client_version.TabIndex = 23;
            this.cb_client_version.SelectedIndexChanged += new System.EventHandler(this.cb_client_version_SelectedIndexChanged);
            // 
            // btn_reset_filters
            // 
            this.btn_reset_filters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset_filters.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset_filters.Location = new System.Drawing.Point(1056, 65);
            this.btn_reset_filters.Name = "btn_reset_filters";
            this.btn_reset_filters.Size = new System.Drawing.Size(126, 22);
            this.btn_reset_filters.TabIndex = 42;
            this.btn_reset_filters.Text = "Reset";
            this.btn_reset_filters.UseVisualStyleBackColor = true;
            this.btn_reset_filters.Click += new System.EventHandler(this.btn_reset_filters_Click);
            // 
            // build_view
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btn_reset_filters);
            this.Controls.Add(this.cb_client_version);
            this.Controls.Add(this.cb_power_score);
            this.Controls.Add(this.cb_map);
            this.Controls.Add(this.cb_grouped);
            this.Controls.Add(this.cb_build_game_modes);
            this.Controls.Add(this.tb_short_desc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_modules);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_movement);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_weapons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_cabin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_build_description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_build_parts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dg_build_view_grid);
            this.Controls.Add(this.lb_build_header);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.MaximumSize = new System.Drawing.Size(1195, 601);
            this.MinimumSize = new System.Drawing.Size(1195, 601);
            this.Name = "build_view";
            this.Size = new System.Drawing.Size(1195, 601);
            this.Load += new System.EventHandler(this.build_view_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_build_view_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dg_build_view_grid;
        private System.Windows.Forms.Label lb_build_header;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tb_build_parts;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tb_build_description;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tb_cabin;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tb_weapons;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tb_movement;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tb_short_desc;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tb_modules;
        private System.Windows.Forms.ComboBox cb_build_game_modes;
        private System.Windows.Forms.ComboBox cb_grouped;
        private System.Windows.Forms.ComboBox cb_map;
        private System.Windows.Forms.ComboBox cb_power_score;
        private System.Windows.Forms.ComboBox cb_client_version;
        private System.Windows.Forms.Button btn_reset_filters;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_build_hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_games;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_avg_damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_damage_taken;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_win_loss;
    }
}

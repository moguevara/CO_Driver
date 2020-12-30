namespace CO_Driver
{
    partial class part_optimizer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dg_available_parts = new System.Windows.Forms.DataGridView();
            this.build_build_hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_games = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_hull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_avg_damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dg_selected_parts = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_total_parts = new System.Windows.Forms.Label();
            this.lb_hull_dura = new System.Windows.Forms.Label();
            this.lb_effective_dura = new System.Windows.Forms.Label();
            this.lb_effective_melee_dura = new System.Windows.Forms.Label();
            this.lb_effective_bullet_dura = new System.Windows.Forms.Label();
            this.lb_mass = new System.Windows.Forms.Label();
            this.lb_power_score = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chk_3_percent = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chk_10_percent = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_available_parts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_selected_parts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(1169, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manual Part Assembly";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dg_available_parts
            // 
            this.dg_available_parts.AllowUserToDeleteRows = false;
            this.dg_available_parts.AllowUserToOrderColumns = true;
            this.dg_available_parts.AllowUserToResizeColumns = false;
            this.dg_available_parts.AllowUserToResizeRows = false;
            this.dg_available_parts.BackgroundColor = System.Drawing.Color.Black;
            this.dg_available_parts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dg_available_parts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_available_parts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_available_parts.ColumnHeadersHeight = 20;
            this.dg_available_parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_available_parts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.build_build_hash,
            this.build_games,
            this.part_hull,
            this.build_kills,
            this.build_deaths,
            this.build_kills_deaths,
            this.build_avg_damage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_available_parts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_available_parts.EnableHeadersVisualStyles = false;
            this.dg_available_parts.GridColor = System.Drawing.Color.Lime;
            this.dg_available_parts.Location = new System.Drawing.Point(5, 85);
            this.dg_available_parts.Margin = new System.Windows.Forms.Padding(0);
            this.dg_available_parts.Name = "dg_available_parts";
            this.dg_available_parts.ReadOnly = true;
            this.dg_available_parts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_available_parts.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_available_parts.RowHeadersVisible = false;
            this.dg_available_parts.RowHeadersWidth = 10;
            this.dg_available_parts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_available_parts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_available_parts.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_available_parts.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dg_available_parts.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_available_parts.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Lime;
            this.dg_available_parts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lime;
            this.dg_available_parts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_available_parts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_available_parts.Size = new System.Drawing.Size(513, 499);
            this.dg_available_parts.StandardTab = true;
            this.dg_available_parts.TabIndex = 3;
            this.dg_available_parts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_available_parts_CellClick);
            // 
            // build_build_hash
            // 
            this.build_build_hash.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.build_build_hash.HeaderText = "Part Name";
            this.build_build_hash.MinimumWidth = 120;
            this.build_build_hash.Name = "build_build_hash";
            this.build_build_hash.ReadOnly = true;
            this.build_build_hash.Width = 120;
            // 
            // build_games
            // 
            this.build_games.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.build_games.HeaderText = "Dura";
            this.build_games.MinimumWidth = 60;
            this.build_games.Name = "build_games";
            this.build_games.ReadOnly = true;
            this.build_games.Width = 60;
            // 
            // part_hull
            // 
            this.part_hull.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.part_hull.HeaderText = "Hull";
            this.part_hull.MinimumWidth = 60;
            this.part_hull.Name = "part_hull";
            this.part_hull.ReadOnly = true;
            this.part_hull.Width = 60;
            // 
            // build_kills
            // 
            this.build_kills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.build_kills.HeaderText = "Mass";
            this.build_kills.MinimumWidth = 60;
            this.build_kills.Name = "build_kills";
            this.build_kills.ReadOnly = true;
            this.build_kills.Width = 60;
            // 
            // build_deaths
            // 
            this.build_deaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.build_deaths.HeaderText = "PS";
            this.build_deaths.MinimumWidth = 60;
            this.build_deaths.Name = "build_deaths";
            this.build_deaths.ReadOnly = true;
            this.build_deaths.Width = 60;
            // 
            // build_kills_deaths
            // 
            this.build_kills_deaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.build_kills_deaths.HeaderText = "D/M";
            this.build_kills_deaths.MinimumWidth = 60;
            this.build_kills_deaths.Name = "build_kills_deaths";
            this.build_kills_deaths.ReadOnly = true;
            this.build_kills_deaths.Width = 60;
            // 
            // build_avg_damage
            // 
            this.build_avg_damage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.build_avg_damage.HeaderText = "PS/M";
            this.build_avg_damage.MinimumWidth = 60;
            this.build_avg_damage.Name = "build_avg_damage";
            this.build_avg_damage.ReadOnly = true;
            this.build_avg_damage.Width = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available Inventory";
            // 
            // dg_selected_parts
            // 
            this.dg_selected_parts.AllowUserToDeleteRows = false;
            this.dg_selected_parts.AllowUserToOrderColumns = true;
            this.dg_selected_parts.AllowUserToResizeColumns = false;
            this.dg_selected_parts.AllowUserToResizeRows = false;
            this.dg_selected_parts.BackgroundColor = System.Drawing.Color.Black;
            this.dg_selected_parts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dg_selected_parts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_selected_parts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dg_selected_parts.ColumnHeadersHeight = 20;
            this.dg_selected_parts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_selected_parts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_selected_parts.DefaultCellStyle = dataGridViewCellStyle6;
            this.dg_selected_parts.EnableHeadersVisualStyles = false;
            this.dg_selected_parts.GridColor = System.Drawing.Color.Lime;
            this.dg_selected_parts.Location = new System.Drawing.Point(826, 85);
            this.dg_selected_parts.Margin = new System.Windows.Forms.Padding(0);
            this.dg_selected_parts.Name = "dg_selected_parts";
            this.dg_selected_parts.ReadOnly = true;
            this.dg_selected_parts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_selected_parts.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dg_selected_parts.RowHeadersVisible = false;
            this.dg_selected_parts.RowHeadersWidth = 10;
            this.dg_selected_parts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_selected_parts.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dg_selected_parts.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_selected_parts.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dg_selected_parts.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_selected_parts.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Lime;
            this.dg_selected_parts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lime;
            this.dg_selected_parts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_selected_parts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_selected_parts.Size = new System.Drawing.Size(335, 434);
            this.dg_selected_parts.StandardTab = true;
            this.dg_selected_parts.TabIndex = 5;
            this.dg_selected_parts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_selected_parts_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.HeaderText = "Part Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.HeaderText = "Dura";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.HeaderText = "Mass";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.HeaderText = "PS";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(814, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Build";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(521, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total Parts";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_total_parts
            // 
            this.lb_total_parts.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total_parts.Location = new System.Drawing.Point(524, 112);
            this.lb_total_parts.Name = "lb_total_parts";
            this.lb_total_parts.Size = new System.Drawing.Size(291, 24);
            this.lb_total_parts.TabIndex = 14;
            this.lb_total_parts.Text = "0";
            this.lb_total_parts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_hull_dura
            // 
            this.lb_hull_dura.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hull_dura.Location = new System.Drawing.Point(524, 162);
            this.lb_hull_dura.Name = "lb_hull_dura";
            this.lb_hull_dura.Size = new System.Drawing.Size(290, 24);
            this.lb_hull_dura.TabIndex = 15;
            this.lb_hull_dura.Text = "0";
            this.lb_hull_dura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_hull_dura.Click += new System.EventHandler(this.lb_hull_dura_Click);
            // 
            // lb_effective_dura
            // 
            this.lb_effective_dura.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_effective_dura.Location = new System.Drawing.Point(524, 212);
            this.lb_effective_dura.Name = "lb_effective_dura";
            this.lb_effective_dura.Size = new System.Drawing.Size(290, 24);
            this.lb_effective_dura.TabIndex = 16;
            this.lb_effective_dura.Text = "0";
            this.lb_effective_dura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_effective_melee_dura
            // 
            this.lb_effective_melee_dura.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_effective_melee_dura.Location = new System.Drawing.Point(524, 262);
            this.lb_effective_melee_dura.Name = "lb_effective_melee_dura";
            this.lb_effective_melee_dura.Size = new System.Drawing.Size(291, 24);
            this.lb_effective_melee_dura.TabIndex = 17;
            this.lb_effective_melee_dura.Text = "0";
            this.lb_effective_melee_dura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_effective_melee_dura.Click += new System.EventHandler(this.lb_effective_melee_dura_Click);
            // 
            // lb_effective_bullet_dura
            // 
            this.lb_effective_bullet_dura.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_effective_bullet_dura.Location = new System.Drawing.Point(524, 312);
            this.lb_effective_bullet_dura.Name = "lb_effective_bullet_dura";
            this.lb_effective_bullet_dura.Size = new System.Drawing.Size(291, 24);
            this.lb_effective_bullet_dura.TabIndex = 18;
            this.lb_effective_bullet_dura.Text = "0";
            this.lb_effective_bullet_dura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_mass
            // 
            this.lb_mass.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mass.Location = new System.Drawing.Point(524, 362);
            this.lb_mass.Name = "lb_mass";
            this.lb_mass.Size = new System.Drawing.Size(291, 24);
            this.lb_mass.TabIndex = 19;
            this.lb_mass.Text = "0";
            this.lb_mass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_power_score
            // 
            this.lb_power_score.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_power_score.Location = new System.Drawing.Point(524, 412);
            this.lb_power_score.Name = "lb_power_score";
            this.lb_power_score.Size = new System.Drawing.Size(291, 24);
            this.lb_power_score.TabIndex = 20;
            this.lb_power_score.Text = "0";
            this.lb_power_score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_power_score.Click += new System.EventHandler(this.lb_power_score_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(1049, 554);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(112, 30);
            this.btn_reset.TabIndex = 21;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(521, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 26);
            this.label5.TabIndex = 22;
            this.label5.Text = "Hull Durability";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(524, 186);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(290, 26);
            this.label11.TabIndex = 23;
            this.label11.Text = "Effective Durability";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(524, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 26);
            this.label6.TabIndex = 24;
            this.label6.Text = "Effective Melee Durability";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(524, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(290, 26);
            this.label7.TabIndex = 25;
            this.label7.Text = "Effective Bullet Durability";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(524, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(291, 26);
            this.label8.TabIndex = 26;
            this.label8.Text = "Mass";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(524, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(290, 26);
            this.label9.TabIndex = 27;
            this.label9.Text = "Power Score";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_3_percent
            // 
            this.chk_3_percent.AutoSize = true;
            this.chk_3_percent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_3_percent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_3_percent.ForeColor = System.Drawing.Color.Lime;
            this.chk_3_percent.Location = new System.Drawing.Point(826, 546);
            this.chk_3_percent.Name = "chk_3_percent";
            this.chk_3_percent.Size = new System.Drawing.Size(12, 11);
            this.chk_3_percent.TabIndex = 28;
            this.chk_3_percent.UseVisualStyleBackColor = true;
            this.chk_3_percent.CheckedChanged += new System.EventHandler(this.check_3_percent_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(844, 570);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 14);
            this.label10.TabIndex = 29;
            this.label10.Text = "10% cab resistance fusion";
            // 
            // chk_10_percent
            // 
            this.chk_10_percent.AutoSize = true;
            this.chk_10_percent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chk_10_percent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_10_percent.ForeColor = System.Drawing.Color.Lime;
            this.chk_10_percent.Location = new System.Drawing.Point(826, 570);
            this.chk_10_percent.Name = "chk_10_percent";
            this.chk_10_percent.Size = new System.Drawing.Size(12, 11);
            this.chk_10_percent.TabIndex = 30;
            this.chk_10_percent.UseVisualStyleBackColor = true;
            this.chk_10_percent.CheckedChanged += new System.EventHandler(this.chk_10_percent_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(844, 543);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 14);
            this.label12.TabIndex = 31;
            this.label12.Text = "3% MJ/Hans resistance";
            // 
            // part_optimizer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chk_10_percent);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chk_3_percent);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.lb_power_score);
            this.Controls.Add(this.lb_mass);
            this.Controls.Add(this.lb_effective_bullet_dura);
            this.Controls.Add(this.lb_effective_melee_dura);
            this.Controls.Add(this.lb_effective_dura);
            this.Controls.Add(this.lb_hull_dura);
            this.Controls.Add(this.lb_total_parts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dg_selected_parts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dg_available_parts);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "part_optimizer";
            this.Size = new System.Drawing.Size(1169, 601);
            ((System.ComponentModel.ISupportInitialize)(this.dg_available_parts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_selected_parts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dg_available_parts;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_build_hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_games;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_hull;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_avg_damage;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dg_selected_parts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_total_parts;
        private System.Windows.Forms.Label lb_hull_dura;
        private System.Windows.Forms.Label lb_effective_dura;
        private System.Windows.Forms.Label lb_effective_melee_dura;
        private System.Windows.Forms.Label lb_effective_bullet_dura;
        private System.Windows.Forms.Label lb_mass;
        private System.Windows.Forms.Label lb_power_score;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chk_3_percent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chk_10_percent;
        private System.Windows.Forms.Label label12;
    }
}

namespace CO_Driver
{
    partial class part_view
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
            this.label1 = new System.Windows.Forms.Label();
            this.dg_available_parts = new System.Windows.Forms.DataGridView();
            this.build_build_hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_faction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_games = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_hull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_pass_through = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_bullet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.part_impact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_avg_damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg_available_parts)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(1195, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "View Available Parts";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dg_available_parts
            // 
            this.dg_available_parts.AllowUserToDeleteRows = false;
            this.dg_available_parts.AllowUserToOrderColumns = true;
            this.dg_available_parts.AllowUserToResizeColumns = false;
            this.dg_available_parts.AllowUserToResizeRows = false;
            this.dg_available_parts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.part_quantity,
            this.part_faction,
            this.part_level,
            this.build_games,
            this.part_hull,
            this.build_kills,
            this.build_deaths,
            this.part_pass_through,
            this.part_bullet,
            this.part_impact,
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
            this.dg_available_parts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_available_parts.EnableHeadersVisualStyles = false;
            this.dg_available_parts.GridColor = System.Drawing.Color.Lime;
            this.dg_available_parts.Location = new System.Drawing.Point(0, 65);
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
            this.dg_available_parts.Size = new System.Drawing.Size(1195, 536);
            this.dg_available_parts.StandardTab = true;
            this.dg_available_parts.TabIndex = 4;
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
            // part_quantity
            // 
            this.part_quantity.HeaderText = "#";
            this.part_quantity.Name = "part_quantity";
            this.part_quantity.ReadOnly = true;
            // 
            // part_faction
            // 
            this.part_faction.HeaderText = "Faction";
            this.part_faction.Name = "part_faction";
            this.part_faction.ReadOnly = true;
            // 
            // part_level
            // 
            this.part_level.HeaderText = "Level";
            this.part_level.Name = "part_level";
            this.part_level.ReadOnly = true;
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
            // part_pass_through
            // 
            this.part_pass_through.HeaderText = "Pass Through %";
            this.part_pass_through.Name = "part_pass_through";
            this.part_pass_through.ReadOnly = true;
            // 
            // part_bullet
            // 
            this.part_bullet.HeaderText = "Bullet Resistance";
            this.part_bullet.Name = "part_bullet";
            this.part_bullet.ReadOnly = true;
            // 
            // part_impact
            // 
            this.part_impact.HeaderText = "Melee Resistance";
            this.part_impact.Name = "part_impact";
            this.part_impact.ReadOnly = true;
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
            // part_view
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.dg_available_parts);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "part_view";
            this.Size = new System.Drawing.Size(1195, 601);
            ((System.ComponentModel.ISupportInitialize)(this.dg_available_parts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dg_available_parts;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_build_hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_faction;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_level;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_games;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_hull;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_pass_through;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_bullet;
        private System.Windows.Forms.DataGridViewTextBoxColumn part_impact;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_avg_damage;
    }
}

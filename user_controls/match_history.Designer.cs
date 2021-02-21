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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dg_match_history_view)).BeginInit();
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
            this.label1.TabIndex = 0;
            this.label1.Text = "Match History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dg_match_history_view
            // 
            this.dg_match_history_view.AllowUserToDeleteRows = false;
            this.dg_match_history_view.AllowUserToOrderColumns = true;
            this.dg_match_history_view.AllowUserToResizeColumns = false;
            this.dg_match_history_view.AllowUserToResizeRows = false;
            this.dg_match_history_view.BackgroundColor = System.Drawing.Color.Black;
            this.dg_match_history_view.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dg_match_history_view.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dg_match_history_view.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_match_history_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_match_history_view.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_match_history_view.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_match_history_view.EnableHeadersVisualStyles = false;
            this.dg_match_history_view.GridColor = System.Drawing.Color.Lime;
            this.dg_match_history_view.Location = new System.Drawing.Point(0, 65);
            this.dg_match_history_view.Margin = new System.Windows.Forms.Padding(0);
            this.dg_match_history_view.Name = "dg_match_history_view";
            this.dg_match_history_view.ReadOnly = true;
            this.dg_match_history_view.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dg_match_history_view.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_match_history_view.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_match_history_view.RowHeadersVisible = false;
            this.dg_match_history_view.RowHeadersWidth = 10;
            this.dg_match_history_view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_match_history_view.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Lime;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lime;
            this.dg_match_history_view.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_match_history_view.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dg_match_history_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dg_match_history_view.Size = new System.Drawing.Size(1195, 536);
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
            this.match_round_start.MinimumWidth = 10;
            this.match_round_start.Name = "match_round_start";
            this.match_round_start.ReadOnly = true;
            this.match_round_start.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_round_start.Width = 120;
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
            this.Column1.HeaderText = "map";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
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
            this.match_kills.Name = "match_kills";
            this.match_kills.ReadOnly = true;
            this.match_kills.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_kills.Width = 66;
            // 
            // match_assists
            // 
            this.match_assists.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_assists.HeaderText = "Assists";
            this.match_assists.Name = "match_assists";
            this.match_assists.ReadOnly = true;
            this.match_assists.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_assists.Width = 80;
            // 
            // match_drone_kills
            // 
            this.match_drone_kills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.match_drone_kills.HeaderText = "Drone Kills";
            this.match_drone_kills.Name = "match_drone_kills";
            this.match_drone_kills.ReadOnly = true;
            this.match_drone_kills.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_drone_kills.Width = 68;
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
            this.match_result.Name = "match_result";
            this.match_result.ReadOnly = true;
            this.match_result.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.match_result.Width = 73;
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
            // match_history
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.dg_match_history_view);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "match_history";
            this.Size = new System.Drawing.Size(1195, 601);
            ((System.ComponentModel.ISupportInitialize)(this.dg_match_history_view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
    }
}

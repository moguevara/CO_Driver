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
            this.build_games = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_kills_deaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_avg_damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_damage_taken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_losses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.build_win_loss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_build_parts = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_build_view_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_build_view_grid
            // 
            this.dg_build_view_grid.AllowUserToDeleteRows = false;
            this.dg_build_view_grid.AllowUserToOrderColumns = true;
            this.dg_build_view_grid.AllowUserToResizeColumns = false;
            this.dg_build_view_grid.AllowUserToResizeRows = false;
            this.dg_build_view_grid.BackgroundColor = System.Drawing.Color.Black;
            this.dg_build_view_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dg_build_view_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
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
            this.build_games,
            this.build_kills,
            this.build_deaths,
            this.build_kills_deaths,
            this.build_avg_damage,
            this.build_damage_taken,
            this.build_wins,
            this.build_losses,
            this.build_win_loss});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_build_view_grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_build_view_grid.EnableHeadersVisualStyles = false;
            this.dg_build_view_grid.GridColor = System.Drawing.Color.Lime;
            this.dg_build_view_grid.Location = new System.Drawing.Point(5, 65);
            this.dg_build_view_grid.Margin = new System.Windows.Forms.Padding(0);
            this.dg_build_view_grid.Name = "dg_build_view_grid";
            this.dg_build_view_grid.ReadOnly = true;
            this.dg_build_view_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
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
            this.dg_build_view_grid.Size = new System.Drawing.Size(710, 519);
            this.dg_build_view_grid.StandardTab = true;
            this.dg_build_view_grid.TabIndex = 2;
            this.dg_build_view_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_build_view_grid_CellClick);
            // 
            // build_build_hash
            // 
            this.build_build_hash.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_build_hash.HeaderText = "  Build Hash";
            this.build_build_hash.Name = "build_build_hash";
            this.build_build_hash.ReadOnly = true;
            this.build_build_hash.Width = 115;
            // 
            // build_games
            // 
            this.build_games.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_games.HeaderText = "  Games";
            this.build_games.Name = "build_games";
            this.build_games.ReadOnly = true;
            this.build_games.Width = 80;
            // 
            // build_kills
            // 
            this.build_kills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_kills.HeaderText = "  K";
            this.build_kills.Name = "build_kills";
            this.build_kills.ReadOnly = true;
            this.build_kills.Width = 52;
            // 
            // build_deaths
            // 
            this.build_deaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_deaths.HeaderText = "  D";
            this.build_deaths.Name = "build_deaths";
            this.build_deaths.ReadOnly = true;
            this.build_deaths.Width = 52;
            // 
            // build_kills_deaths
            // 
            this.build_kills_deaths.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_kills_deaths.HeaderText = "  K/D";
            this.build_kills_deaths.Name = "build_kills_deaths";
            this.build_kills_deaths.ReadOnly = true;
            this.build_kills_deaths.Width = 66;
            // 
            // build_avg_damage
            // 
            this.build_avg_damage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_avg_damage.HeaderText = "  Dmg";
            this.build_avg_damage.Name = "build_avg_damage";
            this.build_avg_damage.ReadOnly = true;
            this.build_avg_damage.Width = 66;
            // 
            // build_damage_taken
            // 
            this.build_damage_taken.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_damage_taken.HeaderText = "  Dmg Rec";
            this.build_damage_taken.Name = "build_damage_taken";
            this.build_damage_taken.ReadOnly = true;
            this.build_damage_taken.Width = 94;
            // 
            // build_wins
            // 
            this.build_wins.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_wins.HeaderText = "  W";
            this.build_wins.Name = "build_wins";
            this.build_wins.ReadOnly = true;
            this.build_wins.Width = 52;
            // 
            // build_losses
            // 
            this.build_losses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_losses.HeaderText = "  L";
            this.build_losses.Name = "build_losses";
            this.build_losses.ReadOnly = true;
            this.build_losses.Width = 52;
            // 
            // build_win_loss
            // 
            this.build_win_loss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.build_win_loss.HeaderText = "  W/L";
            this.build_win_loss.Name = "build_win_loss";
            this.build_win_loss.ReadOnly = true;
            this.build_win_loss.Width = 66;
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
            this.label1.Text = "Build View";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(718, 65);
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
            this.tb_build_parts.Location = new System.Drawing.Point(721, 82);
            this.tb_build_parts.Multiline = true;
            this.tb_build_parts.Name = "tb_build_parts";
            this.tb_build_parts.Size = new System.Drawing.Size(461, 502);
            this.tb_build_parts.TabIndex = 4;
            // 
            // build_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tb_build_parts);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dg_build_view_grid);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "build_view";
            this.Size = new System.Drawing.Size(1195, 601);
            ((System.ComponentModel.ISupportInitialize)(this.dg_build_view_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dg_build_view_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_build_hash;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_games;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_kills_deaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_avg_damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_damage_taken;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_losses;
        private System.Windows.Forms.DataGridViewTextBoxColumn build_win_loss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tb_build_parts;
    }
}

namespace CO_Driver
{
    partial class frm_main_page
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main_page));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.strp_main_menu_strip = new System.Windows.Forms.MenuStrip();
            this.userProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fusionTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partOptimizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clanWarScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inMatchDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamelogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chatlogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.netlogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gfxlogToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_page_panel = new System.Windows.Forms.Panel();
            this.bw_file_feed = new System.ComponentModel.BackgroundWorker();
            this.partViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticPartOptimizerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strp_main_menu_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // strp_main_menu_strip
            // 
            this.strp_main_menu_strip.BackColor = System.Drawing.SystemColors.Control;
            this.strp_main_menu_strip.Enabled = false;
            this.strp_main_menu_strip.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strp_main_menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userProfileToolStripMenuItem,
            this.matchHistoryToolStripMenuItem,
            this.matchAnalysisToolStripMenuItem,
            this.buildToolsToolStripMenuItem,
            this.scheduleToolStripMenuItem,
            this.inMatchDataToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.strp_main_menu_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.strp_main_menu_strip.Location = new System.Drawing.Point(0, 0);
            this.strp_main_menu_strip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.strp_main_menu_strip.Name = "strp_main_menu_strip";
            this.strp_main_menu_strip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.strp_main_menu_strip.Size = new System.Drawing.Size(1195, 23);
            this.strp_main_menu_strip.TabIndex = 2;
            this.strp_main_menu_strip.Text = "menuStrip1";
            this.strp_main_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // userProfileToolStripMenuItem
            // 
            this.userProfileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.userProfileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userProfileToolStripMenuItem.Name = "userProfileToolStripMenuItem";
            this.userProfileToolStripMenuItem.Size = new System.Drawing.Size(103, 18);
            this.userProfileToolStripMenuItem.Text = "User Profile";
            this.userProfileToolStripMenuItem.Click += new System.EventHandler(this.userProfileToolStripMenuItem_Click);
            // 
            // matchHistoryToolStripMenuItem
            // 
            this.matchHistoryToolStripMenuItem.Name = "matchHistoryToolStripMenuItem";
            this.matchHistoryToolStripMenuItem.Size = new System.Drawing.Size(110, 18);
            this.matchHistoryToolStripMenuItem.Text = "Match History";
            this.matchHistoryToolStripMenuItem.Click += new System.EventHandler(this.matchHistoryToolStripMenuItem_Click);
            // 
            // matchAnalysisToolStripMenuItem
            // 
            this.matchAnalysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem});
            this.matchAnalysisToolStripMenuItem.Name = "matchAnalysisToolStripMenuItem";
            this.matchAnalysisToolStripMenuItem.Size = new System.Drawing.Size(110, 18);
            this.matchAnalysisToolStripMenuItem.Text = "Game Analysis";
            this.matchAnalysisToolStripMenuItem.Click += new System.EventHandler(this.matchAnalysisToolStripMenuItem_Click);
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buildToolStripMenuItem.Text = "Build Review";
            this.buildToolStripMenuItem.Click += new System.EventHandler(this.buildToolStripMenuItem_Click);
            // 
            // buildToolsToolStripMenuItem
            // 
            this.buildToolsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.buildToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fusionTrackerToolStripMenuItem,
            this.partViewToolStripMenuItem,
            this.partOptimizationToolStripMenuItem,
            this.automaticPartOptimizerToolStripMenuItem});
            this.buildToolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buildToolsToolStripMenuItem.Name = "buildToolsToolStripMenuItem";
            this.buildToolsToolStripMenuItem.Size = new System.Drawing.Size(96, 18);
            this.buildToolsToolStripMenuItem.Text = "Build Tools";
            // 
            // fusionTrackerToolStripMenuItem
            // 
            this.fusionTrackerToolStripMenuItem.Name = "fusionTrackerToolStripMenuItem";
            this.fusionTrackerToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.fusionTrackerToolStripMenuItem.Text = "Fusion Calculator";
            this.fusionTrackerToolStripMenuItem.Click += new System.EventHandler(this.menu_fusion_calculator);
            // 
            // partOptimizationToolStripMenuItem
            // 
            this.partOptimizationToolStripMenuItem.Name = "partOptimizationToolStripMenuItem";
            this.partOptimizationToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.partOptimizationToolStripMenuItem.Text = "Manual Part Selection";
            this.partOptimizationToolStripMenuItem.Click += new System.EventHandler(this.partOptimizationToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem
            // 
            this.scheduleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clanWarScheduleToolStripMenuItem});
            this.scheduleToolStripMenuItem.Name = "scheduleToolStripMenuItem";
            this.scheduleToolStripMenuItem.Size = new System.Drawing.Size(75, 18);
            this.scheduleToolStripMenuItem.Text = "Schedule";
            // 
            // clanWarScheduleToolStripMenuItem
            // 
            this.clanWarScheduleToolStripMenuItem.Name = "clanWarScheduleToolStripMenuItem";
            this.clanWarScheduleToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.clanWarScheduleToolStripMenuItem.Text = "Clan War Schedule";
            this.clanWarScheduleToolStripMenuItem.Click += new System.EventHandler(this.clanWarScheduleToolStripMenuItem_Click);
            // 
            // inMatchDataToolStripMenuItem
            // 
            this.inMatchDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTraceToolStripMenuItem,
            this.gamelogToolStripMenuItem1,
            this.chatlogToolStripMenuItem1,
            this.netlogToolStripMenuItem1,
            this.gfxlogToolStripMenuItem1});
            this.inMatchDataToolStripMenuItem.Name = "inMatchDataToolStripMenuItem";
            this.inMatchDataToolStripMenuItem.Size = new System.Drawing.Size(96, 18);
            this.inMatchDataToolStripMenuItem.Text = "File Traces";
            this.inMatchDataToolStripMenuItem.Click += new System.EventHandler(this.inMatchDataToolStripMenuItem_Click);
            // 
            // viewTraceToolStripMenuItem
            // 
            this.viewTraceToolStripMenuItem.Name = "viewTraceToolStripMenuItem";
            this.viewTraceToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.viewTraceToolStripMenuItem.Text = "combat.log";
            this.viewTraceToolStripMenuItem.Click += new System.EventHandler(this.viewTraceToolStripMenuItem_Click);
            // 
            // gamelogToolStripMenuItem1
            // 
            this.gamelogToolStripMenuItem1.Name = "gamelogToolStripMenuItem1";
            this.gamelogToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.gamelogToolStripMenuItem1.Text = "game.log";
            this.gamelogToolStripMenuItem1.Click += new System.EventHandler(this.gamelogToolStripMenuItem1_Click);
            // 
            // chatlogToolStripMenuItem1
            // 
            this.chatlogToolStripMenuItem1.Name = "chatlogToolStripMenuItem1";
            this.chatlogToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.chatlogToolStripMenuItem1.Text = "chat.log";
            this.chatlogToolStripMenuItem1.Click += new System.EventHandler(this.chatlogToolStripMenuItem1_Click);
            // 
            // netlogToolStripMenuItem1
            // 
            this.netlogToolStripMenuItem1.Name = "netlogToolStripMenuItem1";
            this.netlogToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.netlogToolStripMenuItem1.Text = "net.log";
            this.netlogToolStripMenuItem1.Click += new System.EventHandler(this.netlogToolStripMenuItem1_Click);
            // 
            // gfxlogToolStripMenuItem1
            // 
            this.gfxlogToolStripMenuItem1.Name = "gfxlogToolStripMenuItem1";
            this.gfxlogToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.gfxlogToolStripMenuItem1.Text = "gfx.log";
            this.gfxlogToolStripMenuItem1.Click += new System.EventHandler(this.gfxlogToolStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(75, 18);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.menu_user_settings_click);
            // 
            // main_page_panel
            // 
            this.main_page_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_page_panel.Location = new System.Drawing.Point(0, 23);
            this.main_page_panel.Name = "main_page_panel";
            this.main_page_panel.Size = new System.Drawing.Size(1195, 600);
            this.main_page_panel.TabIndex = 3;
            // 
            // bw_file_feed
            // 
            this.bw_file_feed.WorkerReportsProgress = true;
            this.bw_file_feed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.process_log_files);
            this.bw_file_feed.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.process_log_event);
            // 
            // partViewToolStripMenuItem
            // 
            this.partViewToolStripMenuItem.Name = "partViewToolStripMenuItem";
            this.partViewToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.partViewToolStripMenuItem.Text = "View Available Parts";
            this.partViewToolStripMenuItem.Click += new System.EventHandler(this.partViewToolStripMenuItem_Click);
            // 
            // automaticPartOptimizerToolStripMenuItem
            // 
            this.automaticPartOptimizerToolStripMenuItem.Name = "automaticPartOptimizerToolStripMenuItem";
            this.automaticPartOptimizerToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.automaticPartOptimizerToolStripMenuItem.Text = "Automatic Part Optimizer";
            // 
            // frm_main_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1195, 623);
            this.Controls.Add(this.main_page_panel);
            this.Controls.Add(this.strp_main_menu_strip);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.strp_main_menu_strip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1211, 662);
            this.Name = "frm_main_page";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rot_Fish_Bandit Tool Suite v0.0.1.1";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.CO_Driver_load);
            this.strp_main_menu_strip.ResumeLayout(false);
            this.strp_main_menu_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem userProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fusionTrackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel main_page_panel;
        private System.Windows.Forms.ToolStripMenuItem inMatchDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTraceToolStripMenuItem;
        public System.Windows.Forms.MenuStrip strp_main_menu_strip;
        private System.Windows.Forms.ToolStripMenuItem gamelogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chatlogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem netlogToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gfxlogToolStripMenuItem1;
        private System.ComponentModel.BackgroundWorker bw_file_feed;
        private System.Windows.Forms.ToolStripMenuItem matchHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clanWarScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partOptimizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticPartOptimizerToolStripMenuItem;
    }
}


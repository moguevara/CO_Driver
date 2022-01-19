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
            this.previousMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liveGarageChartingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateOfYourMetaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revenueAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fusionTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partOptimizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clanWarScheduleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.brawlScheduleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileTracesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combatlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.netlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gfxlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printCurrentWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_page_panel = new System.Windows.Forms.Panel();
            this.bw_file_feed = new System.ComponentModel.BackgroundWorker();
            this.strp_main_menu_strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // strp_main_menu_strip
            // 
            this.strp_main_menu_strip.AutoSize = false;
            this.strp_main_menu_strip.BackColor = System.Drawing.SystemColors.Control;
            this.strp_main_menu_strip.Enabled = false;
            this.strp_main_menu_strip.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strp_main_menu_strip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.strp_main_menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userProfileToolStripMenuItem,
            this.previousMatchToolStripMenuItem,
            this.matchHistoryToolStripMenuItem,
            this.analysisToolStripMenuItem,
            this.buildToolsToolStripMenuItem,
            this.uploadToolStripMenuItem,
            this.printCurrentWindowToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.strp_main_menu_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.strp_main_menu_strip.Location = new System.Drawing.Point(0, 0);
            this.strp_main_menu_strip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.strp_main_menu_strip.Name = "strp_main_menu_strip";
            this.strp_main_menu_strip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.strp_main_menu_strip.Size = new System.Drawing.Size(1193, 22);
            this.strp_main_menu_strip.TabIndex = 2;
            this.strp_main_menu_strip.Text = "menuStrip1";
            this.strp_main_menu_strip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // userProfileToolStripMenuItem
            // 
            this.userProfileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.userProfileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userProfileToolStripMenuItem.Name = "userProfileToolStripMenuItem";
            this.userProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.userProfileToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.userProfileToolStripMenuItem.Text = "Profile";
            this.userProfileToolStripMenuItem.Click += new System.EventHandler(this.userProfileToolStripMenuItem_Click);
            // 
            // previousMatchToolStripMenuItem
            // 
            this.previousMatchToolStripMenuItem.Name = "previousMatchToolStripMenuItem";
            this.previousMatchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.previousMatchToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.previousMatchToolStripMenuItem.Text = "Last Match";
            this.previousMatchToolStripMenuItem.Click += new System.EventHandler(this.previousMatchToolStripMenuItem_Click);
            // 
            // matchHistoryToolStripMenuItem
            // 
            this.matchHistoryToolStripMenuItem.Name = "matchHistoryToolStripMenuItem";
            this.matchHistoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.matchHistoryToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.matchHistoryToolStripMenuItem.Text = "Match History";
            this.matchHistoryToolStripMenuItem.Click += new System.EventHandler(this.matchHistoryToolStripMenuItem_Click);
            // 
            // analysisToolStripMenuItem
            // 
            this.analysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.liveGarageChartingToolStripMenuItem,
            this.buildReviewToolStripMenuItem,
            this.stateOfYourMetaToolStripMenuItem,
            this.revenueAnalysisToolStripMenuItem});
            this.analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            this.analysisToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.analysisToolStripMenuItem.Text = "Analysis Menu";
            // 
            // liveGarageChartingToolStripMenuItem
            // 
            this.liveGarageChartingToolStripMenuItem.Name = "liveGarageChartingToolStripMenuItem";
            this.liveGarageChartingToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.liveGarageChartingToolStripMenuItem.Text = "Garage Weapon Tester";
            this.liveGarageChartingToolStripMenuItem.Click += new System.EventHandler(this.liveGarageChartingToolStripMenuItem_Click);
            // 
            // buildReviewToolStripMenuItem
            // 
            this.buildReviewToolStripMenuItem.Name = "buildReviewToolStripMenuItem";
            this.buildReviewToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.buildReviewToolStripMenuItem.Text = "Build Performance Review";
            this.buildReviewToolStripMenuItem.Click += new System.EventHandler(this.buildReviewToolStripMenuItem_Click);
            // 
            // stateOfYourMetaToolStripMenuItem
            // 
            this.stateOfYourMetaToolStripMenuItem.Name = "stateOfYourMetaToolStripMenuItem";
            this.stateOfYourMetaToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.stateOfYourMetaToolStripMenuItem.Text = "Personal Meta Review";
            this.stateOfYourMetaToolStripMenuItem.Click += new System.EventHandler(this.stateOfYourMetaToolStripMenuItem_Click);
            // 
            // revenueAnalysisToolStripMenuItem
            // 
            this.revenueAnalysisToolStripMenuItem.Name = "revenueAnalysisToolStripMenuItem";
            this.revenueAnalysisToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.revenueAnalysisToolStripMenuItem.Text = "Revenue Analysis";
            this.revenueAnalysisToolStripMenuItem.Click += new System.EventHandler(this.revenueAnalysisToolStripMenuItem_Click);
            // 
            // buildToolsToolStripMenuItem
            // 
            this.buildToolsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.buildToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fusionTrackerToolStripMenuItem,
            this.partViewToolStripMenuItem,
            this.partOptimizationToolStripMenuItem,
            this.scheduleToolStripMenuItem1,
            this.fileTracesToolStripMenuItem});
            this.buildToolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buildToolsToolStripMenuItem.Name = "buildToolsToolStripMenuItem";
            this.buildToolsToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.buildToolsToolStripMenuItem.Text = "Tools Menu";
            this.buildToolsToolStripMenuItem.Click += new System.EventHandler(this.buildToolsToolStripMenuItem_Click);
            // 
            // fusionTrackerToolStripMenuItem
            // 
            this.fusionTrackerToolStripMenuItem.Name = "fusionTrackerToolStripMenuItem";
            this.fusionTrackerToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.fusionTrackerToolStripMenuItem.Text = "Fusion Calculator";
            this.fusionTrackerToolStripMenuItem.Click += new System.EventHandler(this.menu_fusion_calculator);
            // 
            // partViewToolStripMenuItem
            // 
            this.partViewToolStripMenuItem.Name = "partViewToolStripMenuItem";
            this.partViewToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.partViewToolStripMenuItem.Text = "View Available Parts";
            this.partViewToolStripMenuItem.Click += new System.EventHandler(this.partViewToolStripMenuItem_Click);
            // 
            // partOptimizationToolStripMenuItem
            // 
            this.partOptimizationToolStripMenuItem.Name = "partOptimizationToolStripMenuItem";
            this.partOptimizationToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.partOptimizationToolStripMenuItem.Text = "Manual Part Selection";
            this.partOptimizationToolStripMenuItem.Click += new System.EventHandler(this.partOptimizationToolStripMenuItem_Click);
            // 
            // scheduleToolStripMenuItem1
            // 
            this.scheduleToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clanWarScheduleToolStripMenuItem1,
            this.brawlScheduleToolStripMenuItem1});
            this.scheduleToolStripMenuItem1.Name = "scheduleToolStripMenuItem1";
            this.scheduleToolStripMenuItem1.Size = new System.Drawing.Size(258, 26);
            this.scheduleToolStripMenuItem1.Text = "Schedule";
            // 
            // clanWarScheduleToolStripMenuItem1
            // 
            this.clanWarScheduleToolStripMenuItem1.Name = "clanWarScheduleToolStripMenuItem1";
            this.clanWarScheduleToolStripMenuItem1.Size = new System.Drawing.Size(226, 26);
            this.clanWarScheduleToolStripMenuItem1.Text = "Clan War Schedule";
            this.clanWarScheduleToolStripMenuItem1.Click += new System.EventHandler(this.clanWarScheduleToolStripMenuItem1_Click);
            // 
            // brawlScheduleToolStripMenuItem1
            // 
            this.brawlScheduleToolStripMenuItem1.Name = "brawlScheduleToolStripMenuItem1";
            this.brawlScheduleToolStripMenuItem1.Size = new System.Drawing.Size(226, 26);
            this.brawlScheduleToolStripMenuItem1.Text = "Brawl Schedule";
            this.brawlScheduleToolStripMenuItem1.Click += new System.EventHandler(this.brawlScheduleToolStripMenuItem1_Click);
            // 
            // fileTracesToolStripMenuItem
            // 
            this.fileTracesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combatlogToolStripMenuItem,
            this.gamelogToolStripMenuItem,
            this.chatlogToolStripMenuItem,
            this.netlogToolStripMenuItem,
            this.gfxlogToolStripMenuItem});
            this.fileTracesToolStripMenuItem.Name = "fileTracesToolStripMenuItem";
            this.fileTracesToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.fileTracesToolStripMenuItem.Text = "File Traces";
            // 
            // combatlogToolStripMenuItem
            // 
            this.combatlogToolStripMenuItem.Name = "combatlogToolStripMenuItem";
            this.combatlogToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.combatlogToolStripMenuItem.Text = "combat.log";
            this.combatlogToolStripMenuItem.Click += new System.EventHandler(this.combatlogToolStripMenuItem_Click);
            // 
            // gamelogToolStripMenuItem
            // 
            this.gamelogToolStripMenuItem.Name = "gamelogToolStripMenuItem";
            this.gamelogToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.gamelogToolStripMenuItem.Text = "game.log";
            this.gamelogToolStripMenuItem.Click += new System.EventHandler(this.gamelogToolStripMenuItem_Click);
            // 
            // chatlogToolStripMenuItem
            // 
            this.chatlogToolStripMenuItem.Name = "chatlogToolStripMenuItem";
            this.chatlogToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.chatlogToolStripMenuItem.Text = "chat.log";
            this.chatlogToolStripMenuItem.Click += new System.EventHandler(this.chatlogToolStripMenuItem_Click);
            // 
            // netlogToolStripMenuItem
            // 
            this.netlogToolStripMenuItem.Name = "netlogToolStripMenuItem";
            this.netlogToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.netlogToolStripMenuItem.Text = "net.log";
            this.netlogToolStripMenuItem.Click += new System.EventHandler(this.netlogToolStripMenuItem_Click);
            // 
            // gfxlogToolStripMenuItem
            // 
            this.gfxlogToolStripMenuItem.Name = "gfxlogToolStripMenuItem";
            this.gfxlogToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.gfxlogToolStripMenuItem.Text = "gfx.log";
            this.gfxlogToolStripMenuItem.Click += new System.EventHandler(this.gfxlogToolStripMenuItem_Click);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.uploadToolStripMenuItem.Text = "Upload to CrossoutDB";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // printCurrentWindowToolStripMenuItem
            // 
            this.printCurrentWindowToolStripMenuItem.Name = "printCurrentWindowToolStripMenuItem";
            this.printCurrentWindowToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.printCurrentWindowToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.printCurrentWindowToolStripMenuItem.Text = "Capture Window";
            this.printCurrentWindowToolStripMenuItem.Click += new System.EventHandler(this.printCurrentWindowToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.menu_user_settings_click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // main_page_panel
            // 
            this.main_page_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_page_panel.Location = new System.Drawing.Point(0, 22);
            this.main_page_panel.MaximumSize = new System.Drawing.Size(1195, 601);
            this.main_page_panel.MinimumSize = new System.Drawing.Size(1195, 601);
            this.main_page_panel.Name = "main_page_panel";
            this.main_page_panel.Size = new System.Drawing.Size(1195, 601);
            this.main_page_panel.TabIndex = 3;
            // 
            // bw_file_feed
            // 
            this.bw_file_feed.WorkerReportsProgress = true;
            this.bw_file_feed.DoWork += new System.ComponentModel.DoWorkEventHandler(this.process_log_files);
            this.bw_file_feed.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.process_log_event);
            // 
            // frm_main_page
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1193, 615);
            this.Controls.Add(this.main_page_panel);
            this.Controls.Add(this.strp_main_menu_strip);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.strp_main_menu_strip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1211, 662);
            this.MinimumSize = new System.Drawing.Size(1211, 662);
            this.Name = "frm_main_page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rot_Fish_Bandit Tool Suite v0.0.1.1";
            this.Load += new System.EventHandler(this.CO_Driver_load);
            this.strp_main_menu_strip.ResumeLayout(false);
            this.strp_main_menu_strip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem userProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fusionTrackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel main_page_panel;
        public System.Windows.Forms.MenuStrip strp_main_menu_strip;
        private System.ComponentModel.BackgroundWorker bw_file_feed;
        private System.Windows.Forms.ToolStripMenuItem matchHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partOptimizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousMatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printCurrentWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateOfYourMetaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revenueAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clanWarScheduleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem brawlScheduleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileTracesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combatlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem netlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gfxlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liveGarageChartingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildReviewToolStripMenuItem;
    }
}


namespace RFB_Tool_Suite
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
            this.inMatchDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTraceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.combatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.netlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gfxlogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchmakingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clanWarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leviathianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raidsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fusionTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partOptimizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.main_page_panel = new System.Windows.Forms.Panel();
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
            this.inMatchDataToolStripMenuItem,
            this.gameAnalysisToolStripMenuItem,
            this.buildToolsToolStripMenuItem,
            this.chatToolsToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.strp_main_menu_strip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.strp_main_menu_strip.Location = new System.Drawing.Point(0, 0);
            this.strp_main_menu_strip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.strp_main_menu_strip.Name = "strp_main_menu_strip";
            this.strp_main_menu_strip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.strp_main_menu_strip.Size = new System.Drawing.Size(1195, 22);
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
            // 
            // inMatchDataToolStripMenuItem
            // 
            this.inMatchDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTraceToolStripMenuItem});
            this.inMatchDataToolStripMenuItem.Name = "inMatchDataToolStripMenuItem";
            this.inMatchDataToolStripMenuItem.Size = new System.Drawing.Size(82, 18);
            this.inMatchDataToolStripMenuItem.Text = "Live Data";
            this.inMatchDataToolStripMenuItem.Click += new System.EventHandler(this.inMatchDataToolStripMenuItem_Click);
            // 
            // viewTraceToolStripMenuItem
            // 
            this.viewTraceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combatToolStripMenuItem,
            this.gamelogToolStripMenuItem,
            this.chatlogToolStripMenuItem,
            this.netlogToolStripMenuItem,
            this.gfxlogToolStripMenuItem});
            this.viewTraceToolStripMenuItem.Name = "viewTraceToolStripMenuItem";
            this.viewTraceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewTraceToolStripMenuItem.Text = "Trace Logs";
            // 
            // combatToolStripMenuItem
            // 
            this.combatToolStripMenuItem.Name = "combatToolStripMenuItem";
            this.combatToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.combatToolStripMenuItem.Text = "combat.log";
            // 
            // gamelogToolStripMenuItem
            // 
            this.gamelogToolStripMenuItem.Name = "gamelogToolStripMenuItem";
            this.gamelogToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.gamelogToolStripMenuItem.Text = "game.log";
            // 
            // chatlogToolStripMenuItem
            // 
            this.chatlogToolStripMenuItem.Name = "chatlogToolStripMenuItem";
            this.chatlogToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.chatlogToolStripMenuItem.Text = "chat.log";
            // 
            // netlogToolStripMenuItem
            // 
            this.netlogToolStripMenuItem.Name = "netlogToolStripMenuItem";
            this.netlogToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.netlogToolStripMenuItem.Text = "net.log";
            // 
            // gfxlogToolStripMenuItem
            // 
            this.gfxlogToolStripMenuItem.Name = "gfxlogToolStripMenuItem";
            this.gfxlogToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.gfxlogToolStripMenuItem.Text = "gfx.log";
            // 
            // gameAnalysisToolStripMenuItem
            // 
            this.gameAnalysisToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.gameAnalysisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchmakingToolStripMenuItem,
            this.clanWarsToolStripMenuItem,
            this.raidsToolStripMenuItem,
            this.eventToolStripMenuItem});
            this.gameAnalysisToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameAnalysisToolStripMenuItem.Name = "gameAnalysisToolStripMenuItem";
            this.gameAnalysisToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.gameAnalysisToolStripMenuItem.Size = new System.Drawing.Size(110, 18);
            this.gameAnalysisToolStripMenuItem.Text = "Game Analysis";
            // 
            // matchmakingToolStripMenuItem
            // 
            this.matchmakingToolStripMenuItem.Name = "matchmakingToolStripMenuItem";
            this.matchmakingToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.matchmakingToolStripMenuItem.Text = "Matchmaking";
            // 
            // clanWarsToolStripMenuItem
            // 
            this.clanWarsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.leviathianToolStripMenuItem});
            this.clanWarsToolStripMenuItem.Name = "clanWarsToolStripMenuItem";
            this.clanWarsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.clanWarsToolStripMenuItem.Text = "Clan Wars";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.standardToolStripMenuItem.Text = "Standard";
            // 
            // leviathianToolStripMenuItem
            // 
            this.leviathianToolStripMenuItem.Name = "leviathianToolStripMenuItem";
            this.leviathianToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.leviathianToolStripMenuItem.Text = "Leviathian";
            // 
            // raidsToolStripMenuItem
            // 
            this.raidsToolStripMenuItem.Name = "raidsToolStripMenuItem";
            this.raidsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.raidsToolStripMenuItem.Text = "Raids";
            // 
            // eventToolStripMenuItem
            // 
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            this.eventToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.eventToolStripMenuItem.Text = "Event";
            // 
            // buildToolsToolStripMenuItem
            // 
            this.buildToolsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.buildToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fusionTrackerToolStripMenuItem,
            this.partOptimizationToolStripMenuItem,
            this.buildManagmentToolStripMenuItem});
            this.buildToolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buildToolsToolStripMenuItem.Name = "buildToolsToolStripMenuItem";
            this.buildToolsToolStripMenuItem.Size = new System.Drawing.Size(96, 18);
            this.buildToolsToolStripMenuItem.Text = "Build Tools";
            // 
            // fusionTrackerToolStripMenuItem
            // 
            this.fusionTrackerToolStripMenuItem.Name = "fusionTrackerToolStripMenuItem";
            this.fusionTrackerToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.fusionTrackerToolStripMenuItem.Text = "Fusion Calculator";
            this.fusionTrackerToolStripMenuItem.Click += new System.EventHandler(this.menu_fusion_calculator);
            // 
            // partOptimizationToolStripMenuItem
            // 
            this.partOptimizationToolStripMenuItem.Name = "partOptimizationToolStripMenuItem";
            this.partOptimizationToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.partOptimizationToolStripMenuItem.Text = "Part Optimization";
            // 
            // buildManagmentToolStripMenuItem
            // 
            this.buildManagmentToolStripMenuItem.Name = "buildManagmentToolStripMenuItem";
            this.buildManagmentToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.buildManagmentToolStripMenuItem.Text = "Build Managment";
            // 
            // chatToolsToolStripMenuItem
            // 
            this.chatToolsToolStripMenuItem.Name = "chatToolsToolStripMenuItem";
            this.chatToolsToolStripMenuItem.Size = new System.Drawing.Size(89, 18);
            this.chatToolsToolStripMenuItem.Text = "Chat Tools";
            this.chatToolsToolStripMenuItem.Click += new System.EventHandler(this.chatToolsToolStripMenuItem_Click);
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
            this.main_page_panel.Location = new System.Drawing.Point(0, 22);
            this.main_page_panel.Name = "main_page_panel";
            this.main_page_panel.Size = new System.Drawing.Size(1195, 601);
            this.main_page_panel.TabIndex = 3;
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.strp_main_menu_strip.ResumeLayout(false);
            this.strp_main_menu_strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem userProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchmakingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clanWarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leviathianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raidsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fusionTrackerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partOptimizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildManagmentToolStripMenuItem;
        private System.Windows.Forms.Panel main_page_panel;
        private System.Windows.Forms.ToolStripMenuItem chatToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inMatchDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTraceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem netlogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gfxlogToolStripMenuItem;
        public System.Windows.Forms.MenuStrip strp_main_menu_strip;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RFB_Tool_Suite
{
    public partial class frm_main_page : Form
    {
        public frm_main_page()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            main_page_panel.Controls.Add(new welcome_page());
            this.Text = string.Format(@"Rot_Fish_Bandit Tool Suite v{0}", global_data.CURRENT_VERSION);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_user_profile_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menu_user_settings_click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new user_settings());
        }

        private void clear_main_page_panel()
        {
            foreach (Control ctrl in main_page_panel.Controls)
                ctrl.Dispose();
            main_page_panel.Controls.Clear();
        }

        private void menu_fusion_calculator(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new fusion_calculator());
        }

        private void chatToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inMatchDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void initialize_global_data()
        {
            
        }

        private void combatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Combat"));
        }

        private void gamelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Game"));
        }

        private void chatlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Chat"));
        }

        private void netlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Net"));
        }

        private void gfxlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_main_page_panel();
            main_page_panel.Controls.Add(new trace_view("Gfx"));
        }
    }
}

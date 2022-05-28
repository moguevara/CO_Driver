using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class part_optimizer : UserControl
    {
        public List<PartLoader.Part> master_part_list = new List<PartLoader.Part> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public double resistance_modifier = 1.0;
        public part_optimizer()
        {
            InitializeComponent();
        }

        public void refresh_avail_parts()
        {
            this.dg_available_parts.Rows.Clear();
            this.dg_selected_parts.Rows.Clear();

            int engineer_level = session.EngineerLevel;
            int lunatics_level = session.LunaticsLevel;
            int nomads_level = session.NomadsLevel;
            int scavengers_level = session.ScavengersLevel;
            int steppenwolfs_level = session.SteppenWolfLevel;
            int dawns_children_level = session.DawnsChildrenLevel;
            int firestarts_level = session.FireStartersLevel;
            int founders_level = session.FoundersLevel;
            bool prestigue_parts = session.IncludePresitgueParts;

            this.dg_available_parts.AllowUserToAddRows = true;
            this.dg_selected_parts.AllowUserToAddRows = true;

            for (int i = 0; i < master_part_list.Count(); i++)
            {
                if (master_part_list[i].Faction == GlobalData.ENGINEER_FACTION && master_part_list[i].Level > engineer_level)
                    continue;
                if (master_part_list[i].Faction == GlobalData.LUNATICS_FACTION && master_part_list[i].Level > lunatics_level)
                    continue;
                if (master_part_list[i].Faction == GlobalData.NOMADS_FACTION && master_part_list[i].Level > nomads_level)
                    continue;
                if (master_part_list[i].Faction == GlobalData.SCAVENGERS_FACTION && master_part_list[i].Level > scavengers_level)
                    continue;
                if (master_part_list[i].Faction == GlobalData.STEPPENWOLFS_FACTION && master_part_list[i].Level > steppenwolfs_level)
                    continue;
                if (master_part_list[i].Faction == GlobalData.DAWNS_CHILDREN_FACTION && master_part_list[i].Level > dawns_children_level)
                    continue;
                if (master_part_list[i].Faction == GlobalData.FIRESTARTERS_FACTION && master_part_list[i].Level > firestarts_level)
                    continue;
                if (master_part_list[i].Faction == GlobalData.FOUNDERS_FACTION && master_part_list[i].Level > founders_level)
                    continue;
                //if (master_part_list[i].faction == global_data.PRESTIGUE_PACK_FACTION && prestigue_parts == true)
                //    continue;

                DataGridViewRow row = (DataGridViewRow)this.dg_available_parts.Rows[0].Clone();
                row.Cells[0].Value = master_part_list[i].Description;
                row.Cells[1].Value = Math.Round(master_part_list[i].PartDurability * resistance_modifier);
                row.Cells[2].Value = Math.Round(master_part_list[i].HullDurability * resistance_modifier);
                row.Cells[3].Value = master_part_list[i].Mass;
                row.Cells[4].Value = master_part_list[i].PowerScore;
                row.Cells[5].Value = Math.Round(Math.Round((double)master_part_list[i].PartDurability * resistance_modifier) / (double)master_part_list[i].Mass, 2);
                row.Cells[6].Value = Math.Round(Math.Round((double)master_part_list[i].PowerScore * resistance_modifier) / (double)master_part_list[i].Mass, 2);
                this.dg_available_parts.Rows.Add(row);
            }
            this.dg_available_parts.AllowUserToAddRows = false;
            this.dg_selected_parts.AllowUserToAddRows = false;

            this.lb_total_parts.Text = "0";
            this.lb_effective_dura.Text = "0";
            this.lb_hull_dura.Text = "0";
            this.lb_effective_melee_dura.Text = "0";
            this.lb_effective_bullet_dura.Text = "0";
            this.lb_mass.Text = "0";
            this.lb_power_score.Text = "0";
        }

        private void dg_available_parts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                for (int i = 0; i < master_part_list.Count(); i++)
                {
                    if (this.dg_available_parts.Rows[e.RowIndex].Cells[0].Value.ToString() == master_part_list[i].Description)
                    {
                        this.dg_selected_parts.AllowUserToAddRows = true;
                        DataGridViewRow row = (DataGridViewRow)this.dg_selected_parts.Rows[0].Clone();
                        row.Cells[0].Value = master_part_list[i].Description;
                        row.Cells[1].Value = Math.Round(master_part_list[i].PartDurability * resistance_modifier);
                        row.Cells[2].Value = master_part_list[i].Mass;
                        row.Cells[3].Value = master_part_list[i].PowerScore;
                        this.dg_selected_parts.Rows.Add(row);
                        this.dg_available_parts.Rows.RemoveAt(e.RowIndex);

                        this.lb_total_parts.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_total_parts.Text) + 1);
                        this.lb_effective_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_dura.Text) + Math.Round(master_part_list[i].PartDurability * resistance_modifier));
                        this.lb_hull_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_hull_dura.Text) + Math.Round(master_part_list[i].HullDurability * resistance_modifier));
                        this.lb_effective_melee_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_melee_dura.Text) + Math.Round(master_part_list[i].PartDurability * (master_part_list[i].MeleeResistance + resistance_modifier)));
                        this.lb_effective_bullet_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_bullet_dura.Text) + Math.Round(master_part_list[i].PartDurability * (master_part_list[i].BulletResistance + resistance_modifier)));
                        this.lb_mass.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_mass.Text) + master_part_list[i].Mass);
                        this.lb_power_score.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_power_score.Text) + master_part_list[i].PowerScore);
                        break;
                    }
                }

                this.dg_selected_parts.AllowUserToAddRows = false;
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            refresh_avail_parts();
        }

        private void dg_selected_parts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                for (int i = 0; i < master_part_list.Count(); i++)
                {
                    if (this.dg_selected_parts.Rows[e.RowIndex].Cells[0].Value.ToString() == master_part_list[i].Description)
                    {
                        this.dg_available_parts.AllowUserToAddRows = true;
                        DataGridViewRow row = (DataGridViewRow)this.dg_available_parts.Rows[0].Clone();
                        row.Cells[0].Value = master_part_list[i].Description;
                        row.Cells[1].Value = master_part_list[i].PartDurability;
                        row.Cells[2].Value = master_part_list[i].HullDurability;
                        row.Cells[3].Value = master_part_list[i].Mass;
                        row.Cells[4].Value = master_part_list[i].PowerScore;
                        row.Cells[5].Value = Math.Round(Math.Round((double)master_part_list[i].PartDurability * resistance_modifier) / (double)master_part_list[i].Mass, 2);
                        row.Cells[6].Value = Math.Round(Math.Round((double)master_part_list[i].PowerScore * resistance_modifier) / (double)master_part_list[i].Mass, 2);
                        this.dg_available_parts.Rows.Add(row);
                        this.dg_selected_parts.Rows.RemoveAt(e.RowIndex);

                        this.dg_available_parts.AllowUserToAddRows = false;
                        this.lb_total_parts.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_total_parts.Text) - 1);
                        this.lb_effective_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_dura.Text) - Math.Round(master_part_list[i].PartDurability * resistance_modifier));
                        this.lb_hull_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_hull_dura.Text) - Math.Round(master_part_list[i].HullDurability * resistance_modifier));
                        this.lb_effective_melee_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_melee_dura.Text) - Math.Round(master_part_list[i].PartDurability * (master_part_list[i].MeleeResistance + resistance_modifier)));
                        this.lb_effective_bullet_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_bullet_dura.Text) - Math.Round(master_part_list[i].PartDurability * (master_part_list[i].BulletResistance + resistance_modifier)));
                        this.lb_mass.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_mass.Text) - master_part_list[i].Mass);
                        this.lb_power_score.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_power_score.Text) - master_part_list[i].PowerScore);
                        break;
                    }
                }
            }
        }

        private void lb_hull_dura_Click(object sender, EventArgs e)
        {

        }

        private void lb_power_score_Click(object sender, EventArgs e)
        {

        }

        private void lb_effective_melee_dura_Click(object sender, EventArgs e)
        {

        }

        private void check_3_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_3_percent.Checked == true)
                resistance_modifier = resistance_modifier + 0.03;
            else
                resistance_modifier = resistance_modifier - 0.03;
            refresh_avail_parts();
        }

        private void chk_10_percent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_10_percent.Checked == true)
                resistance_modifier = resistance_modifier + 0.1;
            else
                resistance_modifier = resistance_modifier - 0.1;
            refresh_avail_parts();
        }

        private void part_optimizer_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void part_optimizer_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CO_Driver.Properties;

namespace CO_Driver
{
    public partial class part_optimizer : UserControl
    {
        public List<part_loader.Part> master_part_list = new List<part_loader.Part> { };
        public double resistance_modifier = 1.0;
        public part_optimizer()
        {
            InitializeComponent();
        }

        public void refresh_avail_parts()
        {
            this.dg_available_parts.Rows.Clear();
            this.dg_selected_parts.Rows.Clear();

            int engineer_level = Convert.ToInt32(Settings.Default["engineer_level"]);
            int lunatics_level = Convert.ToInt32(Settings.Default["lunatics_level"]);
            int nomads_level = Convert.ToInt32(Settings.Default["nomads_level"]);
            int scavengers_level = Convert.ToInt32(Settings.Default["scavengers_level"]);
            int steppenwolfs_level = Convert.ToInt32(Settings.Default["steppenwolfs_level"]);
            int dawns_children_level = Convert.ToInt32(Settings.Default["dawns_children_level"]);
            int firestarts_level = Convert.ToInt32(Settings.Default["firestarts_level"]);
            int founders_level = Convert.ToInt32(Settings.Default["founders_level"]);
            bool prestigue_parts = Convert.ToBoolean(Settings.Default["include_prestigue_parts"]);

            this.dg_available_parts.AllowUserToAddRows = true;
            this.dg_selected_parts.AllowUserToAddRows = true;

            for (int i = 0; i < master_part_list.Count(); i++)
            {
                if (master_part_list[i].faction == global_data.ENGINEER_FACTION && master_part_list[i].level > engineer_level)
                    continue;
                if (master_part_list[i].faction == global_data.LUNATICS_FACTION && master_part_list[i].level > lunatics_level)
                    continue;
                if (master_part_list[i].faction == global_data.NOMADS_FACTION && master_part_list[i].level > nomads_level)
                    continue;
                if (master_part_list[i].faction == global_data.SCAVENGERS_FACTION && master_part_list[i].level > scavengers_level)
                    continue;
                if (master_part_list[i].faction == global_data.STEPPENWOLFS_FACTION && master_part_list[i].level > steppenwolfs_level)
                    continue;
                if (master_part_list[i].faction == global_data.DAWNS_CHILDREN_FACTION && master_part_list[i].level > dawns_children_level)
                    continue;
                if (master_part_list[i].faction == global_data.FIRESTARTERS_FACTION && master_part_list[i].level > firestarts_level)
                    continue;
                if (master_part_list[i].faction == global_data.FOUNDERS_FACTION && master_part_list[i].level > founders_level)
                    continue;
                //if (master_part_list[i].faction == global_data.PRESTIGUE_PACK_FACTION && prestigue_parts == true)
                //    continue;

                DataGridViewRow row = (DataGridViewRow)this.dg_available_parts.Rows[0].Clone();
                row.Cells[0].Value = master_part_list[i].description;
                row.Cells[1].Value = Math.Round(master_part_list[i].part_durability * resistance_modifier);
                row.Cells[2].Value = Math.Round(master_part_list[i].hull_durability * resistance_modifier);
                row.Cells[3].Value = master_part_list[i].mass;
                row.Cells[4].Value = master_part_list[i].power_score;
                row.Cells[5].Value = Math.Round(Math.Round((double)master_part_list[i].part_durability * resistance_modifier) / (double)master_part_list[i].mass, 2);
                row.Cells[6].Value = Math.Round(Math.Round((double)master_part_list[i].power_score * resistance_modifier) / (double)master_part_list[i].mass, 2);
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
                    if (this.dg_available_parts.Rows[e.RowIndex].Cells[0].Value.ToString() == master_part_list[i].description)
                    {
                        this.dg_selected_parts.AllowUserToAddRows = true;
                        DataGridViewRow row = (DataGridViewRow)this.dg_selected_parts.Rows[0].Clone();
                        row.Cells[0].Value = master_part_list[i].description;
                        row.Cells[1].Value = Math.Round(master_part_list[i].part_durability * resistance_modifier);
                        row.Cells[2].Value = master_part_list[i].mass;
                        row.Cells[3].Value = master_part_list[i].power_score;
                        this.dg_selected_parts.Rows.Add(row);
                        this.dg_available_parts.Rows.RemoveAt(e.RowIndex);

                        this.lb_total_parts.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_total_parts.Text) + 1);
                        this.lb_effective_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_dura.Text) + Math.Round(master_part_list[i].part_durability * resistance_modifier));
                        this.lb_hull_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_hull_dura.Text) + Math.Round(master_part_list[i].hull_durability * resistance_modifier));
                        this.lb_effective_melee_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_melee_dura.Text) + Math.Round(master_part_list[i].part_durability * (master_part_list[i].melee_resistance + resistance_modifier)));
                        this.lb_effective_bullet_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_bullet_dura.Text) + Math.Round(master_part_list[i].part_durability * (master_part_list[i].bullet_resistance + resistance_modifier)));
                        this.lb_mass.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_mass.Text) + master_part_list[i].mass);
                        this.lb_power_score.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_power_score.Text) + master_part_list[i].power_score);
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
                    if (this.dg_selected_parts.Rows[e.RowIndex].Cells[0].Value.ToString() == master_part_list[i].description)
                    {
                        this.dg_available_parts.AllowUserToAddRows = true;
                        DataGridViewRow row = (DataGridViewRow)this.dg_available_parts.Rows[0].Clone();
                        row.Cells[0].Value = master_part_list[i].description;
                        row.Cells[1].Value = master_part_list[i].part_durability;
                        row.Cells[2].Value = master_part_list[i].hull_durability;
                        row.Cells[3].Value = master_part_list[i].mass;
                        row.Cells[4].Value = master_part_list[i].power_score;
                        row.Cells[5].Value = Math.Round(Math.Round((double)master_part_list[i].part_durability * resistance_modifier) / (double)master_part_list[i].mass, 2);
                        row.Cells[6].Value = Math.Round(Math.Round((double)master_part_list[i].power_score * resistance_modifier) / (double)master_part_list[i].mass, 2);
                        this.dg_available_parts.Rows.Add(row);
                        this.dg_selected_parts.Rows.RemoveAt(e.RowIndex);

                        this.dg_available_parts.AllowUserToAddRows = false;
                        this.lb_total_parts.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_total_parts.Text) - 1);
                        this.lb_effective_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_dura.Text) - Math.Round(master_part_list[i].part_durability * resistance_modifier));
                        this.lb_hull_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_hull_dura.Text) - Math.Round(master_part_list[i].hull_durability * resistance_modifier));
                        this.lb_effective_melee_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_melee_dura.Text) - Math.Round(master_part_list[i].part_durability * (master_part_list[i].melee_resistance + resistance_modifier)));
                        this.lb_effective_bullet_dura.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_effective_bullet_dura.Text) - Math.Round(master_part_list[i].part_durability * (master_part_list[i].bullet_resistance + resistance_modifier)));
                        this.lb_mass.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_mass.Text) - master_part_list[i].mass);
                        this.lb_power_score.Text = string.Format(@"{0}", Convert.ToInt32(this.lb_power_score.Text) - master_part_list[i].power_score);
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
    }
}

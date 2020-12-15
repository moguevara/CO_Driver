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
    public partial class part_view : UserControl
    {
        public List<file_trace_managment.Part> master_part_list = new List<file_trace_managment.Part> { };

        private class unique_parts
        {
            public int part_count { get; set; }
            public file_trace_managment.Part part { get; set; }
        }

        public part_view()
        {
            InitializeComponent();
        }

        public void populate_parts_list()
        {
            this.dg_available_parts.Rows.Clear();

            List<unique_parts> part_list = new List<unique_parts> { };
            file_trace_managment ftm = new file_trace_managment { };

            int engineer_level = Convert.ToInt32(Settings.Default["engineer_level"]);
            int lunatics_level = Convert.ToInt32(Settings.Default["lunatics_level"]);
            int nomads_level = Convert.ToInt32(Settings.Default["nomads_level"]);
            int scavengers_level = Convert.ToInt32(Settings.Default["scavengers_level"]);
            int steppenwolfs_level = Convert.ToInt32(Settings.Default["steppenwolfs_level"]);
            int dawns_children_level = Convert.ToInt32(Settings.Default["dawns_children_level"]);
            int firestarts_level = Convert.ToInt32(Settings.Default["firestarts_level"]);
            int founders_level = Convert.ToInt32(Settings.Default["founders_level"]);
            bool prestigue_parts = Convert.ToBoolean(Settings.Default["include_prestigue_parts"]);

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

                if (part_list.Exists(x => x.part.description.Contains(master_part_list[i].description)))
                {
                    part_list.Find(x => x.part.description.Contains(master_part_list[i].description)).part_count++;
                    continue;
                }
                part_list.Add(new unique_parts { part_count = 1, part = master_part_list[i]});
            }

            this.dg_available_parts.AllowUserToAddRows = true;

            foreach (unique_parts part in part_list) 
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_available_parts.Rows[0].Clone();
                row.Cells[0].Value = part.part.description.ToString();
                row.Cells[1].Value = part.part_count;
                row.Cells[2].Value = part.part.faction == global_data.PRESTIGUE_PACK_FACTION ? ftm.decode_faction_name(part.part.level) + " - Prestigue" : ftm.decode_faction_name(part.part.faction);
                row.Cells[3].Value = part.part.faction == global_data.PRESTIGUE_PACK_FACTION ? 0 : part.part.level;
                row.Cells[4].Value = part.part.part_durability;
                row.Cells[5].Value = part.part.hull_durability;
                row.Cells[6].Value = part.part.mass;
                row.Cells[7].Value = part.part.power_score;
                row.Cells[8].Value = part.part.pass_through;
                row.Cells[9].Value = part.part.bullet_resistance;
                row.Cells[10].Value = part.part.melee_resistance;
                row.Cells[11].Value = Math.Round((double)part.part.part_durability / (double)part.part.mass, 2);
                row.Cells[12].Value = Math.Round((double)part.part.power_score / (double)part.part.mass, 2);
                this.dg_available_parts.Rows.Add(row);
            }
            this.dg_available_parts.AllowUserToAddRows = false;
        }
    }
}

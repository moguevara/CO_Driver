﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class part_view : UserControl
    {
        public List<part_loader.Part> master_part_list = new List<part_loader.Part> { };
        public LogFileManagment.SessionVariables session;
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

        private class unique_parts
        {
            public int part_count { get; set; }
            public part_loader.Part part { get; set; }
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

            int engineer_level = session.EngineerLevel;
            int lunatics_level = session.LunaticsLevel;
            int nomads_level = session.NomadsLevel;
            int scavengers_level = session.ScavengersLevel;
            int steppenwolfs_level = session.SteppenWolfLevel;
            int dawns_children_level = session.DawnsChildrenLevel;
            int firestarts_level = session.FireStartersLevel;
            int founders_level = session.FoundersLevel;
            bool prestigue_parts = session.IncludePresitgueParts;

            for (int i = 0; i < master_part_list.Count(); i++)
            {
                if (master_part_list[i].faction == GlobalData.ENGINEER_FACTION && master_part_list[i].level > engineer_level)
                    continue;
                if (master_part_list[i].faction == GlobalData.LUNATICS_FACTION && master_part_list[i].level > lunatics_level)
                    continue;
                if (master_part_list[i].faction == GlobalData.NOMADS_FACTION && master_part_list[i].level > nomads_level)
                    continue;
                if (master_part_list[i].faction == GlobalData.SCAVENGERS_FACTION && master_part_list[i].level > scavengers_level)
                    continue;
                if (master_part_list[i].faction == GlobalData.STEPPENWOLFS_FACTION && master_part_list[i].level > steppenwolfs_level)
                    continue;
                if (master_part_list[i].faction == GlobalData.DAWNS_CHILDREN_FACTION && master_part_list[i].level > dawns_children_level)
                    continue;
                if (master_part_list[i].faction == GlobalData.FIRESTARTERS_FACTION && master_part_list[i].level > firestarts_level)
                    continue;
                if (master_part_list[i].faction == GlobalData.FOUNDERS_FACTION && master_part_list[i].level > founders_level)
                    continue;
                //if (master_part_list[i].faction == global_data.PRESTIGUE_PACK_FACTION && prestigue_parts == true)
                //    continue;

                if ((int)num_min_dura.Value != 0 && master_part_list[i].part_durability < num_min_dura.Value)
                    continue;

                if (!chk_include_bumpers.Checked && master_part_list[i].hull_durability == 0)
                    continue;

                if (part_list.Exists(x => x.part.description.Contains(master_part_list[i].description)))
                {
                    part_list.Find(x => x.part.description.Contains(master_part_list[i].description)).part_count++;
                    continue;
                }
                part_list.Add(new unique_parts { part_count = 1, part = master_part_list[i] });
            }

            this.dg_available_parts.AllowUserToAddRows = true;

            foreach (unique_parts part in part_list)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_available_parts.Rows[0].Clone();
                row.Cells[0].Value = part.part.description.ToString();
                row.Cells[1].Value = part.part_count;
                row.Cells[2].Value = part.part.faction == GlobalData.PRESTIGUE_PACK_FACTION ? ftm.decode_faction_name(part.part.level) + " - Prestigue" : ftm.decode_faction_name(part.part.faction);
                row.Cells[3].Value = part.part.faction == GlobalData.PRESTIGUE_PACK_FACTION ? 0 : part.part.level;
                row.Cells[4].Value = part.part.part_durability;
                row.Cells[5].Value = part.part.hull_durability;
                row.Cells[6].Value = part.part.mass;
                row.Cells[7].Value = part.part.power_score;
                row.Cells[8].Value = part.part.pass_through;
                row.Cells[9].Value = part.part.bullet_resistance;
                row.Cells[10].Value = part.part.melee_resistance;
                row.Cells[11].Value = Math.Round((double)part.part.part_durability / (double)part.part.power_score, 2);
                row.Cells[12].Value = Math.Round((double)part.part.part_durability / (double)part.part.mass, 2);
                row.Cells[13].Value = Math.Round((double)part.part.mass / (double)part.part.power_score, 2);
                row.Cells[14].Value = Math.Round((double)part.part.mass / (double)part.part.part_durability, 2);
                row.Cells[15].Value = Math.Round((double)part.part.power_score / (double)part.part.part_durability, 2);
                row.Cells[16].Value = Math.Round((double)part.part.power_score / (double)part.part.mass, 2);
                this.dg_available_parts.Rows.Add(row);
            }
            this.dg_available_parts.AllowUserToAddRows = false;
        }

        private void chk_include_bumpers_CheckedChanged(object sender, EventArgs e)
        {
            populate_parts_list();
        }

        private void num_min_dura_ValueChanged(object sender, EventArgs e)
        {
            populate_parts_list();
        }

        private void part_view_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.record_initial_sizes(this);
        }

        private void part_view_Resize(object sender, EventArgs e)
        {
            resize.resize(this);
        }
    }
}

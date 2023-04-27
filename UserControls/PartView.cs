using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class PartView : UserControl
    {
        public List<PartLoader.Structure> master_part_list = new List<PartLoader.Structure> { };
        public LogFileManagment.SessionVariables session;
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

        private class unique_parts
        {
            public int part_count { get; set; }
            public PartLoader.Structure part { get; set; }
        }

        public PartView()
        {
            InitializeComponent();
        }

        public void populate_parts_list()
        {
            this.dg_available_parts.Rows.Clear();

            List<unique_parts> part_list = new List<unique_parts> { };
            FileTraceManagment ftm = new FileTraceManagment { };

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

                if ((int)num_min_dura.Value != 0 && master_part_list[i].PartDurability < num_min_dura.Value)
                    continue;

                if (!chk_include_bumpers.Checked && master_part_list[i].HullDurability == 0)
                    continue;

                if (part_list.Exists(x => x.part.Description.Contains(master_part_list[i].Description)))
                {
                    part_list.Find(x => x.part.Description.Contains(master_part_list[i].Description)).part_count++;
                    continue;
                }
                part_list.Add(new unique_parts { part_count = 1, part = master_part_list[i] });
            }

            this.dg_available_parts.AllowUserToAddRows = true;

            foreach (unique_parts part in part_list)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_available_parts.Rows[0].Clone();
                row.Cells[0].Value = part.part.Description.ToString();
                row.Cells[1].Value = part.part.Faction == GlobalData.PRESTIGUE_PACK_FACTION ? ftm.DecodeFactionName(part.part.Level) + " - Prestigue" : ftm.DecodeFactionName(part.part.Faction);
                row.Cells[2].Value = part.part.Faction == GlobalData.PRESTIGUE_PACK_FACTION ? 0 : part.part.Level;
                row.Cells[3].Value = part.part.PartDurability;
                row.Cells[4].Value = part.part.HullDurability;
                row.Cells[5].Value = part.part.Mass;
                row.Cells[6].Value = part.part.PowerScore;
                row.Cells[7].Value = part.part.PassThrough;
                row.Cells[8].Value = part.part.BulletResistance;
                row.Cells[9].Value = part.part.MeleeResistance;
                row.Cells[10].Value = Math.Round((double)part.part.PartDurability / (double)part.part.PowerScore, 2);
                row.Cells[11].Value = Math.Round((double)part.part.PartDurability / (double)part.part.Mass, 2);
                row.Cells[12].Value = Math.Round((double)part.part.Mass / (double)part.part.PowerScore, 2);
                row.Cells[13].Value = Math.Round((double)part.part.Mass / (double)part.part.PartDurability, 2);
                row.Cells[14].Value = Math.Round((double)part.part.PowerScore / (double)part.part.PartDurability, 2);
                row.Cells[15].Value = Math.Round((double)part.part.PowerScore / (double)part.part.Mass, 2);
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
            resize.RecordInitialSizes(this);
        }

        private void part_view_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }

        private void dg_available_parts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

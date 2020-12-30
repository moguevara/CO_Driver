using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using CO_Driver.Properties;
using System.Globalization;

namespace CO_Driver
{
    public partial class build_view : UserControl
    {
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        private int match_type = global_data.ALL_MATCHS;
        public build_view()
        {
            InitializeComponent();

        }

        public void populate_build_record_table()
        {
            this.dg_build_view_grid.Rows.Clear();
            this.dg_build_view_grid.AllowUserToAddRows = true;
            int rows_populated = 0;

            this.tb_build_description.Text = "";
            this.tb_short_desc.Text = "";
            this.tb_cabin.Text = "";
            this.tb_modules.Text = "";
            this.tb_weapons.Text = "";
            this.tb_movement.Text = "";
            this.tb_modules.Text = "";
            this.tb_modules.Text = "";
            this.tb_modules.Text = "";
            this.tb_build_parts.Text = "";

            foreach (KeyValuePair<string, file_trace_managment.BuildRecord> build in build_records)
            {
                if (!build.Value.build_stats.ContainsKey(match_type))
                    continue;
                DataGridViewRow row = (DataGridViewRow)this.dg_build_view_grid.Rows[0].Clone();
                row.Cells[0].Value = build.Key;
                row.Cells[1].Value = build.Value.power_score;
                row.Cells[2].Value = build.Value.build_stats[match_type].games;
                row.Cells[3].Value = build.Value.build_stats[match_type].kills;
                row.Cells[4].Value = Math.Round(build.Value.build_stats[match_type].deaths > 0 ? (double)build.Value.build_stats[match_type].kills / (double)build.Value.build_stats[match_type].deaths : 0.0, 2);
                row.Cells[5].Value = Math.Round((double)build.Value.build_stats[match_type].damage / (double)build.Value.build_stats[match_type].rounds, 1);
                row.Cells[6].Value = Math.Round((double)build.Value.build_stats[match_type].damage_taken / (double)build.Value.build_stats[match_type].rounds, 1);
                row.Cells[7].Value = build.Value.build_stats[match_type].wins;
                row.Cells[8].Value = Math.Round(build.Value.build_stats[match_type].losses > 0 ? (double)build.Value.build_stats[match_type].wins / (double)build.Value.build_stats[match_type].games : 0.0, 2);

                this.dg_build_view_grid.Rows.Add(row);
                rows_populated++;
            }
            if (rows_populated > 0 && build_records.ContainsKey(this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()))
            {
                this.dg_build_view_grid.Sort(this.dg_build_view_grid.Columns[2], ListSortDirection.Descending);

                this.tb_build_description.Text = build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].full_description;
                this.tb_short_desc.Text = build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].short_description;
                this.tb_cabin.Text = build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].cabin.description;
                this.tb_modules.Text = build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].engine.description;
                this.tb_weapons.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].weapons.Select(x => x.description));
                this.tb_movement.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].movement.Select(x => x.description));
                this.tb_modules.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].modules.Select(x => x.description));
                this.tb_modules.Text += string.Join(",", build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].engine.description);
                this.tb_modules.Text += string.Join(",", build_records[this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].explosives.Select(x => x.description));
                this.tb_build_parts.Text = string.Join(",", build_records[dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].parts);
            }

            this.dg_build_view_grid.AllowUserToAddRows = false;
            this.lb_build_header.Focus();
            this.dg_build_view_grid.ClearSelection();
        }

        private void dg_build_view_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tb_build_parts.Clear();
            if (this.dg_build_view_grid.Rows.Count > 0 && e.RowIndex >= 0)
            {
                this.tb_build_description.Text = build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].full_description;
                this.tb_short_desc.Text = build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].short_description;
                this.tb_cabin.Text = build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].cabin.description;
                this.tb_modules.Text = build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].engine.description;
                this.tb_weapons.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].weapons.Select(x =>x.description));
                this.tb_movement.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].movement.Select(x => x.description));
                this.tb_modules.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].modules.Select(x => x.description));
                this.tb_modules.Text += string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].engine.description);
                this.tb_modules.Text += string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].explosives.Select(x => x.description));
                this.tb_build_parts.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].parts);
            }
        }

        private void build_view_Load(object sender, EventArgs e)
        {
            this.cb_build_game_modes.Items.Clear();

            for (int i = 0; i < global_data.MATCH_CATEGORY_COUNT; i++)
            {
                this.cb_build_game_modes.Items.Add(file_trace_managment.decode_match_type(i));
            }
            this.cb_build_game_modes.SelectedIndex = 0;
        }

        private void cb_build_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_build_game_modes.SelectedIndex >= 0)
                match_type = this.cb_build_game_modes.SelectedIndex;
            populate_build_record_table();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cb_build_game_modes_DropDownClosed(object sender, EventArgs e)
        {

        }
    }
}

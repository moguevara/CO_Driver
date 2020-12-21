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
        public build_view()
        {
            InitializeComponent();
        }

        public void populate_build_record_table()
        {
            this.dg_build_view_grid.Rows.Clear();

            foreach (KeyValuePair<string, file_trace_managment.BuildRecord> build in build_records)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_build_view_grid.Rows[0].Clone();
                row.Cells[0].Value = build.Key;
                row.Cells[1].Value = build.Value.total_build_stats.games;
                row.Cells[2].Value = build.Value.total_build_stats.kills;
                row.Cells[3].Value = build.Value.total_build_stats.deaths;
                row.Cells[4].Value = Math.Round(build.Value.total_build_stats.deaths > 0 ? (double)build.Value.total_build_stats.kills / (double)build.Value.total_build_stats.deaths : 0.0, 2);
                row.Cells[5].Value = Math.Round((double)build.Value.total_build_stats.damage / (double)build.Value.total_build_stats.games, 1);
                row.Cells[6].Value = Math.Round((double)build.Value.total_build_stats.damage_taken / (double)build.Value.total_build_stats.games, 1);
                row.Cells[7].Value = build.Value.total_build_stats.wins;
                row.Cells[8].Value = build.Value.total_build_stats.losses;
                row.Cells[9].Value = Math.Round(build.Value.total_build_stats.losses > 0 ? (double)build.Value.total_build_stats.wins / (double)build.Value.total_build_stats.losses : 0.0, 2);

                this.dg_build_view_grid.Rows.Add(row);
            }

            this.dg_build_view_grid.Sort(this.dg_build_view_grid.Columns[1], ListSortDirection.Descending);
            if (build_records.ContainsKey(this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString()))
                this.tb_build_parts.Text = string.Join(",", build_records[dg_build_view_grid.Rows[0].Cells[0].Value.ToString()].parts);

            this.dg_build_view_grid.AllowUserToAddRows = false;
        }

        private void dg_build_view_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.tb_build_parts.Clear();
            if (e.RowIndex >= 0)
            {
                this.tb_build_description.Text = build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].build_description;
                this.tb_cabin.Text = build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].cabin.description;
                this.tb_engine.Text = build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].engine.description;
                this.tb_weapons.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].weapons.Select(x =>x.description));
                this.tb_movement.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].movement.Select(x => x.description));
                this.tb_generator.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].explosives.Where(x => x.explosive_class == "generator").Select(x => x.description));
                this.tb_build_parts.Text = string.Join(",", build_records[this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString()].parts);
            }
        }

        private void build_view_Load(object sender, EventArgs e)
        {

        }
    }
}

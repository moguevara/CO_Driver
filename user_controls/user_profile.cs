using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class user_profile : UserControl
    {
        public file_trace_managment.Player local_player_data = new file_trace_managment.Player { };
        public List<file_trace_managment.MatchRecord> match_history_data = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> local_player_build_data = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public user_profile()
        {
            InitializeComponent();
        }

        public void populate_user_profile_screen(file_trace_managment ftm)
        {
            this.lb_user_profile.Text = string.Format(@"{0} User Profile", local_player_data.nickname);
            populate_match_type_table(ftm);
            populate_build_summary_table();
        }

        public void populate_match_type_table(file_trace_managment ftm)
        {
            this.dg_game_modes.Rows.Clear();

            DataGridViewRow row = (DataGridViewRow)this.dg_game_modes.Rows[0].Clone();
            row.Cells[0].Value = "Total";
            row.Cells[1].Value = local_player_data.total_stats.games;
            row.Cells[2].Value = local_player_data.total_stats.kills;
            row.Cells[3].Value = local_player_data.total_stats.deaths;
            row.Cells[4].Value = Math.Round(local_player_data.total_stats.deaths > 0 ? (double)local_player_data.total_stats.kills / (double)local_player_data.total_stats.deaths : 0, 2);
            row.Cells[5].Value = Math.Round((double)local_player_data.total_stats.damage / (double)local_player_data.total_stats.games, 1);
            row.Cells[6].Value = Math.Round((double)local_player_data.total_stats.damage_taken / (double)local_player_data.total_stats.games, 1);
            row.Cells[7].Value = local_player_data.total_stats.wins;
            row.Cells[8].Value = local_player_data.total_stats.losses;
            row.Cells[9].Value = Math.Round(local_player_data.total_stats.losses > 0 ? (double)local_player_data.total_stats.wins / (double)local_player_data.total_stats.losses : 0, 2);
            this.dg_game_modes.Rows.Add(row);

            foreach (KeyValuePair<int, file_trace_managment.Stats> entry in local_player_data.category_stats)
            {
                row = (DataGridViewRow)this.dg_game_modes.Rows[0].Clone();
                row.Cells[0].Value = ftm.decode_match_type(entry.Key);
                row.Cells[1].Value = entry.Value.games;
                row.Cells[2].Value = entry.Value.kills;
                row.Cells[3].Value = entry.Value.deaths;
                row.Cells[4].Value = Math.Round(entry.Value.deaths > 0 ? (double)entry.Value.kills / (double)entry.Value.deaths : 0.0, 2);
                row.Cells[5].Value = Math.Round((double)entry.Value.damage / (double)entry.Value.games, 1);
                row.Cells[6].Value = Math.Round((double)entry.Value.damage_taken / (double)entry.Value.games, 1);
                row.Cells[7].Value = entry.Value.wins;
                row.Cells[8].Value = entry.Value.losses;
                row.Cells[9].Value = Math.Round(entry.Value.losses > 0 ? (double)entry.Value.wins / (double)entry.Value.losses : 0.0, 2);
                this.dg_game_modes.Rows.Add(row);
            }
            this.dg_game_modes.AllowUserToAddRows = false;

            this.dg_game_modes.Sort(this.dg_game_modes.Columns[1], ListSortDirection.Descending);
        }

        public void populate_build_summary_table()
        {
            this.dg_build_review.Rows.Clear();

            foreach (KeyValuePair<string, file_trace_managment.BuildRecord> build in local_player_build_data)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_build_review.Rows[0].Clone();
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

                this.dg_build_review.Rows.Add(row);
            }

            this.dg_build_review.AllowUserToAddRows = false;

            this.dg_build_review.Sort(this.dg_build_review.Columns[1], ListSortDirection.Descending);
        }
    }
}

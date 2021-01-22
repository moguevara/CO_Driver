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
    public partial class match_history : UserControl
    {
        public List<file_trace_managment.MatchRecord> history = new List<file_trace_managment.MatchRecord> { };
        public file_trace_managment.MatchRecord last_match_data = new file_trace_managment.MatchRecord { };
        public match_history()
        {
            InitializeComponent();
            gridview_styling();
        }

        public void gridview_styling()
        {
        }

        public void refersh_history_table()
        {
            this.dg_match_history_view.Rows.Clear();
            this.dg_match_history_view.Columns[1].DefaultCellStyle.Format = "MM/dd HH:mm:ss";
            this.dg_match_history_view.AllowUserToAddRows = true;
            foreach (file_trace_managment.MatchRecord match in history.ToList())
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_match_history_view.Rows[0].Clone();
                TimeSpan duration = match.match_data.match_end - match.match_data.match_start;
                row.Cells[0].Value = file_trace_managment.decode_match_type(match.match_data.match_type);
                row.Cells[1].Value = match.match_data.match_start;
                row.Cells[2].Value = string.Format(@"{0}M{1}s", duration.Minutes, duration.Seconds);
                row.Cells[3].Value = match.match_data.map_name;
                row.Cells[4].Value =  match.match_data.local_player.build_hash;
                row.Cells[5].Value =  match.match_data.local_player.power_score;
                row.Cells[6].Value =  match.match_data.local_player.stats.score;
                row.Cells[7].Value =  match.match_data.local_player.stats.kills;
                row.Cells[8].Value =  match.match_data.local_player.stats.assists;
                row.Cells[9].Value =  match.match_data.local_player.stats.drone_kills;
                row.Cells[10].Value = Math.Round( match.match_data.local_player.stats.damage, 1);
                row.Cells[11].Value = Math.Round( match.match_data.local_player.stats.damage_taken, 1);
                row.Cells[12].Value = match.match_data.game_result;
                row.Cells[13].Value = string.Join(",", match.match_data.match_rewards.Where(x => x.Key.ToLower().Contains("exp") == false).Select(x => x.Key + ":" + x.Value.ToString()));

                this.dg_match_history_view.Rows.Add(row);
            }

            this.dg_match_history_view.AllowUserToAddRows = false;
            this.dg_match_history_view.Sort(this.dg_match_history_view.Columns[1], ListSortDirection.Descending);
        }

        public void add_last_match_to_table()
        {
            this.dg_match_history_view.AllowUserToAddRows = true;

            DataGridViewRow row = (DataGridViewRow)this.dg_match_history_view.Rows[0].Clone();
            TimeSpan duration = last_match_data.match_data.match_end - last_match_data.match_data.match_start;

            row.Cells[0].Value = file_trace_managment.decode_match_type(last_match_data.match_data.match_type);
            row.Cells[1].Value = last_match_data.match_data.match_start;
            row.Cells[2].Value = string.Format(@"{0}M{1}s", duration.Minutes, duration.Seconds);
            row.Cells[3].Value = last_match_data.match_data.map_name;
            row.Cells[4].Value = last_match_data.match_data.local_player.build_hash;
            row.Cells[5].Value = last_match_data.match_data.local_player.power_score;
            row.Cells[6].Value = last_match_data.match_data.local_player.stats.score;
            row.Cells[7].Value = last_match_data.match_data.local_player.stats.kills;
            row.Cells[8].Value = last_match_data.match_data.local_player.stats.assists;
            row.Cells[9].Value = last_match_data.match_data.local_player.stats.drone_kills;
            row.Cells[10].Value = Math.Round(last_match_data.match_data.local_player.stats.damage, 1);
            row.Cells[11].Value = Math.Round(last_match_data.match_data.local_player.stats.damage_taken, 1);
            row.Cells[12].Value = last_match_data.match_data.game_result;
            row.Cells[13].Value = string.Join(",", last_match_data.match_data.match_rewards.Where(x => x.Key.ToLower().Contains("exp") == false).Select(x => x.Key + ":" + x.Value.ToString()));
            this.dg_match_history_view.Rows.Add(row);

            this.dg_match_history_view.AllowUserToAddRows = false;
            this.dg_match_history_view.Sort(this.dg_match_history_view.Columns[1], ListSortDirection.Descending);
        }

        private void dg_match_history_view_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
        }

        private void dg_match_history_view_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dg_match_history_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

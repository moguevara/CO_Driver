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
        public file_trace_managment.MatchHistoryResponse history_data = new file_trace_managment.MatchHistoryResponse { };
        public file_trace_managment.MatchRecord last_match_data = new file_trace_managment.MatchRecord { };
        public match_history()
        {
            InitializeComponent();
            gridview_styling();
        }

        public void gridview_styling()
        {
        }

        public void refersh_history_table(file_trace_managment ftm)
        {
            this.dg_match_history_view.Rows.Clear();
            this.dg_match_history_view.Columns[1].DefaultCellStyle.Format = "MM/dd HH:mm:ss";
            int i = 0;
            foreach (file_trace_managment.MatchRecord match in history_data.match_history)
            {
                if (i > 100)
                    break;
                DataGridViewRow row = (DataGridViewRow)this.dg_match_history_view.Rows[0].Clone();
                TimeSpan duration = match.stop_time - match.start_time;
                row.Cells[0].Value = ftm.decode_match_type(match.match_type);
                row.Cells[1].Value = match.start_time;
                row.Cells[2].Value = string.Format(@"{0}M{1}s", duration.Minutes, duration.Seconds);
                row.Cells[3].Value = match.build_hash;
                row.Cells[4].Value = match.power_score;
                row.Cells[5].Value = match.local_player_stats.score;
                row.Cells[6].Value = match.local_player_stats.kills;
                row.Cells[7].Value = match.local_player_stats.assists;
                row.Cells[8].Value = match.local_player_stats.drone_kills;
                row.Cells[9].Value = match.local_player_stats.deaths == 0 ? "Yes" : "No";
                row.Cells[10].Value = Math.Round(match.local_player_stats.damage, 2);
                row.Cells[11].Value = Math.Round(match.local_player_stats.damage_taken, 2);
                row.Cells[12].Value = match.game_result;
                row.Cells[13].Value = "reward";

                this.dg_match_history_view.Rows.Add(row);
                i++;
            }
            this.dg_match_history_view.AllowUserToAddRows = false;
        }

        public void add_last_match_to_table(file_trace_managment ftm)
        {
            DataGridViewRow row = (DataGridViewRow)this.dg_match_history_view.Rows[0].Clone();
            row.Cells[0].Value = ftm.decode_match_type(last_match_data.match_type);
            
            TimeSpan duration = last_match_data.stop_time - last_match_data.start_time;
            row.Cells[1].Value = last_match_data.start_time;
            row.Cells[2].Value = string.Format(@"{0}M{1}s", duration.Minutes, duration.Seconds);
            row.Cells[3].Value = last_match_data.build_hash;
            row.Cells[4].Value = last_match_data.power_score;
            row.Cells[5].Value = last_match_data.local_player_stats.score;
            row.Cells[6].Value = last_match_data.local_player_stats.kills;
            row.Cells[7].Value = last_match_data.local_player_stats.assists;
            row.Cells[8].Value = last_match_data.local_player_stats.drone_kills;
            row.Cells[9].Value = last_match_data.local_player_stats.deaths == 0 ? "Yes" : "No";
            row.Cells[10].Value = Math.Round(last_match_data.local_player_stats.damage, 2);
            row.Cells[11].Value = Math.Round(last_match_data.local_player_stats.damage_taken, 2);
            row.Cells[12].Value = last_match_data.game_result;
            row.Cells[13].Value = "test";

            this.dg_match_history_view.Rows.Insert(0, row);
        }
    }
}

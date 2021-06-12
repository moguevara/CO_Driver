using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Windows.Forms.DataVisualization.Charting;

namespace CO_Driver
{
    public partial class match_history : UserControl
    {
        public event EventHandler<file_trace_managment.MatchRecord> load_selected_match;

        public List<file_trace_managment.MatchRecord> history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        private BindingSource history_table_source = new BindingSource();
        private filter.FilterSelections filter_selections = filter.new_filter_selection();
        public bool force_refresh = false;
        private string new_selection = "";
        private string previous_selection = "";
        public match_history()
        {
            InitializeComponent();
        }
        public void refersh_history_table()
        {
            if (!force_refresh)
            {
                new_selection = filter.filter_string(filter_selections);

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;
            previous_selection = new_selection;
            filter.reset_filters(filter_selections);

            dg_match_history_view.Rows.Clear();
            //dg_match_history_view.Columns[1].DefaultCellStyle.Format = "MM/dd HH:mm:ss";
            dg_match_history_view.AllowUserToAddRows = true;
            foreach (file_trace_managment.MatchRecord match in history.ToList())
            {
                if (!filter.check_filters(filter_selections, match, build_records, session, translations))
                    continue;

                DataGridViewRow row = (DataGridViewRow)dg_match_history_view.Rows[0].Clone();
                TimeSpan duration = match.match_data.match_end - match.match_data.match_start;
                row.Cells[0].Value = file_trace_managment.decode_match_type(match.match_data.match_type);
                row.Cells[1].Value = match.match_data.match_start;
                row.Cells[2].Value = string.Format(@"{0}m {1}s", duration.Minutes, duration.Seconds);
                row.Cells[3].Value = translate.translate_string(match.match_data.map_desc, session, translations);
                row.Cells[4].Value = match.match_data.local_player.build_hash;
                row.Cells[5].Value = match.match_data.local_player.power_score;
                row.Cells[6].Value = match.match_data.local_player.stats.score;
                row.Cells[7].Value = match.match_data.local_player.stats.kills;
                row.Cells[8].Value = match.match_data.local_player.stats.assists;
                row.Cells[9].Value = match.match_data.local_player.stats.drone_kills;
                row.Cells[10].Value = Math.Round(match.match_data.local_player.stats.damage, 1);
                row.Cells[11].Value = Math.Round(match.match_data.local_player.stats.damage_taken, 1);
                row.Cells[12].Value = match.match_data.game_result;
                row.Cells[13].Value = string.Join(",", match.match_data.match_rewards.Where(x => x.Key.ToLower().Contains("xp") == false && x.Key != "score").Select(x => translate.translate_string(x.Key, session, translations) + ":" + x.Value.ToString()));
                

                dg_match_history_view.Rows.Add(row);
            }

            dg_match_history_view.AllowUserToAddRows = false;
            dg_match_history_view.Sort(dg_match_history_view.Columns[1], ListSortDirection.Descending);

            filter.populate_filters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }

        private void dg_match_history_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (load_selected_match != null)
            {
                //load_selected_match(this, ((file_trace_managment.MatchRecord)dg_match_history_view.Rows[e.RowIndex].DataBoundItem));
                foreach (file_trace_managment.MatchRecord match in history.ToList())
                {
                    if (DateTime.Equals(match.match_data.match_start, dg_match_history_view.Rows[e.RowIndex].Cells[1].Value))
                    {
                        load_selected_match(this, match);
                        break;
                    }
                }
            }
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            filter.reset_filter_selections(filter_selections);

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            refersh_history_table();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.client_versions_filter = this.cb_versions.Text;

            refersh_history_table();
        }

        private void cb_power_score_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.power_score_filter = this.cb_power_score.Text;

            refersh_history_table();
        }

        private void cb_grouped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.group_filter = this.cb_grouped.Text;

            refersh_history_table();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.game_mode_filter = this.cb_game_modes.Text;

            refersh_history_table();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            filter_selections.start_date = dt_start_date.Value;
            refersh_history_table();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            filter_selections.end_date = dt_end_date.Value;
            refersh_history_table();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.cabin_filter = this.cb_cabins.Text;

            refersh_history_table();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.weapons_filter = this.cb_weapons.Text;

            refersh_history_table();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.module_filter = this.cb_modules.Text;

            refersh_history_table();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.movement_filter = this.cb_movement.Text;

            refersh_history_table();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class match_history : UserControl
    {
        public event EventHandler<FileTraceManagment.MatchRecord> load_selected_match;
        public event EventHandler<string> load_selected_build;

        public List<FileTraceManagment.MatchRecord> history = new List<FileTraceManagment.MatchRecord> { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Dictionary<string, FileTraceManagment.BuildRecord> build_records = new Dictionary<string, FileTraceManagment.BuildRecord> { };
        private BindingSource history_table_source = new BindingSource();
        private Filter.FilterSelections filter_selections = Filter.NewFilterSelection();
        public Resize resize = new Resize { };
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
                new_selection = Filter.FilterString(filter_selections);

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;
            previous_selection = new_selection;
            Filter.ResetFilters(filter_selections);

            dg_match_history_view.Rows.Clear();
            //dg_match_history_view.Columns[1].DefaultCellStyle.Format = "MM/dd HH:mm:ss";
            dg_match_history_view.AllowUserToAddRows = true;
            foreach (FileTraceManagment.MatchRecord match in history.ToList())
            {
                if (!Filter.CheckFilters(filter_selections, match, build_records, session, translations))
                    continue;

                DataGridViewRow row = (DataGridViewRow)dg_match_history_view.Rows[0].Clone();
                TimeSpan duration = match.MatchData.MatchEnd - match.MatchData.MatchStart;
                row.Cells[0].Value = FileTraceManagment.DecodeMatchType(match.MatchData.MatchType);
                row.Cells[1].Value = match.MatchData.MatchStart;
                row.Cells[2].Value = string.Format(@"{0}m {1}s", duration.Minutes, duration.Seconds);
                row.Cells[3].Value = Translate.TranslateString(match.MatchData.MapDesc, session, translations);
                row.Cells[4].Value = match.MatchData.LocalPlayer.BuildHash;
                row.Cells[5].Value = match.MatchData.LocalPlayer.PowerScore;
                row.Cells[6].Value = match.MatchData.LocalPlayer.Stats.Score;
                row.Cells[7].Value = match.MatchData.LocalPlayer.Stats.Kills;
                row.Cells[8].Value = match.MatchData.LocalPlayer.Stats.Assists;
                row.Cells[9].Value = match.MatchData.LocalPlayer.Stats.DroneKills;
                row.Cells[10].Value = Math.Round(match.MatchData.LocalPlayer.Stats.Damage, 1);
                row.Cells[11].Value = Math.Round(match.MatchData.LocalPlayer.Stats.DamageTaken, 1);
                row.Cells[12].Value = match.MatchData.GameResult;
                row.Cells[13].Value = string.Join(",", match.MatchData.MatchRewards.Where(x => x.Key.ToLower().Contains("xp") == false && x.Key != "score").Select(x => Translate.TranslateString(x.Key, session, translations) + ":" + x.Value.ToString()));


                dg_match_history_view.Rows.Add(row);
            }

            dg_match_history_view.AllowUserToAddRows = false;
            dg_match_history_view.Sort(dg_match_history_view.Columns[1], ListSortDirection.Descending);

            Filter.PopulateFilters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }

        private void dg_match_history_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 4)
            {
                if (load_selected_build != null)
                {
                    if (!String.IsNullOrWhiteSpace(dg_match_history_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                        load_selected_build(this, dg_match_history_view.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
            else
            if (load_selected_match != null)
            {
                foreach (FileTraceManagment.MatchRecord match in history.ToList())
                {
                    if (DateTime.Equals(match.MatchData.MatchStart, dg_match_history_view.Rows[e.RowIndex].Cells[1].Value))
                    {
                        load_selected_match(this, match);
                        break;
                    }
                }
            }
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            Filter.ResetFilterSelections(filter_selections);

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            refersh_history_table();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.ClientVersionFilter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.ClientVersionFilter = this.cb_versions.Text;

            refersh_history_table();
        }

        private void cb_power_score_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.PowerScoreFilter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.PowerScoreFilter = this.cb_power_score.Text;

            refersh_history_table();
        }

        private void cb_grouped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.GroupFilter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.GroupFilter = this.cb_grouped.Text;

            refersh_history_table();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.GameModeFilter == this.cb_game_modes.Text)
                return;

            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.GameModeFilter = this.cb_game_modes.Text;

            refersh_history_table();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.StartDate == dt_start_date.Value)
                return;

            filter_selections.StartDate = dt_start_date.Value;
            refersh_history_table();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.EndDate == dt_end_date.Value)
                return;

            filter_selections.EndDate = dt_end_date.Value;
            refersh_history_table();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.CabinFilter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.CabinFilter = this.cb_cabins.Text;

            refersh_history_table();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.WeaponsFilter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.WeaponsFilter = this.cb_weapons.Text;

            refersh_history_table();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.ModuleFilter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.ModuleFilter = this.cb_modules.Text;

            refersh_history_table();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.MovementFilter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.MovementFilter = this.cb_movement.Text;

            refersh_history_table();
        }

        private void match_history_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void match_history_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}

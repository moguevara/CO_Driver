using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class BuildView : UserControl
    {
        private class BuildStats
        {
            public string buildHash;
            public int powerScore;
            public FileTraceManagment.Stats stats;
        }

        //public event EventHandler<string> load_selected_build;

        public FileTraceManagment.MatchHistoryResponse matchHistory = new FileTraceManagment.MatchHistoryResponse { };
        public Dictionary<string, FileTraceManagment.BuildRecord> buildRecords = new Dictionary<string, FileTraceManagment.BuildRecord> { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> uiTranslations = new Dictionary<string, Dictionary<string, string>> { };
        private Dictionary<string, BuildStats> buildStats = new Dictionary<string, BuildStats> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public bool forceRefresh = false;
        private Dictionary<string, int> weaponUsage = new Dictionary<string, int> { };
        private Dictionary<string, int> movementUsage = new Dictionary<string, int> { };
        private Dictionary<string, int> cabinUsage = new Dictionary<string, int> { };
        private Dictionary<string, int> moduleUsage = new Dictionary<string, int> { };
        private Filter.FilterSelections filterSelections = Filter.NewFilterSelection();
        public Resize resize = new Resize { };
        private string newSelection = "";
        private string previousSelection = "";

        public BuildView()
        {
            InitializeComponent();

        }

        private void PopulateBuildRecords()
        {
            buildStats = new Dictionary<string, BuildStats> { };

            foreach (FileTraceManagment.MatchRecord match in matchHistory.MatchHistory.ToList())
            {
                if (!Filter.CheckFilters(filterSelections, match, buildRecords, session, translations))
                    continue;

                if (!buildStats.ContainsKey(match.MatchData.LocalPlayer.BuildHash))
                {
                    buildStats.Add(match.MatchData.LocalPlayer.BuildHash, new BuildStats { buildHash = match.MatchData.LocalPlayer.BuildHash, powerScore = match.MatchData.LocalPlayer.PowerScore, stats = match.MatchData.LocalPlayer.Stats });
                }
                else
                {
                    buildStats[match.MatchData.LocalPlayer.BuildHash].stats = FileTraceManagment.SumStats(buildStats[match.MatchData.LocalPlayer.BuildHash].stats, match.MatchData.LocalPlayer.Stats);
                }
            }

            Filter.PopulateFilters(filterSelections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }

        public void PopulateBuildRecordTable()
        {
            if (!forceRefresh)
            {
                newSelection = Filter.FilterString(filterSelections);

                if (newSelection == previousSelection)
                    return;
            }

            forceRefresh = false;
            previousSelection = newSelection;
            Filter.ResetFilters(filterSelections);

            PopulateBuildRecords();
            this.dg_build_view_grid.Rows.Clear();
            this.dg_build_view_grid.AllowUserToAddRows = true;
            int rows_populated = 0;

            this.lb_build_desc.Text = "";
            this.lb_cabin.Text = "";
            this.dg_module_list.Rows.Clear();
            this.dg_movement_list.Rows.Clear();
            this.dg_weapon_list.Rows.Clear();
            this.lb_game_count.Text = "";
            this.lb_win_rate.Text = "";
            this.lb_kills.Text = "";
            this.lb_assists.Text = "";
            this.lb_deaths.Text = "";
            this.lb_kda.Text = "";
            this.lb_damage.Text = "";
            this.lb_damage_rec.Text = "";
            this.lb_score.Text = "";
            this.lb_parts.Text = "";

            dg_build_view_grid.Columns[7].DefaultCellStyle.Format = "P0";

            foreach (KeyValuePair<string, BuildStats> build in buildStats)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_build_view_grid.Rows[0].Clone();
                row.Cells[0].Value = build.Key;
                row.Cells[1].Value = build.Value.powerScore;
                row.Cells[2].Value = build.Value.stats.Games;
                row.Cells[3].Value = build.Value.stats.Kills;
                row.Cells[4].Value = Math.Round(build.Value.stats.Deaths > 0 ? (double)build.Value.stats.Kills / (double)build.Value.stats.Deaths : Double.PositiveInfinity, 2);
                row.Cells[5].Value = Math.Round((double)build.Value.stats.Damage / (double)build.Value.stats.Rounds, 0);
                row.Cells[6].Value = Math.Round((double)build.Value.stats.DamageTaken / (double)build.Value.stats.Rounds, 0);
                row.Cells[7].Value = (double)build.Value.stats.Wins / (double)build.Value.stats.Games;

                this.dg_build_view_grid.Rows.Add(row);
                rows_populated++;
            }

            this.dg_build_view_grid.Sort(this.dg_build_view_grid.Columns[2], ListSortDirection.Descending);

            string build_hash = "";

            if (rows_populated > 0)
                build_hash = this.dg_build_view_grid.Rows[0].Cells[0].Value.ToString();

            if (rows_populated > 0 && buildRecords.ContainsKey(build_hash) && buildStats.ContainsKey(build_hash))
            {
                this.lb_build_desc.Text = buildRecords[build_hash].FullDescription;
                this.lb_cabin.Text = Translate.TranslateString(buildRecords[build_hash].Cabin.Name, session, translations);
                this.lb_game_count.Text = buildStats[build_hash].stats.Games.ToString();
                this.lb_win_rate.Text = ((double)buildStats[build_hash].stats.Wins / (double)buildStats[build_hash].stats.Games).ToString("P1");
                this.lb_kills.Text = buildStats[build_hash].stats.Kills.ToString();
                this.lb_assists.Text = buildStats[build_hash].stats.Assists.ToString();
                this.lb_deaths.Text = buildStats[build_hash].stats.Deaths.ToString();
                this.lb_kda.Text = (((double)buildStats[build_hash].stats.Kills + (double)buildStats[build_hash].stats.Assists) / (double)buildStats[build_hash].stats.Games).ToString("N2");
                this.lb_damage.Text = (buildStats[build_hash].stats.Damage / (double)buildStats[build_hash].stats.Games).ToString("N1");
                this.lb_damage_rec.Text = (buildStats[build_hash].stats.DamageTaken / (double)buildStats[build_hash].stats.Games).ToString("N1");
                this.lb_score.Text = ((double)buildStats[build_hash].stats.Score / (double)buildStats[build_hash].stats.Games).ToString("N0");
                this.lb_parts.Text = string.Join(", ", buildRecords[build_hash].Parts.Select(x => Translate.TranslateString(x, session, translations)));

                dg_movement_list.Rows.Clear();
                dg_movement_list.AllowUserToAddRows = true;

                foreach (string part in buildRecords[build_hash].Movement.Select(x => Translate.TranslateString(x.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_movement_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_movement_list.Rows.Add(row);
                }

                dg_movement_list.AllowUserToAddRows = false;
                dg_movement_list.ClearSelection();

                dg_weapon_list.Rows.Clear();
                dg_weapon_list.AllowUserToAddRows = true;

                foreach (string part in buildRecords[build_hash].Weapons.Select(x => Translate.TranslateString(x.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_weapon_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_weapon_list.Rows.Add(row);
                }

                dg_weapon_list.AllowUserToAddRows = false;
                dg_weapon_list.ClearSelection();

                dg_module_list.Rows.Clear();
                dg_module_list.AllowUserToAddRows = true;

                foreach (string part in buildRecords[build_hash].Modules.Select(x => Translate.TranslateString(x.Name, session, translations)).Append(Translate.TranslateString(buildRecords[build_hash].Engine.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                foreach (string part in buildRecords[build_hash].Explosives.Select(x => Translate.TranslateString(x.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                dg_module_list.AllowUserToAddRows = false;
                dg_module_list.ClearSelection();


            }

            this.dg_build_view_grid.AllowUserToAddRows = false;
            this.dg_build_view_grid.Sort(this.dg_build_view_grid.Columns[2], ListSortDirection.Descending);
            this.lb_build_desc.Focus();
            this.dg_build_view_grid.ClearSelection();
        }

        private void dg_build_view_grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dg_build_view_grid.Rows.Count > 0 && e.RowIndex >= 0)
            {
                string build_hash = this.dg_build_view_grid.Rows[e.RowIndex].Cells[0].Value.ToString();
                LoadBuildHash(build_hash);


            }
        }

        public void LoadBuildHash(string build_hash)
        {
            if (buildRecords.ContainsKey(build_hash) && buildStats.ContainsKey(build_hash))
            {
                this.lb_build_desc.Text = buildRecords[build_hash].FullDescription;
                this.lb_cabin.Text = Translate.TranslateString(buildRecords[build_hash].Cabin.Name, session, translations);
                this.lb_game_count.Text = buildStats[build_hash].stats.Games.ToString();
                this.lb_win_rate.Text = ((double)buildStats[build_hash].stats.Wins / (double)buildStats[build_hash].stats.Games).ToString("P1");
                this.lb_kills.Text = buildStats[build_hash].stats.Kills.ToString();
                this.lb_assists.Text = buildStats[build_hash].stats.Assists.ToString();
                this.lb_deaths.Text = buildStats[build_hash].stats.Deaths.ToString();
                this.lb_kda.Text = (((double)buildStats[build_hash].stats.Kills + (double)buildStats[build_hash].stats.Assists) / (double)buildStats[build_hash].stats.Games).ToString("N2");
                this.lb_damage.Text = (buildStats[build_hash].stats.Damage / (double)buildStats[build_hash].stats.Games).ToString("N1");
                this.lb_damage_rec.Text = (buildStats[build_hash].stats.DamageTaken / (double)buildStats[build_hash].stats.Games).ToString("N1");
                this.lb_score.Text = ((double)buildStats[build_hash].stats.Score / (double)buildStats[build_hash].stats.Games).ToString("N0");
                this.lb_parts.Text = string.Join(", ", buildRecords[build_hash].Parts.Select(x => Translate.TranslateString(x, session, translations)));

                dg_movement_list.Rows.Clear();
                dg_movement_list.AllowUserToAddRows = true;

                foreach (string part in buildRecords[build_hash].Movement.Select(x => Translate.TranslateString(x.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_movement_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_movement_list.Rows.Add(row);
                }

                dg_movement_list.AllowUserToAddRows = false;
                dg_movement_list.ClearSelection();

                dg_weapon_list.Rows.Clear();
                dg_weapon_list.AllowUserToAddRows = true;

                foreach (string part in buildRecords[build_hash].Weapons.Select(x => Translate.TranslateString(x.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_weapon_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_weapon_list.Rows.Add(row);
                }

                dg_weapon_list.AllowUserToAddRows = false;
                dg_weapon_list.ClearSelection();

                dg_module_list.Rows.Clear();
                dg_module_list.AllowUserToAddRows = true;

                foreach (string part in buildRecords[build_hash].Modules.Select(x => Translate.TranslateString(x.Name, session, translations)).Append(Translate.TranslateString(buildRecords[build_hash].Engine.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                foreach (string part in buildRecords[build_hash].Explosives.Select(x => Translate.TranslateString(x.Name, session, translations)))
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_module_list.Rows[0].Clone();
                    row.Cells[0].Value = part;
                    dg_module_list.Rows.Add(row);
                }

                dg_module_list.AllowUserToAddRows = false;
                dg_module_list.ClearSelection();
            }
            else
            {
                this.lb_build_desc.Text = "";
                this.lb_cabin.Text = "";
                this.dg_module_list.Rows.Clear();
                this.dg_movement_list.Rows.Clear();
                this.dg_weapon_list.Rows.Clear();
                this.lb_game_count.Text = "";
                this.lb_win_rate.Text = "";
                this.lb_kills.Text = "";
                this.lb_assists.Text = "";
                this.lb_deaths.Text = "";
                this.lb_kda.Text = "";
                this.lb_damage.Text = "";
                this.lb_damage_rec.Text = "";
                this.lb_score.Text = "";
                this.lb_parts.Text = "";
            }
        }

        private void BuildViewLoad(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void dg_build_view_grid_SelectionChanged(object sender, EventArgs e)
        {
            this.dg_build_view_grid.Invalidate();
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            Filter.ResetFilterSelections(filterSelections);

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            PopulateBuildRecordTable();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterSelections.GameModeFilter == this.cb_game_modes.Text)
                return;

            if (this.cb_game_modes.SelectedIndex >= 0)
                filterSelections.GameModeFilter = this.cb_game_modes.Text;

            PopulateBuildRecordTable();
        }

        private void cb_grouped_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filterSelections.GroupFilter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filterSelections.GroupFilter = this.cb_grouped.Text;

            PopulateBuildRecordTable();
        }

        private void cb_power_score_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filterSelections.PowerScoreFilter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filterSelections.PowerScoreFilter = this.cb_power_score.Text;

            PopulateBuildRecordTable();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterSelections.ClientVersionFilter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filterSelections.ClientVersionFilter = this.cb_versions.Text;

            PopulateBuildRecordTable();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterSelections.MovementFilter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filterSelections.MovementFilter = this.cb_movement.Text;

            PopulateBuildRecordTable();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterSelections.ModuleFilter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filterSelections.ModuleFilter = this.cb_modules.Text;

            PopulateBuildRecordTable();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterSelections.WeaponsFilter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filterSelections.WeaponsFilter = this.cb_weapons.Text;

            PopulateBuildRecordTable();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterSelections.CabinFilter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filterSelections.CabinFilter = this.cb_cabins.Text;

            PopulateBuildRecordTable();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            if (filterSelections.EndDate == dt_end_date.Value)
                return;

            filterSelections.EndDate = dt_end_date.Value;
            PopulateBuildRecordTable();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            if (filterSelections.StartDate == dt_start_date.Value)
                return;

            filterSelections.StartDate = dt_start_date.Value;
            PopulateBuildRecordTable();
        }

        private void build_view_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}


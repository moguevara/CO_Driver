using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class meta_detail : UserControl
    {
        public event EventHandler<FileTraceManagment.MatchRecord> load_selected_match;

        public List<FileTraceManagment.MatchRecord> match_history = new List<FileTraceManagment.MatchRecord> { };
        public Dictionary<string, FileTraceManagment.BuildRecord> build_records = new Dictionary<string, FileTraceManagment.BuildRecord> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public bool force_refresh = false;
        private Filter.FilterSelections filter_selections = Filter.NewFilterSelection();
        private string new_selection = "";
        private string previous_selection = "";
        private int total_games = 0;
        private int total_wins = 0;
        private double global_enemy_win_percent = 0.0;


        private List<master_meta_grouping> master_groupings = new List<master_meta_grouping> { };

        private class meta_grouping
        {
            public string weapon { get; set; }
            public string cabin { get; set; }
            public string movement { get; set; }
            public string map { get; set; }
            public int rounds { get; set; }
            public int total_seen { get; set; }
            public FileTraceManagment.Stats stats { get; set; }
        }

        private class master_meta_grouping
        {
            public int games { get; set; }
            public int wins { get; set; }
            public int rounds { get; set; }
            public int total_seen { get; set; }
            public meta_grouping group { get; set; }
        }

        public meta_detail()
        {
            InitializeComponent();
        }

        public void populate_meta_detail_screen()
        {
            if (!force_refresh)
            {
                new_selection = Filter.FilterString(filter_selections);

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;

            total_games = 0;
            total_wins = 0;
            master_groupings = new List<master_meta_grouping> { };

            previous_selection = new_selection;

            Filter.ResetFilters(filter_selections);
            initialize_user_profile();

            foreach (FileTraceManagment.MatchRecord match in match_history.ToList())
            {

                if (!Filter.CheckFilters(filter_selections, match, build_records, session, translations))
                    continue;

                /* begin calc */

                total_games += 1;
                List<meta_grouping> match_level_grouping = new List<meta_grouping> { };

                if (match.MatchData.LocalPlayer.Team != match.MatchData.WinningTeam && match.MatchData.WinningTeam != -1)
                    total_wins += 1; /* enemy wins */

                foreach (FileTraceManagment.RoundRecord round in match.MatchData.RoundRecords)
                {
                    List<meta_grouping> round_level_grouping = new List<meta_grouping> { };

                    foreach (FileTraceManagment.Player player in round.Players)
                    {
                        #region player_level
                        if (player.Team == match.MatchData.LocalPlayer.Team)
                            continue;

                        if (!build_records.ContainsKey(player.BuildHash))
                            continue;

                        if (!chk_bot_filter.Checked && player.Bot == 1)
                            continue;

                        if (!chk_bot_filter.Checked && player.PowerScore >= 22000)
                            continue;

                        if (!round.Players.Any(x => x.Nickname == player.Nickname))
                            continue;

                        if (!build_records.ContainsKey(round.Players.FirstOrDefault(x => x.Nickname == player.Nickname).BuildHash))
                            continue;

                        List<meta_grouping> player_level_grouping = new List<meta_grouping> { };
                        FileTraceManagment.BuildRecord build = build_records[round.Players.First(x => x.Nickname == player.Nickname).BuildHash];

                        if (chk_weapon_filter.Checked)
                        {
                            foreach (PartLoader.Weapon weapon in build.Weapons)
                            {
                                meta_grouping new_group = new_grouping();
                                new_group.weapon = Translate.TranslateString(weapon.Name, session, translations);
                                new_group.stats = round.Players.First(x => x.Nickname == player.Nickname).Stats;
                                player_level_grouping.Add(new_group);
                            }
                        }

                        if (chk_movement_filter.Checked)
                        {
                            if (player_level_grouping == null || !player_level_grouping.Any())
                            {
                                foreach (PartLoader.Movement movement in build.Movement)
                                {
                                    meta_grouping new_group = new_grouping();
                                    new_group.movement = Translate.TranslateString(movement.Name, session, translations);
                                    new_group.stats = round.Players.First(x => x.Nickname == player.Nickname).Stats;
                                    player_level_grouping.Add(new_group);
                                }
                            }
                            else
                            {
                                foreach (meta_grouping sub_group in player_level_grouping.ToList())
                                {
                                    for (int i = 0; i < build.Movement.Count(); i++)
                                    {
                                        if (i == 0)
                                        {
                                            sub_group.movement = Translate.TranslateString(build.Movement[i].Name, session, translations);
                                        }
                                        else
                                        {
                                            meta_grouping new_group = new_grouping();
                                            new_group.weapon = sub_group.weapon;
                                            new_group.movement = Translate.TranslateString(build.Movement[i].Name, session, translations);
                                            new_group.stats = round.Players.First(x => x.Nickname == player.Nickname).Stats;
                                            player_level_grouping.Add(new_group);
                                        }
                                    }
                                }
                            }
                        }

                        if (chk_cabin_filter.Checked)
                        {
                            if (player_level_grouping == null || !player_level_grouping.Any())
                            {
                                meta_grouping new_group = new_grouping();
                                new_group.cabin = Translate.TranslateString(build.Cabin.Name, session, translations);
                                new_group.stats = round.Players.First(x => x.Nickname == player.Nickname).Stats;
                                player_level_grouping.Add(new_group);
                            }
                            else
                            {
                                foreach (meta_grouping sub_group in player_level_grouping)
                                    sub_group.cabin = Translate.TranslateString(build.Cabin.Name, session, translations);
                            }
                        }


                        if (chk_map_filter.Checked)
                        {
                            if (player_level_grouping == null || !player_level_grouping.Any())
                            {
                                meta_grouping new_group = new_grouping();
                                new_group.map = Translate.TranslateString(match.MatchData.MapName, session, translations);
                                new_group.stats = round.Players.First(x => x.Nickname == player.Nickname).Stats;
                                player_level_grouping.Add(new_group);
                            }
                            else
                            {
                                foreach (meta_grouping sub_group in player_level_grouping)
                                    sub_group.map = Translate.TranslateString(match.MatchData.MapName, session, translations);
                            }
                        }
                        #endregion
                        foreach (meta_grouping sub_group in player_level_grouping)
                        {
                            bool found = false;
                            for (int i = 0; i < round_level_grouping.Count(); i++)
                            {
                                if (round_level_grouping[i].cabin == sub_group.cabin &&
                                    round_level_grouping[i].movement == sub_group.movement &&
                                    round_level_grouping[i].weapon == sub_group.weapon &&
                                    round_level_grouping[i].map == sub_group.map)
                                {
                                    found = true;
                                    round_level_grouping[i].total_seen += 1;
                                    round_level_grouping[i].stats = FileTraceManagment.SumStats(round_level_grouping[i].stats, round.Players.First(x => x.Nickname == player.Nickname).Stats);
                                }
                            }

                            if (!found)
                                round_level_grouping.Add(sub_group);
                        }

                    }

                    foreach (meta_grouping sub_group in round_level_grouping)
                    {
                        bool found = false;
                        for (int i = 0; i < match_level_grouping.Count(); i++)
                        {
                            if (match_level_grouping[i].cabin == sub_group.cabin &&
                                match_level_grouping[i].movement == sub_group.movement &&
                                match_level_grouping[i].weapon == sub_group.weapon &&
                                match_level_grouping[i].map == sub_group.map)
                            {
                                found = true;
                                match_level_grouping[i].rounds += 1;
                                match_level_grouping[i].total_seen += sub_group.total_seen;

                                match_level_grouping[i].stats = FileTraceManagment.SumStats(match_level_grouping[i].stats, sub_group.stats);
                            }
                        }
                        if (!found)
                            match_level_grouping.Add(sub_group);
                    }
                }
                foreach (meta_grouping sub_group in match_level_grouping)
                {
                    bool found = false;
                    for (int i = 0; i < master_groupings.Count(); i++)
                    {
                        if (master_groupings[i].group.cabin == sub_group.cabin &&
                            master_groupings[i].group.movement == sub_group.movement &&
                            master_groupings[i].group.weapon == sub_group.weapon &&
                            master_groupings[i].group.map == sub_group.map)
                        {
                            found = true;
                            master_groupings[i].games += 1;
                            master_groupings[i].rounds += sub_group.rounds;
                            master_groupings[i].total_seen += sub_group.total_seen;
                            if (match.MatchData.LocalPlayer.Team != match.MatchData.WinningTeam && match.MatchData.WinningTeam != -1)
                                master_groupings[i].wins += 1;

                            master_groupings[i].group.stats = FileTraceManagment.SumStats(master_groupings[i].group.stats, sub_group.stats);
                        }
                    }
                    if (!found)
                    {
                        if (match.MatchData.LocalPlayer.Team != match.MatchData.WinningTeam && match.MatchData.WinningTeam != -1)
                            master_groupings.Add(new master_meta_grouping { games = 1, wins = 1, rounds = sub_group.rounds, group = sub_group });
                        else
                            master_groupings.Add(new master_meta_grouping { games = 1, wins = 0, rounds = sub_group.rounds, group = sub_group });
                    }

                }

            }

            global_enemy_win_percent = (double)total_games > 0 ? (double)total_wins / (double)total_games : 0.0;

            lb_global_percentage.Text = string.Format("{0}%", Math.Round(global_enemy_win_percent * 100, 1));
            lb_total_game.Text = total_games.ToString();

            populate_meta_detail_screen_elements();
            Filter.PopulateFilters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }

        private meta_grouping new_grouping()
        {
            return new meta_grouping { map = "", cabin = "", movement = "", weapon = "", rounds = 1, total_seen = 1, stats = FileTraceManagment.NewStats() };
        }
        private void populate_meta_detail_screen_elements()
        {
            dg_meta_detail_view.Rows.Clear();
            dg_meta_detail_view.Columns[1].DefaultCellStyle.Format = "MM/dd HH:mm:ss";
            dg_meta_detail_view.AllowUserToAddRows = true;

            dg_meta_detail_view.Columns[4].DefaultCellStyle.Format = "N0";
            dg_meta_detail_view.Columns[5].DefaultCellStyle.Format = "P1";
            dg_meta_detail_view.Columns[6].DefaultCellStyle.Format = "N2";
            dg_meta_detail_view.Columns[7].DefaultCellStyle.Format = "N2";
            dg_meta_detail_view.Columns[8].DefaultCellStyle.Format = "N2";
            dg_meta_detail_view.Columns[9].DefaultCellStyle.Format = "N2";
            dg_meta_detail_view.Columns[10].DefaultCellStyle.Format = "N0";
            dg_meta_detail_view.Columns[11].DefaultCellStyle.Format = "N0";
            dg_meta_detail_view.Columns[12].DefaultCellStyle.Format = "N0";
            dg_meta_detail_view.Columns[13].DefaultCellStyle.Format = "P2";
            dg_meta_detail_view.Columns[14].DefaultCellStyle.Format = "P2";

            foreach (master_meta_grouping group in master_groupings)
            {
                DataGridViewRow row = (DataGridViewRow)dg_meta_detail_view.Rows[0].Clone();

                //MessageBox.Show(string.Format(@"weapons:{0} total_seen:{1} rounds:{2} games: {3}", group.group.weapon, (double)group.total_seen, (double)group.rounds, (double)group.games));

                row.Cells[0].Value = group.group.weapon;
                row.Cells[1].Value = group.group.cabin;
                row.Cells[2].Value = group.group.movement;
                row.Cells[3].Value = group.group.map;
                row.Cells[4].Value = group.games;
                row.Cells[5].Value = (double)group.games / (double)total_games;
                row.Cells[6].Value = (double)group.total_seen / (double)group.rounds;
                row.Cells[7].Value = (double)group.group.stats.Kills / (double)group.total_seen;
                row.Cells[8].Value = (double)group.group.stats.Assists / (double)group.total_seen;
                row.Cells[9].Value = (double)group.group.stats.Deaths / (double)group.total_seen;
                row.Cells[10].Value = (double)group.group.stats.Damage / (double)group.total_seen;
                row.Cells[11].Value = (double)group.group.stats.DamageTaken / (double)group.total_seen;
                row.Cells[12].Value = (double)group.group.stats.Score / (double)group.total_seen;
                row.Cells[13].Value = (double)group.wins / (double)group.games;
                row.Cells[14].Value = (((double)group.wins / (double)group.games) - global_enemy_win_percent);
                dg_meta_detail_view.Rows.Add(row);
            }

            dg_meta_detail_view.AllowUserToAddRows = false;
            dg_meta_detail_view.Sort(dg_meta_detail_view.SortedColumn ?? dg_meta_detail_view.Columns[5], ((int)dg_meta_detail_view.SortOrder) != 1 ? ListSortDirection.Descending : ListSortDirection.Ascending);
        }

        private void initialize_user_profile()
        {
        }
        private void btn_save_user_settings_Click_1(object sender, EventArgs e)
        {
            Filter.ResetFilterSelections(filter_selections);

            chk_weapon_filter.Checked = true;
            chk_bot_filter.Checked = false;
            chk_cabin_filter.Checked = false;
            chk_map_filter.Checked = false;
            chk_movement_filter.Checked = false;

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_meta_detail_screen();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.ClientVersionFilter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.ClientVersionFilter = this.cb_versions.Text;

            populate_meta_detail_screen();
        }

        private void cb_power_score_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.PowerScoreFilter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.PowerScoreFilter = this.cb_power_score.Text;

            populate_meta_detail_screen();
        }

        private void cb_grouped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.GroupFilter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.GroupFilter = this.cb_grouped.Text;

            populate_meta_detail_screen();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.GameModeFilter == this.cb_game_modes.Text)
                return;

            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.GameModeFilter = this.cb_game_modes.Text;

            populate_meta_detail_screen();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.StartDate == dt_start_date.Value)
                return;

            filter_selections.StartDate = dt_start_date.Value;
            populate_meta_detail_screen();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.EndDate == dt_end_date.Value)
                return;

            filter_selections.EndDate = dt_end_date.Value;
            populate_meta_detail_screen();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.CabinFilter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.CabinFilter = this.cb_cabins.Text;

            populate_meta_detail_screen();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.WeaponsFilter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.WeaponsFilter = this.cb_weapons.Text;

            populate_meta_detail_screen();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.ModuleFilter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.ModuleFilter = this.cb_modules.Text;

            populate_meta_detail_screen();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.MovementFilter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.MovementFilter = this.cb_movement.Text;

            populate_meta_detail_screen();
        }

        private void chk_weapon_filter_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_meta_detail_screen();
        }

        private void chk_cabin_filter_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_meta_detail_screen();
        }

        private void chk_movement_filter_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_meta_detail_screen();
        }

        private void chk_map_filter_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_meta_detail_screen();
        }

        private void chk_bot_filter_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_meta_detail_screen();
        }

        private void meta_detail_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void meta_detail_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}

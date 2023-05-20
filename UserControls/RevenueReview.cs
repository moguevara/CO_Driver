using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace CO_Driver
{
    public partial class RevenueReview : UserControl
    {
        public List<FileTraceManagment.MatchRecord> match_history = new List<FileTraceManagment.MatchRecord> { };
        public Dictionary<string, FileTraceManagment.BuildRecord> build_records = new Dictionary<string, FileTraceManagment.BuildRecord> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public bool force_refresh = false;
        public Market.MarketData crossoutdb_data = new Market.MarketData { };
        private Filter.FilterSelections filter_selections = Filter.NewFilterSelection();

        private string new_selection = "";
        private string previous_selection = "";
        private int total_games = 0;
        private double total_queue_duration = 0.0;
        private double total_match_duration = 0.0;
        private double total_coins = 0.0;

        private List<revenue_grouping> master_groupings = new List<revenue_grouping> { };
        private List<market_values> master_values = new List<market_values> { };
        private bool show_average = true;
        public RevenueReview()
        {
            InitializeComponent();
        }

        private class revenue_grouping
        {
            public string gamemode { get; set; }
            public string game_result { get; set; }
            public string premium { get; set; }
            public double fuel_cost { get; set; }
            public int games { get; set; }
            public double total_game_duration { get; set; }
            public double total_queue_time { get; set; }
            public double total_match_time { get; set; }
            public Dictionary<string, int> match_rewards { get; set; }
        }

        private class market_values
        {
            public string resource { get; set; }
            public int ammount { get; set; }
            public double sell_price { get; set; }
        }

        public void find_market_values()
        {
            List<market_values> local_values = new List<market_values> { };

            if (crossoutdb_data.market_items == null || crossoutdb_data.market_items.Count() < 2)
            {
                master_values = local_values;
                return;
            }


            foreach (Market.MarketItem item in crossoutdb_data.market_items)
            {
                Match line_results = Regex.Match(item.Name, @"(?<resource_name>.+) x(?<ammount>[0-9].*)");
                bool found_value = false;

                if (line_results.Groups.Count < 2)
                    continue;


                string resource_name = line_results.Groups["resource_name"].Value;
                int resource_ammount = Int32.Parse(line_results.Groups["ammount"].Value);
                double sell_price = item.SellPrice / 100;

                foreach (market_values value in local_values)
                {
                    if (resource_name == value.resource)
                    {
                        found_value = true;
                        if (resource_ammount * sell_price > value.ammount * value.sell_price)
                        {
                            value.ammount = resource_ammount;
                            value.sell_price = sell_price;
                        }
                        break;
                    }
                }

                if (!found_value)
                {
                    local_values.Add(new market_values { resource = resource_name, ammount = resource_ammount, sell_price = sell_price });
                }
            }

            local_values.Add(new market_values { resource = "Badges", ammount = 3000, sell_price = crossoutdb_data.market_items.Find(i => i.ID == 369).SellPrice / 100 });

            master_values = local_values;
        }


        public void populate_revenue_review_screen()
        {
            if (!force_refresh)
            {
                new_selection = Filter.FilterString(filter_selections);

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;

            find_market_values();

            total_games = 0;
            total_queue_duration = 0.0;
            total_match_duration = 0.0;
            total_coins = 0.0;

            master_groupings = new List<revenue_grouping> { };

            previous_selection = new_selection;

            Filter.ResetFilters(filter_selections);
            initialize_user_profile();

            foreach (FileTraceManagment.MatchRecord match in match_history.ToList())
            {
                if (!Filter.CheckFilters(filter_selections, match, build_records, session, translations))
                    continue;

                if (match.MatchData.MatchRewards.Where(x => x.Key != "Fuel" && !x.Key.ToLower().Contains("xp") && !x.Key.ToLower().Equals("glory")).FirstOrDefault().Key == null)
                    continue;

                /* begin calc */
                bool group_found = false;
                int fuel_ammount = 0;
                double badges_amount = 0;
                TimeSpan queue_time = match.MatchData.QueueEnd - match.MatchData.QueueStart;

                string game_mode = match.MatchData.MatchTypeDesc;

                if (game_mode.Contains("Raid"))
                {
                    game_mode = string.Format(@"{0} ({1})", Translate.TranslateString(match.MatchData.GameplayDesc, session, translations), string.Join(",", match.MatchData.MatchRewards.Where(x => !x.Key.ToLower().Contains("xp") && x.Key != "score" && !x.Key.ToLower().Contains("supply") && !x.Key.ToLower().Equals("glory")).Select(x => Translate.TranslateString(x.Key, session, translations))));

                    if (game_mode.EndsWith("()"))
                        game_mode.Substring(("()").Length);
                }

                if (match.MatchData.GameplayDesc == "Pve_Leviathan")
                {
                    game_mode = Translate.TranslateString(match.MatchData.GameplayDesc, session, translations);
                }

                if (game_mode.Contains("8v8"))
                    game_mode = string.Format(@"{0} ({1})", game_mode, string.Join(",", match.MatchData.MatchRewards.Where(x => !x.Key.ToLower().Contains("xp") && x.Key != "score" && !x.Key.ToLower().Equals("glory")).Select(x => Translate.TranslateString(x.Key, session, translations))));

                if (match.MatchData.MatchType == GlobalData.INVASION_MATCH)
                    fuel_ammount = 40;
                else
                    if (match.MatchData.MatchType == GlobalData.EASY_RAID_MATCH)
                    fuel_ammount = 20;
                else
                    if (match.MatchData.MatchType == GlobalData.MED_RAID_MATCH)
                    fuel_ammount = 40;
                else
                    if (match.MatchData.MatchType == GlobalData.HARD_RAID_MATCH)
                    fuel_ammount = 60;

                if (chk_badges.Checked)
                {
                    if (match.MatchData.MatchClassification == GlobalData.BRAWL_CLASSIFICATION)
                    {
                        if (match.MatchData.GameResult == "Win")
                        {
                            badges_amount = 19.444;
                        }
                        else if (match.MatchData.GameResult == "Unfinished" && match.MatchData.LocalPlayer.Stats.Score >= 40 && match.MatchData.WinReason == "RACE_FIRST")
                        {
                            badges_amount = 19.444;
                        }
                    }
                    else if (match.MatchData.GameResult == "Win")
                    {
                        switch (match.MatchData.MatchType)
                        {
                            case GlobalData.EASY_RAID_MATCH:
                                badges_amount = 16.667;
                                break;
                            case GlobalData.STANDARD_MATCH:
                            case GlobalData.PATROL_MATCH:
                                if (match.MatchData.MatchRewards.ContainsKey("Scrap_Rare"))
                                    badges_amount = 10;
                                else if (match.MatchData.MatchRewards.ContainsKey("Accumulators"))
                                    badges_amount = 29.167;
                                else if (match.MatchData.MatchRewards.ContainsKey("Scrap_Common"))
                                    badges_amount = 12.5;
                                break;
                            case GlobalData.INVASION_MATCH:
                                badges_amount = 17.5;
                                break;
                            case GlobalData.MED_RAID_MATCH:
                                badges_amount = 15;
                                break;
                            case GlobalData.HARD_RAID_MATCH:
                                badges_amount = 50;
                                break;
                            case GlobalData.LEVIATHIAN_CW_MATCH:
                            case GlobalData.STANDARD_CW_MATCH:
                                badges_amount = 90;
                                break;
                        }
                    }
                }

                string match_result = match.MatchData.GameResult;
                string premium = match.MatchData.PremiumReward.ToString();

                if (!chk_game_result.Checked)
                    match_result = "";

                foreach (revenue_grouping group in master_groupings)
                {
                    if (group.gamemode == game_mode &&
                       (chk_game_result.Checked == false || group.game_result == match.MatchData.GameResult))
                    {

                        group_found = true;
                        group.total_queue_time += queue_time.TotalSeconds;
                        group.total_match_time += match.MatchData.MatchDurationSeconds;
                        group.games += 1;
                        group.fuel_cost += fuel_ammount;

                        group.total_game_duration += queue_time.TotalSeconds;
                        group.total_game_duration += match.MatchData.MatchDurationSeconds;

                        if (group.match_rewards.ContainsKey("Badges"))
                            group.match_rewards["Badges"] += (int)badges_amount;
                        else
                            group.match_rewards.Add("Badges", (int)badges_amount);

                        foreach (KeyValuePair<string, int> reward in match.MatchData.MatchRewards)
                        {
                            if (group.match_rewards.ContainsKey(reward.Key))
                                group.match_rewards[reward.Key] += reward.Value;
                            else
                                group.match_rewards.Add(reward.Key, reward.Value);
                        }
                        break;
                    }
                }

                if (!group_found)
                {
                    revenue_grouping new_group = new revenue_grouping { };
                    new_group.gamemode = game_mode;
                    new_group.game_result = match_result;
                    new_group.fuel_cost = fuel_ammount;
                    new_group.premium = premium;
                    new_group.games = 1;
                    new_group.total_queue_time = queue_time.TotalSeconds;
                    new_group.total_match_time = match.MatchData.MatchDurationSeconds;
                    new_group.total_game_duration = queue_time.TotalSeconds + match.MatchData.MatchDurationSeconds;
                    new_group.match_rewards = new Dictionary<string, int> { };

                    foreach (KeyValuePair<string, int> reward in match.MatchData.MatchRewards)
                    {
                        if (new_group.match_rewards.ContainsKey(reward.Key))
                            new_group.match_rewards[reward.Key] += reward.Value;
                        else
                            new_group.match_rewards.Add(reward.Key, reward.Value);
                    }

                    if (new_group.match_rewards.ContainsKey("Badges"))
                        new_group.match_rewards["Badges"] += (int)badges_amount;
                    else
                        new_group.match_rewards.Add("Badges", (int)badges_amount);

                    master_groupings.Add(new_group);
                }
            }


            populate_revenue_review_screen_elements();
            Filter.PopulateFilters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }
        private void populate_revenue_review_screen_elements()
        {
            dg_revenue.Rows.Clear();
            dg_revenue.AllowUserToAddRows = true;

            total_games = 0;
            total_queue_duration = 0.0;
            total_match_duration = 0.0;
            total_coins = 0.0;

            dg_revenue.Columns[5].DefaultCellStyle.Format = "N2";
            dg_revenue.Columns[7].DefaultCellStyle.Format = "N2";
            dg_revenue.Columns[8].DefaultCellStyle.Format = "N2";

            foreach (revenue_grouping group in master_groupings)
            {
                TimeSpan t2 = TimeSpan.FromSeconds(group.total_queue_time / group.games);
                TimeSpan t3 = TimeSpan.FromSeconds(group.total_match_time / group.games);
                TimeSpan t4 = TimeSpan.FromSeconds(group.total_queue_time);
                TimeSpan t5 = TimeSpan.FromSeconds(group.total_match_time);
                DataGridViewRow row = (DataGridViewRow)dg_revenue.Rows[0].Clone();
                int default_row_height = row.Height;
                double coin_value = 0.0;
                row.Cells[0].Value = group.gamemode;
                row.Cells[1].Value = group.game_result;
                row.Cells[2].Value = group.games;

                if (show_average)
                {
                    row.Cells[3].Value = t2;
                    row.Cells[4].Value = t3;
                    row.Cells[5].Value = ((double)group.fuel_cost / group.games).ToString();
                }
                else
                {
                    row.Cells[3].Value = t4;
                    row.Cells[4].Value = t5;
                    row.Cells[5].Value = group.fuel_cost.ToString();
                }

                if (chk_free_fuel.Checked)
                    row.Cells[5].Value = "";

                row.Cells[6].Value = "";

                if (group.match_rewards.ContainsKey("expFactionTotal"))
                {
                    bool first = true;

                    foreach (KeyValuePair<string, int> reward in group.match_rewards)
                    {
                        if (reward.Key.ToLower().Contains("xp"))
                            continue;
                        if (reward.Key.ToLower().Contains("score"))
                            continue;
                        if (reward.Key.ToLower().Contains("badge") && reward.Value == 0)
                            continue;

                        if (show_average)
                        {
                            row.Cells[6].Value += string.Format(@"{0}{1}:{2}", first ? "" : Environment.NewLine, Translate.TranslateString(reward.Key, session, translations), Math.Round((reward.Value / (double)group.games), 2).ToString());
                        }
                        else
                        {
                            row.Cells[6].Value += string.Format(@"{0}{1}:{2}", first ? "" : Environment.NewLine, Translate.TranslateString(reward.Key, session, translations), reward.Value.ToString());
                        }

                        first = false;

                        foreach (market_values value in master_values)
                        {
                            if (Translate.TranslateString(reward.Key, session, translations) == value.resource)
                            {
                                coin_value += (reward.Value / (double)value.ammount) * value.sell_price;
                                total_coins += (reward.Value / (double)value.ammount) * value.sell_price;
                            }
                        }
                    }
                    if (!chk_free_fuel.Checked)
                    {
                        coin_value -= ((double)group.fuel_cost / master_values.FirstOrDefault(x => x.resource == "Fuel").ammount) * master_values.FirstOrDefault(x => x.resource == "Fuel").sell_price;
                        total_coins -= ((double)group.fuel_cost / master_values.FirstOrDefault(x => x.resource == "Fuel").ammount) * master_values.FirstOrDefault(x => x.resource == "Fuel").sell_price;
                    }
                }
                if (show_average)
                {
                    row.Cells[7].Value = (double)coin_value / group.games;
                }
                else
                {
                    row.Cells[7].Value = coin_value;
                }

                row.Cells[8].Value = (double)coin_value / ((double)group.total_game_duration / 3600.0);

                total_games += group.games;

                if (coin_value != 0.0)
                {
                    total_queue_duration += group.total_queue_time;
                    total_match_duration += group.total_match_time;
                }

                dg_revenue.Rows.Add(row);
            }

            dg_revenue.AllowUserToAddRows = false;
            dg_revenue.Sort(dg_revenue.SortedColumn ?? dg_revenue.Columns[2], ((int)dg_revenue.SortOrder) != 1 ? ListSortDirection.Descending : ListSortDirection.Ascending);

            lb_queue_time.Text = ViewHelpers.GetMomentFormatFromSeconds(total_queue_duration);
            lb_match_time.Text = ViewHelpers.GetMomentFormatFromSeconds(total_match_duration);
            lb_total_game.Text = total_games.ToString();
            lb_coins.Text = string.Format("{0:n0}", total_coins);
            lb_coins_rate.Text = Math.Round(total_coins / ((double)((total_queue_duration + total_match_duration) / 3600.0)), 2).ToString();

        }

        private void initialize_user_profile()
        {
        }

        private void chk_game_result_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_revenue_review_screen();
        }
        private void chk_free_fuel_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_revenue_review_screen();
        }

        private void chk_badges_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_revenue_review_screen();
        }

        private void btn_total_avg_Click(object sender, EventArgs e)
        {
            if (btn_total_avg.Text == "Average")
            {
                btn_total_avg.Text = "Total";
                show_average = false;
            }
            else
            {
                btn_total_avg.Text = "Average";
                show_average = true;
            }
            force_refresh = true;
            populate_revenue_review_screen();
        }

        private void cb_versions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.ClientVersionFilter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.ClientVersionFilter = this.cb_versions.Text;

            populate_revenue_review_screen();
        }

        private void cb_power_score_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.PowerScoreFilter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.PowerScoreFilter = this.cb_power_score.Text;

            populate_revenue_review_screen();
        }

        private void cb_grouped_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.GroupFilter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.GroupFilter = this.cb_grouped.Text;

            populate_revenue_review_screen();
        }

        private void cb_game_modes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.GameModeFilter == this.cb_game_modes.Text)
                return;

            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.GameModeFilter = this.cb_game_modes.Text;

            populate_revenue_review_screen();
        }

        private void cb_cabins_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.CabinFilter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.CabinFilter = this.cb_cabins.Text;

            populate_revenue_review_screen();
        }

        private void cb_weapons_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.WeaponsFilter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.WeaponsFilter = this.cb_weapons.Text;

            populate_revenue_review_screen();
        }

        private void cb_modules_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.ModuleFilter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.ModuleFilter = this.cb_modules.Text;

            populate_revenue_review_screen();
        }

        private void cb_movement_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.MovementFilter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.MovementFilter = this.cb_movement.Text;

            populate_revenue_review_screen();
        }

        private void dt_start_date_ValueChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.StartDate == dt_start_date.Value)
                return;

            filter_selections.StartDate = dt_start_date.Value;
            populate_revenue_review_screen();
        }

        private void dt_end_date_ValueChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.EndDate == dt_end_date.Value)
                return;

            filter_selections.EndDate = dt_end_date.Value;
            populate_revenue_review_screen();
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            Filter.ResetFilterSelections(filter_selections);

            chk_free_fuel.Checked = false;
            chk_badges.Checked = false;

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_revenue_review_screen();
        }

        private void revenue_review_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void revenue_review_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }

        private void dg_revenue_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && (dg_revenue.Columns[e.ColumnIndex].Name == "Column14" || dg_revenue.Columns[e.ColumnIndex].Name == "Column5"))
            {
                ViewHelpers.SetMomentFormatForTimeSpanCell(e);
            }
        }
    }
}

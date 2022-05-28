using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace CO_Driver
{
    public partial class revenue_review : UserControl
    {
        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public bool force_refresh = false;
        public market.market_data crossoutdb_data = new market.market_data { };
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
        public revenue_review()
        {
            InitializeComponent();
        }

        private class revenue_grouping
        {
            public string gamemode { get; set; }
            public string game_result { get; set; }
            public string premium { get; set; }
            public int fuel_cost { get; set; }
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


            foreach (market.market_item item in crossoutdb_data.market_items)
            {
                Match line_results = Regex.Match(item.name, @"(?<resource_name>.+) x(?<ammount>[0-9].*)");
                bool found_value = false;

                if (line_results.Groups.Count < 2)
                    continue;


                string resource_name = line_results.Groups["resource_name"].Value;
                int resource_ammount = Int32.Parse(line_results.Groups["ammount"].Value);
                double sell_price = item.sellPrice / 100;

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

            local_values.Add(new market_values { resource = "Badges", ammount = 3000, sell_price = crossoutdb_data.market_items.Find(i => i.id == 369).sellPrice/100});

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

            foreach (file_trace_managment.MatchRecord match in match_history.ToList())
            {
                if (!Filter.CheckFilters(filter_selections, match, build_records, session, translations))
                    continue;

                if (match.match_data.match_rewards.Where(x => x.Key != "Fuel" && !x.Key.ToLower().Contains("xp")).FirstOrDefault().Key == null)
                    continue;

                /* begin calc */
                bool group_found = false;
                int fuel_ammount = 0;
                double badges_amount = 0;
                TimeSpan queue_time = match.match_data.queue_end - match.match_data.queue_start;

                string game_mode = match.match_data.match_type_desc;

                if (game_mode.Contains("Raid"))
                {
                    game_mode = string.Format(@"{0} ({1})", translate.translate_string(match.match_data.gameplay_desc, session, translations), string.Join(",", match.match_data.match_rewards.Where(x => !x.Key.ToLower().Contains("xp") && x.Key != "score" && !x.Key.ToLower().Contains("supply")).Select(x => translate.translate_string(x.Key, session, translations))));

                    if (game_mode.EndsWith("()"))
                        game_mode.Substring(("()").Length);
                }

                if (match.match_data.gameplay_desc == "Pve_Leviathan")
                {
                    game_mode = translate.translate_string(match.match_data.gameplay_desc, session, translations);
                }

                if (game_mode.Contains("8v8"))
                    game_mode = string.Format(@"{0} ({1})", game_mode, string.Join(",", match.match_data.match_rewards.Where(x => !x.Key.ToLower().Contains("xp") && x.Key != "score").Select(x => translate.translate_string(x.Key, session, translations))));

                if (match.match_data.match_type == global_data.INVASION_MATCH)
                    fuel_ammount = 40;
                else
                if (match.match_data.match_type == global_data.EASY_RAID_MATCH)
                    fuel_ammount = 20;
                else
                if (match.match_data.match_type == global_data.MED_RAID_MATCH)
                    fuel_ammount = 40;
                else
                if (match.match_data.match_type == global_data.HARD_RAID_MATCH)
                    fuel_ammount = 60;

                if (chk_badges.Checked && match.match_data.game_result == "Win")
                {
                    if (match.match_data.match_classification == global_data.BRAWL_CLASSIFICATION)
                        badges_amount = 19.444;
                    else
                    {
                        switch (match.match_data.match_type)
                        {
                            case global_data.EASY_RAID_MATCH:
                                badges_amount = 16.667;
                                break;
                            case global_data.STANDARD_MATCH:
                            case global_data.PATROL_MATCH:
                                if (match.match_data.match_rewards.ContainsKey("Scrap_Rare"))
                                    badges_amount = 10;
                                else if (match.match_data.match_rewards.ContainsKey("Accumulators"))
                                    badges_amount = 29.167;
                                else if (match.match_data.match_rewards.ContainsKey("Scrap_Common"))
                                    badges_amount = 12.5;
                                break;
                            case global_data.INVASION_MATCH:
                                badges_amount = 17.5;
                                break;
                            case global_data.MED_RAID_MATCH:
                                badges_amount = 15;
                                break;
                            case global_data.HARD_RAID_MATCH:
                                badges_amount = 50;
                                break;
                            case global_data.LEVIATHIAN_CW_MATCH:
                            case global_data.STANDARD_CW_MATCH:
                                badges_amount = 90;
                                break;
                        }
                    }
                }

                string match_result = match.match_data.game_result;
                string premium = match.match_data.premium_reward.ToString();

                if (!chk_game_result.Checked)
                    match_result = "";

                if (chk_free_fuel.Checked)
                    fuel_ammount = 0;

                foreach (revenue_grouping group in master_groupings)
                {
                    if (group.gamemode == game_mode &&
                       (chk_game_result.Checked == false || group.game_result == match.match_data.game_result))
                    {

                        group_found = true;
                        group.total_queue_time += queue_time.TotalSeconds;
                        group.total_match_time += match.match_data.match_duration_seconds;
                        group.games += 1;
                        group.fuel_cost += fuel_ammount;
                        group.total_game_duration += queue_time.TotalSeconds;
                        group.total_game_duration += match.match_data.match_duration_seconds;

                        if (group.match_rewards.ContainsKey("Badges"))
                            group.match_rewards["Badges"] += (int)badges_amount;
                        else
                            group.match_rewards.Add("Badges", (int)badges_amount);

                        foreach (KeyValuePair<string, int> reward in match.match_data.match_rewards)
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
                    new_group.total_match_time = match.match_data.match_duration_seconds;
                    new_group.total_game_duration = queue_time.TotalSeconds + match.match_data.match_duration_seconds;
                    new_group.match_rewards = new Dictionary<string, int> { };

                    foreach (KeyValuePair<string, int> reward in match.match_data.match_rewards)
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

            dg_revenue.Columns[7].DefaultCellStyle.Format = "N2";
            dg_revenue.Columns[8].DefaultCellStyle.Format = "N2";

            foreach (revenue_grouping group in master_groupings)
            {
                TimeSpan t2 = TimeSpan.FromSeconds(group.total_queue_time / (double)group.games);
                TimeSpan t3 = TimeSpan.FromSeconds(group.total_match_time / (double)group.games);
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
                    row.Cells[3].Value = string.Format("{0:D}m {1:D2}s", t2.Minutes, t2.Seconds);
                    row.Cells[4].Value = string.Format("{0:D}m {1:D2}s", t3.Minutes, t3.Seconds);
                    row.Cells[5].Value = (group.fuel_cost / group.games).ToString();
                }
                else
                {
                    if (t4.Days == 0)
                        row.Cells[3].Value = string.Format("{0:D}h {1:D2}m", t4.Hours, t4.Minutes);
                    else
                        row.Cells[3].Value = string.Format("{0:D}d {1:D2}h", t4.Days, t4.Hours);

                    if (t5.Days == 0)
                        row.Cells[4].Value = string.Format("{0:D}h {1:D2}m", t5.Hours, t5.Minutes);
                    else
                        row.Cells[4].Value = string.Format("{0:D}d {1:D2}h", t5.Days, t5.Hours);

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
                            row.Cells[6].Value += string.Format(@"{0}{1}:{2}", first ? "" : Environment.NewLine, translate.translate_string(reward.Key, session, translations), Math.Round(((double)reward.Value / (double)group.games), 2).ToString());
                        }
                        else
                        {
                            row.Cells[6].Value += string.Format(@"{0}{1}:{2}", first ? "" : Environment.NewLine, translate.translate_string(reward.Key, session, translations), reward.Value.ToString());
                        }

                        first = false;

                        foreach (market_values value in master_values)
                        {
                            if (translate.translate_string(reward.Key, session, translations) == value.resource)
                            {
                                coin_value += ((double)reward.Value / (double)value.ammount) * value.sell_price;
                                total_coins += ((double)reward.Value / (double)value.ammount) * value.sell_price;
                            }
                        }
                    }

                    if (!chk_free_fuel.Checked)
                    {
                        coin_value -= ((double)group.fuel_cost / (double)master_values.FirstOrDefault(x => x.resource == "Fuel").ammount) * master_values.FirstOrDefault(x => x.resource == "Fuel").sell_price;
                        total_coins -= ((double)group.fuel_cost / (double)master_values.FirstOrDefault(x => x.resource == "Fuel").ammount) * master_values.FirstOrDefault(x => x.resource == "Fuel").sell_price;
                    }

                }
                if (show_average)
                {
                    row.Cells[7].Value = (double)coin_value / (double)group.games;
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
            dg_revenue.Sort(dg_revenue.Columns[2], ListSortDirection.Descending);

            TimeSpan queue_span = TimeSpan.FromSeconds(total_queue_duration);
            TimeSpan match_span = TimeSpan.FromSeconds(total_match_duration);

            lb_queue_time.Text = "";
            lb_match_time.Text = "";

            if (queue_span.Days != 0)
                lb_queue_time.Text = string.Format("{0:D}d {1:D}h", queue_span.Days, queue_span.Hours);
            else if (queue_span.Hours != 0)
                lb_queue_time.Text = string.Format("{0:D}h {1:D2}m", queue_span.Hours, queue_span.Minutes);
            else if (queue_span.Minutes != 0)
                lb_queue_time.Text = string.Format("{0:D}m {1:D2}s", queue_span.Minutes, queue_span.Seconds);
            else if (queue_span.Seconds != 0)
                lb_queue_time.Text = string.Format("{0:D}s", queue_span.Seconds);

            if (match_span.Days != 0)
                lb_match_time.Text = string.Format("{0:D}d {1:D}h", match_span.Days, match_span.Hours);
            else if (match_span.Hours != 0)
                lb_match_time.Text = string.Format("{0:D}h {1:D2}m", match_span.Hours, match_span.Minutes);
            else if (match_span.Minutes != 0)
                lb_match_time.Text = string.Format("{0:D}m {1:D2}s", match_span.Minutes, match_span.Seconds);
            else if (match_span.Seconds != 0)
                lb_match_time.Text = string.Format("{0:D}s", match_span.Seconds);

            lb_total_game.Text = total_games.ToString();
            lb_coins.Text = string.Format("{0:n0}", total_coins);
            lb_coins_rate.Text = Math.Round((double)total_coins / ((double)((total_queue_duration + total_match_duration) / 3600.0)), 2).ToString();

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
            resize.record_initial_sizes(this);
        }

        private void revenue_review_Resize(object sender, EventArgs e)
        {
            resize.resize(this);
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace CO_Driver
{
    public partial class revenue_review : UserControl
    {
        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public bool force_refresh = false;
        public market.market_data crossoutdb_data = new market.market_data { };

        private Dictionary<string, int> weapon_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> movement_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> cabin_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> module_usage = new Dictionary<string, int> { };
        private DateTime min_date = new DateTime { };
        private DateTime max_date = new DateTime { };
        private string game_mode_filter = global_data.GAME_MODE_FILTER_DEFAULT;
        private string group_filter = global_data.GROUP_FILTER_DEFAULT;
        private string power_score_filter = global_data.POWER_SCORE_FILTER_DEFAULT;
        private string client_versions_filter = global_data.CLIENT_VERSION_FILTER_DEFAULT;
        private string weapons_filter = global_data.WEAPONS_FILTER_DEFAULT;
        private string movement_filter = global_data.MOVEMENT_FILTER_DEFAULT;
        private string cabin_filter = global_data.CABIN_FILTER_DEFAULT;
        private string module_filter = global_data.MODULE_FILTER_DEFAULT;
        private List<string> game_modes = new List<string> { };
        private List<string> grouped = new List<string> { };
        private List<string> power_scores = new List<string> { };
        private List<string> client_versions = new List<string> { };
        private List<string> weapons = new List<string> { };
        private List<string> movement_parts = new List<string> { };
        private List<string> cabins = new List<string> { };
        private List<string> module_parts = new List<string> { };
        private string new_selection = "";
        private string previous_selection = "";
        private int total_games = 0;

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

            master_values = local_values;
        }


        public void populate_revenue_review_screen()
        {
            if (!force_refresh)
            {
                new_selection = string.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    game_mode_filter, group_filter, power_score_filter, client_versions_filter, weapons_filter, movement_filter, module_filter, cabin_filter, dt_start_date.Value.ToString(), dt_end_date.Value.ToString());

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;

            find_market_values();

            total_games = 0;

            master_groupings = new List<revenue_grouping> { };
            
            previous_selection = new_selection;

            reset_filters();
            initialize_user_profile();

            foreach (file_trace_managment.MatchRecord match in match_history.ToList())
            {
                min_date = DateTime.MaxValue;
                max_date = DateTime.MinValue;

                if (match.match_data.match_start < min_date)
                    min_date = match.match_data.match_start;

                if (match.match_data.match_start > max_date)
                    max_date = match.match_data.match_start;

                if (game_mode_filter != global_data.GAME_MODE_FILTER_DEFAULT && game_mode_filter != match.match_data.match_type_desc)
                    continue;

                if (group_filter == "Solo" && match.match_data.local_player.party_id > 0)
                    continue;

                if (group_filter == "Grouped" && match.match_data.local_player.party_id == 0)
                    continue;

                if (client_versions_filter != global_data.CLIENT_VERSION_FILTER_DEFAULT && client_versions_filter != match.match_data.client_version)
                    continue;

                if (dt_start_date.Value.Date != DateTime.Now.Date && match.match_data.match_start.Date < dt_start_date.Value.Date)
                    continue;

                if (dt_end_date.Value.Date != DateTime.Now.Date && match.match_data.match_start.Date > dt_end_date.Value.Date)
                    continue;

                if (power_score_filter != global_data.POWER_SCORE_FILTER_DEFAULT)
                {
                    if (power_score_filter == "0-2499" && (match.match_data.local_player.power_score < 0 || match.match_data.local_player.power_score > 2499))
                        continue;

                    if (power_score_filter == "2500-3499" && (match.match_data.local_player.power_score < 2500 || match.match_data.local_player.power_score > 3499))
                        continue;

                    if (power_score_filter == "3500-4499" && (match.match_data.local_player.power_score < 3500 || match.match_data.local_player.power_score > 4499))
                        continue;

                    if (power_score_filter == "4500-5499" && (match.match_data.local_player.power_score < 4500 || match.match_data.local_player.power_score > 5499))
                        continue;

                    if (power_score_filter == "5500-6499" && (match.match_data.local_player.power_score < 5500 || match.match_data.local_player.power_score > 6499))
                        continue;

                    if (power_score_filter == "6500-7499" && (match.match_data.local_player.power_score < 6500 || match.match_data.local_player.power_score > 7499))
                        continue;

                    if (power_score_filter == "7500-8499" && (match.match_data.local_player.power_score < 7500 || match.match_data.local_player.power_score > 8499))
                        continue;

                    if (power_score_filter == "8500-9499" && (match.match_data.local_player.power_score < 8500 || match.match_data.local_player.power_score > 9499))
                        continue;

                    if (power_score_filter == "9500-12999" && (match.match_data.local_player.power_score < 9500 || match.match_data.local_player.power_score > 12999))
                        continue;

                    if (power_score_filter == "13000+" && (match.match_data.local_player.power_score < 13000 || match.match_data.local_player.power_score > 22000))
                        continue;

                    if (power_score_filter == "Leviathan" && match.match_data.local_player.power_score < 22000)
                        continue;
                }

                if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                {
                    if (weapons_filter != global_data.WEAPONS_FILTER_DEFAULT && build_records[match.match_data.local_player.build_hash].weapons.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == weapons_filter).Count() == 0)
                        continue;

                    if (movement_filter != global_data.MOVEMENT_FILTER_DEFAULT && build_records[match.match_data.local_player.build_hash].movement.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == movement_filter).Count() == 0)
                        continue;

                    if (cabin_filter != global_data.CABIN_FILTER_DEFAULT && translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations) != cabin_filter)
                        continue;

                    if (module_filter != global_data.MODULE_FILTER_DEFAULT && build_records[match.match_data.local_player.build_hash].modules.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == module_filter).Count() == 0)
                        continue;
                }
                else
                {
                    if (weapons_filter != global_data.WEAPONS_FILTER_DEFAULT)
                        continue;

                    if (movement_filter != global_data.MOVEMENT_FILTER_DEFAULT)
                        continue;

                    if (cabin_filter != global_data.CABIN_FILTER_DEFAULT)
                        continue;

                    if (module_filter != global_data.MODULE_FILTER_DEFAULT)
                        continue;
                }

                if (!game_modes.Contains(match.match_data.match_type_desc))
                    game_modes.Add((match.match_data.match_type_desc));

                if (match.match_data.local_player.party_id == 0 && !grouped.Contains("Solo"))
                    grouped.Add("Solo");

                if (match.match_data.local_player.party_id > 0 && !grouped.Contains("Grouped"))
                    grouped.Add("Grouped");

                if (match.match_data.local_player.power_score >= 0 && match.match_data.local_player.power_score <= 2499 && !power_scores.Contains("0-2499"))
                    power_scores.Add("0-2499");

                if (match.match_data.local_player.power_score >= 2500 && match.match_data.local_player.power_score <= 2499 && !power_scores.Contains("2500-3499"))
                    power_scores.Add("2500-3499");

                if (match.match_data.local_player.power_score >= 3500 && match.match_data.local_player.power_score <= 4499 && !power_scores.Contains("3500-4499"))
                    power_scores.Add("3500-4499");

                if (match.match_data.local_player.power_score >= 4500 && match.match_data.local_player.power_score <= 5499 && !power_scores.Contains("4500-5499"))
                    power_scores.Add("4500-5499");

                if (match.match_data.local_player.power_score >= 5500 && match.match_data.local_player.power_score <= 6499 && !power_scores.Contains("5500-6499"))
                    power_scores.Add("5500-6499");

                if (match.match_data.local_player.power_score >= 6500 && match.match_data.local_player.power_score <= 7499 && !power_scores.Contains("6500-7499"))
                    power_scores.Add("6500-7499");

                if (match.match_data.local_player.power_score >= 7500 && match.match_data.local_player.power_score <= 8499 && !power_scores.Contains("7500-8499"))
                    power_scores.Add("7500-8499");

                if (match.match_data.local_player.power_score >= 8500 && match.match_data.local_player.power_score <= 9499 && !power_scores.Contains("8500-9499"))
                    power_scores.Add("8500-9499");

                if (match.match_data.local_player.power_score >= 9500 && match.match_data.local_player.power_score <= 12999 && !power_scores.Contains("9500-12999"))
                    power_scores.Add("9500-12999");

                if (match.match_data.local_player.power_score >= 13000 && match.match_data.local_player.power_score <= 22000 && !power_scores.Contains("13000+"))
                    power_scores.Add("13000+");

                if (match.match_data.local_player.power_score >= 22000 && !power_scores.Contains("Leviathan"))
                    power_scores.Add("Leviathan");

                if (!client_versions.Contains(match.match_data.client_version))
                    client_versions.Add((match.match_data.client_version));

                if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                {
                    if (!string.IsNullOrEmpty(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                    {
                        if (!cabins.Contains(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                        {
                            cabins.Add(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations));
                        }
                        if (!cabin_usage.ContainsKey(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                            cabin_usage.Add(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations), 1);
                        else
                            cabin_usage[translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)] += 1;
                    }

                    foreach (part_loader.Weapon weapon in build_records[match.match_data.local_player.build_hash].weapons)
                    {
                        if (!weapons.Contains(translate.translate_string(weapon.name, session, translations)))
                        {
                            weapons.Add(translate.translate_string(weapon.name, session, translations));
                        }
                        if (!weapon_usage.ContainsKey(translate.translate_string(weapon.name, session, translations)))
                            weapon_usage.Add(translate.translate_string(weapon.name, session, translations), 1);
                        else
                            weapon_usage[translate.translate_string(weapon.name, session, translations)] += 1;
                    }

                    foreach (part_loader.Movement movement in build_records[match.match_data.local_player.build_hash].movement)
                    {
                        if (!movement_parts.Contains(translate.translate_string(movement.name, session, translations)))
                        {
                            movement_parts.Add(translate.translate_string(movement.name, session, translations));
                        }

                        if (!movement_usage.ContainsKey(translate.translate_string(movement.name, session, translations)))
                            movement_usage.Add(translate.translate_string(movement.name, session, translations), 1);
                        else
                            movement_usage[translate.translate_string(movement.name, session, translations)] += 1;
                    }

                    foreach (part_loader.Module module in build_records[match.match_data.local_player.build_hash].modules)
                    {
                        if (!module_parts.Contains(translate.translate_string(module.name, session, translations)))
                        {
                            module_parts.Add(translate.translate_string(module.name, session, translations));
                        }

                        if (!module_usage.ContainsKey(translate.translate_string(module.name, session, translations)))
                            module_usage.Add(translate.translate_string(module.name, session, translations), 1);
                        else
                            module_usage[translate.translate_string(module.name, session, translations)] += 1;
                    }
                }

                if (match.match_data.match_rewards.Where(x => x.Key != "Fuel" && !x.Key.ToLower().Contains("xp")).FirstOrDefault().Key == null)
                    continue;

                /* begin calc */
                bool group_found = false;
                bool contains_fuel = false;
                int fuel_ammount = 0;
                TimeSpan queue_time = match.match_data.queue_end - match.match_data.queue_start;

                string game_mode = match.match_data.match_type_desc;

                if ((match.match_data.match_rewards.Where(x => x.Key == "Fuel").FirstOrDefault().Key != null))
                    contains_fuel = true;

                if (game_mode.Contains("Raid"))
                    game_mode = translate.translate_string(match.match_data.gameplay_desc, session, translations);

                if (game_mode.Contains("8v8"))
                    game_mode = string.Format(@"{0} ({1})", game_mode, string.Join(",", match.match_data.match_rewards.Where(x => !x.Key.ToLower().Contains("xp") && x.Key != "score").Select(x => translate.translate_string(x.Key, session, translations))));

                if (match.match_data.match_type == global_data.EASY_RAID_MATCH)
                    fuel_ammount = 20;
                else
                if (match.match_data.match_type == global_data.MED_RAID_MATCH)
                    fuel_ammount = 40;
                else
                if (match.match_data.match_type == global_data.HARD_RAID_MATCH)
                    fuel_ammount = 60;


                total_games += 1;

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

                    master_groupings.Add(new_group);
                }
            }


            populate_revenue_review_screen_elements();
            populate_filters();
        }
        private void reset_filters()
        {
            game_modes = new List<string> { };
            grouped = new List<string> { };
            power_scores = new List<string> { };
            client_versions = new List<string> { };
            weapons = new List<string> { };
            movement_parts = new List<string> { };
            cabins = new List<string> { };
            module_parts = new List<string> { };

            game_modes.Add(global_data.GAME_MODE_FILTER_DEFAULT);
            grouped.Add(global_data.GROUP_FILTER_DEFAULT);
            power_scores.Add(global_data.POWER_SCORE_FILTER_DEFAULT);
            client_versions.Add(global_data.CLIENT_VERSION_FILTER_DEFAULT);
            weapons.Add(global_data.WEAPONS_FILTER_DEFAULT);
            movement_parts.Add(global_data.MOVEMENT_FILTER_DEFAULT);
            cabins.Add(global_data.CABIN_FILTER_DEFAULT);
            module_parts.Add(global_data.MODULE_FILTER_DEFAULT);

            //dt_start_date.Value = new System.DateTime(2016, 4, 5, 0, 0, 0, 0);
            //dt_end_date.Value = DateTime.Now;
        }

        private void populate_filters()
        {
            cb_game_modes.Items.Clear();
            cb_grouped.Items.Clear();
            cb_power_score.Items.Clear();
            cb_versions.Items.Clear();
            cb_weapons.Items.Clear();
            cb_movement.Items.Clear();
            cb_cabins.Items.Clear();
            cb_modules.Items.Clear();

            game_modes = game_modes.OrderBy(x => x != global_data.GAME_MODE_FILTER_DEFAULT).ThenBy(x => x).ToList();
            power_scores = power_scores.OrderBy(x => x != global_data.POWER_SCORE_FILTER_DEFAULT).ThenBy(x => x).ToList();
            client_versions = client_versions.OrderBy(x => x != global_data.CLIENT_VERSION_FILTER_DEFAULT).ThenBy(x => x).ToList();
            weapons.OrderBy(x => x != global_data.WEAPONS_FILTER_DEFAULT).ThenBy(x => x).ToList();
            movement_parts.OrderBy(x => x != global_data.MOVEMENT_FILTER_DEFAULT).ThenBy(x => x).ToList();
            cabins.OrderBy(x => x != global_data.CABIN_FILTER_DEFAULT).ThenBy(x => x).ToList();
            module_parts.OrderBy(x => x != global_data.MODULE_FILTER_DEFAULT).ThenBy(x => x).ToList();

            if (power_scores.Contains("13000+"))
            {
                power_scores.Remove("13000+");
                power_scores.Add("13000+");
            }

            if (power_scores.Contains("Leviathian"))
            {
                power_scores.Remove("Leviathian");
                power_scores.Add("Leviathian");
            }

            foreach (string desc in game_modes)
                cb_game_modes.Items.Add(desc ?? "");

            foreach (string desc in grouped)
                cb_grouped.Items.Add(desc ?? "");

            foreach (string desc in power_scores)
                cb_power_score.Items.Add(desc ?? "");

            foreach (string desc in client_versions)
                cb_versions.Items.Add(desc ?? "");

            foreach (string desc in weapons)
                cb_weapons.Items.Add(desc ?? "");

            foreach (string desc in movement_parts)
                cb_movement.Items.Add(desc ?? "");

            foreach (string desc in cabins)
                cb_cabins.Items.Add(desc ?? "");

            foreach (string desc in module_parts)
                cb_modules.Items.Add(desc ?? "");

            cb_game_modes.Text = game_mode_filter;
            cb_grouped.Text = group_filter;
            cb_power_score.Text = power_score_filter;
            cb_versions.Text = client_versions_filter;
            cb_weapons.Text = weapons_filter;
            cb_movement.Text = movement_filter;
            cb_cabins.Text = cabin_filter;
            cb_modules.Text = module_filter;
        }

        private void populate_revenue_review_screen_elements()
        {
            dg_revenue.Rows.Clear();
            dg_revenue.AllowUserToAddRows = true;

            //dg_meta_detail_view.Columns[4].DefaultCellStyle.Format = "N0";
            //dg_meta_detail_view.Columns[5].DefaultCellStyle.Format = "P1";
            //dg_meta_detail_view.Columns[6].DefaultCellStyle.Format = "N2";
            //dg_meta_detail_view.Columns[7].DefaultCellStyle.Format = "N2";
            //dg_meta_detail_view.Columns[8].DefaultCellStyle.Format = "N2";
            //dg_meta_detail_view.Columns[9].DefaultCellStyle.Format = "N2";
            //dg_meta_detail_view.Columns[10].DefaultCellStyle.Format = "N1";
            //dg_meta_detail_view.Columns[11].DefaultCellStyle.Format = "N1";
            //dg_meta_detail_view.Columns[12].DefaultCellStyle.Format = "N0";
            //dg_meta_detail_view.Columns[13].DefaultCellStyle.Format = "P2";
            //dg_meta_detail_view.Columns[14].DefaultCellStyle.Format = "P2";

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
                            }
                        }
                    }

                    if (!chk_free_fuel.Checked)
                        coin_value -= ( (double)group.fuel_cost / (double)master_values.FirstOrDefault(x => x.resource == "Fuel").ammount) * master_values.FirstOrDefault(x => x.resource == "Fuel").sell_price;
                }
                if (show_average)
                {
                    row.Cells[7].Value = Math.Round((double)coin_value / (double)group.games,2);
                }
                else
                {
                    row.Cells[7].Value = Math.Round(coin_value, 2);
                }
                
                row.Cells[8].Value = Math.Round((double)coin_value / ((double)group.total_game_duration / 3600.0), 2);
                dg_revenue.Rows.Add(row);
            }

            dg_revenue.AllowUserToAddRows = false;
            dg_revenue.Sort(dg_revenue.Columns[2], ListSortDirection.Descending);
        }

        private void initialize_user_profile()
        {
            movement_usage = new Dictionary<string, int> { };
            cabin_usage = new Dictionary<string, int> { };
            weapon_usage = new Dictionary<string, int> { };
            module_usage = new Dictionary<string, int> { };
        }
        private void btn_save_user_settings_Click_1(object sender, EventArgs e)
        {
            game_mode_filter = global_data.GAME_MODE_FILTER_DEFAULT;
            group_filter = global_data.GROUP_FILTER_DEFAULT;
            power_score_filter = global_data.POWER_SCORE_FILTER_DEFAULT;
            client_versions_filter = global_data.CLIENT_VERSION_FILTER_DEFAULT;
            weapons_filter = global_data.WEAPONS_FILTER_DEFAULT;
            movement_filter = global_data.MOVEMENT_FILTER_DEFAULT;
            module_filter = global_data.MODULE_FILTER_DEFAULT;
            cabin_filter = global_data.CABIN_FILTER_DEFAULT;

            chk_free_fuel.Checked = false;

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_revenue_review_screen();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_versions.SelectedIndex >= 0)
                client_versions_filter = this.cb_versions.Text;

            populate_revenue_review_screen();
        }

        private void cb_power_score_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_power_score.SelectedIndex >= 0)
                power_score_filter = this.cb_power_score.Text;

            populate_revenue_review_screen();
        }

        private void cb_grouped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_grouped.SelectedIndex >= 0)
                group_filter = this.cb_grouped.Text;

            populate_revenue_review_screen();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_game_modes.SelectedIndex >= 0)
                game_mode_filter = this.cb_game_modes.Text;

            populate_revenue_review_screen();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            populate_revenue_review_screen();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            populate_revenue_review_screen();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_cabins.SelectedIndex >= 0)
                cabin_filter = this.cb_cabins.Text;

            populate_revenue_review_screen();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_weapons.SelectedIndex >= 0)
                weapons_filter = this.cb_weapons.Text;

            populate_revenue_review_screen();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_modules.SelectedIndex >= 0)
                module_filter = this.cb_modules.Text;

            populate_revenue_review_screen();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_movement.SelectedIndex >= 0)
                movement_filter = this.cb_movement.Text;

            populate_revenue_review_screen();
        }

        private void chk_weapon_filter_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_revenue_review_screen();
        }

        private void chk_game_result_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_revenue_review_screen();
        }

        private void chk_premium_CheckedChanged(object sender, EventArgs e)
        {
            force_refresh = true;
            populate_revenue_review_screen();
        }

        private void chk_free_fuel_CheckedChanged(object sender, EventArgs e)
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
    }
}

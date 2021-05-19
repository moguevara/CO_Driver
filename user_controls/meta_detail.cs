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
    public partial class meta_detail : UserControl
    {
        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public bool force_refresh = false;
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
        private int total_wins = 0;
        private double global_enemy_win_percent = 0.0;


        private List<master_meta_grouping> master_groupings = new List<master_meta_grouping> { };
        private List<meta_grouping> match_stats = new List<meta_grouping> { };

        private class meta_grouping
        {
            public string weapon { get; set; }
            public string cabin { get; set; }
            public string movement { get; set; }
            public string map { get; set; }
            public file_trace_managment.Stats stats { get; set; }
        }

        private class master_meta_grouping
        {
            public int games { get; set; }
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
                new_selection = string.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    game_mode_filter, group_filter, power_score_filter, client_versions_filter, weapons_filter, movement_filter, module_filter, cabin_filter, dt_start_date.Value.ToString(), dt_end_date.Value.ToString());

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;

            total_games = 0;
            total_wins = 0;
            master_groupings = new List<master_meta_grouping> { };
            List<meta_grouping> groupings = new List<meta_grouping> { };

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

                /* begin calc */

                total_games += 1;
                match_stats = new List<meta_grouping> { };
                

                if (match.match_data.local_player.team != match.match_data.winning_team && match.match_data.winning_team != -1)
                    total_wins += 1; /* enemy wins */

                foreach (KeyValuePair<string, file_trace_managment.Player> player in match.match_data.player_records)
                {
                    if (player.Value.team == match.match_data.local_player.team)
                        continue;

                    if (!build_records.ContainsKey(player.Value.build_hash))
                        continue;

                    if (!chk_bot_filter.Checked && player.Value.bot == 1)
                        continue;

                    if (!chk_bot_filter.Checked && player.Value.power_score >= 22000)
                        continue;

                    groupings = new List<meta_grouping> { };
                    file_trace_managment.BuildRecord build = build_records[player.Value.build_hash];

                    if (chk_weapon_filter.Checked)
                    {
                        foreach (part_loader.Weapon weapon in build.weapons)
                        {
                            meta_grouping new_group = new_grouping();
                            new_group.weapon = translate.translate_string(weapon.name, session, translations);
                            new_group.stats = player.Value.stats;
                            groupings.Add(new_group);
                        }
                    }

                    if (chk_movement_filter.Checked)
                    {
                        if (groupings == null || !groupings.Any())
                        {
                            foreach (part_loader.Movement movement in build.movement)
                            {
                                meta_grouping new_group = new_grouping();
                                new_group.movement = translate.translate_string(movement.name, session, translations);
                                new_group.stats = player.Value.stats;
                                groupings.Add(new_group);
                            }
                        }
                        else
                        {
                            foreach (meta_grouping sub_group in groupings.ToList())
                            {
                                for(int i = 0; i < build.movement.Count(); i++)
                                {
                                    if (i == 0)
                                    {
                                        sub_group.movement = translate.translate_string(build.movement[i].name, session, translations);
                                    }
                                    else
                                    {
                                        meta_grouping new_group = new_grouping();
                                        new_group.weapon = sub_group.weapon;
                                        new_group.movement = translate.translate_string(build.movement[i].name, session, translations);
                                        new_group.stats = player.Value.stats;
                                        groupings.Add(new_group);
                                    }
                                }
                            }
                        }
                    }

                    if (chk_cabin_filter.Checked)
                    {
                        if (groupings == null || !groupings.Any())
                        {
                            meta_grouping new_group = new_grouping();
                            new_group.cabin = translate.translate_string(build.cabin.name, session, translations);
                            new_group.stats = player.Value.stats;
                            groupings.Add(new_group);
                        }
                        else
                        {
                            foreach (meta_grouping sub_group in groupings)
                                sub_group.cabin = translate.translate_string(build.cabin.name, session, translations);
                        }
                    }
                        

                    if (chk_map_filter.Checked)
                    {
                        if (groupings == null || !groupings.Any())
                        {
                            meta_grouping new_group = new_grouping();
                            new_group.map = translate.translate_string(match.match_data.map_name, session, translations);
                            new_group.stats = player.Value.stats;
                            groupings.Add(new_group);
                        }
                        else
                        {
                            foreach (meta_grouping sub_group in groupings)
                                sub_group.map = translate.translate_string(match.match_data.map_name, session, translations);
                        }
                    }

                    foreach (meta_grouping sub_group in groupings)
                    {
                        bool found = false;
                        for (int i = 0; i < match_stats.Count(); i++)
                        {
                            if (match_stats[i].cabin == sub_group.cabin &&
                                match_stats[i].movement == sub_group.movement &&
                                match_stats[i].weapon == sub_group.weapon &&
                                match_stats[i].map == sub_group.map)
                            {
                                found = true;
                                match_stats[i].stats = file_trace_managment.sum_stats(match_stats[i].stats, player.Value.stats);
                            }
                        }
                        if (!found)
                            match_stats.Add(sub_group);
                    }
                }
                foreach (meta_grouping sub_group in match_stats)
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
                            master_groupings[i].group.stats = file_trace_managment.sum_stats(master_groupings[i].group.stats, sub_group.stats);
                        }
                    }
                    if (!found)
                        master_groupings.Add(new master_meta_grouping { games = 1, group = sub_group });
                }

            }

            global_enemy_win_percent = (double)total_games > 0 ? (double)total_wins / (double)total_games : 0.0;

            lb_global_percentage.Text = string.Format("{0}%", Math.Round(global_enemy_win_percent * 100, 1));
            lb_total_game.Text = total_games.ToString();

            populate_meta_detail_screen_elements();
            populate_filters();
        }

        private meta_grouping new_grouping()
        {
            return new meta_grouping { map = "", cabin = "", movement = "", weapon = "" };
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
                cb_game_modes.Items.Add(desc);

            foreach (string desc in grouped)
                cb_grouped.Items.Add(desc);

            foreach (string desc in power_scores)
                cb_power_score.Items.Add(desc);

            foreach (string desc in client_versions)
                cb_versions.Items.Add(desc);

            foreach (string desc in weapons)
                cb_weapons.Items.Add(desc);

            foreach (string desc in movement_parts)
                cb_movement.Items.Add(desc);

            foreach (string desc in cabins)
                cb_cabins.Items.Add(desc);

            foreach (string desc in module_parts)
                cb_modules.Items.Add(desc);

            cb_game_modes.Text = game_mode_filter;
            cb_grouped.Text = group_filter;
            cb_power_score.Text = power_score_filter;
            cb_versions.Text = client_versions_filter;
            cb_weapons.Text = weapons_filter;
            cb_movement.Text = movement_filter;
            cb_cabins.Text = cabin_filter;
            cb_modules.Text = module_filter;
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
            dg_meta_detail_view.Columns[10].DefaultCellStyle.Format = "N1";
            dg_meta_detail_view.Columns[11].DefaultCellStyle.Format = "N1";
            dg_meta_detail_view.Columns[12].DefaultCellStyle.Format = "N0";
            dg_meta_detail_view.Columns[13].DefaultCellStyle.Format = "P2";
            dg_meta_detail_view.Columns[14].DefaultCellStyle.Format = "P2";

            foreach (master_meta_grouping group in master_groupings)
            {
                DataGridViewRow row = (DataGridViewRow)dg_meta_detail_view.Rows[0].Clone();
                row.Cells[0].Value = group.group.weapon;
                row.Cells[1].Value = group.group.cabin;
                row.Cells[2].Value = group.group.movement;
                row.Cells[3].Value = group.group.map;
                row.Cells[4].Value = group.games;
                row.Cells[5].Value = (double)group.games / (double)total_games;
                row.Cells[6].Value = (double)group.group.stats.games / (double)group.games;
                row.Cells[7].Value = (double)group.group.stats.kills / (double)group.group.stats.rounds;
                row.Cells[8].Value = (double)group.group.stats.assists / (double)group.group.stats.rounds;
                row.Cells[9].Value = (double)group.group.stats.deaths / (double)group.group.stats.rounds;
                row.Cells[10].Value = (double)group.group.stats.damage / (double)group.group.stats.rounds;
                row.Cells[11].Value = (double)group.group.stats.damage_taken / (double)group.group.stats.rounds;
                row.Cells[12].Value = (double)group.group.stats.score / (double)group.group.stats.rounds;
                row.Cells[13].Value = (double)group.group.stats.wins / (double)group.group.stats.games;
                row.Cells[14].Value = (((double)group.group.stats.wins / (double)group.group.stats.games) - global_enemy_win_percent);
                dg_meta_detail_view.Rows.Add(row);
            }

            dg_meta_detail_view.AllowUserToAddRows = false;
            dg_meta_detail_view.Sort(dg_meta_detail_view.Columns[5], ListSortDirection.Descending);
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
            if (this.cb_versions.SelectedIndex >= 0)
                client_versions_filter = this.cb_versions.Text;

            populate_meta_detail_screen();
        }

        private void cb_power_score_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_power_score.SelectedIndex >= 0)
                power_score_filter = this.cb_power_score.Text;

            populate_meta_detail_screen();
        }

        private void cb_grouped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_grouped.SelectedIndex >= 0)
                group_filter = this.cb_grouped.Text;

            populate_meta_detail_screen();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_game_modes.SelectedIndex >= 0)
                game_mode_filter = this.cb_game_modes.Text;

            populate_meta_detail_screen();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            populate_meta_detail_screen();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            populate_meta_detail_screen();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_cabins.SelectedIndex >= 0)
                cabin_filter = this.cb_cabins.Text;

            populate_meta_detail_screen();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_weapons.SelectedIndex >= 0)
                weapons_filter = this.cb_weapons.Text;

            populate_meta_detail_screen();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_modules.SelectedIndex >= 0)
                module_filter = this.cb_modules.Text;

            populate_meta_detail_screen();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_movement.SelectedIndex >= 0)
                movement_filter = this.cb_movement.Text;

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

        private void lb_user_name_Click(object sender, EventArgs e)
        {

        }
    }
}

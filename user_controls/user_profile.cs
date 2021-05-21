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
    public partial class user_profile : UserControl
    {
        private class MapData
        {
            public string map_name;
            public int games;
            public int wins;
        }

        private class Opponent
        {
            public string nickname;
            public int killed;
            public int been_killed;
        }

        private class MaxKills
        {
            public int max_kills;
            public int count;
        }

        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public bool force_refresh = false;
        private string local_user;
        private int games_played;
        private int total_rounds;
        private int wins;
        private int total_kills;
        private int total_deaths;
        private int total_assists;
        private int total_drone_kills;
        private int total_score;
        private double total_damage;
        private double total_damage_rec;
        private int total_medals;
        private int total_mvp;
        private int global_total_score;
        private int global_total_bot_score;
        private int global_total_player_count;
        private int global_total_bot_count;
        private int max_score;
        private double max_damage_rec;
        private double max_damage_dealt;
        private MaxKills max_kills = new MaxKills { max_kills = 0, count = 0 };
        private double player_index;
        private double bot_index;
        private Dictionary<string, int> total_resources;
        private Dictionary<string, MapData> total_map_data;
        private Dictionary<string, Opponent> opponent_dict = new Dictionary<string, Opponent> { };
        private Dictionary<string, int> weapon_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> movement_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> cabin_usage = new Dictionary<string, int> { };
        private Dictionary<string, int> module_usage = new Dictionary<string, int> { };
        private DateTime min_date;
        private DateTime max_date;
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

        //translate.translate_string(map.Key,session, translations);
        //ui_translate.translate(ctrl.Text, session, ui_translations);

        public user_profile()
        {
            InitializeComponent();
        }

        public void populate_user_profile_screen()
        {
            if (!force_refresh)
            {
                new_selection = string.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", 
                    game_mode_filter, group_filter, power_score_filter, client_versions_filter, weapons_filter, movement_filter, module_filter, cabin_filter, dt_start_date.Value.ToString(), dt_end_date.Value.ToString());

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;



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

                if (group_filter == "Grouped" &&  match.match_data.local_player.party_id == 0)
                    continue;

                if (client_versions_filter != global_data.CLIENT_VERSION_FILTER_DEFAULT && client_versions_filter != match.match_data.client_version)
                    continue;

                if (dt_start_date.Value.Date != DateTime.Now.Date && match.match_data.match_start.Date < dt_start_date.Value.Date)
                    continue;

                if (dt_end_date.Value.Date != DateTime.Now.Date && match.match_data.match_start.Date > dt_end_date.Value.Date)
                    continue;

                if (power_score_filter != global_data.POWER_SCORE_FILTER_DEFAULT)
                {
                    if (power_score_filter == "0-2499" && ( match.match_data.local_player.power_score < 0 ||  match.match_data.local_player.power_score > 2499))
                        continue;

                    if (power_score_filter == "2500-3499" && ( match.match_data.local_player.power_score < 2500 ||  match.match_data.local_player.power_score > 3499))
                        continue;

                    if (power_score_filter == "3500-4499" && ( match.match_data.local_player.power_score < 3500 ||  match.match_data.local_player.power_score > 4499))
                        continue;

                    if (power_score_filter == "4500-5499" && ( match.match_data.local_player.power_score < 4500 ||  match.match_data.local_player.power_score > 5499))
                        continue;

                    if (power_score_filter == "5500-6499" && ( match.match_data.local_player.power_score < 5500 ||  match.match_data.local_player.power_score > 6499))
                        continue;

                    if (power_score_filter == "6500-7499" && ( match.match_data.local_player.power_score < 6500 ||  match.match_data.local_player.power_score > 7499))
                        continue;

                    if (power_score_filter == "7500-8499" && ( match.match_data.local_player.power_score < 7500 ||  match.match_data.local_player.power_score > 8499))
                        continue;

                    if (power_score_filter == "8500-9499" && ( match.match_data.local_player.power_score < 8500 ||  match.match_data.local_player.power_score > 9499))
                        continue;

                    if (power_score_filter == "9500-12999" && ( match.match_data.local_player.power_score < 9500 ||  match.match_data.local_player.power_score > 12999))
                        continue;

                    if (power_score_filter == "13000+" && ( match.match_data.local_player.power_score < 13000 ||  match.match_data.local_player.power_score > 22000))
                        continue;

                    if (power_score_filter == "Leviathan" &&  match.match_data.local_player.power_score < 22000)
                        continue;
                }

                if (build_records.ContainsKey( match.match_data.local_player.build_hash))
                {
                    if (weapons_filter != global_data.WEAPONS_FILTER_DEFAULT && build_records[ match.match_data.local_player.build_hash].weapons.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == weapons_filter).Count() == 0)
                        continue;

                    if (movement_filter != global_data.MOVEMENT_FILTER_DEFAULT && build_records[ match.match_data.local_player.build_hash].movement.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == movement_filter).Count() == 0)
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

                if ( match.match_data.local_player.party_id == 0 && !grouped.Contains("Solo"))
                    grouped.Add("Solo");

                if ( match.match_data.local_player.party_id > 0 && !grouped.Contains("Grouped"))
                    grouped.Add("Grouped");

                if ( match.match_data.local_player.power_score >= 0 &&  match.match_data.local_player.power_score <= 2499 && !power_scores.Contains("0-2499"))
                    power_scores.Add("0-2499");

                if ( match.match_data.local_player.power_score >= 2500 &&  match.match_data.local_player.power_score <= 2499 && !power_scores.Contains("2500-3499"))
                    power_scores.Add("2500-3499");

                if ( match.match_data.local_player.power_score >= 3500 &&  match.match_data.local_player.power_score <= 4499 && !power_scores.Contains("3500-4499"))
                    power_scores.Add("3500-4499");

                if ( match.match_data.local_player.power_score >= 4500 &&  match.match_data.local_player.power_score <= 5499 && !power_scores.Contains("4500-5499"))
                    power_scores.Add("4500-5499");

                if ( match.match_data.local_player.power_score >= 5500 &&  match.match_data.local_player.power_score <= 6499 && !power_scores.Contains("5500-6499"))
                    power_scores.Add("5500-6499");

                if ( match.match_data.local_player.power_score >= 6500 &&  match.match_data.local_player.power_score <= 7499 && !power_scores.Contains("6500-7499"))
                    power_scores.Add("6500-7499");

                if ( match.match_data.local_player.power_score >= 7500 &&  match.match_data.local_player.power_score <= 8499 && !power_scores.Contains("7500-8499"))
                    power_scores.Add("7500-8499");

                if ( match.match_data.local_player.power_score >= 8500 &&  match.match_data.local_player.power_score <= 9499 && !power_scores.Contains("8500-9499"))
                    power_scores.Add("8500-9499");

                if ( match.match_data.local_player.power_score >= 9500 &&  match.match_data.local_player.power_score <= 12999 && !power_scores.Contains("9500-12999"))
                    power_scores.Add("9500-12999");

                if ( match.match_data.local_player.power_score >= 13000 &&  match.match_data.local_player.power_score <= 22000 && !power_scores.Contains("13000+"))
                    power_scores.Add("13000+");

                if ( match.match_data.local_player.power_score >= 22000 && !power_scores.Contains("Leviathan"))
                    power_scores.Add("Leviathan");

                if (!client_versions.Contains(match.match_data.client_version))
                    client_versions.Add((match.match_data.client_version));

                if (build_records.ContainsKey( match.match_data.local_player.build_hash))
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
                            cabin_usage[translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name,session, translations)] += 1;
                    }
                    
                    foreach (part_loader.Weapon weapon in build_records[ match.match_data.local_player.build_hash].weapons)
                    {
                        if (!weapons.Contains(translate.translate_string(weapon.name, session, translations)))
                        {
                            weapons.Add(translate.translate_string(weapon.name,session, translations));
                        }
                        if (!weapon_usage.ContainsKey(translate.translate_string(weapon.name, session, translations)))
                            weapon_usage.Add(translate.translate_string(weapon.name,session, translations), 1);
                        else
                            weapon_usage[translate.translate_string(weapon.name, session, translations)] += 1;
                    }

                    foreach (part_loader.Movement movement in build_records[ match.match_data.local_player.build_hash].movement)
                    {
                        if (!movement_parts.Contains(translate.translate_string(movement.name,session, translations)))
                        {
                            movement_parts.Add(translate.translate_string(movement.name, session, translations));
                        }

                        if (!movement_usage.ContainsKey(translate.translate_string(movement.name,session, translations)))
                            movement_usage.Add(translate.translate_string(movement.name,session, translations), 1);
                        else
                            movement_usage[translate.translate_string(movement.name,session, translations)] += 1;
                    }

                    foreach (part_loader.Module module in build_records[match.match_data.local_player.build_hash].modules)
                    {
                        if (!module_parts.Contains(translate.translate_string(module.name, session, translations)))
                        {
                            module_parts.Add(translate.translate_string(module.name,session, translations));
                        }

                        if (!module_usage.ContainsKey(translate.translate_string(module.name,session, translations)))
                            module_usage.Add(translate.translate_string(module.name,session,translations), 1);
                        else
                            module_usage[translate.translate_string(module.name,session,translations)] += 1;
                    }
                }

                games_played++;
                if (match.match_data.game_result == "Win")
                    wins++;

                if (local_user == "")
                    local_user =  match.match_data.local_player.nickname;

                total_rounds +=  match.match_data.local_player.stats.rounds;
                total_kills +=  match.match_data.local_player.stats.kills;
                total_deaths +=  match.match_data.local_player.stats.deaths;
                total_assists +=  match.match_data.local_player.stats.assists;
                total_drone_kills +=  match.match_data.local_player.stats.drone_kills;
                total_damage +=  match.match_data.local_player.stats.damage;
                total_damage_rec +=  match.match_data.local_player.stats.damage_taken;
                total_score +=  match.match_data.local_player.stats.score;
                total_medals +=  match.match_data.local_player.stripes.Count();

                foreach (KeyValuePair<string, file_trace_managment.Player> player in match.match_data.player_records)
                {
                    if (player.Value.bot == 1)
                    {
                        global_total_bot_count += 1;
                        global_total_bot_score += player.Value.stats.score;
                    }
                    else if (player.Key != local_user)
                    {
                        global_total_player_count += 1;
                        global_total_score += player.Value.stats.score;
                    } 
                }

                if ( match.match_data.local_player.stats.score > max_score)
                    max_score =  match.match_data.local_player.stats.score;

                if ( match.match_data.local_player.stats.damage > max_damage_dealt)
                    max_damage_dealt =  match.match_data.local_player.stats.damage;

                if ( match.match_data.local_player.stats.damage_taken > max_damage_rec)
                    max_damage_rec =  match.match_data.local_player.stats.damage_taken;

                if ( match.match_data.local_player.stats.kills == max_kills.max_kills)
                    max_kills.count += 1;

                if ( match.match_data.local_player.stats.kills > max_kills.max_kills)
                {
                    max_kills.max_kills = match.match_data.local_player.stats.kills;
                    max_kills.count = 1;
                }

                if (match.match_data.nemesis != "")
                {
                    if (!opponent_dict.ContainsKey(match.match_data.nemesis))
                        opponent_dict.Add(match.match_data.nemesis, new Opponent { nickname = match.match_data.nemesis, been_killed = 1, killed = 0 });
                    else
                        opponent_dict[match.match_data.nemesis].been_killed += 1;
                }

                foreach (string victim in match.match_data.victims)
                {
                    if (!opponent_dict.ContainsKey(victim))
                        opponent_dict.Add(victim, new Opponent { nickname = victim, been_killed = 0, killed = 1 });
                    else
                        opponent_dict[victim].killed += 1;
                }

                foreach (string stripe in  match.match_data.local_player.stripes)
                    if (stripe == "PvpMvpWin")
                        total_mvp++;

                if (!total_map_data.ContainsKey(match.match_data.map_desc))
                {
                    total_map_data.Add(match.match_data.map_desc, new MapData { map_name = match.match_data.map_desc, wins = match.match_data.game_result == "Win" ? 1 : 0, games = 1 });
                }
                else
                {
                    total_map_data[match.match_data.map_desc].games = total_map_data[match.match_data.map_desc].games + 1;
                    if (match.match_data.game_result == "Win")
                        total_map_data[match.match_data.map_desc].wins = total_map_data[match.match_data.map_desc].wins + 1;
                }

                foreach (KeyValuePair<string, int> match_reward in match.match_data.match_rewards)
                {
                    if (!total_resources.ContainsKey(match_reward.Key))
                    {
                        total_resources.Add(match_reward.Key, match_reward.Value);
                    }
                    else
                        total_resources[match_reward.Key] += match_reward.Value;
                }
            }

            populate_user_profile_screen_elements();
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

        private void populate_user_profile_screen_elements()
        {
            double avg_player_score = total_rounds > 0 ? Math.Round((((double)total_score) / (double)games_played)) : double.PositiveInfinity;

            lb_user_name.Text = local_user;
            lb_games_played.Text = games_played.ToString();
            lb_wins.Text = wins.ToString();
            lb_win_rate.Text = string.Format(@"{0}%", games_played > 0 ? Math.Round((((double)wins / (double)games_played) * 100), 2) : double.PositiveInfinity);
            lb_total_kills.Text = total_kills.ToString();
            lb_total_deaths.Text = total_deaths.ToString();
            lb_total_assists.Text = total_assists.ToString();
            lb_total_drone_kills.Text = total_drone_kills.ToString();
            lb_total_kill_deaths.Text = string.Format(@"{0}", games_played > 0 ? Math.Round(((double)total_kills / (double)games_played), 1) : double.PositiveInfinity);
            lb_total_kill_assist_death.Text = string.Format(@"{0}", games_played > 0 ? Math.Round((((double)total_kills + (double)total_assists) / (double)games_played), 1) : double.PositiveInfinity);
            lb_total_medals.Text = total_medals.ToString();
            lb_total_mvp.Text = total_mvp.ToString();
            lb_mvp_percent.Text = string.Format(@"{0}%", total_rounds > 0 ? Math.Round(((((double)total_mvp) / (double)games_played) * 100), 2) : double.PositiveInfinity);
            lb_avg_score.Text = string.Format(@"{0}", avg_player_score);
            lb_avg_kills.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_kills) / (double)total_rounds),1) : double.PositiveInfinity);
            lb_avg_assists.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_assists) / (double)total_rounds),1) : double.PositiveInfinity);
            lb_avg_dmg.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_damage) / (double)total_rounds)) : double.PositiveInfinity);
            lb_avg_dmg_rec.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_damage_rec) / (double)total_rounds)) : double.PositiveInfinity);
            lb_player_index.Text = player_index.ToString();
            lb_bot_index.Text = bot_index.ToString();
            lb_max_damage.Text = Math.Round(max_damage_dealt,1).ToString();
            lb_max_damage_rec.Text = Math.Round(max_damage_rec,1).ToString();
            lb_highest_score.Text = max_score.ToString();
            if (max_kills.count > 1)
                lb_max_kills.Text = string.Format(@"({0} Kills)x{1}", max_kills.max_kills, max_kills.count);
            else
                lb_max_kills.Text = string.Format(@"{0} Kills", max_kills.max_kills);

            if (movement_usage.Count() > 0)
                lb_movement.Text = movement_usage.ToList().OrderByDescending(x => x.Value).ToList().First().Key;
            else
                lb_movement.Text = "";

            if (weapon_usage.Count() > 0)
                lb_weapon.Text = weapon_usage.ToList().OrderByDescending(x => x.Value).ToList().First().Key;
            else
                lb_weapon.Text = "";

            lb_player_index.Text = global_total_player_count > 0 ? Math.Round((avg_player_score / ((double)global_total_score / (double)global_total_player_count)), 2).ToString() : "N/A";
            lb_bot_index.Text = global_total_player_count > 0 ? Math.Round((avg_player_score / ((double)global_total_bot_score / (double)global_total_bot_count)), 2).ToString() : "N/A";

            dg_resources.Rows.Clear();
            dg_resources.AllowUserToAddRows = true;
            dg_resources.Columns[1].DefaultCellStyle.Format = "N0";

            foreach (KeyValuePair<string, int> resource in total_resources.OrderByDescending(x => x.Value))
            {
                DataGridViewRow row = (DataGridViewRow)dg_resources.Rows[0].Clone();
                row.Cells[0].Value = translate.translate_string(resource.Key,session,translations);
                row.Cells[1].Value = (int)resource.Value;
                dg_resources.Rows.Add(row);
            }

            dg_resources.AllowUserToAddRows = false;
            dg_resources.ClearSelection();

            dg_map_data.Rows.Clear();
            dg_map_data.AllowUserToAddRows = true;
            dg_map_data.Columns[1].DefaultCellStyle.Format = "P1";

            bool first = true;

            foreach (KeyValuePair<string, MapData> map in total_map_data.OrderByDescending(x => x.Value.wins / x.Value.games).ThenByDescending(x => x.Value.wins))
            {
                if (first)
                {
                    lb_best_map.Text = translate.translate_string(map.Key, session, translations);
                    first = false;
                }
                DataGridViewRow row = (DataGridViewRow)this.dg_map_data.Rows[0].Clone();
                row.Cells[0].Value = translate.translate_string(map.Key,session, translations);
                row.Cells[1].Value = string.Format(@"{0}/{1}", map.Value.wins, map.Value.games - map.Value.wins);
                dg_map_data.Rows.Add(row);
            }

            dg_map_data.AllowUserToAddRows = false;
            dg_map_data.ClearSelection();

            dg_nemesis_list.Rows.Clear();
            dg_nemesis_list.AllowUserToAddRows = true;

            foreach (KeyValuePair<string, Opponent> nemesis in opponent_dict.ToList().OrderByDescending(x => x.Value.killed).OrderByDescending(x => x.Value.been_killed).ToList())
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_nemesis_list.Rows[0].Clone();
                row.Cells[0].Value = nemesis.Key;
                row.Cells[1].Value = string.Format(@"{0}/{1}", nemesis.Value.killed, nemesis.Value.been_killed);
                dg_nemesis_list.Rows.Add(row);
            }

            dg_victim_list.AllowUserToAddRows = false;
            dg_victim_list.ClearSelection();

            dg_victim_list.Rows.Clear();
            dg_victim_list.AllowUserToAddRows = true;

            foreach (KeyValuePair<string, Opponent> nemesis in opponent_dict.OrderByDescending(x => x.Value.been_killed).OrderByDescending(x => x.Value.killed).ToList())
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_victim_list.Rows[0].Clone();
                row.Cells[0].Value = nemesis.Key;
                row.Cells[1].Value = string.Format(@"{0}/{1}", nemesis.Value.killed, nemesis.Value.been_killed);
                dg_victim_list.Rows.Add(row);
            }

            dg_victim_list.AllowUserToAddRows = false;
            dg_victim_list.ClearSelection();

        }

        private void gb_resources_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gb_map_data_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gb_victims_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gb_nemesis_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void initialize_user_profile()
        {
            local_user = "";
            games_played = 0;
            total_rounds = 0;
            wins = 0;
            total_kills = 0;
            total_deaths = 0;
            total_assists = 0;
            total_drone_kills = 0;
            total_medals = 0;
            total_mvp = 0;
            total_damage = 0.0;
            total_damage_rec = 0.0;
            total_score = 0;
            player_index = 0.0;
            bot_index = 0.0;
            global_total_score = 0;
            global_total_bot_score = 0;
            global_total_player_count = 0;
            global_total_bot_count = 0;
            max_score = 0;
            max_damage_rec = 0.0;
            max_damage_dealt = 0.0;
            movement_usage = new Dictionary<string, int> { };
            cabin_usage = new Dictionary<string, int> { };
            weapon_usage = new Dictionary<string, int> { };
            module_usage = new Dictionary<string, int> { };
            max_kills.max_kills = 0;
            max_kills.count = 0;
            total_resources = new Dictionary<string, int> { };
            total_map_data = new Dictionary<string, MapData> { };
            opponent_dict = new Dictionary<string, Opponent> { };
        }
        private void draw_group_box(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                
                g.Clear(this.BackColor);
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void user_profile_Load(object sender, EventArgs e)
        {
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_game_modes.SelectedIndex >= 0)
                game_mode_filter = this.cb_game_modes.Text;
            populate_user_profile_screen();
        }

        private void cb_power_score_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cb_power_score.SelectedIndex >= 0)
                power_score_filter = this.cb_power_score.Text;

            populate_user_profile_screen();
        }

        private void cb_grouped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_grouped.SelectedIndex >= 0)
                group_filter = this.cb_grouped.Text;

            populate_user_profile_screen();
        }
        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_cabins.SelectedIndex >= 0)
                cabin_filter = this.cb_cabins.Text;

            populate_user_profile_screen();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_movement.SelectedIndex >= 0)
                movement_filter = this.cb_movement.Text;

            populate_user_profile_screen();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_weapons.SelectedIndex >= 0)
                weapons_filter = this.cb_weapons.Text;

            populate_user_profile_screen();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_versions.SelectedIndex >= 0)
                client_versions_filter = this.cb_versions.Text;

            populate_user_profile_screen();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cb_modules.SelectedIndex >= 0)
                module_filter = this.cb_modules.Text;

            populate_user_profile_screen();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            if (dt_end_date.Value < dt_start_date.Value)
                dt_end_date.Value = dt_start_date.Value;

            populate_user_profile_screen();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            if (dt_start_date.Value > dt_end_date.Value)
                dt_start_date.Value = dt_end_date.Value;

            populate_user_profile_screen();
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            game_mode_filter = global_data.GAME_MODE_FILTER_DEFAULT;
            group_filter = global_data.GROUP_FILTER_DEFAULT;
            power_score_filter = global_data.POWER_SCORE_FILTER_DEFAULT;
            client_versions_filter = global_data.CLIENT_VERSION_FILTER_DEFAULT;
            weapons_filter = global_data.WEAPONS_FILTER_DEFAULT;
            movement_filter = global_data.MOVEMENT_FILTER_DEFAULT;
            module_filter = global_data.MODULE_FILTER_DEFAULT;
            cabin_filter = global_data.CABIN_FILTER_DEFAULT;

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_user_profile_screen();
        }

        private void lb_max_kills_Click(object sender, EventArgs e)
        {

        }

    }
}

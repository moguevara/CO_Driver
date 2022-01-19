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
    class filter
    {
        public class FilterSelections
        {
            public string game_mode_filter { get; set; }
            public string group_filter { get; set; }
            public string power_score_filter { get; set; }
            public string client_versions_filter { get; set; }
            public string weapons_filter { get; set; }
            public string movement_filter { get; set; }
            public string cabin_filter { get; set; }
            public string module_filter { get; set; }
            public DateTime start_date { get; set; }
            public DateTime end_date { get; set; }
            public List<string> game_modes { get; set; }
            public List<string> grouped { get; set; }
            public List<string> power_scores { get; set; }
            public List<string> client_versions { get; set; }
            public List<string> weapons { get; set; }
            public List<string> movement_parts { get; set; }
            public List<string> cabins { get; set; }
            public List<string> module_parts { get; set; }
        }

        public static FilterSelections new_filter_selection()
        {
            return new FilterSelections
            {
                game_mode_filter = global_data.GAME_MODE_FILTER_DEFAULT,
                group_filter = global_data.GROUP_FILTER_DEFAULT,
                power_score_filter = global_data.POWER_SCORE_FILTER_DEFAULT,
                client_versions_filter = global_data.CLIENT_VERSION_FILTER_DEFAULT,
                weapons_filter = global_data.WEAPONS_FILTER_DEFAULT,
                movement_filter = global_data.MOVEMENT_FILTER_DEFAULT,
                module_filter = global_data.MODULE_FILTER_DEFAULT,
                cabin_filter = global_data.CABIN_FILTER_DEFAULT,
                start_date = DateTime.Now,
                end_date = DateTime.Now,
                game_modes = new List<string> { },
                grouped = new List<string> { },
                power_scores = new List<string> { },
                client_versions = new List<string> { },
                weapons = new List<string> { },
                movement_parts = new List<string> { },
                cabins = new List<string> { },
                module_parts = new List<string> { }
            };
        }

        public static string filter_string(FilterSelections filter)
        {
            return string.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    filter.game_mode_filter, filter.group_filter, filter.power_score_filter, filter.client_versions_filter, filter.weapons_filter,
                    filter.movement_filter, filter.module_filter, filter.cabin_filter, filter.start_date.ToString(), filter.end_date.ToString());

        }

        public static void reset_filter_selections(FilterSelections filter)
        {
            filter.game_mode_filter = global_data.GAME_MODE_FILTER_DEFAULT;
            filter.group_filter = global_data.GROUP_FILTER_DEFAULT;
            filter.power_score_filter = global_data.POWER_SCORE_FILTER_DEFAULT;
            filter.client_versions_filter = global_data.CLIENT_VERSION_FILTER_DEFAULT;
            filter.weapons_filter = global_data.WEAPONS_FILTER_DEFAULT;
            filter.movement_filter = global_data.MOVEMENT_FILTER_DEFAULT;
            filter.module_filter = global_data.MODULE_FILTER_DEFAULT;
            filter.cabin_filter = global_data.CABIN_FILTER_DEFAULT;
            filter.start_date = DateTime.Now;
            filter.end_date = DateTime.Now;
        }

        public static bool check_filters(FilterSelections filter, file_trace_managment.MatchRecord match, Dictionary<string, file_trace_managment.BuildRecord> build_records,
                                  log_file_managment.session_variables session, Dictionary<string, Dictionary<string, translate.Translation>> translations)
        {
            if (filter.game_mode_filter != global_data.GAME_MODE_FILTER_DEFAULT && filter.game_mode_filter != "PvP" && filter.game_mode_filter != "PvE" && filter.game_mode_filter != "Brawl" && filter.game_mode_filter != match.match_data.match_type_desc)
                return false;

            if (filter.game_mode_filter == "PvP" && match.match_data.match_classification != global_data.PVP_CLASSIFICATION)
                return false;

            if (filter.game_mode_filter == "PvE" && match.match_data.match_classification != global_data.PVE_CLASSIFICATION)
                return false;

            if (filter.game_mode_filter == "Brawl" && match.match_data.match_classification != global_data.BRAWL_CLASSIFICATION)
                return false;

            if (filter.group_filter == "Solo" && match.match_data.local_player.party_id > 0)
                return false;

            if (filter.group_filter == "Grouped" && match.match_data.local_player.party_id == 0)
                return false;

            if (filter.client_versions_filter != global_data.CLIENT_VERSION_FILTER_DEFAULT && filter.client_versions_filter != match.match_data.client_version)
                return false;

            if (filter.start_date.Date != DateTime.Now.Date && match.match_data.match_start.Date < filter.start_date)
                return false;

            if (filter.end_date.Date != DateTime.Now.Date && match.match_data.match_start.Date > filter.end_date)
                return false;

            if (filter.power_score_filter != global_data.POWER_SCORE_FILTER_DEFAULT)
            {
                if (filter.power_score_filter == "0-2499" && (match.match_data.local_player.power_score < 0 || match.match_data.local_player.power_score > 2499))
                    return false;

                if (filter.power_score_filter == "2500-3499" && (match.match_data.local_player.power_score < 2500 || match.match_data.local_player.power_score > 3499))
                    return false;

                if (filter.power_score_filter == "3500-4499" && (match.match_data.local_player.power_score < 3500 || match.match_data.local_player.power_score > 4499))
                    return false;

                if (filter.power_score_filter == "4500-5499" && (match.match_data.local_player.power_score < 4500 || match.match_data.local_player.power_score > 5499))
                    return false;

                if (filter.power_score_filter == "5500-6499" && (match.match_data.local_player.power_score < 5500 || match.match_data.local_player.power_score > 6499))
                    return false;

                if (filter.power_score_filter == "6500-7499" && (match.match_data.local_player.power_score < 6500 || match.match_data.local_player.power_score > 7499))
                    return false;

                if (filter.power_score_filter == "7500-8499" && (match.match_data.local_player.power_score < 7500 || match.match_data.local_player.power_score > 8499))
                    return false;

                if (filter.power_score_filter == "8500-9499" && (match.match_data.local_player.power_score < 8500 || match.match_data.local_player.power_score > 9499))
                    return false;

                if (filter.power_score_filter == "9500-12999" && (match.match_data.local_player.power_score < 9500 || match.match_data.local_player.power_score > 12999))
                    return false;

                if (filter.power_score_filter == "13000+" && (match.match_data.local_player.power_score < 13000 || match.match_data.local_player.power_score > 22000))
                    return false;

                if (filter.power_score_filter == "Leviathan" && match.match_data.local_player.power_score < 22000)
                    return false;
            }

            if (build_records.ContainsKey(match.match_data.local_player.build_hash))
            {
                if (filter.weapons_filter != global_data.WEAPONS_FILTER_DEFAULT && build_records[match.match_data.local_player.build_hash].weapons.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == filter.weapons_filter).Count() == 0)
                    return false;

                if (filter.movement_filter != global_data.MOVEMENT_FILTER_DEFAULT && build_records[match.match_data.local_player.build_hash].movement.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == filter.movement_filter).Count() == 0)
                    return false;

                if (filter.cabin_filter != global_data.CABIN_FILTER_DEFAULT && translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations) != filter.cabin_filter)
                    return false;

                if (filter.module_filter != global_data.MODULE_FILTER_DEFAULT && build_records[match.match_data.local_player.build_hash].modules.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == filter.module_filter).Count() == 0)
                    return false;
            }
            else
            {
                if (filter.weapons_filter != global_data.WEAPONS_FILTER_DEFAULT)
                    return false;

                if (filter.movement_filter != global_data.MOVEMENT_FILTER_DEFAULT)
                    return false;

                if (filter.cabin_filter != global_data.CABIN_FILTER_DEFAULT)
                    return false;

                if (filter.module_filter != global_data.MODULE_FILTER_DEFAULT)
                    return false;
            }

            if (!filter.game_modes.Contains(match.match_data.match_type_desc))
                filter.game_modes.Add((match.match_data.match_type_desc));

            if (!filter.game_modes.Contains("PvP") && match.match_data.match_classification == global_data.PVP_CLASSIFICATION)
                filter.game_modes.Add("PvP");

            if (!filter.game_modes.Contains("PvE") && match.match_data.match_classification == global_data.PVE_CLASSIFICATION)
                filter.game_modes.Add("PvE");

            if (!filter.game_modes.Contains("Brawl") && match.match_data.match_classification == global_data.BRAWL_CLASSIFICATION)
                filter.game_modes.Add("Brawl");

            if (match.match_data.match_classification == global_data.PVP_CLASSIFICATION && !filter.game_modes.Contains("PvP"))
                filter.game_modes.Add("PvP");

            if (match.match_data.match_classification == global_data.PVE_CLASSIFICATION && !filter.game_modes.Contains("PvE"))
                filter.game_modes.Add("PvE");

            if (match.match_data.match_classification == global_data.BRAWL_CLASSIFICATION && !filter.game_modes.Contains("Brawl"))
                filter.game_modes.Add("Brawl");

            if (match.match_data.local_player.party_id == 0 && !filter.grouped.Contains("Solo"))
                filter.grouped.Add("Solo");

            if (match.match_data.local_player.party_id > 0 && !filter.grouped.Contains("Grouped"))
                filter.grouped.Add("Grouped");

            if (match.match_data.local_player.power_score >= 0 && match.match_data.local_player.power_score <= 2499 && !filter.power_scores.Contains("0-2499"))
                filter.power_scores.Add("0-2499");

            if (match.match_data.local_player.power_score >= 2500 && match.match_data.local_player.power_score <= 2499 && !filter.power_scores.Contains("2500-3499"))
                filter.power_scores.Add("2500-3499");

            if (match.match_data.local_player.power_score >= 3500 && match.match_data.local_player.power_score <= 4499 && !filter.power_scores.Contains("3500-4499"))
                filter.power_scores.Add("3500-4499");

            if (match.match_data.local_player.power_score >= 4500 && match.match_data.local_player.power_score <= 5499 && !filter.power_scores.Contains("4500-5499"))
                filter.power_scores.Add("4500-5499");

            if (match.match_data.local_player.power_score >= 5500 && match.match_data.local_player.power_score <= 6499 && !filter.power_scores.Contains("5500-6499"))
                filter.power_scores.Add("5500-6499");

            if (match.match_data.local_player.power_score >= 6500 && match.match_data.local_player.power_score <= 7499 && !filter.power_scores.Contains("6500-7499"))
                filter.power_scores.Add("6500-7499");

            if (match.match_data.local_player.power_score >= 7500 && match.match_data.local_player.power_score <= 8499 && !filter.power_scores.Contains("7500-8499"))
                filter.power_scores.Add("7500-8499");

            if (match.match_data.local_player.power_score >= 8500 && match.match_data.local_player.power_score <= 9499 && !filter.power_scores.Contains("8500-9499"))
                filter.power_scores.Add("8500-9499");

            if (match.match_data.local_player.power_score >= 9500 && match.match_data.local_player.power_score <= 12999 && !filter.power_scores.Contains("9500-12999"))
                filter.power_scores.Add("9500-12999");

            if (match.match_data.local_player.power_score >= 13000 && match.match_data.local_player.power_score <= 22000 && !filter.power_scores.Contains("13000+"))
                filter.power_scores.Add("13000+");

            if (match.match_data.local_player.power_score >= 22000 && !filter.power_scores.Contains("Leviathan"))
                filter.power_scores.Add("Leviathan");

            if (!filter.client_versions.Contains(match.match_data.client_version))
                filter.client_versions.Add((match.match_data.client_version));

            if (build_records.ContainsKey(match.match_data.local_player.build_hash))
            {
                if (!string.IsNullOrEmpty(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                    if (!filter.cabins.Contains(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                        filter.cabins.Add(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations));

                foreach (part_loader.Weapon weapon in build_records[match.match_data.local_player.build_hash].weapons)
                    if (!filter.weapons.Contains(translate.translate_string(weapon.name, session, translations)))
                        filter.weapons.Add(translate.translate_string(weapon.name, session, translations));

                foreach (part_loader.Movement movement in build_records[match.match_data.local_player.build_hash].movement)
                    if (!filter.movement_parts.Contains(translate.translate_string(movement.name, session, translations)))
                        filter.movement_parts.Add(translate.translate_string(movement.name, session, translations));

                foreach (part_loader.Module module in build_records[match.match_data.local_player.build_hash].modules)
                    if (!filter.module_parts.Contains(translate.translate_string(module.name, session, translations)))
                        filter.module_parts.Add(translate.translate_string(module.name, session, translations));
            }

            return true;
        }

        public static void populate_filters(FilterSelections filter, ComboBox cb_game_modes, ComboBox cb_grouped,
                                     ComboBox cb_power_score, ComboBox cb_versions, ComboBox cb_weapons,
                                     ComboBox cb_movement, ComboBox cb_cabins, ComboBox cb_modules)
        {
            cb_game_modes.Items.Clear();
            cb_grouped.Items.Clear();
            cb_power_score.Items.Clear();
            cb_versions.Items.Clear();
            cb_weapons.Items.Clear();
            cb_movement.Items.Clear();
            cb_cabins.Items.Clear();
            cb_modules.Items.Clear();

            filter.game_modes = filter.game_modes.OrderBy(x => x != global_data.GAME_MODE_FILTER_DEFAULT).ThenBy(x => x != "PvP").ThenBy(x => x != "PvE").ThenBy(x => x != "Brawl").ThenBy(x => x).ToList();
            filter.power_scores = filter.power_scores.OrderBy(x => x != global_data.POWER_SCORE_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.client_versions = filter.client_versions.OrderBy(x => x != global_data.CLIENT_VERSION_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.weapons = filter.weapons.OrderBy(x => x != global_data.WEAPONS_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.movement_parts = filter.movement_parts.OrderBy(x => x != global_data.MOVEMENT_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.cabins = filter.cabins.OrderBy(x => x != global_data.CABIN_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.module_parts = filter.module_parts.OrderBy(x => x != global_data.MODULE_FILTER_DEFAULT).ThenBy(x => x).ToList();

            if (filter.power_scores.Contains("13000+"))
            {
                filter.power_scores.Remove("13000+");
                filter.power_scores.Add("13000+");
            }

            if (filter.power_scores.Contains("Leviathian"))
            {
                filter.power_scores.Remove("Leviathian");
                filter.power_scores.Add("Leviathian");
            }

            foreach (string desc in filter.game_modes)
                cb_game_modes.Items.Add(desc);

            foreach (string desc in filter.grouped)
                cb_grouped.Items.Add(desc);

            foreach (string desc in filter.power_scores)
                cb_power_score.Items.Add(desc);

            foreach (string desc in filter.client_versions)
                cb_versions.Items.Add(desc);

            foreach (string desc in filter.weapons)
                cb_weapons.Items.Add(desc);

            foreach (string desc in filter.movement_parts)
                cb_movement.Items.Add(desc);

            foreach (string desc in filter.cabins)
                cb_cabins.Items.Add(desc);

            foreach (string desc in filter.module_parts)
                cb_modules.Items.Add(desc);

            cb_game_modes.Text = filter.game_mode_filter;
            cb_grouped.Text = filter.group_filter;
            cb_power_score.Text = filter.power_score_filter;
            cb_versions.Text = filter.client_versions_filter;
            cb_weapons.Text = filter.weapons_filter;
            cb_movement.Text = filter.movement_filter;
            cb_cabins.Text = filter.cabin_filter;
            cb_modules.Text = filter.module_filter;
        }

        public static void reset_filters(FilterSelections filter)
        {
            filter.game_modes = new List<string> { };
            filter.grouped = new List<string> { };
            filter.power_scores = new List<string> { };
            filter.client_versions = new List<string> { };
            filter.weapons = new List<string> { };
            filter.movement_parts = new List<string> { };
            filter.cabins = new List<string> { };
            filter.module_parts = new List<string> { };

            filter.game_modes.Add(global_data.GAME_MODE_FILTER_DEFAULT);
            filter.grouped.Add(global_data.GROUP_FILTER_DEFAULT);
            filter.power_scores.Add(global_data.POWER_SCORE_FILTER_DEFAULT);
            filter.client_versions.Add(global_data.CLIENT_VERSION_FILTER_DEFAULT);
            filter.weapons.Add(global_data.WEAPONS_FILTER_DEFAULT);
            filter.movement_parts.Add(global_data.MOVEMENT_FILTER_DEFAULT);
            filter.cabins.Add(global_data.CABIN_FILTER_DEFAULT);
            filter.module_parts.Add(global_data.MODULE_FILTER_DEFAULT);
        }
    }
}

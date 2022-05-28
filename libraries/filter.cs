using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    class Filter
    {
        public class FilterSelections
        {
            public string GameModeFilter { get; set; }
            public string GroupFilter { get; set; }
            public string PowerScoreFilter { get; set; }
            public string ClientVersionFilter { get; set; }
            public string WeaponsFilter { get; set; }
            public string MovementFilter { get; set; }
            public string CabinFilter { get; set; }
            public string ModuleFilter { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public List<string> GameModes { get; set; }
            public List<string> Grouped { get; set; }
            public List<string> PowerScores { get; set; }
            public List<string> ClientVersions { get; set; }
            public List<string> Weapons { get; set; }
            public List<string> MovementParts { get; set; }
            public List<string> Cabins { get; set; }
            public List<string> ModuleParts { get; set; }
        }

        public static FilterSelections NewFilterSelection()
        {
            return new FilterSelections
            {
                GameModeFilter = GlobalData.GAME_MODE_FILTER_DEFAULT,
                GroupFilter = GlobalData.GROUP_FILTER_DEFAULT,
                PowerScoreFilter = GlobalData.POWER_SCORE_FILTER_DEFAULT,
                ClientVersionFilter = GlobalData.CLIENT_VERSION_FILTER_DEFAULT,
                WeaponsFilter = GlobalData.WEAPONS_FILTER_DEFAULT,
                MovementFilter = GlobalData.MOVEMENT_FILTER_DEFAULT,
                ModuleFilter = GlobalData.MODULE_FILTER_DEFAULT,
                CabinFilter = GlobalData.CABIN_FILTER_DEFAULT,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                GameModes = new List<string> { },
                Grouped = new List<string> { },
                PowerScores = new List<string> { },
                ClientVersions = new List<string> { },
                Weapons = new List<string> { },
                MovementParts = new List<string> { },
                Cabins = new List<string> { },
                ModuleParts = new List<string> { }
            };
        }

        private List<string> TimeFilters = new List<string> { };

        public static string FilterString(FilterSelections filter)
        {
            return string.Format(@"{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    filter.GameModeFilter, filter.GroupFilter, filter.PowerScoreFilter, filter.ClientVersionFilter, filter.WeaponsFilter,
                    filter.MovementFilter, filter.ModuleFilter, filter.CabinFilter, filter.StartDate.ToString(), filter.EndDate.ToString());

        }

        public static void ResetFilterSelections(FilterSelections filter)
        {
            filter.GameModeFilter = GlobalData.GAME_MODE_FILTER_DEFAULT;
            filter.GroupFilter = GlobalData.GROUP_FILTER_DEFAULT;
            filter.PowerScoreFilter = GlobalData.POWER_SCORE_FILTER_DEFAULT;
            filter.ClientVersionFilter = GlobalData.CLIENT_VERSION_FILTER_DEFAULT;
            filter.WeaponsFilter = GlobalData.WEAPONS_FILTER_DEFAULT;
            filter.MovementFilter = GlobalData.MOVEMENT_FILTER_DEFAULT;
            filter.ModuleFilter = GlobalData.MODULE_FILTER_DEFAULT;
            filter.CabinFilter = GlobalData.CABIN_FILTER_DEFAULT;
            filter.StartDate = DateTime.Now;
            filter.EndDate = DateTime.Now;
        }

        public static void PopulateFilters(FilterSelections filter, List<file_trace_managment.MatchRecord> matchs, Dictionary<string, file_trace_managment.BuildRecord> buildRecords,
                                  LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, translate.Translation>> translations)
        {
            foreach (file_trace_managment.MatchRecord match in matchs)
            {
                PopulateFiltersForMatch(filter, match, buildRecords, session, translations);
            }
        } 

        public static void PopulateFiltersForMatch(FilterSelections filter, file_trace_managment.MatchRecord match, Dictionary<string, file_trace_managment.BuildRecord> buildRecords,
                                  LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, translate.Translation>> translations)
        {
            if (!filter.GameModes.Contains(match.match_data.match_type_desc))
                filter.GameModes.Add((match.match_data.match_type_desc));

            if (!filter.GameModes.Contains("PvP") && match.match_data.match_classification == GlobalData.PVP_CLASSIFICATION)
                filter.GameModes.Add("PvP");

            if (!filter.GameModes.Contains("PvE") && match.match_data.match_classification == GlobalData.PVE_CLASSIFICATION)
                filter.GameModes.Add("PvE");

            if (!filter.GameModes.Contains("Brawl") && match.match_data.match_classification == GlobalData.BRAWL_CLASSIFICATION)
                filter.GameModes.Add("Brawl");

            if (match.match_data.match_classification == GlobalData.PVP_CLASSIFICATION && !filter.GameModes.Contains("PvP"))
                filter.GameModes.Add("PvP");

            if (match.match_data.match_classification == GlobalData.PVE_CLASSIFICATION && !filter.GameModes.Contains("PvE"))
                filter.GameModes.Add("PvE");

            if (match.match_data.match_classification == GlobalData.BRAWL_CLASSIFICATION && !filter.GameModes.Contains("Brawl"))
                filter.GameModes.Add("Brawl");

            if (match.match_data.local_player.party_id == 0 && !filter.Grouped.Contains("Solo"))
                filter.Grouped.Add("Solo");

            if (match.match_data.local_player.party_id > 0 && !filter.Grouped.Contains("Grouped"))
                filter.Grouped.Add("Grouped");

            if (match.match_data.local_player.power_score >= 0 && match.match_data.local_player.power_score <= 2499 && !filter.PowerScores.Contains("0-2499"))
                filter.PowerScores.Add("0-2499");

            if (match.match_data.local_player.power_score >= 2500 && match.match_data.local_player.power_score <= 2499 && !filter.PowerScores.Contains("2500-3499"))
                filter.PowerScores.Add("2500-3499");

            if (match.match_data.local_player.power_score >= 3500 && match.match_data.local_player.power_score <= 4499 && !filter.PowerScores.Contains("3500-4499"))
                filter.PowerScores.Add("3500-4499");

            if (match.match_data.local_player.power_score >= 4500 && match.match_data.local_player.power_score <= 5499 && !filter.PowerScores.Contains("4500-5499"))
                filter.PowerScores.Add("4500-5499");

            if (match.match_data.local_player.power_score >= 5500 && match.match_data.local_player.power_score <= 6499 && !filter.PowerScores.Contains("5500-6499"))
                filter.PowerScores.Add("5500-6499");

            if (match.match_data.local_player.power_score >= 6500 && match.match_data.local_player.power_score <= 7499 && !filter.PowerScores.Contains("6500-7499"))
                filter.PowerScores.Add("6500-7499");

            if (match.match_data.local_player.power_score >= 7500 && match.match_data.local_player.power_score <= 8499 && !filter.PowerScores.Contains("7500-8499"))
                filter.PowerScores.Add("7500-8499");

            if (match.match_data.local_player.power_score >= 8500 && match.match_data.local_player.power_score <= 9499 && !filter.PowerScores.Contains("8500-9499"))
                filter.PowerScores.Add("8500-9499");

            if (match.match_data.local_player.power_score >= 9500 && match.match_data.local_player.power_score <= 12999 && !filter.PowerScores.Contains("9500-12999"))
                filter.PowerScores.Add("9500-12999");

            if (match.match_data.local_player.power_score >= 13000 && match.match_data.local_player.power_score <= 22000 && !filter.PowerScores.Contains("13000+"))
                filter.PowerScores.Add("13000+");

            if (match.match_data.local_player.power_score >= 22000 && !filter.PowerScores.Contains("Leviathan"))
                filter.PowerScores.Add("Leviathan");

            if (!filter.ClientVersions.Contains(match.match_data.client_version))
                filter.ClientVersions.Add((match.match_data.client_version));

            if (buildRecords.ContainsKey(match.match_data.local_player.build_hash))
            {
                if (!string.IsNullOrEmpty(translate.translate_string(buildRecords[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                    if (!filter.Cabins.Contains(translate.translate_string(buildRecords[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                        filter.Cabins.Add(translate.translate_string(buildRecords[match.match_data.local_player.build_hash].cabin.name, session, translations));

                foreach (part_loader.Weapon weapon in buildRecords[match.match_data.local_player.build_hash].weapons)
                    if (!filter.Weapons.Contains(translate.translate_string(weapon.name, session, translations)))
                        filter.Weapons.Add(translate.translate_string(weapon.name, session, translations));

                foreach (part_loader.Movement movement in buildRecords[match.match_data.local_player.build_hash].movement)
                    if (!filter.MovementParts.Contains(translate.translate_string(movement.name, session, translations)))
                        filter.MovementParts.Add(translate.translate_string(movement.name, session, translations));

                foreach (part_loader.Module module in buildRecords[match.match_data.local_player.build_hash].modules)
                    if (!filter.ModuleParts.Contains(translate.translate_string(module.name, session, translations)))
                        filter.ModuleParts.Add(translate.translate_string(module.name, session, translations));
            }
        }

        public static bool CheckFilters(FilterSelections filter, file_trace_managment.MatchRecord match, Dictionary<string, file_trace_managment.BuildRecord> buildRecords,
                                  LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, translate.Translation>> translations)
        {
            PopulateFiltersForMatch(filter, match, buildRecords, session, translations);

            if (filter.GameModeFilter != GlobalData.GAME_MODE_FILTER_DEFAULT && filter.GameModeFilter != "PvP" && filter.GameModeFilter != "PvE" && filter.GameModeFilter != "Brawl" && filter.GameModeFilter != match.match_data.match_type_desc)
                return false;

            if (filter.GameModeFilter == "PvP" && match.match_data.match_classification != GlobalData.PVP_CLASSIFICATION)
                return false;

            if (filter.GameModeFilter == "PvE" && match.match_data.match_classification != GlobalData.PVE_CLASSIFICATION)
                return false;

            if (filter.GameModeFilter == "Brawl" && match.match_data.match_classification != GlobalData.BRAWL_CLASSIFICATION)
                return false;

            if (filter.GroupFilter == "Solo" && match.match_data.local_player.party_id > 0)
                return false;

            if (filter.GroupFilter == "Grouped" && match.match_data.local_player.party_id == 0)
                return false;

            if (filter.ClientVersionFilter != GlobalData.CLIENT_VERSION_FILTER_DEFAULT && filter.ClientVersionFilter != match.match_data.client_version)
                return false;

            if (filter.StartDate.Date != DateTime.Now.Date && match.match_data.match_start.Date < filter.StartDate)
                return false;

            if (filter.EndDate.Date != DateTime.Now.Date && match.match_data.match_start.Date > filter.EndDate)
                return false;

            if (filter.PowerScoreFilter != GlobalData.POWER_SCORE_FILTER_DEFAULT)
            {
                if (filter.PowerScoreFilter == "0-2499" && (match.match_data.local_player.power_score < 0 || match.match_data.local_player.power_score > 2499))
                    return false;

                if (filter.PowerScoreFilter == "2500-3499" && (match.match_data.local_player.power_score < 2500 || match.match_data.local_player.power_score > 3499))
                    return false;

                if (filter.PowerScoreFilter == "3500-4499" && (match.match_data.local_player.power_score < 3500 || match.match_data.local_player.power_score > 4499))
                    return false;

                if (filter.PowerScoreFilter == "4500-5499" && (match.match_data.local_player.power_score < 4500 || match.match_data.local_player.power_score > 5499))
                    return false;

                if (filter.PowerScoreFilter == "5500-6499" && (match.match_data.local_player.power_score < 5500 || match.match_data.local_player.power_score > 6499))
                    return false;

                if (filter.PowerScoreFilter == "6500-7499" && (match.match_data.local_player.power_score < 6500 || match.match_data.local_player.power_score > 7499))
                    return false;

                if (filter.PowerScoreFilter == "7500-8499" && (match.match_data.local_player.power_score < 7500 || match.match_data.local_player.power_score > 8499))
                    return false;

                if (filter.PowerScoreFilter == "8500-9499" && (match.match_data.local_player.power_score < 8500 || match.match_data.local_player.power_score > 9499))
                    return false;

                if (filter.PowerScoreFilter == "9500-12999" && (match.match_data.local_player.power_score < 9500 || match.match_data.local_player.power_score > 12999))
                    return false;

                if (filter.PowerScoreFilter == "13000+" && (match.match_data.local_player.power_score < 13000 || match.match_data.local_player.power_score > 22000))
                    return false;

                if (filter.PowerScoreFilter == "Leviathan" && match.match_data.local_player.power_score < 22000)
                    return false;
            }

            if (buildRecords.ContainsKey(match.match_data.local_player.build_hash))
            {
                if (filter.WeaponsFilter != GlobalData.WEAPONS_FILTER_DEFAULT && buildRecords[match.match_data.local_player.build_hash].weapons.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == filter.WeaponsFilter).Count() == 0)
                    return false;

                if (filter.MovementFilter != GlobalData.MOVEMENT_FILTER_DEFAULT && buildRecords[match.match_data.local_player.build_hash].movement.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == filter.MovementFilter).Count() == 0)
                    return false;

                if (filter.CabinFilter != GlobalData.CABIN_FILTER_DEFAULT && translate.translate_string(buildRecords[match.match_data.local_player.build_hash].cabin.name, session, translations) != filter.CabinFilter)
                    return false;

                if (filter.ModuleFilter != GlobalData.MODULE_FILTER_DEFAULT && buildRecords[match.match_data.local_player.build_hash].modules.Select(x => translate.translate_string(x.name, session, translations)).Where(x => x == filter.ModuleFilter).Count() == 0)
                    return false;
            }
            else
            {
                if (filter.WeaponsFilter != GlobalData.WEAPONS_FILTER_DEFAULT)
                    return false;

                if (filter.MovementFilter != GlobalData.MOVEMENT_FILTER_DEFAULT)
                    return false;

                if (filter.CabinFilter != GlobalData.CABIN_FILTER_DEFAULT)
                    return false;

                if (filter.ModuleFilter != GlobalData.MODULE_FILTER_DEFAULT)
                    return false;
            }

            return true;
        }

        public static void PopulateFilters(FilterSelections filter, ComboBox dbGameModes, ComboBox cbGrouped,
                                     ComboBox cbPowerScores, ComboBox cbVersions, ComboBox cbWeapons,
                                     ComboBox cbMovement, ComboBox cbCabins, ComboBox cbModules)
        {
            dbGameModes.Items.Clear();
            cbGrouped.Items.Clear();
            cbPowerScores.Items.Clear();
            cbVersions.Items.Clear();
            cbWeapons.Items.Clear();
            cbMovement.Items.Clear();
            cbCabins.Items.Clear();
            cbModules.Items.Clear();

            filter.GameModes = filter.GameModes.OrderBy(x => x != GlobalData.GAME_MODE_FILTER_DEFAULT).ThenBy(x => x != "PvP").ThenBy(x => x != "PvE").ThenBy(x => x != "Brawl").ThenBy(x => x).ToList();
            filter.PowerScores = filter.PowerScores.OrderBy(x => x != GlobalData.POWER_SCORE_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.ClientVersions = filter.ClientVersions.OrderBy(x => x != GlobalData.CLIENT_VERSION_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.Weapons = filter.Weapons.OrderBy(x => x != GlobalData.WEAPONS_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.MovementParts = filter.MovementParts.OrderBy(x => x != GlobalData.MOVEMENT_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.Cabins = filter.Cabins.OrderBy(x => x != GlobalData.CABIN_FILTER_DEFAULT).ThenBy(x => x).ToList();
            filter.ModuleParts = filter.ModuleParts.OrderBy(x => x != GlobalData.MODULE_FILTER_DEFAULT).ThenBy(x => x).ToList();

            if (filter.PowerScores.Contains("13000+"))
            {
                filter.PowerScores.Remove("13000+");
                filter.PowerScores.Add("13000+");
            }

            if (filter.PowerScores.Contains("Leviathian"))
            {
                filter.PowerScores.Remove("Leviathian");
                filter.PowerScores.Add("Leviathian");
            }

            foreach (string desc in filter.GameModes)
                dbGameModes.Items.Add(desc);

            foreach (string desc in filter.Grouped)
                cbGrouped.Items.Add(desc);

            foreach (string desc in filter.PowerScores)
                cbPowerScores.Items.Add(desc);

            foreach (string desc in filter.ClientVersions)
                cbVersions.Items.Add(desc);

            foreach (string desc in filter.Weapons)
                cbWeapons.Items.Add(desc);

            foreach (string desc in filter.MovementParts)
                cbMovement.Items.Add(desc);

            foreach (string desc in filter.Cabins)
                cbCabins.Items.Add(desc);

            foreach (string desc in filter.ModuleParts)
                cbModules.Items.Add(desc);

            dbGameModes.Text = filter.GameModeFilter;
            cbGrouped.Text = filter.GroupFilter;
            cbPowerScores.Text = filter.PowerScoreFilter;
            cbVersions.Text = filter.ClientVersionFilter;
            cbWeapons.Text = filter.WeaponsFilter;
            cbMovement.Text = filter.MovementFilter;
            cbCabins.Text = filter.CabinFilter;
            cbModules.Text = filter.ModuleFilter;
        }

        public static void ResetFilters(FilterSelections filter)
        {
            filter.GameModes = new List<string> { };
            filter.Grouped = new List<string> { };
            filter.PowerScores = new List<string> { };
            filter.ClientVersions = new List<string> { };
            filter.Weapons = new List<string> { };
            filter.MovementParts = new List<string> { };
            filter.Cabins = new List<string> { };
            filter.ModuleParts = new List<string> { };

            filter.GameModes.Add(GlobalData.GAME_MODE_FILTER_DEFAULT);
            filter.Grouped.Add(GlobalData.GROUP_FILTER_DEFAULT);
            filter.PowerScores.Add(GlobalData.POWER_SCORE_FILTER_DEFAULT);
            filter.ClientVersions.Add(GlobalData.CLIENT_VERSION_FILTER_DEFAULT);
            filter.Weapons.Add(GlobalData.WEAPONS_FILTER_DEFAULT);
            filter.MovementParts.Add(GlobalData.MOVEMENT_FILTER_DEFAULT);
            filter.Cabins.Add(GlobalData.CABIN_FILTER_DEFAULT);
            filter.ModuleParts.Add(GlobalData.MODULE_FILTER_DEFAULT);
        }
    }
}

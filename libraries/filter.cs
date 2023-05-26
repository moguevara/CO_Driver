using CO_Driver.Libraries;
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

        public static void PopulateFilters(FilterSelections filter, List<FileTraceManagment.MatchRecord> matchs, Dictionary<string, FileTraceManagment.BuildRecord> buildRecords,
                                  LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translations)

        {
            if (filter == null || matchs == null || buildRecords == null || session == null || translations == null)
                return;

            foreach (FileTraceManagment.MatchRecord match in matchs)
            {
                PopulateFiltersForMatch(filter, match, buildRecords, session, translations);
            }
        }

        public static void PopulateFiltersForMatch(FilterSelections filter, FileTraceManagment.MatchRecord match, Dictionary<string, FileTraceManagment.BuildRecord> buildRecords,
                                  LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translations)
        {
            if (filter == null || match == null || buildRecords == null || session == null || translations == null)
                return;

            Utilities.AddToListIfNotExists(filter.GameModes, match.MatchData.MatchTypeDesc);

            if (GlobalData.MatchClassifications.TryGetValue(match.MatchData.MatchClassification, out var classification))
            {
                Utilities.AddToListIfNotExists(filter.GameModes, classification);
            }


            if (match.MatchData.LocalPlayer.PartyID == 0 && !filter.Grouped.Contains("Solo"))
                filter.Grouped.Add("Solo");

            if (match.MatchData.LocalPlayer.PartyID > 0 && !filter.Grouped.Contains("Grouped"))
                filter.Grouped.Add("Grouped");

            var powerScore = match.MatchData.LocalPlayer.PowerScore;

            foreach (var (min, max, label) in GlobalData.PowerScoreRanges)
            {
                if (powerScore >= min && powerScore <= max)
                {
                    Utilities.AddToListIfNotExists(filter.PowerScores, label);
                    break;
                }
            }

            Utilities.AddToListIfNotExists(filter.ClientVersions, match.MatchData.ClientVersion);

            if (buildRecords.TryGetValue(match.MatchData.LocalPlayer.BuildHash, out var buildRecord))
            {
                Utilities.AddTranslatedStringIfNotExists(filter.Cabins, buildRecord.Cabin.Description, session, translations);

                foreach (var weapon in buildRecord.Weapons)
                {
                    Utilities.AddTranslatedStringIfNotExists(filter.Weapons, weapon.Description, session, translations);
                }

                foreach (var movement in buildRecord.Movement)
                {
                    Utilities.AddTranslatedStringIfNotExists(filter.MovementParts, movement.Description, session, translations);
                }

                foreach (var module in buildRecord.Modules)
                {
                    Utilities.AddTranslatedStringIfNotExists(filter.ModuleParts, module.Description, session, translations);
                }
            }
        }

        public static bool CheckFilters(FilterSelections filter, FileTraceManagment.MatchRecord match, Dictionary<string, FileTraceManagment.BuildRecord> buildRecords,
                                  LogFileManagment.SessionVariables session, Dictionary<string, Dictionary<string, Translate.Translation>> translations)
        {
            if (filter == null || match == null || buildRecords == null || session == null || translations == null)
                return false;

            PopulateFiltersForMatch(filter, match, buildRecords, session, translations);


            if (filter.GameModeFilter != GlobalData.GAME_MODE_FILTER_DEFAULT &&
                GlobalData.MatchClassifications.TryGetValue(match.MatchData.MatchClassification, out var gameModeClassification) &&
                gameModeClassification != filter.GameModeFilter &&
                filter.GameModeFilter != match.MatchData.MatchTypeDesc)
                return false;

            if (filter.GameModeFilter != GlobalData.GAME_MODE_FILTER_DEFAULT && filter.GameModeFilter != "PvP" && filter.GameModeFilter != "PvE" && filter.GameModeFilter != "Brawl" && filter.GameModeFilter != match.MatchData.MatchTypeDesc)
                return false;

            if (filter.GroupFilter == "Solo" && match.MatchData.LocalPlayer.PartyID > 0 ||
                filter.GroupFilter == "Grouped" && match.MatchData.LocalPlayer.PartyID == 0)
                return false;

            if (filter.ClientVersionFilter != GlobalData.CLIENT_VERSION_FILTER_DEFAULT &&
                filter.ClientVersionFilter != match.MatchData.ClientVersion)
                return false;

            if (filter.StartDate.Date != DateTime.Now.Date && match.MatchData.MatchStart.Date < filter.StartDate ||
                filter.EndDate.Date != DateTime.Now.Date && match.MatchData.MatchStart.Date > filter.EndDate)
                return false;

            if (filter.PowerScoreFilter != GlobalData.POWER_SCORE_FILTER_DEFAULT)
            {
                var powerScore = match.MatchData.LocalPlayer.PowerScore;
                if (!GlobalData.PowerScoreRanges.Any(range => range.label == filter.PowerScoreFilter &&
                                                   match.MatchData.LocalPlayer.PowerScore >= range.min && powerScore <= range.max))
                    return false;
            }

            if (buildRecords.ContainsKey(match.MatchData.LocalPlayer.BuildHash))
            {
                if (filter.WeaponsFilter != GlobalData.WEAPONS_FILTER_DEFAULT && buildRecords[match.MatchData.LocalPlayer.BuildHash].Weapons.Select(x => Translate.TranslateString(x.Name, session, translations)).Where(x => x == filter.WeaponsFilter).Count() == 0)
                    return false;

                if (filter.MovementFilter != GlobalData.MOVEMENT_FILTER_DEFAULT && buildRecords[match.MatchData.LocalPlayer.BuildHash].Movement.Select(x => Translate.TranslateString(x.Name, session, translations)).Where(x => x == filter.MovementFilter).Count() == 0)
                    return false;

                if (filter.CabinFilter != GlobalData.CABIN_FILTER_DEFAULT && Translate.TranslateString(buildRecords[match.MatchData.LocalPlayer.BuildHash].Cabin.Name, session, translations) != filter.CabinFilter)
                    return false;

                if (filter.ModuleFilter != GlobalData.MODULE_FILTER_DEFAULT && buildRecords[match.MatchData.LocalPlayer.BuildHash].Modules.Select(x => Translate.TranslateString(x.Name, session, translations)).Where(x => x == filter.ModuleFilter).Count() == 0)
                    return false;
            }
            else
            {
                if (filter.WeaponsFilter != GlobalData.WEAPONS_FILTER_DEFAULT ||
                    filter.MovementFilter != GlobalData.MOVEMENT_FILTER_DEFAULT ||
                    filter.CabinFilter != GlobalData.CABIN_FILTER_DEFAULT ||
                    filter.ModuleFilter != GlobalData.MODULE_FILTER_DEFAULT)
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

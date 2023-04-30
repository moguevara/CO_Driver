﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class UserProfile : UserControl
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

        public List<FileTraceManagment.MatchRecord> match_history = new List<FileTraceManagment.MatchRecord> { };
        public Dictionary<string, FileTraceManagment.BuildRecord> build_records = new Dictionary<string, FileTraceManagment.BuildRecord> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public bool force_refresh = false;
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
        private int highest_win_streak;
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
        private Filter.FilterSelections filter_selections = Filter.NewFilterSelection();
        private string new_selection = "";
        private string previous_selection = "";

        //translate.translate_string(map.Key,session, translations);
        //ui_translate.translate(ctrl.Text, session, ui_translations);

        public UserProfile()
        {
            InitializeComponent();
        }

        public void populate_user_profile_screen()
        {
            if (!force_refresh)
            {
                new_selection = Filter.FilterString(filter_selections);

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;

            previous_selection = new_selection;

            Filter.ResetFilters(filter_selections);
            initialize_user_profile();

            int current_win_streak = 0;

            foreach (FileTraceManagment.MatchRecord match in match_history.ToList())
            {
                if (!Filter.CheckFilters(filter_selections, match, build_records, session, translations))
                    continue;

                if (build_records.ContainsKey(match.MatchData.LocalPlayer.BuildHash))
                {
                    if (!string.IsNullOrEmpty(Translate.TranslateString(build_records[match.MatchData.LocalPlayer.BuildHash].Cabin.Name, session, translations)))
                    {
                        if (!cabin_usage.ContainsKey(Translate.TranslateString(build_records[match.MatchData.LocalPlayer.BuildHash].Cabin.Name, session, translations)))
                            cabin_usage.Add(Translate.TranslateString(build_records[match.MatchData.LocalPlayer.BuildHash].Cabin.Name, session, translations), 1);
                        else
                            cabin_usage[Translate.TranslateString(build_records[match.MatchData.LocalPlayer.BuildHash].Cabin.Name, session, translations)] += 1;
                    }

                    foreach (PartLoader.Weapon weapon in build_records[match.MatchData.LocalPlayer.BuildHash].Weapons)
                    {
                        if (!weapon_usage.ContainsKey(Translate.TranslateString(weapon.Name, session, translations)))
                            weapon_usage.Add(Translate.TranslateString(weapon.Name, session, translations), 1);
                        else
                            weapon_usage[Translate.TranslateString(weapon.Name, session, translations)] += 1;
                    }

                    foreach (PartLoader.Movement movement in build_records[match.MatchData.LocalPlayer.BuildHash].Movement)
                    {
                        if (!movement_usage.ContainsKey(Translate.TranslateString(movement.Name, session, translations)))
                            movement_usage.Add(Translate.TranslateString(movement.Name, session, translations), 1);
                        else
                            movement_usage[Translate.TranslateString(movement.Name, session, translations)] += 1;
                    }

                    foreach (PartLoader.Module module in build_records[match.MatchData.LocalPlayer.BuildHash].Modules)
                    {
                        if (!module_usage.ContainsKey(Translate.TranslateString(module.Name, session, translations)))
                            module_usage.Add(Translate.TranslateString(module.Name, session, translations), 1);
                        else
                            module_usage[Translate.TranslateString(module.Name, session, translations)] += 1;
                    }
                }

                games_played++;
                if (match.MatchData.GameResult == "Win")
                    wins++;

                total_rounds += match.MatchData.LocalPlayer.Stats.Rounds;
                total_kills += match.MatchData.LocalPlayer.Stats.Kills;
                total_deaths += match.MatchData.LocalPlayer.Stats.Deaths;
                total_assists += match.MatchData.LocalPlayer.Stats.Assists;
                total_drone_kills += match.MatchData.LocalPlayer.Stats.DroneKills;
                total_damage += match.MatchData.LocalPlayer.Stats.Damage;
                total_damage_rec += match.MatchData.LocalPlayer.Stats.DamageTaken;
                total_score += match.MatchData.LocalPlayer.Stats.Score;
                total_medals += match.MatchData.LocalPlayer.Stripes.Count();

                foreach (KeyValuePair<int, FileTraceManagment.Player> player in match.MatchData.PlayerRecords)
                {
                    if (player.Value.Bot == 1)
                    {
                        global_total_bot_count += 1;
                        global_total_bot_score += player.Value.Stats.Score;
                    }
                    else if (player.Key != match.MatchData.LocalPlayer.UID)
                    {
                        global_total_player_count += 1;
                        global_total_score += player.Value.Stats.Score;
                    }
                }

                if (match.MatchData.LocalPlayer.Team == match.MatchData.WinningTeam)
                    current_win_streak += 1;
                else
                    current_win_streak = 0;

                if (current_win_streak > highest_win_streak)
                    highest_win_streak = current_win_streak;

                if (match.MatchData.LocalPlayer.Stats.Score > max_score)
                    max_score = match.MatchData.LocalPlayer.Stats.Score;

                if (match.MatchData.LocalPlayer.Stats.Damage > max_damage_dealt)
                    max_damage_dealt = match.MatchData.LocalPlayer.Stats.Damage;

                if (match.MatchData.LocalPlayer.Stats.DamageTaken > max_damage_rec)
                    max_damage_rec = match.MatchData.LocalPlayer.Stats.DamageTaken;

                if (match.MatchData.LocalPlayer.Stats.Kills == max_kills.max_kills)
                    max_kills.count += 1;

                if (match.MatchData.LocalPlayer.Stats.Kills > max_kills.max_kills)
                {
                    max_kills.max_kills = match.MatchData.LocalPlayer.Stats.Kills;
                    max_kills.count = 1;
                }

                if (match.MatchData.Nemesis != "")
                {
                    if (!opponent_dict.ContainsKey(match.MatchData.Nemesis))
                        opponent_dict.Add(match.MatchData.Nemesis, new Opponent { nickname = match.MatchData.Nemesis, been_killed = 1, killed = 0 });
                    else
                        opponent_dict[match.MatchData.Nemesis].been_killed += 1;
                }

                foreach (string victim in match.MatchData.Victims)
                {
                    if (!opponent_dict.ContainsKey(victim))
                        opponent_dict.Add(victim, new Opponent { nickname = victim, been_killed = 0, killed = 1 });
                    else
                        opponent_dict[victim].killed += 1;
                }

                foreach (string stripe in match.MatchData.LocalPlayer.Stripes)
                    if (stripe == "PvpMvpWin")
                        total_mvp++;

                if (!total_map_data.ContainsKey(match.MatchData.MapDesc))
                {
                    total_map_data.Add(match.MatchData.MapDesc, new MapData { map_name = match.MatchData.MapDesc, wins = match.MatchData.GameResult == "Win" ? 1 : 0, games = 1 });
                }
                else
                {
                    total_map_data[match.MatchData.MapDesc].games = total_map_data[match.MatchData.MapDesc].games + 1;
                    if (match.MatchData.GameResult == "Win")
                        total_map_data[match.MatchData.MapDesc].wins = total_map_data[match.MatchData.MapDesc].wins + 1;
                }

                foreach (KeyValuePair<string, int> match_reward in match.MatchData.MatchRewards)
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
            Filter.PopulateFilters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }

        private void populate_user_profile_screen_elements()
        {
            double avg_player_score = total_rounds > 0 ? Math.Round((((double)total_score) / (double)games_played)) : double.PositiveInfinity;

            lb_user_name.Text = session.LocalUserName;
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
            lb_avg_kills.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_kills) / (double)total_rounds), 1) : double.PositiveInfinity);
            lb_avg_assists.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_assists) / (double)total_rounds), 1) : double.PositiveInfinity);
            lb_avg_dmg.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_damage) / (double)total_rounds)) : double.PositiveInfinity);
            lb_avg_dmg_rec.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_damage_rec) / (double)total_rounds)) : double.PositiveInfinity);
            lb_player_index.Text = player_index.ToString();
            lb_bot_index.Text = bot_index.ToString();
            lb_max_damage.Text = Math.Round(max_damage_dealt, 1).ToString();
            lb_max_damage_rec.Text = Math.Round(max_damage_rec, 1).ToString();
            lb_highest_score.Text = max_score.ToString();
            lb_win_streak.Text = highest_win_streak.ToString();

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
                if (resource.Key.ToLower().Contains("xp") || resource.Key.ToLower().Contains("score") || resource.Key.ToLower().Equals("glory"))
                    continue;

                DataGridViewRow row = (DataGridViewRow)dg_resources.Rows[0].Clone();
                row.Cells[0].Value = Translate.TranslateString(resource.Key, session, translations);
                row.Cells[1].Value = (int)resource.Value;
                dg_resources.Rows.Add(row);
            }

            dg_resources.AllowUserToAddRows = false;
            dg_resources.ClearSelection();

            dg_map_data.Rows.Clear();
            dg_map_data.AllowUserToAddRows = true;
            dg_map_data.Columns[1].DefaultCellStyle.Format = "P1";

            bool first = true;

            foreach (KeyValuePair<string, MapData> map in total_map_data
                .OrderBy(x => (double)x.Value.games / (double)games_played < 0.005)
                .ThenByDescending(x => (double)x.Value.wins / (double)x.Value.games)
                .ThenByDescending(x => x.Value.wins))
            {
                if (first)
                {
                    lb_best_map.Text = Translate.TranslateString(map.Key, session, translations);
                    first = false;
                }
                DataGridViewRow row = (DataGridViewRow)this.dg_map_data.Rows[0].Clone();
                row.Cells[0].Value = Translate.TranslateString(map.Key, session, translations);
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
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_map_data_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_victims_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_nemesis_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void initialize_user_profile()
        {
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
            movement_usage = new Dictionary<string, int> { };
            cabin_usage = new Dictionary<string, int> { };
            weapon_usage = new Dictionary<string, int> { };
            module_usage = new Dictionary<string, int> { };
            max_score = 0;
            highest_win_streak = 0;
            max_damage_rec = 0.0;
            max_damage_dealt = 0.0;
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
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void lb_max_kills_Click(object sender, EventArgs e)
        {

        }

        private void cb_game_modes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.GameModeFilter = this.cb_game_modes.Text;
            populate_user_profile_screen();
        }

        private void btn_save_user_settings_Click_1(object sender, EventArgs e)
        {
            Filter.ResetFilterSelections(filter_selections);

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_user_profile_screen();
        }

        private void cb_movement_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.MovementFilter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.MovementFilter = this.cb_movement.Text;

            populate_user_profile_screen();
        }

        private void cb_modules_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.ModuleFilter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.ModuleFilter = this.cb_modules.Text;

            populate_user_profile_screen();
        }

        private void cb_weapons_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.WeaponsFilter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.WeaponsFilter = this.cb_weapons.Text;

            populate_user_profile_screen();
        }

        private void cb_cabins_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.CabinFilter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.CabinFilter = this.cb_cabins.Text;

            populate_user_profile_screen();
        }

        private void dt_end_date_ValueChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.EndDate == dt_end_date.Value)
                return;

            if (dt_start_date.Value > dt_end_date.Value)
                dt_start_date.Value = dt_end_date.Value;

            filter_selections.EndDate = dt_end_date.Value;

            populate_user_profile_screen();
        }

        private void dt_start_date_ValueChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.StartDate == dt_start_date.Value)
                return;

            if (dt_end_date.Value < dt_start_date.Value)
                dt_end_date.Value = dt_start_date.Value;

            filter_selections.StartDate = dt_start_date.Value;

            populate_user_profile_screen();
        }

        private void cb_versions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.ClientVersionFilter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.ClientVersionFilter = this.cb_versions.Text;

            populate_user_profile_screen();
        }

        private void cb_power_score_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.PowerScoreFilter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.PowerScoreFilter = this.cb_power_score.Text;

            populate_user_profile_screen();
        }

        private void cb_grouped_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.GroupFilter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.GroupFilter = this.cb_grouped.Text;

            populate_user_profile_screen();
        }

        private void dg_nemesis_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string player = dg_nemesis_list.Rows[e.RowIndex].Cells[0].Value.ToString();
            int uid = match_history.FirstOrDefault(x => x.MatchData.PlayerRecords.Any(y => y.Value.Nickname == player && y.Key > 0)).MatchData.PlayerRecords.FirstOrDefault(z => z.Value.Nickname == player).Value.UID;

            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + uid.ToString());
        }

        private void dg_victim_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string player = dg_victim_list.Rows[e.RowIndex].Cells[0].Value.ToString();
            int uid = match_history.FirstOrDefault(x => x.MatchData.PlayerRecords.Any(y => y.Value.Nickname == player && y.Key > 0)).MatchData.PlayerRecords.FirstOrDefault(z => z.Value.Nickname == player).Value.UID;

            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + uid.ToString());
        }

        private void lb_user_name_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + session.LocalUserID);
        }

        private void user_profile_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}

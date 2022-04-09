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
        public Resize resize = new Resize { };
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
        private filter.FilterSelections filter_selections = filter.new_filter_selection();
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
                new_selection = filter.filter_string(filter_selections);

                if (new_selection == previous_selection)
                    return;
            }

            force_refresh = false;

            previous_selection = new_selection;

            filter.reset_filters(filter_selections);
            initialize_user_profile();

            int current_win_streak = 0;

            foreach (file_trace_managment.MatchRecord match in match_history.ToList())
            {
                if (!filter.check_filters(filter_selections, match, build_records, session, translations))
                    continue;

                if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                {
                    if (!string.IsNullOrEmpty(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                    {
                        if (!cabin_usage.ContainsKey(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)))
                            cabin_usage.Add(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations), 1);
                        else
                            cabin_usage[translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations)] += 1;
                    }

                    foreach (part_loader.Weapon weapon in build_records[match.match_data.local_player.build_hash].weapons)
                    {
                        if (!weapon_usage.ContainsKey(translate.translate_string(weapon.name, session, translations)))
                            weapon_usage.Add(translate.translate_string(weapon.name, session, translations), 1);
                        else
                            weapon_usage[translate.translate_string(weapon.name, session, translations)] += 1;
                    }

                    foreach (part_loader.Movement movement in build_records[match.match_data.local_player.build_hash].movement)
                    {
                        if (!movement_usage.ContainsKey(translate.translate_string(movement.name, session, translations)))
                            movement_usage.Add(translate.translate_string(movement.name, session, translations), 1);
                        else
                            movement_usage[translate.translate_string(movement.name, session, translations)] += 1;
                    }

                    foreach (part_loader.Module module in build_records[match.match_data.local_player.build_hash].modules)
                    {
                        if (!module_usage.ContainsKey(translate.translate_string(module.name, session, translations)))
                            module_usage.Add(translate.translate_string(module.name, session, translations), 1);
                        else
                            module_usage[translate.translate_string(module.name, session, translations)] += 1;
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

                if (match.match_data.local_player.team == match.match_data.winning_team)
                    current_win_streak += 1;
                else
                    current_win_streak = 0;

                if (current_win_streak > highest_win_streak)
                    highest_win_streak = current_win_streak;

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
            filter.populate_filters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
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
                if (resource.Key.ToLower().Contains("xp") || resource.Key.ToLower().Contains("score"))
                    continue;

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

            foreach (KeyValuePair<string, MapData> map in total_map_data
                .OrderBy(x => (double)x.Value.games / (double)games_played < 0.005)
                .ThenByDescending(x => (double)x.Value.wins / (double)x.Value.games)
                .ThenByDescending(x => x.Value.wins))
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
            resize.record_initial_sizes(this);
        }

        private void lb_max_kills_Click(object sender, EventArgs e)
        {

        }

        private void cb_game_modes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.game_mode_filter = this.cb_game_modes.Text;
            populate_user_profile_screen();
        }

        private void btn_save_user_settings_Click_1(object sender, EventArgs e)
        {
            filter.reset_filter_selections(filter_selections);

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_user_profile_screen();
        }

        private void cb_movement_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.movement_filter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.movement_filter = this.cb_movement.Text;

            populate_user_profile_screen();
        }

        private void cb_modules_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.module_filter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.module_filter = this.cb_modules.Text;

            populate_user_profile_screen();
        }

        private void cb_weapons_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.weapons_filter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.weapons_filter = this.cb_weapons.Text;

            populate_user_profile_screen();
        }

        private void cb_cabins_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.cabin_filter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.cabin_filter = this.cb_cabins.Text;

            populate_user_profile_screen();
        }

        private void dt_end_date_ValueChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.end_date == dt_end_date.Value)
                return;

            if (dt_start_date.Value > dt_end_date.Value)
                dt_start_date.Value = dt_end_date.Value;

            filter_selections.end_date = dt_end_date.Value;

            populate_user_profile_screen();
        }

        private void dt_start_date_ValueChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.start_date == dt_start_date.Value)
                return;

            if (dt_end_date.Value < dt_start_date.Value)
                dt_end_date.Value = dt_start_date.Value;

            filter_selections.start_date = dt_start_date.Value;

            populate_user_profile_screen();
        }

        private void cb_versions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.client_versions_filter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.client_versions_filter = this.cb_versions.Text;

            populate_user_profile_screen();
        }

        private void cb_power_score_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.power_score_filter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.power_score_filter = this.cb_power_score.Text;

            populate_user_profile_screen();
        }

        private void cb_grouped_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (filter_selections.group_filter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.group_filter = this.cb_grouped.Text;

            populate_user_profile_screen();
        }

        private void dg_nemesis_list_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string player = dg_nemesis_list.Rows[e.RowIndex].Cells[0].Value.ToString();
            int uid = match_history.FirstOrDefault(x => x.match_data.player_records.Any(y => y.Key == player)).match_data.player_records.FirstOrDefault(z => z.Key == player).Value.uid;

            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + uid.ToString());
        }

        private void dg_victim_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string player = dg_victim_list.Rows[e.RowIndex].Cells[0].Value.ToString();
            int uid = match_history.FirstOrDefault(x => x.match_data.player_records.Any(y => y.Key == player)).match_data.player_records.FirstOrDefault(z => z.Key == player).Value.uid;

            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + uid.ToString());
        }

        private void lb_user_name_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + session.local_user_uid);
        }

        private void user_profile_Resize(object sender, EventArgs e)
        {
            resize.resize(this);
        }
    }
}

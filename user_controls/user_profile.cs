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

        public file_trace_managment.MatchHistoryResponse match_history = new file_trace_managment.MatchHistoryResponse { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
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
        private double mvp_percent;
        private double player_index;
        private double bot_index;
        private Dictionary<string, int> total_resources;
        private Dictionary<string, MapData> total_map_data;

        public user_profile()
        {
            InitializeComponent();
        }

        public void populate_user_profile_screen()
        {
            initialize_user_profile();

            foreach (file_trace_managment.MatchRecord match in match_history.match_history)
            {
                games_played++;
                if (match.match_data.game_result == "Win")
                    wins++;

                total_rounds += match.local_player.stats.rounds;
                total_kills += match.local_player.stats.kills;
                total_deaths += match.local_player.stats.deaths;
                total_assists += match.local_player.stats.assists;
                total_drone_kills += match.local_player.stats.drone_kills;
                total_damage += match.local_player.stats.damage;
                total_damage_rec += match.local_player.stats.damage_taken;
                total_score += match.local_player.stats.score;

                if (!total_map_data.ContainsKey(match.match_data.map_name))
                {
                    total_map_data.Add(match.match_data.map_name, new MapData { map_name = match.match_data.map_name, wins = match.match_data.game_result == "Win" ? 1 : 0, games = 1 });
                }
                else
                {
                    total_map_data[match.match_data.map_name].games = total_map_data[match.match_data.map_name].games + 1;
                    if (match.match_data.game_result == "Win")
                        total_map_data[match.match_data.map_name].wins = total_map_data[match.match_data.map_name].wins + 1;
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
        }

        private void populate_user_profile_screen_elements()
        {
            this.lb_games_played.Text = games_played.ToString();
            this.lb_wins.Text = wins.ToString();
            this.lb_win_rate.Text = string.Format(@"{0}%", games_played > 0 ? Math.Round((((double)wins / (double)games_played) * 100), 2) : double.PositiveInfinity);
            this.lb_total_kills.Text = total_kills.ToString();
            this.lb_total_deaths.Text = total_deaths.ToString();
            this.lb_total_assists.Text = total_assists.ToString();
            this.lb_total_drone_kills.Text = total_drone_kills.ToString();
            this.lb_total_kill_deaths.Text = string.Format(@"{0}", total_deaths > 0 ? Math.Round(((double)total_kills / (double)total_deaths), 1) : double.PositiveInfinity);
            this.lb_total_kill_assist_death.Text = string.Format(@"{0}", total_deaths > 0 ? Math.Round((((double)total_kills + (double)total_assists) / (double)total_deaths), 1) : double.PositiveInfinity);
            this.lb_total_medals.Text = total_medals.ToString();
            this.lb_total_mvp.Text = total_mvp.ToString();
            this.lb_mvp_percent.Text = string.Format(@"{0}%", total_rounds > 0 ? Math.Round(((((double)total_mvp) / (double)total_rounds) * 100), 2) : double.PositiveInfinity);
            this.lb_avg_score.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_score) / (double)total_rounds)) : double.PositiveInfinity);
            this.lb_avg_kills.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_kills) / (double)total_rounds),1) : double.PositiveInfinity);
            this.lb_avg_assists.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_assists) / (double)total_rounds),1) : double.PositiveInfinity);
            this.lb_avg_dmg.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_damage) / (double)total_rounds)) : double.PositiveInfinity);
            this.lb_avg_dmg_rec.Text = string.Format(@"{0}", total_rounds > 0 ? Math.Round((((double)total_damage_rec) / (double)total_rounds)) : double.PositiveInfinity);
            this.lb_player_index.Text = player_index.ToString();
            this.lb_bot_index.Text = bot_index.ToString();
        }

        private void gb_resources_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, Color.Lime, Color.Lime);
        }

        private void gb_map_data_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, Color.Lime, Color.Lime);
        }

        private void gb_victims_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, Color.Lime, Color.Lime);
        }

        private void gb_nemesis_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, Color.Lime, Color.Lime);
        }

        private void initialize_user_profile()
        {
            games_played = 0;
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
            mvp_percent = 0.0;
            player_index = 0.0;
            bot_index = 0.0;
            total_resources = new Dictionary<string, int> { };
            total_map_data = new Dictionary<string, MapData> { };
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
    }
}

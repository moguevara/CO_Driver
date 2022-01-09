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
    public partial class previous_match : UserControl
    {
        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public event EventHandler<file_trace_managment.MatchRecord> load_selected_match;

        public file_trace_managment.MatchData previous_match_data = new file_trace_managment.MatchData { };
        public file_trace_managment.MatchData historical_match_data = new file_trace_managment.MatchData { };
        public file_trace_managment.BuildRecord last_build_record = new file_trace_managment.BuildRecord { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public bool show_last_match = true;
        private file_trace_managment.MatchData match_data = new file_trace_managment.MatchData { };
        private string blue_team = "";
        private string red_team = "";
        private List<string> solo_queue_names = new List<string> { "A worthy collection of players.", 
                                                                   "The elite of solo queue.", 
                                                                   "Crossout's finest.",
                                                                   "Crossout's best and brightest.",
                                                                   "Worthy opponents"};
        public previous_match()
        {
            InitializeComponent();
        }
        public void populate_match()
        {
            if (show_last_match)
                match_data = previous_match_data;
            else
                match_data = historical_match_data;

            reset_screen_elements();
            assign_teams();
            TimeSpan duration = match_data.match_end - match_data.match_start;

            //MessageBox.Show(match_data.game_play_value + Environment.NewLine + match_data.map_name + Environment.NewLine + Environment.NewLine +  string.Join(",", match_data.match_attributes.Select(x => x.attribute)));

            if (match_data.game_result == "Win")
                lb_game_result.Text = "Victory";
            else if (match_data.game_result == "Loss")
                lb_game_result.Text = "Defeat";
            else 
                lb_game_result.Text = match_data.game_result;

            lb_match_type.Text = match_data.match_type_desc;
            lb_map_name.Text = translate.translate_string(match_data.map_name, session, translations);
            if (build_records.ContainsKey(match_data.local_player.build_hash))
                lb_build_name.Text = build_records[match_data.local_player.build_hash].full_description;
            else
                lb_build_name.Text = "";
            lb_duration.Text = string.Format(@"{0}m {1}s", duration.Minutes, duration.Seconds);
            lb_kills.Text = match_data.local_player.stats.kills.ToString();
            lb_assists.Text = match_data.local_player.stats.assists.ToString();
            lb_drone_kills.Text = match_data.local_player.stats.drone_kills.ToString();
            lb_damage_dealt.Text = Math.Round(match_data.local_player.stats.damage,1).ToString();
            lb_damage_rec.Text = Math.Round(match_data.local_player.stats.damage_taken,1).ToString();
            lb_score.Text = match_data.local_player.stats.score.ToString();
            lb_medals.Text = match_data.local_player.stripes.Count().ToString();
            if (match_data.match_rewards.ContainsKey("expFactionTotal")) {
                lb_xp.Text = match_data.match_rewards["expFactionTotal"].ToString();
                lb_resources.Text = string.Join(",", match_data.match_rewards.Where(x => x.Key.ToLower().Contains("xp") == false && x.Key != "score").Select(x => translate.translate_string(x.Key, session, translations) + ":" + x.Value.ToString()));
            }
            else
            {
                lb_xp.Text = "";
                lb_resources.Text = "";
            }
            
            lb_blue_team.Text = blue_team;
            lb_red_team.Text = red_team;

            populate_medals_table();
            populate_score_table();
            populate_teams_tables();
            populate_damage_dealt();
            populate_damage_rec();
        }

        private void reset_screen_elements()
        {
            lb_game_result.Text = "";
            lb_match_type.Text = "";
            lb_map_name.Text = "";
            lb_build_name.Text = "";
            lb_duration.Text = "";
            lb_kills.Text = "";
            lb_assists.Text = "";
            lb_drone_kills.Text = "";
            lb_damage_dealt.Text = "";
            lb_damage_rec.Text = "";
            lb_score.Text = "";
            lb_medals.Text = "";
            lb_xp.Text = "";
            lb_resources.Text = "";
            lb_blue_team.Text = "";
            lb_red_team.Text = "";
            dg_damage_rec.Rows.Clear();
            dg_damage_dealt.Rows.Clear();
            dg_medals.Rows.Clear();
            dg_score.Rows.Clear();
            dg_blue_team.Rows.Clear();
            dg_red_team.Rows.Clear();
            
        }

        private void populate_damage_rec()
        {
            dg_damage_rec.AllowUserToAddRows = false;
            dg_damage_rec.ClearSelection();
            dg_damage_rec.Rows.Clear();
            dg_damage_rec.AllowUserToAddRows = true;
            string previous_attacker = "";
            bool first = true;

            foreach (file_trace_managment.DamageRecord damage_record in match_data.damage_record.OrderBy(x => x.attacker).ThenByDescending(x => x.damage).ToList())
            {
                if (damage_record.victim != match_data.local_player.nickname)
                    continue;

                DataGridViewRow row;

                if (damage_record.attacker != previous_attacker)
                {
                    if (!first)
                    {
                        row = (DataGridViewRow)this.dg_damage_rec.Rows[0].Clone();
                        row.Cells[0].Value = null;
                        row.Cells[1].Value = null;
                        dg_damage_rec.Rows.Add(row);
                    }

                    row = (DataGridViewRow)this.dg_damage_rec.Rows[0].Clone();
                    row.Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                    row.Cells[0].Value = damage_record.attacker;
                    row.Cells[1].Value = Math.Round(match_data.damage_record.Where(x => x.victim == damage_record.victim && x.attacker == damage_record.attacker).Sum(x => x.damage), 1);
                    dg_damage_rec.Rows.Add(row);
                }

                row = (DataGridViewRow)this.dg_damage_rec.Rows[0].Clone();
                row.Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                row.Cells[0].Value = translate.translate_string(damage_record.weapon, session, translations);
                row.Cells[1].Value = Math.Round(damage_record.damage, 1);
                dg_damage_rec.Rows.Add(row);

                previous_attacker = damage_record.attacker;
                if (first)
                    first = false;
            }

            dg_damage_rec.AllowUserToAddRows = false;
            dg_damage_rec.ClearSelection();
        }

        private void populate_damage_dealt()
        {
            dg_damage_dealt.AllowUserToAddRows = false;
            dg_damage_dealt.ClearSelection();
            dg_damage_dealt.Rows.Clear();
            dg_damage_dealt.AllowUserToAddRows = true;
            string previous_victim = "";
            bool first = true;

            foreach (file_trace_managment.DamageRecord damage_record in match_data.damage_record.OrderBy(x=>x.victim).ThenByDescending(x=>x.damage).ToList())
            {
                if (damage_record.attacker != match_data.local_player.nickname)
                    continue;

                if (damage_record.victim == match_data.local_player.nickname)
                    continue;

                DataGridViewRow row;

                if (damage_record.victim != previous_victim)
                {
                    if (!first)
                    {
                        row = (DataGridViewRow)this.dg_damage_dealt.Rows[0].Clone();
                        row.Cells[0].Value = null;
                        row.Cells[1].Value = null;
                        dg_damage_dealt.Rows.Add(row);
                    }

                    row = (DataGridViewRow)this.dg_damage_dealt.Rows[0].Clone();
                    row.Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                    row.Cells[0].Value = damage_record.victim;
                    row.Cells[1].Value = Math.Round(match_data.damage_record.Where(x=>x.attacker == match_data.local_player.nickname && x.victim == damage_record.victim).Sum(x=>x.damage), 1);
                    dg_damage_dealt.Rows.Add(row);
                }

                row = (DataGridViewRow)this.dg_damage_dealt.Rows[0].Clone();
                row.Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                row.Cells[0].Value = translate.translate_string(damage_record.weapon, session, translations);
                row.Cells[1].Value = Math.Round(damage_record.damage, 1);
                dg_damage_dealt.Rows.Add(row);

                previous_victim = damage_record.victim;
                if (first)
                    first = false;
            }

            dg_damage_dealt.AllowUserToAddRows = false;
            dg_damage_dealt.ClearSelection();
        }

        private void populate_medals_table()
        {
            dg_medals.AllowUserToAddRows = false;
            dg_medals.ClearSelection();
            dg_medals.Rows.Clear();
            dg_medals.AllowUserToAddRows = true;

            Dictionary<string, int> stripes = new Dictionary<string, int> { };
            foreach (string stripe in match_data.local_player.stripes.OrderBy(x => x))
            {
                string strip_name = stripe;
                if (strip_name.ToLower().StartsWith("pv"))
                    strip_name = strip_name.Substring(3);

                if (stripes.ContainsKey(strip_name))
                    stripes[strip_name] += 1;
                else
                    stripes.Add(strip_name, 1);
            }

            foreach (KeyValuePair<string, int> stripe in stripes)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_medals.Rows[0].Clone();
                row.Cells[0].Value = stripe.Key;
                row.Cells[1].Value = stripe.Value;
                dg_medals.Rows.Add(row);
            }

            dg_medals.AllowUserToAddRows = false;
            dg_medals.ClearSelection();
            dg_medals.BringToFront();
        }

        private void populate_score_table()
        {
            if (match_data.local_player.scores == null)
                return;

            dg_score.AllowUserToAddRows = false;
            dg_score.ClearSelection();
            dg_score.Rows.Clear();
            dg_score.AllowUserToAddRows = true;

            foreach (file_trace_managment.Score score in match_data.local_player.scores)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_score.Rows[0].Clone();
                row.Cells[0].Value = score.description;
                row.Cells[1].Value = score.points;
                dg_score.Rows.Add(row);
            }

            dg_score.AllowUserToAddRows = false;
            dg_score.ClearSelection();
        }

        private void populate_teams_tables()
        {
            dg_blue_team.AllowUserToAddRows = false;
            dg_red_team.AllowUserToAddRows = false;

            dg_blue_team.Rows.Clear();
            dg_blue_team.AllowUserToAddRows = true;

            dg_red_team.Rows.Clear();
            dg_red_team.AllowUserToAddRows = true;


            foreach (KeyValuePair<string, file_trace_managment.Player> player in match_data.player_records.ToList())
            {
                if (player.Value.team != match_data.local_player.team)
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_red_team.Rows[0].Clone();
                    row.Cells[0].Value = player.Key;
                    row.Cells[1].Value = player.Value.power_score;
                    row.Cells[2].Value = player.Value.stats.kills;
                    row.Cells[3].Value = player.Value.stats.assists;
                    row.Cells[4].Value = player.Value.stats.deaths;
                    row.Cells[5].Value = Math.Round(player.Value.stats.damage, 0);
                    row.Cells[6].Value = Math.Round(player.Value.stats.damage_taken, 0);
                    row.Cells[7].Value = player.Value.stats.score;
                    dg_red_team.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_blue_team.Rows[0].Clone();
                    row.Cells[0].Value = player.Key;
                    row.Cells[1].Value = player.Value.power_score;
                    row.Cells[2].Value = player.Value.stats.kills;
                    row.Cells[3].Value = player.Value.stats.assists;
                    row.Cells[4].Value = player.Value.stats.deaths;
                    row.Cells[5].Value = Math.Round(player.Value.stats.damage, 0);
                    row.Cells[6].Value = Math.Round(player.Value.stats.damage_taken, 0);
                    row.Cells[7].Value = player.Value.stats.score;
                    dg_blue_team.Rows.Add(row);
                }
            }

            dg_blue_team.AllowUserToAddRows = false;
            dg_red_team.AllowUserToAddRows = false;
            

            dg_red_team.Sort(dg_red_team.Columns[7], ListSortDirection.Descending);
            dg_blue_team.Sort(dg_blue_team.Columns[7], ListSortDirection.Descending);

            dg_blue_team.ClearSelection();
            dg_red_team.ClearSelection();
        }

        private void assign_teams()
        {
            blue_team = "";
            Random random_number = new Random();

            if (match_data.match_type == global_data.EASY_RAID_MATCH ||
                match_data.match_type == global_data.MED_RAID_MATCH ||
                match_data.match_type == global_data.HARD_RAID_MATCH ||
                match_data.match_type == global_data.ADVENTURE_MATCH ||
                match_data.match_type == global_data.PRESENT_HEIST_MATCH ||
                match_data.match_type == global_data.PATROL_MATCH)
                red_team = "A bunch of robots.";
            else
            if (match_data.match_type == global_data.BEDLAM_MATCH)
                red_team = "The elite of Bedlam.";
            else
                red_team = solo_queue_names[random_number.Next(solo_queue_names.Count())];

            Dictionary<int, List<string>> blue_teams = new Dictionary<int, List<string>> { };
            Dictionary<int, List<string>> red_teams = new Dictionary<int, List<string>> { };

            blue_teams.Add(match_data.local_player.party_id, new List<string> { match_data.local_player.nickname });

            foreach (KeyValuePair<string, file_trace_managment.Player> player in match_data.player_records.ToList())
            {
                if (player.Value.party_id == 0 || player.Value.nickname == match_data.local_player.nickname)
                    continue;

                if (player.Value.team != match_data.local_player.team)
                {
                    if (!red_teams.ContainsKey(player.Value.party_id))
                        red_teams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                    else
                        red_teams[player.Value.party_id].Add(player.Value.nickname);
                }
                else
                {
                    if (!blue_teams.ContainsKey(player.Value.party_id))
                        blue_teams.Add(player.Value.party_id, new List<string> { player.Value.nickname });
                    else
                        blue_teams[player.Value.party_id].Add(player.Value.nickname);
                }
            }

            foreach (KeyValuePair<int, List<string>> team in blue_teams)
                blue_team += string.Format("({0})", string.Join(",", team.Value));

            if (red_teams.Count > 0)
                red_team = "";

            foreach (KeyValuePair<int, List<string>> team in red_teams)
                red_team += string.Format("({0})", string.Join(",", team.Value));
        }

        private void gp_damage_recieved_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gb_red_team_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gb_damage_dealt_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
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

        private void gb_score_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gb_red_team_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gb_blue_team_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void gp_medals_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }

        private void load_next_match(object sender, EventArgs e)
        {
            file_trace_managment.MatchRecord next_match = match_history.Where(x => x.match_data.match_start > match_data.match_start).OrderBy(x => x.match_data.match_start).FirstOrDefault();

            if (next_match == null)
                return;

            load_selected_match(this, next_match);
        }

        private void load_previous_match(object sender, EventArgs e)
        {
            file_trace_managment.MatchRecord previous_match = match_history.Where(x => x.match_data.match_start < match_data.match_start).OrderByDescending(x => x.match_data.match_start).FirstOrDefault();

            if (previous_match == null)
                return;

            load_selected_match(this, previous_match);
        }

        private void gp_damage_recieved_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.fore_color, session.fore_color);
        }
    }
}

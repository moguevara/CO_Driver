using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class previous_match : UserControl
    {
        public List<FileTraceManagment.MatchRecord> match_history = new List<FileTraceManagment.MatchRecord> { };
        public event EventHandler<FileTraceManagment.MatchRecord> load_selected_match;
        public event EventHandler<string> load_selected_build;

        public FileTraceManagment.MatchData previous_match_data = new FileTraceManagment.MatchData { };
        public FileTraceManagment.MatchData historical_match_data = new FileTraceManagment.MatchData { };
        public FileTraceManagment.BuildRecord last_build_record = new FileTraceManagment.BuildRecord { };
        public Dictionary<string, FileTraceManagment.BuildRecord> build_records = new Dictionary<string, FileTraceManagment.BuildRecord> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public bool show_last_match = true;
        private FileTraceManagment.MatchData match_data = new FileTraceManagment.MatchData { };
        private string blue_team = "";
        private string red_team = "";

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
            TimeSpan duration = match_data.MatchEnd - match_data.MatchStart;

            //MessageBox.Show(match_data.game_play_value + Environment.NewLine + match_data.map_name + Environment.NewLine + Environment.NewLine +  string.Join(",", match_data.match_attributes.Select(x => x.attribute)));

            if (match_data.GameResult == "Win")
                lb_game_result.Text = "Victory";
            else if (match_data.GameResult == "Loss")
                lb_game_result.Text = "Defeat";
            else
                lb_game_result.Text = match_data.GameResult;

#if DEBUG
            lb_game_result.Text = match_data.ServerGUID.ToString();
#endif

            lb_match_type.Text = match_data.MatchTypeDesc;
            lb_map_name.Text = Translate.TranslateString(match_data.MapName, session, translations);
            if (build_records.ContainsKey(match_data.LocalPlayer.BuildHash))
                lb_build_name.Text = build_records[match_data.LocalPlayer.BuildHash].FullDescription;
            else
                lb_build_name.Text = "";
            lb_duration.Text = string.Format(@"{0}m {1}s", duration.Minutes, duration.Seconds);
            lb_kills.Text = match_data.LocalPlayer.Stats.Kills.ToString();
            lb_assists.Text = match_data.LocalPlayer.Stats.Assists.ToString();
            lb_drone_kills.Text = match_data.LocalPlayer.Stats.DroneKills.ToString();
            lb_damage_dealt.Text = Math.Round(match_data.LocalPlayer.Stats.Damage, 1).ToString();
            lb_damage_rec.Text = Math.Round(match_data.LocalPlayer.Stats.DamageTaken, 1).ToString();
            lb_score.Text = match_data.LocalPlayer.Stats.Score.ToString();
            lb_medals.Text = match_data.LocalPlayer.Stripes.Count().ToString();
            if (match_data.MatchRewards.ContainsKey("expFactionTotal"))
            {
                lb_xp.Text = match_data.MatchRewards["expFactionTotal"].ToString();
                lb_resources.Text = string.Join(",", match_data.MatchRewards.Where(x => x.Key.ToLower().Contains("xp") == false && x.Key != "score").Select(x => Translate.TranslateString(x.Key, session, translations) + ":" + x.Value.ToString()));
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

            foreach (FileTraceManagment.DamageRecord damage_record in match_data.DamageRecord.OrderBy(x => x.Attacker).ThenByDescending(x => x.Damage).ToList())
            {
                if (damage_record.Victim != match_data.LocalPlayer.Nickname)
                    continue;

                DataGridViewRow row;

                if (damage_record.Attacker != previous_attacker)
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
                    row.Cells[0].Value = damage_record.Attacker;
                    row.Cells[1].Value = Math.Round(match_data.DamageRecord.Where(x => x.Victim == damage_record.Victim && x.Attacker == damage_record.Attacker).Sum(x => x.Damage), 1);
                    dg_damage_rec.Rows.Add(row);
                }

                row = (DataGridViewRow)this.dg_damage_rec.Rows[0].Clone();
                row.Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                row.Cells[0].Value = Translate.TranslateString(damage_record.Weapon, session, translations);
                row.Cells[1].Value = Math.Round(damage_record.Damage, 1);
                dg_damage_rec.Rows.Add(row);

                previous_attacker = damage_record.Attacker;
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

            foreach (FileTraceManagment.DamageRecord damage_record in match_data.DamageRecord.OrderBy(x => x.Victim).ThenByDescending(x => x.Damage).ToList())
            {
                if (damage_record.Attacker != match_data.LocalPlayer.Nickname)
                    continue;

                if (damage_record.Victim == match_data.LocalPlayer.Nickname)
                    continue;

                DataGridViewRow row;

                if (damage_record.Victim != previous_victim)
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
                    row.Cells[0].Value = damage_record.Victim;
                    row.Cells[1].Value = Math.Round(match_data.DamageRecord.Where(x => x.Attacker == match_data.LocalPlayer.Nickname && x.Victim == damage_record.Victim).Sum(x => x.Damage), 1);
                    dg_damage_dealt.Rows.Add(row);
                }

                row = (DataGridViewRow)this.dg_damage_dealt.Rows[0].Clone();
                row.Cells[0].Style.Alignment = DataGridViewContentAlignment.BottomRight;
                row.Cells[0].Value = Translate.TranslateString(damage_record.Weapon, session, translations);
                row.Cells[1].Value = Math.Round(damage_record.Damage, 1);
                dg_damage_dealt.Rows.Add(row);

                previous_victim = damage_record.Victim;
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
            foreach (string stripe in match_data.LocalPlayer.Stripes.OrderBy(x => x))
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
            if (match_data.LocalPlayer.Scores == null)
                return;

            dg_score.AllowUserToAddRows = false;
            dg_score.ClearSelection();
            dg_score.Rows.Clear();
            dg_score.AllowUserToAddRows = true;

            foreach (FileTraceManagment.Score score in match_data.LocalPlayer.Scores)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_score.Rows[0].Clone();
                row.Cells[0].Value = score.Description;
                row.Cells[1].Value = score.Points;
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


            foreach (KeyValuePair<int, FileTraceManagment.Player> player in match_data.PlayerRecords.ToList())
            {
                if (player.Value.Team != match_data.LocalPlayer.Team)
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_red_team.Rows[0].Clone();
                    row.Cells[0].Value = player.Value.Nickname;
#if DEBUG
                    row.Cells[0].ToolTipText = player.Key.ToString();
#endif
                    row.Cells[1].Value = player.Value.PowerScore;
                    row.Cells[2].Value = player.Value.Stats.Kills;
                    row.Cells[3].Value = player.Value.Stats.Assists;
                    row.Cells[4].Value = player.Value.Stats.Deaths;
                    row.Cells[5].Value = Math.Round(player.Value.Stats.Damage, 0);
                    row.Cells[6].Value = Math.Round(player.Value.Stats.DamageTaken, 0);
                    row.Cells[7].Value = player.Value.Stats.Score;
                    dg_red_team.Rows.Add(row);
                }
                else
                {
                    DataGridViewRow row = (DataGridViewRow)this.dg_blue_team.Rows[0].Clone();
                    row.Cells[0].Value = player.Value.Nickname;
#if DEBUG
                    row.Cells[0].ToolTipText = player.Key.ToString();
#endif
                    row.Cells[1].Value = player.Value.PowerScore;
                    row.Cells[2].Value = player.Value.Stats.Kills;
                    row.Cells[3].Value = player.Value.Stats.Assists;
                    row.Cells[4].Value = player.Value.Stats.Deaths;
                    row.Cells[5].Value = Math.Round(player.Value.Stats.Damage, 0);
                    row.Cells[6].Value = Math.Round(player.Value.Stats.DamageTaken, 0);
                    row.Cells[7].Value = player.Value.Stats.Score;
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
            Overlay.AssignTeams(match_data, ref blue_team, ref red_team);
        }

        private void gp_damage_recieved_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_red_team_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_damage_dealt_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
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
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_red_team_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_blue_team_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gp_medals_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void load_next_match(object sender, EventArgs e)
        {

        }

        private void load_previous_match(object sender, EventArgs e)
        {

        }

        private void gp_damage_recieved_Paint_1(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void lookup_blue_player(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string player = dg_blue_team.Rows[e.RowIndex].Cells[0].Value.ToString();
            int uid = match_data.PlayerRecords.FirstOrDefault(x => x.Value.Nickname == player && (x.Key > 0 || x.Value.Bot != 0)).Value.UID;

            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + uid.ToString());
        }

        private void lookup_red_player(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string player = dg_red_team.Rows[e.RowIndex].Cells[0].Value.ToString();
            int uid = match_data.PlayerRecords.FirstOrDefault(x => x.Value.Nickname == player && (x.Key > 0 || x.Value.Bot != 0)).Value.UID;

            System.Diagnostics.Process.Start("https://beta.crossoutdb.com/profile/" + uid.ToString());
        }

        public void btn_last_MouseClick(object sender, MouseEventArgs e)
        {
            FileTraceManagment.MatchRecord previous_match = match_history.Where(x => x.MatchData.MatchStart < match_data.MatchStart).OrderBy(x => x.MatchData.MatchStart).FirstOrDefault();

            if (previous_match == null)
                return;

            load_selected_match(this, previous_match);
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            FileTraceManagment.MatchRecord previous_match = match_history.Where(x => x.MatchData.MatchStart < match_data.MatchStart).OrderByDescending(x => x.MatchData.MatchStart).FirstOrDefault();

            if (previous_match == null)
                return;

            load_selected_match(this, previous_match);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            FileTraceManagment.MatchRecord next_match = match_history.Where(x => x.MatchData.MatchStart > match_data.MatchStart).OrderBy(x => x.MatchData.MatchStart).FirstOrDefault();

            if (next_match == null)
                return;

            load_selected_match(this, next_match);
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            FileTraceManagment.MatchRecord next_match = match_history.Where(x => x.MatchData.MatchStart > match_data.MatchStart).OrderByDescending(x => x.MatchData.MatchStart).FirstOrDefault();

            if (next_match == null)
                return;

            load_selected_match(this, next_match);
        }

        private void previous_match_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        private void previous_match_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }

        private void lb_build_name_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(match_data.LocalPlayer.BuildHash))
            {
                load_selected_build(sender, match_data.LocalPlayer.BuildHash);
            }
        }
    }
}

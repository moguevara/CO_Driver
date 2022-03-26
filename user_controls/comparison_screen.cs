using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CO_Driver
{
    public partial class comparison_screen : UserControl
    {
        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public log_file_managment.session_variables session = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public bool force_refresh = false;
        private filter.FilterSelections filter_selections = filter.new_filter_selection();
        private string new_selection = "";
        private string previous_selection = "";
        private grouping_category current_x_axis = null;
        private metric_category current_y_axis = null;
        private int current_result_limit = 0;
        private int current_min_sample_size = 0;
        private string mode = "Total";
        private List<chart_element> chart_series = new List<chart_element> { };
        private Series current_series = new Series { };

        private List<string> result_limit_groups = new List<string> { "All", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"};
        private List<string> min_sample_size_groups = new List<string> { "0", "5", "10", "15", "20", "25", "50", "75", "100", "150", "200", "250", "300"};

        private enum grouping 
        {
            DAY,
            WEEK,
            MONTH,
            YEAR,
            WEAPON,
            MOVEMENT,
            CABIN,
            MODULE,
            WEAPON_CAT,
            MOVEMENT_CAT,
            CABIN_CAT,
            MODULE_CAT,
            MAP,
            GAME_MODE,
            GAME_MODE_CAT,
            GAME_RESULT,
            POWER_SCORE,
            REGION,
            SERVER,
            GROUP_SIZE
        }

        private enum metric
        {
            WIN_RATE,
            MVP,
            DAMAGE,
            DAMAGE_REC,
            SCORE,
            KILLS,
            ASSISTS,
            DEATHS,
            KILL_ASSIST,
            DRONE_KILLS,
            MEDALS
        }

        private List<grouping_category> x_axis_groups = new List<grouping_category> { new grouping_category { id = (int)grouping.DAY, name = "Day", min = 0, max = int.MaxValue, max_display = 7 },
                                                                                      new grouping_category { id = (int)grouping.WEEK, name = "Week", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { id = (int)grouping.MONTH, name = "Month", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { id = (int)grouping.YEAR, name = "Year", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { id = (int)grouping.WEAPON, name = "Weapon", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.MOVEMENT, name = "Movement", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.CABIN, name = "Cabin", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.MODULE, name = "Module", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.WEAPON_CAT, name = "Weapon Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.MOVEMENT_CAT, name = "Movement Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.CABIN_CAT, name = "Cabin Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.MODULE_CAT, name = "Module Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.MAP, name = "Map", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.GAME_MODE, name = "Game Mode", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.GAME_MODE_CAT, name = "Game Mode Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { id = (int)grouping.GAME_RESULT, name = "Game Result", min = 0, max = int.MaxValue, max_display = 3 },
                                                                                      new grouping_category { id = (int)grouping.POWER_SCORE, name = "Power Score", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { id = (int)grouping.REGION, name = "Region", min = 0, max = int.MaxValue, max_display = 7 },
                                                                                      new grouping_category { id = (int)grouping.SERVER, name = "Server", min = 0, max = int.MaxValue, max_display = 7 },
                                                                                      new grouping_category { id = (int)grouping.GROUP_SIZE, name = "Group Size", min = 0, max = int.MaxValue, max_display = 14 }
                                                                                    };

        private List<metric_category> y_axis_groups = new List<metric_category> { new metric_category { id = (int)metric.WIN_RATE, name = "Win Rate", supports_min_max = false },
                                                                                  new metric_category { id = (int)metric.MVP, name = "MVP Rate", supports_min_max = false },
                                                                                  new metric_category { id = (int)metric.DAMAGE, name = "Damage", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.DAMAGE_REC, name = "Damage Recieved", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.SCORE, name = "Score", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.KILLS, name = "Kills", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.ASSISTS, name = "Assists", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.DEATHS, name = "Deaths", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.KILL_ASSIST, name = "(K+A)", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.DRONE_KILLS, name = "Drone Kills", supports_min_max = true },
                                                                                  new metric_category { id = (int)metric.MEDALS, name = "Medals", supports_min_max = true }
                                                                                 };
        private class grouping_category
        {
            public int id { get; set; }
            public string name { get; set; }
            public int min { get; set; }
            public int max { get; set; }
            public int max_display { get; set; }
        }

        private class metric_category
        {
            public int id { get; set; }
            public string name { get; set;}
            public bool supports_min_max { get; set; }
        }

        private class chart_element 
        { 
            public double x_value { get; set; }
            public string title { get; set; }
            public int total { get; set; }
            public int min { get; set; }
            public int max { get; set; }
            public int count { get; set; }
        }


        public comparison_screen()
        {
            InitializeComponent();
        }

        private void comparison_screen_Load(object sender, EventArgs e)
        {
            
        }

        public void initialize_comparison_screen()
        {
            reset_comparision_dropdowns();
            initialize_comparison_chart();
        }

        public void reset_comparision_dropdowns()
        {
            cbXaxis.Items.Clear();
            cbYaxis.Items.Clear();
            cbReturnLimit.Items.Clear();
            cbMinSampleSize.Items.Clear();

            foreach (grouping_category group in x_axis_groups)
                cbXaxis.Items.Add(group.name);

            foreach (metric_category group in y_axis_groups)
                cbYaxis.Items.Add(group.name);

            foreach (string group in result_limit_groups)
                cbReturnLimit.Items.Add(group);

            foreach (string group in min_sample_size_groups)
                cbMinSampleSize.Items.Add(group);


            current_x_axis = x_axis_groups.FirstOrDefault();
            current_y_axis = y_axis_groups.FirstOrDefault();
            current_result_limit = 0;
            current_min_sample_size = 0;

            cbXaxis.Text = current_x_axis.name;
            cbYaxis.Text = current_y_axis.name;
            cbReturnLimit.Text = "All";
            cbMinSampleSize.Text = "15";
        }

        public void initialize_comparison_chart()
        {
            ch_comparison.BackColor = session.back_color;
            ch_comparison.ForeColor = session.fore_color;
            ch_comparison.Legends[0].BackColor = session.back_color;
            ch_comparison.Legends[0].ForeColor = session.fore_color;
            //ch_comparison.ChartAreas[0].BackColor = session.back_color;
            //ch_comparison.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            //ch_comparison.ChartAreas[0].AxisX.Title = "Time (S)";
            //ch_comparison.ChartAreas[0].AxisX.Minimum = 0;
            //ch_comparison.ChartAreas[0].AxisX.TitleForeColor = session.fore_color;
            //ch_comparison.ChartAreas[0].AxisX.LineColor = session.fore_color;
            //ch_comparison.ChartAreas[0].AxisX.MajorGrid.LineColor = session.back_color;
            //ch_comparison.ChartAreas[0].AxisX.LabelStyle.ForeColor = session.fore_color;
            //ch_comparison.ChartAreas[0].AxisX.RoundAxisValues();
            //ch_comparison.ChartAreas[0].AxisX.IsMarginVisible = false;
            //ch_comparison.ChartAreas[0].AxisY.Title = "Damage";
            //ch_comparison.ChartAreas[0].AxisY.TitleForeColor = session.fore_color;
            //ch_comparison.ChartAreas[0].AxisY.LineColor = session.fore_color;
            //ch_comparison.ChartAreas[0].AxisY.MajorGrid.LineColor = session.back_color;
            //ch_comparison.ChartAreas[0].AxisY.LabelStyle.ForeColor = session.fore_color;
            //ch_comparison.ChartAreas[0].AxisY.IsMarginVisible = false;
            ch_comparison.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            ch_comparison.ChartAreas[0].CursorX.IsUserEnabled = true;
            ch_comparison.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //ch_comparison.Palette = ChartColorPalette.BrightPastel;
        }

        public void populate_comparison_chart()
        {
            reset_comparison_data();

            foreach (file_trace_managment.MatchRecord match in match_history.OrderByDescending(x => x.match_data.match_start))
            {
                process_match(match);
            }

            //MessageBox.Show(string.Format(@"Found {0} items within limits {1},{2} looking at {3} matches", chart_series.Count.ToString(), current_min_sample_size, current_result_limit, match_history.Count));

            
            ch_comparison.Series.Add(current_series);

            foreach (chart_element element in chart_series.OrderByDescending(x => x.count))
            {
                //if (current_series.Points.Count > current_min_sample_size)
                //    continue;

                //if (element.count < current_min_sample_size)
                //    continue;

                int y_value;

                if (mode == "Total")
                    y_value = element.total;
                else
                if (mode == "Max")
                    y_value = element.max;
                else
                if (mode == "Min")
                    y_value = element.min;
                else
                if (mode == "Avg")
                    y_value = (int)(((double)element.total / (double)element.count) + 0.5);
                else
                    break;


                DataPoint data = new DataPoint(element.x_value, y_value);
                //data.Label = element.title;
                data.LegendText = element.title;
                data.AxisLabel = element.title;
                data.LabelBackColor = session.back_color;
                data.LabelForeColor = session.fore_color;
                //data.LabelAngle = 45;
                data.ToolTip = string.Format(@"{0}:{1}", element.title, y_value);
                current_series.Points.Add(data);

                //TextAnnotation TA1 = new TextAnnotation();
                //TA1.Text = element.title;
                //TA1.SetAnchor(data);
                //ch_comparison.Annotations.Add(TA1);
            }
        }

        private void process_match(file_trace_managment.MatchRecord match)
        {
            int value = 0;
            switch (current_y_axis.id)
            {
                case (int)metric.WIN_RATE:
                    value = match.match_data.winning_team == match.match_data.local_player.team ? 1 : 0;
                    break;
                case (int)metric.MVP:
                    value = match.match_data.local_player.stripes.Any(x => x == "PvpMvpWin") ? 1 : 0;
                    break;
                case (int)metric.DAMAGE:
                    value = Convert.ToInt32(match.match_data.player_records[match.match_data.local_player.nickname].stats.damage);
                    break;
                case (int)metric.DAMAGE_REC:
                    value = Convert.ToInt32(match.match_data.local_player.stats.damage_taken);
                    break;
                case (int)metric.SCORE:
                    value = match.match_data.local_player.stats.score;
                    break;
                case (int)metric.KILLS:
                    value = match.match_data.local_player.stats.kills;
                    break;
                case (int)metric.ASSISTS:
                    value = match.match_data.local_player.stats.assists;
                    break;
                case (int)metric.DEATHS:
                    value = match.match_data.local_player.stats.deaths;
                    break;
                case (int)metric.KILL_ASSIST:
                    value = match.match_data.local_player.stats.kills + match.match_data.local_player.stats.assists;
                    break;
                case (int)metric.DRONE_KILLS:
                    value = match.match_data.local_player.stats.drone_kills;
                    break;
                case (int)metric.MEDALS:
                    value = match.match_data.local_player.stripes.Count();
                    break;
                default:
                    MessageBox.Show("Unable to find metric");
                    return;
            }

            switch (current_x_axis.id)
            {
                case (int)grouping.DAY:
                    add_chart_element(match.match_data.match_start.Date.ToString(), value);
                    break;
                case (int)grouping.WEEK:
                    add_chart_element(match.match_data.match_start.Date.AddDays(-1 * ((int)match.match_data.match_start.Date.DayOfWeek - (int)DayOfWeek.Monday)).Date.ToString(), value);
                    break;
                case (int)grouping.MONTH:
                    add_chart_element(match.match_data.match_start.Date.AddDays(-1 * (int)match.match_data.match_start.Date.Day).Date.ToString(), value);
                    break;
                case (int)grouping.WEAPON:
                    if (current_y_axis.id == (int)metric.DAMAGE)
                    {
                        foreach (file_trace_managment.DamageRecord rec in match.match_data.damage_record.Where(x => x.attacker == match.match_data.local_player.nickname))
                            add_chart_element(translate.translate_string(rec.weapon, session, translations), (int)rec.damage);
                    }
                    else
                    {
                        if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                            foreach (part_loader.Weapon part in build_records[match.match_data.local_player.build_hash].weapons)
                                add_chart_element(translate.translate_string(part.name, session, translations), value);
                    }
                    break;
                case (int)grouping.MOVEMENT:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        foreach (part_loader.Movement part in build_records[match.match_data.local_player.build_hash].movement)
                            add_chart_element(part.name, value);
                    break;
                case (int)grouping.CABIN:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        if (build_records[match.match_data.local_player.build_hash].cabin != null)
                            add_chart_element(build_records[match.match_data.local_player.build_hash].cabin.name, value);
                    break;
                case (int)grouping.MODULE:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        foreach (part_loader.Module part in build_records[match.match_data.local_player.build_hash].modules)
                            add_chart_element(part.name, value);
                    break;
                case (int)grouping.WEAPON_CAT:
                    break;
                case (int)grouping.MOVEMENT_CAT:
                    break;
                case (int)grouping.CABIN_CAT:
                    break;
                case (int)grouping.MODULE_CAT:
                    break;
                case (int)grouping.MAP:
                    add_chart_element(match.match_data.map_name, value);
                    break;
                case (int)grouping.GAME_MODE:
                    add_chart_element(match.match_data.gameplay_desc, value);
                    break;
                case (int)grouping.GAME_MODE_CAT:
                    break;
                case (int)grouping.GAME_RESULT:
                    add_chart_element(match.match_data.game_result, value);
                    break;
                case (int)grouping.POWER_SCORE:
                    add_chart_element(find_power_score_range(match.match_data.local_player.power_score), value);
                    break;
                case (int)grouping.REGION:
                    add_chart_element(match.match_data.host_name.Substring(3), value);
                    break;
                case (int)grouping.SERVER:
                    add_chart_element(match.match_data.host_name, value);
                    break;
                case (int)grouping.GROUP_SIZE:
                    add_chart_element(match.match_data.player_records.Count(x => x.Value.party_id == match.match_data.local_player.party_id).ToString(), value);
                    break;
                default:
                    MessageBox.Show("Unable to find group");
                    return;
            }
        }

        private void add_chart_element(string group, int value)
        {
            if (!chart_series.Any(x => x.title == group))
            {
                chart_series.Add(new chart_element { x_value = chart_series.Count, title = group, total = value, min = value, max = value, count = 1 });
            }
            else
            {
                chart_element element = chart_series.FirstOrDefault(x => x.title == group);
                element.total += value;

                if (element.min < value)
                    element.min = value;

                if (element.max > value)
                    element.max = value;

                element.count += 1;
            }
        }

        public string find_power_score_range(int power_score)
        {
            if (power_score < 2500)
                return "0-2499";
            if (power_score < 3500)
                return "2500-3499";
            if (power_score < 4500)
                return "3500-4499";
            if (power_score < 5500)
                return "4500-5499";
            if (power_score < 6500)
                return "5500-6499";
            if (power_score < 7500)
                return "6500-7499";
            if (power_score < 8500)
                return "7500-8499";
            if (power_score < 9500)
                return "8500-9499";
            if (power_score < 13000)
                return "9500-12999";
            return "13000+";
        }

        public void reset_comparison_data()
        {
            chart_series = new List<chart_element> { };

            ch_comparison.ChartAreas[0].AxisX.Title = current_x_axis.name;
            ch_comparison.ChartAreas[0].AxisY.Title = current_y_axis.name;

            current_series = new Series { };
            current_series.ChartType = SeriesChartType.Column;
            current_series.Palette = ChartColorPalette.BrightPastel;

            ch_comparison.Series.Clear();
        }

        private void cbYaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_y_axis = y_axis_groups.FirstOrDefault(x => x.name == cbYaxis.SelectedItem.ToString());

            if (current_y_axis.supports_min_max)
            {
                btnMaximum.Enabled = true;
                btnMinimum.Enabled = true;
                btnAverage.Enabled = true;
            }
            else
            {
                btnMaximum.Enabled = false;
                btnMinimum.Enabled = false;
                btnAverage.Enabled = false;
            }

            populate_comparison_chart();
        }

        private void cbXaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_x_axis = x_axis_groups.FirstOrDefault(x => x.name == cbXaxis.SelectedItem.ToString());
            populate_comparison_chart();
        }

        private void cbReturnLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReturnLimit.SelectedItem.ToString() == "All")
                current_result_limit = 0;
            else
                current_result_limit = Convert.ToInt32(cbReturnLimit.SelectedItem.ToString());

            populate_comparison_chart();
        }

        private void cbMinSampleSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_min_sample_size = Convert.ToInt32(cbMinSampleSize.SelectedItem.ToString());
            populate_comparison_chart();
        }

        private void reset_button_text()
        {
            //btnTotal.Font =   new Font(btnTotal.Font,   FontStyle.Regular);
            //btnMinimum.Font = new Font(btnMinimum.Font, FontStyle.Regular);
            //btnMaximum.Font = new Font(btnMaximum.Font, FontStyle.Regular);
            //btnAverage.Font = new Font(btnAverage.Font, FontStyle.Regular);

        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            mode = "Total";
            reset_button_text();
            btnTotal.Font = new Font(btnTotal.Font, FontStyle.Bold);
            populate_comparison_chart();
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            mode = "Min";
            reset_button_text();
            btnMinimum.Font = new Font(btnMinimum.Font, FontStyle.Bold);
            populate_comparison_chart();
        }

        private void btnMaximum_Click(object sender, EventArgs e)
        {
            mode = "Max";
            reset_button_text();
            btnMaximum.Font = new Font(btnMaximum.Font, FontStyle.Bold);
            populate_comparison_chart();
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            mode = "Avg";
            reset_button_text();
            btnAverage.Font = new Font(btnAverage.Font, FontStyle.Bold);
            populate_comparison_chart();
        }
    }
}

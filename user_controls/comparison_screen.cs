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
        private List<chart_element> chart_series = new List<chart_element> { };

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
                                                                                      new grouping_category { id = (int)grouping.MOVEMENT, name = "Movement Part", min = 0, max = int.MaxValue, max_display = 14 },
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
            public string group { get; set; }
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
            ch_comparison.ChartAreas[0].BackColor = session.back_color;
            ch_comparison.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ch_comparison.ChartAreas[0].AxisX.Title = "Time (S)";
            ch_comparison.ChartAreas[0].AxisX.Minimum = 0;
            ch_comparison.ChartAreas[0].AxisX.TitleForeColor = session.fore_color;
            ch_comparison.ChartAreas[0].AxisX.LineColor = session.fore_color;
            ch_comparison.ChartAreas[0].AxisX.MajorGrid.LineColor = session.back_color;
            ch_comparison.ChartAreas[0].AxisX.LabelStyle.ForeColor = session.fore_color;
            ch_comparison.ChartAreas[0].AxisX.RoundAxisValues();
            ch_comparison.ChartAreas[0].AxisX.IsMarginVisible = false;
            ch_comparison.ChartAreas[0].AxisY.Title = "Damage";
            ch_comparison.ChartAreas[0].AxisY.TitleForeColor = session.fore_color;
            ch_comparison.ChartAreas[0].AxisY.LineColor = session.fore_color;
            ch_comparison.ChartAreas[0].AxisY.MajorGrid.LineColor = session.back_color;
            ch_comparison.ChartAreas[0].AxisY.LabelStyle.ForeColor = session.fore_color;
            ch_comparison.ChartAreas[0].AxisY.IsMarginVisible = false;
            ch_comparison.Palette = ChartColorPalette.BrightPastel;

            foreach (Series series in ch_comparison.Series)
                series.Points.Clear();

            ch_comparison.Series.Clear();
        }

        public void populate_comparison_chart()
        {
            reset_comparison_data();

            foreach (file_trace_managment.MatchRecord match in match_history)
            {
                
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
                    value = Convert.ToInt32(match.match_data.local_player.stats.damage);
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
                    return;
            }

            switch (current_x_axis.id)
            {
                case (int)grouping.DAY:
                    break;
                case (int)grouping.WEEK:
                    break;
                case (int)grouping.MONTH:
                    break;
                case (int)grouping.WEAPON:
                    if (current_y_axis.id == (int)metric.DAMAGE)
                    {
                        foreach (file_trace_managment.DamageRecord rec in match.match_data.damage_record.Where(x => x.attacker == match.match_data.local_player.nickname))
                            add_chart_element(rec.weapon, (int)rec.damage);
                    }
                    else
                    {
                        if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                            foreach (part_loader.Weapon part in build_records[match.match_data.local_player.build_hash].weapons)
                                add_chart_element(part.name, value);
                    }
                    break;
                case (int)grouping.MOVEMENT:
                    break;
                case (int)grouping.CABIN:
                    break;
                case (int)grouping.MODULE:
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
                    break;
                case (int)grouping.GAME_MODE:
                    break;
                case (int)grouping.GAME_MODE_CAT:
                    break;
                case (int)grouping.GAME_RESULT:
                    break;
                case (int)grouping.POWER_SCORE:
                    break;
                case (int)grouping.REGION:
                    break;
                case (int)grouping.SERVER:
                    break;
                case (int)grouping.GROUP_SIZE:
                    break;
                default:
                    return;
            }
        }

        private void add_chart_element(string group, int value)
        {
            if (chart_series.Any(x => x.group == group))
                chart_series.Add(new chart_element { group = group, total = value, min = value, max = value, count = 1 });
            else
            {
                chart_series.Where(x => x.group == group).Select(x => {
                                                                    x.total += value;
                                                                    if (x.min > value)
                                                                        x.min = value;
                                                                    if (x.max < value)
                                                                        x.max = value;
                                                                    x.count += 1;
                                                                    return x;                                                        
                                                                      });
            }
        }

        public void reset_comparison_data()
        {
            foreach (Series series in ch_comparison.Series)
                series.Points.Clear();

            ch_comparison.Series.Clear();
        }

        public void populate_comparision_graph()
        {

        }

        private void cbYaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_y_axis = y_axis_groups.FirstOrDefault(x => x.name == cbYaxis.SelectedItem.ToString());
        }

        private void cbXaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_x_axis = x_axis_groups.FirstOrDefault(x => x.name == cbXaxis.SelectedItem.ToString());
        }

        private void cbReturnLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbReturnLimit.SelectedItem.ToString() == "All")
                current_result_limit = 0;
            else
                current_result_limit = Convert.ToInt32(cbReturnLimit.SelectedItem.ToString());
        }

        private void cbMinSampleSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_min_sample_size = Convert.ToInt32(cbMinSampleSize.SelectedItem.ToString());
        }

    }
}

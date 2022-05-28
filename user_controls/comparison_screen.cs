using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CO_Driver
{
    public partial class comparison_screen : UserControl
    {
        public List<file_trace_managment.MatchRecord> match_history = new List<file_trace_managment.MatchRecord> { };
        public Dictionary<string, file_trace_managment.BuildRecord> build_records = new Dictionary<string, file_trace_managment.BuildRecord> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };
        public bool force_refresh = false;
        private Filter.FilterSelections filter_selections = Filter.NewFilterSelection();
        private string new_selection = "";
        private string previous_selection = "";
        private grouping_category current_x_axis = null;
        private metric_category current_y_axis = null;
        private int current_result_limit = 0;
        private int current_min_sample_size = 0;
        private string mode = "Total";
        private List<chart_element> chart_series = new List<chart_element> { };
        private Series current_series = new Series { };
        private chart_type current_chart_type = new chart_type { chart_name = "Column", series_type = SeriesChartType.Column };

        private List<string> min_sample_size_groups = new List<string> { "0", "5", "10", "15", "20", "25", "50", "75", "100", "150", "200", "250", "300" };

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
            ENGINE,
            PART,
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
            CLIENT_VERSION,
            GROUP_SIZE,
            SQUAD_MATE,
            OPPONENT,
            ALLY,
            BUILD_HASH,
            BUILD_DESC,
            BOT_ALLY,
            BOT_OPPONENT
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
            MEDALS,
            GAMES_PLAYED,
            ROUNDS_PLAYED,
            TIME_SPENT,
            RAM_DAMAGE,
            CABIN_DAMAGE,
            BODY_DAMAGE,
            EXPERIENCE,
            URANIUM,
            SCRAP,
            WIRES,
            BATTERIES,
            COPPER,
            COUPONS,
            ELECTRONICS,
            PLASTIC
        }

        private enum ordering
        {
            VALUE_DESC,
            TIME_DESC
        }

        private class chart_type
        {
            public string chart_name { get; set; }
            public SeriesChartType series_type { get; set; }
        }



        private List<chart_type> chart_type_list = new List<chart_type> {
                new chart_type { series_type = SeriesChartType.Column, chart_name = "Column"},
                new chart_type { series_type = SeriesChartType.StepLine, chart_name = "Step Line"},
                new chart_type { series_type = SeriesChartType.Line, chart_name = "Line"},
                new chart_type { series_type = SeriesChartType.Point, chart_name = "Point"},
                new chart_type { series_type = SeriesChartType.Bar, chart_name = "Bar"},
                new chart_type { series_type = SeriesChartType.Spline, chart_name = "Spline"},
                new chart_type { series_type = SeriesChartType.Pie, chart_name = "Pie"},
                new chart_type { series_type = SeriesChartType.Doughnut, chart_name = "Doughnut"},
                new chart_type { series_type = SeriesChartType.Area, chart_name = "Area"},
                new chart_type { series_type = SeriesChartType.Bubble, chart_name = "Bubble"},
                new chart_type { series_type = SeriesChartType.Candlestick, chart_name = "Candlestick"},
                //new chart_type { series_type = SeriesChartType.Funnel, chart_name = "Funnel"},
                //new chart_type { series_type = SeriesChartType.Kagi, chart_name = "Kagi"},
                //new chart_type { series_type = SeriesChartType.Pyramid, chart_name = "Pyramid"},
                //new chart_type { series_type = SeriesChartType.Radar, chart_name = "Radar"},
                //new chart_type { series_type = SeriesChartType.StackedArea, chart_name = "Stacked Area"},
                new chart_type { series_type = SeriesChartType.Renko, chart_name = "Renko"},
                new chart_type { series_type = SeriesChartType.Radar, chart_name = "Radar"}
            };


        private List<grouping_category> x_axis_groups = new List<grouping_category> { new grouping_category { id = grouping.DAY, name = "Day", min = 0, max = int.MaxValue, max_display = 7, ordering = ordering.TIME_DESC },
                                                                                      new grouping_category { id = grouping.WEEK, name = "Week", min = 0, max = int.MaxValue, max_display = 12, ordering = ordering.TIME_DESC },
                                                                                      new grouping_category { id = grouping.MONTH, name = "Month", min = 0, max = int.MaxValue, max_display = 12, ordering = ordering.TIME_DESC },
                                                                                      new grouping_category { id = grouping.YEAR, name = "Year", min = 0, max = int.MaxValue, max_display = 12, ordering = ordering.TIME_DESC },
                                                                                      new grouping_category { id = grouping.WEAPON, name = "Weapon", min = 0, max = int.MaxValue, max_display = 14,ordering =  ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.MOVEMENT, name = "Movement", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.CABIN, name = "Cabin", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.MODULE, name = "Module", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.ENGINE, name = "Engine", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.PART, name = "Part", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.MAP, name = "Map", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.GAME_MODE, name = "Game Mode", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.GAME_MODE_CAT, name = "Game Mode Category", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.GAME_RESULT, name = "Game Result", min = 0, max = int.MaxValue, max_display = 3, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.POWER_SCORE, name = "Power Score", min = 0, max = int.MaxValue, max_display = 12, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.REGION, name = "Region", min = 0, max = int.MaxValue, max_display = 7, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.SERVER, name = "Server", min = 0, max = int.MaxValue, max_display = 7, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.CLIENT_VERSION, name = "Crossout Version", min = 0, max = int.MaxValue, max_display = 7, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.GROUP_SIZE, name = "Group Size", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.SQUAD_MATE, name = "Squadmate", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.OPPONENT, name = "Opponent", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.ALLY, name = "Ally", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.BUILD_HASH, name = "Build Hash", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.BUILD_DESC, name = "Build Description", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.BOT_ALLY, name = "Bot (Ally)", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC },
                                                                                      new grouping_category { id = grouping.BOT_OPPONENT, name = "Bot (Opponent)", min = 0, max = int.MaxValue, max_display = 14, ordering = ordering.VALUE_DESC }
                                                                                    };

        private List<metric_category> y_axis_groups = new List<metric_category> { new metric_category { id = metric.WIN_RATE, name = "Win Rate", supports_min_max = false },
                                                                                  new metric_category { id = metric.MVP, name = "MVP Rate", supports_min_max = false },
                                                                                  new metric_category { id = metric.DAMAGE, name = "Damage", supports_min_max = true },
                                                                                  new metric_category { id = metric.DAMAGE_REC, name = "Damage Recieved", supports_min_max = true },
                                                                                  new metric_category { id = metric.SCORE, name = "Score", supports_min_max = true },
                                                                                  new metric_category { id = metric.KILLS, name = "Kills", supports_min_max = true },
                                                                                  new metric_category { id = metric.ASSISTS, name = "Assists", supports_min_max = true },
                                                                                  new metric_category { id = metric.DEATHS, name = "Deaths", supports_min_max = true },
                                                                                  new metric_category { id = metric.KILL_ASSIST, name = "(K+A)", supports_min_max = true },
                                                                                  new metric_category { id = metric.DRONE_KILLS, name = "Drone Kills", supports_min_max = true },
                                                                                  new metric_category { id = metric.MEDALS, name = "Medals", supports_min_max = true },
                                                                                  new metric_category { id = metric.GAMES_PLAYED, name = "Games Played", supports_min_max = true },
                                                                                  new metric_category { id = metric.ROUNDS_PLAYED, name = "Rounds Played", supports_min_max = true },
                                                                                  new metric_category { id = metric.TIME_SPENT, name = "Time Spent", supports_min_max = true },
                                                                                  new metric_category { id = metric.RAM_DAMAGE, name = "Ram Damage", supports_min_max = true },
                                                                                  new metric_category { id = metric.CABIN_DAMAGE, name = "Cabin Damage", supports_min_max = true },
                                                                                  new metric_category { id = metric.BODY_DAMAGE, name = "Body Damage", supports_min_max = true },
                                                                                  new metric_category { id = metric.EXPERIENCE, name = "Experience", supports_min_max = true },
                                                                                  new metric_category { id = metric.URANIUM, name = "Uranium", supports_min_max = true },
                                                                                  new metric_category { id = metric.SCRAP, name = "Scrap", supports_min_max = true },
                                                                                  new metric_category { id = metric.WIRES, name = "Wires", supports_min_max = true },
                                                                                  new metric_category { id = metric.BATTERIES, name = "Batteries", supports_min_max = true },
                                                                                  new metric_category { id = metric.COPPER, name = "Copper", supports_min_max = true },
                                                                                  new metric_category { id = metric.COUPONS, name = "Coupons", supports_min_max = true },
                                                                                  new metric_category { id = metric.ELECTRONICS, name = "Electronics", supports_min_max = true },
                                                                                  new metric_category { id = metric.PLASTIC, name = "Plastic", supports_min_max = true }
                                                                                 };
        private class grouping_category
        {
            public grouping id { get; set; }
            public string name { get; set; }
            public int min { get; set; }
            public int max { get; set; }
            public int max_display { get; set; }
            public ordering ordering { get; set; }
        }

        private class metric_category
        {
            public metric id { get; set; }
            public string name { get; set; }
            public bool supports_min_max { get; set; }
        }

        private class chart_element
        {
            public double x_value { get; set; }
            public string title { get; set; }
            public double total { get; set; }
            public double min { get; set; }
            public double max { get; set; }
            public int count { get; set; }
        }


        public comparison_screen()
        {
            InitializeComponent();
        }

        private void comparison_screen_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.record_initial_sizes(this);
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
            cbMinSampleSize.Items.Clear();
            cbChartType.Items.Clear();

            foreach (grouping_category group in x_axis_groups)
                cbXaxis.Items.Add(group.name);

            foreach (metric_category group in y_axis_groups)
                cbYaxis.Items.Add(group.name);

            foreach (string group in min_sample_size_groups)
                cbMinSampleSize.Items.Add(group);

            foreach (chart_type chart in chart_type_list)
                cbChartType.Items.Add(chart.chart_name);

            current_x_axis = x_axis_groups.FirstOrDefault(x => x.id == grouping.WEAPON);
            current_y_axis = y_axis_groups.FirstOrDefault(x => x.id == metric.DAMAGE);
            current_result_limit = 0;
            current_min_sample_size = 15;

            cbXaxis.Text = current_x_axis.name;
            cbYaxis.Text = current_y_axis.name;
            cbMinSampleSize.Text = "15";
            cbChartType.Text = "Column";
            cb_min_max.Text = "Average";
        }

        public void initialize_comparison_chart()
        {
            ch_comparison.BackColor = session.BackColor;
            ch_comparison.ForeColor = session.ForeColor;
            ch_comparison.Legends[0].BackColor = session.BackColor;
            ch_comparison.Legends[0].ForeColor = session.ForeColor;
            ch_comparison.ChartAreas[0].BackColor = session.BackColor;
            ch_comparison.ChartAreas[0].AxisX.Minimum = 0;
            ch_comparison.ChartAreas[0].AxisX.TitleForeColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisX.LineColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisX.MinorTickMark.LineColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisX.MajorTickMark.LineColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisX.MajorGrid.LineColor = session.BackColor;
            ch_comparison.ChartAreas[0].AxisX.LabelStyle.ForeColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
            ch_comparison.ChartAreas[0].AxisX.Interval = 1;
            ch_comparison.ChartAreas[0].AxisX.RoundAxisValues();
            ch_comparison.ChartAreas[0].AxisX.IsMarginVisible = false;
            ch_comparison.ChartAreas[0].AxisY.TitleForeColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisY.LineColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisY.MajorGrid.LineColor = session.BackColor;
            ch_comparison.ChartAreas[0].AxisY.LabelStyle.ForeColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisY.MinorTickMark.LineColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisY.MajorTickMark.LineColor = session.ForeColor;
            ch_comparison.ChartAreas[0].AxisY.IsMarginVisible = false;
            ch_comparison.Legends[0].Enabled = false;
            ch_comparison.ChartAreas[0].CursorX.IsUserEnabled = true;
            ch_comparison.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
        }

        public void populate_comparison_chart()
        {
            if (match_history.Count <= 0)
                return;

            double y_axis_max = 0;

            //if (!force_refresh)
            //{
            //    new_selection = filter.filter_string(filter_selections);

            //    if (new_selection == previous_selection)
            //        return;
            //}

            force_refresh = false;
            previous_selection = new_selection;
            Filter.ResetFilters(filter_selections);

            reset_comparison_data();

            foreach (file_trace_managment.MatchRecord match in match_history.OrderByDescending(x => x.match_data.match_start))
            {
                if (!Filter.CheckFilters(filter_selections, match, build_records, session, translations))
                    continue;

                process_match(match);
            }

            if (current_x_axis.ordering == ordering.TIME_DESC)
                chart_series = chart_series.OrderByDescending(x => DateTime.Parse(x.title)).ToList();
            else
            if (current_x_axis.ordering == ordering.VALUE_DESC && mode == "Total")
                chart_series = chart_series.OrderByDescending(x => x.total).ToList();
            else
            if (current_x_axis.ordering == ordering.VALUE_DESC && mode == "Maximum")
                chart_series = chart_series.OrderByDescending(x => x.max).ToList();
            else
            if (current_x_axis.ordering == ordering.VALUE_DESC && mode == "Minimum")
                chart_series = chart_series.OrderBy(x => x.min).ToList();
            else
            if (current_x_axis.ordering == ordering.VALUE_DESC && mode == "Average")
                chart_series = chart_series.OrderByDescending(x => (double)x.total / (double)x.count).ToList();
            else
                return;

            int current_group_count = 0;
            foreach (chart_element element in chart_series.ToList())
            {
                if (element.count < current_min_sample_size)
                    chart_series.Remove(element);

                if (current_group_count > current_result_limit - 1 && current_result_limit != 0)
                {
                    if (!chart_series.Any(x => x.title == "Other"))
                    {
                        chart_series.Add(new chart_element { x_value = current_group_count, title = "Other", count = element.count, max = element.max, min = element.min, total = element.total });
                    }
                    else
                    {
                        chart_element other = chart_series.FirstOrDefault(x => x.title == "Other");
                        other.total += element.total;
                        other.count += element.count;

                        if (other.min < element.min)
                            other.min = element.min;

                        if (other.max > element.max)
                            other.max = element.max;
                    }
                    chart_series.Remove(element);
                }
                current_group_count += 1;
            }


            double x_value = 1;
            foreach (chart_element element in chart_series.OrderBy(x => x.title == "Other" ? 0 : 1))
            {
                double y_value;

                if (mode == "Total")
                    y_value = element.total;
                else
                if (mode == "Maximum")
                    y_value = element.max;
                else
                if (mode == "Minimum")
                    y_value = element.min;
                else
                if (mode == "Average")
                    y_value = (double)element.total / (double)element.count;
                else
                    break;

                if (y_value > y_axis_max)
                    y_axis_max = y_value;


                DataPoint data = new DataPoint(x_value, y_value);
                data.LegendText = element.title;
                data.AxisLabel = element.title;
                data.LabelBackColor = session.BackColor;
                data.LabelForeColor = session.ForeColor;
                data.ToolTip = string.Format(@"{0}: {1}", element.title, Math.Round(y_value, 1));
                current_series.Points.Add(data);
                x_value += 1;
            }

            ch_comparison.ChartAreas[0].AxisY.Maximum = y_axis_max * 1.05;
            Filter.PopulateFilters(filter_selections, cb_game_modes, cb_grouped, cb_power_score, cb_versions, cb_weapons, cb_movement, cb_cabins, cb_modules);
        }

        private void process_match(file_trace_managment.MatchRecord match)
        {
            double value = 0;
            switch (current_y_axis.id)
            {
                case metric.WIN_RATE:
                    value = match.match_data.winning_team == match.match_data.local_player.team ? 1 : 0;
                    break;
                case metric.MVP:
                    value = match.match_data.local_player.stripes.Any(x => x == "PvpMvpWin") ? 1 : 0;
                    break;
                case metric.DAMAGE:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.damage;
                    break;
                case metric.DAMAGE_REC:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.damage_taken;
                    break;
                case metric.SCORE:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.score;
                    break;
                case metric.KILLS:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.kills;
                    break;
                case metric.ASSISTS:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.assists;
                    break;
                case metric.DEATHS:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.deaths;
                    break;
                case metric.KILL_ASSIST:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.kills + match.match_data.player_records[match.match_data.local_player.uid].stats.assists;
                    break;
                case metric.DRONE_KILLS:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.drone_kills;
                    break;
                case metric.MEDALS:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stripes.Count();
                    break;
                case metric.GAMES_PLAYED:
                    value = 1;
                    break;
                case metric.ROUNDS_PLAYED:
                    value = match.match_data.round_count;
                    break;
                case metric.TIME_SPENT:
                    value = match.match_data.match_duration_seconds;
                    break;
                case metric.RAM_DAMAGE:
                    foreach (file_trace_managment.RoundRecord round in match.match_data.round_records)
                        foreach (file_trace_managment.RoundDamageRecord rec in round.damage_records.Where(x => x.attacker == match.match_data.local_player.nickname && x.weapon == "Ramming"))
                            value += rec.damage;
                    break;
                case metric.CABIN_DAMAGE:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.cabin_damage;
                    break;
                case metric.BODY_DAMAGE:
                    value = match.match_data.player_records[match.match_data.local_player.uid].stats.damage - match.match_data.player_records[match.match_data.local_player.uid].stats.cabin_damage;
                    break;
                case metric.EXPERIENCE:
                    value = match.match_data.match_rewards.Where(x => x.Key.Contains("xp")).Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                case metric.URANIUM:
                    value = match.match_data.match_rewards.Where(x => x.Key == "ClanMoney").Sum(x => x.Value);
                    if (match.match_data.match_type != GlobalData.STANDARD_CW_MATCH && match.match_data.match_type != GlobalData.LEVIATHIAN_CW_MATCH)
                        return;
                    break;
                case metric.SCRAP:
                    value = match.match_data.match_rewards.Where(x => x.Key == "Scrap_Common").Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                case metric.WIRES:
                    value = match.match_data.match_rewards.Where(x => x.Key == "Scrap_Rare").Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                case metric.BATTERIES:
                    value = match.match_data.match_rewards.Where(x => x.Key == "Accumulators").Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                case metric.COPPER:
                    value = match.match_data.match_rewards.Where(x => x.Key == "Platinum").Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                case metric.COUPONS:
                    value = match.match_data.match_rewards.Where(x => x.Key == "Supply").Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                case metric.ELECTRONICS:
                    value = match.match_data.match_rewards.Where(x => x.Key == "Scrap_Epic").Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                case metric.PLASTIC:
                    value = match.match_data.match_rewards.Where(x => x.Key == "Plastic").Sum(x => x.Value);
                    if ((int)value == 0)
                        return;
                    break;
                default:
                    MessageBox.Show("Unable to find metric");
                    return;
            }

            switch (current_x_axis.id)
            {
                case grouping.DAY:
                    add_chart_element(match.match_data.match_start.Date.ToString(), value);
                    break;
                case grouping.WEEK:
                    add_chart_element(match.match_data.match_start.Date.AddDays((-1 * (double)(match.match_data.match_start.Date.DayOfWeek - (int)DayOfWeek.Monday)) + 1).Date.ToString(), value);
                    break;
                case grouping.MONTH:
                    add_chart_element(match.match_data.match_start.Date.AddDays((-1 * match.match_data.match_start.Date.Day) + 1).Date.ToString(), value);
                    break;
                case grouping.YEAR:
                    add_chart_element(match.match_data.match_start.Date.AddDays((-1 * match.match_data.match_start.Date.DayOfYear) + 1).Date.ToString(), value);
                    break;
                case grouping.WEAPON:

                    if (current_y_axis.id == metric.DAMAGE)
                    {
                        Dictionary<string, double> damage_records = new Dictionary<string, double> { };

                        foreach (file_trace_managment.RoundRecord round in match.match_data.round_records)
                        {
                            foreach (file_trace_managment.RoundDamageRecord rec in round.damage_records.Where(x => x.attacker == match.match_data.local_player.nickname))
                            {
                                if (!damage_records.ContainsKey(rec.weapon))
                                    damage_records.Add(rec.weapon, rec.damage);
                                else
                                    damage_records[rec.weapon] += rec.damage;

                            }
                        }

                        foreach (KeyValuePair<string, double> rec in damage_records)
                            add_chart_element(translate.translate_string(rec.Key, session, translations), rec.Value);
                    }
                    else
                    {
                        if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                            foreach (part_loader.Weapon part in build_records[match.match_data.local_player.build_hash].weapons)
                                add_chart_element(translate.translate_string(part.name, session, translations), value);
                    }
                    break;
                case grouping.MOVEMENT:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        foreach (part_loader.Movement part in build_records[match.match_data.local_player.build_hash].movement)
                            add_chart_element(translate.translate_string(part.name, session, translations), value);
                    break;
                case grouping.CABIN:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        if (build_records[match.match_data.local_player.build_hash].cabin != null)
                            add_chart_element(translate.translate_string(build_records[match.match_data.local_player.build_hash].cabin.name, session, translations), value);
                    break;
                case grouping.MODULE:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        foreach (part_loader.Module part in build_records[match.match_data.local_player.build_hash].modules)
                            add_chart_element(translate.translate_string(part.name, session, translations), value);
                    break;
                case grouping.ENGINE:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        if (build_records[match.match_data.local_player.build_hash].engine != null)
                            add_chart_element(translate.translate_string(build_records[match.match_data.local_player.build_hash].engine.name, session, translations), value);
                    break;
                case grouping.PART:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        foreach (string part in build_records[match.match_data.local_player.build_hash].parts)
                            add_chart_element(translate.translate_string(part, session, translations), value);
                    break;
                case grouping.WEAPON_CAT:
                    break;
                case grouping.MOVEMENT_CAT:
                    break;
                case grouping.CABIN_CAT:
                    break;
                case grouping.MODULE_CAT:
                    break;
                case grouping.MAP:
                    add_chart_element(translate.translate_string(match.match_data.map_name, session, translations), value);
                    break;
                case grouping.GAME_MODE:
                    add_chart_element(match.match_data.match_type_desc, value);
                    break;
                case grouping.GAME_MODE_CAT:
                    add_chart_element(decode_match_classification(match.match_data.match_classification), value);
                    break;
                case grouping.GAME_RESULT:
                    add_chart_element(match.match_data.game_result, value);
                    break;
                case grouping.POWER_SCORE:
                    add_chart_element(find_power_score_range(match.match_data.local_player.power_score), value);
                    break;
                case grouping.REGION:
                    add_chart_element(decode_game_region(match.match_data.host_name), value);
                    break;
                case grouping.SERVER:
                    add_chart_element(match.match_data.host_name, value);
                    break;
                case grouping.CLIENT_VERSION:
                    add_chart_element(match.match_data.client_version, value);
                    break;
                case grouping.GROUP_SIZE:
                    add_chart_element(match.match_data.player_records.Count(x => x.Value.party_id == match.match_data.local_player.party_id && match.match_data.local_player.party_id != 0).ToString(), value);
                    break;
                case grouping.SQUAD_MATE:
                    foreach (string player in match.match_data.player_records.Where(x => x.Value.party_id == match.match_data.local_player.party_id && match.match_data.local_player.party_id != 0).Select(x => x.Value.nickname))
                        add_chart_element(player, value);
                    break;
                case grouping.OPPONENT:
                    foreach (string player in match.match_data.player_records.Where(x => x.Value.team != match.match_data.local_player.team && x.Value.uid > 0 && x.Value.nickname != match.match_data.local_player.nickname).Select(x => x.Value.nickname))
                        add_chart_element(player, value);
                    break;
                case grouping.ALLY:
                    foreach (string player in match.match_data.player_records.Where(x => x.Value.team == match.match_data.local_player.team && x.Value.uid > 0 && x.Value.nickname != match.match_data.local_player.nickname).Select(x => x.Value.nickname))
                        add_chart_element(player, value);
                    break;
                case grouping.BUILD_HASH:
                    add_chart_element(match.match_data.player_records[match.match_data.local_player.uid].build_hash, value);
                    break;
                case grouping.BUILD_DESC:
                    if (build_records.ContainsKey(match.match_data.local_player.build_hash))
                        add_chart_element(build_records[match.match_data.local_player.build_hash].full_description, value);
                    break;
                case grouping.BOT_ALLY:
                    foreach (string player in match.match_data.player_records.Where(x => x.Value.team == match.match_data.local_player.team && x.Value.uid == 0).Select(x => x.Value.nickname))
                        add_chart_element(player, value);
                    break;
                case grouping.BOT_OPPONENT:
                    foreach (string player in match.match_data.player_records.Where(x => x.Value.team != match.match_data.local_player.team && x.Value.uid == 0).Select(x => x.Value.nickname))
                        add_chart_element(player, value);
                    break;
                default:
                    MessageBox.Show("Unable to find group");
                    return;
            }
        }

        private void add_chart_element(string group, double value)
        {
            if (group == "")
                return;

            if (!chart_series.Any(x => x.title == group))
            {
                chart_series.Add(new chart_element { x_value = chart_series.Count + 1, title = group, total = value, min = value, max = value, count = 1 });
            }
            else
            {
                chart_element element = chart_series.FirstOrDefault(x => x.title == group);
                element.total += value;

                if (element.min > value)
                    element.min = value;

                if (element.max < value)
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

        public string decode_match_classification(int match_classification)
        {
            if (match_classification == GlobalData.PVP_CLASSIFICATION)
                return "PvP";
            if (match_classification == GlobalData.PVE_CLASSIFICATION)
                return "PvE";
            if (match_classification == GlobalData.BRAWL_CLASSIFICATION)
                return "Brawl";
            if (match_classification == GlobalData.CUSTOM_CLASSIFICATION)
                return "Custom";
            if (match_classification == GlobalData.FREE_PLAY_CLASSIFICATION)
                return "Free Play";
            return "Undefined";
        }

        public string decode_game_region(string host_name)
        {
            if (host_name.Contains("-ru"))
                return "Russia";
            if (host_name.Contains("-nl"))
                return "Europe";
            if (host_name.Contains("-us"))
                return "North America";
            else if (host_name.Contains("-jp"))
                return "Asia";
            else if (host_name.Contains("-au"))
                return "Australia";
            return "Unknown";
        }

        public void reset_comparison_data()
        {
            chart_series = new List<chart_element> { };

            ch_comparison.ChartAreas[0].AxisX.Title = current_x_axis.name;
            ch_comparison.ChartAreas[0].AxisY.Title = current_y_axis.name;

            current_series = new Series { };
            current_series.ChartType = current_chart_type.series_type;
            current_series.Palette = ChartColorPalette.BrightPastel;

            ch_comparison.Series.Clear();
            ch_comparison.Series.Add(current_series);
        }

        private void cbYaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_y_axis = y_axis_groups.FirstOrDefault(x => x.name == cbYaxis.SelectedItem.ToString());
            populate_comparison_chart();
        }

        private void cbXaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_x_axis = x_axis_groups.FirstOrDefault(x => x.name == cbXaxis.SelectedItem.ToString());
            populate_comparison_chart();
        }

        private void cb_min_max_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = cb_min_max.SelectedItem.ToString();
            populate_comparison_chart();
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            current_x_axis = x_axis_groups.FirstOrDefault(x => x.id == grouping.WEAPON);
            current_y_axis = y_axis_groups.FirstOrDefault(x => x.id == metric.DAMAGE);
            current_result_limit = 0;
            current_min_sample_size = 15;

            cbXaxis.Text = current_x_axis.name;
            cbYaxis.Text = current_y_axis.name;
            cbMinSampleSize.Text = "15";
            cbChartType.Text = "Column";
            cb_min_max.Text = "Average";

            Filter.ResetFilterSelections(filter_selections);

            dt_start_date.Value = DateTime.Now;
            dt_end_date.Value = DateTime.Now;

            populate_comparison_chart();
        }

        private void cb_versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.ClientVersionFilter == this.cb_versions.Text)
                return;

            if (this.cb_versions.SelectedIndex >= 0)
                filter_selections.ClientVersionFilter = this.cb_versions.Text;

            populate_comparison_chart();
        }

        private void cb_power_score_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.PowerScoreFilter == this.cb_power_score.Text)
                return;

            if (this.cb_power_score.SelectedIndex >= 0)
                filter_selections.PowerScoreFilter = this.cb_power_score.Text;

            populate_comparison_chart();
        }

        private void cb_grouped_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.GroupFilter == this.cb_grouped.Text)
                return;

            if (this.cb_grouped.SelectedIndex >= 0)
                filter_selections.GroupFilter = this.cb_grouped.Text;

            populate_comparison_chart();
        }

        private void cb_game_modes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.GameModeFilter == this.cb_game_modes.Text)
                return;

            if (this.cb_game_modes.SelectedIndex >= 0)
                filter_selections.GameModeFilter = this.cb_game_modes.Text;

            populate_comparison_chart();
        }

        private void dt_start_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.StartDate == dt_start_date.Value)
                return;

            filter_selections.StartDate = dt_start_date.Value;
            populate_comparison_chart();
        }

        private void dt_end_date_ValueChanged(object sender, EventArgs e)
        {
            if (filter_selections.EndDate == dt_end_date.Value)
                return;

            filter_selections.EndDate = dt_end_date.Value;
            populate_comparison_chart();
        }

        private void cb_cabins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.CabinFilter == this.cb_cabins.Text)
                return;

            if (this.cb_cabins.SelectedIndex >= 0)
                filter_selections.CabinFilter = this.cb_cabins.Text;

            populate_comparison_chart();
        }

        private void cb_weapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.WeaponsFilter == this.cb_weapons.Text)
                return;

            if (this.cb_weapons.SelectedIndex >= 0)
                filter_selections.WeaponsFilter = this.cb_weapons.Text;

            populate_comparison_chart();
        }

        private void cb_modules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.ModuleFilter == this.cb_modules.Text)
                return;

            if (this.cb_modules.SelectedIndex >= 0)
                filter_selections.ModuleFilter = this.cb_modules.Text;

            populate_comparison_chart();
        }

        private void cb_movement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filter_selections.MovementFilter == this.cb_movement.Text)
                return;

            if (this.cb_movement.SelectedIndex >= 0)
                filter_selections.MovementFilter = this.cb_movement.Text;

            populate_comparison_chart();
        }

        private void comparison_screen_Resize(object sender, EventArgs e)
        {
            resize.resize(this);
        }

        private void cbMinSampleSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_min_sample_size = Convert.ToInt32(cbMinSampleSize.SelectedItem.ToString());
            populate_comparison_chart();
        }

        private void cbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_chart_type = chart_type_list.FirstOrDefault(x => x.chart_name == cbChartType.SelectedItem.ToString());
            populate_comparison_chart();
        }
    }
}

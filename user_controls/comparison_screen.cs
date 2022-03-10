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
        private grouping_category current_y_axis = null;
        private int current_result_limit = 0;
        private int current_min_sample_size = 0;

        private List<string> result_limit_groups = new List<string> { "All", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"};
        private List<string> min_sample_size_groups = new List<string> { "0", "5", "10", "15", "20", "25", "50", "75", "100", "150", "200", "250", "300"};

        private List<grouping_category> x_axis_groups = new List<grouping_category> { new grouping_category { name = "Day", min = 0, max = int.MaxValue, max_display = 7 },
                                                                                      new grouping_category { name = "Week", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { name = "Month", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { name = "Year", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { name = "Weapon", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Movement Part", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Cabin", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Module", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Weapon Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Movement Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Cabin Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Module Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Map", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Game Mode", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Game Mode Category", min = 0, max = int.MaxValue, max_display = 14 },
                                                                                      new grouping_category { name = "Game Result", min = 0, max = int.MaxValue, max_display = 3 },
                                                                                      new grouping_category { name = "Power Score", min = 0, max = int.MaxValue, max_display = 12 },
                                                                                      new grouping_category { name = "Region", min = 0, max = int.MaxValue, max_display = 7 },
                                                                                      new grouping_category { name = "Server", min = 0, max = int.MaxValue, max_display = 7 },
                                                                                      new grouping_category { name = "Group Size", min = 0, max = int.MaxValue, max_display = 14 }
                                                                                    };

        private List<grouping_category> y_axis_groups = new List<grouping_category> { new grouping_category { name = "Win Rate", min = 0, max = 100, max_display = 0 },
                                                                                      new grouping_category { name = "MVP Rate", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Damage", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Damage Recieved", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Score", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Kills", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Assists", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Deaths", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average (K+A)", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Drone Kills", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Average Medals", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Damage", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Damage Recieved", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Score", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Kills", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Assists", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Deaths", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total (K+A)", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Drone Kills", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Total Medals", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Damage", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Damage Recieved", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Score", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Kills", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Assists", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Deaths", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum (K+A)", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Drone Kills", min = 0, max = int.MaxValue, max_display = 0 },
                                                                                      new grouping_category { name = "Maximum Medals", min = 0, max = int.MaxValue, max_display = 0 }
                                                                                    };
        private class grouping_category
        {
            public string name { get; set; }
            public int min { get; set; }
            public int max { get; set; }
            public int max_display { get; set; }
        }

        private class grouping
        {
            public string name { get; set; }
            public int count { get; set; } 
        }


        public comparison_screen()
        {
            InitializeComponent();
        }

        private void comparison_screen_Load(object sender, EventArgs e)
        {
            cbXaxis.Items.Clear();
            cbYaxis.Items.Clear();
            cbReturnLimit.Items.Clear();
            cbMinSampleSize.Items.Clear();

            foreach (grouping_category group in x_axis_groups)
                cbXaxis.Items.Add(group.name);

            foreach (grouping_category group in y_axis_groups)
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

        private void cbYaxis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbXaxis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbReturnLimit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMinSampleSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class fusion_calculator : UserControl
    {

        static int Attempt_depth = 100000;
        static int Fusion_depth = 20;

        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Dictionary<int, int> Distribution { get; set; }

        public fusion_calculator()
        {
            InitializeComponent();

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Distribution = new Dictionary<int, int> { };

            num_item_cost.Value = 330;
            num_reliabilty_target.Value = 1;
            num_reliability_max.Value = 3;
            num_power_target.Value = 0;
            num_power_max.Value = 3;
            num_handling_target.Value = 1;
            num_handling_max.Value = 3;
            
            calculate_probabilities();
        }

        private void fusion_calculator_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void calculate_probabilities()
        {
            int fusion_a;
            int fusion_b;
            int fusion_c;
            bool success;
            int iterations;
            Random rnd = new Random();

            tb_fusion_data.AllowUserToAddRows = true;

            Distribution.Clear();

            for (int i = 0; i < Attempt_depth; i++)
            {
                iterations = 0;

                for (int j = 0; j < Fusion_depth; j++)
                {
                    success = true;

                    fusion_a = rnd.Next(1, Convert.ToInt32(num_reliability_max.Value) + 1);
                    fusion_b = rnd.Next(1, Convert.ToInt32(num_power_max.Value) + 1);
                    fusion_c = rnd.Next(1, Convert.ToInt32(num_handling_max.Value) + 1);

                    iterations++;

                    if (Convert.ToInt32(num_reliabilty_target.Value) > 0)
                        if (Convert.ToInt32(num_reliabilty_target.Value) < fusion_a)
                            success = false;

                    if (Convert.ToInt32(num_power_target.Value) > 0)
                        if (Convert.ToInt32(num_power_target.Value) < fusion_b)
                            success = false;

                    if (Convert.ToInt32(num_handling_target.Value) > 0)
                        if (Convert.ToInt32(num_handling_target.Value) < fusion_c)
                            success = false;

                    if (success)
                    {
                        if (Distribution.ContainsKey(iterations))
                            Distribution[iterations]++;
                        else
                            Distribution.Add(iterations, 1);
                        break;
                    }
                }
            }

            display_probabilities();
        }

        void display_probabilities()
        {
            int previous_iterations = 0;

            List<int> probabilities = new List<int> { };
            foreach (KeyValuePair<int, int> current_iteration in Distribution)
                probabilities.Add(current_iteration.Key);

            probabilities = probabilities.OrderBy(q => q).ToList();

            tb_fusion_data.Rows.Clear();

            foreach (int current_iteration in probabilities)
            {
                DataGridViewRow row = (DataGridViewRow)tb_fusion_data.Rows[0].Clone();
                row.Cells[0].Value = current_iteration.ToString();
                row.Cells[1].Value = string.Format("{0,6:N2}", (((double)Distribution[current_iteration] + (double)previous_iterations) / (double)Attempt_depth) * 100);
                row.Cells[2].Value = (current_iteration + 1).ToString();
                row.Cells[3].Value = (Convert.ToInt32(row.Cells[2].Value) * num_item_cost.Value).ToString();
                row.Cells[4].Value = ((current_iteration * 2) + 1).ToString();
                row.Cells[5].Value = (Convert.ToInt32(row.Cells[4].Value) * num_item_cost.Value).ToString();
                tb_fusion_data.Rows.Add(row);
                previous_iterations += Distribution[current_iteration];
            }
            tb_fusion_data.AllowUserToAddRows = false;
        }

        private void calculator_changed(object sender, EventArgs e)
        {
            calculate_probabilities();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            this.num_item_cost.Value = 330;
            this.num_reliabilty_target.Value = 1;
            this.num_reliability_max.Value = 3;
            this.num_power_target.Value = 0;
            this.num_power_max.Value = 3;
            this.num_handling_target.Value = 1;
            this.num_handling_max.Value = 3;

            calculate_probabilities();
        }
    }
}

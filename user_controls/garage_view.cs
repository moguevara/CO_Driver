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
    public partial class garage_view : UserControl
    {
        private class WeaponTotals
        {
            public string weapon { get; set; }
            public double total { get; set; }
        }

        private class WeaponRow
        {
            public double percent { get; set; }
            public string weapon_name { get; set; }
            public double total_damage { get; set; }
            public double burst_damage { get; set; }
            public double reload_time { get; set; }
            public double heat_up_time { get; set; }
            public double cool_down_time { get; set; }
            public double damage_per_second { get; set; }
        }

        public List<file_trace_managment.GarageDamageRecord> current_damage_records = new List<file_trace_managment.GarageDamageRecord> { };
        public List<List<file_trace_managment.GarageDamageRecord>> historic_damage_records = new List<List<file_trace_managment.GarageDamageRecord>> { };

        private DateTime trial_start_time = DateTime.MinValue;

        private double total_damage = 0.0;
        private double total_hull_damage = 0.0;
        private double total_body_damage = 0.0;
        private double time_cutoff = Double.MinValue;
        private double damage_cutoff = Double.MinValue;

        private List<WeaponTotals> weapon_totals = new List<WeaponTotals> { };
        private List<WeaponRow> weapon_rows = new List<WeaponRow> { };
        private BindingSource weapon_table_source = new BindingSource();
        private Series current_total_series = new Series { };

        public garage_view()
        {
            InitializeComponent();
        }

        public void add_damage_record(file_trace_managment.GarageDamageRecord rec)
        {
            if (trial_start_time == DateTime.MinValue)
                trial_start_time = rec.time;

            if (damage_cutoff != Double.MinValue && total_damage > damage_cutoff)
                return;

            if (time_cutoff != Double.MinValue && rec.time.Subtract(trial_start_time).TotalSeconds > time_cutoff)
                return;

            total_damage += rec.damage;

            if (rec.flags.Contains("HUD_IMPORTANT"))
                total_hull_damage += rec.damage;
            else
                total_body_damage += rec.damage;

            current_total_series.Points.AddXY(rec.time.Subtract(trial_start_time).TotalSeconds, total_damage);

            if (weapon_totals.FirstOrDefault(x => x.weapon == rec.weapon) == null)
            {
                initialize_series(rec);
                ch_live_feed.Series[rec.weapon].Points.AddXY(0, 0);
                add_vertical_annotation(ch_live_feed, ch_live_feed.Series[rec.weapon]);
                weapon_totals.Add(new WeaponTotals { weapon = rec.weapon, total = rec.damage });
            }
            else
            {
                weapon_totals.FirstOrDefault(x => x.weapon == rec.weapon).total += rec.damage;
            }

            if (weapon_rows.FirstOrDefault(x => x.weapon_name == rec.weapon) == null)
                weapon_rows.Add(new WeaponRow { percent = 0, weapon_name = rec.weapon, total_damage = rec.damage, burst_damage = 0, cool_down_time = 0, damage_per_second = 0, heat_up_time = 0, reload_time = 0 });
            else
                weapon_rows.FirstOrDefault(x => x.weapon_name == rec.weapon).total_damage += rec.damage;

            double current_total = 0;
            for (int i = weapon_totals.Count() - 1; i >= 0; i--)
            {
                current_total += weapon_totals[i].total;
                ch_live_feed.Series[weapon_totals[i].weapon].Points.AddXY(rec.time.Subtract(trial_start_time).TotalSeconds, current_total);
            }

            foreach (WeaponRow row in weapon_rows)
            {
                row.percent = row.total_damage / total_damage;
            }

            current_damage_records.Add(rec);
            draw_text_elements();
            weapon_table_source.ResetBindings(false);
        } 

        public void reset_damage_records()
        {
            total_damage = 0.0;
            total_hull_damage = 0.0;
            total_body_damage = 0.0;
            current_damage_records = new List<file_trace_managment.GarageDamageRecord> { };
            trial_start_time = DateTime.MinValue;

            foreach (Series series in ch_live_feed.Series)
                series.Points.Clear();

            ch_live_feed.Series.Clear();

            weapon_totals = new List<WeaponTotals> { };
            weapon_rows = new List<WeaponRow> { };
            weapon_table_source.DataSource = weapon_rows;
            dg_weapon_overview.DataSource = weapon_table_source;

            current_total_series = new Series { };
            current_total_series.LabelBackColor = Color.Black;
            current_total_series.LabelForeColor = Color.Lime;
            current_total_series.ChartType = SeriesChartType.StepLine;
            current_total_series.Points.AddXY(0, 0);

            draw_text_elements();
        }

        public void draw_text_elements()
        {
            lb_total_damage.Text = Math.Round(total_damage, 1).ToString();
            lb_hull_damage.Text = Math.Round(total_hull_damage, 1).ToString();
            lb_body_damage.Text = Math.Round(total_body_damage, 1).ToString();
        }

        public void save_damage_record()
        {
            historic_damage_records.Add(current_damage_records);
        }

        private void gb_weapon_breakdown_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, Color.Lime, Color.Lime);
        }

        private void gb_live_data_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, Color.Lime, Color.Lime);
        }

        private void gb_comparison_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, Color.Lime, Color.Lime);
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

        private void garage_view_Load(object sender, EventArgs e)
        {
        }

        public void initialize_live_feed()
        {
            ch_live_feed.BackColor = Color.Black;
            ch_live_feed.ForeColor = Color.Lime;
            ch_live_feed.Legends[0].BackColor = Color.Black;
            ch_live_feed.Legends[0].ForeColor = Color.Lime;
            ch_live_feed.ChartAreas[0].BackColor = Color.Black;
            ch_live_feed.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ch_live_feed.ChartAreas[0].AxisX.Title = "Time (S)";
            ch_live_feed.ChartAreas[0].AxisX.Minimum = 0;
            ch_live_feed.ChartAreas[0].AxisX.TitleForeColor = Color.Lime;
            ch_live_feed.ChartAreas[0].AxisX.LineColor = Color.Lime;
            ch_live_feed.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;
            ch_live_feed.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Lime;
            ch_live_feed.ChartAreas[0].AxisX.RoundAxisValues();
            ch_live_feed.ChartAreas[0].AxisX.IsMarginVisible = false;
            ch_live_feed.ChartAreas[0].AxisY.Title = "Damage";
            ch_live_feed.ChartAreas[0].AxisY.TitleForeColor = Color.Lime;
            ch_live_feed.ChartAreas[0].AxisY.LineColor = Color.Lime;
            ch_live_feed.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Black;
            ch_live_feed.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Lime;
            ch_live_feed.ChartAreas[0].AxisY.IsMarginVisible = false;

            ch_compare.BackColor = Color.Black;
            ch_compare.ForeColor = Color.Lime;
            ch_compare.Legends[0].BackColor = Color.Black;
            ch_compare.Legends[0].ForeColor = Color.Lime;
            ch_compare.ChartAreas[0].BackColor = Color.Black;
            ch_compare.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ch_compare.ChartAreas[0].AxisX.Title = "Time (S)";
            ch_compare.ChartAreas[0].AxisX.Minimum = 0;
            ch_compare.ChartAreas[0].AxisX.TitleForeColor = Color.Lime;
            ch_compare.ChartAreas[0].AxisX.LineColor = Color.Lime;
            ch_compare.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Black;
            ch_compare.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Lime;
            ch_compare.ChartAreas[0].AxisX.RoundAxisValues();
            ch_compare.ChartAreas[0].AxisX.IsMarginVisible = false;
            ch_compare.ChartAreas[0].AxisY.Title = "Damage";
            ch_compare.ChartAreas[0].AxisY.TitleForeColor = Color.Lime;
            ch_compare.ChartAreas[0].AxisY.LineColor = Color.Lime;
            ch_compare.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Black;
            ch_compare.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Lime;
            ch_compare.ChartAreas[0].AxisY.IsMarginVisible = false;

            weapon_table_source.DataSource = weapon_rows;
            dg_weapon_overview.DataSource = weapon_table_source;

            dg_weapon_overview.Columns["percent"].DisplayIndex = 0;
            dg_weapon_overview.Columns["percent"].ToolTipText = "Percent of total damage";
            dg_weapon_overview.Columns["percent"].HeaderText = "%";
            dg_weapon_overview.Columns["percent"].Width = 60;
            dg_weapon_overview.Columns["percent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dg_weapon_overview.Columns["percent"].DefaultCellStyle.Format = "P1";

            dg_weapon_overview.Columns["weapon_name"].DisplayIndex = 1;
            dg_weapon_overview.Columns["weapon_name"].HeaderText = "Weapon Name";
            dg_weapon_overview.Columns["weapon_name"].Width = 120;
            dg_weapon_overview.Columns["weapon_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

            dg_weapon_overview.Columns["total_damage"].DisplayIndex = 2;
            dg_weapon_overview.Columns["total_damage"].ToolTipText = "Total damage to all targets after damage reduction.";
            dg_weapon_overview.Columns["total_damage"].HeaderText = "DMG";
            dg_weapon_overview.Columns["total_damage"].Width = 80;
            dg_weapon_overview.Columns["percent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dg_weapon_overview.Columns["total_damage"].DefaultCellStyle.Format = "N1";

            dg_weapon_overview.Columns["burst_damage"].DisplayIndex = 3;
            dg_weapon_overview.Columns["burst_damage"].ToolTipText = "Maximum damage in a single burst (3 second interval). Intended to simulate peak-and-poke playstyle.";
            dg_weapon_overview.Columns["burst_damage"].HeaderText = "Burst DMG";
            dg_weapon_overview.Columns["burst_damage"].Width = 80;
            dg_weapon_overview.Columns["burst_damage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dg_weapon_overview.Columns["burst_damage"].DefaultCellStyle.Format = "N1";

            dg_weapon_overview.Columns["reload_time"].DisplayIndex = 4;
            dg_weapon_overview.Columns["reload_time"].ToolTipText = "Period between reloads.";
            dg_weapon_overview.Columns["reload_time"].HeaderText = "Reload Time";
            dg_weapon_overview.Columns["reload_time"].Width = 80;
            dg_weapon_overview.Columns["reload_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dg_weapon_overview.Columns["reload_time"].DefaultCellStyle.Format = "N1";

            dg_weapon_overview.Columns["heat_up_time"].DisplayIndex = 5;
            dg_weapon_overview.Columns["heat_up_time"].ToolTipText = "Duration of sustained fire before overheat.";
            dg_weapon_overview.Columns["heat_up_time"].HeaderText = "Heat up time";
            dg_weapon_overview.Columns["heat_up_time"].Width = 80;
            dg_weapon_overview.Columns["percent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dg_weapon_overview.Columns["heat_up_time"].DefaultCellStyle.Format = "N1";

            dg_weapon_overview.Columns["cool_down_time"].DisplayIndex = 6;
            dg_weapon_overview.Columns["cool_down_time"].ToolTipText = "Interval between end of sustained fire and begining of damage.";
            dg_weapon_overview.Columns["cool_down_time"].HeaderText = "Cool Down Time";
            dg_weapon_overview.Columns["cool_down_time"].Width = 80;
            dg_weapon_overview.Columns["cool_down_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dg_weapon_overview.Columns["cool_down_time"].DefaultCellStyle.Format = "N1";

            dg_weapon_overview.Columns["damage_per_second"].DisplayIndex = 7;
            dg_weapon_overview.Columns["damage_per_second"].ToolTipText = "Damage per second.";
            dg_weapon_overview.Columns["damage_per_second"].HeaderText = "DPS";
            dg_weapon_overview.Columns["damage_per_second"].Width = 60;
            dg_weapon_overview.Columns["damage_per_second"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            dg_weapon_overview.Columns["damage_per_second"].DefaultCellStyle.Format = "N1";

            current_total_series.Color = Color.Lime;
            current_total_series.LabelBackColor = Color.Black;
            current_total_series.LabelForeColor = Color.Lime;
            current_total_series.ChartType = SeriesChartType.StepLine;
            current_total_series.Points.Clear();
            current_total_series.Points.AddXY(0, 0);

            ch_live_feed.Series.Add(new Series("bullshit"));
            ch_live_feed.Series["bullshit"].IsVisibleInLegend = false;
            ch_live_feed.Series["bullshit"].ChartType = SeriesChartType.StepLine;
            ch_live_feed.Series["bullshit"].Points.AddXY(0, 0);
            ch_live_feed.Series["bullshit"].Points.AddXY(1, 1);


            cmb_trial_type.SelectedItem = "Free Form";
            num_trial_threshold.Enabled = false;
        }

        private void initialize_series(file_trace_managment.GarageDamageRecord rec)
        {
            string name = rec.weapon;

            ch_live_feed.Series.Add(new Series(name));
            ch_live_feed.Series[name].LegendText = name;

            if (rec.flags.Contains("HIGH_RATE_FIRE") || rec.flags.Contains("CONTINUOUS"))
                ch_live_feed.Series[name].ChartType = SeriesChartType.StepLine;
            else
                ch_live_feed.Series[name].ChartType = SeriesChartType.StepLine;

            ch_live_feed.Series[name].ToolTip = name;
            ch_live_feed.Series[name].LabelBackColor = Color.Black;
            ch_live_feed.Series[name].LabelForeColor = Color.Lime;
            ch_live_feed.Series[name].Points.Clear();

        }

        private void add_vertical_annotation(Chart chart, Series series)
        {
            VerticalLineAnnotation line_annotaion = new VerticalLineAnnotation();
            line_annotaion.AllowMoving = true;
            line_annotaion.IsInfinitive = true;
            line_annotaion.AnchorDataPoint = series.Points[0];
            line_annotaion.LineColor = Color.Lime;
            line_annotaion.ForeColor = series.Color;
            line_annotaion.ClipToChartArea = chart.ChartAreas[0].Name;
            line_annotaion.AxisX = chart.ChartAreas[0].AxisX;
            line_annotaion.LineWidth = 1;
            line_annotaion.X = 0;

            chart.Annotations.Add(line_annotaion);
        }

        private void btn_save_user_settings_Click(object sender, EventArgs e)
        {
            if (!ch_compare.Series.Contains(current_total_series))
            {
                current_total_series.LegendText = ch_compare.Series.Count().ToString() + ":" + weapon_totals.OrderByDescending(x => x.total).Select(x => x.weapon).FirstOrDefault();
                ch_compare.Series.Add(current_total_series);
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ch_compare.Series.Clear();
        }

        private void num_trial_threshold_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_trial_type.SelectedItem.ToString() == "Time Trial")
            {
                time_cutoff = Convert.ToDouble(num_trial_threshold.Value);
            }
            else
            if (cmb_trial_type.SelectedItem.ToString() == "Damage Trial")
            {
                damage_cutoff = Convert.ToDouble(num_trial_threshold.Value);
            }
        }

        private void cmb_trial_type_SelectedIndexChanged(object sender, EventArgs e)
        {

            time_cutoff = Double.MinValue;
            damage_cutoff = Double.MinValue;
            if (cmb_trial_type.SelectedItem.ToString() == "Time Trial")
            {
                lb_trial_desc.Text = "Seconds";
                num_trial_threshold.Enabled = true;
                num_trial_threshold.Value = 30;
                num_trial_threshold.Increment = 5;
                time_cutoff = Convert.ToDouble(num_trial_threshold.Value);
            }
            else
            if (cmb_trial_type.SelectedItem.ToString() == "Damage Trial")
            {
                lb_trial_desc.Text = "Damage";
                num_trial_threshold.Enabled = true;
                num_trial_threshold.Value = 2500;
                num_trial_threshold.Increment = 250;
                damage_cutoff = Convert.ToDouble(num_trial_threshold.Value);

            }
            else
            {
                lb_trial_desc.Text = "";
                num_trial_threshold.Value = 0;
                num_trial_threshold.Enabled = false;
            }   
        }

        private void button1_Click(object sender, EventArgs e)
        {

            time_cutoff = Double.MinValue;
            damage_cutoff = Double.MinValue;
            lb_trial_desc.Text = "";
            num_trial_threshold.Value = 0;
            cmb_trial_type.SelectedItem = "Free Form";
            num_trial_threshold.Enabled = false;
        }

        private void ch_live_feed_AnnotationPositionChanging(object sender, AnnotationPositionChangingEventArgs e)
        {

            //ch_live_feed.Update();
        }
    }
}

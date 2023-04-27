﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CO_Driver
{
    public partial class GarageView : UserControl
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
            public int hits { get; set; }
            public double burst_damage { get; set; }
            public int bursts { get; set; }
            public DateTime first_hit { get; set; }
            public DateTime last_hit { get; set; }
            public DateTime burst_start { get; set; }
            public double burst_duration { get; set; }
            public double reload_duration { get; set; }
            public double dps { get; set; }
        }

        public List<FileTraceManagment.GarageDamageRecord> current_damage_records = new List<FileTraceManagment.GarageDamageRecord> { };
        public List<List<FileTraceManagment.GarageDamageRecord>> historic_damage_records = new List<List<FileTraceManagment.GarageDamageRecord>> { };
        public LogFileManagment.SessionVariables session = new LogFileManagment.SessionVariables { };
        public Dictionary<string, Dictionary<string, Translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

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

        public GarageView()
        {
            InitializeComponent();
        }

        public void add_damage_record(FileTraceManagment.GarageDamageRecord rec)
        {
            if (trial_start_time == DateTime.MinValue)
                trial_start_time = rec.Time;

            if (damage_cutoff != Double.MinValue && total_damage > damage_cutoff)
                return;

            if (time_cutoff != Double.MinValue && rec.Time.Subtract(trial_start_time).TotalSeconds > time_cutoff)
                return;

            total_damage += rec.Damage;

            if (rec.Flags.Contains("HUD_IMPORTANT"))
                total_hull_damage += rec.Damage;
            else
                total_body_damage += rec.Damage;

            //translate.translate_string(x.Key, session, translations)

            current_total_series.Points.AddXY(rec.Time.Subtract(trial_start_time).TotalSeconds, total_damage);

            if (weapon_totals.FirstOrDefault(x => x.weapon == Translate.TranslateString(rec.Weapon, session, translations)) == null)
            {
                initialize_series(rec);
                ch_live_feed.Series[Translate.TranslateString(rec.Weapon, session, translations)].Points.AddXY(0, 0);
                add_vertical_annotation(ch_live_feed, ch_live_feed.Series[Translate.TranslateString(rec.Weapon, session, translations)]);
                weapon_totals.Add(new WeaponTotals { weapon = Translate.TranslateString(rec.Weapon, session, translations), total = rec.Damage });
            }
            else
            {
                weapon_totals.FirstOrDefault(x => x.weapon == Translate.TranslateString(rec.Weapon, session, translations)).total += rec.Damage;
            }

            if (weapon_rows.FirstOrDefault(x => x.weapon_name == Translate.TranslateString(rec.Weapon, session, translations)) == null)
            {
                weapon_rows.Add(new WeaponRow
                {
                    percent = 0,
                    weapon_name = Translate.TranslateString(rec.Weapon, session, translations),
                    total_damage = rec.Damage,
                    burst_damage = rec.Damage,
                    bursts = 1,
                    hits = 1,
                    first_hit = rec.Time,
                    last_hit = rec.Time,
                    burst_start = rec.Time,
                    burst_duration = 0.0,
                    reload_duration = 0.0
                });
            }
            else
            {
                WeaponRow weapon_rec = weapon_rows.FirstOrDefault(x => x.weapon_name == Translate.TranslateString(rec.Weapon, session, translations));
                weapon_rec.total_damage += rec.Damage;

                if (rec.Time != weapon_rec.last_hit)
                    weapon_rec.hits += 1;

                if ((rec.Time - weapon_rec.last_hit).TotalSeconds > 0.5)
                {
                    weapon_rec.bursts += 1;
                    weapon_rec.burst_duration = (weapon_rec.last_hit - weapon_rec.burst_start).TotalSeconds;
                    weapon_rec.reload_duration = (rec.Time - weapon_rec.last_hit).TotalSeconds;

                    weapon_rec.burst_start = rec.Time;
                    weapon_rec.burst_damage = rec.Damage;
                }
                else
                {
                    weapon_rec.burst_damage += rec.Damage;
                }

                weapon_rec.dps = weapon_rec.total_damage / (rec.Time - weapon_rec.first_hit).TotalSeconds;
                weapon_rec.last_hit = rec.Time;
            }



            double current_total = 0;
            for (int i = weapon_totals.Count() - 1; i >= 0; i--)
            {
                current_total += weapon_totals[i].total;
                ch_live_feed.Series[weapon_totals[i].weapon].Points.AddXY(rec.Time.Subtract(trial_start_time).TotalSeconds, current_total);
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
            current_damage_records = new List<FileTraceManagment.GarageDamageRecord> { };
            trial_start_time = DateTime.MinValue;

            foreach (Series series in ch_live_feed.Series)
                series.Points.Clear();

            ch_live_feed.Series.Clear();

            weapon_totals = new List<WeaponTotals> { };
            weapon_rows = new List<WeaponRow> { };
            weapon_table_source.DataSource = weapon_rows;
            dg_weapon_overview.DataSource = weapon_table_source;

            current_total_series = new Series { };
            current_total_series.LabelBackColor = session.BackColor;
            current_total_series.LabelForeColor = session.ForeColor;
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
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_live_data_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            draw_group_box(box, e.Graphics, session.ForeColor, session.ForeColor);
        }

        private void gb_comparison_Paint(object sender, PaintEventArgs e)
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

        private void garage_view_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.RecordInitialSizes(this);
        }

        public void initialize_live_feed()
        {
            ch_live_feed.BackColor = session.BackColor;
            ch_live_feed.ForeColor = session.ForeColor;
            ch_live_feed.Legends[0].BackColor = session.BackColor;
            ch_live_feed.Legends[0].ForeColor = session.ForeColor;
            ch_live_feed.ChartAreas[0].BackColor = session.BackColor;
            ch_live_feed.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ch_live_feed.ChartAreas[0].AxisX.Title = "Time (S)";
            ch_live_feed.ChartAreas[0].AxisX.Minimum = 0;
            ch_live_feed.ChartAreas[0].AxisX.TitleForeColor = session.ForeColor;
            ch_live_feed.ChartAreas[0].AxisX.LineColor = session.ForeColor;
            ch_live_feed.ChartAreas[0].AxisX.MajorGrid.LineColor = session.BackColor;
            ch_live_feed.ChartAreas[0].AxisX.LabelStyle.ForeColor = session.ForeColor;
            ch_live_feed.ChartAreas[0].AxisX.RoundAxisValues();
            ch_live_feed.ChartAreas[0].AxisX.IsMarginVisible = false;
            ch_live_feed.ChartAreas[0].AxisY.Title = "Damage";
            ch_live_feed.ChartAreas[0].AxisY.TitleForeColor = session.ForeColor;
            ch_live_feed.ChartAreas[0].AxisY.LineColor = session.ForeColor;
            ch_live_feed.ChartAreas[0].AxisY.MajorGrid.LineColor = session.BackColor;
            ch_live_feed.ChartAreas[0].AxisY.LabelStyle.ForeColor = session.ForeColor;
            ch_live_feed.ChartAreas[0].AxisY.IsMarginVisible = false;
            ch_live_feed.Palette = ChartColorPalette.BrightPastel;

            ch_compare.BackColor = session.BackColor;
            ch_compare.ForeColor = session.ForeColor;
            ch_compare.Legends[0].BackColor = session.BackColor;
            ch_compare.Legends[0].ForeColor = session.ForeColor;
            ch_compare.ChartAreas[0].BackColor = session.BackColor;
            ch_compare.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            ch_compare.ChartAreas[0].AxisX.Title = "Time (S)";
            ch_compare.ChartAreas[0].AxisX.Minimum = 0;
            ch_compare.ChartAreas[0].AxisX.TitleForeColor = session.ForeColor;
            ch_compare.ChartAreas[0].AxisX.LineColor = session.ForeColor;
            ch_compare.ChartAreas[0].AxisX.MajorGrid.LineColor = session.BackColor;
            ch_compare.ChartAreas[0].AxisX.LabelStyle.ForeColor = session.ForeColor;
            ch_compare.ChartAreas[0].AxisX.RoundAxisValues();
            ch_compare.ChartAreas[0].AxisX.IsMarginVisible = false;
            ch_compare.ChartAreas[0].AxisY.Title = "Damage";
            ch_compare.ChartAreas[0].AxisY.TitleForeColor = session.ForeColor;
            ch_compare.ChartAreas[0].AxisY.LineColor = session.ForeColor;
            ch_compare.ChartAreas[0].AxisY.MajorGrid.LineColor = session.BackColor;
            ch_compare.ChartAreas[0].AxisY.LabelStyle.ForeColor = session.ForeColor;
            ch_compare.ChartAreas[0].AxisY.IsMarginVisible = false;
            ch_compare.Palette = ChartColorPalette.BrightPastel;

            weapon_table_source.DataSource = weapon_rows;
            dg_weapon_overview.DataSource = weapon_table_source;

            dg_weapon_overview.Columns["percent"].DisplayIndex = 0;
            dg_weapon_overview.Columns["percent"].ToolTipText = "Percent of total damage";
            dg_weapon_overview.Columns["percent"].HeaderText = "%";
            dg_weapon_overview.Columns["percent"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["percent"].MinimumWidth = 60;
            dg_weapon_overview.Columns["percent"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["percent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["percent"].DefaultCellStyle.Format = "P1";

            dg_weapon_overview.Columns["weapon_name"].DisplayIndex = 1;
            dg_weapon_overview.Columns["weapon_name"].HeaderText = "Weapon Name";
            dg_weapon_overview.Columns["weapon_name"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["weapon_name"].MinimumWidth = 120;
            dg_weapon_overview.Columns["weapon_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["weapon_name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dg_weapon_overview.Columns["total_damage"].DisplayIndex = 2;
            dg_weapon_overview.Columns["total_damage"].ToolTipText = "Total damage to all targets after damage reduction.";
            dg_weapon_overview.Columns["total_damage"].HeaderText = "Dmg";
            dg_weapon_overview.Columns["total_damage"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["total_damage"].MinimumWidth = 80;
            dg_weapon_overview.Columns["total_damage"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["total_damage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["total_damage"].DefaultCellStyle.Format = "N1";

            dg_weapon_overview.Columns["hits"].DisplayIndex = 3;
            dg_weapon_overview.Columns["hits"].ToolTipText = "Total recorded hit count.";
            dg_weapon_overview.Columns["hits"].HeaderText = "Hits";
            dg_weapon_overview.Columns["hits"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["hits"].MinimumWidth = 80;
            dg_weapon_overview.Columns["hits"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["hits"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["hits"].DefaultCellStyle.Format = "N0";

            dg_weapon_overview.Columns["burst_damage"].DisplayIndex = 4;
            dg_weapon_overview.Columns["burst_damage"].ToolTipText = "Damage from last burst";
            dg_weapon_overview.Columns["burst_damage"].HeaderText = "Burst Dmg";
            dg_weapon_overview.Columns["burst_damage"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["burst_damage"].MinimumWidth = 80;
            dg_weapon_overview.Columns["burst_damage"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["burst_damage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["burst_damage"].DefaultCellStyle.Format = "N1";

            dg_weapon_overview.Columns["burst_duration"].DisplayIndex = 5;
            dg_weapon_overview.Columns["burst_duration"].ToolTipText = "Duration of last burst.";
            dg_weapon_overview.Columns["burst_duration"].HeaderText = "Dmg Duration";
            dg_weapon_overview.Columns["burst_duration"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["burst_duration"].MinimumWidth = 100;
            dg_weapon_overview.Columns["burst_duration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["burst_duration"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["burst_duration"].DefaultCellStyle.Format = "N2";

            dg_weapon_overview.Columns["bursts"].DisplayIndex = 6;
            dg_weapon_overview.Columns["bursts"].ToolTipText = "Number of individual bursts";
            dg_weapon_overview.Columns["bursts"].HeaderText = "Bursts";
            dg_weapon_overview.Columns["bursts"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["bursts"].MinimumWidth = 80;
            dg_weapon_overview.Columns["bursts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["bursts"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["bursts"].DefaultCellStyle.Format = "N0";

            dg_weapon_overview.Columns["reload_duration"].DisplayIndex = 7;
            dg_weapon_overview.Columns["reload_duration"].ToolTipText = "Duration of last burst.";
            dg_weapon_overview.Columns["reload_duration"].HeaderText = "Reload Time";
            dg_weapon_overview.Columns["reload_duration"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["reload_duration"].MinimumWidth = 100;
            dg_weapon_overview.Columns["reload_duration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["reload_duration"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["reload_duration"].DefaultCellStyle.Format = "N2";

            dg_weapon_overview.Columns["dps"].DisplayIndex = 8;
            dg_weapon_overview.Columns["dps"].ToolTipText = "Damage per second.";
            dg_weapon_overview.Columns["dps"].HeaderText = "DPS";
            dg_weapon_overview.Columns["dps"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["dps"].MinimumWidth = 110;
            dg_weapon_overview.Columns["dps"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dg_weapon_overview.Columns["dps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dg_weapon_overview.Columns["dps"].DefaultCellStyle.Format = "N1";


            dg_weapon_overview.Columns["first_hit"].Visible = false;
            dg_weapon_overview.Columns["last_hit"].Visible = false;
            dg_weapon_overview.Columns["burst_start"].Visible = false;

            current_total_series.Color = session.ForeColor;
            current_total_series.LabelBackColor = session.BackColor;
            current_total_series.LabelForeColor = session.ForeColor;
            current_total_series.ChartType = SeriesChartType.StepLine;
            current_total_series.Points.Clear();
            current_total_series.Points.AddXY(0, 0);

            //ch_live_feed.Series.Add(new Series("bullshit"));
            //ch_live_feed.Series["bullshit"].IsVisibleInLegend = false;
            //ch_live_feed.Series["bullshit"].ChartType = SeriesChartType.StepLine;
            //ch_live_feed.Series["bullshit"].Points.AddXY(0, 0);
            //ch_live_feed.Series["bullshit"].Points.AddXY(1, 1);


            cmb_trial_type.SelectedItem = "Free Form";
            num_trial_threshold.Enabled = false;
        }

        private void initialize_series(FileTraceManagment.GarageDamageRecord rec)
        {
            string name = Translate.TranslateString(rec.Weapon, session, translations);

            ch_live_feed.Series.Add(new Series(name));
            ch_live_feed.Series[name].LegendText = name;

            if (rec.Flags.Contains("HIGH_RATE_FIRE") || rec.Flags.Contains("CONTINUOUS"))
                ch_live_feed.Series[name].ChartType = SeriesChartType.StepLine;
            else
                ch_live_feed.Series[name].ChartType = SeriesChartType.StepLine;

            ch_live_feed.Series[name].ToolTip = name;
            ch_live_feed.Series[name].LabelBackColor = session.BackColor;
            ch_live_feed.Series[name].LabelForeColor = session.ForeColor;
            ch_live_feed.Series[name].Points.Clear();

        }

        private void add_vertical_annotation(Chart chart, Series series)
        {
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

        private void btn_save_user_settings_Click_1(object sender, EventArgs e)
        {
            if (!ch_compare.Series.Contains(current_total_series))
            {
                current_total_series.LegendText = ch_compare.Series.Count().ToString() + ":" + weapon_totals.OrderByDescending(x => x.total).Select(x => x.weapon).FirstOrDefault();
                ch_compare.Series.Add(current_total_series);
            }
        }

        private void btn_reset_Click_1(object sender, EventArgs e)
        {
            ch_compare.Series.Clear();
        }

        private void garage_view_Resize(object sender, EventArgs e)
        {
            resize.ResizeUserControl(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CO_Driver
{
    public partial class schedule_display : UserControl
    {
        public List<PartLoader.EventTime> event_times = new List<PartLoader.EventTime> { };
        public LogFileManagment.SessionVariables session;
        public Dictionary<string, Dictionary<string, translate.Translation>> translations;
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };
        public Resize resize = new Resize { };

        public schedule_display()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        public void populate_schedule_display(string type)
        {
            foreach (DataGridViewColumn column in dg_build_view_grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.dg_build_view_grid.Rows.Clear();
            this.dg_build_view_grid.AllowUserToAddRows = true;
            if (type == "cw")
                this.lbl_schedule_display_text.Text = string.Format(@"Clan War Schedule {0}", TimeZoneInfo.Local.ToString());
            else
                this.lbl_schedule_display_text.Text = string.Format(@"Brawl Schedule {0}", TimeZoneInfo.Local.ToString());

            for (int i = 0; i < 24; i++)
            {
                DataGridViewRow row = (DataGridViewRow)this.dg_build_view_grid.Rows[0].Clone();
                row.Cells[0].Value = DateTime.Today.AddHours(i).ToString("HH:mm");
                for (int j = 0; j < 7; j++)
                {
                    DateTime cell_time = DateTime.Now.Date.ToLocalTime().AddDays(-(int)DateTime.Now.Date.DayOfWeek + j).AddHours(i);

                    foreach (PartLoader.EventTime event_time in event_times)
                    {
                        if (type == "cw")
                        {
                            if (event_time.EventType != GlobalData.STANDARD_CW && event_time.EventType != GlobalData.LEVIATHIAN_CW)
                                continue;
                        }
                        else
                        {
                            if (event_time.EventType == GlobalData.STANDARD_CW || event_time.EventType == GlobalData.LEVIATHIAN_CW)
                                continue;
                        }

                        DateTime start_time_dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.Date.ToUniversalTime().AddDays(-(int)DateTime.UtcNow.Date.DayOfWeek + (int)event_time.Day).Add(event_time.StartTime), TimeZoneInfo.Local);
                        DateTime end_time_dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow.Date.ToUniversalTime().AddDays(-(int)DateTime.UtcNow.Date.DayOfWeek + (int)event_time.Day).Add(event_time.EndTime), TimeZoneInfo.Local);

                        if ((cell_time >= start_time_dt && cell_time < end_time_dt) ||
                            (cell_time >= start_time_dt.AddDays(7) && cell_time < end_time_dt.AddDays(7)) ||
                            (cell_time >= start_time_dt.AddDays(-7) && cell_time < end_time_dt.AddDays(-7)))
                        {
                            if (event_time.EventType == GlobalData.STANDARD_CW)
                                row.Cells[j + 1].Value = "Standard CW";
                            else
                            if (event_time.EventType == GlobalData.LEVIATHIAN_CW)
                                row.Cells[j + 1].Value = "Leviathan CW";
                            else
                            if (event_time.EventType == GlobalData.BIG_BLACK_SCORPION)
                                row.Cells[j + 1].Value = "Big Black Scorpions";
                            else
                            if (event_time.EventType == GlobalData.STORM_WARNING)
                                row.Cells[j + 1].Value = "Storm Warning";
                            else
                            if (event_time.EventType == GlobalData.WHEEL_RACE)
                                row.Cells[j + 1].Value = "Race(Wheels)";
                            else
                            if (event_time.EventType == GlobalData.HOVER_RACE)
                                row.Cells[j + 1].Value = "Race(Hovers)";
                            else
                            if (event_time.EventType == GlobalData.FREE_FOR_ALL)
                                row.Cells[j + 1].Value = "Free For All";
                            else
                            if (event_time.EventType == GlobalData.BATTLE_ROYALE)
                                row.Cells[j + 1].Value = "Battle Royale";
                            else
                            if (event_time.EventType == GlobalData.CANNON_FODDER)
                                row.Cells[j + 1].Value = "Cannon Fodder";
                            else
                            if (event_time.EventType == GlobalData.HEAD_ON)
                                row.Cells[j + 1].Value = "Head-On!";
                            else
                            if (event_time.EventType == GlobalData.STEEL_CHAMPIONSHIP)
                                row.Cells[j + 1].Value = "Steel Championship";
                            else
                                row.Cells[j + 1].Value = "Undefined Brawl";
                        }
                    }
                }
                row.Cells[8].Value = DateTime.Today.AddHours(i).ToString("HH:mm");
                this.dg_build_view_grid.Rows.Add(row);
            }

            this.dg_build_view_grid.Columns[1].DisplayIndex = 7;

            this.dg_build_view_grid.AllowUserToAddRows = false;

            //sizeDGV(dg_build_view_grid);
        }


        private void schedule_display_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            resize.record_initial_sizes(this);
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dg_build_view_grid[column, row];
            DataGridViewCell cell2 = dg_build_view_grid[column, row - 1];
            if (cell1.Value == null && cell2.Value == null)
            {
                return true;
            }
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dg_build_view_grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != dg_build_view_grid.Rows.Count - 1)
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            if (e.ColumnIndex > 0 && e.ColumnIndex < dg_build_view_grid.Columns.Count - 1 && e.RowIndex >= 0)
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

            if (e.RowIndex == 0)
            {
                e.AdvancedBorderStyle.Top = dg_build_view_grid.AdvancedCellBorderStyle.Top;
            }

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (dg_build_view_grid[e.ColumnIndex, e.RowIndex].Value != null)
            {
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.Single;
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single;
            }

            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;

            bool line_contains_value = false;

            for (int i = 1; i < dg_build_view_grid.Columns.Count; i++)
                if (dg_build_view_grid[i, e.RowIndex].Value != null)
                    line_contains_value = true;

            if (line_contains_value)
                e.AdvancedBorderStyle.Top = dg_build_view_grid.AdvancedCellBorderStyle.Top;

            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;

            }
            else
            {
                e.AdvancedBorderStyle.Top = dg_build_view_grid.AdvancedCellBorderStyle.Top;
            }
        }

        private void dg_build_view_grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;

            }
        }

        void sizeDGV(DataGridView dgv)
        {
            DataGridViewElementStates states = DataGridViewElementStates.None;
            dgv.ScrollBars = ScrollBars.None;
            var totalHeight = dgv.Rows.GetRowsHeight(states) + dgv.ColumnHeadersHeight;
            totalHeight += dgv.Rows.Count * 4;
            var totalWidth = dgv.Columns.GetColumnsWidth(states) + dgv.RowHeadersWidth;
            dgv.ClientSize = new Size(totalWidth, totalHeight);
        }

        private void lbl_schedule_display_text_Click(object sender, EventArgs e)
        {

        }

        private void dg_build_view_grid_Resize(object sender, EventArgs e)
        {
            //sizeDGV(dg_build_view_grid);
        }

        private void schedule_display_Resize(object sender, EventArgs e)
        {
            resize.resize(this);
        }
    }
}
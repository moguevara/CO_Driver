using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CO_Driver
{
    public class Theme
    {
        public class ui_theme
        {
            public string name { get; set; }
            public Color fore_ground { get; set; }
            public Color back_ground { get; set; }
        }

        public static List<ui_theme> themes = new List<ui_theme> {  new ui_theme { name = "Terminal",                    fore_ground = Color.Lime,                    back_ground = Color.Black },
                                                                    new ui_theme { name = "Static",                      fore_ground = Color.FromArgb(245,245,245),   back_ground = Color.Black },
                                                                    new ui_theme { name = "Blabadon",                    fore_ground = Color.FromArgb(235, 117, 55),  back_ground = Color.FromArgb(29,35,40)},
                                                                    new ui_theme { name = "Eris",                        fore_ground = Color.FromArgb(247, 247, 247), back_ground = Color.FromArgb(54, 57, 63) },
                                                                    new ui_theme { name = "Isotope",                     fore_ground = Color.FromArgb(198, 245, 165), back_ground = Color.Black },
                                                                    new ui_theme { name = "Mint Oreo",                   fore_ground = Color.FromArgb(154, 246, 189), back_ground = Color.FromArgb(31, 20, 11) },
                                                                    new ui_theme { name = "S C R O L L",                 fore_ground = Color.FromArgb(171, 171, 171), back_ground = Color.FromArgb(25, 25, 25) },
                                                                    new ui_theme { name = "Ravage",                      fore_ground = Color.FromArgb(245, 21, 118),  back_ground = Color.FromArgb(12, 24, 14) },
                                                                    new ui_theme { name = "Yakuza",                      fore_ground = Color.FromArgb(245, 106, 246), back_ground = Color.FromArgb(0, 16, 36) },
                                                                    new ui_theme { name = "Foiu7dnfr",                   fore_ground = Color.FromArgb(246, 207, 70),  back_ground = Color.FromArgb(18, 18, 18) },
                                                                    new ui_theme { name = "Step on Wolf",                fore_ground = Color.FromArgb(234, 240, 207), back_ground = Color.FromArgb(37, 49, 14) },
                                                                    new ui_theme { name = "Don's Children",              fore_ground = Color.FromArgb(36, 246, 236),  back_ground = Color.FromArgb(31, 24, 6) },
                                                                    new ui_theme { name = "Arson",                       fore_ground = Color.FromArgb(246, 125, 35),  back_ground = Color.FromArgb(27, 10, 10) },
                                                                    new ui_theme { name = "Trucker Cab Best Cab",        fore_ground = Color.FromArgb(246, 195, 35),  back_ground = Color.FromArgb(22, 20, 10) },
                                                                    new ui_theme { name = "It ain't easy being green",   fore_ground = Color.FromArgb(84, 211, 70),   back_ground = Color.FromArgb(22, 20, 10) },
                                                                    new ui_theme { name = "Juicebox",                    fore_ground = Color.FromArgb(156, 151, 166), back_ground = Color.FromArgb(47, 40, 51) },
                                                                    new ui_theme { name = "Nomadic",                     fore_ground = Color.FromArgb(195, 191, 148), back_ground = Color.FromArgb(7, 20, 4) },
                                                                    new ui_theme { name = "Mr. Gusano",                  fore_ground = Color.FromArgb(253, 255, 255), back_ground = Color.FromArgb(39, 86, 78) },
                                                                    new ui_theme { name = "Slava Ukraini!",              fore_ground = Color.FromArgb(255, 215, 0),   back_ground = Color.FromArgb(0, 87, 183) },
                                                                    new ui_theme { name = "Hexagonis",                   fore_ground = Color.FromArgb(219, 173, 80),  back_ground = Color.FromArgb(37, 40, 60) },
                                                                    new ui_theme { name = "Split Push Toads",            fore_ground = Color.FromArgb(33, 95, 73),    back_ground = Color.FromArgb(248, 250, 229) },
                                                                    new ui_theme { name = "Soaring Potential",           fore_ground = Color.FromArgb(102, 0, 0),     back_ground = Color.FromArgb(230, 230, 230) }

                                                                 };


        public void apply_theme(Control user_control, LogFileManagment.SessionVariables session)
        {
            for_each_control(user_control, session);
        }

        private void for_each_control(Control parent, LogFileManagment.SessionVariables session)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.ForeColor = session.ForeColor;
                ctrl.BackColor = session.BackColor;

                if (ctrl is DataGridView)
                    style_data_grid_view(((DataGridView)ctrl), session);

                if (ctrl is Chart)
                    style_chart(((Chart)ctrl), session);

                if (ctrl is LinkLabel)
                    style_link(((LinkLabel)ctrl), session);

                if (ctrl is ProgressBar)
                    style_progressbar(((ProgressBar)ctrl), session);

                for_each_control(ctrl, session);
            }
            parent.ForeColor = session.ForeColor;
            parent.BackColor = session.BackColor;
        }

        private void style_progressbar(ProgressBar pb, LogFileManagment.SessionVariables session)
        {
        }

        private void style_link(LinkLabel link, LogFileManagment.SessionVariables session)
        {
            link.ActiveLinkColor = session.ForeColor;
            link.DisabledLinkColor = session.ForeColor;
            link.LinkColor = session.ForeColor;
        }


        private void style_chart(Chart chart, LogFileManagment.SessionVariables session)
        {
            foreach (Legend leg in chart.Legends)
            {
                leg.ForeColor = session.ForeColor;
                leg.BackColor = session.BackColor;
                leg.TitleForeColor = session.ForeColor;
                leg.TitleBackColor = session.BackColor;
            }

            foreach (ChartArea area in chart.ChartAreas)
            {
                area.BackColor = session.BackColor;

                area.AxisX.TitleForeColor = session.ForeColor;
                area.AxisX.LineColor = session.ForeColor;
                area.AxisX.InterlacedColor = session.ForeColor;
                area.AxisX.MajorGrid.LineColor = session.BackColor;
                area.AxisX.LabelStyle.ForeColor = session.ForeColor;

                area.AxisX2.TitleForeColor = session.ForeColor;
                area.AxisX2.LineColor = session.ForeColor;
                area.AxisX2.InterlacedColor = session.ForeColor;
                area.AxisX2.MajorGrid.LineColor = session.BackColor;
                area.AxisX2.LabelStyle.ForeColor = session.ForeColor;

                area.AxisY.TitleForeColor = session.ForeColor;
                area.AxisY.LineColor = session.ForeColor;
                area.AxisY.InterlacedColor = session.ForeColor;
                area.AxisY.MajorGrid.LineColor = session.BackColor;
                area.AxisY.LabelStyle.ForeColor = session.ForeColor;

                area.AxisY2.TitleForeColor = session.ForeColor;
                area.AxisY2.LineColor = session.ForeColor;
                area.AxisY2.InterlacedColor = session.ForeColor;
                area.AxisY2.MajorGrid.LineColor = session.BackColor;
                area.AxisY2.LabelStyle.ForeColor = session.ForeColor;
            }
        }


        private void style_data_grid_view(DataGridView dgv, LogFileManagment.SessionVariables session)
        {
            dgv.GridColor = session.ForeColor;
            dgv.BackgroundColor = session.BackColor;
            dgv.DefaultCellStyle.ForeColor = session.ForeColor;
            dgv.DefaultCellStyle.BackColor = session.BackColor;
            dgv.DefaultCellStyle.SelectionForeColor = session.BackColor;
            dgv.DefaultCellStyle.SelectionBackColor = session.ForeColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = session.ForeColor;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = session.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = session.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = session.ForeColor;
            dgv.RowHeadersDefaultCellStyle.ForeColor = session.ForeColor;
            dgv.RowHeadersDefaultCellStyle.BackColor = session.BackColor;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = session.BackColor;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = session.ForeColor;
            dgv.RowsDefaultCellStyle.ForeColor = session.ForeColor;
            dgv.RowsDefaultCellStyle.BackColor = session.BackColor;
            dgv.RowsDefaultCellStyle.SelectionForeColor = session.BackColor;
            dgv.RowsDefaultCellStyle.SelectionBackColor = session.ForeColor;
            dgv.RowTemplate.DefaultCellStyle.ForeColor = session.ForeColor;
            dgv.RowTemplate.DefaultCellStyle.BackColor = session.BackColor;
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = session.BackColor;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = session.ForeColor;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.ForeColor = session.ForeColor;
                    cell.Style.BackColor = session.BackColor;
                    cell.Style.SelectionForeColor = session.BackColor;
                    cell.Style.SelectionBackColor = session.ForeColor;
                }
            }
        }
    }
}

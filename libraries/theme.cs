using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CO_Driver
{
    public class Theme
    {
        public class UITheme
        {
            public string Name { get; set; }
            public Color ForeGround { get; set; }
            public Color BackGround { get; set; }
        }

        public static List<UITheme> themes = new List<UITheme> {  new UITheme { Name = "Terminal",                      ForeGround = Color.Lime,                    BackGround = Color.Black },
                                                                    new UITheme { Name = "Static",                      ForeGround = Color.FromArgb(245,245,245),   BackGround = Color.Black },
                                                                    new UITheme { Name = "Blabadon",                    ForeGround = Color.FromArgb(235, 117, 55),  BackGround = Color.FromArgb(29,35,40)},
                                                                    new UITheme { Name = "Eris",                        ForeGround = Color.FromArgb(247, 247, 247), BackGround = Color.FromArgb(54, 57, 63) },
                                                                    new UITheme { Name = "Isotope",                     ForeGround = Color.FromArgb(198, 245, 165), BackGround = Color.Black },
                                                                    new UITheme { Name = "Mint Oreo",                   ForeGround = Color.FromArgb(154, 246, 189), BackGround = Color.FromArgb(31, 20, 11) },
                                                                    new UITheme { Name = "S C R O L L",                 ForeGround = Color.FromArgb(171, 171, 171), BackGround = Color.FromArgb(25, 25, 25) },
                                                                    new UITheme { Name = "Ravage",                      ForeGround = Color.FromArgb(245, 21, 118),  BackGround = Color.FromArgb(12, 24, 14) },
                                                                    new UITheme { Name = "Yakuza",                      ForeGround = Color.FromArgb(245, 106, 246), BackGround = Color.FromArgb(0, 16, 36) },
                                                                    new UITheme { Name = "Foiu7dnfr",                   ForeGround = Color.FromArgb(246, 207, 70),  BackGround = Color.FromArgb(18, 18, 18) },
                                                                    new UITheme { Name = "Step on Wolf",                ForeGround = Color.FromArgb(234, 240, 207), BackGround = Color.FromArgb(37, 49, 14) },
                                                                    new UITheme { Name = "Don's Children",              ForeGround = Color.FromArgb(36, 246, 236),  BackGround = Color.FromArgb(31, 24, 6) },
                                                                    new UITheme { Name = "Arson",                       ForeGround = Color.FromArgb(246, 125, 35),  BackGround = Color.FromArgb(27, 10, 10) },
                                                                    new UITheme { Name = "Trucker Cab Best Cab",        ForeGround = Color.FromArgb(246, 195, 35),  BackGround = Color.FromArgb(22, 20, 10) },
                                                                    new UITheme { Name = "It ain't easy being green",   ForeGround = Color.FromArgb(84, 211, 70),   BackGround = Color.FromArgb(22, 20, 10) },
                                                                    new UITheme { Name = "Juicebox",                    ForeGround = Color.FromArgb(156, 151, 166), BackGround = Color.FromArgb(47, 40, 51) },
                                                                    new UITheme { Name = "Nomadic",                     ForeGround = Color.FromArgb(195, 191, 148), BackGround = Color.FromArgb(7, 20, 4) },
                                                                    new UITheme { Name = "Mr. Gusano",                  ForeGround = Color.FromArgb(253, 255, 255), BackGround = Color.FromArgb(39, 86, 78) },
                                                                    new UITheme { Name = "Slava Ukraini!",              ForeGround = Color.FromArgb(255, 215, 0),   BackGround = Color.FromArgb(0, 87, 183) },
                                                                    new UITheme { Name = "Hexagonis",                   ForeGround = Color.FromArgb(219, 173, 80),  BackGround = Color.FromArgb(37, 40, 60) },
                                                                    new UITheme { Name = "Split Push Toads",            ForeGround = Color.FromArgb(33, 95, 73),    BackGround = Color.FromArgb(248, 250, 229) },
                                                                    new UITheme { Name = "Soaring Potential",           ForeGround = Color.FromArgb(102, 0, 0),     BackGround = Color.FromArgb(230, 230, 230) },
                                                                    new UITheme { Name = "Cactus",                      ForeGround = Color.FromArgb(153, 153, 102), BackGround = Color.FromArgb(51, 102, 0) },
                                                                    new UITheme { Name = "Verde Nuevo",                 ForeGround = Color.FromArgb(219, 222, 193), BackGround = Color.FromArgb(21, 27, 26) },
                                                                    new UITheme { Name = "Mustard Coral",               ForeGround = Color.FromArgb(160, 111, 35),  BackGround = Color.FromArgb(165, 55, 62) },

                                                                 };


        public void ApplyTheme(Control userControl, LogFileManagment.SessionVariables session)
        {
            ForEachControl(userControl, session);
        }

        private void ForEachControl(Control parent, LogFileManagment.SessionVariables session)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.ForeColor = session.ForeColor;
                ctrl.BackColor = session.BackColor;

                if (ctrl is DataGridView)
                    StyleDataGridView(((DataGridView)ctrl), session);

                if (ctrl is Chart)
                    StyleChart(((Chart)ctrl), session);

                if (ctrl is LinkLabel)
                    StyleLink(((LinkLabel)ctrl), session);

                if (ctrl is ProgressBar)
                    StyleProgressBar(((ProgressBar)ctrl), session);

                ForEachControl(ctrl, session);
            }
            parent.ForeColor = session.ForeColor;
            parent.BackColor = session.BackColor;
        }

        private void StyleProgressBar(ProgressBar pb, LogFileManagment.SessionVariables session)
        {
        }

        private void StyleLink(LinkLabel link, LogFileManagment.SessionVariables session)
        {
            link.ActiveLinkColor = session.ForeColor;
            link.DisabledLinkColor = session.ForeColor;
            link.LinkColor = session.ForeColor;
        }


        private void StyleChart(Chart chart, LogFileManagment.SessionVariables session)
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


        private void StyleDataGridView(DataGridView dgv, LogFileManagment.SessionVariables session)
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

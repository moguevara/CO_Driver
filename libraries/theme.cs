using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.Net;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;
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
                                                                    new ui_theme { name = "Soaring Potential",           fore_ground = Color.FromArgb(102, 0, 0),     back_ground = Color.FromArgb(230, 230, 230) }

                                                                 };


        public void apply_theme(Control user_control, log_file_managment.session_variables session)
        {
            for_each_control(user_control, session);
        }

        private void for_each_control(Control parent, log_file_managment.session_variables session)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.ForeColor = session.fore_color;
                ctrl.BackColor = session.back_color;

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
            parent.ForeColor = session.fore_color;
            parent.BackColor = session.back_color;
        }

        private void style_progressbar(ProgressBar pb, log_file_managment.session_variables session)
        {
        }

        private void style_link(LinkLabel link, log_file_managment.session_variables session)
        {
            link.ActiveLinkColor = session.fore_color;
            link.DisabledLinkColor = session.fore_color;
            link.LinkColor = session.fore_color;
        }
        

        private void style_chart(Chart chart, log_file_managment.session_variables session)
        {
            foreach (Legend leg in chart.Legends)
            {
                leg.ForeColor = session.fore_color;
                leg.BackColor = session.back_color;
                leg.TitleForeColor = session.fore_color;
                leg.TitleBackColor = session.back_color;
            }

            foreach (ChartArea area in chart.ChartAreas)
            {
                area.BackColor = session.back_color;

                area.AxisX.TitleForeColor = session.fore_color;
                area.AxisX.LineColor = session.fore_color;
                area.AxisX.InterlacedColor = session.fore_color;
                area.AxisX.MajorGrid.LineColor = session.back_color;
                area.AxisX.LabelStyle.ForeColor = session.fore_color;

                area.AxisX2.TitleForeColor = session.fore_color;
                area.AxisX2.LineColor = session.fore_color;
                area.AxisX2.InterlacedColor = session.fore_color;
                area.AxisX2.MajorGrid.LineColor = session.back_color;
                area.AxisX2.LabelStyle.ForeColor = session.fore_color;

                area.AxisY.TitleForeColor = session.fore_color;
                area.AxisY.LineColor = session.fore_color;
                area.AxisY.InterlacedColor = session.fore_color;
                area.AxisY.MajorGrid.LineColor = session.back_color;
                area.AxisY.LabelStyle.ForeColor = session.fore_color;

                area.AxisY2.TitleForeColor = session.fore_color;
                area.AxisY2.LineColor = session.fore_color;
                area.AxisY2.InterlacedColor = session.fore_color;
                area.AxisY2.MajorGrid.LineColor = session.back_color;
                area.AxisY2.LabelStyle.ForeColor = session.fore_color;
            }
        }


        private void style_data_grid_view(DataGridView dgv, log_file_managment.session_variables session)
        {
            dgv.GridColor = session.fore_color;
            dgv.BackgroundColor = session.back_color;
            dgv.DefaultCellStyle.ForeColor = session.fore_color;
            dgv.DefaultCellStyle.BackColor = session.back_color;
            dgv.DefaultCellStyle.SelectionForeColor = session.back_color;
            dgv.DefaultCellStyle.SelectionBackColor = session.fore_color;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = session.fore_color;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = session.back_color;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = session.back_color;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = session.fore_color;
            dgv.RowHeadersDefaultCellStyle.ForeColor = session.fore_color;
            dgv.RowHeadersDefaultCellStyle.BackColor = session.back_color;
            dgv.RowHeadersDefaultCellStyle.SelectionForeColor = session.back_color;
            dgv.RowHeadersDefaultCellStyle.SelectionBackColor = session.fore_color;
            dgv.RowsDefaultCellStyle.ForeColor = session.fore_color;
            dgv.RowsDefaultCellStyle.BackColor = session.back_color;
            dgv.RowsDefaultCellStyle.SelectionForeColor = session.back_color;
            dgv.RowsDefaultCellStyle.SelectionBackColor = session.fore_color;
            dgv.RowTemplate.DefaultCellStyle.ForeColor = session.fore_color;
            dgv.RowTemplate.DefaultCellStyle.BackColor = session.back_color;
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = session.back_color;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = session.fore_color;

            foreach (DataGridViewRow row in dgv.Rows) 
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.ForeColor = session.fore_color;
                    cell.Style.BackColor = session.back_color;
                    cell.Style.SelectionForeColor = session.back_color;
                    cell.Style.SelectionBackColor = session.fore_color;
                }
            }
        }
    }
}

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
    public class theme
    {
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

                for_each_control(ctrl, session);
            }
            parent.ForeColor = session.fore_color;
            parent.BackColor = session.back_color;
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

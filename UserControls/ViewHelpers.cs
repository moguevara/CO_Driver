using System;
using System.Windows.Forms;

namespace CO_Driver
{
    class ViewHelpers
    {
        public static void SetMomentFormatForTimeSpanCell(DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.Format = @"s\s";
            e.FormattingApplied = false;

            Type t = e.Value.GetType();

            if ((double)t.GetProperty("TotalDays").GetValue(e.Value, null) >= 1)
            {
                e.CellStyle.Format = @"d\d\ h\h\ m\m\ s\s";
            }
            else
            if ((double)t.GetProperty("TotalHours").GetValue(e.Value, null) >= 1)
            {
                e.CellStyle.Format = @"h\h\ m\m\ s\s";
            }
            else
            if ((double)t.GetProperty("TotalMinutes").GetValue(e.Value, null) >= 1)
            {
                e.CellStyle.Format = @"m\m\ s\s";
            }
        }

        public static String GetMomentFormatFromSeconds(double seconds)
        {
            String format = @"s\s";

            TimeSpan ts = TimeSpan.FromSeconds(seconds);

            if (ts.TotalDays >= 1)
            {
                format = @"d\d\ h\h\ m\m\ s\s";
            }
            else
            if (ts.TotalHours >= 1)
            {
                format = @"h\h\ m\m\ s\s";
            }
            else
            if (ts.TotalMinutes >= 1)
            {
                format = @"m\m\ s\s";
            }

            return ts.ToString(format);
        }
    }

}

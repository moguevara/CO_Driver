using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using RFB_Tool_Suite.Properties;
using System.IO;
using System.Data.SQLite;

namespace RFB_Tool_Suite
{
    public partial class trace_view : UserControl
    {
        public trace_view(string trace_type)
        {
            InitializeComponent();
            this.lbl_trace_name.Text = string.Format(@"{0}.log Trace", trace_type);
            this.bw_file_tracer.RunWorkerAsync();
        }
        private void bw_trace_file(object sender, DoWorkEventArgs event_args)
        {
            string trace_type = this.lbl_trace_name.Text.Split(' ').First().ToLower();
            FileInfo trace_file = new DirectoryInfo(Settings.Default["log_file_location"].ToString()).GetFiles(trace_type, SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();

            AutoResetEvent wh = new AutoResetEvent(false);
            FileSystemWatcher fsw = new FileSystemWatcher(".");
            fsw.Filter = trace_file.FullName;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();
            string data_return = "";

            FileStream fs = new FileStream(trace_file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader sr = new StreamReader(fs))
            {
                string s = "";
                while (bw_file_tracer.CancellationPending == false)
                {
                    s = sr.ReadLine();
                    if (s != null)
                    {
                        data_return += string.Format(@"{0}{1}",s,Environment.NewLine);
                        if (data_return.Length + s.Length > 50000)
                        {
                            bw_file_tracer.ReportProgress(0, data_return);
                            data_return = "";
                        }
                    }
                    else
                    {
                        if (data_return.Length > 0) {
                            bw_file_tracer.ReportProgress(0, data_return);
                            data_return = "";
                        }
                        System.Threading.Thread.Sleep(1000);
                    }

                }
            }
            fs.Dispose();
            fsw.Dispose();
            wh.Dispose();
        }

        private void bw_cancel_trace(object sender, RunWorkerCompletedEventArgs e)
        {
            bw_file_tracer.CancelAsync();
        }

        private void bw_write_trace(object sender, ProgressChangedEventArgs e)
        {
            this.tb_trace_output.AppendText(e.UserState as string);
        }

        private void trace_view_Leave(object sender, EventArgs e)
        {
            bw_file_tracer.CancelAsync();
        }
    }
}

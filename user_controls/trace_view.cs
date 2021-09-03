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
using System.IO;

namespace CO_Driver
{
    public partial class trace_view : UserControl
    {
        bool restart_background_worker = false;
        private log_file_managment.session_variables local_session_variables = new log_file_managment.session_variables { };
        public Dictionary<string, Dictionary<string, string>> ui_translations = new Dictionary<string, Dictionary<string, string>> { };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Disposed += OnDispose;
        }

        public trace_view(string trace_type, log_file_managment.session_variables session)
        {
            InitializeComponent();

            local_session_variables = session;

            this.lbl_trace_name.Text = string.Format(@"{0}.log Trace", trace_type);

            FileInfo trace_file;

            try
            {
                trace_file = new DirectoryInfo(session.log_file_location).GetFiles(trace_type + "*.log", SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
            }
            catch (Exception ex)
            {
                this.lbl_current_file_name.Text = string.Format(@"File ""{0}.log"" not found at path  ""{1}"". Please check path in settings.", trace_type, local_session_variables.log_file_location);
                return;
            }

            this.lbl_current_file_name.Text = string.Format(@"Tracing File ""{0}""",trace_file.FullName);
            this.bw_file_tracer.RunWorkerAsync();
            
        }
        private void bw_trace_file(object sender, DoWorkEventArgs event_args)
        {
            if (bw_file_tracer.CancellationPending == true)
                return;

            string trace_type = this.lbl_trace_name.Text.Split(' ').First().ToLower();
            FileInfo trace_file = new DirectoryInfo(local_session_variables.log_file_location).GetFiles(trace_type, SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();

            AutoResetEvent wh = new AutoResetEvent(false);
            FileSystemWatcher fsw = new FileSystemWatcher(".");
            fsw.Filter = trace_file.FullName;
            fsw.EnableRaisingEvents = true;
            fsw.Changed += (s, e) => wh.Set();
            string data_return = "";
            long start_time = DateTime.Now.Ticks;

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
                            start_time = DateTime.Now.Ticks;
                        }
                        if (new TimeSpan(DateTime.Now.Ticks - start_time).TotalSeconds > 30)
                        {
                            FileInfo most_recent_trace_file = new DirectoryInfo(local_session_variables.log_file_location).GetFiles(trace_type, SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
                            if (trace_file.FullName != most_recent_trace_file.FullName)
                            {
                                bw_file_tracer.CancelAsync();
                                restart_background_worker = true;
                            }
                            start_time = DateTime.Now.Ticks;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }

                }
            }
            fs.Dispose();
            fsw.Dispose();
            wh.Dispose();
        }
        private void bw_write_trace(object sender, ProgressChangedEventArgs e)
        {
            this.tb_trace_output.AppendText(e.UserState as string);
        }

        private void trace_view_Leave(object sender, EventArgs e)
        {
            bw_file_tracer.CancelAsync();
            this.tb_trace_output.Clear();
        }

        private void bw_work_complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (restart_background_worker)
            {
                restart_background_worker = false;

                string trace_type = this.lbl_trace_name.Text.Split(' ').First().ToLower();
                FileInfo trace_file = new DirectoryInfo(local_session_variables.log_file_location).GetFiles(trace_type, SearchOption.AllDirectories).OrderByDescending(p => p.CreationTime).ToArray().First();
                this.lbl_current_file_name.Text = string.Format(@"Tracing File ""{0}""", trace_file.FullName);

                bw_file_tracer.RunWorkerAsync();
            }
        }

        private void OnDispose(object sender, EventArgs e)
        {
            bw_file_tracer.CancelAsync();
            this.tb_trace_output.Clear();
        }
    }
}

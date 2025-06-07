using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shell;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace VideoDownloader
{
    internal partial class downloaing_form : Form
    {

        VideoInformation videoInformation;
        string formatId;
        string audioFormatId;
        string output_file;
        Downloader d;
        public downloaing_form(VideoInformation vi, string formatId, string output_file, string audioFormatId=null)
        {
            InitializeComponent();
            TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            
            videoInformation = vi;
            this.formatId = formatId;
            this.audioFormatId = audioFormatId;
            this.output_file = output_file;
            label1.Text = vi.FileName;
            label2.Text = vi.FileSize.ToString();
            label4.Text = "Download Location: " + output_file;
            lb_status.Text = "Downloading";
            d = new Downloader(vi);
            d.OnProgressChanged += (sender, progress) =>
            {
                SetProgress(d.Progress);
                SetStatus(d.Speed + " " + d.ETA);
            };

            d.OnDownloadCompleted += (sender, status) =>
            {
                SetStatus("Success");
                SetProgress(100);
            };

            d.OnErrorOccurred += (sender, status) =>
            {
                SetStatus("Error");
                SetProgress(100);
                try
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                }
                catch (Exception ex)
                {
                    // do nothing
                }
            };

            Thread thread = new Thread(StartDownload);
            thread.Start();
        }


        private void StartDownload()
        {
            
            d.start(formatId, output_file, audioFormatId);
            try
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            }
            catch (Exception ex)
            {
                // do nothing
            }
        }
        public void SetProgress(int progress)
        {
            this.Invoke(() =>
            {
                progressBar1.Value = progress;
                try
                {
                    TaskbarManager.Instance.SetProgressValue(progress, 100);
                }
                catch (Exception ex)
                {
                    // do nothing
                }
            });
        }


        public void SetStatus(string status)
        {
            this.Invoke(() =>
            {
                lb_status.Text = status;
                if (status.Contains("Error") || status.Contains("Success"))
                {
                    button1.Text = "Close";
                    
                }
                if (status.Contains("Error"))
                {
                    // red
                    progressBar1.ForeColor = Color.Red;
                }
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void downloaing_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (d != null && d.isDownloading())
            {
                d.stop();
            }

            try
            {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
            }
            catch (Exception ex)
            {
                // do nothing
            }
        }
    }
}

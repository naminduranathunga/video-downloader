using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace VideoDownloader
{
    internal class Downloader
    {
        // events
        // set status
        //public event EventHandler<string> StatusChanged;
        public event EventHandler<string> OnErrorOccurred = null;
        public event EventHandler<string> OnDownloadCompleted = null;
        public event EventHandler<int> OnProgressChanged = null;

        private Process youtubeDl = null;
        private System.Threading.Thread downloadingThread = null;
        private VideoInformation videoInformation = null;


        public string ETA = "";
        public string Speed = "";
        public int Progress = 0;

        public Downloader(VideoInformation iv)
        {
            this.ETA = "";
            this.Speed = "";
            this.Progress = 0;
            videoInformation = iv;
        }
        public void start(string formatId, string output_file, string audioFormatId=null)
        {

            string dlp_path = AppDomain.CurrentDomain.BaseDirectory + "yp-dlp\\yt-dlp.exe";
            string ffmpeg_path = AppDomain.CurrentDomain.BaseDirectory + "ffmpeg\\ffmpeg.exe";
            string ffmpeg_args = "";

            if (audioFormatId != null)
            {
                formatId += "+" + audioFormatId;
                ffmpeg_args = " --ffmpeg-location \"" + ffmpeg_path + "\" ";
            }

            string args = "--no-warnings --quiet --progress --format \"" + formatId + "\" --output \"" + output_file + "\" " + ffmpeg_args + videoInformation.Url;
            youtubeDl = new Process();
            youtubeDl.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            youtubeDl.StartInfo.FileName = dlp_path;
            youtubeDl.StartInfo.Arguments = args;
            youtubeDl.StartInfo.UseShellExecute = false;
            youtubeDl.StartInfo.RedirectStandardOutput = true;
            youtubeDl.StartInfo.CreateNoWindow = true;
            youtubeDl.OutputDataReceived += (sender, args) =>
            {
                try
                {
                    if (args.Data == null)
                    {
                        return;
                    }
                    //Console.WriteLine(args.Data);
                    // Save the data to a temp file
                    
                    if (args.Data.Contains("[download]"))
                    {
                        string pattern = @"(?<progress>\d+\.\d+)%.*at\s+(?<speed>\d+\.\d+KiB/s)\s+ETA\s+(?<eta>\d{2}:\d{2})";

                        Match match = Regex.Match(args.Data, pattern);

                        if (match.Success)
                        {
                            string progress_s = match.Groups["progress"].Value;
                            Speed = match.Groups["speed"].Value;
                            ETA = match.Groups["eta"].Value;
                            Progress = (int)(float.Parse(progress_s));
                            OnProgressChanged?.Invoke(this, Progress);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //df.SetStatus(ex.Message);
                    OnErrorOccurred?.Invoke(this, ex.Message);
                }
            };
            youtubeDl.Start();
            youtubeDl.BeginOutputReadLine();


            youtubeDl.WaitForExit();
            int exitCode = youtubeDl.ExitCode;
            if (exitCode != 0)
            {
                OnErrorOccurred?.Invoke(this, "Error downloading video: " + exitCode);
            }
            else
            {
                OnDownloadCompleted?.Invoke(this, "Success");
                //df.SetStatus("Success");
            }
            youtubeDl = null;
        }

        public bool isDownloading()
        {
            return (youtubeDl != null && !youtubeDl.HasExited);
        }

        public void stop()
        {
            if (this.isDownloading())
            {
                youtubeDl.Kill();
            }
        }
    }
}

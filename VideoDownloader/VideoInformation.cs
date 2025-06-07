using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebPWrapper;


namespace VideoDownloader
{
    internal class VideoInformation
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string ThumbnailUrl { get; set; }
        public string FileName { get; set; }
        public string fileTypes { get; set; }
        public int FileSize { get; set; }
        public bool isLoaded = false;

        public Image thumbnail = null;
        Thread downloadingThread = null;
        Process downladingProcess = null;
        

        public FileFormats[] fileFormats { get; set; }

        // events
        // set status
        public event EventHandler<string> StatusChanged;
        public event EventHandler<string> ErrorOccurred;
        public event EventHandler<int> ProgressChanged;
        // set progress

        // constructor
        public VideoInformation(string url)
        {

            Url = url;
            Title = "";
            ThumbnailUrl = "";
            FileName = "";
            fileTypes = "";
            FileSize = 0;
            fileFormats = new FileFormats[0];
        }

        public void LoadInformation()
        {
            // load information from the URL 
            // create a new process
            // example ./yt-dlp --no-warnings --get-title --get-filename --get-thumbnail https://www.youtube.com/watch?v=x08Q0bcSSdQ
            // example ./yt-dlp --no-warnings --list-formats https://www.youtube.com/watch?v=x08Q0bcSSdQ
            string debug_path = AppDomain.CurrentDomain.BaseDirectory + "yp-dlp\\yt-dlp.exe";
            Process youtubeDl = new Process();
            youtubeDl.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            youtubeDl.StartInfo.FileName = debug_path;
            youtubeDl.StartInfo.Arguments = " --dump-json --no-warnings --simulate " + Url;
            youtubeDl.StartInfo.UseShellExecute = false;
            youtubeDl.StartInfo.RedirectStandardOutput = true;
            youtubeDl.StartInfo.RedirectStandardError = true;
            youtubeDl.StartInfo.CreateNoWindow = true;
            youtubeDl.Start();
            string output = "";
            using (StreamReader reader = new StreamReader(youtubeDl.StandardOutput.BaseStream, Encoding.UTF8))
            {
                output = reader.ReadToEnd();
                Console.WriteLine(output); // This should retain the Unicode characters
            }

            youtubeDl.WaitForExit();

            // read the output
            //string output = youtubeDl.StandardOutput.ReadToEnd();
            int exitCode = youtubeDl.ExitCode;
            if (exitCode != 0)
            {
                string stdError = youtubeDl.StandardError.ReadToEnd();
                throw new Exception("Error getting video information: " + stdError);
            }

            // parse JSON
            dynamic json = JsonConvert.DeserializeObject(output);

            Title = json["title"];
            ThumbnailUrl = json["thumbnail"];
            FileName = json["_filename"] != null ? json["_filename"]:"untitled";
            //fileTypes = json["formats"];
            try
            {
                FileSize = json["filesize"] != null ? json["filesize"] : 0;
            } catch (Exception ex)
            {
                FileSize = 0;
            }
            // parse formats
            List<FileFormats> formats = new List<FileFormats>();
            foreach (dynamic format in json["formats"])
            {
                formats.Add(new FileFormats(format));
            }
            fileFormats = formats.ToArray();

            DownloadImage();

            isLoaded = true;
        }

        void DownloadImage()
        {
            if (ThumbnailUrl == "")
            {
                return;
            }

            // load file from url
            WebRequest request = WebRequest.CreateHttp(ThumbnailUrl);

            using (WebResponse response = request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (ThumbnailUrl.Contains(".webp") || response.ContentType.Contains("webp"))
                {
                    //WebPTest
                    try
                    {
                        stream.CopyTo(memoryStream);
                        byte[] buffer = memoryStream.ToArray();


                        WebP webp = new WebP();
                        // byte[] buffer = new byte[response.ContentLength];
                        stream.Read(buffer, 0, buffer.Length);

                        //DEBUG Save to file
                        webp.Save(webp.Decode(buffer), "thumbnail.webp");

                        thumbnail = webp.Decode(buffer);
                    }
                    catch (Exception ex)
                    {
                        thumbnail = null;
                    }
                }
                else
                {
                    try
                    {
                        thumbnail = Bitmap.FromStream(stream);
                    }
                    catch (Exception ex)
                    {
                        thumbnail = null;
                    }
                }
            }
        }

        public void Download(string formatId, string output_file)
        {
            downloaing_form df = new downloaing_form(this, formatId, output_file);
            df.Show();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDownloader
{

    internal class FileFormats
    {
        string[] units = { "B", "KB", "MB", "GB", "TB" };
        public string FormatId { get; set; }
        public int Size { get; set; }

        // @deprecated
        public bool AudioOnly { get; set; }
        public bool hasAudio { get; set; } // if the format has audio
        public bool hasVideo { get; set; } // if the format has audio
        public string Extension { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public string FormatText { get; set; }

        public FileFormats()
        {
            FormatId = "";
            Size = 0;
            AudioOnly = false;
            Extension = "";
            height = 0;
            width = 0;
            FormatText = "";
        }

        public FileFormats(dynamic format)
        {
            FormatId = format.format_id;
            Size = format.filesize == null ? 0:format.filesize;
            AudioOnly = format.resolution == "audio only"; // Depriciated
            hasAudio = (format.acodec != null && format.acodec != "none");
            hasVideo = (format.vcodec != null && format.vcodec != "none");
            Extension = format.ext;
            height = format.height == null ? 0 : format.height; ;
            width = format.width == null ? 0 : format.width; ;
            FormatText = format.format;
        }

        public string sizeStr()
        {
            int u = 0;
            int size = this.Size;
            while( size > 1024 && u < 5)
            {
                size = size / 1024;
                u++;
            }
            return size + " " + units[u];
        }

        public override string ToString()
        {
            string output = FormatText;
            if (AudioOnly)
            {
                output += " (Audio Only)";
            }

            output += " - " + sizeStr();
            output += " - " + FormatId;
            return output;
        }


        // Check weather audio or video or both are available
        public String getAvState()
        {
            if (this.hasVideo && this.hasAudio)
            {
                return "Video + Audio";
            }
            if (this.hasVideo)
            {
                return "Video Only";
            }
            return "Audio Only";
        }
    }
}

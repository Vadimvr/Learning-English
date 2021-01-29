using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models
{
    class PathToMultimedia
    {
        public string PathImg { get; set; }
        public string PathSong { get; set; }
        public PathToMultimedia(string EngWord, string path)
        {
            PathImg = path + @"img\" + EngWord + ".jpg";
            PathSong = path + @"song\" + EngWord + ".mp3";
        }
    }
}

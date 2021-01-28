using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models
{
    class PathToMultimedia
    {
        public string PathImg { get; set; }
        public string PathSong { get; set; }
        public PathToMultimedia(string id, string path)
        {
            PathImg = path + @"\img\" + id + ".jpg";
            PathSong = path + @"\song\" + id + ".mp3";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models
{
    class PathImgAndSong
    {
        public string PathImg { get; set; }
        public string PathSong { get; set; }
        public PathImgAndSong(string id, string path)
        {
            PathImg = path + @"/img/" + id + ".jpg";
            PathSong = path + @"/song/" + id + ".mp3";
        }
    }
}

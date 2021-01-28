using LElWPF.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models
{
    public class PathToMultimedia__Test 
    {
        PathToMultimedia _PathToMultimedia;
        public PathToMultimedia__Test(string id, string path)
        {
            _PathToMultimedia = new PathToMultimedia(id, path);
        }
        public string PathSong { get => _PathToMultimedia.PathSong; }
        public string PathImg { get => _PathToMultimedia.PathImg; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LElWPF.Core.Models
{
    class TextDataPathToPictureAndTrack
    {
        string  Id { get; set; }
        public string  WordRus { get;private set; }
        public string WordEng { get;private set; }
        public string Song { get; private set; }
        public string Img { get; private set; }

        PathImgAndSong pathImgAnd;
        public TextDataPathToPictureAndTrack(string stringFromDB, string path)
        {
            CredeData(stringFromDB, path);
        }

        public void CredeData(string stringFromDB, string path)
        {
            int temp = 0;
            for (int i = 0; i < stringFromDB.Length; i++)
            {
                if(stringFromDB[i] == '\t' && Id == null)
                {
                    Id = stringFromDB.Substring(temp, i);
                    temp = i+1;
                }
                else if(stringFromDB[i] == '\t' && WordRus == null)
                {
                    WordRus= stringFromDB.Substring(0, i);
                    temp = i+1;
                    break;
                }
            }
            pathImgAnd = new PathImgAndSong(Id, path);
            Song = pathImgAnd.PathSong;
            Img = pathImgAnd.PathImg;
            WordEng = stringFromDB.Substring(temp, stringFromDB.Length - temp);
        }
    }
}

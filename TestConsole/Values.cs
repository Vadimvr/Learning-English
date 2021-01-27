using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class Values
    {
        public string  Rus { get;private set; }
        public string Eng { get;private set; }
        public string EngTranscription { get; private set; }
        public string Song { get; private set; }
        public string Img { get; private set; }

        public Values(string wordRus, string wordEng, string transcription, PathToMultimedia paths)
        {
            Rus = wordRus;
            Eng= wordEng;
            Song=paths.PathSong;
            Img= paths.PathImg;
            EngTranscription = transcription;
        }

        public override string ToString()
        {
            return Rus + "\t"+ Eng + "\t" + EngTranscription + "\t" +Song + "\t" +Img +"\n";
        }
    }
}

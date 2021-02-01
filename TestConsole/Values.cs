using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestConsole
{
    class Values
    {
        public string Rus { get; private set; }
        public string Eng { get; private set; }
        public string EngTranscription { get; private set; }
        public string Song { get; private set; }
        public string Img { get; private set; }

        public Values(string wordRus, string wordEng, string transcription)
        {
            Rus = wordRus;
            Eng = wordEng;
            Img = @"img\" + wordEng + ".jpg";
            Song = @"song\" + wordEng + ".mp3";
            EngTranscription = transcription;
        }
    }
}

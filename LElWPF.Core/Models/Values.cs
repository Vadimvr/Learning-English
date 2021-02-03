namespace LElWPF.Core.Models
{
    class Values
    {
        public string Rus { get; private set; }
        public string Eng { get; private set; }
        public string EngTranscription { get; private set; }
        public string Song { get; private set; }
        public string Img { get; private set; }
        public string Help { get => Eng + " " + EngTranscription;  }

        
        
        public Values(string wordEng, string transcription, string wordRus,  string path)
        {
            Rus = wordRus;
            Eng = wordEng;
            Song =path + $@"song\{wordEng}.mp3";
            Img =path + $@"img\{wordEng}.jpg";
            EngTranscription = transcription;
        }
    }
}

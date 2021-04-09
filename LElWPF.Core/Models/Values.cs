namespace LElWPF.Core.Models
{
    class Values
    {
        public string Rus { get; set; }
        public string Eng { get; set; }
        public string EngTranscription { get; set; }
        public string Song { get;  set; }
        public string Img { get; set; }
        public string Help { get => Eng + " " + EngTranscription;  }

        
        
        public Values(string wordEng, string transcription, string wordRus,  string path)
        {
            Rus = wordRus;
            Eng = wordEng;
            Song =path + $@"data\pronunciation_en_{wordEng.ToLower().Replace(' ','_').Replace('!', '_').Replace('?', '_')}.mp3";
            Img =path + $@"data\{wordEng.ToLower().Replace('!', '_').Replace('?', '_')}.jpg";
            EngTranscription = transcription;
        }
        public Values(string wordEng, string transcription, string wordRus)
        {
            Rus = wordRus;
            Eng = wordEng;
            EngTranscription = transcription;
        }
        public Values()
        {
            
        }
    }
}

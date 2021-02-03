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

        public Values(string[] arr, string path) : this(arr[0], arr[1], arr[2], path) { }
        
        public Values(string wordRus, string wordEng, string transcription, string path)
        {
            Rus = wordRus;
            Eng = wordEng;
            Song =path + $@"song\{wordEng}.mp3";
            Img =path + $@"img\{wordEng}.jpg";
            EngTranscription = transcription;
        }
    }
}

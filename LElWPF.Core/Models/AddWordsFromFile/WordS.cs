namespace LElWPF.Core.Models.AddWordsFromFile
{
    class WordS
    {
        public string Eng { get; set; }
        public string Rus { get; set; }
        public string EngTranscription { get; set; }
        public WordS(string eng, string rus)
        {
            Eng = eng;
            Rus = rus;
            EngTranscription = "";
        }
    }
}
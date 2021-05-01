using System.IO;
using System.Text.Json;

namespace LElWPF.Core.Models.pathFromDb
{
    internal class PathFromDb
    {
        public static string Path;
        public static string Name;
        public static void SavePath(string path, string name)
        {
            DBpath db = new DBpath();
            db.FileName = name;
            db.PathFolder = path;

            string s = JsonSerializer.Serialize<DBpath>(db);
            using (StreamWriter writer = new StreamWriter("user.json"))
            {
                writer.WriteLine(s);
                writer.Close();
            }
        }

        public static void GetPath()
        {
            try
            {
                using (StreamReader fs = new StreamReader("user.json"))
                {
                    string s = fs.ReadLine();
                    DBpath path = JsonSerializer.Deserialize<DBpath>(s);
                    Path = path.PathFolder;
                    Name = path.FileName;
                }
            }
            catch
            {
                Name = string.Empty;
                Path = string.Empty;
            }

        }
    }
}

using System.IO;

namespace Utility.IO
{
    public class JsonIO
    {
        // Public Method
        public static string Load(string path)
        {
            string data;
            using (StreamReader sr = new StreamReader(path))
            {
                data = sr.ReadToEnd();
            }
            return data;
        }

        public static void Save(string data, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(data);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_Utilities
{
    public class FileService
    {
        public static void Save(string path, string content)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine(content);
        }
        public static string Read(string path)
        {
            try
            {
                using var sr = new StreamReader(path);
                return sr.ReadToEnd();
            }
            catch
            {
                return null!;
            }
        }
    }
}

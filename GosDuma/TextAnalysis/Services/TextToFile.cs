using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis.Services
{
    public static class TextToFile
    {
        public static void SaveTextToFile(string text, string path, string fileName, FileMode fileMode=FileMode.Create)
        {
            using (FileStream fstream = new FileStream(Path.Combine(path, fileName), fileMode))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);

                fstream.Write(array, 0, array.Length);
            }
        }
    }
}

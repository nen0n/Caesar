using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Caesar
{
    class FilesWork
    {
        public static string ReadTextFile(string filePath)
        {
            string fileContents = "";

            try
            {
                fileContents = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File not found");
            }
            catch (Exception)
            {
                throw new Exception("Problems with file");
            }

            return fileContents;
        }

        public static void LoadTextFile(string fileContents, string filePath)
        {
            File.WriteAllText(filePath, fileContents);
        }
    }
}

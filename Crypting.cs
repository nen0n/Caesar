using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Caesar
{
    class Crypting
    {
        public enum Crypt 
        {
            Encrypt,
            Decrypt
        }

        public static void CryptNonText(Crypt crypt, string inputFile, string outputPath, int key)
        {
            string outputFile = outputPath + @"\output" + Path.GetExtension(inputFile);
            byte[] inputBytes = File.ReadAllBytes(inputFile);
            byte[] outputBytes = new byte[inputBytes.Length];

            if (crypt == Crypt.Encrypt)
            {
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    outputBytes[i] = (byte)(inputBytes[i] + key % 255);
                }
            }
            else
            {
                for (int i = 0; i < inputBytes.Length; i++)
                {
                    outputBytes[i] = (byte)(inputBytes[i] - key % 255);
                }
            }    
            File.WriteAllBytes(outputFile, outputBytes);
        }

        public static string CryptText(Crypt crypt, string inputText, int key)
        {
            string outputText = "";
            if (crypt == Crypt.Encrypt)
            {
                foreach (char c in inputText)
                {
                    outputText += (char)((c + key) % 65536);
                }
            }
            else
            {
                foreach (char c in inputText)
                {
                    outputText += (char)((c + 65536 - key) % 65536);
                }
            }
            return outputText;
        }
    }
}

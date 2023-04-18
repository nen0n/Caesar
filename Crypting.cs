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

        public static void CryptNonText(Crypt crypt, string inputFile, string outputPath, object key) 
        {
            string outputFilePath;
            byte[] inputBytes = File.ReadAllBytes(inputFile);
            byte[] outputBytes = new byte[inputBytes.Length];
            outputFilePath = outputPath + @"\output (" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") +")"+ Path.GetExtension(inputFile);
            for (int i = 0; i < inputBytes.Length; i++)
            {
                if (crypt == Crypt.Encrypt)
                {
                    if (key is string)
                    {
                        outputBytes[i] =(byte)((inputBytes[i] + Equation(i, (string)key)) % 256);
                    }
                    else
                    {
                        outputBytes[i] = (byte)((inputBytes[i] + Equation(i, (int[])key)) % 256);
                    }
                }
                else
                {
                    if (key is string)
                    {
                        outputBytes[i] = (byte)((inputBytes[i] - Equation(i, (string)key)) % 256);
                    }
                    else
                    {
                        outputBytes[i] = (byte)((inputBytes[i] - Equation(i, (int[])key)) % 256);
                    }
                }
            }
            File.WriteAllBytes(outputFilePath, outputBytes);
        }

        public static string CryptText(Crypt crypt, string plainText, object key)
        {
            string cipherText = "";
            int position = 0;
            foreach (char c in plainText)
            {
                if (crypt == Crypt.Encrypt)
                {
                    int charCode = c;
                    if (key is int[])
                    {
                        int[] args = (int[])key;
                        charCode = (charCode + Equation(position, args)) % 65536;
                    }
                    else if (key is string)
                    {
                        string slogan = (string)key;
                        charCode = (charCode + Equation(position, slogan)) % 65536;
                    }
                    cipherText += (char)charCode;
                    position++;
                }
                else
                {
                    int charCode = c;
                    if (key is int[])
                    {
                        int[] args = (int[])key;
                        charCode = (charCode - Equation(position, args)) % 65536;
                    }
                    else if (key is string)
                    {
                        string slogan = (string)key;
                        charCode = (charCode - Equation(position, slogan)) % 65536;
                    }
                    cipherText += (char)charCode;
                    position++;
                }
            }
            return cipherText;
        }

        private static int Equation(int position, int[] args)
        {
            int value = 0;
            int pow = args.Length;
            foreach (int arg in args)
            {
                pow -= 1;
                value += (int)Math.Pow(position, pow) * arg;
            }
            return value;
        }

        private static int Equation(int position, string slogan)
        {
            return slogan[position % slogan.Length]; 
        }
    }
}

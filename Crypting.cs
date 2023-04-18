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
                int inputByte = inputBytes[i];
                int outputByte;
                if (crypt == Crypt.Encrypt)
                {
                    if (key is string)
                    {
                        outputByte = (inputByte + Equation(i, (string)key)) % 256;
                    }
                    else
                    {
                        outputByte = (inputByte + Equation(i, (int[])key)) % 256;
                    }
                }
                else
                {
                    if (key is string)
                    {
                        outputByte = (inputByte - Equation(i, (string)key)) % 256;
                    }
                    else
                    {
                        outputByte = (inputByte - Equation(i, (int[])key)) % 256;
                    }
                }
                outputBytes[i] = (byte)outputByte;
            }
            File.WriteAllBytes(outputFilePath, outputBytes);
        }

        public static string CryptText(Crypt crypt, string plainText, object key)
        {
            string cipherText = "";
            int position = 0;
            if (crypt == Crypt.Encrypt)
            {
                foreach (char c in plainText)
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
            }
            else
            {
                foreach (char c in plainText)
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

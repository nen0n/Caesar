using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Caesar
{
    class Crypting
    {
        public enum Type
        {
            Caesar,
            Tritemius
        }

        public enum Crypt
        {
            Encrypt,
            Decrypt
        }

        public static void CryptNonText(Crypt crypt, Type type, string inputFile, string outputPath, object key)
        {
            string outputFilePath;
            byte[] inputBytes = FilesWork.ReadFile(inputFile);
            byte[] outputBytes = new byte[inputBytes.Length];
            outputFilePath = outputPath + @"\output (" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ")" + Path.GetExtension(inputFile);
            if (type == Type.Caesar)
            {
                if (crypt == Crypt.Encrypt)
                {
                    for (int i = 0; i < inputBytes.Length; i++)
                    {
                        outputBytes[i] = (byte)((inputBytes[i] + Equation(i, (int[])key)) % 256);
                    }
                }
                if (crypt == Crypt.Decrypt)
                {
                    for (int i = 0; i < inputBytes.Length; i++)
                    {
                        outputBytes[i] = (byte)((inputBytes[i] - Equation(i, (int[])key)) % 256);
                    }
                }
            }
            if (type == Type.Tritemius)
            {
                if (crypt == Crypt.Encrypt)
                {
                    if (key is int[])
                    {
                        for (int i = 0; i < inputBytes.Length; i++)
                        {
                            outputBytes[i] = (byte)((inputBytes[i] + Equation(i, (int[])key)) % 256);
                        }
                    }
                    if (key is string)
                    {
                        for (int i = 0; i < inputBytes.Length; i++)
                        {
                            outputBytes[i] = (byte)((inputBytes[i] + Equation(i, (string)key)) % 256);
                        }
                    }
                }
                if (crypt == Crypt.Decrypt)
                {
                    if (key is int[])
                    {
                        for (int i = 0; i < inputBytes.Length; i++)
                        {
                            outputBytes[i] = (byte)((inputBytes[i] - Equation(i, (int[])key)) % 256);
                        }
                    }
                    if (key is string)
                    {
                        for (int i = 0; i < inputBytes.Length; i++)
                        {
                            outputBytes[i] = (byte)((inputBytes[i] - Equation(i, (string)key)) % 256);
                        }
                    }
                }
            }
            FilesWork.LoadFile(outputFilePath, outputBytes);
        }

        public static string CryptText(Crypt crypt, Type type, string plainText, object key)
        {
            string cipherText = "";
            int position = 0;
            if (type == Type.Caesar)
            {
                if (crypt == Crypt.Encrypt)
                {
                    foreach (char c in plainText)
                    {
                        int charCode = c;
                        int[] args = (int[])key;
                        charCode = (charCode + Equation(position, args)) % 65536;
                        cipherText += (char)charCode;
                        position++;
                    }
                }
                if (crypt == Crypt.Decrypt)
                {
                    foreach (char c in plainText)
                    {
                        int charCode = c;
                        int[] args = (int[])key;
                        charCode = (charCode - Equation(position, args)) % 65536;
                        cipherText += (char)charCode;
                        position++;
                    }
                }
            }
            if (type == Type.Tritemius)
            {
                if (crypt == Crypt.Encrypt)
                {
                    if (key is int[])
                    {
                        foreach (char c in plainText)
                        {
                            int charCode = c;
                            int[] args = (int[])key;
                            charCode = (charCode + Equation(position, args)) % 65536;
                            cipherText += (char)charCode;
                            position++;
                        }
                    }
                    if (key is string)
                    {
                        foreach (char c in plainText)
                        {
                            int charCode = c;
                            string slogan = (string)key;
                            charCode = (charCode + Equation(position, slogan)) % 65536;
                            cipherText += (char)charCode;
                            position++;
                        }
                    }
                }
                if (crypt == Crypt.Decrypt)
                {
                    if (key is int[])
                    {
                        foreach (char c in plainText)
                        {
                            int charCode = c;
                            int[] args = (int[])key;
                            charCode = (charCode - Equation(position, args)) % 65536;
                            cipherText += (char)charCode;
                            position++;
                        }
                    }
                    if (key is string)
                    {
                        foreach (char c in plainText)
                        {
                            int charCode = c;
                            string slogan = (string)key;
                            charCode = (charCode - Equation(position, slogan)) % 65536;
                            cipherText += (char)charCode;
                            position++;
                        }
                    }
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

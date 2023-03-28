using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Caesar
{
    class Crypting
    {
        static int PowerOfByte = 255; 
        static int PowerOfUnicode = 65536; 
        public static void EncryptNonText(string originalFile, string encryptedPath, int[] args) 
        {
            string encryptedFile = encryptedPath + @"\encrypted" + Path.GetExtension(originalFile); 
            byte[] originalBytes = File.ReadAllBytes(originalFile); 
            byte[] encryptedBytes = new byte[originalBytes.Length]; 
            if (Path.GetExtension(originalFile) == ".txt") 
            {
                FilesWork.LoadTextFile(Crypting.EncryptText(FilesWork.ReadTextFile(originalFile), args), encryptedFile); 
                return;
            }
            for (int i = 0; i < originalBytes.Length; i++) 
            {
                encryptedBytes[i] = (byte)(originalBytes[i] + Equation(i, args) % 255); 
            }
            File.WriteAllBytes(encryptedFile, encryptedBytes); 
        }

        public static void DecryptNonText(string encryptedFile, string originalPath, int[] args)
        {
            string originalFile = originalPath + @"\decrypted" + Path.GetExtension(encryptedFile); 
            byte[] encryptedBytes = File.ReadAllBytes(encryptedFile);
            byte[] originalBytes = new byte[encryptedBytes.Length]; 
            if (Path.GetExtension(encryptedFile) == ".txt")
            {
                FilesWork.LoadTextFile(Crypting.DecryptText(FilesWork.ReadTextFile(encryptedFile), args), originalFile); 
                return;
            }
            for (int i = 0; i < encryptedBytes.Length; i++)
            {

                originalBytes[i] = (byte)(encryptedBytes[i] - Equation(i, args) % 255);
            }
            File.WriteAllBytes(originalFile, originalBytes);
        }

        public static void EncryptNonText(string originalFile, string encryptedPath, string slogan)
        {
            string encryptedFile = encryptedPath + @"\encrypted" + Path.GetExtension(originalFile);
            byte[] originalBytes = File.ReadAllBytes(originalFile);
            byte[] encryptedBytes = new byte[originalBytes.Length];
            if (Path.GetExtension(originalFile) == ".txt")
            {
                FilesWork.LoadTextFile(Crypting.EncryptText(FilesWork.ReadTextFile(originalFile), slogan), encryptedFile);
                return;
            }
            for (int i = 0; i < originalBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(originalBytes[i] + Equation(i, slogan) % 255);
            }
            File.WriteAllBytes(encryptedFile, encryptedBytes);
        }

        public static void DecryptNonText(string encryptedFile, string originalPath, string slogan)
        {
            string originalFile = originalPath + @"\decrypted" + Path.GetExtension(encryptedFile);
            byte[] encryptedBytes = File.ReadAllBytes(encryptedFile);
            byte[] originalBytes = new byte[encryptedBytes.Length];

            if (Path.GetExtension(encryptedFile) == ".txt")
            {
                FilesWork.LoadTextFile(Crypting.DecryptText(FilesWork.ReadTextFile(encryptedFile), slogan), originalFile);
                return;
            }
            for (int i = 0; i < encryptedBytes.Length; i++)
            {

                originalBytes[i] = (byte)(encryptedBytes[i] - Equation(i, slogan) % 255);
            }
            File.WriteAllBytes(originalFile, originalBytes);
        }

        public static string EncryptText(string plainText, int[] args)
        {
            string cipherText = "";
            int position = 0;
            foreach (char c in plainText)
            {
                int charCode = c; 
                charCode = (charCode + Equation(position, args)) % PowerOfUnicode; 
                cipherText += (char)charCode;
                position++;
            }
            return cipherText; 
        }

        public static string DecryptText(string cipherText, int[] args)
        {
            string plainText = "";
            int position = 0;
            foreach (char c in cipherText)
            {
                int charCode = c;
                charCode = (charCode + PowerOfUnicode - (Equation(position, args) % PowerOfUnicode)) % PowerOfUnicode;
                plainText += (char)charCode;
                position++;
            }
            return plainText;
        }

        public static string EncryptText(string plainText, string slogan)
        {
            string cipherText = "";
            int position = 0;
            foreach (char c in plainText)
            {
                int charCode = c;
                charCode = (charCode + Equation(position, slogan)) % PowerOfUnicode;
                cipherText += (char)charCode;
                position++;
            }
            return cipherText;
        }

        public static string DecryptText(string cipherText, string slogan)
        {
            string plainText = "";
            int position = 0;
            foreach (char c in cipherText)
            {
                int charCode = c;
                charCode = (charCode + PowerOfUnicode - (Equation(position, slogan) % PowerOfUnicode)) % PowerOfUnicode;
                plainText += (char)charCode;
                position++;
            }
            return plainText;
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

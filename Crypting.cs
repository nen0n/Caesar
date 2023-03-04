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
        public static void EncryptNonText(string originalFile, string encryptedPath, int key)
        {
            string encryptedFile = encryptedPath + @"\encrypted" + Path.GetExtension(originalFile);
            byte[] originalBytes = File.ReadAllBytes(originalFile);
            byte[] encryptedBytes = new byte[originalBytes.Length];

            if(Path.GetExtension(originalFile) == ".txt")
            {
                FilesWork.LoadTextFile(Crypting.EncryptText(FilesWork.ReadTextFile(originalFile), key), encryptedFile);
                return;
            }


            for (int i = 0; i < originalBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(originalBytes[i] + key % 255);
            }

            File.WriteAllBytes(encryptedFile, encryptedBytes);
        }

        public static void DecryptNonText(string encryptedFile, string originalPath, int key)
        {
            string originalFile = originalPath + @"\decrypted" + Path.GetExtension(encryptedFile);
            byte[] encryptedBytes = File.ReadAllBytes(encryptedFile);
            byte[] originalBytes = new byte[encryptedBytes.Length];

            if (Path.GetExtension(encryptedFile) == ".txt")
            {
                FilesWork.LoadTextFile(Crypting.DecryptText(FilesWork.ReadTextFile(encryptedFile), key), originalFile);
                return;
            }

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                originalBytes[i] = (byte)(encryptedBytes[i] - key % 255);
            }

            File.WriteAllBytes(originalFile, originalBytes);
        }

        public static string EncryptText(string plainText, int key)
        {
            string cipherText = "";

            foreach (char c in plainText)
            {
                int charCode = c;
                charCode = (charCode + key) % PowerOfUnicode;
                cipherText += (char)charCode;
            }

            return cipherText;
        }

        public static string DecryptText(string cipherText, int key)
        {
            string plainText = "";

            foreach (char c in cipherText)
            {
                int charCode = c;
                charCode = (charCode + PowerOfUnicode - (key % PowerOfUnicode)) % PowerOfUnicode;
                plainText += (char)charCode;
            }

            return plainText;
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PagesXamarin.Utilities
{
    public class CryptographyAES
    {
        public static string EncryptAesManaged(byte[] input, byte[] aesKey)
        {
            //byte[] key = ConvertStringToByteArray("2b7e151628aed2a6abf7158809cf4f3c");
            //byte[] test = ConvertStringToByteArray("6bc1bee22e409f96e93d7e117393172a");
            //input = test;
            //aesKey = key;
            //resposta = 3ad77bb40d7a3660a89ecaf32466ef97
            //resposta = 34a3998ff17ebfe118510cfcfdf89d6d
            try
            {
                var aesAlg = new AesManaged
                {
                    KeySize = 128,
                    Key = aesKey,
                    BlockSize = 128,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.Zeros,
                    IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };
               

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                return ConvertByteArrayToString( encryptor.TransformFinalBlock(input, 0, input.Length));
               
            }
            catch (Exception exp)
            {
                return "";
            }
            
        }

        public static string ConvertByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public static byte[] ConvertStringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public static string LittleEndian32(Int32 num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            string retval = "";
            foreach (byte b in bytes)
            {
                retval += b.ToString("X2");
            }

            return retval;
        }

        public static string LittleEndian64(Int64 number)
        {
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
            {
                retval += b.ToString("X2");
            }
            return retval;
        }

    }

}

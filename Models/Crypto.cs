using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartQuote.Models
{
    public class Crypto
    {
        static string key { get; set; } = "kljsdkkdlo4454GG00155sajuklmbkdl";

        public static string Encrypt(string text)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(text);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string text)
        {
            byte[] inputArray = Convert.FromBase64String(text);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static string EncryptMd5(string text)
        {
            byte[] sPassKeyArray;

            byte[] sOriginalArray = UTF8Encoding.UTF8.GetBytes(text);

            MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();

            sPassKeyArray = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            MD5Hash.Clear();

            TripleDESCryptoServiceProvider tripleDesCsp = new TripleDESCryptoServiceProvider();

            tripleDesCsp.Key = sPassKeyArray;
            tripleDesCsp.Mode = CipherMode.ECB;
            tripleDesCsp.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tripleDesCsp.CreateEncryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(sOriginalArray, 0, sOriginalArray.Length);

            tripleDesCsp.Clear();

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }





        /// <summary>

        /// MD5 - Decrypt an encrypted string using a key

        /// </summary>

        /// <param name="sToOriginal"></param>

        /// <param name="sPassKey"></param>

        /// <returns>A string containing the decrypted account number</returns>

        public static string DecryptMd5(string text)
        {
            text = text.Replace(" ", "+");
            byte[] sPassKeyArray;
            byte[] sOriginalArray = Convert.FromBase64String(text);

            MD5CryptoServiceProvider MD5Hash = new MD5CryptoServiceProvider();

            sPassKeyArray = MD5Hash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            MD5Hash.Clear();

            TripleDESCryptoServiceProvider tripleDesCsp = new TripleDESCryptoServiceProvider();

            tripleDesCsp.Key = sPassKeyArray;
            tripleDesCsp.Mode = CipherMode.ECB;
            tripleDesCsp.Padding = PaddingMode.PKCS7;


            ICryptoTransform cTransform = tripleDesCsp.CreateDecryptor();

            byte[] resultArray = cTransform.TransformFinalBlock(sOriginalArray, 0, sOriginalArray.Length);

            tripleDesCsp.Clear();

            return UTF8Encoding.UTF8.GetString(resultArray);

        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Helper
{
    public class CryptographyHelper
    {
        /// <summary>
        /// 以AES演算法加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <param name="key">加解密金鑰</param>
        /// <param name="iv">加解密初始化向量</param>
        /// <returns>密文</returns>
        /// <exception cref="ArgumentNullException">
        /// 當<paramref name="key"/>或<paramref name="iv"/>的值為<c>Null</c>或空字串時
        /// 會擲出此例外。
        /// </exception>
        public static string AesEncrypt(string plainText,
            string key,
            string iv)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return plainText;
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (string.IsNullOrEmpty(iv))
            {
                throw new ArgumentNullException("iv");
            }

            byte[] bytedPlainText = Encoding.UTF8.GetBytes(plainText);
            byte[] bytedKey = Encoding.ASCII.GetBytes(key);
            byte[] bytedIv = Encoding.ASCII.GetBytes(iv);

            string result = null;

            AesCryptoServiceProvider provider = new AesCryptoServiceProvider();

            provider.Key = bytedKey;
            provider.IV = bytedIv;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream,
                           provider.CreateEncryptor(),
                           CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytedPlainText, 0, bytedPlainText.Length);
                    cryptoStream.FlushFinalBlock();
                    result = Convert.ToBase64String(memoryStream.ToArray());
                }
            }

            return result;
        }

        /// <summary>
        /// 以AES演算法解密
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <param name="key">加解密金鑰</param>
        /// <param name="iv">加解密初始化向量</param>
        /// <returns>明文</returns>
        /// <exception cref="ArgumentNullException">
        /// 當<paramref name="key"/>或<paramref name="iv"/>的值為<c>Null</c>或空字串時
        /// 會擲出此例外。
        /// </exception>
        public static string AesDecrypt(string cipherText,
            string key,
            string iv)
        {
            if (string.IsNullOrEmpty(cipherText))
            {
                return cipherText;
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (string.IsNullOrEmpty(iv))
            {
                throw new ArgumentNullException("iv");
            }

            byte[] bytedCipherText = Convert.FromBase64String(cipherText);
            byte[] bytedKey = Encoding.ASCII.GetBytes(key);
            byte[] bytedIv = Encoding.ASCII.GetBytes(iv);

            string result = null;

            AesCryptoServiceProvider provider = new AesCryptoServiceProvider();

            provider.Key = bytedKey;
            provider.IV = bytedIv;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream,
                           provider.CreateDecryptor(),
                           CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytedCipherText, 0, bytedCipherText.Length);
                    cryptoStream.FlushFinalBlock();
                    result = Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }

            return result;
        }

        /// <summary>
        /// 取得MD5雜湊加密後的十六進位文字
        /// </summary>
        /// <param name="source">需加密文字</param>
        /// <returns>加密後的十六進位文字</returns>
        public static string GetMD5(string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            StringBuilder result = new StringBuilder();

            byte[] md5Hash = GetMD5Hash(source);
            foreach (byte b in md5Hash)
            {
                result.Append(b.ToString("x2"));
            }

            return result.ToString();
        }

        /// <summary>
        /// 取得MD5雜湊加密
        /// </summary>
        /// <param name="source">需加密文字</param>
        /// <returns>加密後文字</returns>
        private static byte[] GetMD5Hash(string source)
        {
            byte[] result;

            using (MD5 md5Hasher = MD5.Create())
            {
                result = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            return result;
        }
    }
}
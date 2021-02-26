using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Org.Tao.FW.Common.Lic
{
    public class DESHelper
    {
        /// <summary>
        /// DES加密数据
        /// </summary>
        /// <param name="decryptString">加密密文</param>
        /// <param name="encryptKey">8位加密密钥</param>
        /// <returns></returns>
        public static string Encode(string decryptString, string encryptKey = "12345678")
        {
            if (string.IsNullOrWhiteSpace(decryptString)) return decryptString;
            StringBuilder sb = new StringBuilder();
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                byte[] iv = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                byte[] dataByteArray = Encoding.UTF8.GetBytes(decryptString);
                des.Mode = System.Security.Cryptography.CipherMode.CBC;
                des.Key = key;
                des.IV = iv;
                string encrypt = "";
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(ms.ToArray());
                }
                return encrypt;
            }
        }
        /// <summary>
        /// DES解密数据
        /// </summary>
        /// <param name="decryptString">解密密文</param>
        /// <param name="encryptKey">解密密钥</param>
        /// <returns></returns>
        public static string Decrypt(string decryptString, string encryptKey = "123456")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(decryptString)) return decryptString;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(encryptKey);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    string str = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                    return str;
                }
            }
            catch (Exception ex)
            {
                return decryptString;
            }
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GoldenCompany.Security
{
    public static class Cryptography
    {
        private static string Key;

        public static void SetKey(string key) => Key = key;

        public static string Encrypt(string clearText) => Encrypt(clearText, Key);

        public static string Encrypt(string clearText, string salt)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentException("You must set 'Key' value for Cryptography");
            }

            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Key, Encoding.ASCII.GetBytes(salt));
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                pdb.Dispose();

                using var ms = new MemoryStream();
                using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }

                clearText = Convert.ToBase64String(ms.ToArray());
            }

            return clearText;
        }

        public static string Decrypt(string cipherText) => Decrypt(cipherText, Key);

        public static string Decrypt(string cipherText, string salt)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new ArgumentException("You must set 'Key' value for Cryptography");
            }

            cipherText = cipherText.Replace(" ", "+");

            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(Key, Encoding.ASCII.GetBytes(salt));
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                pdb.Dispose();

                using var memoryStream = new MemoryStream();
                using (var cs = new CryptoStream(memoryStream, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }

                cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
            }

            return cipherText;
        }
    }
}

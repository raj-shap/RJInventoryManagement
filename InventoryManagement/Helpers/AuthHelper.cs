
using System.Security.Cryptography;
using System.Text;

namespace InventoryManagement.Helpers
{
    public static class AuthHelper
    {

       public static string GetEncrypted(string plainText)
        {
            return Encryptsec(plainText);
        }
        public static string GetDeprypted(string Encryptedtext)
        {
            return Decryptsec(Encryptedtext);
        }

        public static string EncryptionKey = "mY#SeCuRe@EnCrYpTiOn$KeY2024*OK!";

        private static string Encryptsec(string plainText)
        {
            try
            {
                if (string.IsNullOrEmpty(plainText))
                {
                    throw new ArgumentNullException(nameof(plainText), "Plain Text cannot be null or emplty.");
                }

                if (string.IsNullOrEmpty(EncryptionKey) || EncryptionKey.Length < 16)
                {
                    throw new ArgumentNullException("Key must be at least 16 character long.");
                }

                byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 16));

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.GenerateIV();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Write(aes.IV, 0, aes.IV.Length);
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                            cs.Write(inputBytes, 0, inputBytes.Length);
                            cs.FlushFinalBlock();
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }

        private static string Decryptsec(string encryptedText)
        {
            try
            {
                if (string.IsNullOrEmpty(encryptedText))
                {
                    throw new ArgumentNullException(nameof(encryptedText),"Encrypted text cannot be null or empty.");
                }

                if(string.IsNullOrEmpty(EncryptionKey)|| EncryptionKey.Length < 16)
                {
                    throw new ArgumentNullException("Key must be at least 16 character long.");
                }

                byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey.Substring(0,16));
                byte[] cipherBytes = Convert.FromBase64String(encryptedText);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;

                    byte[] iv = new byte[aes.BlockSize / 8];
                    Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
                    aes.IV = iv;

                    byte[] actualCipher = new byte[cipherBytes.Length - iv.Length];
                    Array.Copy(cipherBytes, iv.Length, actualCipher, 0, actualCipher.Length);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(actualCipher, 0, actualCipher.Length);
                            cs.FlushFinalBlock();
                        }

                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error : {ex.Message}";
            }
        }
    }
}

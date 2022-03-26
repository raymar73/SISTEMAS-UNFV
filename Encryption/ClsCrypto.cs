using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Encryption
{
    public class ClsCrypto
    {
        public static string DecryptStringFromBytes(string cipherText, bool checkPrefixEncrypt)
        {
            // Check arguments.  
            var key = Encoding.UTF8.GetBytes("8080808080808080");
            var iv = Encoding.UTF8.GetBytes("8080808080808080");
            //bool checkPrefixEncrypt = bool.Parse(HttpContext.Current.Session["PrefixEncrypt"].ToString());
            //bool checkPrefixEncrypt = true;
            string _decryptedString = "";
            if (!string.IsNullOrEmpty(cipherText))
            {
                if (checkPrefixEncrypt)
                {
                    //if (cipherText == null || cipherText.Length <= 0)
                    //{
                    //    throw new ArgumentNullException("cipherText");
                    //}
                    if (key == null || key.Length <= 0)
                    {
                        throw new ArgumentNullException("key");
                    }
                    if (iv == null || iv.Length <= 0)
                    {
                        throw new ArgumentNullException("key");
                    }

                    // Declare the string used to hold  
                    // the decrypted text.  
                    string plaintext = null;

                    // Create an RijndaelManaged object  
                    // with the specified key and IV.  
                    using (var rijAlg = new AesManaged())
                    {
                        //Settings  
                        rijAlg.Mode = CipherMode.CBC;
                        rijAlg.Padding = PaddingMode.PKCS7;
                        rijAlg.FeedbackSize = 128;

                        rijAlg.Key = key;
                        rijAlg.IV = iv;

                        // Create a decrytor to perform the stream transform.  
                        var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                        try
                        {
                            // Create the streams used for decryption.  
                            using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                            {
                                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                                {

                                    using (var srDecrypt = new StreamReader(csDecrypt))
                                    {
                                        // Read the decrypted bytes from the decrypting stream  
                                        // and place them in a string.  
                                        plaintext = srDecrypt.ReadToEnd();
                                        _decryptedString = plaintext;
                                    }

                                }
                            }
                        }
                        catch
                        {
                            plaintext = "keyError";
                            _decryptedString = plaintext;
                        }
                    }
                }
                else
                {
                    _decryptedString = cipherText;
                }

            }
            return _decryptedString;
        }
        public static string EncryptStringToBytes(string plainText, bool checkPrefixEncrypt)
        {
            var key = Encoding.UTF8.GetBytes("8080808080808080");
            var iv = Encoding.UTF8.GetBytes("8080808080808080");
            string _encryptedString = "";
            // Check arguments. 
            // bool checkPrefixEncrypt = bool.Parse(HttpContext.Current.Session["PrefixEncrypt"].ToString());
            //bool checkPrefixEncrypt = true;

            if (!string.IsNullOrEmpty(plainText))
            {
                if (checkPrefixEncrypt)
                {
                    if (key == null || key.Length <= 0)
                    {
                        throw new ArgumentNullException("key");
                    }
                    if (iv == null || iv.Length <= 0)
                    {
                        throw new ArgumentNullException("key");
                    }
                    byte[] encrypted;
                    // Create a RijndaelManaged object  
                    // with the specified key and IV.  
                    using (var rijAlg = new AesManaged())
                    {
                        rijAlg.Mode = CipherMode.CBC;
                        rijAlg.Padding = PaddingMode.PKCS7;
                        rijAlg.FeedbackSize = 128;

                        rijAlg.Key = key;
                        rijAlg.IV = iv;

                        // Create a decrytor to perform the stream transform.  
                        var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                        // Create the streams used for encryption.  
                        using (var msEncrypt = new MemoryStream())
                        {
                            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (var swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    //Write all data to the stream.  
                                    swEncrypt.Write(plainText);
                                }
                                encrypted = msEncrypt.ToArray();
                                _encryptedString = Convert.ToBase64String(encrypted);
                            }
                        }
                    }
                }
                else
                {
                    _encryptedString = plainText;
                }
            }
            // Return the encrypted bytes from the memory stream.  
            return _encryptedString;
        }
    }
}

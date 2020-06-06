
using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;

namespace SymetericalEncyptDecryp
{
    //Symetirc algorithems are "block ciphers"
    public class SymetricAlogrithem
    {
        private string IV = "test thi so ke aoeoquroquroiuqorjoo";
        //I use AES instead of TripleDES and I use CBC instead of ECB Mode
        //in case CBC when first block of data is encypted it want to add more randomization of to the symeteric algorithm 
        //since it uses the random data from first encrypted block and then encypt the second block
        //the first block will get the radom data by Initialization Vector (VI)
        public string Decrypt(string stringCipher)
        {
            Aes cipher = CreateCipher();
            cipher.IV = Convert.FromBase64String(IV);

            ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(stringCipher);
            byte[] plaintext = cryptoTransform.TransformFinalBlock(cipherText, 0, cipher.BlockSize);

            var resl = Encoding.UTF8.GetString(plaintext);
            return resl;
        }
        public string Encrypt(string txt)
        {
            Aes cipher = CreateCipher();
            
            IV = Convert.ToBase64String(cipher.IV);
            ICryptoTransform cryptoTransform = cipher.CreateDecryptor();
            byte[] bytetxt = Encoding.UTF8.GetBytes(txt);
            byte[] cipherbyte = cryptoTransform.TransformFinalBlock(bytetxt, 0, bytetxt.Length);

            var Ciphertxt = Convert.ToBase64String(cipherbyte);
            return Ciphertxt;
        }

        private Aes CreateCipher()
        {
            Aes cipher = Aes.Create();
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;
            // cipher.Padding = PaddingMode.None; => for the  same text it wil always be the same cipher text
            // cipher.Mode = CipherMode.ECB; => for all data will return the same cipher text
            cipher.Key = Conversion.HexToByteArray("45678900896875675765698780908e98");
            return cipher;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Helpers
{
    public static class SecurityHelper
    {
        /// <summary>
        /// Encrypt Method
        /// </summary>
        /// <param name="textPlain"></param>
        /// <returns></returns>
        public static string Encrypt(this string textPlain)
        {
            string result = string.Empty;
            byte[] encrypted = Encoding.Unicode.GetBytes(textPlain);
            result = Convert.ToBase64String(encrypted);
            return result;
        }

        /// <summary>
        /// Decrypt Method
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public static string Decrypter(this string encryptedText)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(encryptedText);
            result = Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}

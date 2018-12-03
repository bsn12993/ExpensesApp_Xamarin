using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensesApp.Helpers
{
    public static class SecurityHelper
    {
        public static string Encrypt(this string textPlain)
        {
            string result = string.Empty;
            byte[] encrypted = Encoding.Unicode.GetBytes(textPlain);
            result = Convert.ToBase64String(encrypted);
            return result;
        }

        public static string Decrypter(this string encryptedText)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(encryptedText);
            result = Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}

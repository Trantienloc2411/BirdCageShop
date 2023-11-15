using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public static class Utility
    {
        private static string key = "dontg1ve1h3mkey";

        public static string encrytoStringKey(string encryptString)
        {
            if (string.IsNullOrEmpty(encryptString)) return "";
            encryptString += key;
            var encryptBytes = Encoding.UTF8.GetBytes(encryptString);
            return Convert.ToBase64String(encryptBytes);
        }

        public static string dycryptoString(string decryptString)
        {
            if (string.IsNullOrEmpty(decryptString)) return "";
            var encodeBytes = Convert.FromBase64String(decryptString);
            var result = Encoding.UTF8.GetString(encodeBytes);
            return result.Substring(0, result.Length - key.Length);
        }
    }
}

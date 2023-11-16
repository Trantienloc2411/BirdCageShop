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
        private static Random random = new Random();

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
        public static int codeRecovery()
        {
            // Define the range of the 6-digit integer (from 100000 to 999999)
            const int minValue = 100000; // Minimum value (inclusive)
            const int maxValue = 999999; // Maximum value (inclusive)

            return random.Next(minValue, maxValue + 1);
        }
        public static string passwordRecovery()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }

    }

}

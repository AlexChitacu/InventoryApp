using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryWebApp.Utils
{
    public static class Cypher
    {
        public static string HashStringWithSalt(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                string toBeHashed = input + AppSettings.Salt;

                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(toBeHashed);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
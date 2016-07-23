using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TaskBoard.Web.Infrastructure.Helpers
{
    public static class CryptographyHelper
    {
        private static readonly RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();
        private static readonly SHA512 Sha512 = new SHA512Managed();

        public static string GenerateSalt()
        {

            var salt = new byte[64];

            Rng.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }

        public static string GenerateHash(string password, string salt)
        {
            var data = Encoding.UTF8.GetBytes(password + salt);
            var hash = Sha512.ComputeHash(data);
            return Convert.ToBase64String(hash);
        }
    }
}
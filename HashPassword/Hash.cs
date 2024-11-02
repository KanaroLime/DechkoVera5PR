using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace HashPassword
{

    public class Hash
    {
        public static class HashHelper
        {
            public static string HashPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] sourceBytePassw = Encoding.UTF8.GetBytes(password);
                    byte[] hashSourceBytePassw = sha256.ComputeHash(sourceBytePassw);
                    String hashPassw = BitConverter.ToString(hashSourceBytePassw).Replace("-", string.Empty);
                    return hashPassw;
                }
            }
        }
    }
}

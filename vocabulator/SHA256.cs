using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulator
{
    class SHA256
    {

        public static string Hash(string input)
        {
            SHA256Managed sha256 = new SHA256Managed();
            string hash = "";
            byte[] result = sha256.ComputeHash(Encoding.UTF8.GetBytes(input), 0, Encoding.UTF8.GetByteCount(input));
            foreach (byte bit in result)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }

    }
}

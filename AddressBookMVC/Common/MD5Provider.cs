using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace Common
{
    public class MD5Provider
    {
        public MD5Provider() { }

        public static string Hash(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return string.Empty;
            else
            {
                MD5 md5 = MD5.Create();
                byte[] source = Encoding.Unicode.GetBytes(msg);
                byte[] result = md5.ComputeHash(source);

                StringBuilder buffer = new StringBuilder(result.Length);
                for (int i = 0; i < result.Length; i++)
                    buffer.Append(result[i].ToString("x"));

                return buffer.ToString();
            }
        }
    }
}

using System;
using System.Security.Cryptography;
using System.Text;

namespace ExcelPwdGen.Utils.Strings
{
    internal static class RandomString
    {
        /// <summary>
        /// Generates a random string of arbitrary length from given characters.
        /// </summary>
        /// <param name="len"></param>
        /// <param name="srcChars"></param>
        /// <returns></returns>
        public static string Generate(uint len, string srcChars)
        {
            if (len == 0) return string.Empty;
            var s = srcChars;
            var res = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                var buf = new byte[sizeof(uint)];
                for (int i = 0; i < len; i++)
                {
                    rng.GetBytes(buf);
                    var n = BitConverter.ToUInt32(buf, 0);
                    res.Append(s[(int)(n % (uint)s.Length)]);
                }
            }
            return res.ToString();
        }
    }
}
using System;
using ExcelPwdGen.Utils.Strings;

namespace ExcelPwdGen.Utils.Security
{
    /// <summary>
    /// a password generator.
    /// </summary>
    internal class PasswordGenerator
    {
        /// public const uint MaxPasswordLength = 15;

        /// <summary>
        /// Represents the minimum password length.
        /// </summary>
        public const uint MinLength = 8;

        /// <summary>
        /// Represents the default password length.
        /// </summary>
        /// public const uint DefaultPasswordLength = MaxPasswordLength;

        /// <summary>
        /// Generate a password with the specified length and options.
        /// </summary>
        /// <param name="len">Number of characters to generate</param>
        /// <param name="rule">Character set to use</param>
        /// <returns></returns>
        public static string GenerateRandom(uint len = MinLength, CharRuleset rule = CharRuleset.All)
        {
            len = Math.Max(MinLength, len);

            var s = CharRuleCollection.GetString(rule);
            while (true)
            {
                var pass = RandomString.Generate(len, s);
                var ok = CharRuleCollection.MatchesValue(pass, rule);
                if (ok) return pass;
            }
        }
    }
}
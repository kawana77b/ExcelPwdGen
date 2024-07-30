using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExcelPwdGen.Utils.Strings
{
    internal enum CharacterType
    {
        Lowercase,
        Uppercase,
        Numeric,
        Special,
    }

    internal class CharRule
    {
        public CharacterType Type { get; set; }

        public string Regexp { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// Checks if the given value matches according to the regular expression string held by this object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Matches(string value)
            => Regex.IsMatch(value, Regexp);
    }

    internal static class CharRules
    {
        /// <summary>
        /// All CharRule Values.
        /// </summary>
        public static readonly CharRule[] Values = new CharRule[]
        {
            new CharRule { Type = CharacterType.Lowercase, Regexp = "[a-z]", Value = "abcdefghijklmnopqrstuvwxyz" },
            new CharRule { Type = CharacterType.Uppercase, Regexp = "[A-Z]", Value = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
            new CharRule { Type = CharacterType.Numeric, Regexp = "[0-9]", Value = "0123456789" },
            new CharRule { Type = CharacterType.Special, Regexp = "[!@#$%^&*-_()]", Value = "!@#$%^&*-_()" }
        };

        /// <summary>
        /// Returns a collection from which only one or more of the given types are extracted.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<CharRule> Choose(params CharacterType[] type)
            => Values.Where(s => type.Contains(s.Type));
    }
}
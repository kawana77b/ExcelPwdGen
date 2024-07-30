using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace ExcelPwdGen.Utils.Strings
{
    internal enum CharRuleset
    {
        LowercaseAndNumeric,
        LowercaseAndUppercaseAndNumeric,
        All,
    }

    internal static class CharRuleCollection
    {
        private static ReadOnlyDictionary<TKey, TValue> ToReadOnly<TKey, TValue>(this Dictionary<TKey, TValue> @this)
            => new ReadOnlyDictionary<TKey, TValue>(@this);

        private static readonly ReadOnlyDictionary<CharRuleset, IEnumerable<CharRule>> Rules =
            new Dictionary<CharRuleset, IEnumerable<CharRule>>()
            {
                {
                    CharRuleset.LowercaseAndNumeric,
                    CharRules.Choose(CharacterType.Lowercase, CharacterType.Numeric)
                },
                {
                    CharRuleset.LowercaseAndUppercaseAndNumeric,
                    CharRules.Choose(CharacterType.Lowercase, CharacterType.Uppercase, CharacterType.Numeric)
                },
                {
                    CharRuleset.All,
                    CharRules.Values
                }
            }
            .ToReadOnly();

        private static IEnumerable<CharRule> GetCharacterSets(CharRuleset rule)
        {
            if (Rules.TryGetValue(rule, out var sets)) return sets;
            throw new ArgumentException("Invalid rule");
        }

        /// <summary>
        /// Get concatenated strings according to the specified string rules.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static string GetString(CharRuleset rule = CharRuleset.All)
            => string.Join(string.Empty, GetStrings(rule));

        /// <summary>
        /// Get a collection of strings according to the specified string rules.
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetStrings(CharRuleset rule = CharRuleset.All)
            => GetCharacterSets(rule).Select(s => s.Value);

        /// <summary>
        /// Check if the specified string matches the specified rules.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool MatchesValue(string value, CharRuleset rule = CharRuleset.All)
            => GetCharacterSets(rule).All(s => s.Matches(value));
    }
}
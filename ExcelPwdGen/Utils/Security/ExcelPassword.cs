using System;
using System.Collections.Generic;
using ExcelPwdGen.Utils.Strings;

namespace ExcelPwdGen.Utils.Security
{
    internal class ExcelPassword : IEquatable<ExcelPassword>
    {
        /// <summary>
        /// Generates a random password candidate and returns its instance.
        /// </summary>
        /// <returns></returns>
        public static ExcelPassword Generate(uint len = MaxLength)
            => new ExcelPassword()
            {
                Value = PasswordGenerator.GenerateRandom(len, Ruleset)
            };

        /// <summary>
        /// Represents the maximum password length.
        /// </summary>
        /// <remarks>
        /// Excel for Mac のパスワードには 15 文字までの制限があります。 そのため、Windows 版の Excel でパスワード保護されている場合 (パスワードが 15 文字を超える場合)、ブックまたは文書を開くことができません。<br/>
        /// https://support.microsoft.com/ja-jp/office/%E3%83%96%E3%83%83%E3%82%AF%E3%82%92%E4%BF%9D%E8%AD%B7%E3%81%99%E3%82%8B-7e365a4d-3e89-4616-84ca-1931257c1517#ID0EBBH=macOS
        /// </remarks>
        public const uint MaxLength = 15;

        public const uint MinLength = PasswordGenerator.MinLength;

        public const CharRuleset Ruleset = CharRuleset.All;

        private string _value = string.Empty;

        public string Value
        {
            get => _value;
            set => _value = value == null ? string.Empty : value.Trim();
        }

        public int Length => Value.Length;

        public ExcelPassword()
        {
        }

        public ExcelPassword(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Validate the password.
        /// </summary>
        /// <returns>validation result and error messages.</returns>
        public (bool ok, string[] errors) Validate()
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(Value))
                errors.Add("Password is required");
            if (Value.Length < MinLength)
                errors.Add($"Password must be at least {MinLength} characters long");
            if (Value.Length > MaxLength)
                errors.Add($"Password must be less than {MaxLength} characters long");
            if (!CharRuleCollection.MatchesValue(Value, CharRuleset.All))
                errors.Add("Password must contain at least one lowercase letter, one uppercase letter, one number, and one special character");

            var results = errors.ToArray();
            return (results.Length == 0, results);
        }

        public bool Equals(ExcelPassword other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public bool Equals(string other) => Value == other;

        public override string ToString() => Value;
    }
}
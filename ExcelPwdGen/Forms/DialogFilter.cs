using System;
using System.Collections.Generic;

namespace ExcelPwdGen.Forms
{
    internal class DialogFilter
    {
        public enum FilterType
        {
            WinForms,
            Office,
        }

        private readonly Dictionary<string, string> _filters = new Dictionary<string, string>();
        public int Count => _filters.Count;

        public IEnumerable<string> Exts => _filters.Keys;

        public IEnumerable<string> Descriptions => _filters.Values;

        public FilterType _type = FilterType.WinForms;

        public FilterType Type => _type;

        public void Clear() => _filters.Clear();

        /// <summary>
        /// Add a filter to the dialog.
        /// </summary>
        /// <param name="ext">extension with <c>.</c></param>
        /// <param name="description">Explanation to the user about this extension</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public DialogFilter Add(string ext, string description)
        {
            if (!ext.StartsWith(".")) throw new ArgumentException("Extension must start with '.'", nameof(ext));
            if (_filters.ContainsKey(ext)) throw new ArgumentException("Extension already exists", nameof(ext));

            _filters.Add(ext, description);
            return this;
        }

        public DialogFilter SetFilterType(FilterType filterType)
        {
            _type = filterType;
            return this;
        }

        /// <summary>
        /// Get the configured result string for the dialog filter.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var items = new List<string>();
            foreach (var kv in _filters)
            {
                var ext = kv.Key;
                var desc = kv.Value;
                items.Add($"{desc} (*{ext})");
                items.Add($"*{ext}");
            }
            switch (_type)
            {
                case FilterType.WinForms:
                    return string.Join("|", items);

                case FilterType.Office:
                    return string.Join(",", items);

                default:
                    throw new ArgumentException("Invalid FilterType");
            }
        }
    }
}
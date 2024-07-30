namespace ExcelPwdGen.Forms
{
    public class ReadOptions
    {
        public enum ReadOption
        {
            None,
            ReadOnly,
            ReadOnlyRecommended,
        }

        public class Item
        {
            public string Name { get; set; }
            public ReadOption Value { get; set; }
        }

        public static Item[] Options { get; set; } = new[]
        {
            new Item { Name = "通常", Value = ReadOption.None },
            new Item { Name = "読み取り専用", Value = ReadOption.ReadOnly },
            new Item { Name = "読み取り専用推奨", Value = ReadOption.ReadOnlyRecommended },
        };
    }
}
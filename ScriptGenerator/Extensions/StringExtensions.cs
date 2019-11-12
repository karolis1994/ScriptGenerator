namespace ScriptGenerator.Extensions
{
    public static class StringExtensions
    {
        public static void ParseNullable(this string value, out int? result)
        {
            result = int.TryParse(value, out int outValue) ? (int?)outValue : null;
        }
    }
}

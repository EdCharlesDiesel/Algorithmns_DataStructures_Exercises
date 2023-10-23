namespace BreakCamelCase
{
    /// <summary>
    /// 
    /// </summary>
    public class BreakCamelCaseClass
    {
        public static IEnumerable<char> BreakCamelCase(string value)
        {
            int i = 1;

            foreach (char c in value)
            {
                var startIndex = value.IndexOf(char.IsUpper(c).ToString());
                value.Insert(startIndex, " ");
            }

            return value;
        }
    }
}
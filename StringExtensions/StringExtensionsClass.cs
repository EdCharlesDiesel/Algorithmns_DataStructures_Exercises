namespace StringExtensions
{
    /// <summary>
    /// Create a method to see whether the string is ALL CAPS.
    /// </summary>
    public class StringExtensionsClass
    {
        public static bool  StringExtensions(string value)
        {         
            return !value.Any(x => Char.IsLower(x));
        }
    }
}
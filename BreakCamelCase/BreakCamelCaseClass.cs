namespace BreakCamelCase
{
    /// <summary>
    /// 
    /// </summary>
    public class BreakCamelCaseClass
    {
        public static IEnumerable<char> BreakCamelCase(string value)
        {
            var test = 0;

            foreach (char c in value)
            {
                value.ToCharArray();
                var result = char.IsUpper(c);
                if (result == true)
                {
                    test = value.IndexOf(c);
                }
            }  
            var newCharArray = value.Insert(Convert.ToInt32(test), " ");
            

            return newCharArray;
        }
    }
}
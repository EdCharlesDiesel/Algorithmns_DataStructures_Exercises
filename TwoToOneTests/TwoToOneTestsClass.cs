namespace TwoToOneTests
{
    /// <summary>
    /// Take 2 strings s1 and s2 including only letters from a to z. 
    /// Return a new sorted string, the longest possible, containing
    /// distinct letters - each taken only once - coming from s1 or s2.
    /// </summary>
    public class TwoToOneTestsClass
    {
        public static string Longest(string arrayOne, string arrayTwo)
        {
            return string.Concat((arrayOne + arrayTwo).Distinct().OrderBy(x => x));
        }

        public static string LongestTwo(string s1, string s2)
        {
            return
                    new string(
                        s1.ToCharArray()
                            .Distinct()
                            .Concat(s2.ToCharArray().Distinct())
                            .Distinct()
                            .OrderBy(x => x)
                            .ToArray());
        }

        public static string LongestDictionary(string s1, string s2)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            foreach (char c in s1)
            {
                if (!table.ContainsKey(c)) table[c] = 0;
                table[c] = table[c] + 1;
            }
            foreach (char c in s2)
            {
                if (!table.ContainsKey(c)) table[c] = 0;
                table[c] = table[c] + 1;
            }
            char[] lstr = table.Keys.ToArray();
            Array.Sort(lstr);
            string res = string.Join("", lstr);
            return res;
        }
    }
}
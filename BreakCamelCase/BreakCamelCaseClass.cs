using System;
using System.Linq;
using System.Text;

namespace BreakCamelCase
{
    /// <summary>
    /// Complete the solution so that the function will break up 
    /// camel casing, using a space between words.
    ///
    /// Example
    /// "camelCasing"  =>  "camel Casing"
    /// "identifier"   =>  "identifier"
    /// ""             =>  ""
    /// </summary>
    public class BreakCamelCaseClass
    {
        public static string BreakCamelCase(string str)
        {
            return String.Join("", str.Select(x => char.IsUpper(x) ? " " + x : x.ToString()));
        }

        public static string BreakCamelCaseSolutionOne(string str)
        {
            var sb = new StringBuilder();
            foreach (var symbol in str)
            {
                if (char.IsUpper(symbol)) sb.Append(" ");
                sb.Append(symbol);
            }
            return sb.ToString().Trim();
        }

        public static string BreakCamelCaseSecondSolution(string str)
        {
            var res = new StringBuilder();
            foreach (var ch in str)
            {
                if (ch >= 'A' && ch <= 'Z')
                {
                    res.Append(" ");
                }
                res.Append(ch);
            }
            return res.ToString();
        }
    }
}
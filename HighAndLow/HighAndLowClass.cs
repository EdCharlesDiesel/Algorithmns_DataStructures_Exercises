using System;
using System.Linq;

namespace HighAndLow
{
    /// <summary>
    /// In this little assignment you are given a string of space separated numbers, and have to return the highest and lowest number.
    /// 
    /// -All numbers are valid Int32, no need to validate them.
    /// -There will always be at least one number in the input string.
    /// -Output string must be two numbers separated by a single space, and highest number is first.
    /// </summary>
    public class HighAndLowClass
    {
        public static string HighAndLow(string numbers)
        {
            var parsed = numbers.Split().Select(int.Parse);
            return parsed.Max() + " " + parsed.Min();
        }

        public static string HighAndLowSolutionTwo(string numbers)
        {
            var parsed = numbers.Split().Select(int.Parse);
            return parsed.Max() + " " + parsed.Min();
        }

        public static string HighAndLowSolutionThree(string numbers)
        {
            var numbersList = numbers.Split(' ').Select(x => Convert.ToInt32(x));
            return string.Format("{0} {1}", numbersList.Max(), numbersList.Min());
        }

        public static string HighAndLowSolutionFour(string numbers)
        {
            var nums = numbers.Split(' ').Select(Int32.Parse).ToArray();
            return $"{nums.Max()} {nums.Min()}";
        }

        
    }
}
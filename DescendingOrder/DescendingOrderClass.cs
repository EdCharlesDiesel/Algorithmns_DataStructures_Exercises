using System;
using System.Collections.Generic;
using System.Linq;

namespace DescendingOrder
{
    /// <summary>
    /// Your task is to make a function that can take any non-negative 
    /// integer as an argument and return it with its digits in 
    /// descending order. Essentially, rearrange the digits to 
    /// create the highest possible number.
    /// </summary>
    public class DescendingOrderClass
    {   
        public static int DescendingOrder(int number)
        {
            var splittedList = number.ToString().Select(x => (int)char.GetNumericValue(x)).ToArray();
            Array.Sort(splittedList);
            Array.Reverse(splittedList);

            var result = String.Join("", new List<int>(splittedList).ConvertAll(i => i.ToString()).ToArray());
            
            return Convert.ToInt32(result);           
        }

        public static int DescendingOrderSolutionTwo(int number)
        {
            return int.Parse(string.Concat(number.ToString().OrderByDescending(x => x)));
        }

        public static int DescendingOrderSolutionThree(int num)
        {
            char[] arr = num.ToString().ToCharArray();
            Array.Sort(arr);
            Array.Reverse(arr);
            return Convert.ToInt32(new string(arr));
        }
    }
}
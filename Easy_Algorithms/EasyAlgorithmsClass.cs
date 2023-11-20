using System.Text;

namespace Easy_Algorithms
{
    public class EasyAlgorithmsClass
    {
        #region TwoToOneTests
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
        #endregion

        #region SumTwoSmallestNumbers
        /// <summary>
        /// Create a function that returns the sum of the two lowest positive numbers 
        /// given an array of minimum 4 positive integers. No floats or non-positive 
        /// integers will be passed.

        /// For example, when an array is passed like[19, 5, 42, 2, 77], the output should be 7.
        /// [10, 343445353, 3453445, 3453545353453] should return 3453455.
        /// </summary>
        public class SumTwoSmallestNumbersClass
        {
            public static int SumTwoSmallestNumbers(int[] numbers)
            {
                Array.Sort(numbers);
                var result = 0;
                for (int i = 0; i < 2; i++)
                {
                    result += numbers[i];
                }
                return result;
            }
        } 
        #endregion

        #region StringExtensions

        /// <summary>
        /// Create a method to see whether the string is ALL CAPS.
        /// </summary>
        public class StringExtensionsClass
        {
            public static bool StringExtensions(string value)
            {
                return !value.Any(x => Char.IsLower(x));
            }
        } 
        #endregion

        #region QuickSort        
        public class QuickSortExerciseClass
        {
            public static void QuickSort(int[] array, int low, int high)
            {
                if (low > high)
                {
                    int pi = Partition(array, low, high);
                    QuickSort(array, low, pi - 1);
                    QuickSort(array, pi + 1, high);
                }
                throw new NotImplementedException();

            }

            private static int Partition(int[] array, int low, int high)
            {
                int pivot = array[low];
                int i = array[low + 1];
                int j = array[high];

                do
                {
                    while (i <= j && array[i] <= pivot)
                    {
                        i = i + 1;
                    }
                    while (i <= j && array[j] > pivot)
                        j = j - 1;
                    if (i <= j)
                        Swap(array, i, j);

                } while (i < j);
                Swap(array, low, j);
                return j;
            }

            private static void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        #endregion

        #region MinMax
        /// <summary>
        /// Ben has a very simple idea to make some profit: he buys something and sells it again. 
        /// Of course, this wouldn't give him any profit at all if he was simply to buy and 
        /// sell it at the same price. Instead, he's going to buy it for the lowest 
        /// possible price and sell it at the highest.


        /// -Write a function that returns both the minimum and maximum number of the given list/array.
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public class MinMaxClass
        {
            public static int[] minMax(int[] lst)
            {
                Array.Sort(lst);
                var min = lst[0];
                var max = lst[lst.Length - 1];

                return new int[] { min, max };
            }
        } 
        #endregion

        #region InsertionSort        
        public class InsertionSortExerciseClass
        {
            public static void InsertionSort(int[] array, int limit)
            {
                for (int i = 1; i < limit; i++)
                {
                    int temp = array[i];
                    int position = i;

                    while (position > 0 && array[position - 1] > temp)
                    {
                        array[position] = array[position - 1];
                        position = position - 1;
                    }

                    array[position] = temp;
                }
            }
        }
        #endregion

        #region HighAndLow
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
        #endregion

        #region DescendingOrder
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
        #endregion

        #region BreakCamelCaseClass
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
        #endregion
    }
}
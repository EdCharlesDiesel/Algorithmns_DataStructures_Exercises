using System.Text;

namespace Easy_Algorithms
{
    public class EasyAlgorithmsClass
    {
        #region EvaluateExpressionTree
        /// <summary>
        /// 
        /// </summary>
        public class EvaluateExpressionTreeClass
        {
            public int EvaluateExpressionTree(BinaryTree tree)
            {
                if (tree.value >= 0)
                {
                    return tree.value;
                }

                int leftValue = EvaluateExpressionTree(tree.left);
                int rightValue = EvaluateExpressionTree(tree.right);

                if (tree.value == -1)
                {
                    return leftValue + rightValue;
                }
                else if (tree.value == -2)
                {
                    return leftValue - rightValue;
                }
                else if (tree.value == -3)
                {
                    return leftValue / rightValue;
                }

                return leftValue * rightValue;
            }



            public class BinaryTree
            {
                public int value;
                public BinaryTree left = null;
                public BinaryTree right = null;

                public BinaryTree(int value)
                {
                    this.value = value;
                }
            }
        } 
        #endregion

        #region NonConstructibleChange
        /// <summary>
        /// Given an array of positive integers representing the values of coins in your possession,
        /// write a function that returns the minimum amount of change (minimum sum of money) that
        /// you cannot create. The given coins can have any positive integer value and arent 
        /// necessarily unique (i.e., you can have multiple coins of the same value). 
        /// 
        /// For example, if you're given coins = [1,2,5], the minimum amount of change that you
        /// can't create is 4. If you're given no coins, the minimum amount of change that you can't
        /// is 1.
        /// 
        /// </summary>
        public class NonConstructibleChangeClass
        {
            // O(nlogn) time | O(1) space - where n is the number of coins
            public int NonConstructibleChange(int[] coins)
            {
                Array.Sort(coins);

                var currentChangeCreated = 0;
                foreach (var coin in coins)
                {
                    if (coin > currentChangeCreated + 1)
                    {
                        return currentChangeCreated + 1;
                    }
                    currentChangeCreated += coin;
                }

                return currentChangeCreated + 1;
            }
        } 
        #endregion

        #region SortedSquaredArray
        public class SortedSquaredArrayClass
        {
            /// <summary>
            /// Write a function that takes in a non-empty array of integers that are sorted
            /// in ascending  order and returns a new array of the saw length with the squares
            /// of the original integer  also sorted in ascending order.
            /// </summary>
            /// <param name="array"></param>
            /// <returns></returns>
            public int[] SortedSquaredArray(int[] array)
            {
                var sortedSquares = new int[array.Length];
                for (int index = 0; index < array.Length; index++)
                {
                    var value = array[index];
                    sortedSquares[index] = value * value;
                }

                Array.Sort(sortedSquares);
                return sortedSquares;
            }
        } 
        #endregion

        #region TournamentWinner
        public class TournamentWinnerClass
        {
            /// <summary>
            /// There's an algorithms tournament taking place in which teams of programmers compete against
            /// each other to solve algorithmic problems as fast as possible. Teams compete in round robin,
            /// where each team faces off against all other teams. Only two teams compete against each team
            /// other at a time, and for each competition, one team is designated the home team, while the 
            /// other team is the away team. In each competition, there's always one winner and one loser; there
            /// are no ties. A team receives 3 points if it wins and 0 points if it loses. The winner of the 
            /// tournament is the team that receives 3 points it it wins 0 point it it loses. The winner of the 
            /// tournament is the team that receives the most points.
            /// 
            /// Given an array of pairs representing the teams that have completed against  each other and
            /// an array counting the result of each competition, Write a function that returns the winner of
            /// the tournament . The input arrays are names competitions and result, respectively. The 
            /// competitions array has elements in the form of [homeTeam, awayTeam ], where each team is a 
            /// string of at mos 30 characters representing the name of the team. The results array contains
            /// information about  the winner of each  corresponding competition in the competition array. 
            /// Specifically, results[i] denotes the winner of competitions[i], where 1 in the results array 
            /// means that the home team team in the corresponding competition won a 0 means that the away 
            /// team won.
            /// 
            /// it's guaranteed that exactly one team will win the tournament and thateach team will compete
            /// agaist all other teamns exactly once. It's also guaranteed that the tournament will always have 
            /// at leat two teamns.
            /// 
            /// </summary>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public int HOME_TEAM_WON = 1;

            public string TournamentWinner(List<List<string>> competitions, List<int> results)
            {
                var currentBestTeam = "";
                var scores = new Dictionary<string, int>();
                scores[currentBestTeam] = 0;

                for (int index = 0; index < competitions.Count; index++)
                {
                    List<string> competition = competitions[index];
                    int result = results[index];

                    var homeTeam = competition[0];
                    var awayTeam = competition[1];

                    string winingTeam = (result == HOME_TEAM_WON) ? homeTeam : awayTeam;

                    updateScores(winingTeam, 3, scores);

                    if (scores[winingTeam] > scores[currentBestTeam])
                    {
                        currentBestTeam = winingTeam;
                    }
                }

                return currentBestTeam;
            }

            private void updateScores(string winingTeam, int points, Dictionary<string, int> scores)
            {
                if (!scores.ContainsKey(winingTeam))
                {
                    scores[winingTeam] = 0;
                }

                scores[winingTeam] += points;
            }
        } 
        #endregion

        #region TransposeMatrix
        /// <summary>
        /// You're given a 2D array of integers matrix. Write a function that returns the transpose
        /// of the matrix.
        /// 
        /// The transpose of a matrix is a flipped version of the original matrix across it's main diagonal
        /// (which runs from top-left to bottom-righ); It switches the row and column indices of the
        /// original matrix.
        /// 
        /// You can assume that the inout matrix always has atleast 1 value;however its width and heigh 
        /// are not necessarily the same.
        /// </summary>
        public class TransposeMatrixClass
        {
            public int[,] TransposeMatrix(int[,] matrix)
            {
                var transposeMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

                for (var col = 0; col < matrix.GetLength(1); col++)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        transposeMatrix[col, row] = matrix[row, col];
                    }
                }

                return transposeMatrix;
            }
        } 
        #endregion

        #region IsValidSubsequence
        /// <summary>
        /// Given two non-empty array of integers, write a function that determines whether the second
        /// array is a subsequence of the first one.
        /// 
        /// A subsequence of an array is a set of numbers that aren't necessarily adjacent in the array 
        /// but that are in the same order as they appear in the array. Fo instance, the number [1,3,4]
        /// form a subsequence of an array [1,2,3,4]. and so do the number [2,4]. note that a single 
        /// number in an array and the array itself are both valid subsequence of the array.
        /// </summary>
        public static class ValidateSubsequenceClass
        {
            public static bool IsValidSubsequence(List<int> array, List<int> sequence)
            {
                var sequenceIndex = 0;
                foreach (var val in array)
                {
                    if (sequenceIndex == sequence.Count)
                    {
                        break;
                    }

                    if (sequence[sequenceIndex] == val)
                    {
                        sequenceIndex++;
                    }
                }
                return sequenceIndex == sequence.Count;
            }
        } 
        #endregion

        #region TwoNumberSum
        public class TwoNumberSumClass
        {
            /// <summary>
            /// Write a function that takes in a non-empty array of distinct integers and an integer 
            /// representing a target sum. If any two numbers in the input array sum the target sum,
            /// the function should return them in an array, in any order. If no two numbers sum up to 
            /// to the target sum up to the target sum, the function should return an empty.
            /// 
            /// Note that the target sum has to be obtained by summing two different integers in
            /// the array; you can't add a single integer to itself in order to obtain the target sum.
            /// 
            /// You can assume that there will be at most pair of numbers summing up to the target sum.
            /// </summary>
            /// <param name="array"></param>
            /// <param name="targetSum"></param>
            /// <returns></returns>
            /// <exception cref="NotImplementedException"></exception>
            public int[] TwoNumberSum(int[] array, int targetSum)
            {
                for (var i = 0; i < array.Length - 1; i++)
                {
                    var firstNum = array[i];
                    for (var j = i + 1; j < array.Length; j++)
                    {
                        var secondNum = array[j];
                        if (firstNum + secondNum == targetSum)
                        {
                            return new int[] { firstNum, secondNum };
                        }
                    }
                }

                return Array.Empty<int>();
            }
        }
        #endregion

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
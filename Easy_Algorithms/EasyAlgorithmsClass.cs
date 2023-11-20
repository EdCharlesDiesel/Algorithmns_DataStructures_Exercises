using System.Text;
using static Easy_Algorithms.EasyAlgorithmsClass.BranchSumsClass;

namespace Easy_Algorithms
{
    public class EasyAlgorithmsClass
    {
        #region NodeDepths
        // Average case: when the tree is balanced
        // O(n) time | O(h) space - where n is the number of nodes in
        // the Binary Tree and h is the height of the Binary Tree
        public class NodeDepthsClass
        {
            public class BinaryTree
            {
                public int value;
                public BinaryTree left;
                public BinaryTree right;
                public BinaryTree(int value)
                {
                    this.value = value;
                    left = null;
                    right = null;
                }
            }

            public class Level
            {
                public BinaryTree root;
                public int depth;
                public Level(BinaryTree root, int depth)
                {
                    this.root = root;
                    this.depth = depth;
                }
            }
            public static int NodeDepths(BinaryTree root)
            {
                int sumOfDepths = 0;
                Stack<Level> stack = new Stack<Level>();
                stack.Push(new Level(root, 0));
                while (stack.Count > 0)
                {
                    Level top = stack.Pop();
                    BinaryTree node = top.root;
                    int depth = top.depth;
                    if (node == null) continue;
                    sumOfDepths += depth;
                    stack.Push(new Level(node.left, depth + 1));
                    stack.Push(new Level(node.right, depth + 1));
                }
                return sumOfDepths;
            }
        }


        public class NodeDepthsClass_Solution2
        {
            // Average case: when the tree is balanced
            // O(n) time | O(h) space - where n is the number of nodes in
            // the Binary Tree and h is the height of the Binary Tree
            public static int NodeDepths(BinaryTree root)
            {
                return nodeDepthsHelper(root, 0);
            }

            public static int nodeDepthsHelper(BinaryTree root, int depth)
            {
                if (root == null) return 0;
                return depth + nodeDepthsHelper(root.left, depth + 1) + nodeDepthsHelper(root.right,
                depth + 1);
            }
        }



        #endregion

        #region BranchSums
        /// <summary>
        /// 
        /// </summary>
        public class BranchSumsClass
        {
            public class BinaryTree
            {
                public int value;
                public BinaryTree left;
                public BinaryTree right;
                public BinaryTree(int value)
                {
                    this.value = value;
                    this.left = null;
                    this.right = null;
                }
            }
            public static List<int> BranchSums(BinaryTree root)
            {
                List<int> sums = new List<int>();
                calculateBranchSums(root, 0, sums);
                return sums;
            }

            public static void calculateBranchSums(
                BinaryTree node, int runningSum, List<int> sums)
            {
                if (node == null) return;
                int newRunningSum = runningSum + node.value;
                if (node.left == null && node.right == null)
                {
                    sums.Add(newRunningSum);
                    return;
                }
            }
        }
        #endregion

        #region FindClosestValueInBst
        /// <summary>
        /// Write a function that takes in a Binary Tree(BTS) and a target integer value and returns
        /// the closest value to that target value contained in the BTS.
        ///
        /// You can assume that there will only be one closet value.
        ///
        /// Each BTS node has an integer valie, a left child node, and right child node.A node is
        /// said to be a valid BTS node id and only id it satisfies the BTS property: its value is
        /// strictly greater than the values of every node to its value; its value is less than or
        /// equal to the values of every node to its right
        /// tha
        /// </summary>
        public static class FindClosestValueInBstClass
        {
            // Average: O(log(n)) time | O(log(n)) space
            // Worst: O(n) time | O(n) space
            public static int FindClosestValueInBst(Bst tree, int target)
            {
                return FindClosestValueInBst(tree, target, Int32.MaxValue);
            }

            private static int FindClosestValueInBst(Bst tree, int target, double closest)
            {
                if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
                {
                    closest = tree.value;
                }
                if (target < tree.value && tree.left != null)
                {
                    return FindClosestValueInBst(tree.left, target, closest);
                }
                else if (target > tree.value && tree.right != null)
                {
                    return FindClosestValueInBst(tree.right, target, closest);
                }
                else
                {
                    return (int)closest;
                }
            }
            public class Bst
            {
                public int value;
                public Bst left = null!;
                public Bst right = null!;
                public Bst(int value)
                {
                    this.value = value;
                }
            }
        }
        #endregion

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

        #region WellofIdeasEasyVersion
        /// <summary>
        /// For every good kata idea there seem to be quite a few bad ones!
        //In this kata you need to check the provided array (x) for good
        //ideas 'good' and bad ideas 'bad'. If there are one or two good
        //ideas, return 'Publish!', if there are more than 2 return
        //'I smell a series!'. If there are no good ideas, as is often
        //the case, return 'Fail!'.
        /// </summary>
        public class WellofIdeasEasyVersionClass
        {
            public static IEnumerable<char> Well(string[] stringsArray)
            {
                IEnumerable<char> result = new char[stringsArray.Length];
                for (int i = 0; i < stringsArray.Length; i++)
                {
                    if (stringsArray.Contains(stringsArray[i]))
                    {
                        //result[]
                    }

                }


                //string[] badwords = newStringArray.Split(newStringArray, StringSplitOptions.None);
                //foreach (string firstName in firstNames)
                //    Console.WriteLine(firstName);
                //string[] authorsList = stringsArray.Split(" ,");

                return result;
            }
        }
        #endregion

        #region ArraysEqual
        /// <summary>
        /// Write a program, which reads two arrays from the console and 
        /// checks whether they are equal (two arrays are equal when they 
        /// are of equal length and all of their elements, which have 
        /// the same index, are equal).
        /// </summary>
        public class ArraysAreEqualClass
        {
            public static bool ArraysEqual(int[] arrayOne, int[] arrayTwo)
            {

                int[] arr1 = new int[arrayOne.Length];
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    arr1[i] = arrayOne[i];
                }
                int[] arr2 = new int[arrayTwo.Length];
                for (int i = 0; i < arrayTwo.Length; i++)
                {
                    arr2[i] = arrayTwo[i];
                }

                int counterOfEqualElements = 0;
                if (arr1.Length != arr2.Length)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        if (arr1[i] == arr2[i])
                        {
                            counterOfEqualElements++;
                        }
                    }
                    if (counterOfEqualElements == arr1.Length)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            public static int[] CheckArray(int[] array)
            {
                //array[0] = 1;
                //array[1] = 2;
                //array[2] = 3;
                //array[3] = 4;
                //array[4] = 5;
                //array[5] = 6;

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = i + 1;
                }

                return array;
            }

            public static int[,] GetBestPlatform(int[,] matrix)
            {
                long bestSum = long.MinValue;
                int bestRow = 0;
                int bestCol = 0;
                int[,] newMatrix = new int[2, 4];

                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                    {
                        long sum = matrix[row, col] +
                            matrix[row, col + 1] +
                            matrix[row + 1, col] +
                            matrix[row + 1, col + 1];

                        if (sum > bestSum)
                        {
                            bestSum = sum;
                            bestRow = row;
                            bestCol = col;
                        }
                    }
                }
                return matrix;
            }


            public static int[,] MatriceArray(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix[i, j];
                    }
                }
                return matrix;
            }

            public static int[] ReverseArray(int[] initialArray)
            {
                // Get array size
                int length = initialArray.Length;
                // Declare and create the reversed array
                int[] reversed = new int[length];
                // Initialize the reversed array
                for (int index = 0; index < length; index++)
                {
                    reversed[length - index - 1] = initialArray[index];
                }

                return reversed;
            }

            public static bool SymmetricArray(int[] arrayWithValue)
            {

                int n = arrayWithValue.Length;
                int[] array = new int[n];

                for (int i = 0; i < n; i++)
                {
                    array[i] = arrayWithValue[i];
                }
                bool symmetric = true;
                for (int i = 0; i < array.Length / 2; i++)
                {
                    if (array[i] != array[n - i - 1])
                    {
                        return symmetric = false;
                        break;
                    }
                }
                return symmetric;
            }
        }
        #endregion

        #region BinarySeach
        public class BinarySeachIterativelyClass
        {
            public int BinarySearchIteritevely(int[] inputArray, int numberOfElements, int key)
            {
                Array.Sort(inputArray);
                int leftIndex = 0;
                int rightIndex = numberOfElements - 1;
                while (leftIndex <= rightIndex)
                {
                    int middleElement = (leftIndex + rightIndex) / 2;
                    if (key == inputArray[middleElement])
                        return middleElement;
                    else if (key < inputArray[middleElement])
                        rightIndex = middleElement - 1;
                    else if (key > inputArray[middleElement])
                        leftIndex = middleElement + 1;
                }
                return -1;
            }

            public int BinarysearchRecursion(int[] A, int key, int l, int r)
            {
                if (l > r)
                    return -1;
                else
                {
                    int mid = (l + r) / 2;
                    if (key == A[mid])
                        return mid;
                    else if (key < A[mid])
                        return BinarysearchRecursion(A, key, l, mid - 1);
                    else if (key > A[mid])
                        return BinarysearchRecursion(A, key, mid + 1, r);
                }
                return -1;
            }
        }
        #endregion

        #region SumArray
        /// <summary>
        /// Write a function that takes an array of numbers 
        /// and returns the sum of the numbers. The numbers 
        /// can be negative or non-integer. If the array 
        /// does not contain any numbers then you should return 0.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static class SumArrayClass
        {
            public static double SumArray(double[] array)
            {
                double[] newArray = new double[array.Length];
                double sumArray = 0;

                foreach (var item in array)
                {
                    sumArray = item + item;
                }

                return sumArray;
            }
        }
        #endregion

        #region SubsequenceWithMaxSum
        /// <summary>
        /// Write a program, which finds a subsequence of 
        /// numbers with maximal sum. E.g.: 
        /// {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> 11
        /// </summary>
        public class SubsequenceWithMaxSumClass
        {
            public void SubsequenceWithMaxSum()
            {
                string inputArrayOne = Console.ReadLine();
                char[] delimiter = new char[] { ',', ' ' };
                string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                int[] arr = new int[inputOne.Length];
                for (int i = 0; i < inputOne.Length; i++)
                {
                    arr[i] = int.Parse(inputOne[i]);
                }

                int maxSum = 0;
                int currentSum = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    currentSum += arr[i];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                    else if (currentSum < 0)
                    {
                        currentSum = 0;
                    }
                }

                Console.WriteLine(maxSum);

            }
        }
        #endregion

        #region ShellSort
        /// <summary>
        /// Need to complete this
        /// </summary>
        public static class ShellSortClass
        {
            public static void ShellSort(int[] array, int length)
            {
                int gap = length / 2;
                while (gap > 0)
                {
                    int i = gap;
                    while (i < length)
                    {
                        int temp = array[i];
                        int j = i - gap;
                        while (j >= 0 && array[j] > temp)
                        {
                            array[j + gap] = array[j];
                            j = j - gap;
                        }
                        array[j + gap] = temp;
                        i = i + 1;
                    }
                    gap = gap / 2;
                }
            }
        }
        #endregion

        #region SelectionSort
        /// <summary>
        /// 
        /// </summary>
        public class SelectionSortClass
        {

            public int[] SelectionSort(int[] array, int numberOfElements)
            {
                for (int i = 0; i < numberOfElements - 1; i++)
                {
                    int posistion = i;
                    for (int j = i + 1; j < numberOfElements; j++)
                    {
                        if (array[j] < array[posistion])
                        {
                            posistion = j;
                        }
                    }

                    int temp = array[i];
                    array[i] = array[posistion];
                    array[posistion] = temp;

                }

                return array;
            }
        }
        #endregion

        #region Linearsearch
        /// <summary>
        /// 
        /// </summary>
        public class LinearSearchclass
        {
            public static int Linearsearch(int[] inputArray, int numberOfElements, int key)
            {
                int index = 0;
                while (index < numberOfElements)
                {
                    if (inputArray[index] == key)
                        return index;
                    index++;
                }
                return -1;
            }
        }
        #endregion

        #region PrintMatrix
        /// <summary>
        /// Write a program, which creates square matrices like those in the 
        /// figures below and prints them formatted to the console. 
        /// The size of the matrices will be read from the console. 
        /// See the examples for matrices with size of 4 x 4 and 
        /// make the other sizes in a similar fashion:
        /// </summary>
        public class PrintMatrixClass
        {
            public static void PrintMatrix()
            {
                int n = int.Parse(Console.ReadLine());

                int[,] matrix = DoMatrixA(n);
                PrintMatrix(matrix);

                Console.WriteLine();

                matrix = DoMatrixB(n);
                PrintMatrix(matrix);

                Console.WriteLine();

                matrix = DoMatrixC(n);
                PrintMatrix(matrix);

                Console.WriteLine();

                matrix = DoMatrixD(n);
                PrintMatrix(matrix);

                Console.WriteLine();
            }

            static int[,] DoMatrixA(int dim)
            {
                int[,] matrix = new int[dim, dim];

                matrix[0, 0] = 1;
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    matrix[0, i] = matrix[0, i - 1] + dim;
                }

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = matrix[i - 1, j] + 1;
                    }
                }

                return matrix;
            }

            static int[,] DoMatrixB(int dim)
            {
                int[,] matrix = new int[dim, dim];
                matrix[0, 0] = 1;

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (i % 2 == 1)
                    {
                        matrix[0, i] = matrix[0, i - 1] + dim * 2 - 1;
                    }
                    else
                    {
                        matrix[0, i] = matrix[0, i - 1] + 1;
                    }
                }

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j % 2 == 1)
                        {
                            matrix[i, j] = matrix[i - 1, j] - 1;
                        }
                        else
                        {
                            matrix[i, j] = matrix[i - 1, j] + 1;
                        }
                    }
                }

                return matrix;
            }

            static int[,] DoMatrixC(int dim)
            {
                int[,] matrix = new int[dim, dim];
                matrix[dim - 1, 0] = 1;
                int counter = 1;
                for (int row = dim - 2; row >= 0; row--)
                {
                    matrix[row, 0] = matrix[row + 1, 0] + counter;
                    int newRow = row;
                    for (int diagonal = 1; diagonal <= counter; diagonal++)
                    {
                        matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                        newRow++;
                    }
                    counter++;
                }

                matrix[0, dim - 1] = dim * dim;
                int diagonalLength = 2;
                int posX = 1;
                int posY = dim - 1;
                int prevX = 0;
                int prevY = dim - 1;

                for (int i = 1; i < counter - 1; i++)
                {
                    for (int j = 1; j <= diagonalLength; j++)
                    {
                        matrix[posX, posY] = matrix[prevX, prevY] - 1;
                        prevX = posX;
                        prevY = posY;
                        posX--;
                        posY--;
                    }
                    diagonalLength++;
                    posX = i + 1;
                    posY = dim - 1;
                }

                return matrix;
            }

            static int[,] DoMatrixD(int dim)
            {
                int[,] matrix = new int[dim, dim];
                int numConcentricSquares = (int)Math.Ceiling((dim) / 2.0);
                int j;
                int sideLen = dim;
                int currNum = 0;

                for (int i = 0; i < numConcentricSquares; i++)
                {

                    // do left side
                    for (j = 0; j < sideLen; j++)
                    {
                        matrix[i + j, i] = ++currNum;
                    }

                    // do bottom side
                    for (j = 1; j < sideLen - 1; j++)
                    {
                        matrix[dim - 1 - i, i + j] = ++currNum;
                    }

                    // do right side
                    for (j = sideLen - 1; j > 0; j--)
                    {
                        matrix[i + j, dim - 1 - i] = ++currNum;
                    }

                    // do top side
                    for (j = sideLen - 1; j > 0; j--)
                    {
                        matrix[i, i + j] = ++currNum;
                    }

                    sideLen -= 2;
                }

                return matrix;
            }

            static void PrintMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write("{0, 4}", matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }
        #endregion

        #region MostFrequentNumber
        /// <summary>
        /// 
        /// </summary>
        public class MostFrequentNumberClass
        {
            public static void MostFrequentNumber()
            {
                string inputArrayOne = Console.ReadLine();
                char[] delimiter = new char[] { ',', ' ' };
                string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                int[] arr = new int[inputOne.Length];
                for (int i = 0; i < inputOne.Length; i++)
                {
                    arr[i] = int.Parse(inputOne[i]);
                }

                int tempCounter = 1;
                int counter = 0;
                int index = 0;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 1; j < arr.Length; j++)
                    {
                        if (arr[i] == arr[j])
                        {
                            tempCounter++;
                        }
                    }
                    if (tempCounter > counter)
                    {
                        counter = tempCounter;
                        index = i;
                    }
                    tempCounter = 0;

                }
                Console.WriteLine(arr[index] + "  " + counter + " times");

            }
        }
        #endregion

        #region MergeSort
        /// <summary>
        /// 
        /// </summary>
        public static class MergeSortClass
        {
            public static void MergeSort(int[] arrayOne, int left, int right)
            {
                if (left < right)
                {
                    int mid = (left + right) / 2;
                    MergeSort(arrayOne, left, mid);
                    MergeSort(arrayOne, mid + 1, right);
                    Merge(arrayOne, left, mid, right);
                }
            }

            public static void Merge(int[] arrayOne, int left, int mid, int right)
            {
                int i = left;
                int j = mid + 1;
                int k = left;
                int[] arrayTwo = new int[right + 1];
                while (i <= mid && j <= right)
                {
                    if (arrayOne[i] < arrayOne[j])
                    {
                        arrayTwo[k] = arrayOne[i];
                        i = i + 1;
                    }
                    else
                    {
                        arrayTwo[k] = arrayOne[j];
                        j = j + 1;
                    }
                    k = k + 1;
                }
                while (i <= mid)
                {
                    arrayTwo[k] = arrayOne[i];
                    i = i + 1;
                    k = k + 1;
                }
                while (j <= right)
                {
                    arrayTwo[k] = arrayOne[j];
                    j = j + 1;
                    k = k + 1;
                }
                for (int x = left; x < right + 1; x++)
                    arrayOne[x] = arrayTwo[x];
            }
        }
        #endregion

        #region MaximalSequenceOfIncreasingElements
        /// <summary>
        /// Write a program, which finds the maximal sequence of increasing 
        /// elements in an array arr[n]. It is not necessary the elements
        /// to be consecutively placed. 
        /// E.g.: {9, 6, 2, 7, 4, 7, 6, 5, 8, 4} > {2, 4, 6, 8}.
        /// </summary>
        public class MaximalSequenceOfIncreasingElementsClass
        {

        }
        #endregion

        #region LongestSeqOfEqualElements
        /// <summary>
        /// 
        /// </summary>
        public class LongestSeqOfEqualElementsClass
        {
            public static string[] LongestSeqOfEqualElements()
            {
                string inputArrayOne = Console.ReadLine();
                char[] delimiter = new char[] { ',', ' ' };
                string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                int[] arr = new int[inputOne.Length];
                for (int i = 0; i < inputOne.Length; i++)
                {
                    arr[i] = int.Parse(inputOne[i]);
                }

                int counter = 0;
                int maxSequence = 0;
                int index = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    counter = 0;
                    int j = i;

                    while (arr[i] == arr[j])
                    {
                        counter++;
                        j++;
                        if (j >= arr.Length)
                        {
                            break;
                        }
                    }

                    if (counter > maxSequence)
                    {
                        maxSequence = counter;
                        index = i;
                    }
                }

                for (int i = index; i <= index + maxSequence - 1; i++)
                {
                    if (i != index + maxSequence - 1)
                    {
                        Console.Write(arr[i] + ", ");
                    }
                    else
                    {
                        Console.WriteLine(arr[i]);
                    }

                    //return arr[i].ToCharArray();
                }

                return new string[0];
            }
        }
        #endregion

        #region ListFilterer
        /// <summary>
        /// 
        /// </summary>
        public class ListFiltererClass
        {
            public static IEnumerable<int> GetIntegersFromList(List<object> list)
            {
                var intergerList = new List<int>();
                foreach (var item in list)
                {
                    if (item is int)
                    {
                        intergerList.Add((int)item);
                    }
                }

                return intergerList;
            }

            public static IEnumerable<int> GetIntegersFromListCast(List<object> list)
            {

                return list.OfType<int>().Cast<int>();
            }
        }
        #endregion

        #region LinkedList
        public class LinkedListClass
        {
            private class Node
            {
                public int element;
                public Node next;
                public Node(int e, Node n)
                {
                    element = e;
                    next = n;
                }
            }
            private Node? first;
            private Node? last;
            private int size;

            public LinkedListClass()
            {
                first = null;
                last = null;
                size = 0;
            }

            public int Count()
            {
                return size;
            }

            public bool isEmpty()
            {
                return size == 0;
            }

            public void AddLast(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                    first = newest;
                else
                    last.next = newest;
                last = newest;
                size = size + 1;
            }

            public void AddFirst(int e)
            {
                Node newest = new Node(e, null);
                if (isEmpty())
                {
                    first = newest;
                    last = newest;
                }
                else
                {
                    newest.next = first;
                    first = newest;
                }
                size = size + 1;
            }

            public void AddAny(int e, int position)
            {
                if (position <= 0 || position >= size)
                {
                    Console.WriteLine("Invalid Position");
                    return;
                }
                Node newest = new Node(e, null);
                Node p = first;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i = i + 1;
                }
                newest.next = p.next;
                p.next = newest;
                size = size + 1;
            }

            public int RemoveFirst()
            {
                if (isEmpty())
                {
                    Console.WriteLine("List is Empty");
                    return -1;
                }
                else
                {
                    int e = first.element;
                    first = first.next;
                    size = size - 1;
                    if (isEmpty())
                        last = null;
                    return e;
                }
            }

            public int RemoveLast()
            {
                if (isEmpty())
                {
                    Console.WriteLine("List is Empty");
                    return -1;
                }
                Node p = first;
                int i = 1;
                while (i < size - 1)
                {
                    p = p.next;
                    i = i + 1;
                }
                last = p;
                p = p.next;
                int e = p.element;
                last.next = null;
                size = size - 1;
                return e;
            }

            public int RemoveAny(int position)
            {
                if (position <= 0 || position >= size - 1)
                {
                    Console.WriteLine("Invalid Position");
                    return -1;
                }
                Node p = first;
                int i = 1;
                while (i < position - 1)
                {
                    p = p.next;
                    i = i + 1;
                }
                int e = p.next.element;
                p.next = p.next.next;
                size = size - 1;
                return e;
            }
            /// <summary>
            /// Search linkedlist by key
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public int Search(int key)
            {
                Node p = first;
                int index = 0;
                while (p != null)
                {
                    if (p.element == key)
                        return index;
                    p = p.next;
                    index = index + 1;
                }
                return -1;
            }
        }
        #endregion

        #region Lexicographically
        /// <summary>
        /// Write a program, which compares two arrays of type char lexicographically 
        /// (character by character) and checks, which one is first in the lexicographical order.
        /// </summary>
        public static class LexicographicallyClass
        {
            public static string Lexicographically(string inputArr1, string inputArr2)
            {

                char[] arr1 = inputArr1.ToCharArray();
                char[] arr2 = inputArr2.ToCharArray();
                var results = string.Empty;

                int i = 0;
                int j = 0;
                bool equal = false;

                while (i < arr1.Length && j < arr2.Length)
                {
                    if (arr1[i] > arr2[j])
                    {

                        equal = false;
                        break;
                    }
                    else if (arr1[i] < arr2[j])
                    {

                        equal = false;
                        break;
                    }
                    else
                    {
                        equal = true;
                    }

                    i++;
                    j++;
                }

                if (equal == true)
                {
                    if (arr1.Length < arr2.Length)
                    {
                        results = inputArr1;
                    }
                    else if (arr1.Length > arr2.Length)
                    {
                        results = inputArr2;
                    }
                    else
                    {
                        results = "No difference";
                    }
                }
                return results;
            }
        }
        #endregion

        #region FindTheLongestSubsequeanceOfEqualElements
        /// <summary>
        /// Write a program, which finds the longest sequence of equal string
        /// elements in a matrix.A sequence in a matrix we define as a set of
        /// neighbor elements on the same row, column or diagonal.
        /// </summary>
        public class FindTheLongestSubsequeanceOfEqualElementsClass
        {
            static string[,]? matrix;
            public static void FindTheLongestSubsequeanceOfEqualElements()
            {
                // Initialize the matrix
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());

                matrix = new string[n, m];

                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    string[] transformation = input.Split(' ');
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = transformation[j];
                    }

                }

                // Find the longest sequence of equal strings
                Dictionary<string, int> sequence = new Dictionary<string, int>();
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int neighbourCount = LookupNeighbours(row, col);
                        if (neighbourCount == 0)
                        {
                            if (sequence.ContainsKey(matrix[row, col]))
                            {
                                sequence.Remove(matrix[row, col]);
                            }
                        }
                        else
                        {
                            if (sequence.ContainsKey(matrix[row, col]))
                            {
                                sequence[matrix[row, col]]++;
                            }
                            else
                            {
                                sequence.Add(matrix[row, col], 1);
                            }
                        }
                    }
                }

                var sortedDict = (from entry in sequence orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                KeyValuePair<string, int> element;
                int index = sortedDict.Count - 1;
                element = sortedDict.ElementAt(index);

                int repeats = element.Value;
                string str = element.Key;

                string result = "";
                for (int i = 1; i <= repeats; i++)
                {
                    result += " ";
                    result += str;
                }

                Console.WriteLine(result);

            }

            private static int LookupNeighbours(int x, int y)
            {
                int result = 0;
                for (int row = x - 1; row <= x + 1; row++)
                {
                    if (row < 0 || row > matrix.GetLength(0) - 1)
                    {
                        continue;
                    }
                    for (int col = y - 1; col <= y + 1; col++)
                    {
                        if (col < 0 || col > matrix.GetLength(1) - 1 || (row == x && col == y))
                        {
                            continue;
                        }
                        if (matrix[row, col] == matrix[x, y])
                        {
                            result++;
                        }
                    }
                }
                return result;
            }

        }
        #endregion

        #region FindSubsequenceOfGivenSum
        /// <summary>
        /// Write a program to find a sequence of neighbor numbers 
        /// in an array, which has a sum of certain number S. 
        /// Example: {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}.
        /// </summary>
        public class FindSubsequenceOfGivenSumClass
        {
            public static int[] FindSequenceOfGivenSum(int[] numbersArray, int sum)
            {
                long currentSum = 0;
                for (int currentEndIndex = 0; currentEndIndex < numbersArray.Length; currentEndIndex++)
                {
                    currentSum = 0;
                    for (int currentSumIndex = currentEndIndex; currentSumIndex >= 0; currentSumIndex--)
                    {
                        currentSum += numbersArray[currentSumIndex];
                        if (currentSum == sum)
                        {
                            PrintArray(currentSumIndex, currentEndIndex, numbersArray);
                            break;
                            //return;
                        }
                    }
                }
                Console.WriteLine("There is no sequence of given sum!");
                return numbersArray;
            }

            static void PrintArray(int startIndex, int endIndex, int[] array)
            {
                Console.WriteLine("Sequence of given sum is present:");
                Console.Write("{ ");
                for (int i = startIndex; i <= endIndex; i++)
                {
                    Console.Write("{0} ", array[i]);
                }
                Console.Write("}");
            }

        }
        #endregion

        #region Find3x3MatrixWithMaxSum
        /// <summary>
        /// Write a program, which creates a rectangular array with size of n by m
        /// elements.The dimensions and the elements should be read from the
        /// console.Find a platform with size of(3, 3) with a maximal sum.
        /// </summary>
        public class Find3x3MatrixWithMaxSumClass
        {
            private static int j;
            public static void Find3x3MatrixWithMaxSum()
            {
                int n = int.Parse(Console.ReadLine());
                int m = int.Parse(Console.ReadLine());

                int[,] matrix = new int[n, m];

                for (int i = 0; i < n; i++)
                {
                    string input = Console.ReadLine();
                    string[] transformation = input.Split(' ');
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = int.Parse(transformation[j]);
                    }

                }

                int currentSum = 0;
                int maxSum = 0;
                int maxSquareX = 0;
                int maxSquareY = 0;
                // find square
                for (int i = 0; i < n - 2; i++)
                {
                    for (int j = 0; j < m - 2; j++)
                    {
                        for (int i2 = i; i2 < i + 3; i2++)
                        {
                            for (int j2 = j; j2 < j + 3; j2++)
                            {
                                currentSum += matrix[i2, j2];
                            }
                        }

                        if (currentSum > maxSum)
                        {
                            maxSum = currentSum;
                            maxSquareX = j;
                            maxSquareY = i;
                        }
                        currentSum = 0;
                    }
                }
                // output
                for (int i2 = maxSquareY; i2 < maxSquareY + 3; i2++)
                {
                    for (int j2 = maxSquareX; j2 < maxSquareX + 3; j2++)
                    {
                        Console.Write(matrix[i2, j2] + " ");
                    }
                    Console.WriteLine();
                }

            }

        }
        #endregion
    }
}
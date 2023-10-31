namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //PascalTriangle();
            //LexicographicalComparison();
            MaximalSequenceOfIncreasingElements();
            MacSumOfSequentialElements();
        }

        static void PascalTriangle()
        {
            const int HEIGHT = 12;
            // Allocate the array in a triangle form
            long[][] triangle = new long[HEIGHT + 1][];
            for (int row = 0; row < HEIGHT; row++)
            {
                triangle[row] = new long[row + 1];
            }
            // Calculate the Pascal's triangle
            triangle[0][0] = 1;
            for (int row = 0; row < HEIGHT - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row + 1][col] += triangle[row][col];
                    triangle[row + 1][col + 1] += triangle[row][col];
                }
            }
            // Print the Pascal's triangle
            for (int row = 0; row < HEIGHT; row++)
            {
                Console.Write("".PadLeft((HEIGHT - row) * 2));
                for (int col = 0; col <= row; col++)
                {
                    Console.Write("{0,3} ", triangle[row][col]);
                }
                Console.WriteLine();
            }

        }

        static void LexicographicalComparison()
        {
            string inputArr1 = "Apple";
            string inputArr2 = "Windows";

            char[] arr1 = inputArr1.ToCharArray();
            char[] arr2 = inputArr2.ToCharArray();

            int i = 0;
            int j = 0;
            bool equal = false;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] > arr2[j])
                {
                    Console.WriteLine(inputArr2);
                    equal = false;
                    break;
                }
                else if (arr1[i] < arr2[j])
                {
                    Console.WriteLine(inputArr1);
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
                    Console.WriteLine(inputArr1);
                }
                else if (arr1.Length > arr2.Length)
                {
                    Console.WriteLine(inputArr2);
                }
                else
                {
                    Console.WriteLine("No difference");
                }
            }
        }

        static void MaximalSequenceOfIncreasingElements()
        {
            string inputArrayOne = Console.ReadLine();
            char[] delimiter = new char[] { ',', ' ' };
            string[] inputOne = inputArrayOne.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[inputOne.Length];
            for (int i = 0; i < inputOne.Length; i++)
            {
                arr[i] = int.Parse(inputOne[i]);
            }

            int[] longestSubsequence = FindLongestSubsequence(arr);
            for (int i = 0; i < longestSubsequence.Length; i++)
            {
                Console.Write(longestSubsequence[i] + " ");
            }
            Console.WriteLine();

        }

        static void maximalSumPlatform()
        {
            //Declare and initialize the matrix
            int[,] matrix = {
                { 0, 2, 4, 0, 9, 5 },
                { 7, 1, 3, 3, 2, 1 },
                { 1, 3, 9, 8, 5, 6 },
                { 4, 6, 7, 9, 1, 0 }
                };
            // Find the maximal sum platform of size 2 x 2
            long bestSum = long.MinValue;
            int bestRow = 0;
            int bestCol = 0;
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
            // Print the result
            Console.WriteLine("The best platform is:");
            Console.WriteLine(" {0} {1}",
            matrix[bestRow, bestCol],
            matrix[bestRow, bestCol + 1]);
            Console.WriteLine(" {0} {1}",
            matrix[bestRow + 1, bestCol],
            matrix[bestRow + 1, bestCol + 1]);
            Console.WriteLine("The maximal sum is: {0}", bestSum);
            Console.ReadLine();
        }

        /// <summary>
        /// 07. Write a program, which reads from the console two 
        /// integer numbers N and K (K<N) and array of N integers. 
        /// Find those K consecutive elements in the array, which have maximal sum.
        /// </summary>
        static void MacSumOfSequentialElements()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string input = Console.ReadLine();
            string[] transformedInput = input.Split(' ');
            for (int i = 0; i < transformedInput.Length; i++)
            {
                arr[i] = int.Parse(transformedInput[i]);
            }

            //get max array
            int currentSum = 0;
            int maxIndex = 0;
            int maxSum = 0;
            int maxArrayElementsCount = 1;
            for (int i = 0; i <= n - k; i++)
            {
                int j = i;
                for (; j < i + k; j++)
                {
                    currentSum += arr[j];
                }

                if (currentSum > maxSum)
                {
                    maxIndex = i;
                    maxSum = currentSum;
                    maxArrayElementsCount = j - i;
                }
                currentSum = 0;
            }

            for (int i = maxIndex; i < maxIndex + maxArrayElementsCount; i++)
            {
                if (i != maxIndex + maxArrayElementsCount - 1)
                {
                    Console.Write(arr[i] + " ");
                }
                else
                {
                    Console.Write(arr[i]);
                }
            }

        }

        private static int[] FindLongestSubsequence(int[] arr)
        {
            int[] len = new int[arr.Length];
            len[0] = 1;
            for (int x = 1; x < arr.Length; x++)
            {
                int max = 0;
                for (int prev = 0; prev < x; prev++)
                {
                    if (arr[prev] < arr[x])
                    {
                        int current = len[prev];
                        if (current > max)
                        {
                            max = current;
                        }
                    }
                }
                len[x] = 1 + max;
            }

            int maxLength = len.Max();
            int[] longestSubsequence = new int[maxLength];
            int maxLengthIndex = 0;
            for (int i = len.Length - 1; i >= 0; i--)
            {
                if (len[i] == maxLength)
                {
                    longestSubsequence[maxLength - 1] = arr[i];
                    maxLengthIndex = i;
                    break;
                }
            }

            int currentIndex = maxLengthIndex - 1;
            int currentMaxIndex = maxLengthIndex;
            int sequenceIndex = maxLength - 2;
            while (true)
            {
                if (sequenceIndex == -1 || currentIndex == -1)
                {
                    break;
                }
                if (len[currentIndex] == len[currentMaxIndex] - 1)
                {
                    longestSubsequence[sequenceIndex] = arr[currentIndex];
                    sequenceIndex--;
                    currentMaxIndex = currentIndex;
                }
                currentIndex--;
            }

            return longestSubsequence;
        }

        private static int[] ProcessInput()
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int[] arr = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }


    }

}
    
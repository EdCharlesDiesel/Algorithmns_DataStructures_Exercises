namespace SubsequenceWithMaxSum
{
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
}
namespace FindSubsequenceOfGivenSum
{
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
}
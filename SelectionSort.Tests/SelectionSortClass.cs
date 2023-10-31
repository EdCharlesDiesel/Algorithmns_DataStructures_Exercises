namespace SelectionSort
{
    /// <summary>
    /// Sorting an array means to arrange its elements in an increasing 
    /// (or decreasing) order. Write a program, which sorts an array 
    /// using the algorithm "selection sort".
    /// </summary>
    public static class SelectionSortClass
    {
        public static int[] SelectionSort(int[] numbers)
        {
            //int n = int.Parse(Console.ReadLine());
            //int[] numbers = new int[n];
            int[] resultsArray = new int[numbers.Length];
            //for (int i = 0; i < n; i++)
            //{
            //    numbers[i] = int.Parse(Console.ReadLine());
            //}

            int min;
            for (int i = 0; i < numbers.Length; i++)
            {
                min = i;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                int temp = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = temp;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != numbers.Length - 1)
                {
                    resultsArray[i] = numbers[i];
                    //Console.Write("{0} ", numbers[i]);
                }
                else
                {
                    resultsArray[i] = numbers[i];
                }
            }

            return resultsArray;

        }
    }
}
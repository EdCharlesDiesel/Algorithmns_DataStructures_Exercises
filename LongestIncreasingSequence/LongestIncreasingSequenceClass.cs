namespace LongestIncreasingSequence
{
    /// <summary>
    /// Write a program, which finds the maximal sequence 
    /// of consecutively placed increasing integers. 
    /// Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
    /// </summary>
    public class LongestIncreasingSequenceClass
    {
        public static int[] LongestIncreasingSequence(int[] inputArrayOne)
        {
            //int[] arr = new int[inputOne.Length];

            //for (int i = 0; i < inputOne.Length; i++)
            //{
            //    arr[i] = int.Parse(inputOne[i]);
            //}

            int counter = 0;
            int maxSequence = 0;
            int index = 0;

            for (int i = 0; i < inputArrayOne.Length - 1; i++)
            {
                counter = 1;
                int j = i + 1;
                int k = i;

                while (inputArrayOne[k] < inputArrayOne[j])
                {
                    counter++;
                    j++;
                    k++;
                    if (j >= inputArrayOne.Length)
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
                  //  return inputArrayOne[i];
                }
                else
                {
                   // Console.WriteLine(arr[i]);
                }
            }


            return inputArrayOne;

        }
    }
}
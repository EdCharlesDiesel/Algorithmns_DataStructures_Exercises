namespace SearchingAlgorithmns
{
    public class Search
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
}
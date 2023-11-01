namespace SearchingAlgorithmns
{
    public class Search
    {
        public int linearsearch(int[] inputArray, int numberOfElements, int key)
        {
            int index = 0;
            while (index < numberOfElements)
            {
                if (inputArray[index] == key)
                    return index;
                index = index + 1;
            }
            return -1;
        }
    }
}
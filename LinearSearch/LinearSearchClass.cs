using LinearSearch;

namespace LinearSearch
{
    public class LinearSearchClass
    {
        public int linearsearch(int[] A, int n, int key)
        {
            int index = 0;
            while (index < n)
            {
                if (A[index] == key)
                    return index;
                index = index + 1;
            }
            return -1;
        }
    }
}

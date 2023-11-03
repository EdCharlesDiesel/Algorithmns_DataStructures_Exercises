namespace BubbleSort
{
    public class BubbleSortClass
    {
        public void Bubblesort(int[] array, int limit)
        {
            for (int pass = limit - 1; pass >= 0; pass--)
            {
                for (int i = 0; i < pass; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
    }
}
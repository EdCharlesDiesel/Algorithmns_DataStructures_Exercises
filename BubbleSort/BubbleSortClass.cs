namespace BubbleSort
{
    public class BubbleSortClass
    {
        public void Bubblesort(int[] array, int length)
        {
            for (int i = length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; i++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
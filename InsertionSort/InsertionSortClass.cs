namespace InsertionSort
{
    public class InsertionSortClass
    {
        public void InsertionSort(int[] array, int numberOfElements)
        {
            for (int i = 1; i < numberOfElements; i++)
            {
                int temp = array[i];
                int position = i;
                while (position > 0 && array[position - 1] > temp)
                {
                    array[position] = array[position - 1];
                    position = position - 1;
                }
                array[position] = temp;
            }
        }
    }
}